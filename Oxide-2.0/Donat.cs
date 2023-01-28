using System.Reflection;
using Oxide.Core;
using Oxide.Core.Plugins;
using System;
using UnityEngine;
using RustExtended;
using System.Collections;

namespace Oxide.Plugins
{
[Info("Donat", "DiGGeT", "1.0.3")]
class Donat : RustLegacyPlugin
{
					[ChatCommand("donat")]
				void Sellder(NetUser netuser, string command, string[] args)
				{
					rust.SendChatMessage(netuser, "Донат", "[COLOR#FFFFFF]☛ [COLOR#32CD32]Повелитель (30 дней) [COLOR#FFFFFF]➠ [COLOR#ffff00]390р [color #ffffff]☛ [COLOR#32CD32]Навсегда [color#ff0000]➠ [color #ffffff]600р");
					rust.SendChatMessage(netuser, "Донат", "[COLOR#FFFFFF]☛ [COLOR#32CD32]Гл Админ (30 дней) [COLOR#FFFFFF]➠ [COLOR#ffff00]240р [color #ffffff]☛ [COLOR#32CD32]Навсегда [color#ff0000]➠ [color #ffffff]330р");
					rust.SendChatMessage(netuser, "Донат", "[COLOR#FFFFFF]☛ [COLOR#32CD32]Админ (30 дней) [COLOR#FFFFFF]➠ [COLOR#ffff00]190р [color #ffffff]☛ [COLOR#32CD32]Навсегда [color#ff0000]➠ [color #ffffff]260р");
					rust.SendChatMessage(netuser, "Донат", "[COLOR#FFFFFF]☛ [COLOR#32CD32]GOD (30дней) [COLOR#FFFFFF]➠ [COLOR#ffff00]180р [color #ffffff]☛ [COLOR#32CD32]Навсегда [color#ff0000]➠ [color #ffffff]250р");
					rust.SendChatMessage(netuser, "Донат", "[COLOR#FFFFFF]☛ [COLOR#32CD32]$MD$ (30 дней) [COLOR#FFFFFF]➠ [COLOR#ffff00]90р [color #ffffff]☛ [COLOR#32CD32]Навсегда [color#ff0000]➠ [color #ffffff]160р");
					rust.SendChatMessage(netuser, "Донат", "[COLOR#FFFFFF]☛ [COLOR#32CD32]HITMAN (30 дней) [COLOR#FFFFFF]➠ [COLOR#ffff00]70р [color #ffffff]☛ [COLOR#32CD32]Навсегда [color#ff0000]➠ [color #ffffff]110р");
					rust.SendChatMessage(netuser, "Донат", "[COLOR#FFFFFF]☛ [COLOR#32CD32]VIP (30 дней) [COLOR#FFFFFF]➠ [COLOR#ffff00]60р [color #ffffff]☛ [COLOR#32CD32]Навсегда [color#ff0000]➠ [color #ffffff]90р");
					rust.SendChatMessage(netuser, "Донат", "[COLOR#FFFFFF]☛ [COLOR#00ff00]Группа где вы сможете заказать донат [COLOR#FFFFFF]➠ [COLOR#3399ff]vk.com/rust_premium");
				}
}
}

