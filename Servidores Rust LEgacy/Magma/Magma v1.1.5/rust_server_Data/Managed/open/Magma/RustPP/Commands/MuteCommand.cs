using System;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x02000043 RID: 67
	internal class MuteCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000231 RID: 561 RVA: 0x00009D90 File Offset: 0x00007F90
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			string text = "";
			for (int i = 0; i < ChatArguments.Length; i++)
			{
				text = text + ChatArguments[i] + " ";
			}
			text = text.Trim();
			if ((ChatArguments != null || text == "") && text != "")
			{
				foreach (global::PlayerClient playerClient in global::PlayerClient.All)
				{
					if (playerClient.netUser.displayName.ToLower() == text.ToLower())
					{
						if (!global::RustPP.Core.muteList.Contains(playerClient.userID))
						{
							global::RustPP.Core.muteList.Add(playerClient.userID);
							global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, playerClient.netUser.displayName + " has been muted !");
							return;
						}
						global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, playerClient.netUser.displayName + " is already muted.");
						return;
					}
				}
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "No player found with the name : " + text);
			}
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00009EDC File Offset: 0x000080DC
		public MuteCommand()
		{
		}
	}
}
