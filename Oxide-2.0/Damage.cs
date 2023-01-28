using System;
using System.Collections.Generic;


//▒█▀▀█ ▒█░░▒█ 　 ▒█▀▀█ ▀█▀ ▒█▄░▒█ ▒█░▄▀ 
//▒█▀▀▄ ▒█▄▄▄█ 　 ▒█▄▄█ ▒█░ ▒█▒█▒█ ▒█▀▄░ 
//▒█▄▄█ ░░▒█░░ 　 ▒█░░░ ▄█▄ ▒█░░▀█ ▒█░▒█


namespace Oxide.Plugins
{
    [Info("Damage", "PINK", "0.1.0")]
    class Damage : RustLegacyPlugin		
	{
		
		Dictionary<NetUser,bool> dano = new Dictionary<NetUser, bool>();		
		
		
		[ChatCommand("dmg")]
        void cmdDano(NetUser netuser, string command, string[] args)
        {
          
                if (dano.ContainsKey(netuser))
                {
                    if (dano[netuser])
                    {
                        dano[netuser] = false;
                        rust.RunClientCommand(netuser, "notice.popup \"" + "✘ \"" + "✘ \"" + "Notificação de danos - Desativada \"");
                    }
                    else
                    {
                        dano[netuser] = true;
                        rust.RunClientCommand(netuser, "notice.popup \"" + "✔ \"" + "✔ \"" + "Notificação de danos - Ativada \"");
                    }
                }
                else
                {
                    dano[netuser] = true;
                    rust.RunClientCommand(netuser, "notice.popup \"" + "✔ \"" + "✔ \"" + "Notificação de danos - Ativada \"");
                }
            
        }

        void OnPlayerConnected(NetUser netuser)
        {
            
                dano[netuser] = true;
           
        }


        void OnPlayerDisconected(uLink.NetworkPlayer networkPlayer)
        {
            
                NetUser netuser = (NetUser)networkPlayer.GetLocalData();
                dano[netuser] = false;
           
        }

        void OnHurt(TakeDamage takeDamage, DamageEvent damage)
		{
            
                if (takeDamage is HumanBodyTakeDamage)
                {
                    if (damage.attacker.client == null) return;
                    if (damage.victim.client == null) return;
                    NetUser attacker = damage.attacker.client?.netUser;
                    NetUser victim = damage.victim.client?.netUser;
                    if (attacker == null || victim == null) return;
                    if (damage.attacker.client == damage.victim.client) return;

                    double dmg = Math.Floor(damage.amount);
                    double vida = Math.Floor(victim.playerClient.controllable.health);
                    if (dmg == 0) return;

                    if (dano.ContainsKey(attacker) && dano[attacker]) rust.InventoryNotice(attacker, "" + victim.displayName + " " + "[" + vida + "/" + "100]");
                    if (dano.ContainsKey(victim) && dano[victim]) rust.InventoryNotice(victim, "Atacado por:" + " " + attacker.displayName);
                }
                else
                {
                    if (damage.attacker.client == null) return;
                    if (damage.attacker.client == damage.victim.client) return;
                    if (damage.amount == 0) return;
                    NetUser attacker = damage.attacker.client?.netUser;
                    string message = string.Format("Dano: [{0}/{1}]", Convert.ToInt32(takeDamage.health), takeDamage.maxHealth);
                    if (dano.ContainsKey(attacker) && dano[attacker]) rust.InventoryNotice(attacker, message);
                }
           
		}
	}
}