using System.Collections.Generic;
using System;
using UnityEngine;
using Oxide.Core;
using System.Collections;
using RustExtended;

namespace Oxide.Plugins
{
    [Info("Animality", "XBOCT", "1.1.0")]
	[Description("Мешок с лутом для медведей и волков")]
    class Animality : RustLegacyPlugin
    {
        public float GetGround(float x, float y, float z)
        {
            RaycastHit hit;
            var origin = new Vector3(x, y, z);
            float ground = 0f;
            if (Physics.Raycast(origin, Vector3.down, out hit, 10f)) {ground = hit.point.y;}
            return ground;
        }

        #region [HOOK] [OnKilled] 
        void OnKilled(TakeDamage damage, DamageEvent evt)
        {
            if (evt.amount < damage.health) return;

            NetUser netUser = evt.attacker.client?.netUser ?? null;
            if (netUser == null) return;
            if (damage is HumanBodyTakeDamage) return;

            Character victim = evt.victim.character ?? null;
            if (victim != null && Helper.NiceName(victim.name) == "Bear" | Helper.NiceName(victim.name) == "Wolf")
            {
                float x = victim.transform.position.x - 1.8f;
                float y = victim.transform.position.y;
                float z = victim.transform.position.z;

                y = GetGround(x, y, z);

                World.Spawn(";drop_lootsack_zombie", x, y, z);
            }
        }
        #endregion
    }
}
