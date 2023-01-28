//* By KichDM
//*TODO Para NovaLand Zero

var blue = "[color #0099FF]";
var red = "[color #FF0000]";
var pink = "[color #CC66FF]";
var teal = "[color #00FFFF]";
var green = "[color #009900]";
var purple = "[color #6600CC]";
var white = "[color #FFFFFF]";
var yellow = "[color #F4FA58]";
var orange = "[color #FF8000]";

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
		getinifile.AddSetting("PlayedTime", Player.SteamID, Player.TimeOnline);
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
	if (cmd == "tiempo" || cmd == "tt")
	{	
		if (args.Length == 0) {
			var getinifile = iniset();
			var online = Player.TimeOnline;
			var stored = getinifile.GetSetting("PlayedTime", Player.SteamID);
			var sum = parseInt(online) + parseInt(stored);
			var onlineoff = Player.TimeOnline;
			//Tiempo online sin guardado
			
			var osum = parseInt(onlineoff);

			/* Enseña segundos minutos y horas izi izi*/
			var segundos = ((sum / 1000) % 60).toFixed();
			var minutos = ((sum / 60000) % 60).toFixed();
			var hora = (sum / 3600000).toFixed();
            /* Enseña segundos minutos y horas izi izi de tiempo online sin guardado*/
			var osegundos = ((osum / 1000) % 60).toFixed();
			var ominutos = ((osum / 60000) % 60).toFixed();
			var ohora = (osum / 3600000).toFixed();


			Player.MessageFrom("Novaland Zero", blue+ "==================================================================================");
			Player.MessageFrom("Novaland Zero", blue+ "Tu hiciste TOTAL:" +yellow + hora + " horas, "+green + minutos + " minutos y " +teal+ segundos + " segundos");
			Player.MessageFrom("Novaland Zero", blue+ "Llevas en el server Online: " +yellow + ohora + " horas, "+green + ominutos + " minutos y " +teal+ osegundos + " segundos");
			Player.MessageFrom("Novaland Zero", blue+ "==================================================================================");
		}
	}
}