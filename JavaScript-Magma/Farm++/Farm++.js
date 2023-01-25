//! Multiplicador de Gather por Jugadores ON
//* By KichDM
//*TODO Para NovaLand Zero

var Jugadores = Server.Players.Count;	
var negro = "[color#000000]"
var gris = "[color#424242]"
var grisclaro = "[color#D8D8D8]"
var blanco = "[color#FFFFFF]"
var rosa = "[color#F781F3]"
var morado = "[color#6A0888]"
var rojo = "[color#FF0000]"
var azul = "[color#001EFF]"
var verde = "[color#00FF40]"
var azulclaro = "[color#00FFF7]"
var amarillo = "[color#FCFF02]"
var naranja = "[color#CD8C00]"
var marron = "[color#604200]"
var turquesa = "[color#00FFC0]"

//El Sistema de Farm++ Aqui abajo esta las config que cambia el gather o los jugadores necesarios 

function On_PlayerGathering (Player, GatherEvent)
{

if (Jugadores >= 1 && Jugadores <= 19 )
{
	var MULTIPLICADOR = (GatherEvent.Quantity*(2));
	MULTIPLICADOR = Math.ceil(MULTIPLICADOR);
	Player.Inventory.AddItem(GatherEvent.Item,MULTIPLICADOR);
	Player.InventoryNotice(MULTIPLICADOR + " x " + GatherEvent.Item);
}

	else if (Jugadores >= 20 && Jugadores <= 39)
	{
		var MULTIPLICADOR = (GatherEvent.Quantity*(3));
		MULTIPLICADOR = Math.ceil(MULTIPLICADOR);
		Player.Inventory.AddItem(GatherEvent.Item,MULTIPLICADOR);
		Player.InventoryNotice(MULTIPLICADOR + " x " + GatherEvent.Item);
	}

	else if (Jugadores >= 40 && Jugadores <= 59)
	{
		var MULTIPLICADOR = (GatherEvent.Quantity*(4));
		MULTIPLICADOR = Math.ceil(MULTIPLICADOR);
		Player.Inventory.AddItem(GatherEvent.Item,MULTIPLICADOR);
		Player.InventoryNotice(MULTIPLICADOR + " x " + GatherEvent.Item);
	}

	else if (Jugadores >= 60 && Jugadores <= 79)
	{
		var MULTIPLICADOR = (GatherEvent.Quantity*(5));
		MULTIPLICADOR = Math.ceil(MULTIPLICADOR);
		Player.Inventory.AddItem(GatherEvent.Item,MULTIPLICADOR);
		Player.InventoryNotice(MULTIPLICADOR + " x " + GatherEvent.Item);
	}

	else if (Jugadores >= 80 && Jugadores <= 99)
	{
		var MULTIPLICADOR = (GatherEvent.Quantity*(6));
		MULTIPLICADOR = Math.ceil(MULTIPLICADOR);
		Player.Inventory.AddItem(GatherEvent.Item,MULTIPLICADOR);
		Player.InventoryNotice(MULTIPLICADOR + " x " + GatherEvent.Item);
	}
	
	else if (Jugadores >= 100 && Jugadores <= 119) 
	{
		var MULTIPLICADOR = (GatherEvent.Quantity*(7));
		MULTIPLICADOR = Math.ceil(MULTIPLICADOR);
		Player.Inventory.AddItem(GatherEvent.Item,MULTIPLICADOR);
		Player.InventoryNotice(MULTIPLICADOR + " x " + GatherEvent.Item);
	}
	
	else if (Jugadores >= 120 ) 
	{
		var MULTIPLICADOR = (GatherEvent.Quantity*(8));
		MULTIPLICADOR = Math.ceil(MULTIPLICADOR);
		Player.Inventory.AddItem(GatherEvent.Item,MULTIPLICADOR);
		Player.InventoryNotice(MULTIPLICADOR + " x " + GatherEvent.Item);
	}
}

//envia mensajes cuando un jugador se desconecta o entra asi para saber cuando el gather ha subido o ha bajado :>

function ComprobarPlayers()
{

if (Jugadores == 1 )
{
	Server.BroadcastFrom("Novaland Farm", blue + "Se ha activado el Gather++  " + yellow + "x 2 " +blue + "Players Online"+ "[  "+Jugadores+"  ]");
}


if (Jugadores == 19 )
{
	Server.BroadcastFrom("Novaland Farm", blue + "Se ha activado el Gather++  " + yellow + "x 2 " +blue + "Players Online"+ "[  "+Jugadores+"  ]");
}

	if (Jugadores == 20 ) 
	{
		Server.BroadcastFrom("Novaland Farm", blue + "Se ha activado el Gather++  " + yellow + "x 3 " +blue + "Players Online"+ "[  "+Jugadores+"  ]");
	}

	if (Jugadores == 39 ) 
	{
		Server.BroadcastFrom("Novaland Farm", blue + "Se ha activado el Gather++  " + yellow + "x 3 " +blue + "Players Online"+ "[  "+Jugadores+"  ]");
	}
	if (Jugadores == 40 ) 
	{
		Server.BroadcastFrom("Novaland Farm", blue + "Se ha activado el Gather++  " + yellow + "x 4 " +blue + "Players Online"+ "[  "+Jugadores+"  ]");
	}
	if (Jugadores == 59 ) 
	{
		Server.BroadcastFrom("Novaland Farm", blue + "Se ha activado el Gather++  " + yellow + "x 4 " +blue + "Players Online"+ "[  "+Jugadores+"  ]");
	}
	if (Jugadores == 60 ) 
	{
		Server.BroadcastFrom("Novaland Farm", blue + "Se ha activado el Gather++  " + yellow + "x 5 " +blue + "Players Online"+ "[  "+Jugadores+"  ]");
	}

	if (Jugadores == 79 ) 
	{
		Server.BroadcastFrom("Novaland Farm", blue + "Se ha activado el Gather++  " + yellow + "x 5 " +blue + "Players Online"+ "[  "+Jugadores+"  ]");
	}

	if (Jugadores == 80 ) 
	{
		Server.BroadcastFrom("Novaland Farm", blue + "Se ha activado el Gather++  " + yellow + "x 6 " +blue + "Players Online"+ "[  "+Jugadores+"  ]");
	}
	
	if (Jugadores == 99 ) 
	{
		Server.BroadcastFrom("Novaland Farm", blue + "Se ha activado el Gather++ " + yellow + "x 6 " +blue + "Players Online"+ "[  "+Jugadores+"  ]");
	}

	if (Jugadores == 100 ) 
	{
		Server.BroadcastFrom("Novaland Farm", blue + "Se ha activado el Gather++ " + yellow + "x 7 " +blue + "Players Online"+ "[  "+Jugadores+"  ]");
	}

	if (Jugadores == 119 ) 
	{
		Server.BroadcastFrom("Novaland Farm", blue + "Se ha activado el Gather++  " + yellow + "x 7 " +blue + "Players Online"+ "[  "+Jugadores+"  ]");
	}

	if (Jugadores == 120 ) 
	{
		Server.BroadcastFrom("Novaland Farm", blue + "Se ha activado el Gather++  " + yellow + "x 8 " +blue + "Players Online"+ "[  "+Jugadores+"  ]");
	}
	return;
}





//Comprobante para la funciones de arriba asi cuando un jugador entra o sale y cumple lo requisitos de arriba envia los mensajes :>

function On_PlayerConnected(Player){

 ComprobarPlayers();
 return;

}

function On_PlayerDisconnected(Player)
{
	ComprobarPlayers();
	return;
}

function On_Command(Player, cmd, args) {
	var Jugadores = Server.Players.Count;
    cmd = Data.ToLower(cmd);
	if (cmd == "farm" || cmd == "gather") {
	
		if (Jugadores >= 1 && Jugadores <= 19)
{
	Player.MessageFrom("Novaland Farm", verde + "El Gather++ esta " + yellow + " x 2 " +verde + "Players Online"+ verde +"[  "+ blue+ Jugadores+ verde +"  ]");
}


if (Jugadores >= 20 && Jugadores <= 40)
{
	Player.MessageFrom("Novaland Farm", verde + "El Gather++ esta " + yellow + " x 3 "+verde + "Players Online"+ verde +"[  "+ blue+ Jugadores+ verde +"  ]");
}

if (Jugadores >= 40 && Jugadores <= 60)
{
	Player.MessageFrom("Novaland Farm", verde + "El Gather++ esta " + yellow + " x 4 " +verde + "Players Online"+ verde +"[  "+ blue+ Jugadores+ verde +"  ]");
}

if (Jugadores >= 60 && Jugadores <= 80)
{
	Player.MessageFrom("Novaland Farm", verde + "El Gather++ esta " + yellow + " x 5 " +verde + "Players Online"+ verde +"[  "+ blue+ Jugadores+ verde +"  ]");
}

if (Jugadores >= 80 && Jugadores <= 100)
{
	Player.MessageFrom("Novaland Farm", verde + "El Gather++ esta " + yellow + " x 6 " +verde + "Players Online"+ verde +"[  "+ blue+ Jugadores+ verde +"  ]");
}

if (Jugadores >= 100 && Jugadores <= 120)
{
	Player.MessageFrom("Novaland Farm", verde + "El Gather++ esta " + yellow + " x 7 " +verde + "Players Online"+ verde +"[  "+ blue+ Jugadores+ verde +"  ]");
}

if (Jugadores >= 120)
{
	Player.MessageFrom("Novaland Farm", verde + "El Gather++ esta " + yellow + " x 8 " +verde + "Players Online"+ verde +"[  "+ blue+ Jugadores+ verde +"  ]");
   }
 }
 if (cmd == "farm" && args[0] == "info") {

	  Player.MessageFrom("Novaland Farm", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
	  if (Jugadores >= 1 && Jugadores <= 5)
{
	Player.MessageFrom("Novaland Farm", azulclaro + "➤ " + verde + "[ON] "+ "Jugadores menos de 5 " + yellow + " x 2 " +verde + "de Farm");
}
else {
	Player.MessageFrom("Novaland Farm", rojo + "➤ " + grisclaro + "[OFF] "+ "Jugadores menos de 5 " + yellow + " x 2 " +verde + "de Farm");
}
if (Jugadores >= 20 && Jugadores <= 40)
{
	Player.MessageFrom("Novaland Farm",azulclaro + "➤ " + verde + "[ON] "+ "Jugadores mas de 20 " + yellow + " x 3 " +verde + "de Farm");
}
else{
	Player.MessageFrom("Novaland Farm", rojo + "➤ " + grisclaro + "[OFF] "+ "Jugadores mas de 20 " + yellow + " x 3 " +verde + "de Farm");
}
if (Jugadores >= 40 && Jugadores <= 60)
{
	Player.MessageFrom("Novaland Farm", azulclaro + "➤ " + verde + "[ON] "+"Jugadores mas de 40 " + yellow + " x 4 " +verde + "de Farm");
}
else {
	Player.MessageFrom("Novaland Farm", rojo + "➤ " + grisclaro + "[OFF] "+"Jugadores mas de 40 " + yellow + " x 4 " +verde + "de Farm");
}
if (Jugadores >= 60 && Jugadores <= 80)
{
	Player.MessageFrom("Novaland Farm", azulclaro + "➤ " + verde + "[ON] "+"Jugadores mas de 60 " + yellow + " x 5 " +verde + "de Farm");
}
	else {
		Player.MessageFrom("Novaland Farm", rojo + "➤ " + grisclaro + "[OFF] "+"Jugadores mas de 60 " + yellow + " x 5 " +verde + "de Farm");
	}

	if (Jugadores >= 80 && Jugadores <= 100)
{
	Player.MessageFrom("Novaland Farm", azulclaro + "➤ " + verde + "[ON] "+"Jugadores mas de 80 " + yellow + " x 6 " +verde + "de Farm");
}
else {
	Player.MessageFrom("Novaland Farm", rojo + "➤ " + grisclaro + "[OFF] "+"Jugadores mas de 80 " + yellow + " x 6 " +verde + "de Farm");
}
if (Jugadores >= 100 && Jugadores <= 120)
{
	Player.MessageFrom("Novaland Farm", azulclaro + "➤ " + verde + "[ON] "+"Jugadores mas de 100 " + yellow + " x 7 " +verde + "de Farm");
	}
	else {
		Player.MessageFrom("Novaland Farm", rojo + "➤ " + grisclaro + "[OFF] "+"Jugadores mas de 100 " + yellow + " x 7 " +verde + "de Farm");
	}
	if (Jugadores >= 120)
{
	Player.MessageFrom("Novaland Farm", azulclaro + "➤ " + verde + "[ON] "+"Jugadores mas de 120 " + yellow + " x 8 " +verde + "de Farm");
}
else {
	Player.MessageFrom("Novaland Farm", rojo + "➤ " + grisclaro + "[OFF] "+"Jugadores mas de 120 " + yellow + " x 8 " +verde + "de Farm");
}
	
	Player.MessageFrom("Novaland Farm", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
}
return;
}

