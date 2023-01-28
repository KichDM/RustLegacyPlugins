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



function On_Command(Player, cmd, args) {
    if (cmd == "loc" || cmd == "pos") {
        
var KLK = "Novaland Zero";
        var a = Util.FindLocationName(Player.Location);
        Player.MessageFrom(KLK, verde + "Tu posicion es en " +  amarillo + Player.Location +  verde +" esta en " + azulclaro + a);
    }
}