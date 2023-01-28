/**
 * Created by DreTaX on 2014.03.11.. V1.8.3
 */
function On_PlayerConnected(Player)
{
	var id = Player.SteamID;
	var iban = ManualBan();
	var isbanned = iban.GetSetting("Banned", id);
	if (isbanned == 1 && isbanned != null) {
		Player.Disconnect();
		return;
	}
    var name = Player.Name;
	var ip = Player.IP;
	var time = System.DateTime.Now;
	var location = Player.Location;
	try {
		var ini = PlayersIni();
		if (ini.GetSetting("Track", id) != null && ini.GetSetting("LastJoin", name) != null) {
			ini.SetSetting("Track", id, name);
			ini.SetSetting("LastJoin", name, "|" + id + "|" + ip + "|" + time + "|" + location);
		}
		else {
			ini.AddSetting("Track", id, name);
			ini.AddSetting("LastJoin", name, "|" + id + "|" + ip + "|" + time + "|" + location);
		}
		ini.Save();
	} catch(err) {
        Plugin.Log("IdIdentError", "Error caught at join method.");
	}
}

function On_PlayerDisconnected(Player)
{
	var name = Player.Name;
    var id = Player.SteamID;
	var time = System.DateTime.Now;
	var location = Player.Location;
	try {
		var ini = PlayersIni();
		if (ini.GetSetting("Track", name) != null) {
			ini.SetSetting("LastQuit", name, "|" + id + "|" + time + "|" + location);
		}
		else {
			ini.AddSetting("LastQuit", name, "|" + id + "|" + time + "|" + location);
		}
		ini.Save();
	} catch(err) {
        Plugin.Log("IdIdentError", "Error caught at quit method.");
	}
}

function PlayersIni(){
	if(!Plugin.IniExists("Players")) {
		var ini = Plugin.CreateIni("Players");
		ini.Save();
	}
	return Plugin.GetIni("Players");
}

function ManualBan(){
	if(!Plugin.IniExists("ManualBan")) {
		var ini = Plugin.CreateIni("ManualBan");
		ini.Save();
	}
	return Plugin.GetIni("ManualBan");
}

/**
 * This owner code was made by: Author: Sylar | I just edited it to fit my plugin
 */

function On_Command(Player, cmd, args)
{
	if(cmd == "owner") {
		if (args.Length == 0) {
			Player.Message("OwnerMode");
			Player.Message("To activate use the command \"/owner start\"");
			Player.Message("To deactivate use the command \"/owner stop\"");
		}
		if (args.Length == 1) {
			if (Player.Admin) {
				var id = Player.SteamID;
				if(args[0] == "start") {
					DataStore.Add("OwnerMode", id, "true");
					Player.Message("---Owner---");
					Player.Message("You are in Owner mode");
					Player.Message("If you finished, don't forget to quit from It!");
				}		
				else if(args[0] == "stop") {
					DataStore.Add("OwnerMode", id, "false");
					Player.Message("---Owner---");
					Player.Message("You quit Owner mode!");
				}	
			}
		}
	}
	else if(cmd == "offban") {
		if (args.Length == 0) {
			Player.Message("Specify an ID");
		}
		if (args.Length == 1) {
			if (Player.Admin) {
				var id = args[0];
				var iban = ManualBan();
				iban.AddSetting("Banned", id, 1);
				iban.Save();
				Player.Message("Id of Player (" + id + ") was banned.");
			}
		}
	}
}

function On_EntityHurt(HurtEvent)
{
	if (HurtEvent.Attacker != null && HurtEvent.Entity != null && !HurtEvent.IsDecay && HurtEvent.Attacker.SteamID != null) {
		var get = DataStore.Get("OwnerMode", HurtEvent.Attacker.SteamID);
		if (get != null && get == "true") {
			var type = HurtEvent.DamageType;
			var gun = HurtEvent.WeaponName;
			if (gun == "Hatchet" || gun == "Stone Hatchet" || gun == "Rock" || gun == "Pick Axe" || gun == "HandCannon" || gun == "Pipe Shotgun" || gun == "Revolver" || gun == "9mm Pistol" || gun == "P250" || gun == "Shotgun" || gun == "Bolt Action Rifle" || gun == "M4" || gun == "MP5A4") {
				if (type == "Bleeding") {
					HurtEvent.Entity.GetTakeDamage().health += HurtEvent.DamageAmount * 2;
					HurtEvent.Entity.UpdateHealth();
					var OwnerID = HurtEvent.Entity.OwnerID.toString();
					var ini = PlayersIni();
					var name = ini.GetSetting("Track", OwnerID);
					if (name != null) {
						HurtEvent.Attacker.Notice(HurtEvent.Entity.Name + " is owned by " + name + ".");
					} 
					else {
						HurtEvent.Attacker.Notice(HurtEvent.Entity.Name + " is owned by " + OwnerID + ".");
					}
				}
			}
		}
	}
}