PLUGIN.Title = "CustomChatCommands"
PLUGIN.Author = "#Domestos"
PLUGIN.Version = "1.1"
PLUGIN.Description = "Set completely custom chat commands"
PLUGIN.ResourceId = "559"
PLUGIN.ConfigFile = "customchatcommands"

-- Debug mode
local debug = false
-- ----------------

function PLUGIN:Init()
    self:LoadConfig()
    for key, value in pairs(self.Config.ChatCommands) do
        self:AddChatCommand(key, self.cmdChatCmd)
    end
    print(self.Title .. " v" .. self.Version .. " loaded")
end

function PLUGIN:LoadConfig()
    local b, res = config.Read(self.ConfigFile)
    self.Config = res or {}
    -- Config settings
    self.Config.Settings = self.Config.Settings or {}
    self.Config.Settings.ChatName = self.Config.Settings.ChatName or "SERVER"
    self.Config.ChatCommands = self.Config.ChatCommands or {
        ["command1"] = {
            ["text"] = {"This is an example text"},
            ["helptext"] = "This is the helptext for this command",
            ["admin"] = false
        },
        ["command2"] = {
            ["text"] = {"This is an example text for admins only", "You can also use multiline messages"},
            ["helptext"] = "This is the helptext for this command, also admin only",
            ["admin"] = true
        }
    }
    -- Save config file
    config.Save(self.ConfigFile, {
        indent = true,
        keyorder = {
            "Settings",
                "ChatName",
            "ChatCommands"
        }
    })
end

function PLUGIN:PostInit()
    self:LoadFlags()
end

-- Flag Handling
function PLUGIN:LoadFlags()
    self.flagsPlugin = plugins.Find("flags")
    self.oxminPlugin = plugins.Find("oxmin")
    if(self.oxminPlugin) then
        self.FLAG_CCC = oxmin.AddFlag("customchatcommands")
    end
end

function PLUGIN:HasPermission(netuser)
    if(netuser:CanAdmin()) then
        return true
    elseif((self.oxminPlugin ~= nil) and (self.oxminPlugin:HasFlag(netuser, self.FLAG_CCC))) then
        return true
    elseif((self.flagsPlugin ~= nil) and (self.flagsPlugin:HasFlag(netuser, "customchatcommands"))) then
        return true
    else
        return false
    end
end

function PLUGIN:cmdChatCmd(netuser, cmd)
    for key, value in pairs(self.Config.ChatCommands) do
        if(cmd == key) then
            -- Check if command is admin only
            if(self.Config.ChatCommands[key].admin == true) then
                -- Check if user has permission to use command
                if(self:HasPermission(netuser) == true) then
                    -- Output the text
                    for k, v in pairs(self.Config.ChatCommands[key].text) do
                        rust.SendChatToUser(netuser, self.Config.Settings.ChatName, self.Config.ChatCommands[key].text[k])
                    end
                end
            else
                -- Command can be used by everyone
                for k, v in pairs(self.Config.ChatCommands[key].text) do
                    rust.SendChatToUser(netuser, self.Config.Settings.ChatName, self.Config.ChatCommands[key].text[k])
                end
            end
        end
    end
end

function PLUGIN:SendHelpText(netuser)
    for key, value in pairs(self.Config.ChatCommands) do
        if(self.Config.ChatCommands[key].admin == true) then
            if(self:HasPermission(netuser) == true) then
                rust.SendChatToUser(netuser, self.Config.ChatCommands[key].helptext)
            end
        else
            rust.SendChatToUser(netuser, self.Config.ChatCommands[key].helptext)
        end
    end
end