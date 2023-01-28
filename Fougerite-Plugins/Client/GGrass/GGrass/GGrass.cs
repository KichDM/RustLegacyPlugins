using System;
using System.Runtime.InteropServices;
using UnityEngine;
using RustBuster2016.API;
namespace GGrass {
    public class GGrass : RustBusterPlugin {
        public GameObject Load;
        public bool On = true;

        public override string Name {
            get { return "G Grass"; }
        }

        public override string Author {
            get { return "Gintaras"; }
        }

        public override Version Version {
            get { return new Version("1.0"); }
        }


        public override void DeInitialize() {
            if (Load != null) UnityEngine.Object.Destroy(Load);
        }

        public override void Initialize() {
            Load = new GameObject();
            Load.AddComponent<GGrassGUI>();
            UnityEngine.Object.DontDestroyOnLoad(Load);
        }
    }
}