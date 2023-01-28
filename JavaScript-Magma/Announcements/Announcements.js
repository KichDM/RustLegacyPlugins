function On_ServerInit(Player, cmd, args) {
	StartTimer();
}

function StartTimer() {
	Plugin.CreateTimer("ServerTips",requestConfig("Message_Timer") * 1000).Start();
}

function On_Command(Player, cmd, args) {
	if(cmd == "servertips") {
		if(!Plugin.GetTimer("ServerTips")) {
			if(Player.Admin) {
				Server.Broadcast("Server tips manually activated by " + Player.Name + " every " + requestConfig("Message_Timer") + " seconds.");
				Plugin.CreateTimer("ServerTips",requestConfig("Message_Timer") * 1000).Start();
				break;
			} else {
				return Player.Message("You can't use this command.");
			}
		}
		return Player.Message("The announcements are already running.");
	}
}

function ServerTipsCallback() {
	var TimeNumber = randomIntFromInterval(1,10);
	
	switch(TimeNumber) {
		case "1":
		Server.Broadcast("=============================================");
		Server.Broadcast("Канал на ютубе: YouTube.com/user/serverman4ik");
		return Server.Broadcast("=============================================");
		case "2":
		Server.Broadcast("=============================================");
	    Server.Broadcast("По поводу админки обращаться в группу сервера");
		Server.Broadcast("vk.com/rustmagma");
		return Server.Broadcast("=============================================");
		case "3":
		Server.Broadcast("=============================================");
		Server.Broadcast("Чтобы узнать свою статистику");
		Server.Broadcast("введите в чат /stats");
		return Server.Broadcast("=============================================");
		case "4":
		Server.Broadcast("=============================================");
	    Server.Broadcast("Чтобы узнать статистику топ 10 игроков");
		Server.Broadcast("введите в чат /top10");
		return Server.Broadcast("=============================================");
		case "5":
		Server.Broadcast("=============================================");
		Server.Broadcast("Введите в чат /help");
		Server.Broadcast("Чтобы узнать список доступных комманд");
		return Server.Broadcast("=============================================");
		case "6":
		Server.Broadcast("=============================================");
		Server.Broadcast("Набор новичка");
		Server.Broadcast("комманда в чат /starter");
		return Server.Broadcast("=============================================");
		case "7":
		Server.Broadcast("=============================================");
		Server.Broadcast("На сервере читер?");
		Server.Broadcast("/votekick [ник игрока] - Начать голосование за кик");
		Server.Broadcast("/yes - Голосовать за.");
		Server.Broadcast("/no - Голосовать против.");
		return Server.Broadcast("=============================================");
		case "8":
		Server.Broadcast("=============================================");
		Server.Broadcast("Уменьшен урон взрывчатки C4");
		return Server.Broadcast("=============================================");
		case "9":
		Server.Broadcast("=============================================");
		Server.Broadcast("На сервере можно создат свой клан");
		Server.Broadcast("Подробности, комманда в чат /chelp");
		return Server.Broadcast("=============================================");
	}
}

function requestConfig(key) {
	return Data.GetConfigValue("Announcements", "Settings", key)
}

function randomIntFromInterval(min,max) {
    return Math.floor(Math.random()*(max-min+1)+min);
}