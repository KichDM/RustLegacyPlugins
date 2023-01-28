// Reference: NBSLegacy

using NBSLegacy;
using Oxide.Core;
using System;
namespace Oxide.Plugins {
    [Info ("Itens", "PionixZ", "1.0.2")]
    public class Itens : RustLegacyPlugin {
        private object OnKilled (TakeDamage takeDamage, DamageEvent damageEvent) {
            
                DamageTypeFlags damageTypeList = damageEvent.damageTypes;
                if (damageTypeList != DamageTypeFlags.damage_generic)
                {
                    DeployableObject deployableObject = damageEvent.victim.id.GetComponent<DeployableObject>();
                    if (deployableObject != null)
                    {
                        var inventory = damageEvent.victim.id.GetComponent<Inventory>();
                        EntityInventory entityInventory = new EntityInventory(inventory);
                        if (entityInventory != null)
                        {
                            entityInventory.DropAllItems();
                        }
                    }
                }
           
            return false;
        }
    }
}