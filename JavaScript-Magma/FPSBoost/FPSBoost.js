/**
 * Created by DreTaX on 2014.05.04.. V1.3
 */
 function On_Command(Player, cmd, args) {
	if (cmd == "graph") {
		//var name = Data.GetConfigValue("FPSBoost", "Settings", "name");
		//var cooldown = Data.GetConfigValue("FPSBoost", "Settings", "cd");
		var config = FPSBOOST();
		var name = config.GetSetting("Settings", "name");
		var cooldown = config.GetSetting("Settings", "cd");
		var time = DataStore.Get("FPSBoost", Player.SteamID);
		if (cooldown > 0) {
			var calc = System.Environment.TickCount - time;
			if (time == undefined || time == null || calc < 0 || isNaN(calc)) {
				time = DataStore.Add("FPSBoost", Player.SteamID, System.Environment.TickCount);
			}
			if (calc >= cooldown) {
				DataStore.Add("FPSBoost", Player.SteamID, System.Environment.TickCount);
				Player.SendCommand("grass.on true");
				Player.SendCommand("grass.forceredraw true");
				Player.SendCommand("grass.displacement false");
				Player.SendCommand("grass.disp_trail_seconds 10");
				Player.SendCommand("grass.shadowcast true");
				Player.SendCommand("grass.shadowreceive true");
				Player.SendCommand("render.level 1");
				Player.SendCommand("render.vsync true");
				Player.SendCommand("footsteps.quality 2");
				Player.SendCommand("gfx.grain true");
				Player.SendCommand("gfx.ssao true");
				Player.SendCommand("gfx.shafts true");
				Player.SendCommand("gfx.damage true");
				Player.SendCommand("gfx.tonemap true");
				Player.SendCommand("gfx.ssaa true");
				Player.SendCommand("gfx.bloom true");
				Player.MessageFrom(name, "You Switched to Graphics Mode!");
			}
			else {
				Player.Notice("You have to wait before typing it again!");
				var next = calc / 1000;
				next = next / 60;
				var def = cooldown / 1000;
				def = def / 60;
				var done = Number(next).toFixed(2); 
				var done2 = Number(def).toFixed(2); 
				Player.MessageFrom(name, "Time Remaining: " + done + "/" + done2);
			}
		}
		else {
			Player.SendCommand("grass.on true");
			Player.SendCommand("grass.forceredraw true");
			Player.SendCommand("grass.displacement false");
			Player.SendCommand("grass.disp_trail_seconds 10");
			Player.SendCommand("grass.shadowcast true");
			Player.SendCommand("grass.shadowreceive true");
			Player.SendCommand("render.level 1");
			Player.SendCommand("render.vsync true");
			Player.SendCommand("footsteps.quality 2");
			Player.SendCommand("gfx.grain true");
			Player.SendCommand("gfx.ssao true");
			Player.SendCommand("gfx.shafts true");
			Player.SendCommand("gfx.damage true");
			Player.SendCommand("gfx.tonemap true");
			Player.SendCommand("gfx.ssaa true");
			Player.SendCommand("gfx.bloom true");
			Player.MessageFrom(name, "You Switched to Graphics Mode!");
		}
	}
	else if (cmd == "fps") {
		/*var name = Data.GetConfigValue("FPSBoost", "Settings", "name");
		var cooldown = Data.GetConfigValue("FPSBoost", "Settings", "cd");
		var time = Data.GetTableValue("FPSBoost", Player.SteamID);*/
		var config = FPSBOOST();
		var name = config.GetSetting("Settings", "name");
		var cooldown = config.GetSetting("Settings", "cd");
		var time = DataStore.Get("FPSBoost", Player.SteamID);
		if (cooldown > 0) {
			var calc = System.Environment.TickCount - time;
			if (time == undefined || time == null || calc < 0 || isNaN(calc)) {
				time = DataStore.Add("FPSBoost", Player.SteamID, System.Environment.TickCount);
			}
			if (calc >= cooldown) {
				DataStore.Add("FPSBoost", Player.SteamID, System.Environment.TickCount);
				Player.SendCommand("grass.on false");
				Player.SendCommand("grass.forceredraw False");
				Player.SendCommand("grass.displacement True");
				Player.SendCommand("grass.disp_trail_seconds 0");
				Player.SendCommand("grass.shadowcast False");
				Player.SendCommand("grass.shadowreceive False");
				Player.SendCommand("render.level 0");
				Player.SendCommand("render.vsync False");
				Player.SendCommand("footsteps.quality 2");
				Player.SendCommand("gfx.grain False");
				Player.SendCommand("gfx.ssao False");
				Player.SendCommand("gfx.shafts false");
				Player.SendCommand("gfx.damage false");
				Player.SendCommand("gfx.ssaa False");
				Player.SendCommand("gfx.bloom False");
				Player.SendCommand("gfx.tonemap False");
				Player.MessageFrom(name, "You Switched to FPS Mode!");
			}
			else {
				Player.Notice("You have to wait before typing it again!");
				var next = calc / 1000;
				next = next / 60;
				var def = cooldown / 1000;
				def = def / 60;
				var done = Number(next).toFixed(2); 
				var done2 = Number(def).toFixed(2); 
				Player.MessageFrom(name, "Time Remaining: " + done + "/" + done2);
			}
		}
		else {
			Player.SendCommand("grass.on false");
			Player.SendCommand("grass.forceredraw False");
			Player.SendCommand("grass.displacement True");
			Player.SendCommand("grass.disp_trail_seconds 0");
			Player.SendCommand("grass.shadowcast False");
			Player.SendCommand("grass.shadowreceive False");
			Player.SendCommand("render.level 0");
			Player.SendCommand("render.vsync False");
			Player.SendCommand("footsteps.quality 2");
			Player.SendCommand("gfx.grain False");
			Player.SendCommand("gfx.ssao False");
			Player.SendCommand("gfx.shafts false");
			Player.SendCommand("gfx.damage false");
			Player.SendCommand("gfx.ssaa False");
			Player.SendCommand("gfx.bloom False");
			Player.SendCommand("gfx.tonemap False");
			Player.MessageFrom(name, "You Switched to FPS Mode!");
		}
	}
}

function On_PlayerConnected(Player) {
	//var name = Data.GetConfigValue("FPSBoost", "Settings", "name");
	var config = FPSBOOST();
	var name = config.GetSetting("Settings", "name");
	Player.MessageFrom(name, "Type /fps to increase /graph to decrease your fps.");
}

function FPSBOOST(){
    if(!Plugin.IniExists("FPSBOOST")) {
        var FPSBOOST = Plugin.CreateIni("FPSBOOST");
        FPSBOOST.Save();
    }
    return Plugin.GetIni("FPSBOOST");
}