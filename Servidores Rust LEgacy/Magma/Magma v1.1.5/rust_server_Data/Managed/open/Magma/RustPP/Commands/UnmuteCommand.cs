using System;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x02000054 RID: 84
	internal class UnmuteCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x0600025B RID: 603 RVA: 0x0000B920 File Offset: 0x00009B20
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
						if (global::RustPP.Core.muteList.Contains(playerClient.userID))
						{
							global::RustPP.Core.muteList.Remove(playerClient.userID);
							global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, playerClient.netUser.displayName + " has been unmuted !");
							return;
						}
						global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, playerClient.netUser.displayName + " is not muted.");
						return;
					}
				}
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "No player found with the name : " + text);
			}
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000BA70 File Offset: 0x00009C70
		public UnmuteCommand()
		{
		}
	}
}
