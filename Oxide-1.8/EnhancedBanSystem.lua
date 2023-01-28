PLUGIN.Title = "Enhanced Ban System"
PLUGIN.Author = "#Domestos"
PLUGIN.Version = "1.0.1"
PLUGIN.Description = "Ban system with advanced features"
PLUGIN.ResourceId = "490"
PLUGIN.ConfigFile = "EnhancedBanSystem"
PLUGIN.BanList = "ebsbanlist"

-- ****************************
-- Debug Mode
-- Used to enable/disable debug messages
-- ****************************
local debug = false


-- ****************************
-- PLUGIN:Init()
-- ****************************
function PLUGIN:Init()
    self:LoadConfig()
    self:LoadDataFile()
    self:LoadChatCommands()
    print(self.Title.." v"..self.Version.." loaded.")
end

-- ****************************
-- PLUGIN:LoadChatCommands()
-- ****************************
function PLUGIN:LoadChatCommands()
    self:AddChatCommand(self.Config.ChatCommands.ban, self.cmdBan)
    self:AddChatCommand(self.Config.ChatCommands.unban, self.cmdUnBan)
    self:AddChatCommand(self.Config.ChatCommands.check, self.cmdCheckBan)
    self:AddChatCommand(self.Config.ChatCommands.kick, self.cmdKick)
    self:AddCommand("ebs", "ban", self.ccmdBan)
    self:AddCommand("ebs", "unban", self.ccmdUnBan)
    self:AddCommand("ebs", "kick", self.ccmdKick)
end

-- ****************************
-- PLUGIN:Load Config()
-- ****************************
function PLUGIN:LoadConfig()
    local b, res = config.Read(self.ConfigFile)
    self.Config = res or {}
    -- Config settings
    self.Config.Settings = self.Config.Settings or {}
    self.Config.Settings.BroadcastBans = self.Config.Settings.BroadcastBans or self.Config.broadcastBans or "false"
    self.Config.Settings.LogToConsole = self.Config.Settings.LogToConsole or self.Config.logToConsole or "true"
    self.Config.Settings.CheckForEveryone = self.Config.Settings.CheckForEveryone or self.Config.checkForEveryone or "false"
    self.Config.Settings.CollectDataForRustDB = self.Config.Settings.CollectDataForRustDB or "true"
    -- Config chat commands
    self.Config.ChatCommands = self.Config.ChatCommands or {
        ["ban"] = "ebsban",
        ["unban"] = "ebsunban",
        ["kick"] = "ebskick",
        ["check"] = "ebscheck"
    }
    -- Remove old settings
    self.Config.broadcastBans = nil -- removed in v1.0
    self.Config.logToConsole = nil -- removed in v1.0
    self.Config.checkForEveryone = nil -- removed in v1.0
    -- Save config file
    config.Save(self.ConfigFile, {
        indent = true,
        keyorder = {
            "Settings",
                "BroadcastBans",
                "LogToConsole",
                "CheckForEveryone",
                "CollectDataForRustDB",
            "ChatCommands",
                "ban",
                "unban",
                "kick",
                "check"
        }
    })
end

-- ****************************
-- PLUGIN:LoadDataFile()
-- ****************************
function PLUGIN:LoadDataFile()
    self.DataFile = util.GetDatafile(self.BanList)
    local data = self.DataFile:GetText()
    if(data == "") then
        self.Data = {}
    else
        self.Data = json.decode(data)
    end
end

-- ****************************
-- PLUGIN:Save()
-- ****************************
function PLUGIN:Save()
    self.DataFile:SetText(json.encode(self.Data))
    self.DataFile:Save()
end

-- ****************************
-- PLUGIN:PostInit()
-- ****************************
function PLUGIN:PostInit()
    self:LoadFlags()
    self:CleanUpBanList()
end

-- ****************************
-- PLUGIN:Load Flags()
-- ****************************
function PLUGIN:LoadFlags()
    -- Flags Plugin
    self.flagsPlugin = plugins.Find("flags")
    if(self.flagsPlugin) then
        self.flagsPlugin:AddFlagsChatCommand(self, self.Config.ChatCommands.ban, {"ebs"}, self.cmdBan)
        self.flagsPlugin:AddFlagsChatCommand(self, self.Config.ChatCommands.unban, {"ebs"}, self.cmdUnBan)
        self.flagsPlugin:AddFlagsChatCommand(self, self.Config.ChatCommands.kick, {"ebs"}, self.cmdKick)
    end
    -- Oxmin Plugin
    self.oxminPlugin = plugins.Find("oxmin")
    if(self.oxminPlugin) then
        self.FLAG_EBS = oxmin.AddFlag("ebs")
        self.oxminPlugin:AddExternalOxminChatCommand(self, self.Config.ChatCommands.ban, {self.FLAG_EBS}, self.cmdBan)
        self.oxminPlugin:AddExternalOxminChatCommand(self, self.Config.ChatCommands.unban, {self.FLAG_EBS}, self.cmdUnBan)
        self.oxminPlugin:AddExternalOxminChatCommand(self, self.Config.ChatCommands.kick, {self.FLAG_EBS}, self.cmdKick)
    end
end

-- ****************************
-- PLUGIN:HasPersmission()
-- ****************************
function PLUGIN:HasPermission(netuser)
    if(netuser:CanAdmin()) then
        return true
    elseif((self.oxminPlugin ~= nil) and (self.oxminPlugin:HasFlag(netuser, self.FLAG_EBS))) then
        return true
    elseif((self.flagsPlugin ~= nil) and (self.flagsPlugin:HasFlag(netuser, "ebs"))) then
        return true
    else
        return false
    end
end

-- ****************************
-- PLUGIN:CleanUpBanList()
-- Removes expired bans from the banlist
-- ****************************
function PLUGIN:CleanUpBanList()
    local now = util.GetTime()
    for key, value in pairs(self.Data) do
        if(self.Data[key].expiration < now and self.Data[key].expiration ~= 0) then
            table.remove(self.Data, key)
            self:Save()
        end
    end
end

-- ****************************
-- PLUGIN:NoticeAll()
-- Sends an popup to all online users
-- ****************************
function PLUGIN:NoticeAll(msg)
    local allNetuser = rust.GetAllNetUsers()
    for key, netuser in pairs(allNetuser) do
        rust.Notice(netuser, msg)
    end
end

-- ****************************
-- GetTargetNetuser()
-- Searches for a netuser by name, id or ip
-- ****************************
local function GetTargetNetuser(input)
    local b, netuser = rust.FindNetUsersByName(input)
    if(b == true) then -- one single user is found
        return netuser
    end
    local allNetuser = rust.GetAllNetUsers()
    for key, netuser in pairs(allNetuser) do
        if((rust.GetLongUserID(netuser) == input) or (netuser.networkPlayer.externalIP == input)) then
            return netuser
        end
    end
    return false
end

-- ****************************
-- split()
-- split a string into a table
-- ****************************
local function split(str, sep)
    local t = {}
    for word in string.gmatch(str, "[^"..sep.."]+") do
        table.insert(t, word)
    end
    return t
end

-- ****************************
-- SteamIDToSteam64()
-- Converts a steamid to a steam64id
-- ****************************
local function SteamIDToSteam64(steamid)
    local tokens = split(steamid, ":")
    local serverID, authID
    if (tonumber(tokens[3]) > tonumber(tokens[2])) then
        serverID = tokens[2]
        authID = tokens[3]
    else
        serverID = tokens[3]
        authID = tokens[2]
    end
    return "7656" .. (1197960265728 + (authID * 2) + serverID)
end

-- ****************************
-- url_Encode()()
-- Url encodes a string to send it per webrequest
-- ****************************
local function url_encode(str)
    if (str) then
        str = string.gsub (str, "\n", "\r\n")
        str = string.gsub (str, "([^%w %-%_%.%~])",
            function (c) return string.format ("%%%02X", string.byte(c)) end)
        str = string.gsub (str, " ", "+")
    end
    return str
end

-- ****************************
-- PLUGIN:ccmdBan()
-- Console command to trigger cmdBan()
-- ****************************
function PLUGIN:ccmdBan(arg)
    local netuser = arg.argUser
    if(netuser and not netuser:CanAdmin()) then
        arg:ReplyWith("You dont have permission to use this command")
        return
    end
    local args = split(arg.ArgsStr, " ")
    self:cmdBan(netuser, args)
    return true
end

-- ****************************
-- PLUGIN:cmdBan()
-- Handle bans
-- ****************************
function PLUGIN:cmdBan(netuser, cmd, args)
    -- args[1] == name, args[2] == reason, args[3] == time
    if(netuser and not self:HasPermission(netuser)) then
        rust.Notice(netuser, "You dont have permission to use this command")
        return
    end
    if(type(cmd) == "table") then args = cmd end
    if(not args[1] or not args[2]) then
        if(not netuser) then
            print("Syntax: 'ebs.ban name|steam64id|ip reason time[m|h|d]' or 'ebs.ban name|steam64id|ip reason' for permanent ban")
        else
            rust.Notice(netuser, "Syntax: '/"..self.Config.ChatCommands.ban.." name|steam64id|ip reason time[m|h|d]' or '/"..self.Config.ChatCommands.ban.." name|steam64id|ip reason' for permanent ban")
        end
        return
    end
    -- Set target vars
    local targetNetuser = GetTargetNetuser(args[1])
    if(targetNetuser == false) then
        if(not netuser) then
            print("No player found with that name|steam64id|ip")
        else
            rust.Notice(netuser, "No player found with that name|steam64id|ip")
        end
        return
    end
    local targetName = util.QuoteSafe(targetNetuser.displayName)
    local targetIP = targetNetuser.networkPlayer.externalIP
    local targetSteam64 = rust.GetLongUserID(targetNetuser)
    -- Check if player is already banned
    local now = util.GetTime()
    for key, value in pairs(self.Data) do
        if(self.Data[key].netuser == rust.GetLongUserID(targetNetuser)) then
            if(self.Data[key].expiration > now or self.Data[key].expiration == 0) then
                if(not netuser) then
                    print(targetName.." is already banned")
                else
                    rust.Notice(netuser, targetName..' is already banned!')
                end
                return
            else
                self:CleanUpBanList()
            end
        end
    end
    local reason = args[2]
    local serverIP = Rust.NetCull.player.internalIP
    local serverPort = Rust.server.port
    if(not args[3]) then -- If no time is given ban permanently
        local expiration = 0
        -- Insert data into the banlist
        local newBanlistEntry = {['netuser'] = targetSteam64, ['name'] = targetName, ['expiration'] = expiration, ['externalIP'] = targetIP, ["reason"] = reason }
        table.insert(self.Data, newBanlistEntry)
        self:Save()
        -- Kick target from server
        if(debug) then
            print(self.Title.."----- DEBUG cmdBan() -----")
            print("kick: "..targetName)
            print("--------------------------")
        else
            targetNetuser:Kick(NetError.Facepunch_Kick_Ban, true)
        end
        -- Send data to rustdb.net
        if(self.Config.Settings.CollectDataForRustDB == "true") then
            local newRustDBEntry = {{["action"] = "ban", ["steamid"] = targetSteam64, ["name"] = targetName, ["reason"] = reason, ["port"] = serverPort, ["ip"] = serverIP} }
            self:SendData(newRustDBEntry)
        end
        -- Output bans
        if(self.Config.Settings.BroadcastBans == "true") then
            self:NoticeAll(targetName.." has been permanently banned")
        else
            if(not netuser) then
                print(targetName.." has been permanently banned")
            else
                rust.Notice(netuser, targetName.." has been permanently banned")
            end
        end
        if(self.Config.Settings.LogToConsole == "true") then
            if(not netuser) then
                print(self.Title..": remote console permanently banned "..targetName.." for "..reason)
            else
                print(self.Title..": "..netuser.displayName.." permanently banned "..targetName.." for "..reason)
            end
        end
    else -- if time is given ban for time
        -- Check if time input is a valid format
        local c = string.match(args[3], "^%d*[mhd]$")
        if(string.len(args[3]) < 2 or c == nil) then
            if(not netuser) then
                print("Invalid time format!")
            else
                rust.Notice(netuser, "Invalid time format!")
            end
            return
        end
        -- Build time format
        local now = util.GetTime()
        local banTime = tonumber(string.sub(args[3], 1, -2))
        local timeUnit = string.sub(args[3], -1)
        local timeMult, timeUnitLong
        if(timeUnit == "m") then
            timeMult = 60
            timeUnitLong = "minutes"
        elseif(timeUnit == "h") then
            timeMult = 3600
            timeUnitLong = "hours"
        elseif(timeUnit == "d") then
            timeMult = 86400
            timeUnitLong = "days"
        end
        local expiration = (now + (banTime * timeMult))
        -- Insert data into the banlist
        local newBanlistEntry = {["netuser"] = targetSteam64, ["name"] = targetName, ["expiration"] = expiration, ["externalIP"] = targetIP, ["reason"] = reason}
        table.insert(self.Data, newBanlistEntry)
        self:Save()
        -- Kick target from server
        if(debug) then
            print(self.Title.."----- DEBUG cmdBan() -----")
            print("kick: "..targetName)
            print("--------------------------")
        else
            targetNetuser:Kick(NetError.Facepunch_Kick_Ban, true)
        end
        -- Send data to rustdb.net
        if(self.Config.Settings.CollectDataForRustDB == "true") then
            local newRustDBEntry = {{["action"] = "ban", ["steamid"] = targetSteam64, ["name"] = targetName, ["reason"] = reason, ["port"] = serverPort, ["ip"] = serverIP}}
            self:SendData(newRustDBEntry)
        end
        -- Output bans
        if(self.Config.Settings.BroadcastBans == "true") then
            self:NoticeAll(targetName.." has been banned for "..banTime.." "..timeUnitLong)
        else
            if(not netuser) then
                print(targetName.." has been banned for "..banTime.." "..timeUnitLong)
            else
                rust.Notice(netuser, targetName.." has been banned for "..banTime.." "..timeUnitLong)
            end
        end
        if(self.Config.Settings.LogToConsole == "true") then
            if(not netuser) then
                print(self.Title..": remote console banned "..targetName.." for "..banTime.." "..timeUnitLong.." for "..reason)
            else
                print(self.Title..": "..netuser.displayName.." banned "..targetName.." for "..banTime.." "..timeUnitLong.." for "..reason)
            end
        end
    end
end

-- ****************************
-- PLUGIN:ccmdunBan()
-- Console command to trigger cmdUnBan()
-- ****************************
function PLUGIN:ccmdUnBan(arg)
    local netuser = arg.argUser
    if(netuser and not netuser:CanAdmin()) then
        arg:ReplyWith("You dont have permission to use this command")
        return
    end
    local args = split(arg.ArgsStr, " ")
    self:cmdUnBan(netuser, args)
    return true
end

-- ****************************
-- PLUGIN:cmdUnBan()
-- Handle unbans
-- ****************************
function PLUGIN:cmdUnBan(netuser, cmd, args)
    if(netuser and not self:HasPermission(netuser)) then
        rust.Notice(netuser, "You dont have permission to use this command")
        return
    end
    if(type(cmd) == "table") then args = cmd end
    if(not args[1]) then
        if(not netuser) then
            print("Syntax: 'ebs.unban name|steam64id|ip'")
        else
            rust.Notice(netuser, "Syntax: '/"..self.Config.ChatCommands.unban.." name|steam64id|ip'")
        end
        return
    end
    local banned = false
    local target = util.QuoteSafe(args[1])
    for key, value in pairs(self.Data) do
        if(self.Data[key].name == target or self.Data[key].netuser == target or self.Data[key].externalIP == target) then
            local targetSteam64 = self.Data[key].netuser
            table.remove(self.Data, key)
            self:Save()
            banned = true
            -- Send data to rustdb
            if(self.Config.Settings.CollectDataForRustDB == "true") then
                local serverIP = Rust.NetCull.player.internalIP
                local serverPort = Rust.server.port
                local newBan = {{["action"] = "unban", ["steamid"] = targetSteam64, ["port"] = serverPort, ["ip"] = serverIP}}
                self:SendData(newBan)
            end
            -- Output the bans
            if(self.Config.Settings.BroadcastBans == "true") then
                self:NoticeAll(target.." has been unbanned")
            else
                if(not netuser) then
                    print(target.." has been unbanned")
                else
                    rust.Notice(netuser, target.." has been unbanned")
                end
            end
            if(self.Config.Settings.LogToConsole == "true") then
                if(not netuser) then
                    print(self.Title..": remote console unbanned "..target)
                else
                    print(self.Title..": "..netuser.displayName.." unbanned "..target)
                end
            end
        end
    end
    -- Output if target isnt banned
    if(banned == false) then
        if(not netuser) then
            print(target.." not found in banlist")
        else
            rust.Notice(netuser, target.." not found in banlist")
        end
    end
end

-- ****************************
-- PLUGIN:ccmdKick()
-- Console command to trigger cmdKick()
-- ****************************
function PLUGIN:ccmdKick(arg)
    local netuser = arg.argUser
    if(netuser and not netuser:CanAdmin()) then
        arg:ReplyWith("You dont have permission to use this command")
        return
    end
    local args = split(arg.ArgsStr, " ")
    self:cmdKick(netuser, args)
    return true
end

-- ****************************
-- PLUGIN:cmdKick()
-- Handle kicks
-- ****************************
function PLUGIN:cmdKick(netuser, cmd, args)
    if(netuser and not self:HasPermission(netuser)) then
        rust.Notice(netuser, "You dont have permission to use this command")
        return
    end
    if(type(cmd) == "table") then args = cmd end
    if(not args[1]) then
        if(not netuser) then
            print("Syntax: 'ebs.kick name|steam64id|ip reason'")
        else
            rust.Notice(netuser, "Syntax: '/"..self.Config.ChatCommands.kick.." name|steam64id|ip reason'")
        end
        return
    end
    -- Check if reason is given
    local reason
    if(args[2]) then
        reason = tostring(args[2])
    end
    -- Build target vars
    local targetNetuser = GetTargetNetuser(args[1])
    if(targetNetuser == false) then
        if(not netuser) then
            print("No player found with that name|steam64id|ip")
        else
            rust.Notice(netuser, "No player found with that name|steam64id|ip")
        end
        return
    end
    local targetName = targetNetuser.displayName
    local targetInfo = targetName.." ("..rust.GetLongUserID(targetNetuser)..")"
    -- Kick player
    targetNetuser:Kick(NetError.Facepunch_Kick_RCON, true)
    -- Output the bans
    if(self.Config.Settings.BroadcastBans == "true") then
        if(reason ~= nil) then
            self:NoticeAll(targetName.." has been kicked for "..reason)
        else
            self:NoticeAll(targetName.." has been kicked")
        end
    else
        if(not netuser) then
            print(targetName.." has been kicked")
        else
            rust.Notice(netuser, targetName.." has been kicked")
        end
    end
    if(self.Config.Settings.LogToConsole == "true") then
        if(not netuser) then
            print(self.Title..": "..targetInfo.." got kicked per remote console")
        else
            print(self.Title..": "..netuser.displayName.." kicked "..targetInfo)
        end
    end
end

-- ****************************
-- PLUGIN:cmdCheckBan()
-- Handle ban checks
-- ****************************
function PLUGIN:cmdCheckBan(netuser, cmd, args)
    if((self:HasPermission(netuser)) or (self.Config.Settings.CheckForEveryone == "true")) then
        if(type(cmd) == "table") then args = cmd end
        if(not args[1]) then
            rust.Notice(netuser, "Syntax: '/"..self.Config.ChatCommands.check.." name|steam64id|ip'")
            return
        end
        local target = args[1]
        local banned = false
        local now = util.GetTime()
        for key, value in pairs(self.Data) do
            if(self.Data[key].name == util.QuoteSafe(target) or self.Data[key].netuser == target or self.Data[key].externalIP == target) then
                if(self.Data[key].expiration > now or self.Data[key].expiration == 0) then
                    if(self.Data[key].expiration == 0) then
                        rust.Notice(netuser, target.." is permanently banned")
                        banned = true
                    else
                        local expiration = self.Data[key].expiration
                        local bantime = expiration - now
                        local days = string.format("%02.f", math.floor(bantime / 86400))
                        local hours = string.format("%02.f", math.floor(bantime / 3600 - (days * 24)))
                        local minutes = string.format("%02.f", math.floor(bantime / 60 - (days * 1440) - (hours * 60)))
                        rust.Notice(netuser, target.." is banned for "..tostring(days).." days "..tostring(hours).." hours "..tostring(minutes).." minutes")
                        banned = true
                    end
                end
            end
        end
        if(banned == false) then
            rust.Notice(netuser, target.." is not banned")
        end
    else
        rust.Notice(netuser, "You dont have permission to use this command")
        return
    end
end

-- ****************************
-- PLUGIN:CanClientLogin()
-- ****************************
local userIDField = util.GetFieldGetter(Rust.ClientConnection, "UserID", true)
function PLUGIN:CanClientLogin(approval, connection)
    local userID = userIDField(connection)
    local steamID = rust.CommunityIDToSteamID(userID)
    local steam64 = SteamIDToSteam64(steamID)
    local ip = approval.ipAddress
    local name = connection.UserName
    local userInfo = name.." ("..steam64..")"
    local now = util.GetTime()
    for key, value in pairs(self.Data) do
        if(self.Data[key].netuser == steam64 or (self.Data[key].externalIP == ip) ) then
            if(self.Data[key].expiration < now and self.Data[key].expiration ~= 0) then
                self:CleanUpBanList()
                return
            else
                if(debug) then
                    print(self.Title.."----- DEBUG CanClientLogin() -----")
                    print(userInfo.." tried to join but is banned")
                    print("----------------------------------")
                else
                    if(self.Config.Settings.LogToConsole == "true") then
                        print(self.Title..": "..userInfo.." tried to join but is banned")
                    end
                    return NetworkConnectionError.ApprovalDenied
                end
            end
        else
            if(self.Data[key].name == name) then
                print(self.Title..": Warning! the name from "..userInfo.." has been banned but is using another steam account now!")
                print(self.Title..": It might be the same person with another account or just someone else with the same name. Judge it by yourself")
            end
        end
    end
end

-- ****************************
-- PLUGIN:SendData()
-- Sends information about bans to rustdb.net
-- ****************************
function PLUGIN:SendData(data)
    local url = "http://www.rustdb.net/api.php"
    local bandata = "bandata="..url_encode(json.encode(data))
    local r = webrequest.Post(url, bandata, function(code, response)
    -- Debug message
        if(debug) then
            print(self.Title.."----- DEBUG SendData() -----")
            print("code: "..tostring(code))
            print("response: "..tostring(response))
        end
        -- Check HTTP-Statuscodes
        if(code == 404) then
            print(self.Title..": ERROR - Webreqquest failed. Script not found, check url")
            return
        elseif(code == 503) then
            print(self.Title..": ERROR - Webrequest failed. Webserver unavailable")
            return
        elseif(code == 200) then
            -- Debug message
            if(debug) then
                print("webrequest: Sent successful (code 200)")
            end
        else
            print(self.Title..": ERROR - Webrequest failed. Error code: "..tostring(code)..", response: "..tostring(response))
        end
    end)
    if(not r) then
        print(self.Title..": ERROR - Webrequest failed")
    end
    if(debug) then
        print("r: "..tostring(r))
        print("----------------------------")
    end
end