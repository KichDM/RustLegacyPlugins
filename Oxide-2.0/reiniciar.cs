using Oxide.Core;
using Oxide.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Oxide.Plugins
{
    [Info("AutoRestart", "PionixZ", "1.0")]
    class reiniciar : RustLegacyPlugin
    {
        int AutoRestart = 86400;
        string SystemName = "Server";

        void Loaded()
        {
            
                timer.Repeat(AutoRestart, 0, () =>
                {
                    rust.BroadcastChat(SystemName, "[color green]Reiniciando automaticamente o servidor em 5 minutos.");
                    timer.Once(60f, () =>
                    {
                        rust.BroadcastChat(SystemName, "[color green]Reiniciando automaticamente o servidor em 4 minutos.");
                    });
                    timer.Once(120f, () =>
                    {
                        rust.BroadcastChat(SystemName, "[color green]Reiniciando automaticamente o servidor em 3 minutos.");
                    });
                    timer.Once(180f, () =>
                    {
                        rust.BroadcastChat(SystemName, "[color green]Reiniciando automaticamente o servidor em 2 minutos.");
                    });
                    timer.Once(240f, () =>
                    {
                        rust.BroadcastChat(SystemName, "[color green]Reiniciando automaticamente o servidor em 1 minuto.");
                    });
                    timer.Once(300f, () =>
                    {
                        rust.BroadcastChat(SystemName, "[color green]Reiniciando o servidor, em breve voltaremos.");
                    });
                    timer.Once(302f, () =>
                    {
                        rust.BroadcastChat(SystemName, "[color green]Aguarde alguns segundos, obrigado pela compreensão.");
                    });
                    timer.Once(304f, () =>
                    {
                        EnviarDiscord();
                        Puts("Reiniciando servidor automatico.");
                        rust.RunServerCommand("quit");
                    });
                });

                if (!permission.PermissionExists("canreiniciar")) permission.RegisterPermission("canreiniciar", this);
            

        }

        bool hasAccess(NetUser netuser, string permissionname)
        {
            if (netuser.CanAdmin()) return true;
            if (permission.UserHasPermission(netuser.playerClient.userID.ToString(), "canreiniciar")) return true;
            return permission.UserHasPermission(netuser.playerClient.userID.ToString(), permissionname);
        }

        [ChatCommand("reiniciar")]
        void cmdChatClean(NetUser netuser, string command, string[] args)
        {
            
                if (!hasAccess(netuser, "canreiniciar")) { SendReply(netuser, "Vo[color yellow]Você não tem permissão para usar este comando."); return; }
                rust.BroadcastChat(SystemName, "[color green]Reiniciando o servidor, em breve voltaremos.");
                timer.Once(4f, () =>
                {
                    rust.BroadcastChat(SystemName, "[color green]Aguarde alguns segundos, obrigado pela compreensão.");
                });
                timer.Once(7f, () =>
                {
                    EnviarDiscord();
                    Puts("Reiniciando o servidor.");
                    rust.RunServerCommand("quit");
                });
           

        }

        void EnviarDiscord()
        {
            string payloadJson = JsonConvert.SerializeObject(new DisoverPls()
            {
                MessageText = string.Format("Reiniciando o servidor, em breve voltaremos.")
            }); ;
            Dictionary<string, string> plicksl = new Dictionary<string, string>();
            plicksl.Add("Content-Type", "application/json");
            webrequest.EnqueuePost(CordSupport, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);
        }
        public void NotStuctBack(int code, string responde) { }
        class DisoverPls
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string CordSupport = "https://discord.com/api/webhooks/901125869697904650/Ce1R8eDEdKA02kaO5nzkoiVJH6e5gDuqDjN2ftKJbRMv1Hyf39E048IxF7tXFBk9V1RP";
    }
}