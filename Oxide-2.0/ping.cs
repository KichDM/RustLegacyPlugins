using Oxide.Core;
using Oxide.Core.Plugins;
using System;
using System.Text;
using uLink;

namespace Oxide.Plugins
{
    [Info("Ping", "PionixZ", "0.1.0")]
    public class ping : RustLegacyPlugin
    {
        [ChatCommand("ping")]
        void cmdmyping(NetUser netuser, string command, string[] args)
        {
           
                var meuping = netuser.playerClient.netUser.networkPlayer.averagePing;
                {
                    if (meuping < 200)
                    {
                        rust.Notice(netuser, "Seu Ping - " + meuping + "ms", "✔");

                    }
                    else
                    {
                        rust.Notice(netuser, "Seu Ping - " + meuping + "ms", "✘");
                    }
                }
            
        }
    }
}