PLUGIN.Title = "SharedGameKicker"
PLUGIN.Author = "#Domestos"
PLUGIN.Version = "1.3"
PLUGIN.Description = "Kicks people that play with a shared game and dont own it themselfs"
PLUGIN.ResourceId = "474"
PLUGIN.ConfigFile = "SharedGameKicker"

-- Debug mode
local debug = false
--

function PLUGIN:Init()
    self:LoadConfig()
    print(self.Title.." v"..self.Version.." loaded")
end

function PLUGIN:LoadConfig()
    local b, res = config.Read(self.ConfigFile)
    self.Config = res or {}

    -- Config settings
    self.Config.Settings = self.Config.Settings or {}
    self.Config.Settings.apikey = self.Config.apikey or self.Config.Settings.apikey or ""
    self.Config.Settings.logToConsole = self.Config.logToConsole or self.Config.Settings.logToConsole or true
    self.Config.Whitelist = self.Config.Whitelist or {"123456789"}

    -- Remove old settings
    self.Config.apikey = nil            -- removed in 1.3
    self.Config.logToConsole = nil      -- removed in 1.3

    -- Save config file
    config.Save(self.ConfigFile, {
        indent = true,
        keyorder = {
            "Settings",
                "apikey",
                "logToConsole",
            "Whitelist"
        }
    })
end

function PLUGIN:OnUserConnect(netuser)
    if(not netuser) then
        return
    end
    -- Check if api key is set
    if(self.Config.Settings.apikey == "" or self.Config.Settings.apikey == nil) then
        print(self.Title..': ERROR - No steam api key found')
        return
    end
    -- Set variables for easier string formatting
    local playerInfo = netuser.displayName..' ('..rust.GetLongUserID(netuser)..')'
    -- Check whitelist
    for key, value in pairs(self.Config.Whitelist) do
        if(self.Config.Whitelist[key] == rust.GetLongUserID(netuser)) then
            if(self.Config.Settings.logToConsole == true) then
                print(self.Title..": "..playerInfo.." is whitelisted. Letting him join")
                return
            else
                return
            end
        end
    end
    -- Webrequest steam api
    local url = 'http://api.steampowered.com/IPlayerService/IsPlayingSharedGame/v0001/?key='..self.Config.Settings.apikey..'&steamid='..rust.GetLongUserID(netuser)..'&appid_playing=252490'
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
            if(response.response.lender_steamid ~= "0") then -- returns 0(string) if not shared, steamid if shared
                if(self.Config.Settings.logToConsole == true) then
                    print(self.Title..": "..playerInfo.." doesnt own Rust himself. Kicking player...")
                    netuser:Kick(NetError.ApprovalDenied, true)
                    print(self.Title..": "..playerInfo.." has been kicked")
                else
                    netuser:Kick(NetError.ApprovalDenied, true)
                end
            else -- Not shared
                if(self.Config.Settings.logToConsole == true) then
                    print(self.Title..": "..playerInfo.." owns Rust himself. Letting player join")
                end
            end
        else
            print(self.Title..': ERROR - Webrequest failed. Errorcode: '..tostring(code))
            return
        end
    end)
    if(not r) then
        print(self.Title..': ERROR - Webrequest failed. Webrequest couldnt be sent')
        return
    end
    if(debug == true) then
        print(self.Title..": DEBUG - r: "..tostring(r))
    end
end