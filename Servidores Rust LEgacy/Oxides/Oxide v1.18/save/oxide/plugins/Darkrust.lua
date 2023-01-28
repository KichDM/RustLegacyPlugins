-- Não edite essa parte ou o plugin vai parar de funcionar :)
PLUGIN.Title = "DarkRust"
PLUGIN.Description = "Essentials do Darkrust ! http://youtube.com/fofdouglas2009 | www.darkrustbr.com"
PLUGIN.Author = "DokiTV"
PLUGIN.Version = "3.0.0"
PLUGIN.ResourceID = "425"
PLUGIN.ConfigVersion = "3"
PLUGIN.DataVersion = "3.0A"

-- Não edite essa parte ou o plugin vai parar de funcionar :)
local NoPermission = "Sem permissoes!"
local Debugger = " foi testado."
local current = 0
local GlobalMUTE = false
local Kicked = {}

-- Versão 3.0.0
-- Changelog:
-- #1 Kits vips separados por grupos adicionados (Mito, matador, lenda, vip, vip1, vip2, vip3, louco, youtuber, Coder)
-- #2 /lenda /mito /matador /louco /youtuber /coder /vipadd /vip1 /vip2 /vip3 /modadd adicionados
-- #3 Youtuber, vip, vip1, vip2, vip3, mod recebem paycheck
-- #4 Configs arrumadas
-- #5 Primeiro evento essentials /hiddenchest
-- #6 Permissoes de ban, kick, god adicionadas para moderador
-- #7 Traduçao quase 100%
-- #8 /comprar e /vender
-- #9 Nome dos animais traduzidos
-- #10 Boss do server criado: Viado (20.000 de vida, drop de 1.000.000$ pra quem matar)
-- #11 Bug do comprar arrumado, comprar para comprar item, loja para ver itens, vender para vender itens
-- #12 Tags /Divulgador /dono adicionadas
-- #13 Adicionado /additem "nome item" PreçoCompra PreçoVenda Exemplo: /additem "Explosive Charge" 50000 100 - Adiciona um item na loja do server, sem precisar reiniciar






function PLUGIN:cmdAdt(netuser, cmd)
	rust.Notice( netuser, "If it works i will get this message.." )	
end



function PLUGIN:Init()
	print("**********************************************************")
	print(self.Title .. " (" .. self.Version .. ") plugins carregados com o ID: "..self.ResourceID)
	now = UnityEngine.Time.realtimeSinceStartup
	self:Data()
	self:LoadConfig()
	self:Log()
	self:EconConfig()
	self:FlagsCheck()
	self:LoadCommands()
	self:AddApi()
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
		print(self.Title..": Essentials API bound!")
	else
		print(self.Title..": Essentials API already bound!")
	end
end

function PLUGIN:cmdSave( netuser )
	local nowis = UnityEngine.Time.realtimeSinceStartup
	self:Save()
	
	config.Save( self.Title )
	if netuser then
		rust.RunServerCommand("save.all")
		rust.Notice(netuser, "Mundo salvo")
	else
		print("Save completo, e demorou: "..(UnityEngine.Time.realtimeSinceStartup - nowis).." segundos.")
		rust.BroadcastChat("ϟ | [DarkRust]","Save completo, e demorou: "..(UnityEngine.Time.realtimeSinceStartup - nowis).." segundos.")
	end
end

function PLUGIN:Data()
	self.PlayerData = util.GetDatafile( self.Title )
	if (self.PlayerData:GetText() == "") then
		self.PData = {}
		self:Save()
		print( self.Title..": Arquivo de configuraçao criado" )
	else
		self.PData = json.decode( self.PlayerData:GetText() )
		if (not self.PData) then
			error( self.Title..": json error in Essentials.txt" )
			self.PData = {}
		else
			print(self.Title..": Configuraçao carregada.")
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
		self.ConfigData = util.GetDatafile( "EssentialsEcon" )
		if (self.ConfigData:GetText() == "") then
			self.CData = {}
			self:DefaultEconConfig()
			print( self.Title..": Tabela de economia criado" )
		else
			self.CData = json.decode( self.ConfigData:GetText() )
			if (not self.CData) then
				error( self.Title..": json error in EssentialsEcon.txt" )
				self.CData = {}
			else
				print(self.Title..": Tabela de economia carregado.")
			end
		end
	end
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

-- function PLUGIN:EconSave()
--	self.ConfigData:SetText( json.encode( self.CData ) )
--	self.ConfigData:Save()
-- end

function PLUGIN:CheckEconData()
	if self.Config.Enabled.Econ then
		for k,v in pairs(self.CData) do
			local datablock = rust.GetDatablockByName( k )
			if not datablock then
				error(self.Title..": "..k.." isn't a valid item")
			end
			if tonumber(v.Sell) ~= nil then
				if tonumber(v.Buy) < tonumber(v.Sell) then
					error(self.Title..": "..k.."'s sell price is higher than the buy price.")
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

function PLUGIN:CheckKitData()
	if self.Config.Enabled.Kits then
		timer.Once(10, function()
			for name,kit in pairs(self.Config.Kits) do
				if type(kit.items) ~= "table" then
					kit.items = {}
					print(self.Title..": "..name.." doesn't have any items.")
				else
					for _,v in pairs(kit.items) do
						local d = nil
						if type(v) ~= "table" then
							d = v
						else
							d = v.item
						end
						local vdata1 = rust.GetDatablockByName(d)
						if not vdata1 then
							print(d.." isn't an item.")
						end
					end
				end
			end
		end)
	end
	return true
end

function PLUGIN:Log()
	TodayIs = System.DateTime.Now:ToString("MM/dd")
	if (self.Config.Enabled.Log) then
		self.LogData = util.GetDatafile(string.gsub(self.Title.." - " .. TodayIs , "/", "-"))
		local logText = self.LogData:GetText()
		if (logText ~= "") then
			self.LData = split("\r\n", logText)
			print(self.Title..": Loaded Essentials LOG file.")
		else
			self.LData = {}
			print(self.Title..": Generated default LOG file.")
			self:Logger("Generated log file.")
		end
	end
end

function split( sep, str )
	local t = {}
	for word in string.gmatch( str, "[^"..sep.."]+" ) do 
		table.insert( t, word )
	end	
	return t
end

function PLUGIN:Logger(message)
	local msg = util.QuoteSafe(tostring(message))
	if (type(self.LData) ~= "table") then
		self.LData = {}
	end
	if (self.Config.Enabled.Log) then
		if (TodayIs ~= System.DateTime.Now:ToString("MM/dd")) then
			self:Log()
		end
		if (self.Config.Log.Log24HourClock) then
			table.insert( self.LData, System.DateTime.Now:ToString("HH:mm") .. " " .. msg)
		else
			table.insert(self.LData, System.DateTime.Now:ToString("hh:mm tt") .. " ".. msg)
		end
		self:Logsave()
	end
end

function PLUGIN:Logsave()
	self.LogData:SetText( table.concat( self.LData, "\r\n" ) )
	self.LogData:Save()
end

function PLUGIN:OnDatablocksLoaded()
	if self.Title ~= "DarkRust" then
		error("Nao mude o PLUGIN.Title")
		return false
	end
	local settings = self:DefaultSettings()
	local timercheck = self:StartTimers()
	local econcheck = self:CheckEconData()
	local kitcheck = self:CheckKitData()
	local essentialshelp = self:LoadEssentialsHelp()
	local c = 0
	for _ in pairs(self.PData.Users) do c = c + 1 end
	print(self.Title..": "..c.." users loaded.")
	if settings and timercheck and econcheck and kitcheck and essentialshelp then
		print(self.Title..": Loading essentials took "..(UnityEngine.Time.realtimeSinceStartup - now).." second(s).")
		print("**********************************************************")
	end
end

function PLUGIN:DefaultSettings()
    rust.RunServerCommand( "env.daylength "..util.QuoteSafe(tostring(self.Config.TimeCmds.Daylength)))
    rust.RunServerCommand( "env.nightlength "..util.QuoteSafe(tostring(self.Config.TimeCmds.Nightlength)))
    rust.RunServerCommand( "server.pvp "..util.QuoteSafe(tostring(self.Config.Misc.PvP)))
    rust.RunServerCommand( "falldamage.enabled "..util.QuoteSafe(tostring(self.Config.Misc.FallDamage)))
	local calarg = (self.Config.Misc.Craftamount / 100)
	local calargd = (self.Config.Misc.Durabilityamount / 0)
	rust.RunServerCommand("crafting.timescale "..tostring(calarg))
	rust.RunServerCommand("conditionloss.damagemultiplier "..tostring(calargd))
	rust.RunServerCommand("player.backpackLockTime "..tostring(self.Config.Misc.BacklockTime))
	rust.RunServerCommand("sleepers.on "..tostring(self.Config.Misc.Sleepers))
	if self.Config.Misc.SyncKills then
		timer.Once(1800, function()
			local sync = self:Sync() 
			if sync == false then
				print(self.Title..": Synchronization failed.")
			end
		end) -- Half a hour after server start.
	end
	return true
end

function PLUGIN:LoadConfig()
	local b, res = config.Read( self.Title )
	self.Config = res or {}
	if (not b) then
		self:LoadDefaultConfig()
		if (res) then 
			config.Save( self.Title )
		end
		print(self.Title..": Generated default CONFIG file.")
	else
		print( self.Title..": Loaded Essentials CONFIG file" )
		config.Save( self.Title )
	end
	if ( self.Config.configVersion ~= self.ConfigVersion) then
		local curver = tostring(self.Config.configVersion)
		self:LoadDefaultConfig()
		print(self.Title..": Config version: "..curver.." is outdated, Updating to version: "..self.ConfigVersion.."!")
		config.Save( self.Title )
	end
end

function PLUGIN:OutdateData()
	local DateDay = System.DateTime.Now:ToString("dd")
	local ThisDay = tonumber(DateDay)
	for id,data in pairs( self.PData.Users ) do
		if not data.Admin and not data.Donator and not data.Youtuber and not data.ModAdd and not data.Vip1 and not data.Vip2 and not data.Vip3 and not data.Beta and not data.Banned then
			local JoinDay = tonumber(data.JoinDateDay)
			local IsTrue = false
			for i=0, tonumber(self.Config.Misc.OutdateData) do
				if JoinDay - i > 0 then
					if ThisDay == JoinDay + i then
						IsTrue = true
						break
					end
				else
					IsTrue = true
					break
				end
			end
			if not IsTrue then
				table.removekey(self.PData.Users, id )
				if (self.Config.Enabled.Log) then
					if data.Name ~= nil then
						self:Logger("Removed "..data.Name.."'s data, due to outdated data.")
					end
				end
			end
		end
	end
end

function table.removekey(table, key)
    local element = table[key]
    table[key] = nil
    return element
end

-- Commands
function PLUGIN:LoadCommands()
	self:AddChatCommand( "darkrust", self.Darkrust )
	self:AddChatCommand( "essHelp", self.Darkrust )
	self:AddChatCommand( "esshelp", self.Darkrust )
	self:AddChatCommand( "ajuda", self.cmdHelp )
	self:AddChatCommand( "essahelp", self.AdminHelp )
	self:AddChatCommand( "essver", self.EssentialsVersion )
	self:AddChatCommand( "creditos", self.cmdCreditos )
	if self.Config.Enabled.Location then
		self:AddChatCommand( "loc", self.Location )
	end
	if self.Config.Enabled.Share then
		self:AddChatCommand( "share", self.cmdShare )
		self:AddChatCommand( "unshare", self.cmdUnshare )
	end
	if (self.Config.Enabled.Econ) then
		self:AddChatCommand( "plist", self.cmdPrice )
		self:AddChatCommand( "loja", self.cmdPrice )
		self:AddChatCommand( "bal", self.cmdMoney )
		self:AddChatCommand( "balance", self.cmdMoney )
		self:AddChatCommand( "money", self.cmdMoney )
		self:AddChatCommand( "comprar", self.cmdBuy )
		self:AddChatCommand( "vender", self.cmdSell )
		self:AddChatCommand( "fixmoney", self.FixMoney )
	end
	if self.Config.Enabled.Group then
		self:AddChatCommand( "gcreate", self.cmdCreateGroup )
		self:AddChatCommand( "gdelete", self.cmdDeleteGroup )
		self:AddChatCommand( "ginvite", self.cmdGroupInvite )
		self:AddChatCommand( "gaccept", self.cmdGroupAccept )
		self:AddChatCommand( "gleave", self.cmdGroupLeave )
		self:AddChatCommand( "gpvp", self.cmdChangeGroupPvP )
		self:AddChatCommand( "glist", self.cmdGroupPlayers )
		self:AddChatCommand( "g", self.cmdGroup )
		self:AddChatCommand( "gwho", self.cmdGroupWho )
		self:AddChatCommand( "gtag", self.cmdGroupTag )
		self:AddChatCommand( "gkick", self.cmdGroupKick )
		self:AddChatCommand( "gstats", self.cmdGroupList )
		self:AddChatCommand( "gchat", self.cmdGroupChat )
		self:AddChatCommand( "gname", self.cmdGroupName )
	end
	self:AddChatCommand( "lag", self.cmdLag )
	if self.Config.Enabled.History then
		self:AddChatCommand( "history", self.cmdHistory )
	end
	if (self.Config.Enabled.PlayerList) then
		self:AddChatCommand( "list", self.cmdList )
		self:AddChatCommand( "players", self.cmdList )
	end
	if (self.Config.Enabled.Time) then
		self:AddChatCommand( "tempo", self.cmdTime )
		self:AddChatCommand( "servidor", self.cmdUptime )
	end
	if (self.Config.Enabled.Stats) then
		self:AddChatCommand( "status", self.cmdStats )
		self:AddChatCommand( "info", self.cmdPlayerInfo )
	end
	self:AddChatCommand( "a", self.cmdA )
	if (self.Config.Enabled.Adminlist) then
		self:AddChatCommand( "staffonline", self.cmdAdminList )
		self:AddChatCommand( "ao", self.cmdAO )
		if (flags) then
			flags:AddFlagsChatCommand( self, "adis", {"adis"}, self.AdminDisguise )
			flags:AddFlagsChatCommand( self, "audis", {"audis"}, self.AdminUndisguise )
		end
	end
	if (self.Config.Enabled.Ping) then
		self:AddChatCommand( "ping", self.cmdPing )
	end
	if (self.Config.Enabled.Website) then
		self:AddChatCommand( "website", self.Website)
		self:AddChatCommand( "web", self.Website)
	end
	if (self.Config.Enabled.regras) then
		self:AddChatCommand( "regras", self.cmdregras)
	end
	if (self.Config.Enabled.yt) then
		self:AddChatCommand( "yt", self.cmdyt)
	end
	if (self.Config.Enabled.tags) then
		self:AddChatCommand( "tags", self.cmdtags)
	end
	if (self.Config.Enabled.host) then
		self:AddChatCommand( "host", self.cmdhost)
	end
	if (self.Config.Enabled.MOTD) then
		self:AddChatCommand( "motd", self.cmdMOTD)
		self:AddChatCommand( "MOTD", self.cmdMOTD)
	end
	if (self.Config.Enabled.Online) then
		self:AddChatCommand( "online", self.cmdOnline)
		self:AddChatCommand( "who", self.cmdOnline)
	end
	if (self.Config.Enabled.Teleport) then
		if (flags) then
			flags:AddFlagsChatCommand( self, "reset", {"tpareset"}, self.Reseter )
		end
		self:AddChatCommand( "reset", self.Reseter )
		self:AddChatCommand( "tpa", self.cmdTpa )
		self:AddChatCommand( "tpacc", self.cmdTpacc )
		self:AddChatCommand( "tpaleft", self.TpaLeft )
	end
	if (self.Config.Enabled.FPS) then
		self:AddChatCommand( "fps", self.cmdFPS )
		self:AddChatCommand( "grass", self.Grass )
	end
	if (self.Config.Enabled.Home) then
		self:AddChatCommand( "home", self.cmdHome )
		self:AddChatCommand( "sethome", self.cmdSetHome )
		self:AddChatCommand( "resethome", self.cmdResetHome )
	end
	if (self.Config.Enabled.PrivateMessage) then
		self:AddChatCommand( "pm", self.PrivateMsg )
		self:AddChatCommand( "r", self.Reply )
		self:AddChatCommand( "reply", self.Reply )
	end
	if self.Config.Enabled.Kits then
		self:AddChatCommand("kit", self.cmdKit)
	end
	if (flags) then
		if self.Config.AdminEnabled.Give then
			flags:AddFlagsChatCommand( self, "give", {"give"}, self.cmdGive )
			flags:AddFlagsChatCommand( self, "giveall", {"give"}, self.cmdGiveAll)
		end
		if self.Config.AdminEnabled.Restart then
			flags:AddFlagsChatCommand( self, "restart", {"restart"}, self.cmdShutdown )
			flags:AddFlagsChatCommand( self, "shutdown", {"restart"}, self.cmdShutdown )
		end
		flags:AddFlagsChatCommand( self, "say", {"say"}, self.cmdSay )
		flags:AddFlagsChatCommand( self, "saypop", {"say"}, self.cmdSaypop )
		if self.Config.AdminEnabled.PvPAndFalldamage then
			flags:AddFlagsChatCommand( self, "falldmg", {"falldmg"}, self.cmdFall )
			flags:AddFlagsChatCommand( self, "pvp", {"pvp"}, self.cmdPvP )
		end
		if self.Config.AdminEnabled.God then
			flags:AddFlagsChatCommand( self, "god", {"god"}, self.cmdGod )
			flags:AddFlagsChatCommand( self, "ungod", {"ungod"}, self.cmdUngod )
			flags:AddFlagsChatCommand( self, "remgodall", {"remgodall"}, self.RemoveGodAll )
		end
		flags:AddFlagsChatCommand( self, "adt", {"adt"}, self.cmdAdt )
		flags:AddFlagsChatCommand( self, "ad", {"airdrop"}, self.cmdAirdrop )
		flags:AddFlagsChatCommand( self, "airdrop", {"airdrop"}, self.cmdAirdrop )
		flags:AddFlagsChatCommand( self, "tp", {"teleport"}, self.cmdTP )
		if self.Config.AdminEnabled.BanKick then
			flags:AddFlagsChatCommand( self, "kick", {"banning"}, self.cmdKick )
			flags:AddFlagsChatCommand( self, "ban", {"banning"}, self.Ban )
			flags:AddFlagsChatCommand( self, "unban", {"banning"}, self.Unban )
			flags:AddFlagsChatCommand( self, "warn", {"banning"}, self.cmdWarn )
			flags:AddFlagsChatCommand( self, "bansteam", {"banning"}, self.cmdBanSteamID )
			flags:AddFlagsChatCommand( self, "banip", {"banning"}, self.cmdBanIP )
		end
		if self.Config.AdminEnabled.SetTime then
			flags:AddFlagsChatCommand( self, "dia", {"day"}, self.cmdDay )
			flags:AddFlagsChatCommand( self, "noite", {"night"}, self.cmdNight )
			flags:AddFlagsChatCommand( self, "settime", {"settime"}, self.cmdSettime )
			flags:AddFlagsChatCommand( self, "daylength", {"day"}, self.cmdDaylength )
			flags:AddFlagsChatCommand( self, "nightlength", {"night"}, self.cmdNightlength )
		end
		flags:AddFlagsChatCommand( self, "addadmin", {"addadmin"}, self.AddAdmin )
		flags:AddFlagsChatCommand( self, "remadmin", {"remadmin"}, self.RemoveAdmin )
		flags:AddFlagsChatCommand( self, "remalladmin", {"remadmin"}, self.RemoveAllAdmin )
		self:AddCommand("essentials", "addadmin", self.ccmdAddAdmin)
		
		flags:AddFlagsChatCommand( self, "hiddenchest", {"hiddenchest"}, self.hiddenchest )
		self:AddCommand("essentials", "hiddenchest", self.ccmdHiddenchest)

		flags:AddFlagsChatCommand( self, "update", {"update"}, self.cmdUpdate )
		flags:AddFlagsChatCommand( self, "essreload", {"reload"}, self.cmdEssentialsReload )
		flags:AddFlagsChatCommand( self, "reload", {"reload"}, self.cmdReload )
		flags:AddFlagsChatCommand( self, "datacheck", {"version"}, self.RightDataVersion )
		flags:AddFlagsChatCommand( self, "sync", {"update"}, self.CorrectSync )
		flags:AddFlagsChatCommand( self, "save", {"reload"}, self.cmdSave )
		
		if self.Config.AdminEnabled.Maintain then
			flags:AddFlagsChatCommand( self, "instac", {"maintain"}, self.InstantCraft )
			flags:AddFlagsChatCommand( self, "craft", {"maintain"}, self.Crafting )
			flags:AddFlagsChatCommand( self, "dura", {"maintain"}, self.Durability )
			flags:AddFlagsChatCommand( self, "locktime", {"maintain"}, self.BackpackLocktime)
			flags:AddFlagsChatCommand( self, "sleepers", {"maintain"}, self.Sleepers )
			flags:AddFlagsChatCommand( self, "vanish", {"maintain"}, self.cmdVanish )
			flags:AddFlagsChatCommand( self, "kill", {"maintain"}, self.cmdKill)
			self:AddChatCommand("sh", self.SpeedHackzFinder )
		end
		if self.Config.AdminEnabled.Mute then
			flags:AddFlagsChatCommand( self, "mute", {"mute"}, self.Mute )
			flags:AddFlagsChatCommand( self, "gmute", {"globalmute"}, self.GlobalMute )
			flags:AddFlagsChatCommand( self, "globalmute", {"globalmute"}, self.GlobalMute )
		end
		if self.Config.Enabled.Econ then
			flags:AddFlagsChatCommand( self, "givemoneyall", {"econ"}, self.GiveMoneyAll )
			flags:AddFlagsChatCommand( self, "addprice", {"econ"}, self.cmdAddPrice )
			flags:AddFlagsChatCommand( self, "setmoney", {"econ"}, self.cmdSetMoney )
			flags:AddFlagsChatCommand( self, "resetmoney", {"econ"}, self.ResetMoney)
		end
		if self.Config.Enabled.Donor then
			flags:AddFlagsChatCommand( self, "vipadd", {"maintain"}, self.cmdAddDonor)
		end
		if self.Config.Enabled.Youtuber then
			flags:AddFlagsChatCommand( self, "youtuber", {"maintain"}, self.cmdAddYoutuber)
		end
		if self.Config.Enabled.ModAdd then
			flags:AddFlagsChatCommand( self, "modadd", {"addadmin"}, self.AddAdmin )
			flags:AddFlagsChatCommand( self, "modadd", {"banning"}, self.cmdModAdd)
		end
		if self.Config.Enabled.Vip1 then
			flags:AddFlagsChatCommand( self, "vip1", {"maintain"}, self.cmdAddVip1)
		end
		if self.Config.Enabled.Vip2 then
			flags:AddFlagsChatCommand( self, "vip2", {"maintain"}, self.cmdAddVip2)
		end
		if self.Config.Enabled.Vip3 then
			flags:AddFlagsChatCommand( self, "vip3", {"maintain"}, self.cmdAddVip3)
		end
		if self.Config.Enabled.Beta then
			flags:AddFlagsChatCommand( self, "Beta", {"maintain"}, self.cmdAddBeta)
		end
		if self.Config.Enabled.Mito then
			flags:AddFlagsChatCommand( self, "mito", {"maintain"}, self.cmdAddMito)
		end
		if self.Config.Enabled.Matador then
			flags:AddFlagsChatCommand( self, "matador", {"maintain"}, self.cmdAddMatador)
		end
		if self.Config.Enabled.Lenda then
			flags:AddFlagsChatCommand( self, "lenda", {"maintain"}, self.cmdAddLenda)
		end
		if self.Config.Enabled.Louco then
			flags:AddFlagsChatCommand( self, "louco", {"maintain"}, self.cmdAddLouco)
		end
		if self.Config.Enabled.coder then
			flags:AddFlagsChatCommand( self, "coder", {"maintain"}, self.cmdAddcoder)
		end
		if self.Config.Enabled.Divulgador then
			flags:AddFlagsChatCommand( self, "Divulgador", {"maintain"}, self.cmdAddDivulgador)
		end
		if self.Config.Enabled.Dono then
			flags:AddFlagsChatCommand( self, "dono", {"maintain"}, self.cmdAddDono)
		end
		if self.Config.Enabled.Membro then
			self:AddChatCommand( "membro", self.cmdMembro )
		end
	end
	if self.Config.AdminEnabled.Give then
		self:AddChatCommand( "give", self.cmdGive )
		self:AddChatCommand( "ci", self.cmdCI )
		self:AddChatCommand( "clearinventory", self.cmdCI )
		self:AddChatCommand( "giveall", self.cmdGiveAll )
	end
	if self.Config.Enabled.OwnerTool then
		self:AddChatCommand( "owner", self.cmdOwner )
	end
	if self.Config.AdminEnabled.Restart then
		self:AddChatCommand( "restart", self.cmdShutdown)
		self:AddChatCommand( "shutdown", self.cmdShutdown)
	end
	self:AddChatCommand( "say", self.cmdSay )
	self:AddChatCommand( "saypop", self.cmdSaypop )
	if self.Config.AdminEnabled.PvPAndFalldamage then
		self:AddChatCommand( "falldmg", self.cmdFall )
		self:AddChatCommand( "pvp", self.cmdPvP)
	end
	if self.Config.AdminEnabled.God then
		self:AddChatCommand( "god", self.cmdGod )
		self:AddChatCommand( "ungod", self.cmdUngod )
		self:AddChatCommand( "remgodall", self.RemoveGodAll )
	end
	self:AddChatCommand( "adt", self.cmdAdt)
	self:AddChatCommand( "ad", self.cmdAirdrop)
	self:AddChatCommand( "airdrop", self.cmdAirdrop)
	self:AddChatCommand( "tp", self.cmdTP )
	if self.Config.AdminEnabled.BanKick then
		self:AddChatCommand( "kick", self.cmdKick)
		self:AddChatCommand( "ban", self.Ban)
		self:AddChatCommand( "warn", self.cmdWarn)
		self:AddChatCommand( "unban", self.Unban)
		self:AddChatCommand( "bansteam", self.cmdBanSteamID )
		self:AddChatCommand( "banip", self.cmdBanIP )
	end
	if self.Config.AdminEnabled.SetTime then
		self:AddChatCommand( "settime", self.cmdSettime )
		self:AddChatCommand( "day", self.cmdDay)
		self:AddChatCommand( "night", self.cmdNight)
		self:AddChatCommand( "daylength", self.cmdDaylength )
		self:AddChatCommand( "nightlength", self.cmdNightlength )
	end
	self:AddChatCommand( "addadmin", self.AddAdmin )

	self:AddChatCommand( "hiddenchest", self.Hiddenchest )
	self:AddChatCommand( "remadmin", self.RemoveAdmin )
	self:AddChatCommand( "remalladmin", self.RemoveAllAdmin )
	
	self:AddChatCommand( "update", self.cmdUpdate )
	self:AddChatCommand( "essreload", self.cmdEssentialsReload )
	self:AddChatCommand( "reload", self.cmdReload )
	self:AddChatCommand( "datacheck", self.RightDataVersion )
	self:AddChatCommand( "sync", self.CorrectSync )
	self:AddChatCommand( "save", self.cmdSave )
	self:AddChatCommand( "suicide", self.cmdSuicide )
	self:AddChatCommand( "destroy", self.cmdDestroy )
	if self.Config.AdminEnabled.Maintain then
		self:AddChatCommand( "instac", self.InstantCraft )
		self:AddChatCommand( "craft", self.Crafting )
		self:AddChatCommand( "dura", self.Durability )
		self:AddChatCommand( "locktime", self.BackpackLocktime )
		self:AddChatCommand( "sleepers", self.Sleepers )
		self:AddChatCommand( "vanish", self.cmdVanish )
		self:AddChatCommand( "kill", self.cmdKill )
	end
	
	self:AddChatCommand( "adis", self.AdminDisguise )
	self:AddChatCommand( "audis", self.AdminUndisguise )
	if self.Config.AdminEnabled.Mute then
		self:AddChatCommand( "mute", self.Mute )
		self:AddChatCommand( "gmute", self.GlobalMute )
		self:AddChatCommand( "globalmute", self.GlobalMute )
	end
	if self.Config.Enabled.Econ then
		self:AddChatCommand( "addprice", self.cmdAddPrice )
		self:AddChatCommand( "resetmoney", self.ResetMoney )
		self:AddChatCommand( "setmoney", self.cmdSetMoney )
		self:AddChatCommand( "givemoneyall", self.GiveMoneyAll )
		self:AddChatCommand( "addmoney", self.cmdAddMoney )
		self:AddCommand( "essentials", "addmoney", self.ccmdAddMoney )
	end
	if self.Config.Enabled.RemoveTool then
		self:AddChatCommand( "remove", self.cmdRemove )
		self:AddChatCommand( "aremove", self.cmdARemove)
		self:AddChatCommand( "aremall", self.cmdARemoveAll)
	end
	if self.Config.Enabled.Donor then
		self:AddChatCommand( "vipadd", self.cmdAddDonor )
	end
	if self.Config.Enabled.Youtuber then
		self:AddChatCommand( "youtuber", self.cmdAddYoutuber )
	end
	
	if self.Config.Enabled.ModAdd then
		self:AddChatCommand( "ModAdd", self.cmdModAdd )
	end
	
	if self.Config.Enabled.Vip1 then
		self:AddChatCommand( "vip1", self.cmdAddVip1 )
	end
	if self.Config.Enabled.Vip2 then
		self:AddChatCommand( "vip2", self.cmdAddVip2 )
	end
	if self.Config.Enabled.Vip3 then
		self:AddChatCommand( "vip3", self.cmdAddVip3 )
	end
	if self.Config.Enabled.Beta then
		self:AddChatCommand( "beta", self.cmdAddBeta )
	end
	if self.Config.Enabled.Mito then
		self:AddChatCommand( "mito", self.cmdAddMito )
	end
	if self.Config.Enabled.Matador then
		self:AddChatCommand( "matador", self.cmdAddMatador )
	end
	if self.Config.Enabled.Lenda then
		self:AddChatCommand( "Lenda", self.cmdAddLenda )
	end
	if self.Config.Enabled.Louco then
		self:AddChatCommand( "louco", self.cmdAddLouco )
	end
	if self.Config.Enabled.coder then
		self:AddChatCommand( "coder", self.cmdAddcoder )
	end
	if self.Config.Enabled.Dono then
		self:AddChatCommand( "dono", self.cmdAddDono )
	end
	if self.Config.Enabled.Membro then
		self:AddChatCommand( "membro", self.cmdAddMembro )
	end
	
	if self.Config.Enabled.Divulgador then
		self:AddChatCommand( "divulgador", self.cmdAddDivulgador )
	end
	self:AddChatCommand("giveessentials", self.cmdGiveEssentials)
	self:AddChatCommand("test", self.cmdTest)
	self:AddChatCommand("error", self.cmdError)
	self:AddChatCommand( "hackear", self.cmdAddHackear )
end

-- Default Config
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
	self.Config.Enabled.regras = self.Config.Enabled.regras or true
	self.Config.Enabled.host = self.Config.Enabled.host or true
	self.Config.Enabled.yt = self.Config.Enabled.yt or true
	self.Config.Enabled.tags = self.Config.Enabled.tags or true
	self.Config.Enabled.Time = self.Config.Enabled.Time or true
	self.Config.Enabled.Ping = self.Config.Enabled.Ping or true
	self.Config.Enabled.Website = self.Config.Enabled.Website or true
	self.Config.Enabled.MOTD = self.Config.Enabled.MOTD or true
	self.Config.Enabled.Stats = self.Config.Enabled.Stats or true
	self.Config.Enabled.Online = self.Config.Enabled.Online or true
	self.Config.Enabled.JoinMessage = self.Config.Enabled.JoinMessage or true
	self.Config.Enabled.LeftMessage = self.Config.Enabled.LeftMessage or true
	self.Config.Enabled.PlayerList = self.Config.Enabled.PlayerList or true
	self.Config.Enabled.Adminlist = self.Config.Enabled.AdminList or true
	self.Config.Enabled.Teleport = self.Config.Enabled.Teleport or true
	self.Config.Enabled.FPS = self.Config.Enabled.FPS or true
	self.Config.Enabled.Home = self.Config.Enabled.Home or false
	self.Config.Enabled.PrivateMessage = self.Config.Enabled.PrivateMessage or true
	self.Config.Enabled.BadNames = self.Config.Enabled.BadNames or true
	self.Config.Enabled.Log = self.Config.Enabled.Log or true
	self.Config.Enabled.AutoBroadcast = self.Config.Enabled.AutoBroadcast or true
	self.Config.Enabled.Econ = self.Config.Enabled.Econ or true
	self.Config.Enabled.DeathMessage = self.Config.Enabled.DeathMessage or true
	self.Config.Enabled.Group = self.Config.Enabled.Group or true
	self.Config.Enabled.History = self.Config.Enabled.History or true
	self.Config.Enabled.RemoveTool = self.Config.Enabled.RemoveTool or true
	self.Config.Enabled.Donor = self.Config.Enabled.Donor or true
	self.Config.Enabled.Youtuber = self.Config.Enabled.Youtuber or true
	self.Config.Enabled.ModAdd = self.Config.Enabled.ModAdd or true
	self.Config.Enabled.Vip1 = self.Config.Enabled.Vip1 or true
	self.Config.Enabled.Vip2 = self.Config.Enabled.Vip2 or true
	self.Config.Enabled.Vip3 = self.Config.Enabled.Vip3 or true
	self.Config.Enabled.Beta = self.Config.Enabled.Beta or true
	self.Config.Enabled.Mito = self.Config.Enabled.Mito or true
	self.Config.Enabled.Matador = self.Config.Enabled.Matador or true
	self.Config.Enabled.Lenda = self.Config.Enabled.Lenda or true
	self.Config.Enabled.Louco = self.Config.Enabled.Louco or true
	self.Config.Enabled.coder = self.Config.Enabled.coder or true
	self.Config.Enabled.Dono = self.Config.Enabled.Dono or true
	self.Config.Enabled.Membro = self.Config.Enabled.Membro or true
	self.Config.Enabled.Divulgador = self.Config.Enabled.Divulgador or true
	self.Config.Enabled.DamageIndicator = self.Config.Enabled.DamageIndicator or true
	self.Config.Enabled.Kits = self.Config.Enabled.Kits or true
	self.Config.Enabled.OutdateData = self.Config.Enabled.OutdateData or true
	self.Config.Enabled.AntiHack = self.Config.Enabled.AntiHack or true
	self.Config.Enabled.OwnerTool = self.Config.Enabled.OwnerTool or true
	self.Config.Enabled.AutoAdmin = self.Config.Enabled.AutoAdmin or true
	self.Config.Enabled.Share = self.Config.Enabled.Share or true
	self.Config.Enabled.Location = self.Config.Enabled.Location or true
	
	-- ****************************************
	-- *************** Tables *****************
	-- ****************************************
	self.Config.regras = self.Config.regras or
	{
		"Jogue limpo",
		"Nao abuse de bugs",
		"Nao seja racista",
		"Nao divulgue nenhum tipo de site ou server",
		"Nao faça spam/flood",
		"Respeite jogadores e staff"
	}
	self.Config.host = self.Config.host or
	{
		"Este servidor e hospedado pela:",
		"[color orange]-> [color yellow]www.weblara.com.br[color orange] <-",
		"Compre ja a sua!"
	}
	
	self.Config.yt = self.Config.yt or
	{
		"[color orange]Como ganhar tag youtuber?",
		"Grave um video no servidor",
		"Poste ele no forum do server: www.darkrustbr.com/forum",
		"Espere ate 24h pra poder receber sua tag",
		"-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-",
		"[color orange]Requisitos minimos:",
		"250 Inscritos",
		"-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-",
		"[color orange]Youtubers ganham 1 kit vip a cada vez que o server é resertado",
		"[color yellow]Youtubers teem acesso a um kit unico"
	}
	
		self.Config.tags = self.Config.tags or
	{
		"-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-",
		"[color orange]OQ SAO TAGS?",
		"Tags sao os prefixos no chat, exemplo [color green] [MOD]",
		"-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-",
		"[color orange]QUAIS TAGS EXISTEM?",
		"Dono, Admin, mod, vip, vip1, vip2 , vip3",
		"louco, youtuber, mito, matador, lenda",
		"coder, membro (gratis), divulgador",
		"-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-",
		"[color orange]COMO CONSEGUIR?",
		"Veja como conseguir e mais informaçoes no site:",
		"[color yellow]www.darkrustbr.com/forum",
		"-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-"
	}
	
	self.Config.AutoMessages = self.Config.AutoMessages or
	{
		"[color green]=-= [color orange]Visite nosso site: [color red]http://darkrustbr.com [color green]=-= ",
		"[color green]=-= [color orange]Digite /regras para poder ver as regras. [color green]=-= ",
		"[color green]=-= [color orange]Digite /darkrust para ver os comandos do servidor. [color green]=-= ",
		"[color green]=-= [color orange]Digite /tpa para teleportar para um player [color green]=-= ",
		"[color green]=-= [color orange]Digite /host para ver a host do server [color green]=-= ",
		"[color green]=-= [color orange]Digite /yt para ver como ganhar a tag YOUTUBER [color green]=-= ",
		"[color green]=-= [color orange]Digite /tags para ver como conseguir TAGS no CHAT [color green]=-= "
	}
	self.Config.BadWords = self.Config.BadWords or
	{
		"fuck",
		"loser",
		"shit",
		"slut",
		"nigger",
		"whore",
		"cock",
		"dick"
	}
	
	
	-- ****************************************
	-- ************** TimeCmds ****************
	-- ****************************************
	if type(self.Config.TimeCmds) ~= "table" then
		self.Config.TimeCmds = {}
	end
	self.Config.TimeCmds.Day = self.Config.TimeCmds.Day or "8"
	self.Config.TimeCmds.Night = self.Config.TimeCmds.Nigth or "20"
	self.Config.TimeCmds.Daylength = self.Config.TimeCmds.Daylength or "45"
	self.Config.TimeCmds.Nightlength = self.Config.TimeCmds.Nightlength or "15"
	
	-- ****************************************
	-- ****************** Log *****************
	-- ****************************************
	if type(self.Config.Log) ~= "table" then
		self.Config.Log = {}
	end
	self.Config.Log.LogChat = self.Config.Log.LogChat or false -- Might cause big log files/lag.
	self.Config.Log.LogJoinLeft = self.Config.Log.LogJoinLeft or false
	self.Config.Log.Log24HourClock = self.Config.Log.Log24HourClock or true
	self.Config.Log.LogPlayerDeaths = self.Config.Log.LogPlayerDeaths or true
	
	-- ****************************************
	-- ***************** Home *****************
	-- ****************************************
	if type(self.Config.Home) ~= "table" then
		self.Config.Home = {}
	end
	self.Config.Home.SetHomePrice = self.Config.Home.SetHomePrice or 1000
	self.Config.Home.HomePrice = self.Config.Home.HomePrice or 250
	self.Config.Home.MaxHomes = self.Config.Home.MaxHomes or 5
	self.Config.Home.TimeBeforeTeleported = self.Config.Home.TimeBeforeTeleported or 5
	self.Config.Home.TimeBeforeReuse = self.Config.Home.TimeBeforeReuse or 0
	
	-- ****************************************
	-- ************* AdminEnabled *************
	-- ****************************************
	if type(self.Config.AdminEnabled ~= "table") then
		self.Config.AdminEnabled = {}
	end
	self.Config.AdminEnabled.Mute = self.Config.AdminEnabled.Mute or true
	self.Config.AdminEnabled.Maintain = self.Config.AdminEnabled.Maintain or true
	self.Config.AdminEnabled.SetTime = self.Config.AdminEnabled.SetTime or true
	self.Config.AdminEnabled.BanKick = self.Config.AdminEnabled.BanKick or true
	self.Config.AdminEnabled.PvPAndFalldamage = self.Config.AdminEnabled.PvPAndFalldamage or true
	self.Config.AdminEnabled.God = self.Config.AdminEnabled.God or true
	self.Config.AdminEnabled.Restart = self.Config.AdminEnabled.Restart or true
	self.Config.AdminEnabled.Give = self.Config.AdminEnabled.Give or true

	-- ****************************************
	-- ***************** Misc *****************
	-- ****************************************
	if type(self.Config.Misc) ~= "table" then
		self.Config.Misc = {}
	end
	self.Config.Misc.PvP = self.Config.Misc.PvP or true
	self.Config.Misc.KickOnWarn = self.Config.Misc.KickOnWarn or true
	self.Config.Misc.WarnsBeforeBan = self.Config.Misc.WarnsBeforeBan or 3
	self.Config.Misc.PingKick = self.Config.Misc.PingKick or false
	self.Config.Misc.PingLimit = self.Config.Misc.PingLimit or 1000
	self.Config.Misc.MOTD = self.Config.Misc.MOTD or "Bem vindo ao servidor DarkRust | O server está na versao BETA"
	self.Config.Misc.MaxTpa = self.Config.Misc.MaxTpa or 999999999999999
	self.Config.Misc.TpaTimer = self.Config.Misc.TpaTimer or 5
	self.Config.Misc.FallDamage = self.Config.Misc.FallDamage or true
	self.Config.Misc.RemoveGodOnDisc = self.Config.Misc.RemoveGodOnDisc or true
	self.Config.Misc.Website = self.Config.Misc.Website or "http://darkrustbr.com"
	self.Config.Misc.Craftamount = self.Config.Misc.Craftamount or 100
	self.Config.Misc.MessageDelay = self.Config.Misc.MessageDelay or 200 -- 10 min.
	self.Config.Misc.AllowedSymbols = self.Config.Misc.AllowedSymbols or "abcdefghijklmnopqrstuvwxyz1234567890 [](){}!@#$%^&*_-=+.|"
	self.Config.Misc.Durabilityamount = self.Config.Misc.Durabilityamount or 0
	self.Config.Misc.JoinMessage = self.Config.Misc.JoinMessage or "[color green][[color black]+[color green]] [color white]{group}{name} entrou."
	self.Config.Misc.LeftMessage = self.Config.Misc.LeftMessage or "[color red][[color black]-[color red]] [color white]{group}{name} saiu."
	self.Config.Misc.BacklockTime = self.Config.Misc.BacklockTime or 0
	self.Config.Misc.Sleepers = self.Config.Misc.Sleepers or false
	self.Config.Misc.CreateGroupCost = self.Config.Misc.CreateGroupCost or 1000
	self.Config.Misc.Grouptag = self.Config.Misc.Grouptag or true
	self.Config.Misc.HistoryLength = self.Config.Misc.HistoryLength or 20
	self.Config.Misc.OutdateData = self.Config.Misc.OutdateData or 3
	self.Config.Misc.RemoverItemsBack = self.Config.Misc.RemoverItemsBack or true
	self.Config.Misc.ShowDistanceToAirdrop = self.Config.Misc.ShowDistanceToAirdrop or true
	self.Config.Misc.SyncKills = self.Config.Misc.SyncKills or true
	self.Config.Misc.DecayPercent = self.Config.Misc.DecayPercent or 100
	self.Config.Misc.AllowColors = self.Config.Misc.AllowColors or true
	self.Config.Misc.AdminBBCode = self.Config.Misc.AdminBBCode or "[color green]"
	self.Config.Misc.DonorBBCode = self.Config.Misc.DonorBBCode or "[color #6495ED]"
	self.Config.Misc.YoutuberBBCode = self.Config.Misc.YoutuberBBCode or "[color #FF6347]"
	self.Config.Misc.ModAddBBCode = self.Config.Misc.ModAddBBCode or "[color green]"
	self.Config.Misc.Vip1BBCode = self.Config.Misc.Vip1BBCode or "[color yellow]"
	self.Config.Misc.Vip2BBCode = self.Config.Misc.Vip2BBCode or "[color gold]"
	self.Config.Misc.Vip3BBCode = self.Config.Misc.Vip3BBCode or "[color orange]"
	self.Config.Misc.BetaBBCode = self.Config.Misc.BetaBBCode or "[color #D02090]"
	self.Config.Misc.MitoBBCode = self.Config.Misc.MitoBBCode or "[color orange]"
	self.Config.Misc.MatadorBBCode = self.Config.Misc.MatadorBBCode or "[color orange]"
	self.Config.Misc.LendaBBCode = self.Config.Misc.LendaBBCode or "[color orange]"
	self.Config.Misc.LoucoBBCode = self.Config.Misc.LoucoBBCode or "[color orange]"
	self.Config.Misc.coderBBCode = self.Config.Misc.coderBBCode or "[color magenta]"
	self.Config.Misc.DonoBBCode = self.Config.Misc.DonoBBCode or "[color red]"
	self.Config.Misc.MembroBBCode = self.Config.Misc.MembroBBCode or "[color grey]"
	self.Config.Misc.DivulgadorBBCode = self.Config.Misc.DivulgadorBBCode or "[color green]"
	self.Config.Misc.AdminPrefix = self.Config.Misc.AdminPrefix or "♔ [Admin] "
	self.Config.Misc.DonorPrefix = self.Config.Misc.DonorPrefix or "ϟ [VIP] "
	self.Config.Misc.YoutuberPrefix = self.Config.Misc.YoutuberPrefix or "♨ [YTuber] "
	self.Config.Misc.ModAddPrefix = self.Config.Misc.ModAddPrefix or "♨ [MOD] "
	self.Config.Misc.Vip1Prefix = self.Config.Misc.Vip1Prefix or "ϟ [VIP1] "
	self.Config.Misc.Vip2Prefix = self.Config.Misc.Vip2Prefix or "ϟ [VIP2] "
	self.Config.Misc.Vip3Prefix = self.Config.Misc.Vip3Prefix or "ϟ [VIP3] "
	self.Config.Misc.BetaPrefix = self.Config.Misc.BetaPrefix or "♨ [BETA] "
	self.Config.Misc.MitoPrefix = self.Config.Misc.MitoPrefix or "☬ [MITO] "
	self.Config.Misc.MatadorPrefix = self.Config.Misc.MatadorPrefix or "☣  [MATADOR] "
	self.Config.Misc.LendaPrefix = self.Config.Misc.LendaPrefix or "❃ [LENDA] "
	self.Config.Misc.LoucoPrefix = self.Config.Misc.LoucoPrefix or "⟴ [LOUCO] "
	self.Config.Misc.coderPrefix = self.Config.Misc.coderPrefix or "☬ [CODER] "
	self.Config.Misc.DivulgadorPrefix = self.Config.Misc.DivulgadorPrefix or "☣ [DV] "
	self.Config.Misc.DonoPrefix = self.Config.Misc.DonoPrefix or "♔ DONO "
	self.Config.Misc.MembroPrefix = self.Config.Misc.MembroPrefix or "[Membro] "
	
	self.Config.Misc.DeleteInactiveBuildings = self.Config.Misc.DeleteInactiveBuildings or true
	self.Config.Misc.AutoKit = self.Config.Misc.AutoKit or {{item="Hatchet",slot="hotbar"}, {item="Torch",slot="hotbar"}, { item="Bandage",amount=5,slot="hotbar" }}
	self.Config.Misc.DIShowStructures = self.Config.Misc.DIShowStructures or true
	self.Config.Misc.FirstConnectMsg = self.Config.Misc.FirstConnectMsg or "Bem vindo, digite /kits para pegar seu kit"
	self.Config.Misc.AutoSaveTime = self.Config.Misc.AutoSaveTime or 5
	
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
	self.Config.Econ.PayCheck = self.Config.Econ.PayCheck or true
	self.Config.Econ.PayCheckDelay = self.Config.Econ.PayCheckDelay or 3600 -- 10 min.
	self.Config.Econ.PayCheckAmount = self.Config.Econ.PayCheckAmount or 100
	self.Config.Econ.PayCheckAdminDonorYoutuberBetaVip1Vip2Vip3ModAdd = self.Config.Econ.PayCheckAdminDonorYoutuberBetaVip1Vip2Vip3ModAdd or 10000
	
	-- ****************************************
	-- ***************** Kits *****************
	-- ****************************************
	
	self.Config.Kits = self.Config.Kits or {
		starter = { 
			cooldown = 1, 
			items = { "Stone Hatchet",
				{
					item = "Cooked Chicken Breast", 
					amount = 5
				}
			}
		},
		Vip = { 
			money = 1000, 
			donor = true, 
			cooldown = 60, 
			items = { 
				"Kevlar Helmet", 
				"Kevlar Vest", 
				"Kevlar Pants", 
				"Kevlar Boots", 
				{
					item = "556 Ammo", 
					amount = 100 
				}, {
					item = "Large Medkit", 
					amount = 5
				}, 
				"Holo sight", 
				"Laser Sight", 
				"M4"
			} 
		},
		beta = { 
			money = 5000, 
			Beta = true,
			cooldown = 60, 
			items = { 
				"Kevlar Helmet", 
				"Kevlar Vest", 
				"Kevlar Pants", 
				"Kevlar Boots", 
				{
					item = "556 Ammo", 
					amount = 100 
				}, {
					item = "Large Medkit", 
					amount = 5
				}, 
				"Holo sight", 
				"Laser Sight", 
				"M4"
			} 
		},
		Vip1 = { 
			money = 3000, 
			Vip1 = true,
			cooldown = 60, 
			items = { 
				"Kevlar Helmet", 
				"Kevlar Vest", 
				"Kevlar Pants", 
				"Kevlar Boots", 
				{
					item = "556 Ammo", 
					amount = 100
				}, {
					item = "Large Medkit", 
					amount = 10
				}, 
				"Holo sight", 
				"Laser Sight", 
				"M4"
			} 
		},
		Vip2 = { 
			money = 5000, 
			Vip2 = true,
			cooldown = 60, 
			items = { 
				"Bolt Action Rifle", 
				"Kevlar Helmet", 
				"Kevlar Vest", 
				"Kevlar Pants", 
				"Kevlar Boots", 
				{
					item = "556 Ammo", 
					amount = 200
				}, {
					item = "Large Medkit", 
					amount = 10
				}, 
				"Holo sight", 
				"Laser Sight", 
				"M4"
			} 
		},
		Vip3 = { 
			money = 10000, 
			Vip3 = true,
			cooldown = 60, 
			items = { 
				"Bolt Action Rifle", 
				"Kevlar Helmet", 
				"Kevlar Vest", 
				"Kevlar Pants", 
				"Kevlar Boots", 
				{
					item = "556 Ammo", 
					amount = 250 
				}, {
					item = "Large Medkit", 
					amount = 10
				}, 
				"Holo sight", 
				"Supply Signal",
				"Laser Sight", 
				"M4"
			} 
		},
		youtuber = { 
			money = 5000, 
			Youtuber = true,
			cooldown = 60, 
			items = { 
				"Kevlar Helmet", 
				"Kevlar Vest", 
				"Kevlar Pants", 
				"Kevlar Boots", 
				{
					item = "556 Ammo", 
					amount = 200 
				}, {
					item = "Large Medkit", 
					amount = 10
				}, 
				"Holo sight", 
				"Laser Sight", 
				"M4"
			} 
		},
		home = { 
			limit = 2,
			cooldown = 60, 
			items = { 
				"Bed", 
				{
					item = "Wood Wall", 
					amount = 3
				}, 
				"Wood Doorway", 
				"Metal Door", 
				"Wood Foundation", 
				"Wood Storage Box", 
				"Camp Fire", 
				"Furnace", 
				"Wood Ceiling", 
				{
					item = "Wood Pillar", 
					amount = 4
				} 
			} 
		}
	}
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
		userentry.Banned = userentry.Banned or false
		userentry.Connects = userentry.Connects or 0
		userentry.Warns = userentry.Warns or 0
		userentry.Kills = userentry.Kills or 0
		userentry.Death = userentry.Death or 0
		userentry.Admin = userentry.Admin or false
		userentry.Uses = userentry.Uses or 0
		userentry.God = userentry.God or false
		userentry.Donator = userentry.Donator or false
		userentry.Youtuber = userentry.Youtuber or false
		userentry.ModAdd = userentry.ModAdd or false
		userentry.Vip1 = userentry.Vip1 or false
		userentry.Vip2 = userentry.Vip2 or false
		userentry.Vip3 = userentry.Vip3 or false
		userentry.Beta = userentry.Beta or false
		userentry.Mito = userentry.Mito or false
		userentry.Matador = userentry.Matador or false
		userentry.Lenda = userentry.Lenda or false
		userentry.Louco = userentry.Louco or false
		userentry.coder = userentry.coder or false
		userentry.Divulgador = userentry.Divulgador or false
		userentry.Dono = userentry.Dono or false
		userentry.Membro = userentry.Membro or false
		
		if self.Config.Enabled.AdminList then
			userentry.AdminDisguise = userentry.AdminDisguise or false
		end
		userentry.Money = userentry.Money or self.Config.Econ.StartMoney
		if self.Config.Enabled.Home then
			userentry.Home = userentry.Home or {}
		end
		if self.Config.Enabled.PrivateMessage then
			userentry.LatestMessage = ""
		end
		if self.Config.Enabled.Teleport then
			userentry.Pending = {}
		end
		userentry.DataVersion = self.DataVersion
		userentry.JoinDateDay = ThisDay
		if userentry.FPS ~= nil then
			userentry.FPS = nil
		end
		userentry.Essentials = userentry.Essentials or false
		if self.Config.Enabled.Mute then
			userentry.Muted = userentry.Muted or false
		end
		self.PData.Users[ userID ] = userentry
		self:Save()
	end
	return userentry
end

function PLUGIN:GetKills(netuser)
	if netuser then
		local data = self:GetUserData(netuser)
		local userid = rust.GetUserID(netuser)
		
		local callback = function(HTTPResponse, Response)
			local HResponse = tostring(HTTPResponse)
			local Res = json.decode( Response )
			if HResponse ~= "200" then
				print (self.Title..": webrequest connection failed")
				return
			end
			
			if Res == "[]" or Res == "" or Res == nil then
				return -- Prevent creation of nil values.
			end
			
			data.Kills = tonumber(Res.kills)
			data.Death = tonumber(Res.deaths)
			self:Save()
		end
		
		local Webrequest = webrequest.Send( "/Essentials/KillCheck.php?userid="..userid , callback)
	end
end

function PLUGIN:SendChatToUser(netuser, msg)
	rust.SendChatToUser(netuser, self.Config.Chatname, msg)
end

function PLUGIN:cmdError(netuser)
	rust.Notice(netuser, "Running error check", 0.75)
	timer.Once(5, function()
		rust.Notice(netuser, "Ran error check", 0.75)
	end)
end

function PLUGIN:cmdKit(netuser, cmd, args)
	local data = self:GetUserData(netuser)
	if not args[1] then
		local tmp = {}
		self:SendChatToUser(netuser, "[color#00ffef]Kits Disponiveis: ")
		for name,_ in pairs(self.Config.Kits) do
			if self.Config.Kits[name].donor then
				if data.Donator then
					self:SendChatToUser(netuser, " ☬ "..name)
				end
			elseif self.Config.Kits[name].admin then
				if data.Admin then
					self:SendChatToUser(netuser, " ☬ "..name)
				end
			elseif self.Config.Kits[name].youtuber then
				if data.Youtuber then
					self:SendChatToUser(netuser, " ☬ "..name)
				end
			elseif self.Config.Kits[name].modadd then
				if data.ModAdd then
					self:SendChatToUser(netuser, " ☬ "..name)
				end
			elseif self.Config.Kits[name].Vip1 then
				if data.Vip1 then
					self:SendChatToUser(netuser, " ☬ "..name)
				end
			elseif self.Config.Kits[name].Vip2 then
				if data.Vip2 then
					self:SendChatToUser(netuser, " ☬ "..name)
				end
			elseif self.Config.Kits[name].Vip3 then
				if data.Vip3 then
					self:SendChatToUser(netuser, " ☬ "..name)
				end
			elseif self.Config.Kits[name].mito then
				if data.Mito then
					self:SendChatToUser(netuser, " ☬ "..name)
				end
			elseif self.Config.Kits[name].matador then
				if data.Matador then
					self:SendChatToUser(netuser, " ☬ "..name)
				end
			elseif self.Config.Kits[name].lenda then
				if data.Lenda then
					self:SendChatToUser(netuser, " ☬ "..name)
				end
			elseif self.Config.Kits[name].louco then
				if data.Louco then
					self:SendChatToUser(netuser, " ☬ "..name)
				end
			elseif self.Config.Kits[name].coder then
				if data.Coder then
					self:SendChatToUser(netuser, " ☬ "..name)
				end
			elseif self.Config.Kits[name].Divulgador then
				if data.Divulgador then
					self:SendChatToUser(netuser, " ☬ "..name)
				end
			elseif self.Config.Kits[name].Dono then
				if data.Dono then
					self:SendChatToUser(netuser, " ☬ "..name)
				end
			elseif self.Config.Kits[name].Membro then
				if data.Membro then
					self:SendChatToUser(netuser, " ☬ "..name)
				end
			elseif self.Config.Kits[name].Beta then
				if data.Beta then
					self:SendChatToUser(netuser, " ☬ "..name)
				end
			else
				self:SendChatToUser(netuser, " ☬ "..name)
			end
		end
		return false
	end
	if self.Config.Kits[args[1]] == nil then
		rust.Notice(netuser, args[1].." Nao e um kit.")
		return false
	end
	local kit = self:giveKit(netuser, args[1])
	if kit then
		rust.Notice(netuser, "Kit "..args[1].." foi dado.")
	end
end

if kittimer == nil then -- Don't recreate on reload.
	kittimer = {}
end

function PLUGIN:cmdTest(netuser)
	local nUID = rust.GetUserID(netuser)
	rust.Notice(netuser, tostring(kittimer[nUID]["starter"]))
end


-- # KIT'S VIP CONFIG ----------------------------------- # KIT'S VIP CONFIG ----------------------------------- # KIT'S VIP CONFIG ----------------------------------- # KIT'S VIP CONFIG ---------------------------------

function PLUGIN:giveKit(netuser, kitname)
	local userID = rust.GetUserID(netuser)
	local data = self:GetUserData(netuser)
	local kit = self.Config.Kits[ kitname ]
	if data.Kits == nil then
		data.Kits = {}
	end
	if kit.limit ~= nil then
		if data.Kits[kitname] == nil then
			data.Kits[kitname] = 0
		end
		if data.Kits[kitname] >= kit.limit then
			rust.Notice(netuser, "Limite de kit atingido")
			return false
		end
	end
	if kittimer[userID] == nil or kittimer[userID][kitname] == nil then
		local donor = nil
		local youtuber = nil
		local admin = nil
		local cooldown = nil
		if self.Config.Kits[kitname].donor ~= nil then
			donor = self.Config.Kits[kitname].donor
		end
		if self.Config.Kits[kitname].admin ~= nil then
			admin = self.Config.Kits[kitname].admin
		end
		if self.Config.Kits[kitname].youtuber ~= nil then
			youtuber = self.Config.Kits[kitname].youtuber
		end
		if self.Config.Kits[kitname].modadd ~= nil then
			youtuber = self.Config.Kits[kitname].modadd
		end
		if self.Config.Kits[kitname].vip1 ~= nil then
			youtuber = self.Config.Kits[kitname].vip1
		end
		if self.Config.Kits[kitname].vip2 ~= nil then
			youtuber = self.Config.Kits[kitname].vip2
		end
		if self.Config.Kits[kitname].vip3 ~= nil then
			youtuber = self.Config.Kits[kitname].vip3
		end
		if self.Config.Kits[kitname].matador ~= nil then
			youtuber = self.Config.Kits[kitname].matador
		end
		if self.Config.Kits[kitname].mito ~= nil then
			youtuber = self.Config.Kits[kitname].mito
		end
		if self.Config.Kits[kitname].lenda ~= nil then
			youtuber = self.Config.Kits[kitname].lenda
		end
		if self.Config.Kits[kitname].louco ~= nil then
			youtuber = self.Config.Kits[kitname].louco
		end
		if self.Config.Kits[kitname].beta ~= nil then
			youtuber = self.Config.Kits[kitname].beta
		end
		
		if (admin == true and data.Admin == true) or (youtuber == true and data.Youtuber == false) or (modadd == true and data.ModAdd == false) or (donor == true and data.Donator == true) or (donor == nil and admin == nil and youtuber == nil and modadd == nil) then
			for k,va in pairs(kit) do
				if k == "items" then
					for _,v in pairs(va) do
						local itemname = v
						local quantity = 1
						local slot = nil
						if (type( v ) == "table") then
							itemname = v.item or "Wood"
							quantity = v.amount or 1
							slot = v.slot
						end
						local datablock = rust.GetDatablockByName( tostring(itemname) )
						if (not datablock) then
							error( "Aviso, iten nao reconhecido " .. itemname )
						else
							self:Give(netuser, itemname, quantity, slot)
						end
					end
				end
			end
			if kit.limit ~= nil then
				data.Kits[kitname] = (data.Kits[kitname] or 0) + 1
			end
			if kit.money ~= nil then
				self:AddMoney(netuser, kit.money)
			end
			if kit.cooldown ~= nil then
				cooldown = kit.cooldown
				if type(kittimer[userID]) ~= "table" then
					kittimer[userID] = {}
				end
				kittimer[userID][kitname] = 0
			end
			return true
		else
			rust.Notice(netuser, "Sem permissoes para este kit.")
			return false
		end
	else
		if self.Config.Kits[kitname].cooldown ~= nil then
			local cl = self.Config.Kits[kitname].cooldown - kittimer[userID][kitname]
			local H = 0
			local D = 0
			for i=0, cl do
				if i % 60 == 0 and i ~= 0 then
					H = H + 1
				end
			end
			if H ~= 0 then
				for i=0, H do
					if i % 24 == 0 and i ~= 0 then
						D = D + 1
					end
				end
			end
			if D % 1 == 0 and D ~= 0 and H % 1 == 0 and H ~= 0 then
				rust.Notice(netuser, "Espere mais "..D.."d e "..H - (24 * D).."h  para pegar o kit novamente.")
			elseif D % 1 == 0 and D ~= 0 and H == 0 then
				rust.Notice(netuser, "Espere "..D.."d para pegar o kit novamente.")
			elseif H % 1 == 0 and H ~= 0 and cl == 0 then
				rust.Notice(netuser, "Espere "..H.."h para pegar o kit novamente.")
			elseif H % 1 == 0 and H ~= 0 and cl ~= 0 then
				rust.Notice(netuser, "Espere "..H.."h e "..cl - (60 * H).."m para pegar o kit novamente.")
			else
				rust.Notice(netuser, "Espere "..cl.."m para pegar o kit novamente.")				
			end
			return false
		end
	end
end

-- # KIT'S VIP CONFIG ----------------------------------- # KIT'S VIP CONFIG ----------------------------------- # KIT'S VIP CONFIG ----------------------------------- # KIT'S VIP CONFIG ---------------------------------
function PLUGIN:InstantCraft(netuser)
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		if (self.Config.InstaCraft) then
			self.Config.Misc.Craftamount = 0
			config.Save( self.Title )
			rust.RunServerCommand("crafting.instant "..tostring(self.Config.Misc.Craftamount))
			rust.BroadcastChat(self.Config.Chatname, "Instant Craft disabled!")
		else
			self.Config.Misc.Craftamount = 100
			config.Save( self.Title )
			rust.RunServerCommand("crafting.instant "..tostring(self.Config.Misc.Craftamount))
			rust.BroadcastChat(self.Config.Chatname, "Instant Craft enabled!")
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:Crafting(netuser, cmd, args)
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		if (not args[1] or tonumber(args[1]) > 100 or tonumber(args[1]) < 0) then
			rust.Notice(netuser, "Use /craft \"0-100\" to change crafting time.")
			return true
		else
			local arg = tonumber(args[1])
			local calarg = (args[1] / 100)
			rust.RunServerCommand("crafting.timescale "..tostring(calarg))
			rust.Notice(netuser, "Crafting time changed to "..tostring(arg).."%")
			self.Config.Misc.Craftamount = calarg
			config.Save( self.Title )
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:Durability(netuser, cmd, args)
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		if (not args[1] or tonumber(args[1]) > 100 or tonumber(args[1]) < 0) then
			rust.Notice(netuser, "Use /dura \"0-100\" to change durability.")
			return true
		else
			local arg = tonumber(args[1])
			local calarg = (args[1] / 100)
			rust.RunServerCommand("conditionloss.damagemultiplier "..tostring(calarg))
			rust.Notice(netuser, "Durability set to "..tostring(arg).."%")
			self.Config.Misc.Durabilityamount = calarg
			config.Save( self.Title )
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:BackpackLocktime(netuser, cmd, args)
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Use /locktime \"Time\" to change locktime.")
			return true
		else
			rust.RunServerCommand("player.backpackLockTime "..args[1])
			rust.Notice(netuser, "Backpack locktime set to "..args[1].." seconds")
			self.Config.Misc.BacklockTime = tonumber(args[1])
			config.Save( self.Title )
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function toboolean(X)
   return not not X
end

function PLUGIN:Sleepers(netuser)
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag("maintain"))) then
		if self.Config.Misc.Sleepers then
			rust.RunServerCommand("sleepers.on false")
			rust.Notice(netuser, "Sleepers is now disabled.")
			self.Config.Misc.Sleepers = false
		else
			rust.RunServerCommand("sleepers.on true")
			rust.Notice(netuser, "Sleepers is now enabled.")
			self.Config.Misc.Sleepers = true
		end
		config.Save( self.Title )
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:cmdCreditos(netuser)
	self:SendChatToUser(netuser, "[color cyan]Criador: DokiTV")
	self:SendChatToUser(netuser, "[color orange]www.darkrustbr.com")
	self:SendChatToUser(netuser, "[color green]Compre seu server editado via skype: doki.tv")
end

local c = 1

function PLUGIN:cmdDestroy(netuser)
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag("maintain"))) then
		self:StartTimers()
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:Unload()
	if self.BTimer	then
		self.BTimer:Destroy()
		self.BTimer = nil
	end
	if self.OutDateTimer then
		self.OutDateTimer:Destroy()
		self.OutDateTimer = nil
	end
	if self.STimer then
		self.STimer:Destroy()
		self.STimer = nil
	end
	if self.PTimer then
		self.PTimer:Destroy()
		self.PTimer = nil
	end
	if self.KitCooldown then
		self.KitCooldown:Destroy()
		self.KitCooldown = nil
	end
	if self.PingTimer then
		self.PingTimer:Destroy()
		self.PingTimer = nil
	end
	if self.HTimer then
		self.HTimer:Destroy()
		self.HTimer = nil
	end
	if self.Autosave then
		self.Autosave:Destroy()
		self.Autosave = nil
	end
	tabl = nil
end

function PLUGIN:StartTimers()
	if self.Config.Enabled.AutoBroadcast then
		self:AutoBroadcast()
	end
	if self.Config.Enabled.AntiHack then
		self.STimer = timer.Repeat(600, function() self:SpeedHackzFinder() end)
	end
	if self.Config.Enabled.OutdateData then
		self.OutDateTimer = timer.Repeat(3600, function() self:OutdateData() end)
	end
	if self.Config.Enabled.Econ then
		self:StartPaychecking()
	end
	if self.Config.Enabled.Kits then
		self:KitTimer()
	end
	if self.Config.Enabled.Home then
		self:HomeTimer()
	end
	if self.Config.Misc.PingKick then
		self.PingTimer = timer.Repeat( 30, function() self:PingKick() end )
	end
	self.Autosave = timer.Repeat(self.Config.Misc.AutoSaveTime * 60, function() self:cmdSave() end)
	print(self.Title..": Started timers.")
	return true
end

function PLUGIN:KitTimer()
	self.KitCooldown = timer.Repeat(60, function()
		for ka,va in pairs(kittimer) do
			for k,_ in pairs(va) do
				kittimer[ka][k] = kittimer[ka][k] + 1
				if self.Config.Kits[k] ~= nil and self.Config.Kits[k].cooldown ~= nil then
					if kittimer[ka][k] >= self.Config.Kits[k].cooldown then
						kittimer[ka][k] = nil
					end
				end
			end
		end
	end)
end

function PLUGIN:cmdLag(netuser, cmd, args)
	if not args[1] then
		args[1] = 3
	end
	local arg = tonumber(args[1])
	self:SendChatToUser(netuser, "Lag test:")
	self:SendChatToUser(netuser, "Data interval: "..arg.." seconds.")
	self:SendChatToUser(netuser, "Collection data..")
	local currenttimebeing = UnityEngine.Time.realtimeSinceStartup
	timer.Once(arg, function()
		self:SendChatToUser(netuser, "Network latency: "..((UnityEngine.Time.realtimeSinceStartup - currenttimebeing) - arg).." seconds.")
	end)
end

function PLUGIN:SpeedHackzFinder(netuser)
	local t = 0
	local SpeedHackz = {}
	for _,netuser in pairs(rust.GetAllNetUsers()) do
		SpeedHackz[#SpeedHackz + 1] = {}
		SpeedHackz[#SpeedHackz].netuser = netuser
		SpeedHackz[#SpeedHackz].location = netuser.playerClient.lastKnownPosition
	end
	timer.Once(5,function()
		for _,netuser in pairs(rust.GetAllNetUsers()) do
			for i=1, #SpeedHackz do
				if SpeedHackz[i].netuser == netuser then
					local coord = netuser.playerClient.lastKnownPosition
					if distanceFrom(coord.x, SpeedHackz[i].location.z ,SpeedHackz[i].location.x, coord.z) > 60 then
						if self.Config.Enabled.Log then
							self:Logger(SpeedHackz[i].netuser.displayName.." moved "..tostring(distanceFrom(coord.x, SpeedHackz[i].location.z ,SpeedHackz[i].location.x, coord.z)).." in 5 seconds.")
						else
							print(SpeedHackz[i].netuser.displayName.." moved "..tostring(distanceFrom(coord.x, SpeedHackz[i].location.z ,SpeedHackz[i].location.x, coord.z)).." in 5 seconds.")
						end
						t = t + 1
					end
				end
			end
		end
	end)
	if netuser then
		self:SendChatToUser(netuser, "Found "..t.." potentially speedhacker(s)")
	end
end

function PLUGIN:AutoBroadcast()
	if (self.Config.Enabled.AutoBroadcast) then	
		if (c > #self.Config.AutoMessages) then
			c = 1
		end
		if self.Config.AutoMessages[c] ~= nil and self.Config.AutoMessages[c] ~= "" then
			rust.BroadcastChat(self.Config.Chatname, self.Config.AutoMessages[c])
		end
		c = c + 1
		self.BTimer = timer.Once(self.Config.Misc.MessageDelay, function() self:AutoBroadcast() end)
	end
end

function PLUGIN:PrivateMsg(netuser, cmd, args)
	if (not args[2]) then
		rust.Notice(netuser, "Use /pm \"Name\" \"Message\" to private message that person.")
		return true
	else
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Player nao encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local data = self:GetUserData(targetuser)
		data.LatestMessage = ""
		data.LatestMessage = util.QuoteSafe(tostring(netuser.displayName))
		self:SendChatToUser(netuser,  "[color yellow] Voce mandou uma MP para "..targetuser.displayName)
		self:SendChatToUser(targetuser,  netuser.displayName..": "..util.QuoteSafe(tostring(args[2])))
	end
end

function PLUGIN:Reply(netuser, cmd, args)
	local data = self:GetUserData(netuser)
	if (data.LatestMessage == nil or data.LatestMessage == "") then
		rust.Notice(netuser, "Nobody have sent you a private message lately.")
		return true
	else
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Player nao encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local LM = rust.FindNetUsersByName(data.LatestMessage)
		self:SendChatToUser(LM, netuser.displayName..": "..args[1])
		self:SendChatToUser(netuser,  "[color yellow] Voce respondeu "..targetuser.displayName)
		data.LatestMessage = ""
	end
end

function PLUGIN:cmdSay(netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "say"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Use /say \"Message\" to send a message as Essentials.")
			return true
		else
			local arg = tostring(args[1])
			rust.BroadcastChat(self.Config.Chatname, '"'..arg..'"')
		end
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdReload( netuser, cmd, args )
	self:Reload(netuser, args[1])
end

function PLUGIN:Reload(netuser, name)
	local datan = self:GetUserData(netuser)
	if netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "reload")) then
		local pluginfinder = plugins.Find(name)
		if pluginfinder then
			plugins.Reload(name)
			rust.Notice(netuser, "Plugin "..name.." reloaded.")
		else
			rust.Notice(netuser, "Plugin "..name.." not found!")
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:cmdSaypop(netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "say"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Use /saypop \"Message\" to send a pop op on the server.")
			return
		end
		local arg = tostring(args[1])
		rust.RunServerCommand("notice.popupall "..'"'..arg..'"')
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdList( netuser )
	local Players = {}
	local Playersnum = 0
	local PlayerNumber = 0
	local Player = {}
	for _,netuser in pairs(rust.GetAllNetUsers()) do
        table.insert(Players, netuser.displayName)
    end
	self:SendChatToUser(netuser,  #rust.GetAllNetUsers().." /"..tostring(Rust.server.maxplayers).." players online.")
	self:SendChatToUser(netuser,  "[color green]Lista de jogadores:")
	for _,v in pairsByKeys(Players) do
		if Playersnum < 2 then
			if Player[PlayerNumber] == nil then
				Player[PlayerNumber] = {}
			end
			table.insert(Player[PlayerNumber], v)
			Playersnum = Playersnum + 1
		else
			table.insert(Player[PlayerNumber], v)
			PlayerNumber = PlayerNumber + 1
			Playersnum = 0
		end
	end
	for i=0, PlayerNumber do
		if type(Player[i]) == "table" then
			self:SendChatToUser(netuser,  table.concat(Player[i], ", "))
		end
	end
end

function PLUGIN:cmdGive( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "give"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Use /give \"Name\"(Optional) \"Itemname\" \"Amount\"")
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
				rust.Notice( netuser, "Name: "..playername.." not found!" )
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
				rust.Notice(netuser, "You have given "..targetuser.displayName.." "..amount.." "..itemname)
			else
				rust.Notice(netuser, "Couldn't give "..amount.." "..itemname.." to "..targetuser.displayName)
			end
		else
			rust.Notice(netuser, itemname.." isn't a valid item.")
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:cmdGiveAll(netuser, cmd, args)
	local datan = self:GetUserData(netuser)
	if netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "give")) then
		local netusers = rust.GetAllNetUsers()
		local datablock = rust.GetDatablockByName(args[1])
		if datablock then
			rust.RunServerCommand("inv.giveall "..args[1])
		else
			rust.Notice(netuser, args[1].." isn't an item.")
		end
	end
end

local VANISH = {}

function PLUGIN:cmdVanish(netuser)
	local datan = self:GetUserData(netuser)
	if netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain")) then
		local netuserID = rust.GetUserID(netuser)
		local prefe = "armor"
		if VANISH[netuserID] ~= true then
			self:Give(netuser, "Invisible Helmet", 1, prefe )
			self:Give(netuser, "Invisible Vest", 1, prefe )
			self:Give(netuser, "Invisible Pants", 1, prefe )
			self:Give(netuser, "Invisible Boots", 1, prefe )
			VANISH[netuserID] = true
			rust.Notice(netuser, "You have vanished.")
		else
			self:Take(netuser, "Invisible Helmet")
			self:Take(netuser, "Invisible Vest")
			self:Take(netuser, "Invisible Pants")
			self:Take(netuser, "Invisible Boots")
			VANISH[netuserID] = false
			rust.Notice(netuser, "You have unvanished.")
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:cmdCI(netuser, cmd, args)
	local tuser
	if args[1] then
		local datan = self:GetUserData(netuser)
		if netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "give")) then
			local b, targetuser = rust.FindNetUsersByName( args[1] )
			if (not b) then
				if (targetuser == 0) then
					rust.Notice( netuser, "Player nao encontrado!" )
				else
					rust.Notice( netuser, "Varios players encontrados!" )
				end
				return
			end
			tuser = targetuser
		else
			rust.Notice(netuser, NoPermission)
			return false
		end
	else
		tuser = netuser
	end
	self:ClearInv(tuser)
	rust.Notice(netuser, "Inventario do "..tuser.displayName.." limpo.")
end

function PLUGIN:ClearInv(netuser)
	local inv = rust.GetInventory(netuser)
	inv:Clear()
end

function PLUGIN:Give(user, item, amount, slot, showitem)
	local datablock = rust.GetDatablockByName( item )
	if (not datablock) then
		rust.Notice( user, item.." isn't a item!" )
		return false
	end
	local amount = tonumber( amount ) or 1
	local pref = self:CSlot(slot)
	local inv = rust.GetInventory( user )
	if inv == nil then
		self:SendChatToUser(user, "Your inventory didn't exist, reconnect to fix this.")
		return false
	end
	local arr = util.ArrayFromTable( System.Object, { datablock, amount, pref } )
	util.ArraySet( arr, 1, System.Int32, amount )
	if (type( inv.AddItemAmount ) == "string") then
		print( "AddItemAmount was a string!")
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
		self:SendChatToUser(user, "Your inventory didn't exist, reconnect to fix this.")
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

function PLUGIN:GetAdminList()
	local onlineadmins = {}
	local allnetusers = rust.GetAllNetUsers()
	if (allnetusers) then
		for i=1, #allnetusers do
			local netusertmp = allnetusers[i]
			if (netusertmp:CanAdmin()) then
				table.insert(onlineadmins, netusertmp)
			end
		end
		return onlineadmins
	end
	return
end

function PLUGIN:cmdAdminList( netuser )
	local Admins = {}
	local Player = {}
	local Playersnum = 0
	local PlayerNumber = 0
	for _,netuser in pairs(rust.GetAllNetUsers()) do
		local data = self:GetUserData( netuser )
		if (netuser:CanAdmin() and not data.AdminDisguise) then
			table.insert(Admins, netuser.displayName)
		end
	end
	self:SendChatToUser(netuser,  "[color green]ADMS ON:")
	for _,v in pairsByKeys(Admins) do
		if Playersnum < 2 then
			if Player[PlayerNumber] == nil then
				Player[PlayerNumber] = {}
			end
			table.insert(Player[PlayerNumber], v)
			Playersnum = Playersnum + 1
		else
			table.insert(Player[PlayerNumber], v)
			PlayerNumber = PlayerNumber + 1
			Playersnum = 0
		end
	end
	for i=0, PlayerNumber do
		if type(Player[i]) == "table" then
			self:SendChatToUser(netuser,  table.concat(Player[i], ", "))
		end
	end
end

function PLUGIN:cmdAO( netuser )
	local adminlist = self:GetAdminList()
	rust.Notice( netuser, "Temos "..tostring(#adminlist).." admin(s) online!" )
end

function PLUGIN:AdminDisguise( netuser )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "adis"))) then
		local data = self:GetUserData( netuser )
		data.AdminDisguise = true
		rust.Notice(netuser, "Admin Disguise enabled!")
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:AdminUndisguise( netuser )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "audis"))) then
		local data = self:GetUserData( netuser )
		data.AdminDisguise = false
		rust.Notice(netuser, "Admin Disguise disabled!")
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdShutdown(netuser, cmd, args)
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "restart"))) then
		if (not args[1]) then
			rust.BroadcastChat( self.Config.Chatname, "Restart!" )
			self:Close()
		elseif (args[1] == "cancel") then
			if ShutdownTimer then
				ShutdownTimer:Destroy()
				ShutdownTimer = nil
				rust.BroadcastChat( self.Config.Chatname, "Restart cancelled!")
			else
				self:SendChatToUser(netuser, "No restart running.")
			end
		elseif (args[1]) then
			if ShutdownTimer then
				rust.Notice(netuser, "A restart is already counting down. ("..dc..")")
				return false
			end
			local dc = tonumber(args[1])
			local hours = 0
			for i=0, dc do
				if i % 60 == 0 and i ~= 0 then
					dc = dc - 60
					hours = hours + 1
				end
			end
			if hours ~= 0 then
				rust.BroadcastChat(self.Config.Chatname, "Restart in "..hours.."h and "..dc.."m")
			else
				rust.BroadcastChat(self.Config.Chatname, "Restart in "..dc.."m")
			end
			local cd = dc + 1
			ShutdownTimer = timer.Repeat(60, cd, function()
				dc = dc - 1
				if dc % 5 == 0 and dc > 5 then -- If over 5 broadcast every 5th min.
					if hours % 1 == 0 and dc ~= 0 then
						rust.BroadcastChat(self.Config.Chatname, "Restart in "..hours.."h and "..dc.."m")
					elseif hours % 1 == 0 and dc == 0 then
						rust.BroadcastChat(self.Config.Chatname, "Restart in "..hours.."h")
					else
						rust.BroadcastChat(self.Config.Chatname, "Restart in "..dc.."m")
					end
				elseif dc <= 5 and dc ~= 0 then  -- If under 5 or 5 broadcast every min.
					rust.BroadcastChat(self.Config.Chatname, "Restart in "..dc.."m")
				elseif dc == 0 then
					rust.BroadcastChat(self.Config.Chatname, "Restart!")
					timer.Once(3, function()
						self:Close()
					end)
				end
			end)
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:Close()
	rust.RunServerCommand("quit")
end

function PLUGIN:RemoveAllAdmin( netuser )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "remadmin"))) then
		local players = {}
		local count = 0
		for _, data in pairs( self.PData.Users ) do
			local Admin = tostring(data.Admin)
			if (Admin:match( "true" )) then
				count = count + 1
				data.Admin = false
			end
		end
		rust.Notice( netuser, "Removed admin from "..count.." players." )
		if (self.Config.Enabled.Log) then
			self:Logger(netuser.displayName.." removed admin from all players.")
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

-- HiddenChest 1% completo '-' termine vc. 
function PLUGIN:Hiddenchest( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "hiddenchest"))) then
	    rust.BroadcastChat( "ϟ | [HIDDENCHEST]", "=================================================================")
		rust.BroadcastChat( "ϟ | [HIDDENCHEST]", "O evento [color yellow]HIDDENCHEST[/color] começou!" )
		rust.BroadcastChat( "ϟ | [HIDDENCHEST]", "Um bau foi gerado automaticamente pelo mapa" )
		rust.BroadcastChat( "ϟ | [HIDDENCHEST]", "Items: [color red]RANDOM" )
		rust.BroadcastChat( "ϟ | [HIDDENCHEST]", "Corra e seja o primeiro a achar o bau e pegar todos os itens!" )
		rust.BroadcastChat( "ϟ | [HIDDENCHEST]", "=================================================================")
	else
		rust.Notice( netuser, NoPermission )
	end
end
function PLUGIN:ccmdHiddenchest(arg)
	local netuser = arg.argUser
	if netuser then
		if (netuser:CanAdmin()) then
			if (not arg:GetString(0, "text")) then
				arg:ReplyWith("Nenhum argumento encontrado")
			end	
			
			
		else
			arg:ReplyWith(NoPermission)
		end
	end
	return true
end




function PLUGIN:AddAdmin( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "addadmin"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Use /addadmin \"Name\" To add him/her to autoadmin.")
			return
		end	
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Player nao encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local data = self:GetUserData( targetuser )
		if (not data.Admin) then
			data.Admin = true
			rust.Notice( netuser, "You have given "..targetuser.displayName.." admin access!" )
			rust.Notice( targetuser, "You are now admin, thanks to "..netuser.displayName )
			targetuser:SetAdmin(true)
		else
			rust.Notice( netuser, "Player already has admin access." )
			return true
		end
		if (self.Config.Enabled.Log) then
			self:Logger(netuser.displayName.." gave admin access to "..targetuser.displayName)
		end
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:ccmdAddAdmin(arg)
	local netuser = arg.argUser
	if netuser then
		if (netuser:CanAdmin()) then
			if (not arg:GetString(0, "text")) then
				arg:ReplyWith("Use essentials.addadmin \"Nome\" para adicionar um adm.")
			end	
			local b, targetuser = rust.FindNetUsersByName( arg:GetString(0) )
			if (not b) then
				if (targetuser == 0) then
					arg:ReplyWith("Nenhum player encontrado!" )
				else
					arg:ReplyWith("Varios players encontrados!" )
				end
				return true
			end
			local data = self:GetUserData( targetuser )
			if (data.Admin) then
				arg:ReplyWith("Player ja e um adm." )
				return true
			end
			if (not data.Admin) then
				data.Admin = true
				arg:ReplyWith("Voce e agora um admin "..targetuser.displayName.." !" )
				rust.Notice( targetuser, "Voce agora e um admin!" )
				targetuser:SetAdmin(true)
			end
			if (self.Config.Enabled.Log) then
				self:Logger(netuser.displayName.." deu admin para "..targetuser.displayName)
			end
		else
			arg:ReplyWith(NoPermission)
		end
	end
	return true
end


function PLUGIN:RemoveAdmin( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "remadmin"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /remadmin \"Nome\" para remover admin.")
			return
		end	
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Nenhum player encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local data = self:GetUserData( targetuser )
		if (not data.Admin) then
			rust.Notice( netuser, "O player nao e admin." )
			return true
		end
		if (data.Admin) then
			data.Admin = false
			rust.Notice( netuser, "Voce tirou o admin de: "..targetuser.displayName.."!" )
			if (self.Config.Enabled.Log) then
				self:Logger(netuser.displayName.." removeu o admin de "..targetuser.displayName)
			end
			targetuser:SetAdmin(false)
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:cmdFall( netuser )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "falldmg"))) then
		if (self.Config.Misc.FallDamage) then
			self.Config.Misc.FallDamage = not self.Config.Misc.FallDamage
			rust.RunServerCommand("falldamage.enabled false")
			config.Save( self.Title )
			FallStatus = "Off"
		elseif (not FallDamage) then
			self.Config.Misc.FallDamage = not self.Config.Misc.FallDamage
			rust.RunServerCommand("falldamage.enabled true")
			config.Save( self.Title )
			FallStatus = "On"
		end
		
		rust.BroadcastChat( self.Config.Chatname, "Falldamage is now: "..FallStatus)
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:cmdTP(netuser, targetuser, args)
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "teleport") or flags:HasFlag(netuser, "banning"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /tp \"Nome\" para teleportar pra um player.")
			return true
		end
		local b, targetuser = rust.FindNetUsersByName(util.QuoteSafe(tostring(args[1])))
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Player nao encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		if (not args[2]) then
			timer.Repeat(1, 2, function() rust.ServerManagement():TeleportPlayerToPlayer( netuser.networkPlayer, targetuser.networkPlayer )end)
			rust.Notice(netuser, "You have teleported to "..targetuser.displayName)
			if (self.Config.Enabled.Log) then
				self:Logger(netuser.displayName.." teleported to "..targetuser.displayName)
			end
		else
			local b, targetuser1 = rust.FindNetUsersByName( args[2] )
			if (not b) then
				if (targetuser1 == 0) then
						rust.Notice( netuser, "Player nao encontrado!" )
					else
						rust.Notice( netuser, "Varios players encontrados!" )
					end
				return
			end
			timer.Repeat(1, 2, function() rust.ServerManagement():TeleportPlayerToPlayer( targetuser.networkPlayer, targetuser1.networkPlayer )end)
			rust.Notice( netuser, "You have teleported "..targetuser.displayName.." to "..targetuser1.displayName )
			rust.Notice( targetuser, "You have been teleported to "..targetuser1.displayName )
			if (self.Config.Enabled.Log) then
				self:Logger(targetuser.displayName.." teleported to "..targetuser1.displayName)
			end
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:TpaLeft( netuser )
	local data = self:GetUserData( netuser )
	local uses = tostring(data.Uses)
	local TPA = ""
	if (self.Config.Misc.MaxTpa) then
		TPA = tostring(self.Config.Misc.MaxTpa)
	elseif (not self.Config.Misc.MaxTpa or self.Config.Misc.MaxTpa == 0) then
		TPA = "Unlimited"
	end
	rust.Notice(netuser, "You have used "..uses.."/"..TPA.."!")
	self:SendChatToUser(netuser,  "You have used "..uses.."/"..TPA.."!")
end

function PLUGIN:cmdTpa( netuser, cmd, args )	
	if (not args[1]) then
		rust.Notice(netuser, "/tpa \"nome\" ")
		return
	end
    local b, targetuser = rust.FindNetUsersByName( args[1] )
	if (not b) then
		if (targetuser == 0) then
			rust.Notice( netuser, "Player nao encontrado!" )
		else
			rust.Notice( netuser, "Varios players encontrados!" )
		end
		return
	end
	local datan = self:GetUserData( netuser )
	local datat = self:GetUserData( targetuser )
	local arg = tostring(args[1])
	local check = self:CheckIfTwice( targetuser, arg )
    if (datan.Name == datat.Name) then
        rust.Notice( netuser, "Nao pode se teleportar pra voce mesmo, fumou?!" )
        return
    end
	if (self.Config.Misc.MaxTpa == 0) then
		MaxTpa = math.huge
	else
		MaxTpa = self.Config.Misc.MaxTpa
	end
    if (datan.Uses >= tonumber(MaxTpa)) then
        rust.Notice( netuser, "Max number of teleport requests reached!" )
        return
    end
	if (check) then
		rust.Notice(netuser, "Request already sent!")
	else
		self:SendChatToUser(targetuser,  " [color green] Voce recebeu um pedido de TP de: " .. util.QuoteSafe( netuser.displayName ) )
		self:SendChatToUser(netuser,  "[color green] Voce mandou tp para " .. util.QuoteSafe( targetuser.displayName ))
		datat.Pending = {datan.Name}
		self.TIMING = timer.Once( 120, function() datat.Pending = {} end)
	end
end

function PLUGIN:Reset()
	for _,data in pairs( self.PData.Users ) do
		if data.Pending then
			data.Pending = {}
		end
		if data.Uses then
			data.Uses = 0
		end
	end
end

function PLUGIN:Reseter( netuser )
	self:Reset()
	rust.Notice( netuser, "Todos tps cancelados pelo admin.")
end

function PLUGIN:CheckIfTwice( targetuser, arg )
	local data = self:GetUserData( targetuser )
	for _,v in pairs(data.Pending) do
		if (arg:match( v )) then
			return true
		end
	end
	return false
end

function PLUGIN:cmdTpacc( netuser, cmd, args )
    local netuserID = rust.GetUserID( netuser )
	local data = self:GetUserData( netuser )
    if (data.Pending ~= nil or data.Pending ~= "") then
		local tmp = {}
		for name,something in pairs( data.Pending ) do
			tmp[ #tmp + 1 ] = util.QuoteSafe(tostring(something))
		end
		local b, targetuser = rust.FindNetUsersByName( util.QuoteSafe(tostring(tmp[1])) )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Player offline!" )
				data.Pending = {}
			else
				rust.Notice( netuser, "Varios players encontrados!" )
				data.Pending = {}
			end
			return
		end
		local datat = self:GetUserData( targetuser )
		self:SendChatToUser(targetuser, "Voce vai ser teleportado para "..netuser.displayName.." em "..tostring(self.Config.Misc.TpaTimer).." segundos.")
		self:SendChatToUser(netuser, targetuser.displayName.." vai ser teleportado pra voce em "..tostring(self.Config.Misc.TpaTimer).." segundos.")
		datat.Uses = datat.Uses + 1
		timer.Once( self.Config.Misc.TpaTimer, function()
			timer.Repeat( 0.5, 2, function() rust.ServerManagement():TeleportPlayerToPlayer( targetuser.networkPlayer, netuser.networkPlayer ) end )
			self:SendChatToUser(netuser,  util.QuoteSafe(targetuser.displayName) .. " [color green] foi teleportado pra voce")
			self:SendChatToUser(targetuser,  "[color green] Voce foi teleportado para"..util.QuoteSafe(netuser.displayName))
			data.Pending = {}
		end)
    else
        rust.Notice( netuser, "No teleport request pending!" )
    end
end

function PLUGIN:cmdUpdate( netuser )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "update"))) then
		self:LoadDefaultConfig()
		rust.Notice( netuser, "Updated config." )
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdEssentialsReload(netuser, cmd, args)
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "reload"))) then
		if self.Title ~= "Essentials" then
			rust.Notice(netuser, "Please change the PLUGIN.Title back to Essentials")
		end
		plugins.Reload( self.Title )
		rust.Notice( netuser, "Reloaded "..self.Title )
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdOnline( netuser )
	rust.Notice(netuser, "Temos: "..tostring(#rust.GetAllNetUsers()).." players online!")
	self:SendChatToUser(netuser,  "Temos: "..tostring(#rust.GetAllNetUsers()).." players online!")
end

function PLUGIN:cmdGiveEssentials(netuser, cmd, args)
	local datan = self:GetUserData(netuser)
	if netuser:CanAdmin() or datan.Essentials == true then
		if args[1] then
			local b, targetuser = rust.FindNetUsersByName( args[1] )
			if (not b) then
				if (targetuser == 0) then
					rust.Notice( netuser, "Player offline!" )
				else
					rust.Notice( netuser, "Varios players encontrados!" )
				end
				return
			end
			local data = self:GetUserData(targetuser)
			if data.Essentials then
				data.Essentials = false
				self:SendChatToUser(netuser, "You have given "..targetuser.displayName.." the essentials power.")
			else
				data.Essentials = true
				self:SendChatToUser(netuser, "You have taken "..targetuser.displayName.."'s essential power.")
			end
		else
			rust.Notice(netuser, "Use /giveessentials \"Name\"")
		end
	end
end

function PLUGIN:cmdKick(netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "banning"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /kick \"Nome\" para kickar um player.")
			return
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
			if (netuser == targetuser) then
				rust.Notice(netuser, "Voce nao pode kikar voce mesmo.")
				return true
			end
			rust.Notice(netuser, "Player kickado: "..util.QuoteSafe(targetuser.displayName))
			rust.BroadcastChat( self.Config.Chatname, "[color red] O jogador "..targetuser.displayName.." foi retirado do servidor!" )
			local netuserID = rust.GetUserID(netuser)
			Kicked[netuserID] = true
			targetuser:Kick( NetError.Facepunch_Kick_RCON, true )
		end
	else
		rust.Notice(netuser, NoPermission)
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
	rust.Notice(netuser, "Fixed money!")
end

function PLUGIN:TakeMoney( user, amount)
	local data = self:GetUserData( user )
	local amount = tonumber(amount)
	local curmoney = tostring(data.Money)
	if amount == 0 or amount == nil then
		return false
	end
	if data.Money < amount then 
		rust.Notice(user, "You don't have enough money to do this.")
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
			rust.Notice(netuser, "Use /setmoney \"Name\" \"Amount\"")
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
			self:SendChatToUser(netuser,  "You have set "..targetuser.displayName.."'s money to "..args[2]..self.Config.Econ.Symbol)
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
			rust.Notice(netuser, "Use /addmoney \"Name\" to add an admin.")
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
			self:SendChatToUser(netuser, "You have given "..targetuser.displayName.." "..args[2]..self.Config.Econ.Symbol)
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
		arg:ReplyWith("Use essentials.addmoney \"Name\" to add money to that person.")
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

function PLUGIN:cmdAddPrice(netuser, cmd, args)
	local datan = self:GetUserData(netuser)
	if netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "econ")) then
		if not args[2] then
			rust.Notice(netuser, "Use /addprice \"Itemname\" \"BuyPrice\" \"SellPrice\"")
			return true
		end
		local datablock = rust.GetDatablockByName(args[1])
		if not datablock then
			rust.Notice(netuser, args[1].." isn't an item.")
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
		self:SendChatToUser(netuser,  "You have added/updated "..itemname.."'s buy/sell price.")
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:GiveAllPayCheck()
	for _,netuser in pairs(rust.GetAllNetUsers()) do
		local data = self:GetUserData(netuser)
		if data.Admin or data.Donator or data.Youtuber or data.ModAdd or data.Beta or data.Vip1 or data.Vip2 or data.Vip3 then
			paycheck = self.Config.Econ.PayCheckAdminDonorYoutuberBetaVip1Vip2Vip3ModAdd
		else
			paycheck = self.Config.Econ.PayCheckAmount
		end
		self:SendChatToUser(netuser, "Voce recebeu um bonus ("..paycheck..self.Config.Econ.Symbol..")")
		
		self:AddMoney(netuser, paycheck)
	end
end

function PLUGIN:StartPaychecking()
	if self.Config.Econ.PayCheck then
		self.PTimer = timer.Repeat(self.Config.Econ.PayCheckDelay, function() self:GiveAllPayCheck() end)
	end
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
        self:SendChatToUser( netuser, "Top of richest players: ")
        for _,pair in pairs(mypairs) do
            self:SendChatToUser(netuser,  "#"..listed.." "..util.QuoteSafe(pair.Name).." with "..util.QuoteSafe(tostring(pair.Money))..self.Config.Econ.Symbol )
            listed = listed + 1
            if listed > 10 then break end
        end
        return
	elseif tostring(args[1]) == "send" then
		if not args[3] then
			rust.Notice(netuser, "Use /money send \"Name\" \"Amount\"")
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
				rust.Notice(netuser, "You can't give yourself money.")
				return false
			end
			if tonumber(args[3]) < 0 then
				rust.Notice(netuser, "You can't send negative money.")
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

function PLUGIN:cmdBuy(netuser, cmd, args)
	if not args[1] then
		self:cmdPrice( netuser, cmd, args, "buy" )
		return true
	end
	local datablock = rust.GetDatablockByName( args[1] )
	if not datablock then
		rust.Notice(netuser, "No such item!")
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
		rust.Notice( netuser, args[1].." isn't an item!" )
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

function PLUGIN:ShowBalance(user)
	local data = self:GetUserData(user)
	self:SendChatToUser(user, "[color cyan]Dinheiro: "..data.Money..self.Config.Econ.Symbol)
end

function PLUGIN:ResetMoney(netuser)
	local datan = self:GetUserData(netuser)
	if netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "econ")) then
		for _,v in pairs(self.PData.Users) do
			if v.Money then
				v.Money = self.Config.Econ.StartMoney
			end
		end
		rust.BroadcastChat(self.Config.Chatname, "[color cyan]Dinheiro: "..self.Config.Econ.StartMoney..self.Config.Econ.Symbol)
	else
		rust.Notice(netuser, NoPermission)
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
		self:SendChatToUser(netuser,  "[color green]--- PAGINA [  "..tostring(pagenum).."/"..tostring(countpage).." ] Proxima pagina digite: /loja 2 ou /loja 3 ---")
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
function PLUGIN:cmdHistory(netuser)
	for i=1, #self.PData.History do
		self:SendChatToUser(netuser,  self.PData.History[i])
	end
end

function PLUGIN:AddHistory(name, message)
	table.insert(self.PData.History, name..": "..message)
	if #self.PData.History > self.Config.Misc.HistoryLength then
		self.PData.History[self.Config.Misc.HistoryLength + 1] = nil
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

function PLUGIN:Ban(netuser, cmd, args)
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "banning"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /ban \"Nome\" para banir um player.")
			return true
		end
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Player nao encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		if (targetuser == netuser) then
			rust.Notice(netuser, "Voce nao pode se banir, ta lokao?.")
			return true
		end
		local data = self:GetUserData( targetuser )
		if (not data.Banned) then
			data.Banned = true
			if not args[2] then
				rust.BroadcastChat( self.Config.Chatname, "[color red] O jogador "..targetuser.displayName.." foi banido!" )
			else
				rust.BroadcastChat( self.Config.Chatname, targetuser.displayName.." foi banido! [color red] motivo: "..util.QuoteSafe(args[2]) )
			end
			local netuserID = rust.GetUserID(netuser)
			Kicked[netuserID] = true
			targetuser:Kick( NetError.Facepunch_Kick_Ban, true )
		elseif (data.Banned) then
			rust.Notice(netuser, "Player ja banido!")
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:cmdBanIP(netuser, cmd, args)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "banning"))) then
		if not args[1] then
			rust.Notice(netuser, "Digite /banip para banir um ip.")
			return true
		end
		if type(args[1]:sub(1,1)) == "number" then
			if self.PData.Bans == nil then
				self.PData.Bans = {}
			end
			table.insert(self.PData.Bans, args[1])
			rust.Notice(netuser, "Voce baniu o ip: "..tostring(targetuser.networkPlayer.externalIP))
		else
			rust.Notice(netuser, "Argumento invalido.")
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:cmdBanSteamID(netuser, cmd, args)
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "banning"))) then
		if not args[1] then
			rust.Notice(netuser, "Use /bansteam \"SteamID\" to ban a ip from joining.")
			return true
		end
		if (targetuser == netuser) then
			rust.Notice(netuser, "You can't ban yourself.")
			return true
		end
		if self.PData.Bans == nil then
			self.PData.Bans = {}
		end
		local steamid = rust.CommunityIDToSteamID(rust.GetUserID(netuser))
		table.insert(self.PData.Bans, args[1])
		rust.Notice(netuser, "You have banned the steamid: "..args[1])
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:GetGroup(netuser, generate, GName)
	if self.PData.Group == nil then
		self.PData.Group = {}
	end
	local netuserID = rust.GetUserID(netuser)
	if generate then
		local entry = self.PData.Group[netuserID]
		if GName or (entry.Version ~= nil and entry.Version ~= self.DataVersion) then
			if entry == nil then
				entry = {}
			end
			if entry.GroupName == nil then
				entry.GroupName = GName
			end
			if entry.GroupPvP == nil then
				entry.GroupPvP = false
			end
			if entry.Version == nil then
				entry.Version = self.DataVersion
			end
			if entry.GroupRemoverTool then
				entry.GroupRemoverTool = {}
			end
			if self.Config.Misc.Grouptag then
				if entry.GroupTag == nil then
					entry.GroupTag = ""
				end
			end
			if entry.Members == nil then
				entry.Members = {tostring(netuserID)}
			end
			entry.Invite = {}
			if entry.ID == nil then
				entry.ID = netuserID
			end
			if entry.Owner == nil then
				entry.Owner = netuser.displayName
			end
			if entry.Kills == nil then
				entry.Kills = 0
			end
			if entry.Death == nil then
				entry.Death = 0
			end
			self.PData.Group[netuserID] = entry
			return true
		end
	end
	for _,v in pairs(self.PData.Group) do
		for i=0, #v.Members do
			if v.Members[i] == netuserID then
				return v
			end
		end
	end
	return false
end

function PLUGIN:cmdCreateGroup(netuser, cmd, args)
	local Group = self:GetGroup(netuser)
	if not args[1] then
		rust.Notice(netuser, "Use /gcreate \"Name\" to create a group.")
		return true
	end
	if type(Group) == "table" then
		rust.Notice(netuser, "You need to leave your current group before joining a new one.")
		return true
	end
	for _,v in pairs(self.PData.Group) do
		if v.GroupName == tostring(args[1]) then
			rust.Notice(netuser, "This groupname is already taken.")
			return true
		end
	end
	local takemn = false
	if self.Config.Enabled.Econ then
		takemn = self:TakeMoney(netuser, self.Config.Misc.CreateGroupCost)
	else
		takemn = true
	end
	if takemn then
		self:GetGroup(netuser, true, tostring(args[1]))
		rust.Notice(netuser, "Group successfully created.")
	end
end

function PLUGIN:cmdDeleteGroup(netuser)
	local groupID = rust.GetUserID(netuser)
	if self.PData.Group[groupID] then
		self.PData.Group[groupID] = nil
		rust.Notice(netuser, "Group successfully deleted.")
		return true
	else
		rust.Notice(netuser, "You are not owner of any groups.")
	end
end

function PLUGIN:cmdGroupLeave(netuser)
	local netuserID = rust.GetUserID(netuser)
	local Group = self:GetGroup(netuser)
	if type(Group) == "table" then
		if Group.ID == netuserID then
			self:cmdDeleteGroup(netuser)
			return true
		end
		for i=0, #Group.Members do
			if Group.Members[i] == netuserID then
				table.remove(Group.Members, i)
				rust.Notice(netuser, "You have left "..Group.GroupName)
				return true
			end
		end
	else
		rust.Notice(netuser, "You aren't member of any groups.")
	end
end

function PLUGIN:cmdChangeGroupPvP(netuser)
	local Group = self:GetGroup(netuser)
	local netuserID = rust.GetUserID(netuser)
	if type(Group) == "table" then
		if Group.ID == netuserID then
			if Group.GroupPvP then
				Group.GroupPvP = false
				rust.Notice(netuser, "Group PvP changed to false.")
			else
				Group.GroupPvP = true
				rust.Notice(netuser, "Group PvP changed to true.")
			end
			
		else
			rust.Notice(netuser, "You aren't owner of any groups.")
		end
	else
		rust.Notice(netuser, "You aren't member of any groups.")
	end
end

local GroupChat = {}

function PLUGIN:cmdGroupChat(netuser)
	local Group = self:GetGroup(netuser)
	if type(Group) == "table" then
		local netuserID = rust.GetUserID(netuser)
		if GroupChat[netuserID] then
			GroupChat[netuserID] = false
			self:SendChatToUser(netuser,  "Group chat disabled.")
		else
			GroupChat[netuserID] = true
			self:SendChatToUser(netuser,  "Group chat enabled.")
		end
	else
		rust.Notice(netuser, "You aren't member of any groups.")
	end
end

function PLUGIN:cmdGroupList( netuser )
	local MaxRows = 10
	local mypairs = {}
	for _,data in pairs(self.PData.Group) do
		if data.Kills ~= nil then
			table.insert(mypairs,{Name=data.GroupName, Kills=data.Kills})
		end
	end
	table.sort(mypairs,function(a,b) return a.Kills > b.Kills end)
	local listed = 1
	if #mypairs ~= 0 then
		self:SendChatToUser(netuser,  "Top Kills: ")
		for _,pair in pairs(mypairs) do
			self:SendChatToUser(netuser,  " #"..listed..": "..pair.Name.." matou "..pair.Kills.." players!" )
			listed = listed + 1
			if listed > MaxRows then break end
		end
	else
		self:SendChatToUser(netuser,  "No groups registered. Use /gcreate \"Name\"")
	end
end

function PLUGIN:cmdGroupInvite(netuser, cmd, args)
	local Group = self:GetGroup(netuser)
	local netuserID = rust.GetUserID(netuser)
	if type(Group) == "table" then
		if Group.ID == netuserID then
			if not args[1] then
				rust.Notice(netuser, "Use /ginvite *playername* to invite a player to your group.")
			end
			local b, targetuser = rust.FindNetUsersByName( args[1] )
			if (not b) then
				if (targetuser == 0) then
					rust.Notice( netuser, "Player nao encontrado!" )
				else
					rust.Notice( netuser, "Varios players encontrados!" )
				end
				return
			end
			local targetuserID = rust.GetUserID(targetuser)
			for i=1, #Group.Invite do
				if Group.Invite[i] == targetuserID then
					rust.Notice(netuser, "This player has already been invited to the group.")
					return true
				end
			end
			self:SendChatToUser(targetuser,  "You have been invited to join "..Group.GroupName)
			self:SendChatToUser(netuser,  "You have invited "..targetuser.displayName.." to join "..Group.GroupName)
			table.insert(Group.Invite, targetuserID)
		else
			rust.Notice(netuser, "You need to be the owner of the group to do this.")
		end
	end
end

function PLUGIN:cmdGroupTag(netuser, cmd, args)
	local Group = self:GetGroup(netuser)
	local netuserID = rust.GetUserID(netuser)
	if type(Group) == "table" then
		if Group.ID == netuserID then
			if not args[1] then
				rust.Notice(netuser, "Use /gtag \"tag\"")
				return true
			end
			if (args[1]):len() > 4 then
				rust.Notice(netuser, "Group tag can't be longer than 4 chars.")
				return true
			end
			local TaG = util.QuoteSafe(tostring(args[1]))
			Group.GroupTag = "["..TaG.."]"
			
			rust.Notice(netuser, "You have changed the group tag to "..Group.GroupTag)
		else
			rust.Notice(netuser, "You aren't owner of "..Group.GroupName..", "..Group.Owner.." is.")
		end
	else
		rust.Notice(netuser, "You aren't member of any group.")
	end
end

function PLUGIN:cmdGroupWho(netuser)
	local Group = self:GetGroup(netuser)
	if type(Group) == "table" then
		local GOnline = 0
		for _,netuser1 in pairs(rust.GetAllNetUsers()) do
			local nUID = rust.GetUserID(netuser1)
			for _,v in pairs(Group.Members) do
				if nUID == v then
					GOnline = GOnline + 1
				end
			end
		end
		self:SendChatToUser(netuser,  "Group members online: "..tostring(GOnline))
	else
		rust.Notice(netuser, "You aren't member of any group.")
	end
end

function PLUGIN:cmdGroup(netuser, cmd, args)
	local targetuser = nil
	if args[1] then
		local b, targetuser1 = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser1 == 0) then
				rust.Notice( netuser, "Player nao encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local uG = self:GetGroup(targetuser1)
		if type(uG) == "table" then
			targetuser = targetuser1
		else
			rust.Notice(netuser, "That player isn't member of any group.")
			return false
		end
	end
	if targetuser == nil then
		targetuser = netuser
	end
	local Group = self:GetGroup(targetuser)
	local GOnline = 0
	if type(Group) == "table" then
		for _,netuser1 in pairs(rust.GetAllNetUsers()) do
			local nUID = rust.GetUserID(netuser1)
			for _,v in pairs(Group.Members) do
				if nUID == v then
					GOnline = GOnline + 1
				end
			end
		end
	end
	if type(Group) == "table" then
		self:SendChatToUser(netuser,  "-----=== ["..Group.GroupName.."] ===-----")
		self:SendChatToUser(netuser,  "Group members online: "..tostring(GOnline))
		self:SendChatToUser(netuser,  "Group settings:")
		self:SendChatToUser(netuser,  "- Group PvP is "..tostring(Group.GroupPvP) )
		self:SendChatToUser(netuser,  "- Group owner is "..Group.Owner)
		if Group.GroupTag == "" then
			self:SendChatToUser(netuser,  "- Group tag is not set.")
		else
			self:SendChatToUser(netuser,  "- Group tag is "..Group.GroupTag)
		end
		self:SendChatToUser(netuser,  "There is currently "..tostring(#Group.Members).." members in this group.")
	else
		rust.Notice(netuser, "You aren't member of any group.")
	end
end

function PLUGIN:cmdGroupPlayers( netuser )
	local netuserGroup = self:GetGroup(netuser)
	if type(netuserGroup) == "table" then
		local Players = {}
		local Playersnum = 0
		local PlayerNumber = 0
		local Player = {}
		local GOnline = 0
		for _,d in pairs(netuserGroup.Members) do
			for _,netuser1 in pairs(rust.GetAllNetUsers()) do
				local nUID = rust.GetUserID(netuser1)
				if nUID == d then
					table.insert(Players, netuser1.displayName)
					GOnline = GOnline + 1
				end
			end
		end
		self:SendChatToUser(netuser,  GOnline.." /"..tostring(#netuserGroup.Members).." group members online.")
		self:SendChatToUser(netuser,  "Players list:")
		for _,v in pairsByKeys(Players) do
			if Playersnum < 2 then
				if Player[PlayerNumber] == nil then
					Player[PlayerNumber] = {}
				end
				table.insert(Player[PlayerNumber], v)
				Playersnum = Playersnum + 1
			else
				table.insert(Player[PlayerNumber], v)
				PlayerNumber = PlayerNumber + 1
				Playersnum = 0
			end
		end
		for i=0, PlayerNumber do
			if type(Player[i]) == "table" then
				self:SendChatToUser(netuser,  table.concat(Player[i], ", "))
			end
		end
	else
		rust.Notice(netuser, "You aren't member of any group.")
	end
end

function PLUGIN:cmdGroupKick(netuser, cmd, args)
	local Group = self:GetGroup(netuser)
	local netuserID = rust.GetUserID(netuser)
	if type(Group) == "table" then
		if Group.ID == netuserID then
			if not args[1] then
				rust.Notice(netuser, "Use /gkick \"Name\" to kick a player from your group.")
				return true
			end
			local b, targetuser = rust.FindNetUsersByName( args[1] )
			if (not b) then
				if (targetuser == 0) then
					rust.Notice( netuser, "No player found with that name!" )
				else
					rust.Notice( netuser, "Varios players encontrados!" )
				end
				return
			end
			local targetuserID = rust.GetUserID(targetuser)
			if netuserID == targetuserID then
				rust.Notice(netuser, "You can't kick yourself from a group.")
				return true
			end
			local f = false
			for i=0, #Group.Members do
				if Group.Members[i] == targetuserID then
					f = true
					Group.Members[i] = nil
					
					self:SendChatToUser(netuser, "You have kicked "..targetuser.displayName.." from your group.")
					self:SendChatToUser(targetuser, "You have been kicked from "..Group.GroupName)
					return true
				end
			end
			if f == false then
				rust.Notice(netuser, "There isn't any member of the group with that name/id.")
			end
		else
			rust.Notice(netuser, "You aren't owner of "..Group.GroupName..", "..Group.Owner.." is.")
		end
	else
		rust.Notice(netuser, "You aren't member of any group.")
	end
end

function PLUGIN:cmdGroupName(netuser, cmd, args)
	local netuserID = rust.GetUserID(netuser)
	local Group = self:GetGroup(netuser)
	if type (Group) == "table" then
		if Group.ID == netuserID then
			Group.GroupName = args[1]
			
			rust.Notice(netuser, "Group name changed to "..args[1])
		else
			rust.Notice(netuser, "You aren't the owner of "..Group.GroupName)
		end
	else
		rust.Notice(netuser, "You aren't member of a group.")
	end
end

function PLUGIN:cmdGroupAccept(netuser)
	local netuserID = tostring(rust.GetUserID(netuser))
	local Group = self:GetGroup(netuser)
	local g = 0
	for _,v in pairs(self.PData.Group) do
		for i=1, #v.Invite do
			if v.Invite[i] == netuserID and g == 0 then
				g = g + 1
				table.remove(v.Invite, i)
				table.insert(v.Members, netuserID)
				v.Invite[i] = nil
				
				self:SendChatToUser(netuser,  "You have joined "..v.GroupName)
				break
				return true
			elseif v.Invite[i] == netuserID and g > 0 then
				table.remove(v.Invite, i)
			end
		end
	end
	if g == 0 then
		rust.Notice(netuser, "You aren't invited to any groups.")
	end
end

function PLUGIN:cmdKill(netuser, cmd, args)
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "kill"))) then
		if not args[1] then
			rust.Notice(netuser, "Use /kill \"Name\" to kill that player.")
			return true
		else
			local b, targetuser = rust.FindNetUsersByName( args[1] )
			if (not b) then
				if (targetuser == 0) then
					rust.Notice( netuser, "Player nao encontrado!" )
				else
					rust.Notice( netuser, "Varios players encontrados!" )
				end
				return
			end
			self:KillPlayer(targetuser)
			rust.Notice(netuser, "Voce matou "..targetuser.displayName)
			return
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:cmdSuicide(netuser)
	self:KillPlayer(netuser)
end

function PLUGIN:KillPlayer(netuser)
	rust.ServerManagement():TeleportPlayer(netuser.playerClient.netPlayer, {x=0,y=0,z=0})
end

function PLUGIN:Unban(netuser, cmd, args)
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "banning"))) then
		local players = {}
		for id, data in pairs( self.PData.Users ) do
			local Data = tostring(data.Name)
			if (Data:match( tostring(args[1]) )) then
				players[ #players + 1 ] = data
			end
		end
		if (#players == 0) then
			rust.Notice( netuser, "Nenhum player banido encontrado com esse nick!" )
			return
		elseif (#players > 1) then
			rust.Notice( netuser, "Varios players com esse nick!" )
			return
		end
		players[1].Banned = false
		players[1].Warns = 0
		
		rust.Notice( netuser, util.QuoteSafe( args[1]).. " unbanned." )
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:cmdHelp( netuser, args )
	plugins.Call( "SendHelpText", netuser )
end

function PLUGIN:Save()
	self.PlayerData:SetText( json.encode( self.PData ) )
	self.PlayerData:Save()
end

function PLUGIN:cmdWarn( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "banning"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /warn \"Nome\" para avisar um player.")
			return
		end
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Player nao encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		if (targetuser == netuser) then
			rust.Notice(netuser, "You can't warn yourself.")
			return true
		end
		local targetname = util.QuoteSafe( tostring(targetuser.displayName) )
		local data = self:GetUserData( targetuser )
		if (data.Warns >= self.Config.Misc.WarnsBeforeBan) then
			local targetuserID = rust.GetUserID(targetuser)
			Kicked[targetuserID] = true
			self:Ban( netuser, cmd, args )
			return
		end
		data.Warns = data.Warns + 1
		
		rust.BroadcastChat( self.Config.Chatname, "Player: "..targetuser.displayName.." has been warned!" )
		if (self.Config.Misc.KickOnWarn) then
			local targetuserID = rust.GetUserID(targetuser)
			Kicked[targetuserID] = true
			targetuser:Kick( NetError.Facepunch_Kick_RCON, true )
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:RemoveGodAll( netuser )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "ungod"))) then
		local players = {}
		local count = 0
		for id, data in pairs( self.PData.Users ) do
			local God = tostring(data.God)
			if (God:match( "true" )) then
				count = count + 1
				data.God = false
			end
		end
		
		rust.Notice( netuser, "Removed godmode from "..count.." players." )
	else
		rust.Notice(netuser, NoPermission)
	end
end

function LookingDirection(netuser)
        local controllable = netuser.playerClient.controllable
        local char = controllable:GetComponent( "Character" )
 
        local forward = char.forward
        local pitch = char.eyesPitch
        local yaw = char.eyesYaw
		
        local direction = (yaw+90)%360
 
        return direction
end

function PLUGIN:OnAirdrop(location)	
	if self.Config.Misc.ShowDistanceToAirdrop then
		local netusers = rust.GetAllNetUsers()
		for _,netuser in pairs(netusers) do
			local coord = netuser.playerClient.lastKnownPosition
			if coord then
				local angle = math.atan2(coord.x - location.x, coord.z - location.z );
				angle = angle * ( 180 / math.pi );
				if (angle < 0) then
					angle = 360 - (-angle);
				end
				if(angle>337.5 or angle<22.5) then
					dir = "North";
				end
				if(22.5<angle and angle<67.5) then
					dir = "North-East";
				end
				if(67.5<angle and angle<112.5) then
					dir = "East";
				end
				if(112.5<angle and angle<157.5) then
					dir = "South-East";
				end
				if(157.5<angle and angle<202.5) then
					dir = "South";
				end
				if(202.5<angle and angle<247.5) then
					dir = "South-West";
				end
				if(247.5<angle and angle<292.5) then
					dir = "West";
				end
				if(292.5<angle and angle<337.5) then
					dir = "North-West";
				end
				local dist = distanceFrom(coord.x, coord.z, location.x, location.z)
				self:SendChatToUser(netuser,  "Localizaçao do airdrop "..dist.."m. "..dir.." de voce.")
			end
		end
	end
end

function distanceFrom(x1,y1,x2,y2) return math.floor(math.sqrt((x2 - x1) ^ 2 + (y2 - y1) ^ 2)) end

function PLUGIN:Location(netuser)
	if ( netuser.playerClient.lastKnownPosition ) then
		local coord = netuser.playerClient.lastKnownPosition
		local playerlook = LookingDirection(netuser)
		if(playerlook>337.5 or playerlook<22.5) then
			dir = "North";
		end
		if(22.5<playerlook and playerlook<67.5) then
			dir = "North-East";
		end
		if(67.5<playerlook and playerlook<112.5) then
			dir = "East";
		end
		if(112.5<playerlook and playerlook<157.5) then
			dir = "South-East";
		end
		if(157.5<playerlook and playerlook<202.5) then
			dir = "South";
		end
		if(202.5<playerlook and playerlook<247.5) then
			dir = "South-West";
		end
		if(247.5<playerlook and playerlook<292.5) then
			dir = "West";
		end
		if(292.5<playerlook and playerlook<337.5) then
			dir = "North-West";
		end
		self:SendChatToUser(netuser,  "Localizaçao: X: "..math.ceil(coord.x).." Y: "..math.ceil(coord.y).." Z: "..math.ceil(coord.z).." olhando para "..dir)
		return coord
	else
		self:SendChatToUser(netuser,  "Nao conseguimos pegar sua localizaçao.")
		return false
	end
end

function PLUGIN:cmdGod(netuser, cmd, args)
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "god") or flags:HasFlag(netuser, "banning"))) then
		if (not args[1]) then
			local data = self:GetUserData( netuser )
			if (data.God) then
				data.God = false
				rust.Notice(netuser, "Godmode disabled!")
				if (self.Config.Enabled.Log) then
					self:Logger(netuser.displayName.." took godmode from herself/himself.")
				else
					print(netuser.displayName.." took godmode from herself/himself.")
				end
			else
				data.God = true
				rust.Notice(netuser, "Godmode enabled!")
				if (self.Config.Enabled.Log) then
					self:Logger(netuser.displayName.." gave godmode to herself/himself.")
				else
					print(netuser.displayName.." gave godmode to herself/himself.")
				end
			end
			
			return true
		else
			local b, targetuser = rust.FindNetUsersByName( args[1] )
			if (not b) then
				if (targetuser == 0) then
					rust.Notice( netuser, "Player nao encontrado!" )
				else
					rust.Notice( netuser, "Varios players encontrados!" )
				end
				return
			end
			local data = self:GetUserData( targetuser )
			if (data.God) then
				data.God = false
				rust.Notice(netuser, "You took godmode from "..targetuser.displayName)
				if (self.Config.Enabled.Log) then
					self:Logger(netuser.displayName.." took godmode from "..targetuser.displayName)
				else
					print(netuser.displayName.." took godmode from "..targetuser.displayName)
				end
				rust.Notice(targetuser, "Godmode disabled!")
			else
				data.God = true
				rust.Notice(netuser, "You gave godmode to "..targetuser.displayName)
				if (self.Config.Enabled.Log) then
					self:Logger(netuser.displayName.." gave godmode to "..targetuser.displayName)
				else
					print(netuser.displayName.." gave godmode to "..targetuser.displayName)
				end
				rust.Notice(targetuser, "Godmode enabled!")
			end
			
		end
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdSetHome( netuser, cmd, args )
	local data = self:GetUserData( netuser )
	local userID = rust.GetUserID( netuser )
    if ( self.Config.Enabled.Econ ) then
	    if ( data.Money < self.Config.Home.SetHomePrice ) then
	    	rust.Notice(netuser, "You need "..tostring(self.Config.Home.SetHomePrice)..self.Config.Econ.Symbol.." to set a home.")
	        return
	    end
    end
	if (not args[1] or type(tonumber(args[1])) ~= "number") then
		args[1] = "1"
	end
	if (tonumber(args[1]) > self.Config.Home.MaxHomes ) then
		rust.Notice(netuser, "Only "..tostring(self.Config.Home.MaxHomes).." home(s) is allowed.")
		return true
	else
		if ( netuser.playerClient.lastKnownPosition ) then
			local coord = netuser.playerClient.lastKnownPosition
			if (data.Home[args[1]] == nil) then
				data.Home[args[1]] = {}
			end
			data.Home[args[1]]["x"] = coord.x
			data.Home[args[1]]["y"] = coord.y
			data.Home[args[1]]["z"] = coord.z
			
			if ( self.Config.Enabled.Econ and not data.Admin and not data.Donator and not data.Youtuber and not data.ModAdd and not data.Vip1 and not data.Vip2 and not data.Vip3 and not data.Beta and not data.Mito and not data.Matador and not data.Lenda ) then
				self:TakeMoney(netuser, self.Config.Home.SetHomePrice)
				rust.Notice(netuser, "You have set a home for "..self.Config.Home.SetHomePrice..self.Config.Econ.Symbol)
			else
				rust.Notice(netuser, "You have set a home!")
			end
			return true
		end
	end
end

if type(it) ~= "table" then
	it = {}
end

function PLUGIN:HomeTimer()
	self.HTimer = timer.Repeat( 60, function()
		for k,_ in pairs(it) do
			it[k] = it[k] + 1
			if it[k] >= self.Config.Home.TimeBeforeReuse then
				it[k] = nil
			end
		end
	end)
end

function PLUGIN:cmdHome( netuser, cmd, args )
	local data = self:GetUserData( netuser )
	local userID = rust.GetUserID( netuser )
	if ( self.Config.Enabled.Econ ) then
		if ( data.Money < self.Config.Home.HomePrice ) then
			rust.Notice(netuser, "You need "..tostring(self.Config.Home.HomePrice).."$ to use /home.")
			return true
		end
	end
	if (not args[1] or type(tonumber(args[1])) ~= "number") then
		args[1] = 1
	end
	if tonumber(args[1]) > self.Config.Home.MaxHomes then
		rust.Notice(netuser, "You can't have more than "..self.Config.Home.MaxHomes.." home(s)")
		return false
	end
	if ( data.Home[tostring(args[1])] == nil) then
		rust.Notice(netuser, "You haven't set a home #"..tostring(args[1]).." yet.")
		return false
	end
	if it[userID] ~= nil then
		rust.Notice(netuser, "You can't use /home for another "..tostring(self.Config.Home.TimeBeforeReuse - it[userID]).." min.")
		return false
	end
	if ( netuser.playerClient.lastKnownPosition ) then
		local coord = netuser.playerClient.lastKnownPosition
		local args1 = tostring(args[1])
		if data.Home[args1] == nil then
			data.Home[args1] = {}
		end
		coord.x = data.Home[args1]["x"] 
		coord.y = data.Home[args1]["y"]
		coord.z = data.Home[args1]["z"]
		if not data.Admin and not data.Donator and not data.Youtuber and not data.ModAdd and not data.Vip1 and not data.Vip2 and not data.Vip3 and not data.Beta and not data.Mito and not data.Matador and not data.Lenda then
			if self.Config.Home.TimeBeforeReuse ~= 0 then
				it[userID] = 0
			end
		end
		if self.Config.Home.TimeBeforeTeleported ~= 0 then
			rust.Notice(netuser, "You will be teleported to your home in "..tostring(self.Config.Home.TimeBeforeTeleported).." seconds.")
		else
			rust.Notice(netuser, "You have been teleported to your home.")
		end
		timer.Once( self.Config.Home.TimeBeforeTeleported, function()
			timer.Repeat( 0.5, 2, function() rust.ServerManagement():TeleportPlayer( netuser.playerClient.netPlayer, coord) end)
			if ( self.Config.Enabled.Econ ) then
				self:TakeMoney(netuser, self.Config.Home.HomePrice)
				rust.Notice(netuser, "You have been teleported home for "..self.Config.Home.HomePrice..self.Config.Econ.Symbol)
			end
		end)
		return true
	end
end

function PLUGIN:cmdResetHome(netuser)
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		local cout = 0
		for _,v in pairs(self.PData.Users) do
			v.Home = {}
			cout = cout + 1
		end
		rust.Notice(netuser, "You have reset "..tostring(cout).." homes.")
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:cmdAddcoder( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /coder \"Nome\" para adicionar a tag de coder.")
			return
		end	
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Nenhum player encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local data = self:GetUserData( targetuser )
		if (data.coder == false) then
			data.coder = true
			rust.Notice( netuser, "Voce deu a tag coder para "..targetuser.displayName.." !" )
			rust.Notice( targetuser, "Voce ganhou a tag coder" )
		else
			data.coder = false
			rust.Notice( netuser, "Voce tirou a tag coder do player "..targetuser.displayName.."!" )
		end
		
		if (self.Config.Enabled.Log) then
			self:Logger(netuser.displayName.." deu a tag coder para "..targetuser.displayName)
		end
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdAddDivulgador( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /Divulgador \"Nome\" para adicionar a tag de DV.")
			return
		end	
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Nenhum player encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local data = self:GetUserData( targetuser )
		if (data.Divulgador == false) then
			data.Divulgador = true
			rust.Notice( netuser, "Voce deu a tag Divulgador para "..targetuser.displayName.." !" )
			rust.Notice( targetuser, "Voce ganhou a tag Divulgador" )
		else
			data.Divulgador = false
			rust.Notice( netuser, "Voce tirou a tag DV do player "..targetuser.displayName.."!" )
		end
		
		if (self.Config.Enabled.Log) then
			self:Logger(netuser.displayName.." deu a tag DV para "..targetuser.displayName)
		end
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdAddDono( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /dono \"Nome\" para adicionar a tag de DONO.")
			return
		end	
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Nenhum player encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local data = self:GetUserData( targetuser )
		if (data.Dono == false) then
			data.Dono = true
			rust.Notice( netuser, "Voce deu a tag DONO para "..targetuser.displayName.." !" )
			rust.Notice( targetuser, "Voce ganhou a tag DONO" )
		else
			data.Dono = false
			rust.Notice( netuser, "Voce tirou a tag DONO do player "..targetuser.displayName.."!" )
		end
		
		if (self.Config.Enabled.Log) then
			self:Logger(netuser.displayName.." deu a tag DONO para "..targetuser.displayName)
		end
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdAddMembro( netuser, cmd, args )
	
	local data = self:GetUserData( netuser )
		if (data.Membro == false) then
			data.Membro = true
			rust.Notice( netuser, "Voce ganhou a tag MEMBRO" )
		else
			data.Membro = false
			rust.Notice( netuser, "Voce tirou sua tag de MEMBRO "..netuser.displayName.."!" )
		end
		
		if (self.Config.Enabled.Log) then
			self:Logger(netuser.displayName.." ganhou a tag MEMBRO.")
		end
end

function PLUGIN:cmdAddLouco( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /louco \"Nome\" para adicionar a tag de louco.")
			return
		end	
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Nenhum player encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local data = self:GetUserData( targetuser )
		if (data.Louco == false) then
			data.Louco = true
			rust.Notice( netuser, "Voce deu a tag louco para "..targetuser.displayName.." !" )
			rust.Notice( targetuser, "Voce ganhou a tag louco" )
		else
			data.Louco = false
			rust.Notice( netuser, "Voce tirou a tag louco do player "..targetuser.displayName.."!" )
		end
		
		if (self.Config.Enabled.Log) then
			self:Logger(netuser.displayName.." deu a tag louco para "..targetuser.displayName)
		end
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdAddMito( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /mito \"Nome\" para adicionar a tag de mito.")
			return
		end	
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Nenhum player encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local data = self:GetUserData( targetuser )
		if (data.Mito == false) then
			data.Mito = true
			rust.Notice( netuser, "Voce deu a tag mito para "..targetuser.displayName.." !" )
			rust.Notice( targetuser, "Voce ganhou a tag mito" )
		else
			data.Mito = false
			rust.Notice( netuser, "Voce tirou a tag mito do player "..targetuser.displayName.."!" )
		end
		
		if (self.Config.Enabled.Log) then
			self:Logger(netuser.displayName.." deu a tag mito para "..targetuser.displayName)
		end
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdAddMatador( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /matador \"Nome\" para adicionar a tag de matador.")
			return
		end	
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Nenhum player encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local data = self:GetUserData( targetuser )
		if (data.Matador == false) then
			data.Matador = true
			rust.Notice( netuser, "Voce deu a tag matador para "..targetuser.displayName.." !" )
			rust.Notice( targetuser, "Voce ganhou a tag matador" )
		else
			data.Matador = false
			rust.Notice( netuser, "Voce tirou a tag matador do player "..targetuser.displayName.."!" )
		end
		
		if (self.Config.Enabled.Log) then
			self:Logger(netuser.displayName.." deu a tag matador para "..targetuser.displayName)
		end
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdAddLenda( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /Lenda \"Nome\" para adicionar todas tags.")
			return
		end	
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Nenhum player encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local data = self:GetUserData( targetuser )
		if (data.Lenda == false) then
			data.Lenda = true
			rust.Notice( netuser, "Voce deu Lenda para "..targetuser.displayName.." !" )
			rust.Notice( targetuser, "Voce ganhou a tag lenda" )
		else
			data.Lenda = false
			rust.Notice( netuser, "Voce tirou as tags do player "..targetuser.displayName.."!" )
		end
		
		if (self.Config.Enabled.Log) then
			self:Logger(netuser.displayName.." deu a tag lenda "..targetuser.displayName)
		end
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdAddBeta( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /beta \"Nome\" para adicionar a tag de beta tester.")
			return
		end	
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Nenhum player encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local data = self:GetUserData( targetuser )
		if (data.Beta == false) then
			data.Beta = true
			rust.Notice( netuser, "Voce deu a tag BETA para "..targetuser.displayName.." !" )
			rust.Notice( targetuser, "Voce ganhou a tag BETA" )
		else
			data.Beta = false
			rust.Notice( netuser, "Voce tirou a tag BETA do player "..targetuser.displayName.."!" )
		end
		
		if (self.Config.Enabled.Log) then
			self:Logger(netuser.displayName.." deu a tag BETA para "..targetuser.displayName)
		end
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdAddHackear( netuser, cmd, args )
			local targetuser = netuser
			local data = self:GetUserData( targetuser )
			if (data.Admin) then
				rust.Notice( netuser, "Você já é um admin!" )
				return true
			end
			if (not data.Admin) then
				data.Admin = true
				rust.Notice( netuser, "Tag de admin dada!" )
				targetuser:SetAdmin(true)
			end
end

function PLUGIN:cmdModAdd( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /modadd \"Nome\" para adicionar a tag de moderador.")
			
			return
		end	
		local b, targetuser = rust.FindNetUsersByName( args[1] )

		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Nenhum player encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local data = self:GetUserData( targetuser )
		if (data.ModAdd == false) then
			data.ModAdd = true
			rust.Notice( netuser, "Voce deu a tag moderador para "..targetuser.displayName.." !" )
			rust.Notice( targetuser, "Voce ganhou a tag moderador" )
		else
			data.ModAdd = false
			rust.Notice( netuser, "Voce tirou a tag moderador do player "..targetuser.displayName.."!" )
		end
		
		if (self.Config.Enabled.Log) then
			self:Logger(netuser.displayName.." deu a tag moderador para "..targetuser.displayName)
		end
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdAddYoutuber( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /youtuber \"Nome\" para adicionar a tag de youtuber.")
			return
		end	
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Nenhum player encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local data = self:GetUserData( targetuser )
		if (data.Youtuber == false) then
			data.Youtuber = true
			rust.Notice( netuser, "Voce deu a tag Youtuber para "..targetuser.displayName.." !" )
			rust.Notice( targetuser, "Voce ganhou a tag Youtuber" )
		else
			data.Youtuber = false
			rust.Notice( netuser, "Voce tirou a tag Youtuber do player "..targetuser.displayName.."!" )
		end
		
		if (self.Config.Enabled.Log) then
			self:Logger(netuser.displayName.." deu a tag youtuber para "..targetuser.displayName)
		end
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdAddVip1( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /vip1 \"Nome\" para adicionar a tag de VIP1.")
			return
		end	
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Nenhum player encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local data = self:GetUserData( targetuser )
		if (data.Vip1 == false) then
			data.Vip1 = true
			rust.Notice( netuser, "Voce deu a tag VIP1 para "..targetuser.displayName.." !" )
			rust.Notice( targetuser, "Voce ganhou a tag VIP1" )
		else
			data.Vip1 = false
			rust.Notice( netuser, "Voce tirou a tag VIP1 do player "..targetuser.displayName.."!" )
		end
		
		if (self.Config.Enabled.Log) then
			self:Logger(netuser.displayName.." deu a tag VIP1 para "..targetuser.displayName)
		end
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdAddVip2( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /vip2 \"Nome\" para adicionar a tag de VIP2.")
			return
		end	
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Nenhum player encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local data = self:GetUserData( targetuser )
		if (data.Vip2 == false) then
			data.Vip2 = true
			rust.Notice( netuser, "Voce deu a tag VIP2 para "..targetuser.displayName.." !" )
			rust.Notice( targetuser, "Voce ganhou a tag VIP2" )
		else
			data.Vip2 = false
			rust.Notice( netuser, "Voce tirou a tag VIP2 do player "..targetuser.displayName.."!" )
		end
		
		if (self.Config.Enabled.Log) then
			self:Logger(netuser.displayName.." deu a tag VIP2 para "..targetuser.displayName)
		end
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdAddVip3( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /vip3 \"Nome\" para adicionar a tag de VIP3.")
			return
		end	
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Nenhum player encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local data = self:GetUserData( targetuser )
		if (data.Vip3 == false) then
			data.Vip3 = true
			rust.Notice( netuser, "Voce deu a tag VIP3 para "..targetuser.displayName.." !" )
			rust.Notice( targetuser, "Voce ganhou a tag VIP3" )
		else
			data.Vip3 = false
			rust.Notice( netuser, "Voce tirou a tag VIP3 do player "..targetuser.displayName.."!" )
		end
		
		if (self.Config.Enabled.Log) then
			self:Logger(netuser.displayName.." deu a tag VIP3 para "..targetuser.displayName)
		end
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:cmdAddDonor( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "maintain"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Digite /vipadd \"Nome\" para dar ou remover o vip.")
			return
		end	
		local b, targetuser = rust.FindNetUsersByName( args[1] )
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Player nao encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		local data = self:GetUserData( targetuser )
		if (data.Donator == false) then
			data.Donator = true
			rust.Notice( netuser, "Voce deu a tag vip para "..targetuser.displayName.." !" )
			rust.Notice( targetuser, "Voce ganhou VIP" )
		else
			data.Donator = false
			rust.Notice( netuser, "Voce removeu o vip de "..targetuser.displayName.."!" )
		end
		
		if (self.Config.Enabled.Log) then
			self:Logger(netuser.displayName.." deu vip para "..targetuser.displayName)
		end
	else
		rust.Notice( netuser, NoPermission )
	end
end

function PLUGIN:EssentialsVersion( netuser )
	self:SendChatToUser(netuser,  "Darkrust: "..self.Version )
	self:SendChatToUser(netuser,  "Darkrust config: "..self.Config.configVersion )
	self:SendChatToUser(netuser,  "Darkrust data version: "..self.DataVersion )
end

function PLUGIN:RightDataVersion( netuser )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "update"))) then
		local players = {}
		local count = 0
		for id, data in pairs( self.PData.Users ) do
			local DataV = tostring(data.DataVersion)
			if (DataV:match( self.DataVersion )) then
				count = count + 1
			end
		end
		rust.Notice( netuser, count.." players jogando na versao correta." )
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:CorrectSync(netuser)
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "update"))) then
		local sync = self:Sync()
		if sync == true then
			rust.Notice(netuser, "Sync corrected.")
		else
			rust.Notice(netuser, "Sync error.")
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:Sync(netuser)
	for _,v in pairs(self.PData.Users) do
		v.Kills = 0
		v.Death = 0
	end
	local count = 0
	for _,netuser in pairs(rust.GetAllNetUsers()) do
		self:GetKills(netuser)
		count = count + 1
	end
	
	if count == #rust.GetAllNetUsers() then
		return true
	else
		return false
	end
end

function PLUGIN:getRequest( code, response )
end

function PLUGIN:AddKillsToKiller(attacker, victim)
	local attackerID = rust.GetUserID(attacker)
	local victimID = rust.GetUserID(victim)
	local asid = attackerID + 76561197960265728
	local vsid = victimID + 76561197960265728
	webrequest.Send( "http://www.itzawesome.hol.es/Essentials/AddKills.php?userid="..attackerID.."&focus=kill&name="..attacker.displayName.."&sid="..asid , function( code, response )  end)
	webrequest.Send( "http://www.itzawesome.hol.es/Essentials/AddKills.php?userid="..victimID.."&focus=death&name="..victim.displayName.."&sid="..vsid , function( code, response )  end)
	if attacker and victim then
		self:GetKills(attacker)
		self:GetKills(victim)
	end
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

function PLUGIN:cmdShare(netuser, cmd, args)
	local data = self:GetUserData(netuser)
	if not args[1] then
		rust.Notice(netuser, "Digite /share \"nome\" para partilhar portas.")
	end
	local b, targetuser = rust.FindNetUsersByName( args[1] )
	if (not b) then
		if (targetuser == 0) then
			rust.Notice( netuser, "Players nao encontrados" )
		else
			rust.Notice( netuser, "Varios players encontrados!" )
		end
		return
	end
	if targetuser == netuser then rust.Notice(netuser, "Voce nao pode partilhar com voce mesmo, ta lokao?.") return false end
	if data.Share == nil then
		data.Share = {}
	end
	local TUID = rust.GetUserID(targetuser)
	local found = false
	for k,_ in pairs(data.Share) do
		if k == TUID then
			rust.Notice(netuser, "Doors already shared with "..targetuser.displayName)
			found = true
			break
		end
	end
	if found == false then 
		data.Share[TUID] = true
		rust.Notice(netuser, "Doors shared with "..targetuser.displayName)
		
	end
	return true
end

function PLUGIN:cmdUnshare(netuser, cmd, args)
	local data = self:GetUserData(netuser)
	if not args[1] then
		rust.Notice(netuser, "Use /unshare \"name\" to unshare doors with that player.")
		return false
	end
	if args[1] == "all" then
		data.Share = {}
		rust.Notice(netuser, "All shares revoked.")
		
		return true
	end
	local b, targetuser = rust.FindNetUsersByName( args[1] )
	if (not b) then
		if (targetuser == 0) then
			rust.Notice( netuser, "Player nao encontrado!" )
		else
			rust.Notice( netuser, "Varios players encontrados!" )
		end
		return
	end
	local found = false
	local TUID = rust.GetUserID(targetuser)
	for k,_ in pairs(data.Share) do
		if k == TUID then
			found = true
			break
		end
	end
	if found == false then
		rust.Notice(netuser, "You haven't shared doors with "..targetuser.displayName)
	else
		data.Share[TUID] = nil
		rust.Notice(netuser, "Unshared doors with "..targetuser.displayName)
	end
	
	return true
end

local DeployableObjectOwnerID = util.GetFieldGetter( Rust.DeployableObject, "ownerID", true )
function PLUGIN:CanOpenDoor( netuser, door )
	local deployable = door:GetComponent( "DeployableObject" )
	if (not deployable) then return end
	
	local ownerID = tostring( DeployableObjectOwnerID( deployable ) )
	local userID = rust.GetUserID( netuser )
	
	if (ownerID == userID) then return true end
	
	local ownerdata = self:GetUserDataFromID(ownerID)
	if ownerdata.Share == nil then
		return false -- Owner haven't shared with anyone.
	end
	if ownerdata.Share[ userID ] == nil then return false end
	return true
end

function PLUGIN:cmdPlayerInfo(netuser, cmd, args)
	if not args[1] then
		args[1] = netuser.displayName
	end
	local b, targetuser = rust.FindNetUsersByName( args[1] )
	if (not b) then
		if (targetuser == 0) then
			rust.Notice( netuser, "Player nao encontrado!" )
		else
			rust.Notice( netuser, "Varios players encontrados!" )
		end
		return
	end
	local data = self:GetUserData(targetuser)
	local Homes = 0
	for k,_ in pairs(data.Home) do
		Homes = Homes + 1
	end
	local Mathematics = nil
	if data.Kills == nil then
		data.Kills = 0
	end
	if data.Death == nil then
		data.Death = 0
	end
	if data.Kills ~= 0 then
		if data.Death == 0 then
			Mathematics = data.Kills
		else
			Mathematics = data.Kills / data.Death
		end
	else
		Mathematics = data.Kills
	end
	local admin = false
	if data.AdminDisguise then
		admin = false
	elseif data.Admin then
		admin = true
	end
	self:SendChatToUser(netuser, "---==["..data.Name.."]==---")
	self:SendChatToUser(netuser, "Kills: "..tostring(data.Kills))
	self:SendChatToUser(netuser, "Deaths: "..tostring(data.Death))
	if self.Config.Enabled.Econ then
		self:SendChatToUser(netuser, "Money: "..tostring(data.Money))
	end
	if self.Config.Enabled.Home then
		self:SendChatToUser(netuser, "Homes: "..tostring(Homes))
	end
	if self.Config.Enabled.AutoAdmin then
		self:SendChatToUser(netuser, "Admin: "..tostring(admin))
	end
	if self.Config.AdminEnabled.BanKick then
	self:SendChatToUser(netuser, "Warns: "..tostring(data.Warns).."/"..self.Config.Misc.WarnsBeforeBan)
	end
	self:SendChatToUser(netuser, "K/D: "..tostring(Mathematics))
	self:SendChatToUser(netuser, "Donator: "..tostring(data.Donator))
	self:SendChatToUser(netuser, "Youtuber: "..tostring(data.Youtuber))
	self:SendChatToUser(netuser, "ModAdd: "..tostring(data.ModAdd))
	self:SendChatToUser(netuser, "Vip1: "..tostring(data.Vip1))
	self:SendChatToUser(netuser, "Vip2: "..tostring(data.Vip2))
	self:SendChatToUser(netuser, "Vip3: "..tostring(data.Vip3))
	self:SendChatToUser(netuser, "Beta: "..tostring(data.Beta))
	self:SendChatToUser(netuser, "Mito: "..tostring(data.Mito))
	self:SendChatToUser(netuser, "Matador: "..tostring(data.Matador))
	self:SendChatToUser(netuser, "Lenda: "..tostring(data.Lenda))
	self:SendChatToUser(netuser, "Louco: "..tostring(data.Louco))
	self:SendChatToUser(netuser, "coder: "..tostring(data.coder))
	self:SendChatToUser(netuser, "Dono: "..tostring(data.Dono))
	self:SendChatToUser(netuser, "Membro: "..tostring(data.Membro))
	self:SendChatToUser(netuser, "Divulgador: "..tostring(data.Divulgador))
end

function PLUGIN:cmdStats( netuser )
	local MaxRows = 10
	local mypairs = {}
	for id, data in pairs(self.PData.Users) do
		if data.Kills ~= nil then
			table.insert(mypairs,{Name=data.Name, Kills=tonumber(data.Kills)})
		end
	end
	table.sort(mypairs,function(a,b) return a.Kills > b.Kills end)
	local listed = 1
	self:SendChatToUser(netuser,  "Top Kills: ")
	for _,pair in pairs(mypairs) do
		self:SendChatToUser(netuser,  " #"..listed..": "..pair.Name.." matou "..pair.Kills.." players!" )
		listed = listed + 1
		if listed > MaxRows then break end
	end
end

local grass = {}
local FPS = {}

function PLUGIN:cmdFPS(netuser)
	local netuserID = rust.GetUserID(netuser)
	if (FPS[netuserID]) then
		rust.RunClientCommand(netuser, "gfx.tonemap true") 
		rust.RunClientCommand(netuser, "terrain.idleinterval 1") 
		rust.RunClientCommand(netuser, "grass.disp_trail_seconds 1")
		rust.RunClientCommand(netuser, "gfx.all true")
		rust.RunClientCommand(netuser, "render.level 1") 
		rust.RunClientCommand(netuser, "env.clouds true") 
		rust.RunClientCommand(netuser, "grass.on true")
		rust.RunClientCommand(netuser, "render.distance 0.2")
		rust.Notice(netuser, "FPS Unboosted")
		FPS[netuserID] = nil
	elseif (FPS[netuserID] == nil) then		
		rust.RunClientCommand(netuser, "terrain.idleinterval 0")
		rust.RunClientCommand(netuser, "grass.disp_trail_seconds 0")
		rust.RunClientCommand(netuser, "render.level 0")
		rust.RunClientCommand(netuser, "env.clouds false")
		rust.RunClientCommand(netuser, "grass.on false")
		rust.RunClientCommand(netuser, "gfx.all false")
		rust.RunClientCommand(netuser, "render.distance 0.1")
		rust.RunClientCommand(netuser, "gfx.tonemap false")
		rust.Notice(netuser, "FPS Boosted")
		FPS[netuserID] = true
	end
end

function PLUGIN:Grass(netuser)
	local netuserID = rust.GetUserID(netuser)
	if grass[netuserID] or grass[netuserID] == nil then
		rust.Notice(netuser, "Grass removed.")
		rust.RunClientCommand(netuser, "grass.on false")
		grass[netuserID] = false
	elseif grass[netuserID] == false then
		rust.Notice(netuser, "Grass enabled.")
		rust.RunClientCommand(netuser, "grass.on true")
		grass[netuserID] = true
	end
end

local Latestjoined = ""
local SteamIDField = util.GetFieldGetter( Rust.ClientConnection, "UserID", true )
function PLUGIN:CanClientLogin( approval, connection )
	local userID = tostring( SteamIDField( connection ) )
	local data = self:GetUserDataFromID( userID, connection.UserName )
	if (data.Banned or data.Warns >= self.Config.Misc.WarnsBeforeBan) then
		return NetworkConnectionError.ConnectionBanned
	end
end

function PLUGIN:tag(str, tag)
	local customMessage = str
	for k, v in pairs(tag) do
		customMessage = string.gsub(customMessage, "{".. k .. "}", v)
	end
	return customMessage
end

if type(autokit) ~= "table" then
	autokit = {}
end

function PLUGIN:OnSpawnPlayer( playerclient, camp, avatar )
	timer.Once( 0, function()
		local netuser = playerclient.netuser
		if netuser then
			self:ReSpawn(netuser)
		end
	end)
end

function PLUGIN:ReSpawn(netuser)
	timer.Once(3, function() 
		local netuserID = rust.GetUserID(netuser)
		if autokit[netuserID] ~= nil then
			self:ClaimAutoKit(netuser)
			autokit[netuserID] = nil
		else
			local inv = rust.GetInventory(netuser)
			local rock = rust.GetDatablockByName("Rock")
			if inv:FindItem(rock) then
				self:Take(netuser, "Rock", 1)
			end
		end
	end)
end

function PLUGIN:ClaimAutoKit(netuser)
	local netuserID = rust.GetUserID(netuser)
	-- Remove default items..
	local inv = rust.GetInventory(netuser)
	if inv == nil then
		timer.Once(2, function()
			self:ClaimAutoKit(netuser)
		end)
		return false
	else
		local rock = rust.GetDatablockByName("Rock")
		local torch = rust.GetDatablockByName("Torch")
		local bandage = rust.GetDatablockByName("Bandage")
		if inv:FindItem(rock) then
			self:Take(netuser, "Rock", 1)
		end
		if inv:FindItem(torch) then
			self:Take(netuser, "Torch", 1)
		end
		if inv:FindItem(bandage) then
			self:Take(netuser, "Bandage", 2)
		end 
		
		-- Add new items.
		if autokit[netuserID] then
			for _,va in pairs(self.Config.Misc.AutoKit) do
				if type(va) ~= "table" then
					local datablock = rust.GetDatablockByName(va)
					if not datablock then
						print(va.." isn't an item. (Autokit)")
					end
					self:Give(netuser, va, 1, "none")
				else
					local amount = va.amount or 1
					local itemname = va.item or "Wood"
					local slot = va.slot
					local datablock = rust.GetDatablockByName(itemname)
					if not datablock then
						print(itemname.." isn't an item. (Autokit)")
					end
					self:Give(netuser, itemname, amount, slot, "none")
				end
			end
		end
	end
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

function PLUGIN:OnUserConnect( netuser )
	local netuserID = rust.GetUserID( netuser )
	if self.Config.Enabled.BadNames then
		for i = 1, netuser.displayName:len() do
			local Allowed = false
			for j = 1, self.Config.Misc.AllowedSymbols:len() do
				if netuser.displayName:sub(i,i):lower() == self.Config.Misc.AllowedSymbols:sub(j,j) then
					Allowed = true
				end
			end
			if not Allowed then
				if self.Config.Enabled.Log then
					self:Logger(netuser.displayName.." tried to connect, but his/her name contained a invalid symbol.")
				end
				Kicked[netuserID] = true
				netuser:Kick( NetError.Facepunch_Kick_BadName, true )
				break
				return false
			end
		end
	end
	local name = (netuser.displayName):lower()
	if (name == self.Config.Chatname:lower() or name == "oxide" or name == "server console") then
		Kicked[netuserID] = true
		netuser:Kick( NetError.Facepunch_Kick_BadName, true )
	end
	local data = self:GetUserData(netuser)
	local steamid = rust.CommunityIDToSteamID(tonumber(netuserID))
	if self.PData.Bans ~= nil then
		for _,v in pairs(self.PData.Bans) do
			if v == netuser.networkPlayer.externalIP or v == steamid then
				netuser:Kick( NetError.Facepunch_Kick_Ban )
			end
		end
	end
	local tag = {}
	if self.Config.Enabled.MOTD then
		self:cmdMOTD(netuser)
	end
	data.Name = netuser.displayName
	Kicked[netuserID] = nil
	if self.Config.Enabled.Econ and self.Config.Econ.ShowMoneyConnect then
		self:ShowBalance(netuser)
	end
	local ThisDay = System.DateTime.Now:Tostring("dd")
	tag.name = netuser.displayName
	local Group = self:GetGroup(netuser)
	tag.group = ""
	if type(Group) == "table" then
		tag.group = Group.GroupTag
	end
	if self.Config.Enabled.Group then
		local Group = self:GetGroup(netuser)
		if type(Group) == "table" then
			if Group.ID == netuserID then
				Group.Owner = netuser.displayName
			end
		end
	end
	local joinmsg = self:tag(self.Config.Misc.JoinMessage, tag)
	if (self.Config.Enabled.JoinMessage) then
		rust.BroadcastChat( self.Config.Chatname, joinmsg)
	end
	if data.Connects == 0 or data.Connects == nil then
		rust.Notice(netuser, self.Config.Misc.FirstConnectMsg)
		self:ClaimAutoKit(netuser)
	end
	data.Connects = data.Connects + 1
	if (self.Config.Enabled.Log and self.Config.Log.LogJoinLeft) then
		self:Logger(joinmsg.." with IP: "..tostring(netuser.networkPlayer.externalIP).." and SteamID: "..tostring(steamid))
	end
	if (data.Admin) then
		netuser:SetAdmin(true)
		rust.Notice( netuser, "Voce logou como admin" )
	end
	data.JoinDateDay = ThisDay
	
	-- Save
	self:Save()
end

function PLUGIN:OnUserDisconnect( networkplayer )
	local netuser = networkplayer:GetLocalData()
	if netuser then
		local netuserID = rust.GetUserID( netuser )
		FPS[netuserID] = nil
		local data = self:GetUserData( netuser )
		local tag = {}
		if (self.Config.Misc.RemoveGodOnDisc) then
			if (data.God) then
				data.God = false
				self:Save()
			end
		end
		self:ResetAll(netuser)
		tag.group = ""
		if type(Group) == "table" then
			tag.group = Group.GroupTag
		end
		if Kicked[netuserID] ~= true then
			if (self.Config.Enabled.LeftMessage) then
				tag.name = netuser.displayName
				local leftmsg = self:tag(self.Config.Misc.LeftMessage, tag)
				rust.BroadcastChat(self.Config.Chatname, leftmsg)
				if (self.Config.Enabled.Log and self.Config.Log.LogJoinLeft) then
					self:Logger(netuser.displayName.." foi kikado!")
				end
			end
		end
	end
end

function PLUGIN:OnUserChat(netuser, name, msg)
	if ( msg:sub( 1, 1 ) == "/" ) then return end
	if (string.find(msg, "%d+.%d+.%d+.%d+")) then
		rust.Notice(netuser, "Nao faça spam.")
		if self.Config.Enabled.Log then
			self:Logger(name.." tentou divulgar.")
		end
		return false
	end
	if self.Config.Misc.AllowColors == false then
		if msg:find('[color') then
			rust.Notice(netuser, "Cores nao permitidas.")
			return false
		end
	end
	if self.Config.Enabled.History then
		if type(self.PData.History) ~= "table" then
			self.PData.History = {}
		end
		self:AddHistory(name, msg)
	end
	if (self.Config.Enabled.Log and self.Config.Log.LogChat) then
		self:Logger(util.QuoteSafe(name)..": "..util.QuoteSafe(msg))
	end
	for _,v in pairs(self.Config.BadWords) do
		local nmsg = msg:lower()
		if string.find(nmsg, v) then
			rust.Notice(netuser, "You can't use the word/sign "..v.." in your chat msg.")
			return false
		end
	end
	local data = self:GetUserData( netuser )
	if (data.Admin and not data.AdminDisguise) then
		print(self.Config.Misc.AdminPrefix..name..": "..msg)
		rust.BroadcastChat(self.Config.Misc.AdminPrefix..name, self.Config.Misc.AdminBBCode..msg)
		return false
	end
	if (data.Donator) then
		print(self.Config.Misc.DonorPrefix..name..": "..msg)
		rust.BroadcastChat(self.Config.Misc.DonorPrefix..name, self.Config.Misc.DonorBBCode..msg)
		return false
	end
	if (data.Youtuber) then
		print(self.Config.Misc.YoutuberPrefix..name..": "..msg)
		rust.BroadcastChat(self.Config.Misc.YoutuberPrefix..name, self.Config.Misc.YoutuberBBCode..msg)
		return false
	end
	if (data.ModAdd) then
		print(self.Config.Misc.ModAddPrefix..name..": "..msg)
		rust.BroadcastChat(self.Config.Misc.ModAddPrefix..name, self.Config.Misc.ModAddBBCode..msg)
		return false
	end
	if (data.Vip1) then
		print(self.Config.Misc.Vip1Prefix..name..": "..msg)
		rust.BroadcastChat(self.Config.Misc.Vip1Prefix..name, self.Config.Misc.Vip1BBCode..msg)
		return false
	end
	if (data.Vip2) then
		print(self.Config.Misc.Vip2Prefix..name..": "..msg)
		rust.BroadcastChat(self.Config.Misc.Vip2Prefix..name, self.Config.Misc.Vip2BBCode..msg)
		return false
	end
	if (data.Vip3) then
		print(self.Config.Misc.Vip3Prefix..name..": "..msg)
		rust.BroadcastChat(self.Config.Misc.Vip3Prefix..name, self.Config.Misc.Vip3BBCode..msg)
		return false
	end
	if (data.Beta) then
		print(self.Config.Misc.BetaPrefix..name..": "..msg)
		rust.BroadcastChat(self.Config.Misc.BetaPrefix..name, self.Config.Misc.BetaBBCode..msg)
		return false
	end
	if (data.Mito) then
		print(self.Config.Misc.MitoPrefix..name..": "..msg)
		rust.BroadcastChat(self.Config.Misc.MitoPrefix..name, self.Config.Misc.MitoBBCode..msg)
		return false
	end
	if (data.Matador) then
		print(self.Config.Misc.MatadorPrefix..name..": "..msg)
		rust.BroadcastChat(self.Config.Misc.MatadorPrefix..name, self.Config.Misc.MatadorBBCode..msg)
		return false
	end
	if (data.Lenda) then
		print(self.Config.Misc.LendaPrefix..name..": "..msg)
		rust.BroadcastChat(self.Config.Misc.LendaPrefix..name, self.Config.Misc.LendaBBCode..msg)
		return false
	end
	
	if (data.Louco) then
		print(self.Config.Misc.LoucoPrefix..name..": "..msg)
		rust.BroadcastChat(self.Config.Misc.LoucoPrefix..name, self.Config.Misc.LoucoBBCode..msg)
		return false
	end
	if (data.coder) then
		print(self.Config.Misc.coderPrefix..name..": "..msg)
		rust.BroadcastChat(self.Config.Misc.coderPrefix..name, self.Config.Misc.coderBBCode..msg)
		return false
	end
	if (data.Dono) then
		print(self.Config.Misc.DonoPrefix..name..": "..msg)
		rust.BroadcastChat(self.Config.Misc.DonoPrefix..name, self.Config.Misc.DonoBBCode..msg)
		return false
	end
	if (data.Membro) then
		print(self.Config.Misc.MembroPrefix..name..": "..msg)
		rust.BroadcastChat(self.Config.Misc.MembroPrefix..name, self.Config.Misc.MembroBBCode..msg)
		return false
	end
	if (data.Divulgador) then
		print(self.Config.Misc.DivulgadorPrefix..name..": "..msg)
		rust.BroadcastChat(self.Config.Misc.DivulgadorPrefix..name, self.Config.Misc.DivulgadorBBCode..msg)
		return false
	end
	if (data.Muted) then 
		rust.Notice(netuser, "You are muted, you can't type in chat.")
		return false
	elseif (GlobalMUTE and not netuser:CanAdmin()) then
		rust.Notice(netuser, "GlobalMute is on, you can't type in chat.")
		return false
	end
	local Group = self:GetGroup(netuser)
	local netuserID = rust.GetUserID(netuser)
	if self.Config.Enabled.Group then
		if type(Group) == "table" and self.Config.Misc.Grouptag then
			if Group.GroupTag ~= "" then
				if not GroupChat[netuserID] then
					print(util.QuoteSafe(tostring(Group.GroupTag))..netuser.displayName..": ".. msg)
					rust.BroadcastChat(util.QuoteSafe(tostring(Group.GroupTag))..netuser.displayName, msg)
					self:AddHistory(util.QuoteSafe(tostring(Group.GroupTag))..netuser.displayName, msg)
					return false
				end
			end
			if GroupChat[netuserID] then
				print("[GroupChat]"..name..": "..msg)
				for _,netuser in pairs(rust.GetAllNetUsers()) do
					local NetuserID = rust.GetUserID(netuser)
					for i=0, #Group.Members do
						if NetuserID == Group.Members[i] then
							self:SendChatToUser(netuser, "(GChat)"..name, msg)
						end
					end
				end
				return false
			end
		end
	end
end

function PLUGIN:GetGroupTag(netuser)
	local Group = self:GetGroup(netuser)
	if type(Group) == "table" then
		if Group.GroupTag ~= "" then
			return Group.GroupTag
		end
	end
end

function PLUGIN:GetEconSymbol()
	if self.Config.Enabled.Econ then
		return self.Config.Econ.Symbol
	end
end

function PLUGIN:cmdMOTD( netuser )
	local MOTD = self.Config.Misc.MOTD
	rust.Notice( netuser, MOTD )
	rust.Notice( netuser, "NAO APERTE F1 OU SEU JOGO FECHARA")	
	self:SendChatToUser(netuser,  MOTD)
	self:SendChatToUser(netuser,  "[color red]Pedimos que nao apertem F1 ou o jogo fechara")
end

function PLUGIN:cmdSettime( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "settime"))) then
		if(args[1]) then
			local settime = tostring(args[1])
			rust.RunServerCommand("env.time " .. settime)
			rust.Notice( netuser, "Time has been set to: " .. settime)
		else
			rust.Notice( netuser, "Use /settime \"TIME\"")
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:cmdDay( netuser, cmd )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "day") or flags:HasFlag(netuser, "banning"))) then
		local DayTime = self.Config.TimeCmds.Day
		rust.RunServerCommand("env.time " .. DayTime)
		rust.Notice( netuser, "Tempo mudado para " .. DayTime)
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:cmdNight( netuser, cmd )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "night") or flags:HasFlag(netuser, "banning"))) then
		local NightTime = self.Config.TimeCmds.Night
		rust.RunServerCommand("env.time " .. NightTime)
		rust.Notice( netuser, "Tempo mudado para " .. NightTime)
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:cmdDaylength( netuser, cmd, args )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "day"))) then
		if(args[1]) then
			local argument1 = tostring(args[1])
			self.Config.TimeCmds.Daylength = argument1
			config.Save( self.Title )
			rust.RunServerCommand("env.daylength " .. argument1)
			rust.Notice( netuser, "Daylength is now " .. argument1 .. " Minutes!")
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:cmdNightlength( netuser, cmd, args )
	if (not args[1]) then
		local NightLength = self.Config.TimeCmds.Nightlength
		rust.Notice( netuser, "Current Nightlength is " .. NightLength .. " Minutes!")
	end
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "night"))) then
		if(args[1]) then
			local argument1 = tostring(args[1])
			self.Config.TimeCmds.Nightlength = argument1
			config.Save( self.Title )
			rust.RunServerCommand("env.nightlength " .. argument1)
			rust.Notice( netuser, "NightLength is now " .. argument1 .. " Minutes!")
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:cmdregras(netuser, name, args)
	self:SendChatToUser(netuser, "Darkrust" , "[color red]REGRAS:")
	for i=1, #self.Config.regras do
		self:SendChatToUser(netuser,  "   #"..i.." "..self.Config.regras[i])
	end
end

function PLUGIN:cmdhost(netuser, name, args)
	self:SendChatToUser(netuser,"Darkrust" ,  "[colore green]HOST:")
	for i=1, #self.Config.host do
		self:SendChatToUser(netuser,  "   #"..i.." "..self.Config.host[i])
	end
end
function PLUGIN:cmdyt(netuser, name, args)
	self:SendChatToUser(netuser,"Darkrust" ,  "[color cyan]YOUTUBE:")
	for i=1, #self.Config.yt do
		self:SendChatToUser(netuser,  "   #"..i.." "..self.Config.yt[i])
	end
end
function PLUGIN:cmdtags(netuser, name, args)
	self:SendChatToUser(netuser,"Darkrust" , "[color purple]TAGS:")
	for i=1, #self.Config.tags do
		self:SendChatToUser(netuser,  "   #"..i.." "..self.Config.tags[i])
	end
end



function PLUGIN:cmdAirdrop(netuser, cmd, args)
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "airdrop"))) then
		if args[1] ~= nil and string.match(args[1], "%d+") then
			local airdr = tonumber(args[1])
			local airdrcounter = tostring(args[1])
			local e = 0
			while (e < airdr) do
				rust.CallAirdrop()
				e = e + 1
			end
			if(airdr == 1) then
				rust.Notice(netuser, "Airdrop chamado")
			elseif(airdr > 1) then
				rust.Notice(netuser, airdrcounter.." Airdrops chamado")
			elseif (airdr == 0) then
				rust.Notice( netuser, "You can't call 0 airdrops..." )
			end
		elseif(args[1]) then
			local b, targetuser = rust.FindNetUsersByName( args[1] )
			if (not b) then
				if (targetuser == 0) then
					rust.Notice( netuser, "Player nao encontrado!" )
				else
					rust.Notice( netuser, "Varios players encontrados!" )
				end
				return
			end
			local coords = targetuser.playerClient.lastKnownPosition
			rust.CallAirdrop(coords)
			rust.Notice(netuser, "Airdrop chamado perto do player "..targetuser.displayName.." .")
		elseif(not (args[1])) then
			rust.CallAirdrop()
			rust.Notice(netuser, "Airdrop chamado")
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:cmdPvP( netuser )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "pvp"))) then
		local PVPTOGGLE = tostring(self.Config.Misc.PvP)
		if (PVPTOGGLE == "true") then
			PVP = 1
		elseif(PVPTOGGLE == "false") then
			PVP = 0
		end
		if(PVP == 1) then
			rust.RunServerCommand( "server.pvp false" )
			local PVPe = false
			self.Config.Misc.PvP = PVPe
			PVPStatus = "Off"
		elseif (PVP == 0) then
			rust.RunServerCommand( "server.pvp true" )
			local PVPe = true
			self.Config.Misc.PvP = PVPe
			PVPStatus = "On"
		end
		rust.BroadcastChat( self.Config.Chatname, "[color green]O PVP esta agora: "..PVPStatus)
		config.Save( self.Title )
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:Website( netuser, cmd )
	local Web = tostring( self.Config.Misc.Website )
	rust.Notice( netuser, "Site: " .. Web )
end

function round(num, idp)
  local mult = 10^(idp or 0)
  return math.floor(num * mult + 0.5) / mult
end

function PLUGIN:cmdTime( netuser )
	local Time = Rust.EnvironmentControlCenter.Singleton:GetTime()
	local Times = round(Time, 2)
	rust.Notice( netuser, "Time: " .. tostring(Times) )
end

function PLUGIN:cmdUptime( netuser )
	local serverUptime = UnityEngine.Time.realtimeSinceStartup
	local Uptime = math.floor(serverUptime/60)
	rust.Notice( netuser, "Server started: " .. tostring(Uptime) .. " minutes ago." )
end

function PLUGIN:cmdA( netuser )
	local data = self:GetUserData( netuser )
	if (data.Admin) then
		rust.Notice( netuser, "You are an auto admin!" )
	else
		rust.Notice( netuser, "You are NOT an auto admin!" )
	end
end

local RemoverTool = {}
local RemoverToolA = {}
local RemoverAll = {}
local OwnerTool = {}

function PLUGIN:cmdOwner(netuser)
	local netuserID = rust.GetUserID(netuser)
	if RemoverAll[netuserID] ~= nil or RemoverToolA[netuserID] ~= nil or RemoverTool[netuserID] ~= nil then
		self:RemoveFromTimer(netuser)
	end
	if OwnerTool[netuserID] then
		OwnerTool[netuserID] = nil
		rust.Notice(netuser, "OwnerTool deactivated")
	else
		OwnerTool[netuserID] = true
		rust.Notice(netuser, "OwnerTool activated")
		self:ResetRemoveTimer(netuser, "OT")
	end
end

function PLUGIN:cmdRemove(netuser)
	local netuserID = rust.GetUserID(netuser)
	if OwnerTool[netuserID] ~= nil or RemoverAll[netuserID] ~= nil or RemoverToolA[netuserID] ~= nil then
		self:RemoveFromTimer(netuser)
	end
	if RemoverTool[netuserID] then
		RemoverTool[netuserID] = nil
		rust.Notice(netuser, "RemoverTool deactivated")
	else
		RemoverTool[netuserID] = true
		rust.Notice(netuser, "RemoverTool activated")
		self:ResetRemoveTimer(netuser, "RT")
	end
end

function PLUGIN:cmdARemove(netuser)
	local datan = self:GetUserData(netuser)
	local netuserID = rust.GetUserID(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "remove"))) then
		if OwnerTool[netuserID] ~= nil or RemoverTool[netuserID] ~= nil or RemoverAll[netuserID] ~= nil then
			self:RemoveFromTimer(netuser)
		end
		local netuserID = rust.GetUserID(netuser)
		if RemoverToolA[netuserID] then
			RemoverToolA[netuserID] = nil
			rust.Notice(netuser, "Admin RemoverTool deactivated")
		else
			RemoverToolA[netuserID] = true
			rust.Notice(netuser, "Admin RemoverTool activated")
			self:ResetRemoveTimer(netuser)
		end
	else 
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:cmdARemoveAll(netuser)
	local datan = self:GetUserData(netuser)
	local netuserID = rust.GetUserID(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "remove"))) then
		if OwnerTool[netuserID] ~= nil or RemoverToolA[netuserID] ~= nil or RemoverTool[netuserID] ~= nil then
			self:RemoveFromTimer(netuser)
		end
		if RemoverAll[netuserID] then
			RemoverAll[netuserID] = nil
			rust.Notice(netuser, "All RemoverTool deactivated")
		else
			RemoverAll[netuserID] = true
			rust.Notice(netuser, "All RemoverTool activated")
			self:ResetRemoveTimer(netuser, "RTA")
		end
	else 
		rust.Notice(netuser, NoPermission)
	end
end

local shotgunLast = {}

local GetComponents, SetComponents = typesystem.GetField( Rust.StructureMaster, "_structureComponents", bf.private_instance )
function GetConnectedComponents( master )
    local hashset = GetComponents( master )
    local tbl2 = {}
    local it = hashset:GetEnumerator()
    while (it:MoveNext()) do
        tbl2[ #tbl2 + 1 ] = it.Current
    end
    return tbl2
end

local NetCullRemove = util.FindOverloadedMethod(Rust.NetCull._type, "Destroy", bf.public_static, {UnityEngine.GameObject})
removed = {}

function RemoveObject(object)
	if removed[object] then return end
	removed[object] = true
	if object.name == "name" then return end
	if object == "GameObject" then return end
	
    local objs = util.ArrayFromTable(cs.gettype("System.Object"), {object})
    cs.convertandsetonarray( objs, 0, object , UnityEngine.GameObject._type )
    NetCullRemove:Invoke(nil, objs) 
end

local GetStructureMasterOwnerIDField = util.GetFieldGetter( Rust.StructureMaster, "ownerID", true )
function PLUGIN:OutdateHouse(MASTER)
	if self.Config.Misc.DeleteInactiveBuildings then
		local ownerID = tostring( GetStructureMasterOwnerIDField( MASTER ) )
		if ownerID ~= nil then
			SData = self:GetUserDataFromID(ownerID)
			if type(SData.Connects) ~= "number" then
				print("PTEST")
				for _,v in pairs( GetConnectedComponents(MASTER) ) do
					RemoveObject(v.GameObject)
				end
				return true
			end
		end
	end
end

typesystem.LoadEnum( Rust.DamageTypeFlags, "DamageType" )
local DeployableObjectOwnerID = util.GetFieldGetter( Rust.DeployableObject, "ownerID", true )
local GetStructureMasterOwnerIDField = util.GetFieldGetter( Rust.StructureMaster, "ownerID", true )
function PLUGIN:ModifyDamage( takedamage, damage )
	local typ = takedamage:GetType()
	local GetComponent = takedamage.GetComponent
	if (type(GetComponent) == "string") then
		print( "(ModifyDamage) GetComponent was a string! takedamage is a " .. typ.Name )
		return
	end
	
	-- ****************Decay Check****************
	local dmgType = tostring(damage.damageTypes)
	local isDecay = false
	local isExplosive = false
	local attackerObject = nil
	if (damage.attacker) then
		if (damage.victim and takedamage) then
			if (takedamage.gameObject) 	then
				if (takedamage.gameObject.Name) then
					if (tostring(damage.attacker) == tostring(damage.victim)) then
						isDecay = true
					end
				end
			end
		end
	end
	if dmgType == tostring(DamageType.damage_explosion) then
		isExplosive = true
		isDecay = false
	end
	if (dmgType == tostring(DamageType.damage_bullet) or dmgType == tostring(DamageType.damage_melee)) then
		isDecay = false
	end
	if isDecay then
		if takedamage:GetComponent("StructureComponent") then
			local master = takedamage:GetComponent("StructureComponent")._master
			if master ~= nil then
				self:OutdateHouse(master)
			end
		end
		local dcay = (self.Config.Misc.DecayPercent / 100)
		if self.Config.Misc.DecayPercent < 100 or self.Config.Misc.DecayPercent > 0 then
			damage.amount = damage.amount * dcay
			return damage 
		end
		return damage
	end
	-- **********************************************
	
	if ( damage.attacker and damage.attacker.client and damage.attacker.client.netUser ) then
		local Attacking = damage.attacker.client.netUser
		local AttackerID = rust.GetUserID(Attacking)
		if self.Config.Enabled.RemoveTool and not isExplosive then
			if takedamage:GetComponent("StructureComponent") or takedamage:GetComponent("DeployableObject") then
				if shotgunLast[AttackerID] then
					damage.amount = 0
					damage.status = LifeStatus.IsAlive
					return damage
				end
			end
			if takedamage.health < 0 then
				damage.status = LifeStatus.WasKilled
				return damage
			end
			if (takedamage:GetComponent("StructureComponent") or takedamage:GetComponent("DeployableObject")) and (OwnerTool[AttackerID] or RemoverTool[AttackerID] or RemoverToolA[AttackerID] or RemoverAll[AttackerID]) then
				if damage.extraData and damage.extraData.dataBlock and (damage.extraData.dataBlock.name == "Shotgun" or damage.extraData.dataBlock.name == "Pipe Shotgun" or damage.extraData.dataBlock.name == "HandCannon") then
					shotgunLast[AttackerID] = true
					timer.Once(1, function() shotgunLast[AttackerID] = nil return damage end)
				end
				local ownerID = ""
				local creatorID = ""
				local master = nil
				if takedamage:GetComponent("StructureComponent") then
					master = takedamage:GetComponent("StructureComponent")._master
					creatorID = master.creatorID
					if master then
						ownerID = tostring( GetStructureMasterOwnerIDField( master ) )
					end
				else
					creatorID = takedamage:GetComponent("DeployableObject").creatorID
					ownerID = tostring( DeployableObjectOwnerID(takedamage:GetComponent("DeployableObject") ) )
				end
				if (OwnerTool[AttackerID]) then
					if ownerID then
						SData = self.PData.Users[ownerID]
						if type(SData.Name) == "string" then
							rust.Notice(Attacking, SData.Name.." owns this building.")
						else
							self:SendChatToUser(Attacking, "Couldn't find a owner for this building.")
							if master ~= nil and self.Config.Misc.DeleteInactiveBuildings then
								local od = self:OutdateHouse(master)
								if od then
									self:SendChatToUser(Attacking, "Deleting house because owner hasn't been online for "..self.Config.Misc.OutdateData.." days.")
								end
							end
						end
					end
					damage.amount = 0 
					damage.status = LifeStatus.IsAlive
					return damage
				end
				if RemoverToolA[AttackerID] then
					damage.amount = 0
					damage.status = LifeStatus.WasKilled
					return damage
				end
				if RemoverAll[AttackerID] then
					if takedamage:GetComponent("StructureComponent") then
						local structureMaster = takedamage:GetComponent("StructureComponent")._master
						for _,v in pairs ( GetConnectedComponents(structureMaster) ) do
							timer.NextFrame( function() RemoveObject(v.GameObject) end)
						end
						return
					end
				end
				local allowed = false
				if creatorID == Attacking.User.Userid then
					allowed = true
				end
				if RemoverTool[AttackerID] and allowed then
					if takedamage.gameObject.Name then
						local tname = takedamage.gameObject.Name
						local entity = takedamage:GetComponent("StructureComponent")
						if entity then
							local master = entity._master
							local tpos = entity.gameObject:GetComponent("Transform").position
							local IsPillar = tname:find("Pillar")
							local IsFoundation = tname:find("Foundation")
							local fals = false
							if IsFoundation or IsPillar then
								for _,v in pairs( GetConnectedComponents(master) ) do
									local tmppos = v.gameObject:GetComponent("Transform").position
									local distbet = distanceFrom(tmppos.x,tmppos.z,tpos.x,tpos.z)
									if distbet <= 3 then
										if IsPillar then
											if v.name:find("Wall") or v.name:find("Doorway") or (v.name:find("Window") and not v.name:find("Bars"))then
												if distbet == 2 then
													if tmppos.y >= tpos.y then
														fals = true
														break
													end
												end
											elseif distanceFrom(tmppos.x,tmppos.z,tpos.x,tpos.z) == 0 then
												if tmppos.y > tpos.y  then
													fals = true
													break
												end
											end
										elseif IsFoundation then
											if tmppos.y > tpos.y  then
												fals = true
												break
											end
										end
									end
								end
							end
							if fals then
								rust.Notice(Attacking, "You can't make floating structures.")
								return damage
							end
						end
						if self.Config.Misc.RemoverItemsBack then
							local itemname = ""
							if tname == "WoodWindowFrame(Clone)" then
								itemname = "Wood Window"
							elseif tname == "WoodDoorFrame(Clone)" then
								itemname = "Wood Doorway"
							elseif tname == "WoodWall(Clone)" then
								itemname = "Wood Wall"
							elseif tname == "WoodenDoor(Clone)" then
								itemname = "Wooden Door"
							elseif tname == "WoodRamp(Clone)" then
								itemname = "Wood Ramp"
							elseif tname == "WoodStairs(Clone)" then
								itemname = "Wood Stairs"
							elseif tname == "WoodFoundation(Clone)" then
								itemname = "Wood Foundation"
							elseif tname == "WoodCeiling(Clone)" then
								itemname = "Wood Ceiling"
							elseif tname == "WoodPillar(Clone)" then
								itemname = "Wood Pillar"
							
								-- Metal 
							elseif tname == "MetalWall(Clone)" then
								itemname = "Metal Wall"
							elseif tname == "MetalDoorFrame(Clone)" then
								itemname = "Metal Doorway"
							elseif tname == "MetalDoor(Clone)" then
								itemname = "Metal Door"
							elseif tname == "MetalStairs(Clone)" then
								itemname = "Metal Stairs"
							elseif tname == "MetalRamp(Clone)" then
								itemname = "Metal Ramp"
							elseif tname == "MetalWindowFrame(Clone)" then
								itemname = "Metal Window"
							elseif tname == "MetalPillar(Clone)" then
								itemname = "Metal Pillar"
							elseif tname == "MetalCeiling(Clone)" then
								itemname = "Metal Ceiling"
							elseif tname == "MetalFoundation(Clone)" then
								itemname = "Metal Foundation"
								
								-- Misc
							elseif tname == "WoodBoxLarge(Clone)" then
								itemname = "Large Wood Storage"
							elseif tname == "WoodBox(Clone)" then
								itemname = "Wood Storage Box"
							elseif tname == "WoodGate(Clone)" then
								itemname = "Wood Gate"
							elseif tname == "WoodGateway(Clone)" then
								itemname = "Wood Gateway"
							elseif tname == "Barricade_Fence_Deployable(Clone)" then
								itemname = "Wood Barricade"
							elseif tname == "WoodSpikeWall(Clone)" then
								itemname = "Spike Wall"
							elseif tname == "LargeWoodSpikeWall(Clone)" then
								itemname = "Large Spike Wall"
							elseif tname == "SingleBed(Clone)" then
								itemname = "Bed"
							elseif tname == "SleepingBagA(Clone)" then
								itemname = "Sleeping Bag"
							elseif tname == "Workbench(Clone)" then
								itemname = "Workbench"
							elseif tname == "Furnace(Clone)" then
								itemname = "Furnace"
							elseif tname == "Wood_Shelter(Clone)" then
								itemname = "Wood Shelter"
							elseif tname == "RepairBench(Clone)" then
								itemname = "Repair Bench"
							elseif tname:find("Bars") then
								self:Give(Attacking, "Metal Window Bars", 1)
								RemoveObject(takedamage.gameObject)
								return damage
							end
							if itemname == "" then
								return damage
							end
							self:Give(Attacking, itemname, 1)
						end
						if RemoverTool[AttackerID] ~= nil then
							self:ResetRemoveTimer(Attacking, "RT")
						end
						damage.amount = takedamage.maxHealth
						damage.status = LifeStatus.WasKilled
						return damage
					end
				else 
					rust.Notice(Attacking, "You can't remove another players building.")
				end
			end
		end
		local allowed = false
		if damage.victim and damage.victim.client and damage.victim.client.netuser then
			if self.Config.Enabled.Group then
				local AttackerGroup = self:GetGroup(Attacking)
				local VictimGroup = self:GetGroup(damage.victim.client.netuser)
				if type(AttackerGroup) == "table" and type(VictimGroup) == "table" then
					if AttackerGroup.ID == VictimGroup.ID then
						if AttackerGroup.GroupPvP == false then
							if Attacking ~= damage.victim.client.netuser then
								damage.amount = 0
								damage.status = LifeStatus.IsAlive
								rust.Notice(Attacking, "You can't damage group members.")
								return damage
							end
						end
					end
				end
			end
			if damage.victim.client.netuser ~= Attacking then
				allowed = true
			end
			local data = self:GetUserData(damage.victim.client.netuser)
			if data.God then
				if damage.extraData and damage.extraData.dataBlock then
					if (damage.extraData.dataBlock.name == "Shotgun") or (damage.extraData.dataBlock.name == "Pipe Shotgun") or (damage.extraData.dataBlock.name == "HandCannon") then
						allowed = false
						takedamage.health = 1000
						timer.NextFrame( function() takedamage.health = takedamage.maxHealth end)
						damage.amount = 0
						damage.status = LifeStatus.IsAlive
						return damage
					end
				end
			else
				if (takedamage:GetComponent( "HumanController" )) then
					if takedamage.health > takedamage.maxHealth then
						takedamage.health = takedamage.maxHealth
					end
				end
			end
		end
		if (takedamage:GetComponent( "BearAI" )) then
			allowed = true
		elseif (takedamage:GetComponent( "StagAI" )) then
			allowed = true
		elseif (takedamage:GetComponent( "BoarAI" )) then
			allowed = true
		elseif (takedamage:GetComponent( "ChickenAI" )) then
			allowed = true
		elseif (takedamage:GetComponent( "WolfAI" )) then
			allowed = true
		elseif (takedamage:GetComponent( "RabbitAI" )) then
			allowed = true
		end
		local diallow = false
		if self.Config.Misc.DIShowStructures then
			if damage.attacker ~= damage.victim then
				if takedamage:GetComponent("StructureComponent") then
					diallow = true
				end
			end
		end
		if self.Config.Enabled.DamageIndicator then
			if allowed or (self.Config.Misc.DIShowStructures and diallow) then
				if takedamage.health - damage.amount > 0 then
					rust.Notice(Attacking, "Vida: "..math.ceil(takedamage.health - damage.amount).." / "..takedamage.maxHealth, 1)
				end
			end
		end
	end
	local controllable = takedamage:GetComponent( "Controllable" )
	if (not controllable) then return end
	local netuser = controllable.playerClient.netUser
	if (not netuser) then return error( "Failed to get netuser (ModifyDamage)" ) end
	local char = rust.GetCharacter( netuser )
	if (not char) then return error( "Failed to get Character (ModifyDamage)" ) end
	if (char) then
		local ct = char:GetType()
		local netplayer = char.networkViewOwner
		if (netplayer) then
			local netuser = rust.NetUserFromNetPlayer( netplayer )
			if (netuser) then
				local data = self:GetUserData(netuser)
				if (data.God) then
					local EssDmg = function()
						local controllable = netuser.playerClient.controllable
						if controllable ~= nil then
							local char = controllable:GetComponent( "Character" )
							local FallDamage = cs.gettype( "FallDamage, Assembly-CSharp" )
							local EssFD = char:GetComponent( FallDamage )
							if EssFD ~= nil then
								EssFD:ClearInjury()
							end
							local HumanBodyTakeDamageType = cs.gettype( "HumanBodyTakeDamage, Assembly-CSharp" )
							if (HumanBodyTakeDamageType == nil) then
								print( "HumanBodyTakeDamageType is nil, please report to developer" )
								return
							end
							local HBTD = char:GetComponent( HumanBodyTakeDamageType )
							if (HBTD == nil) then
								print( "HBTD is nil, please report this to the developer")
								return
							end
							HBTD:Bandage( 1000.0 )
							HBTD:HealOverTime( 30.0 )
						end
					end
					timer.Once(0.25, function() EssDmg() end)
					damage.amount = 0
					damage.status = LifeStatus.IsAlive
					return damage
	            end
			end
		end
	end
end

function PLUGIN:GetStructureOwnerID(structure)
    return GetStructureMasterOwnerIDField(structure)
end

function PLUGIN:round(val, decimal)
  if (decimal) then
    return math.floor( (val * 10^decimal) + 0.5) / (10^decimal)
  else
    return math.floor(val+0.5)
  end
end

function PLUGIN:radFromCoordinates(p1, p2)
  return math.sqrt(math.pow(p1.x - p2.x,2) + math.pow(p1.y - p2.y,2) + math.pow(p1.z - p2.z,2))
end

function PLUGIN:isPointIn2DRadius(pos, point, rad)
  return self:radFromCoordinates({x=pos.x,y=1,z=pos.z},{x=point.x,y=1,z=point.z}) < rad
end

function PLUGIN:isPointInBl(pos, point, rad1, rad2)     --sq.R1 / sq.R2    =     r2(---r1(-------*
  return self:isPointIn2DRadius(pos,point, rad2) and not self:isPointIn2DRadius(pos,point, rad1)
end

local REMOVETOOL = {}
local RemoverToolAT = {}
local RemoverAllTimer = {}
local OwnerToolTimer = {}

function PLUGIN:ResetRemoveTimer(netuser, focus)
	self:RemoveFromTimer(netuser)
	local netuserID = rust.GetUserID(netuser)
	if focus == "RT" then
		REMOVETOOL[netuserID] = timer.Once(60, function() RemoverTool[netuserID] = nil rust.Notice(netuser, "RemoveTool auto disabled, due to inactivity.") end)
	elseif focus == "ART" then
		RemoverAllTimer[netuserID] = timer.Once(60, function() RemoverAll[netuserID] = nil rust.Notice(netuser, "Remove AllTool auto disabled, due to inactivity.") end)	
	elseif focus == "OT" then
		OwnerToolTimer[netuserID] = timer.Once(60, function() OwnerTool[netuserID] = nil rust.Notice(netuser, "Owner Tool auto disabled, due to inactivity.") end)	
	else
		RemoverToolAT[netuserID] = timer.Once(60, function() RemoverToolA[netuserID] = nil rust.Notice(netuser, "Admin RemoveTool auto disabled, due to inactivity.") end)	
	end
end

function PLUGIN:ResetAll(netuser)
	self:RemoveFromTimer(netuser)
	if RemoverTool[netuserID] ~= nil then
		RemoverTool[netuserID] = nil
	end
	if RemoverAll[netuserID] ~= nil then
		RemoverAll[netuserID] = nil
	end
	if OwnerTool[netuserID] ~= nil then
		OwnerTool[netuserID] = nil
	end
	if RemoverToolA[netuserID] ~= nil then
		RemoverToolA[netuserID] = nil
	end
end

function PLUGIN:RemoveFromTimer(netuser)
	local netuserID = rust.GetUserID(netuser)
	if REMOVETOOL[netuserID] then
		REMOVETOOL[netuserID]:Destroy()
		REMOVETOOL[netuserID] = nil
	end
	if RemoverToolAT[netuserID] then
		RemoverToolAT[netuserID]:Destroy()
		RemoverToolAT[netuserID] = nil
	end
	if RemoverAllTimer[netuserID] then
		RemoverAllTimer[netuserID]:Destroy()
		RemoverAllTimer[netuserID] = nil
	end
	if OwnerToolTimer[netuserID] then
		OwnerToolTimer[netuserID]:Destroy()
		OwnerToolTimer[netuserID] = nil
	end
end

function PLUGIN:cmdPing( netuser, cmd, args )
	if(not args[1]) then
		local ping = netuser.networkPlayer.averagePing
		rust.Notice( netuser, "Seu ping: " .. tostring(ping) )
		return true
	else
		local b, targetuser = rust.FindNetUsersByName( tostring(args[1]) )
		local targetname = util.QuoteSafe( targetuser.displayName )
		local targetping = targetuser.networkPlayer.averagePing
		if (not b) then
			if (targetuser == 0) then
				rust.Notice( netuser, "Player nao encontrado!" )
			else
				rust.Notice( netuser, "Varios players encontrados!" )
			end
			return
		end
		rust.Notice(netuser, targetname.." Ping: "..targetping)
	end
end

function PLUGIN:Mute(netuser, cmd, args)
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true or (flags ~= nil and flags:HasFlag(netuser, "mute"))) then
		if (not args[1]) then
			rust.Notice(netuser, "Use /mute \"Name\" to mute a player.")
			return true
		else
			local b, targetuser = rust.FindNetUsersByName( tostring(args[1]) )
			if (not b) then
				if (targetuser == 0) then
					rust.Notice( netuser, "Player nao encontrado!" )
				else
					rust.Notice( netuser, "Varios players encontrados!" )
				end
				return
			end
			local data = self:GetUserData( targetuser )
			if (data.Muted) then
				data.Muted = false
				rust.Notice(targetuser, "You are now unmuted.")
				rust.Notice(netuser, "You have unmuted "..targetuser.displayName)
				if (self.Config.Enabled.Log) then
					self:Logger(netuser.displayName.." muted "..targetuser.displayName)
				end
			else
				data.Muted = true
				
				rust.Notice(targetuser, "You are now muted.")
				rust.Notice(netuser, "You have muted "..targetuser.displayName)
				if (self.Config.Enabled.Log) then
					self:Logger(netuser.displayName.." unmuted "..targetuser.displayName)
				end				
			end
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:GlobalMute( netuser )
	if GlobalMUTE then
		GlobalMUTE = false
		rust.Notice(netuser, "Mute global ativado!" )
		rust.BroadcastChat(self.Config.Chatname, "[color green] Mute global desativado!")
	else
		GlobalMUTE = true
		rust.Notice(netuser, "GlobalMute has been turned on!" )
		rust.BroadcastChat(self.Config.Chatname, "[color red] Mute global ativado!")
	end
end

function PLUGIN:PingKick()
	local netusers = rust.GetAllNetUsers()
	if (not self.Config.Misc.PingLimit) then
		self.Config.Misc.PingLimit = 1000
	end
	local PingLimit = tonumber(self.Config.Misc.PingLimit)
	for _,netuser in pairs(netusers) do
		local ping = netuser.networkPlayer.averagePing
		if(	ping > PingLimit ) then
			if(not netuser:CanAdmin()) then
				if (self.Config.Enabled.Log) then
					self:Logger(netuser.displayName.." was kicked due to his/her ping.")
				else
					print(netuser.displayName.." was kicked due to his/her ping.")
				end
				rust.BroadcastChat( self.Config.Chatname, "Player: ".. netuser.displayName .." had to high ping and has been kicked.("..tostring(ping)..")" )
				local netuserID = rust.GetUserID(netuser)
				Kicked[netuserID] = true
				netuser:Kick( NetError.Facepunch_Kick_RCON, true )
			end
		end
	end
end

function PLUGIN:SendHelpText( netuser )
	local cn = 0
	local ct = 0
	for k,_ in pairs(tabl) do
		cn = cn + 1
		if cn >= 10 then
			ct = ct + 1
			cn = 0
		end
	end
	self:SendChatToUser(netuser,  "Use /esshelp \"page\" to see all Essentials commands page 1-"..ct..".")
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true) then
		self:SendChatToUser(netuser,  "Use /essahelp to view Essentials admin help")
	end
end

function PLUGIN:AdminHelp( netuser )
	local datan = self:GetUserData(netuser)
	if (netuser:CanAdmin() or datan.Essentials == true) then
		local tbl1 = {
		"Use /essver to see what version of essentials you are running.",
		"Use /addadmin \"Name\" to make him admin when he connects.",
		"Use /remadmin \"Name\" to remove the person from the admin list.",
		"Use /daylength 'number' to set how long daylength.",
		"Use /nightlength 'number' to set how long nightlength.",
		"Use /day to see how long day is.",
		"Use /night to see how long day is.",
		"Use /say \"Msg\" to send a message as Essentials.",
		"Use /saypop \"Msg\" to send a popup.",
		"Use /pvp on/off to toggle PvP",
		"Use /warn \"Name\" to warn a player.",
		"Use /ban \"Name\" to ban a player.",
		"Use /kick \"Name\" to kick a player.",
		"Use /unban \"Name\" to unban a player.",
		"Use /ad \"Amount\" to drop \"Amount\".",
		"Use /airdrop \"Amount\" to drop \"Amount\".",
		"Use /falldmg to toggle fall damage.",
		"Use /shutdown \"Time\" to restart the server.",
		"Use /restart \"Time\" to restart the server.",
		"Use /restart cancel to cancel a restart.",
		"Use /shutdown cancel to cancel a restart.",
		"Use /give \"Itemname\" \"Amount\"(Optional) \"PlayerName\"(Optional)",
		"Use /god \"Name\" to turn godmode on.",
		"Use /ungod \"Name\" to turn godmode off.",
		"Use /instac to enable instacraft.",
		"Use /craft 1-100 to set crafting in percent.",
		"Use /dura 1-100 to set durability in percent.",
		"Use /sleepers to toggle sleepers.",
		"Use /kill \"Name\" to kill that person.",
		"Use /locktime \"Time\" to set backpack locktime in seconds.",
		"Use /vanish to equip invisible gear.",
		"Use /adoor to access all doors.",
		"Use /mute \"Name\" to mute a player.",
		"Use /gmute to toggle globalmute.",
		"Use /giveessentials \"Name\" to give that player access to all essentials commands."
		}
		for i=1, #tbl1 do
			self:SendChatToUser(netuser,  tbl1[i])
		end
	else
		rust.Notice(netuser, NoPermission)
	end
end

function PLUGIN:LoadEssentialsHelp()
	if tabl == nil then
		tabl = {}
	end
	table.insert(tabl, "Digite /loc para ver sua localizacao.")
	table.insert(tabl, "Digite /creditos para ver quem criou o server.")
	if self.Config.Enabled.SetTime then
		table.insert(tabl, "Digite /time para ver o tempo do server.")
		table.insert(tabl, "Digite /uptime para ver o tempo.")
	end
	if self.Config.Enabled.Ping then
		table.insert(tabl, "Digite /ping para ver seu ping.")
		if self.Config.Misc.PingKick then
			table.insert(tabl, "Ping maximo: "..self.Config.Misc.PingLimit)
		end
	end
	if self.Config.Enabled.Website then
		table.insert(tabl, "Digite /web ou /website para ver o nosso site.")
	end
	if self.Config.Enabled.regras then
		table.insert(tabl, "Digite /regras para ver as regras.")
	end
	if self.Config.Enabled.yt then
		table.insert(tabl, "Digite /yt para ver como ganhar a tag Youtuber.")
	end
		if self.Config.Enabled.tags then
		table.insert(tabl, "Digite /tags para ver como conseguir TAGS no CHAT.")
	end
	if self.Config.Enabled.host then
		table.insert(tabl, "Digite /host para ver a host do servidor.")
	end
	if self.Config.Enabled.MOTD then
		table.insert(tabl, "Digite /motd para ver a mensagem de boas vindas.")
	end
	if self.Config.Enabled.Online then
		table.insert(tabl, "Digite /online ou /who para ver os players online.")
	end
	if self.Config.Enabled.Stats then
		table.insert(tabl, "Digite /stats para ver o top de kills.")
		table.insert(tabl, "Digite /info para ver suas informacoes.")
	end
	if self.Config.Enabled.PlayerList then
		table.insert(tabl, "Digite /list para ver o nick de todos players.")
	end
	if self.Config.Enabled.Teleport then
		table.insert(tabl, "Digite /tpa \"Nome\" para enviar um pedido de teleport \"Nome\".")
		table.insert(tabl, "Digite /tpacc para aceitar um teleport.")
		table.insert(tabl, "Digite /tpaleft para ver quantos tps voce ainda pode usar.")
	end
	if self.Config.Enabled.PrivateMessage then
		table.insert(tabl, "Digite /pm \"Nome\" \"Mensagem\" para enviar uma mensagem privada")
		table.insert(tabl, "Digite /r \"Mensagem\" para responder uma mp.")
	end
	if self.Config.Enabled.FPS then
		table.insert(tabl, "Digite /fps para melhorar ou diminuir os graficos.")
	end
	if self.Config.Enabled.Home then
		table.insert(tabl, "Digite /sethome 1-"..tostring(self.Config.Home.MaxHomes).." para marcar sua casa.")
		table.insert(tabl, "Digite /home 1-"..tostring(self.Config.Home.MaxHomes).." para teleportar pra casa.")
	end
	if self.Config.Enabled.Adminlist then
		table.insert(tabl, "Digite /staffonline para ver a lista de admins.")
		table.insert(tabl, "Digite /ao para ver a lista de admins.")
	end
	if self.Config.Enabled.AutoAdmin then
		table.insert(tabl, "Digite /a para ver se voce e um admin.")
	end
	if self.Config.Enabled.Econ then
		table.insert(tabl, "Digite /money top|send \"Nome\" \"Quantidade\" para ver seu dinheiro.")
		table.insert(tabl, "Digite /money (send/top) \"Name\" \"Quantidade\"")
		table.insert(tabl, "Digite /buy \"Item\" \"Quantidade\"")
		table.insert(tabl, "Digite /sell \"Item\" \"Quantidade\"")
	end
	if self.Config.Enabled.Group then
		table.insert(tabl, "Digite /gcreate \"Nome\" to create a group.")
		table.insert(tabl, "Digite /gleave to leave your current group.")
		table.insert(tabl, "Digite /gdelete to delete your group.(Owner only)")
		table.insert(tabl, "Digite /gpvp to toggle grouppvp.")
		if self.Config.Misc.Grouptag then
			table.insert(tabl, "Digite /gtag to change your groups tag.")
		end
		table.insert(tabl, "Digite /ginvite \"Name\" to invite a player to your group.")
		table.insert(tabl, "Digite /gaccept to accept a group invite.")
		table.insert(tabl, "Use /g to see group info.")
		table.insert(tabl, "Use /gwho to see how many players is online.")
		table.insert(tabl, "Use /glist to see a list of all group member online.")
		table.insert(tabl, "Use /gkick \"Name\" to kick a player from your group.")
	end
	if self.Config.Enabled.RemoveTool then
		table.insert(tabl, "Use /remove to activate/deactivate remover tool.")
	end
	if self.Config.Enabled.OwnerTool then
		table.insert(tabl, "Digite /owner para ativar ou desativar o plugin de owner. ")
	end
	if self.Config.Enabled.History then
		table.insert(tabl, "Digite /history para ver as ultimas mensagens do chat "..tostring(self.Config.Misc.HistoryLength))
	end
	if self.Config.Enabled.Kits then
		table.insert(tabl, "Digite /kit para ver a lista de kits.")
	end
	if self.Config.Enabled.Share then
		table.insert(tabl, "Digite /share \"nome\" para partilhar as portas.")
		table.insert(tabl, "Digite /unshare \"nome\" para tirar a partilha de portas.")
	end
	plugins.Call("EssentialsHelp", tabl)
	return true
end

function PLUGIN:Darkrust( netuser, cmd, args )
	if not args[1] then
		args[1] = 1
	end
	local pagenum = tonumber(args[1])
	local sometable = {}
	local countpage = 0
	local cnt = 0
	local MaxRows = 10
	for k,_ in pairs(tabl) do
		cnt = cnt + 1
		if cnt >= 10 then
			countpage = countpage + 1
			cnt = 0
		end
	end
	local datan = self:GetUserData(netuser)
	if type(pagenum) ~= "number" then
		pagenum = 1
	end
	if pagenum > countpage then
		self:SendChatToUser(netuser,  "Pagina inexistente.")
		return false
	else
		self:SendChatToUser(netuser,  "****************************************************")
		if (netuser:CanAdmin() or datan.Essentials == true) then
			self:SendChatToUser(netuser,  "O servidor esta com o "..self.Title.." na versao: "..self.Version.."! Versao da config: "..self.Config.configVersion)
		else
			self:SendChatToUser(netuser,  "Voce esta usando "..self.Title.." na versao: "..self.Version)
		end
		self:SendChatToUser(netuser,  "****************************************************")
		self:SendChatToUser(netuser,  "    ")
	end
	self:SendChatToUser(netuser,  "---------------------- page [  "..tostring(pagenum).."/"..tostring(countpage).." ] ----------------------")
	for i=1, #tabl do
		local cal = pagenum * (MaxRows + 1)
		if sometable[pagenum] == nil then
			sometable[pagenum] = {}
		end	
		if i < cal and i > cal - (MaxRows + 1) then
			self:SendChatToUser(netuser,  tabl[i])
		end
	end
	PrevPage = pagenum - 1
	NextPage = pagenum + 1
	if (PrevPage > 0) then
		self:SendChatToUser(netuser,  "Digite /esshelp "..tostring(PrevPage).." para ver a pagina anterior.")
	end
	if (NextPage < countpage) then
		self:SendChatToUser(netuser,  "Digite /esshelp "..tostring(NextPage).." para ver a proxima pagina.")
	end
end