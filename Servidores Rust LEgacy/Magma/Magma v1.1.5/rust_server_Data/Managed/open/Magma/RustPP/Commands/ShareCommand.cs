using System;
using System.Collections;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x0200004D RID: 77
	public class ShareCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000247 RID: 583 RVA: 0x0000AA60 File Offset: 0x00008C60
		public void SetSharedDoors(global::System.Collections.Hashtable sd)
		{
			global::RustPP.Commands.ShareCommand.shared_doors = sd;
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000AA68 File Offset: 0x00008C68
		public global::System.Collections.Hashtable GetSharedDoors()
		{
			return global::RustPP.Commands.ShareCommand.shared_doors;
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000AA70 File Offset: 0x00008C70
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
								global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Why would you share with yourself?");
								return;
							}
							global::System.Collections.ArrayList arrayList = (global::System.Collections.ArrayList)global::RustPP.Commands.ShareCommand.shared_doors[userID2];
							if (arrayList != null)
							{
								if (arrayList.Contains(userID))
								{
									global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Doors were already shared with " + playerClient.netUser.displayName);
									return;
								}
							}
							else
							{
								arrayList = new global::System.Collections.ArrayList();
								global::RustPP.Commands.ShareCommand.shared_doors.Add(userID2, arrayList);
							}
							arrayList.Add(userID);
							global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You have shared all doors with " + playerClient.netUser.displayName);
							global::Magma.Util.sayUser(playerClient.netPlayer, Arguments.argUser.displayName + " has shared all doors with you");
							return;
						}
					}
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "No player found with the name: " + text);
					return;
				}
			}
			else
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Sharing Doors Usage:   /share \"playerName\"");
			}
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000AC70 File Offset: 0x00008E70
		public ShareCommand()
		{
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000AC64 File Offset: 0x00008E64
		// Note: this type is marked as 'beforefieldinit'.
		static ShareCommand()
		{
		}

		// Token: 0x0400007F RID: 127
		public static global::System.Collections.Hashtable shared_doors = new global::System.Collections.Hashtable();
	}
}
