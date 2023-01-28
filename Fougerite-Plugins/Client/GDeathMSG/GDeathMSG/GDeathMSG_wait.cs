using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GDeathMSG {
    class GDeathMSG_wait : MonoBehaviour {
        private void Update() {
            if (PlayerClient.GetLocalPlayer() != null) {
                GDeathMSG.Instancija.startinam();
                this.enabled = false;
            }
        }
    }
}
