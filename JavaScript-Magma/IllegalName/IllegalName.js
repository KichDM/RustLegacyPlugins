//Fougerite
/**
 * Created by DreTaX on 2014.03.08.. V1.4.1
 * 
 */
function On_PlayerConnected(Player)
{
	RunCheck(Player);
}

function RunCheck(Player) {
	var name = Player.Name;
	var n = name.length;
	var ini = getIllegal();
	var config = IllegalNameConfig();
	/*var f = parseInt(Data.GetConfigValue("IllegalName", "options", "protection1"));
	var fougerite = Data.GetConfigValue("IllegalName", "options", "FougeriteSupport");
	var reason = Data.GetConfigValue("IllegalName", "options", "DisconnectReason");
	var reason2 = Data.GetConfigValue("IllegalName", "options", "DisconnectReason2");
	var space = Data.GetConfigValue("IllegalName", "options", "Spaces");*/
	var f = parseInt(config.GetSetting("options", "protection1"));
	var fougerite = config.GetSetting("options", "FougeriteSupport");
	var reason = config.GetSetting("options", "DisconnectReason");
	var reason2 = config.GetSetting("options", "DisconnectReason2");
	var space = config.GetSetting("options", "Spaces");
	var listnames = ini.EnumSection("IllegalNames");
    var counted = listnames.Length;
    var i = 0;
	if (counted > 0) {
        for (var checkn in listnames) {
			var get = ini.GetSetting("IllegalNames", checkn);
			i++;
			var lowername = Data.ToLower(name);
			var lowercheck = Data.ToLower(get);
			if (counted >= i) {
				if (fougerite == 1) {
					var contains = Util.ContainsString(lowername, lowercheck);
					//lowername.indexOf(lowercheck) !=-1
					if (contains) {
						Player.Message(reason);
						Player.Disconnect();
						return;
					}
				}
				if (lowername == lowercheck) {
					Player.Message(reason);
					Player.Disconnect();
					return;
				}
			}
		}
	}
	if (f == 1) {
		if (space == 0) {
			if (!name.match(/^[a-zA-Z0-9!@#\$%\^\&*\[\]\)\<\>\(+=._-]+$/g)) {
				Player.Message(reason2);
				Player.Message("Allowed Chars: a-z,0-9,!@#$%/\[]<>+=.-");
				Player.Message("Spaces are not allowed");
				Player.Disconnect();
			}
		} else {
			if (!name.match(/^[a-zA-Z0-9!@#\$%\^\&*\[\]\)\ \<\>\(+=._-]+$/g) || n <= 1) {
				Player.Message(reason2);
				Player.Message("Allowed Chars: a-z,0-9,!@#$%/\[]<>+=.-");
				Player.Disconnect();
			}
		}
    }
	else if (f == 2) {
		if (n <= 1) {
			Player.Message(reason2);
			Player.Message("Allowed Chars: a-z,0-9,!@#$%/\[]<>+=.-");
			Player.Disconnect();
		}
    }
	else if (f == 3) {
		if (space == 0) {
			if (!name.match(/^[a-zA-Z0-9!@#\$%\^\&*\[\]\)\<\>\(+=._-]+$/g) || n <= 1) {
				Player.Message(reason2);
				Player.Message("Allowed Chars: a-z,0-9,!@#$%/\[]<>+=.-");
				Player.Message("Spaces are not allowed");
				Player.Disconnect();
			}
		} else {
			if (!name.match(/^[a-zA-Z0-9!@#\$%\^\&*\[\]\)\ \<\>\(+=._-]+$/g) || n <= 1) {
				Player.Message(reason2);
				Player.Message("Allowed Chars: a-z,0-9,!@#$%/\[]<>+=.-");
				Player.Disconnect();
			}
		}
    }
}

function getIllegal(){
    if(!Plugin.IniExists("IllegalNames")) {
        var IllegalNames = Plugin.CreateIni("IllegalNames");
		IllegalNames.AddSetting("IllegalNames", "Name1", "Suck");
		IllegalNames.AddSetting("IllegalNames", "Name2", "Fuck");
		IllegalNames.AddSetting("IllegalNames", "Name3", "SHITSERVER");
        IllegalNames.Save();
    }
    return Plugin.GetIni("IllegalNames");
}

function IllegalNameConfig(){
    if(!Plugin.IniExists("IllegalNameConfig")) {
        var loc = Plugin.CreateIni("IllegalNameConfig");
        loc.Save();
    }
    return Plugin.GetIni("IllegalNameConfig");
}