PLUGIN.Title = "ChatHandler"
PLUGIN.Author = "#Domestos"
PLUGIN.Version = "2.0"
PLUGIN.Description = "Many features to help moderate the chat"
PLUGIN.ResourceId = "594"
PLUGIN.ConfigFile = "chathandler"
PLUGIN.MuteList = "chathandler-mutelist"
PLUGIN.SpamList = "chathandler-spamlist"


-- changelog
-- auto chat command deactivation when feature disabled
-- code improvements
-- block color codes
-- log chat to oxide true/false
-- /colorme removed
-- /admin added for admin mode
-- admin mode ignores antispam, wordfilter etc

-- TODO: ignorelist


-- ****************************
-- Debug Mode
-- ****************************
local debug = false


-- ****************************
-- Init()
-- ****************************
function PLUGIN:Init()
    self:LoadConfig()
    self:LoadChatCommands()
    self:LoadDataFile()
    print(self.Title .. " v" .. self.Version .. " loaded")
end

-- ****************************
-- LoadConfig()
-- ****************************
function PLUGIN:LoadConfig()
    local b, res = config.Read(self.ConfigFile)
    self.Config = res or {}
    -- Config settings
    self.Config.Settings = self.Config.Settings or {}
    self.Config.Settings.BroadcastMutes = self.Config.Settings.BroadcastMutes or "true"
    self.Config.Settings.BlockServerAds = self.Config.Settings.BlockServerAds or "true"
    self.Config.Settings.EnableWordFilter = self.Config.Settings.EnableWordFilter or "false"
    self.Config.Settings.EnableChatHistory = self.Config.Settings.EnableChatHistory or "true"
    self.Config.Settings.ChatHistoryMaxLines = self.Config.Settings.ChatHistoryMaxLines or 10
    self.Config.Settings.BlockColorCodes = self.Config.Settings.BlockColorCodes or "true"
    -- Logging settings
    self.Config.Settings.Logging = self.Config.Settings.Logging or {}
    self.Config.Settings.Logging.LogToConsole = self.Config.Settings.Logging.LogToConsole or "true"
    self.Config.Settings.Logging.LogBlockedMessages = self.Config.Settings.Logging.LogBlockedMessages or "true"
    self.Config.Settings.Logging.LogChatToOxide = self.Config.Settings.Logging.LogChatToOxide or "true"
    -- Admin mode settings
    self.Config.Settings.AdminMode = self.Config.Settings.AdminMode or {}
    self.Config.Settings.AdminMode.ChatCommand = self.Config.Settings.AdminMode.ChatCommand or "/admin"
    self.Config.Settings.AdminMode.EnableColoredChat = self.Config.Settings.AdminMode.EnableColordChat or "true"
    self.Config.Settings.AdminMode.AdminChatColor = self.Config.Settings.AdminMode.AdminChatColor or "AD1ACE"
    self.Config.Settings.AdminMode.ReplaceChatName = self.Config.Settings.AdminMode.ReplaceChatName or "true"
    self.Config.Settings.AdminMode.AdminChatName = self.Config.Settings.AdminMode.AdminChatName or "- Server Admin -"
    -- Antispam settings
    self.Config.Settings.AntiSpam = self.Config.Settings.AntiSpam or {}
    self.Config.Settings.AntiSpam.EnableAntiSpam = self.Config.Settings.AntiSpam.EnableAntiSpam or "true"
    self.Config.Settings.AntiSpam.MaxLines = self.Config.Settings.AntiSpam.MaxLines or 4
    self.Config.Settings.AntiSpam.TimeFrame = self.Config.Settings.AntiSpam.TimeFrame or 6
    -- Group settings
    self.Config.Settings.Groups = self.Config.Settings.Groups or {}
    self.Config.Settings.Groups.EnableGroups = self.Config.Settings.Groups.EnableGroups or "false"
    self.Config.Settings.Groups.PrefixPosition = self.Config.Settings.Groups.PrefixPosition or "left"
    -- Check if PrefixPosition setting is valid
    if(self.Config.Settings.Groups.PrefixPosition ~= "left" and self.Config.Settings.Groups.PrefixPosition ~= "right") then
        self.Config.Settings.Groups.PrefixPosition = "left"
        print(self.Title..": ERROR: Your PrefixPosition setting is invalid. It must be \"left\" or \"right\"")
        print(self.Title..": Setting PrefixPosition to default")
    end
    -- Serverip whitelist
    self.Config.AllowedIPsToPost = self.Config.AllowedIPsToPost or {Rust.NetCull.player.internalIP }
    -- Globalmute whitelist
    self.Config.GlobalMuteWhitelistedFlags = self.Config.GlobalMuteWhitelistedFlags or {"chathandler", "donator"}
    -- Wordfilter
    self.Config.WordFilter = self.Config.WordFilter or {
        ["bitch"] = "sweety",
        ["fucking hell"] = "lovely heaven",
        ["cunt"] = "****"
    }
    -- Chatgroups
    self.Config.ChatGroups = self.Config.ChatGroups or {
        ["Donator"] = {
            ["Flag"] = "donator",
            ["Prefix"] = "[$$$]",
            ["Color"] = "#06DCFB",
            ["ShowPrefix"] = true,
            ["ShowColor"] = true
        },
        ["VIP"] = {
            ["Flag"] = "vip",
            ["Prefix"] = "[VIP]",
            ["Color"] = "#FFA04A",
            ["ShowPrefix"] = true,
            ["ShowColor"] = true
        }
    }
    -- Check wordfilter for conflicts
    if(self.Config.Settings.EnableWordFilter == "true") then
        for key, value in pairs(self.Config.WordFilter) do
            local first, last = string.find(string.lower(value), string.lower(key))
            if(first ~= nil) then
                self.Config.WordFilter[key] = nil
                print(self.Title..": Config error in word filter: [\""..key.."\":\""..value.."\"] both contain the same word")
                print(self.Title..": [\""..key.."\":\""..value.."\"] was removed from word filter")
            end
        end
    end
    -- Initiate some tables and vars
    self.AntiSpam = {}
    self.ChatHistory = {}
    self.AdminMode = {}
    self.GlobalMute = false
    -- Save config file
    self:SaveConfig()
end

-- ****************************
-- LoadChatCommands()
-- ****************************
function PLUGIN:LoadChatCommands()
    self:AddChatCommand("mute", self.cmdMute)
    self:AddChatCommand("unmute", self.cmdUnMute)
    if(string.sub(self.Config.Settings.AdminMode.ChatCommand, 1, 1) == "/") then
        self.Config.Settings.AdminMode.ChatCommand = string.sub(self.Config.Settings.AdminMode.ChatCommand, 2)
    end
    self:AddChatCommand(self.Config.Settings.AdminMode.ChatCommand, self.cmdAdminMode)
    if(self.Config.Settings.EnableChatHistory == "true") then
        self:AddChatCommand("history", self.cmdHistory)
        self:AddChatCommand("h", self.cmdHistory)
    end
    if(self.Config.Settings.EnableWordFilter == "true") then
        self:AddChatCommand("wordfilter", self.cmdEditWordFilter)
    end
    self:AddChatCommand("globalmute", self.cmdGlobalMute)
    self:AddCommand("chat", "mute", self.ccmdMute)
    self:AddCommand("chat", "unmute", self.ccmdUnMute)
end

-- ****************************
-- LoadDataFile()
-- ****************************
function PLUGIN:LoadDataFile()
    -- Load mutelist
    self.DataFile = util.GetDatafile(self.MuteList)
    local data = self.DataFile:GetText()
    if(data == "") then
        self.Data = {}
    else
        self.Data = json.decode(data)
    end
    -- Load spamlist
    self.SpamFile = util.GetDatafile(self.SpamList)
    local spamdata = self.DataFile:GetText()
    if(spamdata == "") then
        self.Spam = {}
    else
        self.Spam = json.decode(spamdata)
    end
end

-- ****************************
-- Save()
-- ****************************
function PLUGIN:Save()
    self.DataFile:SetText(json.encode(self.Data))
    self.DataFile:Save()
    self.SpamFile:SetText(json.encode(self.Spam))
    self.SpamFile:Save()
end

-- ****************************
-- SaveConfig()
-- ****************************
function PLUGIN:SaveConfig()
    config.Save(self.ConfigFile, {
        indent = true,
        keyorder = {
            "Settings",
                "BroadcastMutes",
                "BlockServerAds",
                "EnableWordFilter",
                "EnableChatHistory",
                "ChatHistoryMaxLines",
                "BlockColorCodes",
                "Logging",
                    "LogToConsole",
                    "LogBlockedMessages",
                    "LogChatToOxide",
                "AdminMode",
                    "ChatCommand",
                    "EnableColoredChat",
                    "AdminChatColor",
                    "ReplaceAdminChatName",
                    "AdminChatName",
                "AntiSpam",
                    "EnableAntiSpam",
                    "MaxLines",
                    "TimeFrame",
                "Groups",
                    "EnableGroups",
                    "PrefixPosition",
            "AllowedIPsToPost",
            "GlobalMuteWhitelistedFlags",
            "WordFilter",
            "ChatGroups",
                    "Flag",
                    "Prefix",
                    "Color",
                    "ShowPrefix",
                    "ShowColor"
        }
    })
end

-- ****************************
-- PostInit()
-- ****************************
function PLUGIN:PostInit()
    self:LoadFlags()
    self:CleanUpMuteList()
    self.groupsPlugin = plugins.Find("groups")
    self.webchatPlugin = plugins.Find("webchat")
end

-- ****************************
-- LoadFlags()
-- ****************************
function PLUGIN:LoadFlags()
    -- Flags Plugin
    self.flagsPlugin = plugins.Find("flags")
    if(self.flagsPlugin) then
        self.flagsPlugin:AddFlagsChatCommand(self, "mute", {"chathandler"}, self.cmdMute)
        self.flagsPlugin:AddFlagsChatCommand(self, "unmute", {"chathandler"}, self.cmdUnMute)
        self.flagsPlugin:AddFlagsChatCommand(self, self.Config.Settings.AdminMode.ChatCommand, {"chathandler"}, self.cmdAdminMode)
        self.flagsPlugin:AddFlagsChatCommand(self, "wordfilter", {"chathandler"}, self.cmdEditWordFilter)
        self.flagsPlugin:AddFlagsChatCommand(self, "globalmute", {"chathandler"}, self.cmdGlobalMute)
    end
    -- If Flags isnt installed disable the groups feature
    if(not self.flagsPlugin and self.Config.Settings.Groups.EnableGroups ~= "false") then
        self.Config.Settings.Groups.EnableGroups = "false"
        self:SaveConfig()
        print(self.Title..": Groups feature disabled because Flags plugin not found")
    end
    -- Oxmin Plugin
    self.oxminPlugin = plugins.Find("oxmin")
    if(self.oxminPlugin) then
        self.FLAG_CHATHANDLER = oxmin.AddFlag("chathandler")
        self.oxminPlugin:AddExternalOxminChatCommand(self, "mute", {self.FLAG_CHATHANDLER}, self.cmdMute)
        self.oxminPlugin:AddExternalOxminChatCommand(self, "unmute", {self.FLAG_CHATHANDLER}, self.cmdUnMute)
        self.oxminPlugin:AddExternalOxminChatCommand(self, self.Config.Settings.AdminMode.ChatCommand, {self.FLAG_CHATHANDLER}, self.cmdAdminMode)
        self.oxminPlugin:AddExternalOxminChatCommand(self, "wordfilter", {self.FLAG_CHATHANDLER}, self.cmdEditWordFilter)
        self.oxminPlugin:AddExternalOxminChatCommand(self, "globalmute", {self.FLAG_CHATHANDLER}, self.cmdGlobalMute)
    end
end

-- ****************************
-- HasPermission()
-- ****************************
function PLUGIN:HasPermission(netuser)
    if(netuser:CanAdmin()) then
        return true
    elseif((self.oxminPlugin ~= nil) and (self.oxminPlugin:HasFlag(netuser, self.FLAG_CHATHANDLER))) then
        return true
    elseif((self.flagsPlugin ~= nil) and (self.flagsPlugin:HasFlag(netuser, "chathandler"))) then
        return true
    else
        return false
    end
end

-- ****************************
-- NoticeAll()
-- Sends an popup to all online users
-- ****************************
function PLUGIN:NoticeAll(exception, msg)
    local allNetuser = rust.GetAllNetUsers()
    for key, netuser in pairs(allNetuser) do
        if(exception ~= false) then
            if(netuser ~= exception) then
                rust.Notice(netuser, msg)
            end
        else
            rust.Notice(netuser, msg)
        end
    end
end

-- ****************************
-- CleanUpMuteList()
-- Removes expired mutes from the mutelist
-- ****************************
function PLUGIN:CleanUpMuteList()
    local now = util.GetTime()
    for key, value in pairs(self.Data) do
        if(self.Data[key].expiration < now and self.Data[key].expiration ~= 0) then
            table.remove(self.Data, key)
            self:Save()
        end
    end
end

-- ****************************
-- GetTargetNetuser()
-- Searches for a netuser by name or id
-- ****************************
local function GetTargetNetuser(input)
    local b, netuser = rust.FindNetUsersByName(input)
    if(b == true) then -- one single user was found
        return netuser
    end
    local allNetuser = rust.GetAllNetUsers()
    for key, netuser in pairs(allNetuser) do
        if(rust.GetLongUserID(netuser) == input) then
            return netuser
        end
    end
    return false
end

-- ****************************
-- split()
-- explode a string into a table
-- ****************************
local function split(str, sep)
    local tbl = {}
    for word in string.gmatch(str, "[^"..sep.."]+") do
        table.insert(tbl, word)
    end
    return tbl
end

-- ****************************
-- splitLongMessages()
-- splits chat messages longer than 80 characters into multilines
-- ****************************
local function splitLongMessages(msg)
    local length = string.len(msg)
    local msgTbl = {}
    if(length > 80) then
        while(length > 80) do
            local subStr = string.sub(msg, 1, 80)
            local first, last = string.find(string.reverse(subStr), " ")
            if(first ~= nil) then
                subStr = string.sub(subStr, 1, -first)
            end
            table.insert(msgTbl, subStr)
            msg = string.sub(msg, string.len(subStr) + 1)
            length = string.len(msg)
        end
        table.insert(msgTbl, msg)
    else
        table.insert(msgTbl, msg)
    end
    return msgTbl
end

-- ****************************
-- CheckMute()
-- Check if someone is muted and for how long
-- ****************************
function PLUGIN:CheckMute(targetSteam64)
    local now = util.GetTime()
    for key, value in pairs(self.Data) do
        if(self.Data[key].steam64 == targetSteam64) then
            if(self.Data[key].expiration < now and self.Data[key].expiration ~= 0) then
                table.remove(self.Data, key)
                self:Save()
                return false, false
            end
            if(self.Data[key].expiration == 0) then
                return true, false
            else
                local expiration = self.Data[key].expiration
                local muteTime = expiration - now
                local hours = string.format("%02.f", math.floor(muteTime / 3600))
                local minutes = string.format("%02.f", math.floor(muteTime / 60 - (hours * 60)))
                local seconds = string.format("%02.f", math.floor(muteTime - (hours * 3600) - (minutes * 60)))
                local expirationString = tostring(hours.."h "..minutes.."m "..seconds.."s")
                return true, expirationString
            end
        end
    end
    return false, false
end

-- ****************************
-- cmdAdminMode()
-- Enables/disables the admin mode
-- ****************************
function PLUGIN:cmdAdminMode(netuser)
    if(netuser and not self:HasPermission(netuser)) then
        rust.Notice(netuser, "You dont have permission to use this command")
        return
    end
    local steam64 = rust.GetLongUserID(netuser)
    if(self.AdminMode[steam64] ~= nil) then
        self.AdminMode[steam64] = nil
        rust.Notice(netuser, "You switched back to player mode")
    else
        self.AdminMode[steam64] = true
        rust.Notice(netuser, "You switched to admin mode")
    end
end

-- ****************************
-- cmdGlobalMute()
-- Mutes the chat globally - only admins and whitelisted flags can chat
-- ****************************
function PLUGIN:cmdGlobalMute(netuser)
    if(netuser and not self:HasPermission(netuser)) then
        rust.Notice(netuser, "You dont have permission to use this command")
        return
    end
    if(self.GlobalMute == false) then
        self.GlobalMute = true
        self:NoticeAll(false, "Chat is now globally muted")
    else
        self.GlobalMute = false
        self:NoticeAll(false, "Global chatmute is now deactivated")
    end
end

-- ****************************
-- ccmdMute()
-- Console command to trigger cmdMute()
-- ****************************
function PLUGIN:ccmdMute(arg)
    local netuser = arg.argUser
    if(netuser and not netuser:CanAdmin()) then
        arg:ReplyWith("You dont have permission to use this command")
        return
    end
    local args = split(arg.ArgsStr, " ")
    self:cmdMute(netuser, args)
    return true
end

-- ****************************
-- cmdMute()
-- Handle mutes
-- ****************************
function PLUGIN:cmdMute(netuser, cmd, args)
    if(netuser and not self:HasPermission(netuser)) then
        rust.Notice(netuser, "You dont have permission to use this command")
        return
    end
    if(type(cmd) == "table") then args = cmd end
    -- Check for valid syntax
    if(not args[1]) then
        if(not netuser) then
            print("Syntax: \"/mute name|steam64id time[m|h|d]\" or \"/mute name|steam64id\" for permanent mute or \"/mute all\" to globally mute")
        else
            rust.Notice(netuser, "Syntax: \"/mute name|steam64id time[m|h|d]\" or \"/mute name|steam64id\" for permanent mute or \"/mute all\" to globally mute")
        end
        return
    end
    -- Try to get target netuser
    local targetNetuser = GetTargetNetuser(args[1])
    if(targetNetuser == false) then
        if(not netuser) then
            print("No player found with that name|steam64id")
        else
            rust.Notice(netuser, "No player found with that name|steam64id")
        end
        return
    end
    local targetName = util.QuoteSafe(targetNetuser.displayName)
    local targetSteam64 = rust.GetLongUserID(targetNetuser)
    -- Check if target is already muted
    local isMuted, timeMuted = self:CheckMute(targetSteam64)
    if(isMuted == true) then
        if(not netuser) then
            print(targetName.." is already muted")
        else
            rust.Notice(netuser, targetName.." is already muted")
        end
        return
    end
    if(not args[2]) then -- No time is given, mute permanently
        -- Mute player with no expiration time
        local newMuteListEntry = {["steam64"] = targetSteam64, ["expiration"] = 0}
        table.insert(self.Data, newMuteListEntry)
        self:Save()
        -- Send mute notice
        if(self.Config.Settings.BroadcastMutes == "true") then
            self:NoticeAll(false, targetName.." has been muted")
            if(not netuser and self.Config.Settings.Logging.LogToConsole == "false") then
                print(targetName.." has been muted")
            end
        else
            rust.Notice(targetNetuser, "You have been muted")
            if(not netuser and self.Config.Settings.Logging.LogToConsole == "false") then
                print(targetName.." has been muted")
            else
                rust.Notice(netuser, targetName.." has been muted")
            end
        end
        -- Send console log
        if(self.Config.Settings.Logging.LogToConsole == "true") then
            if(not netuser) then
                print(self.Title..": Admin muted "..targetName.." per remote console")
            else
                print(self.Title..": "..netuser.displayName.." muted "..targetName)
            end
        end
    else -- Time is given, mute only for this timeframe
        -- Check for valid time format
        local c = string.match(args[2], "^%d*[mh]$")
        if(string.len(args[2]) < 2 or c == nil) then
            if(not netuser) then
                print("Invalid time format")
            else
                rust.Notice(netuser, "Invalid time format")
            end
            return
        end
        -- Build expiration time
        local now = util.GetTime()
        local muteTime = tonumber(string.sub(args[2], 1, -2))
        local timeUnit = string.sub(args[2], -1)
        local timeMult, timeUnitLong
        if(timeUnit == "m") then
            timeMult = 60
            timeUnitLong = "minutes"
        elseif(timeUnit == "h") then
            timeMult = 3600
            timeUnitLong = "hours"
        end
        local expiration = (now + (muteTime * timeMult))
        -- Mute player for given duration
        local newMuteListEntry = {["steam64"] = targetSteam64, ["expiration"] = expiration }
        table.insert(self.Data, newMuteListEntry)
        self:Save()
        -- Send mute notice
        if(self.Config.Settings.BroadcastMutes == "true") then
            self:NoticeAll(false, targetName.." has been muted for "..muteTime.." "..timeUnitLong)
            if(not netuser and self.Config.Settings.Logging.LogToConsole == "false") then
                print(targetName.." has been muted for "..muteTime.." "..timeUnitLong)
            end
        else
            rust.Notice(targetNetuser, "You have been muted for "..muteTime.." "..timeUnitLong)
            if(not netuser and self.Config.Settings.Logging.LogToConsole == "false") then
                print(targetName.." has been muted for "..muteTime.." "..timeUnitLong)
            else
                rust.Notice(netuser, targetName.." has been muted for "..muteTime.." "..timeUnitLong)
            end
        end
        -- Send console log
        if(self.Config.Settings.Logging.LogToConsole == "true") then
            if(not netuser) then
                print(self.Title..": Admin muted "..targetName.." for "..muteTime.." "..timeUnitLong.." per remote console")
            else
                print(self.Title..": "..netuser.displayName.." muted "..targetName.." for "..muteTime.." "..timeUnitLong)
            end
        end
    end
end

-- ****************************
-- ccmdUnMute()
-- Console command to trigger cmdUnMute()
-- ****************************
function PLUGIN:ccmdUnMute(arg)
    local netuser = arg.argUser
    if(netuser and not netuser:CanAdmin()) then
        arg:ReplyWith("You dont have permission to use this command")
        return
    end
    local args = split(arg.ArgsStr, " ")
    self:cmdUnMute(netuser, args)
    return true
end

-- ****************************
-- cmdUnMute()
-- Handle unmutes
-- ****************************
function PLUGIN:cmdUnMute(netuser, cmd, args)
    if(netuser and not self:HasPermission(netuser)) then
        rust.Notice(netuser, "You dont have permission to use this command")
        return
    end
    if(type(cmd) == "table") then args = cmd end
    -- Check for valid syntax
    if(not args[1]) then
        if(not netuser) then
            print("Syntax: '/unmute name|steam64id' or '/unmute all' to clear mutelist")
        else
            rust.Notice(netuser, "Syntax: '/unmute name|steam64id' or '/unmute all' to clear mutelist")
        end
        return
    end
    -- Check if "all" is used to clear the whole mutelist
    if(args[1] == "all") then
        local mutecount = #self.Data
        self.Data = {}
        self:Save()
        if(not netuser) then
            print("cleared "..mutecount.." entries from mutelist")
        else
            rust.Notice(netuser, "Cleared "..mutecount.." entries from mutelist")
        end
        return
    end
    -- Try to get target netuser
    local targetNetuser = GetTargetNetuser(args[1])
    if(targetNetuser == false) then
        if(not netuser) then
            print("No player found with that name|steam64id")
        else
            rust.Notice(netuser, "No player found with that name|steam64id")
        end
        return
    end
    local targetName = util.QuoteSafe(targetNetuser.displayName)
    local targetSteam64 = rust.GetLongUserID(targetNetuser)
    -- Unmute player
    local muted = false
    for key, value in pairs(self.Data) do
        if(self.Data[key].steam64 == targetSteam64) then
            muted = true
            table.remove(self.Data, key)
            self:Save()
            -- Send unmute notice
            if(self.Config.Settings.BroadcastMutes == "true") then
                self:NoticeAll(false, targetName.." has been unmuted")
                if(not netuser and self.Config.Settings.Logging.LogToConsole == "false") then
                    print(targetName.." has been unmuted")
                end
            else
                rust.Notice(targetNetuser, "You have been unmuted")
                if(not netuser and self.Config.Settings.Logging.LogToConsole == "false") then
                    print(targetName.." has been unmuted")
                else
                    rust.Notice(netuser, targetName.." has been unmuted")
                end
            end
            -- Send console log
            if(self.Config.Settings.Logging.LogToConsole == "true") then
                if(not netuser) then
                    print(self.Title..": Admin unmuted "..targetName.." per remote console")
                else
                    print(self.Title..": "..netuser.displayName.." unmuted "..targetName)
                end
            end
        end
    end
    if(muted == false) then
        if(not netuser) then
            print(targetName.." not found in mutelist")
        else
            rust.Notice(netuser, targetName.." not found in mutelist")
        end
    end
end

-- ****************************
-- OnUserChat()
-- ****************************
function PLUGIN:OnUserChat(netuser, name, msg)
    if(msg:sub( 1, 1 ) == "/") then return end
    local steam64 = rust.GetLongUserID(netuser)
    -- Spam prevention
    if(self.Config.Settings.AntiSpam.EnableAntiSpam == "true") then
        local isSpam, punishTime = self:AntiSpamCheck(netuser)
        if(isSpam == true) then
            rust.Notice(netuser, "Auto mute: "..punishTime.." for spam")
            timer.Once(4, function() rust.Notice(netuser, "If you keep spamming your punishment will raise") end)
            if(self.Config.Settings.BroadcastMutes == "true") then
                self:NoticeAll(netuser, netuser.displayName.." auto mute: "..punishTime.." for spam")
            end
            if(self.Config.Settings.Logging.LogToConsole == "true") then
                print(self.Title..": "..netuser.displayName.." got a "..punishTime.." auto mute for spam")
            end
            return false
        end
    end
    -- Parse message to filter stuff and check if message should be blocked
    local canChat, msg, error, prefix = self:ParseChat(netuser, msg)
    -- Chat is blocked
    if(canChat == false) then
        if(self.Config.Settings.Logging.LogBlockedMessages == "true") then
            print("[CHAT]"..prefix.." "..netuser.displayName..": "..msg)
        end
        rust.SendChatToUser(netuser, "ChatHandler", "[color #db2020]"..error)
        return false
    end
    -- Chat is ok and not blocked
    if(canChat == true) then
        -- Split messages if too long
        msg = splitLongMessages(msg) -- msg is a table now
        -- If groups plugin is installed
        if(self.groupsPlugin) then
            local userID = rust.GetUserID(netuser)
            local groupkey = self.groupsPlugin:checkPlayerGroup(userID)
            -- If user is in a group and groupname enabled to show
            if(groupkey ~= 0 and self.groupsPlugin.GroupData[groupkey]["settings"]["groupname"] == 1) then
                local groupname = self.groupsPlugin.GroupData[groupkey]["name"]
                -- prepare chat messages
                local i = 1
                while(msg[i]) do
                    local username, message = self:BuildNameMessage(netuser, msg[i], groupname)
                    self:SendChat(netuser, username, message, msg[i])
                    i = i + 1
                end
                return false
            else -- user is not in a group or groupname is not enabled to show
                -- Prepare chat messages
                local i = 1
                while(msg[i]) do
                    local username, message = self:BuildNameMessage(netuser, msg[i], false)
                    self:SendChat(netuser, username, message, msg[i])
                    i = i + 1
                end
                return false
            end
        else -- Groups plugin is not used
            -- Prepare chat messages
            local i = 1
            while(msg[i]) do
                local username, message = self:BuildNameMessage(netuser, msg[i], false)
                self:SendChat(netuser, username, message, msg[i])
                i = i + 1
            end
            return false
        end
    end
end

-- ****************************
-- BuildNameMessage()
-- Builds prefix and colors into name and message
-- ****************************
function PLUGIN:BuildNameMessage(netuser, msg, groupname)
    local username = netuser.displayName
    local message = msg
    local steam64 = rust.GetLongUserID(netuser)
    if(debug) then
        print("--- ChatHandler debug BuildNameMessage()---")
    end
    if(self.Config.Settings.Groups.EnableGroups == "true") then
        if(debug) then
            print("EnableGroups == true")
        end
        -- Iterate through all groups
        for key, value in pairs(self.Config.ChatGroups) do
            if(debug) then
                print("HasFlag: "..self.Config.ChatGroups[key].Flag.." - "..tostring(self.flagsPlugin:HasFlag(netuser, self.Config.ChatGroups[key].Flag)))
                print("PrefixPosition: "..self.Config.Settings.Groups.PrefixPosition)
            end
            if(self.flagsPlugin:HasActualFlag(netuser, self.Config.ChatGroups[key].Flag)) then
                if(self.Config.ChatGroups[key].ShowPrefix == true) then
                    if(self.Config.Settings.Groups.PrefixPosition == "left") then
                        if(groupname ~= false) then
                            username = self.Config.ChatGroups[key].Prefix.." "..netuser.displayName.." ("..groupname..")"
                        else
                            username = self.Config.ChatGroups[key].Prefix.." "..netuser.displayName
                        end
                    else
                        if(groupname ~= false) then
                            username = netuser.displayName.." "..self.Config.ChatGroups[key].Prefix.." ("..groupname..")"
                        else
                            username = netuser.displayName.." "..self.Config.ChatGroups[key].Prefix
                        end
                    end
                end
                if(self.Config.ChatGroups[key].ShowColor == true and self.AdminMode[steam64] == nil) then
                    message = "[Color "..self.Config.ChatGroups[key].Color.."]"..msg
                end
                break
            end
        end
    elseif(groupname ~= false) then
        if(debug) then
            print("EnableGroups == false")
        end
        username = netuser.displayName.." ("..groupname..")"
    end
    if(self.AdminMode[steam64] ~= nil) then
        if(debug) then
            print("Admin mode enabled")
        end
        message = "[Color "..self.Config.Settings.AdminMode.AdminChatColor.."]"..msg
        if(self.Config.Settings.AdminMode.ReplaceAdminChatName == "true") then
            username = self.Config.Settings.AdminMode.AdminChatName
        end
    end
    if(debug) then
        print("username: "..username)
        print("message: "..message)
        print("--- ChatHandler debug BuildNameMessage() Ende---")
    end
    return username, message
end
-- ****************************
-- AntiSpamCheck()
-- Keeps record of chat spam
-- returns isSpam, punishTime
-- ****************************
function PLUGIN:AntiSpamCheck(netuser)
    local steam64 = rust.GetLongUserID(netuser)
    local now = util.GetTime()
    if(self.AdminMode[steam64] ~= nil) then return false, false end
    if(self.AntiSpam[steam64] ~= nil) then
        local firstMsg = self.AntiSpam[steam64].timestamp
        local msgCount = self.AntiSpam[steam64].msgcount
        if(msgCount < self.Config.Settings.AntiSpam.MaxLines) then
            self.AntiSpam[steam64].msgcount = self.AntiSpam[steam64].msgcount + 1
            return false, false
        else
            if(now - firstMsg <= self.Config.Settings.AntiSpam.TimeFrame) then
                -- punish
                local punishCount = 1
                local expiration, punishTime, newEntry
                for key, value in pairs(self.Spam) do
                    if(self.Spam[key].steam64 == steam64) then
                        newEntry = false
                        punishCount = self.Spam[key].punishcount + 1
                        self.Spam[key].punishcount = punishCount
                        self:Save()
                    end
                end
                if(punishCount == 1) then
                    expiration =  now + 300
                    punishTime = "5 minutes"
                elseif(punishCount == 2) then
                    expiration = now + 3600
                    punishTime = "1 hour"
                else
                    expiration = 0
                    punishTime = "permanent"
                end
                if(newEntry ~= false) then
                    local newSpamListEntry = {["steam64"] = steam64, ["punishcount"] = punishCount }
                    table.insert(self.Spam, newSpamListEntry)
                    self:Save()
                end
                local newMuteListEntry = {["steam64"] = steam64, ["expiration"] = expiration }
                table.insert(self.Data, newMuteListEntry)
                self:Save()
                self.AntiSpam[steam64] = nil
                return true, punishTime
            else
                self.AntiSpam[steam64].timestamp = now
                self.AntiSpam[steam64].msgcount = 1
                return false, false
            end
        end
    else
        self.AntiSpam[steam64] = {}
        self.AntiSpam[steam64].timestamp = now
        self.AntiSpam[steam64].msgcount = 1
        return false, false
    end
end

-- ****************************
-- ParseChat()
-- Parses the chat message to filter blocked stuff
-- Returns canChat, msg, errorMsg, errorPrefix
-- ****************************
function PLUGIN:ParseChat(netuser, msg)
    local msg = tostring(msg)
    local steam64 = rust.GetLongUserID(netuser)
    if(self.AdminMode[steam64] ~= nil) then return true, msg, false, false end
    -- Check player specific mute
    local isMuted, timeMuted = self:CheckMute(steam64)
    if(isMuted == true) then
        if(timeMuted == false) then
            return false, msg, "You are muted", "[MUTED]"
        else
            return false, msg, "You are muted for "..timeMuted, "[MUTED]"
        end
    end
    -- Check global mute
    if(self.GlobalMute == true and not netuser:CanAdmin()) then
        local hasFlag = false
        for key, value in pairs(self.Config.GlobalMuteWhitelistedFlags) do
            if(self.flagsPlugin:HasActualFlag(netuser, self.Config.GlobalMuteWhitelistedFlags[key])) then
                hasFlag = true
                break
            end
        end
        if(hasFlag == false) then
            return false, msg, "Chat is currently global muted", "[MUTED]"
        end
    end
    -- Check for color codes
    if(self.Config.Settings.BlockColorCodes == "true") then
        if(string.sub(string.lower(msg), 1, 6) == "[color") then
            local first, last = string.find(msg, "]", 1)
            if(last ~= nil) then
                msg = string.sub(msg, last + 1)
            end
        end
    end
    -- Check for server advertisements
    if(self.Config.Settings.BlockServerAds == "true") then
        local ipCheck = string.match(msg, "(%d+.%d+.%d+.%d+:%d+)") or string.match(msg, "(%d+.%d+.%d+.%d+)")
        if(ipCheck ~= nil) then
            for key, value in pairs(self.Config.AllowedIPsToPost) do
                if(string.match(self.Config.AllowedIPsToPost[key], ipCheck) ~= nil) then
                    return true, msg, false, false
                end
            end
            return false, msg, "Its not allowed to advertise other servers", "[BLOCKED]"
        end
    end
    -- Check for blacklisted words
    if(self.Config.Settings.EnableWordFilter == "true") then
        for key, value in pairs(self.Config.WordFilter) do
            local first, last = string.find(string.lower(msg), key)
            if(first ~= nil) then
                while(first ~= nil) do
                    local before = string.sub(msg, 1, first - 1)
                    local after = string.sub(msg, last + 1)
                    msg = before..value..after
                    first, last = string.find(string.lower(msg), key)
                end
            end
        end
        return true, msg, false, false
    end
    return true, msg, false, false
end

-- ****************************
-- SendChat()
-- Sends and logs the chat messages
-- ****************************
function PLUGIN:SendChat(netuser, name, chatMsg, logMsg)
    -- chatMsg == contains color code; logMsg == without color code
    -- Broadcast chat ingame
    rust.BroadcastChat(name, chatMsg)
    -- Log to Rusty chat stream
    local DebugPrint = util.FindOverloadedMethod(UnityEngine.Debug._type, "Log", bf.public_static, { System.Object })
    local arr = util.ArrayFromTable(System.Object, { logMsg })
    cs.convertandsetonarray(arr, 0, "[CHAT] " ..name..": "..logMsg, System.Object._type)
    DebugPrint:Invoke(nil, arr)
    -- Log to Oxide log file
    if(self.Config.Settings.Logging.LogChatToOxide == "true") then
        print("[CHAT] "..name..": "..logMsg)
    end
    -- Log to Webchat if installed
    if(self.webchatPlugin ~= nil) then
        local timestamp = util.GetTime()
        local steam64 = rust.GetLongUserID(netuser)
        local newWebchatInsert = {timestamp, name, logMsg, steam64 }
        if(#self.webchatPlugin.ChatData >= self.webchatPlugin.Config.maxlines) then
            table.remove(self.webchatPlugin.ChatData, 1)
        end
        -- Insert new data, save the file and send it
        table.insert(self.webchatPlugin.ChatData, newWebchatInsert)
        self.webchatPlugin:Save()
        self.webchatPlugin:SendChat()
    end
    -- Log chat history
    if(self.Config.Settings.EnableChatHistory == "true") then
        self:InsertHistory(name, chatMsg)
    end
end

-- ****************************
-- OnUserDisconnect()
-- ****************************
function PLUGIN:OnUserDisconnect(networkplayer)
    local netuser = networkplayer:GetLocalData()
    local steam64 = rust.GetLongUserID(netuser)
    self.AntiSpam[steam64] = nil
    self.AdminMode[steam64] = nil
end

-- ****************************
-- cmdHistory()
-- Displays chat history
-- ****************************
function PLUGIN:cmdHistory(netuser)
    if(#self.ChatHistory > 0) then
        rust.SendChatToUser(netuser, "ChatHistory", "----------")
        local i = 1
        while(self.ChatHistory[i]) do
            rust.SendChatToUser(netuser, self.ChatHistory[i]["name"], self.ChatHistory[i]["msg"])
            i = i + 1
        end
        rust.SendChatToUser(netuser, "ChatHistory", "----------")
    else
        rust.SendChatToUser(netuser, "ChatHistory", "No history found")
    end
end

-- ****************************
-- InsertHistory()
-- Saves chat messages into the history
-- ****************************
function PLUGIN:InsertHistory(name, msg)
    local newHistory = {["name"] = name, ["msg"] = msg }
    if(#self.ChatHistory == self.Config.Settings.ChatHistoryMaxLines) then
        table.remove(self.ChatHistory, 1)
    end
    table.insert(self.ChatHistory, newHistory)
end

-- ****************************
-- cmdEditWordFilter()
-- Handles the command /wordfilter
-- ****************************
function PLUGIN:cmdEditWordFilter(netuser, cmd, args)
    if(type(cmd) == "table") then args = cmd end
    if(not args[1] or (args[1] ~= "add" and args[1] ~= "remove" and args[1] ~= "list")) then
        if(not self:HasPermission(netuser)) then
            rust.Notice(netuser, "Syntax \"/wordfilter list\"")
        else
            rust.Notice(netuser, "Syntax: /wordfilter \"add\" \"word\" \"replacement\" or /wordfilter \"remove\" \"word\"")
        end
        return
    end
    if(args[1] == "add") then
        if(not self:HasPermission(netuser)) then
            rust.Notice(netuser, "You dont have permission to use this command")
            return
        end
        if(not args[3]) then
            rust.Notice(netuser, "Syntax: /wordfilter \"add\" \"word\" \"replacement\"")
            return
        end
        local word = args[2]
        local replacement = args[3]
        local first, last = string.find(string.lower(replacement), string.lower(word))
        if(first ~= nil) then
            rust.Notice(netuser, "Error: "..replacement.." contains the word "..word)
            return
        else
            self.Config.WordFilter[word] = replacement
            self:SaveConfig()
            rust.Notice(netuser, "WordFilter added. \""..word.."\" will now be replaced with \""..replacement.."\"")
        end
    elseif(args[1] == "remove") then
        if(not self:HasPermission(netuser)) then
            rust.Notice(netuser, "You dont have permission to use this command")
            return
        end
        if(not args[2]) then
            rust.Notice(netuser, "Syntax: /wordfilter \"remove\" \"word\"")
            return
        end
        local word = args[2]
        if(self.Config.WordFilter[word] ~= nil) then
            self.Config.WordFilter[word] = nil
            self:SaveConfig()
            rust.Notice(netuser, "\""..word.."\" successfully removed from the word filter")
        else
            rust.Notice(netuser, "No filter for \""..word.."\" found")
        end
    elseif(args[1] == "list") then
        local wordFilterList
        for key, value in pairs(self.Config.WordFilter) do
            wordFilterList = wordFilterList..key..", "
        end
        rust.SendChatToUser(netuser, "ChatHandler", "Blacklisted words: "..wordFilterList)
    end
end

-- ****************************
-- SendHelpText()
-- Adds help commands to /help
-- ****************************
function PLUGIN:SendHelpText( netuser )
    if(self.Config.Settings.EnableChatHistory == "true") then
        rust.SendChatToUser(netuser, "Use /history or /h to view recent chat history")
    end
    if(self.Config.Settings.EnableWordFilter == "true") then
        rust.SendChatToUser(netuser, "Use \"/wordfilter list\" to see blacklisted words")
    end
end