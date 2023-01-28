using Oxide.Core;
using Oxide.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oxide.Plugins
{
    [Info("AutoAirdrop", "PionixZ", "1.0")]
    class AutoAirdrop : RustLegacyPlugin
    {
        int AutoAirdroptime = 1200; // segundos save

        void Loaded()
        {
 
                timer.Repeat(AutoAirdroptime, 0, () =>
                {
                    
                        Puts("Airdrop automatico.");
                        rust.RunServerCommand("airdrop.drop");
                   
                });

        }
    }
}
