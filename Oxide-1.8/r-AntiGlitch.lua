PLUGIN.Title = "r-AntiGlitch"
PLUGIN.Description = "Blocks multiple glitchs: PillarBarricade, PillarStash, Box-SleepingBag Foundation, Multiple Ramps on same spot"
PLUGIN.Version = "1.3"
PLUGIN.Author = "Reneb"


function PLUGIN:Init()
	local b, res = config.Read("r-AntiGlitch")
	self.Config = res or {}
	if (not b or not self.Config.Version or (self.Config.Version and self.Config.Version ~= "1.3")) then
		self:LoadDefaultConfig()
		if (res) then
			config.Save("r-AntiGlitch")
     	end
	end
	self.DataFile = util.GetDatafile( "RockGlitchHouses" )
	local txt = self.DataFile:GetText()
	if (txt ~= "") then
		self.RockGlitch = json.decode( txt )
	else
		print("Anti RockGlitch: Couldnt load RockGlitch database, creating a new one.")
		self.RockGlitch = {}
	end
	self:AddChatCommand("rg",self.cmdRockglitch)
	self:AddChatCommand("rgtp",self.cmdRockglitchtp)
	self:AddChatCommand("rgreset",self.cmdRockglitchreset)
end


function PLUGIN:LoadDefaultConfig()
	self.Config.chatName = "Anti-Glitch"
	self.Config.Version = "1.3"
	self.Config.AntiFoundationGlitch = true
	self.Config.AntiPillarStash = true
	self.Config.AntiPillarBarricade = true
	self.Config.AntiRampStack = true
	self.Config.AntiRampStackMaxStack = 2
	self.Config.AntiRampGlitch = true
	self.Config.AntiWolfAndBearGlitch = true
	self.Config.SendNotificationsToUsers = true
	
	
	self.Config.AntiRockGlitch = true
	self.Config.AntiRockGlitch_PunishByDeath = true
	self.Config.AntiRockGlitch_NotifyAdmins = true
	self.Config.AntiRockGlitch_NotifyInConsole = true
	self.Config.AntiRockGlitch_DestroySleepingBag = true
	self.Config.AntiRockGlitch_DetectIfRockHouse = true
end
function PLUGIN:PostInit()
end
local AllStructures = util.GetStaticPropertyGetter( Rust.StructureMaster, "AllStructures") 
local Raycast = util.FindOverloadedMethod( UnityEngine.Physics, "RaycastAll", bf.public_static, { UnityEngine.Vector3,  UnityEngine.Vector3 } )
local SphereCastAll = util.FindOverloadedMethod( UnityEngine.Physics, "SphereCastAll", bf.public_static, { UnityEngine.Ray, System.Single, System.Single } )
local NetCullRemove = util.FindOverloadedMethod(Rust.NetCull._type, "Destroy", bf.public_static, {UnityEngine.GameObject})
local RaycastStructure = util.FindOverloadedMethod(Rust.StructureMaster, "RayTestStructures", bf.public_static, { UnityEngine.Ray })
local SphereOverlap = util.FindOverloadedMethod( UnityEngine.Physics, "OverlapSphere", bf.public_static, { UnityEngine.Vector3, System.Single } )
local GetComponents, SetComponents = typesystem.GetField( Rust.StructureMaster, "_structureComponents", bf.private_instance )
local StructureComponentType = cs.gettype( "StructureComponent+StructureComponentType, Assembly-CSharp" )
typesystem.LoadEnum(StructureComponentType, "StructureComponentTypeEnum" )
local RaycastGlitch = util.FindOverloadedMethod( UnityEngine.Physics, "RaycastAll", bf.public_static, { UnityEngine.Vector3,  UnityEngine.Vector3 } )
cs.registerstaticmethod( "tmp", RaycastGlitch )
local RaycastAll = tmp
tmp = nil
local SphereCastAllGlitch = util.FindOverloadedMethod( UnityEngine.Physics, "SphereCastAll", bf.public_static, { UnityEngine.Vector3, System.Single, UnityEngine.Vector3 } )

local LookDown = new(UnityEngine.Vector3)
LookDown.x = 0
LookDown.y = -1
LookDown.z = 0
local LookUp = new(UnityEngine.Vector3)
LookUp.x = 0
LookUp.y = 1
LookUp.z = 0
local lookuprampglitchdist = 1
local rampglitchradius = 2.5
local RayDown = new(UnityEngine.Ray)
RayDown.direction = LookDown

local Ray = new(UnityEngine.Ray)
local lastshot = false

function RemoveObject(object)
	if object.name == "name" then return end
	if object == "GameObject" then return end
    local objs = util.ArrayFromTable(cs.gettype("System.Object"), {object})
    cs.convertandsetonarray( objs, 0, object , UnityEngine.GameObject._type )
    NetCullRemove:Invoke(nil, objs) 
end

function GetStructureMaster( pos )
	RayDown.origin = pos
	local arr = util.ArrayFromTable( System.Object, { RayDown } , 1 )
	local hits = RaycastStructure:Invoke(nil, arr)
	local tbl = cs.createtablefromarray( hits )
	for k,v in pairs(tbl) do
		return v
	end
	return false
end
function TraceEyesUp( pos, lookfrom )
	pos.y = pos.y - lookfrom
	local hits = RaycastAll( pos, LookUp )
	local tbl = cs.createtablefromarray( hits )
    if (#tbl == 0) then return false end
	local rock = false
    for i=1, #tbl do
		if(tbl[i].collider.GameObject.Name == "") then
			rock = tbl[i].distance
		end
    end
	return rock
end

function TraceEyesDown( pos, lookfrom )
	pos.y = pos.y + lookfrom
    local hits = RaycastAll( pos, LookDown )
	local tbl = cs.createtablefromarray( hits )
    if (#tbl == 0) then 
		return 
	end
	local terrain = false
	local rock = false
	local hbhit = false
    for i=1, #tbl do
		if(tbl[i].collider.GameObject.Name == "") then
			rock = tbl[i].distance
		elseif(tbl[i].collider.GameObject.Name == "Terrain") then
        	terrain = tbl[i].distance
		end
    end
	return terrain, rock
end
function GetSleepingBag( netuser )
	local radius = 0.5
	local coords = netuser.playerClient.lastKnownPosition
	coords.y = coords.y + 1
	local arr = util.ArrayFromTable( System.Object, { coords, radius , LookDown } , 3 )
	cs.convertandsetonarray( arr, 1, radius, System.Single._type )
	local hits = SphereCastAllGlitch:Invoke(nil, arr)
    local tbl = cs.createtablefromarray( hits )
    if (#tbl == 0) then return end
	local bag = false
    for i=1, #tbl do
		if(tostring(tbl[i].collider.gameObject.Name) == "SleepingBagA(Clone)") then
			bag = tbl[i].collider.gameObject
		end
    end
	return bag
end


function PLUGIN:GetConnectedRamps( master, pos )
	local hashset = GetComponents( master )
	local count = 0
    local it = hashset:GetEnumerator()
    while (it:MoveNext()) do
		if(string.find(tostring(it.Current.name), "Ramp")) then
			if(it.Current.transform.position.x == pos.x and it.Current.transform.position.y == pos.y and it.Current.transform.position.z == pos.z ) then
				count = count + 1
			end
		end
    end
	return count
end

function PLUGIN:ModifyDamage(takedamage,damage)
	if(self.Config.AntiWolfAndBearGlitch) then
		if not (tostring(type(damage) ~= "userdata")) or not (tostring(type(takedamage) ~= "userdata")) then
			return
		end
		if(tostring(damage.status) == "IsDead: 2" and tostring(damage.damageTypes) == "damage_bullet: 2") then
			if(damage.victim.idMain.GameObject:GetComponent("HostileWildlifeAI")) then
				if(lastshot and lastshot == damage.victim.idMain) then
					RemoveObject(damage.victim.idMain.GameObject)
				end
				lastshot = damage.victim.idMain
			end
		end
	end
	return
end

function PLUGIN:OnPlaceStructure(structure,pos)
	if(string.find(tostring(structure.name), "Foundation")) then
		if(self.Config.AntiFoundationGlitch) then
			local radius = 3.5
			pos.y = pos.y + 2
			local arr = util.ArrayFromTable( System.Object, { pos, radius } , 2 )
			cs.convertandsetonarray( arr, 1, radius, System.Single._type )
			local colliders = SphereOverlap:Invoke(nil, arr)
			local tbl = cs.createtablefromarray( colliders )
			for k,v in pairs(tbl) do
				if(tostring(v.GameObject.Name) == "WoodBoxLarge(Clone)" or tostring(v.GameObject.Name) == "SleepingBagA(Clone)" or tostring(v.GameObject.Name) == "SmallStash(Clone)" or tostring(v.GameObject.Name) == "WoodBox(Clone)") then
					if(self.Config.SendNotificationsToUsers) then
						self:SendToUserByPos(v.GameObject.transform.position,"ERROR: Boxes or Sleeping Bags are too close to allow the creation of a Foundation")
					end
					return false
				end
			end
		end
	elseif(string.find(tostring(structure.name), "Pillar")) then
		if(self.Config.AntiPillarStash or self.Config.AntiPillarBarricade) then
			local radius = 0.2
			local arr = util.ArrayFromTable( System.Object, { pos, radius } , 2 )
			cs.convertandsetonarray( arr, 1, radius, System.Single._type )
			local colliders = SphereOverlap:Invoke(nil, arr)
			local tbl = cs.createtablefromarray( colliders )
			for k,v in pairs(tbl) do
				if(self.Config.AntiPillarStash and tostring(v.GameObject.Name) == "SmallStash(Clone)") then
					if(self.Config.SendNotificationsToUsers) then
						self:SendToUserByPos(v.GameObject.transform.position,"ERROR: Pillar stash is not allowed")
					end
					return false
				end
				if(self.Config.AntiPillarBarricade and tostring(v.GameObject.Name) == "Barricade_Fence_Deployable(Clone)") then
					if(self.Config.SendNotificationsToUsers) then
						self:SendToUserByPos(v.GameObject.transform.position,"ERROR: Pillar Barricade is not allowed")
					end
					return false
				end
			end
		end
	elseif(string.find(structure.name, "Ramp")) then
		if(self.Config.AntiRampStack or self.Config.AntiRampGlitch) then
			Ray.origin = pos
			if(self.Config.AntiRampStack) then
				Ray.direction = LookDown
				local arr = util.ArrayFromTable( System.Object, { Ray } , 1 )
				local mastersarr = RaycastStructure:Invoke(nil, arr)
				local masters = cs.createtablefromarray( mastersarr )
				for i,master in pairs(masters) do
					local numberoframpsonpos = self:GetConnectedRamps( master, pos )
					if(numberoframpsonpos >= self.Config.AntiRampStackMaxStack) then
						print("r-AntiGlitch: Trying to Ramp stack @ ",pos) 
						if(self.Config.SendNotificationsToUsers) then
							self:SendToUserByPos(pos,"ERROR: You are not allowed to stack more than " .. self.Config.AntiRampStackMaxStack .. " ramps" )
						end
						return false
					end
				end
			end
			if(self.Config.AntiRampGlitch) then
				Ray.direction = LookUp
				local arr = util.ArrayFromTable( System.Object, { Ray, rampglitchradius , lookuprampglitchdist } , 3 )
				cs.convertandsetonarray( arr, 1, rampglitchradius, System.Single._type )
				cs.convertandsetonarray( arr, 2, lookuprampglitchdist, System.Single._type )
				local hits = SphereCastAll:Invoke(nil, arr)
				local tbl = cs.createtablefromarray( hits )
				for i=1, #tbl do
					if(string.find(tostring(tbl[i].collider.GameObject.Name),"player_soldier")) then
						local netuser = tbl[i].collider:GetComponent( "Controllable" ).playerClient.netUser
						rust.SendChatToUser(netuser, "r-AntiGlitch", "Please move away, a Ramp can't be placed here")
						return false
					elseif(tostring(tbl[i].collider.GameObject.Name) == "SleepingBagA(Clone)") then
						self:SendToUserByPos(pos,"You are not allowed to build a sleeping bag under a Ramp")
						return false
					end
				end
			end
		end
	end
end

function PLUGIN:SendToUserByPos(pos,msg)
	local radius = 7
	local arr = util.ArrayFromTable( System.Object, { pos, radius } , 2 )
	cs.convertandsetonarray( arr, 1, radius, System.Single._type )
	local colliders = SphereOverlap:Invoke(nil, arr)
	local tbl = cs.createtablefromarray( colliders )
	for k,v in pairs(tbl) do
		if(string.find(tostring(v.GameObject.Name),"player_soldier")) then
			local netuser = v:GetComponent( "Controllable" ).playerClient.netUser
			rust.SendChatToUser(netuser, "r-AntiGlitch", msg)
		end
	end
end


function PLUGIN:OnSpawnPlayer(playerclient, usecamp, avatar)
	if(usecamp) then
		if(self.Config.AntiRockGlitch) then
			timer.NextFrame( function()
				local netuser = playerclient.netUser
				local pos = playerclient.lastKnownPosition
				local lookfrom = TraceEyesUp( pos, 0.5 )
				if(not lookfrom) then lookfrom = 100 end
				local terrain, rock = TraceEyesDown( pos, lookfrom + 0.5 )
				if(rock and terrain and rock < lookfrom and rock < terrain) then
					rust.SendChatToUser( netuser, "r-AntiGlitch", "WARNING: You are NOT allowed to put your sleeping bag under a rock")
					if(self.Config.AntiRockGlitch_NotifyAdmins) then
						self:SendToAdmins("[color #FF4444]" .. netuser.displayName .. " has respawned under a rock")
					end
					if(self.Config.AntiRockGlitch_NotifyInConsole) then
						print("r-AntiGlitch: " .. netuser.displayName .. " has respawned under a rock")
					end
					local cpos = playerclient.lastKnownPosition
					local bad = false
					if(self.Config.AntiRockGlitch_DestroySleepingBag) then
						bag = GetSleepingBag(netuser)
						if(bag) then
							print("r-AntiGlitch: " .. math.ceil(cpos.x) .. " " .. math.ceil(cpos.y) .. " " .. math.ceil(cpos.z) .. " sleeping bag was removed")
							RemoveObject(bag)
						else
							print("r-AntiGlitch: " .. math.ceil(cpos.x) .. " " .. math.ceil(cpos.y) .. " " .. math.ceil(cpos.z) .. " sleeping bag couldn't be found")
						end
					end
					local master = false
					if(self.Config.AntiRockGlitch_DetectIfRockHouse) then
						master = GetStructureMaster(cpos)
						if(master) then
							self:SendToAdmins("Rock house detected, say /rg to see the list")
							print("r-AntiGlitch: " .. math.ceil(cpos.x) .. " " .. math.ceil(cpos.y) .. " " .. math.ceil(cpos.z) .. " is a rock house")
						end
					end
					local tbl = {}
					tbl.name = netuser.displayName
					tbl.steamid = tostring(rust.GetLongUserID(netuser))
					if(master) then tbl.house = true end
					tbl.x = cpos.x
					tbl.y = cpos.y
					tbl.z = cpos.z
					table.insert(self.RockGlitch,tbl)
					self:Save()
					if(self.Config.AntiRockGlitch_PunishByDeath) then
						local controllable = playerclient.controllable
						local metabolism = controllable:GetComponent("Metabolism")
						metabolism:AddPoison(50000)
					end
				end
			end)
		end
	end
end
function PLUGIN:SendToAdmins(msg)
	for _, targetuser in pairs( rust.GetAllNetUsers() ) do
		if(targetuser:CanAdmin()) then
			rust.SendChatToUser(targetuser, self.Config.chatName, msg)
		end
	end
end
function PLUGIN:cmdRockglitchreset(netuser,cmd,args)
	if(not netuser:CanAdmin()) then return end
	self.RockGlitch = {}
	self:Save()
	rust.SendChatToUser(netuser, "Anti Rock Glitch", "Anti Rock Glitch database has been resetted")
end
function PLUGIN:cmdRockglitchtp(netuser,cmd,args)
	if(not netuser:CanAdmin()) then return end
	if(not args[1]) then return end
	
	local start = tonumber(args[1])
	if(self.RockGlitch[start]) then
		local data = self.RockGlitch[start]
		local coords = netuser.playerClient.lastKnownPosition
		coords.x = data.x
		coords.y = data.y
		coords.z = data.z
		rust.ServerManagement():TeleportPlayer( netuser.playerClient.netPlayer, coords )
		rust.SendChatToUser(netuser, "Anti Wall Loot", start .. " - " .. data.name .. " - " .. data.steamid)
	end
end
function PLUGIN:cmdRockglitch(netuser,cmd,args)
	if(not netuser:CanAdmin()) then return end
	if(not args[1]) then
		local count = self:CountWL()
		for o=0, 19 do
			local data = self.RockGlitch[count-o]
			if(not data) then break end
			if(data.house) then
				rust.SendChatToUser(netuser, "Anti Wall Loot", (count-o) .. " - " .. data.name .. " - " .. data.steamid .. " - Rock House Detected")
			else
				rust.SendChatToUser(netuser, "Anti Wall Loot", (count-o) .. " - " .. data.name .. " - " .. data.steamid)
			end
		end
	else
		local start = tonumber(args[1])
		for o=0, 19 do
			local data = self.RockGlitch[start-o]
			if(not data) then break end
			if(data.house) then
				rust.SendChatToUser(netuser, "Anti Wall Loot", (start-o) .. " - " .. data.name .. " - " .. data.steamid .. " - Rock House Detected")
			else
				rust.SendChatToUser(netuser, "Anti Wall Loot", (start-o) .. " - " .. data.name .. " - " .. data.steamid)
			end
		end
	end
end
function PLUGIN:CountWL()
	local count = 0
	for i=1, #self.RockGlitch do
		count = count + 1
	end
	return count
end
function PLUGIN:Save()
	self.DataFile:SetText( json.encode( self.RockGlitch ) )
	self.DataFile:Save()
end