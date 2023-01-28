PLUGIN.Title = "Auto Admin"
PLUGIN.Description = "Auto Login for Admins"
PLUGIN.Version = "0.1.6.1"
PLUGIN.Author = "greyhawk"

local godmode = false
local permaDay = false

function PLUGIN:Init()

    flags_plugin = plugins.Find("flags")
    if (not flags_plugin) then
        print("You do not have the Flags plugin installed! Check here: http://forum.rustoxide.com/resources/flags.155/")
    end


	self.DataFile = util.GetDatafile( "admins" )
	local txt = self.DataFile:GetText()
	if (txt ~= "") then
		self.Data = json.decode( txt )
	else
		self.Data = {}
	end
    
	
    if (not flags_plugin) then
        self:AddChatCommand("promote", self.cmdPromote)
        self:AddChatCommand("demote", self.cmdDemote)
    else
        flags_plugin:AddFlagsChatCommand(self, "promote", {"superadmin"}, self.cmdPromote)
        flags_plugin:AddFlagsChatCommand(self, "demote", {"superadmin"}, self.cmdDemote)
    end
end

function PLUGIN:flagged(netuser, flag)
    return ( (netuser:CanAdmin())
          or ( flags_plugin and flags_plugin:HasFlag(rust.GetUserID(netuser), flag) ) )
end

function PLUGIN:cmdDemote( netuser, cmd, args )
    if (not(args[1])) then
        return
    end
    if (not(self:flagged(netuser, "superadmin"))) then
        rust.Notice( netuser, "You're not admin!" )
        return
    end
    
    local b, targetuser = rust.FindNetUsersByName( args[1] )
    if (not b) then
        if (targetuser == 0) then
            rust.Notice( netuser, "No players found with that name!" )
        else
            rust.Notice( netuser, "Multiple players found with that name!" )
        end
        return
    end
    
    local data = self:GetUserData( targetuser )
    self.Data[data.ID].isAdmin = false
    targetuser:SetAdmin(false)
    self:Save()
    rust.Notice( targetuser, "You have been demoted!" )
    rust.SendChatToUser( netuser, "You have demoted " .. util.QuoteSafe(targetuser.displayName) )
end

function PLUGIN:cmdPromote( netuser, cmd, args )
    if (not(args[1])) then
        return
    end
    if (not(self:flagged(netuser, "superadmin"))) then
        rust.Notice( netuser, "You're not admin!" )
        return
    end
    
    local b, targetuser = rust.FindNetUsersByName( args[1] )
    if (not b) then
        if (targetuser == 0) then
            rust.Notice( netuser, "No players found with that name!" )
        else
            rust.Notice( netuser, "Multiple players found with that name!" )
        end
        return
    end
    
    local data = self:GetUserData( targetuser )
    self.Data[data.ID].isAdmin = true
    targetuser:SetAdmin(true)
    self:Save()
    rust.Notice( targetuser, "You have been promoted!" )
    rust.SendChatToUser( netuser, "You have promoted " .. util.QuoteSafe(targetuser.displayName) )
end

function PLUGIN:OnUserConnect( netuser )
    local data = self:GetUserData( netuser )
    if (data.isAdmin) then
        netuser:SetAdmin(true)
        rust.Notice( netuser, "You are admin!" )
    end
end

function PLUGIN:invis(netuser)
    rust.RunServerCommand("env.timescale 0" )
    rust.RunServerCommand("env.time 12" )
    rust.RunServerCommand("crafting.instant true" )
    rust.RunServerCommand("dmg.godmode true" )
    rust.RunServerCommand("falldamage.enabled false" )
    local helmet = rust.GetDatablockByName( "Invisible Helmet" )
    local vest = rust.GetDatablockByName( "Invisible Vest" )
    local pants = rust.GetDatablockByName( "Invisible Pants" )
    local boots = rust.GetDatablockByName( "Invisible Boots" )
    local pref = rust.InventorySlotPreference( InventorySlotKind.Armor, false, InventorySlotKindFlags.Armor )
    local inv = netuser.playerClient.rootControllable.idMain:GetComponent( "Inventory" )
    local invitem1 = inv:AddItemAmount( helmet, 1, pref )
    local invitem2 = inv:AddItemAmount( vest, 1, pref )
    local invitem3 = inv:AddItemAmount( pants, 1, pref )
    local invitem4 = inv:AddItemAmount( boots, 1, pref )
end

function PLUGIN:SendHelpText( netuser )
    if (self:flagged(netuser, "superadmin")) then
        rust.SendChatToUser( netuser, "Use /promote name to add someone to the auto-admin list" )
        rust.SendChatToUser( netuser, "Use /demote name to remove someone from the auto-admin list" )
    end
end

function PLUGIN:Save()
	self.DataFile:SetText( json.encode( self.Data ) )
	self.DataFile:Save()
end

function PLUGIN:GetUserData( netuser )
	local userID = rust.GetUserID( netuser )
	return self:GetUserDataFromID( userID, netuser.displayName )
end

function PLUGIN:GetUserDataFromID( userID, name )
	local userentry = self.Data[ userID ]
	if (not userentry) then
		userentry = {}
		userentry.ID = userID
		userentry.Name = name
        userentry.isAdmin = false
		self.Data[ userID ] = userentry
        self:Save()
	end
	return userentry
end