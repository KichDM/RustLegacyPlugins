using System;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x0200003B RID: 59
	public class HistoryCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x0600021E RID: 542 RVA: 0x00009338 File Offset: 0x00007538
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			for (int i = 1 + int.Parse(global::RustPP.Core.config.GetSetting("Settings", "chat_history_amount")); i > 0; i--)
			{
				if (global::Magma.Data.GetData().chat_history_username.Count >= i)
				{
					string text = global::Magma.Data.GetData().chat_history_username[global::Magma.Data.GetData().chat_history_username.Count - i];
					string arg = global::Magma.Data.GetData().chat_history[global::Magma.Data.GetData().chat_history.Count - i];
					if (text != null)
					{
						global::Magma.Util.say(Arguments.argUser.networkPlayer, text, arg);
					}
				}
			}
		}

		// Token: 0x0600021F RID: 543 RVA: 0x000093D5 File Offset: 0x000075D5
		public HistoryCommand()
		{
		}
	}
}
