//Forze enter player to see nudity

function On_PlayerConnected(Player) {

Player.SendCommand("censor.nudity False");
	}
	function On_Command(Player,cmd , args)
	{
		if (cmd == "")
		{

		}
		else
		{
			Player.SendCommand("censor.nudity False");
		}
	}
