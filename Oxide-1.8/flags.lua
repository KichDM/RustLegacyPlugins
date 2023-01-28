PLUGIN.Title = "Flags"
PLUGIN.Description = "Easily handle what users and groups can and can not do."
PLUGIN.Author = "eDeloa and changes by BuSheeZy"
PLUGIN.Version = "1.2.3"

print(PLUGIN.Title .. " (" .. PLUGIN.Version .. ") plugin loaded")

-- Called when then plugin is loaded.
function PLUGIN:Init()
  api.Bind(self, "flags")

  -- Load flag data or create one if nonexistant
  if (not self:ReloadFlags()) then
    self.FlagData = {}
    self.FlagData.Users = {}
    self.FlagData.Groups = {}

    self:CreateGroup("everyone")
    self:CreateGroup("admins")
    self:CreateGroup("owners")
    self:AddGroupFlag("owners", "rcon")
  end

  -- Chat commands
  --self:AddChatCommand("flags", self.cmdFlags)

  -- Console commands
  self:AddFlagsConsoleCommand(self, "flags", "addflag", {"rcon"}, self.conAddFlag)
  self:AddFlagsConsoleCommand(self, "flags", "removeflag", {"rcon"}, self.conRemoveFlag)
  self:AddFlagsConsoleCommand(self, "flags", "deleteuser", {"rcon"}, self.conDeleteUser)

  self:AddFlagsConsoleCommand(self, "flags", "addtogroup", {"rcon"}, self.conAddToGroup)
  self:AddFlagsConsoleCommand(self, "flags", "removefromgroup", {"rcon"}, self.conRemoveFromGroup)

  self:AddFlagsConsoleCommand(self, "flags", "creategroup", {"rcon"}, self.conCreateGroup)
  self:AddFlagsConsoleCommand(self, "flags", "deletegroup", {"rcon"}, self.conDeleteGroup)

  self:AddFlagsConsoleCommand(self, "flags", "addgroupflag", {"rcon"}, self.conAddGroupFlag)
  self:AddFlagsConsoleCommand(self, "flags", "removegroupflag", {"rcon"}, self.conRemoveGroupFlag)

  self:AddFlagsConsoleCommand(self, "flags", "reloadflags", {"rcon"}, self.conReloadFlags)
end

-- *******************************************
-- CONSOLE COMMANDS
-- *******************************************
function PLUGIN:conAddFlag(arg)
  -- Locate the target user
  local success, targetUser = rust.FindNetUsersByName(arg:GetString(0))
  if (not success) then
    if (targetUser == 0) then
      arg:ReplyWith("No players found with that name!")
    else
      arg:ReplyWith("Multiple players found with that name!")
    end
    return true
  end

  -- Add flag to the target uesr
  local flag = arg:GetString(1)
  local success, err = self:AddFlag(targetUser, flag)
  if (not success) then
    arg:ReplyWith(err)
    return true
  end

  arg:ReplyWith("Successfully added flag!")
  return true
end

function PLUGIN:conRemoveFlag(arg)
  -- Locate the target user
  local success, targetUser = rust.FindNetUsersByName(arg:GetString(0))
  if (not success) then
    if (targetUser == 0) then
      arg:ReplyWith("No players found with that name!")
    else
      arg:ReplyWith("Multiple players found with that name!")
    end
    return true
  end
  
  -- Remove flag from the target user
  local flag = arg:GetString(1)
  local success, err = self:RemoveFlag(targetUser, flag)
  if (not success) then
    arg:ReplyWith(err)
    return true
  end

  arg:ReplyWith("Successfully removed flag!")
  return true
end

function PLUGIN:conDeleteUser(arg)
  -- Locate the target user
  local success, targetUser = rust.FindNetUsersByName(arg:GetString(0))
  if (not success) then
    if (targetUser == 0) then
      arg:ReplyWith("No players found with that name!")
    else
      arg:ReplyWith("Multiple players found with that name!")
    end
    return true
  end
  
  -- Remove flag from the target user
  local success, err = self:DeleteUser(targetUser)
  if (not success) then
    arg:ReplyWith(err)
    return true
  end

  arg:ReplyWith("Successfully deleted user!")
  return true
end

function PLUGIN:conAddToGroup(arg)
  -- Locate the target user
  local success, targetUser = rust.FindNetUsersByName(arg:GetString(0))
  if (not success) then
    if (targetUser == 0) then
      arg:ReplyWith("No players found with that name!")
    else
      arg:ReplyWith("Multiple players found with that name!")
    end
    return true
  end

  -- Add user to target group
  local groupName = arg:GetString(1)
  local success, err = self:AddToGroup(targetUser, groupName)
  if (not success) then
    arg:ReplyWith(err)
    return true
  end

  arg:ReplyWith("Successfully added user to group!")
  return true
end

function PLUGIN:conRemoveFromGroup(arg)
  -- Locate the target user
  local success, targetUser = rust.FindNetUsersByName(arg:GetString(0))
  if (not success) then
    if (targetUser == 0) then
      arg:ReplyWith("No players found with that name!")
    else
      arg:ReplyWith("Multiple players found with that name!")
    end
    return true
  end

  -- Remove user from target group
  local groupName = arg:GetString(1)
  local success, err = self:RemoveFromGroup(targetUser, groupName)
  if (not success) then
    arg:ReplyWith(err)
    return true
  end

  arg:ReplyWith("Successfully removed user from group!")
  return true
end

function PLUGIN:conCreateGroup(arg)
  local groupName = arg:GetString(0)
  local success, err = self:CreateGroup(groupName)
  if (not success) then
    arg:ReplyWith(err)
    return true
  end

  arg:ReplyWith("Successfully created group!")
  return true
end

function PLUGIN:conDeleteGroup(arg)
  local groupName = arg:GetString(0)
  local success, err = self:DeleteGroup(groupName)
  if (not success) then
    arg:ReplyWith(err)
    return true
  end

  arg:ReplyWith("Successfully removed group!")
  return true
end

function PLUGIN:conAddGroupFlag(arg)
  -- Add flag to group
  local groupName = arg:GetString(0)
  local flag = arg:GetString(1)
  local success, err = self:AddGroupFlag(groupName, flag)
  if (not success) then
    arg:ReplyWith(err)
    return true
  end

  arg:ReplyWith("Successfully added flag!")
  return true
end

function PLUGIN:conRemoveGroupFlag(arg)
  -- Remove flag from group
  local groupName = arg:GetString(0)
  local flag = arg:GetString(1)
  local success, err = self:RemoveGroupFlag(groupName, flag)
  if (not success) then
    arg:ReplyWith(err)
    return true
  end

  arg:ReplyWith("Successfully removed flag!")
  return true
end

function PLUGIN:conReloadFlags(arg)
  local success, err = self:ReloadFlags()
  if (not success) then
    arg:ReplyWith(err)
    return true
  end

  arg:ReplyWith("Successfully reloaded flags!")
  return true
end

-- *******************************************
-- API COMMANDS
-- *******************************************

-- *******************************************
-- api.Call("flags", "AddFlagsChatCommand", self, "addpack", { "kick" }, self.cmdAddPack)
-- flags_plugin:AddFlagsChatCommand(self, "addpack", { "kick" }, self.cmdAddPack)
-- *******************************************
function PLUGIN:AddFlagsChatCommand(plugin, name, flagsrequired, callback)
  -- Get a reference to this permissions plugin
  local flags_plugin = plugins.Find("flags")
  if (not flags_plugin) then
    error("Flags plugin file was renamed (don't do this)!")
    return false
  end
  
  -- Define a proxy callback that checks for flags
  local function FlagsChatCallback(self, netuser, cmd, args)
    local steamID = rust.CommunityIDToSteamID(tonumber(rust.GetUserID(netuser)))
    if (not (flags_plugin:HasFlags(steamID, flagsrequired) or flags_plugin:CanRCON(netuser))) then
      rust.Notice(netuser, "You are not allowed to use this command!")
      return true
    end
    print("'" .. netuser.displayName .. "' (" .. steamID .. ") ran command '/" .. cmd .. " " .. table.concat(args, " ") .. "'")
    callback(self, netuser, cmd, args)
  end
  
  -- Add the chat command
  plugin:AddChatCommand(name, FlagsChatCallback)
end

-- *******************************************
-- api.Call("flags", "AddFlagsConsoleCommand", self, "basics", "kick", { "kick" }, self.cmdKick)
-- flags_plugin:AddFlagsConsoleCommand(self, "basics", "kick", { "kick" }, self.cmdKick)
-- *******************************************
function PLUGIN:AddFlagsConsoleCommand(plugin, pluginname, commandname, flagsrequired, callback)
  -- Get a reference to this permissions plugin
  local flags_plugin = plugins.Find("flags")
  if (not flags_plugin) then
    error("Flags plugin file was renamed (don't do this)!")
    return false
  end
  
  -- Define a proxy callback that checks for flags
  local function FlagsConsoleCallback(self, arg)
    local netuser = arg.argUser
    if (not netuser) then
      print("[SERVER] ran console command '" .. pluginname .. "." .. commandname .. "'")
      callback(self, arg)
      return true
    end
    
    -- Define a proxy callback that checks for flags
    local steamID = rust.CommunityIDToSteamID(tonumber(rust.GetUserID(netuser)))
    if (not (flags_plugin:HasFlags(steamID, flagsrequired) or flags_plugin:CanRCON(netuser))) then
      arg:ReplyWith("You are not allowed to use this command!")
      return true
    end
    print("'" .. netuser.displayName .. "' (" .. steamID .. ") ran console command '" .. pluginname .. "." .. commandname .. "'")
    callback(self, arg)
    return true
  end
  
  -- Add the chat command
  plugin:AddCommand(pluginname, commandname, FlagsConsoleCallback)
end

-- *******************************************
-- api.Call("flags", "HasFlag", steamid, "kick")
-- flags_plugin:HasFlag(steamid, "kick")
-- *******************************************
function PLUGIN:HasFlag(userarg, flag)
  flag = self:TrimString(flag)
  if (string.len(flag) == 0) then
    return true
  end
  
  if (self:GroupHasFlag("everyone", flag)) then
    return true
  end

  local steamID = self:ConvertUserArgToSteamID(userarg)
  if (not self:UserExists(steamID)) then
    return false
  end

  flag = string.lower(flag)
  local userData = self:GetUserData(steamID)

  -- Check individual flags
  for i = 1, #userData.Flags do
    if (userData.Flags[i] == flag or userData.Flags[i] == "rcon") then
      return true
    end
  end

  -- Check group flags
  for i = 1, #userData.Groups do
    if (self:GroupHasFlag(userData.Groups[i], flag)) then
      return true
    end
  end

  return false
end

-- *******************************************
-- api.Call("flags", "HasFlags", steamid, {"kick", "ban"})
-- flags_plugin:HasFlags(steamid, {"kick", "ban"})
-- *******************************************
function PLUGIN:HasFlags(userarg, flags)
  if (#flags == 0) then
    return true
  end

  local steamID = self:ConvertUserArgToSteamID(userarg)
  for i = 1, #flags do
    if (not self:HasFlag(steamID, flags[i])) then
      return false
    end
  end

  return true
end

-- *******************************************
-- api.Call("flags", "HasActualFlag", steamid, "kick")
-- flags_plugin:HasActualFlag(steamid, "kick")
-- *******************************************
function PLUGIN:HasActualFlag(userarg, flag)
  flag = self:TrimString(flag)
  if (string.len(flag) == 0) then
    return false
  end

  local steamID = self:ConvertUserArgToSteamID(userarg)
  if (not self:UserExists(steamID)) then
    return false
  end

  flag = string.lower(flag)
  local userData = self:GetUserData(steamID)

  -- Check individual flags
  for i = 1, #userData.Flags do
    if (userData.Flags[i] == flag) then
      return true
    end
  end

  return false
end

-- *******************************************
-- api.Call("flags", "AddFlag", steamid, "kick")
-- flags_plugin:AddFlag(steamid, "kick")
-- *******************************************
function PLUGIN:AddFlag(userarg, flag)
  flag = self:TrimString(flag)
  if (string.len(flag) == 0) then
    return false, "Invalid flag name."
  end

  flag = string.lower(flag)
  local steamID = self:ConvertUserArgToSteamID(userarg)
  local userData = self:GetUserData(steamID)

  if (self:HasActualFlag(steamID, flag)) then
    return false, "User already has that flag."
  end

  table.insert(userData.Flags, flag)
  self:SaveFlagData()
  return true
end

-- *******************************************
-- api.Call("flags", "RemoveFlag", steamid, "kick")
-- flags_plugin:RemoveFlag(steamid, "kick")
-- *******************************************
function PLUGIN:RemoveFlag(userarg, flag)
  flag = self:TrimString(flag)
  if (string.len(flag) == 0) then
    return false, "Invalid flag name."
  end

  local steamID = self:ConvertUserArgToSteamID(userarg)
  if (not self:UserExists(steamID)) then
    return false, "User does not exist."
  end

  flag = string.lower(flag)
  local userFlags = self.FlagData.Users[steamID].Flags
  for i = 1, #userFlags do
    if (userFlags[i] == flag) then
      table.remove(userFlags, i)
      self:CleanUser(steamID)
      self:SaveFlagData()
      return true
    end
  end

  return false, "User does not have that flag."
end

-- *******************************************
-- api.Call("flags", "AddToGroup", steamid, "admins")
-- flags_plugin:AddToGroup(steamid, "admins")
-- *******************************************
function PLUGIN:AddToGroup(userarg, groupname)
  groupname = self:TrimString(groupname)
  if (string.len(groupname) == 0) then
    return false, "Invalid group name."
  end

  if (string.lower(groupname) == "everyone") then
    return false, "Everyone is already part of that group."
  end

  if (self:UserInGroup(userarg, groupname)) then
    return false, "User is already in that group."
  end

  if (not self:GroupExists(groupname)) then
    self:CreateGroup(groupname)
  end

  local steamID = self:ConvertUserArgToSteamID(userarg)
  local userData = self:GetUserData(steamID)
  table.insert(userData.Groups, groupname)
  self:SaveFlagData()
  return true
end

-- *******************************************
-- api.Call("flags", "RemoveFromGroup", steamid, "admins")
-- flags_plugin:RemoveFromGroup(steamid, "admins")
-- *******************************************
function PLUGIN:RemoveFromGroup(userarg, groupname)
  local steamID = self:ConvertUserArgToSteamID(userarg)
  if (not self:UserExists(steamID)) then
    return false, "User does not exist."
  end

  groupname = string.lower(self:TrimString(groupname))
  local userGroups = self.FlagData.Users[steamID].Groups
  for i = 1, #userGroups do
    if (string.lower(userGroups[i]) == groupname) then
      table.remove(userGroups, i)
      self:CleanUser(steamID)
      self:SaveFlagData()
      return true
    end
  end

  return false, "User is not in that group."
end

-- *******************************************
-- api.Call("flags", "UserInGroup", steamid, "admins")
-- flags_plugin:UserInGroup(steamid, "admins")
-- *******************************************
function PLUGIN:UserInGroup(userarg, groupname)
  local steamID = self:ConvertUserArgToSteamID(userarg)
  if (not self:UserExists(steamID)) then
    return false
  end

  if (not self:GroupExists(groupname)) then
    return false
  end

  groupname = string.lower(self:TrimString(groupname))
  local groups = self.FlagData.Users[steamID].Groups
  for i = 1, #groups do
    if (string.lower(groups[i]) == groupname) then
      return true
    end
  end

  return false
end

-- *******************************************
-- api.Call("flags", "DeleteUser", steamid)
-- flags_plugin:DeleteUser(steamid)
-- *******************************************
function PLUGIN:DeleteUser(userarg)
  local steamID = self:ConvertUserArgToSteamID(userarg)
  if (not self:UserExists(steamID)) then
    return false, "User does not exist."
  end

  self.FlagData.Users[steamID] = nil
  self:SaveFlagData()
  return true
end

-- *******************************************
-- api.Call("flags", "CreateGroup", groupname)
-- flags_plugin:CreateGroup(groupname)
-- *******************************************
function PLUGIN:CreateGroup(groupname)
  groupname = self:TrimString(groupname)
  if (string.len(groupname) == 0) then
    return false, "Invalid group name."
  end

  if (self:GroupExists(groupname)) then
    return false, "Group already exists."
  end

  local groupKey = string.lower(groupname)
  self.FlagData.Groups[groupKey] = {}
  self.FlagData.Groups[groupKey].Name = groupname
  self.FlagData.Groups[groupKey].Flags = {}
  self:SaveFlagData()
  return true
end

-- *******************************************
-- api.Call("flags", "DeleteGroup", groupname)
-- flags_plugin:DeleteGroup(groupname)
-- *******************************************
function PLUGIN:DeleteGroup(groupname)
  groupname = self:TrimString(groupname)
  if (string.len(groupname) == 0) then
    return false, "Invalid group name."
  end

  if (not self:GroupExists(groupname)) then
    return false, "Group does not exist."
  end

  self.FlagData.Groups[string.lower(groupname)] = nil
  self:SaveFlagData()
  return true
end

-- *******************************************
-- api.Call("flags", "AddGroupFlag", groupname, "kick")
-- flags_plugin:AddGroupFlag(groupname, "kick")
-- *******************************************
function PLUGIN:AddGroupFlag(groupname, flag)
  if (not self:GroupExists(groupname)) then
    return false, "Group does not exist."
  end

  flag = self:TrimString(flag)
  if (string.len(flag) == 0) then
    return false, "Invalid flag name."
  end

  if (self:GroupHasFlag(groupname, flag)) then
    return false, "Group already has that flag."
  end

  flag = string.lower(flag)
  groupname = string.lower(self:TrimString(groupname))
  table.insert(self.FlagData.Groups[groupname].Flags, flag)
  self:SaveFlagData()
  return true
end

-- *******************************************
-- api.Call("flags", "RemoveGroupFlag", groupname, "kick")
-- flags_plugin:RemoveGroupFlag(groupname, "kick")
-- *******************************************
function PLUGIN:RemoveGroupFlag(groupname, flag)
  if (not self:GroupExists(groupname)) then
    return false, "Group does not exist."
  end

  flag = string.lower(self:TrimString(flag))
  groupname = string.lower(self:TrimString(groupname))
  local groupFlags = self.FlagData.Groups[groupname].Flags
  for i = 1, #groupFlags do
    if (groupFlags[i] == flag) then
      table.remove(groupFlags, i)
      self:SaveFlagData()
      return true
    end
  end

  return false, "Group does not have that flag."
end

-- *******************************************
-- api.Call("flags", "GroupHasFlag", groupname, "kick")
-- flags_plugin:GroupHasFlag(groupname, "kick")
-- *******************************************
function PLUGIN:GroupHasFlag(groupname, flag)
  if (not self:GroupExists(groupname)) then
    return false
  end

  flag = self:TrimString(flag)
  if (string.len(flag) == 0) then
    return false, "Invalid flag name."
  end

  flag = string.lower(flag)
  groupname = string.lower(self:TrimString(groupname))
  local flagsData = self.FlagData.Groups[groupname].Flags
  for i = 1, #flagsData do
    if (flagsData[i] == flag or flagsData[i] == "rcon") then
      return true
    end
  end

  return false
end

-- *******************************************
-- api.Call("flags", "GroupHasFlags", groupname, {"kick", "ban"})
-- flags_plugin:GroupHasFlags(groupname, {"kick", "ban"})
-- *******************************************
function PLUGIN:GroupHasFlags(groupname, flags)
  if (not self:GroupExists(groupname)) then
    return false
  end

  for i = 1, #flags do
    if (not self:GroupHasFlag(groupname, flags[i])) then
      return false
    end
  end

  return true
end

-- *******************************************
-- api.Call("flags", "GroupExists", groupname)
-- flags_plugin:GroupExists(groupname)
-- *******************************************
function PLUGIN:GroupExists(groupname)
  groupname = string.lower(self:TrimString(groupname))
  return self.FlagData.Groups[groupname] ~= nil
end

-- *******************************************
-- api.Call("flags", "ReloadFlags")
-- flags_plugin:ReloadFlags()
-- *******************************************
function PLUGIN:ReloadFlags()
  self.FlagsFile = util.GetDatafile("flags")
  local txt = self.FlagsFile:GetText()
  if (txt ~= "") then
    self.FlagData = json.decode(txt)
    if (not self.FlagData) then
      return false, "Error decoding Flags JSON text."
    end
    return true
  else
    return false
  end
end

-- *******************************************
-- HOOK FUNCTIONS
-- *******************************************
function PLUGIN:OnSave()
  self:SaveFlagData()
end

-- *******************************************
-- HELPER FUNCTIONS
-- *******************************************
function PLUGIN:UserExists(steamid)
  return self.FlagData.Users[steamid] ~= nil
end

function PLUGIN:SaveFlagData()
  self.FlagsFile:SetText(json.encode(self.FlagData))
  self.FlagsFile:Save()
end

function PLUGIN:GetUserData(steamid)
  if (not self:UserExists(steamid)) then
    self.FlagData.Users[steamid] = {}
    self.FlagData.Users[steamid].Name = ""
    self.FlagData.Users[steamid].SteamID = steamid
    self.FlagData.Users[steamid].Groups = {}
    self.FlagData.Users[steamid].Flags = {}
    self:SaveFlagData()
  end
  return self.FlagData.Users[steamid]
end

function PLUGIN:CleanUser(steamid)
  local userData = self.FlagData.Users[steamid]
  -- If user has no flags and is part of no groups, remove them
  if (#userData.Flags == 0 and #userData.Groups == 0) then
    self:DeleteUser(steamid)
  end
end

function PLUGIN:TrimString(str)
  return str:match'^%s*(.*%S)' or ''
end

function PLUGIN:CanRCON(netuser)
  --local steamID = rust.CommunityIDToSteamID(tonumber(rust.GetUserID(netuser)))
  --return (netuser:CanAdmin() or self:HasFlag(steamID, "rcon"))
  return netuser:CanAdmin()
end

-- Borrowed from http://lua-users.org/wiki/SplitJoin
local function split(str, pat)
  local t = {}  -- NOTE: use {n = 0} in Lua-5.0
  local fpat = "(.-)" .. pat
  local last_end = 1
  local s, e, cap = str:find(fpat, 1)
  while s do
    if s ~= 1 or cap ~= "" then
      table.insert(t,cap)
    end
    last_end = e+1
    s, e, cap = str:find(fpat, last_end)
  end
  if last_end <= #str then
    cap = str:sub(last_end)
    table.insert(t, cap)
  end
  return t
end

-- Based on code borrowed from manateebans
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

function PLUGIN:ConvertUserArgToSteamID(input)
  if (type(input) == "userdata") then
    local steamID = rust.CommunityIDToSteamID(tonumber(rust.GetUserID(input)))
    return SteamIDToSteam64(steamID)
  elseif (input:match("(STEAM_[0-9]:[0-9]:[0-9]+)")) then
    return SteamIDToSteam64(input)
  elseif (input:match("%a")) then
    return false, "Invalid input.  Input must be a netuser, userID, SteamID or Steam64."
  elseif (tonumber(input) > 76561197960265728) then
    return input
  else
    local steamID = rust.CommunityIDToSteamID(tonumber(input))
    return SteamIDToSteam64(steamID)
  end
end
