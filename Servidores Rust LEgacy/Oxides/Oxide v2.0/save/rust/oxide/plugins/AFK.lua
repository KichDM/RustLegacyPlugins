PLUGIN.Title = "AFK Kick"
PLUGIN.Version = V(0, 1, 8)
PLUGIN.Description = "Kicks players that are AFK (away from keyboard) for too long."
PLUGIN.Author = "Wulfspider"
PLUGIN.Url = "http://oxidemod.org/plugins/766/"
PLUGIN.ResourceId = 766

local debug = false

local afkTimer = {}

function PLUGIN:LoadDefaultConfig()
    self.Config.Settings = self.Config.Settings or {}
    self.Config.Settings.AfkTimeLimit = tonumber(self.Config.Settings.AfkTimeLimit) or self.Config.Settings.AfkLimit or 300 -- 5 minutes
    self.Config.Settings.BroadcastChat = self.Config.Settings.BroadcastChat or "true"

    self.Config.Messages = self.Config.Messages or {}
    self.Config.Messages.PlayerKicked = self.Config.Messages.PlayerKicked or "{player} was kicked for being AFK!"
    self.Config.Messages.YouKicked = self.Config.Messages.YouKicked or "You were kicked for being AFK for {afklimit} seconds!"

    self.Config.Settings.AfkLimit = nil -- Removed in 0.1.7

    self:SaveConfig()
end

local function Print(self, message) print(self.Title .. " > " .. message) end

local function HasPermission(steamId)
    if permission.UserHasPermission(steamId, "afkkick.bypass") then return true end
    return false
end

function PLUGIN:Init()
    self:LoadDefaultConfig()
    permission.RegisterPermission("afkkick.bypass", self.Plugin)
end

function PLUGIN:CheckPosition(player)
    local steamId = rust.UserIDFromPlayer(player)
    local start = player.playerClient.lastKnownPosition
    afkTimer[steamId] = timer.Repeat(self.Config.Settings.AfkTimeLimit, 0, function()
        local current = player.playerClient.lastKnownPosition
        if debug then
            Print(self, "Start position of " .. steamId .. ": " .. tostring(start))
            Print(self, "Current position of " .. steamId .. ": " .. tostring(current))
        end
        if start.x == current.x and start.y == current.y and start.z == current.z then
            local message = self.Config.Messages.YouKicked:gsub("{afklimit}", self.Config.Settings.AfkTimeLimit)
            rust.Notice(player, message, "🕒", 30)
            player:Kick(global.NetError.Facepunch_Kick_RCON, true)
            local message = self.Config.Messages.PlayerKicked:gsub("{player}", player.displayName)
            Print(self, message)
            if self.Config.Settings.Broadcast == "true" then rust.BroadcastChat(message) end
        end
        start = current
    end, self.Plugin)
end

function PLUGIN:OnPlayerSpawn(playerClient)
    if not playerClient then return end
    local player = playerClient.netUser
    local steamId = rust.UserIDFromPlayer(player)
    if HasPermission(steamId) then return end
    self:CheckPosition(player)
end

function PLUGIN:OnPlayerDisconnected(player)
    local player = player:GetLocalData()
    if not player then return end
    local steamId = rust.UserIDFromPlayer(player)
    if afkTimer[steamId] then afkTimer[steamId]:Destroy() end
end
