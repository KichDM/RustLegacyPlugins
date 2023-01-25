//* By KichDM
//*TODO Para NovaLand Zero
//*! Colores del pana kich
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


function On_ServerInit() {

    var klk2 = Plugin.GetIni("PlayersZonas");
    klk2.DeleteSetting("Small", "Players", 0);
    klk2.AddSetting("Vale", "Players", 0);
    klk2.AddSetting("Hangar", "Players", 0);
    klk2.AddSetting("Hvale", "Players", 0);
    klk2.AddSetting("Factory", "Players", 0);
    klk2.AddSetting("Big", "Players", 0);
    klk2.Save();
}

function On_PluginInit() {
    
    if (!Plugin.IniExists("Warp_config")) {
        Plugin.CreateIni("Warp_config");
        var Warpcfg = Plugin.GetIni("Warp_config");
        Warpcfg.AddSetting("Test", "SpawnheightCorrection", 5);
        //autocofiguracion de pas pos de los warps
        // el SpawnCount es cuanto punto spawn hay para calcular el spawn random que hara porfavor no pongais 9999 si no teneis 999 tp ya que no te hara tp algun sitio si no esta puesto
        Warpcfg.AddSetting("Small", "SpawnCount", 6);
        Warpcfg.AddSetting("Small", "Activado", "true");
        Warpcfg.AddSetting("Small", "Spawn1", "6548, 359, -4332");
        Warpcfg.AddSetting("Small", "Spawn2", "6074, 377, -3545");
        Warpcfg.AddSetting("Small", "Spawn3", "6100, 380, -3555");
        Warpcfg.AddSetting("Small", "Spawn4", "6053, 386, -3583");
        Warpcfg.AddSetting("Small", "Spawn5", "6044, 377, -3589");
        Warpcfg.AddSetting("Small", "Spawn6", "6077, 381, -3655");

        Warpcfg.AddSetting("Hangar", "SpawnCount", 7);
        Warpcfg.AddSetting("Hangar", "Activado", "true");
        Warpcfg.AddSetting("Hangar", "Spawn1", "6548, 359, -4332");
        Warpcfg.AddSetting("Hangar", "Spawn2", "6817, 342, -4207");
        Warpcfg.AddSetting("Hangar", "Spawn3", "6762, 330, -4379");
        Warpcfg.AddSetting("Hangar", "Spawn4", "6616, 356, -4192");
        Warpcfg.AddSetting("Hangar", "Spawn5", "6634, 351, -4313");
        Warpcfg.AddSetting("Hangar", "Spawn6", "6695, 343, -4355");
        Warpcfg.AddSetting("Hangar", "Spawn7", "6642, 353, -4236");

        Warpcfg.AddSetting("Hvale", "SpawnCount", 7);
        Warpcfg.AddSetting("Hvale", "Activado", "true");
        Warpcfg.AddSetting("Hvale", "Spawn1", "5984, 396, -2046");
        Warpcfg.AddSetting("Hvale", "Spawn2", "5930, 387, -2177");
        Warpcfg.AddSetting("Hvale", "Spawn3", "5978, 401, -2134");
        Warpcfg.AddSetting("Hvale", "Spawn4", "5563, 406, -2176");
        Warpcfg.AddSetting("Hvale", "Spawn5", "5870, 389, -2223");
        Warpcfg.AddSetting("Hvale", "Spawn6", "6160, 391, -2056");
        Warpcfg.AddSetting("Hvale", "Spawn7", "5614, 400, -2252");

        Warpcfg.AddSetting("Vale", "SpawnCount", 13);
        Warpcfg.AddSetting("Vale", "Activado", "true");
        Warpcfg.AddSetting("Vale", "Spawn1", "4776, 445 -3689");
        Warpcfg.AddSetting("Vale", "Spawn2", "4473, 476 -3793");
        Warpcfg.AddSetting("Vale", "Spawn3", "4628, 464 -3709");
        Warpcfg.AddSetting("Vale", "Spawn4", "4738, 445 -3723");
        Warpcfg.AddSetting("Vale", "Spawn5", "4591, 469, -3734");
        Warpcfg.AddSetting("Vale", "Spawn6", "4738, 445, -3723");
        Warpcfg.AddSetting("Vale", "Spawn7", "4694, 447, -3735");
        Warpcfg.AddSetting("Vale", "Spawn8", "4567, 462, -3770");
        Warpcfg.AddSetting("Vale", "Spawn9", "4473, 476, -3793");
        Warpcfg.AddSetting("Vale", "Spawn10", "4817, 442, -3671");
        Warpcfg.AddSetting("Vale", "Spawn11", "4639, 446, -3856");
        Warpcfg.AddSetting("Vale", "Spawn12", "4847, 430, -3903");
        Warpcfg.AddSetting("Vale", "Spawn13", "4858, 430, -3704");

        Warpcfg.AddSetting("Big", "SpawnCount", 9);
        Warpcfg.AddSetting("Big", "Activado", "true");
        Warpcfg.AddSetting("Big", "Spawn1", "5085, 376, -4838");
        Warpcfg.AddSetting("Big", "Spawn2", "5084, 376, -4773");
        Warpcfg.AddSetting("Big", "Spawn3", "5225, 372, -4675");
        Warpcfg.AddSetting("Big", "Spawn4", "5138, 382, -4692");
        Warpcfg.AddSetting("Big", "Spawn5", "5240, 360, -5006");
        Warpcfg.AddSetting("Big", "Spawn6", "5144, 363, -4935");
        Warpcfg.AddSetting("Big", "Spawn7", "5225, 365, -4883");
        Warpcfg.AddSetting("Big", "Spawn8", "5300, 361, -4934");
        Warpcfg.AddSetting("Big", "Spawn9", "5294, 369, -4731");

        Warpcfg.AddSetting("Factory", "SpawnCount", 7);
        Warpcfg.AddSetting("Factory", "Activado", "true");
        Warpcfg.AddSetting("Factory", "Spawn1", "6306, 360, -4647");
        Warpcfg.AddSetting("Factory", "Spawn2", "6474, 362, -4513");
        Warpcfg.AddSetting("Factory", "Spawn3", "6401, 358, -4441");

        Warpcfg.AddSetting("Factory", "Spawn5", "6344, 365, -4408");
        Warpcfg.AddSetting("Factory", "Spawn6", "6255, 355, -4509");
        Warpcfg.AddSetting("Factory", "Spawn7", "6472, 360, -4586");
        Warpcfg.Save();

    } else { //Actualización automática temporal para Spawn-Height-Correction
        var Warpcfg = Plugin.GetIni("Warp_config");
        var shCoor = Warpcfg.GetSetting("Test", "SpawnheightCorrection");
        if (!shCoor) {
            Warpcfg.AddSetting("Test", "SpawnheightCorrection", 5);
            Warpcfg.Save();
        }
    }
    if (!Plugin.IniExists("Zonas_Config")) {
        Plugin.CreateIni("Zonas_Config");
        var klk = klk();

    }

    if (!Plugin.IniExists("PlayersZonas")) {
        Plugin.CreateIni("PlayersZonas");
        var klk2 = Plugin.GetIni("PlayersZonas");
        klk2.AddSetting("Small", "Players", 0);
        klk2.AddSetting("Vale", "Players", 0);
        klk2.AddSetting("Hangar", "Players", 0);
        klk2.AddSetting("Hvale", "Players", 0);
        klk2.AddSetting("Factory", "Players", 0);
        klk2.AddSetting("Big", "Players", 0);
        klk2.Save();
        var klk1 = klk1();

    }
}

function WARPS1() {
    if (!Plugin.IniExists("WARPS1")) {
        var WARPS1 = Plugin.CreateIni("WARPS1");
        WARPS1.Save();

    }
    return Plugin.GetIni("WARPS1");
}

function klk() {
    if (!Plugin.IniExists("Zonas_Config")) {
        var klk = Plugin.CreateIni("Zonas_Config");
        klk.Save();
    }
    return Plugin.GetIni("Zonas_Config");
}

function klk1() {
    if (!Plugin.IniExists("PlayersZonas")) {
        var klk1 = Plugin.CreateIni("PlayersZonas");
        klk1.Save();
    }
    return Plugin.GetIni("PlayersZonas");
}
function On_ServerInit() {
    //Plugin.CreateTimer("ZonasTimer", 7000).Start();
}

function teste() {
    var ini = Plugin.GetIni("PlayersZonas");
    var SmallP = ini.GetSetting("Small", "Players");
    var HangarP = ini.GetSetting("Hangar", "Players");
    var ValeP = ini.GetSetting("Vale", "Players");
    var HvaleP = ini.GetSetting("Hvale", "Players");
    var FactoryP = ini.GetSetting("Factory", "Players");
    var BigP = ini.GetSetting("Big", "Players");
    if (!SmallP > 0) {
        ini.AddSetting("Small", "Players", 0);
        ini.Save();
    }
    if (!HangarP > 0) {
        ini.AddSetting("Hangar", "Players", 0);
        ini.Save();
    }
    if (!ValeP > 0) {
        ini.AddSetting("Vale", "Players", 0);
        ini.Save();
    }
    if (!HvaleP > 0) {
        ini.AddSetting("Hvale", "Players", 0);
        ini.Save();
    }
    if (!FactoryP > 0) {
        ini.AddSetting("Factory", "Players", 0);
        ini.Save();
    }
    if (!BigP > 0) {
        ini.AddSetting("Big", "Players", 0);
        ini.Save();
        return;
    }  
}

function On_Command(Player, cmd, args) {
    cmd = Data.ToLower(cmd);
    
    ZonasTT(Player);
    teste();
    var config = WARPS1();
    var ini = Plugin.GetIni("PlayersZonas");
    var SmallP = ini.GetSetting("Small", "Players");
    var HangarP = ini.GetSetting("Hangar", "Players");
    var ValeP = ini.GetSetting("Vale", "Players");
    var HvaleP = ini.GetSetting("Hvale", "Players");
    var FactoryP = ini.GetSetting("Factory", "Players");
    var BigP = ini.GetSetting("Big", "Players");
    var klk = Plugin.GetIni("Warp_config");
    var name = config.GetSetting("Settings", "name");
    var Small = klk.GetSetting("Small", "Activado");
    var Hangar = klk.GetSetting("Hangar", "Activado");
    var Hvale = klk.GetSetting("Hvale", "Activado");
    var Vale = klk.GetSetting("Vale", "Activado");
    var Big = klk.GetSetting("Big", "Activado");
    var Factory = klk.GetSetting("Factory", "Activado");

    //Codigos
    //***** AYUDA *******//
    if (cmd == "t" || cmd == "warps" || cmd == "w" || cmd == "warp") {
        Player.MessageFrom("Novaland Warps", "━━━━━━━━━━━━━━━━━━━" + rojo + "◤" + blanco + " Novaland Zero Warps " + rojo + "◥" + blanco + "━━━━━━━━━━━━━━━━━━");
        if (Small == "true" || Small == "si") {
            Player.MessageFrom("Novaland Warps", verde + "➤  " + azulclaro + "/small  -  " + verde + "ir small" + blanco + "  |  " + azulclaro + " [ " + amarillo + SmallP + azulclaro + " ] " + verde + " Players en Zona" + blanco + " | " + morado + " 250M ");
        }
        else {
            Player.MessageFrom("Novaland Warps", rojo + "➤  " + azulclaro + "/small  -  " + verde + "ir small " + rojo + " [OFF]");
        }
        if (Vale == "true" || Vale == "si") {
            Player.MessageFrom("Novaland Warps", verde + "➤  " + azulclaro + "/vale  -  " + verde + "ir vale" + blanco + "  |  " + azulclaro + " [ " + amarillo + ValeP + azulclaro + " ] " + verde + " Players en Zona" + blanco + " | " + morado + " 400M ");
        }
        else {
            Player.MessageFrom("Novaland Warps", rojo + "➤  " + azulclaro + "/vale  -  " + verde + "ir vale " + rojo + " [OFF]");
        }
        if (Hangar == "true" || Hangar == "si") {
            Player.MessageFrom("Novaland Warps", verde + "➤  " + azulclaro + "/hangar  -  " + verde + "ir hangar" + blanco + "  |  " + azulclaro + " [ " + amarillo + HangarP + azulclaro + " ] " + verde + " Players en Zona" + blanco + " | " + morado + " 400M ");
        }
        else {
            Player.MessageFrom("Novaland Warps", rojo + "➤  " + azulclaro + "/hangar  -  " + verde + "ir hangar " + rojo + " [OFF]");
        }
        if (Factory == "true" || Factory == "si") {
            Player.MessageFrom("Novaland Warps", verde + "➤  " + azulclaro + "/factory  -  " + verde + "ir factory" + blanco + "  |  " + azulclaro + " [ " + amarillo + FactoryP + azulclaro + " ] " + verde + " Players en Zona" + blanco + " | " + morado + " 400M ");
        }
        else {
            Player.MessageFrom("Novaland Warps", rojo + "➤  " + azulclaro + "/factory  -  " + verde + "ir factory " + rojo + " [OFF]");
        }
        if (Big == "true" || Big == "si") {
            Player.MessageFrom("Novaland Warps", verde + "➤  " + azulclaro + "/big  -  " + verde + "ir big" + blanco + "  |  " + azulclaro + " [ " + amarillo + BigP + azulclaro + " ] " + verde + " Players en Zona" + blanco + " | " + morado + " 300M ");
        }
        else {
            Player.MessageFrom("Novaland Warps", rojo + "➤  " + azulclaro + "/big  -  " + verde + "ir big " + rojo + " [OFF]");
        }
        if (Hvale == "true" || Hvale == "si") {
            Player.MessageFrom("Novaland Warps", verde + "➤  " + azulclaro + "/hvale  -  " + verde + "ir hvale" + blanco + "  |  " + azulclaro + " [ " + amarillo + HvaleP + azulclaro + " ] " + verde + " Players en Zona" + blanco + " | " + morado + " 500M ");
        }
        else {
            Player.MessageFrom("Novaland Warps", rojo + "➤  " + azulclaro + "/hvale  -  " + verde + "ir hvale " + rojo + " [OFF]");
        }
        Player.MessageFrom("Novaland Warps", "━━━━━━━━━━━━━━━━━━━" + rojo + "◣" + blanco + "  Warps By" + amarillo + " KichDM" + rojo + "◢" + blanco + "━━━━━━━━━━━━━━━━━━");
        if (Player.Admin) {
            Player.MessageFrom("Novaland Warps", "------ Novaland Zero - Warps - Admin Comandos -----");
            Player.MessageFrom("Novaland Warps", "setspawn - Nuevo punto de generación ");
            Player.MessageFrom("Novaland Warps", "setspawn ID del punto: cambia el punto de generación existente ");
        }
    }

    //***** Comando Iniciar Set Spawn *****//
    if ((cmd == "setspawn") && (Player.Admin)) {
        if (args.Length == 1) {
            SetSpawn(Player, 0);
        } else {
            if (isNaN(args[1])) {
                Player.MessageFrom("Novaland Warps", "Sintaxis: -t setspawn <numero> ex. -dm setspawn 2");
                Player.MessageFrom("Novaland Warps", "Para agregar un nuevo punto: -t setspawn");
            } else {
                SetSpawn(Player, args[1]);
            }
        }
    }
    if ((cmd == "recargat") && (Player.Admin)) {
        ini.AddSetting("Small", "Players", 0);
        ini.AddSetting("Hangar", "Players", 0);
        ini.AddSetting("Vale", "Players", 0);
        ini.AddSetting("Hvale", "Players", 0);
        ini.AddSetting("Factory", "Players", 0);
        ini.AddSetting("Big", "Players", 0);
        ini.Save();

        DataStore.Flush("delaysmall");
        DataStore.Flush("delayhangar");
        DataStore.Flush("delayVale");
        DataStore.Flush("delayHvale");
        DataStore.Flush("delayBig");
        DataStore.Flush("delayFactory");
        Player.MessageFrom("Novaland Warps", "listo pa");
    }
    //***** Comando de aparicion en el  final *****//
    //***** Iniciar comando Eliminar Spawn *****//
    if (cmd == "delspawn" && Player.Admin) { //Eliminar el último punto de generación
        var SpawnsINI = Plugin.GetIni("Warp_config");
        var CountS = SpawnsINI.EnumSection("Spawns");
        if (CountS == 0) {
            Player.MessageFrom("Novaland Warps", "No hay puntos para quitar.");

        }
        SpawnsINI.DeleteSetting("Test", "Spawn" + (CountS + 1));
        SpawnsINI.Save();
        Player.MessageFrom("Novaland Warps", "Borraste tu último punto, puntos totales " + (parseInt(CountS) - 1) + ".");
    }
    //***** Final comando Eliminar Spawn *****//
    //***** Iniciar Comandos de warps tps *****//
    var dinero = Economy.GetBalance(Player.SteamID);
    if (dinero >= 100) {
        var cooldown = config.GetSetting("Settings", "cd");
        var time = DataStore.Get("WARPS1", Player.SteamID);
        if (cooldown > 0) {
            var calc = System.Environment.TickCount - time;
            if (calc >= cooldown) {
                var klk = Plugin.GetIni("Warp_config");
                var name = config.GetSetting("Settings", "name");
                var Small = klk.GetSetting("Small", "Activado");
                var Hangar = klk.GetSetting("Hangar", "Activado");
                var Hvale = klk.GetSetting("Hvale", "Activado");
                var Vale = klk.GetSetting("Vale", "Activado");
                var Big = klk.GetSetting("Big", "Activado");
                var Factory = klk.GetSetting("Factory", "Activado");

                if (cmd == "small" && (Small == "true" || Small == "si")) {
                    var test1 = DataStore.Get("delaysmall", Player.SteamID);
                    if (test1 == undefined || test1 > 0) {
                        DataStore.Remove('delaysmall', Player.SteamID);
                    }
                    JoinSmall(Player);
                    DataStore.Add("WARPS1", Player.SteamID, System.Environment.TickCount);
                }
                else {
                    if (cmd == "small") {
                        Player.MessageFrom("Novaland Warps", rojo + "El Warp Small esta OFF.");
                    }
                }

                if (cmd == "hangar" && (Hangar == "true" || Hangar == "si")) {
                    if (test1 == undefined || test1 > 0) {
                        DataStore.Remove('delayhangar', Player.SteamID);
                    }
                    JoinHangar(Player);
                    DataStore.Add("WARPS1", Player.SteamID, System.Environment.TickCount);
                }
                else {
                    if (cmd == "hangar") {
                        Player.MessageFrom("Novaland Warps", rojo + "El Warp Hangar esta OFF.");
                    }
                }
                if (cmd == "hvale" && (Hvale == "true" || Hvale == "si")) {
                    if (test1 == undefined || test1 > 0) {
                        DataStore.Remove('delayHvale', Player.SteamID);
                    }
                    JoinHvale(Player);
                    DataStore.Add("WARPS1", Player.SteamID, System.Environment.TickCount);
                }
                else {
                    if (cmd == "hvale") {
                        Player.MessageFrom("Novaland Warps", rojo + "El Warp Hvale esta OFF.");
                    }
                }
                if (cmd == "vale" && (Vale == "true" || Vale == "si")) {
                    if (test1 == undefined || test1 > 0) {
                        DataStore.Remove('delayVale', Player.SteamID);
                    }
                    JoinVale(Player);
                    DataStore.Add("WARPS1", Player.SteamID, System.Environment.TickCount);
                }
                else {
                    if (cmd == "vale") {
                        Player.MessageFrom("Novaland Warps", rojo + "El Warp Vale esta OFF.");
                    }
                }
                if (cmd == "big" && (Big == "true" || Big == "si")) {
                    if (test1 == undefined || test1 > 0) {
                        DataStore.Remove('delayBig', Player.SteamID);
                    }
                    JoinBig(Player);
                    DataStore.Add("WARPS1", Player.SteamID, System.Environment.TickCount);
                }
                else {
                    if (cmd == "big") {
                        Player.MessageFrom("Novaland Warps", rojo + "El Warp Big esta OFF.");
                    }
                }
                if (cmd == "factory" && (Factory == "true" || Factory == "si")) {
                    if (test1 == undefined || test1 > 0) {
                        DataStore.Remove('delayFactory', Player.SteamID);
                    }
                    JoinFactory(Player);
                    DataStore.Add("WARPS1", Player.SteamID, System.Environment.TickCount);
                }
                else {
                    if (cmd == "factory") {
                        Player.MessageFrom("Novaland Warps", rojo + "El Warp Factory esta OFF.");
                    }
                }
            }
            else {
                if (cmd == "big" || cmd == "small" || cmd == "hangar" || cmd == "hvale" || cmd == "vale" || cmd == "factory") {
                    if (time == undefined || time == null || calc < 0) {
                        DataStore.Remove('WARPS1', Player.SteamID);
                         
                        Player.MessageFrom(name, "[color#00FFFF]Tenias el tiempo negativo bugueado[color#FF8000]" + " vuelve a usar el comando de nuevo!")
                    }
                    var next = calc / 1000;
                    next = next / 60;
                    var def = cooldown / 1000;
                    def = def / 60;
                    var done = Number(next).toFixed(2);
                    var done2 = Number(def).toFixed(2);
                    Player.MessageFrom(name, "[color#00FFFF]Podras usar los warps de nuevo en [color#FF8000]" + done + "[color#00FFFF]/[color#00FF40]" + done2 + " [color#00FFFF]minutos !")
                    var tt2 = (done2 - done).toFixed(2);
                    Player.MessageFrom(name, "[color#00FFFF]Podras usar los warps de nuevo en [color#FF8000] " + tt2 + " [color#00FFFF]segundos !")
                }

            }
        }
    }
    else {
        if (cmd == "big" || cmd == "small" || cmd == "hangar" || cmd == "hvale" || cmd == "vale" || cmd == "factory") {
            Player.MessageFrom("Novaland Warps", amarillo + "No tienes dinero necesitas" + rojo + "100" + amarillo + "minimo.");
            Player.MessageFrom("Novaland Warps", amarillo + " Dinero actual " + "[" + azul + dinero + amarillo + "]");
        }
    }
    return;
}

function JoinSmall(Player) {
    Player.MessageFrom("Novaland Warps", "[color#00FFFF]Seras teletransportado en [color#FF8000] 10s.");
    var klktt = Math.random() * 2.5;
    DataStore.Add("delaysmall", Player.SteamID, klktt);
    
	 
    Plugin.CreateTimer("JoinSmallTimer", 9000).Start();
}

function JoinHangar(Player) {
    Player.MessageFrom("Novaland Warps", "[color#00FFFF]Seras teletransportado en [color#FF8000] 10s.");
    var klktt = Math.random() * 2.5;
    DataStore.Add("delayhangar", Player.SteamID, klktt);
	 
    Plugin.CreateTimer("JoinHangarTimer", 9000).Start();
}

function JoinHvale(Player) {
    Player.MessageFrom("Novaland Warps", "[color#00FFFF]Seras teletransportado en [color#FF8000] 10s.");
    var klktt = Math.random() * 2.5;
    DataStore.Add("delayHvale", Player.SteamID, klktt);
	 
    Plugin.CreateTimer("JoinHvaleTimer", 9000).Start();
}

function JoinVale(Player) {
    Player.MessageFrom("Novaland Warps", "[color#00FFFF]Seras teletransportado en [color#FF8000] 10s.");
    var klktt = Math.random() * 2.5;
    DataStore.Add("delayVale", Player.SteamID, klktt);
	 
    Plugin.CreateTimer("JoinValeTimer", 9000).Start();
}

function JoinBig(Player) {
    Player.MessageFrom("Novaland Warps", "[color#00FFFF]Seras teletransportado en [color#FF8000] 10s.");
    var klktt = Math.random() * 2.5;
    DataStore.Add("delayBig", Player.SteamID, klktt);
	 
    Plugin.CreateTimer("JoinBigTimer", 9000).Start();
}

function JoinFactory(Player) {
    Player.MessageFrom("Novaland Warps", "[color#00FFFF]Seras teletransportado en [color#FF8000] 10s.");
    var klktt = Math.random() * 2.5;
    DataStore.Add("delayFactory", Player.SteamID, klktt);
	 
    Plugin.CreateTimer("JoinFactoryTimer", 9000).Start();
}

function SetSpawn(Player, SpawnNumber) {

    var SpawnsINI = Plugin.GetIni("Warp_config");
    var CountS = SpawnsINI.GetSetting("Small", "SpawnCount");
    var shCorr = SpawnsINI.GetSetting("Test", "SpawnheightCorrection");
    Player.MessageFrom("Novaland Warps", " Tu " + parseInt(CountS) + " puntos de generación y más agregados  +1");
    if (SpawnNumber == 0) {
        SpawnNumber = (parseInt(CountS) + 1);
        SpawnsINI.AddSetting("Spawns", "Spawn" + SpawnNumber, Player.X + ", " + (Player.Y + parseInt(shCorr)) + ", " + Player.Z);
        SpawnsINI.SetSetting("Test", "SpawnCount", (parseInt(CountS) + 1));
        SpawnsINI.Save();
        var Coor = Player.X + ", " + Player.Y + ", " + Player.Z;
        Player.MessageFrom("Novaland Warps", "Ha agregado un punto de generación. Número : " + SpawnNumber + " @Coordenadas  " + Coor);
    } else {
        if (SpawnNumber > CountS) { //Mira si existe el point
            Player.MessageFrom("Novaland Warps", "No tiene sentido este número. Ahora tu tienes  " + parseInt(CountS) + " Puntos .");
            return;
        }
        SpawnsINI.SetSetting("Spawns", "Spawn" + SpawnNumber, Player.X + ", " + (Player.Y + parseInt(shCorr)) + ", " + Player.Z);
        SpawnsINI.Save();
        Player.MessageFrom("Novaland Warps", "Has cambiado el número de punto de generación: " + SpawnNumber + " @Coordenadas  " + Player.X + ", " + Player.Y + ", " + Player.Z);
    }
}

function JoinSmallTimerCallback() {
    for (var pl in Server.Players) {
        if (DataStore.Get("delaysmall", pl.SteamID) != null) {
            var SpawnsINI = Plugin.GetIni("Warp_config");
            var CountS = SpawnsINI.GetSetting("Small", "SpawnCount");
            var SpawnN = getRandomInt(1, CountS)
            var SpawnP = SpawnsINI.GetSetting("Small", "Spawn" + SpawnN);
            var SpawnPA = SpawnP.split(",");
            pl.TeleportTo(SpawnPA[0], SpawnPA[1], SpawnPA[2]);
            Economy.BalanceSub(pl.SteamID, 100);
            DataStore.Add("delaysmall", pl.SteamID, null);
             
            var dinero = Economy.GetBalance(pl.SteamID);
            pl.MessageFrom("Novaland Zero", rojo + "-100" + verde + " de dinero quitado" + amarillo + " Dinero actual " + "[" + azul + dinero + amarillo + "]");
            Server.BroadcastFrom("Novaland Warps", "[COLOR#FF8000]" + pl.Name + "[COLOR#00FFFF]" + "  Fue a small! usando" + "[COLOR#ff0000]" + "  /small");
            break;
        }
    }
    Plugin.KillTimer("JoinSmallTimer");
}


function JoinHangarTimerCallback() {
    for (var pl in Server.Players) {
        if (DataStore.Get("delayhangar", pl.SteamID) != null) {
            var SpawnsINI = Plugin.GetIni("Warp_config");
            var CountS = SpawnsINI.GetSetting("Hangar", "SpawnCount");
            var SpawnN = getRandomInt(1, CountS)
            var SpawnP = SpawnsINI.GetSetting("Hangar", "Spawn" + SpawnN);
            var SpawnPA = SpawnP.split(",");
            pl.TeleportTo(SpawnPA[0], SpawnPA[1], SpawnPA[2]);
            Economy.BalanceSub(pl.SteamID, 100);
            DataStore.Add("delayhangar", pl.SteamID, null);
             
            var dinero = Economy.GetBalance(pl.SteamID);
            pl.MessageFrom("Novaland Zero", rojo + "-100" + verde + " de dinero quitado" + amarillo + " Dinero actual " + "[" + azul + dinero + amarillo + "]");
            Server.BroadcastFrom("Novaland Warps", "[COLOR#FF8000]" + pl.Name + "[COLOR#00FFFF]" + "  Fue a hangar! usando" + "[COLOR#ff0000]" + "  /hangar");
            break;
        }
    }
    Plugin.KillTimer("JoinHangarTimer");
}

function JoinBigTimerCallback() {
    for (var pl in Server.Players) {
        if (DataStore.Get("delayBig", pl.SteamID) != null) {
            var SpawnsINI = Plugin.GetIni("Warp_config");
            var CountS = SpawnsINI.GetSetting("Big", "SpawnCount");
            var SpawnN = getRandomInt(1, CountS)
            var SpawnP = SpawnsINI.GetSetting("Big", "Spawn" + SpawnN);
            var SpawnPA = SpawnP.split(",");
            pl.TeleportTo(SpawnPA[0], SpawnPA[1], SpawnPA[2]);
            Economy.BalanceSub(pl.SteamID, 100);
            DataStore.Add("delayBig", pl.SteamID, null);
             
            var dinero = Economy.GetBalance(pl.SteamID);
            pl.MessageFrom("Novaland Zero", rojo + "-100" + verde + " de dinero quitado" + amarillo + " Dinero actual " + "[" + azul + dinero + amarillo + "]");
            Server.BroadcastFrom("Novaland Warps", "[COLOR#FF8000]" + pl.Name + "[COLOR#00FFFF]" + "  Fue a Big! usando" + "[COLOR#ff0000]" + "  /big");
            break;
        }
    }
    Plugin.KillTimer("JoinBigTimer");
}

function JoinHvaleTimerCallback() {
    for (var pl in Server.Players) {
        if (DataStore.Get("delayHvale", pl.SteamID) != null) {
            var SpawnsINI = Plugin.GetIni("Warp_config");
            var CountS = SpawnsINI.GetSetting("Hvale", "SpawnCount");
            var SpawnN = getRandomInt(1, CountS)
            var SpawnP = SpawnsINI.GetSetting("Hvale", "Spawn" + SpawnN);
            var SpawnPA = SpawnP.split(",");
            pl.TeleportTo(SpawnPA[0], SpawnPA[1], SpawnPA[2]);
            Economy.BalanceSub(pl.SteamID, 100);
            DataStore.Add("delayHvale", pl.SteamID, null);
             
            var dinero = Economy.GetBalance(pl.SteamID);
            pl.MessageFrom("Novaland Zero", rojo + "-100" + verde + " de dinero quitado" + amarillo + " Dinero actual " + "[" + azul + dinero + amarillo + "]");
            Server.BroadcastFrom("Novaland Warps", "[COLOR#FF8000]" + pl.Name + "[COLOR#00FFFF]" + "  Fue a Hvale! usando" + "[COLOR#ff0000]" + "  /hvale");
            break;
        }
    }
    Plugin.KillTimer("JoinHvaleTimer");
}

function JoinValeTimerCallback() {
    for (var pl in Server.Players) {
        if (DataStore.Get("delayVale", pl.SteamID) != null) {
            var SpawnsINI = Plugin.GetIni("Warp_config");
            var CountS = SpawnsINI.GetSetting("Vale", "SpawnCount");
            var SpawnN = getRandomInt(1, CountS)
            var SpawnP = SpawnsINI.GetSetting("Vale", "Spawn" + SpawnN);
            var SpawnPA = SpawnP.split(",");
            pl.TeleportTo(SpawnPA[0], SpawnPA[1], SpawnPA[2]);
            Economy.BalanceSub(pl.SteamID, 100);
            DataStore.Add("delayVale", pl.SteamID, null);
             
            var dinero = Economy.GetBalance(pl.SteamID);
            pl.MessageFrom("Novaland Zero", rojo + "-100" + verde + " de dinero quitado" + amarillo + " Dinero actual " + "[" + azul + dinero + amarillo + "]");
            Server.BroadcastFrom("Novaland Warps", "[COLOR#FF8000]" + pl.Name + "[COLOR#00FFFF]" + "  Fue a Vale! usando" + "[COLOR#ff0000]" + "  /vale");
            break;
        }
    }
    Plugin.KillTimer("JoinValeTimer");
}

function JoinFactoryTimerCallback() {
    for (var pl in Server.Players) {
        if (DataStore.Get("delayFactory", pl.SteamID) != null) {
            var SpawnsINI = Plugin.GetIni("Warp_config");
            var CountS = SpawnsINI.GetSetting("Factory", "SpawnCount");
            var SpawnN = getRandomInt(1, CountS)
            var SpawnP = SpawnsINI.GetSetting("Factory", "Spawn" + SpawnN);
            var SpawnPA = SpawnP.split(",");
            pl.TeleportTo(SpawnPA[0], SpawnPA[1], SpawnPA[2]);
            Economy.BalanceSub(pl.SteamID, 100);
            DataStore.Add("delayFactory", pl.SteamID, null);
             
            var dinero = Economy.GetBalance(pl.SteamID);
            pl.MessageFrom("Novaland Zero", rojo + "-100" + verde + " de dinero quitado" + amarillo + " Dinero actual " + "[" + azul + dinero + amarillo + "]");
            Server.BroadcastFrom("Novaland Warps", "[COLOR#FF8000]" + pl.Name + "[COLOR#00FFFF]" + "  Fue a Factory! usando" + "[COLOR#ff0000]" + "  /factory");
            break;
        }
    }
    Plugin.KillTimer("JoinFactoryTimer");
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

function ZonasTT(Player) {

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////!SMALL //////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    var ini = Plugin.GetIni("Zonas_Config");
    var tt1 = Plugin.GetIni("PlayersZonas");
    var x = ini.GetSetting("Small", "ZonaX");
    var y = ini.GetSetting("Small", "ZonaY");
    var z = ini.GetSetting("Small", "ZonaZ");
    var klktt = tt1.GetSetting("Small", Player.SteamID);
    var test = tt1.GetSetting("Small", "Players");
    var a = Util.CreateVector(x, y, z);
    var b = Util.CreateVector(Player.X, Player.Y, Player.Z);
    var radius = parseInt(ini.GetSetting("Small", "Radio"));
    var distance = parseInt(Util.GetVectorsDistance(a, b));
        if (distance < radius) {
            tt1.AddSetting("Small", Player.SteamID, "ON");
            tt1.Save();
            var test = tt1.GetSetting("Small", "Players");
            if (test == undefined) {
                tt1.AddSetting("Small", "Players", 1);
                tt1.Save();
                test = 1;
            } else {
                if (klktt == "OFF") {
                    tt1.SetSetting("Small", "Players", (parseInt(test) + 1));
                    test = (parseInt(test) + 1);
                    tt1.Save();
                    return;
                }
            }
        }
        if (distance > radius) {
            var test = tt1.GetSetting("Small", "Players");
            if (test == undefined) {
                tt1.AddSetting("Small", "Players", 1);
                tt1.Save();
                test = 1;
            } else {
                if (klktt == "ON") {
                    tt1.AddSetting("Small", Player.SteamID, "OFF");
                    tt1.SetSetting("Small", "Players", (parseInt(test) - 1));
                    test = (parseInt(test) - 1);
                    tt1.Save();
                    return;
                }
            }
        }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////!HANGAR!//////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        var x = ini.GetSetting("Hangar", "ZonaX");
        var y = ini.GetSetting("Hangar", "ZonaY");
        var z = ini.GetSetting("Hangar", "ZonaZ");
        var klktt = tt1.GetSetting("Hangar", Player.SteamID);
        var test = tt1.GetSetting("Hangar", "Players");
        var a = Util.CreateVector(x, y, z);
        var b = Util.CreateVector(Player.X, Player.Y, Player.Z);
        var radius = parseInt(ini.GetSetting("Hangar", "Radio"));
        var distance = parseInt(Util.GetVectorsDistance(a, b));
        if (distance < radius) {
            tt1.AddSetting("Hangar", Player.SteamID, "ON");
            tt1.Save();
            var test = tt1.GetSetting("Hangar", "Players");
            if (test == undefined) {
                tt1.AddSetting("Hangar", "Players", 1);
                test = 1;


            } else {
                if (klktt == "OFF") {
                    tt1.SetSetting("Hangar", "Players", (parseInt(test) + 1));
                    test = (parseInt(test) + 1);
                    tt1.Save();
                    return;
                    
                }
            }
        }
        if (distance > radius) {
            var test = tt1.GetSetting("Hangar", "Players");
            if (test == undefined) {
                tt1.AddSetting("Hangar", "Players", 1);
                test = 1;
                tt1.Save();
            } else {
                if (klktt == "ON") {
                    tt1.AddSetting("Hangar", Player.SteamID, "OFF");
                    tt1.SetSetting("Hangar", "Players", (parseInt(test) - 1));
                    test = (parseInt(test) - 1);
                    tt1.Save();
                    return;
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////!Factory!//////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        var x = ini.GetSetting("Factory", "ZonaX");
        var y = ini.GetSetting("Factory", "ZonaY");
        var z = ini.GetSetting("Factory", "ZonaZ");
        var klktt = tt1.GetSetting("Factory", Player.SteamID);
        var test = tt1.GetSetting("Factory", "Players");
        var a = Util.CreateVector(x, y, z);
        var b = Util.CreateVector(Player.X, Player.Y, Player.Z);
        var radius = parseInt(ini.GetSetting("Factory", "Radio"));
        var distance = parseInt(Util.GetVectorsDistance(a, b));
        if (distance < radius) {
            tt1.AddSetting("Factory", Player.SteamID, "ON");
            tt1.Save();
            var test = tt1.GetSetting("Factory", "Players");
            if (test == undefined) {
                tt1.AddSetting("Factory", "Players", 1);
                tt1.Save();
                test = 1;
            } else {
                if (klktt == "OFF") {
                    tt1.SetSetting("Factory", "Players", (parseInt(test) + 1));
                    test = (parseInt(test) + 1);
                    tt1.Save();
                    return;
                }
            }
        }
        if (distance > radius) {
            var test = tt1.GetSetting("Factory", "Players");
            if (test == undefined) {
                tt1.AddSetting("Factory", "Players", 1);
                test = 1;
                tt1.Save();
            } else {
                if (klktt == "ON") {
                    tt1.AddSetting("Factory", Player.SteamID, "OFF");
                    tt1.SetSetting("Factory", "Players", (parseInt(test) - 1));
                    test = (parseInt(test) - 1);
                    tt1.Save();
                    return;
                }
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////!Vale!//////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        var x = ini.GetSetting("Vale", "ZonaX");
        var y = ini.GetSetting("Vale", "ZonaY");
        var z = ini.GetSetting("Vale", "ZonaZ");
        var klktt = tt1.GetSetting("Vale", Player.SteamID);
        var test = tt1.GetSetting("Vale", "Players");
        var a = Util.CreateVector(x, y, z);
        var b = Util.CreateVector(Player.X, Player.Y, Player.Z);
        var radius = parseInt(ini.GetSetting("Vale", "Radio"));
        var distance = parseInt(Util.GetVectorsDistance(a, b));
        if (distance < radius) {
            tt1.AddSetting("Vale", Player.SteamID, "ON");
            tt1.Save();
            var test = tt1.GetSetting("Vale", "Players");
            if (test == undefined) {
                tt1.AddSetting("Vale", "Players", 1);
                tt1.Save();
                test = 1;
            } else {
                if (klktt == "OFF") {
                    tt1.SetSetting("Vale", "Players", (parseInt(test) + 1));
                    test = (parseInt(test) + 1);
                    tt1.Save();
                    if (test < 0) {
                        tt1.AddSetting("Vale", "Players", 1);
                        test = 0;
                        tt1.Save();
                    }
                    return;
                }
            }
        }
        if (distance > radius) {
            var test = tt1.GetSetting("Vale", "Players");
            if (test == undefined) {
                tt1.AddSetting("Vale", "Players", 1);
                tt1.Save();
                test = 1;
            } else {
                if (klktt == "ON") {
                    tt1.AddSetting("Vale", Player.SteamID, "OFF");
                    tt1.SetSetting("Vale", "Players", (parseInt(test) - 1));
                    test = (parseInt(test) - 1);
                    tt1.Save();

                    return;
                }
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////!HVale!//////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        var x = ini.GetSetting("Hvale", "ZonaX");
        var y = ini.GetSetting("Hvale", "ZonaY");
        var z = ini.GetSetting("Hvale", "ZonaZ");
        var klktt = tt1.GetSetting("Hvale", Player.SteamID);
        var test = tt1.GetSetting("Hvale", "Players");
        var a = Util.CreateVector(x, y, z);
        var b = Util.CreateVector(Player.X, Player.Y, Player.Z);
        var radius = parseInt(ini.GetSetting("Hvale", "Radio"));
        var distance = parseInt(Util.GetVectorsDistance(a, b));
        if (distance < radius) {
            tt1.AddSetting("Hvale", Player.SteamID, "ON");
            tt1.Save();
            var test = tt1.GetSetting("Hvale", "Players");
            if (test == undefined) {
                tt1.AddSetting("Hvale", "Players", 1);
                tt1.Save();
                test = 1;
            } else {
                if (klktt == "OFF") {
                    tt1.SetSetting("Hvale", "Players", (parseInt(test) + 1));
                    test = (parseInt(test) + 1);
                    tt1.Save();
                    return;
                }
            }
        }
        if (distance > radius) {
            var test = tt1.GetSetting("Hvale", "Players");
            if (test == undefined) {
                tt1.AddSetting("Hvale", "Players", 1);
                test = 1;
            } else {
                if (klktt == "ON") {
                    tt1.AddSetting("Hvale", Player.SteamID, "OFF");
                    tt1.SetSetting("Hvale", "Players", (parseInt(test) - 1));
                    tt1.Save();
                    test = (parseInt(test) - 1);

                    return;
                }
            }
        }
        
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////!Big!//////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        var x = ini.GetSetting("Big", "ZonaX");
        var y = ini.GetSetting("Big", "ZonaY");
        var z = ini.GetSetting("Big", "ZonaZ");
        var klktt = tt1.GetSetting("Big", Player.SteamID);
        var test = tt1.GetSetting("Big", "Players");
        var a = Util.CreateVector(x, y, z);
        var b = Util.CreateVector(Player.X, Player.Y, Player.Z);
        var radius = parseInt(ini.GetSetting("Big", "Radio"));
        var distance = parseInt(Util.GetVectorsDistance(a, b));
        if (distance < radius) {
            tt1.AddSetting("Big", Player.SteamID, "ON");
            tt1.Save();
            var test = tt1.GetSetting("Big", "Players");
            if (test == undefined) {
                tt1.AddSetting("Big", "Players", 1);
                tt1.Save();
                test = 1;
            } else {
                if (klktt == "OFF") {
                    tt1.SetSetting("Big", "Players", (parseInt(test) + 1));
                    test = (parseInt(test) + 1);
                    tt1.Save();
                    return;
                }
            }
        }
        if (distance > radius) {
            var test = tt1.GetSetting("Big", "Players");
            if (test == undefined) {
                tt1.AddSetting("Big", "Players", 1);
                tt1.Save();
                test = 1;
            } else {
                if (klktt == "ON") {
                    tt1.AddSetting("Big", Player.SteamID, "OFF");
                    tt1.SetSetting("Big", "Players", (parseInt(test) - 1));
                    test = (parseInt(test) - 1);
                    tt1.Save();

                    return;
                }
            }
        }
        return;     
    }


function On_PlayerDisconnected(Player) {
    var ini = Plugin.GetIni("PlayersZonas");
    var klktt = ini.GetSetting("Small", Player.SteamID);
    var test = ini.GetSetting("Small", "Players");
    if (klktt == "ON") {
        ini.AddSetting("Small", Player.SteamID, "OFF");
        ini.Save();
        ini.SetSetting("Small", "Players", (parseInt(test) - 1));
        ini.Save();


    }
    var klktt = ini.GetSetting("Hangar", Player.SteamID);
    var test = ini.GetSetting("Hangar", "Players");
    if (klktt == "ON") {
        ini.AddSetting("Hangar", Player.SteamID, "OFF");
        ini.Save();
        ini.SetSetting("Hangar", "Players", (parseInt(test) - 1));
        ini.Save();

    }
    var klktt = ini.GetSetting("Vale", Player.SteamID);
    var test = ini.GetSetting("Vale", "Players");
    if (klktt == "ON") {
        ini.AddSetting("Vale", Player.SteamID, "OFF");
        ini.Save();
        ini.SetSetting("Vale", "Players", (parseInt(test) - 1));
        ini.Save();

    }
    var klktt = ini.GetSetting("Hvale", Player.SteamID);
    var test = ini.GetSetting("Hvale", "Players");
    if (klktt == "ON") {
        ini.AddSetting("Hvale", Player.SteamID, "OFF");
        ini.Save();
        ini.SetSetting("Hvale", "Players", (parseInt(test) - 1));
        ini.Save();

    }
    var klktt = ini.GetSetting("Big", Player.SteamID);
    var test = ini.GetSetting("Big", "Players");
    if (klktt == "ON") {
        ini.AddSetting("Big", Player.SteamID, "OFF");
        ini.Save();
        ini.SetSetting("Big", "Players", (parseInt(test) - 1));
        ini.Save();

    }
    var klktt = ini.GetSetting("Factory", Player.SteamID);
    var test = ini.GetSetting("Factory", "Players");
    if (klktt == "ON") {
        ini.AddSetting("Factory", Player.SteamID, "OFF");
        ini.SetSetting("Factory", "Players", (parseInt(test) - 1));
        ini.Save();

    }
    return;
}