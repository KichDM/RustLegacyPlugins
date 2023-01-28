// Version 0.9
// Created by Reaper

function requestConfig()
{
	Data.AddTableValue("airdrop_time", "MINPLAYER", Data.GetConfigValue("Airdrops", "Settings", "airdropMinPlayer"));
	Data.AddTableValue("airdrop_time", "TIMEBETWEENAD", Data.GetConfigValue("Airdrops", "Settings", "timeBetweenAirdrop"));
	Data.AddTableValue("airdrop_time", "ADDURINGNIGHT", Data.GetConfigValue("Airdrops", "Settings", "airdropDuringNight"));
	Data.AddTableValue("airdrop_time", "NBAD", Data.GetConfigValue("Airdrops", "Settings", "nbAirdrop"));
	Data.AddTableValue("airdrop_time", "TIMELEFTAONLY", Data.GetConfigValue("Airdrops", "Settings", "timeleftAdminOnly"));
}

function setLastTime()
{
	var h = System.DateTime.Now.ToString("HH") * 60;
	var m = System.DateTime.Now.ToString("mm");
	var time = Data.ToInt(h) + Data.ToInt(m);
	
	Data.AddTableValue("airdrop_time", "LASTTIME", time);
}

function On_PlayerConnected(Player)
{
	if (Data.GetTableValue("airdrop_time", "MINPLAYER") == false || Data.GetTableValue("airdrop_time", "TIMEBETWEENAD") == false || Data.GetTableValue("airdrop_time", "ADDURINGNIGHT") == false ||
			Data.GetTableValue("airdrop_time", "NBAD") == false || Data.GetTableValue("airdrop_time", "TIMELEFTAONLY") == false)
	{
		requestConfig();
	}
	
	var minPlayer = Data.ToInt(Data.GetTableValue("airdrop_time", "MINPLAYER"));
	var playerCount = Data.ToInt(Server.Players.Count);
	
	if (!Plugin.GetTimer("timedAirdropTimer") && playerCount > 0)
	{
		requestConfig();
	
		Plugin.CreateTimer("timedAirdropTimer",Data.GetTableValue("airdrop_time", "TIMEBETWEENAD")).Start();
	
		setLastTime();
	}
	
	if (playerCount == minPlayer)
	{
		Server.Broadcast( "Минимальное кол-во игроков " + minPlayer + " уже в игре, Airdrop будет каждые " + (Data.GetTableValue("airdrop_time", "TIMEBETWEENAD") / 60000) + " минут.");
	}
	else if (playerCount > minPlayer)
	{
		Player.Message( "Сейчас " + playerCount + " игроков онлайн. Airdrop активен и падает каждые " + (Data.GetTableValue("airdrop_time", "TIMEBETWEENAD") / 60000) + " минут.");
	}
	else
	{
		Player.Message("Airdrop не активен, игроков меньше чем " + minPlayer);
	}
}

function On_PlayerDisconnected(Player)
{
	var minPlayer = Data.ToInt(Data.GetTableValue("airdrop_time", "MINPLAYER"));
	
	if (Data.ToInt(Server.Players.Count) < minPlayer)
	{
		Plugin.KillTimer("delayedAirdropTimer");
		Server.Broadcast("Кол-во игроков меньше " + minPlayer + " и airdrop не будет выпадать.");
	}
}

function timedAirdropTimerCallback()
{
	Plugin.KillTimer("timedAirdropTimer");
	Plugin.CreateTimer("timedAirdropTimer",Data.GetTableValue("airdrop_time", "TIMEBETWEENAD")).Start();
	
	setLastTime();
	
	if (Data.ToInt(Server.Players.Count) >= Data.ToInt(Data.GetTableValue("airdrop_time", "MINPLAYER")) && !Plugin.GetTimer("delayedAirdropTimer"))
	{
		if (Data.GetTableValue("airdrop_time", "ADDURINGNIGHT") == "true" || (World.Time < 16.5 && World.Time > 5.5))
		{
			World.Airdrop(Data.GetTableValue("airdrop_time", "NBAD"));
			Server.Broadcast("Airdrop уже скоро!");
		}
		else
		{
			Plugin.CreateTimer("delayedAirdropTimer",120000).Start();
		}
	}
}

function delayedAirdropTimerCallback()
{
	var minPlayer = Data.ToInt(Data.GetTableValue("airdrop_time", "MINPLAYER"));

	if (Data.ToInt(Server.Players.Count) >= minPlayer)
	{
		if (World.Time < 16.5 && World.Time > 5.5)
		{
			Plugin.KillTimer("delayedAirdropTimer");
			World.Airdrop(Data.GetTableValue("airdrop_time", "NBAD"));
			Server.Broadcast("Airdrop уже скоро!");
		}
	}
	else
	{
		Plugin.KillTimer("delayedAirdropTimer");
		Server.Broadcast("Кол-во игроков меньше " + minPlayer + " и airdrop не будет выпадать.");
	}
}

function On_Command(Player, cmd, args) 
{
	if(cmd == "airdroptimeleft")
    {		
		if (Data.GetTableValue("airdrop_time", "TIMELEFTAONLY") != "true" || Player.Admin == true)
		{
			if (Plugin.GetTimer("delayedAirdropTimer"))
			{
				Player.Message("Airdrop готов, но пилот ждет наступления дня.");
			}
			else
			{
				var h = System.DateTime.Now.ToString("HH") * 60;
				var m = System.DateTime.Now.ToString("mm");
				var time = Data.ToInt(h) + Data.ToInt(m);
				
				var v = time - Data.GetTableValue("airdrop_time", "LASTTIME");
				var v = (Data.GetTableValue("airdrop_time", "TIMEBETWEENAD") / 60000) - v;
				
				if (v < 0)
				{
					v = v + (60 * 24);
				}
				
				Player.Message( "Осталось " + v + " до следующего airdrop, если игроков больше чем " + Data.GetTableValue("airdrop_time", "MINPLAYER"));
			}
		}
		else
		{
			Player.Message("У вас нет доступа к этой команде.");
		}
	}
	
    if(cmd == "airdrop")
    {
		if(Player.Admin == true)
		{
			if(args[0])
			{
				if(args[0] > 0 && args[0] <= 5)
				{
					World.Airdrop(args[0]);
					Player.Message("Airdrop создан " + args[0] + "x.");
				}
				else
				{
					Player.Message("Используй: /airdrop, и число от 1 до 5");
					Player.Message("Например: /airdrop 3");
				}
			}
		}
		else
		{
			Player.Message("У вас нет доступа к этой команде.");
		}
    }
}