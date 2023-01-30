
//* By KichDM
//*TODO Para NovaLand Zero

//Cuando Aparece en el server recien conectado
function On_PlayerSpawned(Player){
	// esto lo hize para que cada vez que entre el usuario al server no le sume a cada rato los items y se le multipliquen  
	if (Player.Inventory.HasItem("Large Medkit") && Player.Inventory.HasItem("Cooked Chicken Breast"))
	{
		// epico , eso es si tiene esas cosas no de nada :>
	}
	else {
		//Facil Autocarga de equipacion en correa 1º el nombre del item una string , 2 el hueco donde ira un int y el 3 la cantidad en int 
		Player.Inventory.AddItemTo("Large Medkit", 30, 5);
		Player.Inventory.AddItemTo("Cooked Chicken Breast", 31, 250);
	}
}
// Cuando hace Spawn o Respawn
function On_PlayerSpawning(Player){
	// esto lo hize para que cada vez que entre el usuario al server no le sume a cada rato los items y se le multipliquen  
	if (Player.Inventory.HasItem("Large Medkit") && Player.Inventory.HasItem("Cooked Chicken Breast"))
	{
		// epico , eso es si tiene esas cosas no de nada :>
	}
	else {
		//Facil Autocarga de equipacion en correa 1º el nombre del item una string , 2 el hueco donde ira un int y el 3 la cantidad en int 
		Player.Inventory.AddItemTo("Large Medkit", 30, 5);
		Player.Inventory.AddItemTo("Cooked Chicken Breast", 31, 250);
	}
}




