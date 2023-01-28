/*---------------------------------------------------\
Плагин               :  Daily                        |
Автор                :  Unkown (vk.com/jacksonspain)|
Дата создания        :  27.03.2018                   |
Последнее обновление :  10.04.2018                   |
----------------------------------------------------*/
using System.Collections.Generic;
using System;
using System.Text;
using Oxide.Core;
using Oxide.Core.Libraries.Covalence;
using System.Text.RegularExpressions;

#pragma warning disable 0618 // отключение предупреждений об устаревших методах

namespace Oxide.Plugins
{
    [Info("ChatControl", "Unkown", "0.1.1")]
	[Description("Unkown's ChatControl.")]
    class ChatControl : RustLegacyPlugin 
	{
		bool nickchecker = true; //Првоерка ника (true - включить, false - выключить)
		string chatName = "Server";                   //Название сервера (отображаеться в чате как ник)
		

		
		void OnPlayerConnected(NetUser netUser)
		{
			if(nickchecker)
			{
				UserData userData = Users.GetBySteamID(netUser.userID);
				string username = userData.Username;
				if(!Regex.IsMatch(username, @"^[0-9a-zA-Z\-_\.]+$"))
				{
					rust.SendChatMessage(netUser, "Su apodo no cumple con los requisitos del servidor");
					netUser.Kick(NetError.NoError, true);
					netuser.Kick(NetError.Facepunch_Kick_RCON, true);
				}
			}
		}
	}
}