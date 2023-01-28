function On_Command(Player, cmd, args){
	try {
		if(cmd == "hacktest"){
			if (args[0] != false){
				if (Users.GetRank(Player.SteamID) > 1){
					var hack = Magma.Player.FindByName(args[0]);
					Data.AddTableValue("hack", hack.Name, hack.Health);
					Data.AddTableValue("hack", "name", hack.Name);
					Data.AddTableValue("hack", "nameP", Player.Name);
					hack.TeleportTo(hack.X, hack.Y + 10, hack.Z);
					Plugin.CreateTimer("hack", 1000 * 3).Start();
				}
			}
		}
	    } catch (err) {
        Plugin.Log("mlog", "Exception Message: " + err.message + " on On_Command");
        Plugin.Log("mlog", "Exception Description: " + err.description + " On_Command");
    }
}

function hackCallback(){
try {
	var hackname = Data.GetTableValue("hack", "name");
	var hack = Magma.Player.FindByName(hackname);
	var pname = Data.GetTableValue("hack", "nameP");
	var PN = Magma.Player.FindByName(pname);
	var hp = Data.GetTableValue("hack", hack.Name);
		if (hp > hack.Health){
			PN.Notice("Проверка пройдена");
		} else {
			PN.Notice(hack.Name + " использует no fall damage");
		}
	Plugin.KillTimer("hack");
    } catch (err) {
        Plugin.Log("elog", "Exception Message: " + err.message + " on pauseCallback");
        Plugin.Log("elog", "Exception Description: " + err.description + " on pauseCallback");
    }
}
