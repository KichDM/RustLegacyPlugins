function On_Command(Player, cmd, args) {
	switch(cmd) {		
		case "stats":
			Player.Message("STATS -EF");
			Player.Message("Health:" + Player.Health + "    IP: " + Player.IP );
			Player.Message("Name: " + Player.Name + "    Ping  " + Player.Ping + "   SteamID " + Player.SteamID )
			Player.Message("Current Position: X: " + Player.X + ", Y: " + Player.Y + ", Z: " + Player.Z)
			Player.Message("Time Online:" + Player.TimeOnline )
			break;
	}
}