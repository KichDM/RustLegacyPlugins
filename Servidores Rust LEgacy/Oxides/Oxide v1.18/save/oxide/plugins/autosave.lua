PLUGIN.Title = "Auto-Save"
PLUGIN.Version = "0.1.3"
PLUGIN.Description = "Saves your server world and player data at configured time or on command."
PLUGIN.Author = "Luke Spragg - Wulfspider"
PLUGIN.Credits = "Zarkkos (original Server Autosave plugin)"
PLUGIN.Url = "http://forum.rustoxide.com/resources/463/"
PLUGIN.ConfigFile = "autosave"
PLUGIN.ResourceId = "463"

local debug = false -- Used to enable debug messages

-- Plugin initialization
function PLUGIN:Init()
    self:LoadConfiguration()
    self:SetupPermissions()
    print(self.Title .. " v" .. self.Version .. " loaded!")
end

-- Perform on server initialized
function PLUGIN:OnServerInitialized()
    -- Start save timer
    self.saveTimer = timer.Repeat(tonumber(self.Config.Settings.Time), function()
        -- Run server save command
        rust.RunServerCommand("save.all")
		rust.RunServerCommand("airdrop.drop")
		rust.RunServerCommand("airdrop.drop")
        -- Check if chat broadcast is enabled
        if (self.Config.Settings.Broadcast ~= "false") then
            -- Send save confirmation to all users via chat
            rust.BroadcastChat(self.Config.Settings.ChatName, self.Config.Messages.Saved)
        end
    end)
end

-- Server save chat command
function PLUGIN:cmdSave(netuser)
    -- Check if user has permission
    if (not self:PermissionsCheck(netuser)) then
        -- Send no permission message to user via notice
        rust.Notice(netuser, self.Config.Messages.NoPermission)
        return
    else
        -- Run server save command
        rust.RunServerCommand("save.all")
		rust.RunServerCommand("airdrop.drop")
		rust.RunServerCommand("airdrop.drop")
        -- Send save confirmation to user via notice
        rust.Notice(netuser, self.Config.Messages.Saved)
        -- Check if chat broadcast is enabled
        if (self.Config.Settings.Broadcast ~= "false") then
            -- Send save confirmation to all users via chat
            rust.BroadcastChat(self.Config.Settings.ChatName, self.Config.Messages.Saved)
        end
    end
end

-- Callable help text
function PLUGIN:SendHelpText(netuser)
    -- Check if user has permission
    if (self:PermissionsCheck(netuser)) then
        -- Send help text to user via chat
        rust.SendChatToUser(netuser, self.Config.Settings.HelpChatName, self.Config.Messages.HelpText)
    end
end

-- Plugin unload function
function PLUGIN:Unload()
    -- Destroy save timer
    if (self.saveTimer ~= nil) then
        self.saveTimer:Destroy()
        self.saveTimer = nil
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
    self.Config.Settings.HelpChatName = self.Config.Settings.HelpChatName or "Help"
    self.Config.Settings.Broadcast = self.Config.Settings.Broadcast or "true"
    self.Config.Settings.Time = self.Config.Settings.Time or self.Config.Time or self.Config.timer or "3600" -- Time in seconds

    -- Message strings
    self.Config.Messages = self.Config.Messages or {}
    self.Config.Messages.Saved = self.Config.Messages.Saved or "Server world and player data saved!"
    self.Config.Messages.HelpText = self.Config.Messages.HelpText or "Use /save to save the server world and player data"
    self.Config.Messages.NoPermission = self.Config.Messages.NoPermission or "You do not have permission to use this command!"

    -- Remove old settings
    self.Config.timer = nil -- Removed in 0.1.1
    self.Config.Time = nil -- Removed in 0.1.2

    -- Save configuration
    config.Save(self.ConfigFile, {
        indent = true,
        keyorder = {
            "Settings",
                "ChatName",
                "HelpChatName",
                "Broadcast",
                "Time",
            "Messages",
                "Saved",
                "HelpText",
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
    elseif ((self.oxmin ~= nil) and (self.oxmin:HasFlag(netuser, self.FLAG_CANSAVE))) then
        if (debug) then error(netuser.displayName .. " has Oxmin flag: cansave") end -- Debug message
        return true -- User has flag assigned
    -- Check if user has Flags plugin flag assigned
    elseif ((self.flags ~= nil) and (self.flags:HasFlag(netuser, "cansave"))) then
        if (debug) then error(netuser.displayName .. " has Flags flag: cansave") end -- Debug message
        return true -- User has flag assigned
    else
        return false -- User has no permission
    end
end

-- Setup plugin commands and flags
function PLUGIN:SetupPermissions()
    -- Find optional Oxmin plugin
    self.oxmin = plugins.Find("oxmin")
    if (self.oxmin) then
        -- Add Oxmin chat command
        self.FLAG_CANSAVE = oxmin.AddFlag("cansave")
        self.oxmin:AddExternalOxminChatCommand(self, "save", {self.FLAG_CANSAVE}, self.cmdSave)
    end

    -- Find optional Flags plugin
    self.flags = plugins.Find("flags")
    if (self.flags) then
        -- Add Flags chat command
        self.flags:AddFlagsChatCommand(self, "save", {"cansave"}, self.cmdSave)
    end

    -- Add default chat command
    self:AddChatCommand("save", self.cmdSave)
end
