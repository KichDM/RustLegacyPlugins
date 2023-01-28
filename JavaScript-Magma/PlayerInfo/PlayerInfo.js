function On_Command(Player, cmd, args) {
	if(cmd == "pinfo" && Player.Admin){
		var pl = Player.Find(args[0]);
		if(pl.Name == undefined){
			Player.Message("No such player");
		}
		else {
			Player.Message("==================Player Info==================");
			Player.Message("| SteamID: "+pl.SteamID+" | | IP: "+pl.IP+" |");
			if (pl.Admin){
				Player.Message(pl.Name+" is Admin.");
			}
			else {
				Player.Message(pl.Name+" isn't Admin.");
			}
			Player.Message(pl.Name+"'s health: "+pl.Health.toFixed(0));
			if (pl.IsBleeding == undefined || pl.IsBleeding == false){
				var IsBleeding = "";
			}
			else {
				var IsBleeding = " |Is Bleeding| ";
			}
			if (pl.IsCold == undefined || pl.IsCold == false){
				var IsCold = "";
			}
			else {
				var IsCold = " |Is Cold| ";
			}
			if (pl.IsInjured == undefined || pl.IsInjured == false){
				var IsInjured = "";
			}
			else {
				var IsInjured = " |Is Injured| ";
			}
			if (IsInjured != "" || IsCold != "" || IsBleeding != ""){
				Player.Message("Traumas: "+IsInjured+""+IsBleeding+""+IsCold);
			}
			else {
				Player.Message("Healthy boy =)");
			}
			Player.Message("Ping: "+pl.Ping);
			var SecondsOnline = ((pl.TimeOnline / 1000) % 60).toFixed();
			var MinutesOnline = ((pl.TimeOnline / 60000) % 60).toFixed();
			var HoursOnline = (pl.TimeOnline / 3600000).toFixed();
			Player.Message("Time online:   "+HoursOnline+" hours,  "+MinutesOnline+" minutes,  "+SecondsOnline+" seconds.");
			Player.Message("Location: | X: "+pl.X.toFixed(2)+" | | Y: "+pl.Y.toFixed(2)+" | | Z: "+pl.Z.toFixed(2)+" |");
			Player.Message("=============================================");			
		}
	}
}