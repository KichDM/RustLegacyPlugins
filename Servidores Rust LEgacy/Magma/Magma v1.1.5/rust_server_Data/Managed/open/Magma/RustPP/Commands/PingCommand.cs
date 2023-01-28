using System;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x02000044 RID: 68
	public class PingCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000233 RID: 563 RVA: 0x00009EE4 File Offset: 0x000080E4
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Ping: " + Arguments.argUser.networkPlayer.lastPing);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00009F25 File Offset: 0x00008125
		public PingCommand()
		{
		}
	}
}
