function On_Command(Player, cmd, args) {
	switch(cmd) {
		/////Now/////
		case "now":
			var gametime = World.Time;
			var hour = Math.floor(gametime);
			var tmp = gametime % 1;
			var min = Math.floor(tmp * 60);
			var players = Server.Players;
			if (hour > 0) {			
			Player.Message("◆ Rust Time : " + hour +" h "+ min +" m  ◆ Ping : " + Player.Ping);			
			Player.Message("◆ Play Time : " + parseInt(Player.TimeOnline / 60000) + " min  ◆ Players : " + players.Count +" ♟");
			break;
			}
	}
}