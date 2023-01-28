/**
 * Name : Group++
 * File : Group++.js
 * Author : Snake
 * Creation : 2014.07.19
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

//Function to check if name is animal by DreTaX @dretax14
function isAnimal(name) {
    if (name == "Wolf" || name == "Bear" || name == "MutantWolf" || name == "MutantBear") {
        return true;
    }
    return false;
}

//Function to get a player by SteamID
function getPlayerBySteamID(id) {
    for (pl in Server.Players) {
        if (Data.ToLower(pl.SteamID) == id) {
            return pl;
        }
    }
    return null;
}

//Function to get the group of a play by SteamID
function getGroup (id) {
    var ini = Plugin.GetIni("Group++");
    var own = ini.GetSetting("Owners", id);
    if (own != "no") {
        return own;
    }
    var mem = ini.GetSetting("Members", id);
    if (mem != "no") {
        return mem;
    }
    return null;
}

//Protection to damage for group members
function On_PlayerHurt (he) {
    var att = he.Attacker;
    var vic = he.Victim;
    if (getPlayer(att.Name) == null || att.Name == vic.Name) {
        return;
    }
    var attgroup = getGroup(att.SteamID);
    var vicgroup = getGroup(vic.SteamID);
    if (attgroup == null || vicgroup == null || attgroup != vicgroup) {
        return;
    }
    he.DamageAmount = 0;
}

//Reset on player connected
function On_PlayerConnected (Player) {
    if (!Plugin.IniExists("Group++")) {
        Server.Broadcast("Group++", "ERROR : Creating ini file because it doesn't exist")
        Plugin.CreatIni("Group++");
    }
    var ini = Plugin.GetIni("Group++");
    ini.AddSetting("Owners", Player.SteamID, "no");
    ini.AddSetting("Members", Player.SteamID, "no");
    ini.Save();
}

//Reset on player disconnected
function On_PlayerDisconnected (Player) {
    var ini = Plugin.GetIni("Group++");
    var owngroup = ini.GetSetting("Owners", Player.SteamID);
    var memgroup = ini.GetSetting("Members", Player.SteamID);

    if (owngroup != "no") {
        for (var member in ini.EnumSection("Members")) {
            var group = getGroup(member);
            if (group == owngroup){
                ini.SetSetting("Members", member, "no");
                ini.Save();
                var pl = getPlayerBySteamID(member);
                pl.MessageFrom("Group++", "Your group has been deleted");
            }
        }
        ini.DeleteSetting("Groups", owngroup);
        ini.SetSetting("Owners", Player.SteamID, "no");
    }

    if (memgroup != "no") {
        for (var member in ini.Enumsection("Members")) {
            var group = getGroup(member);
            if (group == memgroup) {
                var pl = getPlayerBySteamID(member);
                pl.MessageFrom("Group++", Player.Name + " has left the group");
            }
        }
        for (var owner in ini.Enumsection("Owners")) {
            var group = getGroup(member);
            if (group == memgroup) {
                var pl = getPlayerBySteamID(member);
                pl.MessageFrom("Group++", Player.Name + " has left the group");
            }
        }
        ini.SetSetting("Members", Player.SteamID, "no");
    }
    ini.Save();
}

//Commands of the plugin
function On_Command (Player, cmd, args) {
    cmd = Data.ToLower(cmd);
    var n = "Group++";
    if (cmd == "g" || cmd == "group") {
        var ini = Plugin.GetIni("Group++");
        var owngroup= ini.GetSetting("Owners", Player.SteamID);
        var memgroup= ini.GetSetting("Members", Player.SteamID);
        switch (args.Length){
            case 0:
                Player.MessageFrom(n, "Group++ 1.1 by Snake");
                Player.MessageFrom(n, "---------------------------------");
                Player.MessageFrom(n, "Use '/g' to see this info");
                Player.MessageFrom(n, "Use '/g create name password' to create a new group");
                Player.MessageFrom(n, "Use '/g join name password' to invite a player to the group");
                Player.MessageFrom(n, "Use '/g leave' to leave from a group");
                Player.MessageFrom(n, "-----------Owner Tools-----------");
                Player.MessageFrom(n, "Use '/g delete' to delete a group");
                Player.MessageFrom(n, "Use '/g kick name' to kick a player from group");
                if (Player.Admin) {
                    Player.MessageFrom(n, "-----------Admin Tools-----------");
                    Player.MessageFrom(n, "Use '/g list' to delete all groups");
                    Player.MessageFrom(n, "Use '/g delete name' to delete a group and all its members");
                    Player.MessageFrom(n, "Use '/g delall' to delete all groups");
                }
                break;

            case 1:
                switch (args[0]) {
                    case "delete":
                        if (owngroup != "no") {
                            for (var member in ini.EnumSection("Members")) {
                                var group = ini.GetSetting("Members", member);
                                if (group == owngroup){
                                    ini.SetSetting("Members", member, "no");
                                    var pl = getPlayerBySteamID(member);
                                    pl.MessageFrom("Group++", "Your group has been deleted");
                                }
                            }
                            ini.SetSetting("Owners", Player.SteamID, "no");
                            ini.DeleteSetting("Groups", owngroup);
                            ini.Save();
                            Player.MessageFrom("Group++", "Your group has been deleted");
                        }
                        else {
                            Player.MessageFrom(n, "You don't own any group");
                        }
                        break;

                    case "leave":
                        if (memgroup != "no") {
                            ini.SetSetting("Members", Player.SteamID, "no");
                            for (var member in ini.EnumSection("Members")) {
                                var group = ini.GetSetting("Members", member);
                                if (group == memgroup){
                                    var pl = getPlayerBySteamID(member);
                                    pl.MessageFrom("Group++", Player.Name + " has left the group");
                                }
                            }
                            for (var owner in ini.EnumSection("Owners")) {
                                var group = ini.GetSetting("Owners", owner);
                                if (group == owngroup){
                                    var pl = getPlayerBySteamID(member);
                                    pl.MessageFrom("Group++", Player.Name + " has left the group");
                                }
                            }
                            ini.Save();
                            Player.MessageFrom(n, "You left the group " + memgroup);
                        }
                        else {
                            Player.MessageFrom(n, "You aren't a member of any group");
                        }
                        break;

                    case "list":
                        if (Player.Admin) {
                            for (var group in ini.EnumSection("Groups")) {
                                var password = ini.GetSetting("Groups", group);
                                for (var owner in ini.EnumSection("Owners")) {
                                    var plgroup = ini.GetSetting("Owners", owner);
                                    if (plgroup == group){
                                        var owner = getPlayerBySteamID(owner);
                                    }
                                }
                                var members = "";
                                for (var member in ini.EnumSection("Members")) {
                                    if (getGroup(member) == group){
                                        members += member + " ";
                                    }
                                }
                                Player.MessageFrom(n, "Group : " + group + " - Password : " + password + " - Owner : " + owner.Name);
                                Player.MessageFrom(n, "Members : " + members);
                            }
                        }
                        else {
                            Player.MessageFrom(n, "You don't have access to this command");
                        }
                        break;

                    case "delall":
                        if (Player.Admin) {
                            for (var group in ini.EnumSection("Groups")) {
                                ini.DeleteSetting("Groups", group);
                            }
                            for (var owner in ini.EnumSection("Owners")) {
                                ini.SetSetting("Owners", owner, "no");
                            }
                            for (var member in ini.EnumSection("Members")) {
                                ini.SetSetting("Members", member, "no");
                            }
                            ini.Save();
                            Server.BroadcastFrom("Group++", "All groups deleted by " + Player.Name);
                        }
                        else {
                            Player.MessageFrom(n, "You don't have access to this command");
                        }
                        break;

                    default:
                        Player.MessageFrom(n, "Invalid command");
                        break;
                }
                break;

            case 2:
                switch (args[0]) {
                    case "kick":
                        if (owngroup != "no") {
                            var target = getPlayer(args[1]);
                            if (args[1] != null) {
                                var tgroup = ini.GetSetting("Members", target.SteamID);
                                if (tgroup == owngroup) {
                                    ini.SetSetting("Members", target.SteamID, "no");
                                    ini.Save();
                                    target.MessageFrom(n, "You have been kicked from the group by " + Player.Name);
                                    for (var member in ini.EnumSection("Members")) {
                                        var plgroup = ini.GetSetting("Members", member);
                                        if (plgroup == owngroup) {
                                            var pl = getPlayerBySteamID(member);
                                            pl.MessageFrom(n, target.Name + " got kicked from the group by " + Player.Name);
                                        }
                                    }
                                    Player.MessageFrom(n, "You have kicked " + args[1]);
                                }
                                else {
                                    Player.MessageFrom(n, args[1] + " is not in your group");
                                }
                            }
                            else {
                                Player.MessageFrom(n, args[1] + " not found");
                            }
                        }
                        else {
                            Player.MessageFrom(n, "You are not the owner of a group");
                        }
                        break;

                    case "delete":
                        if (Player.Admin) {
                            for (var group in ini.EnumSetcion("Groups")) {
                                if (group == args[1]) {
                                    for (var member in ini.EnumSection("Members")) {
                                        var plgroup = ini.GetSetting("Members", member);
                                        if (plgroup == args[1]){
                                            ini.SetSetting("Members", member, "no");
                                            var pl = getPlayerBySteamID(member);
                                            pl.MessageFrom("Group++", "Your group has been deleted by " + Player.Name);
                                        }
                                    }
                                    for (var owner in ini.EnumSection("Owners")) {
                                        var plgroup = ini.GetSetting("Owners", owner);
                                        if (plgroup == args[1]){
                                            ini.SetSetting("Owners", owner, "no");
                                            var pl = getPlayerBySteamID(member);
                                            pl.MessageFrom("Group++", "Your group has been deleted by " + Player.Name);
                                        }
                                    }
                                    ini.RemoveSetting("Groups", args[1]);
                                    ini.Save();
                                    Player.MessageFrom(n, "Group " + args[1] + " deleted");
                                    return;
                                }
                            }
                            Player.MessageFrom(n, "Group " + args[1] + " not found");
                        }
                        else {
                            Player.MessageFrom(n, "You don't have permission to do that");
                        }
                        break;
                }

            case 3:
                switch (args[0]){
                    case "create":
                        if (memgroup != "no" || owngroup != "no") {
                            Player.MessageFrom(n, "You already are a member/owner of a group");
                            return;
                        }
                        if (args[1].length < 3 || args[1].length > 10) {
                            Player.MessageFrom(n, "Group name must be within 3 and 10 characters");
                            return;
                        }
                        if (args[2].length < 3 || args[2].length > 10) {
                            Player.MessageFrom(n, "Password must be within 3 and 10 characters");
                            return;
                        }
                        for (var group in ini.EnumSection("Groups")) {
                            if (group == args[1]) {
                                Player.MessageFrom(n, "Group " + args[1] + " already exists");
                                return;
                            }
                        }
                        ini.AddSetting("Owners", Player.SteamID, args[1]);
                        ini.AddSetting("Groups", args[1], args[2]);
                        ini.Save();
                        Player.MessageFrom(n, "Group " + args[1] + " created with password " + args[2]);
                        break;

                    case "join":
                        if (memgroup != "no" || owngroup != "no") {
                            Player.MessageFrom(n, "You already are a member/owner of a group");
                            return;
                        }

                        for (var group in ini.EnumSection("Groups")) {
                            if (group == args[1]) {
                                if (args[2] == ini.GetSetting("Groups", group)) {
                                    for (var member in ini.EnumSection("Members")) {
                                        var plgroup = ini.GetSetting("Members", member);
                                        if (plgroup == group){
                                            var pl = getPlayerBySteamID(member);
                                            pl.MessageFrom("Group++", Player.Name + "has joined the group");
                                        }
                                    }
                                    for (var owner in ini.EnumSection("Owners")) {
                                        var plgroup = ini.GetSetting("Owners", owner);
                                        if (plgroup == group){
                                            var pl = getPlayerBySteamID(member);
                                            pl.MessageFrom("Group++", Player.Name + "has joined the group");
                                        }
                                    }
                                    Player.MessageFrom(n, "You have joined " + group);
                                    ini.SetSetting("Members", Player.SteamID, group);
                                    ini.Save();
                                    return;
                                }
                                else {
                                    Player.MessageFrom(n, "Wrong password");
                                    return;
                                }
                            }
                        }
                        Player.MessageFrom(n, "Group " + args[1] + " does not exist");
                        break;
                }
                break;

            default:
                Player.MessageFrom(n, "Invalid command");
                break;
        }
    }
}