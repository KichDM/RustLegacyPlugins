using System;
using System.Runtime.InteropServices;
using UnityEngine;
using RustBuster2016;
using RustBuster2016.API;

namespace GTPbuttons {
    public class GTPbuttons : RustBuster2016.API.RustBusterPlugin {
        public GameObject Load;
        public bool On = true;
        public static GTPbuttons Instance;
        public override string Name {
            get { return "GTPbuttons"; }
        }

        public override string Author {
            get { return "Gintaras"; }
        }

        public override Version Version {
            get { return new Version("1.1"); }
        }
        public override void DeInitialize() {
            UnityEngine.Object.Destroy(Load);
        }

        public override void Initialize() {
            Instance = this;
            Load = new GameObject();
            Load.AddComponent<GTPbuttonsGUI>();
            UnityEngine.Object.DontDestroyOnLoad(Load);
        }
    }
}