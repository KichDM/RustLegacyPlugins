PLUGIN.Title = "Reload"
PLUGIN.Version = "0.1.0"
PLUGIN.Description = "Easy plugin reloading on command, with permissions."
PLUGIN.Author = "Luke Spragg - Wulfspider"
PLUGIN.Url = "http://forum.rustoxide.com/resources/546/"
PLUGIN.ConfigFile = "reload"
PLUGIN.ResourceId = "546"

-- Plugin initialization
function PLUGIN:Init()
    self:LoadConfiguration()
    self:SetupPermissions()
    print(self.Title .. " v" .. self.Version .. " loaded!")
end

-- Reload chat command
function PLUGIN:cmdReload(netuser, cmd, arg)
    local plugin = arg[1]

    -- Check if user has permission
    if (not self:PermissionsCheck(netuser)) then
        -- Send no permission message to user via notice
        rust.Notice(netuser, self.Config.Messages.NoPermission)
        return
    else
        -- Check if plugin exists
        if (not plugins.Find(plugin)) then
            -- Check if chat messages are enabled
            if (self.Config.Settings.ChatEnabled ~= "false") then
                -- Send invalid message to user via chat
                rust.SendChatToUser(netuser, self.Config.Settings.ChatName, string.upper(plugin) .. " " .. self.Config.Messages.Invalid)
            end
            -- Check if notice messages are enabled
            if (self.Config.Settings.NoticeEnabled ~= "false") then
                -- Send invalid message to user via notice
                rust.Notice(netuser, string.upper(plugin) .. " " .. self.Config.Messages.Invalid)
            end
        else
            -- Run server command to reload
            rust.RunServerCommand("oxide.reload " .. plugin)
            -- Check if chat messages are enabled
            if (self.Config.Settings.ChatEnabled ~= "false") then
                -- Send reloaded message to user via chat
                rust.SendChatToUser(netuser, self.Config.Settings.ChatName, string.upper(plugin) .. " " .. self.Config.Messages.Reloaded)
            end
            -- Check if notice messages are enabled
            if (self.Config.Settings.NoticeEnabled ~= "false") then
                -- Send reloaded message to user via notice
                rust.Notice(netuser, string.upper(plugin) .. " " .. self.Config.Messages.Reloaded)
            end
        end
    end
end

-- Load the configuration
function PLUGIN:LoadConfiguration()
    -- Read/create configuration file
    local b, res = config.Read(self.ConfigFile)
    self.Config = res or {}

    -- General settings
    self.Config.Settings = self.Config.Settings or {}
    self.Config.Settings.ChatName = self.Config.Settings.ChatName or "Server"
    self.Config.Settings.ChatCommand = self.Config.Settings.ChatCommand or "reload"
    self.Config.Settings.ChatEnabled = self.Config.Settings.ChatEnabled or "true"
    self.Config.Settings.NoticeEnabled = self.Config.Settings.NoticeEnabled or "true"

    -- Message strings
    self.Config.Messages = self.Config.Messages or {}
    self.Config.Messages.Reloaded = self.Config.Messages.Reloaded or "plugin has been reloaded!"
    self.Config.Messages.Invalid = self.Config.Messages.Invalid or "is not a valid plugin! Please check the spelling and try again."
    self.Config.Messages.NoPermission = self.Config.Messages.NoPermission or "You do not have permission to use this command!"

    -- Save configuration
    config.Save(self.ConfigFile, {
        indent = true,
        keyorder = {
            "Settings",
                "ChatName",
                "ChatCommand",
                "ChatEnabled",
                "NoticeEnabled",
            "Messages",
                "Reloaded",
                "Invalid",
                "NoPermission"
        }
    })
end

-- Check for permissions to use commands
function PLUGIN:PermissionsCheck(netuser)
    -- Check if user is RCON admin
    if (netuser:CanAdmin()) then
        if (debug) then error(netuser.displayName .. " is RCON admin") end -- Debug message
        return true -- User is RCON admin
    -- Check if user has Oxmin plugin flag assigned
    elseif ((self.oxmin ~= nil) and (self.oxmin:HasFlag(netuser, self.FLAG_CANRELOAD))) then
        if (debug) then error(netuser.displayName .. " has Oxmin flag: canreload") end -- Debug message
        return true -- User has flag assigned
    -- Check if user has Flags plugin flag assigned
    elseif ((self.flags ~= nil) and (self.flags:HasFlag(netuser, "canreload"))) then
        if (debug) then error(netuser.displayName .. " has Flags flag: canreload") end -- Debug message
        return true -- User has flag assigned
    else
        return false -- User has no permission
    end
end

-- Setup plugin permissions/flags
function PLUGIN:SetupPermissions()
    -- Find optional Oxmin plugin
    self.oxmin = plugins.Find("oxmin")
    -- Check if Oxmin is installed
    if (self.oxmin) then
        -- Add Oxmin plugin command
        self.FLAG_CANRELOAD = oxmin.AddFlag("canreload")
        self.oxmin:AddExternalOxminChatCommand(self, self.Config.Settings.ChatCommand, {self.FLAG_CANRELOAD}, self.cmdReload)
    end

    -- Find optional Flags plugin
    self.flags = plugins.Find("flags")
    -- Check if Flags is installed
    if (self.flags) then
        -- Add Flags plugin command
        self.flags:AddFlagsChatCommand(self, self.Config.Settings.ChatCommand, {"canreload"}, self.cmdReload)
    end

    -- Add default chat command
    self:AddChatCommand(self.Config.Settings.ChatCommand, self.cmdReload)
end
