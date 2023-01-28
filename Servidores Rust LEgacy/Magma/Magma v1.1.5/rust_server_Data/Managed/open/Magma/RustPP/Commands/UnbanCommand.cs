using System;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x02000052 RID: 82
	internal class UnbanCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000257 RID: 599 RVA: 0x0000B64C File Offset: 0x0000984C
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			string text = "";
			for (int i = 0; i < ChatArguments.Length; i++)
			{
				text = text + ChatArguments[i] + " ";
			}
			text = text.Trim();
			if (ChatArguments != null || text == "")
			{
				if (text != null)
				{
					int num = 0;
					foreach (global::RustPP.PList.Player player in global::RustPP.Core.blackList.Values)
					{
						if (player.DisplayName.ToLower() == text.ToLower())
						{
							global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, player.DisplayName + " has been unbanned.");
							global::RustPP.Core.blackList.Remove(player.UserID);
						}
						else
						{
							num++;
						}
					}
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, text + " is not banned.");
					return;
				}
			}
			else
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Unban Usage:   /unban \"playerName\"");
			}
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000B748 File Offset: 0x00009948
		public UnbanCommand()
		{
		}
	}
}
