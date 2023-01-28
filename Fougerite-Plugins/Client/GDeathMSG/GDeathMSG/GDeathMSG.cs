using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RustBuster2016.API;
using UnityEngine;
using uLink;

namespace GDeathMSG {
    public class GDeathMSG : RustBusterPlugin {
        public GameObject Load;
        public static GDeathMSG Instancija;
        public override string Name { get { return "GDeathMSG GUI"; } }
        public override string Author { get { return " By Gintaras"; } }
        public override Version Version { get { return new Version("1.0"); } }
        private GDeathMSG_GUI guijus;
        public override void Initialize() {
            Caching.expirationDelay = 1;
            Caching.CleanCache();
            Instancija = this;
            Load = new GameObject();
            Load.AddComponent<GDeathMSG_wait>();
            UnityEngine.Object.DontDestroyOnLoad(Load);
        }
        public override void DeInitialize() {
            Caching.expirationDelay = 1;
            Caching.CleanCache();
            if (Load != null) UnityEngine.Object.Destroy(Load);
            if (guijus != null) UnityEngine.Object.Destroy(guijus);
        }
        public void startinam() {
            guijus = PlayerClient.GetLocalPlayer().gameObject.AddComponent<GDeathMSG_GUI>();
            if (Load != null) UnityEngine.Object.Destroy(Load);
        }
        public void RBactivate() {
            Hooks.OnRustBusterClientChat += GDeathMSG_GUI.Instancija.OnChat;
        }
    }
}
