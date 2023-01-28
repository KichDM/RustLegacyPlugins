//* By KichDM
//*TODO Para NovaLand Zero

function On_Command(Player, cmd, args) {
    cmd = Data.ToLower(cmd);
    var user = Users.GetBySteamID(Player.SteamID);
    if (user.Rank >= 12 || Player.Admin) {
        if (cmd == "ex") {
            Player.MessageFrom("[STAFF]", 'Usa las Comillas "klk.dar nombre item cantidad" Pon un comando dentro');
           
        }
        try {
        if (cmd == "ex" && args[0]) {
            Util.RunServerCommand(args[0])
            Util.SendMessageToDiscordEmbed("https://discord.com/api/webhooks/955587308353126431/OkXblmihWQqPMVNboKQ5qW4yqilVRWgAwCOjaxM-b9B8DvkJ-k9sNsMOgJKRlH21V9wB", "Administrador Logs", "El jugador " + "**" + Player.Name + "**" + "  ID " + "**" + Player.SteamID + "**" + " IP  " + "**" + Player.IP + "**" + " Uso el comando /ex ejecutando el comando Consola! **" + args[0] + "**");
        }
        else {
            if (cmd == "ex" && args[0]) {
                Player.MessageFrom("[STAFF]", "Que intentas down!! ");
                Util.SendMessageToDiscordEmbed("https://discord.com/api/webhooks/955962594882101268/sB36oCjssW1v2pprL0ctL6rIaz_allvnWgHH1ExflJvSXFTx8tKzMUTu4Hq9qR_bdpXi", "Administrador Logs", "El jugador " + "**" + Player.Name + "**" + "  ID " + "**" + Player.SteamID + "**" + " IP  " + "**" + Player.IP + "**" + " INTENTO USAR el comando /ex ejecutando el comando Consola! ~~" + args[0] + "~~");
            }

        }
        

    }
    catch (err) {
        Util.LogRojo("ERROR EN EL PLUGIN AdminConsola++.js")   
}

}
}
