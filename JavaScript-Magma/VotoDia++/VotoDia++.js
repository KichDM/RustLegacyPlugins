//* By Salva/Juli && KichDM
//*TODO Para NovaLand Zero
var red = "[color #FF0000]";
var  blue = "[color #81F7F3]";
var  green = "[color #82FA58]";
var  yellow = "[color #F4FA58]";
var  orange = "[color #FF8000]";
var activevote = 0;
var si = 0;
var no = 0;



function On_PluginInit() {

	//Data.AddTableValue("voteday", "activevote", activevote);
	//Data.AddTableValue("voteday", "si", 0);
	//Data.AddTableValue("voteday", "no", 0);
	Plugin.CreateTimer("NLTimer", 10000).Start();
}


function NLTimerCallback() {
	Plugin.CreateTimer("NLTimer", 10000).Start();

	if (World.Time >= 17.5 && World.Time <= 18.5) {
		if (Data.GetTableValue("voteday", "activevote") == 0) {
			Server.BroadcastNotice("VOTO DIA INICIADO");
			Server.BroadcastFrom("Novaland Dia", blue+ "====================================Voto Dia==============================================");
			Server.BroadcastFrom("Novaland Dia", blue + "Vota Dia usando el comando " + orange +" /si "+blue +" para votar dia");
			Server.BroadcastFrom("Novaland Dia", blue + "Vota Noche usando el comando" + yellow + " /no " +blue + " para votar noche");
			Server.BroadcastFrom("Novaland Dia", blue+ "====================================Voto Dia==============================================");
			Data.AddTableValue("voteday", "activevote", 1);
		}
	}
	if (World.Time >= 18.6 && Data.GetTableValue("voteday", "activevote") == 1) {
		Data.AddTableValue("voteday", "activevote", 0);
		ComprobarVotos();
	}
	
}


function ComprobarVotos()
{
	if (Data.GetTableValue("voteday", "si") >= Data.GetTableValue("voteday", "no")) {
		Server.BroadcastFrom("Novaland Dia", orange + "RESULTADOS: " + Data.GetTableValue("voteday", "si") + " Dia | " + Data.GetTableValue("voteday", "no") + " Noche -- " + blue + " GANO DIA");
		World.Time = 6;
		BorrarVariables();

	}
	else if (Data.GetTableValue("voteday", "si") <= Data.GetTableValue("voteday", "no")) {
		Server.BroadcastFrom("Novaland Dia", orange + "RESULTADOS: " + Data.GetTableValue("voteday", "si") + " Dia | " + Data.GetTableValue("voteday", "no") + " Noche -- " + blue + " GANO NOCHE");
		BorrarVariables();

	}
}


function BorrarVariables()
{
	Data.AddTableValue("voteday", "si", 0);
	Data.AddTableValue("voteday", "no", 0);
		for (var pl in Server.Players) {
			Data.AddTableValue("voteday_voted", pl.SteamID, null);
			break;
		}
}
function On_Command(Player, cmd, args) {
	if (cmd == "si" || cmd == "dia") {
		if (Data.GetTableValue("voteday", "activevote") == 0) {
			Player.MessageFrom("Novaland Dia", blue+ "====================================Voto Dia==============================================");
			Player.MessageFrom("Novaland Dia", red + "                                                              NO ESTA LA VOTACION ACTIVA");
			Player.MessageFrom("Novaland Dia", blue+ "====================================Voto Dia==============================================");
			return;
		}

		if (Data.GetTableValue("voteday_voted", Player.SteamID) != null) {
			Player.MessageFrom("Novaland Dia", red + "Tu yas has votado");
			return;
		}

		Player.MessageFrom("Novaland Dia", orange + "Has votado dia");
		var si = Data.GetTableValue("voteday", "si") + 1;
		Data.AddTableValue("voteday", "si", si);
		Data.AddTableValue("voteday_voted", Player.SteamID, true);
		Server.BroadcastFrom("Novaland Dia", blue + "VOTOS: " + Data.GetTableValue("voteday", "si") + " Dia | " + Data.GetTableValue("voteday", "no") + " Noche -- " + orange + Player.Name + " [ SI ]");
	}

	else if (cmd == "no" || cmd == "noche") {
		if (Data.GetTableValue("voteday", "activevote") == 0) {
			Player.MessageFrom("Novaland Dia", blue+ "====================================Voto Dia==============================================");
			Player.MessageFrom("Novaland Dia", red + "                                                              NO ESTA LA VOTACION ACTIVA");
			Player.MessageFrom("Novaland Dia", blue+ "====================================Voto Dia==============================================");
			return;
		}

		if (Data.GetTableValue("voteday_voted", Player.SteamID) != null) {
			Player.MessageFrom("Novaland Dia", red + "Ya has votado");
			return;
		}

		Player.MessageFrom("Novaland Dia", orange + "Has votado noche");
		var no = Data.GetTableValue("voteday", "no") + 1;
		Data.AddTableValue("voteday", "no", no);
		Data.AddTableValue("voteday_voted", Player.SteamID, true);
		Server.BroadcastFrom("Novaland Dia", blue + "VOTOS: " + Data.GetTableValue("voteday", "si") + " Dia | " + Data.GetTableValue("voteday", "no") + " Noche -- " + orange + Player.Name + " [ NO ]");
	}
}


function On_ServerShutdown ()
{
	Data.AddTableValue("voteday", "si", 0);
	Data.AddTableValue("voteday", "no", 0);
	for (var pl in Server.Players) {
		Data.AddTableValue("voteday_voted", pl.SteamID, null);
		break;
	}
}