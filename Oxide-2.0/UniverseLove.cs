using System.Collections.Generic;
using System;
using System.Text;
using Oxide.Core;
using Oxide.Core.Libraries.Covalence;
using RustExtended;
using System.Text.RegularExpressions;

#pragma warning disable 0618

namespace Oxide.Plugins
{
    [Info("UniverseLove", "Freezak & Mixxe73", "1.3.0")]
	[Description("Тот самый любимый универсал | Данный плагин не дает написать определенные слова, заместо их появляются похвальные текста!")]
    class UniverseLove : RustLegacyPlugin 
	{
		string[] array = {"volchara", "rome", "legion", "hostfun", "elegacy", "федяев", "майоров", "evox42", "akrim", "atamg"};
		string[] msg = {"Я люблю сервер The Universe of Rust ♥", "Это просто самый лучший сервер в Legacy ツ", "Невероятно крутой сервер, администрация, вы супер!"};
		
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
				Countdown countdown = new Countdown("mute", (double)1);
				Users.CountdownAdd(userData.SteamID, countdown);
				ConsoleNetworker.SendClientCommand(netUser.networkPlayer, $"chat.add \"" + userData.Username + "\" \"" + msg[Core.Random.Range(0, msg.Length - 1)] + "\"");
				return;
			}
		}
	}
}