-- Não mexer aqui!
PLUGIN.Title = "Loja"
PLUGIN.Description = "Sistema de loja. Compra e venda de itens. Dinheiro em geral "
PLUGIN.Author = "DokiTV"
PLUGIN.Version = "1.0.0"
PLUGIN.ResourceID = "425"
PLUGIN.ConfigVersion = "1"
PLUGIN.DataVersion = "1.0Alpha"
-- Não mexer aqui!
local NoPermission = "Sem permissoes!"
local Debugger = " modo debbuger desativado."
local current = 0

-- Este plugin foi criado com base no plugin Essentials.

-----------------------------------------
--████-------████████---███---███---███--
--██--███---███----███--███--████---███--
--██---██---██------██--██████-----------
--██---██---██------██--███-████----███--
--██--███---███----███--███---███---███--
--████-------████████---███---███---███--
-----------------------------------------

-- Versão:  1.0
-- ChangeLog: 
-- COMANDOS ADICIONADOS
-- /dinheiro - /loja - /comprar - /vender - /additem - /setmoney - /dinheiro top - /dinheiro pagar 
--
-- Bug de perca de dinheiro apos reiniciar server arrumado
-- Sempre que for fechar seu servidor, dê /salvar
--
-- Para adicionar itens na loja, digite /additem
-- Para comprar itens/adicionar itens na loja/vender com espaço nos nomes, digite o nome com aspas, exemplo:
-- /comprar "Explosive Charge" 1
-- /additem "Explosive Charge" 1
-- /vender "Bolt Action Rifle" 10
--
-- Qualquer bug, reporte via skype ou email:
-- darkdoki1@gmail.com
-- skype: doki.tv
-- http://darkrustbr.com

function PLUGIN:LoadDefaultConfig()
	-- ****************************************
	-- **************** Basic *****************
	-- ****************************************
	self.Config.configVersion = self.ConfigVersion
	self.Config.Chatname = self.Config.Chatname or self.Title
	-- ****************************************
	-- *************** Enabled ****************
	-- ****************************************
	if type(self.Config.Enabled) ~= "table" then
		self.Config.Enabled = {}
	end
	self.Config.Enabled.Econ = self.Config.Enabled.Econ or true
	-- ****************************************
	-- ***************** Misc *****************
	-- ****************************************
	if type(self.Config.Misc) ~= "table" then
		self.Config.Misc = {}
	end
	self.Config.Misc.AutoSaveTime = self.Config.Misc.AutoSaveTime or 2500
	
	-- ****************************************
	-- ***************** Econ *****************
	-- ****************************************
	if type(self.Config.Econ) ~= "table" then
		self.Config.Econ = {}
	end
	self.Config.Econ.StartMoney = self.Config.Econ.StartMoney or 1000
	self.Config.Econ.Symbol = self.Config.Econ.Symbol or "$"
	self.Config.Econ.Rabbit = self.Config.Econ.Rabbit or 25
	self.Config.Econ.Wolf = self.Config.Econ.Wolf or 125
	self.Config.Econ.Bear = self.Config.Econ.Bear or 250
	self.Config.Econ.Chicken = self.Config.Econ.Chicken or 25
	self.Config.Econ.Stag = self.Config.Econ.Stag or 80
	self.Config.Econ.Boar = self.Config.Econ.Boar or 120
	self.Config.Econ.HumanPercent = self.Config.Econ.HumanPercent or 15
	self.Config.Econ.ShowMoneyConnect = self.Config.Econ.ShowMoneyConnect or true
end


function PLUGIN:LoadCommands()
	if (self.Config.Enabled.Econ) then
		self:AddChatCommand( "plist", self.cmdPrice )
		self:AddChatCommand( "loja", self.cmdPrice )
		self:AddChatCommand( "bal", self.cmdMoney )
		self:AddChatCommand( "balance", self.cmdMoney )
		self:AddChatCommand( "dinheiro", self.cmdMoney )
		self:AddChatCommand( "money", self.cmdMoney )
		self:AddChatCommand( "comprar", self.cmdBuy )
		self:AddChatCommand( "vender", self.cmdSell )
		self:AddChatCommand( "fixmoney", self.FixMoney )
	end
	if self.Config.Enabled.Econ then
			flags:AddFlagsChatCommand( self, "additem", {"econ"}, self.cmdAddPrice )
			flags:AddFlagsChatCommand( self, "setmoney", {"econ"}, self.cmdSetMoney )
	end
	if self.Config.Enabled.Econ then
		self:AddChatCommand( "additem", self.cmdAddPrice )
		self:AddChatCommand( "setmoney", self.cmdSetMoney )
		self:AddChatCommand( "addmoney", self.cmdAddMoney )
		self:AddCommand( "essentials", "addmoney", self.ccmdAddMoney )
	end
	flags:AddFlagsChatCommand( self, "salvar", {"reload"}, self.cmdSave )
end


function PLUGIN:DefaultEconConfig()
	self.CData["Wood"] = {Buy = 10, Sell = 1}
	self.CData["Cloth"] = {Buy = 50, Sell = 5}
	self.CData["Animal Fat"] = {Buy = 20, Sell = 2}
	self.CData["Blood"] = {Buy = 50, Sell = 5}
	self.CData["Raw Chicken Breast"] = {Buy = 20, Sell = 2}
	self.CData["Stones"] = {Buy = 50, Sell = 5}
	self.CData["Metal Fragments"] = {Buy = 50, Sell = 5}
	self.CData["Sulfur"] = {Buy = 50, Sell = 5}
	self:EconSave()
end


function PLUGIN:Init()
	print("**********************************************************")
	print(self.Title .. " (" .. self.Version .. ") Carregada com o ID: "..self.ResourceID)
	now = UnityEngine.Time.realtimeSinceStartup
	self:Data()
	self:LoadConfig()
	self:EconConfig()
	self:FlagsCheck()
	self:LoadCommands()
	self:AddApi()
	print("**********************************************************")
end


function PLUGIN:OnServerInitialized()
    self.saveTimer = timer.Repeat(tonumber(self.Config.Misc.AutoSaveTime), function()
        rust.RunServerCommand("save.all")
		self:Save()
		self:EconSave()
        rust.BroadcastChat(self.Config.Chatname , "[color orange] Save completo " )
    end)
end

function PLUGIN:Unload()
    if (self.saveTimer ~= nil) then
        self.saveTimer:Destroy()
        self.saveTimer = nil
    end
end

function PLUGIN:FlagsCheck()
    flags = plugins.Find( "flags" )
    if (flags) then
		print(self.Title..": Flags adicionadas.")
    else
		print(self.Title..": Flags plugin nao encontrado.")
	end
	return flags
end

function PLUGIN:AddApi()
	if not api.Exists( "Essentials" ) then
		api.Bind( PLUGIN, "Essentials" )
		print(self.Title..": API Iniciada!")
	else
		print(self.Title..": API Ja iniciada!")
	end
end


function PLUGIN:cmdSave( netuser )
	local nowis = UnityEngine.Time.realtimeSinceStartup
	self:Save()
	self:EconSave()
	config.Save( self.Title )
	if netuser then
		rust.RunServerCommand("save.all")
		rust.Notice(netuser, "Mundo salvo")
	else
		print("Save completo, e demorou: "..(UnityEngine.Time.realtimeSinceStartup - nowis).." segundos.")
		rust.BroadcastChat(self.Config.Chatname ,"Save completo, e demorou: "..(UnityEngine.Time.realtimeSinceStartup - nowis).." segundos.")
	end
end


function PLUGIN:LoadConfig()
	local b, res = config.Read( self.Title )
	self.Config = res or {}
	if (not b) then
		self:LoadDefaultConfig()
		if (res) then 
			config.Save( self.Title )
		end
		print(self.Title..": Config default criada.")
	else
		print( self.Title..": Config encontrada" )
		config.Save( self.Title )
	end
	if ( self.Config.configVersion ~= self.ConfigVersion) then
		local curver = tostring(self.Config.configVersion)
		self:LoadDefaultConfig()
		print(self.Title..": Versao: "..curver.." esta desatualizada! Nova versao: "..self.ConfigVersion.."!")
		config.Save( self.Title )
	end
end

function PLUGIN:Data()
	self.PlayerData = util.GetDatafile( self.Title )
	if (self.PlayerData:GetText() == "") then
		self.PData = {}
		self:Save()
		print( self.Title..": Arquivo de configuracao criado" )
	else
		self.PData = json.decode( self.PlayerData:GetText() )
		if (not self.PData) then
			error( self.Title..": json error in Essentials.txt" )
			self.PData = {}
		else
			print(self.Title..": Configuracao carregada.")
		end
	end
	self:DefaultData()
end

function PLUGIN:DefaultData()
	if self.PData.Users == nil then
		self.PData.Users = {}
	end
	self.PData.History = {}
	if self.PData.Group == nil then
		self.PData.Group = {}
	end
	self:Save()
end

function PLUGIN:EconConfig()
	if self.Config.Enabled.Econ then
		self.ConfigData = util.GetDatafile( "ItensLoja" )
		if (self.ConfigData:GetText() == "") then
			self.CData = {}
			self:DefaultEconConfig()
			print( self.Title..": Tabela de economia criado" )
		else
			self.CData = json.decode( self.ConfigData:GetText() )
			if (not self.CData) then
				error( self.Title..": json error in ItensLoja.txt" )
				self.CData = {}
			else
				print(self.Title..": Tabela de economia carregado.")
			end
		end
	end
end


function PLUGIN:EconSave()
	self.ConfigData:SetText( json.encode( self.CData ) )
	self.ConfigData:Save()
end


function PLUGIN:StartTimers()
	self.Autosave = timer.Repeat(self.Config.Misc.AutoSaveTime * 60, function() self:cmdSave() end)
	print(self.Title..": Started timers.")
	self:Save()
	self:EconSave()
end


function PLUGIN:Save()
	self.PlayerData:SetText( json.encode( self.PData ) )
	self.PlayerData:Save()
end


function PLUGIN:CheckEconData()
	if self.Config.Enabled.Econ then
		for k,v in pairs(self.CData) do
			local datablock = rust.GetDatablockByName( k )
			if not datablock then
				error(self.Title..": "..k.." nao e um item")
			end
			if tonumber(v.Sell) ~= nil then
				if tonumber(v.Buy) < tonumber(v.Sell) then
					error(self.Title..": "..k.." preco de venda e maior que o de compra")
				end
				for ka,va in pairs(self.Config.Misc.AutoKit) do
					if type(va) == "table" then
						if va.item == k then
							error(self.Title..": "..k.." is included in the autokit, you shouldn't be able sell it.")
						end
					else
						if va == k then
							error(self.Title..": "..k.." is included in the autokit, you shouldn't be able sell it.")
						end
					end
				end
			end
		end
	end
	return true
end
	
	
function PLUGIN:cmdAddPrice(netuser, cmd, args)
	local datan = self:GetUserData(netuser)
	if netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "econ")) then
		if not args[2] then
			rust.Notice(netuser, "Digite /additem \"NomeDoItem\" \"PrecoCompra\" \"PrecoVenda\"")
			return true
		end
		local datablock = rust.GetDatablockByName(args[1])
		if not datablock then
			rust.Notice(netuser, args[1].." nao e um item.")
			return true
		end
		local itemname = tostring(args[1])
		self.CData[itemname] = {}
		self.CData[itemname].Buy = tonumber(args[2])
		if (args[3]) then
			self.CData[itemname].Sell = tonumber(args[3])
		else
			self.CData[itemname].Sell = math.floor(tonumber(args[2]) / 10)
		end
		self:EconSave()
		self:SendChatToUser(netuser,  "[color green] Voce adicionou/atualizou o item: "..itemname.." na loja!")
	else
		rust.Notice(netuser, NoPermission)
	end
end


function PLUGIN:cmdBuy(netuser, cmd, args)
	if not args[1] then
		self:cmdPrice( netuser, cmd, args, "buy" )
		return true
	end
	local datablock = rust.GetDatablockByName( args[1] )
	if not datablock then
		rust.Notice(netuser, "Item nao encontrado!")
		return false
	end
	if args[2] == nil or not args[2] then
		args[2] = 1
	end
	if not string.match (args[2], "%d+") then
		args[2] = 1
	end
	if tonumber(args[2]) < 0 then
		args[2] = 1
	end
	arg2 = tonumber(args[2])
	local datacheck = self.CData[args[1]]
	if datacheck then
		local amount = datacheck.Buy * tonumber(arg2)
		local takemn = self:TakeMoney(netuser, amount)
		if takemn then
			self:Give(netuser, tostring(args[1]), arg2)
			self:SendChatToUser(netuser,  "[color green]Voce comprou "..arg2.." "..args[1])
		end
	end
end



function PLUGIN:cmdGive( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "give"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /give \"Player\"(Opcional) \"NomeItem\" \"Quantidade\"")
			return
		end
		local amount, itemname, playername
		if args[1] and not args[2] then
			amount = 1
			itemname = args[1]
			playername = netuser.displayName
		elseif args[2] and string.match(args[2], "%d+") then
			amount = args[2]
			itemname = args[1]
			playername = netuser.displayName
		elseif not string.match(args[2], "%d+") then
			amount = args[3]
			itemname = args[2]
			playername = args[1]
		end
		local b, targetuser = rust.FindNetUsersByName( playername )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Player: "..playername.." nao encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		if not targetuser then
			targetuser = netuser
		end
		if amount == nil then
			amount = 1
		end
		local datablock = rust.GetDatablockByName(itemname)
		if datablock then
			local give = self:Give(targetuser, itemname, amount)
			if give then
				rust.Notice(netuser, "Voce deu: "..targetuser.displayName.." "..amount.." "..itemname)
			else
				rust.Notice(netuser, "Nao foi possivel dar: "..amount.." "..itemname.." to "..targetuser.displayName)
			end
		else
			rust.Notice(netuser, itemname.." nao e um item valido.")
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end


function PLUGIN:Give(user, item, amount, slot, showitem)
	local datablock = rust.GetDatablockByName( item )
	if (not datablock) then
		rust.Notice( user, item.." nao e um item!" )
		return false
	end
	local amount = tonumber( amount ) or 1
	local pref = self:CSlot(slot)
	local inv = rust.GetInventory( user )
	if inv == nil then
		self:SendChatToUser(user, "Inventario nao encontrado, relogue no server.")
		return false
	end
	local arr = util.ArrayFromTable( System.Object, { datablock, amount, pref } )
	util.ArraySet( arr, 1, System.Int32, amount )
	if (type( inv.AddItemAmount ) == "string") then
		print( "AddItemAmount foi uma string!")
	else
		inv:AddItemAmount( datablock, amount, pref )
	end
	if showitem == nil then
		rust.InventoryNotice( user, tostring( amount ) .. " x " .. datablock.name )
	end
	return true
end


function PLUGIN:Take(netuser, itemname, amounty, stackable)
	local datablock = rust.GetDatablockByName( itemname )
	local amount = tonumber(amounty) or 1
	local inv = rust.GetInventory( netuser )
	if inv == nil then
		self:SendChatToUser(user, "Inventario nao encontrado, relogue no server.")
		return 0
	end
    local taken = 0
    while taken < amount do
        local item = inv:FindItem(datablock)
        if not item then return taken end
        if item.datablock:IsSplittable() or stackable  then
            local canTake = item.uses
            local needToTake = amount - taken
            if canTake >  needToTake then
				taken = taken + item.uses
				item:SetUses(item.uses - needToTake)
            else 
				taken = taken + item.uses  
				inv:RemoveItem(item)
			end
        else 
			inv:RemoveItem(item)  
			taken = taken + 1
		end
    end
	return amount
end


function PLUGIN:CSlot(slot)
	local slot = tostring(slot)
	local newslot
	if slot == "armor" then
		newslot = rust.InventorySlotPreference( InventorySlotKind.Armor, true, InventorySlotKindFlags.Armor )
	elseif slot == "hotbar" then
		newslot = rust.InventorySlotPreference( InventorySlotKind.Belt, true, InventorySlotKindFlags.Belt )
	else
		newslot = rust.InventorySlotPreference( InventorySlotKind.Default, true, InventorySlotKindFlags.Belt )
	end
	return newslot
end


function PLUGIN:cmdSell(netuser, cmd, args)
	if not args[1] and not tonumber(args[1]) then
		self:cmdPrice( netuser, cmd, args, "sell" )
		return true
	end
	if not args[2] then
		args[2] = 1
	end
	if not string.match (args[2], "%d+") then
		args[2] = 1
	end
	if tonumber(args[2]) < 0 then
		args[2] = 1
	end
	local datablock = rust.GetDatablockByName(args[1])
	if not datablock then
		rust.Notice( netuser, args[1].." nao e um item!" )
		return
	end
	local datacheck = self.CData[args[1]]
	if datacheck then
		if datacheck.Sell ~= nil then
			local take = self:Take(netuser, args[1], args[2], args[1] == "Research Kit 1")
			if take > 0 then
				self:AddMoney(netuser, datacheck.Sell * take)
				self:SendChatToUser(netuser,  "Voce vendeu "..take.." "..args[1].."")
			else
				self:SendChatToUser(netuser,  "Voce nao tem "..args[1])
			end
		else
			rust.Notice(netuser, "Este item nao tem um preço de venda.")
		end
	end
end


function PLUGIN:cmdPrice( netuser, cmd, args, focus )
	if not args[1] then
		args[1] = 1
	end
	local pagenum = tonumber(args[1])
	local sometable = {}
	local count = 0
	local countpage = 2
	local cnt = 0
	local MaxRows = 10
	for k,_ in pairs(self.CData) do
		cnt = cnt + 1
		if cnt >= MaxRows then
			countpage = countpage + 1
			cnt = 0
		end
	end
	if type(pagenum) ~= "number" then
		local t00 = 0
		for k,value in pairsByKeys(self.CData) do
			kl = k:lower()
			if kl:find(tostring(args[1]):lower()) then
				if t00 > MaxRows then
					break
				end
				t00 = t00 + 1
				if value.Buy ~= nil and value.Sell ~= nil then
					self:SendChatToUser(netuser,  "Nome: \""..k.."\"  -  [Compra: "..value.Buy.."]  -  [Venda: "..value.Sell.."]")
				elseif value.Buy ~= nil and value.Sell == nil then
					self:SendChatToUser(netuser,  "Nome: \""..k.."\"  -  [Compra: "..value.Buy.."]")
				elseif value.Buy == nil and value.Sell ~= nil then
					self:SendChatToUser(netuser,  "Nome: \""..k.."\"  -  [Venda: "..value.Sell.."]")
				end
			end
		end
	else
		if pagenum > countpage then
			self:SendChatToUser(netuser,  "Pagina nao existente.")
			return false
		end
		if not args[2] then
			focus = "all"
		elseif args[2] == "sell" then
			focus = "sell"
		elseif args[2] == "buy" then
			focus = "buy"
		end
		self:SendChatToUser(netuser,  "[color green]--- PAGINA [  "..tostring(pagenum).."/"..tostring(countpage).." ] Proxima pagina digite: /loja 2 ou /loja 3, etc..---")
		for k,value in pairsByKeys(self.CData) do
			count = count + 1
			local cal = (pagenum) * (MaxRows + 1)
			if sometable[pagenum] == nil then
				sometable[pagenum] = {}
			end	
			if count < cal and count > cal - (MaxRows + 1) then
				if focus == "buy" and value.Buy ~= nil then
					self:SendChatToUser(netuser,  "Nome: \""..k.."\"  -  [Compra: "..value.Buy.."]")
				elseif focus == "sell" and value.Sell ~= nil then
					self:SendChatToUser(netuser,  "Nome: \""..k.."\"  -  [Venda: "..value.Sell.."]")
				elseif focus == "all" and value.Sell ~= nil and value.Buy ~= nil then
					self:SendChatToUser(netuser,  "Nome: \""..k.."\"  -  [Compra: "..value.Buy.."]  -  [Venda: "..value.Sell.."]")
				end
			end
		end
	end
end


function PLUGIN:GetUserData( netuser, targetuser, finder )
	if ( netuser ) then
		local userID = rust.GetUserID( netuser )
		return self:GetUserDataFromID( userID, netuser.displayName )
	elseif (targetuser) then
		local userID = rust.GetUserID( targetuser )
		return self:GetUserDataFromID( userID, targetuser.displayName )
	elseif (finder) then
		local userID = rust.GetUserID( finder )
		return self:GetUserDataFromID( userID, finder.displayName )
	end
end


function PLUGIN:GetUserDataFromID( userID, name )
	if self.PData.Users == nil then
		self.PData.Users = {}
	end
	local userentry = self.PData.Users[ userID ]
	local ThisDay = System.DateTime.Now:Tostring("dd")
	if (type(userentry) ~= "table" or userentry.DataVersion ~= self.DataVersion) then
		if (type(userentry) ~= "table") then
			userentry = {}
		end
		userentry.ID = userID
		userentry.Name = name
		userentry.Uses = userentry.Uses or 0
		userentry.Money = userentry.Money or self.Config.Econ.StartMoney
		userentry.DataVersion = self.DataVersion
		userentry.JoinDateDay = ThisDay
		userentry.Essentials = userentry.Essentials or false
		self.PData.Users[ userID ] = userentry
		self:Save()
	end
	return userentry
end


function PLUGIN:cmdMoney(netuser, cmd, args)
	local data = self:GetUserData( netuser )
	if not args[1] or args == nil then
		self:ShowBalance(netuser)
		return true
	end
    if (args[1] == "top") then
        local mypairs = {}
        for id,value in pairs(self.PData.Users) do
			if value.DataVersion == self.DataVersion then
				table.insert(mypairs,{Name=value.Name, Money=math.ceil(value.Money)})
			end
		end
        table.sort(mypairs,function(a,b) return a.Money > b.Money end)
        local listed = 1
        self:SendChatToUser( netuser, "[color green] Players mais ricos do server: ")
        for _,pair in pairs(mypairs) do
            self:SendChatToUser(netuser,  "#"..listed.." "..util.QuoteSafe(pair.Name).." com [color green] "..util.QuoteSafe(tostring(pair.Money))..self.Config.Econ.Symbol )
            listed = listed + 1
            if listed > 10 then break end
        end
        return
	elseif tostring(args[1]) == "pagar" then
		if not args[3] then
			rust.Notice(netuser, "Digite /dinheiro pagar \"Player\" \"Quantidade\"")
			return true
		else
			local b, targetuser = rust.FindNetUsersByName( args[2] )
			if (not b) then
				if (targetuser == 0) then
					rust.Notice( netuser, "Player nao encontrado!" )
				else
					rust.Notice( netuser, "Varios players encontrados!" )
				end
				return
			end
			if netuser == targetuser then
				rust.Notice(netuser, "Voce nao pode dar dinheiro a voce mesmo.")
				return false
			end
			if tonumber(args[3]) < 0 then
				rust.Notice(netuser, "Voce nao pode ficar com dinheiro negativo.")
				return false
			end
			local takemn = self:TakeMoney( netuser, args[3])
			if takemn then
				self:AddMoney( targetuser, args[3] )
				rust.Notice(netuser, "Voce mandou "..targetuser.displayName.." "..tostring(args[3])..self.Config.Econ.Symbol)
				rust.Notice(targetuser, "Voce recebeu "..tostring(args[3]).."$ de "..netuser.displayName)
			end
		end
	elseif (args[1] and args[1] ~= "send" and args[1] ~= "top") then
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Player nao encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
		return
		end
		local datat = self:GetUserData( targetuser )
		self:SendChatToUser(netuser,  targetuser.displayName.." Dinheiro: "..tostring(datat.Money)..self.Config.Econ.Symbol)
		return true
	end
end


function PLUGIN:ShowBalance(user)
	local data = self:GetUserData(user)
	self:SendChatToUser(user, "[color cyan]Dinheiro: "..data.Money..self.Config.Econ.Symbol)
end


function PLUGIN:cmdSave( netuser )
	local nowis = UnityEngine.Time.realtimeSinceStartup
	self:Save()
	self:EconSave()
	config.Save( self.Title )
	if netuser then
		rust.RunServerCommand("save.all")
		rust.Notice(netuser, "Mundo salvo")
	else
		print("Save completo, e demorou: "..(UnityEngine.Time.realtimeSinceStartup - nowis).." segundos.")
		rust.BroadcastChat("Save completo, e demorou: "..(UnityEngine.Time.realtimeSinceStartup - nowis).." segundos.")
	end
end


function PLUGIN:AddMoney(user, amount)
	local data = self:GetUserData( user )
	if type(data) == "table" then
		if amount == 0 then
			return false
		else
			amounty = tonumber(amount)
			data.Money = data.Money + amounty
			data.Money = math.floor(data.Money)
			self:SendChatToUser(user, "[color green]Dinheiro: "..tostring(data.Money).." ( + "..tostring(amount)..self.Config.Econ.Symbol.." )")
			return true
		end
	end
end


function PLUGIN:FixMoney(netuser)
	for _,v in pairs(self.PData.Users) do
		if v.Money < 0 then
			v.Money = self.Config.Econ.StartMoney
		end
	end
	rust.Notice(netuser, "Dinheiro arrumado!")
end


function PLUGIN:TakeMoney( user, amount)
	local data = self:GetUserData( user )
	local amount = tonumber(amount)
	local curmoney = tostring(data.Money)
	if amount == 0 or amount == nil then
		return false
	end
	if data.Money < amount then 
		rust.Notice(user, "Sem dinheiro suficiente para fazer isso!")
		return false
	else
		amount = tonumber(amount)
		data.Money = data.Money - amount
		data.Money = math.floor(data.Money)
		self:SendChatToUser(user, "[color cyan]Dinheiro: "..curmoney.." ( - "..amount..self.Config.Econ.Symbol.." )")
		return true
	end
end


function PLUGIN:cmdSetMoney( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "econ")) then
		if not args[2] then
			rust.Notice(netuser, "Digite /setmoney \"Player\" \"Quantidade\"")
		else
			local b, targetuser = rust.FindNetUsersByName( args[1] )
			if (not b) then
				if (targetuser == 0) then
					rust.Notice( netuser, "Player offline!" )
				else
					rust.Notice( netuser, "Varios players encontrados!" )
				end
				return
			end
			local data = self:GetUserData( targetuser )
			data.Money = math.ceil(tonumber(args[2]))
			self:SendChatToUser(netuser,  "Voce deixou o player "..targetuser.displayName.." com: "..args[2]..self.Config.Econ.Symbol)
			self:ShowBalance(targetuser)
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end


function PLUGIN:cmdAddMoney(netuser, cmd, args)
	local datan = self:GetUserData(netuser)
	if netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "econ")) then
		if (not args[2]) then
			rust.Notice(netuser, "Digite /addmoney \"Player\" para dar dinheiro.")
		end
		if args[2] then
			local b, targetuser = rust.FindNetUsersByName( args[1] )
			if (not b) then
				if (targetuser == 0) then
					rust.Notice(netuser, "Player nao encontrado!" )
				else
					rust.Notice(netuser, "Varios players encontrados!" )
				end
				return
			end
			local argu = tonumber(args[2])
			self:AddMoney(targetuser, argu)
			self:SendChatToUser(netuser, "Voce deu: "..targetuser.displayName.." "..args[2]..self.Config.Econ.Symbol)
			self:ShowBalance(targetuser)
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end


function PLUGIN:ccmdAddMoney(arg)
	local netuser = arg.argUser
	if (netuser and not netuser:CanAdmin()) then return end
	if (arg:GetString(0) == nil) then
		arg:ReplyWith("Digite /addmoney \"Player\" para dar dinheiro.")
	end
	if arg:GetString( 1 ) then
		local b, targetuser = rust.FindNetUsersByName( arg:GetString( 0 ) )
		if (not b) then
			if (targetuser == 0) then
				arg:ReplyWith( "Player nao encontrado!" )
			else
				arg:ReplyWith( "Varios players encontrados!" )
			end
			return
		end
		local argu = tonumber(arg:GetString( 1))
		self:AddMoney(targetuser, argu)
		arg:ReplyWith("You have given "..targetuser.displayName.." "..arg:GetString( 1 )..self.Config.Econ.Symbol)
	end
	return true
end


function PLUGIN:GiveMoneyAll(netuser, cmd, args)
	local datan = self:GetUserData(netuser)
	if netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "econ")) then
		for _,netusertmp in pairs(rust.GetAllNetUsers()) do
			self:AddMoney(netusertmp, tonumber(args[1]))
		end
		rust.Notice(netuser, "You have given all players "..tostring(args[1])..self.Config.Econ.Symbol)
		return
	end
end


function pairsByKeys(t, f)
    local a = {}
    for n in pairs(t) do table.insert(a, n) end
		table.sort(a, f)
		local i = 0
		local iter = function ()
			i = i + 1
			if a[i] == nil then 
				return nil
			else 
				return a[i], t[a[i]] 
			end
		end
	return iter
end


function PLUGIN:SendChatToUser(netuser, msg)
	rust.SendChatToUser(netuser, self.Config.Chatname, msg)
end



function PLUGIN:OnKilled(takedamage, damage)
	if damage.victim and damage.victim.client and damage.victim.client.netuser then
		local NUID = rust.GetUserID(damage.victim.client.netuser)
		autokit[NUID] = true
	end
	if damage.attacker and damage.attacker.client and damage.attacker.client.netuser then
		local attacker = damage.attacker.client.netuser
		local allowed = false
		local animalname = nil
		local human = false
		if (takedamage:GetComponent( "HumanController" )) then
			if damage.victim and damage.victim.client and damage.victim.client.netuser and (damage.victim.client ~= damage.attacker.client) then
				local victim = damage.victim.client.netuser
				local dataa = self:GetUserData( attacker )
				local datav = self:GetUserData( victim )
				local VictimData = self:GetUserData(damage.victim.client.netuser)
				if VictimData.Death ~= nil then
					VictimData.Death = VictimData.Death + 1
				end
				if dataa.Kills ~= nil then
					dataa.Kills = dataa.Kills + 1
				end
				if (self.Config.Log.LogPlayerDeaths) then
					if self.Config.Enabled.DeathMessage then
						self:Logger(attacker.displayName.." [color red] matou "..victim.displayName)
					end
				end
				if (self.Config.Enabled.DeathMessage) then
					rust.BroadcastChat(self.Config.Chatname, attacker.displayName.." [color green] matou "..victim.displayName)
				end
				local Group = self:GetGroup(attacker)
				if type(Group) == "table" then
					Group.Kills = Group.Kills + 1
				end
				local VGroup = self:GetGroup(damage.victim.client.netuser)
				if type(VGroup) == "table" then
					VGroup.Death = VGroup.Death + 1
				end
				if self.Config.Misc.SyncKills then
					self:AddKillsToKiller(attacker, victim)
				end
				if (self.Config.Enabled.Econ) then
					if self.Config.Econ.HumanPercent > 0 and self.Config.Econ.HumanPercent < 100 then
						local gain = math.floor(datav.Money * (self.Config.Econ.HumanPercent / 100))
						self:AddMoney(attacker, gain)
						self:TakeMoney(victim, gain)
					end
				end
				allowed = true
				human = true
			end
		elseif (takedamage:GetComponent( "BearAI" )) then
			allowed = true
			animalname = "Urso"
		elseif (takedamage:GetComponent( "StagAI" )) then
			allowed = true
			animalname = "Veado"
		elseif (takedamage:GetComponent( "BoarAI" )) then
			allowed = true
			animalname = "Porco"
		elseif (takedamage:GetComponent( "ChickenAI" )) then
			allowed = true
			animalname = "Galinha"
		elseif (takedamage:GetComponent( "WolfAI" )) then
			allowed = true
			animalname = "Lobo"
		elseif (takedamage:GetComponent( "RabbitAI" )) then
			allowed = true
			animalname = "Coelho"
		end
		if self.Config.Enabled.Econ then
			if animalname == "Urso" then
				self:AddMoney(attacker, self.Config.Econ.Bear)
			elseif animalname == "Veado" then
				self:AddMoney(attacker, self.Config.Econ.Stag)
			elseif animalname == "Porco" then
				self:AddMoney(attacker, self.Config.Econ.Boar)
			elseif animalname == "Galinha" then
				self:AddMoney(attacker, self.Config.Econ.Chicken)
			elseif animalname == "Lobo" then
				self:AddMoney(attacker, self.Config.Econ.Wolf)
			elseif animalname == "Coelho" then
				self:AddMoney(attacker, self.Config.Econ.Rabbit)
			end
		end
		if self.Config.Enabled.DamageIndicator then
			if allowed then
				if animalname ~= nil then
					rust.Notice(attacker, "Voce matou o/a/um "..animalname)
				elseif (human) and damage.victim.client ~= damage.attacker.client.netuser then
					rust.Notice(attacker, "Voce matou o/a/um "..damage.victim.client.netuser.displayName)
				end
			end
		end
	end
	
end



