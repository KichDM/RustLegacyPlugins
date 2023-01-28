//* By KichDM
//*TODO Para NovaLand Zero

var Red = "[color #FF0000]";
var Green = "[color #00FF40]";
var damn = "[color #00FFFF]";

function On_Command(Player, cmd, args){
switch(cmd) {
case "cesped":
Player.MessageFrom("NovaLand Boost", damn+" Commands:");
Player.MessageFrom("NovaLand Boost", Green+" /cson poner cesped");
Player.MessageFrom("NovaLand Boost", Red+" /csoff quitar cesped");
break;

case "cson":
Player.SendCommand("grass.on true");
Player.MessageFrom("NovaLand Boost", Green+" Su cesped fue aplicado!");
break;

case "cssoff":
Player.SendCommand("grass.on false");
Player.MessageFrom("NovaLand Boost", Red+" Su cesped fue removido!");
break;
}
}

function On_PlayerConnected(Player) {
Player.SendCommand("grass.on False");
}