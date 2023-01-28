using System;
using Magma;
using RustPP.Permissions;

namespace RustPP.Commands
{
	// Token: 0x02000037 RID: 55
	public class GetFlagsCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000215 RID: 533 RVA: 0x00008E9C File Offset: 0x0000709C
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
			if (global::RustPP.Permissions.Administrator.IsAdmin(playerClient.userID))
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, playerClient.netUser.displayName + "'s Flags :");
				int num = 0;
				int num2 = 0;
				string text2 = "";
				foreach (string str in global::RustPP.Permissions.Administrator.GetAdmin(playerClient.userID).Flags)
				{
					num2++;
					if (num2 >= 0x3C)
					{
						num = 0;
						break;
					}
					text2 = text2 + str + ",  ";
					if (num == 6)
					{
						num = 0;
						global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, text2.Substring(0, text2.Length - 3));
						text2 = "";
					}
					else
					{
						num++;
					}
				}
				if (num != 0)
				{
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, text2.Substring(0, text2.Length - 3));
					return;
				}
			}
			else
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, playerClient.netUser.displayName + " is not an administrator.");
			}
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00009070 File Offset: 0x00007270
		public GetFlagsCommand()
		{
		}
	}
}
