function On_Command(Player, cmd, args)
{
	if(cmd == "fov")
	{
		{
			switch(args[0])
			{
			case "50":
				Player.SendCommand("render.fov 50");
				Player.MessageFrom("Novaland Fov", "Tu FOV fue aplicado. (50)");	
			}
			switch(args[0])
			{
			case "60":
				Player.SendCommand("render.fov 60");
				Player.MessageFrom("Novaland Fov", "Tu FOV fue aplicado. (60)");
			}
			switch(args[0])
			{
			case "70":
				Player.SendCommand("render.fov 70");
				Player.MessageFrom("Novaland Fov", "Tu FOV fue aplicado. (70)");					
			}
			switch(args[0])
			{
			case "80":
				Player.SendCommand("render.fov 80");
				Player.MessageFrom("Novaland Fov", "Tu FOV fue aplicado. (80)");
			}
			switch(args[0])
			{
			case "90":
				Player.SendCommand("render.fov 90");
				Player.MessageFrom("Novaland Fov", "Tu FOV fue aplicado. (90)");
			}
			switch(args[0])
			{
			case "100":
				Player.SendCommand("render.fov 100");
				Player.MessageFrom("Novaland Fov", "Tu FOV fue aplicado. (100)");
			}
			switch(args[0])
			{
			case "110":
				Player.SendCommand("render.fov 110");
				Player.MessageFrom("Novaland Fov", "Tu FOV fue aplicado. (110)");
			}
			switch(args[0])
			{
			case "120":
				Player.SendCommand("render.fov 120");
				Player.MessageFrom("Novaland Fov", "Tu FOV fue aplicado. (120)");
			}	
		}		
	}				
}	

