using System;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x0200004C RID: 76
	public class SaveAllCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000245 RID: 581 RVA: 0x0000A9F8 File Offset: 0x00008BF8
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			global::AvatarSaveProc.SaveAll();
			global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Saved ALL Avatar files !");
			global::ServerSaveManager.AutoSave();
			global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Saved server global state !");
			global::RustPP.Helper.CreateSaves();
			global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Saved Rust++ data !");
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000AA58 File Offset: 0x00008C58
		public SaveAllCommand()
		{
		}
	}
}
