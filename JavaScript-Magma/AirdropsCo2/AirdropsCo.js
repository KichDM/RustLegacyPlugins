// Version 1.5 Beta
// Created by Ruppi

var ConfigName = 'AirdropsCo';
var ACVersion = '1.5 Beta';

function TimeStamp() {
    var YearTimeStamp = Number(System.DateTime.Now.ToString("yyyy")) * (60 * 60 * 24 * 365);
    var MonthTimeStamp = Number(System.DateTime.Now.ToString("MM")) * (60 * 60 * 24 * 30);
    var DayTimeStamp = Number(System.DateTime.Now.ToString("dd")) * (60 * 60 * 24);
    var HourTimeStamp = Number(System.DateTime.Now.ToString("HH")) * (60 * 60);
    var MinutesTimeStamp = Number(System.DateTime.Now.ToString("mm")) * 60;
    var SecendTimeStamp = Number(System.DateTime.Now.ToString("ss"));
    var TimeStampNow = YearTimeStamp + MonthTimeStamp + DayTimeStamp + HourTimeStamp + MinutesTimeStamp + SecendTimeStamp;
    return TimeStampNow;    
}

function language() {
    return Data.GetConfigValue(ConfigName, "Settings", "language");
}

function On_Command(Player, cmd, args) {
    cmd = Data.ToLower(cmd);

    if(Data.GetConfigValue(ConfigName, "Settings", "enable") != "true")
    {
        cmd = null;
    }

    if(cmd == "help")
    {
        Player.Message("Airdrop&Co - Plugin Version: " + ACVersion + ". Made by Ruppi. /achelp to help.");
    }

    if(cmd == "achelp")
    {
        if(Player.Admin == true)
        {
            Player.Message("Airdrop&Co - Plugin Version: " + ACVersion + ". Made by Ruppi.");
            Player.Message("Airdrop-Command:");
            Player.Message("/airdrop *X*, /airdrop *NAME* *X*, /airdrop self *X*");
            Player.Message("AirdropTimer-Command:");
            Player.Message("/airdroptimer show, /airdroptimer start, /airdroptimer stop");
            Player.Message("Find-Command:");
            Player.Message("/find *NAME*");
            Player.Message("Summon-Command:");
            Player.Message("/summon help, /summon *NAME* *ID* *COUNT*");
            Player.Message("Time-Command:");
            Player.Message("/time day, /time night, /time set *TIME*, /time say, /time start, /time stop");
            Player.Message("Home-SetHome-DelHome-Command:");
            Player.Message("/home *NAME*, /sethome *NAME*, /delhome *NAME*, /delhome all");
            Player.Message("Spawn-SetSpawn-DelSpawn-Command:");
            Player.Message("/spawn, /setspawn, /delspawn");
            Player.Message("Timer-Command:");
            Player.Message("/timer start, /timer stop, /timer show");
            Player.Message("Clan-Command:");
            Player.Message("/clan create *CLANNAME*, /clan add *NAME*, /clan accept, /clan reject, /clan list, /clan message *TEXT*, /clan delete, /clan kick *NAME*");
            Player.Message("Player-Command:");
            Player.Message("/player info, /clan best");
            Player.Message("Realtime-Command:");
            Player.Message("/realtime real, /realtime default, /realtime");
            Player.Message("Another-Command:");
            Player.Message("/getp *NAME*");
        } else {
            Player.Message("Airdrop&Co - Plugin Version: " + ACVersion + ". Made by Ruppi.");
            Player.Message("Find-Command:");
            Player.Message("/find *NAME*");
            Player.Message("Time-Command:");
            Player.Message("/time say");
            Player.Message("Home-SetHome-DelHome-Command:");
            Player.Message("/home *NAME*, /sethome *NAME*, /delhome *NAME*, /delhome all");
            Player.Message("Spawn-SetSpawn-DelSpawn-Command:");
            Player.Message("/spawn, /setspawn, /delspawn");
            Player.Message("Clan-Command:");
            Player.Message("/clan create *CLANNAME*, /clan add *NAME*, /clan accept, /clan reject, /clan list, /clan message *TEXT*, /clan delete, /clan kick *NAME*");
            Player.Message("Player-Command:");
            Player.Message("/player info, /clan best");
        }
    }

    if(cmd == "airdrop")
    {
        if(Data.GetConfigValue(ConfigName, "Airdrop", "enable") == "true")
        {
            if(Player.Admin == true)
            {
                if(args[0] == "self")
                {
                    if(args[1] >= 1)
                    {
                        if(args[1] <= Number(Data.GetConfigValue(ConfigName, "Airdrop", "max_amount")))
                        {
                            World.AirdropAtPlayer(Player, args[1]);
                            if(language() == "de")
                            {
                                Player.Message("Airdrop wurde fuer dich " + args[1] + "x gerufen.");
                            } else {
                                Player.Message("Airdrop was created for you " + args[1] + "x.");
                            }
                        }
                    }
                }
                else if(args[0] >= 1)
                {
                    if(args[0] <= Number(Data.GetConfigValue(ConfigName, "Airdrop", "max_amount")))
                    {
                        World.Airdrop(args[0]);
                        if(language() == "de")
                        {
                            Player.Message("Airdrop wurde " + args[0] + "x gerufen.");
                        } else {
                            Player.Message("Airdrop was created " + args[0] + "x.");
                        }
                    }
                }
                else if(SearchUser(args[0].Replace('"', '')) != null)
                {
                    if(args[1] >= 1)
                    {
                        if(args[1] <= Number(Data.GetConfigValue(ConfigName, "Airdrop", "max_amount")))
                        {
                            if(Player.Name == SearchUser(args[0].Replace('"', '')).Name)
                            {
                                World.AirdropAtPlayer(Player, args[1]);
                                if(language() == "de")
                                {
                                    Player.Message("Airdrop wurde fuer dich " + args[1] + "x gerufen.");
                                } else {
                                    Player.Message("Airdrop was created for you " + args[1] + "x.");
                                }
                            } else {
                                World.AirdropAtPlayer(SearchUser(args[0].Replace('"', '')), args[1]);
                                if(language() == "de")
                                {
                                    Player.Message("Airdrop wurde fuer " + SearchUser(args[0].Replace('"', '')).Name + " " + args[1] + "x gerufen.");
                                } else {
                                    Player.Message("Airdrop was created for " + SearchUser(args[0].Replace('"', '')).Name + " " + args[1] + "x.");
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    if(cmd == "summon")
    {
        if(Data.GetConfigValue(ConfigName, "Summon", "enable") == "true")
        {
            if(Player.Admin == true)
            {               
                if(args[0] == "help")
                {
                    if(language() == "de")
                    {
                        Player.Message("ID => Bedeutung");
                        Player.Message("ID: 1 => Holzstapel, ID: 2 => Stein (Gold), ID: 3 => Stein (Grau), ID: 4 => Stein (Bronze)");
                        Player.Message("ID: 5 => Hirsch, ID: 6 => Schwein, ID: 7 => Huhn, ID: 8 => Hase, ID: 9 => Baer");
                        Player.Message("ID: 10 => Wolf, ID: 11 => Mutanten Baer, ID: 12 => Mutanten Wolf, ID: 13 => Munition-Box");
                        Player.Message("ID: 14 => Medizin-Box, ID: 15 => Box, ID: 16 => Waffen-Box, ID: 17 => Airdrop-Box, ID: 18 => Flugzeug");
                        Player.Message("Befehl: /summon " + Player.Name + " 1 1.");
                    } else {
                        Player.Message("ID => Description");
                        Player.Message("ID: 1 => Woodpile, ID: 2 => Stone (Gold), ID: 3 => Stone (Grey), ID: 4 => Stone (Bronze)");
                        Player.Message("ID: 5 => Deer, ID: 6 => Pig, ID: 7 => Chicken, ID: 8 => Rabbit, ID: 9 => Bear");
                        Player.Message("ID: 10 => Wolf, ID: 11 => Mutants Bear, ID: 12 => Mutants Wolf, ID: 13 => Ammo-Box");
                        Player.Message("ID: 14 => Medical-Box, ID: 15 => Box, ID: 16 => Weapon-Box, ID: 17 => Airdrop-Box, ID: 18 => Plane");
                        Player.Message("Command: /summon " + Player.Name + " 1 1.");
                    }

                }
                else if(SearchUser(args[0].Replace('"', '')) != null)
                {                    
                    if(language() == "de")
                    {
                        var IDs = [["", "", ""], ["Holzstapel", ";res_woodpile", "object"], ["Stein (Gold)", ";res_ore_1", "object"], ["Stein (Grau)", ";res_ore_2", "object"], ["Stein (Bronze)", ";res_ore_3", "object"], ["Hirsch", ":stag_prefab", "good_animal"], ["Schwein", ":boar_prefab", "good_animal"], ["Huhn", ":chicken_prefab", "good_animal"], ["Hase", ":rabbit_prefab_a", "good_animal"], ["Baer", ":bear_prefab", "evil_animal"], ["Wolf", ":wolf_prefab", "evil_animal"], ["Mutanten Baer", ":mutant_bear", "evil_animal"], ["Mutanten Wolf", ":mutant_wolf", "evil_animal"], ["Munition-Box", "AmmoLootBox", "box"], ["Medizin-Box", "MedicalLootBox", "box"], ["Box", "BoxLoot", "box"], ["Waffen-Box", "WeaponLootBox", "box"], ["Airdrop-Box", "SupplyCrate", "box"], ["Flugzeug", "C130", "plane"]];
                    } else {
                        var IDs = [["", "", ""], ["Woodpile", ";res_woodpile", "object"], ["Stone (Gold)", ";res_ore_1", "object"], ["Stone (Grey)", ";res_ore_2", "object"], ["Stone (Bronze)", ";res_ore_3", "object"], ["Deer", ":stag_prefab", "good_animal"], ["pig", ":boar_prefab", "good_animal"], ["Chicken", ":chicken_prefab", "good_animal"], ["Rabbit", ":rabbit_prefab_a", "good_animal"], ["Bear", ":bear_prefab", "evil_animal"], ["Wolf", ":wolf_prefab", "evil_animal"], ["Mutant Bear", ":mutant_bear", "evil_animal"], ["Mutant Wolf", ":mutant_wolf", "evil_animal"], ["Ammo-Box", "AmmoLootBox", "box"], ["Medical-Box", "MedicalLootBox", "box"], ["Box", "BoxLoot", "box"], ["Weapon-Box", "WeaponLootBox", "box"], ["Airdrop-Box", "SupplyCrate", "box"], ["Plane", "C130", "plane"]];           
                    }
                    var splayer = SearchUser(args[0].Replace('"', ''));
                    var loc = splayer.Location;
                    var count = 1;
                    var distance = {};
                    distance["object"] = 1.7;
                    distance["good_animal"] = 1;
                    distance["evil_animal"] = 1;
                    distance["box"] = 1.7;
                    distance["plane"] = -50;
                    var id = args[1];

                    if(Number(args[2]) >= 1)
                    {
                        if(Number(args[2]) <= 50)
                        {
                            count = args[2];
                        }
                    }
                    
                    if(IDs[id][1] != null)
                    {
                        loc.x = loc.x + Number(Data.GetConfigValue(ConfigName, "Summon", IDs[id][2] + "_distance"));
                        loc.z = loc.z + Number(Data.GetConfigValue(ConfigName, "Summon", IDs[id][2] + "_distance"));
                        loc.y = loc.y - distance[IDs[id][2]];
                        World.Spawn(IDs[id][1], loc, count);
                        if(language() == "de")
                        {
                            Player.Message(IDs[id][0] + " wurde fuer " + splayer.Name + " gerufen.");
                        } else {
                            Player.Message(IDs[id][0] + " was set for " + splayer.Name + ".");
                        }       
                    }
                }
            }
        }
    }

    if(cmd == "find")
    {
        if(Data.GetConfigValue(ConfigName, "Find", "enable") == "true")
        {            
            if(SearchUser(args[0].Replace('"', '')) != null)
            {
                if(language() == "de")
                {
                    Player.Message("Player => " + SearchUser(args[0].Replace('"', '')).Name + " ist Online.");
                } else {
                    Player.Message("Player => " + SearchUser(args[0].Replace('"', '')).Name + " is Online.");
                }
            } else {
                if(language() == "de")
                {
                    Player.Message("Player => " + args[0].Replace('"', '') + " ist Offline.");
                } else {
                    Player.Message("Player => " + args[0].Replace('"', '') + " is Offline." );
                }
            }
        }
    }

    if(cmd == "time")
    {
        if(Data.GetConfigValue(ConfigName, "Time", "enable") == "true")
        {
            if(args[0] == "day")
            {
                if(Player.Admin == true)
                {
                    var ak_time = Number(Data.GetConfigValue(ConfigName, "Time", "day_time"));

                    if(ak_time >= 0)
                    {
                        if(ak_time <= 23)
                        {
                            var pm_am = Data.GetConfigValue(ConfigName, "Time", "time_pm_am");
                            World.Time = ak_time;

                            if(pm_am == "false")
                            {
                                var time_now = ak_time + ":00";
                            } else {
                                if(ak_time >= 12)
                                {
                                    if(ak_time > 12)
                                    {
                                        var time_now = (ak_time - 12) + ":00 PM";
                                    } else {
                                        var time_now = ak_time + ":00 PM";
                                    }
                                } else {
                                    if(ak_time < 1)
                                    {
                                        var time_now = (Number(ak_time) + 12) + ":00 AM";
                                    } else {
                                        var time_now = ak_time + ":00 AM";
                                    }
                                }
                            }

                            if(time_now != null)
                            {
                                if(language() == "de")
                                {
                                    Player.Message("Die Uhrzeit wurde auf " + time_now + " gesetzt.");
                                } else {
                                    Player.Message("The Time was set to " + time_now + ".");
                                }
                            }
                        }
                    }
                }
            }
            else if(args[0] == "night")
            {
                if(Player.Admin == true)
                {
                    var ak_time = Number(Data.GetConfigValue(ConfigName, "Time", "night_time"));

                    if(ak_time >= 0)
                    {
                        if(ak_time <= 23)
                        {
                            var pm_am = Data.GetConfigValue(ConfigName, "Time", "time_pm_am");
                            World.Time = ak_time;

                            if(pm_am == "false")
                            {
                                var time_now = ak_time + ":00";
                            } else {
                                if(ak_time >= 12)
                                {
                                    if(ak_time > 12)
                                    {
                                        var time_now = (ak_time - 12) + ":00 PM";
                                    } else {
                                        var time_now = ak_time + ":00 PM";
                                    }
                                } else {
                                    if(ak_time < 1)
                                    {
                                        var time_now = (Number(ak_time) + 12) + ":00 AM";
                                    } else {
                                        var time_now = ak_time + ":00 AM";
                                    }
                                }
                            }

                            if(time_now != null)
                            {
                                if(language() == "de")
                                {
                                    Player.Message("Die Uhrzeit wurde auf " + time_now + " gesetzt.");
                                } else {
                                    Player.Message("The Time was set to " + time_now + ".");
                                }
                            }
                        }
                    }
                }
            }
            else if(args[0] == "set")
            {
                if(Player.Admin == true)
                {
                    if(args[1] >= 0)
                    {
                        if(args[1] <= 23)
                        {
                            var pm_am = Data.GetConfigValue(ConfigName, "Time", "time_pm_am");
                            var ak_time = args[1];
                            World.Time = ak_time;

                            if(pm_am == "false")
                            {
                                var time_now = ak_time + ":00";
                            } else {
                                if(ak_time >= 12)
                                {
                                    if(ak_time > 12)
                                    {
                                        var time_now = (ak_time - 12) + ":00 PM";
                                    } else {
                                        var time_now = ak_time + ":00 PM";
                                    }
                                } else {
                                    if(ak_time < 1)
                                    {
                                        var time_now = (Number(ak_time) + 12) + ":00 AM";
                                    } else {
                                        var time_now = ak_time + ":00 AM";
                                    }
                                }
                            }

                            if(time_now != null)
                            {
                                if(language() == "de")
                                {
                                    Player.Message("Die Uhrzeit wurde auf " + time_now + " gesetzt.");
                                } else {
                                    Player.Message("The Time was set to " + time_now + ".");
                                }
                            }
                        } else {
                            if(language() == "de")
                            {
                                Player.Message("Gib eine gueltige Uhrzeit ein. (0 - 23)");
                            } else {
                                Player.Message("Please enter a valid time. (0 - 23)");
                            }
                        }
                    } else {
                        if(language() == "de")
                        {
                            Player.Message("Gib eine gueltige Uhrzeit ein. (0 - 23)");
                        } else {
                            Player.Message("Please enter a valid time. (0 - 23)");
                        }
                    }
                }
            }
            else if(args[0] == "say")
            {
                var std = Math.floor(World.Time);
                var min = World.Time - std;
                var pm_am = Data.GetConfigValue(ConfigName, "Time", "time_pm_am");
                min = Math.floor(60 / 100 * (100 / 1 * min));

                if(min < 10)
                {
                    if(pm_am == "false")
                    {
                        var time_now = std + ":0" + min;
                    } else {
                        if(std >= 12)
                        {
                            if(std > 12)
                            {
                                var time_now = (std - 12) + ":0" + min + " PM";
                            } else {
                                var time_now = std + ":0" + min + " PM";
                            }
                        } else {
                            if(std < 1)
                            {
                                var time_now = (std + 12) + ":0" + min + " AM";
                            } else {
                                var time_now = std + ":0" + min + " AM";
                            }
                        }
                    }
                } else {
                    if(pm_am == "false")
                    {
                        var time_now = std + ":" + min;
                    } else {
                        if(std >= 12)
                        {
                            if(std > 12)
                            {
                                var time_now = (std - 12) + ":" + min + " PM";
                            } else {
                                var time_now = std + ":" + min + " PM";
                            }
                        } else {
                            if(std < 1)
                            {
                                var time_now = (std + 12) + ":" + min + " AM";
                            } else {
                                var time_now = std + ":" + min + " AM";
                            }
                        }
                    }
                }

                if(time_now != null)
                {
                    var Hour = System.DateTime.Now.ToString("HH");
                    var Minutes = System.DateTime.Now.ToString("mm");
                    if(language() == "de")
                    {
                        Player.Message("Es ist jetzt " + time_now + ". Serverzeit: " + Hour + ":" + Minutes);
                    } else {
                        Player.Message("The Time is now " + time_now + " clock. Servertime: " + Hour + ":" + Minutes);
                    }
                }
            }
            else if(args[0] == "start")
            {
                if(Player.Admin == true)
                {
                    if(Data.GetConfigValue(ConfigName, "Time", "auto_display") == "true")
                    {
                        if(Data.GetConfigValue(ConfigName, "Settings", "auto_timer_enable") == "true")
                        {
                            if(GetTabled('Timer', 'TimeDisplay') != "on")
                            {
                                SetTabled('Timer', 'TimeDisplay', 'on');
                                var std = Math.floor(World.Time);
                                SetTabled('TimeDisplay', 'LastTime', std);
                                
                                if(language() == "de")
                                {
                                    Player.Message("TimeDisplay wurde angeschaltet.");
                                } else {
                                    Player.Message("TimeDisplay is now on.");
                                }
                            } else {
                                if(language() == "de")
                                {
                                    Player.Message("TimeDisplay ist an.");
                                } else {
                                    Player.Message("TimeDisplay is on.");
                                }    
                            }    
                        }    
                    }
                }
            }
            else if(args[0] == "stop")
            {
                if(Player.Admin == true)
                {
                    if(Data.GetConfigValue(ConfigName, "Time", "auto_display") == "true")
                    {
                        if(Data.GetConfigValue(ConfigName, "Settings", "auto_timer_enable") == "true")
                        {
                            if(GetTabled('Timer', 'TimeDisplay') != "off")
                            {
                                GetTabled('Timer', 'TimeDisplay', 'off');
                                
                                if(language() == "de")
                                {
                                    Player.Message("TimeDisplay wurde ausgeschaltet.");
                                } else {
                                    Player.Message("TimeDisplay is now off.");
                                }
                            } else {
                                if(language() == "de")
                                {
                                    Player.Message("TimeDisplay ist aus.");
                                } else {
                                    Player.Message("TimeDisplay is off.");
                                }    
                            }
                        }
                    }
                }
            }
        }
    }

    if(cmd == "airdroptimer")
    {
        if(Data.GetConfigValue(ConfigName, "AirdropTimer", "enable") == "true")
        {
            if(Player.Admin == true)
            {
                if(args[0] == "show")
                {
                    if(GetTabled('Timer', 'AirdropTimer') == "on")
                    {
                        if(language() == "de")
                        {
                            Player.Message("AirdropTimer ist an.");
                        } else {
                            Player.Message("AirdropTimer is on.");
                        }
                    } else {
                        if(language() == "de")
                        {
                            Player.Message("AirdropTimer ist aus.");
                        } else {
                            Player.Message("AirdropTimer is off.");
                        }
                    }
                }
                else if(args[0] == "start")
                {
                    if(Data.GetConfigValue(ConfigName, "AirdropTimer", "enable") == "true")
                    {
                        if(GetTabled('Timer', 'AirdropTimer') != "on")
                        {
                            if(Number(Data.GetConfigValue(ConfigName, "AirdropTimer", "call_airdrop_per_minutes")) > 0)
                            {
                                SetTabled('Hour', 'time', 0);
                                SetTabled('Timer', 'AirdropTimer', 'on');
                                if(language() == "de")
                                {
                                    Player.Message("AirdropTimer wurde angeschaltet.");
                                } else {
                                    Player.Message("AirdropTimer is now on.");
                                }
                            }
                        } else {
                            if(language() == "de")
                            {
                                Player.Message("AirdropTimer ist an.");
                            } else {
                                Player.Message("AirdropTimer is on.");
                            }
                        }
                    }
                }
                else if(args[0] == "stop")
                {
                    if(GetTabled('Timer', 'AirdropTimer') != "off")
                    {
                        SetTabled('Timer', 'AirdropTimer', 'off');
                        if(language() == "de")
                        {
                            Player.Message("AirdropTimer wurde ausgeschaltet.");
                        } else {
                            Player.Message("AirdropTimer is now off.");
                        }
                    } else {
                        if(language() == "de")
                        {
                            Player.Message("AirdropTimer ist aus.");
                        } else {
                            Player.Message("AirdropTimer is off.");
                        }
                    }
                }
            }
        }
    }

    if(cmd == "home")
    {
        if(Data.GetConfigValue(ConfigName, "Home", "enable") == "true")
        {
            if(Data.GetConfigValue(ConfigName, "SaveZone", "enable") == "true")
            {
                if(SaveZone(Player) != false)
                {
                    if(Data.GetConfigValue(ConfigName, "SaveZone", "teleport") == "true")
                    {
                        var release2 = true;
                    } else {
                        var release2 = false;
                    }
                } else {
                    var release2 = true;
                }
            } else {
                var release2 = true;
            }
            
            if(Data.GetConfigValue(ConfigName, "Home", "admin_only") == "true")
            {
                if(Player.Admin == true)
                {
                    var release = true;
                }
            } else {
                var release = true;
            }
            
            if(release == true)
            {
                if(release2 == true)
                {
                    if(args[0] == "list")
                    {
                    }
                    else if(args[0] != null)
                    {
                        var teleport = true;
                        var inihomeget = Plugin.GetIni("Home\\" + Player.SteamID);
                        var inihomelocx = inihomeget.GetSetting(args[0], 'locationX');
                        var inihomelocy = inihomeget.GetSetting(args[0], 'locationY');
                        var inihomelocz = inihomeget.GetSetting(args[0], 'locationZ');
        
                        if(inihomelocx != null)
                        {
                            if(inihomelocy != null)
                            {
                                if(inihomelocz != null)
                                {
                                    if(Data.GetConfigValue(ConfigName, "Cooldown", "enable") == "true")
                                    {
                                        var iniuserget = Plugin.GetIni("UserData\\" + Player.SteamID);
                                        if(TimeStamp() <= Number(iniuserget.GetSetting('Information', 'cooldown')))
                                        {
                                            teleport = false;    
                                        }
                                    }
                                    
                                    if(teleport == true)
                                    {
                                        if(Data.GetConfigValue(ConfigName, "Cooldown", "enable") == "true")
                                        {
                                            var iniuserget = Plugin.GetIni("UserData\\" + Player.SteamID);
                                            var newer = TimeStamp() + Number(Data.GetConfigValue(ConfigName, "Cooldown", "cooldown_in_second"));
                                            iniuserget.AddSetting('Information', 'cooldown', newer);    
                                            iniuserget.Save();    
                                        }
                                        Player.TeleportTo(inihomelocx, inihomelocy, inihomelocz);
                                        Player.Message("HomeName: " + args[0] + " | HomeLocation: X: " + inihomelocx + ", Y: " + inihomelocy + ", Z: " + inihomelocz);
                                    } else {
                                        if(language() == "de")
                                        {
                                            Player.Message('Du bist noch nicht bereit, dich zu Teleportieren.');
                                        } else {
                                            Player.Message("You are not yet ready to get to teleport.");
                                        }                               
                                    }         
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    if(cmd == "sethome")
    {
        if(Data.GetConfigValue(ConfigName, "SetHome", "enable") == "true")
        {
            if(Data.GetConfigValue(ConfigName, "SaveZone", "enable") == "true")
            {
                if(SaveZone(Player) != false)
                {
                    if(Data.GetConfigValue(ConfigName, "SaveZone", "set_home_allowed") == "true")
                    {
                        var release2 = true;
                    } else {
                        var release2 = false;
                    }
                } else {
                    var release2 = true;
                }
            } else {
                var release2 = true;
            }
            
            if(Data.GetConfigValue(ConfigName, "SetHome", "admin_only") == "true")
            {
                if(Player.Admin == true)
                {
                    var release = true;
                }
            } else {
                var release = true;
            }
            
            if(release == true)
            {
                if(release2 == true)
                {
                    if(args[0] != null)
                    {
                        if(args[0] != "list")
                        {
                            if(args[0] != "all")
                            {
                                var inihomeget = Plugin.GetIni("Home\\" + Player.SteamID);
                                if(inihomeget == null)
                                {
                                    var inihomeget = Plugin.CreateIni("Home\\" + Player.SteamID);
                                    var inihomecount = 0;
                                } else {
                                    var inihomecount = inihomeget.GetSetting('Count', 'home_count');
                                }
                                var inihomelocx = inihomeget.GetSetting(args[0], 'locationX');
                                var inihomelocy = inihomeget.GetSetting(args[0], 'locationY');
                                var inihomelocz = inihomeget.GetSetting(args[0], 'locationZ');
        
                                if(inihomelocx == null)
                                {
                                    if(inihomelocy == null)
                                    {
                                        if(inihomelocz == null)
                                        {
                                            if(Number(inihomecount) < Number(Data.GetConfigValue(ConfigName, "SetHome", "max_homes")))
                                            {
                                                var loc = Player.Location;
                                                inihomeget.AddSetting(args[0], 'locationX', loc.x);
                                                inihomeget.AddSetting(args[0], 'locationY', loc.y);
                                                inihomeget.AddSetting(args[0], 'locationZ', loc.z);
                                                inihomeget.AddSetting('Count', 'home_count', (Number(inihomecount) + 1));
                                                inihomeget.Save();
        
                                                if(language() == "de")
                                                {
                                                    Player.Message("Home wurde gesetzt.");
                                                } else {
                                                    Player.Message("Home has been set.");
                                                }
                                            } else {
                                                if(language() == "de")
                                                {
                                                    Player.Message("Du kannst nicht mehrere Home setzten.");
                                                } else {
                                                    Player.Message("You can not put multiple Home.");
                                                }
                                            }
                                        } else {
                                            if(language() == "de")
                                            {
                                                Player.Message("Name ist vergeben.");
                                            } else {
                                                Player.Message("Name is assigned.");
                                            }
                                        }
                                    } else {
                                        if(language() == "de")
                                        {
                                            Player.Message("Name ist vergeben.");
                                        } else {
                                            Player.Message("Name is assigned.");
                                        }
                                    }
                                } else {
                                    if(language() == "de")
                                    {
                                        Player.Message("Name ist vergeben.");
                                    } else {
                                        Player.Message("Name is assigned.");
                                    }
                                }
                            } else {
                                if(language() == "de")
                                {
                                    Player.Message("Dieser Name darf nicht vergeben werden.");
                                } else {
                                    Player.Message("This name must not be assigned.");
                                }
                            }
                        } else {
                            if(language() == "de")
                            {
                                Player.Message("Dieser Name darf nicht vergeben werden.");
                            } else {
                                Player.Message("This name must not be assigned.");
                            }
                        }
                    }
                }
            }
        }
    }

    if(cmd == "delhome")
    {
        if(Data.GetConfigValue(ConfigName, "DelHome", "enable") == "true")
        {
            if(Data.GetConfigValue(ConfigName, "DelHome", "admin_only") == "true")
            {
                if(Player.Admin == true)
                {
                    var release = true;
                }
            } else {
                var release = true;
            }

            if(release == true)
            {
                if(args[0] != null)
                {
                    if(args[0] != "list")
                    {
                        if(args[0] != "all")
                        {
                            var inihomeget = Plugin.GetIni("Home\\" + Player.SteamID);
                            var inihomelocx = inihomeget.GetSetting(args[0], 'locationX');
                            var inihomelocy = inihomeget.GetSetting(args[0], 'locationY');
                            var inihomelocz = inihomeget.GetSetting(args[0], 'locationZ');
                            var inihomecount = inihomeget.GetSetting('Count', 'home_count');
    
                            if(inihomelocx != null)
                            {
                                if(inihomelocy != null)
                                {
                                    if(inihomelocz != null)
                                    {
                                        inihomeget.DeleteSetting(args[0], 'locationX');
                                        inihomeget.DeleteSetting(args[0], 'locationY');
                                        inihomeget.DeleteSetting(args[0], 'locationZ');
                                        inihomeget.AddSetting('Count', 'home_count', (Number(inihomecount) - 1));
                                        inihomeget.Save();
    
                                        if(language() == "de")
                                        {
                                            Player.Message("Home wurde entfernt.");
                                        } else {
                                            Player.Message("Home has been removed.");
                                        }
                                    } else {
                                        if(language() == "de")
                                        {
                                            Player.Message("Name ist nicht vergeben.");
                                        } else {
                                            Player.Message("Name is not assigned.");
                                        }
                                    }
                                } else {
                                    if(language() == "de")
                                    {
                                        Player.Message("Name ist nicht vergeben.");
                                    } else {
                                        Player.Message("Name is not assigned.");
                                    }
                                }
                            } else {
                                if(language() == "de")
                                {
                                    Player.Message("Name ist nicht vergeben.");
                                } else {
                                    Player.Message("Name is not assigned.");
                                }
                            }
                        } else {
                            var inihomeget = Plugin.CreateIni("Home\\" + Player.SteamID);
                            var inihomecount = inihomeget.AddSetting('Count', 'home_count', 0);
                            inihomeget.Save();
                            if(language() == "de")
                            {
                                Player.Message("Es wurden alle Home entfernt.");
                            } else {
                                Player.Message("It all home were removed.");
                            }
                        }
                    }
                }
            }
        }
    }

    if(cmd == "spawn")
    {
        if(Data.GetConfigValue(ConfigName, "Spawn", "enable") == "true")
        {
            if(Data.GetConfigValue(ConfigName, "SaveZone", "enable") == "true")
            {
                
                if(SaveZone(Player) != false)
                {
                    if(Data.GetConfigValue(ConfigName, "SaveZone", "teleport") == "true")
                    {
                        var release2 = true;
                    } else {
                        var release2 = false;    
                    }
                } else {
                    var release2 = true;
                }
            } else {
                var release2 = true;
            }
            
            if(Data.GetConfigValue(ConfigName, "Spawn", "admin_only") == "true")
            {
                if(Player.Admin == true)
                {
                    var release = true;
                }
            } else {
                var release = true;
            }

            if(release == true)
            {
                if(release2 == true)
                {
                    var teleport = true;
                    var inispawnget = Plugin.GetIni("Spawn\\" + Player.SteamID);
                    var inispawnlocx = inispawnget.GetSetting('Spawn', 'locationX');
                    var inispawnlocy = inispawnget.GetSetting('Spawn', 'locationY');
                    var inispawnlocz = inispawnget.GetSetting('Spawn', 'locationZ');
                    if(inispawnlocx != null)
                    {
                        if(inispawnlocy != null)
                        {
                            if(inispawnlocz != null)
                            {
                                if(Data.GetConfigValue(ConfigName, "Cooldown", "enable") == "true")
                                {
                                    var iniuserget = Plugin.GetIni("UserData\\" + Player.SteamID);
                                    if(TimeStamp() <= Number(iniuserget.GetSetting('Information', 'cooldown')))
                                    {
                                        teleport = false;
                                    }
                                }
                                
                                if(teleport == true)
                                {
                                    if(Data.GetConfigValue(ConfigName, "Cooldown", "enable") == "true")
                                    {
                                        var iniuserget = Plugin.GetIni("UserData\\" + Player.SteamID);
                                        var newer = TimeStamp() + Number(Data.GetConfigValue(ConfigName, "Cooldown", "cooldown_in_second"));
                                        iniuserget.AddSetting('Information', 'cooldown', newer);
                                        iniuserget.Save();
                                    }
                                    Player.TeleportTo(inispawnlocx, inispawnlocy, inispawnlocz);
                                    Player.Message("Spawn-Location: X: " + inispawnlocx + ", Y: " + inispawnlocy + ", Z: " + inispawnlocz);
                                } else {
                                    if(language() == "de")
                                    {
                                        Player.Message('Du bist noch nicht bereit, dich zu Teleportieren.');
                                    } else {
                                        Player.Message("You are not yet ready to get to teleport.");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    if(cmd == "setspawn")
    {
        if(Data.GetConfigValue(ConfigName, "SetSpawn", "enable") == "true")
        {
            if(Data.GetConfigValue(ConfigName, "SaveZone", "enable") == "true")
            {
                if(SaveZone(Player) != false)
                {
                    if(Data.GetConfigValue(ConfigName, "SaveZone", "set_spawn_allowed") == "true")
                    {
                        var release2 = true;
                    } else {
                        var release2 = false;
                    }
                } else {
                    var release2 = true;
                }
            } else {
                var release2 = true;
            }
            
            if(Data.GetConfigValue(ConfigName, "DelSpawn", "admin_only") == "true")
            {
                if(Player.Admin == true)
                {
                    var release = true;
                }
            } else {
                var release = true;
            }

            if(release == true)
            {
                if(release == true)
                {
                    var inispawnget = Plugin.CreateIni("Spawn\\" + Player.SteamID);
                    var loc = Player.Location;
                    inispawnget.AddSetting('Spawn', 'locationX', loc.x);
                    inispawnget.AddSetting('Spawn', 'locationY', loc.y);
                    inispawnget.AddSetting('Spawn', 'locationZ', loc.z);
                    inispawnget.Save();
        
                    if(language() == "de")
                    {
                        Player.Message("Spawn wurde gesetzt.");
                    } else {
                        Player.Message("Spawn has been set.");
                    }
                }
            }
        }
    }

    if(cmd == "delspawn")
    {
        if(Data.GetConfigValue(ConfigName, "DelSpawn", "enable") == "true")
        {
            if(Data.GetConfigValue(ConfigName, "DelSpawn", "admin_only") == "true")
            {
                if(Player.Admin == true)
                {
                    var release = true;
                }
            } else {
                var release = true;
            }

            if(release == true)
            {
                var inispawnget = Plugin.CreateIni("Spawn\\" + Player.SteamID);
                if(language() == "de")
                {
                    Player.Message("Spawn wurde entfernt.");
                } else {
                    Player.Message("Spawn has been removed.");
                }
            }
        }
    }
    
    if(cmd == "timer")
    {
        if(Player.Admin == true)
        {
            if(args[0] == "start")
            {
                if(Plugin.GetTimer("AutoTimer") == null)
                {
                    Plugin.CreateTimer("AutoTimer", 1000).Start();
                    if(language() == "de")
                    {
                        Player.Message("Timer wurde angeschaltet.");
                    } else {
                        Player.Message("Timer is now on.");
                    }
                } else {
                    if(language() == "de")
                    {
                        Player.Message("Timer ist an.");
                    } else {
                        Player.Message("Timer is on.");
                    }    
                }
            }
            else if(args[0] == "stop")
            {
                if(Plugin.GetTimer("AutoTimer") != null)
                {
                    Plugin.KillTimer("AutoTimer");
                    if(language() == "de")
                    {
                        Player.Message("Timer wurde ausgeschaltet.");
                    } else {
                        Player.Message("Timer is now off.");
                    }
                } else {
                    if(language() == "de")
                    {
                        Player.Message("Timer ist aus.");
                    } else {
                        Player.Message("Timer is off.");
                    }    
                }
            }
            else if(args[0] == "show")
            {
                if(Plugin.GetTimer("AutoTimer") != null)
                {
                    if(language() == "de")
                    {
                        Player.Message("AirdropTimer ist an.");
                    } else {
                        Player.Message("AirdropTimer is on.");
                    }
                } else {
                    if(language() == "de")
                    {
                        Player.Message("AirdropTimer ist aus.");
                    } else {
                        Player.Message("AirdropTimer is off.");
                    }
                }
            }
        }
    }
    
    if(cmd == "clan")
    {
        if(Data.GetConfigValue(ConfigName, "Clan", "enable") == "true")
        {
            var iniuserget = Plugin.GetIni("UserData\\" + Player.SteamID);
            
            if(args[0] == "create")
            {
                if(iniuserget.GetSetting('Information', 'clan') == null)
                {
                    if(Data.StrLen(args[1].Replace('"', '')) >= 3)
                    {
                        if(Data.StrLen(args[1].Replace('"', '')) <= 15)
                        {
                            var iniclanget = Plugin.GetIni("Clan\\" + args[1].Replace('"', ''));
                            var ok = 1;
                            
                            if(iniclanget == null)
                            {
                                ok = 2;    
                            }
                            else if(iniclanget.GetSetting(args[1].Replace('"', ''), 'admin') == null)
                            {
                                ok = 2;    
                            }
                            
                            if(ok != 1)
                            {
                                var iniclanget = Plugin.CreateIni("Clan\\" + args[1].Replace('"', ''));
                                iniclanget.AddSetting(args[1].Replace('"', ''), 'admin', Player.SteamID);
                                iniclanget.AddSetting(args[1].Replace('"', ''), 'player_count', 1);
                                iniclanget.AddSetting(args[1].Replace('"', ''), 'player1', Player.SteamID);
                                iniclanget.Save();
                                iniuserget.AddSetting('Information', 'clan', args[1].Replace('"', ''));
                                iniuserget.Save();
                                if(language() == "de")
                                {
                                    Player.Message(args[1].Replace('"', '') + " wurde erfolgreich erstellt.");
                                } else {
                                    Player.Message(args[1].Replace('"', '') + " was successfully created.");
                                }
                            } else {
                                if(language() == "de")
                                {
                                    Player.Message("Dieser Name existiert bereits.");
                                } else {
                                    Player.Message("This name already exists.");
                                }
                            }
                        } else {
                            if(language() == "de")
                            {
                                Player.Message("Dieser Name darf nicht laenger sein als 15 Buchstaben.");
                            } else {
                                Player.Message("This name must not be longer than 15 characters.");
                            }
                        }
                    } else {
                        if(language() == "de")
                        {
                            Player.Message("Dieser Name darf nicht kleiner sein als 3 Buchstaben.");
                        } else {
                            Player.Message("This name must not be less than 3 characters.");
                        }
                    }
                } else {
                    if(language() == "de")
                    {
                        Player.Message("Du bist bereits in einem Clan.");
                    } else {
                        Player.Message("You are already in a clan.");
                    }
                }
            }
            else if(args[0] == "add")
            {
                if(iniuserget.GetSetting('Information', 'clan') != null)
                {
                    if(SearchUser(args[1].Replace('"', '')) != null)
                    {
                        var iniclanget = Plugin.GetIni("Clan\\" + iniuserget.GetSetting('Information', 'clan'));
                        if(iniclanget.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'admin') == Player.SteamID)
                        {
                            var iniuserget2 = Plugin.GetIni("UserData\\" + SearchUser(args[1].Replace('"', '')).SteamID);
                            if(iniuserget2.GetSetting('Information', 'clan') == null)
                            {
                                if(GetTabled('ClanAdd', SearchUser(args[1].Replace('"', '')).SteamID) == iniuserget.GetSetting('Information', 'clan'))
                                {
                                    if(language() == "de")
                                    {
                                        SearchUser(args[1].Replace('"', '')).Message('Du wurdest von ' + iniuserget.GetSetting('Information', 'clan') + ' Eingeladen, gib "/clan accept" oder "/clan reject" ein, um Anzunehmen/Abzulehnen.');
                                        Player.Message(SearchUser(args[1].Replace('"', '')).Name + ' wurde nochmal eingeladen.');
                                    } else {
                                        SearchUser(args[1].Replace('"', '')).Message('You were chosen by ' + iniuserget.GetSetting('Information', 'clan') + ' Invited to enter "/clan accept" or "/clan reject" to be assumed/be rejected.');
                                        Player.Message(SearchUser(args[1].Replace('"', '')).Name + ' was again invited.');
                                    }
                                }
                                else if(GetTabled('ClanAdd', SearchUser(args[1].Replace('"', '')).SteamID) == null)
                                {
                                    SetTabled('ClanAdd', SearchUser(args[1].Replace('"', '')).SteamID, iniuserget.GetSetting('Information', 'clan'));
                                    if(language() == "de")
                                    {
                                        SearchUser(args[1].Replace('"', '')).Message('Du wurdest von ' + iniuserget.GetSetting('Information', 'clan') + ' Eingeladen, gib "/clan accept" oder "/clan reject" ein, um Anzunehmen/Abzulehnen.');
                                        Player.Message(SearchUser(args[1].Replace('"', '')).Name + ' wurde eingeladen.');
                                    } else {
                                        SearchUser(args[1].Replace('"', '')).Message('You were chosen by ' + iniuserget.GetSetting('Information', 'clan') + ' Invited to enter "/clan accept" or "/clan reject" to be assumed/be rejected.');
                                        Player.Message(SearchUser(args[1].Replace('"', '')).Name + ' was invited.');
                                    }
                                } else {
                                    if(language() == "de")
                                    {
                                        Player.Message(SearchUser(args[1].Replace('"', '')) + " hat bereits eine andere Einladung bekommen.");
                                    } else {
                                        Player.Message(SearchUser(args[1].Replace('"', '')) + " has already received another invitation.");
                                    }
                                }
                            } else {
                                if(language() == "de")
                                {
                                    Player.Message(SearchUser(args[1].Replace('"', '')) + " ist bereits in einem Clan.");
                                } else {
                                    Player.Message(SearchUser(args[1].Replace('"', '')) + " is already in a clan.");
                                }
                            }
                        } else {
                            if(language() == "de")
                            {
                                Player.Message("Du bist kein Admin.");
                            } else {
                                Player.Message("You are not an admin.");
                            }
                        }
                    } else {
                        if(language() == "de")
                        {
                            Player.Message("Spieler existiert nicht.");
                        } else {
                            Player.Message("Player no exists.");
                        }
                    }
                } else {
                    if(language() == "de")
                    {
                        Player.Message("Du bist nicht in einem Clan.");
                    } else {
                        Player.Message("You're not in a clan.");
                    }
                }
            }
            else if(args[0] == "accept")
            {
                if(iniuserget.GetSetting('Information', 'clan') == null)
                {
                    if(GetTabled('ClanAdd', Player.SteamID) != null)
                    { 
                        var count = ClanPlayerCount(GetTabled('ClanAdd', Player.SteamID));
                        iniuserget.AddSetting('Information', 'clan', GetTabled('ClanAdd', Player.SteamID));
                        iniuserget.Save();
                        SetTabled('ClanAdd', Player.SteamID, null);
                        var iniclanget = Plugin.GetIni("Clan\\" + iniuserget.GetSetting('Information', 'clan'));
                        iniclanget.AddSetting(iniuserget.GetSetting('Information', 'clan'), 'player_count', Number(iniclanget.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'player_count')) + 1);
                        iniclanget.AddSetting(iniuserget.GetSetting('Information', 'clan'), 'player' + count, Player.SteamID);
                        iniclanget.Save();

                        if(language() == "de")
                        {
                            Player.Find(iniclanget.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'admin')).Message(Player.Name + ' hat akzeptiert.');
                            Player.Message('Du bist jetzt in den Clan beigetreten.');
                        } else {
                            Player.Find(iniclanget.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'admin')).Message(Player.Name + ' has accepted.');
                            Player.Message('You are now joined into the clan.');
                        }

                    } else {
                        if(language() == "de")
                        {
                            Player.Message("Du hast keine Einladung bekommen.");
                        } else {
                            Player.Message("You have not received an invitation.");
                        }
                    }

                } else {
                    if(language() == "de")
                    {
                        Player.Message("Du bist bereits in einem Clan.");
                    } else {
                        Player.Message("You are already in a clan.");
                    }
                }
            }
            else if(args[0] == "reject")
            {
                if(GetTabled('ClanAdd', Player.SteamID) != null)
                {
                    var iniclanget = Plugin.GetIni("Clan\\" + GetTabled('ClanAdd', Player.SteamID));

                    if(language() == "de")
                    {
                        Player.Find(iniclanget.GetSetting(GetTabled('ClanAdd', Player.SteamID), 'admin')).Message(Player.Name + ' hat die Einladung abgelehnt.');
                        Player.Message('Du hast erfolgreich abgelehnt.');
                    } else {
                        Player.Find(iniclanget.GetSetting(GetTabled('ClanAdd', Player.SteamID), 'admin')).Message(Player.Name + ' has rejected the invitation.');
                        Player.Message('You have successfully rejected.');
                    }
                    SetTabled('ClanAdd', Player.SteamID, null);
                } else {
                    if(language() == "de")
                    {
                        Player.Message("Du hast keine Einladung bekommen.");
                    } else {
                        Player.Message("You have not received an invitation.");
                    }
                }
            }
            else if(args[0] == "kick")
            {
                if(iniuserget.GetSetting('Information', 'clan') != null)
                {
                    var iniclanget = Plugin.GetIni("Clan\\" + iniuserget.GetSetting('Information', 'clan'));
                    if(iniclanget.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'admin') == Player.SteamID)
                    {
                        if(SearchUser(args[1].Replace('"', '')) != null)
                        {
                            var iniuserget2 = Plugin.GetIni("UserData\\" + SearchUser(args[1].Replace('"', '')).SteamID);
                            if(iniuserget2.GetSetting('Information', 'clan') == iniuserget.GetSetting('Information', 'clan'))
                            {
                                var count = ClanGetPlayerSlot(iniuserget.GetSetting('Information', 'clan'), SearchUser(args[1].Replace('"', '')).SteamID);
                                iniuserget2.AddSetting('Information', 'clan', null);
                                iniuserget2.Save();
                                iniclanget.AddSetting(iniuserget.GetSetting('Information', 'clan'), 'player_count', Number(iniclanget.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'player_count')) - 1);
                                iniclanget.DeleteSetting(iniuserget.GetSetting('Information', 'clan'), 'player' + count);
                                iniclanget.Save();
                                if(language() == "de")
                                {
                                    Player.Message(SearchUser(args[1].Replace('"', '')).Name + " wurde gekickt.");
                                    SearchUser(args[1].Replace('"', '')).Message('Du wurdest vom Clan gekickt.');
                                } else {
                                    Player.Message(SearchUser(args[1].Replace('"', '')).Name + " was kicked.");
                                    SearchUser(args[1].Replace('"', '')).Message('You have been kicked from the clan.');
                                }
                            } else {
                                if(language() == "de")
                                {
                                    Player.Message(SearchUser(args[1].Replace('"', '')).Name + " ist nicht in deinem Clan.");
                                } else {
                                    Player.Message(SearchUser(args[1].Replace('"', '')).Name + " is not in your clan.");
                                }
                            }
                        }
                    } else {
                        if(language() == "de")
                        {
                            Player.Message("Du bist kein Admin.");
                        } else {
                            Player.Message("You are not an admin.");
                        }
                    }
                }
            }
            else if(args[0] == "leave")
            {
                if(iniuserget.GetSetting('Information', 'clan') != null)
                {
                    var iniclanget = Plugin.GetIni("Clan\\" + iniuserget.GetSetting('Information', 'clan'));
                    if(iniclanget.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'admin') != Player.SteamID)
                    {
                        var count = ClanGetPlayerSlot(iniuserget.GetSetting('Information', 'clan'), Player.SteamID);
                        iniclanget.AddSetting(iniuserget.GetSetting('Information', 'clan'), 'player_count', Number(iniclanget.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'player_count')) - 1);
                        iniclanget.DeleteSetting(iniuserget.GetSetting('Information', 'clan'), 'player' + count);
                        iniclanget.Save();
                        iniuserget.AddSetting('Information', 'clan', null);
                        iniuserget.Save();
                        if(language() == "de")
                        {
                            Player.Message("Du hast den Clan erfolgreich verlassen.");
                        } else {
                            Player.Message("You left the clan successfully.");
                        }
                    } else {
                        if(language() == "de")
                        {
                            Player.Message("Als Admin kannst du dies nicht tun.");
                        } else {
                            Player.Message("As an admin you can not do this.");
                        }
                    }
                }
            }
            else if(args[0] == "delete")
            {
                if(iniuserget.GetSetting('Information', 'clan') != null)
                {
                    var iniclanget = Plugin.GetIni("Clan\\" + iniuserget.GetSetting('Information', 'clan'));
                    if(iniclanget.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'admin') == Player.SteamID)
                    {
                        var whilecount = 1;
                        var counter = Number(iniclanget.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'player_count'));
                        var iniuser = "";
                        
                        while(counter > 0)
                        {
                            if(iniclanget.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'player' + whilecount) != null)
                            {
                                if(iniclanget.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'player' + whilecount) != Player.SteamID)
                                {
                                    iniuser = Plugin.GetIni("UserData\\" + iniclanget.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'player' + whilecount));
                                    iniuser.AddSetting('Information', 'clan', null);
                                    iniuser.Save();
                                    counter = counter - 1;
                                    
                                    if(language() == "de")
                                    {
                                        SearchUser(iniuser.GetSetting('Information', 'name')).Message("Der Clan wurde vom Admin geloescht.");
                                    } else {
                                        SearchUser(iniuser.GetSetting('Information', 'name')).Message("The clan was deleted by Admin.");
                                    }
                                }
                            }
                            whilecount = whilecount + 1;
                            if(whilecount > 60)
                            {
                                counter = 0;
                            }
                        }
                        Plugin.CreateIni("Clan\\" + iniuserget.GetSetting('Information', 'clan'));
                        iniuserget.AddSetting('Information', 'clan');
                        iniuserget.Save();
                        
                        if(language() == "de")
                        {
                            Player.Message("Du hast erfolgreich dein Clan geloescht.");
                        } else {
                            Player.Message("You have successfully deleted your clan.");
                        }
                    } else {
                        if(language() == "de")
                        {
                            Player.Message("Du bist kein Admin.");
                        } else {
                            Player.Message("You are not an admin.");
                        }
                    }
                }
            }
            else if(args[0] == "message")
            {
                if(Data.GetConfigValue(ConfigName, "Clan", "enable") == "true")
                {
                    var iniuserget = Plugin.GetIni("UserData\\" + Player.SteamID);
                    if(iniuserget.GetSetting('Information', 'clan') != null)
                    {
                        var iniclanget = Plugin.GetIni("Clan\\" + iniuserget.GetSetting('Information', 'clan'));
                        var whilecount = 1;
                        var counter = iniclanget.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'player_count');
                        var iniuser = "";
                        var a = 1;
                        var text = Player.Name + ": ";
                        
                        for(var part in args) 
                        {
                            if(a != 1)
                            {
                                text += part + " ";
                            }
                            a = 2;
                        }
        
                        while(counter > 0)
                        {
                            if(iniclanget.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'player' + whilecount) != null)
                            {
                                iniuser = Plugin.GetIni("UserData\\" + iniclanget.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'player' + whilecount));
        
                                if(SearchUser(iniuser.GetSetting('Information', 'name')) != null)
                                {
                                    SearchUser(iniuser.GetSetting('Information', 'name')).Message("Clan Message von " + Player.Name + ": ");
                                    SearchUser(iniuser.GetSetting('Information', 'name')).Message(text);
                                    counter = counter - 1;
                                }
                            }
                            whilecount = whilecount + 1;
                            if(whilecount > 60)
                            {
                                counter = 0;
                            }
                        }
                    }
                }    
            }
            else if(args[0] == "list" || args[0] == "who")
            {
                if(iniuserget.GetSetting('Information', 'clan') != null)
                {
                    var iniclanfunc = Plugin.GetIni("Clan\\" + iniuserget.GetSetting('Information', 'clan'));
                    var counter = Number(iniclanfunc.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'player_count'));
                    var str = [];
                    var whilecount = 1;
                    var a = 0;
                
                    while(counter > 0)
                    {
                        if(iniclanfunc.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'player' + whilecount) != null)
                        {
                            str[a] = iniclanfunc.GetSetting(iniuserget.GetSetting('Information', 'clan'), 'player' + whilecount);
                            counter = counter -1;
                            a = a + 1;
                        }
                        whilecount = whilecount + 1;
                
                        if(whilecount > 60)
                        {
                            counter = 0;
                        }
                    }                    
                    
                    var str2 = "";
                    var iniuser = "";
                    var a = 0;
                    var b = 0;
                    Player.Message("ClanName: " + iniuserget.GetSetting('Information', 'clan'));
                    while(str[b] != null)
                    {
                        if(args[0] == "list")
                        {
                            iniuser = Plugin.GetIni("UserData\\" + str[b]);
                            str2 += iniuser.GetSetting('Information', 'name').Replace('#', '') + ",  ";
                            a = a + 1;
                            if(a >= 6)
                            {
                                a = 0;
                                Player.Message("User: " + Data.Substring(str2, 0, Data.StrLen(str2) - 3));
                                str2 = "";
                            }
                        }
                        else if(args[0] == "who")
                        {
                            if(Player.Find(str[b]) != null)
                            {
                                iniuser = Plugin.GetIni("UserData\\" + str[b]);
                                str2 += iniuser.GetSetting('Information', 'name').Replace('#', '') + ",  ";
                                a = a + 1;
                                if(a >= 6)
                                {
                                    a = 0;
                                    Player.Message("UserOnline: " + Data.Substring(str2, 0, Data.StrLen(str2) - 3));
                                    str2 = "";
                                }
                            }
                        }
                        b = b + 1;
                    }

                    if(a != 0)
                    {
                        if(args[0] == "list")
                        {
                            Player.Message("User: " + Data.Substring(str2, 0, Data.StrLen(str2) - 3));
                        }
                        else if(args[0] == "who")
                        {
                            Player.Message("UserOnline: " + Data.Substring(str2, 0, Data.StrLen(str2) - 3));
                        }
                    }
                }
            }      
        }
    }
    
    if(cmd == "player")
    {
        if(Data.GetConfigValue(ConfigName, "Player", "enable") == "true")
        {
            var iniuserget = Plugin.GetIni("UserData\\" + Player.SteamID);
            if(args[0] == "info")
            {
                var kd = Number(iniuserget.GetSetting('Information', 'kill_count')) / Number(iniuserget.GetSetting('Information', 'death_count'));
                if(kd == "Infinity")
                {
                    endKD = 0;
                } else {
                    var vollKD = Math.floor(kd);
				    var halfKD = kd - vollKD;
				    var endKD = vollKD + "," + Data.Substring(halfKD, 2, 2);
                }

                if(iniuserget.GetSetting('Information', 'clan') != null)
                {
                    var clan = iniuserget.GetSetting('Information', 'clan');
                } else {
                    var clan = '"No Clan."';
                }

                Player.Message('Name: ' + Player.Name);
                Player.Message('SteamID: ' + Player.SteamID);
                Player.Message('IP: ' + Player.IP);
                Player.Message('Clan: ' + clan);
                Player.Message('K/D: ' + endKD);
                Player.Message('Kill: ' + iniuserget.GetSetting('Information', 'kill_count'));
                Player.Message('Death: ' + iniuserget.GetSetting('Information', 'death_count'));
                Player.Message('Suicide: ' + iniuserget.GetSetting('Information', 'suicide_count'));
                Player.Message('Player_Damage: ' + Math.round(Number(iniuserget.GetSetting('Information', 'damage_count'))) + " HP.");
                Player.Message('Self_Damage: ' + Math.round(Number(iniuserget.GetSetting('Information', 'self_damage_count'))) + " HP.");
            }
            else if(args[0] == "best")
            {
                var inilist = Plugin.GetIni("PlayerList");
                if(inilist != null)
                {
                    var Place = [];
                    var count = 0;
                    var ID = inilist.EnumSection("PlayerID");

                    for(var pl in ID)
                    {
                        var inikd = Plugin.GetIni("UserData\\" + inilist.GetSetting('PlayerID', pl));
                        var mathkd = Number(inikd.GetSetting('Information', 'kill_count')) / Number(inikd.GetSetting('Information', 'death_count'));
                        var PlayerInfo = {};
                        PlayerInfo['ID'] = inilist.GetSetting('PlayerID', pl);
                        PlayerInfo['Name'] = inikd.GetSetting('Information', 'name').replace('#', ' ');

                        if(mathkd == "Infinity")
                        {
                            PlayerInfo['KD'] = 0;
                        } else {
                            PlayerInfo['KD'] = mathkd;
                        }
                        Place[count] = PlayerInfo;
                        count = count + 1;
                    }

                    Place = Place.sort(function(VarA, VarB) { return VarA['KD'] > VarB['KD']; });

                    for(var a = 0; a < 5; a++)
        			{
        				if(Place[a] != null)
        				{
        				    var vollKD = Math.floor(Place[a]['KD']);
        				    var halfKD = Place[a]['KD'] - vollKD;
        				    var endKD = vollKD + "," + Data.Substring(halfKD, 2, 2);
        				    Player.Message("Place " + (a + 1) + " => " + Place[a]['Name'] + " => " + endKD + " K/D!");
        				}
        			}

                }
            }
        }
    }
    
    if(cmd == "getp")
    {
        if(args[0] != null)
        {
            if(Player.Admin == true)
            {
                var iniplayer = Plugin.GetIni("PlayerList");
                var a = 1;
                var finish = 1;
    
                while(finish > 0)
                {
                    if(iniplayer.GetSetting('PlayerName', 'name_' + a) != null)
                    {
                        if(iniplayer.GetSetting('PlayerName', 'name_' + a) == args[0])
                        {
                            var iniuserget2 = Plugin.GetIni("UserData\\" + iniplayer.GetSetting('PlayerID', 'id_' + a));
                            var loc_x = iniuserget2.GetSetting('Information', 'loc_x');
                            var loc_y = iniuserget2.GetSetting('Information', 'loc_y');
                            var loc_z = iniuserget2.GetSetting('Information', 'loc_z');
                            Player.TeleportTo(loc_x, loc_y, loc_z);
                            Player.Message(iniuserget2.GetSetting('Information', 'name').Replace("#", " ") + "-Location: X: " + loc_x + ", Y: " + loc_y + ", Z: " + loc_z);
                            finish = 0;
                            
                        } else {
                            a = a + 1;
                        }
                    } else {
                        finish = 0;
                    }
                }
            }    
        }    
    }
    
    if(cmd == "realtime")
    {
        if(Data.GetConfigValue(ConfigName, "RealTime", "enable") == "true")
        {
            if(Player.Admin == true)
            {
                if(args == null)
                {
                    Player.Message("DayLength: " + World.DayLength + " - NightLength: " + World.NightLength);
                }
                else if(args[0] == "real")
                {
                    World.DayLength = Number(Data.GetConfigValue(ConfigName, "RealTime", "real_day_length"));
                    World.NightLength = Number(Data.GetConfigValue(ConfigName, "RealTime", "real_night_length"));
                    World.Time = Number(System.DateTime.Now.ToString("HH")) + ((100 / 60 * Number(System.DateTime.Now.ToString("mm"))) / 100);
                    Player.Message("DayLength: " + World.DayLength + " - NightLength: " + World.NightLength);
                }
                else if(args[0] == "default")
                {
                    World.DayLength = 45;
                    World.NightLength = 15;
                    Player.Message("DayLength: " + World.DayLength + " - NightLength: " + World.NightLength);
                }
            }
        }
    }
    
    if(cmd == "savezone")
    {
        if(Player.Admin == true)
        {
            if(Data.GetConfigValue(ConfigName, "SaveZone", "enable") == "true")
            {
                if(args[0] == "info")
                {
                    var iniszget = Plugin.GetIni("SaveZone");
                    var Name = iniszget.EnumSection("Info");
                    var count = 0;
                    var str = "";

                    for(var pl in Name)
                    {
                        if(pl != "count")
                        {
                            count++;
                            str += iniszget.GetSetting('Info', pl).Replace('#', ' ') + ",  ";
                            if(count >= 6)
                            {
                                count = 0;
                                Player.Message(Data.Substring(str, 0, Data.StrLen(str) - 3));
                                str = "";
                            }
                        }
                    }

                    if(count != 0)
                    {
                        Player.Message(Data.Substring(str, 0, Data.StrLen(str) - 3));
                    }
                }
                else if(args[0] == "start")
                {
                    if(args[1] != null)
                    {
                        var iniszget = Plugin.GetIni("SaveZone");
                        if(Number(iniszget.GetSetting('info', 'count')) < Number(Data.GetConfigValue(ConfigName, "SaveZone", "max_zone")))
                        {
                            if(GetTabled('SaveZone_Name', Player.SteamID) == null)
                            {
                                if(iniszget.GetSetting(args[1], 'start_x') == null)
                                {
                                    SetTabled('SaveZone_Name', Player.SteamID, args[1]);
                                    Player.Message("Name: " + GetTabled('SaveZone_Name', Player.SteamID));
                                    Player.Message("Die Positionen koennen jetzt mit /start und /end gesetzt werden. Mit /stop kann abgebrochen werden.");
                                } else {
                                    Player.Message("Dieser Name existiert bereits.");
                                }
                            }
                        } else {
                            Player.Message("Du kannst keine SaveZone mehr erstellen.");
                        }
                    } else {
                        Player.Message("Bitte gib einen Namen ein.");
                    }
                }
                else if(args[0] == "del")
                {
                    if(args[1] != null)
                    {
                        var iniszget = Plugin.GetIni("SaveZone");
                        if(GetTabled('SaveZone_Name', Player.SteamID) == null)
                        {
                            if(iniszget.GetSetting(args[1], 'start_x') != null)
                            {
                                iniszget.DeleteSetting(args[1], 'start_x');
                                iniszget.DeleteSetting(args[1], 'start_z');
                                iniszget.DeleteSetting(args[1], 'end_x');
                                iniszget.DeleteSetting(args[1], 'end_z');
                                for(a = 1; a <= 60; a++)
                                {
                                    if(iniszget.GetSetting('Info', 'name' + a) == args[1])
                                    {
                                        iniszget.DeleteSetting('Info', 'name' + a);
                                        iniszget.AddSetting('Info', 'count', Number(iniszget.GetSetting('Info', 'count')) - 1);
                                        a = 61;
                                    }
                                }
                                iniszget.Save();
                                Player.Message("Dieser SaveZone wurde geloescht.");
                            } else {
                                Player.Message("Dieser Name existiert nicht.");
                            }
                        }
                    } else {
                        Player.Message("Bitte gib einen Namen ein.");
                    }
                }
            }
        }
    }
    
    if(cmd == "start")
    {
        if(Player.Admin == true)
        {
            if(Data.GetConfigValue(ConfigName, "SaveZone", "enable") == "true")
            {
                if(GetTabled('SaveZone_Name', Player.SteamID) != null)
                {
                    var loc = Player.Location;
                    SetTabled('SaveZone_PosX_Start', Player.SteamID, Math.round(loc.x));
                    SetTabled('SaveZone_PosZ_Start', Player.SteamID, Math.round(loc.z));
                    Player.Message("Der Anfangs-Punkt wurde gesetzt. Setzte noch das end-punkt mit /end.");
                }
            }
        }
    }
    
    if(cmd == "end")
    {
        if(Player.Admin == true)
        {
            if(Data.GetConfigValue(ConfigName, "SaveZone", "enable") == "true")
            {
                if(GetTabled('SaveZone_Name', Player.SteamID) != null)
                {
                    if(GetTabled('SaveZone_PosX_Start', Player.SteamID) != null)
                    {
                        var loc = Player.Location;
                        SetTabled('SaveZone_PosX_End', Player.SteamID, Math.round(loc.x));
                        SetTabled('SaveZone_PosZ_End', Player.SteamID, Math.round(loc.z));
                        var iniszget = Plugin.GetIni("SaveZone");

                        iniszget.AddSetting(GetTabled('SaveZone_Name', Player.SteamID), 'start_x', GetTabled('SaveZone_PosX_Start', Player.SteamID));
                        iniszget.AddSetting(GetTabled('SaveZone_Name', Player.SteamID), 'start_z', GetTabled('SaveZone_PosZ_Start', Player.SteamID));
                        iniszget.AddSetting(GetTabled('SaveZone_Name', Player.SteamID), 'end_x', GetTabled('SaveZone_PosX_End', Player.SteamID));
                        iniszget.AddSetting(GetTabled('SaveZone_Name', Player.SteamID), 'end_z', GetTabled('SaveZone_PosZ_End', Player.SteamID));

                        for(a = 1; a <= 60; a++)
                        {
                            if(iniszget.GetSetting('Info', 'name' + a) == null)
                            {
                                iniszget.AddSetting('Info', 'name' + a, GetTabled('SaveZone_Name', Player.SteamID));
                                iniszget.AddSetting('Info', 'count', Number(iniszget.GetSetting('Info', 'count')) + 1);
                                a = 61;
                            }
                        }
                        iniszget.Save();

                        Player.Message("Name: " + GetTabled('SaveZone_Name', Player.SteamID).Replace('#', ' ') + " - Start-Position: X: " + GetTabled('SaveZone_PosX_Start', Player.SteamID) + " - Z: " + GetTabled('SaveZone_PosZ_Start', Player.SteamID) + " - End-Position: X: " + GetTabled('SaveZone_PosX_End', Player.SteamID) + " - Z: " + GetTabled('SaveZone_PosZ_End', Player.SteamID));
                        Player.Message("Der End-Punkt wurde gesetzt. SaveZone wurde gespeichert");
                        SetTabled('SaveZone_Name', Player.SteamID, null);
                        SetTabled('SaveZone_PosX_Start', Player.SteamID, null);
                        SetTabled('SaveZone_PosZ_Start', Player.SteamID, null);
                        SetTabled('SaveZone_PosX_End', Player.SteamID, null);
                        SetTabled('SaveZone_PosZ_End', Player.SteamID, null);
                    } else {
                        Player.Message("Setzte zuerst den Start-Punkt mit /start.");
                    }
                }
            }
        }
    }
    
    if(cmd == "stop")
    {
        if(Player.Admin == true)
        {
            if(Data.GetConfigValue(ConfigName, "SaveZone", "enable") == "true")
            {
                if(GetTabled('SaveZone_Name', Player.SteamID) != null)
                {
                    SetTabled('SaveZone_Name', Player.SteamID, null);
                    SetTabled('SaveZone_PosX_Start', Player.SteamID, null);
                    SetTabled('SaveZone_PosZ_Start', Player.SteamID, null);
                    SetTabled('SaveZone_PosX_End', Player.SteamID, null);
                    SetTabled('SaveZone_PosZ_End', Player.SteamID, null);
                    Player.Message("Wurde abgebrochen.");
                }
                
            }
        }
    }
}

function SaveZone(player) {
    if(Data.GetConfigValue(ConfigName, "SaveZone", "enable") == "true")
    {
        var for_return = false;
        var iniszget = Plugin.GetIni("SaveZone");
        var Name = iniszget.EnumSection("Info");
        var loc = player.Location;
        var count = 0;
    
        for(var pl in Name)
        {
            count = 0;
            if(pl != "count")
            {
                var Aktuell_Pos_X_Start = iniszget.GetSetting(iniszget.GetSetting('Info', pl), 'start_x').Replace('-', '');
                var Aktuell_Pos_Z_Start = iniszget.GetSetting(iniszget.GetSetting('Info', pl), 'start_z').Replace('-', '');
                var Aktuell_Pos_X_End = iniszget.GetSetting(iniszget.GetSetting('Info', pl), 'end_x').Replace('-', '');
                var Aktuell_Pos_Z_End = iniszget.GetSetting(iniszget.GetSetting('Info', pl), 'end_z').Replace('-', '');
    
                if(loc.x < 0)
                {
                    loc.x = loc.x * (1 - 2);
                }
                if(loc.z < 0)
                {
                    loc.z = loc.z * (1 - 2);
                }
    
                if(Math.round(loc.x) >= Number(Aktuell_Pos_X_Start))
                {
                    count++;
                }
                if(Math.round(loc.z) >= Number(Aktuell_Pos_Z_Start))
                {
                    count++;
                }
                if(Math.round(loc.x) <= Number(Aktuell_Pos_X_End))
                {
                    count++;
                }
                if(Math.round(loc.z) <= Number(Aktuell_Pos_Z_End))
                {
                    count++;
                }
    
                if(count != 4)
                {
                    count = 0;
                    if(Math.round(loc.x) <= Number(Aktuell_Pos_X_Start))
                    {
                        count++;
                    }
                    if(Math.round(loc.z) <= Number(Aktuell_Pos_Z_Start))
                    {
                        count++;
                    }
                    if(Math.round(loc.x) >= Number(Aktuell_Pos_X_End))
                    {
                        count++;
                    }
                    if(Math.round(loc.z) >= Number(Aktuell_Pos_Z_End))
                    {
                        count++;
                    }
    
                    if(count == 4)
                    {
                        for_return = pl;
                    }
                } else {
                    for_return = pl;
                }
            }
        }
        return for_return;       
    }
}
                                     
function On_ServerInit() {
    if(Data.GetConfigValue(ConfigName, "Settings", "enable") == "true")
    {
        if(Data.GetConfigValue(ConfigName, "SaveZone", "enable") == "true")
        {
            if(Plugin.GetIni("SaveZone") == null)
            {
                var iniszget = Plugin.CreateIni("SaveZone");
                iniszget.AddSetting('Info', 'count', 0);
                iniszget.Save();
            }
        }
        
        if(Data.GetConfigValue(ConfigName, "Settings", "auto_timer_enable") == "true")
        {
            Plugin.CreateTimer("AutoTimer", 30000).Start();
            SetTabled("Hour", "time", 0);
            if(Data.GetConfigValue(ConfigName, "Time", "auto_display") == "true")
            {
                if(Data.GetConfigValue(ConfigName, "Time", "enable") == "true")
                {
                    var std = 24;
                    SetTabled('Timer', 'TimeDisplay', 'on');
                    SetTabled('TimeDisplay', 'LastTime', std);
                }
            } else {
                SetTabled('Timer', 'TimeDisplay', 'off');
            }
            
            if(Data.GetConfigValue(ConfigName, "AirdropTimer", "enable") == "true")
            {
                if(Number(Data.GetConfigValue(ConfigName, "AirdropTimer", "call_airdrop_per_minutes")) > 0)
                { 
                        SetTabled('Hour', 'time', 0);
                        SetTabled('Timer', 'AirdropTimer', 'on');
                } else {
                    SetTabled('Timer', 'AirdropTimer', 'off');
                }
            } else {
                SetTabled('Timer', 'AirdropTimer', 'off');    
            }
        }
    }
}

function On_PlayerConnected(Player) {
    if(Data.GetConfigValue(ConfigName, "Settings", "enable") == "true")
    {
        var std = Math.floor(World.Time);
        var min = World.Time - std;
        min = Math.floor(60 / 100 * (100 / 1 * min));
        var pm_am = Data.GetConfigValue(ConfigName, "Time", "time_pm_am");
         
        if(Data.GetConfigValue(ConfigName, "Settings", "auto_timer_enable") == "true")
        {
            if(GetTabled('Timer', 'TimeDisplay') == "on")
            {
                if(GetTabled('TimeDisplay', 'LastTime') != std)
                {
                    if(min < 10)
                    {
                        if(pm_am == "false")
                        {
                            var time_now = std + ":0" + min;
                        } else {
                            if(std >= 12)
                            {
                                if(std > 12)
                                {
                                    var time_now = (std - 12) + ":0" + min + " PM";
                                } else {
                                    var time_now = std + ":0" + min + " PM";
                                }
                            } else {
                                if(std < 1)
                                {
                                    var time_now = (std + 12) + ":0" + min + " AM";
                                } else {
                                    var time_now = std + ":0" + min + " AM";
                                }
                            }
                        }
                    } else {
                        if(pm_am == "false")
                        {
                            var time_now = std + ":" + min;
                        } else {
                            if(std >= 12)
                            {
                                if(std > 12)
                                {
                                    var time_now = (std - 12) + ":" + min + " PM";
                                } else {
                                    var time_now = std + ":" + min + " PM";
                                }
                            } else {
                                if(std < 1)
                                {
                                    var time_now = (std + 12) + ":" + min + " AM";
                                } else {
                                    var time_now = std + ":" + min + " AM";
                                }
                            }
                        }
                    }
                    time_now = time_now + " - " + System.DateTime.Now.ToString("HH") + ":" + System.DateTime.Now.ToString("mm");
                    Player.Notice(time_now);
                }
            }
        }
         
        Player.Message("Airdrop&Co - Plugin Version: " + ACVersion + ". /achelp to help.");

        if(Data.GetConfigValue(ConfigName, "Settings", "auto_timer_enable") == "true")
        {
            if(Player.Admin == true)
            {
                if(Plugin.GetTimer("AutoTimer") != null)
                {
                    if(language() == "de")
                    {
                        Player.Message("Timer ist an.");
                    } else {
                        Player.Message("Timer is on.");
                    }
                } else {
                    if(language() == "de")
                    {
                        Player.Message("Timer ist aus.");
                    } else {
                        Player.Message("Timer is off.");
                    }
                }
            }
        }
        
        if(Plugin.GetIni("PlayerList") == null)
        {
            var iniplayer = Plugin.CreateIni("PlayerList");
            iniplayer.AddSetting('PlayerID', 'id_1', Player.SteamID);
            iniplayer.AddSetting('PlayerName', 'name_1', Player.Name.Replace(" ", "#"));
            iniplayer.Save();
        } else {
            var iniplayer = Plugin.GetIni("PlayerList");
            var a = 1;
            var finish = 1;
            
            while(finish > 0)
            {
                if(iniplayer.GetSetting('PlayerID', 'id_' + a) != null)
                {
                    if(iniplayer.GetSetting('PlayerID', 'id_' + a) != Player.SteamID)
                    {
                        a = a + 1;
                    } else {
                        if(iniplayer.GetSetting('PlayerID', 'id_' + a) != Player.Name.Replace(" ", "#"))
                        {
                            iniplayer.AddSetting('PlayerName', 'name_' + a, Player.Name.Replace(" ", "#"));
                            iniplayer.Save();
                        }
                        finish = 0;
                    }    
                } else {
                    finish = 0;
                    iniplayer.AddSetting('PlayerID', 'id_' + a, Player.SteamID);
                    iniplayer.AddSetting('PlayerName', 'name_' + a, Player.Name.Replace(" ", "#"));
                    iniplayer.Save();
                } 
            }         
        }
        
        if(Plugin.GetIni("UserData\\" + Player.SteamID) == null)
        {
            var iniuserget = Plugin.CreateIni("UserData\\" + Player.SteamID);
            iniuserget.AddSetting('Information', 'id', Player.SteamID);
            iniuserget.AddSetting('Information', 'name', Player.Name.Replace(" ", "#"));
            iniuserget.AddSetting('Information', 'ping', Player.Ping);
            iniuserget.AddSetting('Information', 'ip', Player.IP);
            iniuserget.AddSetting('Information', 'clan', null);
            iniuserget.AddSetting('Information', 'cooldown', 0);
            iniuserget.AddSetting('Information', 'death_count', 0); //getötet werden
            iniuserget.AddSetting('Information', 'kill_count', 0); //jemadnen töten
            iniuserget.AddSetting('Information', 'damage_count', 0); //jemanden dmg machen
            iniuserget.AddSetting('Information', 'self_damage_count', 0); //dmg bekommen
            iniuserget.AddSetting('Information', 'suicide_count', 0); //selbstmord
            iniuserget.Save();
        }    
    }
}

function On_PlayerDisconnected(Player) {
    if(Data.GetConfigValue(ConfigName, "Settings", "enable") == "true")
    {
        var loc = Player.Location;
        var iniuserget = Plugin.GetIni("UserData\\" + Player.SteamID);
        iniuserget.AddSetting('Information', 'loc_x', loc.x);
        iniuserget.AddSetting('Information', 'loc_y', loc.y);
        iniuserget.AddSetting('Information', 'loc_z', loc.z);
        iniuserget.Save();
    }
}

function AutoTimerCallback() {
    if(Data.GetConfigValue(ConfigName, "Settings", "enable") == "true")
    {
        var std = Math.floor(World.Time);
        var min = World.Time - std;
        min = Math.floor(60 / 100 * (100 / 1 * min));
        var pm_am = Data.GetConfigValue(ConfigName, "Time", "time_pm_am");
    
        if(Data.GetConfigValue(ConfigName, "Time", "auto_display") == "true")
        {
            if(GetTabled('Timer', 'TimeDisplay') == "on")
            {
                if(GetTabled('TimeDisplay', 'LastTime') != std)
                {
                    if(min < 10)
                    {
                        if(pm_am == "false")
                        {
                            var time_now = std + ":0" + min;
                        } else {
                            if(std >= 12)
                            {
                                if(std > 12)
                                {
                                    var time_now = (std - 12) + ":0" + min + " PM";
                                } else {
                                    var time_now = std + ":0" + min + " PM";
                                }
                            } else {
                                if(std < 1)
                                {
                                    var time_now = (std + 12) + ":0" + min + " AM";
                                } else {
                                    var time_now = std + ":0" + min + " AM";
                                }
                            }
                        }
                    } else {
                        if(pm_am == "false")
                        {
                            var time_now = std + ":" + min;
                        } else {
                            if(std >= 12)
                            {
                                if(std > 12)
                                {
                                    var time_now = (std - 12) + ":" + min + " PM";
                                } else {
                                    var time_now = std + ":" + min + " PM";
                                }
                            } else {
                                if(std < 1)
                                {
                                    var time_now = (std + 12) + ":" + min + " AM";
                                } else {
                                    var time_now = std + ":" + min + " AM";
                                }
                            }
                        }
                    }
                    time_now = time_now + " - " + System.DateTime.Now.ToString("HH") + ":" + System.DateTime.Now.ToString("mm");
                    SetTabled('TimeDisplay', 'LastTime', std);    
                    Server.BroadcastNotice(time_now);
                }    
            }
        }
        
        if(Data.GetConfigValue(ConfigName, "AirdropTimer", "enable") == "true")
        {
            if(GetTabled('Timer', 'AirdropTimer') == "on")
            {
                if(Number(Data.GetConfigValue(ConfigName, "AirdropTimer", "call_airdrop_per_minutes")) > 0)
                {
                    SetTabled('Hour', 'time', (Number(GetTabled('Hour', 'time')) + 30));
                    if(Number(GetTabled('Hour', 'time')) >= (Number(Data.GetConfigValue(ConfigName, "AirdropTimer", "call_airdrop_per_minutes")) * 60))
                    {
                        SetTabled('Hour', 'time', 0);
                        if(Data.GetConfigValue(ConfigName, "AirdropTimer", "airdrop_to_player") != "true")
                        {
                            if(Number(Data.GetConfigValue(ConfigName, "AirdropTimer", "airdrop_amount")) >= 1)
                            {
                                if(Number(Data.GetConfigValue(ConfigName, "AirdropTimer", "airdrop_amount")) <=  100)
                                {
                                    var count = Number(Data.GetConfigValue(ConfigName, "AirdropTimer", "airdrop_amount"));
                                    World.Airdrop(count);
                                    if(language() == "de")
                                    {
                                        Server.Broadcast(count + " Airdrops sind unterwegs.");
                                    } else {
                                        Server.Broadcast(count + " Airdrops are traveling.");
                                    }
                                } else {
                                    Data.OverrideConfig(ConfigName, "AirdropTimer", "airdrop_amount", 100);
                                }
                            }
                        } else {
                            if(Number(Data.GetConfigValue(ConfigName, "AirdropTimer", "airdrop_amount")) >= 1)
                            {
                                if(Number(Data.GetConfigValue(ConfigName, "AirdropTimer", "airdrop_amount")) <= 30)
                                {
                                    var count = Number(Data.GetConfigValue(ConfigName, "AirdropTimer", "airdrop_amount"));
                                    var players = Server.Players;
                            		for(var pl in players)
                                    {
                                        World.AirdropAtPlayer(pl, count);
                                    }
                                    if(language() == "de")
                                    {
                                        Server.Broadcast(count + " Airdrops sind unterwegs.");
                                    } else {
                                        Server.Broadcast(count + " Airdrops are traveling.");
                                    }
                                } else {
                                    Data.OverrideConfig(ConfigName, "AirdropTimer", "airdrop_amount", 30);
                                }
                            }
                        }        
                    }
                }    
            }
        }
	}
}

function GetTabled(ID, Name) {
    if(Data.GetConfigValue(ConfigName, "Settings", "enable") == "true")
    {
        return Data.GetTableValue(Name, ID);
    }
}

function SetTabled(ID, Name, Value) {
    if(Data.GetConfigValue(ConfigName, "Settings", "enable") == "true")
    {
        Data.AddTableValue(Name, ID, Value);
    }
}

function SearchUser(name) {
    var players = Server.Players;
	var count=0; 
    var totalcount=0;
	for(var pl in players) 
    {
		totalcount++;
		if(totalcount > 250) {
			count = 0;
			break;
		}
		
		if(name.Replace("#", " ") == pl.Name)
		{
        return pl;
        totalcount = 1000;
        } else {
            
        }
	}   
}

function On_PlayerHurt(HurtEvent) {
    if(Data.GetConfigValue(ConfigName, "Settings", "enable") == "true")
    {
        if(Data.GetConfigValue(ConfigName, "SaveZone", "enable") == "true")
        {
            if(SaveZone(HurtEvent.Victim) != false)
            {
                if(Data.GetConfigValue(ConfigName, "SaveZone", "pvp") == "false")
                {
                    var returno = true;
                } else {
                    var returno = false;    
                }
            } else {
                var returno = false;
            }
        } else {
            var returno = false;
        }
    
        if(returno != false)
        {
            HurtEvent.DamageAmount = 0;    
        } else {
            if(HurtEvent.Victim.SteamID != null)
            {
                var iniattackerget = Plugin.GetIni("UserData\\" + HurtEvent.Attacker.SteamID);
                var inivictimget = Plugin.GetIni("UserData\\" + HurtEvent.Victim.SteamID);
                
                if(inivictimget.GetSetting('Information', 'clan') != iniattackerget.GetSetting('Information', 'clan'))
                {
                    var Damage = HurtEvent.DamageAmount;
                    iniattackerget.AddSetting('Information', 'damage_count', Number(iniattackerget.GetSetting('Information', 'damage_count')) + Damage);
                    inivictimget.AddSetting('Information', 'self_damage_count', Number(inivictimget.GetSetting('Information', 'self_damage_count')) + Damage);
                    
                    if(Data.GetConfigValue(ConfigName, "Cooldown", "enable") == "true")
                    {
                        var newer = TimeStamp() + Number(Data.GetConfigValue(ConfigName, "Cooldown", "attack_cooldown_in_second"));
                        iniattackerget.AddSetting('Information', 'cooldown', newer);
                        inivictimget.AddSetting('Information', 'cooldown', newer);                
                    }
                    iniattackerget.Save();
                    inivictimget.Save();            
                }
                else if(iniattackerget.GetSetting('Information', 'clan') == null)
                {
                    if(HurtEvent.Attacker.SteamID != HurtEvent.Victim.SteamID)
                    {
                        var Damage = HurtEvent.DamageAmount;
                        iniattackerget.AddSetting('Information', 'damage_count', Number(iniattackerget.GetSetting('Information', 'damage_count')) + Damage);
                        inivictimget.AddSetting('Information', 'self_damage_count', Number(inivictimget.GetSetting('Information', 'self_damage_count')) + Damage);
                        
                        if(Data.GetConfigValue(ConfigName, "Cooldown", "enable") == "true")
                        {
                            var newer = TimeStamp() + Number(Data.GetConfigValue(ConfigName, "Cooldown", "attack_cooldown_in_second"));
                            iniattackerget.AddSetting('Information', 'cooldown', newer);
                            inivictimget.AddSetting('Information', 'cooldown', newer);
                        }
                        iniattackerget.Save();
                        inivictimget.Save();   
                    } else {
                        var Damage = HurtEvent.DamageAmount;
                        iniattackerget.AddSetting('Information', 'self_damage_count', Number(iniattackerget.GetSetting('Information', 'self_damage_count')) + Damage);
                        iniattackerget.Save();
                    }    
                }
                else if(inivictimget.GetSetting('Information', 'clan') == iniattackerget.GetSetting('Information', 'clan'))
                {
                    if(HurtEvent.Attacker.SteamID != HurtEvent.Victim.SteamID)
                    {
                        HurtEvent.DamageAmount = 0;
                        if(language() == "de")
                        {
                            HurtEvent.Attacker.Notice("Das ist dein Clan-Kamerad.");
                        } else {
                            HurtEvent.Attacker.Notice("This is your clan mate.");
                        }
                    }                 
                }                 
            }	    
        }	    
    }	    
}

function ClanPlayerCount(ClanName) {
    var iniclanfunc = Plugin.GetIni("Clan\\" + ClanName);
    var counter = Number(iniclanfunc.GetSetting(ClanName, 'player_count'));
    var whilecount = 1;
    var erfolg = 1;
    
    while(counter > 0)
    {
        if(iniclanfunc.GetSetting(ClanName, 'player' + whilecount) == null)
        {
            return  whilecount;
            counter = 0;
            erfolg = 2;
        } else {
            whilecount = whilecount + 1;    
        }    
    }
    
    if(erfolg == 1)
    {
        return  whilecount;   
    }
}

function ClanPlayer(ClanName) {
    var iniclanfunc = Plugin.GetIni("Clan\\" + ClanName);
    var counter = Number(iniclanfunc.GetSetting(ClanName, 'player_count'));
    var str = [];
    var whilecount = 1;
    var a = 0;

    while(counter > 0)
    {
        if(iniclanfunc.GetSetting(ClanName, 'player' + whilecount) != null)
        {
            str[a] = iniclanfunc.GetSetting(ClanName, 'player' + whilecount);
            counter = counter -1;
            a = a + 1;
        }
        whilecount = whilecount + 1;

        if(whilecount > 60)
        {
            counter = 0;
        }
    }

    return str;
}

function ClanGetPlayerSlot(ClanName, ID) {
    var iniclanfunc = Plugin.GetIni("Clan\\" + ClanName);
    var counter = Number(iniclanfunc.GetSetting(ClanName, 'player_count'));
    var whilecount = 1;
    var erfolg = 1;

    while(counter > 0)
    {
        if(iniclanfunc.GetSetting(ClanName, 'player' + whilecount) == ID)
        {
            return  whilecount;
            counter = 0;
            erfolg = 2;
        } else {
            whilecount = whilecount + 1;
        }
    }

    if(erfolg == 1)
    {
        return null;
    }
}

function On_PlayerKilled(DeathEvent) {
    if(Data.GetConfigValue(ConfigName, "Settings", "enable") == "true")
    {
        var Attacker = DeathEvent.Attacker;
        var Victim = DeathEvent.Victim;
        
        if(Attacker.SteamID != Victim.SteamID)
        {
            var AttackerIni = Plugin.GetIni("UserData\\" + Attacker.SteamID);
            var VictimIni = Plugin.GetIni("UserData\\" + Victim.SteamID);
            
            AttackerIni.AddSetting('Information', 'kill_count', Number(AttackerIni.GetSetting('Information', 'kill_count')) + 1); //selbstmord
            AttackerIni.Save();
            VictimIni.AddSetting('Information', 'death_count', Number(VictimIniIni.GetSetting('Information', 'death_count')) + 1); //selbstmord
            VictimIni.Save();
        } else {
            var SelfIni = Plugin.GetIni("UserData\\" + Attacker.SteamID);
            
            SelfIni.AddSetting('Information', 'suicide_count', Number(SelfIni.GetSetting('Information', 'suicide_count')) + 1); //selbstmord
            SelfIni.Save();
        }    
    }    
}











