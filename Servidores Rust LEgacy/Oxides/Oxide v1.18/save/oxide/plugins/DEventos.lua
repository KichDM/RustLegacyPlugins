PLUGIN.Title = "DokiTV - Evento de sorteio"
PLUGIN.Description = "Um plugin que sorteia um player aleatorio"
PLUGIN.Author = "DokiTV"
PLUGIN.Version = "1.0"
PLUGIN.RID = "613"

function PLUGIN:Init()
	self:AddChatCommand( "entrar", self.cmdRaffle )
    self.flags = plugins.Find("flags")
    if (not self.flags) then
      error("Voce precisa instalar o plugin de flags: https://github.com/busheezy/Flags!")
      return
    end
	defaultDuration = 20
	defaultMaxEntries = 0
	entryTable = {}
	maxEntries = 0
	isRunning = false
end

function PLUGIN:PostInit()
	self.flags:AddFlagsChatCommand(self, "evento", {"raffle"}, self.cmdComecar)
	self.flags:AddFlagsChatCommand(self, "tevento", {"raffle"}, self.cmdTerminar)
	self.flags:AddFlagsChatCommand(self, "cancelarevento", {"raffle"}, self.cmdCancelar)
end

function PLUGIN:cmdComecar( netuser, cmd, args )
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
		maxEntries = tonumber(args[2])
		if (maxEntries == nil or maxEntries < 0) then
			maxEntries = defaultMaxEntries
		end
		rust.BroadcastChat( "ϟ | [EVENTO]", "Um sorteio começou: " .. duration .. " segundos para terminar." )
		rust.BroadcastChat( "ϟ | [EVENTO]", "Digite [color yellow]/entrar[/color] para participar do sorteio!" )
		timer.Once( duration, self.GetWinner )
			
		if (duration > 15) then
			timer.Once( duration - 10, self.BroadcastWarning )
		end
	else
		rust.SendChatToUser( netuser, "Um evento já está em progresso" )
	end
	
end

function PLUGIN:cmdRaffle( netuser, cmd, args )
	if isRunning then
		if (maxEntries <= 0 or #entryTable < maxEntries) then
			
			local isDuplicate = false
			for i,v in ipairs(entryTable) do
				if netuser == v then
					isDuplicate = true
					break
				end
			end
			
			if not isDuplicate then
				table.insert(entryTable, netuser)
				rust.BroadcastChat( "ϟ | [EVENTO]", netuser.displayName .. " entrou no sorteio! Digite [color yellow]/entrar[/color] para participar também!" )
			else
				rust.SendChatToUser( netuser, "Voce ja esta participando." )
			end
		else
			rust.SendChatToUser( netuser, "Numero maximo de participantes atingido." )
		end
	else
		rust.SendChatToUser( netuser, "Nenhum evento em progresso." )
	end
end

function PLUGIN:cmdTerminar( netuser, cmd, args )
	if isRunning then
		rust.BroadcastChat( "ϟ | [EVENTO]", "Evento cancelado por " .. netuser.displayName .. ".")
		self.GetWinner()
	else
		rust.SendChatToUser( netuser, "Nenhum evento em progresso." )
	end
end

function PLUGIN:cmdCancelar( netuser, cmd, args )
	if isRunning then
		rust.BroadcastChat( "ϟ | [EVENTO]", "Evento cancelado por " .. netuser.displayName .. ".")
	else
		rust.SendChatToUser( netuser, "Nenhum evento em progresso." )
	end
	isRunning = false
	entryTable = {}
	initiator = nil
end

function PLUGIN:BroadcastWarning()
	rust.BroadcastChat( "ϟ | [EVENTO]", "[color yellow]10 segundos para sortear! [color orange] Digite /entrar para participar" )
end

function PLUGIN:GetWinner()
    if isRunning then
		isRunning = false
		
		if #entryTable > 0 then
			local index = math.random( #entryTable )
			
			for i,v in ipairs(entryTable) do
				if index == i then
					rust.BroadcastChat( "ϟ | [EVENTO]", "=================================================================")
					rust.BroadcastChat( "ϟ | [EVENTO]","[color yellow]" .. v.displayName .. " foi o vencedor!" )
					rust.BroadcastChat( "ϟ | [EVENTO]","Seu premio sera entregue em alguns minutos pelo admin" )
					rust.BroadcastChat( "ϟ | [EVENTO]","Va para uma zona segura" )
					rust.BroadcastChat( "ϟ | [EVENTO]", "=================================================================")

					break
				end
			end
		else
			rust.BroadcastChat( "ϟ | [EVENTO]", "Evento cancelado. Nenhum participante..." )
		end
		
		entryTable = {}
		initiator = nil
	end
end