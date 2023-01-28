
using System;
//▒█▀▀█ ▒█░░▒█ 　 ▒█▀▀█ ▀█▀ ▒█▄░▒█ ▒█░▄▀ 
//▒█▀▀▄ ▒█▄▄▄█ 　 ▒█▄▄█ ▒█░ ▒█▒█▒█ ▒█▀▄░ 
//▒█▄▄█ ░░▒█░░ 　 ▒█░░░ ▄█▄ ▒█░░▀█ ▒█░▒█ 


namespace Oxide.Plugins
{
    [Info("Suicide", "PINK", "0.1.0")]
    class Suicide : RustLegacyPlugin
    {			
		
		[ChatCommand("suicide")]
        void cmdDie(NetUser netuser, string command, string[] args)
		
		{

				var rootControllable = netuser.playerClient.rootControllable;
				TakeDamage takee = rootControllable.takeDamage;
				if (takee.health <= 0)
					return;
				TakeDamage.KillSelf(rootControllable);

		}
	}
}