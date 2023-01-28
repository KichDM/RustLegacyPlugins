using System;
using System.Collections.Generic;
using Oxide.Core;
//using Oxide.Core.Libraries;
using RustExtended;
#pragma warning disable 0618 // отключение предупреждений об устаревших методах

namespace Oxide.Plugins
{
    [Info("RNDStat", "lutseferTest", "1.0.2")]
    class RNDStat : RustLegacyPlugin	 
	{
		string ChatName= RustExtended.Core.ServerName ;

		static void SendMessage(PlayerClient player, string message) { ConsoleNetworker.SendClientCommand(player.netPlayer, "chat.add RustKing "+ Facepunch.Utility.String.QuoteSafe(message));  }
		[ChatCommand("stat")]
		void statistic(NetUser netuser, string command, string[] args)		
		{			
			SendMessage(netuser.playerClient, string.Format("{0}", "[color#00ffff]Ваша статистика:"));
			UserData userData = Users.GetBySteamID(netuser.userID);
			string plkil = "[color#00ffff]Убито игроков:   "+RustExtended.Economy.Get(netuser.userID).PlayersKilled+"[color#00ffff]";
			string mutkil = "[color#00ffff]Убито мутантов:   "+RustExtended.Economy.Get(netuser.userID).MutantsKilled+"[color#00ffff]";
			string anikill = "[color#00ffff]Убито животных:   "+RustExtended.Economy.Get(netuser.userID).AnimalsKilled+"[color#00ffff]";
			string death = "[color#00ffff]Погибли:   "+RustExtended.Economy.Get(netuser.userID).Deaths + "[color#00ffff]";
			string rang = "[color#00ffff]ВАШ РАНГ :   "+RustExtended.Core.Ranks[userData.Rank]+"[color#00ffff]";
			SendMessage(netuser.playerClient, string.Format("{0}", rang));
			SendMessage(netuser.playerClient, string.Format("{0}", plkil));
			SendMessage(netuser.playerClient, string.Format("{0}", mutkil));
			SendMessage(netuser.playerClient, string.Format("{0}", anikill));
			SendMessage(netuser.playerClient, string.Format("{0}", death));
			SendMessage(netuser.playerClient, string.Format("{0}", ping));
			
		}
		void cmdSqlUpdate()
        {
            foreach (PlayerClient player in PlayerClient.All)
            {
			   var controllable = player.controllable;
			   var user = controllable.netUser;
			   OnSqlEcon(user);
            }
        }
		void OnSqlEcon(NetUser player)
		{
			
		}
	}
}