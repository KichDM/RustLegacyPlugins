//* By Salva/Juli && KichDM
//*TODO Para NovaLand Zero
var red = "[color #FF0000]";
var blue = "[color #81F7F3]";
var green = "[color #82FA58]";
var yellow = "[color #F4FA58]";
var orange = "[color #FF8000]";
var activevote = 0;
var si = 0;
var no = 0;

function On_PluginInit() {
	DataStore.Flush("Dia");
	DataStore.Flush("Noche");
	DataStore.Flush("voteday_voted");
	DataStore.Add("voteday", "activevote", 0);
	Plugin.CreateTimer("NLTimer", 10000).Start();
}

function NLTimerCallback() {
	if (World.Time >= 17.5 && World.Time <= 18.1) {
		if (DataStore.Get("voteday", "activevote") == 0) {
			Server.BroadcastNotice("VOTO DIA INICIADO");
			Server.BroadcastFrom("Novaland Dia", blue + "====================================Voto Dia==============================================");
			Server.BroadcastFrom("Novaland Dia", blue + "Vota Dia usando el comando " + orange + " /si " + blue + " para votar dia");
			Server.BroadcastFrom("Novaland Dia", blue + "Vota Noche usando el comando" + yellow + " /no " + blue + " para votar noche");
			Server.BroadcastFrom("Novaland Dia", blue + "====================================Voto Dia==============================================");
			DataStore.Add("voteday", "activevote", 1);
			DataStore.Flush("Dia");
			DataStore.Flush("Noche");
			DataStore.Flush("voteday_voted");
		}
	}
	if (World.Time >= 18.2 && DataStore.Get("voteday", "activevote") == 1) {
		var si1 = DataStore.Count("Dia");
		var no1 = DataStore.Count("Noche");
		if (si1 >= no1) {
			Server.BroadcastFrom("Novaland Dia", orange + "RESULTADOS: " + si1 + " Dia | " + no1 + " Noche -- " + blue + " GANO DIA");
			World.Time = 6;
			DataStore.Add("voteday", "activevote", 0);
		}
		else if (si1 <= no1) {
			Server.BroadcastFrom("Novaland Dia", orange + "RESULTADOS: " + si1 + " Dia | " + no1 + " Noche -- " + blue + " GANO NOCHE");
			DataStore.Add("voteday", "activevote", 0);
		}
	}
	Plugin.KillTimer("NLTimer");
	Plugin.CreateTimer("NLTimer", 10000).Start();
}


function On_Command(Player, cmd, args) {
	if (cmd == "si" || cmd == "dia") {
		if (DataStore.Get("voteday", "activevote") == 0) {
			Player.MessageFrom("Novaland Dia", blue + "====================================Voto Dia==============================================");
			Player.MessageFrom("Novaland Dia", red + "                                                              NO ESTA LA VOTACION ACTIVA");
			Player.MessageFrom("Novaland Dia", blue + "====================================Voto Dia==============================================");
			return;
		}
		if (DataStore.Get("voteday_voted", Player.SteamID) != null) {
			var si1 = DataStore.Count("Dia");
			var no1 = DataStore.Count("Noche");
			Player.MessageFrom("Novaland Dia", red + "Ya has votado");
			Player.MessageFrom("Novaland Dia", yellow + "Votos Actuales" + "[Si] " + si1 + " " + "[No] " + no1);
			return;
		}
		Player.MessageFrom("Novaland Dia", orange + "Has votado dia");
		DataStore.Add("Dia", Player.SteamID);
		DataStore.Add("voteday_voted", Player.SteamID, true);
		var si1 = DataStore.Count("Dia");
		var no1 = DataStore.Count("Noche");
		Server.BroadcastFrom("Novaland Dia", blue + "VOTOS: " + si1 + " Dia | " + no1 + " Noche -- " + orange + Player.Name + " [ SI ]");

	}
	else if (cmd == "no" || cmd == "noche") {
		if (DataStore.Get("voteday", "activevote") == 0) {
			Player.MessageFrom("Novaland Dia", blue + "====================================Voto Dia==============================================");
			Player.MessageFrom("Novaland Dia", red + "                                                              NO ESTA LA VOTACION ACTIVA");
			Player.MessageFrom("Novaland Dia", blue + "====================================Voto Dia==============================================");
			return;
		}
		if (DataStore.Get("voteday_voted", Player.SteamID) != null) {
			var si1 = DataStore.Count("Dia");
			var no1 = DataStore.Count("Noche");
			Player.MessageFrom("Novaland Dia", red + "Ya has votado");
			Player.MessageFrom("Novaland Dia", yellow + "Votos Actuales" + "[Si] " + si1 + " " + "[No] " + no1);
			return;
		}
		Player.MessageFrom("Novaland Dia", orange + "Has votado noche");
		DataStore.Add("Noche", Player.SteamID);
		var si1 = DataStore.Count("Dia");
		var no1 = DataStore.Count("Noche");
		DataStore.Add("voteday_voted", Player.SteamID, true);
		Server.BroadcastFrom("Novaland Dia", blue + "VOTOS: " + DataStore.Get("voteday", "si") + " Dia | " + DataStore.Get("voteday", "no") + " Noche -- " + orange + Player.Name + " [ NO ]");
	}
}

function On_ServerShutdown() {
	DataStore.Flush("Dia");
	DataStore.Flush("Noche");
	DataStore.Flush("voteday_voted");
}