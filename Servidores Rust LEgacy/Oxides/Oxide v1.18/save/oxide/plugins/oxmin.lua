--[[ **************** ]]--
--[[ oxmin - thomasfn ]]--
--[[ **************** ]]--


-- Define plugin variables
PLUGIN.Title = "Oxmin"
PLUGIN.Description = "Administration mod"
PLUGIN.Author = "thomasfn"
PLUGIN.Version = "1.5"

-- Load oxmin module
if (not oxmin) then
	oxmin = {}
	oxmin.flagtostr = {}
	oxmin.strtoflag = {}
	oxmin.nextflagid = 1
end
function oxmin.AddFlag( name )
	if (oxmin.strtoflag[ name ]) then return oxmin.strtoflag[ name ] end
	local id = oxmin.nextflagid
	oxmin.flagtostr[ id ] = name
	oxmin.strtoflag[ name ] = id
	oxmin.nextflagid = oxmin.nextflagid + 1
	return id
end

-- Add all default flags
local FLAG_ALL = oxmin.AddFlag( "all" )
local FLAG_BANNED = oxmin.AddFlag( "banned" )
local FLAG_CANKICK = oxmin.AddFlag( "cankick" )
local FLAG_CANBAN = oxmin.AddFlag( "canban" )
local FLAG_CANUNBAN = oxmin.AddFlag( "canunban" )
local FLAG_CANTELEPORT = oxmin.AddFlag( "canteleport" )
local FLAG_CANGIVE = oxmin.AddFlag( "cangive" )
local FLAG_CANGOD = oxmin.AddFlag( "cangod" )
local FLAG_GODMODE = oxmin.AddFlag( "godmode" )
local FLAG_CANLUA = oxmin.AddFlag( "canlua" )
local FLAG_CANCALLAIRDROP = oxmin.AddFlag( "cancallairdrop" )
local FLAG_RESERVED = oxmin.AddFlag( "reserved" )
local FLAG_CANDESTROY = oxmin.AddFlag( "candestroy" )

-- *******************************************
-- PLUGIN:Init()
-- Initialises the Oxmin plugin
-- *******************************************
function PLUGIN:Init()
	-- Notify console that oxmin is loading
	print( "Loading Oxmin..." )
	
	-- Load the user datafile
	self.DataFile = util.GetDatafile( "oxmin" )
	local txt = self.DataFile:GetText()
	if (txt ~= "") then
		self.Data = json.decode( txt )
	else
		self.Data = {}
		self.Data.Users = {}
	end
	
	-- Count and output the number of users
	local cnt = 0
	for _, _ in pairs( self.Data.Users ) do cnt = cnt + 1 end
	print( tostring( cnt ) .. " users are tracked by Oxmin!" )
	
	-- Load the config file
	local b, res = config.Read( "oxmin" )
	self.Config = res or {}
	if (not b) then
		self:LoadDefaultConfig()
		if (res) then config.Save( "oxmin" ) end
	end
	
	-- Add chat commands
	self:AddOxminChatCommand( "kick", { FLAG_CANKICK }, self.cmdKick )
	self:AddOxminChatCommand( "ban", { FLAG_CANBAN }, self.cmdBan )
	self:AddOxminChatCommand( "unban", { FLAG_CANBAN }, self.cmdUnban )
	self:AddOxminChatCommand( "lua", { FLAG_CANLUA }, self.cmdLua )
	self:AddOxminChatCommand( "god", { FLAG_CANGOD }, self.cmdGod )
	self:AddOxminChatCommand( "airdrop", { FLAG_CANCALLAIRDROP }, self.cmdAirdrop )
	self:AddOxminChatCommand( "give", { FLAG_CANGIVE }, self.cmdGive )
	self:AddOxminChatCommand( "help", { }, self.cmdHelp )
	self:AddOxminChatCommand( "who", { }, self.cmdWho )
	self:AddOxminChatCommand( "tp", { FLAG_CANTELEPORT }, self.cmdTeleport )
	self:AddOxminChatCommand( "bring", { FLAG_CANTELEPORT }, self.cmdBring )
	self:AddOxminChatCommand( "destroy", { FLAG_CANDESTROY }, self.cmdDestroy )
	
	-- Add console commands
	self:AddCommand( "oxmin", "giveflag", self.ccmdGiveFlag )
	self:AddCommand( "oxmin", "takeflag", self.ccmdTakeFlag )
end

-- *******************************************
-- PLUGIN:LoadDefaultConfig()
-- Loads the default configuration into the config table
-- *******************************************
function PLUGIN:LoadDefaultConfig()
	-- Set default configuration settings
	self.Config.chatname = "Oxmin"
	self.Config.reservedslots = 5
	self.Config.showwelcomenotice = true
	self.Config.welcomenotice = "Welcome to the server %s! Type /help for a list of commands."
	self.Config.showconnectedmessage = true
	self.Config.showdisconnectedmessage = true
	self.Config.helptext =
	{
		"Welcome to the server!",
		"This server is powered by the Oxide Modding API for Rust.",
		"Use /who to see how many players are online."
	}
end

-- *******************************************
-- PLUGIN:AddOxminChatCommand()
-- Adds an internal chat command with flag requirements
-- *******************************************
function PLUGIN:AddOxminChatCommand( name, flagsrequired, callback )
	-- Add external chat command to ourself
	self:AddExternalOxminChatCommand( self, name, flagsrequired, callback )
end

-- *******************************************
-- PLUGIN:AddExternalOxminChatCommand()
-- Adds an external chat command with flag requirements
-- *******************************************
function PLUGIN:AddExternalOxminChatCommand( plugin, name, flagsrequired, callback )
	-- Get a reference to the oxmin plugin
	local oxminplugin = plugins.Find( "oxmin" )
	if (not oxminplugin) then
		error( "Oxmin plugin file was renamed (don't do this)!" )
		return
	end
	
	-- Define a "proxy" callback that checks for flags
	local function FixedCallback( self, netuser, cmd, args )
		for i=1, #flagsrequired do
			if (not oxminplugin:HasFlag( netuser, flagsrequired[i] )) then
				rust.Notice( netuser, "You don't have permission to use this command!" )
				return true
			end
		end
		print( "'" .. netuser.displayName .. "' (" .. rust.CommunityIDToSteamID( tonumber( rust.GetUserID( netuser ) ) ) .. ") ran command '/" .. cmd .. " " .. table.concat( args, " " ) .. "'" )
		callback( self, netuser, args )
	end
	
	-- Add the chat command
	plugin:AddChatCommand( name, FixedCallback )
end

-- *******************************************
-- PLUGIN:ccmdGiveFlag()
-- Console command callback (oxmin.giveflag <user> <flag>)
-- *******************************************
function PLUGIN:ccmdGiveFlag( arg )
	-- Check the caller has admin or rcon
	local user = arg.argUser
	if (user and not user:CanAdmin()) then return end
	
	-- Locate the target user
	local b, targetuser = rust.FindNetUsersByName( arg:GetString( 0 ) )
	if (not b) then
		if (targetuser == 0) then
			arg:ReplyWith( "No players found with that name!" )
		else
			arg:ReplyWith( "Multiple players found with that name!" )
		end
		return
	end
	
	-- Locate the flag
	local flagid = oxmin.strtoflag[ arg:GetString( 1 ) ]
	if (not flagid) then
		arg:ReplyWith( "Unknown flag!" )
		return
	end
	
	-- Give the flag
	local targetname = util.QuoteSafe( targetuser.displayName )
	self:GiveFlag( targetuser, flagid )
	arg:ReplyWith( "Flag given to " .. targetname .. "." )
	
	-- Handled
	return true
end

-- *******************************************
-- PLUGIN:ccmdTakeFlag()
-- Console command callback (oxmin.takeflag <user> <flag>)
-- *******************************************
function PLUGIN:ccmdTakeFlag( arg )
	-- Check the caller has admin or rcon
	local user = arg.argUser
	if (user and not user:CanAdmin()) then return end
	
	-- Locate the target user
	local b, targetuser = rust.FindNetUsersByName( arg:GetString( 0 ) )
	if (not b) then
		if (targetuser == 0) then
			arg:ReplyWith( "No players found with that name!" )
		else
			arg:ReplyWith( "Multiple players found with that name!" )
		end
		return
	end
	
	-- Locate the flag
	local flagid = oxmin.strtoflag[ arg:GetString( 1 ) ]
	if (not flagid) then
		arg:ReplyWith( "Unknown flag!" )
		return
	end
	
	-- Take the flag
	local targetname = util.QuoteSafe( targetuser.displayName )
	self:TakeFlag( targetuser, flagid )
	arg:ReplyWith( "Flag taken from " .. targetname .. "." )
	
	-- Handled
	return true
end

-- *******************************************
-- PLUGIN:Save()
-- Saves the player data to file
-- *******************************************
function PLUGIN:Save()
	self.DataFile:SetText( json.encode( self.Data ) )
	self.DataFile:Save()
end

-- *******************************************
-- PLUGIN:BroadcastChat()
-- Broadcasts a chat message
-- *******************************************
function PLUGIN:BroadcastChat( msg )
	rust.BroadcastChat( self.Config.chatname, msg )
end

-- *******************************************
-- PLUGIN:CanClientLogin()
-- Saves the player data to file
-- *******************************************
local SteamIDField = util.GetFieldGetter( Rust.ClientConnection, "UserID", true )
--local PlayerClientAll = util.GetStaticPropertyGetter( Rust.PlayerClient, "All" )
--local serverMaxPlayers = util.GetStaticFieldGetter( Rust.server, "maxplayers" )
function PLUGIN:CanClientLogin( approval, connection )
	-- Get the user ID and player data
	local userID = tostring( SteamIDField( connection ) )
	local data = self:GetUserDataFromID( userID, connection.UserName )
	
	-- Check if they have the banned flag
	for i=1, #data.Flags do
		local f = data.Flags[i]
		if (f == FLAG_BANNED) then
			return NetworkConnectionError.ConnectionBanned
		end
	end
	
	-- Get the maximum number of players
	local maxplayers = Rust.server.maxplayers
	local curplayers = self:GetUserCount()
	
	-- Are we biting into reserved slots?
	if (curplayers + self.Config.reservedslots >= maxplayers) then
		-- Check if they have reserved flag
		for i=1, #data.Flags do
			local f = data.Flags[i]
			if (f == FLAG_RESERVED or f == FLAG_ALL) then return end
		end
		return NetworkConnectionError.TooManyConnectedPlayers
	end
end

-- *******************************************
-- PLUGIN:GetUserCount()
-- Gets the number of connected users
-- *******************************************
function PLUGIN:GetUserCount()
	return Rust.PlayerClient.All.Count
end

-- *******************************************
-- PLUGIN:OnUserConnect()
-- Called when a user has connected
-- *******************************************
function PLUGIN:OnUserConnect( netuser )
	local sid = rust.CommunityIDToSteamID( tonumber( rust.GetUserID( netuser ) ) )
	print( "User \"" .. util.QuoteSafe( netuser.displayName ) .. "\" connected with SteamID '" .. sid .. "'" )
	local data = self:GetUserData( netuser )
	data.Connects = data.Connects + 1
	self:Save()
	if (data.Connects == 1 and self.Config.showwelcomenotice) then
		rust.Notice( netuser, self.Config.welcomenotice:format( netuser.displayName ), 20.0 )
	end
	if (self.Config.showconnectedmessage) then self:BroadcastChat( netuser.displayName .. " has joined the game." ) end
end

-- *******************************************
-- PLUGIN:OnUserDisconnect()
-- Called when a user has disconnected
-- *******************************************
function PLUGIN:OnUserDisconnect( networkplayer )
	--print( "OnUserDisconnect " .. tostring( networkplayer ) )
	local netuser = networkplayer:GetLocalData()
	if (not netuser or netuser:GetType().Name ~= "NetUser") then return end
	local sid = rust.CommunityIDToSteamID( tonumber( rust.GetUserID( netuser ) ) )
	print( "User \"" .. util.QuoteSafe( netuser.displayName ) .. "\" disconnected with SteamID '" .. sid .. "'" )
	if (self.Config.showdisconnectedmessage) then self:BroadcastChat( netuser.displayName .. " has left the game." ) end
end

-- *******************************************
-- PLUGIN:GetUserData()
-- Gets a persistent table associated with the given user
-- *******************************************
function PLUGIN:GetUserData( netuser )
	local userID = rust.GetUserID( netuser )
	return self:GetUserDataFromID( userID, netuser.displayName )
end

-- *******************************************
-- PLUGIN:GetUserDataFromID()
-- Gets a persistent table associated with the given user ID
-- *******************************************
function PLUGIN:GetUserDataFromID( userID, name )
	local userentry = self.Data.Users[ userID ]
	if (not userentry) then
		userentry = {}
		userentry.Flags = {}
		userentry.ID = userID
		userentry.Name = name
		userentry.Connects = 0
		self.Data.Users[ userID ] = userentry
		self:Save()
	end
	return userentry
end

-- *******************************************
-- PLUGIN:HasFlag()
-- Returns true if the specified user has the specified flag
-- *******************************************
function PLUGIN:HasFlag( netuser, flag, ignoreall )
	local userID = rust.GetUserID( netuser )
	local data = self:GetUserData( netuser )
	for i=1, #data.Flags do
		local f = data.Flags[i]
		if (f == FLAG_ALL and not ignoreall) then return true end
		if (f == flag) then return true end
	end
	return false
end

-- *******************************************
-- PLUGIN:GiveFlag()
-- Gives the specified flag to the specified user
-- *******************************************
function PLUGIN:GiveFlag( netuser, flag )
	local userID = rust.GetUserID( netuser )
	local data = self:GetUserData( netuser )
	for i=1, #data.Flags do
		if (data.Flags[i] == flag) then return false end
	end
	table.insert( data.Flags, flag )
	rust.Notice( netuser, "You now have the flag '" .. oxmin.flagtostr[ flag ] .. "'!" )
	self:Save()
	return true
end

-- *******************************************
-- PLUGIN:TakeFlag()
-- Takes the specified flag from the specified user
-- *******************************************
function PLUGIN:TakeFlag( netuser, flag )
	local userID = rust.GetUserID( netuser )
	local data = self:GetUserData( netuser )
	for i=1, #data.Flags do
		if (data.Flags[i] == flag) then
			table.remove( data.Flags, i )
			rust.Notice( netuser, "You no longer have the flag '" .. oxmin.flagtostr[ flag ] .. "'!" )
			self:Save()
			return true
		end
	end
	return false
end

-- *******************************************
-- PLUGIN:OnTakeDamage()
-- Called when an entity take damage
-- *******************************************
function PLUGIN:ModifyDamage( takedamage, damage )
	local typ = takedamage:GetType()
	local GetComponent = takedamage.GetComponent
	if (GetComponent == "GetComponent") then
		print( "(oxmin:ModifyDamage) GetComponent was a string! takedamage is a " .. typ.Name )
		return
	end
	local controllable = takedamage:GetComponent( "Controllable" )
	if (not controllable) then return end
	--print( controllable )
	local netuser = controllable.playerClient.netUser
	if (not netuser) then return error( "Failed to get net user (ModifyDamage)" ) end
	local char = rust.GetCharacter( netuser )
	if (not char) then return error( "Failed to get Character (ModifyDamage)" ) end
	--local char = obj:GetComponent( "Character" )
	if (char) then
		local ct = char:GetType()
		--[[if (ct.Name == "DamageBeing") then
			char = char.character
			print( "Hacky fix, " .. ct.Name .. " is now " .. char:GetType().Name )
			if (char:GetType().Name == "DamageBeing") then
				print( "The hacky fix didn't work, it's still a DamageBeing!" )
				return
			end
		end]]
		--print( ct )
		local netplayer = char.networkViewOwner
		if (netplayer) then
			local netuser = rust.NetUserFromNetPlayer( netplayer )
			if (netuser) then
				if (self:HasFlag( netuser, FLAG_GODMODE, true )) then
					--print( "Damage denied" )
					damage.amount = 0
					return damage
				end
			end
		end
	end
end

-- CHAT COMMANDS --
function PLUGIN:cmdHelp( netuser, args )
	for i=1, #self.Config.helptext do
		rust.SendChatToUser( netuser, self.Config.helptext[i] )
	end
	plugins.Call( "SendHelpText", netuser )
end
function PLUGIN:cmdWho( netuser, args )
	rust.SendChatToUser( netuser, "There are " .. tostring( #rust.GetAllNetUsers() ) .. " survivors online." )
end
function PLUGIN:cmdKick( netuser, args )
	if (not args[1]) then
		rust.Notice( netuser, "Syntax: /kick name" )
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
	local targetname = util.QuoteSafe( targetuser.displayName )
	self:BroadcastChat( "'" .. targetname .. "' was kicked by '" .. util.QuoteSafe( netuser.displayName ) .. "'!" )
	rust.Notice( netuser, "\"" .. targetname .. "\" kicked." )
	targetuser:Kick( NetError.Facepunch_Kick_RCON, true )
end
function PLUGIN:cmdBan( netuser, args )
	if (not args[1]) then
		rust.Notice( netuser, "Syntax: /ban name" )
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
	local targetname = util.QuoteSafe( targetuser.displayName )
	self:BroadcastChat( "'" .. targetname .. "' was banned by '" .. util.QuoteSafe( netuser.displayName ) .. "'!" )
	rust.Notice( netuser, "\"" .. targetname .. "\" banned." )
	self:GiveFlag( targetuser, FLAG_BANNED )
	targetuser:Kick( NetError.Facepunch_Kick_Ban, true )
end
function PLUGIN:cmdUnban( netuser, args )
	if (not args[1]) then
		rust.Notice( netuser, "Syntax: /unban name" )
		return
	end
	local candidates = {}
	for id, data in pairs( self.Data.Users ) do
		if (data.Name:match( args[1] )) then
			candidates[ #candidates + 1 ] = data
		end
	end
	if (#candidates == 0) then
		rust.Notice( netuser, "No banned users found with that name!" )
		return
	elseif (#candidates > 1) then
		rust.Notice( netuser, "Multiple banned users found with that name!" )
		return
	end
	candidates[1].Flags = {}
	self:Save()
	rust.Notice( netuser, util.QuoteSafe( candidates[1].Name ) .. " unbanned." )
end
function PLUGIN:cmdTeleport( netuser, args )
	if (not args[1]) then
		rust.Notice( netuser, "Syntax: /tp target OR /tp player target" )
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
	if (not args[2]) then
		-- Teleport netuser to targetuser
		rust.ServerManagement():TeleportPlayerToPlayer( netuser.networkPlayer, targetuser.networkPlayer )
		rust.Notice( netuser, "You teleported to '" .. util.QuoteSafe( targetuser.displayName ) .. "'!" )
		rust.Notice( targetuser, "'" .. util.QuoteSafe( netuser.displayName ) .. "' teleported to you!" )
	else
		local b, targetuser2 = rust.FindNetUsersByName( args[2] )
		if (not b) then
			if (targetuser2 == 0) then
				rust.Notice( netuser, "No players found with that name!" )
			else
				rust.Notice( netuser, "Multiple players found with that name!" )
			end
			return
		end
		
		-- Teleport targetuser to targetuser2
		rust.ServerManagement():TeleportPlayerToPlayer( targetuser.networkPlayer, targetuser2.networkPlayer )
		rust.Notice( targetuser, "You were teleported to '" .. util.QuoteSafe( targetuser2.displayName ) .. "'!" )
		rust.Notice( targetuser2, "'" .. util.QuoteSafe( targetuser.displayName ) .. "' teleported to you!" )
	end
end
function PLUGIN:cmdGod( netuser, args )
	if (not args[1]) then
		if (not self:GiveFlag( netuser, FLAG_GODMODE )) then
			self:TakeFlag( netuser, FLAG_GODMODE )
		end
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
	local targetname = util.QuoteSafe( targetuser.displayName )
	if (self:GiveFlag( targetuser, FLAG_GODMODE )) then
		rust.Notice( netuser, "\"" .. targetname .. "\" now has godmode." )
	elseif (self:TakeFlag( targetuser, FLAG_GODMODE )) then
		rust.Notice( netuser, "\"" .. targetname .. "\" no longer has godmode." )
	end
end
function PLUGIN:cmdLua( netuser, args )
	local code = table.concat( args, " " )
	local b, res = util.LoadString( code, "Oxmin /lua" )
	if (not b) then
		rust.Notice( netuser, res )
		return
	end
	util.BeginCapture()
	b, res = pcall( res )
	local log_print, log_err = util.EndCapture()
	if (not b) then
		rust.Notice( netuser, res )
		return
	end
	if (#log_err > 0) then
		rust.Notice( netuser, tostring( #log_err ) .. " error(s) when executing Lua code!", 2.5 )
		for i=1, #log_err do
			timer.Once( i * 2.5, function() rust.Notice( netuser, log_err[i], 2.5 ) end )
		end
	elseif (#log_print > 0) then
		for i=1, #log_print do
			timer.Once( (i - 1) * 2.5, function() rust.Notice( netuser, log_print[i], 2.5 ) end )
		end
	else
		rust.Notice( netuser, "No output from Lua call." )
	end
end
function PLUGIN:cmdAirdrop( netuser, args )
	rust.Notice( netuser, "Airdrop called!" )
	rust.CallAirdrop()
end

local preftype = cs.gettype( "Inventory+Slot+Preference, Assembly-CSharp" )
--local AddItemAmount = util.FindOverloadedMethod( Rust.PlayerInventory, "AddItemAmount", bf.public_instance, { Rust.ItemDataBlock, System.Int32, preftype } )
function PLUGIN:cmdGive( netuser, args )
	if (not args[1]) then
		rust.Notice( netuser, "Syntax: /give itemname {quantity}" )
		return
	end
	local datablock = rust.GetDatablockByName( args[1] )
	if (not datablock) then
		rust.Notice( netuser, "No such item!" )
		return
	end
	local amount = tonumber( args[2] ) or 1
	-- IInventoryItem objA = current.AddItem(byName, Inventory.Slot.Preference.Define(Inventory.Slot.Kind.Default, false, Inventory.Slot.KindFlags.Belt), quantity);
	local pref = rust.InventorySlotPreference( InventorySlotKind.Default, false, InventorySlotKindFlags.Belt )
	--local controllable = netuser.playerClient.controllable
	--local inv = controllable:GetComponent( "PlayerInventory" )
	local inv = rust.GetInventory( netuser )
	local arr = util.ArrayFromTable( System.Object, { datablock, amount, pref } )
	--cs.convertandsetonarray( arr, 1, amount, System.Int32._type )
	util.ArraySet( arr, 1, System.Int32, amount )
	--util.PrintArray( arr )
	--print( datablock )
	--print( pref )
	--print( amount )
	--local invitem = inv:AddItem( datablock, pref, amount )
	if (type( inv.AddItemAmount ) == "string") then
		print( "AddItemAmount was a string! (inv = " .. tostring( inv ) .. " - " .. (inv and inv:GetType().Name or "") .. ")" )
		--AddItemAmount:Invoke( inv, arr )
	else
		inv:AddItemAmount( datablock, amount, pref )
	end
	rust.InventoryNotice( netuser, tostring( amount ) .. " x " .. datablock.name )
end

local RaycastHitDistance = util.GetPropertyGetter( UnityEngine.RaycastHit, "distance" )
local function TraceEyes( netuser )
	local controllable = netuser.playerClient.controllable
	local char = controllable:GetComponent( "Character" )
	local ray = char.eyesRay
	local hits = RaycastAll( ray )
	local tbl = cs.createtablefromarray( hits )
	if (#tbl == 0) then return end
	local closest = tbl[1]
	local closestdist = closest.distance
	for i=2, #tbl do
		if (tbl[i].distance < closestdist) then
			closest = tbl[i]
			closestdist = closest.distance
		end
	end
	return closest
end
function PLUGIN:cmdDestroy( netuser, args )
	
end