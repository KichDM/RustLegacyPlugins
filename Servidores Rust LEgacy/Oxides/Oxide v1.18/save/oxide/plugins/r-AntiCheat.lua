PLUGIN.Title = "r-AntiCheat"
PLUGIN.Description = "Anti Speed & Walk Speed & Fly & Super Jump Hacks & much more"
PLUGIN.Author = "Reneb"
PLUGIN.Version = "1.5.4"

function util.FindOverloadedMethodByRef( typ, method, bindingFlags, typeList )
typ = typesystem.TypeFromMetatype( typ )
    local methods = typ:GetMethods( bindingFlags )
    if (methods.Length == 0) then
        error( "Tried to find overloaded method '" .. name .. "' on type '" .. typ.Name .. "', no candidates found!" )
        return
    end

    for i=1, methods.Length do
        local methodinfo = methods[i - 1]
        if (method and methodinfo.Name == method) then
            local plist = methodinfo:GetParameters()
            if (plist.Length == #typeList) then
                local found = true
                for j=1, plist.Length do
                    local paraminfo = plist[j - 1]
                    local othertype = typesystem.TypeFromMetatype( typeList[j] )
                    if (paraminfo.ParameterType ~= othertype) then
                        if (paraminfo.Name ~= "hit" and paraminfo.Name ~= "hitMergedMeshBatchInstance" and paraminfo.Name ~= "hitInstance" ) then
                            found = false
                            break
                        end
                    end
                end
                if (found) then return methodinfo end
            end
        end
    end
end


local RefParam2 = cs.gettype("UnityEngine.RaycastHit&, UnityEngine" )
local _RayCast = util.FindOverloadedMethod( UnityEngine.Physics, "Raycast", bf.public_static, { UnityEngine.Vector3, UnityEngine.Vector3, RefParam2 } )
cs.registerstaticmethod( "tmp", _RayCast )
local RayCast = tmp
tmp = nil
local SphereCastAll = util.FindOverloadedMethod( UnityEngine.Physics, "SphereCastAll", bf.public_static, { UnityEngine.Vector3, System.Single, UnityEngine.Vector3 } )
local LookDown = new(UnityEngine.Vector3)
LookDown.x = 0
LookDown.y = -1
LookDown.z = 0
local Ray = new(UnityEngine.Ray)
local GetBlueprints, SetBlueprints = typesystem.GetField( Rust.PlayerInventory, "_boundBPs", bf.private_instance )
local GetPlayersLooting, SetPlayersLooting = typesystem.GetField( Rust.Inventory, "_netListeners", bf.private_instance )

local typ1 = cs.gettype( "Facepunch.MeshBatch.MeshBatchPhysics, Facepunch.MeshBatch" )
local RefParam2 = cs.gettype("UnityEngine.RaycastHit&, UnityEngine" )
local RefParam3 = cs.gettype("System.Boolean&, System" )
local RefParam4 = cs.gettype("Facepunch.MeshBatch.MeshBatchInstance&, Facepunch.MeshBatch" )
local _MeshBatchPhysicsGlitch = util.FindOverloadedMethodByRef( typ1, "Raycast", bf.public_static, { UnityEngine.Ray, RefParam2, RefParam3, RefParam4 } )
cs.registerstaticmethod( "tmp", _MeshBatchPhysicsGlitch )
local MeshBatchPhysics = tmp
tmp = nil

function PLUGIN:Init()
	self.DataFile = util.GetDatafile( "r-anticheat" )
	local txt = self.DataFile:GetText()
	if (txt ~= "") then
		self.Data = json.decode( txt )
	else
		self.Data = {}
	end

	local b, res = config.Read("r-anticheat")
	self.Config = res or {}
	if (not b or not self.Config.Version or (self.Config.Version and self.Config.Version ~= "1.5" )) then
		self:LoadDefaultConfig()
		if (res) then
			config.Save("r-anticheat")
     	end
	end
	
	self.oxminPlugin = cs.findplugin("oxmin")
	self.FlagsPlugin = cs.findplugin("flags")
	self.Timers = {}
	self.Fallers = {}
	self.DynData = {}
	self.Admins = {}
	self.DisconnectionLocations = {}
	self.SuspiciousPlayer = {}
	self:AddChatCommand("ac_check", self.cmdCheck)
	self:AddChatCommand("ac_checkall", self.cmdCheckAll)
	self:AddChatCommand("ac_reset", self.cmdReset)
	for _, snetuser in pairs( rust.GetAllNetUsers() ) do
		local userID = rust.GetUserID( snetuser )
		if(not self.Data[userID]) then
			self.Data[userID] = {}
			self.Data[userID].timeleft = self.Config.timeofcheck
		end
		if(not self.DynData[userID]) then self.DynData[userID] = {} end
		self.DynData[userID].count = 0
		self.DynData[userID].tick = 0
		self.DynData[userID].jump = 0
		self.DynData[userID].countfly = 0
		if(snetuser.playerClient.lastKnownPosition) then
			self.DynData[userID].lastknownposition = snetuser.playerClient.lastKnownPosition
			self.DynData[userID].lastdist = 0
		end
		if(self.Timers[userID]) then
			self.Timers[userID]:Destroy()
			self.Timers[userID] = nil
		end
		if(self.Data[userID].timeleft > 0 or self.Config.PermanentCheck ) then
			self.Timers[userID] = timer.Repeat( 2, function() self:EverySecond(snetuser,userID) end )
		end
		if(self:isAdmin(snetuser)) then
			self.Admins[snetuser] = true
		end
	end	
end

function PLUGIN:PostInit()
	self.ebs = plugins.Find("EnhancedBanSystem")
end

function PLUGIN:Unload()
	for k,v in pairs(self.Timers) do
		self.Timers[k]:Destroy()
	end
end
function PLUGIN:cmdCheck( netuser, cmd, args )
    if (not(args[1])) then
        return
    end
    if(not self:isAdmin(netuser)) then
		return
	end
    local b, targetuser = rust.FindNetUsersByName( args[1] )
    if (not b) then
        if (targetuser == 0) then
            rust.Notice( netuser, "No players found with that name!" )
        else
            rust.Notice( netuser, "Multiple players found with that name!" )
        end
        return
    end
    
	local userID = rust.GetUserID( targetuser )
	self.Data[userID].timeleft = self.Config.timeofcheck
	if(not self.DynData[userID]) then self.DynData[userID] = {} end
	self.DynData[userID].count = 0
	self.DynData[userID].tick = 0
	self.DynData[userID].jump = 0
	self.DynData[userID].countfly = 0
	self.DynData[userID].lastknownposition = targetuser.playerClient.lastKnownPosition
	self.DynData[userID].lastdist = 0
	if(self.Timers[userID]) then
		self.Timers[userID]:Destroy()
		self.Timers[userID] = nil
	end
	self.Timers[userID] = timer.Repeat( 2, function() self:EverySecond(targetuser,userID) end )
	rust.SendChatToUser( netuser, self.Config.NotifyInChatName, targetuser.displayName .. " will now be checked for hacks.")
end

function PLUGIN:cmdReset( netuser, cmd, args )
    if(not self:isAdmin(netuser)) then
		return
	end
	for uid, timer in pairs( self.Timers ) do
		self.Timers[uid]:Destroy()
		self.Timers[uid] = nil
	end
	self.Timers = {}
	self.Data = {}
	self:Save()
	for _, snetuser in pairs( rust.GetAllNetUsers() ) do
		local userID = rust.GetUserID( snetuser )
		self.Data[userID] = {}
		self.Data[userID].timeleft = self.Config.timeofcheck
		if(not self.DynData[userID]) then self.DynData[userID] = {} end
		self.DynData[userID].count = 0
		self.DynData[userID].tick = 0
		self.DynData[userID].jump = 0
		self.DynData[userID].countfly = 0
		self.DynData[userID].lastknownposition = snetuser.playerClient.lastKnownPosition
		self.DynData[userID].lastdist = 0
		if(self.Timers[userID]) then
			self.Timers[userID]:Destroy()
			self.Timers[userID] = nil
		end
		self.Timers[userID] = timer.Repeat( 2, function() self:EverySecond(snetuser,userID) end )
	end	
	rust.SendChatToUser( netuser, self.Config.NotifyInChatName, "I will now search check all players for potential hacks")
end

function PLUGIN:cmdCheckAll( netuser, cmd, args )
    if(not self:isAdmin(netuser)) then
		return
	end
	for uid, timer in pairs( self.Timers ) do
		self.Timers[uid]:Destroy()
		self.Timers[uid] = nil
	end
	for _, snetuser in pairs( rust.GetAllNetUsers() ) do
		local userID = rust.GetUserID( snetuser )
		self.Data[userID] = {}
		self.Data[userID].timeleft = self.Config.timeofcheck
		if(not self.DynData[userID]) then self.DynData[userID] = {} end
		self.DynData[userID].count = 0
		self.DynData[userID].tick = 0
		self.DynData[userID].jump = 0
		self.DynData[userID].countfly = 0
		self.DynData[userID].lastknownposition = snetuser.playerClient.lastKnownPosition
		self.DynData[userID].lastdist = 0
		if(self.Timers[userID]) then
			self.Timers[userID]:Destroy()
			self.Timers[userID] = nil
		end
		self.Timers[userID] = timer.Repeat( 2, function() self:EverySecond(snetuser,userID) end )
	end	
	rust.SendChatToUser( netuser, self.Config.NotifyInChatName, "I will now search check all players for hacks")
end

function PLUGIN:OnUserConnect( netuser )
	local userID = rust.GetUserID(netuser)
	if(not self.Data[userID]) then
		self.Data[userID] = {}
		self.Data[userID].timeleft = self.Config.timeofcheck
	end
	if(not self.DynData[userID]) then self.DynData[userID] = {} end
	self.DynData[userID].count = 0
	self.DynData[userID].tick = 0
	self.DynData[userID].jump = 0
	self.DynData[userID].countfly = 0
	if(netuser.playerClient.lastKnownPosition) then
		self.DynData[userID].lastknownposition = netuser.playerClient.lastKnownPosition
		self.DynData[userID].lastdist = 0
	end
	if(self.Timers[userID]) then
		self.Timers[userID]:Destroy()
		self.Timers[userID] = nil
	end
	if(self.Data[userID].timeleft > 0 or self.Config.PermanentCheck ) then
		self.Timers[userID] = timer.Repeat( 2, function() self:EverySecond(netuser,userID) end )
	end
	if(self:isAdmin(netuser)) then
		self.Admins[netuser] = true
	end
	if(self.Config.useAntiCeilingSpawnRemoval) then
		if(self.DisconnectionLocations[userID]) then
			timer.NextFrame( function()
				self:WaitForPosition(netuser,userID)
			end)
		end
	end
end
function PLUGIN:WaitForPosition(netuser,userid)
	if(not netuser or not netuser.playerClient) then
		return
	end
	if(netuser.playerClient.lastKnownPosition.x ~= 0) then
		timer.Once( 1, function() self:CheckSpawnLocation(netuser,userid) end )
	else
		timer.Once( 0.5, function() self:WaitForPosition(netuser,userid) end )
	end
end
function PLUGIN:CheckSpawnLocation(netuser,userid)
	local newpos = netuser.playerClient.lastKnownPosition
	local oldpos = self.DisconnectionLocations[userid]
	local deltay = oldpos.y - newpos.y
	if( deltay > 1 and deltay < 4.5 ) then
		local nvector = newpos
		nvector.x = newpos.x - oldpos.x
		nvector.y = newpos.y - oldpos.y
		nvector.z = newpos.z - oldpos.z
		if(nvector.x < 1 and nvector.z < 1) then
			Ray.origin = oldpos
			Ray.direction = nvector.normalized
			local rep,hits,boolrep,meshbatch = MeshBatchPhysics(Ray)
			if(meshbatch) then
				if(string.find(tostring(meshbatch.graphicalModel),"ceiling")) then
					if(self.Config.NotifyInChat) then
						rust.BroadcastChat(self.Config.NotifyInChatName, "[color #FFD630]" .. netuser.displayName .. " [color red]tried to go threw a ceiling!")
					elseif(self.Config.NotifyAdmins) then
						self:SendtoAdmins( "[color #FFD630]" .. netuser.displayName .. " [color red]tried to go threw a ceiling!" )
					end
					if(self.Config.NotifyInConsole) then
						print(self.Config.NotifyInChatName..": "..netuser.displayName.." tried to go threw a ceiling.")
					end
					if(self.Config.PunishForCeilingSpawnRemoval) then
						if(self.Config.PunishByBan) then
							rust.RunServerCommand("banid \"" .. tostring(rust.GetLongUserID( netuser )) .. "\" \"" .. tostring(netuser.displayName) .. "\" \"rCeilingHack\"")
							rust.BroadcastChat(self.Config.NotifyInChatName, "[color #FFD630]" .. netuser.displayName .. " [color red]tried to go threw a ceiling! [color #FF9933](Auto Banned)")
							netuser:Kick(NetError.Facepunch_Kick_Ban, true)
						elseif(self.Config.PunishByKick) then
							netuser:Kick(NetError.Facepunch_Kick_Ban, true)
							rust.BroadcastChat(self.Config.NotifyInChatName, "[color #FFD630]" .. netuser.displayName .. " [color red]tried to go threw a ceiling! [color #FF9933](Auto Kicked)")
						end
					end
				end
			end
		end
	end
end

function PLUGIN:OnUserDisconnect(networkplayer)
  local netuser = networkplayer:GetLocalData()
  if (not netuser or netuser:GetType().Name ~= "NetUser") then
    return
  end
  local userID = rust.GetUserID(netuser)
  if(self.Timers[userID]) then
		self.Timers[userID]:Destroy()
		self.Timers[userID] = nil
  end
  self.DisconnectionLocations[userID] = netuser.playerClient.lastKnownPosition
  self.DynData[userID] = {}
  self.Admins[netuser] = nil
  self:Save()
end
function PLUGIN:Save()
	self.DataFile:SetText( json.encode( self.Data ) )
	self.DataFile:Save()
end
function PLUGIN:CanContinue(netuser,userID)
	if(not userID) then
		return false
	end
	if(not netuser or netuser.playerClient == nil) then
		self.Timers[userID]:Destroy()
		self.Timers[userID] = nil
		return false
	end	
	if((self.Data[userID].timeleft < 1) and self.DynData[userID].count == 0 and not self.Config.PermanentCheck) then
		self.Timers[userID]:Destroy()
		self.Timers[userID] = nil
		print(self.Config.NotifyInChatName..": "..netuser.displayName.." was cleared from this plugin.")
		self:Save()
		return false
	end
	if(netuser:CanAdmin()) then
		self.Data[userID].timeleft = 0
		return false
	end
	return true
end
function PLUGIN:EverySecond(netuser,userID)
	if(not self:CanContinue(netuser,userID)) then
		return
	end
	local coords = netuser.playerClient.lastKnownPosition
	coords.y = coords.y - 1.5
	local notify = false
	local playerCoords = self.DynData[userID].lastknownposition
	local dist1 = 22
	local dist2 = 60
	if playerCoords.x ~= 0 then
		if(type(coords.x)~="number") or (type(playerCoords.x)~="number") then
			return
		end
		if(self.Config.useAntiSpeedhack) then
			dist = Rust.TransformHelpers.Dist2D( coords, playerCoords )
			if dist >= dist1 and dist < dist2 then
				if(self.DynData[userID].tick and self.DynData[userID].tick > (util.GetTime() - 3)) then
					self.DynData[userID].count = self.DynData[userID].count + 1
					self.DynData[userID].lastspeed = math.ceil(dist)
					self:Notify("[color #996600]" .. netuser.displayName.." moved "..math.ceil(dist).." meters in 2 seconds." )
				else
					self.DynData[userID].count = 0
				end
				self.DynData[userID].state = "running"
				self.DynData[userID].tick = util.GetTime()
			end
			if(self.Config.useAntiWallSpeedHack) then
				if(self:HasCharacter(netuser,userID)) then
					local character = self.DynData[userID].char
					local state = tostring(character.stateFlags.flags)
					if(self.DynData[userID].state and self.DynData[userID].state == "64" and state == "64" and dist > 14 and dist < 20) then
						if( (coords.y - playerCoords.y) > -10) then
							if(self.DynData[userID].tick and self.DynData[userID].tick > (util.GetTime() - 3)) then
								self.DynData[userID].count = self.DynData[userID].count + 1
								self.DynData[userID].lastspeed = math.ceil(dist)
								self:Notify("[color #996600]" .. netuser.displayName.." is walking too fast: "..math.ceil(dist).." meters in 2 seconds." )
							else
								self.DynData[userID].count = 0
							end
							self.DynData[userID].tick = util.GetTime()
						end
						
					end
					self.DynData[userID].state = state
				end
			end
		end
		if(self.Config.useAntiFlyhack or self.Config.useAntiJumphack) then
			boolResult, Rayhit = RayCast( coords , LookDown )
			if(boolResult) then
				if(Rayhit.distance > 10) then
					if(playerCoords.y) then
						local delta = playerCoords.y - coords.y
						if(delta < -5 and delta > - 40) then
							if(playerCoords.y < 1900) then
								if(self.Config.useAntiJumphack) then
									self:Notify("[color #996600]" .. netuser.displayName .. " made a SuperJump")
									if(self.DynData[userID].tick < (util.GetTime() - 600)) then
										self.DynData[userID].jump = 0
									end
									self.DynData[userID].jump = self.DynData[userID].jump + 1
									self.DynData[userID].tick = util.GetTime()
								end
							end
						elseif(delta >= -5 and delta < 10 and delta ~= 0) then
							if(self.Config.useAntiFlyhack) then
								if(self.DynData[userID].lastdist > 10) then
									if(not self:StandingOnBuilding(coords, 5)) then
										self:Notify("[color #996600]" .. netuser.displayName .. " is suspected of flyhacking")
										if(self.DynData[userID].tick and self.DynData[userID].tick < (util.GetTime() - 3)) then
											self.DynData[userID].countfly = 0
										end
										self.DynData[userID].countfly = self.DynData[userID].countfly + 1
										self.DynData[userID].tick = util.GetTime()
									end
								end
							end
						end
					end
				end
				self.DynData[userID].lastdist = Rayhit.distance
			end
		end
	end
	self.Data[userID].timeleft = self.Data[userID].timeleft - 2
	self.DynData[userID].lastknownposition = coords
	self:CheckForHacks(netuser,userID)
end
function PLUGIN:HasCharacter(netuser,userID)
	if(not self.DynData[userID].char) then
		local character = rust.GetCharacter(netuser)
		if(not character) then
			return false
		end
		self.DynData[userID].char = character
	end
	return true
end
function PLUGIN:StandingOnBuilding(coords, radius)
	local arr = util.ArrayFromTable( System.Object, { coords, radius , LookDown } , 3 )
	cs.convertandsetonarray( arr, 1, radius, System.Single._type )
	local hits = SphereCastAll:Invoke(nil, arr)
	local tbl = cs.createtablefromarray( hits )
	if (#tbl == 0) then return false end
	local smallestdistance = 100
	for i=1, #tbl do
		if(tostring(tbl[i].collider.gameObject.Name) ~= "HB Hit" and not string.find(tostring(tbl[i].collider.gameObject.Name),"player_soldier") and tbl[i].distance < smallestdistance) then
			smallestdistance = tbl[i].distance
		end
	end
	if(smallestdistance < 5) then
		return true
	end
	return false
end

	

function PLUGIN:CheckForHacks(netuser,userID)
	if(self.DynData[userID].count >= self.Config.SpeedDetectionsForPunish or self.DynData[userID].countfly >= self.Config.FlyDetectionsForPunish or self.DynData[userID].jump >= self.Config.JumpDetectionsForPunish) then
		if( self.Config.PunishByBan ) then
			
			if(self.DynData[userID].count >= self.Config.SpeedDetectionsForPunish) then
				local hack = ""
				if(self.DynData[userID].state ~= "64") then
					hack = "rSpeedHack"
				else
					if(not self.Data[userID].wshk and self.DynData[userID].lastspeed and self.DynData[userID].lastspeed < 20) then
						self.Data[userID].wshk = true
						self:SendtoAdmins(netuser.displayName .. " was kicked for speedwalk, next time will be a ban (this doesn't mean he cheats at 100%, yet)")
						netuser:Kick(NetError.Facepunch_Kick_Violation, true)	
						return false
					end
					if(self.DynData[userID].lastspeed) then
						hack = "rWalkSpeedHack ("..self.DynData[userID].lastspeed..")"
					else
						hack = "rWalkSpeedHack"
					end
					
				end
				rust.BroadcastChat(self.Config.NotifyInChatName, "[color #FFD630]" .. netuser.displayName .. " [color red]tried to cheat on this server! [color #FF9933](Auto Banned)")
				rust.RunServerCommand("banid \"" .. tostring(rust.GetLongUserID( netuser )) .. "\" \"" .. tostring(netuser.displayName) .. "\" \""..hack.."\"")
				print(netuser.displayName .. " has been auto banned for speedhacking ")	
				if(self.ebs) then
					local nargs = {}
					nargs[1] = netuser.networkPlayer.externalIP
					nargs[2] = hack
					self.ebs:cmdBan(false,nargs)
				end
			elseif(self.DynData[userID].countfly >= self.Config.FlyDetectionsForPunish) then
				rust.RunServerCommand("banid \"" .. tostring(rust.GetLongUserID( netuser )) .. "\" \"" .. tostring(netuser.displayName) .. "\" \"rFlyHack\"")
				print(netuser.displayName .. " has been auto banned for Flyhacking ")	
				if(self.ebs) then
					local nargs = {}
					nargs[1] = netuser.networkPlayer.externalIP
					nargs[2] = "rFlyHack"
					self.ebs:cmdBan(false,nargs)
				end
			else
				rust.RunServerCommand("banid \"" .. tostring(rust.GetLongUserID( netuser )) .. "\" \"" .. tostring(netuser.displayName) .. "\" \"rSuperJump\"")
				print(netuser.displayName .. " has been auto banned for Superjump ")
				if(self.ebs) then
					local nargs = {}
					nargs[1] = netuser.networkPlayer.externalIP
					nargs[2] = "rSuperJump"
					self.ebs:cmdBan(false,nargs)
				end
			end
			self.DynData[userID] = nil
			netuser:Kick(NetError.Facepunch_Kick_Ban, true)	
			return false
		elseif(self.Config.PunishByKick) then
			rust.BroadcastChat(self.Config.NotifyInChatName, netuser.displayName.." has been kicked for cheating in the server.")
			if(self.DynData[userID].count >= self.Config.SpeedDetectionsForPunish) then
				print(netuser.displayName .. " has been auto kicked for speedhacking ")	
			elseif(self.DynData[userID].countfly >= self.Config.FlyDetectionsForPunish) then
				print(netuser.displayName .. " has been auto kicked for Flyhacking ")	
			else
				print(netuser.displayName .. " has been auto kicked for Superjump ")	
			end
			self.DynData[userID] = nil
			netuser:Kick( NetError.Facepunch_Kick_RCON, true )
			return false
		end	
	end
	return true
end

function PLUGIN:OnStartCrafting( inventory, bp, amount, starttime )
	if(self.Config.useAntiBlueprintUnlocker) then
		local inv = inventory:GetComponent("PlayerInventory")
		local blueprints = GetBlueprints( inv )
		if(not blueprints:Contains(bp)) then
			local netuser = inventory:GetComponent( "Controllable" ).playerClient.netUser
			self:Notify("[color #FFD630]" .. netuser.displayName .. " is crafting something that he [color red]isn't allowed to craft! [color #FFD630](AutoBan)")
			if(self.Config.PunishForBlueprintUnlocker) then
				timer.Once(0.05, function() 
					rust.RunServerCommand("banid \"" .. tostring(rust.GetLongUserID( netuser )) .. "\" \"" .. tostring(netuser.displayName) .. "\" \"rBlueprintUnlocker\"")
					print(netuser.displayName .. " has been auto banned for using a Blueprint Unlocker ")	
					if(self.ebs) then
						local nargs = {}
						nargs[1] = netuser.networkPlayer.externalIP
						nargs[2] = "rBlueprintUnlocker"
						self.ebs:cmdBan(false,nargs)
					end
					netuser:Kick( NetError.Facepunch_Kick_RCON, true )
				end)
			end
		end
	end
end

function PLUGIN:Notify(msg)
	if (self.Config.NotifyInChat) then
		rust.BroadcastChat (self.Config.NotifyInChatName, msg)
	end
	if (self.Config.NotifyAdmins) then
		 self:SendtoAdmins(msg)
	end
	if (self.Config.NotifyInConsole) then
		 print(msg)
	end
end
function PLUGIN:SendtoAdmins(msg)
	for netuser,bool in pairs(self.Admins) do
		rust.SendChatToUser( netuser, self.Config.NotifyInChatName, msg )
	end
end
function PLUGIN:isAdmin(netuser)
	if(netuser:CanAdmin()) then return true end
	if(self.oxminPlugin and self.oxminPlugin:HasFlag( netuser, 3 )) then return true end
	if(self.FlagsPlugin and self.FlagsPlugin:HasFlag(tostring( rust.GetLongUserID(netuser) ), "kick" )) then return true end
	return false
end
function PLUGIN:LoadDefaultConfig()
	self.Config.NotifyInChatName = "r-AntiCheat"
	self.Config.Version = "1.5"
	self.Config.NotifyAdmins = true
	self.Config.NotifyInChat = false
	self.Config.NotifyInConsole = true
	self.Config.PunishByKick = false
	self.Config.PunishByBan = true
	self.Config.useAntiSpeedhack = true
	self.Config.useAntiFlyhack = true
	self.Config.useAntiBlueprintUnlocker = true
	self.Config.useAntiWallSpeedHack = true
	self.Config.useAntiJumphack = true
	self.Config.useAntiAirdropAutoLoot = true
	self.Config.useAntiCeilingSpawnRemoval = true
	self.Config.PunishForCeilingSpawnRemoval = true
	self.Config.AirdropAutoLootDetectionsForPunish = 2
	self.Config.PunishForAirdropAutoLoot = true
	self.Config.SpeedDetectionsForPunish = 3
	self.Config.FlyDetectionsForPunish = 4
	self.Config.PunishForBlueprintUnlocker = true
	self.Config.JumpDetectionsForPunish = 2
	self.Config.PermanentCheck = false
	self.Config.timeofcheck = 1800
end

function PLUGIN:OnItemRemoved(inventory, slot, item )
	if(self.Config.useAntiAirdropAutoLoot and inventory.name == "SupplyCrate(Clone)") then
		local hashset = GetPlayersLooting( inventory )
		local netuser = false
		local it = hashset:GetEnumerator()
		while (it:MoveNext()) do
			local networkplayer = it.Current
			netuser = networkplayer:GetLocalData()
		end
		if(netuser and netuser.playerClient) then
			local pos = netuser.playerClient.lastKnownPosition
			if(Rust.TransformHelpers.Dist2D(pos,inventory.transform.position) > 10) then
				local userid = rust.GetUserID( netuser )
				if(self.SuspiciousPlayer[userid]) then
					self.SuspiciousPlayer[userid] = self.SuspiciousPlayer[userid] + 1
				else
					self.SuspiciousPlayer[userid] = 1 
				end
				if(self.SuspiciousPlayer[userid] >= self.Config.AirdropAutoLootDetectionsForPunish) then
					self:Notify("[color #996600]" .. netuser.displayName .. " used an Auto Loot hack (Auto Ban)")
					if(self.Config.PunishForAirdropAutoLoot) then
						if(self.Config.PunishByBan) then
							if(self.ebs) then
								local nargs = {}
								nargs[1] = netuser.networkPlayer.externalIP
								nargs[2] = "rAutoLoot"
								self.ebs:cmdBan(false,nargs)
							end
							rust.RunServerCommand("banid \"" .. tostring(rust.GetLongUserID( netuser )) .. "\" \"" .. tostring(netuser.displayName) .. "\" \"rAutoLoot\"")
							rust.BroadcastChat(self.Config.NotifyInChatName, "[color #996600]" .. netuser.displayName .. " has been detected as an Auto-Looter! (Auto Banned)")
							netuser:Kick(NetError.Facepunch_Kick_Ban, true)	
						elseif(self.Config.PunishByKick) then
							rust.BroadcastChat(self.Config.NotifyInChatName, "[color #996600]" .. netuser.displayName .. " has been detected as an Auto-Looter! (Auto kicked)")
							netuser:Kick(NetError.Facepunch_Kick_Ban, true)	
						end
					end
				end
			end
		end
	end
end

