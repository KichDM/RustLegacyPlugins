/*

Author: KichDM

------------------------------------
Implement a ranking system (COMPLETE)
Implement kits system (COMPLETE)
Implement a Chat Rank Tagging System (COMPLETE FOR DEATH MESSAGES)
Implement CFG file 
Add lastKill to ini file to prevent spam kills
Make Donor Kit

Changelog: 
Add /checkrank "username" 
Add /getkit
Add /giveHeroPoints "username" 	

Hero/Bandit Points
Heroes can give Bandit Points
Anyone can give Hero Points (once every 6 hours)

----------------------------------
*/


//process player killed event
function On_PlayerKilled(DeathEvent)
{
	if (DeathEvent.Attacker.Name != DeathEvent.Victim.Name) 
	{
		var kills = parseInt(getKills(DeathEvent.Attacker)) + 1;
		var heroPoints = parseInt(getHeroPoints(DeathEvent.Attacker));
		var killerRank = getPlayerRank(DeathEvent.Attacker);
		var victimRank = getPlayerRank(DeathEvent.Victim);
		
		if (victimRank == null || victimRank == "undefined")
			Server.Broadcast("[" + killerRank + "]" + DeathEvent.Attacker.Name + " ㊉ " + DeathEvent.Victim.Name + "(" + DeathEvent.WeaponName + ")");
		else 
			Server.Broadcast("[" + killerRank + "]" + DeathEvent.Attacker.Name + " ㊉ " + "[" + victimRank + "]" + DeathEvent.Victim.Name + "(" + DeathEvent.WeaponName + ")");
		
		DeathEvent.Attacker.Message("You just got a kill! - Kills: " + kills);
		
		var lastPlayerKilled = getLastPlayerKilled(DeathEvent.Attacker);
		if (DeathEvent.Victim.SteamID != lastPlayerKilled)
		{
			addKill(DeathEvent.Attacker, kills);
			
			// takes away hero points for bad behaviour
			if (getPlayerRank(DeathEvent.Victim) == "PEACE-KEEPER" || getPlayerRank(DeathEvent.Victim) == "ADVENTURER" || getPlayerRank(DeathEvent.Victim) == "HERO" || getPlayerRank(DeathEvent.Victim) == "POLICE") 
			{
				// take away two b/c current addHeroPoints function adds 1 (-2 + 1 takes away 1 from points)
				heroPoints = heroPoints - 2;
				addHeroPoints(DeathEvent.Attacker, heroPoints);
				DeathEvent.Attacker.Message("You have lost one hero point! (/getHeroPoints)");
			}
			
			// gives player hero points
			if (getPlayerRank(DeathEvent.Victim) == "BANDIT" || getPlayerRank(DeathEvent.Victim) == "B-Hunter" || getPlayerRank(DeathEvent.Victim) == "MERCENARY" || getPlayerRank(DeathEvent.Victim) == "GOD") 
			{
				addHeroPoints(DeathEvent.Attacker, heroPoints);
				DeathEvent.Attacker.Message("You have gained one hero point! (/getHeroPoints)");
			}
			
			// allows survivors to get hero points by killing survivors who have killed them
			var killedByPlayer = getLastPlayerKilled(DeathEvent.Victim);
			if (getPlayerRank(DeathEvent.Victim) == "SURVIVOR" && getPlayerRank(DeathEvent.Attacker) == "SURVIVOR" && killedByPlayer == DeathEvent.Attacker.SteamID)
			{
				addHeroPoints(DeathEvent.Attacker, heroPoints);
			}
		
		}
		
		// store last player killed
		addLastPlayerKilled(DeathEvent.Attacker, DeathEvent.Victim.SteamID);
		fixPlayerRank(Player);
		
		if (kills == 1)
		{
			addPlayerRank(DeathEvent.Attacker, "SURVIVOR");
		}
		
	}
}

function On_PlayerConnected(Player)
{
	addName(Player); 
	fixPlayerRank(Player);
}

//process user commands
function On_Command(Player, cmd, args)
{
	if(cmd == "kills")
	{
		var kills = getKills(Player);
		Player.Message("You have: " + kills + " kills");
	}
	else if(cmd == "top10")
	{
		if(args[0] == "kills")
		{
			var players = getTopKillers(Player);
			
			for(var x = 0; x < 10; x++)
			{
				if(players[x] != null)
				{
					Player.Message("#" + (x+1) + " - " + players[x]['name'] + ": " + players[x]['kills'] + " kills!");
				}
			}
		}
	}
	else if(cmd == "getkit")
	{
			var lastKitTime = getLastKitTime(Player);
			var currentTime =  System.Environment.TickCount; //System.DateTime.Now;
			
			// 600,000 milliseconds = 600 seconds = 10 minutes
			// Allow user to /getkit if they haven't used /getkit in the past 10 mins
			if (lastKitTime == null || currentTime > lastKitTime + 600000)
			{
				var kills = getKills(Player); 
				if (getPlayerRank(Player) == "SURVIVOR") 
				{
					Player.Message("You have received your SURVIVOR kit!"); 
					Player.Inventory.AddItem("9mm Pistol", 1);
					Player.Inventory.AddItem("9mm Ammo", 50);
					Player.Inventory.AddItem("Cloth Helmet", 1);
					Player.Inventory.AddItem("Cloth Vest", 1);
					Player.Inventory.AddItem("Cloth Pants", 1);
					Player.Inventory.AddItem("Cloth Boots", 1);
					Player.Inventory.AddItem("Bandage", 5);
					Player.Inventory.AddItem("Small Medkit", 5);
				} 
				else if (getPlayerRank(Player) == "BANDIT") 
				{
					Player.Message("You have received your BANDIT kit!"); 
					Player.Inventory.AddItem("P250", 1);
					Player.Inventory.AddItem("9mm Ammo", 50);
					Player.Inventory.AddItem("Rad Suit Helmet", 1);
					Player.Inventory.AddItem("Rad Suit Vest", 1);
					Player.Inventory.AddItem("Rad Suit Pants", 1);
					Player.Inventory.AddItem("Rad Suit Boots", 1);
					Player.Inventory.AddItem("Bandage", 5);
				} 
				else if (getPlayerRank(Player) == "B-Hunter") 
				{
					Player.Message("You have received your B-HUNTER kit!"); 
					Player.Inventory.AddItem("MP5A4", 1);
					Player.Inventory.AddItem("9mm Ammo", 50);
					Player.Inventory.AddItem("Rad Suit Helmet", 1);
					Player.Inventory.AddItem("Leather Vest", 1);
					Player.Inventory.AddItem("Rad Suit Pants", 1);
					Player.Inventory.AddItem("Rad Suit Boots", 1);
					Player.Inventory.AddItem("Bandage", 5);
					
				} 
				else if (getPlayerRank(Player) == "MERCENARY") 
				{
					Player.Message("You have received your MERCENARY kit!"); 
					Player.Inventory.AddItem("Bolt Action Rifle", 1);
					Player.Inventory.AddItem("556 Ammo", 50);
					Player.Inventory.AddItem("Revolver", 1);
					Player.Inventory.AddItem("9mm Ammo", 50);
					Player.Inventory.AddItem("Leather Helmet", 1);
					Player.Inventory.AddItem("Leather Vest", 1);
					Player.Inventory.AddItem("Leather Pants", 1);
					Player.Inventory.AddItem("Leather Boots", 1);
					Player.Inventory.AddItem("Bandage", 5);
					Player.Inventory.AddItem("Large Medkit", 1);
				} 
				else if (getPlayerRank(Player) == "GOD")
				{
					Player.Message("You have received your GOD kit!"); 
					Player.Inventory.AddItem("Bolt Action Rifle", 1);
					Player.Inventory.AddItem("556 Ammo", 50);
					Player.Inventory.AddItem("P250", 1);
					Player.Inventory.AddItem("9mm Ammo", 50);
					Player.Inventory.AddItem("Kevlar Helmet", 1);
					Player.Inventory.AddItem("Leather Vest", 1);
					Player.Inventory.AddItem("Leather Pants", 1);
					Player.Inventory.AddItem("Leather Boots", 1);
					Player.Inventory.AddItem("Bandage", 5);
					Player.Inventory.AddItem("Large Medkit", 3);
				}
				else if (getPlayerRank(Player) == "PEACE-KEEPER")
				{
					Player.Message("You have received your PEACE-KEEPER kit!"); 
					Player.Inventory.AddItem("MP5A4", 1);
					Player.Inventory.AddItem("P250", 1);
					Player.Inventory.AddItem("9mm Ammo", 50);
					Player.Inventory.AddItem("Leather Helmet", 1);
					Player.Inventory.AddItem("Kevlar Vest", 1);
					Player.Inventory.AddItem("Leather Pants", 1);
					Player.Inventory.AddItem("Leather Boots", 1);
					Player.Inventory.AddItem("Bandage", 5);
					Player.Inventory.AddItem("Small Medkit", 3);
				}
				else if (getPlayerRank(Player) == "ADVENTURER")
				{
					Player.Message("You have received your ADVENTURER kit!"); 
					Player.Inventory.AddItem("Bolt Action Rifle", 1);
					Player.Inventory.AddItem("556 Ammo", 50);
					Player.Inventory.AddItem("P250", 1);
					Player.Inventory.AddItem("9mm Ammo", 50);
					Player.Inventory.AddItem("Leather Helmet", 1);
					Player.Inventory.AddItem("Kevlar Vest", 1);
					Player.Inventory.AddItem("Kevlar Pants", 1);
					Player.Inventory.AddItem("Leather Boots", 1);
					Player.Inventory.AddItem("Bandage", 5);
					Player.Inventory.AddItem("Small Medkit", 3);
				}
				else if (getPlayerRank(Player) == "HERO")
				{
					Player.Message("You have received your HERO kit!"); 
					Player.Inventory.AddItem("M4", 1);
					Player.Inventory.AddItem("556 Ammo", 50);
					Player.Inventory.AddItem("P250", 1);
					Player.Inventory.AddItem("9mm Ammo", 50);
					Player.Inventory.AddItem("Kevlar Helmet", 1);
					Player.Inventory.AddItem("Kevlar Vest", 1);
					Player.Inventory.AddItem("Leather Pants", 1);
					Player.Inventory.AddItem("Leather Boots", 1);
					Player.Inventory.AddItem("Bandage", 5);
					Player.Inventory.AddItem("Small Medkit", 3);
				}
				else if (getPlayerRank(Player) == "POLICE")
				{
					Player.Message("You have received your POLICE kit!"); 
					Player.Inventory.AddItem("MP5A4", 1);
					Player.Inventory.AddItem("P250", 1);
					Player.Inventory.AddItem("9mm Ammo", 100);
					Player.Inventory.AddItem("Shotgun", 1);
					Player.Inventory.AddItem("Shotgun Shells", 25);
					Player.Inventory.AddItem("Kevlar Helmet", 1);
					Player.Inventory.AddItem("Kevlar Vest", 1);
					Player.Inventory.AddItem("Kevlar Pants", 1);
					Player.Inventory.AddItem("Kevlar Boots", 1);
					Player.Inventory.AddItem("Bandage", 5);
					Player.Inventory.AddItem("Large Medkit", 3);
				}
				
				addLastKitTime(Player, currentTime);
			} 
			else 
			{
				// displays the time remaining to get rank kit
				var timeleft = (currentTime - lastKitTime)/1000;
				Player.Message("You need to wait " + Math.round((600 - timeleft)) + " seconds before using this again!"); 
			}
			
		}
		else if(cmd == "getrank")
		{
			var rank = getPlayerRank(Player);
			Player.Message(Player.Name + " : [" + rank + "]");
		}
		else if(cmd == "checkrank")
		{
			// lets players check other user's ranks
			if(args.Length != 0)
			{
				var username = "";
				for (var l = 0; l < args.Length; l++)
				{
					if (l == args.Length -1)
					{
						username += args[l];
					}
					else
					{
						username += args[l] + " ";
					}
				}
				var searchPlayer = Player.Find(username);
				if (searchPlayer != null){
					searchPlayer.Message("Your rank has been searched by " + Player.Name + "!");
					Player.Message(searchPlayer.Name + " : Kills - " + getKills(searchPlayer) + " : [" + getPlayerRank(searchPlayer) + "]");
				}
				else 
				{
					Player.Message ("Player is not online!");
				}
			}
			else 
			{
				Player.Message("Please enter a username! /checkrank username"); 
			} 	
		}
		else if(cmd == "kits" || cmd == "ranks")
		{
			Player.Message("Survivor   : Requires(1 kill)   : Kit(9mm Pistol, 50 9mm Ammo)");	
			Player.Message("-------------------BANDIT RANKS-------------------");
			Player.Message("BANDIT     : Requires(15 kills) : Kit(P250)");
			Player.Message("B-HUNTER   : Requires(30 kills) : Kit(MP5A4)");
			Player.Message("MERCENARY  : Requires(60 kills) : Kit(Bolt Action Rifle, Revolver)");
			Player.Message("GOD        : Requires(90 kills) : Kit(Bolt Action Rifle, P250)");
			Player.Message("--------------------HERO RANKS---------------------");
			Player.Message("PEACE-KEEPER    : Requires(15 kills/10 Hero Points) : Kit(MP5A4, P250)");
			Player.Message("ADVENTURER      : Requires(30 kills/20 Hero Points) : Kit(Bolt Action, P250)");
			Player.Message("HERO            : Requires(60 kills/40 Hero Points) : Kit(M4, P250)");
			Player.Message("POLICE          : Requires(90 kills/60 Hero Points) : Kit(M4, P250)");
			Player.Message("Commands: /kithelp, /kits, /kills, /getkit, /getrank, checkrank 'name', /giveHeroPoint 'name'!");
		}
		else if(cmd == "kithelp")
		{
			Player.Message("RuinNation : FactionKits Server");
			Player.Message("/getrank - Lists your rank");
			Player.Message("/getkit - Gives player a kit based on faction/rank");
			Player.Message("/checkrank 'username' - Lists other player's rank");
			Player.Message("/giveHeroPoint 'username' - Gives a player a hero point for helping you! (6h cooldown)");
			Player.Message("/resetrank or /resetkills' - Resets all stats and makes you a SURVIVOR.");
			Player.Message("/getHeroPoints' - Lists amount of hero points you have!");
			Player.Message("/kits or /ranks - Lists all ranks and kits");
			Player.Message("/requestpolice - Broadcasts your location and desire for police help to server!");
			Player.Message("Get Hero Points by killing Bandits, B-Hunters, Mercenaries, and Gods!");
			Player.Message("Lose Hero Points by killing Peace-Keepers, Adventurers, Heros, and Police!");
		}
		else if(cmd == "giveHeroPoint")
		{
			var lastHeroPointTime = getLastHeroPoint(Player);
			var currentTime = System.Environment.TickCount; //System.DateTime.Now;
			
			// 22,000,000 milliseconds = 6.11 hours
			// Allow user to /giveHeroPoints if they haven't used /giveHeroPoints in the past 6 hours
			if (lastHeroPointTime == null || currentTime > lastHeroPointTime + 22000000) 
			{
				if(args.Length != 0)
				{
					var username = "";
					for (var l = 0; l < args.Length; l++)
					{
						if (l == args.Length -1)
						{
							username += args[l];
						}
						else
						{
							username += args[l] + " ";
						}
					}
					var searchPlayer = Player.Find(username);
					if (searchPlayer != null)
					{
						searchPlayer.Message("You have been given a Hero Point by " + Player.Name + "!");
						Player.Message("You have given a HeroPoint to " + searchPlayer.Name + "!");
						var heroPoint = getHeroPoints(searchPlayer);
						addHeroPoints(searchPlayer, heroPoint);
						addLastHeroPoint(Player, currentTime);
					}
					else 
					{
						Player.Message ("Player is not online!");
					}
				}
			}
			else 
			{
				// displays the time remaining to give hero point
				var secondsLeft = (currentTime - lastHeroPointTime)/1000;
				var hoursLeft = secondsLeft/3600;
				Player.Message("You need to wait " + Math.round((6 - hoursLeft)) + " hours before using this again!"); 
			}
		}
		else if(cmd == "getHeroPoints")
		{
			var heroPoints = getHeroPoints(Player);
			Player.Message(Player.Name + " - " + heroPoints + " Hero Points!");
		}
		else if(cmd == "resetrank" || cmd == "resetkills")
		{
			resetHeroPoints(Player);
			resetKills(Player);
			resetPlayerRank(Player);
			Player.Message("You have reset your rank/kills/heropoints!");
		}
		else if(cmd == "rankup")
		{
			fixPlayerRank(Player);
		}
		else if (cmd == "adminGiveHeroPoint")
		{
				if(args.Length != 0)
				{
					var username = "";
					for (var l = 0; l < args.Length; l++)
					{
						if (l == args.Length -1)
						{
							username += args[l];
						}
						else
						{
							username += args[l] + " ";
						}
					}
					var searchPlayer = Player.Find(username);
					if (searchPlayer != null)
					{
						searchPlayer.Message("You have been given a Hero Point by " + Player.Name + "!");
						Player.Message("You have given a HeroPoint to " + searchPlayer.Name + "!");
						var heroPoint = parseInt(getHeroPoints(searchPlayer));
						addHeroPoints(searchPlayer, heroPoint);
					}
					else 
					{
						Player.Message ("Player is not online!");
					}
				}
		} 
		else if (cmd == "adminGiveKill")
		{
			if(args.Length != 0)
				{
					var username = "";
					for (var l = 0; l < args.Length; l++)
					{
						if (l == args.Length -1)
						{
							username += args[l];
						}
						else
						{
							username += args[l] + " ";
						}
					}
					var searchPlayer = Player.Find(username);
					if (searchPlayer != null)
					{
						var kills = parseInt(getKills(searchPlayer));
						addKill(searchPlayer, kills+1);
						Player.Message("You have given a kill to " + searchPlayer.Name + "!");
					}
					else 
					{
						Player.Message ("Player is not online!");
					}
				}
		}
		else if (cmd == "requestpolice")
		{
			Player.Message("You have sent a request of help to the police!");
			Server.Broadcast(Player.Name + " requests police help at " + Player.Location + "!");
			/*
			var ini = getIni();
			var steamIDs = ini.EnumSection("PlayerRanks");
			for(var steamID in steamIDs)
			{
				//var name = Data.GetTableValue("liquid_names", steamID);
				var cop = Player.FindByID(steamID);
				var rank = getPlayerRank(cop);
				if(rank == "POLICE")
				{
					cop.Notice(Player.Name + " needs help at X:" + Player.X + " - Y: " + Player.Y + "!");
					cop.Message(Player.Name + " needs help at X:" + Player.X + " - Y: " + Player.Y + "!");
				}
			} */

		}
}


//Returns a list of all killers
function getTopKillers(Player)
{	
	var ini = getIni();
	var kills = [];
	var counter = 0;
	var steamIDs = ini.EnumSection("Kills");

	for(var steamID in steamIDs)
	{
		var info = {};
		info['steamID'] = steamID;
		info['kills'] = Data.GetTableValue("liquid_kills", steamID);
		info['name'] = Data.GetTableValue("liquid_names", steamID);
		info['heroPoints'] = Data.GetTableValue("liquid_heroPoints", steamID);

		kills[counter] = info;
		counter++;
	}

	kills = kills.sort(function(a,b) {
		return a['kills'] > b['kills'];
	});
 
	return kills;
}

/************************/
/*    Rank Functions    */
/************************/

//adds rank to player
function addPlayerRank(Player, rank) 
{
	Data.AddTableValue("liquid_rank", Player.SteamID, rank);
	Player.Message("You have ranked up to [" + rank + "]! /getrank /getkit /kits /kithelp");
	Player.Notice("You have ranked up to [" + rank + "]! /getrank /getkit /kits /kithelp");
	updatePlayerRank(Player, rank);
}

//resets rank
function resetPlayerRank(Player) 
{
	Data.AddTableValue("liquid_rank", Player.SteamID, "SURVIVOR");
	updatePlayerRank(Player, "SURVIVOR");
}

//Returns the rank of the player
function getPlayerRank(Player)
{	
	var _rank = Data.GetTableValue("liquid_rank", Player.SteamID);
	return _rank;
}

//Update the main database
function updatePlayerRank(Player, rank)
{
	var ini = getIni();
	
	ini.AddSetting("PlayerRanks", Player.SteamID, rank);
	ini.Save();
}

/************************/
/*    Kill Functions    */
/************************/

//add one kill to players total kill score
function addKill(Player, kills) 
{
	Data.AddTableValue("liquid_kills", Player.SteamID, kills);
	updateKills(Player, kills);
}

// reset kills
function resetKills(Player) 
{
	Data.AddTableValue("liquid_kills", Player.SteamID, 0);
	updateKills(Player, 0);
}

//return number of kills a player has
function getKills(Player)
{
	var _kills = Data.GetTableValue("liquid_kills", Player.SteamID);
	
	if(_kills == null)
	{
		_kills = 0;
		Data.AddTableValue("liquid_kills", Player.SteamID, _kills);
		updateKills(Player, _kills);
	}
	
	return _kills;
}

//Update the main database
function updateKills(Player, kills)
{
	var ini = getIni();
	
	ini.AddSetting("Kills", Player.SteamID, kills);
	ini.Save();
}

//add last time player received a kit
function addLastKitTime(Player, lastKitTime)
{
	Data.AddTableValue("liquid_lastKitTimes", Player.SteamID, lastKitTime);
	updateLastKitTime(Player, lastKitTime);
}

//return last kit time
function getLastKitTime(Player)
{
	var _lastKitTime = Data.GetTableValue("liquid_lastKitTimes", Player.SteamID);
	
	if(_lastKitTime == null)
	{
		_lastKitTime = 0;
		Data.AddTableValue("liquid_lastKitTimes", Player.SteamID, _lastKitTime);
		updateLastKitTime(Player, _lastKitTime);
	}
	
	return _lastKitTime;
}

//add last player killed
function addLastPlayerKilled(Player, lastPlayerKilled)
{
	Data.AddTableValue("liquid_lastPlayerKilled", Player.SteamID, lastPlayerKilled);
	updateLastPlayerKilled(Player, lastPlayerKilled);
}

//return last player killed
function getLastPlayerKilled(Player)
{
	var _lastPlayerKilled = Data.GetTableValue("liquid_lastPlayerKilled", Player.SteamID);
	
	if(_lastPlayerKilled == null)
	{
		_lastPlayerKilled = 0;
		Data.AddTableValue("liquid_lastPlayerKilled", Player.SteamID, _lastPlayerKilled);
		updateLastPlayerKilled(Player, _lastPlayerKilled);
	}
	
	return _lastPlayerKilled;
}

//Update last player killed
function updateLastPlayerKilled(Player, lastPlayerKilled)
{
	var ini = getIni();
	
	ini.AddSetting("LastPlayerKilled", Player.SteamID, lastPlayerKilled);
	ini.Save();
}


/***************************/
/* Name Functions */
/***************************/

//add player name
function addName(Player) 
{
	Data.AddTableValue("liquid_names", Player.SteamID, Player.Name);
	updateName(Player);
}

//Update the main database
function updateName(Player)
{
	var ini = getIni();
	
	ini.AddSetting("Names", Player.SteamID, Player.Name);
	ini.Save();
}

//return last player killed
function getName(steamID)
{
	var _name = Data.GetTableValue("liquid_names", steamID);
	
	if(_name == null)
	{
		_name = "";
		Data.AddTableValue("liquid_names", steamID, _name);
		updateName(Player);
	}
	
	return _name;
}

/******************/
/* Misc Functions */
/******************/

//Load all scores into relevant tables
function loadLeaderBoard()
{
	var ini = getIni();
	var steamIDs = ini.EnumSection("Kills");

	for(var steamID in steamIDs)
	{
		var kills = ini.GetSetting("Kills", steamID);
		Data.AddTableValue("liquid_kills", steamID, kills);
	}

	steamIDs = ini.EnumSection("Names");

	for(var steamID in steamIDs)
	{
		var name = ini.GetSetting("Names", steamID);
		Data.AddTableValue("liquid_names", steamID, name);
	}

	steamIDs = ini.EnumSection("HeroPoints");
	
	for(var steamID in steamIDs)
	{
		var heroPoints = ini.GetSetting("HeroPoints", steamID);
		Data.AddTableValue("liquid_heroPoints", steamID, heroPoints);
	}
	
	steamIDs = ini.EnumSection("LastKitTimes");
	
	for(var steamID in steamIDs)
	{
		var lastKit = ini.GetSetting("LastKitTimes", steamID);
		Data.AddTableValue("liquid_lastKitTimes", steamID, lastKit);
	}
	
	steamIDs = ini.EnumSection("LastPlayerKilled");
	
	for(var steamID in steamIDs)
	{
		var lastPlayerKilled = ini.GetSetting("LastPlayerKilled", steamID);
		Data.AddTableValue("liquid_lastPlayerKilled", steamID, lastPlayerKilled);
	}
	
	
	steamIDs = ini.EnumSection("LastHeroPoint");
	
	for(var steamID in steamIDs)
	{
		var lastHeroPoint = ini.GetSetting("LastHeroPoint", steamID);
		Data.AddTableValue("liquid_lastHeroPoint", steamID, lastHeroPoint);
	}
	
	steamIDs = ini.EnumSection("PlayerRanks");
	
	for(var steamID in steamIDs)
	{
		var playerRank = ini.GetSetting("PlayerRanks", steamID);
		Data.AddTableValue("liquid_rank", steamID, playerRank);
	}
	
}

//Grab the correct ini file
function getIni()
{
	if(!Plugin.IniExists("FactionKitData"))
	{
		Plugin.CreateIni("FactionKitData");
	}
		
	return Plugin.GetIni("FactionKitData");
}

//Load leaderboard on server restart
function On_ServerInit()
{
	loadLeaderBoard();
}

// allows user to give other players hero points
function addHeroPoints(Player, heroPoints)
{
	var newPoints = heroPoints + 1;
	Data.AddTableValue("liquid_heroPoints", Player.SteamID, newPoints);
	updateHeroPoints(Player, newPoints);
}

// allows user to give other players hero points
function resetHeroPoints(Player)
{
	Data.AddTableValue("liquid_heroPoints", Player.SteamID, 1);
	updateHeroPoints(Player, 1);
}

//return number of hero points a player has
function getHeroPoints(Player)
{
	var _heroPoints = Data.GetTableValue("liquid_heroPoints", Player.SteamID);
	
	if(_heroPoints == null)
	{
		_heroPoints = 1;
		Data.AddTableValue("liquid_heroPoints", Player.SteamID, _heroPoints);
		updateHeroPoints(Player, _heroPoints);
	}
	
	return _heroPoints;
}

//Update the hero points on the main database
function updateHeroPoints(Player, heroPoints)
{
	var ini = getIni();
	
	ini.AddSetting("HeroPoints", Player.SteamID, heroPoints);
	ini.Save();
}

//add last time player gave a hero point
function addLastHeroPoint(Player, lastHeroPoint)
{
	Data.AddTableValue("liquid_lastHeroPoint", Player.SteamID, lastHeroPoint);
	updateLastHeroPoint(Player, lastHeroPoint);
}

//return last time someone gave hero point
function getLastHeroPoint(Player)
{
	var _lastHeroPoint = Data.GetTableValue("liquid_lastHeroPoint", Player.SteamID);
	
	if(_lastHeroPoint == null)
	{
		_lastHeroPoint = 0;
		Data.AddTableValue("liquid_lastHeroPoint", Player.SteamID, _lastHeroPoint);
		updateLastHeroPoint(Player, _lastHeroPoint);
	}
	
	return _lastHeroPoint;
}

//Update last time someone gave hero point
function updateLastHeroPoint(Player, lastHeroPoint)
{
	var ini = getIni();
	
	ini.AddSetting("LastHeroPoint", Player.SteamID, lastHeroPoint);
	ini.Save();
}

// fixes player rank if there is problem
function fixPlayerRank(Player) 
{
			var kills = parseInt(getKills(Player));
			var heroPoints = parseInt(getHeroPoints(Player));
			
			if (heroPoints == null)
			{
				heroPoints = 0;
			}
			// fixes rank of players
			if (kills < 15)
			{
				addPlayerRank(Player, "SURVIVOR");
			}
			else if (kills >= 15 && kills < 29 && heroPoints < 10)
			{
				addPlayerRank(Player, "BANDIT");
			}
			else if (kills >= 15 && kills < 29 && heroPoints >= 10)
			{
				addPlayerRank(Player, "PEACE-KEEPER");
			}
			else if (kills >= 30 && kills < 59 && heroPoints < 20)
			{
				addPlayerRank(Player, "B-Hunter");
			}
			else if (kills >= 30 && kills < 59 && heroPoints >= 20)
			{
				addPlayerRank(Player, "ADVENTURER");
			}
			else if (kills >= 60 && kills < 89 && heroPoints < 40)
			{
				addPlayerRank(Player, "MERCENARY");
			}
			else if (kills >= 60 && kills < 89 && heroPoints >= 40)
			{
				addPlayerRank(Player, "HERO");
			}
			else if (kills >= 90 && heroPoints < 60)
			{
				addPlayerRank(Player, "GOD");
			}	
			else if (kills >= 90 && heroPoints >= 60)
			{
				addPlayerRank(Player, "POLICE");
			}	
			
			Player.Message(Player.Name + " : Kills - " + kills + " : [" + getPlayerRank(Player) + "]");
}