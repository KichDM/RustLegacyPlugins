// Reference: RustExtended
// Reference: USAC
using Oxide.Core;
using Oxide.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAC;
using RustExtended;

namespace Oxide.Plugins
{
    [Info("AutoReinicios", "KichDM", "1.0")]
    class AutoRestart : RustLegacyPlugin
    {
        int klk = 86400;
        string SystemName = "VSS";

        void Loaded()
        {

            timer.Repeat(klk, 0, () =>
            {
                rust.BroadcastChat(SystemName, "[color green]Reiniciando automaticamente el servidor en 5 minutos.");
                timer.Once(60f, () =>
                {
                    rust.BroadcastChat(SystemName, "[color green]Reiniciando automaticamente el servidor en 4 minutos.");
                });
                timer.Once(120f, () =>
                {
                    rust.BroadcastChat(SystemName, "[color green]Reiniciando automaticamente el servidor en 3 minutos.");
                });
                timer.Once(180f, () =>
                {
                    rust.BroadcastChat(SystemName, "[color green]Reiniciando automaticamente el servidor en 2 minutos.");
                });
                timer.Once(240f, () =>
                {
                    rust.BroadcastChat(SystemName, "[color green]Reiniciando automaticamente el servidor en 1 minuto.");
                });
                timer.Once(300f, () =>
                {
                    rust.BroadcastChat(SystemName, "[color green]Reiniciando automaticamente el servidor!.");
                });
                timer.Once(302f, () =>
                {
                    rust.BroadcastChat(SystemName, "[color green]Guardando automaticamente todo.");
                    rust.RunServerCommand("save.all");
                });
                timer.Once(304f, () =>
                {
                    EnviarDiscord();
                    Puts("Reiniciando servidor automatico.");
                    rust.RunServerCommand("klk.reinicio 5");
                });
            });

            if (!permission.PermissionExists("canreiniciar")) permission.RegisterPermission("canreiniciar", this);


        }

        bool hasAccess(NetUser netuser, string permissionname)
        {
            if (netuser.CanAdmin()) return true;
            string id = netuser.userID.ToString();
            UserData me = Users.GetBySteamID(netuser.userID);
            if (me.Rank >= 14)
            {
                return true;
            }
            return permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionname);
        }

        void EnviarDiscord()
        {
            API.SendMessageToDiscordEmbed("https://discord.com/api/webhooks/955163445504925697/opiHmjVEzHoi-nK5eAoFdH4uwsxAFgXN3y6Xbt_4FM6z9NMDQ5U4TohpQG6QE508yGX-", "AutoReinicios", " Servidor Reiniciado!");
        }
    }
}
