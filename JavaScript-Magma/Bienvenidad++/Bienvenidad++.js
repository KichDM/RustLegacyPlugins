
//* By KichDM
//*TODO Para NovaLand Zero
function On_PlayerConnected(Player) {
    var user = Users.GetBySteamID(Player.SteamID);
    var time = System.DateTime.Now.toString();
    if (user.Rank > 0) {
        var a = Util.FindLocationName(Player.Location);
        Server.BroadcastFrom("Novaland Zero", "[color#22AB22][" + RustExtended.Core.Ranks[Users.GetBySteamID(Player.SteamID).Rank] + "] " + Player.Name + " [color#00fffb] Entro." + "[color#Fbfb00] 1+ " + "[color#00f2fb] [ " + Server.Players.Count + "  ]");
        try {
        Util.SendMessageToDiscordEmbed("https://discord.com/api/webhooks/955129628115218432/_rKaBfw6wrCren1glCetgRcpKZ9DizDA7rh9wRoUPHHFQJzbtixUtpt4__PBcF-96-yq", "ENTRADA EPICA", "[" + RustExtended.Core.Ranks[Users.GetBySteamID(Player.SteamID).Rank] + "] " + Player.Name + " Entro." + " 1+ " + " [ " + Server.Players.Count + "  ]");
        Util.SendMessageToDiscordEmbed(
            "https://discord.com/api/webhooks/967537086355894302/bD5gEPC3a_Nt-vkB0hVXluejEMXV2bFf7AMwRfcL_1EmNDzCwrBaVLe5yz2gXfV8LOls",
            "Entrada",
            "\n El jugador:\n" +
            "**" + Player.Name + "**" +
            " \n\n Rango \n" +
            "**" + RustExtended.Core.Ranks[Users.GetBySteamID(Player.SteamID).Rank] + "**" +
            " \n\n ID \n" +
            "**" + Player.SteamID + "**" +
            " \n\n IP \n" +
            "**" + Player.IP + "**" +
            "\n\n Hora:\n" +
            "**" + time + "**"
        );
    }
    catch (err) {
        Util.LogRojo("ERROR AL ENVIAR MSG A DISCORD DE BIENVENIDAD++.js On_PlayerConnected > 0")   
}

}
    else {

        Server.BroadcastFrom("Novaland Zero", "[color#22AB22] " + Player.Name + " [color#00fffb] Entro." + "[color#Fbfb00] 1+ " + "[color#00f2fb] [ " + Server.Players.Count + "  ] ");
        Util.SendMessageToDiscordEmbed("https://discord.com/api/webhooks/955129628115218432/_rKaBfw6wrCren1glCetgRcpKZ9DizDA7rh9wRoUPHHFQJzbtixUtpt4__PBcF-96-yq", "ENTRADA EPICA", " " + Player.Name + "  Entro." + " 1+ " + " [ " + Server.Players.Count + "  ] ");
        try {
        Util.SendMessageToDiscordEmbed(
            "https://discord.com/api/webhooks/967537086355894302/bD5gEPC3a_Nt-vkB0hVXluejEMXV2bFf7AMwRfcL_1EmNDzCwrBaVLe5yz2gXfV8LOls",
            "Entrada",
            "\n El jugador:\n" +
            "**" + Player.Name + "**" +
            " \n\n Rango \n" +
            "**" + RustExtended.Core.Ranks[Users.GetBySteamID(Player.SteamID).Rank] + "**" +
            " \n\n ID:\n" +
            "**" + Player.SteamID + "**" +
            " \n\n IP \n" +
            "**" + Player.IP + "**" +
            "\n\n Hora:\n" +
            "**" + time + "**");
    }
    catch (err) {
        Util.LogRojo("ERROR AL ENVIAR MSG A DISCORD DE BIENVENIDAD++.js On_PlayerConnected < 0")   
}

}
}

function On_Command(Player, cmd, args) {
    if (cmd == "info") {
        Player.MessageFrom("Novaland Zero", "[COLOR#32CD32]︾︾︾︾︾︾︾︾︾︾︾︾︾ [COLOR#f7a102]Nova[COLOR##f70205]Land [COLOR#7ff702]Zero [COLOR#32CD32]︾︾︾︾︾︾︾︾︾︾︾︾︾ .");
        Player.MessageFrom("Novaland Zero", "[COLOR#ff5b3a] " + Player.Name + " [COLOR#FFFFFF] - Bienvenido!");
        Player.MessageFrom("Novaland Zero", "[COLOR#FFFFFF] Proyecto [COLOR#ffff00][COLOR#f7a102]Nova[COLOR##f70205]Land [COLOR#7ff702]Zero [COLOR#FFFFFF]te desea un buen juego!");
        Player.MessageFrom("Novaland Zero", "[COLOR#f70205]➠ [COLOR#FFFFFF]Gather: [COLOR#f70205]х9.");
        Player.MessageFrom("Novaland Zero", "[COLOR#02f7f4]➠ [COLOR#FFFFFF]Wipe fue:[COLOR#02f7f4] falta por poner.");
        Player.MessageFrom("Novaland Zero", "[COLOR#7a02f7]➠ [COLOR#FFFFFF]Actual en línea:[COLOR#7a02f7] " + Server.Players.Count + " [COLOR#FFFFFF]de [COLOR#ff5b3a]70.");
        Player.MessageFrom("Novaland Zero", "[COLOR#32CD32]︾︾︾︾︾︾︾︾︾︾︾︾︾ [COLOR#f7a102]Nova[COLOR##f70205]Land [COLOR#7ff702]Zero [COLOR#32CD32]︾︾︾︾︾︾︾︾︾︾︾︾︾ .");
        //USAC.API.SendMessageToDiscordEmbed("https://discord.com/api/webhooks/954797382263009300/s8peQLOkCdHsqFbQ9YUVOi7E6hB8yDI1C_r95Ou182eV8IJFDZ1CEC2I7XkeTebeaVOa","KLKTT","El jugador " + Player.Name + " Uso el comando /info");
    }
}

function On_PlayerDisconnected(Player) {
    var user = Users.GetBySteamID(Player.SteamID);
    if (user.Rank > 0) {
        var a = Util.FindLocationName(Player.Location);
        var time = System.DateTime.Now.toString();
        Server.BroadcastFrom("Novaland Zero", "[color#FF4500][" + RustExtended.Core.Ranks[Users.GetBySteamID(Player.SteamID).Rank] + "] " + Player.Name + " [color#Ff0b00]salio." + "[color#Fbfb00] 1- " + "[color#00f2fb] [ " + Server.Players.Count + "  ]");
        try {
        Util.SendMessageToDiscordEmbed("https://discord.com/api/webhooks/955129628115218432/_rKaBfw6wrCren1glCetgRcpKZ9DizDA7rh9wRoUPHHFQJzbtixUtpt4__PBcF-96-yq", "SALIDA TRISTE", " [" + RustExtended.Core.Ranks[Users.GetBySteamID(Player.SteamID).Rank] + "] " + Player.Name + " salio." + " 1- " + " [ " + Server.Players.Count + "  ]");
        Util.SendMessageToDiscordEmbed(
            "https://discord.com/api/webhooks/967537086355894302/bD5gEPC3a_Nt-vkB0hVXluejEMXV2bFf7AMwRfcL_1EmNDzCwrBaVLe5yz2gXfV8LOls",
            "Salida",
            "\n El jugador:\n" +
            "**" + Player.Name + "**" +
            " \n\n Rango \n" +
            "**" + RustExtended.Core.Ranks[Users.GetBySteamID(Player.SteamID).Rank] + "**" +
            " \n\n ID:\n" +
            "**" + Player.SteamID + "**" +
            " \n\n IP \n" +
            "**" + Player.IP + "**" +
            "\n\n Loc:\n" +
            "**" + Player.Location + "**" +
            "\n\n Cerca de:\n" +
            "**" + a + "**" +
            "\n\n Hora:\n" +
            "**" + time + "**");
    }
    catch (err) {
        Util.LogRojo("ERROR AL ENVIAR MSG A DISCORD DE BEIVENIDAD++.js ON_PLAYERDISCONNECTED > 0")   
}

}

    else {
                
        var a = Util.FindLocationName(Player.Location);
        var time = System.DateTime.Now.toString();
        Server.BroadcastFrom("Novaland Zero", "[color#FF4500] " + Player.Name + " [color#Ff0b00]salio." + "[color#Fbfb00] 1- " + "[color#00f2fb] [ " + Server.Players.Count + "  ] ");
        Util.SendMessageToDiscordEmbed("https://discord.com/api/webhooks/955129628115218432/_rKaBfw6wrCren1glCetgRcpKZ9DizDA7rh9wRoUPHHFQJzbtixUtpt4__PBcF-96-yq", "SALIDA TRISTE", " " + Player.Name + " salio." + " 1- " + " [ " + Server.Players.Count + "  ] ");
        try {
        Util.SendMessageToDiscordEmbed(
            "https://discord.com/api/webhooks/967537086355894302/bD5gEPC3a_Nt-vkB0hVXluejEMXV2bFf7AMwRfcL_1EmNDzCwrBaVLe5yz2gXfV8LOls",
            "Salida",
            "\n El jugador:\n" +
            "**" + Player.Name + "**" +
            " \n\n Rango \n" +
            "**" + RustExtended.Core.Ranks[Users.GetBySteamID(Player.SteamID).Rank] + "**" +
            " \n\n ID:\n" +
            "**" + Player.SteamID + "**" +
            " \n\n IP \n" +
            "**" + Player.IP + "**" +
            "\n\n Loc:\n" +
            "**" + Player.Location + "**" +
            "\n\n Cerca de:\n" +
            "**" + a + "**" +
            "\n\n Hora:\n" +
            "**" + time + "**");
    }
    catch (err) {
        Util.LogRojo("ERROR AL ENVIAR MSG A DISCORD DE BIENVENIDAD++.js ON_PLAYERDISCONNECTED < 0")   
}

}    
}








