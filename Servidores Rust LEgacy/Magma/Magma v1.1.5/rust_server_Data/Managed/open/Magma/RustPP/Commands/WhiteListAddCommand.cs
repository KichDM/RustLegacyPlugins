using System;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x02000056 RID: 86
	internal class WhiteListAddCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x0600025F RID: 607 RVA: 0x0000BC40 File Offset: 0x00009E40
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			string text = "";
			for (int i = 0; i < ChatArguments.Length; i++)
			{
				text = text + ChatArguments[i] + " ";
			}
			text = text.Trim();
			global::PlayerClient playerClient = null;
			foreach (global::PlayerClient playerClient2 in global::PlayerClient.All)
			{
				if (playerClient2.netUser.displayName.ToLower() == text.ToLower())
				{
					playerClient = playerClient2;
				}
			}
			if (playerClient == null)
			{
				return;
			}
			if (!global::RustPP.Core.whiteList.Contains(playerClient.userID))
			{
				global::RustPP.Core.whiteList.Add(playerClient.userID, playerClient.netUser.displayName);
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, playerClient.netUser.displayName + " has been added to the whitelist.");
				global::RustPP.Helper.CreateSaves();
				return;
			}
			global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, playerClient.netUser.displayName + " is already on the whitelist.");
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000BD64 File Offset: 0x00009F64
		public WhiteListAddCommand()
		{
		}
	}
}
