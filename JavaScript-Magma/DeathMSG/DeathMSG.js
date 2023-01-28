/**
 * Created by DreTaX on 2014.04.03.. V1.6
 */
function On_PlayerKilled(DeathEvent) {
	var killer = DeathEvent.Attacker.Name;
	var victim = DeathEvent.Victim.Name;
	var weapon = DeathEvent.WeaponName; 
	var damage = Math.round(DeathEvent.DamageAmount);
	var distance = Util.GetVectorsDistance(DeathEvent.Attacker.Location, DeathEvent.Victim.Location);
	var number = Number(distance).toFixed(2); 
	var bodyPart = BD(DeathEvent.DamageEvent.bodyPart);
	// Check if player is bleeding
	var bleed = DeathEvent.DamageType;
	var ini = Plugin.GetIni("BannedPeopleDM");
	var autoban = Data.GetConfigValue("DeathMSG", "Settings", "autoban");
	var tpfriendsupport = Data.GetConfigValue("DeathMSG", "Settings", "tpfriendsupport");
	if (victim != killer && bleed != null && DeathEvent.Victim != null && DeathEvent.Attacker != null && DeathEvent.Attacker != "undefined" && DeathEvent.Victim != "undefined") {
		if(bleed == "Bullet" && bodyPart != "undefined") {
			if (weapon == "HandCannon") {
				Server.Broadcast(victim + " УБИТ ОТ: " + killer + " ОРУЖИЕ: " + weapon + " ДМГ: " + damage + " ДИСТАНЦИЯ: " + number + "М" + " ПОПАЛ В: " + bodyPart);
				if (autoban == 1) {
					if (tpfriendsupport == 1) {
						var tpfriendcheck = Data.GetTableValue("tp_da", pl.SteamID);
						if (tpfriendcheck == 0) {
							if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
								DeathEvent.Attacker.Kill();
								Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
								ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
								ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
								ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
								ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
								ini.Save();
								DeathEvent.Attacker.Disconnect();
							}
						}
					}
					else {
						if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
							DeathEvent.Attacker.Kill();
							Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
							ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
							ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
							ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
							ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
							ini.Save();
							DeathEvent.Attacker.Disconnect();
						}
					}
				}
			}
			else if (weapon == "Pipe Shotgun") {
				Server.Broadcast(victim + " УБИТ ОТ: " + killer + " ОРУЖИЕ: " + weapon + " ДМГ: " + damage + " ДИСТАНЦИЯ: " + number + "М" + " ПОПАЛ В: " + bodyPart);
				if (autoban == 1) {
					if (tpfriendsupport == 1) {
						var tpfriendcheck = Data.GetTableValue("tp_da", pl.SteamID);
						if (tpfriendcheck == 0) {
							if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
								DeathEvent.Attacker.Kill();
								Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
								ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
								ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
								ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
								ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
								ini.Save();
								DeathEvent.Attacker.Disconnect();
							}
						}
					}
					else {
						if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
							DeathEvent.Attacker.Kill();
							Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
							ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
							ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
							ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
							ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
							ini.Save();
							DeathEvent.Attacker.Disconnect();
						}
					}
				}
			}
			else if (weapon == "Revolver") {
				Server.Broadcast(victim + " УБИТ ОТ: " + killer + " ОРУЖИЕ: " + weapon + " ДМГ: " + damage + " ДИСТАНЦИЯ: " + number + "М" + " ПОПАЛ В: " + bodyPart);
				if (autoban == 1) {
					if (tpfriendsupport == 1) {
						var tpfriendcheck = Data.GetTableValue("tp_da", pl.SteamID);
						if (tpfriendcheck == 0) {
							if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
								DeathEvent.Attacker.Kill();
								Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
								ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
								ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
								ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
								ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
								ini.Save();
								DeathEvent.Attacker.Disconnect();
							}
						}
					}
					else {
						if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
							DeathEvent.Attacker.Kill();
							Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
							ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
							ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
							ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
							ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
							ini.Save();
							DeathEvent.Attacker.Disconnect();
						}
					}
				}
			}
			else if (weapon == "9mm Pistol") {
				Server.Broadcast(victim + " УБИТ ОТ: " + killer + " ОРУЖИЕ: " + weapon + " ДМГ: " + damage + " ДИСТАНЦИЯ: " + number + "М" + " ПОПАЛ В: " + bodyPart);
				if (autoban == 1) {
					if (tpfriendsupport == 1) {
						var tpfriendcheck = Data.GetTableValue("tp_da", pl.SteamID);
						if (tpfriendcheck == 0) {
							if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
								DeathEvent.Attacker.Kill();
								Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
								ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
								ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
								ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
								ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
								ini.Save();
								DeathEvent.Attacker.Disconnect();
							}
						}
					}
					else {
						if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
							DeathEvent.Attacker.Kill();
							Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
							ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
							ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
							ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
							ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
							ini.Save();
							DeathEvent.Attacker.Disconnect();
						}
					}
				}
			}
			else if (weapon == "P250") {
				Server.Broadcast(victim + " УБИТ ОТ: " + killer + " ОРУЖИЕ: " + weapon + " ДМГ: " + damage + " ДИСТАНЦИЯ: " + number + "М" + " ПОПАЛ В: " + bodyPart);
				if (autoban == 1) {
					if (tpfriendsupport == 1) {
						var tpfriendcheck = Data.GetTableValue("tp_da", pl.SteamID);
						if (tpfriendcheck == 0) {
							if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
								DeathEvent.Attacker.Kill();
								Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
								ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
								ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
								ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
								ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
								ini.Save();
								DeathEvent.Attacker.Disconnect();
							}
						}
					}
					else {
						if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
							DeathEvent.Attacker.Kill();
							Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
							ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
							ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
							ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
							ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
							ini.Save();
							DeathEvent.Attacker.Disconnect();
						}
					}
				}
			}
			else if (weapon == "Hunting Bow" || weapon == undefined) {
				Server.Broadcast(victim + " УБИТ ОТ: " + killer + " ОРУЖИЕ: Hunting Bow  ДМГ: " + damage + " ДИСТАНЦИЯ: " + number + "М" + " ПОПАЛ В: " + bodyPart);
				if (autoban == 1) {
					if (tpfriendsupport == 1) {
						var tpfriendcheck = Data.GetTableValue("tp_da", pl.SteamID);
						if (tpfriendcheck == 0) {
							if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
								DeathEvent.Attacker.Kill();
								Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
								ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
								ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
								ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
								ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
								ini.Save();
								DeathEvent.Attacker.Disconnect();
							}
						}
					}
					else {
						if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
							DeathEvent.Attacker.Kill();
							Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
							ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
							ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
							ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
							ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
							ini.Save();
							DeathEvent.Attacker.Disconnect();
						}
					}
				}
			}
			else if (weapon == "Shotgun") {
				Server.Broadcast(victim + " УБИТ ОТ: " + killer + " ОРУЖИЕ: " + weapon + " ДМГ: " + damage + " ДИСТАНЦИЯ: " + number + "М" + " ПОПАЛ В: " + bodyPart);
				if (autoban == 1) {
					if (tpfriendsupport == 1) {
						var tpfriendcheck = Data.GetTableValue("tp_da", pl.SteamID);
						if (tpfriendcheck == 0) {
							if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
								DeathEvent.Attacker.Kill();
								Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
								ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
								ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
								ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
								ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
								ini.Save();
								DeathEvent.Attacker.Disconnect();
							}
						}
					}
					else {
						if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
							DeathEvent.Attacker.Kill();
							Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
							ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
							ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
							ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
							ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
							ini.Save();
							DeathEvent.Attacker.Disconnect();
						}
					}
				}
			}
			else if (weapon == "Bolt Action Rifle") {
				Server.Broadcast(victim + " УБИТ ОТ: " + killer + " ОРУЖИЕ: " + weapon + " ДМГ: " + damage + " ДИСТАНЦИЯ: " + number + "М" + " ПОПАЛ В: " + bodyPart);
				if (autoban == 1) {
					if (tpfriendsupport == 1) {
						var tpfriendcheck = Data.GetTableValue("tp_da", pl.SteamID);
						if (tpfriendcheck == 0) {
							if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
								DeathEvent.Attacker.Kill();
								Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
								ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
								ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
								ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
								ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
								ini.Save();
								DeathEvent.Attacker.Disconnect();
							}
						}
					}
					else {
						if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
							DeathEvent.Attacker.Kill();
							Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
							ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
							ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
							ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
							ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
							ini.Save();
							DeathEvent.Attacker.Disconnect();
						}
					}
				}
			}
			else if (weapon == "M4") {
				Server.Broadcast(victim + " УБИТ ОТ: " + killer + " ОРУЖИЕ: " + weapon + " ДМГ: " + damage + " ДИСТАНЦИЯ: " + number + "М" + " ПОПАЛ В: " + bodyPart);
				if (autoban == 1) {
					if (tpfriendsupport == 1) {
						var tpfriendcheck = Data.GetTableValue("tp_da", pl.SteamID);
						if (tpfriendcheck == 0) {
							if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
								DeathEvent.Attacker.Kill();
								Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
								ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
								ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
								ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
								ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
								ini.Save();
								DeathEvent.Attacker.Disconnect();
							}
						}
					}
					else {
						if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
							DeathEvent.Attacker.Kill();
							Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
							ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
							ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
							ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
							ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
							ini.Save();
							DeathEvent.Attacker.Disconnect();
						}
					}
				}
			}
			else if (weapon == "MP5A4") {
				Server.Broadcast(victim + " УБИТ ОТ: " + killer + " ОРУЖИЕ: " + weapon + " ДМГ: " + damage + " ДИСТАНЦИЯ: " + number + "М" + " ПОПАЛ В: " + bodyPart);
				if (autoban == 1) {
					if (tpfriendsupport == 1) {
						var tpfriendcheck = Data.GetTableValue("tp_da", pl.SteamID);
						if (tpfriendcheck == 0) {
							if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
								DeathEvent.Attacker.Kill();
								Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
								ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
								ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
								ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
								ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
								ini.Save();
								DeathEvent.Attacker.Disconnect();
							}
						}
					}
					else {
						if (number > RangeOf(weapon) && RangeOf(weapon) > 0) {
							DeathEvent.Attacker.Kill();
							Server.Broadcast(killer + " был забанен, в связи с невозможным выстрелом! ");
							ini.AddSetting("Ips", DeathEvent.Attacker.IP, "1");
							ini.AddSetting("Ids", DeathEvent.Attacker.SteamID, "1");
							ini.AddSetting("NameIps", DeathEvent.Attacker.Name, DeathEvent.Attacker.IP);
							ini.AddSetting("NameIds", DeathEvent.Attacker.Name, DeathEvent.Attacker.SteamID);
							ini.Save();
							DeathEvent.Attacker.Disconnect();
						}
					}
				}
			}
		}
		else if (bleed == "Melee") {
			if (weapon == "Hatchet") {
				Server.Broadcast(victim + " УБИТ ОТ: " + killer + " ОРУЖИЕ: " + weapon + " ДМГ: " + damage + " ДИСТАНЦИЯ: " + number + "М" + " ПОПАЛ В: " + bodyPart);
			}
			else if (weapon == "Rock") {
				Server.Broadcast(victim + " УБИТ ОТ: " + killer + " ОРУЖИЕ: " + weapon + " ДМГ: " + damage + " ДИСТАНЦИЯ: " + number + "М" + " ПОПАЛ В: " + bodyPart);
			}
			else if (weapon == "Pick Axe") {
				Server.Broadcast(victim + " УБИТ ОТ: " + killer + " ОРУЖИЕ: " + weapon + " ДМГ: " + damage + " ДИСТАНЦИЯ: " + number + "М" + " ПОПАЛ В: " + bodyPart);
			}
			else if (weapon == "Stone Hatchet") {
				Server.Broadcast(victim + " УБИТ ОТ: " + killer + " ОРУЖИЕ: " + weapon + " ДМГ: " + damage + " ДИСТАНЦИЯ: " + number + "М" + " ПОПАЛ В: " + bodyPart);
			}
		}
		else if (bleed == "Explosion") {
			if (weapon == undefined) {
				Server.Broadcast(victim + " УБИТ ОТ: " + killer + " ОРУЖИЕ: F1 Grenade/C4 ДМГ: " + damage);
			}
		}
		else if (bleed == "Bleeding") {
			Server.Broadcast(victim + " УБИТ КРОВОТЕЧЕНИЕМ. УБИЙЦА: " + killer);
		}
	}
}

function BD(bodyp) {
	var ini = Bodies();
	var name = ini.GetSetting("bodyparts", bodyp);
	return name;
}

function Bodies() {
	if(!Plugin.IniExists("bodyparts"))
		Plugin.CreateIni("bodyparts");
	return Plugin.GetIni("bodyparts");
}

function RangeOf(weapon) {
	var ini = Plugin.GetIni("range");
	var range = ini.GetSetting("range", weapon);
	return range;
}

function On_PlayerConnected(Player)
{
    var ini = Plugin.GetIni("BannedPeopleDM");
	var name = Player.Name;
    var id = Player.SteamID;
	var ip = Player.IP;
	if (ini.GetSetting("Ips", ip) == "1") {
		Player.Message("Вы забанены на этом сервере!");
		Player.Disconnect();
	}
	if (ini.GetSetting("Ids", id) == "1") {
		Player.Message("Вы забанены на этом сервере!");
		Player.Disconnect();
	}
}