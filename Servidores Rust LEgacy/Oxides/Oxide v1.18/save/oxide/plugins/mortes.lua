PLUGIN.Title = "Death Handler SQL Exporter & Anti Cheat & No recoil detections"
PLUGIN.Description = "Broadcast death messages to chat. Reneb Edit: Anti cheat and optional death messages & no recoil detections"
PLUGIN.Version = "1.6.2rc14"
PLUGIN.Author = "Hatemail for DeathHandler, Reneb for SQL and AntiCheat"
PLUGIN.ConfigVersion = "1.6rc14"

if not fileLog then fileLog = {} end

local UserChat = {}

function PLUGIN:Init()
	self:LoadConfig()
	self:LoadChatCommands()
	self:LoadLog()
	
	self.DataFile = util.GetDatafile( "weaponrange" )
	local txt = self.DataFile:GetText()
	if (txt ~= "") then
		self.Data = json.decode( txt )
	else
		self:LoadDefaultWeaponRange()
		self:Save()
	end
	self.NameFile = util.GetDatafile( "DeathHandler-admin-names" )
	local txt = self.NameFile:GetText()
	if (txt ~= "") then
		self.AdminNames = json.decode( txt )
	else
		self.AdminNames = {}
		self:SaveName()
	end
	self.UserData = {}
	self.LiveStats = {}
	self.ShotTimers = {}
	self.NoRecoil = {}
end
function PLUGIN:LoadDefaultWeaponRange()
	self.Data = {}
	self.Data["HandCannon"] = {}
	self.Data["HandCannon"].distance1 = "20"
	self.Data["HandCannon"].distance2 = "30"
	self.Data["Pipe Shotgun"] = {}
	self.Data["Pipe Shotgun"].distance1 = "80"
	self.Data["Pipe Shotgun"].distance2 = "90"
	self.Data["Revolver"] = {}
	self.Data["Revolver"].distance1 = "80"
	self.Data["Revolver"].distance2 = "90"
	self.Data["9mm Pistol"] = {}
	self.Data["9mm Pistol"].distance1 = "80"
	self.Data["9mm Pistol"].distance2 = "90"
	self.Data["Bolt Action Rifle"] = {}
	self.Data["Bolt Action Rifle"].distance1 = "250"
	self.Data["Bolt Action Rifle"].distance2 = "260"
	self.Data["M4"] = {}
	self.Data["M4"].distance1 = "140"
	self.Data["M4"].distance2 = "150"
	self.Data["MP5A4"] = {}
	self.Data["MP5A4"].distance1 = "80"
	self.Data["MP5A4"].distance2 = "90"
	self.Data["P250"] = {}
	self.Data["P250"].distance1 = "120"
	self.Data["P250"].distance2 = "130"
	self.Data["Shotgun"] = {}
	self.Data["Shotgun"].distance1 = "30"
	self.Data["Shotgun"].distance2 = "40"
	print("Default Weapon Range loaded")
end
function PLUGIN:LoadLog()
	startDateTime = System.DateTime.Now:ToString("MM/dd/yyyy")
	if self.Config.logToFile then
		fileLog.file = util.GetDatafile(string.gsub("Death Handler - " .. startDateTime , "/", "-"))
		local logText = fileLog.file:GetText()
		if (logText ~= "") then
			fileLog.text = split("\r\n", logText)
		else
			fileLog.text = {}
		end
		
	end
end

function PLUGIN:PostInit()
    self:LoadFlags()
	self:LoadUserChat()
end

function PLUGIN:LoadUserChat()
	for _, netuser in pairs( rust.GetAllNetUsers() ) do
		UserChat[netuser] = true
		self.LiveStats[netuser] = {}
	end
end

function PLUGIN:LoadConfig()
	local b, res = config.Read( "Death Handler SqLAC" )
	self.Config = res or {}
	if (not b) then
		print("Loading Default Death Handler Config...")
		self:LoadDefaultConfig()
		if (res) then config.Save( "Death Handler SqLAC" ) end
	end
	
	if ( self.Config.configVersion ~= self.ConfigVersion) then
		print("Out of date Death Handler Config, Updating!")
		self:LoadDefaultConfig()
		config.Save( "Death Handler SqLAC" )
	end
	
	if(self.Config.AntiCheatNoRecoilDetectionsMinimumNoRecoilRatio > 0.34) then
		error("AntiCheatNoRecoilDetectionsMinimumNoRecoilRatio can't be heigher then 0.34")
		self.Config.AntiCheatNoRecoilDetectionsMinimumNoRecoilRatio = 1/3
		config.Save( "Death Handler SqLAC" )
	end
	if(self.Config.AntiCheatNoRecoilDetectionsMinimumKillsNeeded < 4) then
		error("AntiCheatNoRecoilDetectionsMinimumKillsNeeded can't be lower then 4")
		self.Config.AntiCheatNoRecoilDetectionsMinimumKillsNeeded = 4 
		config.Save( "Death Handler SqLAC" )
	end
end

function PLUGIN:LoadFlags()
    self.oxminPlugin = plugins.Find("oxmin")
    if (self.oxminPlugin) then
        self.FLAG_DEATHCONFIG = oxmin.AddFlag("Deathconfig")
        self.oxminPlugin:AddExternalOxminChatCommand(self, "death", { self.FLAG_DEATHCONFIG }, self.setConfigValue)
    end

    self.flagsPlugin = plugins.Find("flags")
    if (self.flagsPlugin) then
        self.flagsPlugin:AddFlagsChatCommand(self, "death", { "Deathconfig" }, self.setConfigValue)
    end
end
function PLUGIN:HasFlag(netuser, flag)
    if (netuser:CanAdmin()) then
        do return true end
    elseif ((self.oxminPlugin ~= nil) and (self.oxminPlugin:HasFlag(netuser, flag))) then
       do return true end
    elseif ((self.flagsPlugin ~= nil) and (self.flagsPlugin:HasFlag(netuser, flag))) then
       do return true end
    end
    return false
end
function PLUGIN:cmdDeathLog(netuser,cmd,args)
	if (not self:HasFlag(netuser,"Deathconfig")) then return end
	if (not self.Config.liveLogs) then print("DeathHandler: This command was not activated (liveLogs = false)") end
	--CHECK IF ITS A NUMBER
	if(not args[1]) then
		rust.SendChatToUser(netuser, "Death Logs", "Arguments: /deathlog PLAYERID optionnal:FROMKILLID")
		rust.SendChatToUser(netuser, "Death Logs", "PLAYERID: get it from /deathlog_list, FROMKILLID: get it when you do /deathlog PLAYERID")
		return
	end
	local killnum = 1
	if(args[2]) then
		killnum = tonumber(args[2])
	end
	local num = tonumber(args[1])
	local current = 0
	local theuser = false
	for _, targetuser in pairs( rust.GetAllNetUsers() ) do
		current = current + 1
		if(current == num) then
			theuser = targetuser
		end
	end
	if(not theuser) then
		rust.SendChatToUser(netuser, "Death Logs", "Error: couldn't find playerid: " .. args[1] .. ". Say /deathlog_list to get the playerid")
		return
	end
	current = 0
	local max = 0
	for i,data in pairs( self.LiveStats[theuser] ) do
		max = max + 1
	end
	rust.SendChatToUser(netuser, "Death Logs", "Live stats of " .. theuser.displayName .. " (" .. killnum .. "/" .. max ..")")
	for i,data in pairs( self.LiveStats[theuser] ) do
		current = current + 1
		if(current >= killnum and current < (killnum + 20)) then
			rust.SendChatToUser(netuser, "Death Logs", tostring(data.killer) .. " killed " .. tostring(data.killed) .. " (" .. tostring(data.weapon) .. ") with a hit to their " .. tostring(data.bodypart) .. " at " .. tostring(data.distance) .. "m in " .. tostring(data.location))
		end
	end
	
end
function PLUGIN:cmdDeathList(netuser,cmd,args)
	if (not self:HasFlag(netuser,"Deathconfig")) then return end
	if (not self.Config.liveLogs) then print("DeathHandler: This command was not activated (liveLogs = false)") end
	local num = 1
	if(args[1]) then
		num = tonumber(args[1])
	end
	
	local count = 0
	for _, targetuser in pairs( rust.GetAllNetUsers() ) do
		count = count + 1
	end
	local current = 0
	rust.SendChatToUser(netuser, "Death Logs", "Death Logs since last users connection (" .. num .. "/"..count..")")
	for _, targetuser in pairs( rust.GetAllNetUsers() ) do
		current = current + 1
		if(current >= num and current < (num + 20)) then
			local stats = self:FastStats(targetuser)
			local ratio = "*"
			if(stats.deaths ~= 0) then
				ratio = stats.kills / stats.deaths
			end
			rust.SendChatToUser(netuser, "Death Logs", current .. " - " .. targetuser.displayName .. " - Kills: " .. stats.kills .. " (HS: " .. stats.hs .. ") Deaths: " .. stats.deaths .. " Ratio: " .. ratio)
		end
	end
end
function PLUGIN:FastStats(netuser)
	local tbl = {}
	local userid = rust.GetUserID(netuser)
	tbl.hs = 0
	tbl.kills = 0
	tbl.deaths = 0
	if(not self.LiveStats[netuser]) then
		return tbl
	end
	for i,data in pairs( self.LiveStats[netuser] ) do
		if(data.killerID == userid) then
			tbl.kills = tbl.kills + 1
			if( string.lower(data.bodypart) == "head") or ( string.lower(data.bodypart) == "throat") then
				tbl.hs = tbl.hs + 1
			end
		else
			tbl.deaths = tbl.deaths + 1
		end
	end
	return tbl
end
function PLUGIN:cmdStats(netuser,cmd,args)
	if(not self.Config.allowStats) then
		print("DeathHandler_rc: allowStats is set to false, you can't use the command /stats")
		return
	end
	if(not self.Config.logToMysql) then
		print("DeathHandler_rc: You can't use /stats if you don't use Mysql")
		return
	end
	local targetsteamid = tostring(rust.GetLongUserID(netuser))
	--if(args[1] and self:HasFlag(netuser,"Deathconfig")) then
	--	targetname = tostring(args[1])
	--end
	
	webrequest.Send( self.Config.page .. "?stats="..targetsteamid, function( code, response ) 
		if(response) then
			
			local resp = json.decode(response)
			if(not resp["name"]) then
				rust.SendChatToUser(netuser, self.Config.chatName, "No stats found for " .. args[1])
				return
			end
			local ratio = "*"
			if(tonumber(resp["deaths"]>0)) then
				ratio = tonumber(resp["kills"])/tonumber(resp["deaths"])
			end
			rust.SendChatToUser(netuser, self.Config.chatName, tostring(resp["name"]) .. " - Kills: " .. tostring(resp["kills"]) .. " - Deaths: " .. tostring(resp["deaths"]) .. " - Headshots: " .. tostring(resp["headshots"]) .. " - Ratio: " .. tostring(ratio))
		else
			rust.SendChatToUser(netuser, self.Config.chatName, "Couldn't get the stats of " .. netuser.displayName)
		end
	end  )

end
function PLUGIN:LoadChatCommands()
	--self:AddChatCommand( "stats", self.cmdStats)
	self:AddChatCommand( "death", self.setConfigValue)
	self:AddChatCommand( "deathmsg", self.ActiDeactiDeathMSG )
	self:AddChatCommand( "deathlog_list", self.cmdDeathList )
	self:AddChatCommand( "deathlog", self.cmdDeathLog )
	self:AddChatCommand( "norecoil", self.cmdNorecoil )
end
function PLUGIN:OnUserConnect( netuser )
    UserChat[netuser] = true
	self.LiveStats[netuser] = {}
end
function PLUGIN:OnUserDisconnect( networkplayer )
    local netuser = networkplayer:GetLocalData()
	if(not netuser) then return end
	self.LiveStats[netuser] = nil
	if(UserChat[netuser]) then
		UserChat[netuser] = nil
	end
	local userid = rust.GetUserID(netuser)
	if(self.UserData[userid]) then
		self.UserData[userid]:Destroy()
		self.UserData[userid] = nil
	end
	if(self.NoRecoil[netuser]) then
		print("NoRecoil:" .. netuser.displayName .. "(".. tostring(rust.GetLongUserID(netuser)) .. ") left with " .. self.NoRecoil[netuser].norecoil .. "/" .. self.NoRecoil[netuser].kills .. " no recoils detections")
		self.NoRecoil[netuser] = {}
		self.NoRecoil[netuser] = nil
	end
	
	self.LiveStats[netuser] = nil
end
function PLUGIN:ActiDeactiDeathMSG(netuser, cmd )
  if (UserChat[netuser]) then
     rust.SendChatToUser(netuser, "Death Messages", "You have deactivated the death messages")
     UserChat[netuser] = nil
  else
     UserChat[netuser] = true
     rust.SendChatToUser(netuser, "Death Messages", "You have reactivated the death messages")
  end
end
function PLUGIN:Save()
	self.DataFile:SetText( json.encode( self.Data ) )
	self.DataFile:Save()
end
function PLUGIN:SaveName()
	self.NameFile:SetText( json.encode( self.AdminNames ) )
	self.NameFile:Save()
end
function fileLog.save()
	fileLog.file:SetText( table.concat( fileLog.text, "\r\n" ) )
	fileLog.file:Save()
end
function PLUGIN:cmdNorecoil(netuser,cmd,args)
	for targetuser,data in pairs(self.NoRecoil) do
		rust.SendChatToUser(netuser,"No Recoils",targetuser.displayName .. ": " .. data.norecoil .. "/" .. data.kills .. " no recoils")
	end
end
function PLUGIN:LoadDefaultConfig()
	self.Config.configVersion 			=	"1.6rc14"
	self.Config.ShowLocation			=	self.Config.ShowLocation or true
	self.Config.liveLogs 				=	self.Config.liveLogs or true
	self.Config.allowStats				=	false
	self.Config.logToConsole 			=	self.Config.logToConsole or false
	self.Config.logToAdmin 				=	self.Config.logToAdmin or false
	self.Config.logToAdminChat			=	self.Config.logToAdminChat or false
	self.Config.logToAdminConsole 		=	self.Config.logToAdminConsole or false
	self.Config.logToFile 				=	self.Config.logToFile or false
	self.Config.broadCastChat 			=	self.Config.broadCastChat or true
	self.Config.deathByEntity 			=	self.Config.deathByEntity or false
	self.Config.player 					=	self.Config.player or true
	self.Config.bear 					=	self.Config.bear or false
	self.Config.wolf 					=	self.Config.wolf or false
	self.Config.stag 					=	self.Config.stag or false
	self.Config.chicken 				=	self.Config.chicken or false
	self.Config.rabbit 					=	self.Config.rabbit or false
	self.Config.boar 					=	self.Config.boar or false
	self.Config.suicide 				=	self.Config.suicide or false
	self.Config.suicideMessage 			=	self.Config.suicideMessage or "@{killed} has commited suicide"
	self.Config.chatName 				=	self.Config.chatName or "Death"
	self.Config.notifyKiller 			=	self.Config.notifyKiller or true
	self.Config.playerDeathMessage 		=	self.Config.playerDeathMessage or "@{killer} killed @{killed} (@{weapon}) with a hit to their @{bodypart} at @{distance}m"
	self.Config.logDeathMessage 		=	self.Config.logDeathMessage or "@{killer} killed @{killed} (@{weapon}) with a hit to their @{bodypart} at @{distance}m in @{location}"
	self.Config.adminDeathMessage 		=	self.Config.adminDeathMessage or "@{killer} killed @{killed} (@{weapon}) with a hit to their @{bodypart} at @{distance}m in @{location}"
	self.Config.deathByEntityMessage    =   self.Config.deathByEntityMessage or "@{killed} has died by a @{killer}"
	self.Config.wildlifeDeathMessage    =   self.Config.wildlifeDeathMessage or "@{killer} killed a @{killed} (@{weapon})"
	self.Config.AntiCheat				=	self.Config.AntiCheat or true
	self.Config.AntiCheatNotifyAdminsForDist1	=	self.Config.AntiCheatNotifyAdminsForDist1 or false
	self.Config.AntiCheatBroadcastBan	=	self.Config.AntiCheatBroadcastBan or true
	self.Config.AntiCheatAutoBanForDist2		=	self.Config.AntiCheatAutoBanForDist2 or true
	self.Config.AntiCheatNoRecoilDetections		=	self.Config.AntiCheatNoRecoilDetections or true
	self.Config.AntiCheatNoRecoilDetectionsTriggerDistance		=	self.Config.AntiCheatNoRecoilDetectionsTriggerDistance or 40
	self.Config.AntiCheatNoRecoilDetectionsMinimumKillsNeeded		=	self.Config.AntiCheatNoRecoilDetectionsMinimumKillsNeeded or 40
	self.Config.AntiCheatNoRecoilDetectionsMinimumNoRecoilRatio		=	self.Config.AntiCheatNoRecoilDetectionsMinimumNoRecoilRatio or 1/3
	self.Config.AntiCheatNoRecoilDetectionsAutoban		=	self.Config.AntiCheatNoRecoilDetectionsAutoban or true
	self.Config.page   					=  self.Config.page or "http://example.com/logsql.php"
	self.Config.logToMysql					=	self.Config.logToMysql or false
	self.Config.allowUsersToDeactivateDeathMessages		=	self.Config.allowUsersToDeactivateDeathMessages	or false

end

function PLUGIN:notifyDeath(tagInformation,useSwitch,switch)
	local message = "" 
	if self.Config.logToAdmin then
		if useSwitch then
			message = self:BuildDeathMessage(self:GetMessageConfig(switch),tagInformation)
		else
			message = self:BuildDeathMessage(self.Config.adminDeathMessage,tagInformation)
		end

		for _, netuser in pairs( rust.GetAllNetUsers() ) do
			if netuser:CanAdmin() then 
				if self.Config.logToAdminChat then
					rust.SendChatToUser( netuser, self.Config.chatName, message)
				end
				if self.Config.logToAdminConsole then
					rust.RunClientCommand( netuser, "echo " .. System.DateTime.Now:ToString("hh:mm tt") .. " " .. message ) 
				end
			end
		end
	end
	if self.Config.broadCastChat then
		if useSwitch then
			message = self:BuildDeathMessage(self:GetMessageConfig(switch),tagInformation)
		else
			message = self:BuildDeathMessage(self.Config.playerDeathMessage,tagInformation)
		end
		for k,v in pairs( UserChat ) do
			if (UserChat[k])  then 
			        rust.SendChatToUser( k, self.Config.chatName, message)
			end
		end
	end
	if self.Config.logToConsole then 
		if useSwitch then
			message = self:BuildDeathMessage(self:GetMessageConfig(switch),tagInformation)
		else
			message = self:BuildDeathMessage(self.Config.logDeathMessage,tagInformation)
		end
		print(message)
	 end
	
	if self.Config.logToFile then
		if useSwitch then
			message = self:BuildDeathMessage(self:GetMessageConfig(switch),tagInformation)
		else
			message = self:BuildDeathMessage(self.Config.logDeathMessage,tagInformation)
		end
		if (startDateTime ~= System.DateTime.Now:ToString("MM/dd/yyyy")) then
			self:LoadLog()
		end
		table.insert( fileLog.text, System.DateTime.Now:ToString("hh:mm tt") .. " " .. message)
		fileLog.save()
		
	end
end
function PLUGIN:getRequest( code, response )
end
function PLUGIN:GetMessageConfig(switch)

	if switch == "AnimalDeath" then
		return self.Config.wildlifeDeathMessage
	end
	if switch == "PlayerDeath" then
		return self.Config.deathByEntityMessage 
	end
	if switch == "Suicide" then
		return self.Config.suicideMessage
	end

	return "Death Happened @{killed}"
end

function PLUGIN:BuildDeathMessage(str, tags)
	local customMessage = str
	for k, v in pairs(tags) do
		customMessage = string.gsub(customMessage, "@{".. k .. "-}", v)
	end
	return customMessage
end

function PLUGIN:DistanceFromPlayers(p1, p2)
    return math.sqrt(math.pow(p1.x - p2.x,2) + math.pow(p1.y - p2.y,2) + math.pow(p1.z - p2.z,2)) end
function PLUGIN:setConfigValue(netuser, cmd, args)
	if (type(cmd) == "table") then
		args = cmd
	end
	if (self:HasFlag(netuser,"Deathconfig")) then
		if(args[1] == "name") then
			local userid = rust.GetUserID(netuser)
			if(not self.AdminNames[userid]) then self.AdminNames[userid] = {} end
			if(not args[2]) then 
				self.AdminNames[userid].name = nil
				self.AdminNames[userid].hide = nil
				self.AdminNames[userid] = nil
				rust.Notice( netuser, "You will no longer be hidden")
			else
				self.AdminNames[userid].name = args[2]
				if(not self.AdminNames[userid].hide) then
					rust.Notice( netuser, "You need to activate the hidden name: /death hide")
				end
			end
			self:SaveName()
		elseif(args[1] == "hide") then
			local userid = rust.GetUserID(netuser)
			if(not self.AdminNames[userid]) then self.AdminNames[userid] = {} end
			if(not self.AdminNames[userid].hide) then 
				self.AdminNames[userid].hide = true
				if(not self.AdminNames[userid].name) then
					rust.Notice( netuser, "You need to set a name: /death name XXX")
				end
			else
				self.AdminNames[userid].hide = false
			end
			rust.Notice( netuser, "Hidden death name set to " .. tostring(self.AdminNames[userid].hide))
			self:SaveName()
		else
			local targetConfig = args[1]
			for k, v in pairs(self.Config) do 
				if (k == targetConfig) then 
					if (tostring(self.Config[targetConfig]) == "true") then 
						self.Config[targetConfig] = false 
						rust.Notice( netuser, targetConfig .. " Set to: false") 
					else
						if (tostring(self.Config[targetConfig]) == "false") then 
							self.Config[targetConfig] = true 
							rust.Notice( netuser, targetConfig .. " Set to: true") 
						else
							table.remove(args, 1)
							
							local msg = table.concat( args, " ")
							print(string.len(msg))
							if string.len(msg) < 1 then
								rust.SendChatToUser( netuser, targetConfig, "Value: " .. self.Config[targetConfig]) 
								return 
							end
							self.Config[targetConfig] = args[2]
							rust.Notice( netuser, targetConfig .. " Set to: " .. msg) 
						end
					end
					--print("Saving Config")
					config.Save( "Death Handler" )
					self:LoadConfig()
					return
				end
			end
			rust.Notice( netuser, "No Config found!") 
		end
	end
end
function PLUGIN:CheckNoRecoil(netuser)
	if(self.NoRecoil[netuser] and self.NoRecoil[netuser].kills > self.Config.AntiCheatNoRecoilDetectionsMinimumKillsNeeded) then
		if( (self.NoRecoil[netuser].norecoil / self.NoRecoil[netuser].kills) >= self.Config.AntiCheatNoRecoilDetectionsMinimumNoRecoilRatio ) then
			if(self.Config.AntiCheatNoRecoilDetectionsAutoban) then
			   rust.BroadcastChat("Death", "[color #FFD630]" .. netuser.displayName .. " [color white]was detected using [color #FFD630]No Recoil[color red] (Auto Banned)")
			   rust.RunServerCommand("banid \"" .. tostring(rust.GetLongUserID( netuser )) .. "\" \"" .. tostring(netuser.displayName) .. "\" \"rNoRecoil (" .. self.NoRecoil[netuser].norecoil .. "/" .. self.NoRecoil[netuser].kills .. ")\"")
			   netuser:Kick(NetError.Facepunch_Kick_Ban, true)	
		   else
				rust.BroadcastChat("Death", "[color #FFD630]" .. netuser.displayName .. " [color white]was detected using [color #FFD630]No Recoil")
		   end
		end
	end
end
local _BodyParts = cs.gettype( "BodyParts, Facepunch.HitBox" )
local _GetNiceName = util.GetStaticMethod( _BodyParts, "GetNiceName" )
local _NetworkView = cs.gettype( "Facepunch.NetworkView, Facepunch.ID" )
local _Find = util.GetStaticMethod( _NetworkView, "Find" )
function PLUGIN:OnKilled(takedamage, damage)
	local tags = {}
	tags.killer = ""
	tags.killed = ""
	tags.weapon = ""
	tags.bodypart = ""
	tags.distance = ""
	if not (tostring(type(damage) ~= "userdata")) or not (tostring(type(takedamage) ~= "userdata")) then
		return
	end
	--TakeDamage , DamageEvent
	local weapon
	if(damage.extraData and damage.extraData.dataBlock) then
		weapon = damage.extraData.dataBlock.name
	end
	if( weapon) then 
		tags.weapon = weapon
	else 
		if(tostring(damage.damageTypes) == "damage_melee: 4") then
			if(damage.amount <= 80 and damage.amount >= 40) then
				tags.weapon = "Hunting Bow"
			elseif(damage.amount <= 30) then
				tags.weapon = "Spike Wall"
			else
				tags.weapon = "Unknown"
			end
		else
			tags.weapon = "Haemorrhage"
		end
	end
	
    if (takedamage:GetComponent( "HumanController" ) and self.Config.player) then
		if(damage.victim.client) then
			if(self.Config.deathByEntity) then
				if not damage.attacker.networkView then return end
				tags.killed = damage.victim.client.netUser.displayName
				idMain = damage.attacker.idMain
                if idMain then
                    idMain = idMain.idMain
                end
                killer = idMain:ToString()
				local idMainT = {}
			 	for k in string.gmatch(killer , "%a+") do
			       table.insert(idMainT , k)
			    end
			    
				if(damage.attacker.networkView.gameObject:GetComponent("BearAI")) then
					if idMainT[1] == "MutantBear" then
						tags.killer = "mutant bear"
					else
						tags.killer = "bear"
					end
					self:notifyDeath(tags, true, "PlayerDeath")
					return
				end
				if(damage.attacker.networkView.gameObject:GetComponent("WolfAI")) then
					if idMainT[1] == "MutantWolf" then
						tags.killer = "mutant wolf"
					else
						tags.killer = "wolf"
					end
					self:notifyDeath(tags, true, "PlayerDeath")
					return
				end
			end
		end          
        if(damage.victim.client and damage.attacker.client) then
			local isSamePlayer = (damage.victim.client == damage.attacker.client)
			tags.killerID = rust.GetUserID(damage.attacker.client.netUser)
			tags.killedID = rust.GetUserID(damage.victim.client.netUser)
			if(self.AdminNames[tags.killedID] and self.AdminNames[tags.killedID].hide and self.AdminNames[tags.killedID].name) then
				tags.killed = self.AdminNames[tags.killedID].name
			else
				tags.killed = damage.victim.client.netUser.displayName
			end
			if(self.AdminNames[tags.killerID] and self.AdminNames[tags.killerID].hide and self.AdminNames[tags.killerID].name) then
				tags.killer = self.AdminNames[tags.killerID].name
			else
				tags.killer = damage.attacker.client.netUser.displayName
			end
			
			tags.location = "Unknown"
			if(self.Config.ShowLocation) then 
				if(damage.victim.client.netUser.playerClient.lastKnownPosition) then
					tags.location = self:getPlaceName(damage.victim.client.netUser.playerClient.lastKnownPosition)
				end
			end
			if not isSamePlayer then				
				local dist = self:DistanceFromPlayers(damage.attacker.client.netUser.playerClient.lastKnownPosition,damage.victim.client.netUser.playerClient.lastKnownPosition)
				if self.Config.notifyKiller then
					rust.Notice(damage.attacker.client.netUser, "You killed " .. tags.killed)
				end
				tags.bodypart = "body"
				if (damage.bodyPart ~= nil) then
					if(damage.bodyPart:GetType().Name == "BodyPart" and _GetNiceName(damage.bodyPart) ~= nil) then
						tags.bodypart = _GetNiceName(damage.bodyPart)
					end
				end
				tags.distance = tostring(math.floor(dist))	
				if	self.Config.logToMysql then
					webrequest.Send( self.Config.page .. "?killed-id=" .. tags.killedID .. "&killer-id=" .. tags.killerID .. "&weapon=" .. tags.weapon .. "&bodypart=" .. tags.bodypart .. "&dist=" .. tags.distance .. "&dmg=" .. math.floor(damage.amount) .. "&killer=" .. tags.killer .. "&killed=" .. tags.killed, function( code, response ) self:getRequest( code, response ) end  )
				end
				if(self.Config.liveLogs) then
					tags.isKiller = "true"
					table.insert(self.LiveStats[damage.attacker.client.netUser],tags)
					tags.isKiller = "false"
					table.insert(self.LiveStats[damage.victim.client.netUser],tags)
				end
				if self.Config.AntiCheat then	
					if ( self.Data[ tags.weapon ] and tags.distance ) then
						if (tonumber(tags.distance) > tonumber( self.Data[ tags.weapon ].distance2 ) ) and self.Config.AntiCheatAutoBanForDist2 then
							if(not self.UserData[tags.killerID]) then
								self.UserData[tags.killerID] = timer.Once(300, function() self:ResetLongRangeKill(tags.killerID) end)
							else
								if(self.Config.AntiCheatBroadcastBan) then
								   rust.BroadcastChat("Death", "[color #FF4444]Out of range kill from: " .. damage.attacker.client.netUser.displayName .. " ! (Auto Banned)")
								end
								rust.RunServerCommand("banid \"" .. tostring(rust.GetLongUserID( damage.attacker.client.netUser )) .. "\" \"" .. tostring(damage.attacker.client.netUser.displayName) .. "\" \"rAimbot\"")
							   --damage.attacker.client.netUser:Ban()	
							   damage.attacker.client.netUser:Kick(NetError.Facepunch_Kick_Ban, true)	
						   end
						elseif (tonumber(tags.distance) > tonumber( self.Data[ tags.weapon ].distance1 ) ) and self.Config.AntiCheatNotifyAdminsForDist1 then
							for _, netuser in pairs( rust.GetAllNetUsers() ) do
								if netuser:CanAdmin() then 
									rust.SendChatToUser( netuser, "Anti-Cheat", damage.attacker.client.netUser.displayName .. " made an out of range kill with " .. tags.weapon .. " at " .. tonumber(tags.distance) .. "meters")
								end
							end
						end
					end		
				end
				if(self.Config.AntiCheatNoRecoilDetections) then
					if(tonumber(tags.distance) > self.Config.AntiCheatNoRecoilDetectionsTriggerDistance) then
						if(tostring(damage.damageTypes) == "damage_bullet: 2") then
							if(not self.ShotTimers[damage.attacker.client.netUser]) then
								local netuser = damage.attacker.client.netUser
								if(not self.NoRecoil[netuser]) then self.NoRecoil[netuser] = {kills=0,norecoil=0} end
								self.NoRecoil[netuser].kills = self.NoRecoil[netuser].kills + 1
								local userID = rust.GetUserID(netuser)
								local char = rust.GetCharacter( netuser )
								local lasttime = util.GetTime()
								if(char) then 
									local anglesx = char.eyesAngles.x
									self.ShotTimers[netuser] = timer.Once(0.3, function() 
										if(not netuser) then return end
										--local char2 = rust.GetCharacter( netuser )
										--if(not char2) then return end
										if((util.GetTime() - lasttime) > 1) then
											print("lag spike, should ignore this detection") 
										end
										local angles2x = char.eyesAngles.x
										if(anglesx == angles2x) then
											self:SendToAdmins("[color #9932CC]" .. netuser.displayName .. " might be using no recoil")
											self.NoRecoil[netuser].norecoil = self.NoRecoil[netuser].norecoil + 1
											
											print(netuser.displayName .. " might be using no recoil")
										end
										self.ShotTimers[netuser]:Destroy()
										self.ShotTimers[netuser] = nil
										self:CheckNoRecoil(netuser)
									end )
								end
							end
						end
					end
				end
				self:notifyDeath(tags,false)
				return
			end
			if(isSamePlayer and self.Config.suicide) then
				self:notifyDeath(tags,true, "Suicide")
				return
			end
		end
		
        return
    end

    if (takedamage:GetComponent( "BearAI" ) and self.Config.bear) then
    	tags.killer = damage.attacker.client.netUser.displayName
    	tags.killed = "bear"
    	self:notifyDeath(tags, true, "AnimalDeath")
        return
    end
    
    if (takedamage:GetComponent( "WolfAI" ) and self.Config.wolf) then
       tags.killer = damage.attacker.client.netUser.displayName
       tags.killed = "wolf"
       self:notifyDeath(tags, true, "AnimalDeath")
        return
    end
	
	if (takedamage:GetComponent( "StagAI" ) and self.Config.stag) then
	   tags.killer = damage.attacker.client.netUser.displayName
       tags.killed = "deer"
       self:notifyDeath(tags, true, "AnimalDeath")
        return
    end
	
	if (takedamage:GetComponent( "ChickenAI" ) and self.Config.chicken) then
		tags.killer = damage.attacker.client.netUser.displayName
       	tags.killed = "chicken"
		self:notifyDeath(tags, true, "AnimalDeath")
        return
    end
	
	if (takedamage:GetComponent( "RabbitAI" ) and self.Config.rabbit) then
        tags.killer = damage.attacker.client.netUser.displayName
       	tags.killed = "rabbit"
        self:notifyDeath(tags, true, "AnimalDeath")
        return
    end
	
	if (takedamage:GetComponent( "BoarAI" ) and self.Config.boar) then
        tags.killer = damage.attacker.client.netUser.displayName
       	tags.killed = "boar"
        self:notifyDeath(tags, true, "AnimalDeath")
        return
    end
	return
end
function PLUGIN:ResetLongRangeKill( netuser )
	if(not netuser) then return end
	local userid = rust.GetUserID(netuser)
	if(userid) then
		if(self.UserData[userid]) then
			self.UserData[userid]:Destroy()
			self.UserData[userid] = nil
		end
	end
end
function PLUGIN:SendHelpText( netuser )
	if (self:HasFlag(netuser,"Deathconfig")) then
		rust.SendChatToUser( netuser, self.Config.chatName, "Use /death configName <value> to change config in-game" )
		rust.SendChatToUser( netuser, self.Config.chatName, "Use /death name <value> to change your death name" )
		rust.SendChatToUser( netuser, self.Config.chatName, "Use /death hide to change activate/deactivate your custom death name" )
		if(self.Config.logToMysql) then
			rust.SendChatToUser( netuser, self.Config.chatName, "Use /stats <player> to check players stats" )
		end
		if(self.Config.liveLogs) then
			rust.SendChatToUser( netuser, self.Config.chatName, "Use /deathlog_list <plnum> to check the K/D of your players since last connection" )
			rust.SendChatToUser( netuser, self.Config.chatName, "Use /deathlog <plnum> <deathnum> to check all the kills/deaths of a player" )
		end
	end
	rust.SendChatToUser( netuser, self.Config.chatName, "Use /deathmsg to remove death messages" )
end
function split( sep, str )
	local t = {}
	for word in string.gmatch( str, "[^"..sep.."]+" ) do 
		table.insert( t, word )
	end	
	return t
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

function PLUGIN:SendToAdmins(msg)
	for _, targetuser in pairs( rust.GetAllNetUsers() ) do
		if(targetuser:CanAdmin()) then
			rust.SendChatToUser(targetuser, "AntiRecoil", msg)
		end
	end
end

