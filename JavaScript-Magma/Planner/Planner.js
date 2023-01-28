/**
 * Name : Planner
 * File : Planner.js
 * Author : Snake
 * Creation Date : 2014.07.24
 * Update Date : 2014.07.31
 * Version : 1.0.2
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
    var n = "Planner";
    if (cmd == "plan") {
        var ini = Plugin.GetIni("Planner");
        var status = ini.GetSetting("Settings", "status");
        var start = ini.GetSetting("Settings", "start");
        var startmode = ini.GetSetting("Settings", "startmode");
        var stop = ini.GetSetting("Settings", "stop");
        var stopmode = ini.GetSetting("Settings", "stopmode");
        switch (args.Length) {
            case 0:
                Player.MessageFrom(n, "Planner 1.0.2 by Snake");
                Player.MessageFrom(n, "-------------------");
                Player.MessageFrom(n, "Planner Status : " + status);
                Player.MessageFrom(n, "PvP Starts : " + start + " " + startmode);
                Player.MessageFrom(n, "PvP Stops : " + stop + " " + stopmode);
                if (Player.Admin) {
                    Player.MessageFrom(n, "-------------------");
                    Player.MessageFrom(n, "Use '/plan on' to change the Planner status to ON");
                    Player.MessageFrom(n, "Use '/plan off' to change the Planner status to OFF");
                    Player.MessageFrom(n, "Use '/plan start x AM/PM' to change the PvP time start");
                    Player.MessageFrom(n, "Use '/plan stop x AM/PM' to change the PvP time start");
                }
                break;

            case 1:
                if (Player.Admin) {
                    switch (args[0]) {
                        case "on":
                            ini.SetSetting("Settings", "status", "on");
                            ini.Save();
                            Server.BroadcastFrom(n, "PvP Planner set to ON from " + start + " to " + stop);
                            break;

                        case "off":
                            ini.SetSetting("Settings", "status", "off");
                            ini.Save();
                            Server.BroadcastFrom(n, "PvP Planner set to OFF");
                            break;

                        default:
                            Player.MessageFrom(n, "Invalid option (on/off)");
                            break;
                    }
                }
                else {
                    Player.MessageFrom(n, "You don't have permission to do this");
                }
                break;

            case 3:
                args[2] = Data.ToUpper(args[2]);
                if (Player.Admin) {
                    if (isNaN(parseInt(args[1])) || args[1] > 12 || args[1] < 0 || args[2] != "AM" && args[2] != "PM") {
                        Player.MessageFrom(n, "Invalid option ('/plan action number AM/PM)");
                        Player.MessageFrom(n, "Example : /plan start 10 AM");
                        Player.MessageFrom(n, "Example : /plan stop 5 PM");
                        return;
                    }
                    var t = args[1]+args[2];
                    switch (args[0]) {
                        case "start":
                            ini.SetSetting("Settings", "start", args[1]);
                            ini.SetSetting("Settings", "startmode", args[2]);
                            ini.Save();
                            Player.MessageFrom(n, "Start set to " + t);
                            break;

                        case "stop":
                            ini.SetSetting("Settings", "stop", args[1]);
                            ini.SetSetting("Settings", "stopmode", args[2]);
                            ini.Save();
                            Player.MessageFrom(n, "Stop set to " + t);
                            break;

                        default:
                            Player.MessageFrom(n, "Invalid option (start/stop)");
                            Player.MessageFrom(n, "Example : /plan start 10 AM");
                            Player.MessageFrom(n, "Example : /plan stop 5 PM");
                            break;
                    }
                }
                else {
                    Player.MessageFrom(n, "You don't have permission to do this");
                }
                break;

            default:
                Player.MessageFrom(n, "Invalid command");
                break;
        }
    }
}

//Protection for pvp damage if it's in the plugin limits
function On_PlayerHurt(he) {
    var att = he.Attacker;
    var vic = he.Victim;
    if (getPlayer(att.Name) == null || att.SteamID == vic.SteamID) {
        return;
    }
    //Getting all the settings
    var ini = Plugin.GetIni("Planner");
    var status = ini.GetSetting("Settings", "status");
    if (status == "off") {
        return;
    }
    var start = ini.GetSetting("Settings", "start");
    var startmode = ini.GetSetting("Settings", "startmode");
    var stop = ini.GetSetting("Settings", "stop");
    var stopmode = ini.GetSetting("Settings", "stopmode");

    //Getting the hour
    var t = Plugin.GetTime();
    var i = t.indexOf(":");
    var hour = t.substr(0, i);

    //Getting the mode
    var sys = "";
    var length = t.length;
    if (length == 7) {
        sys = t.substring(5, 7);
    }
    else {
        sys = t.substring(6, 8);
    }

    //If doesn't match any limit stop it
    if (startmode != sys && stopmode != sys) {
        return;
    }

    //Comparing hour and limits set by the plugin
    if (startmode == sys) {
        if (hour >= start) {
            he.DamageAmount = 0;
            att.MessageFrom(n, "PvP is OFF from " + start + startmode + " to " + stop + stopmode);
            vic.MessageFrom(n, "PvP is OFF from " + start + startmode + " to " + stop + stopmode);
        }
    }
    else if (hour < stop){
        he.DamageAmount = 0;
        att.MessageFrom(n, "PvP is OFF from " + start + startmode + " to " + stop + stopmode);
        vic.MessageFrom(n, "PvP is OFF from " + start + startmode + " to " + stop + stopmode);
    }
}