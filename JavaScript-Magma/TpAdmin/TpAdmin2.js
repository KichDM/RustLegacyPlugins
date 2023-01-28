/*
@title Tp Admin
@author Mastah
@date 14/03/2014
@version: 1.0.1
@small edit by ggblade
*/

function On_Command(Player, cmd, args) {
	
	// The target player
	var targetPlayer = null,
	
	// The target name
	targetName = null,
	
	// Distance at which we will teleport from target (stored in cfg file)
	distance = null,
	
	// Vector 3D corresponding to the "inback" position from target
	vector3d = null,
	
	// Y coordinate from ground at TP location
	newYLocation = null;

	switch(cmd) {
	
		case "tpadmin":
		
			// Retrive distance value and set a default value if not exist
			distance = Data.GetConfigValue("TpAdmin", "Settings", "distance") || 20;
	
			// Only if player is admin or in the steam UIDs
			if(Player.Admin || Player.SteamID == "PLAYERUID" || Player.SteamID == "PLAYERUID") {
				
				// Set the name
				targetName = ConcatName(args);
				
				// Check for the arg name
				if(!isEmptyString(targetName)) {
				
					// Retrieve player target
					targetPlayer = Player.Find(GetProperName(targetName));
					
					// Inform that the player couldn't be found in case of not found
					if (targetPlayer === null) {
						Player.Message("Player " + targetName + " couldn't be found.");
					} else {
					
						// Logging purpose
						Player.Message("Teleporting you to " + targetPlayer.Name + ".");
						
						// Retrieve the "inback" coordinate from target
						vector3d = Util.Infront(targetPlayer, distance * -1);
						
						// Retrieve the proper Y coordinate to make you land on ground
						newYLocation = World.GetGround(vector3d.x, vector3d.z);
						
						// Teleporting you to destination
						Player.TeleportTo(vector3d.x, newYLocation, vector3d.z);
						
					}
					
				} else {
					Player.Message("Player name is empty. The arguments need to be the player name.");
				}
				
			} else {
				Player.Message("You are not allowed.");
			}
			break;
		
	}
	
}




// Tools
function ConcatName(args){
	var name = args[0];
	for(var i=1; i < args.Length; i++)
		name += " " + args[i];
	return name;
}
function GetProperName(name){
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
