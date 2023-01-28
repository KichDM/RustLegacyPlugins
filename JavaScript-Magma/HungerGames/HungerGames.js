var sysname = "Hunger Games";//Data.GetConfigValue("HungerGames", "Settings", "sysname");
var version = "V1.0";
//var jobParams = [];
var players = 0;
var isactive = 0;
var isstarted = 0;
var killprot = 1;
var blue = "[color #0099FF]";
var red = "[color #FF0000]";
var pink = "[color #CC66FF]";
var teal = "[color #00FFFF]";
var green = "[color #009900]";
var purple = "[color #6600CC]";
var white = "[color #FFFFFF]";
/*
 * Door Locations, well i didn't want to do a for cycle in one for cycle, and i dont have any better ways atm in mind, suggest please.
 */
var door;
var door2;
var door3;
var door4;
var door5;
var door6;
var door7;
var door8;
var door9;
var door10;
var door11;
var door12;
var door13;
var door14;
function On_Command(Player, cmd, args) {
	if (cmd != "hungergames") {
		if (isactive == 1) {
			var id = Player.SteamID;
			var isin = DataStore.Get("HungerGamesP", id);
			if (isin == 1) {
				Player.MessageFrom(sysname, "You can't do any other commands, while in the event!");
				Player.MessageFrom(sysname, "/hungergames leave - To leave the event.");
				return;
			}
		}
	}
    switch(cmd) {
		case "hungergames":
			if (args.Length == 0) {
				Player.MessageFrom(sysname, green + "Hunger Games By DreTaX! " + blue + version);
				Player.MessageFrom(sysname, "/hungergames join - Join HG");
				Player.MessageFrom(sysname, "/hungergames leave - Leave HG");
				Player.MessageFrom(sysname, "/hungergames info - HG info");
				Player.MessageFrom(sysname, "/hungergames inv - Gives your inventory back, if you didn't get it.");
				return;
			}
			else if (args.Length > 0) {
				var arg = args[0];
				if (arg == "announce") {
					if (Player.Admin) {
						if (isactive == 1) {
							Player.MessageFrom(sysname, "Hunger Games is already active!");
							return;
						}
						Server.BroadcastFrom(sysname, red + "----------------------------HUNGERGAMES--------------------------------");
						Server.BroadcastFrom(sysname, "Hunger Games is now active! Type /hungergames join to enter the battle!");
						Server.BroadcastFrom(sysname, "Type /hungergames info to know more!");
						Server.BroadcastFrom(sysname, red + "----------------------------HUNGERGAMES--------------------------------");
						isactive = 1;
					}
					else {
						Player.Message("You aren't admin!");
					}
				}
				else if (arg == "disable") {
					if (Player.Admin) {
						Server.BroadcastFrom(sysname, red + "----------------------------HUNGERGAMES--------------------------------");
						Server.BroadcastFrom(sysname, "Hunger Games is now inactive.");
						Server.BroadcastFrom(sysname, red + "----------------------------HUNGERGAMES--------------------------------");
						if (isstarted == 1) {
							if (players == 1) {
								var contains = DataStore.ContainsValue("HungerGamesP", 1);
								if (contains) {
									for (var value in DataStore.Keys("HungerGamesP")) {
										var getlast = DataStore.Get("HungerGamesP", value);
										if (getlast == 1) {
											var pl = FindPlayer(value);
											EndGame(pl);
										}
									}
								}
								else {
									Player.MessageFrom(sysname, "Didn't find any players in the list?!");
								}
							}
							else {
								Player.MessageFrom(sysname, "You can't disable it, there are still more players alive than 1");
								return;
							}
						}
						else {
							Reset();
						}
					}
					else {
						Player.Message("You aren't admin!");
						return;
					}
				}
				else if (arg == "info") {
					Player.MessageFrom(sysname, green + "HungerGames By DreTaX " + blue + version);
					Player.MessageFrom(sysname, "You will start in a small house. In the middle of the area");
					Player.MessageFrom(sysname, "there are Boxes on a foundation which contains loot, and you may try to take it.");
					Player.MessageFrom(sysname, "You can also head to the big buildings, which contains loot also.");
					Player.MessageFrom(sysname, "Don't forget to look for hidden stashes, those may contain C4");
					Player.MessageFrom(sysname, "which allows you to blow 1x1 houses, which contain even better loot.");
				}
				else if (arg == "join") {
					//var length = jobParams.length;
					var id = Player.SteamID;
					var name = Player.Name;
					var loc = Player.Location.toString();
					var ini = HungerGames();
					var isin = DataStore.Get("HungerGamesP", id);
					if (isin == 1) {
						Player.MessageFrom(sysname, "You are already in.");
						return;
					}
					if (isstarted == 1) {
						Player.MessageFrom(sysname, "Hunger Games is already running!");
						return;
					}
					if (isactive == 1) {
						if (players < 14) {
							players += 1;
							var getini = ini.GetSetting("StartPos", players);
							var split = SplitLoc(getini);
							var locationc = Util.CreateVector(split[0], split[1], split[2]);
							if (players == 14) {
								recordInventory(Player);
								//jobParams.push(String(name));
								Player.TeleportTo(locationc);
								AddItems(Player);
								DataStore.Add("HungerGamesP", Player.SteamID, 1);
								DataStore.Add("HungerGamesL", Player.SteamID, loc);
								Player.MessageFrom(sysname, green + "You received the items, and got teleported.");
								Player.MessageFrom(sysname, green + "Your Inventory will be given back after you die in the event and respawn");
								Server.BroadcastFrom(sysname, teal + "14 players. Hunger Games will start after 20 seconds.");
								Time.CreateTimer("Start", 20000).Start();
							}
							if (players < 14) {
								Server.BroadcastFrom(sysname, "Players Waiting: " + players + "/14");
								Player.MessageFrom(sysname, "We need 14 Players to start the event.");
								recordInventory(Player);
								//jobParamsjobParams.push(String(name));
								Player.TeleportTo(locationc);
								AddItems(Player);
								DataStore.Add("HungerGamesP", Player.SteamID, 1);
								DataStore.Add("HungerGamesL", Player.SteamID, loc);
								Player.MessageFrom(sysname, green + "You received the items, and got teleported.");
								Player.MessageFrom(sysname, green + "Your Inventory will be given back after you die in the event and respawn");
								//iJSON.stringify(jobParams);
							}
						}
						else {
							Player.MessageFrom(sysname, "Hunger Games is full");
							return;
						}
					} else {
						Player.MessageFrom(sysname, "Hunger Games is inactive!");
						return;
					}
				}
				else if (arg == "leave") {
					var id = Player.SteamID;
					var isin = DataStore.Get("HungerGamesP", id);
					if (isin == 1) {
						var loc = DataStore.Get("HungerGamesL", Player.SteamID);
						var getorigloc = SplitLoc(loc);
						var locationc = Util.CreateVector(getorigloc[0], getorigloc[1], getorigloc[2]);
						Player.TeleportTo(locationc);
						returnInventory(Player);
						DataStore.Add("HungerGamesP", id, 0);
						DataStore.Add("HungerGamesL", id, 0);
						players -= 1;
						Server.BroadcastFrom(sysname, "Players Waiting: " + players + "/14");
						Server.BroadcastFrom(sysname, Player.Name + " left the event.");
						if (players == 1) {
							var contains = DataStore.ContainsValue("HungerGamesP", 1);
							if (contains) {
								for (var value in DataStore.Keys("HungerGamesP")) {
									var getlast = DataStore.Get("HungerGamesP", value);
									if (getlast == 1) {
										var pl = FindPlayer(value);
										EndGame(pl);
									}
								}
							}
						}
					}
					else {
						Player.MessageFrom(sysname, "You aren't in the event!");
						return;
					}
				}
				else if (arg == "inv") {
					var id = Player.SteamID;
					var isin = DataStore.Get("HungerGamesP", id);
					if (isstarted == 1) {
						if (isin == 1) {
							Player.MessageFrom(sysname, "You are still in the event! Can't do that!");
							return;
						}
						else {
							returnInventory(Player);
						}
					}
					else {
						returnInventory(Player);
					}
				}
				else if (arg == "add") {
					if (Player.Admin) {
						var sec = ini.EnumSection("EntityLocs");
						var count = sec.Length;
						if (count <= 14) {
							Player.MessageFrom(sysname, "You are in door adding mode.");
							DataStore.Add("HungAdd", Player.SteamID, "true");
						}
						else {
							Player.MessageFrom(sysname, "There are 14 Door locations inside the ini already.");
							Player.MessageFrom(sysname, "/hungergames wipe - to wipe the door locations only");
						}
					}
					else {
						Player.MessageFrom(sysname, "You arent an admin.");
					}
				}
				else if (arg == "quit") {
					if (Player.Admin) {
						Player.MessageFrom(sysname, "You quit from door adding mode.");
						DataStore.Add("HungAdd", Player.SteamID, "false");
					}
					else {
						Player.MessageFrom(sysname, "You arent an admin.");
					}
				}
				else if (arg == "wipe") {
					if (Player.Admin) {
						var ini = HungerGames();
						ini.DeleteSetting("EntityLocs");
						ini.Save();
						Player.MessageFrom(sysname, "Wiped.");
					}
					else {
						Player.MessageFrom(sysname, "You arent an admin.");
					}
				}
			}
		break;
	}
	
}

function On_EntityHurt(HurtEvent) {
	if (HurtEvent.Attacker != null && HurtEvent.Entity != null && !HurtEvent.IsDecay) {
		var id = HurtEvent.Attacker.SteamID;
		var get = DataStore.Get("HungAdd", id);
		if (get == "true" && get != null) {
			var type = HurtEvent.DamageType;
			var gun = HurtEvent.WeaponName;
			if (gun == "Hatchet" || gun == "Stone Hatchet" || gun == "Rock" || gun == "Pick Axe" || gun == "HandCannon" || gun == "Pipe Shotgun" || gun == "Revolver" || gun == "9mm Pistol" || gun == "P250" || gun == "Shotgun" || gun == "Bolt Action Rifle" || gun == "M4" || gun == "MP5A4") {
				if (HurtEvent.Entity.Name == "MetalDoor") {
					var locx = HurtEvent.Entity.X.toString();
					var locy = HurtEvent.Entity.Y.toString();
					var locz = HurtEvent.Entity.Z.toString();
					var ini = HungerGames();
					var sec = ini.EnumSection("EntityLocs");
					var count = sec.Length;
					count = count + 1;
					ini.AddSetting("EntityLocs", count, "(" + locx + ", " + locy + ", " + locz + ")");
					ini.Save();
					HurtEvent.Attacker.Message("Added!");
				}
                else if (HurtEvent.Entity.Name == "Wood Box") {
                    var locx = HurtEvent.Entity.X.toString();
					var locy = HurtEvent.Entity.Y.toString();
					var locz = HurtEvent.Entity.Z.toString();
					var ini = HungerGames();
					var sec = ini.EnumSection("RandomChests");
					var count = sec.Length;
					count = count + 1;
					ini.AddSetting("RandomChests", count, "(" + locx + ", " + locy + ", " + locz + ")");
					ini.Save();
					HurtEvent.Attacker.Message("Added!");
                }
                else if (HurtEvent.Entity.Name == "Wood Box Large") {
                    var locx = HurtEvent.Entity.X.toString();
					var locy = HurtEvent.Entity.Y.toString();
					var locz = HurtEvent.Entity.Z.toString();
					var ini = HungerGames();
					var sec = ini.EnumSection("RandomChests");
					var count = sec.Length;
					count = count + 1;
					ini.AddSetting("RandomChests", count, "(" + locx + ", " + locy + ", " + locz + ")");
					ini.Save();
					HurtEvent.Attacker.Message("Added!");
                }
			}
		}
	}
}

/*
 * Dont Laugh. Tired & Working on it.
 */
function DestroyDoors() {
	var ini = HungerGames();
	door = SplitLoc(ini.GetSetting("EntityLocs", "1")); 
	door2 = SplitLoc(ini.GetSetting("EntityLocs", "2")); 
	door3 = SplitLoc(ini.GetSetting("EntityLocs", "3")); 
	door4 = SplitLoc(ini.GetSetting("EntityLocs", "4")); 
	door5 = SplitLoc(ini.GetSetting("EntityLocs", "5")); 
	door6 = SplitLoc(ini.GetSetting("EntityLocs", "6")); 
	door7 = SplitLoc(ini.GetSetting("EntityLocs", "7")); 
	door8 = SplitLoc(ini.GetSetting("EntityLocs", "8")); 
	door9 = SplitLoc(ini.GetSetting("EntityLocs", "9")); 
	door10 = SplitLoc(ini.GetSetting("EntityLocs", "10")); 
	door11 = SplitLoc(ini.GetSetting("EntityLocs", "11")); 
	door12 = SplitLoc(ini.GetSetting("EntityLocs", "12")); 
	door13 = SplitLoc(ini.GetSetting("EntityLocs", "13")); 
	door14 = SplitLoc(ini.GetSetting("EntityLocs", "14")); 
	//Fougerite Methods only.
	var entity = Util.GetDooratCoords(door[0], door[1], door[2]);
	var entity2 = Util.GetDooratCoords(door2[0], door2[1], door2[2]);
	var entity3 = Util.GetDooratCoords(door3[0], door3[1], door3[2]);
	var entity4 = Util.GetDooratCoords(door4[0], door4[1], door4[2]);
	var entity5 = Util.GetDooratCoords(door5[0], door5[1], door5[2]);
	var entity6 = Util.GetDooratCoords(door6[0], door6[1], door6[2]);
	var entity7 = Util.GetDooratCoords(door7[0], door7[1], door7[2]);
	var entity8 = Util.GetDooratCoords(door8[0], door8[1], door8[2]);
	var entity9 = Util.GetDooratCoords(door9[0], door9[1], door9[2]);
	var entity10 = Util.GetDooratCoords(door10[0], door10[1], door10[2]);
	var entity11 = Util.GetDooratCoords(door11[0], door11[1], door11[2]);
	var entity12 = Util.GetDooratCoords(door12[0], door12[1], door12[2]);
	var entity13 = Util.GetDooratCoords(door13[0], door13[1], door13[2]);
	var entity14 = Util.GetDooratCoords(door14[0], door14[1], door14[2]);
	if (entity != null && entity2 != null && entity3 != null && entity4 != null && entity5!= null && entity6 != null && entity7 != null && entity8 != null && entity9 != null && entity10 != null && entity11 != null && entity12 != null && entity13 != null && entity14 != null) {
		entity.Destroy();
		entity2.Destroy();
		entity3.Destroy();
		entity4.Destroy();
		entity5.Destroy();
		entity6.Destroy();
		entity7.Destroy();
		entity8.Destroy();
		entity9.Destroy();
		entity10.Destroy();
		entity11.Destroy();
		entity12.Destroy();
		entity13.Destroy();
		entity14.Destroy();
	}
	else {
		Server.BroadcastFrom(sysname, red + "A door doesn't exist, Destroy function stopped. Force Disabling HungerGames");
		Server.BroadcastFrom(sysname, red + "/hungergames leave - To leave the event.");
		Reset();
	}
}

function LaunchEvent() {
	if (isstarted == 0) {
        RandomItems();
		DestroyDoors();
		Time.CreateTimer("Protection", 60000).Start();
		Server.BroadcastFrom(sysname, purple + "Hunger Games Started!");
		Server.BroadcastFrom(sysname, purple + "Kill Protection is on for 1 minute!");
		isstarted = 1;
	}
}

function RandomItems() {
	var ini = HungerGames();
    sec = ini.EnumSection("RandomChests");
    for (number in sec) {
        chest = ini.GetSetting("RandomChests", number);
        inventory = chest.Inventory;
        //Todo finish the random weapons here
    }
}

function On_PlayerDisconnected(Player) {
	var id = Player.SteamID;
	var name = Player.Name;
	var isin = DataStore.Get("HungerGamesP", id);
	if (isin == 1 && isstarted == 1) {
		players -= 1;
		Server.BroadcastFrom(sysname, "Players Waiting: " + players + "/14");
		Server.BroadcastFrom(sysname, name + " left the event.");
		if (players == 1) {
			var contains = DataStore.ContainsValue("HungerGamesP", 1);
			if (contains) {
				for (var value in DataStore.Keys("HungerGamesP")) {
					var getlast = DataStore.Get("HungerGamesP", value);
					if (getlast == 1) {
						var pl = FindPlayer(value);
						EndGame(pl);
					}
				}
			}
		}
	}
}

function On_PlayerConnected(Player) {
	var id = Player.SteamID;
	var isin = DataStore.Get("HungerGamesP", id);
	if (isin == 1) {
		var loc = DataStore.Get("HungerGamesL", id);
		var getorigloc = SplitLoc(loc);
		var locationc = Util.CreateVector(getorigloc[0], getorigloc[1], getorigloc[2]);
		Player.TeleportTo(locationc);
		DataStore.Add("HungerGamesL", id, 0);
		DataStore.Add("HungerGamesP", id, 0);
		returnInventory(Player);
	}
}

function On_PlayerSpawned(Player, SpawnEvent) {
	var id = Player.SteamID;
	var isin = DataStore.Get("HungerGamesP", id);
	var loc = DataStore.Get("HungerGamesL", id);
	if (isin == 1 && isactive == 1 && loc != null) {
		DataStore.Add("HungerGamesP", id, 0);
		DataStore.Add("HungerGamesL", id, 0);
		var getorigloc = SplitLoc(loc);
		SpawnEvent.X = getorigloc[0];
		SpawnEvent.Y = getorigloc[1];
		SpawnEvent.Z = getorigloc[2];
		returnInventory(Player);
	}
}

function SplitLoc(loc) {
	var c = loc.replace("(", "");
    c = c.replace(")", "");
    return c.split(",");
}

function On_PlayerKilled(DeathEvent) {
	var victim = DeathEvent.Victim;
	var name = victim.Name;
	var attacker = DeathEvent.Attacker;
	var attackername = attacker.Name;
	var id = victim.SteamID;
	var isin = DataStore.Get("HungerGamesP", id);
	if (isin == 1 && isactive == 1 && isstarted == 1) {
		players -= 1;
		Server.BroadcastFrom(sysname, "Player " + name + " was killed! Players left: " + players);
		if (players == 1) {
			EndGame(DeathEvent.Attacker);
		}
	}
}

function EndGame(Player) {
	var name = Player.Name;
	var id = Player.SteamID;
	Server.BroadcastFrom(sysname, "Event Ended!");
	Server.BroadcastFrom(sysname, "Player " + name + " has won the game!");
	Server.BroadcastFrom(sysname, "Congratulations!");
	var loc = DataStore.Get("HungerGamesL", id);
	var getorigloc = SplitLoc(loc);
	var locationc = Util.CreateVector(getorigloc[0], getorigloc[1], getorigloc[2]);
	Player.TeleportTo(locationc);
	returnInventory(Player);
	DataStore.Add("HungerGamesL", id, 0);
	DataStore.Add("HungerGamesP", id, 0);
	players = 0;
	isactive = 0;
	isstarted = 0;
	killprot = 1;
}

function Reset() {
	players = 0;
	isactive = 0;
	isstarted = 0;
	killprot = 1;
}

function ProtectionCallback() {
	killprot = 0;
	Server.BroadcastFrom(sysname, purple + "Kill Protection Ended! SHOOT TO KILL");
	Time.KillTimer("Protection");
}

function StartCallback() {
	LaunchEvent();
	Time.KillTimer("Start");
}

function FindPlayer(id) {
	for (pl in Server.Players) {
		if (pl.SteamID == id) {
			return pl;
		}
	}
    return null;
}

function AddItems(Player) {
	var inventory = Player.Inventory;
	inventory.AddItem("Cloth Helmet");
	inventory.AddItem("Cloth Vest");
	inventory.AddItem("Cloth Pants");
	inventory.AddItem("Cloth Boots");
	inventory.AddItem("Stone Hatchet");
	inventory.AddItem("Revolver");
	inventory.AddItem("Cooked Chicken Breast", 3);
	inventory.AddItem("Bandage");
	inventory.AddItem("9mm Ammo", 24);
}

function HungerGames(){
    if(!Plugin.IniExists("HungerGames")) {
        var HungerGames = Plugin.CreateIni("HungerGames");
		HungerGames.AddSetting("StartPos", "1", "loc");
		HungerGames.AddSetting("StartPos", "2", "loc");
		HungerGames.AddSetting("StartPos", "3", "loc");
		HungerGames.AddSetting("StartPos", "4", "loc");
		HungerGames.AddSetting("StartPos", "5", "loc");
		HungerGames.AddSetting("StartPos", "6", "loc");
		HungerGames.AddSetting("StartPos", "7", "loc");
		HungerGames.AddSetting("StartPos", "8", "loc");
		HungerGames.AddSetting("StartPos", "9", "loc");
		HungerGames.AddSetting("StartPos", "10", "loc");
		HungerGames.AddSetting("StartPos", "11", "loc");
		HungerGames.AddSetting("StartPos", "12", "loc");
		HungerGames.AddSetting("StartPos", "13", "loc");
		HungerGames.AddSetting("StartPos", "14", "loc");
        HungerGames.Save();
    }
    return Plugin.GetIni("HungerGames");
}

function On_PlayerHurt(HurtEvent) {
	var player = HurtEvent.Victim;
	var attacker = HurtEvent.Attacker;
	var id = player.SteamID;
	var ida = attacker.SteamID;
	var isain = DataStore.Get("HungerGamesP", ida);
	var isin = DataStore.Get("HungerGamesP", id);
	var dmg = HurtEvent.DamageAmount;
	if (isstarted == 1) {
		if (isactive == 1) {
			if (isain == 0 && isin == 1) {
				attacker.MessageFrom(sysname, "You can't kill players in the event, if you didn't participate!");
				HurtEvent.DamageAmount = dmg - dmg;
				return;
			}
			if (killprot == 1 && isin == 1) {
				HurtEvent.DamageAmount = dmg - dmg;
				attacker.MessageFrom(sysname, "You can't kill players, protection is still active!");
			}
		}
	}
}


/*
 * Mr. Five's code
 */

function recordInventory(Player) {
    var Inventory = [];
    var counter = 0;
	var id = Player.SteamID;
    for (var Item in Player.Inventory.Items) {
        if (Item && Item.Name) {
            var myitem = {};
            myitem.name = Item.Name;
            myitem.quantity = Item.Quantity;
            myitem.slot = Item.Slot;
            Inventory[counter++] = myitem;
        }
    }
    for (var Item in Player.Inventory.ArmorItems) {
        if (Item && Item.Name) {
            var myitem = {};
            myitem.name = Item.Name;
            myitem.quantity = Item.Quantity;
            myitem.slot = Item.Slot;
            Inventory[counter++] = myitem;
        }
    }
    for (var Item in Player.Inventory.BarItems) {
        if (Item && Item.Name) {
            var myitem = {};
            myitem.name = Item.Name;
            myitem.quantity = Item.Quantity;
            myitem.slot = Item.Slot;
            Inventory[counter++] = myitem;
        }
    }

    DataStore.Add("HungerGames", id, Inventory);
    Player.Inventory.ClearAll();
}

function returnInventory(Player) {
	var id = Player.SteamID;
	Player.Inventory.ClearAll();
    if (DataStoreContainsKey("HungerGames", id)) {
        var Inventory = DataStore.Get("HungerGames", id);
        if (Inventory) {
            Player.Inventory.ClearAll();
            for (var i = 0; i < Inventory.length; i++) {
                var Item = Inventory[i];
                if (Item && Item.name) {
                    Player.Inventory.AddItemTo(Item.name, Item.slot, Item.quantity);
                }
            }
            Player.MessageFrom(sysname, green + "Your have received your original inventory");
        } else {
            Player.MessageFrom(sysname, "Inventory == null");
        }
        DataStore.Remove("HungerGames", id);
    } else {
        Player.MessageFrom(sysname, "No Items found!");
    }
}

function DataStoreContainsKey(tbl, pkey) {
    for (var key in DataStore.Keys(tbl)) {
        if (Data.ToLower(key) == Data.ToLower(pkey)) return true;
    }
    return false;
}
