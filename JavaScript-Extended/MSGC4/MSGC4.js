//* By KichDM
//*TODO Para NovaLand Zero

function On_EntityHurt(HurtEvent) {
    if (HurtEvent.Attacker != null && HurtEvent.Entity != null) {
        if (HurtEvent.Entity.IsStructure() || HurtEvent.Entity.IsDeployableObject()) {
            var bleed = HurtEvent.DamageType;
            if (bleed == "Explosion") {

                var entname = HurtEvent.Entity.Name;

                if (entname == "WoodWall" || entname == "MetalWall" || entname == "WoodDoorFrame" || entname == "MetalDoorFrame" || entname == "MetalDoor" || entname == "WoodenDoor" || entname == "WoodRamp" || entname == "MetalRamp") {

                    var weapon = "NADA";
                    var dmg = Math.round(HurtEvent.DamageAmount);
                    var healt = HurtEvent.Entity.Health;
                    var raid = false;

                    if (dmg == 600) {
                        weapon = "C4";
                        if (healt <= 600) {
                            raid = true;
                        }
                    }

                    //Ajustar los valores de daño de las granadas. Cuanto hacen de daño las granadas en paredes y puertas
                    if (dmg > 70 && dmg < 90) {
                        weapon = "F1 Grenade";
                        var calc = healt - dmg;
                        if (calc <= 0) {
                            raid = true;
                        }
                    }

                    if (raid == true) {
                        var ini = getIni();
                        var ininombres = Plugin.GetIni("KLK");
                        var tt = ininombres.GetSetting(HurtEvent.Entity.OwnerID, "Name")
                        var name = HurtEvent.Attacker.Name;
                        var time = System.DateTime.Now.toString();
                        var loc = HurtEvent.Attacker.Location.toString();
                        var pos = Util.ConvertStringToVector3(loc);
                        var zona = Util.FindLocationName(pos);

                        if (weapon == "C4") {
                            ini.AddSetting("C4Log", loc, name + "|" + time + "|" + weapon + " " + entname);

                        }
                        else if (weapon == "F1 Grenade") {
                            ini.AddSetting("GrenadeLog", loc, name + "|" + time + "|" + weapon + " " + entname + " | " + tt);
                        }
                        Server.Broadcast(rojo + name + azulclaro + " Raideando en " +  blanco +"| " + amarillo + loc + " " + zona + blanco  + " a " + verde + tt);
                        ini.Save();
try {
                        Util.SendMessageToDiscordEmbed(
                            "https://discord.com/api/webhooks/955130535414476830/-dYClJnM66qEpuUdya5K_lnmi7iRcDKrqqhacRpZWN5kv_xCaA_7v1h2Jb2zJmSOq_4y",
                            "RAIDEO!",
                            "\n El jugador:\n" +
                            "**" + name + "**" +
                            " \n\n Esta Raidenado en:\n" +
                            "**||" + loc + "||**" +
                            " \n\n La Estructura \n" +
                            "**" + entname + "**" +
                            "\n\n Cerca de:\n" +
                            "**" + zona + "**"+
                            "\n\n Hora:\n" +
                            "**"+  time + "**" + 
                            "\n\n La base es de:\n" +
                            "__***~~" + tt + "~~***__"
                        );
                        
                        
                    }
                    catch (err) {
                        Util.LogRojo("ERROR AL ENVIAR MSG A DISCORD DE MSGC4++.js")   
                }
            
            }
                }
            }
        }
    }
}

function On_PlayerSpawned(Player, se) {
    var PlayerINI = Plugin.GetIni("KLK");
    PlayerINI.AddSetting(Player.SteamID, "Name", Player.Name);
    PlayerINI.Save();
}


function On_PlayerSpawning(Player, se) {
    var PlayerINI = Plugin.GetIni("KLK");
    PlayerINI.AddSetting(Player.SteamID, "Name", Player.Name);
    PlayerINI.Save();;
}

function getIni() {
    if (!Plugin.IniExists("C4Log")) {
        var ini = Plugin.CreateIni("C4Log");
        ini.AddSetting("C4Log");
        ini.Save();
    }
    return Plugin.GetIni("C4Log");
}