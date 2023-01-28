/*
*KKMoney
*By: KuhlKid
*Do not take this author section out.
*Version 1.0 (5/12/14)
*/

//Global Color Variables for Chat
var blue = "[color #0099FF]"
var red = "[color #FF0000]"
var pink = "[color #CC66FF]"
var teal = "[color #00FFFF]"
var green = "[color #009900]"
var purple = "[color #6600CC]"
var white = "[color #FFFFFF]"

function On_Command(Player, cmd, args){
	switch(cmd){
        case "shop":
            Player.Message("Economy Commands: /balance, /buy [Item] [Quantity], /sell [Item] [Quantity], /price");
        break;

        case "clearmoney":
            if (Player.Admin){
                ClearMoney(Player);
            } else {
                Player.Message("You are unable to do this.");
            }
        break;

		case "balance":
			var dbm = Data.GetTableValue("KKMoney", Player.SteamID);
			if (dbm != null) {
				if (isNaN(dbm)) {
					var mon = ini.GetSetting("KKMoney", Player.SteamID);
					var monp = parseInt(mon);
					if (mon != null) {
						if (!isNaN(monp)) {
							var ini = PullIni();
							ini.DeleteSetting("KKMoney", Player.SteamID, monp);
							ini.Save();
							ini.AddSetting("KKMoney", Player.SteamID, monp);
							ini.Save();
						} 
						else {
							ClearMoney(Player);
						}
					}
					else {
						ClearMoney(Player);
					}
				}
			}
			else {
				ClearMoney(Player);
			}
			var Money = PullMoney(Player);
			Player.Message("You have " + teal + "$" + Money + ".");
		break;

        case "givemoney":
            if (!Player.Admin){
                Player.Message("You can't give money you twit.");
            } else if (args.Length == 0){
                Player.Message("Please enter a player's name!");
                Player.Message("Example: /givemoney Kuhlkid 100");
                return;
            } else if (args.Length < 2){
                Player.Message("Please enter an ammount to give the player!");
                Player.Message("Example: /givemoney Kuhlkid 100");
                return;
            } else {
                var user = Player.Find(args[0]);
                if(user != undefined && user != null){
                    var amount = args[1];
                    AddMoney(user, amount);
                    user.Message("You have been credited " + teal + "$" + amount + "!");
                    Player.Message("You have given " + args[0] + " $" + amount + ".");
                    break;
                } else {
                    Player.Message("Sorry. A user named " + args[0] + " was not found!");
                }                       
            }
        break;

        case "takemoney":
            if (!Player.Admin){
        		Player.Message("You can't take money you twit.");
        	} else if (args.Length == 0){
                Player.Message("Please enter a player's name!");
                Player.Message("Example: /takemoney Kuhlkid 100");
                return;
            } else if (args.Length < 2){
                Player.Message("Please enter an ammount to give the player!");
                Player.Message("Example: /takemoney Kuhlkid 100");
                return;
            } else {
                var user = Player.Find(args[0]);
                if(user != undefined && user != null){
                    var amount = args[1];
                    RemoveMoney(user, amount);
                    user.Message(teal +"$" + amount + white + " has been removed from your account!");
                    Player.Message("You have taken " + teal + "$" + amount + white + " from " + args[0] + ".");
                    break;
                } else {
                    Player.Message("Sorry. A user named " + args[0] + " was not found!");
                }                       
            }
        break;

        case "buy":
            if (args.Length > 1){
                Buy_Item(Player, args);
            } else {
                Player.Message("Try: /buy [Item] [Quantity]");
            }
        break;
        case "sell":
            if (args.Length > 1){
                Sell_Item(Player, args);
            } else {
                Player.Message("Try: /sell [Item] [Quantity]");
            }
        break;

        case "price":
            if (args.Length == 1){
                GetPrices(Player, args[0]);
            } else {
                Player.Message("Try: /price [List]");
                Player.Message(teal + "Lists:");
                var Count = parseInt(Data.GetConfigValue("KKMoney", "Categories", "Count"));
                for (var i=1; i<=Count; i++){
                var ListName = Data.GetConfigValue("KKMoney", "Categories", i);
                Player.Message(green + ListName);
                }
            }
        break;
	}
}

function AddMoney(Player, amount){
	var Money = parseInt(PullMoney(Player)) + parseInt(amount);
	Data.AddTableValue("KKMoney", Player.SteamID, Money);
	Player.Message("You now have " + teal + "$" + Money + ".");
}

function RemoveMoney(Player, amount){
	var Money = parseInt(PullMoney(Player)) - parseInt(amount);
    if (Money <= 0){
        Money = 0;
        Data.AddTableValue("KKMoney", Player.SteamID, Money);
        Player.Message("You now have " + teal + "$" + Money + ".");
    } else {
        Data.AddTableValue("KKMoney", Player.SteamID, Money);
        Player.Message("You now have " + teal + "$" + Money + ".");
    }
}

function ClearMoney(Player) {
	var Money = 100
	Data.AddTableValue("KKMoney", Player.SteamID, Money);
	Player.Message("You now have " + teal + "$" + Money + ".");
}

function On_NPCKilled(de){
	if (Data.GetConfigValue("KKMoney", "Settings", "AnimalKills") == "true"){
		var animal = de.Victim.Name;
		var amount = parseInt(Data.GetConfigValue("KKMoney", "AnimalValues", animal));
		AddMoney(de.Attacker, amount);
		de.Attacker.MessageFrom("Frosty Falls",teal + "$" + amount + white + " has been credited to you for killing an animal!");
	}
}

function On_PlayerKilled(de){ 
	if (de.Attacker != de.Victim && de.DamageType != null && de.Victim != null && de.Attacker != null && !IsAnimal(de.Attacker.Name)) {
		var victim = de.Victim.Name;
		var vic = de.Victim;
		var killer = de.Attacker.Name;
		var kill = de.Attacker;
		if (Data.GetConfigValue("KKMoney", "PlayerValues", "PercentageLoss") && Data.GetConfigValue("KKMoney", "PlayerValues", "PercentageGain")) {
			var ratiolost = parseInt(Data.GetConfigValue("KKMoney", "PlayerValues", "PercentageLoss")) / 100;
			var ratiogained = parseInt(Data.GetConfigValue("KKMoney", "PlayerValues", "PercentageGain")) / 100;
			if (killer != victim && PullMoney(vic) != null) {
				var earnings = (parseInt(PullMoney(vic)) * ratiogained);
				var losses = (parseInt(PullMoney(vic)) * ratiolost);
				AddMoney(kill, earnings);
				RemoveMoney(vic, losses);
			}
		}
	}
}

function GetPrices(Player, args){
    var Count = parseInt(Data.GetConfigValue("KKMoney", args, "Count"));
    if (Count >= 1){
        Player.Message(teal + args + ":");
        for (var i=1; i<=Count; i++){
            var ItemName = Data.GetConfigValue("KKMoney", args, i);
            Player.Message(green + ItemName);
        }
    } else {
        Player.Message("That category does not exist!");
    }
}

function Buy_Item(Player, args){
    var Money = PullMoney(Player);
	if (Money == null) return;
    var item = Item(args);
    var price = parseInt(Data.GetConfigValue("KKMoney", "BuyPrices", item));
    var qty = args[args.Length - 1];
        if (Data.GetConfigValue("KKMoney", "Settings", "Buy") == "true"){
            var pricesum = price * qty
            if (price) {
                if (pricesum <= Money){
                    Player.Inventory.AddItem(item, qty);
                    RemoveMoney(Player, pricesum);
                    Player.Message("You have bought " + qty + " " + item + "(s).");
                } else {
                    Player.Message("You do not have enough money to buy " + qty + " " + item + "(s).");
                }
            } else {
                Player.Message("You can't currently buy " + item + ".");
                Player.Message("Contact an admin to see if it will be added later!");
            }
        } else {
            Player.Message("Sorry, buying has been disabled.");
        }
}

function Sell_Item(Player, args){
    //var weapons = "M4,Shotgun,Bolt Action Rifle,MP5A4,P250,Revolver,HandCannon,9mm Pistol,Pipe Shotgun,Torch"
    var Money = PullMoney(Player);
	if (Money == null) return;
    var item = Item(args);
    var price = parseInt(Data.GetConfigValue("KKMoney", "SellPrices", item));
    var qty = args[args.Length - 1];
    if (Data.GetConfigValue("KKMoney", "Settings", "Sell") == "true"){
        var salesum = price * qty;
        if (price >= 1) {
            //var re = new RegExp(item, i);
            //Player.Message(re);
            //var uses, slot;
            //if(weapons.match(re) !== null) {
            //    for(slot in Player.Inventory.Items) {
            //        if(Player.Inventory.Items[slot].Name == item) {
            //            uses = Player.Inventory.Items[slot].UsesLeft;
            //            slot = Player.Inventory.Items[slot].Slot;
            //            Player.Message(slot + " " + uses);
            //        }
            //    }
            //} else 
            if(Player.Inventory.HasItem(item, qty)) {
                Player.Message("You are not selling a weapon.");
                Player.Inventory.RemoveItem(item, qty);
                AddMoney(Player, salesum);
                Player.Message("You have sold " + qty + " " + item + "(s).");
            } else {
                Player.Message("You either don't have the item or the quantity wanted to sell. Try again.");
            }
        } else {
            Player.Message("You can't currently sell " + item + ".");
            Player.Message("Contact an admin to see if it will be added later!");
        }
    } else {
       Player.Message("Sorry, selling has been disabled.");
    }
}

function Item(args) {
    var item = "";
    for (var i = 0; i < args.Length - 1; i++) {
        item += args[i] + " ";
    }
    item = Data.ToLower(item.substring(0, item.length - 1));
    var newItem = Data.GetConfigValue("KKMoney", "ItemNames", item);
    return newItem;
}

function IsAnimal(killer) {
	switch (killer) {
		case 'Wolf':
		case 'Bear':
		case 'MutantWolf':
		case 'MutantBear':
			return true;
		default:
			return false;
	}
}

function PullMoney(Player){
	var Money = Data.GetTableValue("KKMoney", Player.SteamID);
	if (Money != null) {
		return Money;
	}
	return null;
}

function On_PlayerConnected(Player){
	try {
		var id = Player.SteamID;
		var ini = PullIni();
		if (!ini.GetSetting("KKMoney", id)){
			var Money = Data.GetConfigValue("KKMoney", "Settings", "StarterBalance");
			Data.AddTableValue("KKMoney", id, Money);
			Player.Message("You have " + teal + "$" + Money + ".");
		} else if (ini.GetSetting("KKMoney", id)){
			var Money = ini.GetSetting("KKMoney", id);
			Data.AddTableValue("KKMoney", id, Money);
			Player.Message("You have " + teal + "$" + Money + ".");
		} else {
			Player.Message("Oh NO. Something went wrong!");
		}
	} catch(err) {
		Plugin.Log("KKmoneyerror", "Error at connection");
	}
}

function PullIni(){
	if(!Plugin.IniExists("KKMoney"))
		Plugin.CreateIni("KKMoney");
	return Plugin.GetIni("KKMoney");
}

function UpdateIni(Player){
	var Money = PullMoney(Player);
	var ini = PullIni();
	ini.AddSetting("KKMoney", Player.SteamID, Money);
	ini.Save();
}

function On_PlayerDisconnected(Player){
    UpdateIni(Player);
}