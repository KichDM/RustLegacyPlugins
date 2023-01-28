PLUGIN.Title = "Im Invincible"
PLUGIN.Author = "#Domestos"
PLUGIN.Version = "1.3"
PLUGIN.Description = "Simple Godmode and option to heal"
PLUGIN.ResourceId = "553"

-- changelog
-- code cleanup
-- console commands
-- godmode, heal on target


-- Debug mode
local debug = false
-- ----------------

-- ****************************
-- Init
-- ****************************
function PLUGIN:Init()
    self:AddChatCommand("godmode", self.cmdGodMode)
    self:AddChatCommand("heal", self.cmdHeal)
    self:AddCommand("invincible", "godmode", self.ccmdGodMode)
    self:AddCommand("invincible", "heal", self.ccmdHeal)
    -- Set godmode table
    self.GodMode = {}
    print(self.Title .. " v" .. self.Version .. " loaded")
end
function PLUGIN:PostInit()
    self:LoadFlags()
end

-- ****************************
-- Flag and permission handling
-- ****************************
function PLUGIN:LoadFlags()
    -- Flags Plugin
    self.flagsPlugin = plugins.Find("flags")
    if(self.flagsPlugin) then
        self.flagsPlugin:AddFlagsChatCommand(self, "godmode", {"invincible"}, self.cmdGodMode)
        self.flagsPlugin:AddFlagsChatCommand(self, "heal", {"invincible"}, self.cmdHeal)
    end
    -- Oxmin Plugin
    self.oxminPlugin = plugins.Find("oxmin")
    if(self.oxminPlugin) then
        self.FLAG_INVINCIBLE = oxmin.AddFlag("invincible")
        self.oxminPlugin:AddExternalOxminChatCommand(self, "godmode", {self.FLAG_INVINCIBLE}, self.cmdGodMode)
        self.oxminPlugin:AddExternalOxminChatCommand(self, "heal", {self.FLAG_INVINCIBLE}, self.cmdHeal)
    end
end
function PLUGIN:HasPermission(netuser)
    if(netuser:CanAdmin()) then
        return true
    elseif((self.oxminPlugin ~= nil) and (self.oxminPlugin:HasFlag(netuser, self.FLAG_INVINCIBLE))) then
        return true
    elseif((self.flagsPlugin ~= nil) and (self.flagsPlugin:HasFlag(netuser, "invincible"))) then
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
-- split a string into a table
-- ****************************
local function split(str, sep)
    local tbl = {}
    for word in string.gmatch(str, "[^"..sep.."]+") do
        table.insert(tbl, word)
    end
    return tbl
end

-- ****************************
-- PLUGIN:ccmdGodMode()
-- Console command to trigger cmdGodMode()
-- ****************************
function PLUGIN:ccmdGodMode(arg)
    local netuser = arg.argUser
    if(netuser and not netuser:CanAdmin()) then
        arg:ReplyWith("You dont have permission to use this command")
        return
    end
    local args = split(arg.ArgsStr, " ")
    self:cmdGodMode(netuser, "", args)
    return true
end
-- ****************************
-- PLUGIN:cmdGodMode()
-- Handles godmode
-- ****************************
function PLUGIN:cmdGodMode(netuser, cmd, args)
    if(netuser and not self:HasPermission(netuser)) then
        rust.Notice(targetNetuser, "You dont have permission to use this command")
        return
    end
    if (type(cmd) == "table") then args = cmd end
    if(not netuser and not args[1]) then
        print("Syntax: \"/godmode name|steam64id\"")
        return
    end
    -- Set target netuser
    local targetNetuser
    if(netuser) then
        targetNetuser = netuser
    end
    if(args[1]) then
        targetNetuser = GetTargetNetuser(args[1])
        if(targetNetuser == false) then
            if(not netuser) then
                print("No player found with that name|steam64id")
            else
                rust.Notice(netuser, "No player found with that name|steam64id")
            end
            return
        end
    end
    -- Debug
    if(debug) then
        print(self.Title..": ----- DEBUG cmdGodMode() -----")
        print("targetSteamID64: "..tostring(rust.GetLongUserID(targetNetuser)))
        print("HasPermission: "..tostring(self:HasPermission(netuser)))
    end
    -- Set some vars
    local controllable = targetNetuser.playerClient.controllable
    local takeDamage = controllable:GetComponent("TakeDamage")
    local targetSteamID64 = rust.GetLongUserID(targetNetuser)
    local targetName = targetNetuser.displayName
    -- Set godmode on or off
    if(#self.GodMode > 0) then
        for key, value in pairs(self.GodMode) do
            if(value == targetSteamID64) then
                takeDamage:SetGodMode(false)
                table.remove(self.GodMode, key)
                -- Debug
                if(debug) then
                    print("GodMode table: "..tostring(targetSteamID64).." removed")
                    print("------------------------------")
                end
                -- Notice player
                rust.Notice(targetNetuser, "Godmode off")
                if(netuser and netuser ~= targetNetuser) then
                    rust.Notice(netuser, "Godmode off for "..targetName)
                end
                if(not netuser) then
                    print("Godmode off for "..targetName)
                end
                return
            end
        end
    end
    takeDamage:SetGodMode(true)
    table.insert(self.GodMode, targetSteamID64)
    -- Notice player
    rust.Notice(targetNetuser, "Godmode on")
    if(netuser and netuser ~= targetNetuser) then
        rust.Notice(netuser, "Godmode on for "..targetName)
    end
    if(not netuser) then
        print("Godmode on for "..targetName)
    end
    -- Debug
    if(debug) then
        print("GodMode table: "..tostring(targetSteamID64).." added")
        print("------------------------------")
    end
end

-- ****************************
-- PLUGIN:ccmdHeal()
-- Console command to trigger cmdHeal()
-- ****************************
function PLUGIN:ccmdHeal(arg)
    local netuser = arg.argUser
    if(netuser and not netuser:CanAdmin()) then
        arg:ReplyWith("You dont have permission to use this command")
        return
    end
    local args = split(arg.ArgsStr, " ")
    self:cmdHeal(netuser, "", args)
    return true
end
-- ****************************
-- PLUGIN:cmdHeal()
-- Handles healing
-- ****************************
function PLUGIN:cmdHeal(netuser, cmd, args)
    if(netuser and not self:HasPermission(netuser)) then
        rust.Notice(netuser, "You dont have permission to use this command")
        return
    end
    if (type(cmd) == "table") then args = cmd end
    if(not netuser and not args[1]) then
        print("Syntax: \"/heal name|steam64id\"")
        return
    end
    -- Get target netuser
    local targetNetuser
    if(netuser) then
        targetNetuser = netuser
    end
    if(args[1]) then
        targetNetuser = GetTargetNetuser(args[1])
        if(targetNetuser == false) then
            if(not netuser) then
                print("No player found with that name|steam64id")
            else
                rust.Notice(netuser, "No player found with that name|steam64id")
            end
            return
        end
    end
    -- Set some vars
    local targetSteamID64 = rust.GetLongUserID(targetNetuser)
    local targetName = targetNetuser.displayName
    local controllable = targetNetuser.playerClient.controllable
    local metabolism = controllable:GetComponent("Metabolism")
    local fallDamage = controllable:GetComponent("FallDamage")
    local humanBodyTakeDamage = controllable:GetComponent("HumanBodyTakeDamage")
    local char = rust.GetCharacter(targetNetuser)
    local radLevel = metabolism:GetRadLevel()
    -- Debug
    if(debug == true) then
        print(self.Title..": ----- DEBUG cmdHeal() -----")
        print("targetSteamID64: "..tostring(targetSteamID64))
        print("targetName: "..targetName)
        print("HasPermission: "..tostring(self:HasPermission(netuser)))
        print("health: "..tostring(char.takeDamage.health))
        print("GetCalorieLevel: "..tostring(metabolism:GetCalorieLevel()))
        print("RadLevel: "..tostring(metabolism:GetRadLevel()))
        print("GetLegInjury: "..tostring(fallDamage:GetLegInjury()))
        print("IsBleeding: "..tostring(humanBodyTakeDamage:IsBleeding()))
        print("---------------------------")
    end
    -- Cure player
    if(char.takeDamage.health < 99) then
        char.takeDamage.health = 99
    end
    if(radLevel > 0) then
        metabolism:AddAntiRad(radLevel)
    end
    metabolism:AddCalories(3000)
    fallDamage:ClearInjury()
    humanBodyTakeDamage:SetBleedingLevel(0)
    -- Notice player
    if(netuser and netuser ~= targetNetuser) then
        rust.Notice(netuser, targetName.." was healed")
        rust.Notice(targetNetuser, "You got healed")
    end
    if(not netuser) then
        print(targetName.." was healed")
    end
end

-- ****************************
-- PLUGIN:OnUserConnect()
-- Triggered when someone connects
-- ****************************
function PLUGIN:OnUserDisconnect(networkplayer)
    local netuser = networkplayer:GetLocalData()
    if(#self.GodMode > 0) then
        for key, value in pairs(self.GodMode) do
            if(value == rust.GetLongUserID(netuser)) then
                table.remove(self.GodMode, key)
            end
        end
    end
end