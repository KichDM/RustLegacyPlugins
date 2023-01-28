function On_ServerInit()
{
	Plugin.CreateTimer("CheckJail", 10000).Start();
	requestConfig();
    var ini = getIni();
	var jailX = ini.GetSetting("Jail", "JailX");
	var jailY = ini.GetSetting("Jail", "JailY");
	var jailZ = ini.GetSetting("Jail", "JailZ");
	var radius = ini.GetSetting("Jail", "JailRadius");
	DataStore.Add("Jail", "JailX", jailX);
	DataStore.Add("Jail", "JailY", jailY);
	DataStore.Add("Jail", "JailZ", jailZ);
	DataStore.Add("Jail", "JailRadius", radius);
	DataStore.Save();
}

function requestConfig()
{
	Data.AddTableValue("Jail", "LOG_OUT_TIMER", Data.GetConfigValue("Jail", "Settings", "Log_Out_Timer"));
	Data.AddTableValue("Jail", "Cop1", Data.GetConfigValue("Jail", "Settings", "Cop1"));
	Data.AddTableValue("Jail", "Cop2", Data.GetConfigValue("Jail", "Settings", "Cop2"));
	Data.AddTableValue("Jail", "Cop3", Data.GetConfigValue("Jail", "Settings", "Cop3"));
}


//Grab the correct ini file
function getIni()
{
	if(!Plugin.IniExists("Jail"))
	{
		Plugin.CreateIni("Jail");
	}
		
	return Plugin.GetIni("Jail");
}

function CheckJailCallback()
{
	//Server.Broadcast("Timer working");
	checkJail();
}

function On_PlayerConnected(Player)
{
	//Player.Message("Need help? Want to report rule breakers? Type /cops to see which cops are online!");
	var jail = DataStore.Get("Jail",Player.SteamID+"jail");
	if (jail == "true")
	{
		//checks cfg file for logOutTimer. If timer is true, let the jail counter continue counting while player is offline. 
		//If false, reset the counter to full when player reconnects
		requestConfig();
		var logOutTimer = Data.GetTableValue("Jail", "LOG_OUT_TIMER");
		if (logOutTimer == "false")
		{
			var jaillength = DataStore.Get("Jail", Player.SteamID+"jaillength");
			sendToJail(Player, jaillength);
		}
		else
		{
			var jaillength = parseInt(DataStore.Get("Jail", Player.SteamID+"jaillength"));
			var jailtime = parseInt(DataStore.Get("Jail", Player.SteamID+"jailtime"));
			var time = System.DateTime.Now/1000;

			var timeleft = jaillength - (time - jailtime);
			if (timeleft > 0)
			{
				sendToJail(Player, timeleft);
			}
			else
			{
				sendToJail(Player, 1);
				//var position = DataStore.Get("Jail", Player.SteamID+"position");
	    		//var x = position[0];
				//var y = position[1];	
				//var z = position[2];
				//Player.TeleportTo(x, y, z);
				//Player.Message("You are free and have been teleported back to your orginal position!");
				//DataStore.Add("Jail", Player.SteamID+"jailmute", "false");
				//DataStore.Add("Jail", Player.SteamID+"jail", "false");
				//DataStore.Add("Jail", Player.SteamID+"jaillength", "0");
				//Server.Broadcast("Log_Out_Timer sent Fraccas free!");
				//DataStore.Save();
			}
		}
	}
}


function On_Chat(Player, ChatMsg){
	var jail = DataStore.Get("Jail",Player.SteamID+"jailmute");

    if(jail == "true"){
         ChatMsg.NewText = "";
		return;
    }
}

function On_PlayerHurt(he)
{
	var jailA;
	for (var pl in Server.Players)
	{
		if (he.Attacker == pl)
		{
			jailA = DataStore.Get("Jail", he.Attacker.SteamID+"jail");
		}
	}
	
	if (jailA == null || jailA == undefined)
		jailA = "false";

	if (jailA == "true")
	{
		if (he.WeaponName == false)
		{
			he.DamageAmount = 0;
			he.Victim.IsBleeding = false;
			he.Victim.IsInjured = false;
			he.Victim.Health = 99;
			he.Victim.UpdateHealth();
		}
		else
		{
			//he.Victim.Health = he.Victim.Health + he.DamageAmount;
			he.DamageAmount = 0;
			he.Attacker.Message("YOU CANNOT ATTACK WHILE IN JAIL!");
		}
	}

	var jailV = DataStore.Get("Jail", he.Victim.SteamID+"jail");
	if (jailV == null || jailV == undefined)
		jailV = "false";
	if (jailV == "true")
	{
		if (he.WeaponName == false)
		{
			he.DamageAmount = 0;
			he.Victim.IsBleeding = false;
			he.Victim.IsInjured = false;
			he.Victim.Health = 99;
			he.Victim.UpdateHealth();
		}
		else
		{
			he.Victim.Health = he.Victim.Health + he.DamageAmount;
			he.Attacker.Message("YOU CANNOT ATTACK PEOPLE WHO ARE IN JAIL!");		
		}
	}		
}

function On_EntityHurt(he)
{
	//he.Victim.Message("A player is receiving this message!");
	var x = DataStore.Get("Jail", "JailX");
	var y = DataStore.Get("Jail", "JailY");
	var z = DataStore.Get("Jail", "JailZ");

	var a = Util.CreateVector(x, y, z);
	var b = Util.CreateVector(he.Attacker.X, he.Attacker.Y, he.Attacker.Z);

	var radius = parseInt(DataStore.Get("Jail", "JailRadius"));
	var distance = parseInt(Util.GetVectorsDistance(a, b));

	if (distance < radius+50 && he.WeaponName == false)
	{
		he.Entity.Health = he.Entity.Health + he.DamageAmount;
		if (he.DamageAmount < 10)
			return;
		he.Attacker.Message("You may not destroy objects within 50 meters of the jail!");
	}
}	


function On_Command(Player, cmd, args)
{
	if (Player.Admin || isCop(Player))
	{
		if (cmd == "setJail" || cmd == "setjail")
		{
        	Player.Message("Jail has been set here!");
			var ini = getIni();
			ini.AddSetting("Jail", "JailX", Player.X);
			ini.AddSetting("Jail", "JailY", Player.Y);
			ini.AddSetting("Jail", "JailZ", Player.Z);
			ini.Save();

			Datastore.Add("Jail", "JailX", Player.X);
			Datastore.Add("Jail", "JailY", Player.Y);
			Datastore.Add("Jail", "JailZ", Player.Z);
			//Datastore.Add("Jail", "Jail", Util.CreateVector(Player.X, Player.Y, Player.Z));
			DataStore.Save();
		}
		else if (cmd == "jail" || cmd == "JAIL" || cmd == "jailmute")
		{
			Plugin.CreateTimer("CheckJail", 10000).Start();

			// send player to jail
			var argsAmount = args.Length;

			//if the user puts a | into the command, add whatever is after to var reason
			var reason = "";
			for (var i=0; i<argsAmount; i++)
			{
				if (args[i] == "|")
				{
					for (var ii=i+1; ii<argsAmount; ii++)
					{
						reason += args[ii] + " ";
					}
				}
			}

			// if user adds | to command, don't count that in the argsAmount
			for (var i=0; i<argsAmount; i++)
			{
				if (args[i] == "|")
					argsAmount = i;
			}

			if(argsAmount != 0)
			{
				var username;
				var time;
				if (argsAmount == 2)
				{
					username = "" + args[0];
					time = args[1];
				}
				else if (argsAmount == 3)
				{
					username = args[0] + " " + args[1];
					time = args[2];
				}
				else if (argsAmount == 4)
				{
					username = args[0] + " " + args[1] + " " + args[2];
					time = args[3];
				}

				var searchPlayer = Player.Find(username);
				if (searchPlayer != null)
				{
					if (cmd == "jailmute")
					{
						searchPlayer.Notice("You have been JAILED and MUTED by " + Player.Name + " for " + time + " seconds! /jaillength");
						Server.Broadcast(username + " has been JAILED and MUTED for " + time + " seconds by " + Player.Name + "!");
						DataStore.Add("Jail", searchPlayer.SteamID+"jailmute", "true");
					}
					else 
					{
						searchPlayer.Notice("You have been JAILED by " + Player.Name + " for " + time + " seconds! /jaillength");
						Server.Broadcast(username + " has been JAILED for " + time + " seconds by " + Player.Name + "!");
					}


					if (reason != "")
					{
						Server.Broadcast("REASON: " + reason);
					}
					
					//var position = Util.CreateVector(searchPlayer.X, searchPlayer.Y, searchPlayer.Z);
					DataStore.Add("Jail", searchPlayer.SteamID+"positionX", searchPlayer.X);
					DataStore.Add("Jail", searchPlayer.SteamID+"positionY", searchPlayer.Y);
					DataStore.Add("Jail", searchPlayer.SteamID+"positionZ", searchPlayer.Z);
					sendToJail(searchPlayer, time);
				}
				else 
				{
					Player.Message ("Player is not online!");
				}
			}
			else 
			{
				Player.Message("Please enter a username! /jail username time"); 
			} 
		}
		else if (cmd == "setjailradius")
		{
			Player.Message("Jail radius has been set to " + args[0] + "!");
			var ini = getIni();
			ini.AddSetting("Jail", "JailRadius", args[0]);
			ini.Save();
			setJailRadius(args[0]);
		}
		else if (cmd == "getjailradius")
		{
			Player.Message("Jail Radius is currently " + getJailRadius());
		}
		else if (cmd == "freeplayer")
		{
			var argsAmount = args.Length;
			if(argsAmount != 0)
			{
				var username;
				if (argsAmount == 1)
				{
					username = "" + args[0];
				}
				else if (argsAmount == 2)
				{
					username = args[0] + " " + args[1];
				}
				else if (argsAmount == 3)
				{
					username = args[0] + " " + args[1] + " " + args[2];
				}

				var searchPlayer = Player.Find(username);
				if (searchPlayer != null)
				{
					freePlayer(searchPlayer);
				}
				else 
				{
					Player.Message ("Player is not online!");
				}
			}
		}
		else if (cmd == "changejailtime")
		{
			var argsAmount = args.Length;
			var time;
			if(argsAmount != 0)
			{
				var username;
				if (argsAmount == 2)
				{
					username = "" + args[0];
					time = args[1];
				}
				else if (argsAmount == 3)
				{
					username = args[0] + " " + args[1];
					time = args[2];
				}
				else if (argsAmount == 4)
				{
					username = args[0] + " " + args[1] + " " + args[2];
					time = args[3];
				}

				var searchPlayer = Player.Find(username);
				if (searchPlayer != null)
				{
					Player.Message("You have changed " + username + "'s jail length to " + time + " seconds!");
					searchPlayer.Message(Player.Name + " has changed your jail length to " + time + " seconds!");
					sendToJail(searchPlayer, time);
				}
				else 
				{
					Player.Message ("Player is not online!");
				}
			}
		}
		else if (cmd == "addcop")
		{
			var argsAmount = args.Length;
			
			if(argsAmount != 0)
			{
				var username;
				if (argsAmount == 1)
				{
					username = "" + args[0];
				}
				else if (argsAmount == 2)
				{
					username = args[0] + " " + args[1];
				}
				else if (argsAmount == 3)
				{
					username = args[0] + " " + args[1] + " " + args[2];
				}

				var searchPlayer = Player.Find(username);
				if (searchPlayer != null)
				{
					Player.Message("You have added " + username + " as a cop!");
					searchPlayer.Notice(Player.Name + " has decided to promote you to cop!");
					Server.Broadcast(Player.Name + " has promoted " + username + " to a cop!");
					addCop(searchPlayer);
				}
				else 
				{
					Player.Message ("Player is not online!");
				}
			}
		}
		else if (cmd == "checkcop")
		{
			var argsAmount = args.Length;
			
			if(argsAmount != 0)
			{
				var username;
				if (argsAmount == 1)
				{
					username = "" + args[0];
				}
				else if (argsAmount == 2)
				{
					username = args[0] + " " + args[1];
				}
				else if (argsAmount == 3)
				{
					username = args[0] + " " + args[1] + " " + args[2];
				}

				var searchPlayer = Player.Find(username);
				if (searchPlayer != null)
				{
					var cop = isCop(searchPlayer);
					if (cop)
						Player.Message(username + " is a cop!");
					else
						Player.Message(username + " is not a cop!");
				}
				else 
				{
					Player.Message ("Player is not online!");
				}
			}
		}
		else if (cmd == "killplayer")
		{
			var argsAmount = args.Length;
			
			if(argsAmount != 0)
			{
				var username;
				if (argsAmount == 1)
				{
					username = "" + args[0];
				}
				else if (argsAmount == 2)
				{
					username = args[0] + " " + args[1];
				}
				else if (argsAmount == 3)
				{
					username = args[0] + " " + args[1] + " " + args[2];
				}

				var searchPlayer = Player.Find(username);
				if (searchPlayer != null)
				{
					Player.Message("You have killed jailed player " + username + "!");
					searchPlayer.Notice(Player.Name + " has decided to kill you!");
					Server.Broadcast(Player.Name + " has deicded to kill jailed player: " + username);
					DataStore.Add("Jail", searchPlayer.SteamID+"jail", "false");
					searchPlayer.Kill();
					//searchPlayer.Health = 0;
					//searchPlayer.UpdateHealth();
					//Server.Broadcast("Past updatehealth()");
					DataStore.Add("Jail", searchPlayer.SteamID+"jail", "true");

				}
				else 
				{
					Player.Message ("Player is not online!");
				}
			}
		}
		else if (cmd == "reloadcfg")
		{
			requestConfig();
			Player.Message("Jail.cfg has been reloaded!");
		}
		else if (cmd == "restartTimer")
		{
			Plugin.KillTimer("CheckJail");
			Plugin.CreateTimer("CheckJail", 10000).Start();
		}
	}

	//Non admin commands
	if(cmd == "checkjail")
	{
		// lets players check other user's jail status
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
				searchPlayer.Message("Your jail status has been searched by " + Player.Name + "!");
				if (getJailStatus(searchPlayer) == "true")
				{
					var jaillength = parseInt(DataStore.Get("Jail", searchPlayer.SteamID+"jaillength"));
					var jailtime = parseInt(DataStore.Get("Jail", searchPlayer.SteamID+"jailtime"));
    				var time = System.DateTime.Now/1000;
 
					var timeleft = jaillength - (time - jailtime);
					Player.Message(searchPlayer.Name + " is in jail and has " + Math.round(timeleft) + " seconds left in jail!");
				}
				else
				{
					Player.Message("This player does not have a jail sentence!");
				}
				
			}
			else 
			{
				Player.Message ("Player is not online!");
			}
		}
		else 
		{
			Player.Message("Please enter a username! /checkjail username"); 
		} 	
	}
	else if (cmd == "jaillength")
	{
		var jaillength = parseInt(DataStore.Get("Jail", Player.SteamID+"jaillength"));
		var jail = DataStore.Get("Jail", Player.SteamID+"jail");
		if (jaillength != undefined &&  jail == "true")
		{
    		var jailtime = parseInt(DataStore.Get("Jail", Player.SteamID+"jailtime"));
    		var time = System.DateTime.Now/1000;
 
			var timeleft = jaillength - (time - jailtime);
			Player.Message("Your remaining jail time is " + Math.round(timeleft) + " seconds!");
		}
		else
		{
			Player.Message("You do not have a jail sentence!");
		}
	}
	else if (cmd == "jaillist")
	{
		Player.Message("Players in jail:");
		for (var pl in Server.Players)
    	{
    		var jail = getJailStatus(Player);
    		if (jail == "true")
    		{
    			Player.Message(pl.Name);
    		}
    	}
	}
	else if (cmd == "cops")
	{
		Player.Message("---------DISPLAYING ALL ONLINE COPS---------");
		for (var pl in Server.Players)
   		{
   			if (pl.Admin)
   				Player.Message(pl.Name)

   			var cop = isCop(pl);
   			if (cop)
   				Player.Message(pl.Name);
		}
		Player.Message("---------END OF ONLINE COP LIST---------");
	}
}

function getJailStatus(Player)
{
	return DataStore.Get("Jail", Player.SteamID+"jail");
}

function getJailLength(Player)
{
	return DataStore.Get("Jail", Player.SteamID+"jaillength");
}

function setJailRadius(radius)
{
	DataStore.Add("Jail", "JailRadius", radius);
	DataStore.Save();
}

function getJailRadius()
{
	var radius = DataStore.Get("Jail", "JailRadius");

	if (radius == undefined)
		radius = 0;

	return radius;
}

function sendToJail(Player, time)
{
	var x = DataStore.Get("Jail", "JailX");
	var y = DataStore.Get("Jail", "JailY");
	var z = DataStore.Get("Jail", "JailZ");
	Player.TeleportTo(x, y, z);
	//Player.Message("You have been teleported to Jail!");

	var jailtime = System.DateTime.Now/1000;
	//var position = Util.CreateVector(Player.X, Player.Y, Player.Z);
	//DataStore.Add("Jail", Player.SteamID+"position", position);
	
	DataStore.Add("Jail", Player.SteamID+"jail", "true");
	DataStore.Add("Jail", Player.SteamID+"jaillength", time);
	DataStore.Add("Jail", Player.SteamID+"jailtime", jailtime);
	DataStore.Save();
}

function freePlayer(searchPlayer)
{
	DataStore.Add("Jail", searchPlayer.SteamID+"jailmute", "false");
	DataStore.Add("Jail", searchPlayer.SteamID+"jail", "false");
	DataStore.Add("Jail", searchPlayer.SteamID+"jaillength", "0");
	var positionX = DataStore.Get("Jail", searchPlayer.SteamID+"positionX");
	var positionY = DataStore.Get("Jail", searchPlayer.SteamID+"positionY");
	var positionZ = DataStore.Get("Jail", searchPlayer.SteamID+"positionZ");
	if (positionY != null || positionX != undefined)
	{
		searchPlayer.TeleportTo(positionX, positionY, positionZ);
		searchPlayer.Message("You are free and have been teleported back to your orginal position!");
	}
	else
	{
		//Server.Broadcast("Previous position has not been set!");
	}	
}

function checkJail()
{
	for (var pl in Server.Players)
    {
    	var jail = DataStore.Get("Jail", pl.SteamID+"jail");
    	if (jail == "true")
    	{
    		var x = DataStore.Get("Jail", "JailX");
			var y = DataStore.Get("Jail", "JailY");
			var z = DataStore.Get("Jail", "JailZ");

			var a = Util.CreateVector(x, y, z);
    		var b = Util.CreateVector(pl.X, pl.Y, pl.Z);

    		var radius = parseInt(DataStore.Get("Jail", "JailRadius"));
    		var distance = parseInt(Util.GetVectorsDistance(a, b));

    		var jaillength = parseInt(DataStore.Get("Jail", pl.SteamID+"jaillength"));
    		var jailtime = parseInt(DataStore.Get("Jail", pl.SteamID+"jailtime"));
    		var time = System.DateTime.Now/1000;


    		if (time > jailtime + jaillength)
    		{
    			var positionX = DataStore.Get("Jail", pl.SteamID+"positionX");
				var positionY = DataStore.Get("Jail", pl.SteamID+"positionY");
				var positionZ = DataStore.Get("Jail", pl.SteamID+"positionZ");
				if (positionY != null || positionX != undefined)
				{
					pl.TeleportTo(positionX, positionY, positionZ);
					//pl.Message("You are free and have been teleported back to your orginal position!");
					DataStore.Add("Jail", pl.SteamID+"jailmute", "false");
					DataStore.Add("Jail", pl.SteamID+"jail", "false");
					DataStore.Add("Jail", pl.SteamID+"jaillength", "0");
				}
    		}

    		//pl.Message("jail:" + a + " player:" + b + " radius:" + radius + " distance:" + distance);
			if (distance > radius)
			{
				//pl.Message("You were sent back to jail and jail time has been reset! Don't try to escape!!!");
				sendToJail(pl, jaillength);
			}
    	}
    }
}

function isCop(Player)
{
	var ini = getIni();
	var cop = ini.GetSetting("Jail", Player.SteamID+"cop");
	if (cop)
		return true;
	else
		return false;
}

function addCop(Player)
{
	var ini = getIni();
	ini.AddSetting("Jail", Player.SteamID+"cop", true);
	ini.Save();
}



/*
Updates for version 1.5
Fixed problem where players can be killed when logging out
Added option to cfg to keep counter going while logged out (false by default)
Added time to /checkjail username
Added command /changejailtime
Added command /jaillist

Updates for version 1.6
Added /cops to view all cops
Added option to add non-admin players as cops
Added /killplayer "username". Kills player, and sends them back to jail afterwards
Fixed a problem with DataStore and Jail Coors as Vector
*/