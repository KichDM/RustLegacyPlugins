PLUGIN.Title = "VAC Kicker"
PLUGIN.Author = "#Domestos"
PLUGIN.Version = "1.4"
PLUGIN.Description = "Kick people with VAC bans"
PLUGIN.ResourceId = "458"
PLUGIN.ConfigFile = "vackicker"

-- Debug mode
local debug = false
--

function PLUGIN:Init()
    self:AddChatCommand("vaccheck", self.cmdVacCheck)
    self:AddCommand("vac", "check", self.ccmdVacCheck)
	self:LoadConfig()
    print(self.Title..' v'..self.Version..' loaded')
end

function PLUGIN:LoadConfig()
	local b, res = config.Read(self.ConfigFile)
	self.Config = res or {}
    -- Config settings
    self.Config.apikey = self.Config.apikey or ""
    self.Config.threshold = self.Config.threshold or 0
    self.Config.logToConsole = self.Config.logToConsole or "true"
    -- Old settings
    self.Config.version = nil -- removed in 1.2
    -- Save config file
    config.Save(self.ConfigFile, {
        indent = true,
        keyorder = {
            "apikey",
            "threshold",
            "logToConsole"
        }
    })
    -- Check for valid steam api key
    if(self.Config.apikey == "" or self.Config.apikey == nil) then
        print(self.Title..': ERROR - No steam api key found!')
        return
    end
end

function PLUGIN:PostInit()
    self:LoadFlags()
end

-- ****************************
-- PLUGIN:Load Flags()
-- Load all the Flags and Oxmin flags
-- ****************************
function PLUGIN:LoadFlags()
    -- Flags Plugin
    self.flagsPlugin = plugins.Find("flags")
    if(self.flagsPlugin) then
        self.flagsPlugin:AddFlagsChatCommand(self, "vaccheck", {"vac"}, self.cmdVacCheck)
    end
    -- Oxmin Plugin
    self.oxminPlugin = plugins.Find("oxmin")
    if(self.oxminPlugin) then
        self.FLAG_VAC = oxmin.AddFlag("vac")
        self.oxminPlugin:AddExternalOxminChatCommand(self, "vaccheck", {self.FLAG_VAC}, self.cmdVacCheck)
    end
end

-- ****************************
-- PLUGIN:CheckFlags()
-- Check if user has permission
-- ****************************
function PLUGIN:CheckFlags(netuser)
    if(netuser:CanAdmin()) then
        return true
    elseif((self.oxminPlugin ~= nil) and (self.oxminPlugin:HasFlag(netuser, self.FLAG_VAC))) then
        return true
    elseif((self.flagsPlugin ~= nil) and (self.flagsPlugin:HasFlag(netuser, "vac"))) then
        return true
    else
        return false
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
-- PLUGIN:OnUserChat()
-- Triggered when someone chats
-- ****************************
function PLUGIN:OnUserConnect(netuser)
    -- Check for valid netuser
	if(not netuser) then return end
	-- Call the vac check
	self:VACCheck(netuser, netuser, "connect")
end

-- ****************************
-- PLUGIN:ccmdVacCheck()
-- Handles the console command vac.check
-- ****************************
function PLUGIN:ccmdVacCheck(arg)
    local netuser = arg.argUser
    if(netuser and not netuser:CanAdmin()) then
        arg:ReplyWith("You dont have permission to use this command")
        return
    end
    local args = split(arg.ArgsStr, " ")
    self:cmdVacCheck(netuser, args)
    return true
end

-- ****************************
-- PLUGIN:cmdVacCheck()
-- Handles the chat command /vaccheck
-- ****************************
function PLUGIN:cmdVacCheck(netuser, cmd, args)
    if(netuser and self:CheckFlags(netuser) == false) then
        rust.Notice(netuser, "You dont have permission to use this command")
        return
    end
    if(type(cmd) == "table") then args = cmd end
    -- Check for valid syntax
    if(not args[1]) then
        if(not netuser) then
            print("Syntax: \"/vaccheck name|steam64id\"")
        else
            rust.Notice(netuser, "Syntax: \"/vaccheck name|steam64id \"")
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
    -- Call the vac check
    local srcfunc
    if(netuser) then
        srcfunc = "cmd"
    else
        srcfunc = "console"
    end
    self:VACCheck(netuser, targetNetuser, srcfunc)
end

-- ****************************
-- PLUGIN:VACCheck()
-- Checks the steam api for vac bans
-- ****************************
function PLUGIN:VACCheck(netuser, targetNetuser, srcfunc)
    local url ='http://api.steampowered.com/ISteamUser/GetPlayerBans/v0001/?key='..self.Config.apikey..'&steamids='..rust.GetLongUserID(targetNetuser)
    local r = webrequest.Send(url, function(code, response)
        -- Debug
        if(debug == true) then
            print(self.Title..": DEBUG - code: "..tostring(code))
            print(self.Title..": DEBUG - response: "..tostring(response))
        end
        -- Check HTTP-Statuscodes
        if(code == 401) then
            print(self.Title..": ERROR - Webreqquest failed. Invalid steam api key")
            return
        elseif(code == 404 or code == 503) then
            print(self.Title..": ERROR - Webrequest failed. Steam api unavailable")
            return
        elseif(code == 200) then
            local response = json.decode(response)
            -- Set variables for easier string formatting
            local daysSinceLastBan = tostring(response.players[1].DaysSinceLastBan)
            local playerInfo = targetNetuser.displayName..' ('..rust.GetLongUserID(targetNetuser)..')'
            -- Debug
            if(debug == true) then
                print(self.Title..": DEBUG - daysSinceLastBan: "..daysSinceLastBan)
                print(self.Title..": DEBUG - response.players[1].VACBanned: "..response.players[1].VACBanned)
                print(self.Title..": DEBUG - threshold: "..self.Config.threshold)
            end
            -- Check if vac banned
            if(response.players[1].VACBanned == true) then
                -- Check if days since last ban are above threshold if set
                if(self.Config.threshold > 0) then
                    if(response.players[1].DaysSinceLastBan < self.Config.threshold) then
                        if(self.Config.logToConsole == "true") then
                            -- Print console message when set to true and kick
                            print(self.Title..': VAC ban detected on '..playerInfo..'['..daysSinceLastBan..' days]. Kicking player...')
                            targetNetuser:Kick(NetError.Facepunch_Connector_VAC_Banned, true)
                            print(self.Title..': '..playerInfo..' has been kicked.')
                        else
                            -- Kick without message
                            targetNetuser:Kick(NetError.Facepunch_Connector_VAC_Banned, true)
                        end
                        -- If check was triggered by chat command send a notice
                        if(srcfunc == "cmd") then
                            rust.Notice(netuser, "VAC ban detected on "..playerInfo.."["..daysSinceLastBan.." days]. Player kicked")
                        end
                    else -- Days since last ban is above threshold
                        print(self.Title..': '..playerInfo..' VAC ban detected but above threshold ['..daysSinceLastBan..' days]. Not kicking')
                        -- If check was triggered by chat command send a notice
                        if(srcfunc == "cmd") then
                            rust.Notice(netuser, playerInfo.." VAC ban detected but above threshold ["..daysSinceLastBan.." days]. Not kicking")
                        end
                    end
                else -- No threshold is set
                    if(self.Config.logToConsole == "true") then
                        -- Print console message when set to true and kick
                        print(self.Title..': VAC ban detected on '..playerInfo..'. Kicking player...')
                        targetNetuser:Kick(NetError.Facepunch_Connector_VAC_Banned, true)
                        print(self.Title..': '..playerInfo..' has been kicked.')
                    else
                        -- Kick without message
                        targetNetuser:Kick(NetError.Facepunch_Connector_VAC_Banned, true)
                    end
                    -- If check was triggered by chat command send a notice
                    if(srcfunc == "cmd") then
                        rust.Notice(netuser, "VAC ban detected on "..playerInfo.."["..daysSinceLastBan.." days]. Player kicked")
                    end
                end
            else
                -- Victim not vac banned
                if(self.Config.logToConsole == "true") then
                    print(self.Title..': '..playerInfo..' no ban detected')
                end
                -- If check was triggered by chat command send a notice
                if(srcfunc == "cmd") then
                    rust.Notice(netuser, "No VAC ban detected on "..playerInfo)
                end
            end
        else
            print(self.Title..': ERROR - Webrequest failed. Errorcode: '..tostring(code))
            return
        end
    end)
    if(not r) then
        print(self.Title..': ERROR - Webrequest failed. Couldnt send request')
        return
    end
    if(debug == true) then
        print(self.Title..": DEBUG - r: "..tostring(r))
    end
end
