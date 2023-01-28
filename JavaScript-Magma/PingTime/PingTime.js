 // Author: Ferum
 // Plugin: Ping, Time, Message...
 // Fougerite
 // Version: 2.0 Release
 
function On_Command(Player, cmd, args)
{
	if (cmd == "loc")
		if (Player.Admin == false)
			
		var gametime = World.Time;
		    var hour = Math.floor(gametime);
		    var tmp = gametime % 1;
			var min = Math.floor(tmp * 60);
			var tmp = gametime % 1;
			if (hour > 0)
			{	
			Player.Message("[color Green]Time : " + hour +" h "+ min +" m   Ping : " + Player.Ping);
            }
    
        {
            Player.Message("[color red]Your location: X: " + Player.X + ", Y: " + Player.Y + ", Z: " + Player.Z);
        }			
			
}		