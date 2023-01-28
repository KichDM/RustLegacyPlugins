PLUGIN.Title         = "Decay Control"
PLUGIN.Author        = "Gliktch"
PLUGIN.Description   = "Turns building decay on or off, with the option to leave decay on but customise the time it takes for structures to decay."
PLUGIN.Version       = "0.8.12"
PLUGIN.ConfigVersion = "0.5"
PLUGIN.ResourceID    = "334"

function PLUGIN:Init()

    print("Loading Decay Control mod...")

    self:LoadConfig()

    self:AddChatCommand( "decay", self.cmdDecay )

    if (self.Config.DecayOff) then
        self:DisableDecay()
    else
        self:EnableDecay()
    end
end

function PLUGIN:PostInit()
    self.oxminPlugin = plugins.Find("oxmin")
    if (self.oxminPlugin) then
        self.FLAG_DECAY = oxmin.AddFlag("decay")
        self.oxminPlugin:AddExternalOxminChatCommand(self, "decay", { }, self.cmdDecay)
    end
    self.flagsPlugin = plugins.Find("flags")
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

function PLUGIN:LoadConfig()
    local b, res = config.Read("decay")
    self.Config = res or {}
    if (not b) then
        print("Decay Control: Creating default config...")
        self:LoadDefaultConfig()
        if (res) then config.Save("decay") end
    end
end

function PLUGIN:LoadDefaultConfig()
    self.Config.ConfigVersion = "0.5"
    self.Config.CheckForUpdates = true
    self.Config.DecayOff = true
    self.Config.DecayTime = 4838400
    self.Config.PublicDecayStatus = true
    self.Config.CheckTickRate = true
end

function PLUGIN:cmdDecay( netuser, args )
    if (self:HasFlag(netuser,"decay")) then
        if ((not args[1]) or (args[1] == "?") or (args[1] == "help")) then
            self:PrintSyntax( netuser )
        elseif (string.lower(args[1]) == "on") then
            self:EnableDecay( netuser )
        elseif (string.lower(args[1]) == "off") then
            self:DisableDecay( netuser )
        elseif (type(tonumber(args[1])) == "number") then
            if (args[2]) then
                if     (string.sub(string.lower(args[2]), 1, 4) == "hour") then
                    self.Config.DecayTime = self:round( (args[1] *   3600), 0 )
                elseif (string.sub(string.lower(args[2]), 1, 3) == "day") then
                    self.Config.DecayTime = self:round( (args[1] *  86400), 0 )
                elseif (string.sub(string.lower(args[2]), 1, 4) == "week") then
                    self.Config.DecayTime = self:round( (args[1] * 604800), 0)
                else
                    self:PrintSyntax( netuser )
                    return
                end
            else
                -- Assume 'days' if the unit of DecayTime is not provided
                rust.SendChatToUser( netuser, "Decay Control: Assuming you meant " .. tonumber(args[1]) .. " days." )
                self.Config.DecayTime = self:round( (tonumber(args[1]) *  86400), 0 )
            end
            self:EnableDecay( netuser )
        else
            self:PrintSyntax( netuser )
        end
        self:PrintDecayStatus( netuser )
    else
        if (self.Config.PublicDecayStatus) then
            self:PrintDecayStatus( netuser )
        else
            rust.SendChatToUser("Decay Control: You do not have access to this command.")
        end
    end
end

function PLUGIN:DisableDecay( netuser )
    self:CheckTickRate()
    if (not DecayTouchTimer) then
        DecayTouchTimer = timer.Repeat( 60, function() rust.RunServerCommand("structure.touchall") end )
    end
    self.Config.DecayOff = true
    config.Save("decay")
    local offmsg = "Decay Control: Decay has been disabled."
    if (netuser) then
        rust.SendChatToUser( netuser, offmsg )
    end
    print(offmsg)
end

function PLUGIN:EnableDecay( netuser )
    self:CheckTickRate()
    if (DecayTouchTimer) then
        DecayTouchTimer:Destroy()
--      if (DecayReinstateAlertTimer) then
--          DecayReinstateAlertTimer:Destroy()
--      end
--      DecayReinstateAlertTimer = timer.Repeat( 60, 3, function() rust.BroadcastChat("Decay Control: Decay has been re-enabled. Decay time is now set to " .. self:CalculateDecayTime(self.Config.DecayTime)) end )
    end
    self.Config.DecayOff = false
    config.Save("decay")
    local onmsg = "Decay Control: Decay has been enabled."
    local minmsg = "Decay Control: Please note that with a very low DecayTime value (currently " .. self:CalculateDecayTime(self.Config.DecayTime) .. "), decay may behave unexpectedly."
    if (not netuser) then
        DecayRateSetTimer = timer.Once( 60, function() rust.RunServerCommand("decay.deploy_maxhealth_sec " .. math.floor(tonumber(self.Config.DecayTime))) end )
    else
        rust.RunServerCommand("decay.deploy_maxhealth_sec " .. math.floor(tonumber(self.Config.DecayTime)))
        rust.SendChatToUser( netuser, onmsg )
        if (self.Config.DecayTime < 43200) then
            rust.SendChatToUser( netuser, minmsg )
        end
    end
    print(onmsg)
    if (self.Config.DecayTime < 43200) then
        print(minmsg)
    end
end

function PLUGIN:toboolean(var)
  return not not var
end

function PLUGIN:round(num, dec)
  local pow = 10^(dec or 0)
  return math.floor(num * pow + 0.5) / pow
end

function PLUGIN:CalculateDecayTime( secs )
    if (secs < 86400) then
        result = self:round((secs / 3600), 2) .. " hour(s)"
    elseif (secs < 604800) then
        result = self:round((secs / 86400), 2) .. " day(s)"
    else
        result = self:round((secs / 604800), 2) .. " week(s)"
    end
    return result
end

function PLUGIN:CheckTickRate()
    local errmsg = "Decay Control: DecayTickRate setting too low or not found - resetting to default (300)."
    if ((self.Config.CheckTickRate) and ((not Rust.decay.decaytickrate) or (Rust.decay.decaytickrate < 100))) then
        error(errmsg)
        rust.BroadcastChat(errmsg)
        rust.RunServerCommand("decay.decaytickrate 300")
    end
end

function PLUGIN:PrintDecayStatus( netuser )
    local statusmsg = "Decay is currently " .. (self:toboolean(self.Config.DecayOff) and "OFF.  Decay Control is continuously keeping buildings from decaying. :)" or "ON, Decay Time is " .. self:CalculateDecayTime(self.Config.DecayTime) .. ".")
    rust.SendChatToUser( netuser, statusmsg )
end

function PLUGIN:PrintSyntax( netuser )
    rust.SendChatToUser( netuser, "Decay Control Syntax: You may use /decay [number] [hour(s)|day(s)|week(s)]")
    rust.SendChatToUser( netuser, "or /decay [on|off], or simply /decay by itself to show current settings.")
end