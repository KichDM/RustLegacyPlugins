function On_EntityHurt(HurtEvent)
{
	if (HurtEvent.Attacker != null && HurtEvent.Entity != null && !HurtEvent.IsDecay && HurtEvent.Attacker.SteamID != null) {
		var entityname = HurtEvent.Entity.Name.toString();
		if (entityname == "WoodBoxLarge" || entityname == "WoodBox" || entityname == "SmallStash") {
			var ini = ChestLog();
			var name = HurtEvent.Attacker.Name.toString();
			var id = HurtEvent.Attacker.SteamID.toString();
			var time = System.DateTime.Now.toString();
			var loc = HurtEvent.Attacker.Location.toString();
			var entityloc = Util.CreateVector(HurtEvent.Entity.X, HurtEvent.Entity.Y, HurtEvent.Entity.Z);
			ini.AddSetting("ChestLog", entityloc.toString(), entityname + "|" + id + "|" + name + "|" + time + "|" + loc);
			ini.Save();
		}
	}
}

function ChestLog()
{
	if(!Plugin.IniExists("ChestLog")) {
		var ini = Plugin.CreateIni("ChestLog");
		ini.Save();
	}
	return Plugin.GetIni("ChestLog");
}