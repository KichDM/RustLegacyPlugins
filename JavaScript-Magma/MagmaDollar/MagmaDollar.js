function On_Command(Player, cmd, args) {
	switch(cmd) {		
		case "money":
			var money = GetMoney(Player);
			Player.Message("You have " + money + " Magma Dollars");
			break;
		case "givemoney":
			AddMoney(Player, 500);
			Player.Message("You have been given $500. You now have $" + GetMoney(Player));
			break;
	}
}

function GetMoney(Player) {
	var money = Data.GetTableValue("magma_dollar", Player.SteamID);
		if(money == null) {
			money = 0;
			Data.AddTableValue("magma_dollar", Player.SteamID, money);
			Update(Player);
		}
	return money;
}

function AddMoney(Player, amount) {
	var money = GetMoney(Player) + amount;
	Data.AddTableValue("magma_dollar", Player.SteamID, money);
	Update(Player);
}

function RemoveMoney(Player, amount) {
	var money = GetMoney(Player) - amount;
	Data.AddTableValue("magma_dollar", Player.SteamID, money);
	Update(Player);
}

function SetMoney(Player, amount) {
	Data.AddTableValue("magma_dollar", Player.SteamID, amount);
	Update(Player);
}

function HasMoney(Player, amount) {
	var money = GetMoney(Player);
	return money >= amount;
}

function Update(Player) {
	var money = GetMoney(Player);
	var ini = GetIni();
	ini.AddSetting("Money", Player.SteamID, money);
	ini.Save();
}

function GetIni() {
	if(!Plugin.IniExists("MagmaDollarData"))
		Plugin.CreateIni("MagmaDollarData");
	return Plugin.GetIni("MagmaDollarData");
}

function LoadMoney() {
	var ini = GetIni();
	for(var heh in ini.EnumSection("Money")) {
		var money = ini.GetSetting("Money", heh); 
		Data.AddTableValue("magma_dollar", heh, money);
	}
}

function On_ServerInit() {
	LoadMoney();
}