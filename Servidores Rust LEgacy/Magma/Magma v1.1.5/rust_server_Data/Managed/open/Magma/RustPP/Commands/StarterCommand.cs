using System;
using System.Collections;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x0200004F RID: 79
	public class StarterCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x0600024E RID: 590 RVA: 0x0000ADA0 File Offset: 0x00008FA0
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			bool flag = false;
			if (!this.starterkits.ContainsKey(Arguments.argUser.playerClient.userID))
			{
				flag = true;
				this.starterkits.Add(Arguments.argUser.playerClient.userID, global::System.Environment.TickCount);
			}
			else
			{
				int num = (int)this.starterkits[Arguments.argUser.playerClient.userID];
				if (global::System.Environment.TickCount - num < int.Parse(global::RustPP.Core.config.GetSetting("Settings", "starterkit_cooldown")) * 0x3E8)
				{
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You must wait awhile before using this..");
				}
				else
				{
					flag = true;
					this.starterkits.Remove(Arguments.argUser.playerClient.userID);
					this.starterkits.Add(Arguments.argUser.playerClient.userID, global::System.Environment.TickCount);
				}
			}
			if (!flag)
			{
				return;
			}
			for (int i = 0; i < int.Parse(global::RustPP.Core.config.GetSetting("StarterKit", "items")); i++)
			{
				string[] args = new string[]
				{
					global::RustPP.Core.config.GetSetting("StarterKit", "item" + (i + 1) + "_name"),
					global::RustPP.Core.config.GetSetting("StarterKit", "item" + (i + 1) + "_amount")
				};
				Arguments.Args = args;
				global::ConsoleSystem.Arg arg = Arguments;
				global::inv.give(ref arg);
			}
			global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You have spawned a Starter Kit!");
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000AF6C File Offset: 0x0000916C
		public StarterCommand()
		{
		}

		// Token: 0x04000080 RID: 128
		private global::System.Collections.Hashtable starterkits = new global::System.Collections.Hashtable();
	}
}
