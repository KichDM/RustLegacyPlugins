using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Fougerite;
using Fougerite.Events;
using RustBuster2016Server;
using UnityEngine;
using uLink;

namespace GSoundkillserver {
    public class GSoundkillserver : Fougerite.Module {
        GameObject MoNo;
        GSoundkillserver_Mono Mono;
        public override string Name {
            get { return "GSound kill server"; }
        }

        public override string Author {
            get { return "Gintaras"; }
        }

        public override string Description {
            get { return "PVP sound system"; }
        }

        public override Version Version {
            get { return new Version("1.0"); }
        }

        public override void Initialize() {
            MoNo = new GameObject();
            Mono = MoNo.AddComponent<GSoundkillserver_Mono>();
            API.OnRustBusterLogin += Mono.OnRustBusterLogin;
            Fougerite.Hooks.OnPlayerSpawned += Mono.OnPlayerSpawned;
            Fougerite.Hooks.OnPlayerKilled += Mono.PlayerKilled;
            Fougerite.Hooks.OnPlayerDisconnected += Mono.OnPlayerDc;
            Fougerite.Hooks.OnPlayerConnected += Mono.OnPlConnect;
        }

        public override void DeInitialize() {
            API.OnRustBusterLogin -= Mono.OnRustBusterLogin;
            Fougerite.Hooks.OnPlayerSpawned -= Mono.OnPlayerSpawned;
            Fougerite.Hooks.OnPlayerKilled -= Mono.PlayerKilled;
            Fougerite.Hooks.OnPlayerDisconnected -= Mono.OnPlayerDc;
            Fougerite.Hooks.OnPlayerConnected -= Mono.OnPlConnect;
            if (MoNo != null) UnityEngine.Object.Destroy(MoNo);
        }
    }
}
