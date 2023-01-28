using RustExtended;



namespace Oxide.Plugins

{

    [Info("Admins", "Kazzooom", "1.0.0")]

    [Description("Show list of server admins")]

    class Admins : RustLegacyPlugin

    {

		string ChatName = "Администрация";// Префикс в чате

		int MinStuffRank = 9;// Минимальный ранг персонала (начиная с модера например)

		string cFirst = "[color #FFFF00]";// Основной цвет чата

		string cSecond = "[color #0000FF]";// Вторичный цвет чата

		

        [ChatCommand("admins")]

        void cmdAdmins(NetUser user, string cmd, string[] args)

        {

			var num = 0;

			rust.SendChatMessage(user, ChatName, $"{cSecond}Администрация онлайн:");

			foreach(PlayerClient pl in PlayerClient.All)

			{

				UserData userData = Users.GetBySteamID(pl.userID);

				if(userData.Rank >= MinStuffRank)

				{

					num++;

					rust.SendChatMessage(user, ChatName, $"{num}. {cFirst} {userData.Username} {cSecond}[{RustExtended.Core.Ranks[userData.Rank]}]");

				}

			}

			if(num == 0) rust.SendChatMessage(user, ChatName, $"{cFirst} [color#FFFFFF]Сейчас, никого из [COLOR##FF0000]администрации[COLOR#FFFFFF] \ [color#1E90FF]модерации[COLOR#FFFFFF] нет!");

		}

	}

}