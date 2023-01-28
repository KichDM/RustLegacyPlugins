using System;
using System.IO;
using Fougerite;
using Fougerite.Events;
using UnityEngine;
using uLink;
namespace GDeathMSGserver {
    public class GDeathMSGserver_Mono : UnityEngine.MonoBehaviour {
        public IniParser Config;
        public IniParser Bodies;
        public IniParser Range;

        public string DeathMSGName;
        public string Bullet;
        public string animal;
        public string suicide;
        public string sleeper;
        public string huntingbow;
        public string banmsg;
        public string tpamsg;
        public string spike;
        public string explosion;
        public string bleeding;
        public string tpbackmsg;

        public const string red = "[color #FF0000]";
        public const string green = "[color #009900]";

        public int KillLog;
        public int ean;
        public int esn;
        public int autoban;
        public int essn;
        public int dkl;
        public System.IO.StreamWriter file;

        public void Start() {
            if (!File.Exists(Path.Combine(GDeathMSGserver.ModuleFolderis, "KillLog.log"))) {
                File.Create(Path.Combine(GDeathMSGserver.ModuleFolderis, "KillLog.log")).Dispose();
            }
            LoadConfig();
        }
        public void OnPlayerSpawned(Fougerite.Player player, SpawnEvent se) {
            if (player != null) {
                if (DataStore.GetInstance().Get("tpfriendautoban", player.UID) != null) { DataStore.GetInstance().Remove("tpfriendautoban", player.UID); }
                if (DataStore.GetInstance().Get("homesystemautoban", player.UID) != null) { DataStore.GetInstance().Remove("homesystemautoban", player.UID); }
                if (DataStore.GetInstance().Get("DeathMSGBAN", player.UID) != null) {
                    string get = (string)DataStore.GetInstance().Get("DeathMSGBAN", player.UID);
                    Vector3 loc = Util.GetUtil().ConvertStringToVector3(get);
                    player.TeleportTo(loc);
                    player.MessageFrom(DeathMSGName, green + tpbackmsg);
                    DataStore.GetInstance().Remove("DeathMSGBAN", player.UID);
                }
            }
        }

        public void Log(string killer, string weapon, string distance, string victim,
            string bodypart, string damage, int tp, string loca, string locv, string avg = "Not Available") {
            string line = DateTime.Now + " Killer: " + killer + " Gun: " + weapon + " Dist: " + distance + " Victim: " +
                          victim + " BodyP: " + bodypart + " DMG: " + damage + " LocA: " + loca + " LocV: " + locv
                          + " " + avg;
            if (tp == 1) {
                line = line + " WAS TELEPORTING";
            }
            file = new System.IO.StreamWriter(Path.Combine(GDeathMSGserver.ModuleFolderis, "KillLog.log"), true);
            file.WriteLine(line);
            file.Close();
        }

        public void LoadConfig() {
            Config = new IniParser(Path.Combine(GDeathMSGserver.ModuleFolderis, "Settings.ini"));
            Range = new IniParser(Path.Combine(GDeathMSGserver.ModuleFolderis, "Range.ini"));
            Bodies = new IniParser(Path.Combine(GDeathMSGserver.ModuleFolderis, "Bodies.ini"));
            DeathMSGName = Config.GetSetting("Settings", "DeathMSGName");
            Bullet = Config.GetSetting("Settings", "msg");
            KillLog = int.Parse(Config.GetSetting("Settings", "killog"));
            ean = int.Parse(Config.GetSetting("Settings", "enableanimalmsg"));
            animal = Config.GetSetting("Settings", "animalkill");
            esn = int.Parse(Config.GetSetting("Settings", "enablesuicidemsg"));
            suicide = Config.GetSetting("Settings", "suicide");
            autoban = int.Parse(Config.GetSetting("Settings", "autoban"));
            essn = int.Parse(Config.GetSetting("Settings", "enablesleepermsg"));
            dkl = int.Parse(Config.GetSetting("Settings", "displaykilllog"));
            sleeper = Config.GetSetting("Settings", "SleeperKill");
            huntingbow = Config.GetSetting("Settings", "huntingbow");
            banmsg = Config.GetSetting("Settings", "banmsg");
            tpamsg = Config.GetSetting("Settings", "TpaMsg");
            spike = Config.GetSetting("Settings", "spike");
            explosion = Config.GetSetting("Settings", "explosionmsg");
            bleeding = Config.GetSetting("Settings", "bmsg");
            tpbackmsg = Config.GetSetting("Settings", "tpbackmsg");
        }

        public void OnCommand(Fougerite.Player player, string cmd, string[] args) {
            if (cmd == "flushdeathmsg") {
                if (player.Admin) {
                    DataStore.GetInstance().Flush("DeathMSGAVG");
                    DataStore.GetInstance().Flush("DeathMSGAVG2");
                    player.MessageFrom(DeathMSGName, "Flushed!");
                }
            } else if (cmd == "deathmsgrd") {
                if (player.Admin) {
                    LoadConfig();
                    player.MessageFrom(DeathMSGName, "Reloaded!");
                }
            } else if (cmd == "deathmsgscore") {
                if (player.Admin) {
                    DataStore.GetInstance().Flush("DeathMSGkills");
                    DataStore.GetInstance().Flush("DeathMSGdeaths");
                }
            } else if (cmd== "dtest") {
                SendRPCblet(player.Name, player.Name, "bleed", "none", 0.0);
                player.MessageFrom("[testas]", "testas");
            } else if (cmd == "score") {
                int kills=(int)DataStore.GetInstance().Get("DeathMSGkills", player.UID);
                int deaths=(int)DataStore.GetInstance().Get("DeathMSGdeaths", player.UID);
                player.MessageFrom("[Score]", "Your kill death ratio: [color #75ff75]" + kills.ToString() + "[color #FFFFFF]|[color #ff7580]" + deaths.ToString() + "[color #FFFFFF] /score");
            }
        }
        public void OnPlayerConnect(Fougerite.Player pl) {
            int kills, deaths;
            if (DataStore.GetInstance().Get("DeathMSGkills", pl.UID) == null) {
                DataStore.GetInstance().Add("DeathMSGkills", pl.UID, 0);
                kills = 0;
            } else {
                kills = (int)DataStore.GetInstance().Get("DeathMSGkills", pl.UID);
            }
            if (DataStore.GetInstance().Get("DeathMSGdeaths", pl.UID) == null) {
                DataStore.GetInstance().Add("DeathMSGdeaths", pl.UID, 0);
                deaths = 0;
            } else {
                deaths = (int)DataStore.GetInstance().Get("DeathMSGdeaths", pl.UID);
            }

            Server.GetServer().Broadcast("Joined: [color #75ff75]" + pl.Name + "[color #FFFFFF] Score: [color #75ff75]" + kills.ToString() + "[color #FFFFFF]|[color #ff7580]" + deaths.ToString() + "[color #FFFFFF] /score");
            if (pl.Admin) {
                Server.GetServer().Broadcast(red + "Your Lord and Savior Gintaras come to help!");
            }
        }
        public void OnPlayerDC(Fougerite.Player pl) {
            int kills, deaths;
            if (DataStore.GetInstance().Get("DeathMSGkills", pl.UID) == null) {
                DataStore.GetInstance().Add("DeathMSGkills", pl.UID, 0);
                kills = 0;
            } else {
                kills = (int)DataStore.GetInstance().Get("DeathMSGkills", pl.UID);
            }
            if (DataStore.GetInstance().Get("DeathMSGdeaths", pl.UID) == null) {
                DataStore.GetInstance().Add("DeathMSGdeaths", pl.UID, 0);
                deaths = 0;
            } else {
                deaths = (int)DataStore.GetInstance().Get("DeathMSGdeaths", pl.UID);
            }
            Server.GetServer().Broadcast("Disconnected: [color #75ff75]" + pl.Name + "[color #FFFFFF] Score: [color #75ff75]" + kills.ToString() + "[color #FFFFFF]|[color #ff7580]" + deaths.ToString());
        }
        public void AddScore(Fougerite.Player Att,Fougerite.Player vic) {
            int kills, deaths,vkills,kdeaths;
            if (DataStore.GetInstance().Get("DeathMSGkills", Att.UID) == null) {
                DataStore.GetInstance().Add("DeathMSGkills", Att.UID, 0);
                kills = 0;
            } else {
                kills = (int)DataStore.GetInstance().Get("DeathMSGkills", Att.UID);
            }
            if (DataStore.GetInstance().Get("DeathMSGdeaths", Att.UID) == null) {
                DataStore.GetInstance().Add("DeathMSGdeaths", Att.UID, 0);
                kdeaths = 0;
            } else {
                kdeaths = (int)DataStore.GetInstance().Get("DeathMSGdeaths", Att.UID);
            }
            if (DataStore.GetInstance().Get("DeathMSGkills", vic.UID) == null) {
                DataStore.GetInstance().Add("DeathMSGkills", vic.UID, 0);
                vkills = 0;
            } else {
                vkills = (int)DataStore.GetInstance().Get("DeathMSGkills", vic.UID);
            }
            if (DataStore.GetInstance().Get("DeathMSGdeaths", vic.UID) == null) {
                DataStore.GetInstance().Add("DeathMSGdeaths", vic.UID, 0);
                deaths = 0;
            } else {
                deaths = (int)DataStore.GetInstance().Get("DeathMSGdeaths", vic.UID);
            }
            DataStore.GetInstance().Add("DeathMSGkills", Att.UID, (kills+1));
            DataStore.GetInstance().Add("DeathMSGdeaths", vic.UID, (deaths + 1));
            Debug.Log(Att.Name+"-->"+vic.Name);
            Att.MessageFrom("[Score]", "Your score: [color #75ff75]" + kills.ToString() + "[color #FFFFFF]|[color #ff7580]" + kdeaths.ToString() + "[color #FFFFFF]");
            vic.MessageFrom("[Score]", "Your score: [color #75ff75]" + vkills.ToString() + "[color #FFFFFF]|[color #ff7580]" + deaths.ToString() + "[color #FFFFFF]");
        }
        public int RangeOf(string weapon) {
            var data = Range.GetSetting("range", weapon);
            if (data == null) {
                return -1;
            }
            return int.Parse(data);
        }
        public void OnPlayerKilled(DeathEvent de) {
            if (de.DamageType != null && de.Attacker != null && de.Victim != null &&
                (de.AttackerIsPlayer || de.AttackerIsNPC || de.AttackerIsEntity)) {
                Fougerite.Player victim = (Fougerite.Player)de.Victim;
                string victimname = victim.Name;
                if (de.AttackerIsNPC) {
                    return;
                } else if (de.AttackerIsPlayer) {
                    Fougerite.Player attacker = (Fougerite.Player)de.Attacker;
                    ulong vid = victim.UID;
                    ulong aid = attacker.UID;
                    if (vid == aid) {
                        return;
                    }
                    string weapon = de.WeaponName;
                    string bodyPart = Bodies.GetSetting("bodyparts", de.DamageEvent.bodyPart.ToString());
                    Vector3 killerloc = attacker.Location;
                    Vector3 location = victim.Location;
                    double distance = Math.Round(Vector3.Distance(killerloc, location));
                    double damage = Math.Round(de.DamageAmount);
                    string bleed = de.DamageType;
                    if (bleed == "Bullet") {
                        string message;
                        if (de.VictimIsSleeper) {
                            return;
                        } else {
                            message = Bullet;
                        }
                        string n = message.Replace("victim", victimname);
                        n = n.Replace("killer", attacker.Name);
                        n = n.Replace("weapon", weapon);
                        n = n.Replace("damage", damage.ToString());
                        n = n.Replace("number", distance.ToString());
                        n = n.Replace("bodyPart", bodyPart);
                        int c = 0;
                        string calc = "Not Available";
                        if (bodyPart == "Head") {
                            if (DataStore.GetInstance().Get("DeathMSGAVG", attacker.UID) == null) {
                                DataStore.GetInstance().Add("DeathMSGAVG", attacker.UID, 1);
                                c = 1;
                            } else {
                                c = (int)DataStore.GetInstance().Get("DeathMSGAVG", attacker.UID) + 1;
                                DataStore.GetInstance().Add("DeathMSGAVG", attacker.UID, c);
                            }
                        } else {
                            if (DataStore.GetInstance().Get("DeathMSGAVG2", attacker.UID) == null) {
                                DataStore.GetInstance().Add("DeathMSGAVG2", attacker.UID, 1);
                                c = 1;
                            } else {
                                c = (int)DataStore.GetInstance().Get("DeathMSGAVG2", attacker.UID) + 1;
                                DataStore.GetInstance().Add("DeathMSGAVG2", attacker.UID, c);
                            }

                        }
                        if (c >= 5) {
                            object cd = DataStore.GetInstance().Get("DeathMSGAVG2", attacker.UID);
                            if (cd != null) {
                                int cd2 = (int)cd;
                                double cc = c / cd2;
                                calc = Math.Round(cc).ToString();
                                n = n + " (HAvg: " + calc + "% )";
                            }
                        }
                        //Server.GetServer().BroadcastFrom(DeathMSGName, n);
                        SendRPCblet(attacker.Name, victimname, weapon, bodyPart, distance);
                        AddScore(attacker, victim);
                        if (autoban == 1) {
                            int range = RangeOf(weapon);
                            if (range == -1 || weapon.ToLower().Contains("spike")) {
                                return;
                            }
                            if (distance > range) {
                                var tpfriendteleport = DataStore.GetInstance().Get("tpfriendautoban", aid);
                                var hometeleport = DataStore.GetInstance().Get("homesystemautoban", aid);
                                if (hometeleport == null || string.IsNullOrEmpty((string)hometeleport)
                                    || (string)hometeleport == "none"
                                    || tpfriendteleport == null || string.IsNullOrEmpty((string)tpfriendteleport)
                                    || (string)tpfriendteleport == "none") {
                                    string z = banmsg;
                                    z = z.Replace("killer", attacker.Name);
                                    if (distance >= 1000) {
                                        return;
                                    }
                                    if (KillLog == 1) {
                                        Log(attacker.Name, weapon, distance.ToString(), victimname, bodyPart,
                                            damage.ToString(),
                                            0, killerloc.ToString(), location.ToString(), calc);
                                    }
                                    DataStore.GetInstance().Add("DeathMSGBAN", vid, location);
                                    Server.GetServer().BroadcastFrom(DeathMSGName, red + z);
                                    Server.GetServer()
                                        .BanPlayer(attacker, "Console", "Range Ban: " + distance + " Gun: " +
                                                                        weapon);
                                } else {
                                    string t = tpamsg;
                                    t = t.Replace("killer", attacker.Name);
                                    if (distance >= 1000) {
                                        return;
                                    }
                                    if (KillLog == 1) {
                                        Log(attacker.Name, weapon, distance.ToString(), victimname, bodyPart,
                                            damage.ToString(),
                                            1, killerloc.ToString(), location.ToString(), calc);
                                    }
                                    Server.GetServer().BroadcastFrom(DeathMSGName, t);
                                    DataStore.GetInstance().Remove("tpfriendautoban", aid);
                                    DataStore.GetInstance().Remove("homesystemautoban", aid);
                                }
                                return;
                            }
                        }
                        if (KillLog == 1) {
                            Log(attacker.Name, weapon, distance.ToString(), victimname, bodyPart,
                                damage.ToString(),
                                0, killerloc.ToString(), location.ToString(), calc);
                        }
                    } else if (bleed == "Melee") {
                        string hn = huntingbow;
                        if (weapon == "Hunting Bow") {
                            if (de.VictimIsSleeper) {
                                return;
                            }
                            hn = hn.Replace("victim", victimname);
                            hn = hn.Replace("killer", attacker.Name);
                            hn = hn.Replace("damage", damage.ToString());
                            hn = hn.Replace("number", distance.ToString());
                            hn = hn.Replace("bodyPart", bodyPart);
                            //Server.GetServer().BroadcastFrom(DeathMSGName, hn);
                            SendRPCblet(attacker.Name, victimname, weapon, bodyPart, distance);
                            AddScore(attacker, victim);
                            if (autoban == 1) {
                                int range = RangeOf(weapon);
                                if (range == -1 || weapon.ToLower().Contains("spike")) {
                                    return;
                                }
                                if (distance > range) {
                                    var tpfriendteleport = DataStore.GetInstance().Get("tpfriendautoban", aid);
                                    var hometeleport = DataStore.GetInstance().Get("homesystemautoban", aid);
                                    if (hometeleport == null || string.IsNullOrEmpty((string)hometeleport)
                                    || (string)hometeleport == "none"
                                    || tpfriendteleport == null || string.IsNullOrEmpty((string)tpfriendteleport)
                                    || (string)tpfriendteleport == "none") {
                                        string z = banmsg;
                                        z = z.Replace("killer", attacker.Name);
                                        if (distance >= 1000) {
                                            return;
                                        }
                                        if (KillLog == 1) {
                                            Log(attacker.Name, weapon, distance.ToString(), victimname, bodyPart,
                                                damage.ToString(),
                                                0, killerloc.ToString(), location.ToString());
                                        }
                                        DataStore.GetInstance().Add("DeathMSGBAN", vid, location);
                                        Server.GetServer().BroadcastFrom(DeathMSGName, red + z);
                                        Server.GetServer()
                                            .BanPlayer(attacker, "Console", "Range Ban: " + distance + " Gun: " +
                                                                            weapon);
                                    } else {
                                        string t = tpamsg;
                                        t = t.Replace("killer", attacker.Name);
                                        if (distance >= 1000) {
                                            return;
                                        }
                                        if (KillLog == 1) {
                                            Log(attacker.Name, weapon, distance.ToString(), victimname, bodyPart,
                                                damage.ToString(),
                                                1, killerloc.ToString(), location.ToString());
                                        }
                                        Server.GetServer().BroadcastFrom(DeathMSGName, t);
                                        DataStore.GetInstance().Remove("tpfriendautoban", aid);
                                        DataStore.GetInstance().Remove("homesystemautoban", aid);
                                    }
                                    return;
                                }
                            }
                            if (KillLog == 1) {
                                Log(attacker.Name, weapon, distance.ToString(), victimname, bodyPart,
                                    damage.ToString(),
                                    0, killerloc.ToString(), location.ToString());
                            }
                        } else if (weapon == "Spike Wall" && de.AttackerIsEntity) {
                            string ownername = de.Entity.OwnerName;
                            string s = spike;
                            s = s.Replace("victim", victimname);
                            s = s.Replace("killer", ownername);
                            s = s.Replace("weapon", "Spike Wall");
                            Server.GetServer().BroadcastFrom(DeathMSGName, s);
                        } else if (weapon == "Large Spike Wall" && de.AttackerIsEntity) {
                            string ownername = de.Entity.OwnerName;
                            string s = spike;
                            s = s.Replace("victim", victimname);
                            s = s.Replace("killer", ownername);
                            s = s.Replace("weapon", "Spike Wall");
                            Server.GetServer().BroadcastFrom(DeathMSGName, s);
                        } else {
                            string n = Bullet;
                            n = n.Replace("victim", victimname);
                            n = n.Replace("killer", attacker.Name);
                            n = n.Replace("weapon", weapon);
                            n = n.Replace("damage", damage.ToString());
                            n = n.Replace("number", distance.ToString());
                            n = n.Replace("bodyPart", bodyPart);
                            //Server.GetServer().BroadcastFrom(DeathMSGName, n);
                            SendRPCblet(attacker.Name, victimname, weapon, bodyPart, distance);
                            AddScore(attacker, victim);
                        }
                    } else if (bleed == "Explosion") {
                        string x = explosion;
                        x = x.Replace("killer", attacker.Name);
                        x = x.Replace("victim", victimname);
                        if (weapon == "F1 Grenade") {
                            x = x.Replace("weapon", "F1 Grenade");
                        } else if (weapon == "Explosive Charge") {
                            x = x.Replace("weapon", "C4");
                        }
                        //Server.GetServer().BroadcastFrom(DeathMSGName, x);
                        SendRPCblet(attacker.Name, victimname, weapon, "none", 0.0);
                        AddScore(attacker, victim);
                    } else if (bleed == "Bleeding") {
                        string n = bleeding;
                        n = n.Replace("victim", victimname);
                        n = n.Replace("killer", attacker.Name);
                        //Server.GetServer().BroadcastFrom(DeathMSGName, n);
                        SendRPCblet(attacker.Name, victimname, "bleed", "none", 0.0);
                        AddScore(attacker, victim);
                    }
                }
            }
        }
        public void SendRPCblet(string att_name, string vic_name, string weapon, string part, double distance) {
            string weap;
            bool head = false;
            if (weapon == "M4") { weap = "m4a1"; } else if (weapon == "MP5A4") { weap = "ump45"; } else if (weapon == "9mm Pistol") { weap = "fseven";
            } else if (weapon == "Bolt Action Rifle") { weap = "scout"; } else if (weapon == "P250") { weap = "p250";
            } else if (weapon == "Revolver") { weap = "revolver"; } else if (weapon == "Pipe Shotgun") { weap = "nova";
            } else if (weapon == "Pick Axe") { weap = "khuntsman"; } else if (weapon == "Explosive Charge") { weap = "c4";
            } else if (weapon == "F1 Grenade") { weap = "granade"; } else if (weapon == "Hand Cannon") { weap = "mag7";
            } else if (weapon == "Hatchet") { weap = "kgut"; } else if (weapon == "Shotgun") { weap = "xm1014"; } else if (weapon == "bleed") { weap = "kshadow";
            } else { weap = "kkarambit"; }
            if (part == "Head") {
                head = true;
            }
            if (att_name.Length > 12) att_name = att_name.Substring(0, 12);
            if (vic_name.Length > 12) vic_name = vic_name.Substring(0, 12);
            //uLink.NetworkView networkvi = GetComponent<Facepunch.NetworkView>();
            //networkView.RPC("GDeathmessage", UnityEngine.RPCMode.Others, att_name, vic_name, weap, head, Convert.ToInt32(distance));
            foreach (Fougerite.Player pla in Server.GetServer().Players) {
                if(pla.PlayerClient.networkView!=null) {
                    uLink.NetworkView.Get(pla.PlayerClient.networkView).RPC("GDeathMessage", pla.NetworkPlayer, att_name, vic_name, weap, head, Convert.ToInt32(distance));
                }
            }
            //uLink.NetworkViewBase.RPC("GDeathmessage", uLink.RPCMode.Others, att_name, vic_name, weap, head, Convert.ToInt32(distance));
        }
    }
}
