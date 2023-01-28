/////////////////////////////////////////////////
////Перевёл panda939. Специально для 9rust.net///
/////////////////////////////////////////////////
var playerf;

function On_Command(Player, cmd, args) {
	if(Data.GetConfigValue("TpFriend", "Settings", "enabled") == "false"){
		return;
	}
	switch(cmd) {
		case "tpa":
			if (args.Length == 0){
				Player.Message("Teleport Usage:");
				Player.Message("Вы будете телепортированы к другогому игроку.");
				Player.Message("\"/tpa [имя игрока]\", чтобы запросить телепорт.");
				Player.Message("\"/tpaccept\"чтобы принять запрос на телепорт.");
				Player.Messame("\"/tpdeny\" чтобы отклонить запрос.");
				Player.Message("\"/tpcount\" чтобы увидеть MAX запросов, и сколько у вас осталось.");
			}
			if (args.Length >= 1){
				var playertor = GetPlayer(args[0]);
				if (playertor == null) {
					Player.Message("Игрок " + playertor + " не найден!");	
					return;
				}
				if (playertor == Player) {
					Player.Notice("Вы не можете телепортировать себя!");
					return;
				}
				var maxuses = Data.GetConfigValue("TpFriend", "Settings", "Maxuses");
				var cd = Data.GetConfigValue("TpFriend", "Settings", "cooldown");
				var cooldown = parseInt(cd);
				var checkn = Data.GetConfigValue("TpFriend", "Settings", "safetpcheck");
				var stuff = Data.GetConfigValue("TpFriend", "Settings", "timeoutr");
				var time = Data.GetTableValue("tpfriendcooldown", Player.SteamID);
				var usedtp = Data.GetTableValue("tpfriendusedtp", Player.SteamID);
				var calc = System.Environment.TickCount - time;
				if (calc < 0) {
					time = Data.AddTableValue("tpfriendcooldown", Player.SteamID, null);
					Player.Message("Ваше время вышло! Попробуйте еще раз!");
				}
				if (calc >= cooldown) {
					if (usedtp == null) {
						Data.AddTableValue("tpfriendusedtp", Player.SteamID, 0);
						usedtp = 0;
					} 
					var maxtpnumber = parseInt(maxuses); 
					var playertpuse = parseInt(usedtp);
					if(maxtpnumber > 0) {
						if (maxtpnumber >= playertpuse) {
							Player.Notice("Достигнуто Максимальное число телепорт запросов!");
							return;
						}
					}
						
					/*if (Data.GetTableValue("tpfriendcooldown", Player.SteamID) != null) {
						Player.Message("You have already requested teleport, and It didn't get accepted/timed out yet!");
						return;
					}*/
					
					Data.AddTableValue("tpfriendcooldown", Player.SteamID, System.Environment.TickCount);
					playertor.Notice("Teleport request from " + Player.Name + " to accept write /tpaccept");
					Player.Notice("Teleport request sent to " + playertor.Name);
					Data.AddTableValue("tpfriendpending",  Player.SteamID, playertor.SteamID);
					Data.AddTableValue("tpfriendpending2",  playertor.SteamID, Player.SteamID);
					playerf = Player.SteamID;
					Plugin.CreateTimer("autokilltpfriend", 1000 * stuff).Start();
				}
				else {
					Player.Notice("Вам придется ждать до телепортации снова!");
					var next = calc / 1000;
					var next2 = next / 60;
					var def = cooldown / 1000;
					var def2 = def / 60;
					var done = Number(next2).toFixed(2); 
					var done2 = Number(def2).toFixed(2); 
					Player.Message("Оставшееся Время: " + done + "/" + done2);
				}
			}
			break;
		case "tpaccept":
			var pending = Data.GetTableValue("tpfriendpending2", Player.SteamID);
			if (pending != null) {
				var playerfromm = GetPlayerByID(pending);
				if (playerfromm != null) {
					Plugin.KillTimer("autokilltpfriend");
					var maxuses = Data.GetConfigValue("TpFriend", "Settings", "Maxuses");
					var checkn = Data.GetConfigValue("TpFriend", "Settings", "safetpcheck");
					var usedtp = Data.GetTableValue("tpfriendusedtp", pending);
					var maxtpnumber = parseInt(maxuses); 
					var playertpuse = parseInt(usedtp);
					var cd = Data.GetConfigValue("TpFriend", "Settings", "cooldown");
					var cooldown = parseInt(cd);
					var tpdelay = Data.GetConfigValue("TpFriend", "Settings", "tpdelay");
					if(maxtpnumber > 0) {
						var uses = playertpuse + 1;
						Data.AddTableValue("tpfriendusedtp", pending, uses);
						playerfromm.Notice("Телепорт запросы, используемые " + String(uses) + " / " + String(maxtpnumber));
					}
					else {
						playerfromm.Notice("У вас есть неограниченное количество запросов!");
					}
					
					if (tpdelay > 0) {
						playerfromm.Message("Телепортация: " + tpdelay + " секунд(ы)");
						Plugin.CreateTimer("delaytpfriend", 1000 * tpdelay).Start();
					}
					else {
						playerfromm.Message("Телепортирован!");
						playerfromm.TeleportTo(Player);
						Plugin.CreateTimer("tpthere", 1000 * checkn).Start();
					}
				} 
				else {
					Player.Message("Игрок не онлайн");
				}
			}
			else {
				Player.Message("Ваш запрос истёк, или Вы не запрашивали.");
			}
			break;
		case "tpdeny":
			var pending = Data.GetTableValue("tpfriendpending2", Player.SteamID);
			if (pending != null) {
				var playerfromm = GetPlayerByID(pending);
				if (playerfromm != null){
					Data.AddTableValue("tpfriendpending", pending, null);
					Data.AddTableValue("tpfriendcooldown", pending, null);
					Data.AddTableValue("tpfriendpending2", Player.SteamID, null);
					Player.Notice("Request denied!");
					playerfromm.Notice("Ваш запрос был отклонен!");
				}
			}else{
				Player.Notice("Просьба не отказать.");
			}
			break;
		case "tpcount":
			var maxuses = Data.GetConfigValue("TpFriend", "Settings", "Maxuses");
			if (maxuses > 0)
			{
				var uses = Data.GetTableValue("tpfriendusedtp", Player.Name);
				if(uses == null){
					uses = 0;
				}
				Player.Notice("Телепорт запросы, используемые " + String(uses) + " / " + String(maxuses));

			}else{
				Player.Notice("У вас есть неограниченное количество запросов!");
			}
			break;
		case "tphelp":
			Player.Message("Teleport Usage:");
			Player.Message("Вы будете телепортированы к другогому игроку.");
			Player.Message("\"/tpa [имя игрока]\", чтобы запросить телепорт.");
			Player.Message("\"/tpaccept\"чтобы принять запрос на телепорт.");
			Player.Messame("\"/tpdeny\" чтобы отклонить запрос.");
			Player.Message("\"/tpcount\" чтобы увидеть MAX запросов, и сколько у вас осталось.");
			Player.Message("\"/tpreset\" сброс вашего запроса счетчик, когда готов.");
			break;
		case "tpresettime":
			if (Player.Admin) {
				Data.AddTableValue("tpfriendcooldown", Player.SteamID, null);
				Player.Message("Ваше время, сброшено!");
			}
			break;
	}
}

function tpthereCallback() {
	var checkn = Data.GetConfigValue("TpFriend", "Settings", "safetpcheck");
	var playerid = Data.GetTableValue("tpfriendpending", playerf);
	var playerfrom = GetPlayerByID(playerf);
	var playerto = GetPlayerByID(playerid);
	if (playerid != null && playerfrom != null && playerto != null) {
		playerfrom.TeleportTo(playerto);
		playerfrom.Message("You have been teleported here again for safety reasons in: " + checkn + " secs");
		Data.AddTableValue("tpfriendpending", playerf, null);
		Data.AddTableValue("tpfriendpending2", playerid, null);
	}
	Plugin.KillTimer("tpthere");
}

function autokilltpfriendCallback() {
	var playerid = Data.GetTableValue("tpfriendpending", playerf);
	var playerfrom = GetPlayerByID(playerf);
	var playerto = GetPlayerByID(playerid);
	if (playerid != null && playerfrom != null && playerto != null) {
		Data.AddTableValue("tpfriendpending", playerf, null);
		Data.AddTableValue("tpfriendcooldown", playerf, null);
		Data.AddTableValue("tpfriendpending2",  playerid, null);
		playerfrom.Message("Teleport request timed out");
		playerto.Message("Teleport request timed out");
	}
	Plugin.KillTimer("autokilltpfriend");
}

function delaytpfriendCallback() {
	var checkn = Data.GetConfigValue("HomeSystem", "Settings", "safetpcheck");
	var playerid = Data.GetTableValue("tpfriendpending", playerf);
	var playerfrom = GetPlayerByID(playerf);
	var playerto = GetPlayerByID(playerid);
	if (playerid != null && playerfrom != null && playerto != null) {
		playerfrom.TeleportTo(playerto);
		Plugin.CreateTimer("tpthere", 1000 * checkn).Start();
	}
	Plugin.KillTimer("delaytpfriend");
}


function GetPlayer(name){
	name = Data.ToLower(name);
	for(pl in Server.Players){
		if(Data.ToLower(pl.Name) == name){
			return pl;
		}
	}
	return null;
}

function GetPlayerByID(id) {
	var player;
	for(var Players in Server.Players) {
		if (Players.SteamID == id) {
			player = Players;
			return player;
		}
	}
	return null;
}