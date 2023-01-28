using System;
using System.Collections.Generic;
using System.IO;
using Magma;
using RustPP.Permissions;

namespace RustPP.Commands
{
	// Token: 0x02000047 RID: 71
	public class ReloadCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000239 RID: 569 RVA: 0x0000A2A4 File Offset: 0x000084A4
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			global::Magma.Data.GetData().Load();
			global::RustPP.Core.config = global::Magma.Data.GetData().GetRPPConfig();
			global::RustPP.TimedEvents.startEvents();
			if (global::System.IO.File.Exists(global::RustPP.Helper.GetAbsoluteFilePath("admins.xml")))
			{
				global::RustPP.Permissions.Administrator.AdminList = global::RustPP.Helper.ObjectFromXML<global::System.Collections.Generic.List<global::RustPP.Permissions.Administrator>>(global::RustPP.Helper.GetAbsoluteFilePath("admins.xml"));
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

		// Token: 0x0600023A RID: 570 RVA: 0x0000A35F File Offset: 0x0000855F
		public ReloadCommand()
		{
		}
	}
}
