//* By KichDM 
//*TODO Para NovaLand Zero

var negro = "[color #000000]";
var gris = "[color #424242]";
var grisclaro = "[color #D8D8D8]";
var blanco = "[color #FFFFFF]";
var rosa = "[color #F781F3]";
var morado = "[color #6A0888]";
var rojo = "[color #FF0000]";
var azul = "[color #001EFF]";
var verde = "[color #00FF40]";
var azulclaro = "[color #00FFF7]";
var amarillo = "[color #FCFF02]";
var naranja = "[color #CD8C00]";
var marron = "[color #604200]";
var turquesa = "[color #00FFC0]";
var naranjab = "[color #FF6600]";

function On_PluginInit() {

    if (!Plugin.IniExists("NVKD_kill")) {
        Plugin.CreateIni("NVKD_kill");
    }
    if (!Plugin.IniExists("NVKD_Muertes")) {
        Plugin.CreateIni("NVKD_Muertes");
    }
    if (!Plugin.IniExists("NVKD_Players")) {
        Plugin.CreateIni("NVKD_Players");
    }
}


function BD(bodyp) {
    var ini = Bodies();
    var name = ini.GetSetting("bodyparts", bodyp);
    return name;
}

function Bodies() {
    if (!Plugin.IniExists("bodyparts"))
        Plugin.CreateIni("bodyparts");
    return Plugin.GetIni("bodyparts");
}


function On_Command(Player, cmd, args) {
    cmd = Data.ToLower(cmd);
    //***** AYUDA *******//
    if (cmd == "kd" && cmd == "help") {
        Player.MessageFrom("Novaland KD", "--------- Novaland Zero - KD - Comandos --------");
        Player.MessageFrom("Novaland KD", "Usa /rank para ver el top 10");
        Player.MessageFrom("Novaland KD", "Usa /stats para ver sus stats");
        Player.MessageFrom("Novaland KD", "Usa /kills para tus Kills");
        Player.MessageFrom("Novaland KD", "Usa /muertes para tus muertes");
        Player.MessageFrom("Novaland KD", "Usa /kd para ver tu KD");
    }
    //***** FINAL DE AYUDA *******//
    if (cmd == "kills" || cmd == "baja" || cmd == "bajas") {
        KDkill(Player);
    }
    if (cmd == "muertes" || cmd == "muerte") {
        KDMuertes(Player);
    }
    if (cmd == "kd") {
        KDtt(Player);
    }
    if (cmd == "stats") {
        msg1(Player);
    }
    //***** Inicio comando Rank *****//
    if (cmd == "rank" || cmd == "top") {
        Ranking(Player);
    }
    //***** Final Comando Rank *****//
	return;
}

function On_PlayerKilled(DeathEvent) {

var NVKDpl = Plugin.GetIni("NVKD_Players");
    var killer = DeathEvent.Attacker.Name;
    var victim = DeathEvent.Victim.Name;
    var weapon = DeathEvent.WeaponName;
    var distance = Util.GetVectorsDistance(DeathEvent.Attacker.Location, DeathEvent.Victim.Location);
    var number = Number(distance).toFixed(2);
    var bodyPart = BD(DeathEvent.DamageEvent.bodyPart);


    var NVKDsc = Plugin.GetIni("NVKD_kill");
    var NVKDMr = Plugin.GetIni("NVKD_Muertes");
    var VicMuerte = NVKDMr.GetSetting("Muerte", DeathEvent.Victim.SteamID);

    var Vickill = NVKDsc.GetSetting("kills", DeathEvent.Victim.SteamID);
    var Vickd = (Vickill / VicMuerte).toFixed(2);
    if (Vickd == "Infinity") {
        Vickd = 0;
    }
    if (VicMuerte == "Infinity") {
        VicMuerte = 0;
    }
    if (VicMuerte == undefined || VicMuerte == null) {
        VicMuerte = 0;
    }

    if (Vickill == undefined || Vickill == null) {
        Vickill = 0;
    }
    if (Vickd <= 0) {
        Vickd = Vickill
    }

    var AtcMuerte = NVKDMr.GetSetting("Muerte", DeathEvent.Attacker.SteamID);
    var Atckill = NVKDsc.GetSetting("kills", DeathEvent.Attacker.SteamID);
    var Atckd = (Atckill / AtcMuerte).toFixed(2);
    if (Atckd == "Infinity") {
        Atckd = 0;
    }
    if (AtcMuerte == "Infinity") {
        AtcMuerte = 0;
    }

    if (AtcMuerte == undefined || AtcMuerte == null) {
        AtcMuerte = 0;
    }
    if (Atckill == undefined || Atckill == null) {
        Atckill = 0;
    }
    if (Atckd <= 0) {
        Atckd = Atckill
    }

    var bleed = DeathEvent.DamageType;
    if (victim != azulclaro + killer && bleed != null && DeathEvent.Victim != null && DeathEvent.Attacker != null && DeathEvent.Attacker != "undefined" && DeathEvent.Victim != "undefined") {
        if (bleed == "Bullet" && bodyPart != "undefined") {
            if (weapon == "HandCannon") {
                Server.Broadcast(amarillo + "[" + Atckd + "]" + azulclaro + killer + blanco + " mato " + amarillo + "[" + Vickd + "]" + azulclaro + victim + blanco + " | " + azulclaro + weapon + blanco + " a " + azulclaro + number + blanco + " m " + rojo + bodyPart + blanco);

            }

            else if (weapon == "Pipe Shotgun") {
                Server.Broadcast(amarillo + "[" + Atckd + "]" + azulclaro + killer + blanco + " mato " + amarillo + "[" + Vickd + "]" + azulclaro + victim + blanco + " | " + azulclaro + weapon + blanco + " a " + azulclaro + number + blanco + " m " + rojo + bodyPart + blanco);

            }

            else if (weapon == "Revolver") {
                Server.Broadcast(amarillo + "[" + Atckd + "]" + azulclaro + killer + blanco + " mato " + amarillo + "[" + Vickd + "]" + azulclaro + victim + blanco + " | " + azulclaro + weapon + blanco + " a " + azulclaro + number + blanco + " m " + rojo + bodyPart + blanco);
 
            }

            else if (weapon == "9mm Pistol") {
                Server.Broadcast(amarillo + "[" + Atckd + "]" + azulclaro + killer + blanco + " mato " + amarillo + "[" + Vickd + "]" + azulclaro + victim + blanco + " | " + azulclaro + weapon + blanco + " a " + azulclaro + number + blanco + " m " + rojo + bodyPart + blanco);

            }

            else if (weapon == "P250") {
                Server.Broadcast(amarillo + "[" + Atckd + "]" + azulclaro + killer + blanco + " mato " + amarillo + "[" + Vickd + "]" + azulclaro + victim + blanco + " | " + azulclaro + weapon + blanco + " a " + azulclaro + number + blanco + " m " + rojo + bodyPart + blanco);

            }

            else if (weapon == "Hunting Bow" || weapon == undefined) {
                Server.Broadcast(amarillo + "[" + Atckd + "]" + azulclaro + killer + blanco + " mato " + amarillo + "[" + Vickd + "]" + azulclaro + victim + blanco + " | " + azulclaro + " Hunting Bow  " + blanco + " a " + azulclaro + number + blanco + " m " + rojo);

            }

            else if (weapon == "Shotgun") {
                Server.Broadcast(amarillo + "[" + Atckd + "]" + azulclaro + killer + blanco + " mato " + amarillo + "[" + Vickd + "]" + azulclaro + victim + blanco + " | " + azulclaro + weapon + blanco + " a " + azulclaro + number + blanco + " m " + rojo + bodyPart + blanco);

            }

            else if (weapon == "Bolt Action Rifle") {
                Server.Broadcast(amarillo + "[" + Atckd + "]" + azulclaro + killer + blanco + " mato " + amarillo + "[" + Vickd + "]" + azulclaro + victim + blanco + " | " + azulclaro + weapon + blanco + " a " + azulclaro + number + blanco + " m " + rojo + bodyPart + blanco);

            }

            else if (weapon == "M4") {
                Server.Broadcast(amarillo + "[" + Atckd + "]" + azulclaro + killer + blanco + " mato " + amarillo + "[" + Vickd + "]" + azulclaro + victim + blanco + " | " + azulclaro + weapon + blanco + " a " + azulclaro + number + blanco + " m " + rojo + bodyPart + blanco);
                return;
            }

            else if (weapon == "MP5A4") {
                Server.Broadcast(amarillo + "[" + Atckd + "]" + azulclaro + killer + blanco + " mato " + amarillo + "[" + Vickd + "]" + azulclaro + victim + blanco + " | " + azulclaro + weapon + blanco + " a " + azulclaro + number + blanco + " m " + rojo + bodyPart + blanco);

            }
         }
        else if (bleed == "Melee") {
            if (weapon == "Hatchet") {
                Server.Broadcast(amarillo + "[" + Atckd + "]" + azulclaro + killer + blanco + " mato " + amarillo + "[" + Vickd + "]" + azulclaro + victim + blanco + " | " + azulclaro + weapon + blanco + " a " + azulclaro + number + blanco + " m ");

            }
            else if (weapon == "Rock") {
                Server.Broadcast(amarillo + "[" + Atckd + "]" + azulclaro + killer + blanco + " mato " + amarillo + "[" + Vickd + "]" + azulclaro + victim + blanco + " | " + azulclaro + weapon + blanco + " a " + azulclaro + number + blanco + " m ");

            }
            else if (weapon == "Pick Axe") {
                Server.Broadcast(amarillo + "[" + Atckd + "]" + azulclaro + killer + blanco + " mato " + amarillo + "[" + Vickd + "]" + azulclaro + victim + blanco + " | " + azulclaro + weapon + blanco + " a " + azulclaro + number + blanco + " m ");

            }
            else if (weapon == "Stone Hatchet") {
                Server.Broadcast(amarillo + "[" + Atckd + "]" + azulclaro + killer + blanco + " mato " + amarillo + "[" + Vickd + "]" + azulclaro + victim + blanco + " | " + azulclaro + weapon + blanco + " a " + azulclaro + number + blanco + " m ");

            }
            else if (weapon == "Hunting Bow") {
                Server.Broadcast(amarillo + "[" + Atckd + "]" + azulclaro + killer + blanco + " mato " + amarillo + "[" + Vickd + "]" + azulclaro + victim + blanco + " | " + azulclaro + weapon + blanco + " a " + azulclaro + number + blanco + " m ");

            }
        }
        else if (bleed == "Explosion") {
            if (weapon == undefined) {
                Server.Broadcast(amarillo + "[" + Atckd + "]" + azulclaro + killer + blanco + " mato " + amarillo + "[" + Vickd + "]" + azulclaro + victim + blanco + " con " + rojo + "F1 Grenade/C4 " + azulclaro);

            }
        }
        else if (bleed == "Bleeding") {
            Server.Broadcast(amarillo + "[" + Vickd + "]" + azulclaro + victim + blanco + " muerto " + rojo + " desangrado. " + blanco + " por " + amarillo + "[" + Atckd + "]" + azulclaro + killer);

        }
        if (victim == killer)
        {
            //para evitar el bug que envie mensajes de discord cuando alguien muere por si mismo por bug
        }
        else {
            Util.SendMessageToDiscordEmbed(
                "https://discord.com/api/webhooks/967542451776675870/I_TUoQiG-q6OF9TZzLfGj-6gWFodPa4nOHn4mI-h1-1NTPkjQ7AIy_BMA59IUhVWG7OW",
                "KILLS EPICAS",
                "\n El jugador:\n" +
                "**" + killer + "**" +
                " \n\n Mato a: \n" +
                "**" + victim + "**" +
                " \n\n Arma:\n" +
                "**" + weapon + "**" +
                " \n\n Distancia: \n" +
                "**" + number + "**" +
                "\n\n Parte del cuerpo:\n" +
                "**"+  bodyPart + "**");
        }
        
    }
	        var NVKDpl = Plugin.GetIni("NVKD_Players");
        var InKD = NVKDpl.GetSetting(DeathEvent.Attacker.SteamID, "InKD");
            if (DeathEvent.Attacker.SteamID != undefined) {
                killBoard(DeathEvent.Attacker, DeathEvent.Victim);
            }
    
	return;
}

function killBoard(Attacker, Victim) {

    var NVKDsc = Plugin.GetIni("NVKD_kill");
    var NVKDpl = Plugin.GetIni("NVKD_Players");
    var NVKDMr = Plugin.GetIni("NVKD_Muertes");
    if (Attacker.SteamID != Victim.SteamID) {
        var kill = NVKDsc.GetSetting("kills", Attacker.SteamID);
        if (kill == undefined) {
            NVKDsc.AddSetting("kills", Attacker.SteamID, 1);
            NVKDsc.Save();
            kill = 1;
        } else {
            NVKDsc.SetSetting("kills", Attacker.SteamID, (parseInt(kill) + 1));
            NVKDsc.Save();
            kill = (parseInt(kill) + 1);
        }
        //Server.BroadcastFrom("[KD]", "[ +" + (kill) + "  Kills  ] " + Attacker.Name + " ► " + Victim.Name);
    }

    if (Victim.SteamID != Attacker.SteamID) {
        var Muerte = NVKDMr.GetSetting("Muerte", Victim.SteamID);
        if (Muerte == undefined) {
            NVKDMr.AddSetting("Muerte", Victim.SteamID, 1);
            NVKDMr.Save();
            Muerte = 1;
        } else {
            NVKDMr.SetSetting("Muerte", Victim.SteamID, (parseInt(Muerte) + 1));
            NVKDMr.Save();
            Muerte = (parseInt(Muerte) + 1);
        }
        //Server.BroadcastFrom("[KD]", "[ +" + (Muerte) + "  Muerte  ] " + Attacker.Name + " ► " + Victim.Name);
    }
}


function Ranking(Player) {
    var NVKDsc = Plugin.GetIni("NVKD_kill");
    Player.MessageFrom("[KD]", "━━━━━━━━━━━━━━━━━━━" + rojo + "◤" + blanco + "  TOP PVP " + rojo + "◥" + blanco + "━━━━━━━━━━━━━━━━━━━");
    var killsA = [];
    var PlayerINI = Plugin.GetIni("NVKD_Players");
    //Player.Message("OK A");
    for (var kills in NVKDsc.EnumSection("kills")) {
        var nameP = kills;
        var x = [nameP, parseInt(NVKDsc.GetSetting("kills", kills))];
        killsA.push(x);
    }
    //Player.Message("OK B");
    killsA.sort(function (a, b) {
        return a[1] - b[1];
    });
    //Player.Message("OK C");
    killsA.reverse();
    for (var i = 0; i < killsA.length; i++) {
        if (killsA[i][1] > 0) {
            var NVKDMr = Plugin.GetIni("NVKD_Muertes");
            var PlayerINI1 = Plugin.GetIni("NVKD_Players");
            var Muerte = NVKDMr.GetSetting("Muerte", killsA[i][0]);
            var sName = PlayerINI1.GetSetting(killsA[i][0], "Name");
            var xkill = (killsA[i][1]).toString();
            xkill = (padding_left(xkill, 5));
            var a = parseInt(Muerte);
            var b = parseInt(xkill);
            var KD = (b / a).toFixed(2);


            if (Muerte == undefined || Muerte == null) {
                Muerte = 0;
            }

            if (xkill == undefined || xkill == null) {
                xkill = 0;
            }
            if (KD == "Infinity") {
                KD = 0;
            }
            if (KD <= 0) {
                KD = xkill
            }
            if (isNaN(KD)) {
                KD = xkill
            }
            //Player.MessageFrom("[KD]", rojo+ "#" + (i + 1) +  blanco + " |  " + naranjab + sName + blanco +"  |" + verde + xkill + amarillo +" Kills" + Muerte + " Muertes");
            Player.MessageFrom("[KD]", azulclaro + "#" + (i + 1) + blanco + " | " + naranjab + sName + blanco + " |" + verde + xkill + " Kill(s)" + blanco + " | " + rojo + Muerte + " Muerte(s)" + blanco + " | " + amarillo + KD + " KD");
            if (i == 9) {
                break;
            }
        }
    }
}
function KDkill(Player) {
    var NVKDsc = Plugin.GetIni("NVKD_kill");
    var kill = NVKDsc.GetSetting("kills", Player.SteamID);
    if (kill == undefined || kill == null) {
        kill = 0;
    }
    Player.Message(rojo + "➤" + blanco + "[color #FF6600]Kills:  " + verde + kill);
}

function KDMuertes(Player) {
    var NVKDMr = Plugin.GetIni("NVKD_Muertes");
    var Muerte = NVKDMr.GetSetting("Muerte", Player.SteamID);
    if (Muerte == undefined || Muerte == null) {
        Muerte = 0;
    }
    Player.Message(rojo + "➤" + blanco + "[color #FF6600]Muertes: " + rojo + Muerte);
}

function KDtt(Player) {
    var NVKDMr = Plugin.GetIni("NVKD_Muertes");
    var Muerte = NVKDMr.GetSetting("Muerte", Player.SteamID);
    var NVKDsc = Plugin.GetIni("NVKD_kill");
    var kill = NVKDsc.GetSetting("kills", Player.SteamID);
    var kd = (kill / Muerte).toFixed(2);
    if (Muerte == undefined || Muerte == null) {
        Muerte = 0;
    }
    if (kill == undefined || kill == null) {
        kill = 0;
    }
    var kd = (kill / Muerte).toFixed(2);
    if (kd == "Infinity") {
        kd = 0;
    }
    if (kd <= 0) {
        kd = kill
    }
    Player.MessageFrom("[KD]", "Tienes  " + kd + " KD.");
}

function msg1(Player) {
    var NVKDMr = Plugin.GetIni("NVKD_Muertes");
    var Muerte = NVKDMr.GetSetting("Muerte", Player.SteamID);
    if (Muerte == undefined || Muerte == null) {
        Muerte = 0;
    }
    var NVKDsc = Plugin.GetIni("NVKD_kill");
    var kill = NVKDsc.GetSetting("kills", Player.SteamID);
    if (kill == undefined || kill == null) {
        kill = 0;
    }
    var kd = (kill / Muerte).toFixed(2);
    if (kd == "Infinity") {
        kd = 0;
    }
    if (kd <= 0) {
        kd = kill
    }
    var Segundos = ((Player.TimeOnline / 1000) % 60).toFixed();
    var Minutos = ((Player.TimeOnline / 60000) % 60).toFixed();
    var Horas = (Player.TimeOnline / 3600000).toFixed();
    Player.Message("━━━━━━━━━━━━━━━━━━━" + rojo + "◤" + blanco + " STATS" + rojo + "◥" + blanco + "━━━━━━━━━━━━━━━━━━");
    Player.Message(rojo + "➤" + "[color #FF6600]SALUD:[color #FFFFCC]" + Player.Health + "    [color #FF6600]DIRECCIÓN IP:[color #FFFFCC] " + Player.IP);
    Player.Message(rojo + "➤" + "[color #FF6600]NOMBRE:[color #FFFFCC] " + Player.Name + "    [color #FF6600]PING:[color #FFFFCC]  " + Player.Ping + "   [color #FF6600]UID:[color #FFFFCC] " + Player.SteamID);
    Player.Message(rojo + "➤" + "[color #FF6600]UBICACIÓN ACTUAL:[color #FFFFCC] X: " + Math.round(Player.X) + ", Y: " + Math.round(Player.Y) + ", Z: " + Math.round(Player.Z));
    Player.Message(rojo + "➤" + "[color #FF6600]TIEMPO EN LÍNEA:[color #FFFFCC] " + Horas + " horas,  " + Minutos + " minutos,  " + Segundos + " segundos.");
    Player.Message(rojo + "➤" + blanco + "[color #FF6600]Kills:  " + verde + kill);
    Player.Message(rojo + "➤" + blanco + "[color #FF6600]Muertes: " + rojo + Muerte);
    Player.Message(rojo + "➤" + blanco + " [color #FF6600]KD: " + amarillo + kd);
}



function On_PlayerSpawned(Player, se) {
    var PlayerINI = Plugin.GetIni("NVKD_Players");
    var NVPlayers = PlayerINI.GetSetting(Player.SteamID, "InKD");
    if (!NVPlayers) {
        PlayerINI.AddSetting(Player.SteamID, "Name", Player.Name);
        PlayerINI.Save();
    }
}

function On_PlayerSpawning(Player, se) {
    var PlayerINI = Plugin.GetIni("NVKD_Players");
    var NVPlayers = PlayerINI.GetSetting(Player.SteamID, "InKD");
    if (!NVPlayers) {
        PlayerINI.AddSetting(Player.SteamID, "Name", Player.Name);
        PlayerINI.Save();;
    }
}

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function padding_left(s, n) {
    var c = " ";
    if (!s || !c || s.length >= n) {
        return s;
    }
    var max = (n - s.length) / c.length;
    for (var i = 0; i < max; i++) {
        s = c + s;
    }
    return s;
}