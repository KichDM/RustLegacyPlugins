using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Fougerite;
using Fougerite.Events;
using RustBuster2016Server;
using UnityEngine;
using Random = System.Random;

namespace GEvent {
    public class GEvent : Fougerite.Module {
        public DataStore DataStor = DataStore.GetInstance();
        public static Random Randomizer;

        public const string red = "[color #FF0000]";
        public const string yellow = "[color yellow]";
        public const string green = "[color green]";
        public const string orange = "[color #ffa500]";
        Vector3[] smalas = new Vector3[] { new Vector3(6067,377,-3609),new Vector3(6000,381,-3609),new Vector3(6108,377,-3482), new Vector3(6039,383,-3470),new Vector3(6024,377,-3554), new Vector3(6126,377,-3566),new Vector3(6091,377,-3533)};
        Vector3[] angaras = new Vector3[]{ new Vector3(6648,357,-4182),new Vector3(6688,354,-4222), new Vector3(6723,349,-4244),new Vector3(6732,349,-4279), new Vector3(6635,351,-4327),new Vector3(6545,368,-4288), new Vector3(6564,366,-4270)};
        Vector3[] arenike = new Vector3[]{
            new Vector3(-3398,499,2602),new Vector3(-3391,499,2596),new Vector3(-3384,499,2590),new Vector3(-3375,499,2583),new Vector3(-3367,499,2577),new Vector3(-3360,499,2571),
            new Vector3(-3455,499,2532),new Vector3(-3447,499,2526),new Vector3(-3439,499,2520),new Vector3(-3432,499,2513),new Vector3(-3424,499,2507),new Vector3(-3416,499,2501),
            new Vector3(-3408,499,2495)
        };
        string[] respawneriokit = new string[]{
            "M4","Small Rations","Large Medkit","MP5A4","Shotgun","P250",
            "Kevlar Helmet","Kevlar Vest","Kevlar Pants","Kevlar Boots",
            "556 Ammo","556 Ammo","556 Ammo","9mm Ammo","9mm Ammo",
            "9mm Ammo","Shotgun Shells","Large Medkit","Large Medkit","Large Medkit",
            "Large Medkit","9mm Pistol","F1 Grenade","F1 Grenade","Holo sight",
            "Holo sight","Holo sight","Silencer","Silencer","Silencer",
            "Flashlight Mod","P250","Pick Axe","M4","M4",
            "M4","Bolt Action Rifle","Bolt Action Rifle","MP5A4"
        };
	    int[] respawneriokitq= new int[]{
		    24,20,5,30,8,8,1,1,1,1,
		    250,250,250,250,250,250,250,5,5,5,
		    5,1,5,5,1,1,1,1,1,1,
		    1,8,1,24,24,24,3,3,30
	    };
        string[] respawneriokit2 = new string[]{
            "P250","P250","Large Medkit","Large Medkit","Small Rations","P250",
            "Kevlar Helmet","Kevlar Vest","Kevlar Pants","Kevlar Boots",
            "556 Ammo","556 Ammo","556 Ammo","9mm Ammo","9mm Ammo",
            "9mm Ammo","Shotgun Shells","Large Medkit","Large Medkit","Large Medkit",
            "Large Medkit","9mm Pistol","F1 Grenade","F1 Grenade","Holo sight",
            "Holo sight","Holo sight","Silencer","Silencer","Silencer",
            "Flashlight Mod","P250","Pick Axe","M4","M4",
            "M4","Bolt Action Rifle","Bolt Action Rifle","MP5A4"
        };
        int[] respawneriokitq2 = new int[]{
            8,8,5,5,20,8,1,1,1,1,
            250,250,250,250,250,250,250,5,5,5,
            5,1,5,5,1,1,1,1,1,1,
            1,8,1,24,24,24,3,3,30
        };
        int[] respawneriokits = new int[]{ 31,31,31,31,31,31,36,37,38,39,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        public override string Name {
            get { return "G Event"; }
        }

        public override string Author {
            get { return "Gintaras"; }
        }

        public override string Description {
            get { return "PVP server system"; }
        }

        public override Version Version {
            get { return new Version("1.1"); }
        }

        public override void Initialize() {
            Hooks.OnCommand += OnCommand;
            Hooks.OnPlayerConnected += PConnected;
            Hooks.OnPlayerSpawned += PSpawned;
            API.OnRustBusterUserMessage += OnRustBusterUserMessage;
            Randomizer = new Random();
        }

        public override void DeInitialize() {
            Hooks.OnCommand -= OnCommand;
            Hooks.OnPlayerConnected -= PConnected;
            Hooks.OnPlayerSpawned -= PSpawned;
            API.OnRustBusterUserMessage -= OnRustBusterUserMessage;
        }

        public void PConnected(Fougerite.Player Playe) {
            DataStor.Add("eventas", Playe.SteamID, 0);
            DataStor.Add("kitevent", Playe.SteamID, 0);
        }
        public void PSpawned(Fougerite.Player Playe,SpawnEvent Events) {
            int dataevent, datakit;
            bool events= int.TryParse(DataStor.Get("eventas", Playe.SteamID).ToString(),out dataevent);
            bool kevents = int.TryParse(DataStor.Get("kitevent", Playe.SteamID).ToString(),out datakit);
            if (!events) {dataevent = 0;} 
            if (!kevents) {datakit = 0;}
            kit_setup(Playe, datakit);
            teleportas_eventas(Playe, dataevent);
        }
        public void kit_setup(Fougerite.Player Playe,int sk) {
            Playe.Inventory.ClearAll();
            if (sk == 0) {
                for(int i=0;i<respawneriokit.Length; i++){
                    Playe.Inventory.AddItemTo(respawneriokit[i], respawneriokits[i], respawneriokitq[i]);
                }
            } else {
                for (int i = 0; i < respawneriokit2.Length; i++) {
                    Playe.Inventory.AddItemTo(respawneriokit2[i], respawneriokits[i], respawneriokitq2[i]);
                }
            }
        }
        public void teleportas_eventas(Fougerite.Player Playe, int sk) {
            if(Playe.Health<99f) {
                Playe.MessageFrom("[MCK]", "Cant Teleport if health is <100");
                return;
            }
            Playe.MessageFrom("[MCK]", "Prepare for battle...");
            Vector3 loc = new Vector3(-3625, 1000, 2475);
            Playe.TeleportTo(loc);
            var dict = new Dictionary<string, object>();
            dict["player"] = Playe;
            if (sk==1) {
                TimerSmall(5000, dict).Start();
            } else if (sk==2){
                TimerHangar(5000, dict).Start();
            } else {
                TimerArena(5000, dict).Start();
            }
        }
        public void SmallsCallback(TimedEvent e) {
            var dict = e.Args;
            e.Kill();
            Fougerite.Player Playe = (Fougerite.Player)dict["player"];
            int krenta = Randomizer.Next(0, 7);
            Playe.TeleportTo(smalas[krenta]);
        }
        public void HangarCallback(TimedEvent e) {
            var dict = e.Args;
            e.Kill();
            Fougerite.Player Playe = (Fougerite.Player)dict["player"];
            int krenta = Randomizer.Next(0, 7);
            Playe.TeleportTo(angaras[krenta]);
        }
        public void ArenaCallback(TimedEvent e) {
            var dict = e.Args;
            e.Kill();
            Fougerite.Player Playe = (Fougerite.Player)dict["player"];
            int krenta = Randomizer.Next(0, 13);
            Playe.TeleportTo(arenike[krenta]);
        }
        public void OnCommand(Fougerite.Player playe, string cmd, string[] msg) {
            float hpkiek=playe.Health;
            if (cmd == "small"|| cmd == "hangar"|| cmd == "arena") {
                int kur = 3;
                if(cmd == "small") { kur = 1; } else if(cmd=="hangar") { kur = 2; }
                DataStor.Add("eventas", playe.SteamID, kur);
                teleportas_eventas(playe, kur);
                DataStor.Save();
            } else if(cmd == "kit") {
                if (msg.Length == 0 || msg.Length > 1) {
                    playe.MessageFrom("[MCK]", yellow + "/kit 1 " + orange + "- Default kit");
                    playe.MessageFrom("[MCK]", yellow + "/kit 2 " + orange + "- P250 Pro kit.");
                } else {
                    int rez=1;
                    int.TryParse(msg[0], out rez);
                    if (rez==1) {
                        DataStor.Add("kitevent", playe.SteamID, 0);
                        playe.MessageFrom("[MCK]", yellow + "CHANGED " + orange + "- Default kit");
                        kit_setup(playe, 0);
                    } else {
                        DataStor.Add("kitevent", playe.SteamID, 1);
                        playe.MessageFrom("[MCK]", yellow + "CHANGED " + orange + "- P250 Pro kit.");
                        kit_setup(playe, 1);
                    }
                }
            }
            DataStor.Save();
        }
        public void OnRustBusterUserMessage(API.RustBusterUserAPI user, Message msgc) {
            //Logger.Log("GEVENT TEST: " + msgc.MessageByClient);
            //Logger.Log("DREX TEST: " + msgc.PluginSender);
            if (msgc.PluginSender == "GTPbuttons") {
                string cmd = msgc.MessageByClient;
                if(cmd=="IsAdmin") {
                        msgc.ReturnMessage = user.Player.Admin ? "yes" : "no";
                } else if (cmd == "small" || cmd == "hangar" || cmd == "arena") {
                    int kur = 3;
                    if (cmd == "small") { kur = 1; } else if (cmd == "hangar") { kur = 2; }
                    DataStor.Add("eventas", user.Player.SteamID, kur);
                    teleportas_eventas(user.Player, kur);
                    msgc.ReturnMessage = "yes";
                } else if(cmd == "default") {
                    DataStor.Add("kitevent", user.Player.SteamID, 0);
                    user.Player.MessageFrom("[MCK]", yellow + "CHANGED " + orange + "- Default kit");
                    kit_setup(user.Player, 0);
                    msgc.ReturnMessage = "yes";
                } else if (cmd == "p250") {
                    DataStor.Add("kitevent", user.Player.SteamID, 1);
                    user.Player.MessageFrom("[MCK]", yellow + "CHANGED " + orange + "- P250 Pro kit.");
                    kit_setup(user.Player, 1);
                    msgc.ReturnMessage = "yes";
                }
                DataStor.Save();
            }
        }
        internal TimedEvent TimerSmall(int timeoutDelay, Dictionary<string, object> args) {
            TimedEvent TimedEvents = new TimedEvent(timeoutDelay);
            TimedEvents.Args = args;
            TimedEvents.OnFire += SmallsCallback;
            return TimedEvents;
        }
        internal TimedEvent TimerHangar(int timeoutDelay, Dictionary<string, object> args) {
            TimedEvent TimedEvents = new TimedEvent(timeoutDelay);
            TimedEvents.Args = args;
            TimedEvents.OnFire += HangarCallback;
            return TimedEvents;
        }
        internal TimedEvent TimerArena(int timeoutDelay, Dictionary<string, object> args) {
            TimedEvent TimedEvents = new TimedEvent(timeoutDelay);
            TimedEvents.Args = args;
            TimedEvents.OnFire += ArenaCallback;
            return TimedEvents;
        }
    }
}
