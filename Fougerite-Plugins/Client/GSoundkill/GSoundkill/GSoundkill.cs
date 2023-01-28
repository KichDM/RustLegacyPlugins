using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RustBuster2016.API;
using UnityEngine;
using uLink;

namespace GSoundkill {
    public class GSoundkill : RustBusterPlugin {
        public GameObject Load;
        public static GSoundkill Instancija;
        public override string Name { get { return "GSounds for kills"; } }
        public override string Author { get { return " By Gintaras"; } }
        public override Version Version { get { return new Version("1.0"); } }
        public override void Initialize() {
            Instancija = this;
            Load = new GameObject();
            Load.AddComponent<GSoundkill_wait>();
            UnityEngine.Object.DontDestroyOnLoad(Load);
        }
        public override void DeInitialize() {
            if (Load != null) UnityEngine.Object.Destroy(Load);
        }
        public void startinam() {
            PlayerClient.GetLocalPlayer().gameObject.AddComponent<GSoundkill_GUI>();
            if (Load != null) UnityEngine.Object.Destroy(Load);
        }
    }
}