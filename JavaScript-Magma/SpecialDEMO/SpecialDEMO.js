function On_Command(Player, cmd, args) {
	var ini = Plugin.GetIni("Special");
	var inip = Plugin.GetIni("SPoints");
	var inis = Plugin.GetIni("Settings");
	var CheckP = inip.GetSetting("IP=Points", Player.IP);
	var invis = ini.GetSetting("Invis Mode", Player.IP);
	var uhat = ini.GetSetting("UHatchet Mode", Player.IP);
	var ubow = ini.GetSetting("UBow Mode", Player.IP);
	var pinv = inis.GetSetting("Prices", "Invisible Armor");
	var puhat = inis.GetSetting("Prices", "Uber Hatchet");
	var pubow = inis.GetSetting("Prices", "Uber Bow");
	var pinfo = inis.GetSetting("Prices", "Info Price");
	var pweb = inis.GetSetting("Donation", "Web-Site");
	var hinv = inis.GetSetting("Hours", "Invisible Armor");
	var huhat = inis.GetSetting("Hours", "Uber Hatchet");
	var hubow = inis.GetSetting("Hours", "Uber Bow");
	var bon = inis.GetSetting("Timers", "Expired Bonus Checking-Min")*60000;
	var X = ini.GetSetting("Zone: " + Player.IP, "X");
	var sdate = System.DateTime.Now.ToString("M.dd");
	var TimeONHH = System.DateTime.Now.ToString("HH")*60*60;
	var TimeONmm = System.DateTime.Now.ToString("mm")*60;
	var TimeONss = System.DateTime.Now.ToString("ss");
	var TimeONfull = parseInt(TimeONHH) + parseInt(TimeONmm) + parseInt(TimeONss);
	var setinv = parseInt(TimeONfull) + hinv*3600;
	var setuhat = parseInt(TimeONfull) + huhat*3600;
	var setubow = parseInt(TimeONfull) + hubow*3600;
	var vinvis = invis - TimeONfull;
	var hinvis = parseInt(vinvis/3600);
	var minvis = parseInt(vinvis/60);
	var sminvis = minvis - hinvis * 60;
	var vuhat = uhat - TimeONfull;
	var hsuhat = parseInt(vuhat/3600);
	var muhat = parseInt(vuhat/60);
	var smuhat = muhat - hsuhat * 60;
	var vubow = ubow - TimeONfull;
	var hsubow = parseInt(vubow/3600);
	var mubow = parseInt(vubow/60);
	var smubow = mubow - hsubow * 60;

	if (hinvis < 0) {
	var hinvis = hinvis + 23;
	var sminvis = sminvis + 59;
	}
	if (hsuhat < 0) {
	var hsuhat = hsuhat + 23;
	var smuhat = smuhat + 59;
	}
	if (hsubow < 0) {
	var hsubow = hsubow + 23;
	var smubow = smubow + 59;
	}
	
	if (cmd == "sptimer" && Player.Admin) {
	Player.MessageFrom("✯ Special ✯", "[color#BB9FF][color#FF0000]Special DEMO Version ![/color] Get now the full version on: [color#00FFFF]http://spoock.yolasite.com/get-it.php");
		if (Plugin.GetTimer("SpecialAnnounce")) {
		Player.MessageFrom("✯ Special ✯", "[color#BB9FF]Announce Timer: [color#00FF00]RUNNING[/color]");
		} else {
		Player.MessageFrom("✯ Special ✯", "[color#BB9FF]Announce Timer: [color#FF0000]OFF[/color]");
		}
		if (Plugin.GetTimer("CheckBonuses")) {
		Player.MessageFrom("✯ Special ✯", "[color#BB9FF]Check Timer: [color#00FF00]RUNNING[/color]");
		} else {
		Player.MessageFrom("✯ Special ✯", "[color#BB9FF]Check Timer: [color#FF0000]OFF[/color]");
		}
	}
	
	if (cmd == "spforce" && Player.Admin) {
	Player.MessageFrom("✯ Special ✯", "[color#BB9FF][color#FF0000]Special DEMO Version ![/color] Get now the full version on: [color#00FFFF]http://spoock.yolasite.com/get-it.php");
	SpecialAnnounceCallback();
	CheckBonusesCallback();
	}		
	
	if (cmd == "spadd" && Player.Admin) {
	Player.MessageFrom("✯ Special ✯", "[color#BB9FF][color#FF0000]Special DEMO Version ![/color] Get now the full version on: [color#00FFFF]http://spoock.yolasite.com/get-it.php");
	if (args.Length == 2) {
	var target = CheckV(Player, args);
	var sp = args[1];
		if (sp.match(/[0-9]/g)) {
			for (var name in Server.Players) {
				if (name == target) {
				var check = inip.GetSetting("IP=Points", target.IP);
					if (check == null) {
					inip.AddSetting("IP=Points", target.IP, sp);
					inip.Save();
					Player.MessageFrom("✯ Special ✯", "[color#BB9FF]Added [color#FFFF00]" + sp + " ✯[/color] to [color#00FFFF]" + target.Name + "[/color].");
					target.MessageFrom("✯ Special ✯", "[color#BB9FF]You Recieved [color#FFFF00]" + sp + " ✯[/color] from [color#00FFFF]" + Player.Name + "[/color].");
					} else if (check != null) {
					inip.AddSetting("IP=Points", target.IP, parseInt(check) + parseInt(sp));
					inip.Save();
					Player.MessageFrom("✯ Special ✯", "[color#BB9FF]Added [color#FFFF00]" + sp + " ✯[/color] to [color#00FFFF]" + target.Name + "[/color].");
					target.MessageFrom("✯ Special ✯", "[color#BB9FF]You Recieved [color#FFFF00]" + sp + " ✯[/color] from [color#00FFFF]" + Player.Name + "[/color].");
					}
				}
			}
		} else {
		Player.MessageFrom("✯ Special ✯", "[color#BB9FF]Use only numbers for [color#FFFF00]✯[/color] !");
		}
		} else {
		Player.MessageFrom("✯ Special ✯", "[color#BB9FF]To add Player [color#FFFF00]✯[/color] use [color#FF0000]/spadd NAME ✯[/color] !");
		}
	}
	
	if (cmd == "sprem" && Player.Admin) {
	Player.MessageFrom("✯ Special ✯", "[color#BB9FF][color#FF0000]Special DEMO Version ![/color] Get now the full version on: [color#00FFFF]http://spoock.yolasite.com/get-it.php");
	if (args.Length == 2) {
	var target = CheckV(Player, args);
	var sp = args[1];
		if (sp.match(/[0-9]/g)) {
			for (var name in Server.Players) {
				if (name == target) {
				var check = inip.GetSetting("IP=Points", target.IP);
					if (check == null || check == "0") {
					Player.MessageFrom("✯ Special ✯", "[color#BB9FF]Player [color#00FFFF]" + target.Name + "[/color] don't have any [color#FFFF00]✯[/color].");
					} else if (check != null && sp <= parseInt(check)) {
					inip.AddSetting("IP=Points", target.IP, parseInt(check) - parseInt(sp));
					inip.Save();
					Player.MessageFrom("✯ Special ✯", "[color#BB9FF]Removed [color#FFFF00]" + sp + " ✯[/color] to [color#00FFFF]" + target.Name + "[/color].");
					target.MessageFrom("✯ Special ✯", "[color#BB9FF]You Lost [color#FFFF00]" + sp + " ✯[/color] from [color#00FFFF]" + Player.Name + "[/color].");
					} else if (check != null && sp > parseInt(check)) {
					Player.MessageFrom("✯ Special ✯", "[color#BB9FF]Can't remove [color#FFFF00]" + sp + " ✯[/color] from [color#00FFFF]" + target.Name + "[/color] [color#FFFF00]" + check + " ✯[/color]");
					}
				}
			}
		} else {
		Player.MessageFrom("✯ Special ✯", "[color#BB9FF]Use only numbers for [color#FFFF00]✯[/color] !");
		}
		} else {
		Player.MessageFrom("✯ Special ✯", "[color#BB9FF]To remove Player [color#FFFF00]✯[/color] use [color#FF0000]/sprem NAME ✯[/color] !");
		}
	}
	
	if (cmd == "bsp") {
	Player.MessageFrom("✯ Special ✯", "[color#BB9FF][color#FF0000]Special DEMO Version ![/color] Get now the full version on: [color#00FFFF]http://spoock.yolasite.com/get-it.php");
	AdminItems(Player);
	}
	
	if (cmd == "mysp") {
	Player.MessageFrom("✯ Special ✯", "[color#BB9FF][color#FF0000]Special DEMO Version ![/color] Get now the full version on: [color#00FFFF]http://spoock.yolasite.com/get-it.php");
		if (invis != null) {
		Player.MessageFrom("✯ Invisible Armor ✯", "[color#BB9FF]Time Left: [color#00FFFF]" + hinvis + " h. " + sminvis + " min.[/color]");
		}
		if (uhat != null) {
		Player.MessageFrom("✯ Uber Hatchet ✯", "[color#BB9FF]Time Left: [color#00FFFF]" + hsuhat + " h. " + smuhat + " min.[/color]");
		}
		if (ubow != null) {
		Player.MessageFrom("✯ Uber Hunting Bow ✯", "[color#BB9FF]Time Left: [color#00FFFF]" + hsubow + " h. " + smubow + " min.[/color]");
		}
		if (CheckP != null) {
		Player.MessageFrom("MY ✯", "[color#FFFF00]" + CheckP + " ✯[/color]");
		Player.MessageFrom("? INFO ¿", "[color#BB9FF]For LOST [color#FFFF00]✯[/color] ITEMS [color#FF0000]/bsp[/color].");
		} else if (CheckP == null) {
		Player.MessageFrom("MY ✯", "[color#FFFF00]0 ✯[/color]");
		Player.MessageFrom("? INFO ¿", "[color#BB9FF]For LOST [color#FFFF00]✯[/color] ITEMS [color#FF0000]/bsp[/color].");
		}
	}
	
	if (cmd == "special") {
	if (args.Length == 0) {
	Player.MessageFrom("✯ Special ✯", "[color#BB9FF]Be [color#FFFF00]✯[color#00FFFF]SPECIAL[/color]✯[/color] ! Be [color#FFFF00]✯[color#00FFFF]DIFFRENT[/color]✯[/color] ! By [color#FFFF00]♚[color#00FFFF]DONATION[/color]♚[/color] You Can Get:");
	Player.MessageFrom("/special zone", "[color#BB9FF]+N day(s) ➲[/color] [color#FFFF00]♚[/color] [color#00FFFF]Zone Protect =[/color] [color#FF0000]Special DEMO Version ![/color]");
	Player.MessageFrom("/special god", "[color#BB9FF]+N hour(s) ➲[/color] [color#FFFF00]♚[/color] [color#00FFFF]God Mode =[/color] [color#FF0000]Special DEMO Version ![/color]");
	Player.MessageFrom("/special inv", "[color#BB9FF]+" +hinv+ " hour(s) ➲[/color] [color#FFFF00]♚[/color] [color#00FFFF]Invisible Armor =[/color] [color#FFFF00]" +pinv+ " ✯");
	Player.MessageFrom("/special uhat", "[color#BB9FF]+" +huhat+ " hour(s) ➲[/color] [color#FFFF00]♛[/color] [color#00FFFF]Uber Hatchet =[/color] [color#FFFF00]" +puhat+ " ✯");
	Player.MessageFrom("/special ubow", "[color#BB9FF]+" +hubow+ " hour(s) ➲[/color] [color#FFFF00]♛[/color] [color#00FFFF]Uber Hunting Bow =[/color] [color#FFFF00]" +pubow+ " ✯");
	Player.MessageFrom("/special unwo", "[color#BB9FF]+N hour(s) ➲[/color] [color#FFFF00]☬[/color] [color#00FFFF]Unlimited Wood =[/color] [color#FF0000]Special DEMO Version ![/color]");
	Player.MessageFrom("/special unme", "[color#BB9FF]+N hour(s) ➲[/color] [color#FFFF00]☬[/color] [color#00FFFF]Unlimited Metal Fragments =[/color] [color#FF0000]Special DEMO Version ![/color]");
	Player.MessageFrom("/special supp", "[color#BB9FF]+1 ➲[/color] [color#FFFF00]☬[/color] [color#00FFFF]Supply Signal =[/color] [color#FF0000]Special DEMO Version ![/color]");
	Player.MessageFrom("✯ Special ✯", "[color#BB9FF]Use the command[/color] [color#FF0000]/mysp[/color] [color#BB9FF]to check your[/color] [color#FFFF00]✯[/color] [color#BB9FF]and time left for the bonus you have.");
	Player.MessageFrom("♚ DONATION ♚", "[color#00FFFF]☞ " +pweb+ "[/color] [color#FFFF00] +" +pinfo+ " ✯");
	} else if (args.Length == 1) {
	Player.MessageFrom("✯ Special ✯", "[color#BB9FF][color#FF0000]Special DEMO Version ![/color] Get now the full version on: [color#00FFFF]http://spoock.yolasite.com/get-it.php");
	var choice = args[0].ToLower();	
	
	if (choice == "inv" && CheckP >= parseInt(pinv)) {
	var free = Player.Inventory.FreeSlots
	if (!Plugin.GetTimer("CheckBonuses")) {
	Plugin.CreateTimer("CheckBonuses", bon).Start();
	}
	var date = fixDate(setinv);
	var set = fixTime(setinv);
	var INC = parseInt(invis) + hinv*3600;
	var dateI = fixDateI(INC);
	var setI = fixTime(INC);
		if (invis != null) {
		ini.AddSetting("Invis Mode", Player.IP, setI);
			if (dateI != null) {
			ini.AddSetting("Dates", "Invis Mode: " + Player.IP, dateI);
			}
		ini.Save();
		inip.AddSetting("IP=Points", Player.IP, CheckP - parseInt(pinv));
		inip.Save();
		Server.BroadcastFrom("✯ Special ✯", "[color#BB9FF][color#FFFF00]" +Player.Name+ "[/color] just bought +"+hinv+" hour(s) [color#00FFFF]Invisible Armor[/color] Type [color#FFFF00]/special[/color] for more info !")
		Player.MessageFrom("✯ Special ✯", "[color#00FF00]✔[/color] [color#BB9FF]You just increased your [color#00FFFF]Invisible Armor[/color] with +"+hinv+" hour(s) !");
		} else if (invis == null && free >= 4) {
		ini.AddSetting("Invis Mode", Player.IP, setinv);
		ini.AddSetting("Dates", "Invis Mode: " + Player.IP, date);
		ini.Save();
		inip.AddSetting("IP=Points", Player.IP, CheckP - parseInt(pinv));
		inip.Save();
		Player.Inventory.AddItem("Invisible Helmet", 1);
		Player.Inventory.AddItem("Invisible Vest", 1);
		Player.Inventory.AddItem("Invisible Boots", 1);
		Player.Inventory.AddItem("Invisible Pants", 1);
		Server.BroadcastFrom("✯ Special ✯", "[color#BB9FF][color#FFFF00]" +Player.Name+ "[/color] just bought +"+hinv+" hour(s) [color#00FFFF]Invisible Armor[/color] Type [color#FFFF00]/special[/color] for more info !"); 
		Player.MessageFrom("✯ Special ✯", "[color#00FF00]✔[/color] [color#BB9FF]You just bought +"+hinv+" hour(s) [color#00FFFF]Invisible Armor[/color] !");
		} else {
		Player.MessageFrom("✯ Special ✯", "[color#FF0000]✘[/color] [color#BB9FF]You must have 4 free slots in your inventory !");
		}
	} else if (choice == "inv" && CheckP < parseInt(pinv)) {
	Player.MessageFrom("✯ Special ✯", "[color#BB9FF]You dont have enough [color#FFFF00]✯[/color]");
	}
	
	if (choice == "uhat" && CheckP >= parseInt(puhat)) {	
	var free = Player.Inventory.FreeSlots
	if (!Plugin.GetTimer("CheckBonuses")) {
	Plugin.CreateTimer("CheckBonuses", bon).Start();
	}
	var date = fixDate(setuhat);
	var set = fixTime(setuhat);
	var INC = parseInt(uhat) + huhat*3600;
	var dateI = fixDateI(INC);
	var setI = fixTime(INC);
		if (uhat != null) {
		ini.AddSetting("UHatchet Mode", Player.IP, setI);
			if (dateI != null) {
			ini.AddSetting("Dates", "UHatchet Mode: " + Player.IP, dateI);
			}
		ini.Save();
		inip.AddSetting("IP=Points", Player.IP, CheckP - parseInt(puhat));
		inip.Save();
		Server.BroadcastFrom("✯ Special ✯", "[color#BB9FF][color#FFFF00]" +Player.Name+ "[/color] just bought +"+huhat+" hour(s) [color#00FFFF]Uber Hatchet[/color] Type [color#FFFF00]/special[/color] for more info !");
		Player.MessageFrom("✯ Special ✯", "[color#00FF00]✔[/color] [color#BB9FF]You just increased your [color#00FFFF]Uber Hatchet with[/color] +"+huhat+" hour(s) !");
		} else if (uhat == null && free >= 1) {
		ini.AddSetting("UHatchet Mode", Player.IP, set);
		ini.AddSetting("Dates", "UHatchet Mode: " + Player.IP, date);
		ini.Save();
		inip.AddSetting("IP=Points", Player.IP, CheckP - parseInt(puhat));
		inip.Save();
		Player.Inventory.AddItem("Uber Hatchet", 1);
		Server.BroadcastFrom("✯ Special ✯", "[color#BB9FF][color#FFFF00]" +Player.Name+ "[/color] just bought +"+huhat+" hour(s) [color#00FFFF]Uber Hatchet[/color] Type [color#FFFF00]/special[/color] for more info !");
		Player.MessageFrom("✯ Special ✯", "[color#00FF00]✔[/color] [color#BB9FF]You just bought +"+huhat+" hour(s) [color#00FFFF]Uber Hatchet[/color] !");
		} else {
		Player.MessageFrom("✯ Special ✯", "[color#FF0000]✘[/color] [color#BB9FF]You must have 1 free slot in your inventory !");
		}
	} else if (choice == "uhat" && CheckP < parseInt(puhat)) {
	Player.MessageFrom("✯ Special ✯", "[color#FF0000]✘[/color] [color#BB9FF]You dont have enough [color#FFFF00]✯[/color]");
	}
	
	if (choice == "ubow" && CheckP >= parseInt(pubow)) {
	var free = Player.Inventory.FreeSlots
	if (!Plugin.GetTimer("CheckBonuses")) {
	Plugin.CreateTimer("CheckBonuses", bon).Start();
	}
	var date = fixDate(setubow);
	var set = fixTime(setubow);
	var INC = parseInt(ubow) + hubow*3600;
	var dateI = fixDateI(INC);
	var setI = fixTime(INC);
		if (ubow != null) {
		ini.AddSetting("UBow Mode", Player.IP, setI);
			if (dateI != null) {
			ini.AddSetting("Dates", "UBow Mode: " + Player.IP, dateI);
			}
		ini.Save();
		inip.AddSetting("IP=Points", Player.IP, CheckP - parseInt(pubow));
		inip.Save();
		Server.BroadcastFrom("✯ Special ✯", "[color#BB9FF][color#FFFF00]" +Player.Name+ "[/color] just bought +"+hubow+" hour(s) [color#00FFFF]Uber Hunting Bow[/color] Type [color#FFFF00]/special[/color] for more info !");
		Player.MessageFrom("✯ Special ✯", "[color#00FF00]✔[/color] [color#BB9FF]You just increased your [color#00FFFF]Uber Hunting Bow[/color] with +"+hubow+" hour(s) !");
		} else if (ubow == null && free >= 1) {
		ini.AddSetting("UBow Mode", Player.IP, set);
		ini.AddSetting("Dates", "UBow Mode: " + Player.IP, date);
		ini.Save();
		inip.AddSetting("IP=Points", Player.IP, CheckP - parseInt(pubow));
		inip.Save();
		Player.Inventory.AddItem("Uber Hunting Bow", 1);
		Server.BroadcastFrom("✯ Special ✯", "[color#BB9FF][color#FFFF00]" +Player.Name+ "[/color] just bought +"+hubow+" hour(s) [color#00FFFF]Uber Hunting Bow[/color] Type [color#FFFF00]/special[/color] for more info !");
		Player.MessageFrom("✯ Special ✯", "[color#00FF00]✔[/color] [color#BB9FF]You just bought +"+hubow+" hour(s) [color#00FFFF]Uber Hunting Bow[/color] !");
		} else {
		Player.MessageFrom("✯ Special ✯", "[color#FF0000]✘[/color] [color#BB9FF]You must have 1 free slot in your inventory !");
		}
	} else if (choice == "ubow" && CheckP < parseInt(pubow)) {
	Player.MessageFrom("✯ Special ✯", "[color#FF0000]✘[/color] [color#BB9FF]You dont have enough [color#FFFF00]✯[/color]");
	}
}
	}
}

function CheckBonusesCallback() {
	var ini = Plugin.GetIni("Special");
	var inis = Plugin.GetIni("Settings");
	var TimeONHH = System.DateTime.Now.ToString("HH")*60*60;
	var TimeONmm = System.DateTime.Now.ToString("mm")*60;
	var TimeONss = System.DateTime.Now.ToString("ss");
	var TimeONfull = parseInt(TimeONHH) + parseInt(TimeONmm) + parseInt(TimeONss);
	var bon = inis.GetSetting("Timers", "Expired Bonus Checking-Min")*60000;
	var n1 = 0;
	for (var Player in Server.Players) {
		var invis = ini.GetSetting("Invis Mode", Player.IP);
		var uhat = ini.GetSetting("UHatchet Mode", Player.IP);
		var ubow = ini.GetSetting("UBow Mode", Player.IP);
		if (invis != null || uhat != null || ubow != null) {
		n1++;
		}	
	}
	if (n1 == 0) {
	Plugin.KillTimer("CheckBonuses");
	return;
	}
	Plugin.CreateTimer("CheckBonuses", bon).Start();
	for (var Player in Server.Players) {
	var invis = ini.GetSetting("Invis Mode", Player.IP);
	var uhat = ini.GetSetting("UHatchet Mode", Player.IP);
	var ubow = ini.GetSetting("UBow Mode", Player.IP);
	var date = System.DateTime.Now.ToString("M.dd");
	var einvis = ini.GetSetting("Dates", "Invis Mode: " + Player.IP);
	var euhat = ini.GetSetting("Dates", "UHatchet Mode: " + Player.IP);
	var eubow = ini.GetSetting("Dates", "UBow Mode: " + Player.IP);
		
		if (invis < TimeONfull && invis != null && parseFloat(einvis) <= parseFloat(date) || invis != null && parseFloat(einvis) < parseFloat(date)) {
		ini.DeleteSetting("Invis Mode", Player.IP);
		ini.DeleteSetting("Dates", "Invis Mode: " + Player.IP);
		ini.Save();
		Player.Inventory.RemoveItem("Invisible Helmet", 250);
		Player.Inventory.RemoveItem("Invisible Vest", 250);
		Player.Inventory.RemoveItem("Invisible Pants", 250);
		Player.Inventory.RemoveItem("Invisible Boots", 250);
		Player.MessageFrom("✯ Special ✯", "[color#BB9FF]Your [color#00FFFF]Invisible Armor[/color] just [color#FF0000]EXPIRED[/color] ! [color#00FFFF]DONATE[/color] for more :)");
		}
		
		if (uhat < TimeONfull && uhat != null && parseFloat(euhat) <= parseFloat(date) || uhat != null && parseFloat(euhat) < parseFloat(date)) {
		ini.DeleteSetting("UHatchet Mode", Player.IP);
		ini.DeleteSetting("Dates", "UHatchet Mode: " + Player.IP);
		ini.Save();
		Player.Inventory.RemoveItem("Uber Hatchet", 250);
		Player.MessageFrom("✯ Special ✯", "[color#BB9FF]Your [color#00FFFF]Uber Hatchet[/color] just [color#FF0000]EXPIRED[/color] ! [color#00FFFF]DONATE[/color] for more :)");
		}
		
		if (ubow < TimeONfull && ubow != null && parseFloat(eubow) <= parseFloat(date) || ubow != null && parseFloat(eubow) < parseFloat(date)) {
		ini.DeleteSetting("UBow Mode", Player.IP);
		ini.DeleteSetting("Dates", "UBow Mode: " + Player.IP);
		ini.Save();
		Player.Inventory.RemoveItem("Uber Hunting Bow", 250);
		Player.MessageFrom("✯ Special ✯", "[color#BB9FF]Your [color#00FFFF]Uber Hunting Bow[/color] just [color#FF0000]EXPIRED[/color] ! [color#00FFFF]DONATE[/color] for more :)");
		}
	}
} 

function SpecialAnnounceCallback() {
	var ini = Plugin.GetIni("Special");
	var inis = Plugin.GetIni("Settings");
	var pweb = inis.GetSetting("Donation", "Web-Site");
	var TimeONdd = System.DateTime.Now.ToString("dd")*24;
	var TimeONHH = System.DateTime.Now.ToString("HH")*60*60;
	var TimeONmm = System.DateTime.Now.ToString("mm")*60;
	var TimeONss = System.DateTime.Now.ToString("ss");
	var TimeONfull = parseInt(TimeONdd) + parseInt(TimeONHH) + parseInt(TimeONmm) + parseInt(TimeONss);
	var ann = inis.GetSetting("Timers", "Announce Message-Min")*60000;
	Server.BroadcastFrom("✯ Special ✯", "[color#BB9FF][color#FF0000]Special DEMO Version ![/color] Get now the full version on: [color#00FFFF]http://spoock.yolasite.com/get-it.php");
	Server.BroadcastFrom("✯ Special ✯", "[color#BB9FF]☞ Do you want [/color] [color#00FFFF]Your Private Zone, God Mode, Invisible Armor, Uber Weapons, Unlimited Wood/Metal[/color] [color#BB9FF]?![/color]");
	Server.BroadcastFrom("✯ Special ✯", "[color#BB9FF]☞ The only thing you have to do is type [color#FFFF00]/special[/color] and follow the instructions ! ツ");
	Server.BroadcastFrom("♚ DONATION ♚", "[color#BB9FF]☞ Visit: [color#00FFFF]" + pweb + "[/color] To Get [color#FFFF00]✯[/color] !");
	Plugin.CreateTimer("SpecialAnnounce", ann).Start();
}


function On_PlayerSpawned(Player) {
	var ini = Plugin.GetIni("Special");
	var inis = Plugin.GetIni("Settings");
	var invis = ini.GetSetting("Invis Mode", Player.IP);
	var uhat = ini.GetSetting("UHatchet Mode", Player.IP);
	var ubow = ini.GetSetting("UBow Mode", Player.IP);
	var unl = inis.GetSetting("Timers", "Unlimited Checker-Sec")*1000;
	var bon = inis.GetSetting("Timers", "Expired Bonus Checking-Min")*60000;
	AdminItems(Player);
	if (invis != null && !Plugin.GetTimer("CheckBonuses") || uhat != null && !Plugin.GetTimer("CheckBonuses") || ubow != null && !Plugin.GetTimer("CheckBonuses")) {
	Plugin.CreateTimer("CheckBonuses", bon).Start();
	}
}

function AdminItems(Player) {
	var ini = Plugin.GetIni("Special");
	var invis = ini.GetSetting("Invis Mode", Player.IP);
	var uhat = ini.GetSetting("UHatchet Mode", Player.IP);
	var ubow = ini.GetSetting("UBow Mode", Player.IP);
	var free = Player.Inventory.FreeSlots
	
	if (invis != null) {
	if (free >= 4) {
		if (!Player.Inventory.HasItem("Invisible Helmet")) {
		Player.Inventory.AddItem("Invisible Helmet", 1);
		}
		if (!Player.Inventory.HasItem("Invisible Vest")) {
		Player.Inventory.AddItem("Invisible Vest", 1);
		}
		if (!Player.Inventory.HasItem("Invisible Boots")) {
		Player.Inventory.AddItem("Invisible Boots", 1);
		}
		if (!Player.Inventory.HasItem("Invisible Pants")) {
		Player.Inventory.AddItem("Invisible Pants", 1);
		}
	Player.MessageFrom("✯ Special ✯", "[color#00FF00]✔[/color] [color#FFFF00]✯[/color] [color#00FFFF]Invisible Armor[/color] [color#BB9FF]Restored !");
	} else {
	Player.MessageFrom("✯ Special ✯", "[color#FF0000]✘[/color] [color#BB9FF]You must have 4 free slots in your inventory !");
	}
	}
	
	if (uhat != null) {
	if (free >= 1) {
		if (!Player.Inventory.HasItem("Uber Hatchet")) {
		Player.Inventory.AddItem("Uber Hatchet", 1);
		}
	Player.MessageFrom("✯ Special ✯", "[color#00FF00]✔[/color] [color#FFFF00]✯[/color] [color#00FFFF]Uber Hatchet[/color] [color#BB9FF]Restored !");
	} else {
	Player.MessageFrom("✯ Special ✯", "[color#FF0000]✘[/color] [color#BB9FF]You must have 1 free slot in your inventory !");
	}
	}
	
	if (ubow != null) {
	if (free >= 1) {
		if (!Player.Inventory.HasItem("Uber Hunting Bow")) {
		Player.Inventory.AddItem("Uber Hunting Bow", 1);
		}
	Player.MessageFrom("✯ Special ✯", "[color#00FF00]✔[/color] [color#FFFF00]✯[/color] [color#00FFFF]Uber Bow[/color] [color#BB9FF]Restored !");
	} else {
	Player.MessageFrom("✯ Special ✯", "[color#FF0000]✘[/color] [color#BB9FF]You must have 1 free slot in your inventory !");
	}
	}
}

function On_PluginInit() {
	if (!Plugin.IniExists("Special")) {
	var iniA = Plugin.CreateIni("Special");
	}
	if (!Plugin.IniExists("SPoints")) {
	var iniB = Plugin.CreateIni("SPoints");
	}
	if (!Plugin.IniExists("Settings")) {
	var iniC = Plugin.CreateIni("Settings");
	iniC.AddSetting("Prices", "God Mode", "Special DEMO Version ! Get now the full version on: http://spoock.yolasite.com/get-it.php");
	iniC.AddSetting("Prices", "Invisible Armor", 6);
	iniC.AddSetting("Prices", "Uber Hatchet", 5);
	iniC.AddSetting("Prices", "Uber Bow", 5);
	iniC.AddSetting("Prices", "Unlimited Wood", "Special DEMO Version ! Get now the full version on: http://spoock.yolasite.com/get-it.php");
	iniC.AddSetting("Prices", "Unlimited MetalF", "Special DEMO Version ! Get now the full version on: http://spoock.yolasite.com/get-it.php");
	iniC.AddSetting("Prices", "Zone Protect", "Special DEMO Version ! Get now the full version on: http://spoock.yolasite.com/get-it.php");
	iniC.AddSetting("Prices", "Supply Signal", "Special DEMO Version ! Get now the full version on: http://spoock.yolasite.com/get-it.php");
	iniC.AddSetting("Prices", "Info Price", 14);
	iniC.AddSetting("Days", "Zone Protect", "Special DEMO Version ! Get now the full version on: http://spoock.yolasite.com/get-it.php");
	iniC.AddSetting("Hours", "God Mode", "Special DEMO Version ! Get now the full version on: http://spoock.yolasite.com/get-it.php");
	iniC.AddSetting("Hours", "Invisible Armor", 1);
	iniC.AddSetting("Hours", "Uber Hatchet", 1);
	iniC.AddSetting("Hours", "Uber Bow", 1);
	iniC.AddSetting("Hours", "Unlimited Wood", "Special DEMO Version ! Get now the full version on: http://spoock.yolasite.com/get-it.php");
	iniC.AddSetting("Hours", "Unlimited MetalF", "Special DEMO Version ! Get now the full version on: http://spoock.yolasite.com/get-it.php");
	iniC.AddSetting("Donation", "Web-Site", "http://spoock.yolasite.com/donate.php");
	iniC.AddSetting("Timers", "Announce Message-Min", 10);
	iniC.AddSetting("Timers", "Expired Bonus Checking-Min", 3);
	iniC.AddSetting("Timers", "Unlimited Checker-Sec", "Special DEMO Version ! Get now the full version on: http://spoock.yolasite.com/get-it.php");
	iniC.AddSetting("Timers", "Zone Protect Checking-Min", "Special DEMO Version ! Get now the full version on: http://spoock.yolasite.com/get-it.php");
	iniC.AddSetting("Zone System", "Default Radius", "Special DEMO Version ! Get now the full version on: http://spoock.yolasite.com/get-it.php");
	iniC.AddSetting("Zone System", "Increase Radius", "Special DEMO Version ! Get now the full version on: http://spoock.yolasite.com/get-it.php");
	iniC.AddSetting("Zone System", "Increase Radius Cost", "Special DEMO Version ! Get now the full version on: http://spoock.yolasite.com/get-it.php");
	iniC.AddSetting("Zone System", "Maximum Radius", "Special DEMO Version ! Get now the full version on: http://spoock.yolasite.com/get-it.php");
	iniC.AddSetting("Zone System", "Maximum ReSets", "Special DEMO Version ! Get now the full version on: http://spoock.yolasite.com/get-it.php");
	iniC.AddSetting("Zone System", "Between Zone Radius", "Special DEMO Version ! Get now the full version on: http://spoock.yolasite.com/get-it.php");
	iniC.Save();
	}
	StartUp();
}

function StartUp() {
Server.BroadcastFrom("✯ Special ✯", "[color#BB9FF][color#FF0000]Special DEMO Version ![/color] Get now the full version on: [color#00FFFF]http://spoock.yolasite.com/get-it.php");
	var ini = Plugin.GetIni("Special");
	var inis = Plugin.GetIni("Settings");
	var TimeONdd = System.DateTime.Now.ToString("dd")*24;
	var TimeONHH = System.DateTime.Now.ToString("HH")*60*60;
	var TimeONmm = System.DateTime.Now.ToString("mm")*60;
	var TimeONss = System.DateTime.Now.ToString("ss");	
	var TimeONfull = parseInt(TimeONdd) + parseInt(TimeONHH) + parseInt(TimeONmm) + parseInt(TimeONss);
	var ann = inis.GetSetting("Timers", "Announce Message-Min")*60000;
	var bon = inis.GetSetting("Timers", "Expired Bonus Checking-Min")*60000;
	var date = System.DateTime.Now.ToString("M.dd");
	Plugin.CreateTimer("SpecialAnnounce", ann).Start();
	
	for (var Player in Server.Players) {
	var uhat = ini.GetSetting("UHatchet Mode", Player.IP);
	var ubow = ini.GetSetting("UBow Mode", Player.IP);		
		if (invis != null || uhat != null || ubow != null) {
		Plugin.CreateTimer("CheckBonuses", bon).Start();
		}
	}	
	
	for(var a in ini.EnumSection("Invis Mode")) {
	var invis = ini.GetSetting("Invis Mode", a);
	var einvis = ini.GetSetting("Dates", "Invis Mode: " + a);
	if (invis < TimeONfull && parseFloat(einvis) <= parseFloat(date) || parseFloat(einvis) < parseFloat(date)) {
	ini.DeleteSetting("Invis Mode", a);
	ini.DeleteSetting("Dates", "Invis Mode: " + a);
	ini.Save();
		}
	}
	for(var a in ini.EnumSection("UHatchet Mode")) {
	var uhat = ini.GetSetting("UHatchet Mode", a);
	var euhat = ini.GetSetting("Dates", "UHatchet Mode: " + a);
	if (uhat < TimeONfull && parseFloat(euhat) <= parseFloat(date) || parseFloat(euhat) < parseFloat(date)) {
	ini.DeleteSetting("UHatchet Mode", a);
	ini.DeleteSetting("Dates", "UHatchet Mode: " + a);
	ini.Save();
		}
	}
	for(var a in ini.EnumSection("UBow Mode")) {
	var ubow = ini.GetSetting("UBow Mode", a);
	var eubow = ini.GetSetting("Dates", "UBow Mode: " + a);
	if (ubow < TimeONfull && parseFloat(eubow) <= parseFloat(date) || parseFloat(eubow) < parseFloat(date)) {
	ini.DeleteSetting("UBow Mode", a);
	ini.DeleteSetting("Dates", "UHatchet Mode: " + a);
	ini.Save();
		}
	}
}

function CheckV(Player, args) {
	var target;
			var Nickname = "";
			for(var i=0; i < args.Length; i++)
			Nickname += args[i] + " ";
			Nickname = Data.Substring(Nickname, 0, Data.StrLen(Nickname) - 1)
			target = Magma.Player.FindByName(Nickname);
			if (target != null) {
				return (target);
			} else {
			var cc = 0;
		for (var all in Server.Players) {
			var name = all.Name.ToLower();
			var check = args[0].ToLower();
			if (name.Contains(check)) {
			var found = all.Name;
			cc++;
			}
		}
		if (cc == 1) {
			target = Magma.Player.FindByName(found);
			return (target);
		} else if (cc > 1) {
			Player.MessageFrom("✯ Special ✯", "[color#BB9FF]Found [color#FF0000]" + cc + " players[/color] with similar names. [color#FF0000]Use more correct name ![/color]");
			return (0);
		} else if (cc == 0) {
			Player.MessageFrom("✯ Special ✯", "[color#BB9FF]Player [color#00FFFF]" + Nickname + "[/color] not found");
			return (0);
		}
	}
}

function fixTime(set) {
	var TimeONHH = System.DateTime.Now.ToString("HH")*60*60;
	var TimeONmm = System.DateTime.Now.ToString("mm")*60;
	var TimeONss = System.DateTime.Now.ToString("ss");
	var TimeONfull = parseInt(TimeONHH) + parseInt(TimeONmm) + parseInt(TimeONss);
	var v1 = set - TimeONfull;
	var h1 = parseInt(v1/3600);
	var m1 = parseInt(v1/60);
	var sm1 = m1 - h1 * 60;
	var v2 = TimeONfull;
	var h2 = parseInt(v2/3600);
	var m2 = parseInt(v2/60);
	var sm2 = m2 - h2 * 60;
	var h = (h1 + h2);
	var sm = (sm1 + sm2);
	
	if (h > 23) {
	var cor1 = (h - 24)*60*60;
	var cor2 = sm*60;
	var cor3 = TimeONss;
	var corF = parseInt(cor1) + parseInt(cor2) + parseInt(cor3);
	var set = parseInt(corF);
	} else {
	var set = set;
	}
	return set;
}

function fixDate(date) {
	var TimeONHH = System.DateTime.Now.ToString("HH")*60*60;
	var TimeONmm = System.DateTime.Now.ToString("mm")*60;
	var TimeONss = System.DateTime.Now.ToString("ss");
	var TimeONfull = parseInt(TimeONHH) + parseInt(TimeONmm) + parseInt(TimeONss);
	var v1 = date - TimeONfull;
	var h1 = parseInt(v1/3600);
	var m1 = parseInt(v1/60);
	var sm1 = m1 - h1 * 60;
	var v2 = TimeONfull;
	var h2 = parseInt(v2/3600);
	var m2 = parseInt(v2/60);
	var sm2 = m2 - h2 * 60;
	var h = (h1 + h2);
	var sm = (sm1 + sm2);
	var time = 1;
	
	if (h > 23) {
	var date = CalcDays(time);	
	} else {
	var date = System.DateTime.Now.ToString("M.dd");
	}
	return date;
}

function fixDateI(dateI) {
	var TimeONHH = System.DateTime.Now.ToString("HH")*60*60;
	var TimeONmm = System.DateTime.Now.ToString("mm")*60;
	var TimeONss = System.DateTime.Now.ToString("ss");
	var TimeONfull = parseInt(TimeONHH) + parseInt(TimeONmm) + parseInt(TimeONss);
	var v1 = dateI - TimeONfull;
	var h1 = parseInt(v1/3600);
	var m1 = parseInt(v1/60);
	var sm1 = m1 - h1 * 60;
	var v2 = TimeONfull;
	var h2 = parseInt(v2/3600);
	var m2 = parseInt(v2/60);
	var sm2 = m2 - h2 * 60;
	var h = (h1 + h2);
	var sm = (sm1 + sm2);
	var time = 1;
	
	if (h > 23) {
	var dateI = CalcDays(time);	
	return dateI;
	}
}


function CalcDays(time) {
	var tday = System.DateTime.Now.ToString("M.dd")*100;
	var FULL = parseInt(tday)/100 + time/100;
	if (2.01 > FULL && FULL > 1.31) {
	var calc = (FULL - 1.31) + 2.01;
	} else if (3.01 > FULL && FULL > 2.28) {
	var calc = (FULL - 2.28) + 3.01;
	} else if (4.01 > FULL && FULL > 3.30) {
	var calc = (FULL - 3.30) + 4.01;
	} else if (5.01 > FULL && FULL > 4.30) {
	var calc = (FULL - 4.30) + 5.01;
	} else if (6.01 > FULL && FULL > 5.31) {
	var calc = (FULL - 5.31) + 6.01;
	} else if (7.01 > FULL && FULL > 6.30) {
	var calc = (FULL - 6.30) + 7.01;
	} else if (8.01 > FULL && FULL > 7.31) {
	var calc = (FULL - 7.31) + 8.01;
	} else if (9.01 > FULL && FULL > 8.31) {
	var calc = (FULL - 8.31) + 9.01;
	} else if (10.01 > FULL && FULL > 9.30) {
	var calc = (FULL - 9.30) + 10.01;
	} else if (11.01 > FULL && FULL > 10.31) {
	var calc = (FULL - 10.31) + 11.01;
	} else if (12.01 > FULL && FULL > 11.30) {
	var calc = (FULL - 11.30) + 12.01;
	} else if (FULL > 12.31) {
	var calc = (FULL - 12.31) + 1.01;
	} else {
	var calc = FULL;
	}
	return calc;
}


function Check(Player, args) {
	var target;
			var Nickname = "";
			for(var i=1; i < args.Length; i++)
			Nickname += args[i] + " ";
			Nickname = Data.Substring(Nickname, 0, Data.StrLen(Nickname) - 1)
			target = Magma.Player.FindByName(Nickname);
			if (target != null) {
				return (target);
			} else {
			var cc = 0;
		for (var all in Server.Players) {
			var name = all.Name.ToLower();
			var check = args[1].ToLower();
			if (name.Contains(check)) {
			var found = all.Name;
			cc++;
			}
		}
		if (cc == 1) {
			target = Magma.Player.FindByName(found);
			return (target);
		} else if (cc > 1) {
			Player.MessageFrom("✯ Special ✯", "Found [color#FF0000]" + cc + " players[/color] with similar names. [color#FF0000]Use more correct name !");
			return (0);
		} else if (cc == 0) {
			Player.MessageFrom("✯ Special ✯", "Player [color#00FF00]" + Nickname + "[/color] not found");
			return (0);
		}
	}
}