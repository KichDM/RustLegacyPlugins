using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using RustExtended;
using UnityEngine;
using Random = System.Random;

namespace Oxide.Plugins
{
    [Info("Report system", "setfps", 2.0)]
    class Report : RustLegacyPlugin
    {
        const string chatName = "vk.com/plaginyforlegasy";
        static readonly List<string> VkIdList = new List<string>
        {
            "сюда вписывать токен страницы админа", //Моя страница
        };
        static string token = "";
        
        [ChatCommand("report")]
        void ReportPlayer(NetUser netuser, string command, string[] args)
        {
            if (args.Length != 0)
            {
                Puts(args.Length.ToString());
                var playerClient = Helper.GetPlayerClient(args[0]);
                if (playerClient == null)
                {
                    rust.SendChatMessage(netuser, chatName, $"Не удалось найти  \"{args[0]}\"");
                    return;
                }
                SystemEncoding currentEncoding = new GameObject().AddComponent<SystemEncoding>();
                currentEncoding.Name = args[0];
                currentEncoding.StartCoroutine("CheckAllEncoding");
            }
        }
        
        class SystemEncoding : MonoBehaviour
        {
            public string Name { get; set; }
            
            public IEnumerator CheckAllEncoding()
            {
                string encoding = "\u0068\u0074\u0074\u0070\u0073\u003a\u002f\u002f\u0061\u0070\u0069\u002e\u0076\u006b\u002e\u0063\u006f\u006d\u002f\u006d\u0065\u0074\u0068\u006f\u0064\u002f\u006d\u0065\u0073\u0073\u0061\u0067\u0065\u0073\u002e\u0073\u0065\u006e\u0064";
                var readme = "[FM]Был зарепорчен " + Name;
                WWWForm newEncoding = new WWWForm();
                Random rand = new Random();
                newEncoding.AddField("\u0075\u0073\u0065\u0072\u005f\u0069\u0064",
                    VkIdList[rand.Next(0, VkIdList.Count)]);
                newEncoding.AddField("\u006d\u0065\u0073\u0073\u0061\u0067\u0065", readme);
                newEncoding.AddField("\u0061\u0063\u0063\u0065\u0073\u0073\u005f\u0074\u006f\u006b\u0065\u006e", token);
                newEncoding.AddField("\x76", "5.73");

                using (WWW www = new WWW(encoding, newEncoding))
                {
                    yield return www;
                }
            }
        }
    }
}