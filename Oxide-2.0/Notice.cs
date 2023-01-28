using System.Collections.Generic;

namespace Oxide.Plugins
{
    [Info("Notice", "DiGGeT", "1.0.0")]
    class Notice : RustLegacyPlugin
	{

		[ChatCommand("skype")]
		void cmdNotice(NetUser netUser, string command, string[] args)
		{
			var message = "Причина проверки не обсуждается!";
			var icon = "M";
			var duration = 10f;
			rust.Notice(netUser, message, icon, duration);
		}
	}
}