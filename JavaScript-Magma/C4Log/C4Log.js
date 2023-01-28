function On_EntityHurt(HurtEvent) {
	if (HurtEvent.Attacker != null && HurtEvent.Entity != null) {
		if (HurtEvent.Entity.IsStructure() ||  HurtEvent.Entity.IsDeployableObject()) {
			var bleed = HurtEvent.DamageType;
			if (bleed == "Explosion") {
				var weapon = DeathEvent.WeaponName; 
				if (weapon == undefined) {
					var ini = getIni();
					if (HurtEvent.DamageAmount == 600) {
						ini.AddSetting("C4Log", HurtEvent.Attacker.Location.toString(), HurtEvent.Attacker.Name + "|" + System.DateTime.Now + "| C4");
						ini.Save();
					}
					else if (HurtEvent.DamageAmount < 100 && HurtEvent.DamageAmount > 60) {
						ini.AddSetting("GrenadeLog", HurtEvent.Attacker.Location.toString(), HurtEvent.Attacker.Name + "|" + System.DateTime.Now + "| Grenade");
						ini.Save();
					}
				}
			}
		}
	}
}

function getIni(){
	if(!Plugin.IniExists("C4Log")) {
		var ini = Plugin.CreateIni("C4Log");
		ini.AddSetting("C4Log");
		ini.Save();
	}
	return Plugin.GetIni("C4Log");
}
