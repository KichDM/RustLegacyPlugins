function iniset() {
    return Plugin.GetIni("Settings");
}
function inisetb() {
    return Plugin.GetIni("Database");
}

function On_PlayerConnected(Player) {
	var getinifile = inisetb();
	if (!getinifile.GetSetting("Cooldown", Player.SteamID))
	{
		getinifile.AddSetting("Cooldown", Player.SteamID, 0);
		getinifile.Save();
	}
}

function On_PluginInit() {
	 if (!Plugin.IniExists("Settings")) {
        var inifile = Plugin.CreateIni("Settings");

        inifile.AddSetting("Settings", "RewardCooldown", "1440");
        inifile.AddSetting("Settings", "RewardItems", "5");
        inifile.AddSetting("Items", "Low Quality Metal", "50");
        inifile.AddSetting("Items", "Large Medkit", "50");
        inifile.AddSetting("Items", "556 Ammo", "100");
        inifile.AddSetting("Items", "9mm Ammo", "100");
        inifile.AddSetting("Items", "Cooked Chicken Breast", "50");
        inifile.Save();
    }
    if (!Plugin.IniExists("Database")) {
    	var inifile2 = Plugin.CreateIni("Database");
    	inifile2.AddSetting("Cooldown", "1494949239248482", "0");
    	inifile2.Save();
    }
}

function On_Command(Player, cmd, args) {
    if (cmd == "rewardlist")
    {
        var getfile = iniset();
        var itemenum = getfile.EnumSection("Items");
        Player.MessageFrom("[DailyReward]","=====================================");
        Player.MessageFrom("[DailyReward]", "[color#FF0000]Join daily and get following items as reward");
        Player.MessageFrom("[DailyReward]","----------------------------------------------");
        for (var item in itemenum) 
        {
            var amount = getfile.GetSetting("Items", item);
            Player.MessageFrom("[DailyReward]", "[color#00FFFF]" + item + "[color#AB00CD] - [color#FF8000]" + amount);
        }
        Player.MessageFrom("[DailyReward]","=====================================");
    }
	if (cmd == "reward") {
		var getinifile = iniset();
		var getfile = inisetb();
		var cooldown = getinifile.GetSetting("Settings","RewardCooldown");
		var itemcount = getinifile.GetSetting("Settings","RewardItems");
		var rewarditems = getinifile.EnumSection("Items");
		var lastreward = getfile.GetSetting("Cooldown", Player.SteamID);
		var calc = parseInt(System.Environment.TickCount) - parseInt(lastreward);
		if (Player.Inventory.FreeSlots <= parseInt(itemcount)) {
            Player.MessageFrom("[DailyReward]", "[color#00FFFF]Your inventory is full. Get some free space then run the command again.");
        } else {
            if (calc >= cooldown * 60000 || Player.Admin) {
            	Player.MessageFrom("[DailyReward]", "[color#AB00CD]============================================");
                Player.MessageFrom("[DailyReward]", "[color#00FFFF]Hooray! Thanks for connecting today , here are your reward! ");
                Server.Broadcast("[color#00FFFF]Player [color#FF0000]" + Player.Name + "[color#00FFFF] Connected today and claimed the [color#FF8000]DAILY REWARD![color#00FFFF](/reward)");
                Player.MessageFrom("[DailyReward]", "[color#AB00CD]============================================");
                for (var item in rewarditems)
                {
                    var amount = getinifile.GetSetting("Items",item);
                    Player.Inventory.AddItem(item,amount);
                }

                var tick = parseInt(System.Environment.TickCount);
                getfile.AddSetting("Cooldown", Player.SteamID,tick);
                getfile.Save();
            } else {
                if (calc < 0) {
                    time = getfile.AddSetting("Cooldown", Player.SteamID, 0);
                    getfile.Save();
                    Player.MessageFrom("[DailyReward]", "[color#00FFFF]Your time went negative! Try again!");
                }
                var next = calc / 1000;
                var next2 = next / 60;
                var def = cooldown;
                var done = Number(next2).toFixed(2);
                var done2 = Number(def).toFixed(2);
                Player.MessageFrom("[DailyReward]", "[color#00FFFF]You will be able to use DailyReward again in [color#FF8000]" + done + "[color#00FFFF]/[color#AB00CD]" + done2 + " [color#00FFFF]min !");
            }
        }

	}
	if (cmd == "rreset") {
        if (args.Length == 0 && Player.Admin) {
            Player.MessageFrom("[DailyReward Timer Reset]", "Usage: /rreset name");
        }
        if (args.Length == 1 && Player.Admin) {
            if (!args[0]) {
                Player.MessageFrom("[DailyReward Timer Reset]", "No name inserted.");
            } else {
                var name = args[0];
                var player = Server.FindPlayer(name);
                if (player != null) {
                    Player.MessageFrom("[DailyReward Timer Reset]", "Found: " + player.Name);
                    Player.MessageFrom("[DailyReward Timer Reset]", "Timers for " + player.Name + " has been reset!");
                	var getfile = inisetb();
                	getfile.AddSetting("Cooldown",player.SteamID,System.Environment.TickCount);
                    getfile.Save();
                }
                }
            }
        }
}