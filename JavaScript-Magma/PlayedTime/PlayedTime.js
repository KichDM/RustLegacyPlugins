
function iniset() {
    return Plugin.GetIni("Database");
}

function On_PluginInit() {

    if (!Plugin.IniExists("Database")) {
        var inifile = Plugin.CreateIni("Database");
        inifile.AddSetting("PlayedTime", "76561198014834325", "0");
        inifile.Save();
}
}

function On_PlayerConnected(Player) {
	var getinifile = iniset();
	if (!getinifile.GetSetting("PlayedTime", Player.SteamID))
	{
		getinifile.AddSetting("PlayedTime", Player.SteamID, 0);
		getinifile.Save();
	}
}

function On_PlayerDisconnected(Player) {
	var getinifile = iniset();
	var stored = getinifile.GetSetting("PlayedTime", Player.SteamID);
	var online = Player.TimeOnline;
	var sum = parseInt(stored) + parseInt(online);
	getinifile.AddSetting("PlayedTime", Player.SteamID, sum);
    getinifile.Save();

}


function On_Command(Player, cmd, args) {
	if (cmd == "playedtime" || cmd == "pt")
	{	
		if (args.Length == 0) {
			var getinifile = iniset();
			var online = Player.TimeOnline;
			var stored = getinifile.GetSetting("PlayedTime", Player.SteamID);
			var sum = parseInt(online) + parseInt(stored);

			/* Displaying By Hours,Minutes and Seconds*/
			var displaysec = ((sum / 1000) % 60).toFixed();
			var displaymin = ((sum / 60000) % 60).toFixed();
			var displayhour = (sum / 3600000).toFixed();


			Player.MessageFrom("[Played Time]", "======================================");
			Player.MessageFrom("[Played Time]", "You spent on server " + displayhour + " hours, " + displaymin + " minutes and " + displaysec + "seconds");
			Player.MessageFrom("[Played Time]", "======================================");
		}
	}
}
