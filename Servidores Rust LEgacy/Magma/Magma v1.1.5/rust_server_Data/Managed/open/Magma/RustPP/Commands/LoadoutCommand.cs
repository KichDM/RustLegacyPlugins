using System;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x0200003F RID: 63
	public class LoadoutCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000228 RID: 552 RVA: 0x00009A28 File Offset: 0x00007C28
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			try
			{
				for (int i = 1; i < int.Parse(global::RustPP.Core.config.GetSetting("AdminLoadout", "items") + 1); i++)
				{
					string[] args = new string[]
					{
						global::RustPP.Core.config.GetSetting("AdminLoadout", "item" + i + "_name"),
						global::RustPP.Core.config.GetSetting("AdminLoadout", "item" + i + "_amount")
					};
					Arguments.Args = args;
					global::inv.give(ref Arguments);
				}
			}
			catch (global::System.Exception)
			{
			}
			global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You have spawned an Admin Loadout!");
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00009AF8 File Offset: 0x00007CF8
		public LoadoutCommand()
		{
		}
	}
}
