using System;
using Magma;
using RustPP.Permissions;

namespace RustPP.Commands
{
	// Token: 0x02000048 RID: 72
	internal class RemoveAdminCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x0600023B RID: 571 RVA: 0x0000A368 File Offset: 0x00008568
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
								global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Seriously ? You can't unadmin yourself...");
								return;
							}
							if (global::RustPP.Permissions.Administrator.IsAdmin(userID))
							{
								global::RustPP.Permissions.Administrator.DeleteAdmin(userID);
								global::RustPP.Permissions.Administrator.NotifyAdmins(playerClient.netUser.displayName + " is not an administrator anymore !");
								return;
							}
							global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, playerClient.netUser.displayName + " is not an administrator.");
							return;
						}
					}
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "No player found with the name: " + text);
					return;
				}
			}
			else
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Remove Admin Usage:   /unadmin \"playerName\"");
			}
		}

		// Token: 0x0600023C RID: 572 RVA: 0x0000A4D8 File Offset: 0x000086D8
		public RemoveAdminCommand()
		{
		}
	}
}
