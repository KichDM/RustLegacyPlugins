//Title: Multi-Home-System
//Author: Simba (forked from Home by Henrique Seifarth)
//Version 1.0
//Description: Save multiply home locations

function On_Command(Player, cmd, args) {
	switch(cmd) {
		case "home":
			Player.Message("Mult-Home System: Max " + Data.GetConfigValue("Home", "Home", "max") +" Location - 30 sec Cooldown");
			Player.Message("/sethome name - saves location");
			Player.Message("/gohome name - teleports to that saved location");
			Player.Message("/removehome name - removes that saved location");
			Player.Message("/myhome - shows a list of your saved locations");
			Player.Message("/abouthome - info about Multi-Home System");
		break;
		case "abouthome":
			Player.Message("Multi-Home-System Version 1.0");
			Player.Message("This plugin was modified by Simba");
			Player.Message("The original plugin was Home by Henrique Seifarth");
		break;
		case "sethome":
			if (args.Length > 0){
				var name = argsToText(args);
				var h = getHouseIni();
				var count = 0;
				var hList = h.EnumSection(Player.SteamID);
				if (hList.Length == Data.GetConfigValue("Home", "Home", "max")){
					Player.Message("You have maxed out the # of locations saved");
				}else{
					h.AddSetting(Player.SteamID, name, Player.Location.toString());
					h.Save();
					Player.Message("Location saved!");
				}
			}else {
				Player.Message("Home System");
				Player.Message("Use \"/sethome name to store the coordinates of your house.");
			}
		break;
		case "gohome":
			if (args.Length > 0){
				var name = argsToText(args);
				var coords = GetHome(name, Player);
				if (coords == 0){
					Player.Message("Invalid Name. check /myhome");	
				}
				else {
					var waittime = Data.GetConfigValue("Home", "Home", "cooldown");
					var time = Data.GetTableValue("HomeColldown", Player.SteamID);
					if (time == null) {
						time = 0;
					}
					var calc = System.Environment.TickCount - time;
					if (calc >= waittime) {
						Player.TeleportTo(coords[0], coords[1], coords[2]);
						Data.AddTableValue("HomeColldown", Player.SteamID, System.Environment.TickCount);
						Player.Message("Home Sweet Home");
					}
					else
					{
						Player.Message("You must wait to do this action again!"); 
					}
				}
			}else{
				Player.Message("Syntax: /gohome name");
			}
		break;
		case "removehome":
			if (args.Length > 0){
				var name = argsToText(args);
				RemoveHome(name, Player, Player.Location);
			}else{
				Player.Message("Syntax: /removehome name");
			}
		break;
		case "myhome":
			var home = getHouseIni();
			var homeList = home.EnumSection(Player.SteamID);
			var myHomes = "";
			var index = 0;
			for (var house in homeList){
				if (index != homeList.Length -1){
					myHomes += house + ", ";
				}else{
					myHomes += house;
				}
				index++;
			}
			Player.Message("Your Home Locations: " + myHomes );
		break;	
	}
}
function getHouseIni(){
	if(!Plugin.IniExists("MyHome")){
		var h = Plugin.CreateIni("MyHome");
		h.Save();
	}
	return Plugin.GetIni("MyHome");
}

function RemoveHome(name, Player, coords){
	var h = getHouseIni();
	if (h.GetSetting(Player.SteamID, name) != null){
		h.DeleteSetting(Player.SteamID, name);
		h.Save();
		Player.Message("Location: " + name + " Deleted");
	}else{
		Player.Message("Location name doesn't exists! check your list /myhome");
	}
}

function GetHome(name, Player){
		var h = getHouseIni();
		if (h.GetSetting(Player.SteamID, name) != null){
			var myHome = h.GetSetting(Player.SteamID, name);
			myHome = myHome.replace("(", "");
			myHome = myHome.replace(")", "");
			return myHome.split(",");
		}
		return 0;
}


//correct the cooldown
function On_PlayerConnected(Player) {
    Data.AddTableValue("HomeColldown", Player.SteamID, System.Environment.TickCount);
}

function On_PlayerDisconnected(Player) {
    Data.AddTableValue("HomeColldown", Player.SteamID, System.Environment.TickCount);
}

function argsToText(args){
	var text = "";
	if (args.Length == 1 ){
		text = args[0];
	}else{
		for (var l = 0; l < args.Length; l++){
			if (l == args.Length - 1){
				text += args[l];
			}else {
				text += args[l] + " ";
			}
		}
	}
	return text;
}