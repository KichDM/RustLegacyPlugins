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
    [Info("Rules", "Aspire", "1.0.0")]
    class Rules : RustLegacyPlugin
    {
		public string chatName = "RUST:GO";
		[ChatCommand("rules")]
		void cmdInfo(NetUser netuser, string command, string[] args)
		{
			if(args.Length == 0)
				{
					rust.SendChatMessage(netuser, chatName, string.Format("[color#A52A2A]ЗАПРЕЩЕНО [color#FFFFFF]играть в тиме 3+ человека. [color#33FF33]Наказание:[color#FFFFFF] перманентный бан."));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#A52A2A]ЗАПРЕЩЕНО [color#FFFFFF]ставить ворота под двери чужих домов. [color#33FF33]Наказание:[color#FFFFFF] предупреждение, бан на 1 день."));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#A52A2A]ЗАПРЕЩЕНО [color#FFFFFF]оскорблять родных и близких. [color#33FF33]Наказание:[color#FFFFFF] предупреждение, перманентный бан."));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#A52A2A]ЗАПРЕЩЕНО [color#FFFFFF]прятаться в животных. [color#33FF33]Наказание:[color#FFFFFF] предупреждение, бан на 3 дня."));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#A52A2A]ЗАПРЕЩЕНО [color#FFFFFF]использовать макросы. [color#33FF33]Наказание:[color#FFFFFF] перманентный бан."));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#A52A2A]ЗАПРЕЩЕНО [color#FFFFFF]использовать любое стороннее ПО, дающее преимущество перед другими игроками.  [color#33FF33]Наказание:[color#FFFFFF] перманентный бан."));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#A52A2A]ЗАПРЕЩЕНО [color#FFFFFF]использовать увязвимости игры (баги). [color#33FF33]Наказание:[color#FFFFFF] перманентный бан."));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#A52A2A]ЗАПРЕЩЕНО [color#FFFFFF]изменять/писать другим цветом в чате. [color#33FF33]Наказание:[color#FFFFFF] вечный мут."));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#A52A2A]ЗАПРЕЩЕНО [color#FFFFFF]выдавать себя за Администратора. [color#33FF33]Наказание:[color#FFFFFF] перманентный бан."));
					rust.SendChatMessage(netuser, chatName, string.Format("[color#ADFF2F]РАЗРЕШЕНО  [color#FFFFFF]использовать двойной прыжок и бег гуськом."));
				}
		}	
	}
}