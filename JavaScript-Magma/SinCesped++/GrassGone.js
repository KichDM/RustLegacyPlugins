var Red = "[color#FF0000]"
var Green = "[color#00FF40]"
var damn = "[color#00FFFF]"

function On_Command(Player, cmd, args){
switch(cmd) {
case "grasshelp":
Player.MessageFrom("Grass Gone", damn+" Commands:");
Player.MessageFrom("Grass Gone", Green+" /grasson");
Player.MessageFrom("Grass Gone", Red+" /grassoff");
break;

case "grass on":
Player.SendCommand("grass.on true");
Player.MessageFrom("Grass Gone", Green+" Grass is now on!");
break;

case "grass off":
Player.SendCommand("grass.on false");
Player.MessageFrom("Grass Gone", Red+" Grass is now off!");
break;
}
}

function On_PlayerConnected(Player) {
Player.SendCommand("grass.on False");
}