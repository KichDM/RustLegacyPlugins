using System;
using System.IO;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x0200004B RID: 75
	public class RulesCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000243 RID: 579 RVA: 0x0000A984 File Offset: 0x00008B84
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			if (global::System.IO.File.Exists(global::RustPP.Helper.GetAbsoluteFilePath("rules.txt")))
			{
				foreach (string arg in global::System.IO.File.ReadAllLines(global::RustPP.Helper.GetAbsoluteFilePath("rules.txt")))
				{
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, arg);
				}
				return;
			}
			global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "No rules are currently set.");
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0000A9ED File Offset: 0x00008BED
		public RulesCommand()
		{
		}
	}
}
