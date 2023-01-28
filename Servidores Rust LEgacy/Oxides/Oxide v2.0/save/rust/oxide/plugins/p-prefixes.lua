PLUGIN.Title = "PaiN Prefix"
PLUGIN.Description = "Simple Prefix system."
PLUGIN.Author = "PaiN"
PLUGIN.Version = V(0, 7, 5)
PLUGIN.ResourceId = 1115

function PLUGIN:LoadDefaultConfig()
self.Config.VipSettings = self.Config.VipSettings or {}
self.Config.VipSettings.Permission = self.Config.VipSettings.Permission or "vipprefix"
self.Config.VipSettings.Prefix = self.Config.VipSettings.Prefix or "[VIP]"
self.Config.VipSettings.TextColor = self.Config.VipSettings.TextColor or "[color green]"
self.Config.AdminSettings = self.Config.AdminSettings or {}
self.Config.AdminSettings.Permission = self.Config.AdminSettings.Permission or "adminprefix"
self.Config.AdminSettings.Prefix = self.Config.AdminSettings.Prefix or "[ADMIN]"
self.Config.AdminSettings.TextColor = self.Config.AdminSettings.TextColor or "[color red]"
self.Config.ModSettings = self.Config.ModSettings or {}
self.Config.ModSettings.Permission = self.Config.ModSettings.Permission or "modprefix"
self.Config.ModSettings.Prefix = self.Config.ModSettings.Prefix or "[MOD]"
self.Config.ModSettings.TextColor = self.Config.ModSettings.TextColor or "[color yellow]"
self.Config.Custom1Settings = self.Config.Custom1Settings or {}
self.Config.Custom1Settings.Permission = self.Config.Custom1Settings.Permission or "custom1prefix"
self.Config.Custom1Settings.Prefix = self.Config.Custom1Settings.Prefix or "[CUSTOM1]"
self.Config.Custom1Settings.TextColor = self.Config.Custom1Settings.TextColor or "[color blue]"
self.Config.Custom2Settings = self.Config.Custom2Settings or {}
self.Config.Custom2Settings.Permission = self.Config.Custom2Settings.Permission or "custom2prefix"
self.Config.Custom2Settings.Prefix = self.Config.Custom2Settings.Prefix or "[CUSTOM2]"
self.Config.Custom2Settings.TextColor = self.Config.Custom2Settings.TextColor or "[color orange]"
self:SaveConfig()
end

function PLUGIN:Init()
    self:LoadDefaultConfig()
    permission.RegisterPermission(self.Config.VipSettings.Permission, self.Plugin)
	permission.RegisterPermission(self.Config.AdminSettings.Permission, self.Plugin)
	permission.RegisterPermission(self.Config.ModSettings.Permission, self.Plugin)
	permission.RegisterPermission(self.Config.Custom1Settings.Permission, self.Plugin)
	permission.RegisterPermission(self.Config.Custom2Settings.Permission, self.Plugin)
end

function PLUGIN:OnPlayerChat(netuser, message)
    if message:sub(1, 1) == "/" then return end
	local steamId = rust.UserIDFromPlayer(netuser)
if permission.UserHasPermission(steamId, self.Config.VipSettings.Permission) then
rust.BroadcastChat(self.Config.VipSettings.Prefix .. " " .. netuser.displayName, self.Config.VipSettings.TextColor .. message)
print(self.Config.VipSettings.Prefix .. " " .. netuser.displayName .. ": " .. message)
elseif permission.UserHasPermission(steamId, self.Config.AdminSettings.Permission) then
rust.BroadcastChat(self.Config.AdminSettings.Prefix .. " " .. netuser.displayName, self.Config.AdminSettings.TextColor .. message)
print(self.Config.AdminSettings.Prefix .. " " .. netuser.displayName .. ": " .. message)
elseif permission.UserHasPermission(steamId, self.Config.ModSettings.Permission) then
rust.BroadcastChat(self.Config.ModSettings.Prefix .. " " .. netuser.displayName, self.Config.ModSettings.TextColor .. message)
print(self.Config.ModSettings.Prefix .. " " .. netuser.displayName .. ": " .. message)
elseif permission.UserHasPermission(steamId, self.Config.Custom1Settings.Permission) then
rust.BroadcastChat(self.Config.Custom1Settings.Prefix .. " " .. netuser.displayName, self.Config.Custom1Settings.TextColor .. message)
print(self.Config.Custom1Settings.Prefix .. " " .. netuser.displayName .. ": " .. message)
elseif permission.UserHasPermission(steamId, self.Config.Custom2Settings.Permission) then
rust.BroadcastChat(self.Config.Custom2Settings.Prefix .. " " .. netuser.displayName, self.Config.Custom2Settings.TextColor .. message)
print(self.Config.Custom2Settings.Prefix .. " " .. netuser.displayName .. ": " .. message)
else
rust.BroadcastChat(netuser.displayName, message)
print(netuser.displayName .. ": " .. message)
	end
	return false
end