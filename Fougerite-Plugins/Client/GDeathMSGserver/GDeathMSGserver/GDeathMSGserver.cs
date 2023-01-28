using System;
using System.IO;
using Fougerite;
using Fougerite.Events;
using UnityEngine;

namespace GDeathMSGserver {
    public class GDeathMSGserver : Fougerite.Module {
        GameObject MoNo;
        GDeathMSGserver_Mono Mono;
        public static string ModuleFolderis;
        public override string Name {
            get { return "DeathMSG"; }
        }

        public override string Author {
            get { return "DreTaX"; }
        }

        public override string Description {
            get { return "DeathMSG"; }
        }

        public override Version Version {
            get { return new Version("1.1"); }
        }

        public override void Initialize() {
            MoNo = new GameObject();
            Mono = MoNo.AddComponent<GDeathMSGserver_Mono>();
            ModuleFolderis = ModuleFolder;
            Hooks.OnPlayerKilled += Mono.OnPlayerKilled;
            Hooks.OnPlayerSpawned += Mono.OnPlayerSpawned;
            Hooks.OnCommand += Mono.OnCommand;
            Hooks.OnPlayerConnected += Mono.OnPlayerConnect;
            Hooks.OnPlayerDisconnected += Mono.OnPlayerDC;
        }

        public override void DeInitialize() {
            Hooks.OnPlayerKilled -= Mono.OnPlayerKilled;
            Hooks.OnCommand -= Mono.OnCommand;
            Hooks.OnPlayerSpawned -= Mono.OnPlayerSpawned;
            Hooks.OnPlayerConnected -= Mono.OnPlayerConnect;
            Hooks.OnPlayerDisconnected -= Mono.OnPlayerDC;
            if (MoNo != null) UnityEngine.Object.Destroy(MoNo);
        }
    }
}
