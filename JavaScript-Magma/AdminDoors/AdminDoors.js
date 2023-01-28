function On_DoorUse(Player, DoorUseEvent)
{
	if(Player.Admin || allowed(Player))
	{
		if(toggled(Player))
		{
			DoorUseEvent.Open= true;
		}
	}
}

function On_Command(Player, cmd, args)
{
	if(Data.ToLower(cmd) == "admindoors" || Data.ToLower(cmd) == "ad")
	{
		if(args.Length <= 0)
		{
			if((Player.Admin || allowed(Player)) && Data.ToLower(cmd) != "ad")
			{
				Player.MessageFrom("AdminDoors", "/AdminDoors Allow  -  /AdminDoors UnAllow  -  /AdminDoors Toggle  -  /AdminDoors Info");
				Player.MessageFrom("AdminDoors", "/AD can also be used.");
			}
			else
			{
				Player.MessageFrom("AdminDoors", "/AD Allow  -  /AD UnAllow  -  /AD toggle  -  /AD Info");
				Player.MessageFrom("AdminDoors", "/AdminDoors can also be used.");
			}
		}
		if(Data.ToLower(args[0]) == "allow")
		{
			if(Player.Admin || allowed(Player))
			{
				if(args.Length == 1)
				{
					Player.MessageFrom("AdminDoors", "/AdminDoors Allow <PlayerName>");
					return;
				}
				if(args.Length == 2)
				{
					var targetByArgs = args[1];
				}
				if(args.Length == 3)
				{
					var targetByArgs = args[1] + " " + args[2];
				}
				if(args.Length == 4)
				{
					var targetByArgs = args[1] + " " + args[2] + " " + args[3];
				}
				if(args.Length == 5)
				{
					var targetByArgs = args[1] + " " + args[2] + " " + args[3] + " " + args[4];
				}
				if(args.Length == 6)
				{
					var targetByArgs = args[1] + " " + args[2] + " " + args[3] + " " + args[4] + " " + args[5];
				}
				var target = Magma.Player.FindByName(targetByArgs);
				if(target == null)
				{
					Player.MessageFrom("AdminDoors", targetByArgs + " was not found.");
				}
				else
				{
					if(allowed(target) == false)
					{
						allow(target, Player);
						Player.MessageFrom("AdminDoors", target.Name + " can now use all doors!");
						target.MessageFrom("AdminDoors", Player.Name + " allowed you to use all doors!");
					}
					else
					{
						Player.MessageFrom("AdminDoors", target.Name + " was allowed, nothing has been changed.");
					}
				}
				
			}
			else
			{
				Player.MessageFrom("AdminDoors", "You do not have permission for this.");
			}
		}
		if(Data.ToLower(args[0]) == "unallow")
		{
			if(Player.Admin || allowed(Player))
			{
				if(args.Length == 1)
				{
					Player.MessageFrom("AdminDoors", "/AdminDoors UnAllow <PlayerName>");
					return;
				}
				if(args.Length == 2)
				{
					var targetByArgs = args[1];
				}
				if(args.Length == 3)
				{
					var targetByArgs = args[1] + " " + args[2];
				}
				if(args.Length == 4)
				{
					var targetByArgs = args[1] + " " + args[2] + " " + args[3];
				}
				if(args.Length == 5)
				{
					var targetByArgs = args[1] + " " + args[2] + " " + args[3] + " " + args[4];
				}
				if(args.Length == 6)
				{
					var targetByArgs = args[1] + " " + args[2] + " " + args[3] + " " + args[4] + " " + args[5];
				}
				var target = Magma.Player.FindByName(targetByArgs);
				if(target == null)
				{
					Player.MessageFrom("AdminDoors", targetByArgs + " was not found.");
				}
				else
				{
					if(allowed(target))
					{
						unAllow(target);
						Player.MessageFrom("AdminDoors", target.Name + " can no longer use all doors!");
						target.MessageFrom("AdminDoors", Player.Name + " took your powers to open all doors!");
					}
					else
					{
						Player.MessageFrom("AdminDoors", target.Name + " was not allowed, nothing has been changed.");
					}
				}
				
			}
			else
			{
				Player.MessageFrom("AdminDoors", "You do not have permission for this.");
			}
		}
		if(Data.ToLower(args[0]) == "toggle")
		{
			if(Player.Admin || allowed(Player))
			{
				toggle(Player);
			}
			else
			{
				Player.MessageFrom("AdminDoors", "You do not have permission for this.");
			}
		}
		if(Data.ToLower(args[0]) == "info")
		{
			Player.MessageFrom("AdminDoors", "Plugin version 3.0 by EternalxFear.");
		}
	}
}

function allowed(target)
{
	var ini = Plugin.GetIni("allowed");
	if(!Plugin.IniExists("allowed"))
	{
		Plugin.CreateIni("allowed");
		Server.BroadcastFrom("AdminDoors", "Generated a save file.");
	}
	if(ini.GetSetting("Players", target.SteamID) != null)
	{
		return true;
	}
	else
	{
		return false;
	}
}

function allow(target, allowedBy)
{
	var ini = Plugin.GetIni("allowed");
	ini.AddSetting("Players", target.SteamID, target.Name + " was allowed by " + allowedBy.Name);
	ini.Save();
	toggle(target);
}

function unAllow(target)
{
	var ini = Plugin.GetIni("allowed");
	var ini2 = Plugin.GetIni("toggled");
	ini.DeleteSetting("Players", target.SteamID);
	ini.DeleteSetting("Players", target.SteamID);
	ini.Save();
	ini2.Save();
}

function toggle(target)
{
	if(!Plugin.IniExists("toggled"))
	{
		Plugin.CreateIni("toggled");
		Server.BroadcastFrom("AdminDoors", "Generated a toggle file.");
	}
	var ini = Plugin.GetIni("toggled");
	if(ini.GetSetting("Players", target.SteamID) == null)
	{
		ini.AddSetting("Players", target.SteamID, target.Name);
		target.MessageFrom("AdminDoors", "Toggled on!");
		ini.Save();
	}
	else
	{
		ini.DeleteSetting("Players", target.SteamID);
		target.MessageFrom("AdminDoors", "Toggled off!");
		ini.Save();
	}
}

function toggled(target)
{
	var ini = Plugin.GetIni("toggled");
	if(ini.GetSetting("Players", target.SteamID) != null)
	{
		return true;
	}
	else
	{
		return false;
	}
}