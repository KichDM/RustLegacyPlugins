using System;
using Magma;
using RustPP.Permissions;

namespace RustPP.Commands
{
	// Token: 0x02000041 RID: 65
	public class MasterAdminCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x0600022C RID: 556 RVA: 0x00009CEC File Offset: 0x00007EEC
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			if (!global::RustPP.Permissions.Administrator.IsAdmin(Arguments.argUser.userID))
			{
				global::RustPP.Permissions.Administrator.AddAdmin(new global::RustPP.Permissions.Administrator(Arguments.argUser.userID, Arguments.argUser.displayName, global::RustPP.Commands.MasterAdminCommand.MasterAdminPreset));
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You are now a Master Administrator !");
				return;
			}
			global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You are already an administrator !");
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00009D6C File Offset: 0x00007F6C
		public MasterAdminCommand()
		{
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00009D60 File Offset: 0x00007F60
		// Note: this type is marked as 'beforefieldinit'.
		static MasterAdminCommand()
		{
		}

		// Token: 0x0400007D RID: 125
		private static string MasterAdminPreset = "CanKick|CanBan|CanUnban|CanTeleport|CanLoadout|CanAnnounce|CanSpawnItem|CanGiveItem|CanReload|CanSaveAll|CanAddAdmin|CanDeleteAdmin|CanGetFlags|CanInstaKO|CanAddFlags|CanUnflag|CanWhiteList|CanKill|CanMute|CanUnmute|CanGodMode|RCON";
	}
}
