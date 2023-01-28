/**
 * Name : TeleShooter
 * File : TeleShooter.js
 * Author : Snake
 * Creation : 2014.07.30
 * Version : 1.1
 */

//Function to get a player by name by DreTaX @dretax14
function getPlayer(name) {
    name = Data.ToLower(name);
    for (pl in Server.Players) {
        if (Data.ToLower(pl.Name) == name) {
            return pl;
        }
    }
    return null;
}

//Commands of the plugin
function On_Command (Player, cmd, args) {
    cmd = Data.ToLower(cmd);
    if (cmd == "ts" && Player.Admin) {
        var n = "TeleShooter";
        switch (args.Length) {
            case 0:
                Player.MessageFrom(n, "TeleShooter 1.1 by Snake");
                Player.MessageFrom(n, "-------------------");
                Player.MessageFrom(n, "Use '/ts' to see this info");
                Player.MessageFrom(n, "Use '/ts to' to teleport yourself to your target");
                Player.MessageFrom(n, "Use '/ts here' to teleport your target to you");
                Player.MessageFrom(n, "Use '/ts off' to turn it off");
                break;

            case 1:
                switch(args[0]) {
                    case "to":
                        DataStore.Add("TeleShooter", Player.SteamID, "to");
                        Player.MessageFrom(n, "You will be teleported when you shoot someone");
                        break;

                    case "here":
                        DataStore.Add("TeleShooter", Player.SteamID, "here");
                        Player.MessageFrom(n, "You will teleport a player to you when you shoot someone");
                        break;

                    case "off":
                        DataStore.Add("TeleShooter", Player.SteamID, "off");
                        Player.MessageFrom(n, "TeleShooter is OFF");
                        break;

                    default:
                        Player.MessageFrom(n, "Invalid command");
                        break;
                }
                break;

            default:
                Player.MessageFrom(n, "Invalid command");
                break;
        }
    }
}

//Teleshooting function
function On_PlayerHurt(he) {
    var att = he.Attacker;
    var vic = he.Victim;
    if (Player.Admin == false || getPlayer(att.Name) == null || att.SteamID == vic.SteamID) {
        Server.Broadcast("cancel");
        return;
    }
    var n = "TeleShooter";
    var mode = DataStore.Get("TeleShooter", he.Attacker.SteamID);
    if (mode != "off") {
        switch (mode) {
            case "to":
                he.DamageAmount = 0;
                att.TeleportTo(vic);
                att.MessageFrom(n, "You have been TeleShooted to " + vic.Name);
                vic.MessageFrom(n, att.Name + " has been teleshooted to you");
                break;

            case "here":
                he.DamageAmount = 0;
                vic.TeleportTo(att);
                vic.MessageFrom(n, "You have been TeleShooted to " + vic.Name);
                break;
        }
    }
}