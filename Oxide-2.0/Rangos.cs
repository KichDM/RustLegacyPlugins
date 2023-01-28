/* Atención:
Si la persona que esta editando este documento
no entiende el lenguaje C# ni la API de Oxide, le recomiendo que
no edite este archivo ya que puede corromperlo.

Atentamente TrecTar
*/

using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustProto;
using Oxide.Core.Libraries;
using Newtonsoft.Json;

namespace Oxide.Plugins  
{
    [Info("Rangos", "Kich", "0.0.1")]

    class Rangos : RustLegacyPlugin
    {
		//Tag de Chat
		static string Chattag = "Rangos";











        //Escritura por rangos
        void OnPlayerChat(NetUser netuser, string message)
        {
            string nombre = netuser.displayName;
            var msg = rust.QuoteSafe(message);


            msg = rust.QuoteSafe(message);

            Puts(nombre + ": " + message);
            chatdiscord(netuser, message);
            ConsoleNetworker.Broadcast(string.Concat("chat.add " + netuser.displayName + " " + msg));
            netuser.NoteChatted();
            return;
        }



        void chatdiscord(NetUser sender, string message)
        {


            string payloadJson = JsonConvert.SerializeObject(new chatdiscorddd()
            {
                MessageText = string.Format("```md\n# {0}: {1}```", sender.displayName, message)
            }); ;
            Dictionary<string, string> plicksl = new Dictionary<string, string>();
            plicksl.Add("Content-Type", "application/json");
            webrequest.EnqueuePost(chatdiscordd, payloadJson, (code, response) => NotStuctBack(code, response), this, plicksl);

        }

        public void NotStuctBack(int code, string responde) { }
        class chatdiscorddd
        {
            [JsonProperty("content")]
            public string MessageText { get; set; }
        }
        string chatdiscordd = "https://discord.com/api/webhooks/892852722930446377/u8b5fjGAkG4L_T9FlIHSceWDD2mB_GpT7MoBlaL0uD5BnFLGcxRLRyV-lA-FKYYSzBjV";

    }
}