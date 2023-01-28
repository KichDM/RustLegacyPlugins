using System;
using System.Collections;
using Magma;
using RustPP.Commands;
using RustPP.Permissions;
using RustPP.Social;

namespace RustPP
{
	// Token: 0x02000059 RID: 89
	internal class Hooks
	{
		// Token: 0x0600026E RID: 622 RVA: 0x0000C740 File Offset: 0x0000A940
		public static bool IsFriend(ref global::DamageEvent e)
		{
			global::RustPP.Commands.GodModeCommand godModeCommand = (global::RustPP.Commands.GodModeCommand)global::RustPP.Commands.ChatCommand.GetCommand("god");
			bool result;
			try
			{
				global::RustPP.Commands.FriendsCommand friendsCommand = (global::RustPP.Commands.FriendsCommand)global::RustPP.Commands.ChatCommand.GetCommand("friends");
				global::RustPP.Social.FriendList friendList = (global::RustPP.Social.FriendList)friendsCommand.GetFriendsLists()[e.attacker.userID];
				if (global::RustPP.Core.config.GetSetting("Settings", "friendly_fire") == "true")
				{
					result = godModeCommand.IsOn(e.victim.userID);
				}
				else if (friendList == null)
				{
					result = godModeCommand.IsOn(e.victim.userID);
				}
				else if (friendList.isFriendWith(e.victim.userID))
				{
					result = true;
				}
				else
				{
					result = godModeCommand.IsOn(e.victim.userID);
				}
			}
			catch (global::System.Exception)
			{
				result = godModeCommand.IsOn(e.victim.userID);
			}
			return result;
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000C82C File Offset: 0x0000AA2C
		public static bool KeepItem()
		{
			bool result;
			try
			{
				result = (global::RustPP.Core.config.GetSetting("Settings", "keepitems") == "true");
			}
			catch (global::System.Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000C870 File Offset: 0x0000AA70
		public static bool checkOwner(global::DeployableObject obj, global::Controllable controllable)
		{
			if (obj.ownerID == controllable.playerClient.userID)
			{
				return true;
			}
			bool result;
			try
			{
				global::SleepingBag sleepingBag = (global::SleepingBag)obj;
				result = false;
			}
			catch (global::System.Exception)
			{
				try
				{
					global::RustPP.Commands.ShareCommand shareCommand = global::RustPP.Commands.ChatCommand.GetCommand("share") as global::RustPP.Commands.ShareCommand;
					global::System.Collections.ArrayList arrayList = (global::System.Collections.ArrayList)shareCommand.GetSharedDoors()[obj.ownerID];
					if (arrayList == null)
					{
						result = false;
					}
					else if (arrayList.Contains(controllable.playerClient.userID))
					{
						result = true;
					}
					else
					{
						result = false;
					}
				}
				catch (global::System.Exception)
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000C914 File Offset: 0x0000AB14
		public static void broadcastDeath(string victim, string killer, string weapon)
		{
			try
			{
				if (global::RustPP.Core.config.GetSetting("Settings", "pvp_death_broadcast") == "true")
				{
					global::Magma.Util.sayAll(string.Concat(new string[]
					{
						killer,
						" ",
						'⊕'.ToString(),
						" ",
						victim,
						" (",
						weapon,
						")"
					}));
				}
			}
			catch (global::System.Exception)
			{
			}
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000C9A4 File Offset: 0x0000ABA4
		public static bool loginNotice(global::NetUser user)
		{
			try
			{
				if (global::RustPP.Core.blackList.Contains(user.userID))
				{
					global::RustPP.Core.tempConnect.Add(user.userID);
					user.Kick(global::NetError.Facepunch_Connector_VAC_Banned, true);
					return false;
				}
				if (global::RustPP.Core.config.GetSetting("WhiteList", "enabled") != null && global::RustPP.Core.config.GetSetting("WhiteList", "enabled") == "true" && !global::RustPP.Core.whiteList.Contains(user.userID))
				{
					user.Kick(global::NetError.Facepunch_Connector_AuthFailure, true);
				}
				if (!global::RustPP.Core.userCache.ContainsKey(user.userID))
				{
					global::RustPP.Core.userCache.Add(user.userID, user.displayName);
				}
				else if (user.displayName != global::RustPP.Core.userCache[user.userID])
				{
					global::RustPP.Core.userCache[user.userID] = user.displayName;
				}
				if (global::RustPP.Permissions.Administrator.IsAdmin(user.userID) && global::RustPP.Permissions.Administrator.GetAdmin(user.userID).HasPermission("RCON"))
				{
					user.admin = true;
				}
				global::RustPP.Core.motd(user.networkPlayer);
				if (global::RustPP.Core.config.GetSetting("Settings", "join_notice") == "true")
				{
					foreach (global::PlayerClient playerClient in global::PlayerClient.All)
					{
						if (playerClient.userID != user.userID)
						{
							global::Magma.Util.sayUser(playerClient.netPlayer, user.displayName + " has joined the server");
						}
					}
				}
			}
			catch (global::System.Exception)
			{
			}
			return true;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000CB84 File Offset: 0x0000AD84
		public static void logoffNotice(global::NetUser user)
		{
			try
			{
				if (global::RustPP.Core.tempConnect.Contains(user.userID))
				{
					global::RustPP.Core.tempConnect.Remove(user.userID);
				}
				else if (global::RustPP.Core.config.GetSetting("Settings", "leave_notice") == "true")
				{
					foreach (global::PlayerClient playerClient in global::PlayerClient.All)
					{
						if (playerClient.userID != user.userID)
						{
							global::Magma.Util.sayUser(playerClient.netPlayer, user.displayName + " has left the server");
						}
					}
				}
			}
			catch (global::System.Exception)
			{
			}
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000CC50 File Offset: 0x0000AE50
		public static void deployableKO(global::DeployableObject dep, global::DamageEvent e)
		{
			try
			{
				global::RustPP.Commands.InstaKOCommand instaKOCommand = global::RustPP.Commands.ChatCommand.GetCommand("instako") as global::RustPP.Commands.InstaKOCommand;
				if (instaKOCommand.IsOn(e.attacker.client.userID))
				{
					try
					{
						global::RustPP.Helper.Log("StructDestroyed.txt", string.Concat(new object[]
						{
							e.attacker.client.netUser.displayName,
							" [",
							e.attacker.client.netUser.userID,
							"] destroyed (InstaKO) ",
							global::NetUser.FindByUserID(dep.ownerID).displayName,
							"'s ",
							dep.gameObject.name.Replace("(Clone)", "")
						}));
					}
					catch (global::System.Exception)
					{
						if (global::RustPP.Core.userCache.ContainsKey(dep.ownerID))
						{
							global::RustPP.Helper.Log("StructDestroyed.txt", string.Concat(new object[]
							{
								e.attacker.client.netUser.displayName,
								" [",
								e.attacker.client.netUser.userID,
								"] destroyed (InstaKO) ",
								global::RustPP.Core.userCache[dep.ownerID],
								"'s ",
								dep.gameObject.name.Replace("(Clone)", "")
							}));
						}
					}
					dep.OnKilled();
				}
				else
				{
					dep.UpdateClientHealth();
				}
			}
			catch (global::System.Exception)
			{
				dep.UpdateClientHealth();
			}
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000CE20 File Offset: 0x0000B020
		public static void structureKO(global::StructureComponent sc, global::DamageEvent e)
		{
			try
			{
				global::RustPP.Commands.InstaKOCommand instaKOCommand = global::RustPP.Commands.ChatCommand.GetCommand("instako") as global::RustPP.Commands.InstaKOCommand;
				if (instaKOCommand.IsOn(e.attacker.client.userID))
				{
					sc.StartCoroutine("DelayedKill");
				}
				else
				{
					sc.UpdateClientHealth();
				}
			}
			catch (global::System.Exception)
			{
				sc.UpdateClientHealth();
			}
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000CE88 File Offset: 0x0000B088
		public static bool decayDisabled()
		{
			bool result;
			try
			{
				result = (global::RustPP.Core.config.GetSetting("Settings", "decay") == "false");
			}
			catch (global::System.Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000CECC File Offset: 0x0000B0CC
		public Hooks()
		{
		}
	}
}
