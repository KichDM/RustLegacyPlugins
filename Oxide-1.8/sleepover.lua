PLUGIN.Title = "Sleepover"
PLUGIN.Description = "Only players allowed will be able to respawn on other players bases"
PLUGIN.Version = "1.0.2"
PLUGIN.Author = "Reneb"


function PLUGIN:Init()
	local b, res = config.Read("sleepOver")
	self.Config = res or {}
	if (not b or not self.Config.Version or (self.Config.Version and self.Config.Version ~= "1.0")) then
		self:LoadDefaultConfig()
		if (res) then
			config.Save("sleepOver")
     	end
	end
	
	if (self.Config.groups) then
		self.groups = plugins.Find( "groups" )
	end
	if (self.Config.doorshare) then
		self.doorshare = plugins.Find( "doorshare" )
	end
	if (self.Config.factions) then
		self.factions = plugins.Find( "Factions_basics" )
	end
	if(not self.groups and not self.doorshare and not self.factions) then
		self.sleepover = true
		self.dataFile = util.GetDatafile("sleepover")
		local txt = self.dataFile:GetText()
		if (txt ~= "") then
			self.data = json.decode(txt)
		else
			self.data = {}
		end
		self:AddChatCommand("sleepover", self.cmdSleepOver )
	end
end
function PLUGIN:LoadDefaultConfig()
	self.Config.chatName = "SleepOver"
	self.Config.Version = "1.0"
	self.Config.doorshare = false
	self.Config.factions = false
	self.Config.groups = false
	self.Config.PunishByDeath = true
end
function PLUGIN:PostInit()
end



local AllStructures = util.GetStaticPropertyGetter( Rust.StructureMaster, "AllStructures") 
local Raycast = util.FindOverloadedMethod( UnityEngine.Physics, "RaycastAll", bf.public_static, { UnityEngine.Vector3,  UnityEngine.Vector3 } )
local SphereCastAll = util.FindOverloadedMethod( UnityEngine.Physics, "SphereCastAll", bf.public_static, { UnityEngine.Vector3, System.Single, UnityEngine.Vector3 } )
local NetCullRemove = util.FindOverloadedMethod(Rust.NetCull._type, "Destroy", bf.public_static, {UnityEngine.GameObject})
local RaycastStructure = util.FindOverloadedMethod(Rust.StructureMaster, "RayTestStructures", bf.public_static, { UnityEngine.Ray })
local SphereOverlap = util.FindOverloadedMethod( UnityEngine.Physics, "OverlapSphere", bf.public_static, { UnityEngine.Vector3, System.Single } )
local getStructureMasterOwnerId = util.GetFieldGetter(Rust.StructureMaster, "ownerID", true)

local LookDown = new(UnityEngine.Vector3)
LookDown.x = 0
LookDown.y = -1
LookDown.z = 0
local Ray = new(UnityEngine.Ray)
local function isOnStructure( netuser )
	local pos = netuser.playerClient.lastKnownPosition
	local arr = util.ArrayFromTable( System.Object, { pos, LookDown } , 2 )
	local hits = Raycast:Invoke(nil, arr)
	local tbl = cs.createtablefromarray( hits )
	if (#tbl == 0) then return end
    for i=2, #tbl do
		if(tostring(tbl[i].collider.gameObject.Name) == "__MESHBATCH_PHYSICAL_OUTPUT") then
			return true
		end
	end
	return false
end

function GetSleepingBag( netuser )
	local radius = 0.1
	local arr = util.ArrayFromTable( System.Object, { netuser.playerClient.lastKnownPosition, radius , LookDown } , 3 )
	cs.convertandsetonarray( arr, 1, radius, System.Single._type )
	local hits = SphereCastAll:Invoke(nil, arr)
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

local function FindStructureMaster( netuser )
	
	Ray.origin = netuser.playerClient.lastKnownPosition
	Ray.direction = LookDown
	local arr = util.ArrayFromTable( System.Object, { Ray } , 1 )
	local hits = RaycastStructure:Invoke(nil, arr)
	local tbl = cs.createtablefromarray( hits )
	if (#tbl == 0) then return end
	for k,v in pairs(tbl) do
		return v
	end
	return false
end

function RemoveObject(object)
	if object.name == "name" then return end
	if object == "GameObject" then return end
    local objs = util.ArrayFromTable(cs.gettype("System.Object"), {object})
    cs.convertandsetonarray( objs, 0, object , UnityEngine.GameObject._type )
    NetCullRemove:Invoke(nil, objs) 
end

function PLUGIN:Save()
	self.dataFile:SetText( json.encode( self.data ) )
	self.dataFile:Save()
end
function PLUGIN:cmdSleepOver(netuser,cmd,args)
	local userid = tostring(rust.GetUserID(netuser))
	if(not args[1]) then
		rust.SendChatToUser(netuser, self.Config.chatName, "List of SleepOvers:")
		if(not self.data[userid]) then self.data[userid] = {} end
		for targetid,name in pairs(self.data[userid]) do
			rust.SendChatToUser(netuser, self.Config.chatName, name)
		end
		rust.SendChatToUser(netuser, self.Config.chatName, "/sleepover add/remove \"NAME\"")
		return
	else
		local action = args[1]
		if(not args[2]) then
			rust.SendChatToUser(netuser, self.Config.chatName, "/sleepover add/remove \"NAME\"")
			return
		end
		
		if(action == "add") then
			print("here4")
			local found, targetuser = rust.FindNetUsersByName( args[2] )
			if(not found) then rust.SendChatToUser(netuser, self.Config.chatName, "No users found with that name") return end
			local targetuserid = tostring( rust.GetUserID( targetuser ) )
			if(not self.data[userid]) then self.data[userid] = {} end
			self.data[userid][targetuserid] = targetuser.displayName
			rust.SendChatToUser(netuser, self.Config.chatName, targetuser.displayName .. " added to the sleepovers")
			self:Save()
		elseif(action == "remove") then
			local targetuserid, err = self:FindPlayerInSleepOver(args[2],userid)
			if(not targetuserid) then
				rust.SendChatToUser(netuser, self.Config.chatName, err)
				return
			end
			self.data[userid][targetuserid] = nil
			rust.SendChatToUser(netuser, self.Config.chatName, err .. " removed from the sleepovers")
			self:Save()
		else
			rust.SendChatToUser(netuser, self.Config.chatName, "/sleepover add/remove \"NAME\"")
		end
	end
end
function PLUGIN:FindPlayerInSleepOver(name,callerid)
	local targetuser = false
	local realname = false
	local potentials = {}
	for userid,targetname in pairs(self.data[callerid]) do
		if(string.find(string.lower(targetname),string.lower(name))) then
			potentials[userid] = targetname
		end
	end
	for userid,tname in pairs(potentials) do
		if(tname == name) then
			return userid, name
		end
		if(targetuser) then
			return false, "Multiple sleepovers with that name found"
		end
		targetuser = userid	
		realname = 	tname
	end
	if(not targetuser) then return false, "No sleepovers with that name found" end
	return targetuser, realname
end
function PLUGIN:OnSpawnPlayer(playerclient, usecamp, avatar)
	if(usecamp) then
		timer.NextFrame( function() 
			local netuser = playerclient.netUser
			if(isOnStructure(netuser)) then
				local structureMaster = FindStructureMaster(netuser)
				if(not structureMaster) then print("Couldnt find master for player respawn: " .. netuser.displayName ) end
				local masterid = tostring(getStructureMasterOwnerId(structureMaster))
				if( not self:isAllowedToSpawnHere( tostring(rust.GetUserID(netuser)), masterid ) ) then
					local bag = GetSleepingBag(netuser)
					if(bag) then
						RemoveObject(bag)
					else
						local pos = playerclient.lastKnownPosition
						print("SleepOver: " .. math.ceil(pos.x) .. " " .. math.ceil(pos.y) .. " " .. math.ceil(pos.z) .. " sleeping bag couldn't be found and removed")
					end
					if(self.sleepover) then
						rust.SendChatToUser(netuser, self.Config.chatName, "You are not allowed to respawn here! Good bye! (/sleepover)")
					elseif(self.groups) then
						rust.SendChatToUser(netuser, self.Config.chatName, "You are not allowed to respawn here! Good bye! (/groups)")
					elseif(self.factions) then
						rust.SendChatToUser(netuser, self.Config.chatName, "You are not allowed to respawn here! Good bye! (/factions)")
					elseif(self.doorshare) then
						rust.SendChatToUser(netuser, self.Config.chatName, "You are not allowed to respawn here! Good bye! (/doorshare)")
					end
					if(self.Config.PunishByDeath) then
						local controllable = playerclient.controllable
						local metabolism = controllable:GetComponent("Metabolism")
						metabolism:AddPoison(50000)
					end
				end
			end
		end)
	end	
end

function PLUGIN:isAllowedToSpawnHere( userid, ownerid )
	if(userid == ownerid) then return true end
	if(self.sleepover) then
		if(self.data[ownerid] and self.data[ownerid][userid]) then return true end
		return false
	end
	if(self.groups) then
		local ownergroup = self.groups:checkPlayerGroup(ownerid)
		local usergroup = self.groups:checkPlayerGroup(userid)
		if(ownergroup ~= 0 and ownergroup == usergroup) then
			return true
		end
	end
	if(self.factions) then
		if(self.factions:inSameFaction(ownerid,userid)) then
			return true
		end
	end
	if(self.doorshare) then
		self.DoorShareDataFile = util.GetDatafile( "doorshare" )
		local txt = self.DoorShareDataFile:GetText()
		if (txt ~= "") then
			self.DoorShareData = json.decode( txt )
		else
			self.DoorShareData = {}
		end
		local sharedata = self.DoorShareData[ ownerid ]
		if (sharedata) then
			if (sharedata.Allowed) then 
				if (sharedata.Allowed[ userid ]) then 
					return true
				end
			end
		end
	end
	return false
end

function PLUGIN:SendHelpText( netuser )
	if(self.sleepover) then
		rust.SendChatToUser(netuser, self.Config.chatName, "/sleepover - to manage the players that are allowed to respawn on your buildings")
	end
end