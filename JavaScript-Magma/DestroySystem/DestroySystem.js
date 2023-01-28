//Fougerite
/**
 * Created by DreTaX on 2014.04.11.. V1.2
 */
function On_Command(Player, cmd, args) {
	if(cmd == "destroy") {
		if (args.Length == 0) {
			Player.Message("Destroy System");
			Player.Message("To activate use the command \"/destroy start\"");
			Player.Message("To deactivate use the command \"/destroy stop\"");
		}
		if (args.Length == 1) {
			if(args[0] == "start") {
				DataStore.Add("DestroySystem", Player.SteamID, "true");
				Player.Message("---DestroySystem---");
				Player.Message("You are in Destroy mode");
				Player.Message("If you finished, don't forget to quit from It!");
			}
			else if(args[0] == "stop") {
				DataStore.Add("DestroySystem", Player.SteamID, "false");
				Player.Message("---DestroySystem---");
				Player.Message("You quit Destroy mode!");
			}
			else {
				Player.Message("Type /destroy for help");
			}
		}
	}
}

function On_EntityHurt(HurtEvent){
	if (HurtEvent.Attacker != null && HurtEvent.Entity != null && !HurtEvent.IsDecay && HurtEvent.Victim.SteamID == null && HurtEvent.Attacker.SteamID) {	
		var get = DataStore.Get("DestroySystem", HurtEvent.Attacker.SteamID);
		if (HurtEvent.Attacker == HurtEvent.Entity.Owner && HurtEvent.Entity != undefined && get == "true") {
			var gun = HurtEvent.WeaponName;
			if (gun == "Hatchet" || gun == "Stone Hatchet" || gun == "Rock" || gun == "Pick Axe" || gun == "HandCannon" || gun == "Pipe Shotgun" || gun == "Revolver" || gun == "9mm Pistol" || gun == "P250" || gun == "Shotgun" || gun == "Bolt Action Rifle" || gun == "M4" || gun == "MP5A4") {
				if (IsEligible(HurtEvent)) {
					var EntityName = HurtEvent.Entity.Name;
					HurtEvent.Entity.Destroy();
					var giveback = Data.GetConfigValue("DestroySystem", "options", "giveback");
					if (giveback == 1) {
						if(EntityName == "WoodFoundation") {
							HurtEvent.Attacker.Inventory.AddItem("Wood Foundation");
						}
						else if(EntityName == "WoodDoorFrame") {
							HurtEvent.Attacker.Inventory.AddItem("Wood Doorway");
						}	
						else if(EntityName == "WoodWall") {
							HurtEvent.Attacker.Inventory.AddItem("Wood Wall");
						}	
						else if(EntityName == "WoodPillar") {
							HurtEvent.Attacker.Inventory.AddItem("Wood Pillar");
						}	
						else if(EntityName == "WoodCeiling") {
							HurtEvent.Attacker.Inventory.AddItem("Wood Ceiling");
						}	
						else if(EntityName == "MetalDoor") {
							HurtEvent.Attacker.Inventory.AddItem("Metal Door");
						}	
						else if(EntityName == "WoodStairs") {
							HurtEvent.Attacker.Inventory.AddItem("Wood Stairs");
						}	
						else if(EntityName == "WoodWindowFrame") {
							HurtEvent.Attacker.Inventory.AddItem("Wood Window");
						}	
						else if(EntityName == "MetalFoundation") {
							HurtEvent.Attacker.Inventory.AddItem("Metal Foundation");
						}	
						else if(EntityName == "MetalDoorFrame") {
							HurtEvent.Attacker.Inventory.AddItem("Metal Doorway");
						}	
						else if(EntityName == "MetalWall") {
							HurtEvent.Attacker.Inventory.AddItem("Metal Wall");
						}	
						else if(EntityName == "MetalPillar") {
							HurtEvent.Attacker.Inventory.AddItem("Metal Pillar");
						}	
						else if(EntityName == "MetalCeiling") {
							HurtEvent.Attacker.Inventory.AddItem("Metal Ceiling");
						}
						else if(EntityName == "MetalStairs") {
							HurtEvent.Attacker.Inventory.AddItem("Metal Stairs");
						}
						else if(EntityName == "MetalWindowFrame") {
							HurtEvent.Attacker.Inventory.AddItem("Metal Window");
						}
						else if(EntityName == "Wood_Shelter") {
							HurtEvent.Attacker.Inventory.AddItem("Wood Shelter");
						}
						else if(EntityName == "Barricade_Fence_Deployable") {
							HurtEvent.Attacker.Inventory.AddItem("Wood Barricade");
						}
						else if(EntityName == "Wood Box") {
							HurtEvent.Attacker.Inventory.AddItem("Wood Storage Box");
						}
                        else if (EntityName == "Wood Box Large") {
                            HurtEvent.Attacker.Inventory.AddItem("Large Wood Storage");
                        }
						else if(EntityName == "Metal Bars Window") {
							HurtEvent.Attacker.Inventory.AddItem("Metal Window Bars");
						}
						else if(EntityName == "CampFire") {
							HurtEvent.Attacker.Inventory.AddItem("Camp Fire");
						}
						else if(EntityName == "Wood Spike Wall") {
							HurtEvent.Attacker.Inventory.AddItem("Spike Wall");
						}
						else if(EntityName == "Large Wood Spike Wall") {
							HurtEvent.Attacker.Inventory.AddItem("Large Spike Wall");
						}
					}
				}
			}
		}
	}
}

/*
 * Original Destroy Mode Method to check if the object is holding something. Credits: Magma authors
 *
*/

function IsEligible(HurtEvent){
    try{
        var Eligible = HurtEvent.Entity.Object._master.ComponentCarryingWeight(HurtEvent.Entity.Object);
        return !Eligible;
    }
    catch(err){
        return true;
    }
}