using System;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x02000030 RID: 48
	public class AboutCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000203 RID: 515 RVA: 0x0000814C File Offset: 0x0000634C
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "This server is currently running on Rust++ v" + global::RustPP.Core.Version);
			global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Brought to you by xEnt & EquiFox17");
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00008184 File Offset: 0x00006384
		public AboutCommand()
		{
		}
	}
}
