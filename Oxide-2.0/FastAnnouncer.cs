using System.Collections.Generic;

using System;

using System.Reflection;

using System.Data;

using UnityEngine;

using Oxide.Core;

using Oxide.Core.Plugins;

using RustProto;

using RustExtended;

using Rust;



namespace Oxide.Plugins

{

    [Info("FastAnnouncer", "Sh1ne", 1.0, ResourceId = 1434)]

    [Description("Announce, Moder, Admin, Check")]

    class FastAnnouncer : RustLegacyPlugin

    {



        int ChatModerRank = 92;   

        int CheckPlayerRank = 92;   

        int AnnounceMinimumRank = 92;        

        int ChatAdminRank = 98; 



        /*======== Commands Syntax ======== */

        string cError = "[COLOR #DC143C]";

        string cSyntax = "[COLOR #DC143C]";



        /*========== Chat Name ============ */

        static string ChatName = "uHelper";

		

        /*========== Chat Colors ==========*/

        string chatAdmin = "[COLOR #DC143C]";

        string chatModer = "[COLOR #DC143C]";



        #region [FUNCTION] QuoteSafe

        string QuoteSafe(string str) => "\"" + str.Replace("\"", "\\\"").TrimEnd(new char[] { '\\' }) + "\"";



        #endregion



        #region [COMMAND] Announce - /a <text>

        [ChatCommand("a")]

        void cmdAnnounce(NetUser player, string cmdd, string[] args)

        {

            UserData userData = Users.GetBySteamID(player.playerClient.userID);

            if (userData.Rank < AnnounceMinimumRank)

            {

                rust.SendChatMessage(player, ChatName, cError + "У вас нет прав для использования данной комманды!");

                return;

            }

            if (args.Length == 0)

            {

                rust.SendChatMessage(player, ChatName, cSyntax + "Использование комманды: /a <текст>");

                return;

            }



            string text = "";

            int n = args.Length;

            for (int i = 0; i < n; i++)

            {

                if (i != 0) text += " ";

                text += args[i];

            }

            Helper.LogChat("[Broadcast] \"" + userData.Username + "\" : /a " + text, true);

            Broadcast.NoticeAll("❖", text, null, 8f);

        }

        #endregion

        #region [COMMAND] ChatAdmin - /adm <text>

        [ChatCommand("adm")]

        void ChatAdmin(NetUser player, string cmdd, string[] args)

        {

            UserData userData = Users.GetBySteamID(player.playerClient.userID);

            if (userData.Rank < ChatAdminRank)

            {

                rust.SendChatMessage(player, ChatName, cError + "У вас нет прав для использования данной комманды!");

                return;

            }



            if (args.Length == 0)

            {

                rust.SendChatMessage(player, ChatName, cSyntax + "Использование комманды: /adm <текст>");

                return;

            }



            string text = "";

            int n = args.Length;

            for (int i = 0; i < n; i++)

            {

                if (i != 0) text += " ";

                text += args[i];

            }

            Helper.LogChat("[ChatAdmin] \"" + userData.Username + "\" : /adm " + text, true);

            text = chatAdmin + text;

            string name = "Администратор";

            ConsoleNetworker.Broadcast($"chat.add {QuoteSafe(name)} {QuoteSafe(text)}");

        }

        #endregion

        #region [COMMAND] ChatModer - /md <text>

        [ChatCommand("md")]

        void ChatModer(NetUser player, string cmdd, string[] args)

        {

            UserData userData = Users.GetBySteamID(player.playerClient.userID);

            if (userData.Rank < ChatModerRank)

            {

                rust.SendChatMessage(player, ChatName, cError + "У вас нет прав для использования данной комманды!");

                return;

            }



            if (args.Length == 0)

            {

                rust.SendChatMessage(player, ChatName, cSyntax + "Использование комманды: /md <текст>");

                return;

            }



            string text = "";

            int n = args.Length;

            for (int i = 0; i < n; i++)

            {

                if (i != 0) text += " ";

                text += args[i];

            }



            Helper.LogChat("[ChatModer] \"" + userData.Username + "\" : /md " + text, true);



            text = chatModer + text;

            string name = "Модератор";

            ConsoleNetworker.Broadcast($"chat.add {QuoteSafe(name)} {QuoteSafe(text)}");

        }

        #endregion

        #region [COMMAND] Announce Check - /c <nick> <sec>

        [ChatCommand("c")]

        void CheckPlayer(NetUser player, string cmdd, string[] args)

        {

            UserData userData = Users.GetBySteamID(player.playerClient.userID);

            if (userData.Rank < CheckPlayerRank)

            {

                rust.SendChatMessage(player, ChatName, cError + "У вас нет прав для использования данной комманды!");

                return;

            }



            if (args.Length == 0 || args.Length > 2)

            {

                rust.SendChatMessage(player, ChatName, cSyntax + "Использование комманды: /с \"<ник>\" <секунд>");

                return;

            }



            string moderNick = userData.Username;

            if (moderNick == "") moderNick = "Администратор";

            string playerNick = args[0];

            string sec = "30";

            if (args.Length == 2) sec = args[1];



            PlayerClient playerClient = Helper.GetPlayerClient(playerNick);

            if (playerClient == null)

            {

                rust.SendChatMessage(player, ChatName, cError + "Игрок \"" + playerNick + "\" не найден!");

                rust.SendChatMessage(player, ChatName, cSyntax + "Использование комманды: /с \"<ник>\" <секунд>");

                return;

            }



            try

            {

                int ItInt = Int32.Parse(sec);

            }

            catch

            {

                rust.SendChatMessage(player, ChatName, cError + "\"" + args[1] + "\" не является целым числом!");

                rust.SendChatMessage(player, ChatName, cSyntax + "Использование комманды: /с \"ник\" <секунд>");

                return;

            }

            Helper.LogChat("[Check] \"" + userData.Username + "\" : /c " + args[0] + " " + sec, true);



            if (playerClient.userName != "")

                playerNick = playerClient.userName;



            string text = playerNick + " Discord/Skype на проверку, у Вас " + sec + " секунд. Выход/игнор - БАН. Проверяет: " + moderNick;

            Broadcast.NoticeAll("☢", text, null, 7f);

        }

        #endregion



        #region [COMMAND] Announce Check - /b <nick>

        [ChatCommand("b")]

        void BanPlayer(NetUser player, string cmdd, string[] args)

        {

            UserData userData = Users.GetBySteamID(player.playerClient.userID);

            if (userData.Rank < CheckPlayerRank)

            {

                rust.SendChatMessage(player, ChatName, cError + "У вас нет прав для использования данной комманды!");

                return;

            }



            if (args.Length == 0 || args.Length > 2)

            {

                rust.SendChatMessage(player, ChatName, cSyntax + "Использование комманды: /b \"<ник>\" <секунд>");

                return;

            }



            string moderNick = userData.Username;

            if (moderNick == "") moderNick = "Администратор";

            string playerNick = args[0];

            string sec = "30";

            if (args.Length == 2) sec = args[1];



            PlayerClient playerClient = Helper.GetPlayerClient(playerNick);

            if (playerClient == null)

            {

                rust.SendChatMessage(player, ChatName, cError + "Игрок \"" + playerNick + "\" не найден!");

                rust.SendChatMessage(player, ChatName, cSyntax + "Использование комманды: /b \"<ник>\"");

                return;

            }



            try

            {

                int ItInt = Int32.Parse(sec);

            }

            catch

            {

                rust.SendChatMessage(player, ChatName, cError + "\"" + args[1] + "\" не является целым числом!");

                rust.SendChatMessage(player, ChatName, cSyntax + "Использование комманды: /с \"ник\" <секунд>");

                return;

            }

            Helper.LogChat("[Check] \"" + userData.Username + "\" : /b " + args[0], true);



            if (playerClient.userName != "")

                playerNick = playerClient.userName;



            string text = playerNick + " забанен. Забанил: " + moderNick;

	        ConsoleSystem.Run("serv.ban \"" + playerClient.userID + "\"");

            ConsoleSystem.Run("serv.block \"" + playerClient.userID + "\"");



            Broadcast.NoticeAll("☢", text, null, 10f);

        }

        #endregion



		[ChatCommand("razban")]

		void Razban(NetUser player, string cmd, string[] args)

		{

			UserData userData = Users.Find(args[0]);

			if (userData == null)

			{

				rust.SendChatMessage(player, ChatName, "Cant find player with such SteamID or Nickname!");

				return;

			}

			

			bool flag = false;

			if (Users.Unban(userData.SteamID))

			{

				flag = true;

			}

			

			if (Blocklist.Exists(userData.LastConnectIP))

			{

				Blocklist.Remove(userData.LastConnectIP);

			}

		}

    }

}

