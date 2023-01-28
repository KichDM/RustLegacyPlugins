using System;
using System.Collections;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x02000055 RID: 85
	public class UnshareCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x0600025D RID: 605 RVA: 0x0000BA78 File Offset: 0x00009C78
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
								global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Why would you unshare with yourself?");
								return;
							}
							global::RustPP.Commands.ShareCommand shareCommand = (global::RustPP.Commands.ShareCommand)global::RustPP.Commands.ChatCommand.GetCommand("share");
							global::System.Collections.ArrayList arrayList = (global::System.Collections.ArrayList)shareCommand.GetSharedDoors()[userID2];
							if (arrayList != null && arrayList.Contains(userID))
							{
								arrayList.Remove(userID);
								global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You have stopped sharing doors with " + playerClient.netUser.displayName);
								global::Magma.Util.sayUser(playerClient.netPlayer, Arguments.argUser.displayName + " has stopped sharing doors with you");
								return;
							}
						}
					}
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "No player found with the name: " + text);
					return;
				}
			}
			else
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Sharing Doors Usage:   /unshare \"playerName\"");
			}
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000BC38 File Offset: 0x00009E38
		public UnshareCommand()
		{
		}
	}
}
