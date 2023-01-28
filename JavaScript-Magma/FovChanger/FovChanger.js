function On_PlayerConnected(Player) {
Player.SendCommand("render.fov 85");
}

function On_Command(Player, cmd, args)
{
	if(cmd == "fov")
	{
		{
			switch(args[0])
			{
			case "basis":
				Player.SendCommand("render.fov 65");
				Player.MessageFrom("FOV Changer", "Your FOV is changed. (65)");	
			}
			switch(args[0])
			{
			case "normal":
				Player.SendCommand("render.fov 75");
				Player.MessageFrom("FOV Changer", "Your FOV is changed. (75)");
			}
			switch(args[0])
			{
			case "high":
				Player.SendCommand("render.fov 85");
				Player.MessageFrom("FOV Changer", "Your FOV is changed. (85)");					
			}	
		}		
	}				
}	

