using System;
using System.Collections.Generic;
using Magma;
using RustPP.Permissions;

namespace RustPP.Commands
{
	// Token: 0x0200003D RID: 61
	internal class KickCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000223 RID: 547 RVA: 0x00009484 File Offset: 0x00007684
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
				if (text != "")
				{
					global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>();
					list.Add("Cancel");
					foreach (global::PlayerClient playerClient in global::PlayerClient.All)
					{
						if (playerClient.netUser.displayName.ToLower().Contains(text.ToLower()))
						{
							if (playerClient.netUser.displayName.ToLower() == text.ToLower())
							{
								if (Arguments.argUser.userID == playerClient.userID)
								{
									global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You can't kick yourself.");
									return;
								}
								if (global::RustPP.Permissions.Administrator.IsAdmin(playerClient.userID) && !global::RustPP.Permissions.Administrator.GetAdmin(Arguments.argUser.userID).HasPermission("RCON"))
								{
									global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You cannot kick an administrator !");
									return;
								}
								global::RustPP.Core.kickWaitList.Remove(Arguments.argUser.userID);
								string displayName = playerClient.netUser.displayName;
								global::RustPP.Permissions.Administrator.NotifyAdmins(displayName + " has been kicked.");
								playerClient.netUser.Kick(global::NetError.Facepunch_Kick_Violation, true);
								return;
							}
							else
							{
								list.Add(playerClient.netUser.displayName);
							}
						}
					}
					if (list.Count != 1)
					{
						global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, (list.Count - 1).ToString() + " Player" + ((list.Count - 1 > 1) ? "s" : "") + " were found :");
						for (int j = 1; j < list.Count; j++)
						{
							global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, j + " - " + list[j]);
						}
						global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "0 - Cancel");
						global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Please enter the number matching the player you were looking for.");
						global::RustPP.Core.kickWaitList.Add(Arguments.argUser.userID, list);
						return;
					}
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "No player found with the name: " + text);
					return;
				}
			}
			else
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Kick Usage:   /kick \"playerName\"");
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00009764 File Offset: 0x00007964
		public void PartialNameKick(ref global::ConsoleSystem.Arg Arguments, int id)
		{
			if (global::RustPP.Core.kickWaitList.Contains(Arguments.argUser.userID))
			{
				global::System.Collections.Generic.List<string> list = (global::System.Collections.Generic.List<string>)global::RustPP.Core.kickWaitList[Arguments.argUser.userID];
				string b = list[id];
				if (id == 0)
				{
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Cancelled !");
					global::RustPP.Core.kickWaitList.Remove(Arguments.argUser.userID);
					return;
				}
				foreach (global::PlayerClient playerClient in global::PlayerClient.All)
				{
					if (playerClient.netUser.displayName == b)
					{
						global::RustPP.Core.kickWaitList.Remove(Arguments.argUser.userID);
						if (global::RustPP.Permissions.Administrator.IsAdmin(playerClient.userID) && !global::RustPP.Permissions.Administrator.GetAdmin(Arguments.argUser.userID).HasPermission("RCON"))
						{
							global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You cannot kick an administrator !");
							break;
						}
						string displayName = playerClient.netUser.displayName;
						global::RustPP.Permissions.Administrator.NotifyAdmins(displayName + " has been kicked.");
						playerClient.netUser.Kick(global::NetError.Facepunch_Kick_Violation, true);
						break;
					}
				}
				global::RustPP.Core.kickWaitList.Remove(Arguments.argUser.userID);
			}
		}

		// Token: 0x06000225 RID: 549 RVA: 0x000098F4 File Offset: 0x00007AF4
		public KickCommand()
		{
		}
	}
}
