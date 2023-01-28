using System;
using System.Collections.Generic;
using Oxide.Core;
//using Oxide.Core.Libraries;
#pragma warning disable 0618 

namespace Oxide.Plugins
{
    [Info("Top", "TT", "1.0.0")]
    class Top : RustLegacyPlugin	 
	{
		string ChatName = "KLK";

		[ChatCommand("top")]
		void top(NetUser netuser, string command, string[] args)		
		{
            rust.SendChatMessage(netuser, ChatName, "[color#5EC5FF]TOP PLAYERS:");
            List<UserData> topList = new List<UserData>();
            List<String> colors = new List<String>();
            colors.Add("[COLOR # FF0000]");
            colors.Add("[COLOR # FF9C00]");
            colors.Add("[COLOR # FFFA00]");
            colors.Add("[COLOR # 41DB00]");
            colors.Add("[COLOR # 00FF00]");

            for (int n = 1; n <= 5; n++)
            {
                UserData topPlayer = null;
                bool flag = false;
                float maxKD = 0;

                foreach (UserData userData in Users.All)
                {
                    float thisKD = (RustExtended.Economy.Get(userData.SteamID).PlayersKilled);
                    if ((!flag || thisKD > maxKD) && !topList.Contains(userData))
                    {
                        flag = true;
                        maxKD = thisKD;
                        topPlayer = userData;
                    }
                }
                topList.Add(topPlayer);
                float kills = RustExtended.Economy.Get(topPlayer.SteamID).PlayersKilled;
                float deaths = RustExtended.Economy.Get(topPlayer.SteamID).Deaths;
                rust.SendChatMessage(netuser, ChatName, $"[color#5EC5FF]{n}. {colors[n - 1]}{topPlayer.Username}[color#5EC5FF] - {kills} Kills, {deaths} Death");
            }
        }
	}
}