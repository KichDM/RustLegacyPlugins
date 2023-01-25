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

function On_AirdropPayLoad(string)
{
    for (var pl in Server.Players){
        var pos = Util.ConvertStringToVector3(string);
var Dist = Util.GetVectorsDistance(pl.Location, pos);
var zona = Util.FindLocationName(pos);
pl.MessageFrom("[Airdrops]", "El " + verde + "Airdrop" + blanco +" ha caido en " + naranja +zona + blanco +  " a " + amarillo + Dist.toFixed(0) + blanco + " Metros de ti");


    }
    var pos = Util.ConvertStringToVector3(string);
    var zona = Util.FindLocationName(pos);
    Util.Log("~~~~~~~~~~~~~~~~~~~~~Airdrop~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    Util.Log("El Airdrop ha caido en "  + zona);
    Util.Log("Player Totales "  + Server.Players.Count + " Cuando ha caido el drop");
    Util.Log("~~~~~~~~~~~~~~~~~~~~~Airdrop~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    Util.SendMessageToDiscordEmbed("https://discord.com/api/webhooks/955584905713172550/j9twFcpa9gUdgrIVkcNrmoy5NXCfhLnwnZ8L-27cqlxScIfEMIsJToJDLMqWsjW4mxrn","AIRDROP", "Ha caido en " +"***||" +zona + "||***");
}