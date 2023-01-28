PLUGIN.Title = "R-Banlist"
PLUGIN.Description = "Ban system with rust banlist integration and Reneb's anti-cheat supports."
PLUGIN.Author = "Reneb"
PLUGIN.Version = "1.8.2"

local BanList = cs.gettype( "BanList, Assembly-CSharp")
local BanListStringEx = util.GetStaticMethod( BanList, "BanListStringEx" )
local BanListSave = util.GetStaticMethod( BanList, "Save" )
local BanListLoad = util.GetStaticMethod( BanList, "Load" )
local BanListContains = util.FindOverloadedMethod( Rust.BanList, "Contains", bf.public_static, { System.UInt64 } )
local BanListAdd = util.FindOverloadedMethod( Rust.BanList, "Add", bf.public_static, { System.UInt64, System.String, System.String } )
local BanListRemove = util.FindOverloadedMethod( Rust.BanList, "Remove", bf.public_static, { System.UInt64 } )

function PLUGIN:Init()
	local b, res = config.Read( "r-bans" )
	self.Config = res or {}
	if (not b) then
		self:LoadDefaultConfig()
		if (res) then config.Save( "r-bans" ) end
	end
	if(not self.Config.Version or (self.Config.Version and self.Config.Version ~= "1.8.2")) then
		local tempkey = self.Config.SteamAPIKey
		local tempfirst = self.Config.FirstLaunch
		self:LoadDefaultConfig()
		self.Config.SteamAPIKey = tempkey
		self.Config.FirstLaunch = tempfirst
		config.Save( "r-bans" )
	end
	self.BanFile = util.GetDatafile( "r-banlist" )
    local txt = self.BanFile:GetText()
    if (txt ~= "") then
        self.Banlist = json.decode( txt )
    else
        self.Banlist = {}
		self:Save()
    end
	if(self.Config.useIPBans) then
		self.BanIPFile = util.GetDatafile( "r-banlist-ips" )
		local txt = self.BanIPFile:GetText()
		if (txt ~= "") then
			self.BanIPlist = json.decode( txt )
		else
			self.BanIPlist = {}
			self:SaveIP()
		end
	end
	self.oxmin_plugin = plugins.Find("oxmin")
	self.flags_plugin = plugins.Find("flags")
	
	self.ServerInitialized = false
	self:AddChatCommand( "banlist", self.cmdBanList)
	self:AddChatCommand( "blist", self.cmdBanList)
	self:AddChatCommand( "bl", self.cmdBanList)
	self:AddChatCommand( "bi", self.cmdBanInfo)
	self:AddChatCommand( "baninfo", self.cmdBanInfo)
	self:AddChatCommand( "binfo", self.cmdBanInfo)
	self:AddChatCommand( "br", self.cmdBanRemove)
	self:AddChatCommand( "breload", self.cmdBanReload)
	self:AddChatCommand( "bremove", self.cmdBanRemove)
	self:AddChatCommand( "banremove", self.cmdBanRemove)
	self:AddChatCommand( "b", self.cmdBanAdd)
	self:AddChatCommand( "banadd", self.cmdBanAdd)
	self:AddChatCommand( "bhelp", self.cmdbhelp)
	self:AddChatCommand( "ba", self.cmdBanAdd)
	self:AddChatCommand( "banip", self.cmdBanIP)
	self:AddChatCommand( "removeip", self.cmdRemoveIP)
	self:AddChatCommand( "listip", self.cmdIPList)
	self:AddChatCommand( "iplist", self.cmdIPList)
	self:AddChatCommand( "pl", self.cmdPlayerList)
	self:AddChatCommand( "playerinfo", self.cmdPlayerInfo)
	self:AddChatCommand( "pi", self.cmdPlayerInfo)
	self:AddChatCommand( "heatmeter", self.cmdHeatmeter)
	
end
function PLUGIN:ModifyServerTags( tags )
	table.insert( tags, "rustdb" )
end
function PLUGIN:ccmdBanlist( arg )
	local user = arg.argUser
	if (user and not self:isAdmin(user)) then return end
	rust.RunServerCommand( "banlistex" )
end
function PLUGIN:ccmdUnban( arg )
	local user = arg.argUser
	if (user and not self:isAdmin(user)) then return end
	if(not arg:GetString( 0 )) then
		arg:ReplyWith( "You need to put the steamid or name" )
		return
	end
	local argument = arg:GetString( 0 )
	--rust.RunServerCommand( "removeid" )
end
function PLUGIN:cmdbhelp( netuser,cmd,args )
	if(not netuser:CanAdmin()) then return end
	rust.SendChatToUser( netuser, "®", "/banlist optional:BANID - to get the full banlist")
	rust.SendChatToUser( netuser, "®", "/baninfo BANID - to get the full ban information of a player")
	rust.SendChatToUser( netuser, "®", "/breload - reload the banlist (if you made a manual change in the file bans.cfg)")
	rust.SendChatToUser( netuser, "®", "/b STEAMID/PLAYERNAME/USERID REASON - To ban a player, online (with playername/steamid/userid) or offline (steamid/userid)")
	rust.SendChatToUser( netuser, "®", "/banremove BANID/STEAMID - remove a ban")
	rust.SendChatToUser( netuser, "®", "/heatmeter - Check all online players to see if those players have suspicious profiles or not")
	rust.SendChatToUser( netuser, "®", "/pl optional:ID - get the full player list")
	rust.SendChatToUser( netuser, "®", "/pi ID - get all the steam account informations from a player (ID from /pl)")
	if(self.Config.useIPBans) then
		rust.SendChatToUser( netuser, "®", "/listip optional:ID - get the full IP banlist")
		rust.SendChatToUser( netuser, "®", "/banip BANID IP - add an IP to a banned user")
		rust.SendChatToUser( netuser, "®", "/removeip IP - remove an IP from the banlist")
	end
	rust.SendChatToUser( netuser, "®", "BANID can be found in the banlist (/bl)")
	rust.SendChatToUser( netuser, "®", "STEAMID/USERID can be found the playerlist (/pl)")
end
function PLUGIN:SendHelpText(netuser)
	if(self:isAdmin(netuser)) then
		rust.SendChatToUser( netuser, "®", "/bhelp - to get the full commands from r-bans")
	end
end
local function url_encode(str)
    if (str) then
        str = string.gsub (str, "\n", "\r\n")
        str = string.gsub (str, "([^%w %-%_%.%~])",
            function (c) return string.format ("%%%02X", string.byte(c)) end)
        str = string.gsub (str, " ", "+")
    end
    return str
end
function PLUGIN:BanListLenght()
	local curr = 0
	for steamid,data in pairs(self.Banlist) do
		curr = curr + 1
	end
	return curr
end
function PLUGIN:cmdHeatmeter(netuser,cmd,args)
	if(not self:isAdmin(netuser)) then return end
	if(not self.Config.SteamAPIKey or self.Config.SteamAPIKey == "") then rust.SendChatToUser( netuser, "®", "You did not configure your steam api: http://steamcommunity.com/dev/apikey") return end
	for _, targetuser in pairs( rust.GetAllNetUsers() ) do
		self:Heatmeter( netuser, targetuser )
	end
end
function PLUGIN:OnUserConnect(netuser)
	if(self.Config.useIPBans) then
		local ip = netuser.networkPlayer.externalIP
		if(self.BanIPlist[ip]) then
			if(self.Banlist[self.BanIPlist[ip]] and self.Banlist[self.BanIPlist[ip]].reason) then
				local reason = tostring(self.Banlist[self.BanIPlist[ip]].reason)
				success, err = self:BanAdd(tostring(rust.GetLongUserID(netuser)),netuser.displayName,reason .. "(Ban Escape)",false)
				netuser:Kick(NetError.Facepunch_Kick_Ban, true)
				rust.BroadcastChat( "®", netuser.displayName .. " was auto banned (IP in Banlist)" )
				return
			else
				print("r-bans: " .. netuser.displayName .. " was found in the IP data base with " .. self.BanIPlist[ip] .. " as steamID, but was not found in the main banlist => auto removed")
				self.BanIPlist[ip] = nil
			end
		end
	end
	if(self.Config.RustDB.CheckAllConnectingPlayersForBans) then
		local steamid = tostring(rust.GetLongUserID(netuser))
		local url = "http://www.rustdb.net/api.php"
		local serverIP = Rust.NetCull.player.internalIP
		local serverPort = Rust.server.port
		local newRustDBEntry = {{["action"] = "banned", ["steamid"] = steamid, ["ip"] = serverIP, ["port"] = serverPort }}
		local bandata = "bandata="..url_encode(json.encode(newRustDBEntry))
		local r = webrequest.Post(url, bandata, function(code, response)
			if(string.sub(response,1,1) ~= nil and string.sub(response,1,1) ~= "0" and string.sub(response,1,1) ~= "") then
				local nbans = string.sub(response,1,string.find(response, "%s"))
				if(nbans ~= nil and nbans ~= "" and tonumber(nbans) ~= nil) then
					if(tonumber(nbans) > 0) then
						local reason = string.sub(response,(string.find(response, "%s")+1))
						if(string.find(reason, "<")) then reason = string.sub(reason,1,(string.find(reason, "<") - 1)) end
						if(self.Config.RustDB.ActivateAutoKick and tonumber(nbans) >= self.Config.RustDB.NumberOfBansNeededForAutoKick) then
							rust.BroadcastChat("[RustDB]","[color red]" .. netuser.displayName .. " has too many bans (" .. nbans ..") on RustDB (" .. reason .. ")! Connection has been rejected")
							rust.SendChatToUser( netuser, "[RustDB]", "[color red]You have been a badboy and have too much bans on RustDB!!")
							netuser:Kick(NetError.Facepunch_Kick_Ban, true)
						elseif(self.Config.RustDB.BroadCastIfBannedPlayer) then
							if(tonumber(nbans) > 1) then
								rust.BroadcastChat("[RustDB]","[color red]" .. netuser.displayName .. " has " .. nbans .. " ban entries in RustDB (" .. reason .. ")")
							else
								rust.BroadcastChat("[RustDB]","[color #CC6600]" .. netuser.displayName .. " has " .. nbans .. " ban entry in RustDB (" .. reason .. ")")
							end
						elseif(self.Config.RustDB.SendToAdminsIfBannedPlayer) then
							for _, targetuser in pairs( rust.GetAllNetUsers() ) do
								if(self:isAdmin(targetuser)) then
									rust.SendChatToUser( netuser, "[RustDB]","[color #CC6600]" .. netuser.displayName .. " has " .. nbans .. " ban entry in RustDB (" .. reason .. ")")
								end
							end
						end
						if(self.Config.RustDB.LogIfBannedPlayer) then
							print("[RustDB] " .. netuser.displayName .. " has " .. nbans .. " ban entry in RustDB. (" .. reason .. ")")
						end
					end
				end
			end
		end)
	end
end
function PLUGIN:Heatmeter(netuser,targetuser)
	local steamid = tostring(rust.GetLongUserID(targetuser))
	local temp = {}
	local url = "https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=" .. self.Config.SteamAPIKey .. "&steamids=" .. steamid
	local request = webrequest.Send(url, function(code, response)
		 if (code == 200 and response ~= "") then
			local json = json.decode(response)
			if (json.response.players[1]) then
				if (tostring(json.response.players[1]['profilestate']) ~= "1") then
					temp.profile = false
					return
				end
				temp.profile = true
				if (json.response.players[1]['communityvisibilitystate'] == 1) then
					temp.block = true
				else
					temp.block = false
				end
				temp.username = json.response.players[1]['personaname']
			end
		end
	end)
	local urltwo = "http://api.steampowered.com/IPlayerService/GetRecentlyPlayedGames/v0001/?key=" .. self.Config.SteamAPIKey .. "&steamid=" .. steamid .. "&format=json"
	local requesttwo = webrequest.Send(urltwo, function(code, response)
		if (code == 200 and response ~= "") then
			local jsontwo = json.decode(response)
			local rust = false
			if (jsontwo.response.games and jsontwo.response.games[1]) then
				for k,data in pairs(jsontwo.response.games) do
					if data["name"] == "Rust" then
						rust = k
						break
					end
				end				
			end
			if(rust) then temp.played = jsontwo.response.games[rust]["playtime_forever"] end
		end
	end)
	local urlthree = "http://api.steampowered.com/ISteamUser/GetPlayerBans/v0001/?key=" .. self.Config.SteamAPIKey .. "&steamids=" .. steamid .. "&format=json"
	local requestthree = webrequest.Send(urlthree, function(code, response)
		if (code == 200 and response ~= "") then
			local jsonthree = json.decode(response)
			local rust = false
			if (jsonthree.players and jsonthree.players[1]) then
				temp.vacban = jsonthree.players[1]['VACBanned']
				temp.nvb = jsonthree.players[1]['NumberOfVACBans']
				temp.lastban = jsonthree.players[1]['DaysSinceLastBan']
			end
		end
		
	end)
	local rustdburl = "http://www.rustdb.net/api.php"
	local serverIP = Rust.NetCull.player.internalIP
	local serverPort = Rust.server.port
	local newRustDBEntry = {{["action"] = "banned", ["steamid"] = steamid, ["ip"] = serverIP, ["port"] = serverPort }}
	local bandata = "bandata="..url_encode(json.encode(newRustDBEntry))
	-- TESTER DE METTRE UN TIMER DE 5S POUR VOIR SI CA FAIT LAG 5S
	local r = webrequest.Post(rustdburl, bandata, function(code, response)
		if(string.sub(response,1,1) ~= nil and string.sub(response,1,1) ~= "0" and string.sub(response,1,1) ~= "") then
			local nbans = string.sub(response,1,string.find(response, "%s"))
			if(nbans ~= nil and nbans ~= "" and tonumber(nbans) ~= nil) then
				temp.rustdbbans = tonumber(nbans)
			else
				temp.rustdbbans = 0
			end
		else
			temp.rustdbbans = 0
		end
		self:SendHeatMeter(netuser,targetuser,temp)
	end)
end
function PLUGIN:SendHeatMeter(netuser,targetuser,temp)
	local heat = self:GenerateHeat(temp)
	local color = "#FFFFFF"
	if(heat == "Very High") then color = "#FF0000" end
	if(heat == "High") then color = "#FF6600" end
	if(heat == "Medium") then color = "#FFCC00" end
	if(temp.rustdbbans > 0 ) then
		rust.SendChatToUser( netuser, "®", "[color " .. color .. "]" .. tostring(targetuser.displayName) .. " - " .. tostring(rust.GetLongUserID(targetuser)) .. " - RustDB: " .. temp.rustdbbans .. " ban(s)"  )
	else
		rust.SendChatToUser( netuser, "®", "[color " .. color .. "]" .. tostring(targetuser.displayName) .. " - " .. tostring(rust.GetLongUserID(targetuser)))
	end
end
function PLUGIN:cmdBanReload(netuser,cmd,args)
	if(not self:isAdmin(netuser)) then return end
	self.ServerInitialized = false
	BanListLoad()
	self:RefreshBanList()
	rust.SendChatToUser( netuser, "®", "BanList Reloaded")
	self.ServerInitialized = true
end
function PLUGIN:cmdIPList(netuser,cmd,args)
	if(not self:isAdmin(netuser)) then return end
	if(not self.Config.useIPBans) then
		rust.SendChatToUser( netuser, "®", "This command was deactivated, useIPBans is set to false")
		return
	end
	local startid = 1
	if(args[1]) then startid = tonumber(args[1]) end
	local curr = 0
	local max = 0
	for ip,bsteamid in pairs(self.BanIPlist) do
		max = max + 1
	end
	rust.SendChatToUser( netuser, "®", "Banlist by IP (" .. startid .. "/" .. max .. ")")
	for ip,bsteamid in pairs(self.BanIPlist) do
		curr = curr + 1
		if(curr >= startid and curr < (startid+20)) then
			if(self.Banlist[bsteamid]) then
				rust.SendChatToUser( netuser, "®", curr .. " - " .. ip .. " - " .. tostring(bsteamid) .. " - " .. tostring(self.Banlist[bsteamid].username) .. " - " .. tostring(self.Banlist[bsteamid].reason)  )
			else
				self.BanIPlist[ip] = nil
				print("r-bans: detected an IP ban with no informations in the banlist: " .. tostring(bsteamid) .. " auto removed")
			end
		end
	end
end
function PLUGIN:cmdRemoveIP(netuser,cmd,args)
	if(not self:isAdmin(netuser)) then return end
	if(not self.Config.useIPBans) then
		rust.SendChatToUser( netuser, "®", "This command was deactivated, useIPBans is set to false")
		return
	end
	if(not args[1]) then
		rust.SendChatToUser( netuser, "®", "Wrong Argument: /removeip IP (This command will only remove an IP from the banlist but not the main ban)")
		return 
	end
	if(not self.BanIPlist[args[1]]) then
		rust.SendChatToUser( netuser, "®", "This IP: " .. args[1] .. " is not in the BanList")
		return
	end
	self.BanIPlist[args[1]] = nil
	self:SaveIP()
	rust.SendChatToUser( netuser, "®", "This IP: " .. args[1] .. " was removed from the database")
end
function PLUGIN:cmdBanIP(netuser,cmd,args)
	if(not self:isAdmin(netuser)) then return end
	if(not self.Config.useIPBans) then
		rust.SendChatToUser( netuser, "®", "This command was deactivated, useIPBans is set to false")
		return
	end
	if(not args[1] or not args[2]) then
		rust.SendChatToUser( netuser, "®", "Wrong Argument: /banip BANID IP (This command is to add an IP to a Banned Player)")
		return 
	end
	if(self.BanIPlist[args[2]]) then
		rust.SendChatToUser( netuser, "®", "This IP is already associated with a ban: " .. tostring(self.BanIPlist[args[2]]))
		return
	end
	local id = tonumber(args[1])
	local curr = 1
	for thetime,steamids in pairs(self:OrderBanListBanData()) do
		for o,steamid in pairs(steamids) do
			if(curr == id) then
				self.BanIPlist[args[2]] = steamid
				rust.SendChatToUser( netuser, "®", curr .. " - " .. tostring(steamid) .. " - " .. self.Banlist[steamid].username .. " - Added IP: " .. args[2])
			end
			curr = curr + 1
		end
	end
	if(not self.BanIPlist[args[2]]) then
		rust.SendChatToUser( netuser, "®", "Error: Wrong BANID, say /banlist to get the full list with banids")
		return
	end
	self:SaveIP()
end
function PLUGIN:cmdPlayerInfo(netuser,cmd,args)
	if(not self:isAdmin(netuser)) then return end
	if(not args[1]) then
		rust.SendChatToUser( netuser, "®", "Wrong Argument: /pi PLAYERID (from /pl)")
		return 
	end
	pid = tonumber(args[1])
	local curr = 1
	for _, targetuser in pairs( rust.GetAllNetUsers() ) do
		if(curr == pid) then
				rust.SendChatToUser( netuser, "®", "Informations of " .. targetuser.displayName)
				local steamid = tostring(rust.GetLongUserID(targetuser))
				local rustdburl = "http://www.rustdb.net/api.php"
				local serverIP = Rust.NetCull.player.internalIP
				local serverPort = Rust.server.port
				local newRustDBEntry = {{["action"] = "banned", ["steamid"] = steamid, ["ip"] = serverIP, ["port"] = serverPort }}
				local bandata = "bandata="..url_encode(json.encode(newRustDBEntry))
				local r = webrequest.Post(rustdburl, bandata, function(code, response)
					if(string.sub(response,1,1) ~= nil and string.sub(response,1,1) ~= "0" and string.sub(response,1,1) ~= "") then
						local nbans = string.sub(response,1,string.find(response, "%s"))
						if(nbans ~= nil and nbans ~= "" and tonumber(nbans) ~= nil) then
							rust.SendChatToUser( netuser, "®", "RustDB: " .. nbans .. " bans")
						else
							rust.SendChatToUser( netuser, "®", "RustDB: 0 bans")
						end
					else
						rust.SendChatToUser( netuser, "®", "RustDB: 0 bans")
					end
				end)
				local url = "https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=" .. self.Config.SteamAPIKey .. "&steamids=" .. steamid
				local request = webrequest.Send(url, function(code, response)
					 if (code == 200 and response ~= "") then
						local json = json.decode(response)
						if (json.response.players[1]) then
							if (tostring(json.response.players[1]['profilestate']) ~= "1") then
								rust.SendChatToUser( netuser, "®", "Profile: Private")
								return
							end
							if (json.response.players[1]['communityvisibilitystate'] == 1) then
								rust.SendChatToUser( netuser, "®", "Profile Blocked: Yes")
							else
								rust.SendChatToUser( netuser, "®", "Profile Blocked: No")
							end
							rust.SendChatToUser( netuser, "®", "Current Name: " .. json.response.players[1]['personaname'])
						end
					end
				end)
				local urltwo = "http://api.steampowered.com/IPlayerService/GetRecentlyPlayedGames/v0001/?key=" .. self.Config.SteamAPIKey .. "&steamid=" .. steamid .. "&format=json"
				local requesttwo = webrequest.Send(urltwo, function(code, response)
					if (code == 200 and response ~= "") then
						local jsontwo = json.decode(response)
						local therust = false
						if (jsontwo.response.games and jsontwo.response.games[1]) then
							for k,data in pairs(jsontwo.response.games) do
								if data["name"] == "Rust" then
									therust = k
									break
								end
							end				
						end
						if(therust) then 
							rust.SendChatToUser( netuser, "®", "Rust Played Time: " .. math.floor(jsontwo.response.games[therust]["playtime_forever"]/60) .. "h") 
						end
					end
				end)
				local urlthree = "http://api.steampowered.com/ISteamUser/GetPlayerBans/v0001/?key=" .. self.Config.SteamAPIKey .. "&steamids=" .. steamid .. "&format=json"
				local requestthree = webrequest.Send(urlthree, function(code, response)
					if (code == 200 and response ~= "") then
						local jsonthree = json.decode(response)
						if (jsonthree.players and jsonthree.players[1]) then
							rust.SendChatToUser( netuser, "®", "VAC Banned: " .. tostring(jsonthree.players[1]['VACBanned']))
							rust.SendChatToUser( netuser, "®", "VAC Bans: " .. tostring(jsonthree.players[1]['NumberOfVACBans']))
							rust.SendChatToUser( netuser, "®", "Time since last VAC Ban: " .. tostring(jsonthree.players[1]['DaysSinceLastBan']))
						end
					end
				end)
		end
		curr = curr + 1
	end
end
function PLUGIN:cmdBanInfo(netuser,cmd,args)
	if(not self:isAdmin(netuser)) then return end
	if(not args[1]) then
		rust.SendChatToUser( netuser, "®", "Wrong Argument: /binfo BANID")
		return 
	end
	local id = tonumber(args[1])
	local curr = 1
	for thetime,steamids in pairs(self:OrderBanListBanData()) do
		for o,steamid in pairs(steamids) do
			if(curr == id) then
				self.ToGetUserInformations = {}
				table.insert(self.ToGetUserInformations,steamid)
				self:GetUserInformations()
				local targetip = false
				if(self.Config.useIPBans) then
					for ip,bsteamid in pairs(self.BanIPlist) do
						if(bsteamid == steamid) then
							targetip = ip
							break
						end
					end
				end
				rust.SendChatToUser( netuser, "®", "Searching ... ( 5secs )" )
				timer.Once( 5, function()
					local heat = self:GenerateHeat(self.Banlist[steamid])
					local color = "#FFFFFF"
					if(heat == "Very High") then color = "#FF0000" end
					if(heat == "High") then color = "#FF6600" end
					if(heat == "Medium") then color = "#FFCC00" end					
					rust.SendChatToUser( netuser, "®", "Heat: [color " .. color .. "]" .. heat )
					rust.SendChatToUser( netuser, "®", "BanID: " .. curr )
					rust.SendChatToUser( netuser, "®", "SteamID: " .. tostring(steamid) )
					rust.SendChatToUser( netuser, "®", "Name: " .. tostring(self.Banlist[steamid].username) )
					rust.SendChatToUser( netuser, "®", "Reason: " .. tostring(self.Banlist[steamid].reason) )
					if(targetip) then
						rust.SendChatToUser( netuser, "®", "Banned IP: " .. tostring(targetip) )
					end
					if(self.Banlist[steamid].rustdbbans) then
						rust.SendChatToUser( netuser, "®", "RustDB Bans: " .. tostring(self.Banlist[steamid].rustdbbans) )
					end
					if(not self.Banlist[steamid].profile) then
						rust.SendChatToUser( netuser, "®", "Profile doesn't exist" )
						return
					end
					if(self.Banlist[steamid].currentname) then rust.SendChatToUser( netuser, "®", "Current Name: " .. tostring(self.Banlist[steamid].currentname) ) end
					if(self.Banlist[steamid].block) then 
						rust.SendChatToUser( netuser, "®", "Profile Block: Yes" )
					else
						rust.SendChatToUser( netuser, "®", "Profile Block: No" )
					end
					if(self.Banlist[steamid].played) then
						rust.SendChatToUser( netuser, "®", "Time played on rust: " .. tostring(self:MinsToHours(self.Banlist[steamid].played)) )
					end
					if(self.Banlist[steamid].vacban) then rust.SendChatToUser( netuser, "®", "Vac Banned: " .. tostring(self.Banlist[steamid].vacban) ) end
					if(self.Banlist[steamid].nvb) then rust.SendChatToUser( netuser, "®", "Number of VAC bans: " .. tostring(self.Banlist[steamid].nvb) ) end
					if(self.Banlist[steamid].lastban) then rust.SendChatToUser( netuser, "®", "Days since last VAC ban: " .. tostring(self.Banlist[steamid].lastban) ) end
				end)
				return
			end
			curr = curr + 1
		end
	end
end
function PLUGIN:PlayerListLenght()
	local curr = 0
	for _, netuser in pairs( rust.GetAllNetUsers() ) do
		curr = curr + 1
	end
	return curr
end
function PLUGIN:cmdPlayerList(netuser,cmd,args)
	if(not self:isAdmin(netuser)) then return end
	local startid = 1
	if(args[1]) then startid = tonumber(args[1]) end
	rust.SendChatToUser( netuser, "®", "=========== PlayerList ============  " .. startid .. "/" .. self:PlayerListLenght())
	rust.SendChatToUser( netuser, "®", "CurrentID - UserID - UserName - SteamID")
	local curr = 1
	for _, targetuser in pairs( rust.GetAllNetUsers() ) do
		if(curr >= startid and curr < (startid+20)) then
			local userid = rust.GetUserID(targetuser)
			rust.SendChatToUser( netuser, "®", curr .. " - " .. tostring(userid) .. " - " .. tostring(targetuser.displayName) .. " - " .. rust.GetLongUserID(targetuser)  )
		end
		curr = curr + 1
	end
end
function PLUGIN:GenerateHeat(data)
	local heat = 0
	if(not data.profile) then return "Very High" end
	if(data.block) then heat = heat + 1 end
	if(not data.played) then
		heat = heat + 1
	else
		if(tonumber(data.played) > 0) then
			if(tonumber(data.played) < 3000) then heat = heat + 1 end
			if(tonumber(data.played) < 12000) then heat = heat + 1 end
		end
	end
	if(data.rustdbbans and data.rustdbbans > 0) then heat = heat + data.rustdbbans end
	if(data.nvb and tonumber(data.nvb) > 0) then return "Very High" end
	if(data.vacban) then return "Very High" end
	if(self.Config.AntiCheatReasons[data.reason]) then return "Very High" end
	if(heat < 1) then 
		return "Low" 
	elseif(heat == 3) then
		return "High"
	elseif(heat > 3) then
		return "Very High"
	end 
	return "Medium"
end
function PLUGIN:OrderBanListBanData()
	local tbl = {}
	for steamid,data in pairs(self.Banlist) do
		if(not data.time) then self.Banlist[steamid].time = util.GetTime() end
		if(not tbl[self.Banlist[steamid].time]) then tbl[self.Banlist[steamid].time] = {} end
		table.insert(tbl[self.Banlist[steamid].time],steamid)
	end
	table.sort(tbl)
	self:Save() 
	return tbl
end
function PLUGIN:cmdBanList(netuser,cmd,args)
	if(not self:isAdmin(netuser)) then return end

	local startid = 1
	if(args[1]) then startid = tonumber(args[1]) end
	rust.SendChatToUser( netuser, "®", "=========== BanList ============ " .. startid .. "/" .. self:BanListLenght())
	local curr = 1
	for thetime,steamids in pairs(self:OrderBanListBanData()) do
		for o,steamid in pairs(steamids) do
			if(curr >= startid and curr < (startid+20)) then
				local heat = self:GenerateHeat(self.Banlist[steamid])
				local color = "#FFFFFF"
				if(heat == "Very High") then color = "#FF0000" end
				if(heat == "High") then color = "#FF6600" end
				if(heat == "Medium") then color = "#FFCC00" end
				rust.SendChatToUser( netuser, "®", "[color " .. color .. "]" .. curr .. " - " .. tostring(steamid) .. " - " .. tostring(self.Banlist[steamid].username) .. " - " .. tostring(self.Banlist[steamid].reason))
			end
			curr = curr + 1
		end
	end
end
function PLUGIN:Unban(steamid)
	local idArr = util.ArrayFromTable( System.Object, { steamid }, 1 )
	cs.convertandsetonarray( idArr, 0, steamid, System.UInt64._type )
	if(BanListContains:Invoke(nil, idArr)) then 
		self.Banlist[steamid] = nil
		rust.RunServerCommand("echo removeid: "..steamid.." was removed from the banlist")
		self:Save()
	else
		rust.RunServerCommand("echo removeid:  couldn't find " .. steamid .. "")
	end
	BanListRemove:Invoke(nil,idArr)
	BanListSave()
	if(self.Config.useIPBans) then
		for ip,bsteamid in pairs(self.BanIPlist) do
			if(bsteamid == steamid) then
				self.BanIPlist[ip] = nil
			end
		end
	end
	local serverIP = Rust.NetCull.player.internalIP
	local serverPort = Rust.server.port
	local newBan = {{["action"] = "unban", ["steamid"] = steamid, ["port"] = serverPort, ["ip"] = serverIP}}
	self:SendToRustDB(newBan)
end
function PLUGIN:cmdBanAdd(netuser,cmd,args)
	if(not self:isAdmin(netuser)) then return end
	if(not args[1]) then
		rust.SendChatToUser( netuser, "®", "Wrong Argument (first): /b STEAMID/USERID/NAME REASON")
		return 
	end
	if(not args[2]) then
		rust.SendChatToUser( netuser, "®", "Wrong Argument (reason is empty): /b STEAMID/USERID/NAME REASON")
		return 
	end
	local reason = ""
	for i=2, #args do
		reason = reason .. args[i] .. " "
	end
	local targetuser = false
	local userid = false
	local steamid = false
	local targetsteamid = false
	local targetname = ""
	if(string.len(args[1]) == 17 and string.match(args[1], "%d%d%d%d%d%d%d%d%d%d%d%d%d%d%d%d%d")) then
		targetuser = self:FindPlayerBySteamID(tostring(args[1]))
		steamid = tostring(args[1])
	elseif(string.len(args[1]) == 7 and string.match(args[1], "%d%d%d%d%d%d%d")) then
		targetuser, userid = self:FindPlayerByUserID(tostring(args[1]))
	else
		targetuser, targetsteamid = self:FindPlayer(netuser,args[1])
	end
	if(not targetuser) then
		rust.Notice(netuser, "No Player was kicked!")
	else
		targetname = targetuser.displayName
	end
	local success
	local err
	if(steamid) then
		success, err = self:BanAdd(steamid,targetname,reason,netuser.displayName)
	elseif(userid) then
		success, err = self:BanAdd(userid,targetname,reason,netuser.displayName)
	else
		if(not targetuser) then return end
		success, err = self:BanAdd(tostring(rust.GetLongUserID(targetuser)),targetname,reason,netuser.displayName)
	end
	if(not success) then
		rust.Notice(netuser, err)
		return
	else
		rust.SendChatToUser( netuser, "®", "SteamID: " .. tostring(err) .. " was added to the banlist" )
		if(targetuser) then
			if(self.Config.useIPBans) then
				self.BanIPlist[targetuser.networkPlayer.externalIP] = err
				self:SaveIP()
			end
			rust.BroadcastChat( "®", "[color #996600]" .. targetuser.displayName .. " was banned from the server for " .. reason )
			targetuser:Kick(NetError.Facepunch_Kick_Ban, true)
		end
	end
end
function PLUGIN:BanAdd(steamid,username,reason,human)
	local idArr = util.ArrayFromTable( System.Object, { steamid }, 1 )
	cs.convertandsetonarray( idArr, 0, steamid, System.UInt64._type )
	if(BanListContains:Invoke(nil, idArr)) then 
		return false, "This user is already banned"
	end
	local newreason = reason
	if(human) then
		newreason = newreason .. " ("..human..")"
	end
	if(not self.Banlist[steamid]) then self.Banlist[steamid] = {} end
	if(username == "" or username == nil) then
		if( self.Config.SteamAPIKey ) then
			local url = "https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=" .. self.Config.SteamAPIKey .. "&steamids=" .. steamid
			local request = webrequest.Send(url, function(code, response)
				 if (code == 200 and response ~= "") then
					local json = json.decode(response)
					if (json.response.players[1]) then
						if (tostring(json.response.players[1]['profilestate']) == "1") then
							username = json.response.players[1]['personaname']
							if(reason ~= "Unknown" and reason ~= nil and reason ~= "") then
								if(self.Config.RustDB.SendToRustDB) then
									local serverIP = Rust.NetCull.player.internalIP
									local serverPort = Rust.server.port
									local newRustDBEntry = {{["action"] = "ban", ["steamid"] = steamid, ["name"] = tostring(username), ["reason"] = tostring(newreason), ["port"] = serverPort, ["ip"] = serverIP} }
									self:SendToRustDB(newRustDBEntry)
								end
							end
						end
					end
				end
			end)
		else
			print("r-bans: You may not upload a ban to rustdb without any names. You may consider using SteamAPIKey!!")
		end
	else
		if(reason ~= "Unknown" and reason ~= nil and reason ~= "") then
			if(self.Config.RustDB.SendToRustDB) then
				local serverIP = Rust.NetCull.player.internalIP
				local serverPort = Rust.server.port
				local newRustDBEntry = {{["action"] = "ban", ["steamid"] = steamid, ["name"] = tostring(username), ["reason"] = tostring(reason), ["port"] = serverPort, ["ip"] = serverIP} }
				self:SendToRustDB(newRustDBEntry)
			end
		end
	end
	local arr = util.ArrayFromTable( System.Object, { steamid, tostring(username), tostring(reason) }, 3 )
	cs.convertandsetonarray( arr, 0, steamid, System.UInt64._type )
	BanListAdd:Invoke(nil, arr)
	BanListSave()
	self.Banlist[steamid] = {}
	self.Banlist[steamid].username = tostring(username)
	self.Banlist[steamid].reason = tostring(reason)
	self.Banlist[steamid].time = util.GetTime()
	
	table.insert(self.ToGetUserInformations,steamid)
	self:GetUserInformations()
	return true, steamid
end
function PLUGIN:FindPlayerBySteamID(userid)
	for _, targetuser in pairs( rust.GetAllNetUsers() ) do
		local targetid = tostring(rust.GetLongUserID( targetuser ))
		if(targetid == userid) then
			return targetuser
		end
	end
	return false
end
function PLUGIN:FindPlayerByUserID(userid)
	for _, targetuser in pairs( rust.GetAllNetUsers() ) do
		local targetid = tostring(rust.GetUserID( targetuser ))
		if(targetid == userid) then
			return targetuser, tostring(rust.GetLongUserID( targetuser ))
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
	return targetuser, tostring(rust.GetLongUserID( targetuser ))
end
function PLUGIN:cmdBanRemove(netuser,cmd,args)
	if(not self:isAdmin(netuser)) then return end
	if(not args[1]) then
		rust.SendChatToUser( netuser, "®", "Wrong Argument: /br BANID/STEAMID")
		return 
	end
	local id = false
	local steamid = false
	if(string.len(args[1]) == 17) then
		steamid = args[1]
	else
		id = tonumber(args[1])
	end
	
	if(id) then
		local curr = 1
		for thetime,steamids in pairs(self:OrderBanListBanData()) do
			for o,fsteamid in pairs(steamids) do
				if(curr == id) then
					steamid = fsteamid
					break
				end
				curr = curr + 1
			end
			if(steamid) then break end
		end
		if(not steamid) then
			rust.SendChatToUser( netuser, "®", "Wrong BanID, say /bl to see the banlist")
			return
		end
	end
	if(self.Banlist[steamid]) then
		local success, err = self:RemoveSteamID(steamid)
		if(not success) then
			rust.SendChatToUser( netuser, "®", err)
			return
		end
		rust.SendChatToUser( netuser, "®", err .. " (" .. steamid .. ") was removed from banlist")
	end
end
function PLUGIN:RemoveSteamID(steamid)
	local idArr = util.ArrayFromTable( System.Object, { steamid }, 1 )
	cs.convertandsetonarray( idArr, 0, steamid, System.UInt64._type )
	if(not BanListContains:Invoke(nil, idArr)) then 
		self.Banlist[steamid] = nil
		self:Save()
		return false, "This user couldn't be found in the banlist (debug)"
	end
	local name = self.Banlist[steamid].username
	self:Unban(steamid)
	return true, name
end
function PLUGIN:LoadDefaultConfig()
	self.Config.SteamAPIKey = ""
	self.Config.FirstLaunch = true
	self.Config.Version = "1.8.2"
	self.Config.useIPBans = true
	self.Config.RustDB = {}
	self.Config.RustDB.SendToRustDB = true
	self.Config.RustDB.CheckAllConnectingPlayersForBans = true
	self.Config.RustDB.BroadCastIfBannedPlayer = true
	self.Config.RustDB.ActivateAutoKick = true
	self.Config.RustDB.NumberOfBansNeededForAutoKick = 2
	self.Config.RustDB.SendToAdminsIfBannedPlayer = false
	self.Config.RustDB.LogIfBannedPlayer = true
	self.Config.ForceKickOnBan = true
	self.Config.AntiCheatReasons = {
		["rSpeedHack"]=true,
		["rFlyhack"]=true,
		["rAimbot"]=true
	}
end
function PLUGIN:OnServerInitialized()
	self.ServerInitialized = true
	self:RefreshBanList()
end

function PLUGIN:explode(div,str)
	if (div=='') then return false end
	local pos,arr = 0,{}
	for st,sp in function() return string.find(str,div,pos,true) end do
		table.insert(arr,string.sub(str,pos,st-1)) -- Attach chars left of current divider
		pos = sp + 1 -- Jump past current divider
	end
	table.insert(arr,string.sub(str,pos)) -- Attach chars right of last divider
	return arr
end
function PLUGIN:RefreshBanList()	
	self.ToGetUserInformations = {}
	local tempbanlist = {}
	local BanListStringEx = util.GetStaticMethod( BanList, "BanListStringEx" )
	local BanListExplode = self:explode("\n",tostring(BanListStringEx()))
	for i,data in pairs(BanListExplode) do
		local steamid = string.match(data, "%d%d%d%d%d%d%d%d%d%d%d%d%d%d%d%d%d")
		if(steamid) then
			if(not self.Banlist[steamid]) then
				local patern = '([%a"]+)'
				local start,endpos,username,start2,endpos2,reason
				start,endpos,username = string.find(data,patern)
				if(username) then
					start2,endpos2,reason = string.find(data,patern,endpos+1)
				end
				if(username and reason) then
					username = string.gsub(username,'"','',2)
					reason = string.gsub(reason,'"','',2)
					tempbanlist[steamid] = {}
					if(not self.Config.FirstLaunch) then
						tempbanlist[steamid].username = username
						tempbanlist[steamid].reason = reason
					else
						tempbanlist[steamid].reason = username
					end
					table.insert(self.ToGetUserInformations,steamid)
				end
			else
				tempbanlist[steamid] = self.Banlist[steamid]
			end
		end
	end
	self.Banlist = tempbanlist
	if(self.Timer) then self.Timer:Destroy() end
	self:GetUserInformations()
	self.Config.FirstLaunch = false
	config.Save( "r-bans" )
end
function PLUGIN:GetUserInformations()
	if(self.Timer) then self.Timer:Destroy() end
	local data = false
	for k,steamid in pairs(self.ToGetUserInformations) do
		self:GetUserThenGameInfo( steamid )
		data = k
	end
	--if(not data) then self:Save() return end
	--table.remove(self.ToGetUserInformations,data)
	--self.Timer = timer.Once( 0.5 , function() self:GetUserInformations() end )
end

function PLUGIN:Save()
	self.BanFile:SetText(json.encode(self.Banlist))
	self.BanFile:Save()
end

function PLUGIN:SaveIP()
	self.BanIPFile:SetText(json.encode(self.BanIPlist))
	self.BanIPFile:Save()
end

function PLUGIN:GetUserThenGameInfo( steamid )
	if(not self.Config.SteamAPIKey or self.Config.SteamAPIKey == "") then print("You did not configure your steam api: http://steamcommunity.com/dev/apikey") end
	if(not self.Banlist[steamid]) then self.Banlist[steamid] = {} end
	local url = "https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=" .. self.Config.SteamAPIKey .. "&steamids=" .. steamid
	local request = webrequest.Send(url, function(code, response)
		 if (code == 200 and response ~= "") then
			local json = json.decode(response)
			if (json.response.players[1]) then
				if (tostring(json.response.players[1]['profilestate']) ~= "1") then
					self.Banlist[steamid].profile = false
					return
				end
				self.Banlist[steamid].profile = true
				if (json.response.players[1]['communityvisibilitystate'] == 1) then
					self.Banlist[steamid].block = true
				else
					self.Banlist[steamid].block = false
				end
				if(not self.Banlist[steamid].username or self.Banlist[steamid].username == "" ) then
					self.Banlist[steamid].username = json.response.players[1]['personaname']
					self.Banlist[steamid].currentname = json.response.players[1]['personaname']
				else
					self.Banlist[steamid].currentname = json.response.players[1]['personaname']
				end
				self:MakeTheBanListGood(steamid)
			end
		end
	end)
	local urltwo = "http://api.steampowered.com/IPlayerService/GetRecentlyPlayedGames/v0001/?key=" .. self.Config.SteamAPIKey .. "&steamid=" .. steamid .. "&format=json"
	local requesttwo = webrequest.Send(urltwo, function(code, response)
		if (code == 200 and response ~= "") then
			local jsontwo = json.decode(response)
			local rust = false
			if (jsontwo.response.games and jsontwo.response.games[1]) then
				for k,data in pairs(jsontwo.response.games) do
					if data["name"] == "Rust" then
						rust = k
						break
					end
				end				
			end
			if(rust) then self.Banlist[steamid].played = jsontwo.response.games[rust]["playtime_forever"] end
		end
	end)
	local urlthree = "http://api.steampowered.com/ISteamUser/GetPlayerBans/v0001/?key=" .. self.Config.SteamAPIKey .. "&steamids=" .. steamid .. "&format=json"
	local requestthree = webrequest.Send(urlthree, function(code, response)
		if (code == 200 and response ~= "") then
			local jsonthree = json.decode(response)
			local rust = false
			if (jsonthree.players and jsonthree.players[1]) then
				self.Banlist[steamid].vacban = jsonthree.players[1]['VACBanned']
				self.Banlist[steamid].nvb = jsonthree.players[1]['NumberOfVACBans']
				self.Banlist[steamid].lastban = jsonthree.players[1]['DaysSinceLastBan']
			end
		end
	end)
	local rustdburl = "http://www.rustdb.net/api.php"
	local serverIP = Rust.NetCull.player.internalIP
	local serverPort = Rust.server.port
	local newRustDBEntry = {{["action"] = "banned", ["steamid"] = steamid, ["ip"] = serverIP, ["port"] = serverPort }}
	local bandata = "bandata="..url_encode(json.encode(newRustDBEntry))
	-- TESTER DE METTRE UN TIMER DE 5S POUR VOIR SI CA FAIT LAG 5S
	local r = webrequest.Post(rustdburl, bandata, function(code, response)
		if(string.sub(response,1,1) ~= nil and string.sub(response,1,1) ~= "0" and string.sub(response,1,1) ~= "") then
			local nbans = string.sub(response,1,string.find(response, "%s"))
			if(nbans ~= nil and nbans ~= "" and tonumber(nbans) ~= nil) then
				self.Banlist[steamid].rustdbbans = tonumber(nbans)
			else
				self.Banlist[steamid].rustdbbans = 0
			end
		else
			self.Banlist[steamid].rustdbbans = 0
		end
		self:Save()
	end)
end
function PLUGIN:MakeTheBanListGood(steamid)
	if(self.Banlist[steamid] and self.Banlist[steamid].profile) then
		local idArr = util.ArrayFromTable( System.Object, { steamid }, 1 )
		cs.convertandsetonarray( idArr, 0, steamid, System.UInt64._type )
		BanListRemove:Invoke(nil, idArr)
		local arr = util.ArrayFromTable( System.Object, { steamid, tostring(self.Banlist[steamid].username), tostring(self.Banlist[steamid].reason) }, 3 )
		cs.convertandsetonarray( arr, 0, steamid, System.UInt64._type )
		BanListAdd:Invoke(nil, arr)
		BanListSave()
	end
end

function PLUGIN:MinsToHours(timestamp)
	local msg = ""
	local hours = math.floor(timestamp / 60)
	if(hours >= 1) then
		msg = msg .. hours .. "h "
		timestamp = timestamp - (hours * 60)
	end
	local mins = math.floor(timestamp)
	if(mins >= 1) then
		msg = msg .. mins .. "mins"
	end
	return msg
end
function PLUGIN:makeargs(msg)
	local args = {}
	for arg in msg:gmatch( "%S+" ) do
		args[ #args + 1 ] = arg
	end

	-- Loop each argument and merge arguments surrounded by double quotes
	local newargs = {}
	local inlongarg = false
	local longarg = ""
	for i=1, #args do
		local str = args[i]
		local l = str:len()
		local handled = false
		if (l > 1) then
			if (str:sub( 1, 1 ) == "\"") then
				inlongarg = true
				longarg = longarg .. str .. " "
				handled = true
			end
			if (str:sub( l, l ) == "\"") then
				inlongarg = false
				if (not handled) then longarg = longarg .. str .. " " end
				newargs[ #newargs + 1 ] = longarg:sub( 2, longarg:len() - 2 )
				longarg = ""
				handled = true
			end
		end
		if (not handled) then
			if (inlongarg) then
				longarg = longarg .. str .. " "
			else
				newargs[ #newargs + 1 ] = str
			end
		end
	end
	return newargs
end
function PLUGIN:OnRunCommand(arg, wantreply)
    local command = ""
    if (arg.Class) then
        command = arg.Class .. "." .. arg.Function
    else
        command = arg.Function
    end
	if(self.ServerInitialized) then
		if(command == "global.unbanall") then
			self.Banlist = {}
			self.BanIPlist = {}
			self:SaveIP()
			self:Save()
		elseif(command == "global.banid") then
			local args = self:makeargs(arg.ArgsStr)
			if(not args[1]) then
				return
			end
			if(not string.len(args[1]) == 17 or not string.match(args[1], "%d%d%d%d%d%d%d%d%d%d%d%d%d%d%d%d%d")) then
				return
			end
			local steamid = args[1]
			local username = ""
			local reason
			if(not args[2]) then
				reason = "Unknown"
			end
			if(args[2] and not args[3]) then
				reason = tostring(args[2])
			end
			if(args[2] and args[3]) then
				username = tostring(args[2])
				reason = tostring(args[3])
			end
			
			self:BanAdd(steamid,username,reason,false)
			
			if(self.Config.useIPBans or self.Config.ForceKickOnBan) then
				timer.Once(0.2, function()
					local targetplayer = self:FindPlayerBySteamID(steamid)
					if(targetplayer) then 
						if(self.Config.useIPBans) then
							self.BanIPlist[targetuser.networkPlayer.externalIP] = steamid
							self:SaveIP()
						end
						if(self.Config.ForceKickOnBan) then
							targetplayer:Kick(NetError.Facepunch_Kick_Ban, true)
						end
					end
				end)
			end
		elseif(command == "global.removeid") then
			local args = arg.ArgsStr
			if(not args) then
				return true
			end
			self:Unban(args)
			return false
		elseif(command == "global.ban") then
			local args = self:makeargs(arg.ArgsStr)
			if(not args[1]) then return true end
			local b, targetuser = rust.FindNetUsersByName(args[1])
			if(not b) then return true end
			local targetid = tostring(rust.GetLongUserID( targetuser ))
			local reason
			if(not args[2]) then 
				reason = "Unknown"
			else
				reason = tostring(args[2])
			end
			self:BanAdd(targetid,targetuser.displayName,reason,false)
			if(self.Config.useIPBans or self.Config.ForceKickOnBan) then
				timer.Once(0.2, function()
					local targetplayer = self:FindPlayerBySteamID(steamid)
					if(targetplayer) then 
						if(self.Config.useIPBans) then
							self.BanIPlist[targetuser.networkPlayer.externalIP] = steamid
							self:SaveIP()
						end
						if(self.Config.ForceKickOnBan) then
							targetplayer:Kick(NetError.Facepunch_Kick_Ban, true)
						end
					end
				end)
			end
		end	
	end
end
function PLUGIN:isAdmin(netuser)
	if(netuser:CanAdmin()) then return true end
	if(self.oxmin_plugin and self.oxmin_plugin:HasFlag( netuser, 4 )) then return true end
	if(self.flags_plugin and self.flags_plugin:HasFlag(tostring( rust.GetLongUserID(netuser) ), "ban" )) then return true end
	return false
end
function PLUGIN:SendToRustDB(data)
    local url = "http://www.rustdb.net/api.php"
    local bandata = "bandata="..url_encode(json.encode(data))
    local r = webrequest.Post(url, bandata, function(code, response) end)
    if(not r) then
        print(self.Title..": ERROR - Webrequest failed. Unknown error")
    end
    if(debug == true) then
        print(self.Title..": DEBUG - r: "..tostring(r))
    end
end
