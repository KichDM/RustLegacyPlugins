function On_PlayerHurt(HurtEvent) {
	if (HurtEvent.Attacker == HurtEvent.Victim) {
		var bleed = HurtEvent.DamageType;
		var damage = HurtEvent.DamageAmount;
		if (bleed == "Melee") {
			if (damage == 10 || damage == 15) {
				HurtEvent.DamageAmount = 0;
			}
		}
	}
	else {
		if (FriendOf(HurtEvent.Attacker.SteamID, HurtEvent.Victim.SteamID)) {
			var bleed = HurtEvent.DamageType;
			var damage = HurtEvent.DamageAmount;
			if (bleed == "Melee") {
				if (damage == 10 || damage == 15) {
					HurtEvent.DamageAmount = 0;
				}
			}
		}
	}
}

function On_Command(Player, cmd, args) {
	switch(cmd) {
		case "spikedmg":
			if (args.Length == 0) {
				Player.Message("---SpikeDamage---");
				Player.Message("Makes ur friends not to get dmg from ur spikes");
				Player.Message("/spikedmg - List Commands");
				Player.Message("/spikedmga name - Adds friend to whitelist");
				Player.Message("/spikedmgd name - Deletes friend from whitelist");
				Player.Message("/spikedmgl - Lists Friends in Whitelist");
			}
		break;
		case "spikedmga":
			if (args.Length == 0) {
				Player.Message("Usage: /spikedmga playername");
				return;
			}
			else if (args.Length > 0) {
				var playertor = GetPlayer(args[0]);
				if (playertor != null && playertor != Player) {
					var ini = SpikeL();
					var id = Player.SteamID;
					ini.AddSetting(id, playertor.SteamID, playertor.Name);
					ini.Save();
					Player.Message("Player Whitelisted");
				}
				else {
					Player.Message("Player doesn't exist, or you tried to add yourself!");
				}
			}
		break;
		case "spikedmgd":
			if (args.Length == 0) {
				Player.Message("Usage: /spikedmgd playername");
				return;
			}
			else if (args.Length > 0) {
				var name = args[0];
				var ini = SpikeL();
				var id = Player.SteamID;
				var players = ini.EnumSection(id);
				var i = 0;
				var counted = players.Length;
				name = Data.ToLower(name);
				for (var playerid in players) {
					i++;
					var nameof = ini.GetSetting(id, playerid);
					var lowered = Data.ToLower(nameof);
					if (lowered == name) {
						ini.DeleteSetting(id, playerid);
						ini.Save();
						Player.Message("Player Removed from Whitelist");
						return;
					}
					if (i == counted) {
						Player.Message("Player doesn't exist!");
						return;
					}
				}
			}
		break;
		case "spikedmgl":
			var ini = SpikeL();
			var id = Player.SteamID;
			var players = ini.EnumSection(id);
			for (var playerid in players) {
				var nameof = ini.GetSetting(id, playerid);
				Player.Message("Whitelisted: " + nameof);
			}
		break;
	}
}

function FriendOf(id, selfid){
	var ini = SpikeL();
	var check = ini.GetSetting(id, selfid);
	if (check != null) {
		return true;
	}
	return false;
}

function GetPlayer(name){
	name = Data.ToLower(name);
	for(pl in Server.Players){
		if(Data.ToLower(pl.Name) == name){
			return pl;
		}
	}
	return null;
}

function SpikeL(){
	if(!Plugin.IniExists("SpikeL")) {
		var SpikeL = Plugin.CreateIni("SpikeL");
		SpikeL.Save();
	}
	return Plugin.GetIni("SpikeL");
}