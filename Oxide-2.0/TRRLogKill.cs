using System;
using UnityEngine;
using Oxide.Core;
using System.Collections.Generic;
using RustExtended;
using Oxide.Core.Libraries;
namespace Oxide.Plugins
{
    [Info("TRR Logger Kills", "Hostfun", "1.2.5")]
    class TRRLogKill : RustLegacyPlugin
    {
        void OnKilled(TakeDamage damage, DamageEvent evt)
        {
            if (evt.attacker.client == null || evt.victim.client == null) return;
            if (evt.attacker.client.userID != evt.victim.client.userID && damage is HumanBodyTakeDamage)
            {
                string weaponName = ""; if (evt.extraData as WeaponImpact != null) weaponName = (evt.extraData as WeaponImpact).dataBlock.name;
                if ((evt.extraData as WeaponImpact) == null && evt.damageTypes == DamageTypeFlags.damage_melee) weaponName = "Hunting Bow";
                if ((evt.extraData as WeaponImpact) == null && evt.damageTypes != DamageTypeFlags.damage_melee) weaponName = "Кровотечение";
                string bodyPart = evt.bodyPart.GetNiceName();
                RustExtended.Config.Get("BODYPART." + (Users.GetBySteamID(evt.attacker.userID) == null ? RustExtended.Core.Languages[0] : Users.GetBySteamID(evt.attacker.userID).Language), bodyPart, ref bodyPart);
                double distance = Math.Round(Vector3.Distance(evt.attacker.id.transform.position, evt.victim.id.transform.position));
                var user1 = Users.GetBySteamID(evt.attacker.userID); string abbr1 = ""; if (user1.Clan != null && user1.Clan.Abbr != "") abbr1 = "<" + user1.Clan.Abbr + ">";
                var user2 = Users.GetBySteamID(evt.victim.userID); string abbr2 = ""; if (user2.Clan != null && user2.Clan.Abbr != "") abbr2 = "<" + user2.Clan.Abbr + ">";
                Debug.Log("[КИЛЛ ЛОГ] "+user1.Username + " убил " + user2.Username + " в " + bodyPart + " c " + weaponName + " (Дистанция  " + distance.ToString() + "м)");
            }
        }
	}
}