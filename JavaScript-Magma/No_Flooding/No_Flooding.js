// The Author Demo
function On_Chat(Player, ChatMsg){
 	
 	var timeleft = getTimeRemaining(Player);

 	if (timeleft > 0)
 	{
 		ChatMsg.NewText = "";
    	Player.Message("You can't type in chat for another " + timeleft + " seconds!");
 	}
 	else
 	{
 		//Player.Message("timeleft: " + timeleft);
 		var time = System.Environment.TickCount/1000;
 		DataStore.Add("ChatCooldown", Player.SteamID+"chattime", time);
 		DataStore.Save();
 	}
    
		
}

function On_Command(Player, cmd, args)
{
	if (Player.Admin)
	{
		if (cmd == "chatcooldown")
		{
			Server.Broadcast("Chat Cooldown has been set to " + args[0] + " seconds!");
			DataStore.Add("ChatCooldown", "Cooldown", args[0]);
		}
	}
}

function getTimeRemaining(Player)
{
	var cooldown = parseInt(DataStore.Get("ChatCooldown", "Cooldown"));
	if (cooldown == undefined || isNaN(cooldown))
		cooldown = 0;

	var chattime = parseInt(DataStore.Get("ChatCooldown", Player.SteamID+"chattime"));
	if (chattime == undefined || isNaN(chattime))
		chattime = 0;

	var time = System.Environment.TickCount/1000;

	var timeleft = cooldown - (time - chattime);

	return timeleft = Math.round(timeleft);
}