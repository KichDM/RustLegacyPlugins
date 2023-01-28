PLUGIN.Title = "Flags and Oxmin Flag Info"
PLUGIN.Author = "#Domestos"
PLUGIN.Version = "0.2.2"
PLUGIN.Description = "Extends Oxmin and Flags for easier flag control"
PLUGIN.ResourceId = "641"

function PLUGIN:Init()
    self:AddCommand("oxmin", "flaglist", self.ccmdOxminFlagList)
    self:AddCommand("oxmin", "userflags", self.ccmdOxminUserFlags)
    self:AddCommand("oxmin", "userswithflag", self.ccmdUsersWithOxminFlag)
    self:AddCommand("flags", "userflags", self.ccmdFlagsUserFlags)
    self:AddCommand("flags", "userswithflag", self.ccmdUsersWithFlagsFlag)
    print(self.Title .. " v" .. self.Version .. " loaded")
end

function PLUGIN:PostInit()
    self.oxminPlugin = plugins.Find("oxmin")
    self.flagsPlugin = plugins.Find("flags")
    if(not self.oxminPlugin and not self.flagsPlugin) then
        error("No Flags or Oxmin plugin found!")
    end
end

-- ****************************
-- GetTargetNetuser()
-- Trys to get a netuser by name or id
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
-- ccmdOxminFlagList()
-- lists all flags tracked by Oxmin with id and name
-- ****************************
function PLUGIN:ccmdOxminFlagList(arg)
    if(not self.oxminPlugin) then
        arg:ReplyWith("Oxmin plugin not found")
        return true
    end
    local netuser = arg.argUser
    if(netuser and not netuser:CanAdmin()) then
        arg:ReplyWith("You need to be admin")
        return
    end
    print("--- Oxmin flags ---")
    for key, value in pairs(oxmin.flagtostr) do
        print(key, value)
    end
    return true
end

-- ****************************
-- ccmdOxminUserFlags()
-- lists all Oxmin flags assigned to the given user
-- ****************************
function PLUGIN:ccmdOxminUserFlags(arg)
    if(not self.oxminPlugin) then
        arg:ReplyWith("Oxmin plugin not found")
        return true
    end
    local netuser = arg.argUser
    if(netuser and not netuser:CanAdmin()) then
        arg:ReplyWith("You need to be admin")
        return
    end
    local targetName
    if(string.len(arg:GetString(0)) > 1) then
        targetName = arg:GetString(0)
    else
        arg:ReplyWith("Syntax: \"oxmin.userflags name\"")
        return true
    end
    for key, value in pairs(self.oxminPlugin.Data.Users) do
        if(self.oxminPlugin.Data.Users[key].Name == targetName) then
            print("--- Oxmin flags for "..targetName.." ---")
            for k, v in pairs(self.oxminPlugin.Data.Users[key].Flags) do
                print(v, oxmin.flagtostr[v])
            end
            return true
        end
    end
    print("No players tracked by Oxmin with that name")
    return true
end

-- ****************************
-- ccmdUsersWithOxminFlag()
-- lists all users that have the given Oxmin flag
-- ****************************
function PLUGIN:ccmdUsersWithOxminFlag(arg)
    if(not self.oxminPlugin) then
        arg:ReplyWith("Oxmin plugin not found")
        return true
    end
    local netuser = arg.argUser
    if(netuser and not netuser:CanAdmin()) then
        arg:ReplyWith("You need to be admin")
        return
    end
    local targetFlag, userFound
    if(string.len(arg:GetString(0)) > 1) then
        targetFlag = arg:GetString(0)
    else
        arg:ReplyWith("Syntax: \"oxmin.userswithflag flag\"")
        return true
    end
    print("--- Users with flag "..targetFlag.." ---")
    for key, value in pairs(self.oxminPlugin.Data.Users) do
        for k, v in pairs(self.oxminPlugin.Data.Users[key].Flags) do
            if(oxmin.flagtostr[v] == targetFlag) then
                print(self.oxminPlugin.Data.Users[key].Name.." ("..key..")")
                userFound = true
            end
        end
    end
    if(not userFound) then print("No players found with that flag") end
    return true
end

-- ****************************
-- ccmdFlagsUserFlags()
-- lists all Flags plugin flags assigned to the given user
-- ****************************
function PLUGIN:ccmdFlagsUserFlags(arg)
    if(not self.flagsPlugin) then
        arg:ReplyWith("Flags plugin not found")
        return true
    end
    local netuser = arg.argUser
    if(netuser and not netuser:CanAdmin()) then
        arg:ReplyWith("You need to be admin")
        return
    end
    local targetNetuser, targetName, targetSteamID64
    if(string.len(arg:GetString(0)) > 1) then
        targetNetuser = GetTargetNetuser(arg:GetString(0))
        if(string.match(arg:GetString(0), "%a")) then
            if(targetNetuser) then
                targetName = targetNetuser.displayName
                targetSteamID64 = rust.GetLongUserID(targetNetuser)
            else
                arg:ReplyWith("The given user is not online, you can only search for offline users by steamID64")
                return true
            end
        else
            if(targetNetuser) then
                targetName = targetNetuser.displayName
                targetSteamID64 = rust.GetLongUserID(targetNetuser)
            else
                targetName = false
                targetSteamID64 = arg:GetString(0)
            end
        end
    else
        arg:ReplyWith("Syntax: \"flags.userflags name|steamID64\"")
        return true
    end
    for key, value in pairs(self.flagsPlugin.FlagData.Users) do
        if(self.flagsPlugin.FlagData.Users[key].SteamID == targetSteamID64) then
            if(targetName) then
                print("--- Flags plugin flags for "..targetName.." ---")
            else
                print("--- Flags plugin flags for "..targetSteamID64.." ---")
            end
            for k, v in pairs(self.flagsPlugin.FlagData.Users[key].Flags) do
                print(self.flagsPlugin.FlagData.Users[key].Flags[k])
            end
            return true
        end
    end
    arg:ReplyWith("No players tracked by Flags with that name|SteamID64")
    return true
end

-- ****************************
-- ccmdUsersWithFlagsFlag()
-- lists all users that have the given Flags plugin flag
-- ****************************
function PLUGIN:ccmdUsersWithFlagsFlag(arg)
    if(not self.flagsPlugin) then
        arg:ReplyWith("Flags plugin not found")
        return true
    end
    local netuser = arg.argUser
    if(netuser and not netuser:CanAdmin()) then
        arg:ReplyWith("You need to be admin")
        return
    end
    local targetFlag, userFound
    if(string.len(arg:GetString(0)) > 1) then
        targetFlag = arg:GetString(0)
    else
        arg:ReplyWith("Syntax: \"flags.userswithflag flag\"")
        return true
    end
    print("--- Users with flag "..targetFlag.." ---")
    for key, value in pairs(self.flagsPlugin.FlagData.Users) do
        for k, v in pairs(self.flagsPlugin.FlagData.Users[key].Flags) do
            if(self.flagsPlugin.FlagData.Users[key].Flags[k] == targetFlag) then
                local targetNetuser = GetTargetNetuser(self.flagsPlugin.FlagData.Users[key].SteamID)
                if(targetNetuser) then
                    print(targetNetuser.displayName.." ("..key..")")
                else
                    print(self.flagsPlugin.FlagData.Users[key].SteamID)
                end
                userFound = true
            end
        end
    end
    if(not userFound) then arg:ReplyWith("No players found with that flag") end
    return true
end