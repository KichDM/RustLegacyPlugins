using System;
using System.Collections.Generic;
using Magma;
using RustPP.Permissions;

namespace RustPP.Commands
{
	// Token: 0x02000035 RID: 53
	internal class BanCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x0600020D RID: 525 RVA: 0x0000895C File Offset: 0x00006B5C
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
							if (Arguments.argUser.userID == playerClient.userID)
							{
								global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You can't ban yourself.");
								return;
							}
							if (playerClient.netUser.displayName.ToLower() == text.ToLower())
							{
								if (global::RustPP.Permissions.Administrator.IsAdmin(playerClient.userID) && !global::RustPP.Permissions.Administrator.GetAdmin(Arguments.argUser.userID).HasPermission("RCON"))
								{
									global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You cannot ban an administrator !");
									return;
								}
								global::RustPP.Core.blackList.Add(playerClient.netUser.userID, playerClient.netUser.displayName);
								global::RustPP.Permissions.Administrator.NotifyAdmins(playerClient.netUser.displayName + " has been banned.");
								playerClient.netUser.Kick(global::NetError.Facepunch_Connector_VAC_Banned, true);
								global::RustPP.Core.banWaitList.Remove(Arguments.argUser.userID);
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
						global::RustPP.Core.banWaitList.Add(Arguments.argUser.userID, list);
						global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "No player found with the name: " + text);
						return;
					}
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "No player found with the name: " + text);
					return;
				}
			}
			else
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Ban Usage:   /ban \"playerName\"");
			}
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00008C74 File Offset: 0x00006E74
		public void PartialNameBan(ref global::ConsoleSystem.Arg Arguments, int id)
		{
			if (global::RustPP.Core.banWaitList.Contains(Arguments.argUser.userID))
			{
				global::System.Collections.Generic.List<string> list = (global::System.Collections.Generic.List<string>)global::RustPP.Core.banWaitList[Arguments.argUser.userID];
				string b = list[id];
				if (id == 0)
				{
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Cancelled !");
					global::RustPP.Core.banWaitList.Remove(Arguments.argUser.userID);
					return;
				}
				foreach (global::PlayerClient playerClient in global::PlayerClient.All)
				{
					if (playerClient.netUser.displayName == b)
					{
						global::RustPP.Core.banWaitList.Remove(Arguments.argUser.userID);
						if (global::RustPP.Permissions.Administrator.IsAdmin(playerClient.userID) && !global::RustPP.Permissions.Administrator.GetAdmin(Arguments.argUser.userID).HasPermission("RCON"))
						{
							global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You cannot ban an administrator !");
							break;
						}
						global::RustPP.Core.blackList.Add(playerClient.netUser.userID, playerClient.netUser.displayName);
						global::RustPP.Permissions.Administrator.NotifyAdmins(playerClient.netUser.displayName + " has been banned.");
						playerClient.netUser.Kick(global::NetError.Facepunch_Connector_VAC_Banned, true);
						break;
					}
				}
			}
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00008E04 File Offset: 0x00007004
		public BanCommand()
		{
		}
	}
}
