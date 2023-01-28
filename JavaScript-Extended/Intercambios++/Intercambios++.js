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

function On_Command (Player, cmd, args) {
    cmd = Data.ToLower(cmd);
    if (cmd == "it" || cmd == "wp") {
        var k = "IntercambiosK";
        switch (args.Length) {
            case 0:
                Player.MessageFrom(k, blanco+"usa " + verde + "/it 1"+blanco+" y intercambiaras" + azulclaro + " Weapon Part 1"+blanco+" por una"+ rojo+" P250 ");
                Player.MessageFrom(k, blanco+"usa " + verde + "/it 2"+blanco+" y intercambiaras " + azulclaro + "Weapon Part 2"+blanco+" por una"+ rojo+" Shotgun ");
                Player.MessageFrom(k, blanco+"usa " + verde + "/it 3"+blanco+" y intercambiaras " + azulclaro + "Weapon Part 3"+blanco+" por una"+ rojo+" Pistola 9mm ");
                Player.MessageFrom(k, blanco+"usa " + verde + "/it 4"+blanco+" y intercambiaras " + azulclaro + "Weapon Part 4"+blanco+" por una"+ rojo+" MP5 ");
                Player.MessageFrom(k, blanco+"usa " + verde + "/it 5"+blanco+" y intercambiaras " + azulclaro + "Weapon Part 5"+blanco+" por una"+ rojo+" M4 ");
                Player.MessageFrom(k, blanco+"usa " + verde + "/it 6"+blanco+" y intercambiaras " + azulclaro + "Weapon Part 6"+blanco+" por una"+ rojo+" Bolt ");
                Player.MessageFrom(k, blanco+"usa " + verde + "/it 7"+blanco+" y intercambiaras " + azulclaro + "Weapon Part 7"+blanco+" por un"+ rojo+" C4 ");
                Player.MessageFrom(k, blanco+"usa " + verde + "/it 8"+blanco+" y intercambiaras llevando todas las " + azulclaro + "Weapon Part"+blanco+" por"+ rojo+" 6 C4 y su BP ");
                break;

                case 1:
                    switch(args[0]) {
                        case "1":
                            if (Player.Inventory.FreeSlots <= 1)
                            {
                                Player.MessageFrom(k, rosa + "Tu inventario esta lleno necesitas" + amarillo + " 1 Espacio libre");
                            }
                            else {
                                if (Player.Inventory.HasItem("Weapon Part 1",1))
                                {
                                    Player.Inventory.RemoveItem("Weapon Part 1",1);
                                    Player.Inventory.AddItemTo("P250", 1);
                                    Player.MessageFrom(k, naranja +Player.Name +" [color#00FFFF]Has recibido en el intercambio una "+ azulclaro +" P250");
                                }
                                else {
                                    Player.MessageFrom(k, rojo +"No tienes en tu inventario "+ naranja + " Weapon Part 1"  );
                             }
                         }
                            break;
    
                        case "2":
                            if (Player.Inventory.FreeSlots <= 1)
                            {
                                Player.MessageFrom(k, rosa + "Tu inventario esta lleno necesitas" + amarillo + " 1 Espacio libre");
                            }
                            else {
                                if (Player.Inventory.HasItem("Weapon Part 2",1))
                                {
                                    Player.Inventory.RemoveItem("Weapon Part 2",1);
                                    Player.Inventory.AddItemTo("Shotgun", 1);
                                    Player.MessageFrom(k, naranja +Player.Name +" [color#00FFFF]Has recibido en el intercambio una "+ azulclaro +" Shotgun");
                                }
                                else {
                                    Player.MessageFrom(k, rojo +"No tienes en tu inventario "+ naranja + " Weapon Part 2"  );
                             }
                         }
                            break;
    
                        case "3":
                            if (Player.Inventory.FreeSlots <= 1)
                            {
                                Player.MessageFrom(k, rosa + "Tu inventario esta lleno necesitas" + amarillo + " 1 Espacio libre");
                            }
                            else {
                                if (Player.Inventory.HasItem("Weapon Part 3",1))
                                {
                                    Player.Inventory.RemoveItem("Weapon Part 3",1);
                                    Player.Inventory.AddItemTo("9mm Pistol", 1);
                                    Player.MessageFrom(k, naranja +Player.Name +" [color#00FFFF]Has recibido en el intercambio una "+ azulclaro +" 9mm Pistol");
                                }
                                else {
                                    Player.MessageFrom(k, rojo +"No tienes en tu inventario "+ naranja + " Weapon Part 3"  );
                             }
                         }
                            break;

                            case "4":
                                if (Player.Inventory.FreeSlots <= 1)
                                {
                                    Player.MessageFrom(k, rosa + "Tu inventario esta lleno necesitas" + amarillo + " 1 Espacio libre");
                                }
                                else {
                                    if (Player.Inventory.HasItem("Weapon Part 4",1))
                                    {
                                        Player.Inventory.RemoveItem("Weapon Part 4",1);
                                        Player.Inventory.AddItemTo("MP5A4", 1);
                                        Player.MessageFrom(k, naranja +Player.Name +" [color#00FFFF]Has recibido en el intercambio una "+ azulclaro +" MP5A4");
                                    }
                                    else {
                                        Player.MessageFrom(k, rojo +"No tienes en tu inventario "+ naranja + " Weapon Part 4"  );
                                 }
                             }
                                break;

                                case "5":
                                    if (Player.Inventory.FreeSlots <= 1)
                                    {
                                        Player.MessageFrom(k, rosa + "Tu inventario esta lleno necesitas" + amarillo + " 1 Espacio libre");
                                    }
                                    else {
                                        if (Player.Inventory.HasItem("Weapon Part 5",1))
                                        {
                                            Player.Inventory.RemoveItem("Weapon Part 5",1);
                                            Player.Inventory.AddItemTo("M4", 1);
                                            Player.MessageFrom(k, naranja +Player.Name +" [color#00FFFF]Has recibido en el intercambio una "+ azulclaro +" M4");
                                        }
                                        else {
                                            Player.MessageFrom(k, rojo +"No tienes en tu inventario "+ naranja + " Weapon Part 5"  );
                                     }
                                 }
                                    break;

                                    case "6":
                                        if (Player.Inventory.FreeSlots <= 1)
                                        {
                                            Player.MessageFrom(k, rosa + "Tu inventario esta lleno necesitas" + amarillo + " 1 Espacio libre");
                                        }
                                        else {
                                            if (Player.Inventory.HasItem("Weapon Part 6",1))
                                            {
                                                Player.Inventory.RemoveItem("Weapon Part 6",1);
                                                Player.Inventory.AddItemTo("Bolt Action Rifle", 1);
                                                Player.MessageFrom(k, naranja +Player.Name +" [color#00FFFF]Has recibido en el intercambio una "+ azulclaro +" Bolt Action Rifle");
                                            }
                                            else {
                                                Player.MessageFrom(k, rojo +"No tienes en tu inventario "+ naranja + " Weapon Part 6"  );
                                         }
                                     }

                                     case "7":
                                        if (Player.Inventory.FreeSlots <= 1)
                                        {
                                            Player.MessageFrom(k, rosa + "Tu inventario esta lleno necesitas" + amarillo + " 1 Espacio libre");
                                        }
                                        else {
                                            if (Player.Inventory.HasItem("Weapon Part 7",1))
                                            {
                                                Player.Inventory.RemoveItem("Weapon Part 7",1);
                                                Player.Inventory.AddItemTo("Explosive Charge", 1);
                                                Player.MessageFrom(k, naranja +Player.Name +" [color#00FFFF]Has recibido en el intercambio una "+ azulclaro +" Explosive Charge");
                                            }
                                            else {
                                                Player.MessageFrom(k, rojo +"No tienes en tu inventario "+ naranja + " Weapon Part 7"  );
                                         }
                                     }
                                        break;
                                        case "8":
                                            if (Player.Inventory.FreeSlots <= 3)
                                            {
                                                Player.MessageFrom(k, rosa + "Tu inventario esta lleno necesitas" + amarillo + " 1 Espacio libre");
                                            }
                                            else {
                                                if (Player.Inventory.HasItem("Weapon Part 7",1) && Player.Inventory.HasItem("Weapon Part 6",1) && Player.Inventory.HasItem("Weapon Part 5",1) && Player.Inventory.HasItem("Weapon Part 4",1) && Player.Inventory.HasItem("Weapon Part 3",1) && Player.Inventory.HasItem("Weapon Part 2",1) && Player.Inventory.HasItem("Weapon Part 1",1))
                                                {
                                                    Player.Inventory.RemoveItem("Weapon Part 1",1);
                                                    Player.Inventory.RemoveItem("Weapon Part 2",1);
                                                    Player.Inventory.RemoveItem("Weapon Part 3",1);
                                                    Player.Inventory.RemoveItem("Weapon Part 4",1);
                                                    Player.Inventory.RemoveItem("Weapon Part 5",1);
                                                    Player.Inventory.RemoveItem("Weapon Part 6",1);
                                                    Player.Inventory.RemoveItem("Weapon Part 7",1);

                                                    Player.Inventory.AddItem("Explosive Charge Blueprint", 1);
                                                    Player.Inventory.AddItem("Explosive Charge", 6);
                                                    Player.MessageFrom(k, naranja +Player.Name +" [color#00FFFF]Has recibido en el intercambio una "+ azulclaro +" Explosive Charge Blueprint");
                                                    Player.MessageFrom(k, naranja +Player.Name +" [color#00FFFF]Has recibido en el intercambio 5 "+ azulclaro + " Explosive Charge");                                                }
                                                else {
                                                    Player.MessageFrom(k, rojo +"No tienes en tu inventario "+ naranja + " Todas las Weapon Part "  );
                                             }
                                         }
                                            break;
    
                        default:
                            Player.MessageFrom(k, "Comando invalido");
                            break;
                    }
                    break;
    
                default:
                    Player.MessageFrom(k, "Comando invalido");
                    break;
            }
        }
    }



    function RemovePlayerItem(Player , nombre, cantidad)
    {
        var count = 1;
        for (var item in Player.Inventory.Items)
        {
            if (item.Name == nombre)
            {
                if (count < cantidad)
                {
                    Player.Inventory.RemoveItem(item);
                    count++;
                }
                else
                {
                    break;
                }
            }
        }
    }

