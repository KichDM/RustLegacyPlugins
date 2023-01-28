PLUGIN.Title = "Anti Flyhack & NoFall"
PLUGIN.Description = "Anti Flyhack and nofall hacks"
PLUGIN.Author = "Reneb"
PLUGIN.Version = "1.2"

function PLUGIN:Init()
	self.DataFile = util.GetDatafile( "r-antinofalldamage" )
	local txt = self.DataFile:GetText()
	if (txt ~= "") then
		self.Data = json.decode( txt )
	else
		self.Data = {}
	end

	local b, res = config.Read("r-antinofalldamage")
	self.Config = res or {}
	if (not b) then
		self:LoadDefaultConfig()
		if (res) then
			config.Save("r-antinofalldamage")
     	end
	end
	self.SpawnPoint = {}
	self:AddChatCommand("nfd", self.cmdCheck)
	self.SavedInventory = {}
end
function PLUGIN:PostInit()
	self.ebs = plugins.Find("EnhancedBanSystem")
end
function PLUGIN:cmdCheck( netuser, cmd, args )
    if (not(args[1])) then
        return
    end
    if(not netuser:CanAdmin()) then
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
    
	local userID = rust.GetUserID( targetuser )
	rust.Notice( netuser, targetuser.displayName .. " esta sendo testado pelo anticheat" )
	self.Data[userID] = {}
	self.Data[userID].justjoinned = true
	self.Data[userID].detected = 0
	self:StartCheck(targetuser,userID)
end

function PLUGIN:OnUserConnect( netuser )
	local userID = rust.GetUserID(netuser)
	if(not self.Data[userID] or (self.Data[userID] and not self.Data[userID].cleared)) then
		if(self.Config.CheckAllPlayersOnJoin) then
			self.Data[userID] = {}
			self.Data[userID].justjoinned = true
			self.Data[userID].detected = 0
			timer.NextFrame( function() self:StartCheck(netuser,userID) end )
		end
	end
end
function PLUGIN:StartCheck(netuser,userID)
	if(not netuser or not netuser.playerClient) then
		self.Data[userID] = nil
		return
	end
	local coords = netuser.playerClient.lastKnownPosition
	self.SpawnPoint[userID] = coords
	coords.x = 0
	coords.y = 10000
	coords.z = 0
	rust.ServerManagement():TeleportPlayer(netuser.playerClient.netPlayer, coords)
	timer.Once( 1, function() self:CheckIfTeleported(netuser,userID) end )
end
function PLUGIN:CheckIfTeleported(netuser,userID)
	if(not netuser or not netuser.playerClient) then
		self.Data[userID] = nil
		return
	end
	local coords = netuser.playerClient.lastKnownPosition
	if(coords.y > 9000) then
		self.Data[userID].lasty = math.floor(coords.y)
		timer.Once( 1, function() self:CheckFallSpeed(netuser,userID,1) end)
	else
		timer.Once( 1, function() self:StartCheck(netuser,userID) end )
	end
end
function PLUGIN:SendToAdmins(msg)
	for _, targetuser in pairs( rust.GetAllNetUsers() ) do
		if(targetuser:CanAdmin()) then
			rust.SendChatToUser(targetuser, self.Config.chatName, msg)
		end
	end
end
function PLUGIN:CheckFallSpeed(netuser,userID,current)
	if(not netuser or not netuser.playerClient) then
		self.Data[userID] = nil
		return
	end
	local coords = netuser.playerClient.lastKnownPosition
	local delta = math.abs(coords.y - self.Data[userID].lasty)
	if(delta < 30 and delta > 0.001) then 
		self.Data[userID].detected = self.Data[userID].detected + 1
		if(self.Config.SendDetectionsToAdmins) then
			self:SendToAdmins( netuser.displayName .. " esta caindo a " .. delta .. " metros" )
		end
	elseif(coords.y > 10004) then
		self.Data[userID].detected = self.Data[userID].detected + 10
		if(self.Config.SendDetectionsToAdmins) then
			self:SendToAdmins( netuser.displayName .. " esta subindo durante o teste! Bom hack.." )
		end
	end
	self.Data[userID].lasty = coords.y
	if(self.Data[userID].detected >= self.Config.NumberOfDetectionsBeforeBan) then
		if(self.Config.AllowAutoBan) then
			if(self.ebs) then
				local nargs = {}
				nargs[1] = netuser.networkPlayer.externalIP
				nargs[2] = "rFlyhack"
				self.ebs:cmdBan(false,nargs)
			end
			rust.RunServerCommand("banid \"" .. tostring(rust.GetLongUserID( netuser )) .. "\" \"" .. tostring(netuser.displayName) .. "\" \"rFlyhack\"")
			netuser:Kick(NetError.Facepunch_Kick_Ban, true)	
			self.Data[userID] = nil
			if(self.Config.BroadcastBan) then
				rust.BroadcastChat( self.Config.chatName, "[color #FF4444]" .. netuser.displayName .. " foi banido por fly")
			end
			return
		end
	end 
	if(current > self.Config.TimerToCheckForFallDamage) then
		rust.SendChatToUser(netuser, self.Config.chatName, "[color gold]Voce aparenta estar sem hack, obrigado e bom jogo!!")
		rust.Notice(netuser, "Voce aparenta estar sem hack, obrigado e bom jogo!!")
		self:SaveInventory(netuser,userID)
		self:ClearInventory(netuser)
		local controllable = netuser.playerClient.controllable
		local metabolism = controllable:GetComponent("Metabolism")
		metabolism:AddPoison(50000)
		self.Data[userID] = {}
		self.Data[userID].cleared = true
		self:Save()
		return
	end
	timer.Once( 1, function() self:CheckFallSpeed(netuser,userID,current+1) end)
end
function PLUGIN:OnSpawnPlayer( playerclient, usecamp, avatar )
	local netuser = playerclient.netUser
	if(not netuser) then return end
	local userID = rust.GetUserID(netuser)
	if(self.SavedInventory[userID]) then
		timer.NextFrame( function()
			timer.Once( 1, function()
				if(netuser and netuser.playerClient) then
					self:ClearInventory(netuser)
					self:RestoreInventory(netuser,userID)
					self.SavedInventory[userID] = {}
					self.SavedInventory[userID] = nil
					rust.SendChatToUser(netuser, self.Config.chatName, "[color gold]Todos seus itens foram devolvidos!!")
				end
			end )
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
	for i,item in pairs(self.SavedInventory[userID]) do
		pref = nil
		if(self.SavedInventory[userID][i]) then
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
function PLUGIN:Save()
	self.DataFile:SetText( json.encode( self.Data ) )
	self.DataFile:Save()
end
function PLUGIN:LoadDefaultConfig()
	self.Config.chatName = "AntiHack"
	self.Config.NumberOfDetectionsBeforeBan = 3
	self.Config.TimerToCheckForFallDamage = 5
	self.Config.BroadcastBan = true
	self.Config.SendDetectionsToAdmins = true
	self.Config.AllowAutoBan = true
	self.Config.CheckAllPlayersOnJoin = true
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
function PLUGIN:SaveInventory(netuser,userID)
	local inv = rust.GetInventory( netuser )
	if(not inv or tostring(type(inv)) == "string" ) then 
		inv = netuser.playerClient.rootControllable.idMain:GetComponent( "Inventory" )
	end
	if(not inv or tostring(type(inv)) == "string" ) then 
		return
	end
	self.SavedInventory[userID] = {}
	local iterator = inv.OccupiedIterator
	local currentitem = 1
	while iterator:Next() do
		local item = iterator.item
		if item and item.datablock and item.datablock.Name then
			local itemtosave = self:getItemSpecifics( item )
			self.SavedInventory[userID][currentitem] = {}
			self.SavedInventory[userID][currentitem] = itemtosave
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