using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GSoundkill {
    class GSoundkill_wait:MonoBehaviour {
        private void Update() {
            if (PlayerClient.GetLocalPlayer() != null) {
                GSoundkill.Instancija.startinam();
                this.enabled = false;
            }
        }
    }
}
