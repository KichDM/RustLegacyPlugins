using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oxide.Plugins
{
    [Info("AutoSave", "TrecTar", 0.1)]
    class AutoSave : RustLegacyPlugin
    {
        static string chattag = "AutoSave";
        void OnServerInitialized()
        {
			Save();
        }
		
        void Save()
        {
            timer.Repeat(7200f, 0, () =>
            {
                rust.RunServerCommand("server.all");
                rust.BroadcastChat(chattag, "[color yellow] El servidor se esta guardando...");
				rust.BroadcastChat(chattag, "[color red][!][color orange] Puede causar un poco de lag.");
				rust.BroadcastChat(chattag, "[color cyan][?][color green] El servidor se guarda cada 2 horas.");
            });
        }
    }
}
