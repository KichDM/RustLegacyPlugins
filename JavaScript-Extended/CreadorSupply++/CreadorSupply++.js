//* By KichDM
//*TODO Para NovaLand Zero

//*! Colores del pana kich
var negro = "[color#000000]";
var gris = "[color#424242]";
var grisclaro = "[color#D8D8D8]";
var blanco = "[color#FFFFFF]";
var rosa = "[color#F781F3]";
var morado = "[color#6A0888]";
var rojo = "[color#FF0000]";
var azul = "[color#001EFF]";
var verde = "[color#00FF40]";
var azulclaro = "[color#00FFF7]";
var amarillo = "[color#FCFF02]";
var naranja = "[color#CD8C00]";
var marron = "[color#604200]";
var turquesa = "[color#00FFC0]";

function On_Command (Player, cmd, args) {
    cmd = Data.ToLower(cmd);
    if (cmd == "sp") {
        var k = "SupplyK";
        switch (args.Length) {
            case 0:
                Player.MessageFrom(k, blanco+"usa " + verde + "/sp 1"+blanco+" para crear" + azulclaro + " Supply Signal");
                Player.MessageFrom(k, "Necesitas:   200 Paper  , 200 Low Quaily Metal  , Gunpowder 500  , F1 Grenade 1  , Explosives 10");
                Player.MessageFrom(k, "Research Kit 1  , Flare 5  , Low Grade Fuel 150  , Silencer 1");
                break;

                case 1:
                    switch(args[0]) {
                        case "1":
                            if (Player.Inventory.FreeSlots <= 1)
                            {
                                Player.MessageFrom(k, rosa + "Tu inventario esta lleno necesitas" + amarillo + " 1 Espacio libre");
                            }
                            else {
                                if (Player.Inventory.HasItem("Paper",200) && (Player.Inventory.HasItem("Low Quality Metal",200)&& (Player.Inventory.HasItem("Gunpowder",500)&& (Player.Inventory.HasItem("F1 Grenade",1)&& (Player.Inventory.HasItem("Explosives",10)&& (Player.Inventory.HasItem("Research Kit 1",1)&& (Player.Inventory.HasItem("Flare",5)&& (Player.Inventory.HasItem("Low Grade Fuel",150)&& (Player.Inventory.HasItem("Silencer",5))))))))))
                                {
                                    Player.Inventory.RemoveItem("Paper",200);
                                    Player.Inventory.RemoveItem("Low Quality Metal",200);
                                    Player.Inventory.RemoveItem("Gunpowder",500);
                                    Player.Inventory.RemoveItem("F1 Grenade",1);
                                    Player.Inventory.RemoveItem("Explosives",10);
                                    Player.Inventory.RemoveItem("Research Kit 1",1);
                                    Player.Inventory.RemoveItem("Flare",5);
                                    Player.Inventory.RemoveItem("Low Grade Fuel",150);
                                    Player.Inventory.RemoveItem("Silencer",1);

                                    Player.Inventory.AddItemTo("Supply Signal", 1);
                                    Player.MessageFrom(k, naranja +Player.Name +" [color#00FFFF]Has recibido en el intercambio una "+ azulclaro +" Supply Signal");
                                }
                                else {
                                    Player.MessageFrom(k, rojo +"No tienes en tu inventario "+ naranja + " los items necesarios"  );
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