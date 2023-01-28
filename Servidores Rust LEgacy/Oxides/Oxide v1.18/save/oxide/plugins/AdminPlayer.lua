PLUGIN.Title = "Admin / Player"
PLUGIN.Description = "Easily switch between player and admin mod"
PLUGIN.Author = "Reneb"
PLUGIN.Version = "1.3"

function PLUGIN:Init()
	
	
	local b, res = config.Read( "admin-player" )
	self.Config = res or {}
	if (not b or (not self.Config.Version or (self.Config.Version and self.Config.Version ~= "1.3"))) then
		self:LoadDefaultConfig()
		if (res) then config.Save( "admin-player" ) end
	end
	if(self.Config.Flags_with_oxmin) then
		self.oxminPlugin =  plugins.Find("oxmin")
	end
	if(self.Config.Flags_with_flags) then
		self.flags_plugin = plugins.Find("flags")
	end
	self.DataFile = util.GetDatafile( "admin" )
	local txt = self.DataFile:GetText()
	if (txt ~= "") then
		self.Admin = json.decode( txt )
	else
		self.Admin = {}
	end
	
	self.Timer = {}
	
	-- Oxmin flag nÂ°6 = canteleport
	self:AddChatCommand( "admin", self.cmdAdminnooxmin )
	self.AdminInv = {}
end
function PLUGIN:LoadDefaultConfig()
	self.Config.BagPack = {
		[1]={name="Arrow",amount=50},
	}
	self.Config.Armor = {
		[1]="Invisible Helmet",
		[2]="Invisible Vest",
		[3]="Invisible Pants",
		[4]="Invisible Boots"	
	}
	self.Config.FastBar = {
		[1]={name="Uber Hatchet",amount=1},
		[2]={name="Uber Hunting Bow",amount=1},
		[3]={name="Cooked Chicken Breast",amount=5},
		[4]={name="Large Medkit",amount=5},
		[5]={name="Stone Hatchet",amount=1}
	}
	self.Config.Version = "1.3"
	self.Config.Flags_with_oxmin = true
	self.Config.Flags_with_flags = false
	self.Config.flagsplugin_flag = "admin"
end
function PLUGIN:OnUserChat(netuser,name,msg)
	if (msg:sub( 1, 1 ) ~= "/") then
		local userID = tonumber(rust.GetUserID(netuser))
		if(self.Admin[userID] and self.Admin[userID].hideName) then
			name = self.Admin[userID].AdminName
			rust.BroadcastChat( name, msg )
			return true
		end
	end
end
function PLUGIN:cmdAdminnooxmin(netuser,cmd,args)
	if not self:isAdmin(netuser) then
		return
	end
	self:AdminCMD(netuser,args)
end
function PLUGIN:SetGodMode(netuser,to)
	local char = rust.GetCharacter(netuser)
	if(not char) then return end
	if(tostring(type(char.takeDamage)) ~= "userdata") then return end
	char.takeDamage:SetGodMode(to)
end
function PLUGIN:AdminCMD(netuser,args)
	local userID = tonumber(rust.GetUserID(netuser))
	if(not self.Admin[userID]) then 
	self.Admin[userID] = {} 
		self.Admin[userID].isAdmin = false
		self.Admin[userID].hideName = false
		self.Admin[userID].AdminName = "SERVER CONSOLE"
	end
	if(args[1]) then
		if(args[1] == "hide") then
			if(not self.Admin[userID].hideName) then
				self.Admin[userID].hideName = true
				rust.SendChatToUser(netuser, "You will now have a hidden name (" .. self.Admin[userID].AdminName .. ")!" )
			else
				self.Admin[userID].hideName = false
				rust.SendChatToUser(netuser, "You will no longer have a hidden name!" )
			end
			self:Save()
			return
		elseif(args[1] == "name") then
			local adminname = ""
			if(not args[2]) then 
				adminname = "SERVER CONSOLE"
			else
				for i,v in pairs(args) do
					if(i ~= 1) and (i ~= 0) then
						adminname = adminname .. v .. " "
					end
				end
			end
			self.Admin[userID].AdminName = adminname
			rust.SendChatToUser(netuser, "Your new admin name will be " .. adminname )
			self:Save()
			return
		end
	end
	if(not self.Admin[userID].isAdmin) then
		self.Admin[userID].isAdmin = true
		self:SaveInventory(netuser,userID)
		self:ClearInventory(netuser)
		self:AdminGear(netuser)
		self:ClearInjury(netuser)
		self:SetGodMode(netuser,true)
		rust.Notice( netuser, "You've transformed into an admin", 5.0 )
		
	else
		self.Admin[userID].isAdmin = false
		self:ClearInventory(netuser)
		self:RestoreInventory(netuser,userID)
		self:SetGodMode(netuser,false)
		rust.Notice( netuser, "You are a simple mortel again", 5.0 )
	end
end
function PLUGIN:ClearInjury(netuser)
	if(not netuser) then return end
	local userID = tonumber(rust.GetUserID(netuser))
    local playerClient = netuser.playerClient
    if(not playerClient) then
        return
    end
	
    local controllable = playerClient.controllable
    if(not controllable) then
        return
    end
	if(self.Timer[netuser]) then self.Timer[netuser]:Destroy() end
	local fallDamage = controllable:GetComponent("FallDamage")
	if(fallDamage:GetLegInjury() > 0) then
		fallDamage:ClearInjury()
	end
	if(self.Admin[userID] and self.Admin[userID].isAdmin) then
		self.Timer[netuser] = timer.Once( 2, function() self:ClearInjury(netuser) end)
	end
end
function PLUGIN:OnSpawnPlayer( playerclient, usecamp, avatar )
	local netuser = playerclient.netUser
	if(not netuser) then return end
	local userID = tonumber(rust.GetUserID(netuser))
	if(self.Timer[netuser]) then self.Timer[netuser]:Destroy() end

	if(self.Admin[userID] and self.Admin[userID].isAdmin) then
		timer.NextFrame( function()
			self:ClearInventory(playerclient.netUser)
			self:AdminGear(playerclient.netUser)
			self:SetGodMode(playerclient.netUser,true)
			self:ClearInjury(playerclient.netUser)
		end)
	else
		timer.NextFrame( function()
			self:SetGodMode(playerclient.netUser,false)
		end)
	end
end
function PLUGIN:RestoreInventory(netuser,userID)
	local inv = rust.GetInventory( netuser )
	if(not inv or tostring(type(inv)) == "string" ) then 
		inv = netuser.playerClient.rootControllable.idMain:GetComponent( "Inventory" )
	end
	if(not inv or tostring(type(inv)) == "string" ) then 
		return
	end
	local pref
	local belt = 29
	local bag = -1
	for i,item in pairs(self.AdminInv[userID]) do
		pref = nil
		if(self.AdminInv[userID][i]) then
			if(item.slot >= 0 and item.slot <= 29) then
				pref = rust.InventorySlotPreference(InventorySlotKind.Default, false, InventorySlotKindFlags.Belt)
				bag = bag + 1
			elseif(item.slot >= 30 and item.slot <= 35) then
				pref = rust.InventorySlotPreference(InventorySlotKind.Belt, false, InventorySlotKindFlags.Belt)
				belt = belt + 1
			elseif(item.slot >= 36 and item.slot <= 39) then
				pref = rust.InventorySlotPreference(InventorySlotKind.Armor, false, InventorySlotKindFlags.Armor)
			end
		end
		if(pref ~= nil) then
			local itemdata = rust.GetDatablockByName( item.Name )
			inv:AddItemAmount( itemdata, 1, pref )
			local _b, invitem = inv:GetItem( GetNewSlotFromOld(item.slot,bag,belt) )
			if(invitem and invitem ~= nil) then
				if(item.uses) then invitem:SetUses( item.uses ) end
				if(item.condition) then invitem:SetCondition( item.condition ) end
				if(item.maxcondition) then invitem:SetMaxCondition( item.maxcondition ) end
				if(item.totalModSlots) then invitem:SetTotalModSlotCount( tonumber(item.totalModSlots) ) end
				if item.ModList and tonumber( #item.ModList ) then
					for key, value in pairs( item.ModList ) do
						invitem:AddMod( value )
					end
				end
			end
		end
	end
end
function GetNewSlotFromOld(slot,bag,belt)
	if(slot >= 0 and slot <= 29) then
		return bag
	elseif(slot >= 30 and slot <= 35) then
		return belt
	else
		return slot
	end
end
function PLUGIN:AdminGear(netuser)
	local inv = rust.GetInventory( netuser )
	if(not inv or tostring(type(inv)) == "string" ) then 
		inv = netuser.playerClient.rootControllable.idMain:GetComponent( "Inventory" )
	end
	if(not inv or tostring(type(inv)) == "string" ) then 
		return
	end

	local pref = rust.InventorySlotPreference( InventorySlotKind.Armor, false, InventorySlotKindFlags.Armor )
	for i=1, #self.Config.Armor do
		if(i > 4) then
			error("More than 4 armor parts, WTF!")
			break
		end
		inv:AddItemAmount( rust.GetDatablockByName( self.Config.Armor[i] ) , 1, pref )
	end
	pref = rust.InventorySlotPreference( InventorySlotKind.Belt, false, InventorySlotKindFlags.Belt )
	for i=1, #self.Config.FastBar do
		if(i > 6) then
			error("More than 6 items in the Bar, WTF!")
			break
		end
		inv:AddItemAmount( rust.GetDatablockByName( self.Config.FastBar[i].name ) , self.Config.FastBar[i].amount , pref )
	end

	pref = rust.InventorySlotPreference( InventorySlotKind.Default, false, InventorySlotKindFlags.Belt )
	for i=1, #self.Config.BagPack do
		inv:AddItemAmount( rust.GetDatablockByName( self.Config.BagPack[i].name ) , self.Config.BagPack[i].amount, pref )
	end
	
end
function PLUGIN:ClearInventory(netuser)
	local inv = rust.GetInventory( netuser )
	if(not inv or tostring(type(inv)) == "string" ) then 
		inv = netuser.playerClient.rootControllable.idMain:GetComponent( "Inventory" )
	end
	if(not inv or tostring(type(inv)) == "string" ) then 
		return
	end
	inv:Clear()
end
function PLUGIN:Save()
	self.DataFile:SetText( json.encode( self.Admin ) )
	self.DataFile:Save()
end

function PLUGIN:SaveInventory(netuser,userID)
	local inv = rust.GetInventory( netuser )
	self.AdminInv[userID] = {}
	local iterator = inv.OccupiedIterator
	local currentitem = 1
	while iterator:Next() do
		local item = iterator.item
		if item and item.datablock and item.datablock.Name then
			local itemtosave = self:getItemSpecifics( item )
			self.AdminInv[userID][currentitem] = {}
			self.AdminInv[userID][currentitem] = itemtosave
			currentitem = currentitem + 1
		end
	end
end
function PLUGIN:getItemSpecifics( item )
	local tmp = {}
	tmp.Name = item.datablock.Name
	tmp.slot = item.slot
	if tonumber( item.maxUses ) then tmp.maxUses = item.maxUses end
	if tonumber( item.uses ) then tmp.uses = item.uses end
	if tonumber( item.condition ) then tmp.condition = item.condition end
	if tonumber( item.maxcondition ) then tmp.maxcondition = item.maxcondition end
	if tonumber( item.totalModSlots ) then tmp.totalModSlots = item.totalModSlots end
	if tonumber( item.usedModSlots ) and item.usedModSlots > 0 then
		tmp.usedModSlots = item.usedModSlots
		tmp.ModList = self:getItemMods( item )
	end
	return tmp
end

function PLUGIN:getItemMods( item )
	local itemModList = {}
	local itemMods = item.itemMods
	local _count = itemMods.Length - 1
	for _i = 0, _count do
		local _itemMod = itemMods[ _i ]
		if _itemMod then
			table.insert( itemModList, _itemMod )
		end
	end
	return itemModList
end

function PLUGIN:isAdmin(netuser)
	if(netuser:CanAdmin()) then return true end
	if(self.oxminPlugin and self.oxminPlugin:HasFlag( netuser, 6 )) then return true end
	if(self.flags_plugin and self.flags_plugin:HasFlag(tostring( rust.GetLongUserID(netuser) ), self.Config.flagsplugin_flag )) then return true end
	return false
end