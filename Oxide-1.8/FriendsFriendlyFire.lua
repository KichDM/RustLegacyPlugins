PLUGIN.Title = "Friends Friendly Fire"
PLUGIN.Author = "#Domestos"
PLUGIN.Version = "0.2"
PLUGIN.Description = "Activates or deactivates friendly fire on friends"
PLUGIN.ResourceId = "477"
PLUGIN.ConfigFile = "FriendsFF"



function PLUGIN:Init()
    if(not api.Exists("friends")) then
        print(self.Title..": plugin not loaded. Friends plugin is missing!")
        return
    end
    self:AddChatCommand("fff", self.cmdSetConfig)
    self:LoadConfig()
    print(self.Title.." v"..self.Version.." loaded.")
end

function PLUGIN:PostInit()
    self.friendsApi = plugins.Find("friends")
end

function PLUGIN:LoadConfig()
    local b, res = config.Read(self.ConfigFile)
    self.Config = res or {}
    self.Config.friendlyFire = self.Config.friendlyFire or "false"
    config.Save(self.ConfigFile)
end

typesystem.LoadEnum(Rust.DamageTypeFlags, "DamageType")
function PLUGIN:ModifyDamage(takedamage, damage)
    if(self.Config.friendlyFire == true or self.Config.friendlyFire == nil) then
        return damage
    else
        local dmgtype = tostring(damage.damageTypes)
        if(dmgtype == tostring(DamageType.damage_bullet) or dmgtype == tostring(DamageType.damage_explosion) or dmgtype == tostring(DamageType.damage_melee)) then
            if(damage.attacker ~= nil and damage.victim ~= nil) then
                if(damage.attacker.client ~= nil and damage.victim.client ~= nil) then
                    if(damage.attacker.client.netUser ~= nil and damage.victim.client.netUser ~= nil) then
                        local victim = damage.victim.client.netUser
                        local attacker = damage.attacker.client.netUser
                        local areFriends = self.friendsApi:areFriends(attacker, victim.displayName)
                        if(areFriends == true) then
                            rust.Notice(attacker, victim.displayName.." is your friend. You cant dmg him")
                            damage.amount = 0
                            damage.status = LifeStatus.IsAlive
                            return damage
                        end
                    end
                end
            end
        end
    end
end

function PLUGIN:cmdSetConfig(netuser)
    if(netuser:CanAdmin() == true) then
        if(self.Config.friendlyFire == false) then
            self.Config.friendlyFire = true
        elseif(self.Config.friendlyFire == true) then
            self.Config.friendlyFire = false
        end
        config.Save(self.ConfigFile)
        rust.Notice(netuser, "friendly fire set to "..tostring(self.Config.friendlyFire))
    else
        rust.SendChatToUser(netuser, "You need to be admin to use this command")
    end
end