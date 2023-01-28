using System;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x0200003A RID: 58
	public class HelpCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x0600021C RID: 540 RVA: 0x000092C8 File Offset: 0x000074C8
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "RUST++ Mod");
			int num = 1;
			do
			{
				string setting = global::RustPP.Core.config.GetSetting("Settings", "help_string" + num);
				if (setting != null)
				{
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, setting);
					num++;
				}
				else
				{
					num = 0;
				}
			}
			while (num != 0);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000932D File Offset: 0x0000752D
		public HelpCommand()
		{
		}
	}
}
