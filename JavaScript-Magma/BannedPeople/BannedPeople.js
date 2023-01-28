//Fougerite
/**
 * Created by DreTaX on 2014.04.05.. V1.6
 */
 
function On_PluginInit() {
	var moderators = Moderators();
	var mods = moderators.EnumSection("Moderators");
	var counted = mods.Length;
	var i = 0;
	for (var mod in mods ) {
		i++;
		if (i <= counted) {
			var modid = moderators.GetSetting("Moderators", mod);
			DataStore.Add("Moderators", modid, mod);
		}
	}
}

function On_Command(Player, cmd, args) {
    if(cmd == "banip") {
        if (Player.Admin || isMod(Player.SteamID)) {
            var sysname = Data.GetConfigValue("BannedPeople", "Main", "Name");
            if (args.Length == 1) {
				var url = Data.GetConfigValue("BannedPeople", "Main", "url");
				var playerr = CheckV(Player, args);
                if (playerr == null) {
                    Player.MessageFrom(sysname, "No Player found with that name!");
                }
                else {
                    if (playerr.Admin) {
                        Player.MessageFrom(sysname, "You cannot ban admins!");
                        return;
                    }
					var id = playerr.SteamID;
					var ip = playerr.IP;
					var name = playerr.Name;
                    for(pl in Server.Players){
                        if (pl.Admin) {
                            pl.MessageFrom(sysname, "Message to Admins: " + name + " was banned by: " + Player.Name);
                        }
                    }
                    var ini = BannedPeopleIni();
                    ini.AddSetting("Ips", ip, "1");
                    ini.AddSetting("Ids", id, "1");
                    ini.AddSetting("NameIps", name, ip);
                    ini.AddSetting("NameIds", name, id);
					ini.AddSetting("AdminWhoBanned", name, Player.Name);
                    ini.Save();
                    Player.Message("You banned " + name);
                    Player.Message("Player's IP: " + ip);
                    Player.Message("Player's ID: " + id);
                    playerr.Message("You were banned from the server");
                    var checking = Data.AddTableValue("BanIp", Player.SteamID);
                    if (checking == "true") {
                        playerr.MessageFrom(sysname, "Admin, who banned you: UNKNOWN - Admin in Casing mode");
                    }
                    else if (checking == "false" || checking == null) {
                        playerr.MessageFrom(sysname, "Admin, who banned you: " + Player.Name);
                    }
                    playerr.Disconnect();
                }
            }
            else {
                Player.MessageFrom(sysname, "Specify a Name!");
            }
        }
    }
    if(cmd == "unbanip") {
        if (Player.Admin || isMod(Player.SteamID)) {
            var sysname = Data.GetConfigValue("BannedPeople", "Main", "Name");
            if (args.Length > 0) {
				var url = Data.GetConfigValue("BannedPeople", "Main", "url");
                var ini = BannedPeopleIni();
                var name = argsToText(args);
                var id = GetPlayerUnBannedID(name);
                var ip = GetPlayerUnBannedIP(name);
                if(id == null) {
                    Player.Message("Target: " + name + " isn't in the database, or you misspelled It!")
                }
                else {
                    name = id
                    var iprq = ini.GetSetting("NameIps", ip);
                    var idrq = ini.GetSetting("NameIds", id);
                    ini.DeleteSetting("Ips", iprq);
                    ini.DeleteSetting("Ids", idrq);
                    ini.DeleteSetting("NameIps", name);
                    ini.DeleteSetting("NameIds", name);
                    ini.Save();
                    for(pl in Server.Players){
                        if(pl.Admin){
                            pl.MessageFrom(sysname, name + " was unbanned by: " + Player.Name);
                        }
                    }
                    Player.MessageFrom(sysname, "Player " + name + " unbanned!");
                }
            }
            else {
                Player.MessageFrom(sysname, "Specify a Name!");
            }
        }
    }
    if(cmd == "banhidename") {
        if(Player.Admin || isMod(Player.SteamID)) {
            var sysname = Data.GetConfigValue("BannedPeople", "Main", "Name");
            if (args.Length == 0) {
                Player.MessageFrom(sysname, "BanIp HideName");
                Player.MessageFrom(sysname, "To activate use the command \"/banhidename true\"");
                Player.MessageFrom(sysname, "To deactivate use the command \"/banhidename false\"");
            }
            if (args.Length == 1) {
                if(args[0] == "true") {
                    Data.AddTableValue("BanIp", Player.SteamID, "true");
                    Player.MessageFrom(sysname, "Now hiding your name!");
                }
                if(args[0] == "false") {
                    Data.AddTableValue("BanIp", Player.SteamID, "false");
                    Player.MessageFrom(sysname, "Now displaying your name!");
                }
            }
        }
    }
}

function On_PlayerConnected(Player)
{
    var bannedreason = Data.GetConfigValue("BannedPeople", "Main", "BannedDrop");
    var sysname = Data.GetConfigValue("BannedPeople", "Main", "Name");
    var ini = BannedPeopleIni();
	var ip = Player.IP;
	var id = Player.SteamID;
    if (ini.GetSetting("Ips", ip) == "1") {
		Player.MessageFrom(sysname, bannedreason);
		Player.Disconnect();
    }
    if (ini.GetSetting("Ids", id) == "1") {
        Player.MessageFrom(sysname, bannedreason);
        Player.Disconnect();
    }
}

function isMod(id) {
	if (DataStore.ContainsKey("Moderators", id)) return true;
	return false;
}

function BannedPeopleIni() {
    if(!Plugin.IniExists("BannedPeople")){
        var ini = Plugin.CreateIni("BannedPeople");
        ini.Save();
    }
    return Plugin.GetIni("BannedPeople");
}

function Moderators() {
    if(!Plugin.IniExists("Moderators")){
        var ini = Plugin.CreateIni("Moderators");
        ini.Save();
    }
    return Plugin.GetIni("Moderators");
}

function GetPlayerName(name) {
	try {
		name = Data.ToLower(name);
		for(pl in Server.Players){
			if(Data.ToLower(pl.Name) == name){
				return pl;
			}
		}
		return null;
	} catch(err) {
		Plugin.Log("BannedPeopleError", "Error caught at getPlayer method. Player was null.");
		return null;
	}
}

/**
 * Method provided by Spoock
 */
function CheckV(Player, args) {
	
		var target;
		var systemname = Data.GetConfigValue("BannedPeople", "Main", "Name");
		var Nickname = "";
		for(var i=0; i < args.Length; i++)
		Nickname += args[i] + " ";
		Nickname = Data.Substring(Nickname, 0, Data.StrLen(Nickname) - 1)
		target = GetPlayerName(Nickname);
		if (target != null) {
			return (target);
		} 
		else {
			var cc = 0;
			for (var all in Server.Players) {
				var name = all.Name.ToLower();
				var check = args[0].ToLower();
				if (name.Contains(check)) {
					var found = all.Name;
					cc++;
				}
			}	
			if (cc == 1) {
				target = GetPlayerName(found);
				return (target);
			} else if (cc > 1) {
				Player.MessageFrom(systemname, "Found [color#FF0000]" + cc + " players[/color] with similar names. [color#FF0000]Use more correct name !");
				return null;
			} else if (cc == 0) {
				Player.MessageFrom(systemname, "Player [color#00FF00]" + Nickname + "[/color] not found");
				return null;
			}
		}
	
}

function argsToText(args) {
  var text = "";
  if (args.Length == 1) {
	text = args[0];
  } else {
	for (var l = 0; l < args.Length; l++) {
		if (l == args.Length - 1) {
			text += args[l];
		} else {
			text += args[l] + " ";
		}
	}
  }
  return text;
}

/**
 * @return {null}
 */
function GetPlayerUnBannedID(name){
    var ini = BannedPeopleIni();
    name = Data.ToLower(name);
    var checkdist = ini.EnumSection("NameIds");
    for(pl in checkdist){
        var nameid = ini.GetSetting("NameIds", pl);
        var lower = Data.ToLower(pl);
        if (nameid != null && lower == name) {
            return pl;
        }
    }
    return null;
}

function GetPlayerUnBannedIP(name){
	var ini = BannedPeopleIni();
	name = Data.ToLower(name);
	var checkdist = ini.EnumSection("NameIps");
	for(pl in checkdist){
		var nameid = ini.GetSetting("NameIps", pl);
		var lower = Data.ToLower(pl);
		if (nameid != null && lower == name) {
			return pl;
		}
	}
	return null;
 }