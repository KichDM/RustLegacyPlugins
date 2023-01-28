
var Version = "1";
var ini = "";
var Chat = "";
var Kick = "";
var Ban = "";
var Tp = "";
var ChatDist = "";
var KickDist = "";
var BanDist = "";
var TpDist = "";
var AdminCheck = "";
var Send = "";
var Script = "";
var Voteban = "";
var MinOnline = "";
var SecsToVote = "";
var AntiSH = "";
var timer = "";
var TempWork = "";
var WorkMins = "";
var CountAim = "";
var AntiFlyHack = "";
var TimeFlyCheck = "";
var CountFly = "";
var Whitelist = "";
var APIKey = "";
var AllowShared = "";
var AllowVACBanned = "";
var AllowedVACBans = "";
var MaximumDays = "";
var LogPlayers = "";
var NamesRestrict = "";
var allowed = "";
var MaxLength = "";
var MinLength = "";
var bannedNamesAll = "";
var BindName = "";
var AdminsOnly = "";
var RelogCooldown = "";
var Cooldown = "";
var JoinMessage = "";
var LeaveMessage = "";
var GodModDetect = "";
var Message = "";
var AntiAim = "";
var HsOnly = "";
var MaxDist = "";
var MaxKillDist = "";
var MinYesPercent = "";
var RestMins = "";
var HighPing = "";
var Time = "";
var MaxPing = "";
var MaxHeight = "";
configInit();

function configInit(){
	try {
		ini = Plugin.GetIni("AntiCheatSettings");
		AntiSH = ini.GetSetting("AntiSpeedHack","Enable");
		timer = ini.GetSetting("AntiSpeedHack","Timer");
		TempWork = ini.GetSetting("AntiSpeedHack","TempWork");
		WorkMins = ini.GetSetting("AntiSpeedHack","WorkMins");	
		RestMins = ini.GetSetting("AntiSpeedHack","RestMins");
		Chat = ini.GetSetting("AntiSpeedHack","Chat");
		Kick = ini.GetSetting("AntiSpeedHack","Kick");
		Ban = ini.GetSetting("AntiSpeedHack","Ban");
		Tp = ini.GetSetting("AntiSpeedHack","Teleport");
		ChatDist = ini.GetSetting("AntiSpeedHack","ChatDistance");
		KickDist = ini.GetSetting("AntiSpeedHack","KickDistance");
		BanDist = ini.GetSetting("AntiSpeedHack","BanDistance");
		TpDist = ini.GetSetting("AntiSpeedHack","TeleportDistance");
		AdminCheck = ini.GetSetting("AntiSpeedHack","AdminCheck");
		AntiAim = ini.GetSetting("AntiAim","Enable");
		CountAim = ini.GetSetting("AntiAim","ShotsCount");
		HsOnly = ini.GetSetting("AntiAim","HeadshotsOnly");
		MaxDist = ini.GetSetting("AntiAim","ShotMaxDistance");
		MaxKillDist = ini.GetSetting("AntiAim","MaxKillDistance");
		AntiFlyHack = ini.GetSetting("AntiFlyHack","Enable");
		MaxHeight = ini.GetSetting("AntiFlyHack","MaxHeight");
		TimeFlyCheck = ini.GetSetting("AntiFlyHack","TimeToCheck");
		CountFly = ini.GetSetting("AntiFlyHack","Detections");
		Send = ini.GetSetting("SendToKich","Enable");
		Script = ini.GetSetting("SendToKich","Script");
		Voteban = ini.GetSetting("Voteban","Enable");
		MinOnline = ini.GetSetting("Voteban","MinOnline");
		SecsToVote = ini.GetSetting("Voteban","SecsToVote");
		MinYesPercent = ini.GetSetting("Voteban","MinYesPercent");
		APIKey = ini.GetSetting("Restrictions","APIKey");
		AllowShared = ini.GetSetting("Restrictions","AllowShared");
		AllowVACBanned = ini.GetSetting("Restrictions","AllowVACBanned");
		AllowedVACBans = ini.GetSetting("Restrictions","AllowedVACBans");
		MaximumDays = ini.GetSetting("Restrictions","MaximumDays");
		NamesRestrict = ini.GetSetting("Names","Enable");
		allowed = ini.GetSetting("Names","AllowedChars");
		MaxLength = ini.GetSetting("Names","MaxLength");
		MinLength = ini.GetSetting("Names","MinLength");
		bannedNamesAll = ini.GetSetting("Names","BannedNames");
		BindName = ini.GetSetting("Names","BindNameToSteamID");
		AdminsOnly = ini.GetSetting("Names","BindOnlyAdmins");
		RelogCooldown = ini.GetSetting("RelogCooldown","Enable");
		Cooldown = ini.GetSetting("RelogCooldown","Cooldown");
		JoinMessage = ini.GetSetting("Messages","Join");
		LeaveMessage = ini.GetSetting("Messages","Leave");
		Message = ini.GetSetting("Messages","Death");
		HighPing = ini.GetSetting("HighPingKicker","Enable");
		Time = ini.GetSetting("HighPingKicker","SecondsToCheck");	
		MaxPing = ini.GetSetting("HighPingKicker","MaxPing");
		GodModDetect = ini.GetSetting("GodModDetect","Enable");
		Whitelist = ini.GetSetting("Whitelist","Enable");
		LogPlayers = ini.GetSetting("LogPlayers","Enable");
	}
	catch (err) {
            ErrorFound(err, "configInit");
    }
}

function ErrorFound(err, str){
	if (Send == 1){
		Web.GET(Script+"?type=error&message="+err.message+"&function="+str+"&description="+err.number+"&line="+err.lineNumber+"&version="+Version);/**/
	}
}

/*function NearEntities(X, Z){
	try {
		World.CreateZone("ZoneAround");
		var ZoneAround = Datastore.Get("3DZonesList","ZoneAround");
		ZoneAround.Mark(X-20, Z-20);
		ZoneAround.Mark(X+20, Z-20); 
		ZoneAround.Mark(X-20, Z+20); 
		ZoneAround.Mark(X+20, Z+20);
		var count = 0;
		for (var Entity in ZoneAround.Entities){
			count = 1;
			break;
		}
		ZoneAround.Mark(0, 0);
		ZoneAround.Mark(1, 0); 
		ZoneAround.Mark(0, 1); 
		ZoneAround.Mark(1, 1);
		return count;
	}
	catch (err) {
            ErrorFound(err, "NearEntities");
    }
}*/

function banCheater(Player, LogString) {
	try {
		if (AntiSH == ""){
			configInit();
		}
		var Date = Plugin.GetDate();
		var Time = Plugin.GetTime();
		var iniBansIP = Plugin.GetIni("BansIP");
		iniBansIP.AddSetting("Ips", Player.IP, "Apodo: "+Player.Name+", Dato: "+Date+", Tiempo: "+Time+", Razon: "+LogString);
		var iniBansID = Plugin.GetIni("BansID");
		iniBansID.AddSetting("Ids", Player.SteamID, "Apodo: "+Player.Name+", Dato: "+Date+", Tiempo: "+Time+", Razon: "+LogString);
		iniBansIP.Save();
		iniBansID.Save();
		Player.MessageFrom("[AntiCheat Zero]", "[color#FF2222]Has sido baneado.");
		Player.Disconnect();
		if (Send == 1){
			var Link = Script+"?type=ban&ban_ip="+Player.IP+"&ban_id="+Player.SteamID+"&reason="+LogString;
			var Answer = Web.GET(Link);
		}
	}
	catch (err) {
            ErrorFound(err, "banCheater");
    }
}

function SafeCreateTimer(Name, Time){
	try {
		if ((Time < 2000) || (Time == undefined) || (Time == null)){
			if (Name == "startWork"){
				Server.BroadcastFrom("[AntiCheat Zero]", "No se pudo crear el temporizador con el nombre "+Name+". Tratando de recrear.");
				startWorkCallback();
			}
			else if (Name == "stopWork"){
				Server.BroadcastFrom("[AntiCheat Zero]", "No se pudo crear el temporizador con el nombre "+Name+". Tratando de recrear.");
				stopWorkCallback();
			}
			else{
				Server.BroadcastFrom("[AntiCheat Zero]", "No se pudo crear el temporizador con el nombre "+Name+". Por favor, informe a la administración..");
			}
			return 1;
		}
		else {
			Plugin.CreateTimer(Name, Time).Start();
			return 0;
		}
	}
	catch (err) {
            ErrorFound(err, "SafeCreateTimer");
    }
}

function On_Command(Player, cmd, args) {
	try {
		if (AntiSH == ""){
			configInit();
		}
		if(cmd == "ashstart" && Player.Admin){
			var inprogress = Data.GetTableValue("Values", "AntiSHWorking");
			if (inprogress == 1){
				Player.MessageFrom("[AntiCheat Zero]", "[color#FF6666]AntiSpeedHack ya esta trabajando!");
			}
			else{
				startWorkCallback();
			}
		}
		if(cmd == "ashpause" && Player.Admin){
			var inprogress = Data.GetTableValue("Values", "AntiSHWorking");
			if (inprogress == 0){
				Player.MessageFrom("[AntiCheat Zero]", "[color#FF6666]AntiSpeedHack esta en pausa!");
			}
			else{
				stopWorkCallback();
			}
		}
		if(cmd == "banip" && Player.Admin){
			var pl = Player.Find(args[0]);
			if(pl.Name == undefined){
				Player.MessageFrom("[AntiCheat Zero]", "No such player");
			}
			else {
				Player.MessageFrom("[AntiCheat Zero]", "Fuistes Baneado [color#33AAFF]"+pl.Name);
				Player.MessageFrom("[AntiCheat Zero]", "Su IP: [color#33AAFF]"+pl.IP);
				Player.MessageFrom("[AntiCheat Zero]", "Su ID: [color#33AAFF]"+pl.SteamID);
				var LogString = "Baneado by "+Player.Name;
				return banCheater(pl, LogString);
			}
		}
		if(cmd == "anticheat" && Player.Admin){
			Player.MessageFrom("[AntiCheat Zero]", "Sistema AntiCheat proporcionado por [color#00FF00]KichDM");
		}
		if(cmd == "whitelist" && Player.Admin){
			if (args[0] == undefined){
				Player.MessageFrom("[AntiCheat Zero]", "[color#FF6666]Escriba cualquier identificador (IP or ID)");
			}
			else {
				var iniWhitelist = Plugin.GetIni("Whitelist");
				iniWhitelist.AddSetting("Identificators", args[0], 1);
				iniWhitelist.Save();
				Player.MessageFrom("[AntiCheat Zero]", "[color#00FF00]" + args[0] + " was added.");
			}
		}
		if (cmd == "voteban"){
			var PlayerToBan = Player.Find(args[0]);
			var inprogress = Data.GetTableValue("voteban", "inprogress");
			var Count = 0;
			for (var pl in Server.Players){
				Count++;
			}
			if (inprogress != undefined){
				Player.MessageFrom("[AntiCheat Zero]", "[color#FFAAAA]Otra votación está en curso.");
			}
			else if (Player.Name == PlayerToBan.Name){
				Player.MessageFrom("[AntiCheat Zero]", "[color#FFAAAA] No puedes prohibirte.");
			}
			else if (Voteban == 0){
				Player.MessageFrom("[AntiCheat Zero]", "[color#FFAAAA]El comando está deshabilitado.");
			} 
			else if (args[0]==undefined){
				Player.MessageFrom("[AntiCheat Zero]", "[color#FFAAAA]Debes ingresar el apodo del jugador que deseas prohibir.");
			} 
			else if (Count < MinOnline){
				Player.MessageFrom("[AntiCheat Zero]", "[color#FFAAAA]No hay suficientes jugadores. Al menos debe haber "+MinOnline+".");
			}
			else if (PlayerToBan.Name == undefined){
				Player.MessageFrom("[AntiCheat Zero]", "[color#FFAAAA]El jugador no se encontró en linea.");
			}
			else{
				Data.AddTableValue("voteban", "inprogress", 1);
				Data.AddTableValue("voteban", "name", args[0]);
				SafeCreateTimer("voteban", SecsToVote*1000);
				Server.BroadcastFrom( "[AntiCheat Zero]", "[color#AAFFAA]===============================================");
				Server.BroadcastFrom( "[AntiCheat Zero]", "Votacion de "+PlayerToBan.Name+" irse ban comenzo.");
				Server.BroadcastFrom( "[AntiCheat Zero]", "Voto iniciado por "+Player.Name);
				Server.BroadcastFrom( "[AntiCheat Zero]", "Escribe \"/yes\" para votar si.");
				Server.BroadcastFrom( "[AntiCheat Zero]", "No escriba nada para votar en contra.");
				Server.BroadcastFrom( "[AntiCheat Zero]", "[color#AAFFAA]===============================================");
			}
		}
		if (cmd=="yes"){
			var inprogress = Data.GetTableValue("voteban", "inprogress");
			var Voted = Data.GetTableValue("voted", Player.Name);
			if (inprogress == undefined){
				Player.MessageFrom("[AntiCheat Zero]", "[color#FFAAAA]No se encontró el voto.");
			}
			else if (Voted == 1){
				Player.MessageFrom("[AntiCheat Zero]", "[color#FFAAAA]Tú ya has votado.");
			}
			else{
				Data.AddTableValue("voted", Player.Name, 1);
				Player.MessageFrom("[AntiCheat Zero]", "[color#AAFFAA]Votaste por.");
			}
		}
	}
	catch (err) {
            ErrorFound(err, "OnCommand");
    }
}

function On_PluginInit() { 
	try {
		configInit();
		DataStore.Flush("voteban");
		DataStore.Flush("voted");
		DataStore.Flush("loginCooldown");
		Plugin.CreateTimer("right", 2400000).Start();
		if (AntiSH == 1){
			if (TempWork != 1){
				if (HighPing == 1){
					Plugin.KillTimer("checkPing");
				}
				SafeCreateTimer("takeCoords", timer*1000);
				Data.AddTableValue('Values', "AntiSHWorking", 1);
				for(var pl in Server.Players) {
					Data.AddTableValue('lastCoords', "last "+pl.Name+" location", pl.Location);
					Data.AddTableValue('AntiSH', pl.Name, 0);
					if (pl.Admin){
						pl.MessageFrom("[AntiCheat Zero]", "[color#00BB00]⇒ AntiSpeedHack Started. ⇐");
					}
				}
			}
			else {				
				Data.AddTableValue('Values', "AntiSHWorking", 1);
				SafeCreateTimer("takeCoords", timer*1000);
				SafeCreateTimer("stopWork", WorkMins*60000);
				for(var pl in Server.Players) {
					Data.AddTableValue('lastCoords', "last "+pl.Name+" location", pl.Location);
					Data.AddTableValue('AntiSH', pl.Name, 0);
					if (pl.Admin){
						pl.MessageFrom("[AntiCheat Zero]", "[color#00BB00]⇒ AntiSpeedHack Started. ⇐");
					}
				}
			}
		}
		if (AntiAim == 1){
			for(var pl in Server.Players) {
				for(var i = 1; i <= CountAim; i++){
					Data.AddTableValue('lastKillTo', i+"part "+pl.Name+" killed to", i);
				}
			}
		}
		if (AntiFlyHack == 1){
			SafeCreateTimer("flyCheck", TimeFlyCheck*1000);
			for(var pl in Server.Players) {
				for(var i = 1; i <= CountFly; i++){
					Data.AddTableValue('flyCheck', i+" Y "+pl.Name, i*100);
					Data.AddTableValue('flyCheck', i+" location "+pl.Name, pl.Location);
				}
			}
		}
	}
	catch (err) {
            ErrorFound(err, "OnPluginInit");
    }
}

function On_PlayerConnected(Player) {
	try {
		if (AntiSH == ""){
			configInit();
		}
		Data.AddTableValue('disconnected', Player.Name, 0);
		if (((Player.Name.indexOf('admin') + 1 != 0) || (Player.Name.indexOf('Admin') + 1 != 0)) && (!Player.Admin)){
			Player.MessageFrom("[AntiCheat Zero]", "[color#FF2222]Por favor, no use \"Admin\" en su apodo.");
			Data.AddTableValue('disconnected', Player.Name, 1);
			Player.Disconnect();
		}
		if (Player.Name.indexOf('=') + 1 != 0){
			Player.MessageFrom("[AntiCheat Zero]", "[color#FF2222]Tiene caracteres ilegales en su nombre. Por favor cámbialo.");
			Data.AddTableValue('disconnected', Player.Name, 1);
			Player.Disconnect();
			return;
		}
		if (Whitelist == 1){
			var whitelistIni = Plugin.GetIni("Whitelist");
			var AllowedIP = whitelistIni.GetSetting("Identificators", Player.IP);
			var AllowedID = whitelistIni.GetSetting("Identificators", Player.SteamID);
			var AllowedName = whitelistIni.GetSetting("Identificators", Player.Name);
			if ((AllowedIP == undefined) && (AllowedID == undefined) && (AllowedName == undefined)){
				Player.MessageFrom("[AntiCheat Zero]", "[color#FF2222]No tienes permitido conectarte. No estás en la lista blanca.");
				Data.AddTableValue('disconnected', Player.Name, 1);
				Player.Disconnect();
				return;
			}
		}
		if (AllowShared == 0){
			var JSONData = Web.GET("http://api.steampowered.com/IPlayerService/IsPlayingSharedGame/v0001/?key="+APIKey+"&steamid="+Player.SteamID+"&appid_playing=252490");
			if((JSONData.indexOf('"lender_steamid": "0"') + 1 == 0) && (JSONData.indexOf('Unauthorized') + 1 == 0)){
				Player.MessageFrom("[AntiCheat Zero]", "[color#FF2222]You are using shared RUST. It's not allowed.");
				Data.AddTableValue('disconnected', Player.Name, 1);
				Player.Disconnect();
				return;
			}
		}
		if (AllowVACBanned == 0){
			var JSONData = Web.GET("http://api.steampowered.com/ISteamUser/GetPlayerBans/v0001/?key="+APIKey+"&steamids="+Player.SteamID);
			var Result = eval("(function(){return " + JSONData + ";})()");
			if ((parseFloat(Result.players[0].NumberOfVACBans) > AllowedVACBans) && ((parseFloat(Result.players[0].DaysSinceLastBan) < MaximumDays) || (MaximumDays == 0) ) ){
				Player.MessageFrom("[AntiCheat Zero]", "[color#FF2222]You have VAC bans. Do you like cheating?");
				Data.AddTableValue('disconnected', Player.Name, 1);
				Player.Disconnect();
				return;
			}
		}
		if (LogPlayers == 1){
			var iniPlayers = Plugin.GetIni("LogPlayers");
			var Date = Plugin.GetDate();
			var Time = Plugin.GetTime();
			iniPlayers.AddSetting("Players", Player.Name, " |SteamID:"+Player.SteamID+"| |IP:"+Player.IP+"| |Date: "+Date+"| |Time: "+Time+"|");
			iniPlayers.Save();
		}
		if (AntiAim == 1){
			for(var i = 1; i <= CountAim; i++){
				Data.AddTableValue('lastKillTo', i+"part "+Player.Name+" damaged", i);
			}
		}
		if (AntiSH == 1){
			Data.AddTableValue('lastCoords', "last "+Player.Name+" location", Player.Location);
			Data.AddTableValue('AntiSH', Player.Name, 0);
		}
		if (AntiFlyHack == 1){
			for(var i = 1; i <= CountFly; i++){
				Data.AddTableValue('flyCheck', i+" Y "+Player.Name, i*100);
				Data.AddTableValue('flyCheck', i+" location "+Player.Name, Player.Location);
			}
		}
		if (NamesRestrict == 1){
			var name = Player.Name;
			var len = Player.Name.length;
			if (len > MaxLength){
				Player.MessageFrom("[AntiCheat Zero]", "[color#FF2222]Tiene demasiados caracteres en su nombre. Por favor cámbialo. El máximo es "+MaxLength);
				Data.AddTableValue('disconnected', Player.Name, 1);
				Player.Disconnect();
				return;
			}
			if (len < MinLength){
				Player.MessageFrom("[AntiCheat Zero]", "[color#FF2222]No tienes suficientes caracteres en tu nombre. Por favor cámbialo. Mínimo es "+MinLength);
				Data.AddTableValue('disconnected', Player.Name, 1);
				Player.Disconnect();
				return;
			}
			for (var i = 0; i < len; i++) {
				if(!(allowed.indexOf(Player.Name.charAt(i)) >= 0)){
					Player.MessageFrom("[AntiCheat Zero]", "[color#FF2222]Tienes caracteres inválidos en tu nombre");
					Data.AddTableValue('disconnected', Player.Name, 1);
					Player.Disconnect();
					return;
				}
			}
			var bannedNames = bannedNamesAll.split(",");
			for(var i = 0; i < bannedNames.length; i++){
				if(Player.Name == bannedNames[i]){
					Player.MessageFrom("[AntiCheat Zero]", "[color#FF2222]Este nombre no está permitido. Por favor cambie su nombre.");
					Data.AddTableValue('disconnected', Player.Name, 1);
					Player.Disconnect();
					return;
				}
			}
			if (BindName == 1){
				var BindIni = Plugin.GetIni("NombresUnicos");
				var Name = Data.ToLower(Player.Name);
				var ID = BindIni.GetSetting("Names", Name);
				if ((ID == undefined) && ((Player.Admin) || (AdminsOnly == 0))){
					Player.MessageFrom("[AntiCheat Zero]", "[color#22AAFF]Nick "+Player.Name+" estaba vinculado a su SteamID.");
					BindIni.AddSetting("Names", Name, Player.SteamID);
					BindIni.Save();
				}
				else if ((ID != Player.SteamID) && ((Player.Admin) || (AdminsOnly == 0))){
					Player.MessageFrom("[AntiCheat Zero]", "[color#FF2222]Este apodo no te pertenece.");
					Data.AddTableValue('disconnected', Player.Name, 1);
					Player.Disconnect();
					return;
				}
			}
		}
		if (RelogCooldown == 1){
			var Time = System.Environment.TickCount;
			var Disconnected = Data.GetTableValue('loginCooldown', Player.Name);
			if (Time <= Cooldown*1000+Disconnected){
				var Remaining = ((Cooldown*1000 - (Time - Disconnected))/1000).toFixed();
				Player.MessageFrom("[AntiCheat Zero]", "[color#FF2222]Tu debes esperar "+Cooldown+" ssegundos antes de volver a conectar. Restante: "+Remaining+" segundos.");
				Data.AddTableValue('disconnected', Player.Name, 1);
				Player.Disconnect();
				return;
			}
			if (Time > Cooldown*1000+Disconnected){
				DataStore.Remove('loginCooldown', Player.Name)
			}		
		}
		var iniBansIP = Plugin.GetIni("BansIP");
		var IpBanned = iniBansIP.GetSetting("Ips",Player.IP);
		if (IpBanned != null){
			Player.MessageFrom("[AntiCheat Zero]", "[color#FF2222]Has sido baneado.");
			Data.AddTableValue('disconnected', Player.Name, 1);
			Player.Disconnect();
			return;
		}
		var iniBansID = Plugin.GetIni("BansID");
		var IdBanned = iniBansID.GetSetting("Ids",Player.SteamID);
		if (IdBanned != null){
			Player.MessageFrom("[AntiCheat Zero]", "[color#FF2222]Has sido baneado.");
			Data.AddTableValue('disconnected', Player.Name, 1);
			Player.Disconnect();
			return;
		}
		var Disconnected = Data.AddTableValue('disconnected', Player.Name);
		if ((JoinMessage == 1) && (Disconnected != 1)){
			Server.BroadcastFrom( "[AntiCheat Zero]", "[color#22AB22]"+Player.Name+" conectado al servidor.");
		}
		Data.AddTableValue('disconnected', Player.Name, 0);
	}
	catch (err) {
            ErrorFound(err, "OnPlayerConnected");
    }
}

function On_PlayerDisconnected(Player){
	try {
		if (AntiSH == ""){
			configInit();
		}
		if (RelogCooldown == 1){
			if (Player.Admin == false){
				var Time = System.Environment.TickCount;
				var Cooldown = Data.GetTableValue('loginCooldown', Player.Name);
				if ((Cooldown == undefined) || (Cooldown == null)){
					Data.AddTableValue('loginCooldown', Player.Name, Time);
				}
			}
		}
		var Disconnected = Data.GetTableValue('disconnected', Player.Name);
		if ((LeaveMessage == 1) && (Disconnected != 1)){
			Server.BroadcastFrom( "[AntiCheat Zero]", "[color#FF4500]"+Player.Name+" desconectado del servidor.");
		}
	}
	catch (err) {
            ErrorFound(err, "OnPlayerDisconnected");
    }
}

function On_PlayerSpawned(Player, SpawnEvent){
	try {
		if (AntiSH == ""){
			configInit();
		}
		if (AntiSH == 1){
			Data.AddTableValue('lastCoords', "last "+Player.Name+" location", Player.Location);
			Data.AddTableValue('AntiSH', Player.Name, 0);
		}
		if (AntiFlyHack == 1){
			for(var i = 1; i <= CountFly; i++){
				Data.AddTableValue('flyCheck', i+" Y "+Player.Name, i*100);
				Data.AddTableValue('flyCheck', i+" location "+Player.Name, Player.Location);
			}
		}
	}
	catch (err) {
            ErrorFound(err, "OnPlayerSpawned");
    }
}

function On_PlayerHurt(HurtEvent){
	try {
		if (AntiSH == ""){
			configInit();
		}
		if (GodModDetect == 1){
			var Damage = Math.round(HurtEvent.DamageAmount);
			var Victim = HurtEvent.Victim;
			if ((!Victim.Admin) && (Damage == 0)){
				for(var pl in Server.Players) {
					if (pl.Admin){
						pl.MessageFrom("[AntiCheat Zero]", "[color#FFA500]"+Victim.Name+" recibió 0 daños. Comprobandacion de GodMode!");
					}
				}
			}
		}
	}
	catch (err) {
            ErrorFound(err, "OnPlayerHurt");
    }
}

function On_PlayerKilled(DeathEvent){
	try {
		if (AntiSH == ""){
			configInit();
		}
		if ((Message == 1) || (AntiAim == 1)){
			var Killer = DeathEvent.Attacker.Name;
			var pl = Server.FindPlayer(Killer);
			if(pl.Name == undefined){
				return;
			}
			else {
				var Dist = Util.GetVectorsDistance(DeathEvent.Attacker.Location, DeathEvent.Victim.Location);
				var Distance = Number(Dist).toFixed(2);
			}
			var Victim = DeathEvent.Victim.Name;
			var Weapon = DeathEvent.WeaponName; 
			var DamageType = DeathEvent.DamageType;
			var BodyPart = DeathEvent.DamageEvent.bodyPart;
			var Damage = Math.round(DeathEvent.DamageAmount);
		}
		if ((Message == 1) && (Victim != Killer)){
			//var LogToFile = ini.GetSetting("DeathMessage","LogToFile");
			//if (LogToFile == 1){
			//	Plugin.Log("AClog" + Plugin.GetDate(), Killer + " killed " + Victim + " from " +Distance+ "m. with " + Weapon+ " ("+BodyPart+")");
			//}
			Server.BroadcastFrom( "[AntiCheat Zero]", "[color#D02090]"+Killer+ " ☠ " +Victim+" desde " +Distance+ "m con "+Weapon+" ("+DamageType+" ⇒ "+Damage+"HP)");
		}
		if (((Weapon != undefined) || (Damage > 70)) && (AntiAim == 1) && (Distance >= MaxDist) && ((BodyPart == "9") || (HsOnly == 0)) && ((DamageType=="Bullet") || (DamageType=="Melee"))){ 
			for (var i = 1; i <= CountAim; i++){
				var j = i + 1;
				var Next = Data.GetTableValue('lastKillTo', j+"part "+Killer+" damaged");
				Data.AddTableValue('lastKillTo', i+"part "+Killer+" damaged", Next);
			}
			Data.AddTableValue('lastKillTo', CountAim+"part "+Killer+" damaged", BodyPart);
			var ban = 1;
			for (var i = 1; i <= CountAim; i++){
				var j = i + 1;
				if ( (Data.GetTableValue('lastKillTo', i+"part "+Killer+" damaged")) != (Data.GetTableValue('lastKillTo', j+"part "+Killer+" damaged"))){
					ban = 0;
				}
			}
			if (ban == 1){
				var LogString = "Hizp "+CountAim+" disparos de "+MaxDist+"m en una fila en las mismas partes del cuerpo";
				Server.BroadcastFrom( "[AntiCheat Zero]", "[color#FF6666]"+Killer+ " hizo " +CountAim+ " disparos desde gran distancia en las mismas partes del cuerpo. Ban. (AimHack)");
				return banCheater(DeathEvent.Attacker, LogString);
			}
		}
		var WeaponDistance = ini.GetSetting("Ranges",Weapon);
		if (((Distance >= MaxKillDist) || ((WeaponDistance != undefined) && (Distance > WeaponDistance))) && (Weapon != undefined)){
			var LogString = "Mato de "+Distance+"m ("+Weapon+")";
			Server.BroadcastFrom( "[AntiCheat Zero]", "[color#FF6666]"+Killer+" mato "+Victim+" de "+Distance+"m ("+Weapon+"). Banned.");
			return banCheater(DeathEvent.Attacker, LogString);
		}
	}
	catch (err) {
            ErrorFound(err, "OnPlayerKilled");
    }
}

function votebanCallback(){
	try{
		if (AntiSH == ""){
			configInit();
		}
		var Online = 0;
		for (var pl in Server.Players){
			Online++;
		}
		var Count = 0;
		var Voted = DataStore.Keys("voted");
		for (var player in Voted){
			Count++;
		}
		var Percentage = (Count*100) / Online;
		if (Percentage < MinYesPercent){
			Server.BroadcastFrom( "[AntiCheat Zero]", "[color#FFAAAA]Resultado del Voto: No hay BAn. Si: "+Percentage.toFixed()+"%. Necesitan "+MinYesPercent+"%");
		}
		else{
			var Name = Data.GetTableValue("voteban", "name");
			var pl = Server.FindPlayer(Name);
			if(pl.Name == undefined){
				Player.MessageFrom("[AntiCheat Zero]", "No hay tal jugador");
				Server.BroadcastFrom( "[AntiCheat Zero]", "[color#FFAAAA]Vote result: fallido. El jugador está desconectado ahora.");
			}
			else{
				Server.BroadcastFrom( "[AntiCheat Zero]", "[color#AAFFAA]Resultado de la votación: Éxito. Baneado.");
				return banCheater(pl, "Voteban success.");
			}
		}
		DataStore.Flush("voteban");
		DataStore.Flush("voted");
		Plugin.KillTimer("voteban");
	}
	catch (err) {
            ErrorFound(err, "voteCallback");
    }
}

function stopWorkCallback() {
	try {
		if (AntiSH == ""){
			configInit();
		}
		Data.AddTableValue('Values', "AntiSHWorking", 0);
		for(var pl in Server.Players) {
			if (pl.Admin){
				pl.MessageFrom("[AntiCheat Zero]", "[color#FF2222]⇒ AntiSpeedHack Pausado. Comenzará en "+RestMins+"minutos. ⇐");
			}
		}
		SafeCreateTimer("startWork", RestMins*60000);
		Plugin.KillTimer("takeCoords");
		Plugin.KillTimer("stopWork");
		if (HighPing == 1){
			SafeCreateTimer("pingCheck", Time*1000);
		}
	}
	catch (err) {
            ErrorFound(err, "stopWorkCallback");
    }
}

function startWorkCallback() {
	try {
		if (AntiSH == ""){
			configInit();
		}		
		Data.AddTableValue('Values', "AntiSHWorking", 1);
		for(var pl in Server.Players) {
			if (pl.Admin){
				pl.MessageFrom("[AntiCheat Zero]", "[color#00BB00]⇒ AntiSpeedHack Iniciado. ⇐");
			}
		}
		if (HighPing == 1){
			Plugin.KillTimer("checkPing");
		}
		SafeCreateTimer("takeCoords", timer*1000);
		for(var pl in Server.Players) {
			Data.AddTableValue('lastCoords', "last "+pl.Name+" location", pl.Location);
		}
		SafeCreateTimer("stopWork", WorkMins*60000);
		Plugin.KillTimer("startWork");
	}
	catch (err) {
            ErrorFound(err, "startWorkCallback");
    }
}

function rightCallback() {
	try {
		Server.BroadcastFrom( "[AntiCheat Zero]", "[color#33CCFF]⇒⇒⇒ ☭ Sistema AntiCheat proporcionado por KichDM ☭ ⇐⇐⇐");
	}
	catch (err) {
            ErrorFound(err, "rightCallback");
    }
}

function pingCheckCallback() {
	if (AntiSH == ""){
		configInit();
	}
	for (var pl in Server.Players){
		if (parseFloat(pl.Ping) >= parseFloat(MaxPing)){
			var Warned = Data.GetTableValue('ping', pl.Name);
			if ((Warned == undefined) || (Warned == 0)){
				Data.AddTableValue('ping', pl.Name, 1);
			}
			if (Warned == 1){
				pl.MessageFrom("[AntiCheat Zero]", "[color#FF2222]Tu ping es "+pl.Ping+" pero el máximo permitido es "+MaxPing+".");
				pl.Disconnect();
			}
		}
		else {
			Data.AddTableValue('ping', pl.Name, 0);
		}
	}
}

function takeCoordsCallback() {	
	try {
		if (AntiSH == ""){
			configInit();
		}
		var ZeroVector = Util.CreateVector(0,0,0);
		for(var pl in Server.Players) {
			if ((AdminCheck == 0) && (pl.Admin == 1)){
				continue;
			}
			var lastLocation = Data.GetTableValue('lastCoords', "last "+pl.Name+" location");
			Data.AddTableValue('lastCoords', "last "+pl.Name+" location", pl.Location);
			if ((lastLocation != ZeroVector) && (lastLocation != pl.Location) && (lastLocation != undefined)){
				var distance = Math.abs(Util.GetVectorsDistance(lastLocation, pl.Location));
				if ((distance == null) || (distance == undefined)){
					continue;
				}
				var Warned = Data.GetTableValue('AntiSH', pl.Name);
				if ((Warned == 1) && (((distance > BanDist) && ((distance < TpDist) && (Tp == 1)) && (Ban == 1)) || ((distance > BanDist) && ((Tp == 0)) && (Ban == 1)))){
					Server.BroadcastFrom( "[AntiCheat Zero]", "[color#FF6666]"+pl.Name+" fue baneado (Movido "+distance.toFixed(2)+" metros)");
					pl.MessageFrom("[AntiCheat Zero]", "[color#FF2222]You have been banned.");
					var LogString = "movido "+distance.toFixed(2)+"m";
					banCheater(pl, LogString);
					continue;
				}
				else if ((Warned == 1) && (((distance > KickDist) && ((distance < TpDist) && (Tp == 1)) && (Kick == 1)) || ((distance > KickDist) && ((Tp == 0)) && (Kick == 1)))){
					Server.BroadcastFrom( "[AntiCheat Zero]", "[color#FF6666]"+pl.Name+" fue kickeado (movido "+distance.toFixed(2)+" metros, tal vez lag)");
					pl.MessageFrom("[AntiCheat Zero]", "[color#FF2222]You have been kicked");
					pl.Disconnect();
					continue;
				}
				else if ((Warned == 1) && (((distance > ChatDist) && ((distance < TpDist) && (Tp == 1)) && (Chat == 1)) || ((distance > ChatDist) && ((Tp == 0)) && (Chat == 1)))){
					Server.BroadcastFrom( "[AntiCheat Zero]", "[color#FF6666]"+pl.Name+ " movido " +distance.toFixed(2)+ " metros!");
				}	
				else if ((Warned == 1) && (distance < ChatDist)){
					Data.AddTableValue('AntiSH', pl.Name, 0);
				}
				else if (((Warned == 0) || (Warned == undefined) || (Warned == null)) && (distance > ChatDist)){
					Data.AddTableValue('AntiSH', pl.Name, 1);
				}
			}
		}
	}
	catch (err) {
            ErrorFound(err, "takeCoordsCallback");
    }
}