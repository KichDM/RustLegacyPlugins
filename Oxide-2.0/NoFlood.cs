using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustProto;
using System.Linq;
using System.Collections.Generic;
using RustProto;
using RustExtended;
using Oxide.Core.Libraries;
#pragma warning disable 0618 // отключение предупреждений об устаревших методах

namespace Oxide.Plugins  
{
    [Info("NoFlood", "BaNDiT", "7.7.7")]
    class NoFlood : RustLegacyPlugin
    {
		static string ChatTag = "NoFlood";
		static Dictionary<NetUser, int> AntFlood = new Dictionary<NetUser, int>();
		public static List<object> cores = new List<object>(){"[color"};
		public static List<object> nomes = new List<object>(){"net.connect","мальвина", "МАЛЬВИНА", "ЧИТ", "Мальвина"};
		
        bool Acess(NetUser netuser)
		{
			if(netuser.CanAdmin())return true; 
			return false;
		}
		
		bool OnPlayerChat(NetUser netuser, string message)
		{
			string name = rust.QuoteSafe(netuser.displayName);
			string msg = rust.QuoteSafe(message); 
			var idnetuser = netuser.playerClient.userID.ToString();

			if(AntFlood.ContainsKey(netuser))
            {                                   // Цвет
                rust.SendChatMessage(netuser, ChatTag, "Вы можете [color#42AAFF]писать в чат, [color#FFFFFF]не раньше чем каждые [color#42AAFF]2 секунды.");
				return true;
            }
			foreach(string value in cores){
                if(message.Contains(value)){  // Цвет
					rust.Notice(netuser, "Перестаньте писать цветным текстом.");
				    return true;
                    
                }
            }
			foreach(string value in nomes){
                if(message.Contains(value)){ // Цвет
					rust.Notice(netuser, "Перестаньте писать запрещённые слова.");
				    return true;
                    
                }
            }				
			    AntFlood.Add(netuser, 0);
				        // Кулдаун
				timer.Once(2f, () => { AntFlood.Remove(netuser); });
			return false;
		}
	}
}