PLUGIN.Title = "Shutdown"
PLUGIN.Version = "0.1.7"
PLUGIN.Description = "Notifies players, saves, and shuts down the server on command."
PLUGIN.Author = "Luke Spragg - Wulfspider"
PLUGIN.Url = "http://forum.rustoxide.com/resources/338/"
PLUGIN.ConfigFile = "shutdown"
PLUGIN.ResourceId = "338"

local debug = false -- Used to enable debug messages

-- Plugin initialization
function PLUGIN:Init()
    self:LoadConfiguration()
    self:SetupPermissions()
    print(self.Title .. " v" .. self.Version .. " loaded!")
end

-- Shutdown chat command
function PLUGIN:cmdShutdown(netuser, cmd, arg)
    -- Check if user has permission
    if (not self:PermissionsCheck(netuser)) then
        -- Notify user of no permission
        rust.Notice(netuser, self.Config.Messages.NoPermission)
        return
    else
        local action = tostring(arg[1])
        local minutes = tonumber(arg[1])

        -- Check for/destroy existing timer
        self:Destroy()

        -- Display proper command usage
        if (not action) then
            rust.Notice(netuser, self.Config.Messages.HelpText)
        -- Immediate shutdown
        elseif (action == "now") then
            self:SaveShutdown()
        -- Check for shutdown cancellation
        elseif (action == "cancel" or action == "stop") then
            -- Check for/destroy existing timer
            self:Destroy()
            -- Notify users of shutdown cancellation
            self:SendNotice(action)
        -- Timed shutdown
        elseif (minutes ~= nil) then
            -- Confirm shutdown started
            self:SendNotice(minutes)
            -- Countdown
            self:Countdown(netuser, minutes)
        end
    end
end

-- Shutdown console command
function PLUGIN:ccmdShutdown(arg)
    local netuser = arg.argUser
    local action = tostring(arg:GetString(0, "text"))
    local minutes = tonumber(arg:GetString(0, "text"))
    -- Check if time unit should be plural
    if (minutes == 1) then
        self.unit = self.Config.Messages.Units.Minute
    else
        self.unit = self.Config.Messages.Units.Minutes
    end

    -- Check if user has permission
    if (netuser and not netuser:CanAdmin()) then
         arg:ReplyWith(self.Config.Messages.NoPermission)
        return true -- Fixes "Command not found"
    else
        -- Check for/destroy existing timer
        self:Destroy()

        -- Display proper command usage
        if (not action) then
            arg:ReplyWith(self.Config.Messages.HelpText)
        -- Immediate shutdown
        elseif (action == "now") then
            self:SaveShutdown()
        -- Check for shutdown cancellation
        elseif (action == "cancel" or action == "stop") then
            -- Check for/destroy timer
            self:Destroy()
            -- Notify users of shutdown cancellation
            self:SendNotice(action)
        -- Timed shutdown
        elseif (minutes ~= nil) then
            -- Confirm shutdown started
            self:SendNotice(minutes)
            -- Countdown
            self:Countdown(netuser, minutes)
        end
    end
    return true -- Fixes "Command not found"
end

-- Notice countdown
function PLUGIN:Countdown(netuser, minutes)
    local i = 0
    self.Timer = timer.Repeat(60, minutes, function()
        i = i + 1
        -- Only send message of minutes left
        if (minutes ~= i) then
            -- Notify all users of shutdown
            self:SendNotice(minutes-i)
        -- Time is up!
        else
            -- Notify all users of shutdown
            self:SendNotice(nil)

            -- Trigger save and shutdown
            self:SaveShutdown()
        end
    end)
end

-- Timer check/destroy
function PLUGIN:Destroy()
    -- Check for existing timer
    if (self.Timer) then
        -- Destroy existing timer
        self.Timer:Destroy()
        self.Timer = nil
    end
end

-- Send notices to players
function PLUGIN:SendNotice(arg)
    local chatname = self.Config.Settings.ChatName
    local action = tostring(arg)
    local minutes = tonumber(arg)
    -- Check if time unit should be plural
    if (minutes == 1) then
        self.unit = self.Config.Messages.Units.Minute
    else
        self.unit = self.Config.Messages.Units.Minutes
    end

    -- Check for shutdown cancellation
    if (action == "cancel" or action == "stop") then
        --- Check if chat messages are enabled
        if (self.Config.Settings.ChatEnabled ~= "false") then
            -- Broadcast shutdown cancellation to chat
            rust.BroadcastChat(chatname, self.Config.Messages.ShutdownCancelled)
        end

        --- Check if notices are enabled
        if (self.Config.Settings.NoticeEnabled ~= "false") then
            -- Notify all users of shutdown cancellation
            local netusers = rust.GetAllNetUsers()
            for key, netuser in pairs(netusers) do
                rust.Notice(netuser, self.Config.Messages.ShutdownCancelled)
            end
        end

        -- Print shutdown cancellation to server console
        print(self.Config.Messages.ShutdownCancelled)
    else
        --- Check if chat messages are enabled
        if (self.Config.Settings.ChatEnabled ~= "false") then
            -- Broadcast shutdown to chat
            if (minutes ~= nil) then
                rust.BroadcastChat(chatname, self.Config.Messages.ShutdownIn .. " " .. tostring(minutes) .. " " .. self.unit .. "!")
            else
                rust.BroadcastChat(chatname, self.Config.Messages.ShutdownNow)
            end
        end

        --- Check if notices are enabled
        if (self.Config.Settings.NoticeEnabled ~= "false") then
            -- Notify all users of shutdown
            local netusers = rust.GetAllNetUsers()
            for key, netuser in pairs(netusers) do
                if (minutes ~= nil) then
                    rust.Notice(netuser, self.Config.Messages.ShutdownIn .. " " .. tostring(minutes) .. " " .. self.unit .. "!")
                else
                    rust.Notice(netuser, self.Config.Messages.ShutdownNow)
                end
            end
        end

        -- Print shutdown to server console
        if (minutes ~= nil) then
            print(self.Config.Messages.ShutdownIn .. " " .. tostring(minutes) .. " " .. self.unit .. "!")
        else
            print(self.Config.Messages.ShutdownNow)
        end
    end
end

-- Save and shutdown command
function PLUGIN:SaveShutdown()
    -- Save world map and player inventory
    print("Saving world map and player inventory...")
    rust.RunServerCommand("save.all")

    -- Issue server shutdown command
    print("Shutting down server...")
    rust.RunServerCommand("quit")
end

-- Callable help text
function PLUGIN:SendHelpText(netuser)
    -- Check if user has permission
    if (self:PermissionsCheck(netuser)) then
        -- Send help text to user via chat
        rust.SendChatToUser(netuser, self.Config.Settings.HelpChatName, self.Config.Messages.HelpText)
    end
end

-- Load the configuration
function PLUGIN:LoadConfiguration()
    -- Read/create configuration file
    local b, res = config.Read(self.ConfigFile)
    self.Config = res or {}

    -- General settings
    self.Config.Settings = self.Config.Settings or {}
    self.Config.Settings.ChatName = self.Config.Settings.ChatName or "WARNING"
    self.Config.Settings.HelpChatName = self.Config.Settings.HelpChatName or "Help"
    self.Config.Settings.ChatEnabled = self.Config.Settings.ChatEnabled or "true"
    self.Config.Settings.NoticeEnabled = self.Config.Settings.NoticeEnabled or self.Config.Settings.NoticesEnabled or "true"

    -- Message strings
    self.Config.Messages = self.Config.Messages or {}
    self.Config.Messages.HelpText =  self.Config.Messages.HelpText or "Use /shutdown # to shutdown the server, now for instant, or cancel to stop."
    self.Config.Messages.ShutdownCancelled = self.Config.Messages.ShutdownCancelled or "Server shutdown has been cancelled!"
    self.Config.Messages.ShutdownNow = self.Config.Messages.ShutdownNow or "Server is shutting down!"
    self.Config.Messages.ShutdownIn = self.Config.Messages.ShutdownIn or "Server is shutting down in"
    self.Config.Messages.NoPermission = self.Config.Messages.NoPermission or "You do not have permission to use this command!"
    self.Config.Messages.Units = self.Config.Messages.Units or {}
    self.Config.Messages.Units.Hour = self.Config.Messages.Units.Hour or "hour"
    self.Config.Messages.Units.Hours = self.Config.Messages.Units.Hours or "hours"
    self.Config.Messages.Units.Minute = self.Config.Messages.Units.Minute or "minute"
    self.Config.Messages.Units.Minutes = self.Config.Messages.Units.Minutes or "minutes"
    self.Config.Messages.Units.Second = self.Config.Messages.Units.Second or "second"
    self.Config.Messages.Units.Seconds = self.Config.Messages.Units.Seconds or "seconds"

    -- Remove old settings
    self.Config.ConfigVersion = nil -- Removed in 0.1.3
    self.Config.Settings.NoticesEnabled = nil -- Removed in 0.1.6

    -- Save configuration
    config.Save(self.ConfigFile)
end

-- Check for permissions to use commands
function PLUGIN:PermissionsCheck(netuser)
    -- Debug messages
    if (debug) then
        error("Can admin " .. netuser.displayName .. ": " .. tostring(netuser:CanAdmin()))
        error("Oxmin " .. netuser.displayName .. " canshutdown: " .. tostring(self.oxmin:HasFlag(netuser, self.FLAG_CANSHUTDOWN)))
        error("Flags " .. netuser.displayName .. " canshutdown: " .. tostring(self.flags:HasFlag(netuser, "canshutdown")))
    end

    -- Check if user is RCON admin
    if (netuser:CanAdmin()) then
        return true -- User is RCON admin
    -- Check if user has Oxmin plugin flag assigned
    elseif ((self.oxmin ~= nil) and (self.oxmin:HasFlag(netuser, self.FLAG_CANSHUTDOWN))) then
        return true -- User has flag assigned
    -- Check if user has Flags plugin flag assigned
    elseif ((self.flags ~= nil) and (self.flags:HasFlag(netuser, "canshutdown"))) then
        return true -- User has flag assigned
    else
        return false -- User has no permission
    end
end

-- Setup plugin commands and flags
function PLUGIN:SetupPermissions()
    -- Find optional Oxmin plugin
    self.oxmin = plugins.Find("oxmin")
    -- Check if Oxmin is installed
    if (self.oxmin) then
        -- Add Oxmin plugin flag and commands
        self.FLAG_CANSHUTDOWN = oxmin.AddFlag("canshutdown")
        self.oxmin:AddExternalOxminChatCommand(self, "shutdown", {self.FLAG_CANSHUTDOWN}, self.cmdShutdown)
        self.oxmin:AddExternalOxminChatCommand(self, "restart", {self.FLAG_CANSHUTDOWN}, self.cmdShutdown)
    end

    -- Find optional Flags plugin
    self.flags = plugins.Find("flags")
    -- Check if Flags is installed
    if (self.flags) then
        -- Add Flags plugin flag and commands
        self.flags:AddFlagsChatCommand(self, "shutdown", {"canshutdown"}, self.cmdShutdown)
        self.flags:AddFlagsChatCommand(self, "restart", {"canshutdown"}, self.cmdShutdown)
    end

    -- Add default chat commands
    self:AddChatCommand("shutdown", self.cmdShutdown)
    self:AddChatCommand("restart", self.cmdShutdown)

    -- Add default console commands
    self:AddCommand("server", "shutdown", self.ccmdShutdown)
    self:AddCommand("server", "restart", self.ccmdShutdown)
end
