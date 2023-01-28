using System;

namespace RustPP.Commands
{
	// Token: 0x02000042 RID: 66
	internal class MOTDCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x0600022F RID: 559 RVA: 0x00009D74 File Offset: 0x00007F74
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			global::RustPP.Core.motd(Arguments.argUser.networkPlayer);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00009D87 File Offset: 0x00007F87
		public MOTDCommand()
		{
		}
	}
}
