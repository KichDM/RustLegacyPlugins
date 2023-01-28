using System.Collections.Generic;
using System;
using System.Text;
using Oxide.Core;
using Oxide.Core.Libraries.Covalence;
using RustExtended;
using System.Text.RegularExpressions;

#pragma warning disable 0618 // отключение предупреждений об устаревших методах

namespace Oxide.Plugins
{
    [Info("ChatControl", "setfps", "0.1.1")]
	[Description("Freezak's ChatControl.")]
    class ChatControl1 : RustLegacyPlugin 
	{
		bool nickchecker = false; //Првоерка ника (true - включить, false - выключить)
		string chatName = "БОТ";                   //Название сервера (отображаеться в чате как ник)
		string[] array = {"сука", "пидор", "бля", "еба", "пизда", "уёбок", "уёбки", "уебок", "уебки", "хули", "стерва", "шлюха", "хуй", "гондон", "гандон", "ебланы", "похуй",}; // Список матов
		
		void execCMD(string Command){
			rust.RunServerCommand(Command);
		}
		
		void OnPlayerChat(NetUser netUser, string message)
		{
			string text = message.ToLower();
			int num = 0;
			foreach (string element in array)
			{
				if (Regex.IsMatch(text, "\\b" + element + "\\b"))
				{
					num++;
				}
			}
			if (num > 0)
			{
				UserData userData = Users.GetBySteamID(netUser.userID);
				string username = userData.Username;
				//execCMD("serv.mute \""+username+"\" 300");
				Countdown countdown = new Countdown("mute", (double)300);
				Users.CountdownAdd(userData.SteamID, countdown);
				string mutemessage = "[COLOR#ff0000]" + username + " был замучен на 5 минут. Причина: Мат";
				//execCMD("chat.add \"" + chatName + "\" \"" + mutemessage + "\"");
				ConsoleNetworker.SendClientCommand(netUser.networkPlayer, $"chat.add \"" + chatName + "\" \"" + mutemessage + "\"");
				return;
			}
		}
		
		void OnPlayerConnected(NetUser netUser)
		{
			if(nickchecker)
			{
				UserData userData = Users.GetBySteamID(netUser.userID);
				string username = userData.Username;
				if(!Regex.IsMatch(username, @"^[0-9a-zA-Z\-_\.]+$"))
				{
					rust.SendChatMessage(netUser, "Ваш ник не соответствует требованиям сервера");
					netUser.Kick(NetError.NoError, true);
					execCMD("serv.users " + username + " remove");
				}
			}
		}
	}
}