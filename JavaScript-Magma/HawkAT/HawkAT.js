/*
 * EternalAdmin - Hawk Admin Tool - 1.2.2.1
 * 
 * Developed by closerto
 * #FreeAssange #FreeAnakata #Kopimi
*/


function Hawk_UpdateLogs(File, Type, Section, Player, Content)
{
	var Ini		= Plugin.GetIni(File);
	var LogDate	= "[" + Plugin.GetDate() + " " + Plugin.GetTime() + "] ";
	var Value	= "";

	switch (Type)
	{
		case "Players":
		case "Report":
			Value = Value + Player.Name + " | " + Player.SteamID + " | " + Player.IP;
			break;

		case "Chat":
		case "Command":
			Value = Value + Player.Name + " : " + Content;
			break;
			
		case "Death":
			var Dx = Content.Attacker.X - Content.Victim.X;
			var Dz = Content.Attacker.Z - Content.Victim.Z;
			var Distance = Math.round(Math.sqrt((Dx*Dx) + (Dz*Dz)));
			Value = Value + Content.Attacker.Name + " ⊕ " + Player.Name + " (" + Content.DamageType + " → ";
			if (Content.DamageAmount == "Infinity")
				Value = Value + "Suicide)";
			else
			{
				Value = Value + Math.round(Content.DamageAmount) + "HP)";
				if (Content.Attacker.SteamID && ((Content.DamageType == "Melee") || (Content.DamageType == "Bullet")))
					Value = Value + " (" + Content.WeaponName + " → " + Distance + "M)";
			}
			break;
	}
	
	Ini.AddSetting(Section, LogDate + Value);
	Ini.Save();
	
	return (Value);
}


function Hawk_GetUsers(File, Type, Section, Player)
{
	var Ini		= Plugin.GetIni(File);
	var Content	= "";
	var EnumSection;
	
	if (Type == "Level")
	{
		EnumSection = Ini.EnumSection("Administrators");
		for (var Setting in EnumSection)
			if (Setting == (Player.SteamID + " "))
				return (2);

		EnumSection = Ini.EnumSection("Moderators");
		for (var Setting in EnumSection)
			if (Setting == (Player.SteamID + " "))
				return (1);
	}
	else if (Type == "Permissions")
	{
		EnumSection	= Ini.EnumSection(Section);
		for (var Setting in EnumSection)
			Content = Content + Ini.GetSetting(Section, Setting) + ",";
		return (Content);
	}
	else if (Type == "Banned")
	{
		EnumSection = Ini.EnumSection(Section);
		for (var Setting in EnumSection)
		{
			Content = Ini.GetSetting(Section, Setting);
			if (Setting == (Player.SteamID + " ") || Content.Contains(Player.IP))
				return (1);
		}
	}
	else if (Type == "Flag")
	{
		EnumSection = Ini.EnumSection(Section);
		for (var Setting in EnumSection)
			if (Setting == (Player.SteamID + " "))
				return (1);
	}
	return (0);
}


function Hawk_UpdateUsers(File, Type, Section, Player)
{
	var Ini		= Plugin.GetIni(File);
	var Setting	= "";
	var Value	= "";
	
	if ((Type.indexOf("adm") > -1) || (Type.indexOf("mod") > -1) || (Type.indexOf("god") > -1) || (Type.indexOf("doors") > -1))
	{
		Setting = Player.SteamID + " ";
		Value = " " + Player.Name;
	}
	else if (Type.indexOf("ban") > -1)
	{
		Setting = Player.SteamID + " ";
		Value = " " + Player.Name + " | " + Player.IP;
	}
	
	if (Type.charAt(1) == "s")
		Ini.AddSetting(Section, Setting, Value);
	else
		Ini.DeleteSetting(Section, Setting);

	Ini.Save();
}


function Hawk_CheckRNP(Ctbp, NeededLevel, Player, Arguments)
{
	var Level = Hawk_GetUsers("users/permissions", "Level", 0, Player);
	var Target;
	
	if ((Level >= NeededLevel) || Player.Admin)
	{
		if (Arguments.Length != 0)
		{
			var Nickname = "";
			for (var i = 0; i < Arguments.Length; i++)
			{
				Nickname = (i == (Arguments.Length - 1)) ? Nickname + Arguments[i] : Nickname + Arguments[i] + " ";
			}
			if ((Target = Magma.Player.FindByName(Nickname)))
				return (Target);
			else
			{
				Player.MessageFrom("EternalAdmin",  Nickname + " : Player not found.");
				return (0);
			}
		}
		else
		{
			if (Ctbp)
				return (Player);
			else
			{
				Player.MessageFrom("EternalAdmin", "You can't be the target of this command.");
				return (0);
			}
		}
	}
	else
	{
		Player.MessageFrom("EternalAdmin", "You don't have access to this command.");
		return (0);
	}
}


function Hawk_GetConnections(Type, Player)
{
	if (Type == "Connected")
	{
		if (Player.Name == "")
		{
			Player.MessageFrom("EternalAdmin", "You have been auto-kicked from this server.");
			Player.Notice("☢", "You have been kicked.", 8);
			Player.Disconnect();
			Server.BroadcastFrom("EternalAdmin", Player.Name + " has been auto-kicked.");
		}
		else if (Hawk_GetUsers("users/bans", "Banned", "Bans", Player))
		{
			Player.MessageFrom("EternalAdmin", "You are banned from this server.");
			Player.Notice("☢", "You are banned.", 8);
			Player.Disconnect();
			Server.BroadcastFrom("EternalAdmin", Player.Name + " tried to join, but he's banned.");
		}
		else
		{
			return (1);
		}
	}
	else if (Type == "Disconnected")
	{
		if ((!Hawk_GetUsers("users/bans", "Banned", "Bans", Player)) && Player.Name != "")
		{
			return (1);
		}
	}
}


function Hawk_GetCheaters(Type, Player, Content)
{
	if (Type == "Hurt")
	{
		var Dx			= Content.Attacker.X - Content.Victim.X;
		var Dz			= Content.Attacker.Z - Content.Victim.Z;
		var Distance	= Math.round(Math.sqrt((Dx*Dx) + (Dz*Dz)));
		var MaxDistance	= Distance;
		var Damage		= Math.round(Content.DamageAmount);
		var MaxDamage	= Damage;
		
		switch (Content.WeaponName)
		{
			case "M4":
				MaxDistance = 141;
				MaxDamage	= 120;
				break;
			case "Shotgun":
				MaxDistance = 31;
				MaxDamage	= 45;
				break;
			case "P250":
				MaxDistance = 121;
				MaxDamage	= 105;
				break;
		}
		
		if (Distance > MaxDistance)
			return (1);
		else if (Damage > MaxDamage)
			return (2);
		else
			return (0);
	}
	else if (Type == "Speed")
	{
		
	}
}


function Hawk_SpyCallback(Params)
{
	var X = parseInt(Params.Get(1).X);
	var Y = parseInt(Params.Get(1).Y);
	var Z = parseInt(Params.Get(1).Z);
	
	Params.Get(0).Message("Location : " + X + " ; " + Y + " ; " + Z);
}


function On_Command(Player, Command, Arguments) // EternalAdmin's heart
{
	if (Command.charAt(0) == "h")
	{
		Hawk_UpdateLogs("logs/commands", "Command", "Commands", Player, Command);
		
		switch (Command)
		{
			case "hhelp":
				var Level = Hawk_GetUsers("users/permissions", "Level", 0, Player);
				Player.MessageFrom("EternalAdmin", "Commands : /hhelp, /hadmins, /hmods, /hreport" + ((Level > 0) ? ", /h<s|u>ban, /h<s|u>god, /hkick, /hpunish" : ""));
				break;

			case "hadmins":
				var Content = Hawk_GetUsers("users/permissions", "Permissions", "Administrators", Player);
				Player.MessageFrom("EternalAdmin", "Administrators :" + Content.substr(0, Content.length - 1));
				break;

			case "hmods":
				var Content = Hawk_GetUsers("users/permissions", "Permissions", "Moderators", Player);
				Player.MessageFrom("EternalAdmin", "Moderators :" + Content.substr(0, Content.length - 1));
				break;

			case "hsadm":
			case "huadm":
				var Target = Hawk_CheckRNP(1, 2, Player, Arguments);
				if (Target.SteamID)
				{
					Hawk_UpdateUsers("users/permissions", Command, "Administrators", Target);
					if (Command == "hsadm")
						Server.BroadcastFrom("EternalAdmin", Target.Name + " has been granted to Administrators by " + Player.Name + ".");
					else
						Server.BroadcastFrom("EternalAdmin", Target.Name + " is not an administrator anymore.");
				}
				break;
			
			case "hsmod":
			case "humod":
				var Target = Hawk_CheckRNP(1, 2, Player, Arguments);
				if (Target.SteamID)
				{
					Hawk_UpdateUsers("users/permissions", Command, "Moderators", Target);
					if (Command == "hsmod")
						Server.BroadcastFrom("EternalAdmin", Target.Name + " has been granted to Moderators by " + Player.Name + ".");
					else
						Server.BroadcastFrom("EternalAdmin", Target.Name + " is not a moderator anymore.");
				}
				break;
			
			case "hsban":
			case "huban":
				var Target = Hawk_CheckRNP(0, 1, Player, Arguments);
				if (Target.SteamID)
				{
					Hawk_UpdateUsers("users/bans", Command, "Bans", Target);
					if (Command == "hsban")
					{
						Target.MessageFrom("EternalAdmin", "You have been banned from this server.");
						Target.Kill();
						Target.Disconnect();
						Server.BroadcastFrom("EternalAdmin", Target.Name + " has been banned by " + Player.Name + ".");
					}
					else
						Server.BroadcastFrom("EternalAdmin", Target.Name + " is not banned anymore.");
				}
				break;
			
			case "hsgod":
			case "hugod":
				var Target = Hawk_CheckRNP(1, 1, Player, Arguments);
				if (Target.SteamID)
				{
					Hawk_UpdateUsers("users/permissions", Command, "GodMode", Target);
					if (Command == "hsgod")
						Server.BroadcastFrom("EternalAdmin", Target.Name + " is now in godmode.");
					else
						Server.BroadcastFrom("EternalAdmin", Target.Name + " is not in godmode anymore.");
				}
				break;
				
			case "hsdoors":
			case "hudoors":
				var Target = Hawk_CheckRNP(1, 2, Player, Arguments);
				if (Target.SteamID)
				{
					Hawk_UpdateUsers("users/permissions", Command, "AdminDoors", Target);
					if (Command == "hsdoors")
						Server.BroadcastFrom("EternalAdmin", Target.Name + " can now open every doors.");
					else
						Server.BroadcastFrom("EternalAdmin", Target.Name + " can not open every doors anymore.");
				}
				break;
			
			case "hsarmor":
			case "huarmor":
				var Target = Hawk_CheckRNP(1, 2, Player, Arguments);
				if (Target.SteamID)
				{
					if (Command == "hsarmor")
					{
						Target.Inventory.ClearArmor();
						Target.Inventory.AddItemTo("Invisible Helmet", 36);
						Target.Inventory.AddItemTo("Invisible Vest", 37);
						Target.Inventory.AddItemTo("Invisible Pants", 38);
						Target.Inventory.AddItemTo("Invisible Boots", 39);
						// Server.BroadcastFrom("EternalAdmin", Target.Name + " is now invisible.");
					}
					else
					{
						Target.Inventory.ClearArmor();
						// Server.BroadcastFrom("EternalAdmin", Target.Name + " is not invisible anymore.");
					}
				}
				break;
				
			case "hsspy":
				var Target = Hawk_CheckRNP(0, 1, Player, Arguments);
				if (Target.SteamID)
				{
					var Params = new ParamsList();
						Params.Add(Player);
						Params.Add(Target);
					Plugin.CreateTimer("Hawk_Spy", 500, Params).Start();
				}
				break;
				
			case "huspy":
				var Level = Hawk_GetUsers("users/permissions", "Level", 0, Player);
				if (Level > 0)
				{
					Plugin.KillTimer("Hawk_Spy");
				}
				break;
			
			case "hreport":
				var Target = Hawk_CheckRNP(0, 0, Player, Arguments);
				if (Target.SteamID)
				{
					Hawk_UpdateLogs("logs/reports", "Report", "Reports", Target, 0);
					Server.BroadcastFrom("EternalAdmin", Target.Name + " has been reported to admins by " + Player.Name + ".");
				}
				break;
	
			case "hkick":
				var Target = Hawk_CheckRNP(0, 1, Player, Arguments);
				if (Target.SteamID)
				{
					Target.MessageFrom("EternalAdmin", "You have been kicked from this server.");
					Target.Notice("☢", "You have been kicked.", 8);
					Target.Disconnect();
					Server.BroadcastFrom("EternalAdmin", Target.Name + " has been kicked by " + Player.Name + ".");
				}
				break;
			
			case "hkill":
				var Target = Hawk_CheckRNP(1, 2, Player, Arguments);
				if (Target.SteamID)
				{
					Target.MessageFrom("EternalAdmin", "You have been killed by an admin.");
					Target.Kill();
					Server.BroadcastFrom("EternalAdmin", Target.Name + " has been killed by " + Player.Name + ".");
				}
				break;
			
			case "hinfos":
				var Target = Hawk_CheckRNP(1, 1, Player, Arguments);
				if (Target.SteamID)
				{
					Player.MessageFrom("EternalAdmin", "Location  :  " + parseInt(Target.X) + " ; " + parseInt(Target.Y) + " ; " + parseInt(Target.Z));
					Player.MessageFrom("EternalAdmin", "Health       :  " + parseInt(Target.Health) + "HP");
					Player.MessageFrom("EternalAdmin", "Ping           :  " + Target.Ping);
					Player.MessageFrom("EternalAdmin", "SteamID   :  " + Target.SteamID);
					Player.MessageFrom("EternalAdmin", "IP                :  " + Target.IP);
				}
				break;
				
			case "hairdrop":
				var Level = Hawk_GetUsers("users/permissions", "Level", 0, Player);
				if (Level > 0)
				{
					World.Airdrop();
					Server.BroadcastFrom("EternalAdmin", "Airdrop is on the way !");
				}
				break;
				
			case "hairdropon":
				var Target = Hawk_CheckRNP(1, 2, Player, Arguments);
				if (Target.SteamID)
				{
					World.AirdropAtPlayer(Target);
				}
				break;
			
			case "hpunish":
				var Target = Hawk_CheckRNP(0, 1, Player, Arguments);
				if (Target.SteamID)
				{
					World.Spawn(":wolf_prefab", Target.X, Target.Y, Target.Z, 7);
					Server.BroadcastFrom("EternalAdmin", Target.Name + " has been punished by " + Player.Name + ". Wolves are on him !");
				}
				break;
			
			default:
				Player.MessageFrom("EternalAdmin", "This command doesn't exist, type /hhelp");
		}
	}
}


function On_DoorUse(Player, DoorEvent)
{
	if (Hawk_GetUsers("users/permissions", "Flag", "AdminDoors", Player)) // Is godmode on ?
	{
		DoorEvent.Open = true;
	}
}

function On_PlayerHurt(HurtEvent) // Checks godmode, checks distance and damage
{
	var Cheater = Hawk_Cheaters("Hurt", HurtEvent.Attacker, HurtEvent);
	if (Cheater)
	{
		HurtEvent.Victim.IsBleeding = 0;
		HurtEvent.DamageAmount		= 0;
		
		Hawk_UpdateUsers("users/bans", "hsban", "Bans", HurtEvent.Attacker);
		HurtEvent.Attacker.MessageFrom("EternalAdmin", "You have been banned from this server.");
		HurtEvent.Attacker.Kill();
		HurtEvent.Attacker.Disconnect();
		Server.BroadcastFrom("EternalAdmin", HurtEvent.Attacker.Name + " has been auto-banned by the server.");
		
		switch (Cheater)
		{
			case 1:
				Server.BroadcastFrom("EternalAdmin", "Reason : Hit distance is too long !");
				break;
			case 2:
				Server.BroadcastFrom("EternalAdmin", "Reason : Hit damage is too high !");
				break;
		}
	}
	
	if (Hawk_GetUsers("users/permissions", "Flag", "GodMode", HurtEvent.Victim)) // Is godmode on ?
	{
		HurtEvent.Victim.IsBleeding = 0;
		HurtEvent.DamageAmount		= 0;
	}
}


function On_PlayerKilled(DeathEvent)
{
	var Notification;
	
	if (DeathEvent.Attacker.SteamID)
		Notification = Hawk_UpdateLogs("logs/deaths", "Death", "Players", DeathEvent.Victim, DeathEvent);
	else
		Notification = Hawk_UpdateLogs("logs/deaths", "Death", "Animals", DeathEvent.Victim, DeathEvent);
	Server.BroadcastFrom("EternalAdmin", Notification);
}


function On_PlayerConnected(Player)
{
	if (Hawk_GetConnections("Connected", Player))
	{
		Server.BroadcastFrom("EternalAdmin", Player.Name + " has joined the server.");
		Hawk_UpdateLogs("logs/players", "Players", "Joined", Player, 0);
	}
}


function On_PlayerDisconnected(Player)
{
	if (Hawk_GetConnections("Disconnected", Player))
	{
		Server.BroadcastFrom("EternalAdmin", Player.Name + " has left the server.");
		Hawk_UpdateLogs("logs/players", "Players", "Left", Player, 0);
	}
}


function On_Chat(Player, Text)
{
	Hawk_UpdateLogs("logs/chat", "Chat", "Chat", Player, Text);
}

