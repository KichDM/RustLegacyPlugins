using System;
using System.Collections;
using System.Collections.Generic;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x02000051 RID: 81
	public class TeleportToCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000252 RID: 594 RVA: 0x0000B2B4 File Offset: 0x000094B4
		public global::System.Collections.Hashtable GetTPWaitList()
		{
			return global::RustPP.Commands.TeleportToCommand.tpWaitList;
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000B2BC File Offset: 0x000094BC
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			if (ChatArguments == null)
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Teleport Usage:   /tpto \"playerName\"");
				return;
			}
			string text = "";
			for (int i = 0; i < ChatArguments.Length; i++)
			{
				text = text + ChatArguments[i] + " ";
			}
			text = text.Trim();
			if (text != "")
			{
				global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>();
				list.Add("ToTarget");
				foreach (global::PlayerClient playerClient in global::PlayerClient.All)
				{
					if (playerClient.netUser.displayName.ToLower().Contains(text.ToLower()))
					{
						if (playerClient.netUser.displayName.ToLower() == text.ToLower())
						{
							Arguments.Args = new string[]
							{
								Arguments.argUser.displayName,
								playerClient.netUser.displayName
							};
							global::teleport.toplayer(ref Arguments);
							global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You have teleported to " + playerClient.netUser.displayName);
							return;
						}
						list.Add(playerClient.netUser.displayName);
					}
				}
				if (list.Count != 0)
				{
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, (list.Count - 1).ToString() + " Player" + ((list.Count - 1 > 1) ? "s" : "") + " were found :");
					for (int j = 1; j < list.Count; j++)
					{
						global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, j + " - " + list[j]);
					}
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "0 - Cancel");
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Please enter the number matching the player you were looking for.");
					global::RustPP.Commands.TeleportToCommand.tpWaitList.Add(Arguments.argUser.userID, list);
					return;
				}
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "No player found with the name: " + text);
				return;
			}
			global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Teleport Usage:   /tphere \"playerName\"");
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000B530 File Offset: 0x00009730
		public void PartialNameTP(ref global::ConsoleSystem.Arg Arguments, int choice)
		{
			if (global::RustPP.Commands.TeleportToCommand.tpWaitList.Contains(Arguments.argUser.userID))
			{
				global::System.Collections.Generic.List<string> list = (global::System.Collections.Generic.List<string>)global::RustPP.Commands.TeleportToCommand.tpWaitList[Arguments.argUser.userID];
				string text = list[choice];
				if (choice == 0)
				{
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Cancelled !");
					global::RustPP.Commands.TeleportToCommand.tpWaitList.Remove(Arguments.argUser.userID);
					return;
				}
				if (list[0] == "ToTarget")
				{
					Arguments.Args = new string[]
					{
						Arguments.argUser.displayName,
						text
					};
				}
				else
				{
					Arguments.Args = new string[]
					{
						text,
						Arguments.argUser.displayName
					};
				}
				global::teleport.toplayer(ref Arguments);
				global::RustPP.Commands.TeleportToCommand.tpWaitList.Remove(Arguments.argUser.userID);
			}
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000B641 File Offset: 0x00009841
		public TeleportToCommand()
		{
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000B635 File Offset: 0x00009835
		// Note: this type is marked as 'beforefieldinit'.
		static TeleportToCommand()
		{
		}

		// Token: 0x04000081 RID: 129
		public static global::System.Collections.Hashtable tpWaitList = new global::System.Collections.Hashtable();
	}
}
