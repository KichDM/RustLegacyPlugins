/* HACKER DETECTION AND PUNISH PLUGIN
 * BY LeonelF
 * Version 1.0                      */
function On_PlayerKilled(deathEvent) {
	if(getConfig("enable") != "true")
		return;
	if(deathEvent.Attacker != deathEvent.Victim) {
		var weapon = deathEvent.WeaponData.dataBlock.get_name();
		if(weapon != null && weapon != "undefined" && !deathEvent.Attacker.Admin) {
			var distance = getDistance(deathEvent.Attacker, deathEvent.Victim);
			if (distance > getRange(weapon) && getRange(weapon) > 0) {
				deathEvent.Attacker.Kill();
				Server.Broadcast("Attention! " + deathEvent.Attacker.Name + " was detected as Hacker (Killed and Auto-Banned)! -EF");
				var ini = getHackerIni();
				ini.AddSetting("hackersID",deathEvent.Attacker.SteamID,"Banned");
				ini.AddSetting("hackersIP",deathEvent.Attacker.IP,"Banned");
				ini.AddSetting("hackersLog",deathEvent.Attacker.SteamID,deathEvent.Attacker.Name + " IP:" + deathEvent.Attacker.IP);
				ini.Save();
				deathEvent.Attacker.Disconnect();
			}
		}
	}
}


function On_PlayerConnected(Player){
	if (getHackerID(Player.SteamID) == "Banned" || getHackerIP(Player.SteamIP) == "Banned") {
		Server.Broadcast(Player.Name + " was detected as Hacker (Auto-Banned)-EF");
		Player.Message("You have been detected has hacker, auto-banned!-EF");
		Player.Disconnect();
	}
}

function getDistance(player, player2) {
	var x = Math.pow((player.X - player2.X), 2);
	var y = Math.pow((player.Y - player2.Y), 2);
	var z = Math.pow((player.Z - player2.Z), 2);
	var distance = Math.sqrt(x + y + z);
	return Math.round(distance);
}

function getRange(weapon) {
	var ini = getWeaponRangeIni();
	var weaponRange = ini.GetSetting("range", weapon);
	return weaponRange;
}

function getWeaponRangeIni() {
	if(!Plugin.IniExists("weapons"))
		Plugin.CreateIni("weapons");
	return Plugin.GetIni("weapons");
}

function getHackerID(hacker) {
	var ini = getHackerIni();
	var hackerINI = ini.GetSetting("hackersID", hacker);
	return hackerINI;
}

function getHackerIP(hacker) {
	var ini = getHackerIni();
	var hackerINI = ini.GetSetting("hackersIP", hacker);
	return hackerINI;
}

function getHackerIni() {
	if(!Plugin.IniExists("hackers"))
		Plugin.CreateIni("hackers");
	return Plugin.GetIni("hackers");
}

function getConfig(key) {
	return Data.GetConfigValue("HackAutoBan", "Settings", key);
}