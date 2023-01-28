/*
--------------Battle Royale--------------
---------Rust Mod made with Magma---------
------------Written by Fraccas-----------

--------------
To-Do Phase 1
--------------
When game is preparing, spawn players around middle (COMPLETE)
Game Preparation - 3 minutes or max players from cfg (COMPLETE)
----If max players not reached, restart timer (COMPLETE)
Jail players before match starts (COMPLETE)
Drop bags with items in the middle of the group, then begin match (COMPLETE)
Match will last 30 minutes, or last man standing (COMPLETE)
Make a radius, if player goes outside of radius they are punished (COMPLETE)


--------------
To-Do Phase 2
--------------
Fix loot spawn bug (COMPLETE)
Rewrite radius system/Provide indicator when outside the radius
Push players back from the start
Add rare guns to all town loot spawns (COMPLETE)
Add Arena feature to aid wait times
Add VIP system
Create encrypted code with KEY


*/

function On_ServerInit()
{
	requestConfig();
	getBRwins();
	//Starts preparation stage timer
	startBattleRoyalePrepare();
}

function BattleRoyaleLobbyClosedCallback()
{
	startBattleRoyaleLobbyClosed();
}

function BattleRoyalePrepareCallback()
{
	// After preparation time ends, start game if more than 1 player is on
	//DataStore.Flush("Jail");
	//DataStore.Flush("BattleRoyale");
	var count = 0
	for (var pl in Server.Players)
	{
		var alive = DataStore.Get("BattleRoyale", pl.SteamID+"alive");
		if (alive)
			count++;
	}
		
	var minPlayers = Data.GetTableValue("BattleRoyale", "MinPlayers");
	if (count >= minPlayers)
		startBattleRoyale();
	else 
	{
		DataStore.Add("BattleRoyale", "LobbyClosed", false);
		Server.BroadcastNotice("Not enough players online! Starting Preparation Time!");
		Server.Broadcast("[color#00FF00]Not enough players online! Starting Preparation Time![/color]");
		Server.Broadcast("[color#00FF00]Lobby has been reopened! You have now been added to the queue![/color]");
		startBattleRoyalePrepare();
	}
}

function BattleRoyaleCallback()
{
	// After game ends, start preparation time
	startBattleRoyalePrepare();
}

function FreezePlayerCallback()
{
	for (var pl in Server.Players)
	{
		freezePlayer(pl);
	}
}

function CheckDistanceCallback()
{
	checkDistance();
}

function requestConfig()
{
	Data.AddTableValue("BattleRoyale", "MinPlayers", Data.GetConfigValue("BattleRoyale", "Settings", "MinPlayers"));
	Data.AddTableValue("BattleRoyale", "StartPositionX", Data.GetConfigValue("BattleRoyale", "Settings", "StartPositionX"));
	Data.AddTableValue("BattleRoyale", "StartPositionY", Data.GetConfigValue("BattleRoyale", "Settings", "StartPositionY"));
	Data.AddTableValue("BattleRoyale", "StartPositionZ", Data.GetConfigValue("BattleRoyale", "Settings", "StartPositionZ"));
}

//Grab the correct ini file
function getBRini()
{
	if(!Plugin.IniExists("BattleRoyale"))
	{
		Plugin.CreateIni("BattleRoyale");
	}
		
	return Plugin.GetIni("BattleRoyale");
}

// If preparation time, spawn/freeze player at spawn poFloat. Otherwise tp to jail.
function On_PlayerSpawned(Player)
{
	Player.Inventory.ClearAll();
	var random = Math.floor((Math.random() * 360) + 1);
	DataStore.Add("BattleRoyale", Player.SteamID+"random", random);

	var game = DataStore.Get("BattleRoyale", "Game");
	var lobbyClosed = DataStore.Get("BattleRoyale", "LobbyClosed");
	if (lobbyClosed == null || lobbyClosed == undefined)
		lobbyClosed = false;
    if(game || lobbyClosed)
    {
    	Player.Message("[color#FFFF00]You have joined the server while a game is in progess or during a closed lobby![/color]");
    	var minPlayers = Data.GetTableValue("BattleRoyale", "MinPlayers");
    	Player.Message("[color#FFFF00]/PlayerCount to see how many players are left! If players are less than " 
    		+ minPlayers +  " then lobby will restart soon![/color]");
    	DataStore.Add("BattleRoyale", Player.SteamID+"alive", false);
    	try
    	{
    		sendToJail(Player, "300000");
    	}
    	catch(err)
    	{
    		//Server.Broadcast("JAIL ERROR: " + err);
    	}
    }
    else
    {
    	Player.Message("[color#FFFF00]Welcome to the Battle Royale Mod developed by Fraccas![/color]");
    	Player.Message("[color#FFFF00]The match will begin shortly![/color]");
    	DataStore.Add("BattleRoyale", Player.SteamID+"alive", true);
    	var player_count = DataStore.Get("BattleRoyale", "PlayerCount");
		//player_count++;
		//DataStore.Add("BattleRoyale", player_count);
    	//freePlayer(Player);
    	//sendToStart(Player);
    	sendToJail(Player, "300000");
    }
    Player.Message("[color#00FF00]YOU WILL BE HELD WITHIN THE JAIL UNTIL THE GAME STARTS![/color]");
	Server.Message("[color#00FF00]IF YOU CAN'T SEE OTHER PLAYERS RELAUNCH YOUR GAME![/color]");
	Server.Message("[color#00FF00]PLEASE REPORT ALL BUGS. ADD ME ON STEAM: FRACCAS[/color]");

    Player.Health = 99;
    Player.UpdateHealth();

    var count = 0;
    for (var pl in Server.Players)
    {
    	count++;
    }

    if (count == 1)
    	Plugin.CreateTimer("BattleRoyalePrepare", time).Start();

    var alive = DataStore.Get("BattleRoyale", Player.SteamID+"alive")
    if (alive == false)
    	sendToJail(Player, "300000");

}

function On_PlayerDisconnected(Player)
{
	var player_alive = DataStore.Get("BattleRoyale", Player.SteamID+"alive");
	var game = DataStore.Get("BattleRoyale", "Game");
	Server.Broadcast(Player.Name + " has left the server! Alive: " + player_alive);
	if (player_alive)
	{			
		var player_count = DataStore.Get("BattleRoyale", "PlayerCount");
		player_count--;
		Server.BroadcastNotice(Player.Name + " has left the server! (" + player_count + " players remaining!)");
		DataStore.Add("BattleRoyale", "PlayerCount", player_count);
		DataStore.Add("BattleRoyale", Player.SteamID+"alive", false);
		var game = DataStore.Get("BattleRoyale", "Game");

		if (player_count < 2 && game)
		{
			// Find the last player marked as alive and declare him winner
			for (var pl in Server.Players)
			{
				var alive = DataStore.Get("BattleRoyale", pl.SteamID+"alive");
				var game = DataStore.Get("BattleRoyale", "Game");
				if (players_alive < 2 && game  && alive)
				{
					Server.BroadcastNotice(pl.Name + " has won the Battle Royale!!!");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#00FF00]--------------------------------------------------------------------------------------[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★Shutting down server in 60 seconds!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★Shutting down server in 60 seconds!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★Shutting down server in 60 seconds!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★Shutting down server in 60 seconds!★★★★★★★★★★[/color]");
					RustPP.TimedEvents.shutdown();
					World.AirdropAtPlayer(pl);
					World.AirdropAtPlayer(pl);
					World.AirdropAtPlayer(pl);
					World.AirdropAtPlayer(pl);
					World.AirdropAtPlayer(pl);
					
					try
					{
						var ini = getBRini();
						var wins = ini.GetSetting("BattleRoyale", pl.Name);
						if (wins == null || wins == undefined)
							wins = 0;
						wins++;
						ini.AddSetting("BattleRoyale", pl.Name, wins);
						Server.Broadcast("[color#00FF00]--------------------------------------------------------------------------------------[/color]");
						Server.Broadcast("[color#FFFF00]" + pl.Name + " has won ★★" + wins + "★★ BATTLE ROYALE matches![/color]");
						ini.Save();
					}
					catch(err)
					{
						Server.Broadcast("INI ERROR: " + err);
					}
					getBRwins();
					break;
					//pl.Inventory.ClearAll();
				}
			}
			startBattleRoyalePrepare();
		}
	}
	Player.Inventory.ClearAll();
}

function On_PlayerKilled(de)
{
	try
	{
		var loc = Util.CreateVector(5768, 416, -3420);
		World.Spawn(";explosive_charge", loc);
	}
	catch(err)
	{
		Server.Broadcast("DeathSound: " + err);
	}
	

	var player_count = DataStore.Get("BattleRoyale", "PlayerCount");
	player_count--;
	if (de.Attacker != de.Victim)
		Server.BroadcastNotice(de.Attacker.Name + " has eliminate " + de.Victim.Name + "! (" + player_count + " players remaining!)");

	DataStore.Add("BattleRoyale", de.Victim.SteamID+"alive", false);
	DataStore.Add("BattleRoyale", "PlayerCount", player_count);

	if (player_count < 2)
	{		
		//Server.Broadcast(Object.prototype.toString.call(de.Attacker));
		//Server.Broadcast(Object.prototype.toString.call(de.Victim));

		// If one of the two last players commits suicide ***********************************
		if (de.Attacker == de.Victim)
		{
			// Find the last player marked as alive and declare him winner
			for (var pl in Server.Players)
			{
				var game = DataStore.Get("BattleRoyale", "Game");
				var alive = DataStore.Get("BattleRoyale", pl.SteamID+"alive");
				if (player_count < 2 && game && alive)
				{
					Server.BroadcastNotice(pl.Name + " has won the Battle Royale!!!");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#00FF00]--------------------------------------------------------------------------------------[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★Shutting down server in 60 seconds!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★Shutting down server in 60 seconds!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★Shutting down server in 60 seconds!★★★★★★★★★★[/color]");
					Server.Broadcast("[color#FFFF00]★★★★★★★★★★Shutting down server in 60 seconds!★★★★★★★★★★[/color]");
					RustPP.TimedEvents.shutdown();
					World.AirdropAtPlayer(de.Attacker);
					World.AirdropAtPlayer(de.Attacker);
					World.AirdropAtPlayer(de.Attacker);
					World.AirdropAtPlayer(de.Attacker);
					World.AirdropAtPlayer(de.Attacker);
					World.AirdropAtPlayer(de.Attacker);
					World.AirdropAtPlayer(de.Attacker);
					pl.Inventory.ClearAll();
					sendToJail(pl);
					try
					{
						var ini = getBRini();
						var wins = ini.GetSetting("BattleRoyale", pl.Name);
						if (wins == null || wins == undefined)
							wins = 0;
						wins++;
						ini.AddSetting("BattleRoyale", pl.Name, wins);
						Server.Broadcast("[color#00FF00]--------------------------------------------------------------------------------------[/color]");
						Server.Broadcast("[color#FFFF00]" + pl.Name + " has won ★★" + wins + "★★ BATTLE ROYALE matches![/color]");
						ini.Save();
					}
					catch(err)
					{
						Server.Broadcast("INI ERROR: " + err);
					}
					getBRwins();
					break;
					
					
					/*
					startBattleRoyalePrepare();
					pl.Health = 99;
					pl.UpdateHealth();
					*/
				}
			}
			//de.Victim.Disconnect();
		}
		else
		{
			Server.BroadcastNotice(de.Attacker.Name + " has won the Battle Royale!!!");
			Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + de.Attacker.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
			Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + de.Attacker.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
			Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + de.Attacker.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
			Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + de.Attacker.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
			Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + de.Attacker.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
			Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + de.Attacker.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
			Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + de.Attacker.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
			Server.Broadcast("[color#00FF00]--------------------------------------------------------------------------------------[/color]");
			Server.Broadcast("[color#FFFF00]★★★★★★★★★★Shutting down server in 60 seconds!★★★★★★★★★★[/color]");
			Server.Broadcast("[color#FFFF00]★★★★★★★★★★Shutting down server in 60 seconds!★★★★★★★★★★[/color]");
			Server.Broadcast("[color#FFFF00]★★★★★★★★★★Shutting down server in 60 seconds!★★★★★★★★★★[/color]");
			Server.Broadcast("[color#FFFF00]★★★★★★★★★★Shutting down server in 60 seconds!★★★★★★★★★★[/color]");
			RustPP.TimedEvents.shutdown();
			World.AirdropAtPlayer(de.Attacker);
			World.AirdropAtPlayer(de.Attacker);
			World.AirdropAtPlayer(de.Attacker);
			World.AirdropAtPlayer(de.Attacker);
			World.AirdropAtPlayer(de.Attacker);
			World.AirdropAtPlayer(de.Attacker);
			World.AirdropAtPlayer(de.Attacker);
			de.Attacker.Inventory.ClearAll();
			try
			{
				sendToJail(de.Attacker);
				sendToJail(de.Victim);
				//Server.Broadcast("Starting to save INI");
			}
			catch(err)
			{
				//Server.Broadcast("Jailing Victim Error: " + err);
			}
			
			try
			{
				var ini = getBRini();
				var wins = ini.GetSetting("BattleRoyale", de.Attacker.Name);
				if (wins == null || wins == undefined)
					wins = 0;
				wins++;
				ini.AddSetting("BattleRoyale", de.Attacker.Name, wins);
				Server.Broadcast("[color#00FF00]--------------------------------------------------------------------------------------[/color]");
				Server.Broadcast("[color#FFFF00]" + de.Attacker.Name + " has won ★★" + wins + "★★ BATTLE ROYALE matches![/color]");
				ini.Save();
			}
			catch(err)
			{
				Server.Broadcast("INI ERROR: " + err);
			}
			getBRwins();
			break;
			
			/*
			
			startBattleRoyalePrepare();
			de.Attacker.Health = 99;
			de.Attacker.UpdateHealth();
			//de.Victim.Disconnect();
			*/
		}
		//startBattleRoyalePrepare();
		DataStore.Add("BattleRoyale", de.Attacker.SteamID+"alive", false);
	}
	//de.Victim.Disconnect();

}

// Prevent side chat during game. Allow during preparation.
function On_Chat(Player, ChatMsg)
{
	var game = DataStore.Get("BattleRoyale", "Game");
    if(game)
    {
        //ChatMsg.NewText = "";
		return;
    }
}

function On_Command(Player, cmd, args)
{
	switch (cmd)
	{
		case "startBattleRoyale":
			DataStore.Add("BattleRoyale", Player.SteamID+"alive", true);
			startBattleRoyale();
			break;
		case "startBattleRoyalePrepare":
			DataStore.Add("BattleRoyale", "LobbyClosed", false);
			Plugin.KillTimer("BattleRoyaleLobbyClosed");
			startBattleRoyalePrepare();
			break;
		case "reloadcfg":
			requestConfig();
			Player.Message("BattleRoyale.cfg has been reloaded!");
			break;
		case "getcfg":
			var x = Data.GetConfigValue("BattleRoyale", "Settings", "StartPositionX");
			var y = Data.GetConfigValue("BattleRoyale", "Settings", "StartPositionY");
			var z = Data.GetConfigValue("BattleRoyale", "Settings", "StartPositionZ");
			Player.Message("BattleRoyale.cfg - X:" + x + " Y:" + y + " Z:" + z);
			var time = parseInt(Data.GetConfigValue("BattleRoyale", "Settings", "PrepareTime"));
			Player.Message("BattleRoyale.cfg - PrepareTime: " + time);
			break;
		case "getGameState":
			var game = DataStore.Get("BattleRoyale", "Game");
			Player.Message("GameState: " + game);
			break;
		case "PlayerCount":
			var count = 0
			for (var pl in Server.Players)
			{
				var alive = DataStore.Get("BattleRoyale", pl.SteamID+"alive");
				if (alive)
					count++;
			}
			Player.Message(count);
			break;
		case "getLobbyState":
			var lobbyClosed = DataStore.Get("BattleRoyale", "LobbyClosed");
			if (lobbyClosed == null || lobbyClosed == undefined)
				lobbyClosed = false;
			Player.Message("LobbyClosedState: " + lobbyClosed);
			break;
		case "getAliveState":
			var alive = DataStore.Get("BattleRoyale", Player.SteamID+"alive");
			Player.Message("AliveState: " + alive);
			break;
		case "getBRwins":
			getBRwins();
			break;
	}
}

function sendToStart(Player)
{
	var StartPositionX = parseFloat(Data.GetTableValue("BattleRoyale", "StartPositionX"));
	var StartPositionY = parseFloat(Data.GetTableValue("BattleRoyale", "StartPositionY"));
	var StartPositionZ = parseFloat(Data.GetTableValue("BattleRoyale", "StartPositionZ"));

	var sx = StartPositionX;
	var sy = StartPositionY;
	var sz = StartPositionZ;

	var radius = 50;
	var random = parseFloat(DataStore.Get("BattleRoyale", Player.SteamID+"random"));
	var angle_in_rad = convertToRadians(random);

	var x = sx + radius * Math.cos(angle_in_rad);
	var z = sz + radius * Math.sin(angle_in_rad);
	//Player.Message("We made it past the spawn math functions! x: " + x + " z: " + z);
	Player.TeleportTo(x, sy+250, z);
	//Player.Message("You have been teleported to the starting area! (X:" + x + " Y:" + sy + " Z:" + z + ")");
}

function convertToRadians(degrees)
{
return degrees * (Math.PI/180);
}

function startBattleRoyale()
{
	var matches = DataStore.Get("BattleRoyale", "Matches");
	if (matches == null || matches == undefined)
		matches = 0;
	
	matches = matches + 1;
	DataStore.Add("BattleRoyale", "Matches", matches);
	//Server.Broadcast("There have been " + matches + " matches since the last restart!");

	for (var pl in Server.Players)
	{	
		var alive = DataStore.Get("BattleRoyale", pl.SteamID+"alive");
		if (alive == null || alive == undefined)
			alive = false;

		if (alive)
		{
			freePlayer(pl);
			//Server.Broadcast("Sending " + pl.Name + " to Starting Area!");
			sendToStart(pl);
		}
	}
	Server.BroadcastNotice("GOOD LUCK! LAST MAN STANDING WINS! GOOOOOOO!");
	DataStore.Add("BattleRoyale", "Game", true);
	DataStore.Add("BattleRoyale", "PrepareCount", 0);
	Plugin.KillTimer("BattleRoyalePrepare");
	Plugin.KillTimer("BattleRoyaleLobbyClosed");
	//Plugin.KillTimer("FreezePlayer");

	var time = parseInt(Data.GetConfigValue("BattleRoyale", "Settings", "RoundTime"));
	Plugin.CreateTimer("BattleRoyale", time).Start();
	Plugin.CreateTimer("CheckDistance", 120000).Start();

	// Drop airdrops based on amount of players
	var count = 0;
	for (var pl in Server.Players)
	{	
		var alive = DataStore.Get("BattleRoyale", pl.SteamID+"alive");
		if (alive)
			count++;
		//DataStore.Add("BattleRoyale", pl.SteamID+"alive", true);
	}

	DataStore.Add("BattleRoyale", "PlayerCount", count);

	/* Need to fix Airdrop bug
	while (count > 0)
	{
		World.AirdropAt(X, Y, Z);
		Server.Broadcast("Dropping more airdrops!");
		count = count - 10;
	}*/
		
	var time = (System.DateTime.Now/1000);
	DataStore.Add("BattleRoyale", "MatchStartTime", time);

	for (var pl in Server.Players)
	{
		pl.Inventory.AddItem("Bandage", 5);
		pl.Inventory.AddItem("Hatchet", 1);
	}

	spawnStartingCrates();
}

function startBattleRoyalePrepare()
{

	Server.BroadcastNotice("Starting Battle Royale Prepare...");
	Server.Broadcast("[color#FFFF00]YOU WILL BE HELD WITHIN THE JAIL UNTIL THE GAME STARTS![/color]");
	//Server.Broadcast("[color#FFFF00]IF YOU CAN'T SEE OTHER PLAYERS RELAUNCH YOUR GAME![/color]");
	Server.Broadcast("[color#FFFF00]PLEASE REPORT ALL BUGS. ADD ME ON STEAM:[/color][color#00FF00] FRACCAS[/color]");
	DataStore.Add("BattleRoyale", "Game", false);
	DataStore.Add("BattleRoyale", "Radius", 1000);
	DataStore.Add("BattleRoyale", "LobbyClosed", false);
	Plugin.KillTimer("BattleRoyaleLobbyClosed");
	Plugin.KillTimer("BattleRoyale");
	Plugin.KillTimer("CheckDistance");

	var time = parseInt(Data.GetConfigValue("BattleRoyale", "Settings", "PrepareTime"));
	Plugin.CreateTimer("BattleRoyalePrepare", time).Start();
	// If user joins within 15 secs of stop prevent him from joining
	var lobby_time = time - 30000;
	Plugin.CreateTimer("BattleRoyaleLobbyClosed", lobby_time).Start();
	//Plugin.CreateTimer("FreezePlayer", 5000).Start();

	Server.Broadcast("[color#00FF00]Battle Royale will begin in " + (time/1000) + " seconds![/color]");
	var X = parseFloat(Data.GetTableValue("BattleRoyale", "StartPositionX"));
	var Y = parseFloat(Data.GetTableValue("BattleRoyale", "StartPositionY"));
	var Z = parseFloat(Data.GetTableValue("BattleRoyale", "StartPositionZ"));
	//Server.Broadcast(X + " " + Y + " " + Z);

	//removeSpawningCrates();

	var count = 0;
	for (var pl in Server.Players)
	{
		try
		{
			DataStore.Add("BattleRoyale", pl.SteamID+"alive", true);
			//sendToJail(pl, "30000");
		}
		catch(err)
		{
			Server.Broadcast("Couldn't send player to jail/make alive!");
			Server.Broadcast(err);
		}
		
		count++;
	}
	DataStore.Add("BattleRoyale", "PlayerCount", count);
	//Server.Broadcast("Past Aidrop");
	/*
	for (var pl in Server.Players)
	{
		freePlayer(pl);
		//Server.Broadcast("Past Free Players");
	}
	*/

	
	for (var pl in Server.Players)
	{
		pl.Inventory.ClearAll();
	}



	//Server.Broadcast("Past Clear Inventory");

}

function startBattleRoyaleLobbyClosed()
{
	DataStore.Add("BattleRoyale", "LobbyClosed", true);
	Server.Broadcast("[color#FFFF00]The lobby is now closed! Future players will not be able join this match![/color]");
	Server.Broadcast("[color#FFFF00]The match will begin in 30 seconds! Prepare yourself![/color]");
	Server.Broadcast("The following players are in the queue:")

	for (var pl in Server.Players)
	{
		var alive = DataStore.Get("BattleRoyale", pl.SteamID+"alive");
		if (alive)
		{
			Server.Broadcast("[color#DC143C]" + pl.Name + "[color]");
		}
	}
}

function freezePlayer(Player)
{
	var random = parseFloat(DataStore.Get("BattleRoyale", Player.SteamID+"random"));
	var StartPositionX = parseFloat(Data.GetTableValue("BattleRoyale", "StartPositionX"));
	var StartPositionY = parseFloat(Data.GetTableValue("BattleRoyale", "StartPositionY"));
	var StartPositionZ = parseFloat(Data.GetTableValue("BattleRoyale", "StartPositionZ"));
	var x = StartPositionX+random;
	var y = StartPositionY;
	var z = StartPositionZ+random;
	if (Player.Z != z)
		Player.TeleportTo(x, y, z);
}

function checkDistance()
{
	BRairdrop();
	var radius = DataStore.Get("BattleRoyale", "Radius");
	radius = radius - 60;
	DataStore.Add("BattleRoyale", "Radius", radius);
	var players_alive = 0;
	var timeremaining = getTimeRemaining();
	Server.Broadcast("[color#FFFF00]The match has " + Math.round(timeremaining) + " minutes remaining![/color]");

	var player_count = DataStore.Get("BattleRoyale", "PlayerCount");
	Server.Broadcast("[color#FFFF00]There are " + player_count + " players remaining![/color]");
	for (var pl in Server.Players)
    {
    	var alive = DataStore.Get("BattleRoyale", pl.SteamID+"alive");
    	if (alive)
    	{
    		var x = parseFloat(Data.GetTableValue("BattleRoyale", "StartPositionX"));
			var y = parseFloat(Data.GetTableValue("BattleRoyale", "StartPositionY"));
			var z = parseFloat(Data.GetTableValue("BattleRoyale", "StartPositionZ"));

			var a = Util.CreateVector(x, y, z);
    		var b = Util.CreateVector(pl.X, pl.Y, pl.Z);

    		var distance = parseInt(Util.GetVectorsDistance(a, b));
    		pl.Message("[color#00FF00]You are " + distance + " meters from the starting point![/color]");
    		pl.Message("[color#00FF00]You need to be within " + radius + " meters from the starting point or you will be penalized![/color]");

			players_alive++;
    		checkPenalty(b, radius, distance);	
    	}
    }
    // Check to see if somehow it became one player by bug (ex. Game Crash, Login Data, etc.)
    var game = DataStore.Get("BattleRoyale", "Game");
	if (players_alive < 2 && game)
	{
		Server.Broadcast("Player's Alive: " + players_alive);
		// Find the last player marked as alive and declare him winner
		for (var pl in Server.Players)
		{
			var alive = DataStore.Get("BattleRoyale", pl.SteamID+"alive");
			var game = DataStore.Get("BattleRoyale", "Game");
			if (players_alive < 2 && game && alive)
			{
				Server.BroadcastNotice(pl.Name + " has won the Battle Royale!!!");
				Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
				Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
				Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
				Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
				Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
				Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
				Server.Broadcast("[color#FFFF00]★★★★★★★★★★[color#00FF00]" + pl.Name + "[/color] has won the Battle Royale!!!★★★★★★★★★★[/color]");
				Server.Broadcast("[color#00FF00]---------------------------------------------------------------------------------[/color]");
				Server.Broadcast("[color#FFFF00]★★★★★★★★★★Shutting down server in 60 seconds!★★★★★★★★★★[/color]");
				Server.Broadcast("[color#FFFF00]★★★★★★★★★★Shutting down server in 60 seconds!★★★★★★★★★★[/color]");
				Server.Broadcast("[color#FFFF00]★★★★★★★★★★Shutting down server in 60 seconds!★★★★★★★★★★[/color]");
				Server.Broadcast("[color#FFFF00]★★★★★★★★★★Shutting down server in 60 seconds!★★★★★★★★★★[/color]");
				RustPP.TimedEvents.shutdown();
				World.AirdropAtPlayer(pl);
				World.AirdropAtPlayer(pl);
				World.AirdropAtPlayer(pl);
				World.AirdropAtPlayer(pl);
				World.AirdropAtPlayer(pl);
				World.AirdropAtPlayer(pl);
				World.AirdropAtPlayer(pl);
				pl.Inventory.ClearAll();
			}
		}
		startBattleRoyalePrepare();
	}
}

function getTimeRemaining()
{
	var MatchStartTime = parseInt(DataStore.Get("BattleRoyale", "MatchStartTime"));
	var time = (System.DateTime.Now/1000);
	var RoundTime = parseInt(Data.GetConfigValue("BattleRoyale", "Settings", "RoundTime"));
	RoundTime = RoundTime/1000;

	var timeremaining = (RoundTime - (time - MatchStartTime));

	return timeremaining/60;
}

function checkPenalty(p_loc, radius, distance)
{
	if (distance > radius)
	{
		try
		{
			
			World.Spawn(":mutant_bear", p_loc);
			World.Spawn(":mutant_wolf", p_loc);
			World.Spawn(":mutant_wolf", p_loc);
			World.Spawn(":mutant_wolf", p_loc);
			World.Spawn(":mutant_wolf", p_loc);
			World.Spawn(";explosive_charge", p_loc);
			//World.Spawn(":mutant_wolf", p_loc);
			//World.Spawn(":mutant_wolf", p_loc);

			//pl.Health = 3;
	   		//pl.UpdateHealth();
	   		//Server.Broadcast("Health Altered!");
		}
		catch(err)
		{
			//Server.Broadcast("Problem with pentalty checker!");
			Server.Broadcast(err);	
		}
		
	}
}

function BRairdrop()
{
	var count = DataStore.Get("BattleRoyale", "PlayerCount");
	var random = Math.floor((Math.random() * count) + 1);
	var i = 1;
	for (var pl in Server.Players)
	{
		//Server.Broadcast("Count: " + count + " Random: " + random + " I: " + i + " PlayerName: " + pl.Name);
		var alive = DataStore.Get("BattleRoyale", pl.SteamID+"alive");
		if (alive)
		{
			if (i == random)
			{
				//World.AirdropAtPlayer(pl);
				pl.Message("You have been gifted a supply signal! May the odds be in your favor!");
				pl.Message("Check your inventory! Be careful when calling in your crate!");
				pl.Inventory.AddItem("Supply Signal", 1);
				break;
			}
			i++;
		}		
	}	
}

function spawnStartingCrates()
{	
	Server.BroadcastNotice("Start spawning crates!");
	var X = parseFloat(Data.GetTableValue("BattleRoyale", "StartPositionX"));
	var Y = parseFloat(Data.GetTableValue("BattleRoyale", "StartPositionY"));
	var Z = parseFloat(Data.GetTableValue("BattleRoyale", "StartPositionZ"));

	var count = -16.0;

	Server.Broadcast("X:" + X + " Y:" + Y + " Z:" + Z + " | Count:" + count);
	try
	{
		for(var i=0;i<32;i++)
		{
			var x = parseFloat(X+(count*2));
			//Server.Broadcast("X"+i+": " + x);
			var z = Z;
			var y = World.GetGround(x, z);
			y++;
			var loc = Util.CreateVector(x, y, z);
			World.Spawn(";drop_lootsack_zombie", loc);
			
			var y2 = y + 1;
			var loc2 = Util.CreateVector(x, y2, z);
			World.Spawn(";explosive_charge", loc2);
			//Server.Broadcast("X: " + X + " Y: " + Y + " Z: " + Z + " Crate: " + spawn_crates[i]);
			count++;
		}
	}
	catch(err)
	{	
		Server.Broadcast(err);
		Server.Broadcast("ERROR: Problem trying to spawn crates!");
		startBattleRoyale();
	}
}


function getBRwins()
{
	try
	{
		var ini =  Plugin.GetIni("BattleRoyale");
		var players = ini.EnumSection("BattleRoyale");
		var leaderboard = [];
		var kills = [];
		var names = [];

		var i = 0;
		for (var player in players)
		{
			var kills = ini.GetSetting("BattleRoyale", player);
			//Server.Broadcast(player + ": " + kills);
			names[i] = player;
			kills[i] = kills;
			leaderboard[i] = [names[i], kills[i]];
			i++;
		}

		DataStore.Add("BattleRoyale", "Leaderboard", leaderboard);

	}
	catch(err)
	{
		Server.Broadcast("INI ERROR: " + err);
	}
}

// teleport.topos "playerName" "3682" "1000" "-2244