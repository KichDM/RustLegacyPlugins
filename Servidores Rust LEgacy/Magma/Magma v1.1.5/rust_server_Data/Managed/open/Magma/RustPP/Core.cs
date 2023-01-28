using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Magma;
using RustPP.Commands;
using RustPP.Permissions;
using uLink;

namespace RustPP
{
	// Token: 0x02000057 RID: 87
	public class Core
	{
		// Token: 0x06000261 RID: 609 RVA: 0x0000BD6C File Offset: 0x00009F6C
		static Core()
		{
			global::RustPP.Core.InitializeCommands();
			global::RustPP.Commands.ShareCommand shareCommand = global::RustPP.Commands.ChatCommand.GetCommand("share") as global::RustPP.Commands.ShareCommand;
			global::RustPP.Commands.FriendsCommand friendsCommand = global::RustPP.Commands.ChatCommand.GetCommand("friends") as global::RustPP.Commands.FriendsCommand;
			if (global::System.IO.File.Exists(global::RustPP.Helper.GetAbsoluteFilePath("doorsSave.rpp")))
			{
				shareCommand.SetSharedDoors(global::RustPP.Helper.ObjectFromFile<global::System.Collections.Hashtable>(global::RustPP.Helper.GetAbsoluteFilePath("doorsSave.rpp")));
			}
			if (global::System.IO.File.Exists(global::RustPP.Helper.GetAbsoluteFilePath("friendsSave.rpp")))
			{
				friendsCommand.SetFriendsLists(global::RustPP.Helper.ObjectFromFile<global::System.Collections.Hashtable>(global::RustPP.Helper.GetAbsoluteFilePath("friendsSave.rpp")));
			}
			if (global::System.IO.File.Exists(global::RustPP.Helper.GetAbsoluteFilePath("admins.xml")))
			{
				global::RustPP.Permissions.Administrator.AdminList = global::RustPP.Helper.ObjectFromXML<global::System.Collections.Generic.List<global::RustPP.Permissions.Administrator>>(global::RustPP.Helper.GetAbsoluteFilePath("admins.xml"));
			}
			if (global::System.IO.File.Exists(global::RustPP.Helper.GetAbsoluteFilePath("cache.rpp")))
			{
				global::RustPP.Core.userCache = global::RustPP.Helper.ObjectFromFile<global::System.Collections.Generic.Dictionary<ulong, string>>(global::RustPP.Helper.GetAbsoluteFilePath("cache.rpp"));
			}
			else
			{
				global::RustPP.Core.userCache = new global::System.Collections.Generic.Dictionary<ulong, string>();
			}
			if (global::System.IO.File.Exists(global::RustPP.Helper.GetAbsoluteFilePath("whitelist.xml")))
			{
				global::RustPP.Core.whiteList = new global::RustPP.PList(global::RustPP.Helper.ObjectFromXML<global::System.Collections.Generic.List<global::RustPP.PList.Player>>(global::RustPP.Helper.GetAbsoluteFilePath("whitelist.xml")));
			}
			else
			{
				global::RustPP.Core.whiteList = new global::RustPP.PList();
			}
			if (global::System.IO.File.Exists(global::RustPP.Helper.GetAbsoluteFilePath("bans.xml")))
			{
				global::RustPP.Core.blackList = new global::RustPP.PList(global::RustPP.Helper.ObjectFromXML<global::System.Collections.Generic.List<global::RustPP.PList.Player>>(global::RustPP.Helper.GetAbsoluteFilePath("bans.xml")));
				return;
			}
			global::RustPP.Core.blackList = new global::RustPP.PList();
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000BEF4 File Offset: 0x0000A0F4
		private static void InitializeCommands()
		{
			global::RustPP.Commands.ChatCommand.AddCommand("/about", new global::RustPP.Commands.AboutCommand());
			global::RustPP.Commands.ChatCommand.AddCommand("/addfriend", new global::RustPP.Commands.AddFriendCommand());
			global::RustPP.Commands.ChatCommand.AddCommand("/addadmin", new global::RustPP.Commands.AddAdminCommand
			{
				AdminFlags = "CanAddAdmin"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/addflag", new global::RustPP.Commands.AddFlagCommand
			{
				AdminFlags = "CanAddFlags"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/announce", new global::RustPP.Commands.AnnounceCommand
			{
				AdminFlags = "CanAnnounce"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/ban", new global::RustPP.Commands.BanCommand
			{
				AdminFlags = "CanBan"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/friends", new global::RustPP.Commands.FriendsCommand());
			global::RustPP.Commands.ChatCommand.AddCommand("/getflags", new global::RustPP.Commands.GetFlagsCommand
			{
				AdminFlags = "CanGetFlags"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/give", new global::RustPP.Commands.GiveItemCommand
			{
				AdminFlags = "CanGiveItem"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/god", new global::RustPP.Commands.GodModeCommand
			{
				AdminFlags = "CanGodMode"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/help", new global::RustPP.Commands.HelpCommand());
			global::RustPP.Commands.ChatCommand.AddCommand("/history", new global::RustPP.Commands.HistoryCommand());
			global::RustPP.Commands.ChatCommand.AddCommand("/i", new global::RustPP.Commands.SpawnItemCommand
			{
				AdminFlags = "CanSpawnItem"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/instako", new global::RustPP.Commands.InstaKOCommand
			{
				AdminFlags = "CanInstaKO"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/kick", new global::RustPP.Commands.KickCommand
			{
				AdminFlags = "CanKick"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/kill", new global::RustPP.Commands.KillCommand
			{
				AdminFlags = "CanKill"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/loadout", new global::RustPP.Commands.LoadoutCommand
			{
				AdminFlags = "CanLoadout"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/motd", new global::RustPP.Commands.MOTDCommand());
			global::RustPP.Commands.ChatCommand.AddCommand("/mute", new global::RustPP.Commands.MuteCommand
			{
				AdminFlags = "CanMute"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/location", new global::RustPP.Commands.LocationCommand());
			global::RustPP.Commands.ChatCommand.AddCommand("/ping", new global::RustPP.Commands.PingCommand());
			global::RustPP.Commands.ChatCommand.AddCommand("/players", new global::RustPP.Commands.PlayersCommand());
			global::RustPP.Commands.ChatCommand.AddCommand("/pm", new global::RustPP.Commands.PrivateMessagesCommand());
			global::RustPP.Commands.ChatCommand.AddCommand("/reload", new global::RustPP.Commands.ReloadCommand
			{
				AdminFlags = "CanReload"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/unadmin", new global::RustPP.Commands.RemoveAdminCommand
			{
				AdminFlags = "CanDeleteAdmin"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/r", new global::RustPP.Commands.ReplyCommand());
			global::RustPP.Commands.ChatCommand.AddCommand("/rules", new global::RustPP.Commands.RulesCommand());
			global::RustPP.Commands.ChatCommand.AddCommand("/saveall", new global::RustPP.Commands.SaveAllCommand
			{
				AdminFlags = "CanSaveAll"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/setmasteradmin", new global::RustPP.Commands.MasterAdminCommand
			{
				AdminFlags = "RCON"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/share", new global::RustPP.Commands.ShareCommand());
			global::RustPP.Commands.ChatCommand.AddCommand("/starter", new global::RustPP.Commands.StarterCommand());
			global::RustPP.Commands.ChatCommand.AddCommand("/tphere", new global::RustPP.Commands.TeleportHereCommand
			{
				AdminFlags = "CanTeleport"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/tpto", new global::RustPP.Commands.TeleportToCommand
			{
				AdminFlags = "CanTeleport"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/unban", new global::RustPP.Commands.UnbanCommand
			{
				AdminFlags = "CanUnban"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/unfriend", new global::RustPP.Commands.UnfriendCommand());
			global::RustPP.Commands.ChatCommand.AddCommand("/unflag", new global::RustPP.Commands.RemoveFlagsCommand
			{
				AdminFlags = "CanUnflag"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/unmute", new global::RustPP.Commands.UnmuteCommand
			{
				AdminFlags = "CanUnmute"
			});
			global::RustPP.Commands.ChatCommand.AddCommand("/unshare", new global::RustPP.Commands.UnshareCommand());
			global::RustPP.Commands.ChatCommand.AddCommand("/addwl", new global::RustPP.Commands.WhiteListAddCommand
			{
				AdminFlags = "CanWhiteList"
			});
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000C2B0 File Offset: 0x0000A4B0
		public static void motd(global::uLink.NetworkPlayer player)
		{
			if (global::RustPP.Core.config.GetSetting("Settings", "motd") == "true")
			{
				int num = 1;
				do
				{
					string setting = global::RustPP.Core.config.GetSetting("Settings", "motd" + num);
					if (setting != null)
					{
						global::Magma.Util.sayUser(player, setting);
						num++;
					}
					else
					{
						num = 0;
					}
				}
				while (num != 0);
			}
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000C314 File Offset: 0x0000A514
		public static void handleCommand(ref global::ConsoleSystem.Arg arg)
		{
			string displayname = arg.argUser.user.Displayname;
			string text = arg.GetString(0, "text").Trim();
			string[] array = text.Split(new char[]
			{
				' '
			});
			text = array[0].Trim();
			string[] array2 = new string[array.Length - 1];
			for (int i = 1; i < array.Length; i++)
			{
				array2[i - 1] = array[i];
			}
			global::RustPP.Commands.ChatCommand.CallCommand(text, ref arg, ref array2);
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000C390 File Offset: 0x0000A590
		public static bool IsEnabled()
		{
			if (global::RustPP.Core.config == null)
			{
				return false;
			}
			string setting = global::RustPP.Core.config.GetSetting("Settings", "rust++_enabled");
			return setting != null && !(setting == "false") && setting == "true";
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000C3DF File Offset: 0x0000A5DF
		public Core()
		{
		}

		// Token: 0x04000082 RID: 130
		public static global::IniParser config;

		// Token: 0x04000083 RID: 131
		public static global::System.Collections.Generic.Dictionary<ulong, string> userCache;

		// Token: 0x04000084 RID: 132
		public static global::RustPP.PList whiteList = new global::RustPP.PList();

		// Token: 0x04000085 RID: 133
		public static global::RustPP.PList blackList = new global::RustPP.PList();

		// Token: 0x04000086 RID: 134
		public static global::System.Collections.Hashtable banWaitList = new global::System.Collections.Hashtable();

		// Token: 0x04000087 RID: 135
		public static global::System.Collections.Hashtable kickWaitList = new global::System.Collections.Hashtable();

		// Token: 0x04000088 RID: 136
		public static global::System.Collections.Generic.List<ulong> muteList = new global::System.Collections.Generic.List<ulong>();

		// Token: 0x04000089 RID: 137
		public static global::System.Collections.Generic.List<ulong> tempConnect = new global::System.Collections.Generic.List<ulong>();

		// Token: 0x0400008A RID: 138
		public static string Version = "1.5.5";
	}
}
