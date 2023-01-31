//* By KichDM
//*TODO Para NovaLand Zero
function On_PlayerConnected(Player) {
    var user = Users.GetBySteamID(Player.SteamID);
    var time = System.DateTime.Now.toString();
    if (user.Rank > 0) {
        Server.BroadcastFrom("Novaland Zero", "[color#22AB22][" + RustExtended.Core.Ranks[Users.GetBySteamID(Player.SteamID).Rank] + "] " + Player.Name + " [color#00fffb] Entro." + "[color#Fbfb00] 1+ " + "[color#00f2fb] [ " + Server.Players.Count + "  ]");
    }
    else {
        Server.BroadcastFrom("Novaland Zero", "[color#22AB22] " + Player.Name + " [color#00fffb] Entro." + "[color#Fbfb00] 1+ " + "[color#00f2fb] [ " + Server.Players.Count + "  ] ");
    }
}

function On_Command(Player, cmd, args) {
    if (cmd == "info") {
        Player.MessageFrom("Novaland Zero", "[COLOR#32CD32]︾︾︾︾︾︾︾︾︾︾︾︾︾ [COLOR#f7a102]Nova[COLOR##f70205]Land [COLOR#7ff702]Zero [COLOR#32CD32]︾︾︾︾︾︾︾︾︾︾︾︾︾ .");
        Player.MessageFrom("Novaland Zero", "[COLOR#ff5b3a] " + Player.Name + " [COLOR#FFFFFF] - Bienvenido!");
        Player.MessageFrom("Novaland Zero", "[COLOR#FFFFFF] Proyecto [COLOR#ffff00][COLOR#f7a102]Nova[COLOR##f70205]Land [COLOR#7ff702]Zero [COLOR#FFFFFF]te desea un buen juego!");
        Player.MessageFrom("Novaland Zero", "[COLOR#f70205]➠ [COLOR#FFFFFF]Gather: [COLOR#f70205]х2.");
        Player.MessageFrom("Novaland Zero", "[COLOR#02f7f4]➠ [COLOR#FFFFFF]Wipe fue:[COLOR#02f7f4] falta por poner.");
        Player.MessageFrom("Novaland Zero", "[COLOR#7a02f7]➠ [COLOR#FFFFFF]Actual en línea:[COLOR#7a02f7] " + Server.Players.Count + " [COLOR#FFFFFF]de [COLOR#ff5b3a]70.");
        Player.MessageFrom("Novaland Zero", "[COLOR#32CD32]︾︾︾︾︾︾︾︾︾︾︾︾︾ [COLOR#f7a102]Nova[COLOR##f70205]Land [COLOR#7ff702]Zero [COLOR#32CD32]︾︾︾︾︾︾︾︾︾︾︾︾︾ .");
    }
}

function On_PlayerDisconnected(Player) {
    var user = Users.GetBySteamID(Player.SteamID);
    if (user.Rank > 0) {
        Server.BroadcastFrom("Novaland Zero", "[color#FF4500][" + RustExtended.Core.Ranks[Users.GetBySteamID(Player.SteamID).Rank] + "] " + Player.Name + " [color#Ff0b00]salio." + "[color#Fbfb00] 1- " + "[color#00f2fb] [ " + Server.Players.Count + "  ]");
    }
    else {
        Server.BroadcastFrom("Novaland Zero", "[color#FF4500] " + Player.Name + " [color#Ff0b00]salio." + "[color#Fbfb00] 1- " + "[color#00f2fb] [ " + Server.Players.Count + "  ] ");
    }
}








