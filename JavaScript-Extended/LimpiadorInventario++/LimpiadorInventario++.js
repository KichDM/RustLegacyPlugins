//* By KichDM
//*TODO Para NovaLand Zero

//*! Colores del pana kich
var rosa = "[color #F781F3]";
var rojo = "[color #FF0000]";
var amarillo = "[color #FCFF02]";

function On_Command (Player, cmd, args) {
    cmd = Data.ToLower(cmd);
    if (cmd == "limpiar") {
        var k = "Novaland Limpiador";
        switch (args.Length) {
            case 0:
                if (Player.Inventory.FreeSlots <= 35)
                {
                    Player.MessageFrom(k, rojo + "Invetario Limpiado.")
                    Player.Inventory.Clear();
                    

                }
                else {
                    Player.MessageFrom(k, rosa + "Tu inventario esta vacio necesitas" + amarillo + " 1 Item para limpiar down");
                }
                break;

                case 1:
                    switch(args[0] == "todo") {
                        case "1":
                            Player.MessageFrom(k, rojo + "Invetario Completo Limpiado.")
                            Player.Inventory.ClearAll();
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