using System;
using System.Collections.Generic;
using Magma;
using Rust;

namespace RustPP.Commands
{
	// Token: 0x02000034 RID: 52
	public class AnnounceCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x0600020B RID: 523 RVA: 0x00008884 File Offset: 0x00006A84
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			if (ChatArguments != null)
			{
				string text = "";
				for (int i = 0; i < ChatArguments.Length; i++)
				{
					text = text + ChatArguments[i] + " ";
				}
				if (text != string.Empty)
				{
					char c = '☢';
					using (global::System.Collections.Generic.List<global::PlayerClient>.Enumerator enumerator = global::PlayerClient.All.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							global::PlayerClient playerClient = enumerator.Current;
							global::Rust.Notice.Popup(playerClient.netPlayer, c.ToString(), text, 5f);
						}
						return;
					}
				}
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Please enter a valid message.");
				return;
			}
			global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Announce Usage:   /announce \"message\"");
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00008954 File Offset: 0x00006B54
		public AnnounceCommand()
		{
		}
	}
}
