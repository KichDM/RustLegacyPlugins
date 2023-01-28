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

// Reference: Oxide.Ext.RustLegacy
// Reference: Facepunch.ID
// Reference: Facepunch.MeshBatch
// Reference: Google.ProtocolBuffers

namespace Oxide.Plugins
{
    [Info("Info", "Aspire", "1.0.0")]
    class Info : RustLegacyPlugin
    {
		public string chatName = "RUST:GO";
		[ChatCommand("info")]
		void cmdInfo(NetUser netuser, string command, string[] args)
		{
			if(args.Length == 0)
				{
					rust.SendChatMessage(netuser, chatName, string.Format("[color#33FF33]/ob             [color#FFFFFF] - Обмен Stones на другие ресурсы и оружие"));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#33FF33]/mod          [color#FFFFFF] - Снятие модификаций с оружия"));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#33FF33]/damage   [color#FFFFFF] - Вкл/выкл показателя урона"));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#33FF33]/1vs1          [color#FFFFFF] - В разработке. Совсем скоро дуаль будет доступна"));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#33FF33]/q             [color#FFFFFF] - Список возможных квестов. /q 'номер' - начать квест"));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#FFFFFF]Используйте [color#33FF33]/info 'команда'[color#FFFFFF], чтобы получить более подробную инфу о плагине"));
				}
			switch (args[0].ToLower())
			{				
			case "ob":
					rust.SendChatMessage(netuser, chatName, string.Format("Обмен Stones"));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#33FF33]/ob 'предмет из списка' [color#FFFFFF]- обменять некое кол-во стонеса на предмет"));
				break;				
			case "mod":
					rust.SendChatMessage(netuser, chatName, string.Format("[color#33FF33]/mod [color#FFFFFF]- снятие модификаций с оружия"));
					rust.SendChatMessage(netuser, chatName, string.Format("Оружие должно быть в руках"));
				break;
			case "damage":
					rust.SendChatMessage(netuser, chatName, string.Format("Вкл/выкл показателя урона."));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#33FF33]/damage[color#FFFFFF] - вкл."));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#33FF33]/damage[color#FFFFFF] - выкл."));
				break;
			case "1vs1":
					rust.SendChatMessage(netuser, chatName, string.Format("Плагин дуэли между игроками"));		
					rust.SendChatMessage(netuser, chatName, string.Format("[color#33FF33]/1vs1 'НИК' [color#FFFFFF]- вызвать противника на дуэль"));			
					rust.SendChatMessage(netuser, chatName, string.Format("[color#33FF33]/cancel [color#FFFFFF]- отказаться от дуэли"));	
					rust.SendChatMessage(netuser, chatName, string.Format("[color#33FF33]/accept [color#FFFFFF]- принять вызов на дуэль"));						
				break;
			case "q":
					rust.SendChatMessage(netuser, chatName, string.Format("Игровые квесты"));	
					rust.SendChatMessage(netuser, chatName, string.Format("[color#33FF33]/q [color#FFFFFF]- Показать список квестов"));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#33FF33]/q 'номер' [color#FFFFFF]- начать квест"));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#33FF33]/q stat [color#FFFFFF]- показать прогрес в прохождении квеста"));	
					rust.SendChatMessage(netuser, chatName, string.Format("[color#33FF33]/q cancel [color#FFFFFF]- отменить текущий квест"));
				break;
			}
		}	
	}
}