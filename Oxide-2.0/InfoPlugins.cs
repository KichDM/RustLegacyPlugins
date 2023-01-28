using System.Reflection;
using Oxide.Core;
using Oxide.Core.Plugins;
using System;
using UnityEngine;
using RustExtended;
using System.Collections;

namespace Oxide.Plugins
{
[Info("Info Plugins", "DiGGeT", "1.0.3")]
class InfoPlugins : RustLegacyPlugin
{
					[ChatCommand("plugins")]
				void Sellder(NetUser netuser, string command, string[] args)
				{
					rust.SendChatMessage(netuser, "Plugins", "[COLOR#FFFFFF]☛ [COLOR#32CD32]/top [COLOR#FFFFFF]➠ Узнать топ 5 игроков на сервере");
					rust.SendChatMessage(netuser, "Plugins", "[COLOR#FFFFFF]☛ [COLOR#32CD32]/stat [COLOR#FFFFFF]➠ Узнать личную статистику на сервере");
					rust.SendChatMessage(netuser, "Plugins", "[COLOR#FFFFFF]☛ [COLOR#32CD32]/day [COLOR#FFFFFF]➠ Вызвать голосование за день");
					rust.SendChatMessage(netuser, "Plugins", "[COLOR#FFFFFF]☛ [COLOR#32CD32]/info [COLOR#FFFFFF]➠ Информация о сервере");
					rust.SendChatMessage(netuser, "Plugins", "[COLOR#FFFFFF]☛ [COLOR#32CD32]/promo [COLOR#FFFFFF]➠ Узнать все о промокодах");
					rust.SendChatMessage(netuser, "Plugins", "[COLOR#FFFFFF]☛ [COLOR#32CD32]/ss [COLOR#FFFFFF]➠ Информация о крафте сопли");
					rust.SendChatMessage(netuser, "Plugins", "[COLOR#FFFFFF]☛ [COLOR#32CD32]/w [COLOR#FFFFFF]➠ Информация о варпах");
				}
}
}

