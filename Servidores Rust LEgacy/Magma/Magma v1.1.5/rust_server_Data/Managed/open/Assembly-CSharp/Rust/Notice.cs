using System;
using Facepunch.Utility;
using uLink;

namespace Rust
{
	// Token: 0x0200051D RID: 1309
	public static class Notice
	{
		// Token: 0x06002C77 RID: 11383 RVA: 0x000A7F14 File Offset: 0x000A6114
		public static void Popup(global::uLink.NetworkPlayer target, string strIcon, string strText, float fDuration = 4f)
		{
			strIcon = global::Facepunch.Utility.String.QuoteSafe(strIcon);
			strText = global::Facepunch.Utility.String.QuoteSafe(strText);
			global::ConsoleNetworker.SendClientCommand(target, string.Concat(new string[]
			{
				"notice.popup ",
				fDuration.ToString(),
				" ",
				strIcon,
				" ",
				strText
			}));
		}

		// Token: 0x06002C78 RID: 11384 RVA: 0x000A7F6C File Offset: 0x000A616C
		public static void Inventory(global::uLink.NetworkPlayer target, string strText)
		{
			strText = global::Facepunch.Utility.String.QuoteSafe(strText);
			global::ConsoleNetworker.SendClientCommand(target, "notice.inventory " + strText);
		}
	}
}
