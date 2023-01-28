function On_Chat(Player, Message)
{
    try {
    var user = Users.GetBySteamID(Player.SteamID);
    if(user.Rank >= 0)
    {
        if (Message == "."){
                
    }
    else {
        Util.SendMessageToDiscordEmbed("https://discord.com/api/webhooks/964169348958801942/FTxXX9RIYcdFUmlRJ3wt6CN9d_b1xYczmhePyghm86VQqTJlVAsTpEMUD5W0jFTF7xf9" ,"["+RustExtended.Core.Ranks[Users.GetBySteamID(Player.SteamID).Rank]+"]" + Player.Name, "**" + Message + "**");      
    }
}
}
catch (err) {
    Util.LogRojo("ERROR AL ENVIAR MSG A DISCORD DE ChatMSG++.js")   
}
return;
}