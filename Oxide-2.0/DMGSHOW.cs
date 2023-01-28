using System.Reflection;
using Oxide.Core;
using Oxide.Core.Plugins;

namespace Oxide.Plugins
{
[Info("DMGSHOW", "Atamg", "1.0.3")]
class DMGSHOW : RustLegacyPlugin
{
object cachedValue;
string hurted = "";
string hurtedId = "";
string killerId = "";
string UNKNOWN = "UNKNOWN";
string killer = "";


object ModifyDamage(TakeDamage takedamage, DamageEvent damage)
{
killerId = damage.attacker.client?.netUser.userID.ToString() ?? UNKNOWN;
killer = damage.attacker.client?.netUser.displayName ?? UNKNOWN;
NetUser killeruser = damage.attacker.client?.netUser ?? null;
NetUser hurteduser = damage.victim.client?.netUser ?? null;
hurted = damage.victim.client?.netUser.displayName ?? UNKNOWN;
hurtedId = damage.victim.client?.netUser.userID.ToString() ?? UNKNOWN;
cachedValue = Interface.CallHook("isFriend", killerId, hurtedId);
if(damage.amount >= 1f && killeruser != null && hurteduser != null){
rust.InventoryNotice(killeruser, string.Format("Нанесли урона - {0}", damage.amount.ToString()));
rust.InventoryNotice(hurteduser, string.Format("Получили Урона {0}", damage.amount.ToString()));
}
//damage.amount = 0f;
// damage.status = LifeStatus.IsAlive;
return CancelDamage(damage);
}

object CancelDamage(DamageEvent damage)
{

return damage;
}


}
}