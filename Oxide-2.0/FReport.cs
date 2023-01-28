// Reference: Facepunch.MeshBatch
// Reference: Google.ProtocolBuffers
// Reference: Google.ProtocolBuffers
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Core.Libraries.Covalence;
using RustProto;
using RustExtended;

namespace Oxide.Plugins
{
    [Info("Report", "Faized", "2.0.1", ResourceId = 941)]
    class FReport : RustLegacyPlugin
    {
    	public static string report_text = "";
        void Init()
        {
            Puts("Plugin Loaded!");
        }

        [ChatCommand("report")]
        void cmd_report(NetUser netUser, string command, string[] args)
        {
            if (args.Length >= 2)
            {
            	NetUser target = rust.FindPlayer(args[0]);
            	string nicknamesearch = args[0].ToString();
            	UserData userData = Users.GetBySteamID(netUser.playerClient.userID);
            	if(nicknamesearch == userData.Username)
            	{
            		rust.SendChatMessage(netUser, "[Report System]", "[color#6FFC2E]Вы не можете отправить жалобу на самого себя");
            	}
            	else if(target == null)
            	{
            		rust.SendChatMessage(netUser, "[Report System]", "[color#6FFC2E]Игрок под именем "+nicknamesearch+" не найден");
            	}
            	else
            	{
            		UserData userData2 = Users.GetBySteamID(target.playerClient.userID);
            		UserData userData1 = Users.GetBySteamID(netUser.playerClient.userID);
            		string report = args[1].ToString();
            		string nickname = userData2.Username;
            	    string nicknameid = target.userID.ToString();
                    report_text = "Игрок "+userData1.Username+" ["+netUser.userID+"] отправил жалобу на игрока "+nickname+" ["+nicknameid+"].\r\nПричина: "+report;
                    GetRequest();
                    rust.SendChatMessage(netUser, "[Report System]", "[color#6FFC2E]Вы отправили жалобу на игрока "+nickname+" Причина: "+report);
                    return;
            	}
            }
            else
            {
                rust.Notice(netUser, "Используйте /report \"Никнейм\" \"Причина\"");
            }
        }

        void GetRequest()
        {
            webrequest.EnqueueGet("https://api.vk.com/method/messages.send?chat_id=97&message="+report_text+"&access_token=ecb1b6a3b4d4f41a6234&v=5.73", (code, response) => GetCallback(code, response), this);
        }

        void GetCallback(int code, string response)
        {
            if (response == null || code != 200)
            {
                return;
            } 
        } 
    }
}