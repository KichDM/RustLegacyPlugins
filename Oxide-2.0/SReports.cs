using System.Collections.Generic;
using System;
using System.Data;
using UnityEngine;
using Oxide.Core;
using RustExtended;

namespace Oxide.Plugins
{
    [Info("SReports", "Sh1ne", "1.1")]
    class SReports : RustLegacyPlugin
    {
        [ChatCommand("report")]
        void cmdReport(NetUser netUser, string command, string[] args)
        {
            if (args.Length >= 2)
            {
                PlayerClient target = Helper.GetPlayerClient(args[0]);
                if (target == null)
                {
                    rust.SendChatMessage(netUser, "Система жалоб", $"[color#6FFC2E]Игрок под именем {args[0]} не найден");
                    return;
                }

                UserData userData = Users.GetBySteamID(netUser.playerClient.userID);
                if (args[0] == userData.Username)
                {
                    rust.SendChatMessage(netUser, "Система жалоб", "[color#6FFC2E]Вы не можете отправить жалобу на самого себя");
                    return;
                }


                NetUser targetUser = target.netUser;
                
                string text = "";
                for (int i = 1; i < args.Length; i++)
                {
                    if (i != 1) text += " ";
                    text += args[i];
                }

                string report_text = $"Игрок {netUser.displayName} [{netUser.userID}] отправил жалобу на игрока {targetUser.displayName} [{target.userID}]{Environment.NewLine}Причина: {text}";
                SendPostRequest(report_text);
                Helper.LogChat(report_text, true);
                rust.SendChatMessage(netUser, "Система жалоб", $"[color#6FFC2E]Вы отправили жалобу на игрока {targetUser.displayName} Причина: {text}");
            }
            else
            {
                rust.Notice(netUser, "Используйте /report \"Никнейм\" \"Причина\"");
            }
        }

        void SendPostRequest(string text)
        {
			string msg = $"content=```json{Environment.NewLine}" + text + "```";
			Helper.LogChat(msg, true);
            webrequest.EnqueuePost("https://discordapp.com/api/webhooks/703661258720252212/gmxVjXCАAxsaLt3ZHi7pnt8DmeJАВПАВNmB2yPjrRFAВАПАВПLnbb45nvZKAQA6C2U3GKtM_-ME", msg, (code, response) => GetCallback(code, response), this);
        }

        void GetCallback(int code, string response)
        {
            if (response == null || code != 200)
            {
				Helper.LogError(response, true);
                return;
            }
            Helper.LogChat(response, true);
        }
    }
}