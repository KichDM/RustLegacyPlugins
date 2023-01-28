PLUGIN.Title = "Factions"
PLUGIN.Description = "Create your own factions"
PLUGIN.Author = "Reneb"
PLUGIN.Version = "1.1.1"

function PLUGIN:Init()
	self.DataFileF = util.GetDatafile( "Factions-factions" )
	self.DataFileU = util.GetDatafile( "Factions-users" )
	self.DataFileD = util.GetDatafile( "Factions-data" )
	local txt = self.DataFileF:GetText()
	self.Data = {}
	if (txt ~= "") then
		self.Data.Factions = json.decode( txt )
	else
		self.Data.Factions = {}
	end
	local txtu = self.DataFileU:GetText()
	if (txtu ~= "") then
		self.Data.Users = json.decode( txtu )
	else
		self.Data.Users = {}
	end
	local txtd = self.DataFileD:GetText()
	if (txtd ~= "") then
		self.Data.Info = json.decode( txtd )
	else
		self.Data.Info  = {}
		self.Data.Info["currentdoor"] = 0
		self:SaveD()
	end
	self.TempDoorPos = {}
	self.DoorIsUsed = {}
	self.Teleports = {}
	self.LastTeleports = {}
	self:SaveU()
	self:SaveF()
	self.ToggleDoor = {}
	self.LastKnownHealth = {}
	self.isSettingHome = {}
	local b, res = config.Read("r-Factions")
	self.Config = res or {}
	if (not b) then
		self:LoadDefaultConfig()
		if (res) then
			config.Save("r-Factions")
		end
	end
	if(tostring(self.Config.Version) ~= "1.1.1") then
		self:LoadDefaultConfig()
		config.Save("r-Factions")
	end
	self.CurrentTimers = {}
	
	-- Commands for all players
	self:AddChatCommand( "fcreate", self.cmdFcreate )
	self:AddChatCommand( "fjoin", self.cmdFjoin )
	self:AddChatCommand( "fplayers", self.cmdFplayers )
	self:AddChatCommand( "fplayer", self.cmdFplayers )
	self:AddChatCommand( "flist", self.cmdFlist )
	self:AddChatCommand( "fhelp", self.cmdFhelp )
	self:AddChatCommand( "fcall", self.cmdBackup )
	
	-- Commands for factionned players
	self:AddChatCommand( "fleave", self.cmdFleave )
	self:AddChatCommand( "f", self.cmdFchat )
	self:AddChatCommand( "fdoor", self.cmdFdoor )
	self:AddChatCommand( "fhome", self.cmdFhome )
	
	-- Commands for faction owners
	self:AddChatCommand( "fconfig", self.cmdFmod )
	self:AddChatCommand( "faccept", self.cmdFaccept )
	self:AddChatCommand( "frefuse", self.cmdFrefuse )
	self:AddChatCommand( "frequest", self.cmdFrequests )
	self:AddChatCommand( "frequests", self.cmdFrequests )
	self:AddChatCommand( "fkick", self.cmdFkick )
	self:AddChatCommand( "finvite", self.cmdFinvite )
	
	-- Commands for server admins
	self:AddChatCommand( "fadmin", self.cmdFadmin )
end
function PLUGIN:LoadDefaultConfig()
	self.Config.Version = "1.1.1"
	self.Config.ServerName = "Factions"
	self.Config.ShowConnectedMessage = true
	self.Config.ShowDisconnectedMessage = true
	self.Config.AllowFactionCreations = true
	self.Config.FactionNameLenght = 10
	self.Config.ExportChatPage = ""
	self.Config.DefaultConfigs = {
		["teamkill"] = {["default"] = true,["editable"] = true},
		["teamkillpunish"] = {["default"] = false,["editable"] = true},
		["open"] = {["default"] = false,["editable"] = true},
		["homefaction"] = {["default"] = false,["editable"] = true},
		["allowtobecalled"] = {["default"] = true,["editable"] = true}
	}
	self.Config.TeleportToFactionDelay = 30
	self.Config.TeleportToFactionCoolDown = 1800
	self.Config.ForceFriendlyFireON = false
end
function PLUGIN:PostInit()
	for _, targetuser in pairs( rust.GetAllNetUsers() ) do
		local userid = rust.GetUserID( targetuser ) 
		if(not self.Data.Users[userid]) then
			self.Data.Users[userid] = {}
			self.Data.Users[userid]["kit"] = false
			self.Data.Users[userid]["Faction"] = nil
		end
		self.Data.Users[userid]["Name"] = targetuser.displayName
		if(self.Data.Users[userid]["Faction"]) then
			if(not self.Data.Factions[self.Data.Users[userid]["Faction"]]) then
				self.Data.Users[userid]["Faction"] = nil
				 rust.SendChatToUser( targetuser, self.Config.ServerName, "Your faction doesn't exist anymore" )
			end
		end
	end
	self:SaveU()
	self:SaveF()
end

function PLUGIN:cmdFadmin(netuser,cmd,args)
	if(not netuser:CanAdmin()) then
		rust.Notice(netuser, "You are now allowed to use this command",5)
		return
	end
	if(not args[1]) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "/fadmin create 'FACTION' - to create a faction")
		rust.SendChatToUser( netuser, self.Config.ServerName, "/fadmin owner 'FACTION' 'OWNER-NAME' - to set the owner of a faction")
		rust.SendChatToUser( netuser, self.Config.ServerName, "/fadmin join 'FACTION' 'NAME' - to force join a player in a faction")
		rust.SendChatToUser( netuser, self.Config.ServerName, "/fadmin kick 'NAME' - to force kick a player from his faction")
		rust.SendChatToUser( netuser, self.Config.ServerName, "/fadmin players 'FACTION' - to see the faction players list")
		rust.SendChatToUser( netuser, self.Config.ServerName, "/fadmin disband 'FACTION' - to disband a faction")
		rust.SendChatToUser( netuser, self.Config.ServerName, "/fadmin ff true/false - to activate/deactivate the forced friendlyfire (for arenas for example)")
		return
	end
	if(args[1] == "create") then
		if(not args[2]) then
			rust.Notice(netuser,"You must select a name")
			return
		end
		local factionname = ""
		for i=2, #args do
			if(i == 2) then
				factionname = factionname .. args[i]
			else
				factionname = factionname .. " " .. args[i]
			end
		end
		if( self.Data.Factions[string.lower(factionname)] ~= nil ) then
			rust.SendChatToUser( netuser, self.Config.ServerName, "This faction already exist")
			return
		end
		self.Data.Factions[string.lower(factionname)] = {
			["Name"] = factionname,
			["Owner"] = "Server",
			["OwnerID"] = "",
			["Requests"] = {},
			["Invites"] = {},
			["Banlist"] = {},
			["Doors"] = {},
			["Configs"] = {}
		}
		for topic,data in pairs(self.Config.DefaultConfigs) do
			self.Data.Factions[string.lower(factionname)]["Configs"][topic] = data["default"]
		end
		rust.SendChatToUser( netuser, self.Config.ServerName, "Faction " .. factionname .. " was successfully created")
		return
	elseif(args[1] == "ff") then
		if(not args[2]) then
			if(self.Config.ForceFriendlyFireON) then
				rust.SendChatToUser( netuser, self.Config.ServerName, "Friendly fire is no longer forced")
				self.Config.ForceFriendlyFireON = false
			else
				rust.SendChatToUser( netuser, self.Config.ServerName, "Friendly fire is now forced, members from all factions will be able to kill each other")
				self.Config.ForceFriendlyFireON = true
			end
			config.Save("r-Factions")
			return
		end
		if(tostring(args[2]) == "true") then
			rust.SendChatToUser( netuser, self.Config.ServerName, "Friendly fire is now forced, members from all factions will be able to kill each other")
			self.Config.ForceFriendlyFireON = true
		elseif(tostring(args[2]) == "false") then
			rust.SendChatToUser( netuser, self.Config.ServerName, "Friendly fire is no longer forced")
			self.Config.ForceFriendlyFireON = false
		else
			rust.SendChatToUser( netuser, self.Config.ServerName, "wrong argument: true or false")
			return
		end
		config.Save("r-Factions")
	elseif(args[1] == "owner") then
		if(not args[2]) then
			rust.Notice(netuser,"You must select a faction name")
			return
		end
		if(not args[3]) then
			rust.Notice(netuser,"You must select a player name")
			return
		end
		local sfaction = string.lower(args[2])
		if(args[3] == "Server") then
			rust.SendChatToUser( netuser, self.Config.ServerName, "Faction " .. factionname .. " is now a server faction")
			self.Data.Factions[sfaction]["OwnerID"] = ""
			self.Data.Factions[sfaction]["Owner"] = "Server"
			return
		end
		local targetuser = self:FindPlayer(netuser,args[3])
		if(not targetuser) then return end
		local targetid = rust.GetUserID( targetuser ) 
		if(not self.Data.Users[targetid]["Faction"]) then
			rust.SendChatToUser( netuser, self.Config.ServerName, "This player " .. targetuser.displayName .. " has no factions")
			return
		end
		if(self.Data.Users[targetid]["Faction"] ~= sfaction) then
			rust.SendChatToUser( netuser, self.Config.ServerName, "This player " .. targetuser.displayName .. " already in another faction")
			return
		end
		self.Data.Factions[sfaction]["Owner"] = targetuser.displayerName
		self.Data.Factions[sfaction]["OwnerID"] = targetid
		local factionname = self.Data.Factions[sfaction]["Name"]
		rust.SendChatToUser( netuser, self.Config.ServerName, "This player " .. targetuser.displayName .. " is now the new faction owner of " .. factionname)
		rust.SendChatToUser( targetuser, factionname, "The admin set you as the new owner of " .. factionname)
		return
	elseif(args[1] == "join") then
		if(not args[2]) then
			rust.Notice(netuser,"You must select a faction name")
			return
		end
		if(not args[3]) then
			rust.Notice(netuser,"You must select a player name")
			return
		end
		local sfaction = string.lower(args[2])
		local targetuser = self:FindPlayer(netuser,args[3])
		if(not targetuser) then return end
		local targetid = rust.GetUserID( targetuser ) 
		if(self.Data.Users[targetid]["Faction"] ~= nil) then
			rust.SendChatToUser( netuser, self.Config.ServerName, "This player " .. targetuser.displayName .. " already has a faction: " .. self.Data.Users[targetid]["Faction"])
			return
		end
		if(not self.Data.Factions[sfaction]) then
			rust.SendChatToUser( netuser, self.Config.ServerName, "This faction: " .. args[2] .. " doesn't exist")
			return
		end
		local factionname = self.Data.Factions[sfaction]["Name"]
		self:JoinFaction(targetid,factionname)
		rust.SendChatToUser( netuser, self.Config.ServerName, targetuser.displayName .. " has joined " .. factionname)
		return
	elseif(args[1] == "kick") then
		if(not args[2]) then
			rust.Notice(netuser,"You must select a faction name")
			return
		end
		if(not args[3]) then
			rust.Notice(netuser,"You must select a player name")
			return
		end
		local sfaction = string.lower(args[2])
		if(not self.Data.Factions[sfaction]) then
			rust.SendChatToUser( netuser, self.Config.ServerName, "This faction: \"" .. factionname .. "\" doesn't exist")
			return
		end
		local targetid, err = self:FindPlayerInFaction(args[3],sfaction)
		if(not targetid) then
			rust.SendChatToUser( netuser, sfaction, err)
			return
		end
		local targetuser = self:FindPlayerByID(targetid)
		if(targetuser) then
			rust.SendChatToUser( targetuser, self.Config.ServerName, "You were kicked out of the faction")
		end
		self:LeaveFaction(targetid)
	elseif(args[1] == "players") then
		if(not args[2]) then
			rust.Notice(netuser,"You must select a faction name")
			return
		end
		local factionname = ""
		for i=2, #args do
			if(i == 2) then
				factionname = factionname .. args[i]
			else
				factionname = factionname .. " " .. args[i]
			end
		end
		local sfaction = string.lower(factionname)
		if(not self.Data.Factions[sfaction]) then
			rust.SendChatToUser( netuser, self.Config.ServerName, "This faction: \"" .. factionname .. "\" doesn't exist")
			return
		end
		local factionname = self.Data.Factions[sfaction]["Name"]
		local members = {}
		local con = 0
		local tot = 0
		for tuserid,data in pairs(self.Data.Users) do
			if(data["Faction"] == sfaction) then
				members[tuserid] = false
				tot = tot + 1
			end
		end
		for _, targetuser in pairs( rust.GetAllNetUsers() ) do
			local targetid = rust.GetUserID( targetuser ) 
			if (sfaction == self.Data.Users[targetid]["Faction"]) then
				members[targetid] = true
				con = con + 1
			end
		end
		rust.SendChatToUser( netuser, factionname, con .. " Connected | " .. tot .. " Total" )
		for id,conn in pairs(members) do
			local status
			if(conn) then 
				status = "[color #9CFFA2]Online"
			else 
				status = "[color #FF9090]Offline"
			end
			rust.SendChatToUser( netuser, factionname, self.Data.Users[id]["Name"] .. " - " .. status )
		end
		return
	elseif(args[1] == "disband") then
		if(not args[2]) then
			rust.Notice(netuser,"You must select a faction name")
			return
		end
		local factionname = ""
		for i=2, #args do
			if(i == 2) then
				factionname = factionname .. args[i]
			else
				factionname = factionname .. " " .. args[i]
			end
		end
		local sfaction = string.lower(factionname)
		if(not self.Data.Factions[sfaction]) then
			rust.SendChatToUser( netuser, self.Config.ServerName, "This faction: \"" .. factionname .. "\" doesn't exist")
			return
		end
		self:DisbandFaction(sfaction)
		rust.SendChatToUser( netuser, self.Config.ServerName, "The faction was disbanded")
	else
		rust.Notice(netuser, "This command doesn't exist, say /fadmin for full list",5)
		return
	end
end

function PLUGIN:cmdFhelp(netuser,cmd,args)
	rust.SendChatToUser( netuser, self.Config.ServerName, "-------------- Public commands --------------")
	if(self.Config.AllowFactionCreations) then rust.SendChatToUser( netuser, self.Config.ServerName, "/fcreate - to create a faction") end
	rust.SendChatToUser( netuser, self.Config.ServerName, "/flist - to get the factions list")
	rust.SendChatToUser( netuser, self.Config.ServerName, "/fjoin - to join a faction")
	local userid = rust.GetUserID( netuser ) 
	local sfaction = self.Data.Users[userid]["Faction"]
	if(not sfaction) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "/fcall 'faction name' - to call a faction for help, on your position")
	else
		local factionname = self.Data.Factions[sfaction]["Name"]
		rust.SendChatToUser( netuser, self.Config.ServerName, "-------------- Faction Members commands --------------")
		rust.SendChatToUser( netuser, factionname, "/fcall - to call your faction for backup, on your position")
		rust.SendChatToUser( netuser, factionname, "/fplayers - to get the faction's players list")
		rust.SendChatToUser( netuser, factionname, "/f 'text' - to write to your faction only")
		rust.SendChatToUser( netuser, factionname, "/fhome - Teleport to your faction home")
		rust.SendChatToUser( netuser, factionname, "/fdoor 'text' - activate/deactivate a door to share for the faction, with optional text")
		rust.SendChatToUser( netuser, factionname, "/fleave - to leave your faction")
		if(self.Data.Factions[sfaction]["OwnerID"] ~= tostring(userid)) then
			return
		end
		rust.SendChatToUser( netuser, self.Config.ServerName, "-------------- Faction Owners commands --------------")
		rust.SendChatToUser( netuser, factionname, "/fconfig - to configure settings in your faction")
		rust.SendChatToUser( netuser, factionname, "/finvite 'player' - to invite someone in your faction")
		rust.SendChatToUser( netuser, factionname, "/frequests - to see the requests to join your faction (if config 'open' is set to false)")
		rust.SendChatToUser( netuser, factionname, "/faccept 'NUMBER' - to accept a player in your faction (/frequests)")
		rust.SendChatToUser( netuser, factionname, "/frefuse 'NUMBER' - to refuse someone (/frequests)")
		rust.SendChatToUser( netuser, factionname, "/fkick 'Faction Member' - to kick the member from your faction")

	end
	if(netuser:CanAdmin()) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "/fadmin - to administrate a plugin and a faction")
	end
end
function PLUGIN:cmdFmod(netuser,cmd,args)
	local userid = rust.GetUserID( netuser ) 
	local sfaction = self.Data.Users[userid]["Faction"]
	if(not sfaction) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You do not have a faction")
		return
	end
	if(self.Data.Factions[sfaction]["OwnerID"] ~= tostring(userid)) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You must be the faction owner to edit configs")
		return
	end
	local factionname = self.Data.Factions[sfaction]["Name"]
	if(not args[1]) then
		rust.SendChatToUser( netuser, factionname, "Avaible configurations:")
		rust.SendChatToUser( netuser, factionname, "ex: /fconfig open false or /fconfig open true")
		for topic,data in pairs(self.Config.DefaultConfigs) do
			if(data["editable"]) then
				rust.SendChatToUser( netuser, factionname, "[color #9CFFA2]" .. topic .. " : " .. tostring(self.Data.Factions[sfaction]["Configs"][topic]))
			else
				rust.SendChatToUser( netuser, factionname, "[color #FF9090]" .. topic .. " : " .. tostring(self.Data.Factions[sfaction]["Configs"][topic]) .. " - Locked")
			end
		end
		return
	end
	local v = string.lower(args[1])
	if(self.Data.Factions[sfaction]["Configs"][v] == nil) then
		rust.SendChatToUser( netuser, factionname, "This option doesn't exist, /fconfig to get the full list")
		return
	end
	if(not args[2]) then
		if(self.Config.DefaultConfigs[v]["editable"]) then
			rust.SendChatToUser( netuser, factionname, "[color #9CFFA2]" .. v .. " : " .. tostring(self.Data.Factions[sfaction]["Configs"][v]))
		else
			rust.SendChatToUser( netuser, factionname, "[color #FF9090]" .. v .. " : " .. tostring(self.Data.Factions[sfaction]["Configs"][v]) .. " - Locked")
		end
		return
	end
	if(self.Config.DefaultConfigs[v]["editable"]) then
		if(tostring(args[2]) == "true") then
			if(v == "homefaction") then
				rust.SendChatToUser( netuser, "You are about to set your faction home, hit the foundation" )
				self.isSettingHome[netuser] = true
			else
				self.Data.Factions[sfaction]["Configs"][v] = true
				rust.SendChatToUser( netuser, factionname, v .. " set to true")
			end
		elseif(tostring(args[2]) == "false") then
			if(v == "homefaction") then
				rust.SendChatToUser( netuser, "You have deactivated the teleport to the faction home" )
				self.Data.Factions[sfaction]["Configs"][v] = false
				self.isSettingHome[netuser] = nil
			else
				self.Data.Factions[sfaction]["Configs"][v] = false
				rust.SendChatToUser( netuser, factionname, v .. " set to false")
			end
		else
			rust.SendChatToUser( netuser, factionname, "This argument isn't allowed, please put true or false")
			return
		end
		self:SaveF()
	else
		rust.SendChatToUser( netuser, factionname, "You are not allowed to change this setting.")
		return
	end
end
function PLUGIN:OnUserConnect( netuser )
	local userid = rust.GetUserID( netuser ) 
	if(not self.Data.Users[userid]) then
		self.Data.Users[userid] = {}
		self.Data.Users[userid]["kit"] = false
		self.Data.Users[userid]["Faction"] = nil
	end
	self.Data.Users[userid]["Name"] = netuser.displayName
		if(not self.Data.Users[userid]["Faction"]) then
			if (self.Config.ShowConnectedMessage) then
				rust.BroadcastChat( netuser.displayName .. " has joined the game." ) 
			end
		else
			if(not self.Data.Factions[self.Data.Users[userid]["Faction"]]) then
				if (self.Config.ShowConnectedMessage) then
					rust.BroadcastChat( netuser.displayName .. " has joined the game." )
				end
				self.Data.Users[userid]["Faction"] = nil
				 rust.SendChatToUser( netuser, self.Config.ServerName, "Your faction doesn't exist anymore" )
			else
				if (self.Config.ShowConnectedMessage) then
					rust.BroadcastChat( "[" .. self.Data.Factions[self.Data.Users[userid]["Faction"]]["Name"] .. "] " .. netuser.displayName .. " has joined the game." )
				end
			end
		end
	self:SaveU()
	self:SaveF()
end

function PLUGIN:SaveD()
	self.DataFileD:SetText( json.encode( self.Data.Info ) )
	self.DataFileD:Save()
end
function PLUGIN:SaveU()
	self.DataFileU:SetText( json.encode( self.Data.Users ) )
	self.DataFileU:Save()
end
function PLUGIN:SaveF()
	self.DataFileF:SetText( json.encode( self.Data.Factions ) )
	self.DataFileF:Save()
end

function PLUGIN:cmdFsave(netuser,cmd,args)
	if(not netuser:CanAdmin()) then
		rust.Notice(netuser,"You are not allowed to use this command")
		return
	end
	self:SaveU()
	self:SaveF()
end
function PLUGIN:FactionsCount()
	local f = 0
	for sfaction,data in pairs(self.Data.Factions) do
		f = f + 1
	end
	return f
end
function PLUGIN:cmdFlist(netuser,cmd,args)
	local startid = 1
	if(args[1]) then startid = tonumber(args[1]) end
	rust.SendChatToUser( netuser, self.Config.ServerName, "===== Faction list ===== " .. startid .. "/" .. self:FactionsCount())
	local factions = {}
	for sfaction,data in pairs(self.Data.Factions) do
		table.insert(factions, sfaction)
	end
	table.sort(factions)
	local factionnumbers = {}
	for userid,data in pairs(self.Data.Users) do
		if(data["Faction"]) then
			if(not factionnumbers[data["Faction"]]) then factionnumbers[data["Faction"]] = 0 end
			factionnumbers[data["Faction"]] = factionnumbers[data["Faction"]] + 1
		end
	end
	
	local curr = 1
	for i,sfaction in ipairs(factions) do
		if(curr >= startid and curr < (startid + 20)) then
			rust.SendChatToUser( netuser, self.Config.ServerName, curr .. " - " .. self.Data.Factions[sfaction]["Name"] .. " - Owned by " .. self.Data.Factions[sfaction]["Owner"] .. " - " .. tostring(factionnumbers[sfaction]) .. " members" )
		end
		curr = curr + 1
	end
end
function PLUGIN:cmdFhome(netuser,cmd,args)
	local userid = rust.GetUserID( netuser ) 
	local sfaction = self.Data.Users[userid]["Faction"]
	if(not sfaction) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You do not have a faction")
		return
	end
	local factionname = self.Data.Factions[sfaction]["Name"]
	if(not self.Config.DefaultConfigs["homefaction"]["editable"] and not self.Data.Factions[sfaction]["Configs"]["homefaction"]) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "This command is deactivated")
		return
	end
	if(not self.Data.Factions[sfaction]["Configs"]["homefaction"]) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "The faction leader didn't set a home faction yet")
		return
	end
	if( self.LastTeleports[ netuser ] ) then
		if( (util.GetTime() - self.LastTeleports[ netuser ]) < self.Config.TeleportToFactionCoolDown ) then
			local timeleft = self.Config.TeleportToFactionCoolDown - (util.GetTime() - self.LastTeleports[ netuser ])
			rust.SendChatToUser( netuser, self.Config.ServerName, "You must wait another " .. timeleft .. "s to teleport to your faction home")
			return
		end
	end
	if(self.Teleports[netuser]) then self.Teleports[netuser]:Destroy() end
	rust.SendChatToUser( netuser, factionname, "You will be teleported to your faction's base in " .. self.Config.TeleportToFactionDelay .. "s" )
	self.Teleports[netuser] = timer.Once( self.Config.TeleportToFactionDelay, function() self:TeleportToFaction(netuser,self.Data.Factions[sfaction]["Configs"]["homefaction"]) end )
end
function PLUGIN:TeleportToFaction(netuser,pos)
	if(not netuser) then return end
	if(not netuser.playerClient) then return end
	local position = netuser.playerClient.lastKnownPosition
	position.x = pos["x"]
	position.y = pos["y"]
	position.z = pos["z"]
	self:FreezePlayer(netuser)
	timer.Repeat( 1, 3, function() rust.ServerManagement():TeleportPlayer( netuser.playerClient.netPlayer, position) end )
	timer.Once( 4, function () self:UnfreezePlayer( netuser ) end )
	self.LastTeleports[ netuser ] = util.GetTime()
end
function PLUGIN:FreezePlayer ( netuser )
	if(not netuser) then return end
	if(not netuser.playerClient) then return end
	if(not netuser.playerClient.controllable) then return end
	local fallDamage = netuser.playerClient.controllable:GetComponent("FallDamage")
	fallDamage:AddLegInjury(1)
end
function PLUGIN:UnfreezePlayer ( netuser )
	if(not netuser) then return end
	if(not netuser.playerClient) then return end
	if(not netuser.playerClient.controllable) then return end
	local fallDamage = netuser.playerClient.controllable:GetComponent("FallDamage")
	fallDamage:ClearInjury()
end

function PLUGIN:cmdFdoor(netuser,cmd,args)
	local userid = rust.GetUserID( netuser ) 
	local sfaction = self.Data.Users[userid]["Faction"]
	if(not sfaction) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You do not have a faction")
		return
	end
	if(self.ToggleDoor[netuser]) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You will no longer select doors for your faction")
		self.ToggleDoor[netuser] = false
		return
	end
	local factionname = self.Data.Factions[sfaction]["Name"]
	local text = "-= " .. factionname .. " =-"
	if(args[1]) then
		text = ""
		for i=1,#args do
			text = text .. args[i] .. " "
		end
	end
	rust.SendChatToUser( netuser, self.Config.ServerName, "By opening doors you will select them to be shared with your faction")
	rust.SendChatToUser( netuser, self.Config.ServerName, "The text when opening will be: " .. text)
	self.ToggleDoor[netuser] = text
end
local GetDeployableObjectownerID = util.GetFieldGetter( Rust.DeployableObject, "ownerID", true )
local NullableOfVector3 = typesystem.MakeNullableOf( UnityEngine.Vector3 )
local NullableOfBoolean = typesystem.MakeNullableOf( System.Boolean )

local ToggleStateServer = util.FindOverloadedMethod( Rust.BasicDoor, "ToggleStateServer", bf.private_instance, { NullableOfVector3, System.UInt64, NullableOfBoolean } )
local GetDoorState, SetDoorState = typesystem.GetField( Rust.BasicDoor, "state", bf.private_instance )
local GetOpeningInReverse, SetOpeningInReverse = typesystem.GetField( Rust.BasicDoor, "openingInReverse", bf.private_instance )
local CurrentTime = util.GetStaticPropertyGetter( cs.gettype("NetCull, Assembly-CSharp"), "timeInMillis")

function PLUGIN:close_door(door)
    if (tostring(GetDoorState(door)) == "Opened: 1") then
        local timestamp = CurrentTime()
        local origin = new( UnityEngine.Vector3 )
        local arr = util.ArrayFromTable( System.Object, { new( NullableOfVector3, origin ), timestamp, nil }, 3 )
        cs.convertandsetonarray( arr, 1, timestamp, System.UInt64._type )
        local res= ToggleStateServer:Invoke( door, arr )
    end
end
function PLUGIN:open_door_foward(door)
    if (tostring(GetDoorState(door)) == "Closed: 3") then
        local timestamp = CurrentTime()
        local origin = new( UnityEngine.Vector3 )
        local arr = util.ArrayFromTable( System.Object, { new( NullableOfVector3, origin ), timestamp, nil }, 3 )
        cs.convertandsetonarray( arr, 1, timestamp, System.UInt64._type )
        local res= ToggleStateServer:Invoke( door, arr )
    end
end
function PLUGIN:SaveDoorPos(num,door)
	if(not door or door == nil) then
		return
	end
	local pos = door.transform.position
	table.insert(self.TempDoorPos[num],{x=pos.x,y=pos.y,z=pos.z})
end
function PLUGIN:CheckAndSaveDoor(netuser,num,door)
	if(not netuser or netuser == nil) then
		self.TempDoorPos[num] = {}
		self.TempDoorPos[num] = nil
		return
	end
	if(not door or door == nil) then
		return
	end
	local one = self.TempDoorPos[num][1]
	local two = self.TempDoorPos[num][2]
	local three = self.TempDoorPos[num][3]
	if(not one or not two or not three) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "Something went wrong, please try again")
		return
	end
	if((one.x == two.x and one.z == two.z) or (one.x == three.x and one.z == three.z) or (two.x == three.x and two.z == three.z)) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "There was an error while saving this door for your faction, try opening the door from the other side!")
		return
	end
	local userID = rust.GetUserID( netuser )
	local sfaction = self.Data.Users[userID]["Faction"]
	if(not sfaction) then return end
	for i=1, #self.TempDoorPos[num] do
		local pos = self.TempDoorPos[num][i]
		local x = tostring(pos.x)
		local y = tostring(pos.y)
		local z = tostring(pos.z)
		if(not self.Data.Factions[sfaction]["Doors"][x]) then self.Data.Factions[sfaction]["Doors"][x] = {} end
		if(not self.Data.Factions[sfaction]["Doors"][x][y]) then self.Data.Factions[sfaction]["Doors"][x][y] = {} end
		self.Data.Factions[sfaction]["Doors"][x][y][z] = {}
		self.Data.Factions[sfaction]["Doors"][x][y][z]["ownerid"] = userID
		self.Data.Factions[sfaction]["Doors"][x][y][z]["num"] = num
		if(i == 1) then
			self.Data.Factions[sfaction]["Doors"][x][y][z]["text"] = self.ToggleDoor[netuser]
		else
			self.Data.Factions[sfaction]["Doors"][x][y][z]["text"] = ""
		end
	end
	local factionname = self.Data.Factions[sfaction]["Name"]
	rust.SendChatToUser( netuser, factionname, "This door was set for the faction: " .. factionname .. ". Text is: " .. self.ToggleDoor[netuser])
	self:SaveF()
	return
end

function PLUGIN:StartSavingDoor(netuser,door)
    local basicdoor = door:GetComponent("BasicDoor")
    if basicdoor == nil then
        return
    end
	self.DoorIsUsed[door] = true
	self.Data.Info["currentdoor"] = self.Data.Info["currentdoor"] + 1
	local currentdoor = self.Data.Info["currentdoor"]
	self.TempDoorPos[currentdoor] = {}
	self:SaveDoorPos(currentdoor,door)
	timer.Once(0.5, function()
		self:SaveDoorPos(currentdoor,door)
		self:close_door(door)
	end )
	timer.Once(1, function()
		self:open_door_foward(door)
	end )
	timer.Once(1.5, function()
		self:SaveDoorPos(currentdoor,door)
		self:close_door(door)
	end )
	timer.Once(2, function()
		self:CheckAndSaveDoor(netuser,currentdoor,door)
		self.DoorIsUsed[door] = nil
	end )
	self:SaveD()

end
function PLUGIN:CanOpenDoor( netuser, door )
	local deployable = door:GetComponent( "DeployableObject" )
    if (not deployable) then
        return
    end
	local ownerID = tostring( GetDeployableObjectownerID( deployable ) )
	if(not ownerID) then return end
	local userID = rust.GetUserID( netuser )
	if(self.DoorIsUsed[door]) then
		rust.Notice(netuser, "This door is being saved for a faction, please wait couple seconds",5)
		return false
	end
    if (ownerID == userID) then
		local sfaction = self.Data.Users[userID]["Faction"]
		if(not sfaction) then
			return true
		end
		if(self.ToggleDoor[netuser]) then
		    if (tostring(GetDoorState(door)) == "Closed: 3") then
				self:StartSavingDoor(netuser,door)
			end
			return true
		end
	end
	if(not self.Data.Users[ownerID]) then return end
	if(self.Data.Users[ownerID]["Faction"] ~= nil and self.Data.Users[userID]["Faction"] ~= nil) then
		if(self.Data.Users[userID]["Faction"] == self.Data.Users[ownerID]["Faction"]) then
			local sfaction = self.Data.Users[userID]["Faction"]
			local pos = door.transform.position
			local x = tostring(pos.x)
			local y = tostring(pos.y)
			local z = tostring(pos.z)
			if(self.Data.Factions[sfaction]["Doors"][x] and self.Data.Factions[sfaction]["Doors"][x][y] and self.Data.Factions[sfaction]["Doors"][x][y][z]) then
				if(self.Data.Factions[sfaction]["Doors"][x][y][z]["text"] ~= "") then rust.Notice(netuser, self.Data.Factions[sfaction]["Doors"][x][y][z]["text"], 2) end
				return true
			end
		end
	end
	return
end

function PLUGIN:cmdFaccept(netuser,cmd,args)
	local userid = rust.GetUserID( netuser ) 
	local sfaction = self.Data.Users[userid]["Faction"]
	if(not sfaction) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You do not have a faction")
		return
	end
	if(self.Data.Factions[sfaction]["OwnerID"] ~= tostring(userid)) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You must be the faction owner to accept requests")
		return
	end
	if(not self.Data.Factions[sfaction]["Requests"][1]) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You have no pending requests to join your faction" )
		return
	end
	local num = tonumber(args[1])
	if(not self.Data.Factions[sfaction]["Requests"][num]) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "This request number doesn't exist" )
		return
	end
	rust.SendChatToUser( netuser, self.Config.ServerName, self.Data.Factions[sfaction]["Requests"][num]["Name"] .. " was accepted in the faction" )
	self:JoinFaction(self.Data.Factions[sfaction]["Requests"][num]["UserID"],self.Data.Factions[sfaction]["Name"])
	table.remove(self.Data.Factions[sfaction]["Requests"],num)
	self:SaveU()
	self:SaveF()
end
function PLUGIN:cmdFrefuse(netuser,cmd,args)
	local userid = rust.GetUserID( netuser ) 
	local sfaction = self.Data.Users[userid]["Faction"]
	if(not sfaction) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You do not have a faction")
		return
	end
	if(self.Data.Factions[sfaction]["OwnerID"] ~= tostring(userid)) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You must be the faction owner to accept requests")
		return
	end
	if(not self.Data.Factions[sfaction]["Requests"][1]) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You have no pending requests to join your faction" )
		return
	end
	local num = tonumber(args[1])
	if(not self.Data.Factions[sfaction]["Requests"][num]) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "This request number doesn't exist" )
		return
	end
	rust.SendChatToUser( netuser, self.Config.ServerName, self.Data.Factions[sfaction]["Requests"][num]["Name"] .. " was rejected from the faction" )
	table.insert(self.Data.Factions[sfaction]["Banlist"],self.Data.Factions[sfaction]["Requests"][num]["UserID"])
	table.remove(self.Data.Factions[sfaction]["Requests"],num)
	self:SaveU()
	self:SaveF()
end
function PLUGIN:cmdFrequests(netuser,cmd,args)
	local userid = rust.GetUserID( netuser ) 
	local sfaction = self.Data.Users[userid]["Faction"]
	if(not sfaction) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You do not have a faction")
		return
	end
	if(self.Data.Factions[sfaction]["OwnerID"] ~= tostring(userid)) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You must be the faction owner to see the requests")
		return
	end
	if(not self.Data.Factions[sfaction]["Requests"][1]) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You have no pending requests to join your faction" )
		return
	end
	rust.SendChatToUser( netuser, self.Config.ServerName, "/faccept NUMBER to accept - /frefuse NUMBER to refuse and ban the player from reapplying" )
	for i,data in pairs(self.Data.Factions[sfaction]["Requests"]) do
		rust.SendChatToUser( netuser, self.Config.ServerName, i .. " - " .. data["Name"])
	end
end
function PLUGIN:cmdFcreate(netuser,cmd,args)
	if(not self.Config.AllowFactionCreations) then
		rust.Notice(netuser,"You are not allowed to create factions")
		return
	end
	local userid = rust.GetUserID( netuser ) 
	if(not args[1]) then
		rust.Notice(netuser,"You must select a name")
		return
	end
	local factionname = ""
	for i=1, #args do
		if(i == 1) then
			factionname = factionname .. args[i]
		else
			factionname = factionname .. " " .. args[i]
		end
	end
	if( self.Data.Factions[string.lower(factionname)] ~= nil ) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "This faction already exist")
		return
	end
	if( self.Data.Users["Faction"] ~= nil ) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You already have a faction, /fleave your faction first!")
		return
	end
	if( string.len(factionname) > self.Config.FactionNameLenght ) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "Faction names can't exceed " .. tostring(self.Config.FactionNameLenght) .. " characters")
		return
	end
	self.Data.Factions[string.lower(factionname)] = {
		["Name"] = factionname,
		["Owner"] = netuser.displayName,
		["OwnerID"] = tostring(userid),
		["Requests"] = {},
		["Invites"] = {},
		["Banlist"] = {},
		["Doors"] = {},
		["Configs"] = {}
	}
	for topic,data in pairs(self.Config.DefaultConfigs) do
		self.Data.Factions[string.lower(factionname)]["Configs"][topic] = data["default"]
	end
	rust.BroadcastChat( self.Config.ServerName, "A new Faction has been created by " .. netuser.displayName .. ": " .. factionname )
	self:JoinFaction(userid,factionname)
end
function PLUGIN:cmdFjoin(netuser,cmd,args)
	local userid = rust.GetUserID( netuser ) 
	if(not args[1]) then
		rust.Notice(netuser,"You must select a name")
		return
	end
	local factionname = ""
	for i=1, #args do
		if(i == 1) then
			factionname = factionname .. args[i]
		else
			factionname = factionname .. " " .. args[i]
		end
	end
	if( self.Data.Factions[string.lower(factionname)] == nil ) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "This faction doesn't exist")
		return
	end
	if( self.Data.Users[userid]["Faction"] ~= nil ) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You already have a faction, /fleave your faction first!")
		return
	end
	for i,id in pairs(self.Data.Factions[string.lower(factionname)]["Invites"]) do
		if(userid == id) then
			self:JoinFaction(userid,factionname)
			table.remove(self.Data.Factions[string.lower(factionname)]["Invites"],i)
			return
		end
	end
	for num,targetid in pairs(self.Data.Factions[string.lower(factionname)]["Banlist"]) do
		if(tonumber(targetid) == userid) then
			rust.SendChatToUser( netuser, self.Config.ServerName, "You were already refused from this faction, you may now only be invited")
			return
		end
	end
	if(self.Data.Factions[string.lower(factionname)]["Configs"]["open"]) then
		self:JoinFaction(userid,factionname)
	else
		rust.SendChatToUser( netuser, self.Data.Factions[string.lower(factionname)]["Name"], "This faction is under invite only, your request has been sent to the leader of the faction")
		self:SendJoinRequest(netuser,userid,factionname)
	end
end
function PLUGIN:SendJoinRequest(netuser,userid,faction)
	local sfaction = string.lower(faction)
	local ownerid = self.Data.Factions[sfaction]["OwnerID"]
	local tbl = {
		["Name"] = netuser.displayName,
		["UserID"] = tostring(userid)
	}
	table.insert(self.Data.Factions[sfaction]["Requests"],tbl)
	local targetuser = self:FindPlayerByID(ownerid)
	if(not targetuser) then return end
	rust.SendChatToUser( targetuser, self.Data.Factions[sfaction]["Name"], "You have a new join request from " .. netuser.displayName )
	rust.SendChatToUser( targetuser, self.Data.Factions[sfaction]["Name"], "say /faccept " .. netuser.displayName .. " to accept him" )
	rust.SendChatToUser( targetuser, self.Data.Factions[sfaction]["Name"], "say /frefuse " .. netuser.displayName .. " to refuse him and ban him from requesting again" )
end
function PLUGIN:cmdFleave(netuser,cmd,args)
	local userid = rust.GetUserID( netuser )
	if(not self.Data.Users[userid]["Faction"]) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You can't leave a faction when you are not in one")
		return
	end
	rust.SendChatToUser( netuser, self.Config.ServerName, "You have left the " .. self.Data.Factions[self.Data.Users[userid]["Faction"]]["Name"] .. " faction" )
	self:LeaveFaction(userid)
end
function PLUGIN:cmdFkick(netuser,cmd,args)
	local userid = rust.GetUserID( netuser ) 
	if(not self.Data.Users[userid]["Faction"]) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You aren't in any faction")
		return
	end
	local sfaction = self.Data.Users[userid]["Faction"]
	if(tostring(userid) ~= self.Data.Factions[sfaction]["OwnerID"]) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You aren't the faction owner, you are not allowed to do that")
		return
	end
	local targetid, err = self:FindPlayerInFaction(args[1],sfaction)
	if(not targetid) then
		rust.SendChatToUser( netuser, self.Config.ServerName, err)
		return 
	end
	local targetuser = self:FindPlayerByID(targetid)
	if(targetuser) then
		rust.SendChatToUser( targetuser, self.Config.ServerName, "You were kicked out of the faction")
	end
	self:LeaveFaction(targetid)
end
function PLUGIN:FindPlayerInFaction(name,sfaction)
	local targetuser = false
	local potentials = {}
	for userid,data in pairs(self.Data.Users) do
		if(data["Faction"] == sfaction) then
			if(string.find(string.lower(data["Name"]),string.lower(name))) then
				potentials[userid] = data["Name"]
			end
		end
	end
	for userid,tname in pairs(potentials) do
		if(tname == name) then
			return userid
		end
		if(targetuser) then
			return false, "Multiple members with that name found"
		end
		targetuser = userid		
	end
	if(not targetuser) then return false, "No member with that name found" end
	return targetuser
end
function PLUGIN:DisbandFaction(sfaction)
	for _, targetuser in pairs( rust.GetAllNetUsers() ) do
		local targetid = rust.GetUserID( targetuser ) 
		if (sfaction == self.Data.Users[targetid]["Faction"]) then 
			rust.SendChatToUser( targetuser, self.Data.Factions[sfaction]["Name"], "You left the faction")
			rust.SendChatToUser( targetuser, self.Data.Factions[sfaction]["Name"], "Reason: The faction was disbanded")
		end
	end
	for tuserid,data in pairs(self.Data.Users) do
		if(data["Faction"] == sfaction) then
			self.Data.Users[tuserid]["Faction"] = nil
		end
	end
	rust.BroadcastChat( self.Config.ServerName, "The faction " .. self.Data.Factions[sfaction]["Name"] .. " was disbanded"  )
	self.Data.Factions[sfaction] = nil
	self:SaveU()
	self:SaveF()
end
function PLUGIN:LeaveFaction(userid)
	local temp = self.Data.Users[userid]["Faction"]
	if(tostring(userid) == self.Data.Factions[string.lower(temp)]["OwnerID"]) then
		self.Data.Users[userid]["Faction"] = nil
		self:DisbandFaction(temp)
	else
		for x,next in pairs(self.Data.Factions[temp]["Doors"]) do
			for y,nexxt in pairs(next) do
				for z,data in pairs(nexxt) do
					if(data["ownerid"] == userid) then
						self.Data.Factions[temp]["Doors"][x][y][z] = {}
						self.Data.Factions[temp]["Doors"][x][y][z] = nil
					end
				end
			end
		end
		self.Data.Users[userid]["Faction"] = nil
		for _, targetuser in pairs( rust.GetAllNetUsers() ) do
			local targetid = rust.GetUserID( targetuser ) 
			if (temp == self.Data.Users[targetid]["Faction"] and targetid ~= userid) then 
				rust.SendChatToUser( targetuser, "[F][" .. self.Data.Factions[temp]["Name"] .. "] " .. self.Data.Users[userid]["Name"], "[color #9CFFA2]has left the faction")
			end
		end
	end
	self:SaveU()
	self:SaveF()
end

function PLUGIN:JoinFaction(userid,faction)
	if(not self.Data.Factions[string.lower(faction)]) then
		return
	end
	self.Data.Users[userid]["Faction"] = string.lower(faction)
	local sfaction = string.lower(faction)
	self:SaveU()
	self:SaveF()
	local targetuser = self:FindPlayerByID(userid)
	if(not targetuser) then return end
	rust.SendChatToUser( targetuser, self.Config.ServerName, "You have successfully joined the " .. faction .. " faction" )
	for _, fuser in pairs( rust.GetAllNetUsers() ) do
		local targetid = rust.GetUserID( fuser ) 
		if (sfaction == self.Data.Users[targetid]["Faction"] and targetid ~= userid) then 
			rust.SendChatToUser( fuser, "[F][" .. faction .. "] " .. targetuser.displayName, "[color #9CFFA2]has joined the faction")
		end
	end

end

function PLUGIN:cmdFplayers(netuser,cmd,args)
	local userid = rust.GetUserID( netuser ) 
	local sfaction = self.Data.Users[userid]["Faction"]
	local factionname = self.Data.Factions[sfaction]["Name"]
	local members = {}
	local con = 0
	local tot = 0
	for tuserid,data in pairs(self.Data.Users) do
		if(data["Faction"] == sfaction) then
			members[tuserid] = false
			tot = tot + 1
		end
	end
	for _, targetuser in pairs( rust.GetAllNetUsers() ) do
		local targetid = rust.GetUserID( targetuser ) 
		if (sfaction == self.Data.Users[targetid]["Faction"]) then
			members[targetid] = true
			con = con + 1
		end
	end
	rust.SendChatToUser( netuser, factionname, con .. " Connected | " .. tot .. " Total" )
	for id,conn in pairs(members) do
		local status
		if(conn) then 
			status = "[color #9CFFA2]Online"
		else 
			status = "[color #FF9090]Offline"
		end
		rust.SendChatToUser( netuser, factionname, self.Data.Users[id]["Name"] .. " - " .. status )
	end
end
function PLUGIN:cmdFinvite(netuser,cmd,args)
	local userid = rust.GetUserID( netuser ) 
	if(not self.Data.Users[userid]["Faction"]) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You aren't in any faction")
		return
	end
	local sfaction = self.Data.Users[userid]["Faction"]
	local factionname = self.Data.Factions[sfaction]["Name"]
	if(tostring(userid) ~= self.Data.Factions[sfaction]["OwnerID"]) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You aren't the faction owner, you are not allowed to do that")
		return
	end
	local targetname = ""
	for i=1, #args do
		if(i == 1) then
			targetname = targetname .. args[i]
		else
			targetname = targetname .. " " .. args[i]
		end
	end
	local targetuser, err = self:FindPlayer(netuser,targetname)
	if(not targetuser) then
		rust.SendChatToUser( netuser, self.Config.ServerName, err)
		return 
	end
	local targetid = rust.GetUserID( targetuser )
	for i,id in pairs(self.Data.Factions[sfaction]["Invites"]) do
		if(targetid == id) then
			rust.SendChatToUser( netuser, self.Config.ServerName, "This user was already invited and didn't answer!")
			return
		end
	end
	table.insert(self.Data.Factions[sfaction]["Invites"],targetid)
	rust.SendChatToUser( targetuser, factionname, "You were invited in the faction by " .. netuser.displayName .."! '/fjoin "..factionname.."' to accept")
end


function PLUGIN:FindPlayerByID(userid)
	for _, targetuser in pairs( rust.GetAllNetUsers() ) do
		local targetid = rust.GetUserID( targetuser ) 
		if(targetid == userid) then
			return targetuser
		end
	end
	return false
end

function PLUGIN:FindPlayer(netuser,name)
	local b, targetuser = rust.FindNetUsersByName(name)
	if (not b) then
		if (targetuser == 0) then
			rust.Notice(netuser, "No players found with that name!")
		else
			rust.Notice(netuser, "Multiple players found with that name!")
		end
		return false
	end
	return targetuser
end
local LifeStatusType = cs.gettype( "LifeStatus, Assembly-CSharp" )
typesystem.LoadEnum(LifeStatusType, "LifeStatus" )

function PLUGIN:ModifyDamage( takedamage, damage )
	if(damage.attacker.client and damage.attacker.client.netUser) then
		if(damage.victim.client and damage.victim.client.netUser) then
			if(damage.victim.client == damage.attacker.client) then
					return
			else
				if(not self.Config.ForceFriendlyFireON) then
					local attackeruserid = rust.GetUserID( damage.attacker.client.netUser ) 
					local victimuserid = rust.GetUserID( damage.victim.client.netUser ) 
					if(self.Data.Users[attackeruserid]["Faction"] ~= nil and self.Data.Users[victimuserid]["Faction"] ~= nil) then
						if(self.Data.Users[attackeruserid]["Faction"] == self.Data.Users[victimuserid]["Faction"]) then
							local sfaction = string.lower(self.Data.Users[attackeruserid]["Faction"])
							if(not self.Data.Factions[sfaction]["Configs"]["teamkill"]) then
								damage.amount = 0
								damage.status = LifeStatus.IsAlive 
								rust.Notice(damage.attacker.client.netUser, "Don't attack people from the same faction!", 2)
								return damage
							end
						end
					end
				end
			end
			local char = rust.GetCharacter(damage.victim.client.netUser)
			if(not char) then 
				self.LastKnownHealth[damage.victim.client.netUser] = 100
			else
				self.LastKnownHealth[damage.victim.client.netUser] = char.takeDamage.health
			end
		elseif(self.isSettingHome[damage.attacker.client.netUser]) then
			local attackerNetuser = damage.attacker.client.netUser
			local structureComponent = takedamage.GameObject:GetComponent("StructureComponent")
			if(structureComponent) then
				local master = structureComponent._master
				if(string.find(takedamage.gameObject.Name,"Foundation")) then
					local master = structureComponent._master
					local lpos = structureComponent:GetComponent("Transform").position
					self:DoSetHome( attackerNetuser, master , lpos )
				else
					rust.SendChatToUser( attackerNetuser, "You may only hit a foundation to set a home" )
					rust.Notice(attackerNetuser, "Setting Home Faction Deactivated")
					self.isSettingHome[attackerNetuser] = nil
				end
			end
		end
	end
end
local getStructureMasterOwnerId = util.GetFieldGetter(Rust.StructureMaster, "ownerID", true)

function PLUGIN:DoSetHome( netuser, master, pos)
	local userid = rust.GetUserID( netuser )
	if(not self.Data.Users[userid]["Faction"]) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "You aren't in any faction")
		rust.Notice(netuser, "Setting Home Faction Deactivated")
		self.isSettingHome[netuser] = nil
		return
	end
	local sfaction = self.Data.Users[userid]["Faction"]
	local factionname = self.Data.Factions[sfaction]["Name"]
	
	if (not self.Data.Factions[sfaction]["Configs"]["homefaction"]) then
		self.Data.Factions[sfaction]["Configs"]["homefaction"] = {}
	end
	local structureOwnerId = tostring(getStructureMasterOwnerId(master))
	if(not self:CanSetHome(userid, structureOwnerId)) then
		rust.SendChatToUser( netuser, "You are not allowed to set your home here" )
		rust.Notice(netuser, "Setting Home Faction Deactivated")
		self.isSettingHome[netuser] = nil
		return
	end
	self.Data.Factions[sfaction]["Configs"]["homefaction"][ "x" ] = pos.x
	self.Data.Factions[sfaction]["Configs"]["homefaction"][ "y" ] = (pos.y + 4)
	self.Data.Factions[sfaction]["Configs"]["homefaction"][ "z" ] = pos.z
	self:SaveF()
	rust.SendChatToUser( netuser, "Set Home Faction Successfull" )
	rust.Notice(netuser, "Setting Home Faction Deactivated")
	self.isSettingHome[netuser] = nil
end
function PLUGIN:CanSetHome(userid,masterid)
	local allowed = false
	if(userid == masterid) then return true end
	if(self:inSameFaction(masterid,userid)) then
		allowed = true
	end
	return allowed
end
function PLUGIN:OnKilled(takedamage,damage)
	if(damage.victim.client and damage.victim.client.netUser) then
		if(damage.attacker.client and damage.attacker.client.netUser) then
			if(damage.victim.client == damage.attacker.client) then
					return
				else
					if(not self.Config.ForceFriendlyFireON) then
					local attackeruserid = rust.GetUserID( damage.attacker.client.netUser ) 
					local victimuserid = rust.GetUserID( damage.victim.client.netUser ) 
					if(self.Data.Users[attackeruserid]["Faction"] ~= nil and self.Data.Users[victimuserid]["Faction"] ~= nil) then
						if(self.Data.Users[attackeruserid]["Faction"] == self.Data.Users[victimuserid]["Faction"]) then
							local sfaction = string.lower(self.Data.Users[attackeruserid]["Faction"])
							if(not self.Data.Factions[sfaction]["Configs"]["teamkill"]) then
								damage.amount = 0
								damage.status = LifeStatus.IsAlive 
								local char = rust.GetCharacter(damage.victim.client.netUser)
								if(self.LastKnownHealth[damage.victim.client.netUser]) then
									char.takeDamage.health = self.LastKnownHealth[damage.victim.client.netUser]
								else
									char.takeDamage.health = char.takeDamage.maxHealth
								end
								rust.Notice(damage.attacker.client.netUser, "Don't attack people from the same faction!", 2)
								return damage
							end
							if(self.Data.Factions[sfaction]["Configs"]["teamkillpunish"]) then
								rust.Notice(damage.attacker.client.netUser, "Killing a friend made you sick!!", 2)
								self:MakeHimSuffer(damage.attacker.client.netUser)
							end
						end
					end
				end
			end
		end
	end
end

function PLUGIN:MakeHimSuffer(netUser)
    local playerClient = netUser.playerClient
    if not playerClient then
        return false
    end
    local controllable = playerClient.controllable
    if not controllable then
        return false
    end
    local metabolism = controllable:GetComponent("Metabolism")
    metabolism:AddPoison(15)
	if(not self.CurrentTimers[metabolism]) then self.CurrentTimers[metabolism] = {} end
	if(self.CurrentTimers[metabolism]["poisonned"]) then
		self.CurrentTimers[metabolism]["poisonned"]:Destroy()
		self.CurrentTimers[metabolism]["poisonned"] = nil
	end
	self.CurrentTimers[metabolism]["poisonned"] = timer.Once( 2, function() self:SubstractPoison(metabolism) end)
end
function PLUGIN:SubstractPoison(metabolism)
	if not metabolism then
		return false
	end
	if(self.CurrentTimers[metabolism]["poisonned"]) then
		self.CurrentTimers[metabolism]["poisonned"]:Destroy()
		self.CurrentTimers[metabolism]["poisonned"] = nil
	end
	if(not metabolism:IsPoisoned()) then
		return
	end
	metabolism:SubtractPosion(1)
	self.CurrentTimers[metabolism]["poisonned"] = timer.Once( 2, function() self:SubstractPoison(metabolism) end)
end
function PLUGIN:Unload()
	for userid,tm in pairs(self.CurrentTimers) do
		for tname,tim in pairs(self.CurrentTimers[userid]) do
			self.CurrentTimers[userid][tname]:Destroy()
		end
	end
end
function PLUGIN:OnUserChat(netuser,name,msg)
	if (msg:sub( 1, 1 ) == "/") then
		return
	end
	local userid = rust.GetUserID( netuser ) 
	if(not self.Data.Users[userid]) then
		self.Data.Users[userid] = {}
		self.Data.Users[userid]["kit"] = false
		self.Data.Users[userid]["Faction"] = nil
		self.Data.Users[userid]["Name"] = netuser.displayName
	end
	if(self.Data.Users[userid]["Faction"] ~= nil) then
		local sfaction = string.lower(self.Data.Users[userid]["Faction"])
		rust.BroadcastChat( "[" .. self.Data.Factions[sfaction]["Name"] .. "] " .. netuser.displayName, msg )
		print("[CHAT] [" .. self.Data.Factions[sfaction]["Name"] .. "] " .. netuser.displayName .. ": " .. msg)
		if(self.Config.ExportChatPage ~= "") then
			webrequest.Send( self.Config.ExportChatPage .. "?uid=" .. rust.GetUserID( netuser ) .. "&cnick=" .. name .. "&msg=" .. msg, function( code, response ) self:getRequest( code, response ) end )
		end
		return false
	else
		if(self.Config.ExportChatPage ~= "") then
			webrequest.Send( self.Config.ExportChatPage .. "?uid=" .. rust.GetUserID( netuser ) .. "&cnick=" .. name .. "&msg=" .. msg, function( code, response ) self:getRequest( code, response ) end )
		end
	end
end
function PLUGIN:inSameFaction(userid,otherid)
	if(not self.Data.Users[userid]["Faction"]) then
		return false
	end
	if(not self.Data.Users[otherid]["Faction"]) then
		return false
	end
	if(self.Data.Users[otherid]["Faction"] == self.Data.Users[userid]["Faction"]) then
		return true
	end
	return false
end
function PLUGIN:OnSpawnPlayer( playerclient, usecamp, avatar )
	timer.NextFrame( function()
		local char = rust.GetCharacter(playerclient.netUser)
		if(not char) then 
			self.LastKnownHealth[playerclient.netUser] = 100 
		else
			if(not char.takeDamage) then
				self.LastKnownHealth[playerclient.netUser] = 100
			else
				self.LastKnownHealth[playerclient.netUser] = char.takeDamage.health
			end
		end
	end)
end
function PLUGIN:cmdFchat(netuser,cmd,args)
	local userid = rust.GetUserID( netuser ) 
	if(not self.Data.Users[userid]["Faction"]) then
		rust.Notice(netuser, "You are not in a faction", 2)
		return
	end
	local sfaction = self.Data.Users[userid]["Faction"]
	local factionname = self.Data.Factions[sfaction]["Name"]
	local msg = "[color #9CFFA2]"
	for i=1,#args do
		msg = msg .. util.QuoteSafe(args[i]) .. " "
	end
	print("[CHAT] [F][" .. factionname .. "] " .. netuser.displayName .. ": " .. msg)
	for _, targetuser in pairs( rust.GetAllNetUsers() ) do
		local targetid = rust.GetUserID( targetuser ) 
		if (sfaction == self.Data.Users[targetid]["Faction"]) then 
			rust.SendChatToUser( targetuser, "[F][" .. factionname .. "] " .. netuser.displayName, msg)
		end
	end
end
function PLUGIN:cmdBackup(netuser,cmd,args)
	local userid = rust.GetUserID( netuser )
	if(not args[1]) then
		local sfaction = self.Data.Users[userid]["Faction"]
		if(not sfaction) then
			rust.SendChatToUser( netuser, self.Config.ServerName , "You are not in any faction, to call a faction use /fcall \"factionname\"")
		end
		local factionname = self.Data.Factions[sfaction]["Name"]
		local place = self:getPlaceName(netuser.playerClient.lastKnownPosition)
		local msg = "[color #FF9090] is calling for backup in " .. place
		for _, targetuser in pairs( rust.GetAllNetUsers() ) do
			local targetid = rust.GetUserID( targetuser ) 
			if (sfaction == self.Data.Users[targetid]["Faction"]) then 
		 	rust.SendChatToUser( targetuser, "[F][" .. factionname .. "] " .. netuser.displayName, msg)
			end
		end
	else
		local factionname = ""
		for i=1, #args do
			if(i == 1) then
				factionname = factionname .. args[i]
			else
				factionname = factionname .. " " .. args[i]
			end
		end
		local sfaction = string.lower(factionname)
		if(not self.Data.Factions[sfaction]) then
			rust.SendChatToUser( netuser, self.Config.ServerName , "The faction: \"" .. factionname .. "\" doesn't exist. /flist to get the list")
			return
		end
		local place = self:getPlaceName(netuser.playerClient.lastKnownPosition)
		local msg = "[color #FF9090] is requesting your faction help in " .. place
		for _, targetuser in pairs( rust.GetAllNetUsers() ) do
			local targetid = rust.GetUserID( targetuser ) 
			if (sfaction == self.Data.Users[targetid]["Faction"]) then 
				rust.SendChatToUser( targetuser, "[F]" .. netuser.displayName, msg)
			end
		end
		rust.SendChatToUser( netuser, self.Data.Factions[sfaction]["Name"], "The help request was successfully sent")
	end
end
function PLUGIN:getPlaceName( position )
	local LocationPoints = {
		{ name = "Hacker Valley South", x = 5907, z = -1848 },
		{ name = "Hacker Mountain South", x = 5268, z = -1961 },
		{ name = "Hacker Valley Middle", x = 5268, z = -2700 },
		{ name = "Hacker Mountain North", x = 4529, z = -2274 },
		{ name = "Hacker Valley North", x = 4416, z = -2813 },
		{ name = "Wasteland North", x = 3208, z = -4191 },
		{ name = "Wasteland South", x = 6433, z = -2374 },
		{ name = "Wasteland East", x = 4942, z = -2061 },
		{ name = "Wasteland West", x = 3827, z = -5682 },
		{ name = "Sweden", x = 3677, z = -4617 },
		{ name = "Everust Mountain", x = 5005, z = -3226 },
		{ name = "North Everust Mountain", x = 4316, z = -3439 },
		{ name = "South Everust Mountain", x = 5907, z = -2700 },
		{ name = "Metal Valley", x = 6825, z = -3038 },
		{ name = "Metal Mountain", x = 7185, z = -3339 },
		{ name = "Metal Hill", x = 5055, z = -5256 },
		{ name = "Resource Mountain", x = 5268, z = -3665 },
		{ name = "Resource Valley", x = 5531, z = -3552 },
		{ name = "Resource Hole", x = 6942, z = -3502 },
		{ name = "Resource Road", x = 6659, z = -3527 },
		{ name = "Beach", x = 5494, z = -5770 },
		{ name = "Beach Mountain", x = 5108, z = -5875 },
		{ name = "Coast Valley", x = 5501, z = -5286 },
		{ name = "Coast Mountain", x = 5750, z = -4677 },
		{ name = "Coast Resource", x = 6120, z = -4930 },
		{ name = "Secret Mountain", x = 6709, z = -4730 },
		{ name = "Secret Valley", x = 7085, z = -4617 },
		{ name = "Factory Radtown", x = 6446, z = -4667 },
		{ name = "Small Radtown", x = 6120, z = -3452 },
		{ name = "Big Radtown", x = 5218, z = -4800 },
		{ name = "Hangar", x = 6809, z = -4304 },
		{ name = "Tanks", x = 6859, z = -3865 },
		{ name = "Civilian Forest", x = 6659, z = -4028 },
		{ name = "Civilian Mountain", x = 6346, z = -4028 },
		{ name = "Civilian Road", x = 6120, z = -4404 },
		{ name = "Ballzack Mountain", x =4316, z = -5682 },
		{ name = "Ballzack Valley", x = 4720, z = -5660 },
		{ name = "Spain Valley", x = 4742, z = -5143 },
		{ name = "Portugal Mountain", x = 4203, z = -4570 },
		{ name = "Portugal", x = 4579, z = -4637 },
		{ name = "Lone Tree Mountain", x = 4842, z = -4354 },
		{ name = "Forest", x = 5368, z = -4434 },
		{ name = "Civ Two", x = 5725, z = -4280 },
		{ name = "Rad-Town Valley", x = 5907, z = -3400 },
		{ name = "Next Valley", x = 4955, z = -3900 },
		{ name = "Silk Valley", x = 5674, z = -4048 },
		{ name = "French Valley", x = 5995, z = -3978 },
		{ name = "Ecko Valley", x = 7085, z = -3815 },
		{ name = "Ecko Mountain", x = 7348, z = -4100 },
		{ name = "Middle Mountain", x = 6346, z = -4028 },
		{ name = "Zombie Hill", x = 6396, z = -3428 }
	}
	local currentlocation = "Unknown"
	local coords = position
	local min = -1
	local minIndex = -1
	for i = 1, #LocationPoints do
	   if (minIndex==-1) then
			min = (LocationPoints[i].x-coords.x)^2+(LocationPoints[i].z-coords.z)^2
			minIndex = i
	   else
			local dist = (LocationPoints[i].x-coords.x)^2+(LocationPoints[i].z-coords.z)^2
			if (dist<min) then
				min = dist
				minIndex = i
			end
	   end
	end
	currentlocation = LocationPoints[minIndex].name
	return currentlocation
end

function PLUGIN:SendHelpText(netuser)
	rust.SendChatToUser(netuser, self.Config.ServerName, "/fhelp to get the faction commands")
	if(netuser:CanAdmin()) then
		rust.SendChatToUser( netuser, self.Config.ServerName, "/fadmin - to administrate a plugin and a faction")
	end
end