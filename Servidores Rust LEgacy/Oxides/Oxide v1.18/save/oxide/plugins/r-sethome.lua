PLUGIN.Title = "r-Sethome"
PLUGIN.Description = "Sethomes only on your home or friends home. Based on GreeManLP Sethome"
PLUGIN.Author = "Reneb"
PLUGIN.Version = "2.0.2"
local RaycastStructure = util.FindOverloadedMethod(Rust.StructureMaster, "RayTestStructures", bf.public_static, { UnityEngine.Ray })
local LookDown = new(UnityEngine.Vector3)
LookDown.x = 0
LookDown.y = -1
LookDown.z = 0
local Ray = new(UnityEngine.Ray)

local getStructureMasterOwnerId = util.GetFieldGetter(Rust.StructureMaster, "ownerID", true)
local function FindStructureMaster( pos )
	Ray.origin = pos
	Ray.direction = LookDown
	local arr = util.ArrayFromTable( System.Object, { Ray } , 1 )
	local hits = RaycastStructure:Invoke(nil, arr)
	local tbl = cs.createtablefromarray( hits )
	local master = false
	if (#tbl == 0) then return false, "Voce tem que estar na sua propria foundation para dar sethome." end
	if(#tbl == 1) then
		return tbl[1]
	end
	return false, "Move a bit, i can find 2 structures here"
end

function PLUGIN:Init ()

	self:AddChatCommand( "sethome", self.cmdsethome )
	self:AddChatCommand( "home", self.cmdhome )

	local b, res = config.Read ( "r-sethome" )
	self.Config = res or {}
	if (not b) then
		self:LoadDefaultConfig()
		if ( res ) then config.Save( "r-sethome" ) end
	end
	if(not self.Config.Version or (self.Config.Version and self.Config.Version ~= "2.0")) then
		print("r-Sethome: config out of date, cfg file updated")
		self:LoadDefaultConfig()
		config.Save( "r-sethome" )
	end
	self.FileData = util.GetDatafile( "r-sethome" )
	local txt = self.FileData:GetText()
	if (txt ~= "") then
		self.Homes = json.decode( txt )
	else
		self.Homes = {}
	end
	self.isSettingHome = {}
	self.HomeCoolDown = {}
	self.Timers = {}
	if (self.Config.Use_Economy == true ) then
		local bushy = plugins.Find( "bushycoin" )
		econ = plugins.Find( "econ" )
		if ( bushy ) and ( not econ ) then
			econ_loaded = "bushycoin"
		elseif ( econ ) and ( not bushy ) then
			econ_loaded = "econ" 
		elseif ( econ ) and ( bushy ) then	
			print ( "r-sethome: You can't have 2 economy plugins loaded" )
		else	
			print ( "r-sethome: No ecnonomy plugins found" )
			self.Config.Use_Economy = false
		end
	end	
	if (self.Config.Use_Friends) then
		self.friends = plugins.Find( "friends" )
		if(not self.friends) then
			print( "r-sethome: friends plugin not found" )
		end
	end
	if (self.Config.Use_Groups) then
		self.groups = plugins.Find( "groups" )
		if(not self.groups) then
			print( "r-sethome: groups plugin not found" )
		end
	end
	if (self.Config.Use_Doorshare) then
		self.doorshare = plugins.Find( "doorshare" )
		if(not self.doorshare) then
			print( "r-sethome: doorshare plugin not found" )
		end
	end
	if (self.Config.Use_Factions) then
		self.factions = plugins.Find( "Factions_basics" )
		if(not self.factions) then
			print( "r-sethome: factions plugin not found" )
		end
	end
end

function PLUGIN:LoadDefaultConfig ()
	self.Config.Version = "2.0"
	self.Config.homes_limit = 3
	self.Config.homes_timer = 30
	self.Config.homes_cooldown = 300
	self.Config.Use_Economy = false
	self.Config.Use_Groups = false
	self.Config.Use_Factions = false
	self.Config.Use_Doorshare = false
	self.Config.sethome_price = 500
	self.Config.gohome_price = 500
	self.Config.reset_home_timer_if_attacked = true
end

function PLUGIN:cmdsethome( netuser , cmd, args )
	if ( not args[1] or ( args[1] and (tonumber( args[1] ) < 1 or tonumber( args[1] ) > self.Config.homes_limit ))) then
		rust.Notice( netuser, "Escolha um numero de 1 a " .. self.Config.homes_limit .. "." )
		return
	end	
	local pos = netuser.playerClient.lastKnownPosition
	local master, err = FindStructureMaster( pos )
	if(not master) then
		rust.SendChatToUser( netuser, err )
		return
	end
	self:DoSetHome( netuser, tostring(math.floor(tonumber(args[1]))), master , pos )
end
function PLUGIN:GetDamageEventAttackerNetuser(damage)
	local theattacker = damage.attacker
	
	if(theattacker) then
		if(type(theattacker) == "number") then return false end
		local attackerClient = damage.attacker.client
		if attackerClient then
			local attackerNetuser = attackerClient.netUser
			if(attackerNetuser) then
				return attackerNetuser
			end
		end
	end
end
function PLUGIN:GetDamageEventVictimNetuser(damage)
	if(damage.victim) then
		if(type(damage.victim) == "number") then return false end
		local attackerClient = damage.victim.client
		if attackerClient then
			local attackerNetuser = attackerClient.netUser
			if(attackerNetuser) then
				return attackerNetuser
			end
		end
	end
end
function PLUGIN:ModifyDamage(takedamage,damage)
	if(self.Config.reset_home_timer_if_attacked) then
		if not (tostring(type(damage) ~= "userdata")) or not (tostring(type(takedamage) ~= "userdata")) then
			return
		end
		if(damage.attacker and damage.attacker.client and damage.attacker.client.netUser and damage.victim and damage.victim.client and damage.victim.client.netUser) then
			
			local attackerNetuser = damage.attacker.client.netUser
			local victimNetuser = damage.victim.client.netUser
			if(victimNetuser ~= attackerNetuser) then
				if(self.Timers[victimNetuser]) then
					rust.SendChatToUser( victimNetuser,"❃ [CASA] ", "[color red]Teleport cancelado, voce foi atingido por algo" )
					self.Timers[victimNetuser]:Destroy()
					self.Timers[victimNetuser] = nil
				end
			end
		end
	end
	return
end
function PLUGIN:CanSetHome(userid,masterid)
	local allowed = false
	if(userid == masterid) then return true end
	if(self.doorshare) then
		self.DoorShareDataFile = util.GetDatafile( "doorshare" )
		local txt = self.DoorShareDataFile:GetText()
		if (txt ~= "") then
			self.DoorShareData = json.decode( txt )
		else
			self.DoorShareData = {}
		end
		local sharedata = self.DoorShareData[ masterid ]
		if (sharedata) then
			if (sharedata.Allowed) then 
				if (sharedata.Allowed[ userid ]) then 
					allowed = true
				end
			end
		end
	end
	if(self.friends) then
		-- maybe later ...
	end
	if(self.groups) then
		local ownergroup = self.groups:checkPlayerGroup(masterid)
		local usergroup = self.groups:checkPlayerGroup(userid)
		if(ownergroup ~= 0 and ownergroup == usergroup) then
			allowed = true
		end
	end
	if(self.factions) then
		if(self.factions:inSameFaction(masterid,userid)) then
			allowed = true
		end
	end
	return allowed
end
function PLUGIN:DoSetHome( netuser, num, master, pos)
	local userid = rust.GetUserID( netuser )
	if (not self.Homes[ userid ]) then
		self.Homes[ userid ] = {}
	end
	if ( self.Config.Use_Economy == true ) and ( econ_loaded ) then
		if (econ_loaded == "bushycoin") then
			local call, req, res = api.Call ( "bushycoin", "balance", netuser )
			if ( res < self.Config.sethome_price ) then
				rust.SendChatToUser( netuser, "You don't have enough money to Set Home" )
				rust.Notice(netuser, "Setting Home Deactivated")
				self.isSettingHome[netuser] = nil
				return
			end
		end
		if ( econ_loaded == "econ" ) then
			if ( econ.Data[ userid ].Money < self.Config.sethome_price ) then
				rust.SendChatToUser( netuser, "Sem dinheiro para marcar um sethome" )
				
				self.isSettingHome[netuser] = nil
				return
			end
		end
	end
	local structureOwnerId = tostring(getStructureMasterOwnerId(master))
	if(not self:CanSetHome(userid, structureOwnerId)) then
		rust.SendChatToUser( netuser,"❃ [CASA] ", "Voce nao pode dar sethome na foundation dos outros" )
		
		self.isSettingHome[netuser] = nil
		return
	end
	if (self.Homes[ userid ][ num ] == nil) then
		self.Homes[ userid ][ num ] = {}
	end
	self.Homes[ userid ][ num ][ "x" ] = pos.x
	self.Homes[ userid ][ num ][ "y" ] = pos.y + 2
	self.Homes[ userid ][ num ][ "z" ] = pos.z
	self:Save()
	if ( self.Config.Use_Economy == true ) and ( econ_loaded ) then
		if ( econ_loaded == "bushycoin" ) then
			local call, req, res = api.Call ( "bushycoin", "deduct", netuser, self.Config.sethome_price )
			rust.SendChatToUser( netuser, "Home " .. num .. " set successfully for $" .. self.Config.sethome_price )
			rust.Notice(netuser, "Setting Home Deactivated")
			self.isSettingHome[netuser] = nil
			return
		end
		if ( econ_loaded == "econ" ) then
			econ.Data[ userid ].Money = econ.Data[ userid ].Money - self.Config.sethome_price
			rust.SendChatToUser( netuser, "Casa " .. num .. " definida com sucesso por $" .. self.Config.sethome_price )
			
			self.isSettingHome[netuser] = nil
			return
		end
	end
	rust.SendChatToUser( netuser,"❃ [CASA] ", "Casa " .. num .. " definida com sucesso." )
	
	self.isSettingHome[netuser] = nil
end

function PLUGIN:cmdhome( netuser, cmd, args )
	local userid = rust.GetUserID( netuser )
	if ( not args[1] or ( args[1] and (tonumber( args[1] ) < 1 or tonumber( args[1] ) > self.Config.homes_limit ))) then
		rust.Notice( netuser, "Por favor digite um numero de 1 a " .. self.Config.homes_limit .. "." )
		return
	end	
	if (not self.Homes[ userid ]) then
		rust.Notice( netuser, "Voce nao tem sethome marcado." )
		return
	end
	if (not self.Homes[ userid ][ args[1] ]) then
		rust.Notice( netuser, "Voce nao tem a casa numero " .. args[1] .. " marcada.")
		return
	end
	if( not self.HomeCoolDown[ netuser ] ) then
		self.HomeCoolDown[ netuser ] = 0
	end
	if( (util.GetTime() - self.HomeCoolDown[ netuser ]) < self.Config.homes_cooldown ) then
		local timeleft = self.Config.homes_cooldown - (util.GetTime() - self.HomeCoolDown[ netuser ])
		rust.Notice( netuser, "Voce so podera teleportar novamente em " .. timeleft .. " segundos.")
		return
	end
	if ( self.Config.Use_Economy == true ) and ( econ_loaded ) then
		if (econ_loaded == "bushycoin") then
			local call, req, res = api.Call ( "bushycoin", "balance", netuser )
			if ( res < self.Config.gohome_price ) then
				rust.SendChatToUser( netuser, "You don't have enough money to Go Home" )
				return
			end
		end
		if ( econ_loaded == "econ" ) then
			if ( econ.Data[ userid ].Money < self.Config.gohome_price ) then
				rust.SendChatToUser( netuser, "Sem dinherio para voltar pra casa" )
				return
			end
		end
	end
	if ( netuser.playerClient.lastKnownPosition ) then
		local position = netuser.playerClient.lastKnownPosition
		position.x = self.Homes[ userid ][ args[1] ][ "x" ]
		position.y = self.Homes[ userid ][ args[1] ][ "y" ]
		position.z = self.Homes[ userid ][ args[1] ][ "z" ]
		rust.SendChatToUser( netuser,"❃ [CASA] ", "Teleportando pra casa em " .. self.Config.homes_timer .. " segundos!" )
		if(self.Timers[netuser]) then self.Timers[netuser]:Destroy() end
		self.Timers[netuser] = timer.Once( self.Config.homes_timer, function() self:teleport( netuser, position, userid ) end )
	end
end

function PLUGIN:teleport( netuser, position, player )
	if(not netuser or not netuser.playerClient) then
		return
	end
	if(self.Timers[netuser]) then 
		self.Timers[netuser]:Destroy() 
		self.Timers[netuser] = nil
	end
	rust.SendChatToUser( netuser,"❃ [CASA] ", "Teleportando, fique parado!" )
	self:FreezePlayer( netuser )
	rust.ServerManagement():TeleportPlayer( netuser.playerClient.netPlayer, position )
	timer.Repeat( 2, 2, function() 
    	if(netuser and netuser.playerClient) then
            rust.ServerManagement():TeleportPlayer( netuser.playerClient.netPlayer, position) 
        end
    end )
	if ( self.Config.Use_Economy == true ) and ( econ_loaded ) then
		if ( econ_loaded == "bushycoin" ) then
			local call, req, res = api.Call ( "bushycoin", "deduct", netuser, self.Config.gohome_price )
			rust.SendChatToUser( netuser, "You have successfully teleported home for $" .. self.Config.gohome_price )
		end
		if ( econ_loaded == "econ" ) then
			econ.Data[ player ].Money = econ.Data[ player ].Money - self.Config.gohome_price
			rust.SendChatToUser( netuser, "❃ [CASA] ","Teleportado com sucesso por $" .. self.Config.gohome_price )
		end
	else
		rust.SendChatToUser( netuser, "❃ [CASA] ","[color green]Teleportado.." )
	end
	self.HomeCoolDown[ netuser ] = util.GetTime()
	timer.Once( 4, function () self:UnfreezePlayer( netuser ) end )
end

function PLUGIN:FreezePlayer ( netuser )
	if(not netuser) then return end
	if(not netuser.playerClient) then return end
	if(not netuser.playerClient.controllable) then return end
	
	local fallDamage = netuser.playerClient.controllable:GetComponent("FallDamage")
	fallDamage:AddLegInjury(1)
end
function PLUGIN:OnUserDisconnect( networkplayer )
    local netuser = networkplayer:GetLocalData()
	if(self.Timers[netuser]) then
		self.Timers[netuser]:Destroy()
		self.Timers[netuser] = nil
	end
end
function PLUGIN:UnfreezePlayer ( netuser )
	if(not netuser) then return end
	if(not netuser.playerClient) then return end
	if(not netuser.playerClient.controllable) then return end

	local fallDamage = netuser.playerClient.controllable:GetComponent("FallDamage")
	fallDamage:ClearInjury()
end

function PLUGIN:SendHelpText ( netuser )
	rust.SendChatToUser( netuser, "[color green]Voce pode marcar sua casa usando /sethome 1 -> " .. self.Config.homes_limit )
	rust.SendChatToUser( netuser, "[color green]Voce pode voltar pra casa usando /home 1 -> " .. self.Config.homes_limit )
end

function PLUGIN:Save()
	self.FileData:SetText( json.encode( self.Homes ) )
	self.FileData:Save()
end