using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace FPSDiplay
{
    public class FPSDisplay : RustBuster2016.API.RustBusterPlugin
    {
        public FPSDisplayM test;
        public GameObject Load;
        public bool On = true;

        public override string Name
        {
            get { return "FPSDisplay"; }
        }

        public override string Author
        {
            get { return "DreTaX"; }
        }

        public override Version Version
        {
            get { return new Version("1.0"); }
        }


        public override void DeInitialize()
        {
            RustBuster2016.API.Hooks.OnRustBusterClientConsole -= OnRustBusterClientConsole;
            if (Load != null) UnityEngine.Object.Destroy(Load);
        }

        public override void Initialize()
        {
            RustBuster2016.API.Hooks.OnRustBusterClientConsole += OnRustBusterClientConsole;
            Load = new GameObject();
            test = Load.AddComponent<FPSDisplayM>();
            UnityEngine.Object.DontDestroyOnLoad(Load);
        }

        public void OnRustBusterClientConsole(string msg)
        {
            if (msg == "rb.fps")
            {
                if (On)
                {
                    Load.SetActive(false);
                    On = false;
                }
                else
                {
                    On = true;
                    Load.SetActive(true);
                }
            }
        }
    }
}
