PLUGIN.Title = "DokiTV - Evento de sorteio"
PLUGIN.Description = "Um plugin que sorteia um player aleatorio"
PLUGIN.Author = "Limyc(Raffle plugin) & DokiTV"
PLUGIN.Version = "1.0"
PLUGIN.RID = "613"
	
	
	
	--defaultDuration = 1800 -- 30 minutos
	maxPedidos = 500
	--entryTable = {}
	--isRuning = False

-- # ============================================================ Cria a config, faz load e etc ============================================================ # -- 
function PLUGIN:Init()
	print("*****************")
	print("[DokiTV] Plugin de ajuda inicializando ...")
	self:LoadConfig()
	self:AddChatCommand( "cadmin", self.cmdCadmin )
    self.flags = plugins.Find("flags")
    if (not self.flags) then
      error("Voce precisa instalar o plugin de flags: https://github.com/busheezy/Flags!")
      return
    end
	self:LoadDefaultConfig()
	
	if (self.Config.isRunning) then
		self.Config.defaultDuration = self.Config.defaultDuration or 5
		
        self:Desativarajuda()
    else
        self:Ativarajuda()
    end
end

function PLUGIN:LoadConfig()
    local b, res = config.Read("DAjuda")
    self.Config = res or {}
    if (not b) then
        print("Pedidos de ajuda. Criando configuracao...")
        self:LoadDefaultConfig()
        if (res) then config.Save("DAjuda") end
    end
end

function PLUGIN:LoadDefaultConfig()
    self.Config.Versao = "1.0"
    self.Config.isRuning = self.Config.isRuning or true
	self.Config.defaultDuration = self.Config.defaultDuration or 5
	self.Config.maxPedidos = self.Config.maxPedidos or 20
end

function PLUGIN:Desativarajuda( netuser )
    self.Config.isRuning = false
	self.Config.defaultDuration = 0
	self.Config.maxPedidos = 0
    config.Save("DAjuda")
    local offmsg = "Pedidos de ajuda OFF."
    if (netuser) then
        rust.SendChatToUser( netuser, offmsg )
    end
    print(offmsg)
end

function PLUGIN:Ativarajuda( netuser )
    self.Config.isRuning = self.Config.isRuning or true
	self.Config.defaultDuration = self.Config.defaultDuration or 5
	self.Config.maxPedidos = self.Config.maxPedidos or 20
    config.Save("DAjuda")
    local onmsg = "Plugin de ajuda carregado com sucesso!"
	print("Obrigado por usar meu plugin :)")
    print(onmsg)  
end

-- # ============================================================ Cria a config, faz load e etc ============================================================ # -- 

function PLUGIN:PostInit()
	self.flags:AddFlagsChatCommand(self, "ajudaon", {"banning"}, self.cmdAjudaon)
	self.flags:AddFlagsChatCommand(self, "ajudat", {"banning"}, self.cmdAjudat)
	self.flags:AddFlagsChatCommand(self, "ajudaoff", {"banning"}, self.cmdAjudaoff)
end

function PLUGIN:cmdAjudaon( netuser, cmd, args )
    if not isRunning then
		isRunning = true
		initiator = netuser
		local duration = tonumber(args[1])
		if (num ~= nil) then				
			if num < 10 then
				num = 10
			end	
			duration = num
		else
			duration = defaultDuration
		end
		
		rust.BroadcastChat( "ϟ | [AJUDA]", "O pedido de ajuda para admins foi ativado por " ..tostring(self.Config.defaultDuration).. " segundos ! " )
		rust.BroadcastChat( "ϟ | [AJUDA]", "Para pedir ajuda digite: [color green]/cadmin" )
		timer.Once( self.Config.defaultDuration, self.GetWinner )
			
		if (self.Config.defaultDuration > 15) then
			timer.Once( self.Config.defaultDuration - 10, self.BroadcastWarning )
		end
	else
		rust.SendChatToUser( netuser, "ϟ | [AJUDA]", "[color red]Pedidos de ajuda desabilitados." )
	end
	
end

function PLUGIN:cmdCadmin( netuser, cmd, args )
	if isRunning then
		if (maxPedidos <= 0 or #entryTable < maxPedidos) then
		local isDuplicate = false
			for i,v in ipairs(entryTable) do
				if netuser == v then
					isDuplicate = true
					break
				end
			end
			if not isDuplicate then
				table.insert(entryTable, netuser)
				rust.BroadcastChat( "ϟ | [AJUDA]", netuser.displayName .. " [color orange]esta pedindo ajuda para um admin/mod! Nível:[color yellow] Médio[/color]!" )
			else
				rust.SendChatToUser( netuser, "ϟ | [AJUDA]", "[color red]Voce já chamou um adm/mod. [color yellow]Aguarde! ." )
			end	
			
		
		end
	else
		rust.SendChatToUser( netuser,"ϟ | [AJUDA]", "[color red]Pedidos de ajuda desabilitados." )
	end
end

function PLUGIN:cmdAjudat( netuser, cmd, args )
	if isRunning then
		rust.BroadcastChat( "ϟ | [AJUDA]", "[color red]Todos pedidos de ajuda cancelados pelo admin/mod: [color green]" .. netuser.displayName .. ".")
		self.GetWinner()
	else
		rust.SendChatToUser( netuser,"ϟ | [AJUDA]", "[color red]Pedidos de ajuda desabilitados." )
	end

	
end

function PLUGIN:cmdAjudaoff( netuser, cmd, args )
	if isRunning then
		rust.BroadcastChat( "ϟ | [AJUDA]", "[color red]Pedidos de ajuda desabilitados pelo admin: [color green]" .. netuser.displayName .. ".")
	else
		rust.SendChatToUser( netuser, "ϟ | [AJUDA]", "[color red]Pedidos de ajuda desabilitados, tente mais tarde." )
	end
	isRunning = false
	entryTable = {}
	initiator = nil
end

function PLUGIN:BroadcastWarning()
	rust.BroadcastChat( "ϟ | [AJUDA]", "[color orange] Os pedidos de ajuda estao [color green]ON![color orange] Digite [color green]/cadmin" )
end

function PLUGIN:GetWinner()
    if isRunning then
		isRunning = false
		
		if #entryTable > 0 then
			local index = math.random( #entryTable )
			
			for i,v in ipairs(entryTable) do
				if index == i then
					rust.BroadcastChat( "ϟ | [AJUDA]", "=================================================================")
					rust.BroadcastChat( "ϟ | [AJUDA]", "[color yellow]" .. v.displayName .. " foi o ultimo player a ser ajudado!" )
					rust.BroadcastChat( "ϟ | [AJUDA]", "[color green]Pedidos de ajuda [color red]OFFLINE" )
					rust.BroadcastChat( "ϟ | [AJUDA]", "=================================================================")
					rust.RunServerCommand("save.all")
					break
				end
			end
		else
			rust.BroadcastChat( "ϟ | [AJUDA]", "[color red]Pedidos de ajuda desligados. Motivo: Ninguem quer ajuda kk.." )
		end
		
		entryTable = {}
		initiator = nil
	end
end