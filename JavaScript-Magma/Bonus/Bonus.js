function inifile() {
    return Plugin.GetIni("Settings");
}


function On_PluginInit() {
	if (!Plugin.IniExists("Settings")) {
    	var inifile = Plugin.CreateIni("Settings");
    	inifile.AddSetting("Settings","Cooldown","30");
    	inifile.AddSetting("Settings","NumItems","3");
    	inifile.AddSetting("Settings","ItemName1","Stone Hatchet");
    	inifile.AddSetting("Settings","ItemAmount1","1");
    	inifile.AddSetting("Settings","ItemName2","Cooked Chicken Breast");
    	inifile.AddSetting("Settings","ItemAmount2","10");
    	inifile.AddSetting("Settings","ItemName3","Leather Helmet");
    	inifile.AddSetting("Settings","ItemAmount3","1");
        inifile.Save();

}
}

function On_Command(Player, cmd, args) {
    if (cmd == "bonus") {
    	var getinifile = inifile();
    	var cooldown = getinifile.GetSetting("Settings","Cooldown");
    	var itemcount = getinifile.GetSetting("Settings","NumItems");
        var time = DataStore.Get("bonus_cooldown", Player.SteamID);
        var calc = System.Environment.TickCount - time;
        if (Player.Inventory.FreeSlots <= 5) {
            Player.MessageFrom("[bonus]", "[color#00FFFF]Your inventory is full. Get some free space then run the command again.");
        } else {
            if (calc >= cooldown * 60000 || Player.Admin) {
                Player.MessageFrom("[bonus]", "[color#00FFFF]Items were added in ur inventory , check it out! ");
                for (var i = 1; i <= parseInt(itemcount); i++)
                {
                    Player.Inventory.AddItem(getinifile.GetSetting("Settings","ItemName"+i), getinifile.GetSetting("Settings","ItemAmount"+i));
                }
                DataStore.Add("bonus_cooldown", Player.SteamID, System.Environment.TickCount);
            } else {
                if (calc < 0) {
                    time = DataStore.Add("bonus_cooldown", Player.SteamID, null);
                    Player.MessageFrom("[bonus]", "[color#00FFFF]Your time went negative! Try again!");
                }
                var next = calc / 1000;
                var next2 = next / 60;
                var def = cooldown;
                var done = Number(next2).toFixed(2);
                var done2 = Number(def).toFixed(2);
                Player.MessageFrom("[bonus]", "[color#00FFFF]You will be able to use bonus again in [color#FF8000]" + done + "[color#00FFFF]/[color#AB00CD]" + done2 + " [color#00FFFF]min !");
            }
        }

    }
}