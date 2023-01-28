using System;
using System.Collections.Generic;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x0200003C RID: 60
	internal class InstaKOCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000220 RID: 544 RVA: 0x000093DD File Offset: 0x000075DD
		public bool IsOn(ulong uid)
		{
			return this.userIDs.Contains(uid);
		}

		// Token: 0x06000221 RID: 545 RVA: 0x000093EC File Offset: 0x000075EC
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			if (!this.userIDs.Contains(Arguments.argUser.userID))
			{
				this.userIDs.Add(Arguments.argUser.userID);
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "InstaKO mode has been activated !");
				return;
			}
			this.userIDs.Remove(Arguments.argUser.userID);
			global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "InstaKO mode has been deactivated !");
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000946E File Offset: 0x0000766E
		public InstaKOCommand()
		{
		}

		// Token: 0x0400007C RID: 124
		private global::System.Collections.Generic.List<ulong> userIDs = new global::System.Collections.Generic.List<ulong>();
	}
}
