
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

function On_PlayerConnected(Player) {
    var config = KLK();
    var name = config.GetSetting("Settings", "name");
}

function On_PlayerDisconnected(Player){
	//DataStore.Remove('KLK', Player.SteamID);
    DataStore.Remove('KLK', Player.SteamID);
    DataStore.Remove('KLK1', Player.SteamID);
    DataStore.Remove('KLK2', Player.SteamID);
    DataStore.Remove('KLK3', Player.SteamID);
    DataStore.Remove('KLK4', Player.SteamID);
    DataStore.Remove('KLK5', Player.SteamID);
    DataStore.Remove('KLK6', Player.SteamID);
    DataStore.Remove('KLK7', Player.SteamID);
    DataStore.Remove('KLK8', Player.SteamID);
    DataStore.Remove('KLK9', Player.SteamID);
    DataStore.Remove('KLK10', Player.SteamID);
    DataStore.Remove('KLK11', Player.SteamID);
    DataStore.Save();
}

function KLK() {
    if (!Plugin.IniExists("KLK")) {
        var KLK = Plugin.CreateIni("KLK");
        KLK.Save();
    }
    return Plugin.GetIni("KLK");
}

function On_Command(Player, cmd, args) {
    cmd = Data.ToLower(cmd);
    var config = KLK();
    if (cmd == "regalo" || cmd == "regalos" || cmd == "reward") {
        switch (args.Length) {
            case 0:
                Player.MessageFrom("Novaland Regalos", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                
                if (Player.TimeOnline >= 900000) {
            
                    Player.MessageFrom("Regalos", verde + "➤ " + naranja + "Regalo 1 ON " + blanco + "||" + amarillo + " 15 Min ON" + verde + " (9mm Pistola + Balas)");
                    
                }
                else {
                    var tt = (900000 - Player.TimeOnline);
                    var tt1 = (tt / 60000);
                    var tt2 = Math.floor(tt1)
                    Player.MessageFrom("Regalos", rojo + "➤ " + marron + "Regalo 1 OFF " + blanco + "||" + amarillo + " 15 Min ON" + verde + " (9mm Pistola + Balas)  " + azulclaro + tt2 +" minuto(s)  " + naranja+ "restantes");
                }

                if (Player.TimeOnline >= 1800000) {
                    Player.MessageFrom("Regalos", verde + "➤ " + naranja + "Regalo 2 ON " + blanco + "||" + amarillo + " 30 Min ON" + verde + " (P250 + Balas)");
                }
                else {
                    var tt = (1800000 - Player.TimeOnline);
                    var tt1 = (tt / 60000);
                    var tt2 = Math.floor(tt1)
                    Player.MessageFrom("Regalos", rojo + "➤ " + marron + "Regalo 2 OFF" + blanco + "||" + amarillo + " 30 Min ON" + verde + " (P250 + Balas) " + azulclaro + tt2 +" minuto(s)  " + naranja+ "restantes");
                }

                if (Player.TimeOnline >= 3600000) {
                    Player.MessageFrom("Regalos", verde + "➤ " + naranja + "Regalo 3 ON" + blanco + "||" + amarillo + " 60 Min ON" + verde + " (+1000 Money)");
                }
                else {
                    var tt = (3600000 - Player.TimeOnline);
                    var tt1 = (tt / 60000);
                    var tt2 = Math.floor(tt1)
                    Player.MessageFrom("Regalos", rojo + "➤ " + marron + "Regalo 3 OFF" + blanco + "||" + amarillo + " 60 Min ON" + verde + " (+1000 Money) " + azulclaro + tt2 +" minuto(s)  " + naranja+ "restantes");
                }

                if (Player.TimeOnline >= 7200000) {
                    Player.MessageFrom("Regalos", verde + "➤ " + naranja + "Regalo 4 ON" + blanco + "||" + amarillo + " 2h ON" + verde + " (Full Leather + M4)");
                }
                else {
                    var tt = (7200000 - Player.TimeOnline);
                    var tt1 = (tt / 60000);
                    var tt2 = Math.floor(tt1)
                    Player.MessageFrom("Regalos", rojo + "➤ " + marron + "Regalo 4 OFF" + blanco + "||" + amarillo + " 2h ON" + verde + " (Full Leather + M4) " + azulclaro + tt2 +" minuto(s)  " + naranja+ "restantes");
                }

                if (Player.TimeOnline >= 10800000) {
                    Player.MessageFrom("Regalos", verde + "➤ " + naranja + "Regalo 5 ON" + blanco + "||" + amarillo + " 3h ON" + verde + " (+4000 Money + P250) ");
                }
                else {
                    var tt = (10800000 - Player.TimeOnline);
                    var tt1 = (tt / 60000);
                    var tt2 = Math.floor(tt1)
                    Player.MessageFrom("Regalos", rojo + "➤ " + marron + "Regalo 5 OFF" + blanco + "||" + amarillo + " 3h ON" + verde + " (+4000 Money + P250) " + azulclaro + tt2 +" minuto(s)  " + naranja+ "restantes");
                }

                if (Player.TimeOnline >= 14400000) {
                    Player.MessageFrom("Regalos", verde + "➤ " + naranja + "Regalo 6 ON" + blanco + "||" + amarillo + " 4h ON" + verde + " (2 C4 + 1 M4 + 1 Holo Sight)");
                }
                else {
                    var tt = (14400000 - Player.TimeOnline);
                    var tt1 = (tt / 60000);
                    var tt2 = Math.floor(tt1)
                    Player.MessageFrom("Regalos", rojo + "➤ " + marron + "Regalo 6 OFF" + blanco + "||" + amarillo + " 4h ON" + verde + " (2 C4 + 1 M4 + 1 Holo Sight) " + azulclaro + tt2 +" minuto(s)  " + naranja+ "restantes");
                }

                if (Player.TimeOnline >= 18000000) {
                    Player.MessageFrom("Regalos", verde + "➤ " + naranja + "Regalo 7 ON" + blanco + "||" + amarillo + " 5h ON" + verde + " (Full Kevlar + 1 P250)");
                }
                else {
                    var tt = (18000000 - Player.TimeOnline);
                    var tt1 = (tt / 60000);
                    var tt2 = Math.floor(tt1)
                    Player.MessageFrom("Regalos", rojo + "➤ " + marron + "Regalo 7 OFF" + blanco + "||" + amarillo + " 5h ON" + verde + " (Full Kevlar + 1 P250) " + azulclaro + tt2 +" minuto(s)  " + naranja+ "restantes");
                }

                if (Player.TimeOnline >= 21600000) {
                    Player.MessageFrom("Regalos", verde + "➤ " + naranja + "Regalo 8 ON" + blanco + "||" + amarillo + " 6h ON" + verde + " (Full Kevlar + M4)");
                }
                else {
                    var tt = (21600000 - Player.TimeOnline);
                    var tt1 = (tt / 60000);
                    var tt2 = Math.floor(tt1)
                    Player.MessageFrom("Regalos", rojo + "➤ " + marron + "Regalo 8 OFF" + blanco + "||" + amarillo + " 6h ON" + verde + " (Full Kevlar + M4) " + azulclaro + tt2 +" minuto(s)  " + naranja+ "restantes");
                }

                if (Player.TimeOnline >= 25200000) {
                    Player.MessageFrom("Regalos", verde + "➤ " + naranja + "Regalo 9 ON" + blanco + "||" + amarillo + " 7h ON" + verde + " (1 Supply Signal)");
                }
                else {
                    var tt = (25200000 - Player.TimeOnline);
                    var tt1 = (tt / 60000);
                    var tt2 = Math.floor(tt1)
                    Player.MessageFrom("Regalos", rojo + "➤ " + marron + "Regalo 9 OFF" + blanco + "||" + amarillo + " 7h ON" + verde + " (1 Supply Signal) " + azulclaro + tt2 +" minuto(s)  " + naranja+ "restantes");
                }

                if (Player.TimeOnline >= 28800000) {
                    Player.MessageFrom("Regalos", verde + "➤ " + naranja + "Regalo 10 ON" + blanco + "||" + amarillo + " 8h ON" + verde + " (Todas las Weapons Part)");
                }
                else {
                    var tt = (28800000 - Player.TimeOnline);
                    var tt1 = (tt / 60000);
                    var tt2 = Math.floor(tt1)
                    Player.MessageFrom("Regalos", rojo + "➤ " + marron + "Regalo 10 OFF" + blanco + "||" + amarillo + " 8h ON" + verde + " (Todas las Weapons Part) " + azulclaro + tt2 +" minuto(s)  " + naranja+ "restantes");
                }

                if (Player.TimeOnline >= 32400000) {
                    Player.MessageFrom("Regalos", verde + "➤ " + naranja + "Regalo 11 ON" + blanco + "||" + amarillo + " 9h ON" + verde + " (2 Supply + 2 Full Kevlar + 4 M4)");
                }
                else {
                    var tt = (32400000 - Player.TimeOnline);
                    var tt1 = (tt / 60000);
                    var tt2 = Math.floor(tt1)
                    
                    Player.MessageFrom("Regalos", rojo + "➤ " + marron + "Regalo 11 OFF" + blanco + "||" + amarillo + " 9h ON" + verde + " (2 Supply + 2 Full Kevlar + 4 M4) " + azulclaro + tt2 +" minuto(s)  " + naranja+ "restantes");
                }
                Player.MessageFrom("Novaland Regalos", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                break;

            case 1:
                switch (args[0]) {
                    case "1":
                        if (Player.TimeOnline >= 900000) {
                            if (Player.Inventory.FreeSlots <= 2) {

                                Player.MessageFrom("Regalos", "Tu inventario esta lleno necesitas 2 Espacio libre  ");
                            }

                            else  {
                                var cooldown = config.GetSetting("Settings", "cd1");
                                var time = DataStore.Get("KLK", Player.SteamID);
                                var calc = System.Environment.TickCount - time;

                                if (cooldown > 0) {
                                    if (calc >= cooldown) {
                                        Player.Inventory.AddItem("9mm Pistol", 1)
                                        Player.Inventory.AddItem("9mm Ammo", 100)
                                        Player.MessageFrom("Regalos", "Has recibido una 9mm Pistol con 100 Balas");
                                        Server.Broadcast(rojo + "➤ " + azulclaro + Player.Name + verde + " Ha obtenido el regalo 1 usado" + amarillo + "/regalo 1");
                                        DataStore.Add("KLK", Player.SteamID, System.Environment.TickCount);
                                        DataStore.Save();
                                    }
                                    else {
                                        if (time == undefined || time == null || calc < 0) {
                                            DataStore.Remove('KLK', Player.SteamID);
                                            DataStore.Save();
                                        }
                                        var next = calc / 1000;
                                        next = next / 60;
                                        var def = cooldown / 1000;
                                        def = def / 60;
                                        var done = Number(next).toFixed(2); 
                                        var done2 = Number(def).toFixed(2); 
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000]" + done + "[color#00FFFF]/[color#00FF40]" + done2 + " [color#00FFFF]minutos !")
                                        var tt2 = (done2 - done)
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000] " + tt2 + " [color#00FFFF]Minutos !")
                                    }
                                }
                            }
                        }
                        else {
                            Player.MessageFrom("Regalos", rojo + "No tienes el tiempo suficiente aun rata");
                        }

                        break;

                    case "2":

                        if (Player.TimeOnline >= 1800000) {
                            if (Player.Inventory.FreeSlots <= 2) {

                                Player.MessageFrom("Regalos", "Tu inventario esta lleno necesitas 2 Espacio libre  ");
                            }

                            else {

                                var config = KLK();
                                var cooldown = config.GetSetting("Settings", "cd2");
                                var time = DataStore.Get("KLK2", Player.SteamID);

                                if (cooldown > 0) {
                                    var calc = System.Environment.TickCount - time;
                                    if (calc >= cooldown) {
                                        Player.Inventory.AddItem("P250", 1)
                                        Player.Inventory.AddItem("9mm Ammo", 100)
                                       Player.MessageFrom("Regalos", "Has recibido una P250");
                                       Server.Broadcast(rojo+"➤ " +azulclaro+ Player.Name +verde + " Ha obtenido el regalo 2 usado" + amarillo + "/regalo 2");
                                        DataStore.Add("KLK2", Player.SteamID, System.Environment.TickCount);
                                        DataStore.Save();
                                    }
                                    else {
                                        if (time == undefined || time == null || calc < 0) {
                                            DataStore.Remove('KLK2', Player.SteamID);
                                            DataStore.Save();
                                        }
                                        var next = calc / 1000;
                                        next = next / 60;
                                        var def = cooldown / 1000;
                                        def = def / 60;
                                        var done = Number(next).toFixed(2);
                                        var done2 = Number(def).toFixed(2);
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000]" + done + "[color#00FFFF]/[color#00FF40]" + done2 + " [color#00FFFF]minutos !")
                                        var tt2 = (done2 - done)
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000] " + tt2 + " [color#00FFFF]Minutos !")
                                    }
                                }
                            }
                        }
                        else {
                            Player.MessageFrom("Regalos", rojo + "No tienes el tiempo suficiente aun rata");
                        }

                        break;

                    case "3":

                        if (Player.TimeOnline >= 3600000) {
                            if (Player.Inventory.FreeSlots <= 0) {

                                Player.MessageFrom("Regalos", "Tu inventario esta lleno necesitas 0 Espacio libre  ");
                            }

                            else {

                                var config = KLK();
                                var cooldown = config.GetSetting("Settings", "cd3");
                                var time = DataStore.Get("KLK3", Player.SteamID);

                                if (cooldown > 0) {
                                    var calc = System.Environment.TickCount - time;
                                    if (calc >= cooldown) {
                                        Economy.BalanceAdd(Player.SteamID,1000);
                                        Player.MessageFrom("Regalos", "Has recibido +1000 Money");
                                        Server.Broadcast(rojo+"➤ " +azulclaro+ Player.Name +verde + " Ha obtenido el regalo 3 usado" + amarillo + "/regalo 2");
                                        DataStore.Add("KLK3", Player.SteamID, System.Environment.TickCount);
                                        DataStore.Save();
                                    }
                                    else {
                                        if (time == undefined || time == null || calc < 0) {
                                            DataStore.Remove('KLK3', Player.SteamID);
                                            DataStore.Save();
                                        }
                                        var next = calc / 1000;
                                        next = next / 60;
                                        var def = cooldown / 1000;
                                        def = def / 60;
                                        var done = Number(next).toFixed(2);
                                        var done2 = Number(def).toFixed(2);
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000]" + done + "[color#00FFFF]/[color#00FF40]" + done2 + " [color#00FFFF]minutos !")
                                        var tt2 = (done2 - done)
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000] " + tt2 + " [color#00FFFF]Minutos !")
                                    }
                                }
                            }
                        }
                        else {
                            Player.MessageFrom("Regalos", rojo + "No tienes el tiempo suficiente aun rata");
                        }

                        break;

                    case "4":

                        if (Player.TimeOnline >= 7200000) {
                            if (Player.Inventory.FreeSlots <= 6) {

                                Player.MessageFrom("Regalos", "Tu inventario esta lleno necesitas 6 Espacio libre  ");
                            }

                            else {

                                var config = KLK();
                                var cooldown = config.GetSetting("Settings", "cd4");
                                var time = DataStore.Get("KLK4", Player.SteamID);

                                if (cooldown > 0) {
                                    var calc = System.Environment.TickCount - time;

                                    if (calc >= cooldown) {
                                        Player.Inventory.AddItem("M4", 1)
                                        Player.Inventory.AddItem("556 Ammo", 100)
                                        Player.Inventory.AddItem("Leather Boots", 1)
                                        Player.Inventory.AddItem("Leather Helmet", 1)
                                        Player.Inventory.AddItem("Leather Pants", 1)
                                        Player.Inventory.AddItem("Leather Vest", 1)
                                       Player.MessageFrom("Regalos", "Full Leather con 1 M4 y municion de M4");
                                       Server.Broadcast(rojo+"➤ " +azulclaro+ Player.Name +verde + " Ha obtenido el regalo 4 usado" + amarillo + "/regalo 4");
                                        DataStore.Add("KLK4", Player.SteamID, System.Environment.TickCount);
                                        DataStore.Save();
                                    }
                                    else {
                                        if (time == undefined || time == null || calc < 0) {
                                            DataStore.Remove('KLK4', Player.SteamID);
                                            DataStore.Save();
                                        }
                                        var next = calc / 1000;
                                        next = next / 60;
                                        var def = cooldown / 1000;
                                        def = def / 60;
                                        var done = Number(next).toFixed(2);
                                        var done2 = Number(def).toFixed(2);
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000]" + done + "[color#00FFFF]/[color#00FF40]" + done2 + " [color#00FFFF]minutos !")
                                        var tt2 = (done2 - done)
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000] " + tt2 + " [color#00FFFF]Minutos !")
                                    }
                                }
                            }
                        }
                        else {
                            Player.MessageFrom("Regalos", rojo + "No tienes el tiempo suficiente aun rata");
                        }

                        break;
                    case "5":

                        if (Player.TimeOnline >= 10800000) {
                            if (Player.Inventory.FreeSlots <= 1) {

                                Player.MessageFrom("Regalos", "Tu inventario esta lleno necesitas 1 Espacio libre  ");
                            }

                            else {

                                var config = KLK();
                                var cooldown = config.GetSetting("Settings", "cd5");
                                var time = DataStore.Get("KLK5", Player.SteamID);

                                if (cooldown > 0) {
                                    var calc = System.Environment.TickCount - time;
                                    if (calc >= cooldown) {
                                        Economy.BalanceAdd(Player.SteamID,4000);
                                        Player.Inventory.AddItem("P250", 1)
                                       Player.MessageFrom("Regalos", "Has recibido una P250 y +4000 Money");
                                       Server.Broadcast(rojo+"➤ " +azulclaro+ Player.Name +verde + " Ha obtenido el regalo 5 usado" + amarillo + "/regalo 5");
                                        DataStore.Add("KLK5", Player.SteamID, System.Environment.TickCount);
                                        DataStore.Save();
                                    }
                                    else {
                                        if (time == undefined || time == null || calc < 0) {
                                            DataStore.Remove('KLK5', Player.SteamID);
                                            DataStore.Save();
                                        }
                                        var next = calc / 1000;
                                        next = next / 60;
                                        var def = cooldown / 1000;
                                        def = def / 60;
                                        var done = Number(next).toFixed(2);
                                        var done2 = Number(def).toFixed(2);
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000]" + done + "[color#00FFFF]/[color#00FF40]" + done2 + " [color#00FFFF]minutos !")
                                        var tt2 = (done2 - done)
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000] " + tt2 + " [color#00FFFF]Minutos !");
                                    }
                                }
                            }
                        }
                        else {
                            Player.MessageFrom("Regalos", rojo + "No tienes el tiempo suficiente aun rata");
                        }

                        break;
                    case "6":

                        if (Player.TimeOnline >= 14400000) {
                            if (Player.Inventory.FreeSlots <= 4) {

                                Player.MessageFrom("Regalos", "Tu inventario esta lleno necesitas 4 Espacio libre  ");
                            }

                            else {

                                var config = KLK();
                                var cooldown = config.GetSetting("Settings", "cd6");
                                var time = DataStore.Get("KLK6", Player.SteamID);

                                if (cooldown > 0) {
                                    var calc = System.Environment.TickCount - time;

                                    if (calc >= cooldown) {
                                        Player.Inventory.AddItem("Explosive Charge", 2)
                                        Player.Inventory.AddItem("M4", 1)
                                        Player.Inventory.AddItem("556 Ammo", 100)
                                        Player.Inventory.AddItem("Holo sight", 1)
                                       Player.MessageFrom("Regalos", "Has recibido 2 C4 + M4 con municion + 1 Holo");
                                       Server.Broadcast(rojo+"➤ " +azulclaro+ Player.Name +verde + " Ha obtenido el regalo 6 usado" + amarillo + "/regalo 6");
                                        DataStore.Add("KLK6", Player.SteamID, System.Environment.TickCount);
                                        DataStore.Save();
                                    }
                                    else {
                                        if (time == undefined || time == null || calc < 0) {
                                            DataStore.Remove('KLK6', Player.SteamID);
                                            DataStore.Save();
                                        }
                                        var next = calc / 1000;
                                        next = next / 60;
                                        var def = cooldown / 1000;
                                        def = def / 60;
                                        var done = Number(next).toFixed(2);
                                        var done2 = Number(def).toFixed(2);
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000]" + done + "[color#00FFFF]/[color#00FF40]" + done2 + " [color#00FFFF]minutos !")
                                        var tt2 = (done2 - done)
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000] " + tt2 + " [color#00FFFF]Minutos !")
                                    }
                                }
                            }
                        }
                        else {
                            Player.MessageFrom("Regalos", rojo + "No tienes el tiempo suficiente aun rata");
                        }

                        break;
                    case "7":

                        if (Player.TimeOnline >= 18000000) {
                            if (Player.Inventory.FreeSlots <= 5) {

                                Player.MessageFrom("Regalos", "Tu inventario esta lleno necesitas 5 Espacio libre  ");
                            }

                            else {

                                var config = KLK();
                                var cooldown = config.GetSetting("Settings", "cd7");
                                var time = DataStore.Get("KLK7", Player.SteamID);

                                if (cooldown > 0) {
                                    var calc = System.Environment.TickCount - time;
                                    if (calc >= cooldown) {
                                        Player.Inventory.AddItem("P250", 1)
                                        Player.Inventory.AddItem("Kevlar Boots", 1)
                                        Player.Inventory.AddItem("Kevlar Helmet", 1)
                                        Player.Inventory.AddItem("Kevlar Pants", 1)
                                        Player.Inventory.AddItem("Kevlar Vest", 1)
                                           Player.MessageFrom("Regalos", "Has recibido una  + Full Kevlar");
                                           Server.Broadcast(rojo+"➤ " +azulclaro+ Player.Name +verde + " Ha obtenido el regalo 7 usado" + amarillo + "/regalo 7");
                                        DataStore.Add("KLK7", Player.SteamID, System.Environment.TickCount);
                                        DataStore.Save();
                                    }
                                    else {
                                        if (time == undefined || time == null || calc < 0) {
                                            DataStore.Remove('KLK7', Player.SteamID);
                                            DataStore.Save();
                                        }
                                        var next = calc / 1000;
                                        next = next / 60;
                                        var def = cooldown / 1000;
                                        def = def / 60;
                                        var done = Number(next).toFixed(2);
                                        var done2 = Number(def).toFixed(2);
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000]" + done + "[color#00FFFF]/[color#00FF40]" + done2 + " [color#00FFFF]minutos !")
                                        var tt2 = (done2 - done)
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000] " + tt2 + " [color#00FFFF]Minutos !")
                                    }
                                }
                            }
                        }
                        else {
                            Player.MessageFrom("Regalos", rojo + "No tienes el tiempo suficiente aun rata");
                        }

                        break;
                    case "8":

                        if (Player.TimeOnline >= 21600000) {
                            if (Player.Inventory.FreeSlots <= 6) {

                                Player.MessageFrom("Regalos", "Tu inventario esta lleno necesitas 6 Espacio libre  ");
                            }

                            else {

                                var config = KLK();
                                var cooldown = config.GetSetting("Settings", "cd8");
                                var time = DataStore.Get("KLK8", Player.SteamID);

                                if (cooldown > 0) {
                                    var calc = System.Environment.TickCount - time;

                                    if (calc >= cooldown) {
                                        Player.Inventory.AddItem("M4", 1)
                                        Player.Inventory.AddItem("Kevlar Boots", 1)
                                        Player.Inventory.AddItem("Kevlar Helmet", 1)
                                        Player.Inventory.AddItem("Kevlar Pants", 1)
                                        Player.Inventory.AddItem("Kevlar Vest", 1)
                                        Player.Inventory.AddItem("556 Ammo", 100)
                                               Player.MessageFrom("Regalos", "Has recibido una M4 + Full Kevlar");
                                               Server.Broadcast(rojo+"➤ " +azulclaro+ Player.Name +verde + " Ha obtenido el regalo 8 usado" + amarillo + "/regalo 8");
                                        DataStore.Add("KLK8", Player.SteamID, System.Environment.TickCount);
                                        DataStore.Save();
                                    }
                                    else {
                                        if (time == undefined || time == null || calc < 0) {
                                            DataStore.Remove('KLK8', Player.SteamID);
                                            DataStore.Save();
                                        }
                                        var next = calc / 1000;
                                        next = next / 60;
                                        var def = cooldown / 1000;
                                        def = def / 60;
                                        var done = Number(next).toFixed(2);
                                        var done2 = Number(def).toFixed(2);
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000]" + done + "[color#00FFFF]/[color#00FF40]" + done2 + " [color#00FFFF]minutos !")
                                        var tt2 = (done2 - done)
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000] " + tt2 + " [color#00FFFF]Minutos !")
                                    }
                                }
                            }
                        }
                        else {
                            Player.MessageFrom("Regalos", rojo + "No tienes el tiempo suficiente aun rata");
                        }

                        break;
                    case "9":

                        if (Player.TimeOnline >= 25200000) {
                            if (Player.Inventory.FreeSlots <= 1) {

                                Player.MessageFrom("Regalos", "Tu inventario esta lleno necesitas 1 Espacio libre  ");
                            }

                            else {

                                var config = KLK();
                                var cooldown = config.GetSetting("Settings", "cd9");
                                var time = DataStore.Get("KLK9", Player.SteamID);

                                if (cooldown > 0) {
                                    var calc = System.Environment.TickCount - time;
                                    if (calc >= cooldown) {
                                        Player.Inventory.AddItem("Supply Signal", 1)
                                        Player.MessageFrom("Regalos", "Has recibido una Supply Signal");
                                        Server.Broadcast(rojo+"➤ " +azulclaro+ Player.Name +verde + " Ha obtenido el regalo 9 usado" + amarillo + "/regalo 9");
                                        DataStore.Add("KLK9", Player.SteamID, System.Environment.TickCount);
                                        DataStore.Save();
                                    }
                                    else {
                                        if (time == undefined || time == null || calc < 0) {
                                            DataStore.Remove('KLK9', Player.SteamID);
                                            DataStore.Save();
                                        }
                                        var next = calc / 1000;
                                        next = next / 60;
                                        var def = cooldown / 1000;
                                        def = def / 60;
                                        var done = Number(next).toFixed(2);
                                        var done2 = Number(def).toFixed(2);
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000]" + done + "[color#00FFFF]/[color#00FF40]" + done2 + " [color#00FFFF]minutos !")
                                        var tt2 = (done2 - done)
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000] " + tt2 + " [color#00FFFF]Minutos !")
                                    }
                                }
                            }
                        }
                        else {
                            Player.MessageFrom("Regalos", rojo + "No tienes el tiempo suficiente aun rata");
                        }

                        break;

                    case "10":

                        if (Player.TimeOnline >= 28800000) {
                            if (Player.Inventory.FreeSlots <= 7) {

                                Player.MessageFrom("Regalos", "Tu inventario esta lleno necesitas 7 Espacio libre  ");
                            }

                            else {

                                var config = KLK();
                                var cooldown = config.GetSetting("Settings", "cd10");
                                var time = DataStore.Get("KLK10", Player.SteamID);

                                if (cooldown > 0) {
                                    var calc = System.Environment.TickCount - time;

                                    if (calc >= cooldown) {
                                        Player.Inventory.AddItem("Weapon Part 1", 1)
                                        Player.Inventory.AddItem("Weapon Part 2", 1)
                                        Player.Inventory.AddItem("Weapon Part 3", 1)
                                        Player.Inventory.AddItem("Weapon Part 4", 1)
                                        Player.Inventory.AddItem("Weapon Part 5", 1)
                                        Player.Inventory.AddItem("Weapon Part 6", 1)
                                        Player.Inventory.AddItem("Weapon Part 7", 1)
                                        Player.MessageFrom("Regalos", "Has recibido todas las Weapon Part");
                                        Server.Broadcast(rojo+"➤ " +azulclaro+ Player.Name +verde + " Ha obtenido el regalo 10 usado" + amarillo + "/regalo 10");
                                        DataStore.Add("KLK10", Player.SteamID, System.Environment.TickCount);
                                        DataStore.Save();
                                    }
                                    else {
                                        if (time == undefined || time == null || calc < 0) {
                                            DataStore.Remove('KLK10', Player.SteamID);
                                            DataStore.Save();
                                        }
                                        var next = calc / 1000;
                                        next = next / 60;
                                        var def = cooldown / 1000;
                                        def = def / 60;
                                        var done = Number(next).toFixed(2);
                                        var done2 = Number(def).toFixed(2);
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000]" + done + "[color#00FFFF]/[color#00FF40]" + done2 + " [color#00FFFF]minutos !")
                                        var tt2 = (done2 - done)
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000] " + tt2 + " [color#00FFFF]Minutos !")
                                    }
                                }
                            }
                        }
                        else {
                            Player.MessageFrom("Regalos", rojo + "No tienes el tiempo suficiente aun rata");
                        }

                        break;
                    case "11":

                        if (Player.TimeOnline >= 32400000) {
                            if (Player.Inventory.FreeSlots <= 15) {

                                Player.MessageFrom("Regalos", "Tu inventario esta lleno necesitas 15 Espacio libre  ");
                            }

                            else {

                                var config = KLK();
                                var cooldown = config.GetSetting("Settings", "cd11");
                                var time = DataStore.Get("KLK11", Player.SteamID);

                                if (cooldown > 0) {
                                    var calc = System.Environment.TickCount - time;

                                    if (calc >= cooldown) {
                                        Player.Inventory.AddItem("M4", 1)
                                        Player.Inventory.AddItem("M4", 1)
                                        Player.Inventory.AddItem("M4", 1)
                                        Player.Inventory.AddItem("M4", 1)
                                        Player.Inventory.AddItem("Kevlar Boots", 2)
                                        Player.Inventory.AddItem("Kevlar Helmet", 2)
                                        Player.Inventory.AddItem("Kevlar Pants", 2)
                                        Player.Inventory.AddItem("Kevlar Vest", 2)
                                        Player.Inventory.AddItem("556 Ammo", 200)
                                        Player.Inventory.AddItem("Supply Signal", 2)
                                        Player.MessageFrom("Regalos", "2 Full Kevlars + 4 M4 con municion y 2 Supplys Signals");
                                        Server.Broadcast(rojo+"➤ " +azulclaro+ Player.Name +verde + " Ha obtenido el regalo 11 usado" + amarillo + "/regalo 11");
                                        DataStore.Add("KLK11", Player.SteamID, System.Environment.TickCount);
                                        DataStore.Save();
                                    }
                                    else {
                                        if (time == undefined || time == null || calc < 0) {
                                            DataStore.Remove('KLK11', Player.SteamID);
                                            DataStore.Save();
                                        }
                                        var next = calc / 1000;
                                        next = next / 60;
                                        var def = cooldown / 1000;
                                        def = def / 60;
                                        var done = Number(next).toFixed(2);
                                        var done2 = Number(def).toFixed(2);
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000]" + done + "[color#00FFFF]/[color#00FF40]" + done2 + " [color#00FFFF]minutos !")
                                        var tt2 = (done2 - done)
                                        Player.MessageFrom("Regalos", "[color#00FFFF]Podras de nuevo en [color#FF8000] " + tt2 + " [color#00FFFF]Minutos !")
                                    }
                                }
                            }
                        }
                        else {
                            Player.MessageFrom("Regalos", rojo + "No tienes el tiempo suficiente aun rata");
                        }

                        break;
                    default:
                        Player.MessageFrom("Regalos",rojo + "Comando invalido");
                        break;
                }
                break;

            default:
                Player.MessageFrom("Regalos",rojo + "Comando invalido");
                break;
        }
    }
}