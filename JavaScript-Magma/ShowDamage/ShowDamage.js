/**
 * Name : VerDaño
 * File : VerDaño.js
 */

//Function to check if name is animal 
function isAnimal(name) {
    if (name == "Wolf" || name == "Bear" || name == "MutantWolf" || name == "MutantBear") {
        return true;
    }
    return false;
}

//Function to check bodypart 
function getBodypart(bodyp) {
    var ini = Plugin.GetIni("bodyparts");
    var part = ini.GetSetting("bodyparts", bodyp);
    return part;
}

//Function to give inventory name of entities inspired in getBodypart function
function getEntityName(ent) {
    var ini = Plugin.GetIni("entities");
    var part = ini.GetSetting("entities", ent);
    return part;
}

//Function to give animal name inspired getBodypart function
function getAnimalName(value) {
    var ini = Plugin.GetIni("animals");
    var name = ini.GetSetting("animals", value);
    return name;
}

//Function to get a player by name 
function getPlayer(name) {
    name = Data.ToLower(name);
    for (pl in Server.Players) {
        if (Data.ToLower(pl.Name) == name) {
            return pl;
        }
    }
    return null;
}

//Function to prevent massive messages when using shotgun
function ShotgunCallback() {
    Plugin.KillTimer("Shotgun");
    var ini = Plugin.GetIni("showdamage");
    var n = ini.GetSetting("Settings", "display");
    var mode = ini.GetSetting("Settings", "mode");
    for (var name in DataStore.Keys("SDFIX")) {
        var dmg = DataStore.Get("SDFIX", name);
        var vname = DataStore.Get("SDFIX2", name);
        var att = getPlayer(name);
        var vic = getPlayer(vname);
        switch(mode) {
            case "msg":
                att.MessageFrom(n, dmg + " damage to " + vname + " ( Shotgun )");
                if (vic != null) {
                    vic.MessageFrom(n, dmg + " damage from " + name + " ( Shotgun )");
                }
                break;

            case "not":
                att.Notice(dmg + " damage to " + vname + " ( Shotgun )");
                if (vic != null) {
                    vic.Notice(n, dmg + " damage from " + name + " ( Shotgun )");
                }
                break;
        }
    }
    DataStore.Flush("SDFIX");
    DataStore.Flush("SDFIX2");
}

//Functions to print damage when hurt
function On_PlayerHurt(he) {
    var ini = Plugin.GetIni("showdamage");
    if (ini.GetSetting("Settings", "status") == "on") {
        var n = ini.GetSetting("Settings", "display");
        var mode = ini.GetSetting("Settings", "mode");
        var att = he.Attacker;
        var vic = he.Victim;
        var dmg = Math.round(he.DamageAmount);
        //Checking if dmg is decimal 0 and then ignores it
        if(dmg == 0){
            return;
        }
        var type = he.DamageType;
        //Checking if dmg is from an animal and ignores the rest of the code
        if(isAnimal(att.Name) && getPlayer(att.Name) == null){
            switch (type) {
                case "Melee":
                    vic.MessageFrom(n, dmg + " damage from " + att.Name);
                    break;

                case "Bleeding":
                    vic.MessageFrom(n, dmg + " damage from bleeding ( " + att.Name + " )");
                    break;
            }
            return;
        }
        var weapon = he.WeaponName;
        if (weapon == "Shotgun") {
            var s = DataStore.Get("SDFIX", att.Name);
            if (isNaN(s)) {
                DataStore.Add("SDFIX", att.Name, dmg);
                DataStore.Add("SDFIX2", att.Name, name);
                DataStore.Save();
            }
            else {
                DataStore.Add("SDFIX", att.Name, s+dmg);
                DataStore.Save();
            }
            Plugin.CreateTimer("Shotgun", 400).Start();
            return;
        }
	    var bodypart = getBodypart(he.DamageEvent.bodyPart);
        var attloc = he.Attacker.Location;
        var vicloc = he.Victim.Location;
        var distance = Util.GetVectorsDistance(attloc, vicloc);
        distance = Number(distance).toFixed(2);        
        if (type == "Explosion") {
            weapon = "Explosion";
            if (att.Name == vic.Name) {
                switch(mode){
                    case "msg":
                        vic.MessageFrom(n, dmg + " damage to yourself ( " + weapon + " )");
                        break;
                    
                    case "not":
                        vic.Notice(dmg + " damage to yourself ( " + weapon + " )");
                        break;
                }
            } 
            else {
                switch(mode){
                    case "msg":
                        att.MessageFrom(n, dmg + " damage to " + vic.Name + " ( " + weapon + " ) @ " + distance + " m");
                        vic.MessageFrom(n, dmg + " damage from " + att.Name + " ( " + weapon + " ) @ " + distance + " m");
                        break;
                    
                    case "not":
                        att.Notice(dmg + " damage to " + vic.Name + " ( " + weapon + " ) @ " + distance + " m");
                        vic.Notice(dmg + " damage from " + att.Name + " ( " + weapon + " ) @ " + distance + " m");
                        break;
                }
            }
        }

        if (type == "Melee") {
            switch (weapon) {
            case undefined:
                if (dmg > 15 && att.Name != vic.Name) {
                    weapon = "Hunting Bow";
                    switch(mode){
                        case "msg":
                            att.MessageFrom(n, dmg + " damage to " + vic.Name + " to his " + bodypart + " ( " + weapon + " ) @ " + distance + " m");
                            vic.MessageFrom(n, dmg + " damage from " + att.Name + " to your " + bodypart + " ( " + weapon + " ) @ " + distance + " m");
                            break;
                    
                        case "not":
                            att.Notice(dmg + " damage to " + vic.Name + " to his " + bodypart + " ( " + weapon + " ) @ " + distance + " m");
                            vic.Notice(dmg + " damage from " + att.Name + " to your " + bodypart + " ( " + weapon + " ) @ " + distance + " m");
                            break;
                    }
                } 
                else {
                    weapon = "Spike Wall";
                    switch(mode){
                    case "msg":
                        vic.MessageFrom(n, dmg + " damage from " + weapon);
                        break;
                    
                    case "not":
                        vic.Notice(n, dmg + " damage from " + weapon);
                        break;
                    }
                }
                break;
            
            default:
                switch(mode){
                    case "msg":
                        att.MessageFrom(n, dmg + " damage to " + vic.Name + " to his " + bodypart + " ( " + weapon + " ) @ " + distance + " m");
                        vic.MessageFrom(n, dmg + " damage from " + att.Name + " to your " + bodypart + " ( " + weapon + " ) @ " + distance + " m");
                        break;
                    
                    case "not":
                        att.Notice(dmg + " damage to " + vic.Name + " to his " + bodypart + " ( " + weapon + " ) @ " + distance + " m");
                        vic.Notice(dmg + " damage from " + att.Name + " to your " + bodypart + " ( " + weapon + " ) @ " + distance + " m");
                        break;
                }           
                break;
            }
        }

        if (type == "Bullet") {
            switch(mode){
                case "msg":
                    att.MessageFrom(n, dmg + " damage to " + vic.Name + " to his " + bodypart + " ( " + weapon + " ) @ " + distance + " m");
                    vic.MessageFrom(n, dmg + " damage from " + att.Name + " to your " + bodypart + " ( " + weapon + " ) @ " + distance + " m");
                    break;
                    
                case "not":
                    att.Notice(dmg + " damage to " + vic.Name + " to his " + bodypart + " ( " + weapon + " ) @ " + distance + " m");
                    vic.Notice(dmg + " damage from " + att.Name + " to your " + bodypart + " ( " + weapon + " ) @ " + distance + " m");
                    break;
            }    
        }

        if (type == "Bleeding") {
            if (dmg > 10) {
                weapon = "fall";
            } 
            else {
                weapon = "bleeding";
            }
            switch(mode){
                    case "msg":
                        vic.MessageFrom(n, dmg + " damage from " + weapon);
                        break;
                    
                    case "not":
                        vic.Notice(n, dmg + " damage from " + weapon);
                        break;
            }  
        }
    }
}

function On_NPCHurt(he) {
    var ini = Plugin.GetIni("showdamage");
    if (ini.GetSetting("Settings", "status") == "on") {
        var n = ini.GetSetting("Settings", "display");
        var att = he.Attacker;
        var vic = he.Victim;
        var name = getAnimalName(vic.Name);
        var dmg = Math.round(he.DamageAmount); 
        var type = he.DamageType;
        var weapon = he.WeaponName;
        if (weapon == "Shotgun") {
            var s = DataStore.Get("SDFIX", att.Name);
            if (isNaN(s)) {
                DataStore.Add("SDFIX", att.Name, dmg);
                DataStore.Add("SDFIX2", att.Name, name);
                DataStore.Save();
            }
            else {
                DataStore.Add("SDFIX", att.Name, s+dmg);
                DataStore.Save();
            }
            Plugin.CreateTimer("Shotgun", 400).Start();
            return;
        }
        var mode = ini.GetSetting("Settings", "mode");
        var attloc = att.Location;
        var vicloc = vic.Character.get_origin();
        var distance = Util.GetVectorsDistance(attloc, vicloc);
        distance = Number(distance).toFixed(2);
        if (type == "Explosion") {
            switch(mode){
                    case "msg":
                        att.MessageFrom(n, dmg + " damage to " + name + " ( " + weapon + " ) @ " + distance + " m");
                        break;
                    
                    case "not":
                        att.Notice(dmg + " damage to " + name + " ( " + weapon + " ) @ " + distance + " m");
                        break;
            }
        }
        if (type == "Melee") {
            switch (weapon) {
            case undefined:
                weapon = "Hunting Bow";
                switch(mode){
                        case "msg":
                            att.MessageFrom(n, dmg + " damage to " + name + " ( " + weapon + " ) @ " + distance + " m");
                            break;
                    
                        case "not":
                            att.Notice(dmg + " damage to " + name + " ( " + weapon + " ) @ " + distance + " m");
                            break;
                }
                break;
            
            default:
                switch(mode){
                        case "msg":
                            att.MessageFrom(n, dmg + " damage to " + name + " ( " + weapon + " ) @ " + distance + " m");
                            break;
                    
                        case "not":
                            att.Notice(dmg + " damage to " + name + " ( " + weapon + " ) @ " + distance + " m");
                            break;
                }           
                break;
            }
        }
        if (type == "Bullet") {
            switch(mode){
                        case "msg":
                            att.MessageFrom(n, dmg + " damage to " + name + " ( " + weapon + " ) @ " + distance + " m");
                            break;
                    
                        case "not":
                            att.Notice(dmg + " damage to " + name + " ( " + weapon + " ) @ " + distance + " m");
                            break;
                }
        }
    }
    return;
}

function On_NPCKilled (de) {
    var ini = Plugin.GetIni("showdamage");
    if (ini.GetSetting("Settings", "status") == "on") {
        var n = ini.GetSetting("Settings", "display");
        var mode = ini.GetSetting("Settings", "mode");
        var att = de.Attacker;
        var vic = de.Victim;
        var name = getAnimalName(vic.Name);
        var dmg = Math.round(de.DamageAmount); 
        var type = de.DamageType;
        var weapon = de.WeaponName;
        if (weapon == "Shotgun") {
            var s = parseInt(DataStore.Get("SDFIX", att.Name));
            if (isNaN(s)) {
                DataStore.Add("SDFIX", att.Name, dmg);
                DataStore.Add("SDFIX2", att.Name, name);
                DataStore.Save();
                Plugin.CreateTimer("Shotgun", 400).Start();
            }
            else {
                DataStore.Add("SDFIX", att.Name, s+dmg);
                DataStore.Save();
            }
            return;
        }
        var attloc = att.Location;
        var vicloc = vic.Character.get_origin();
        var distance = Util.GetVectorsDistance(attloc, vicloc);
        distance = Number(distance).toFixed(2);        
        if (type == "Explosion") {
            switch(mode){
                    case "msg":
                        att.MessageFrom(n, dmg + " damage to " + name + " ( " + weapon + " ) @ " + distance + " m");
                        break;
                    
                    case "not":
                        att.Notice(dmg + " damage to " + name + " ( " + weapon + " ) @ " + distance + " m");
                        break;
            }
        }
        if (type == "Melee") {
            switch (weapon) {
            case undefined:
                weapon = "Hunting Bow";
                switch(mode){
                        case "msg":
                            att.MessageFrom(n, dmg + " damage to " + name + " ( " + weapon + " ) @ " + distance + " m");
                            break;
                    
                        case "not":
                            att.Notice(dmg + " damage to " + name + " ( " + weapon + " ) @ " + distance + " m");
                            break;
                }
                break;
            
            default:
                switch(mode){
                        case "msg":
                            att.MessageFrom(n, dmg + " damage to " + name + " ( " + weapon + " ) @ " + distance + " m");
                            break;
                    
                        case "not":
                            att.Notice(dmg + " damage to " + name + " ( " + weapon + " ) @ " + distance + " m");
                            break;
                }           
                break;
            }
        }
        if (type == "Bullet") {
            switch(mode){
                        case "msg":
                            att.MessageFrom(n, dmg + " damage to " + name + " ( " + weapon + " ) @ " + distance + " m");
                            break;
                    
                        case "not":
                            att.Notice(dmg + " damage to " + name + " ( " + weapon + " ) @ " + distance + " m");
                            break;
                }
        }
    }
}

function On_EntityHurt(he) {
    var ini = Plugin.GetIni("showdamage");
    if (ini.GetSetting("Settings", "status") == "on") {
        var n = ini.GetSetting("Settings", "display");
        var mode = ini.GetSetting("Settings", "mode");        
        var att = he.Attacker;
        var ent = he.Entity;        
        var dmg = Math.round(he.DamageAmount);
        if (dmg == 0) {
            return;
        }
        var type = he.DamageType;
        var weapon = he.WeaponName;
        if (weapon == "Shotgun") {
            var s = DataStore.Get("SDFIX", att.Name);
            if (isNaN(s)) {
                DataStore.Add("SDFIX", att.Name, dmg);
                DataStore.Add("SDFIX2", att.Name, name);
            }
            else {
                DataStore.Add("SDFIX", att.Name, s+dmg);
            }
            DataStore.Save();
            Plugin.CreateTimer("Shotgun", 400).Start();
            return;
        }
        var attloc = att.Location;
        var vicloc = Util.CreateVector(ent.X, ent.Y, ent.Z);
        var distance = Util.GetVectorsDistance(attloc, vicloc);
        distance = Number(distance).toFixed(2);        
        var entname = getEntityName(ent.Name);
        if (type == "Explosion") {
            if(dmg>200){
                weapon = "C4";
            }
            else{
                weapon = "F1 Grenade";
            }
            switch(mode){
                case "msg":
                    att.MessageFrom(n, dmg + " damage to " + entname + " ( " + weapon + " )");
                    break;
                    
                case "not":
                    att.Notice(dmg + " damage to " + entname + " ( " + weapon + " )");
                    break;
            }
        }
        if (type == "Melee") {
            switch(mode){
                case "msg":
                    att.MessageFrom(n, dmg + " damage to " + entname + " ( " + weapon + " )");
                    break;
                    
                case "not":
                    att.Notice(dmg + " damage to " + entname + " ( " + weapon + " )");
                    break;
            }
        }
        if (type == "Bullet") {
            switch(mode){
                case "msg":
                    att.MessageFrom(n, dmg + " damage to " + entname + " ( " + weapon + " ) @ " + distance + " m");
                    break;
                    
                case "not":
                    att.Notice(dmg + " damage to " + entname + " ( " + weapon + " ) @ " + distance + " m");
                    break;
            }
        }
    }
}

//Commands of the plugin
function On_Command(Player, cmd, args) {
    if (Player.Admin) {
        if (cmd == "showdamage"  || cmd == "sd") {
            var ini = Plugin.GetIni("showdamage");
            switch (args.Length) {
            case 0:
                Player.MessageFrom("ShowDamage", "ShowDamage 1.3.1 by Snake");
                Player.MessageFrom("ShowDamage", "---------------------------------");
                Player.MessageFrom("ShowDamage", "Use '/showdamage' to see this info");
                Player.MessageFrom("ShowDamage", "Use '/showdamage [on/off]' to change the status");
                Player.MessageFrom("ShowDamage", "Use '/showdamage mode [msg/not]' to change the mode");
                Player.MessageFrom("ShowDamage", "Use '/showdamage display x' to change the display name when in msg mode");
                Player.MessageFrom("ShowDamage", "Use '/showdamage status' to see the status and display name");
                break;

            case 1:
                if (!Plugin.IniExists("showdamage")) {
                    Plugin.CreateIni("showdamage");
                    var ini = Plugin.GetIni("showdamage");
                    ini.AddSetting("Settings", "status", "off");
                }
                switch (args[0]) {
                case "on":
                    ini.AddSetting("Settings", "status", "on");
                    ini.Save();
                    Player.MessageFrom("ShowDamage", "Switched to ON");
                    break;

                case "off":
                    ini.AddSetting("Settings", "status", "off");
                    ini.Save();
                    Player.MessageFrom("ShowDamage", "Switched to OFF");
                    break;

                case "status":
                    var status = ini.GetSetting("Settings", "status");
                    var display = ini.GetSetting("Settings", "display");
                    var mode = ini.GetSetting("Settings", "mode");
                    Player.MessageFrom("ShowDamage", "ShowDamage 1.3 by Snake");
                    Player.MessageFrom("ShowDamage", "--------------------------------");
                    Player.MessageFrom("ShowDamage", "Status : " + status);
                    Player.MessageFrom("ShowDamage", "Display Name : " + display);
                    Player.MessageFrom("ShowDamage", "Mode : " + mode);
                    break;
                }
                break;

            case 2:
                switch(args[0]) {
                    case "display":
                        ini.AddSetting("Settings", "display", args[1]);
                        ini.Save();
                        Player.MessageFrom("ShowDamage", "Display name changed to " + args[1]);
                        break;
                    
                    case "mode":
                        switch(args[1]){
                            case "msg":
                                ini.AddSetting("Settings", "mode", "msg");
                                ini.Save();
                                Player.MessageFrom("ShowDamage", "Mode changed to " + "msg");
                                break;
                                
                            case "not":
                                ini.AddSetting("Settings", "mode", "not");
                                ini.Save();
                                Player.MessageFrom("ShowDamage", "Mode changed to " + "not");
                                break;
                                
                            default:
                                Player.MessageFrom("ShowDamage", "Invalid command");
                                break;
                        }
                        break;
                        
                    default:
                        Player.MessageFrom("ShowDamage", "Invalid command");
                        break;
                }

            default:
                Player.MessageFrom("ShowDamage", "Invalid command");
                break;
            }
        }
    }
}