/*
Sistema de Reporte en JS
By KichDM
Para NovaLand Zero
*/


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
    var targetPlayer = null,
        targetName = null;
    switch (cmd) {
        case "report":
            targetName = ConcatName(args);
            if (!isEmptyString(targetName)) {
                targetPlayer = Player.Find(GetProperName(targetName));
                if (targetPlayer === null) {
                    Player.Message( rojo + "Player " + amarillo + targetName + rojo + " Jugador no encontrado.");
                } else {
                    if (args.Length == 1) {
                        Player.Message( verde + "Pon el " + rojo + "motivo" + verde + " de por que quieres reportar!");
                        Player.Message( amarillo + "Ex: /report nombre motivo");

                    }

                    else {
                        //var mensagem = StringArray(args[1]);
                        var tt = args[1].toString()
                        
                        Player.Message(amarillo + "Has reportado a  " + rojo +  targetPlayer.Name + amarillo + " por el motivo " + naranja + tt);
                        
                        Util.SendMessageToDiscordEmbed(
                            "https://discord.com/api/webhooks/981636194561581176/98p1L0IMLK_IBtOumqSAR9kTgh7lVkqEJefu1F39CJYI3hc6LJ6c3-HxnXumHCuMhdwx",
                            "REPORTE!",
                            "\n El jugador:\n" +
                            "**" + Player.Name + "  |  " + Player.SteamID + "  |  " + Player.IP + "**" +
                            " \n\n Reporto a :\n" +
                            "**" + targetName + "  |  " + targetPlayer.SteamID + "  |  " + targetPlayer.IP + "**" +
                            " \n\n Motivo \n" +
                            "**" + tt + "**");
                            Player.Message(azulclaro + "Tu reporte a sido enviado al discord de los administradores con exito!");
                    }
                }
            }
            break;
    }
}



function ConcatName(args) {
    var name = args[0];
    for (var i = 1; i < args[0]; i++)
        name += " " + args[i];
    return name;
}

function GetProperName(name) {
    var players = Server.Players, lowerCaseName = null;
    lowerCaseName = Data.ToLower(name);
    for (var i = 0; i < players.Count; i++) {
        if (lowerCaseName == Data.ToLower(players[i].Name)) {
            return players[i].Name;
        }
    }
    return null;
}
function isNull(theValue) {
    return (theValue === null);
}
function isUndefined(theValue) {
    return (typeof theValue === "undefined");
}
function isNullOrUndefined(theValue) {
    return isNull(theValue) || isUndefined(theValue);
}
function isEmptyString(theValue) {
    if (isNullOrUndefined(theValue)) {
        return true;
    } else if (theValue.length === 0) {
        return true;
    } else {
        return false;
    }
}