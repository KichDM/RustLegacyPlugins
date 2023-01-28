//Created by Apihl1000

function On_PlayerConnected(Player)
{
    var Admin_names =  Data.GetConfigValue("NoNameStealing", "Config", "protect_name_on");
    var name = Player.Name;
    var id = Player.SteamID;
    var allowed = Data.GetConfigValue("NoNameStealing", "Config", "allowed");
    
    /* Kick Name Stealers*/
    if (Admin_names == "True") {
	var numadmins = Data.GetConfigValue("NoNameStealing", "Config", "numadmins");
	for (var x = 1; x <= numstaffs; x++) {
	    if (name == Data.GetConfigValue("NoNameStealing", "Admins", "name" + x) && id != Data.GetConfigValue("NoNameStealing", "Admins", "id" + x)) {
		Player.Message("That name is reserved, please change it.");
		Server.Broadcast(name + " has been disconnected because of reserved name.");
		Player.Disconnect();
	    }
	}
    }
}