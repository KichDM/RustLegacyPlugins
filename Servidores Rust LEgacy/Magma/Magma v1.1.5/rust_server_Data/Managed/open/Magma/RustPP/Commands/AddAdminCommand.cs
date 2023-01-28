using System;
using Magma;
using RustPP.Permissions;

namespace RustPP.Commands
{
	// Token: 0x02000031 RID: 49
	internal class AddAdminCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000205 RID: 517 RVA: 0x0000818C File Offset: 0x0000638C
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
					foreach (global::PlayerClient playerClient in global::PlayerClient.All)
					{
						ulong userID = playerClient.userID;
						ulong userID2 = Arguments.argUser.userID;
						if (playerClient.netUser.displayName.ToLower() == text.ToLower())
						{
							if (userID == userID2)
							{
								global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Seriously ? You are already an admin...");
								return;
							}
							if (global::RustPP.Permissions.Administrator.IsAdmin(userID))
							{
								global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, playerClient.netUser.displayName + " is already an administrator.");
								return;
							}
							global::RustPP.Permissions.Administrator.AddAdmin(new global::RustPP.Permissions.Administrator(userID, playerClient.netUser.displayName));
							global::RustPP.Permissions.Administrator.NotifyAdmins(playerClient.netUser.displayName + " is now an administrator !");
							return;
						}
					}
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "No player found with the name: " + text);
					return;
				}
			}
			else
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "AddAdmin Usage:   /addadmin \"playerName\"");
			}
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00008314 File Offset: 0x00006514
		public AddAdminCommand()
		{
		}
	}
}
