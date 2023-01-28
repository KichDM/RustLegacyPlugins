using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Core.Configuration;


namespace Oxide.Plugins
{
    [Info("Info", "Unkown", "1.3.6")]
    class Info : RustLegacyPlugin 
	 
	{
  
	[ChatCommand("info")]
				void Sellder(NetUser netuser, string command, string[] args)
		{
						
	rust.SendChatMessage(netuser, "" );
	rust.SendChatMessage(netuser, "" );
	rust.SendChatMessage(netuser, "" );
	rust.SendChatMessage(netuser, "" );

		}
	}
}
	