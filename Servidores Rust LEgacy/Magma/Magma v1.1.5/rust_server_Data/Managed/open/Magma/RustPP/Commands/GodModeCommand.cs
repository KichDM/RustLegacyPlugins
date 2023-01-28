using System;
using System.Collections.Generic;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x02000039 RID: 57
	internal class GodModeCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000219 RID: 537 RVA: 0x00009220 File Offset: 0x00007420
		public bool IsOn(ulong uid)
		{
			return this.userIDs.Contains(uid);
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00009230 File Offset: 0x00007430
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			if (!this.userIDs.Contains(Arguments.argUser.userID))
			{
				this.userIDs.Add(Arguments.argUser.userID);
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "God mode has been activated !");
				return;
			}
			this.userIDs.Remove(Arguments.argUser.userID);
			global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "God mode has been deactivated !");
		}

		// Token: 0x0600021B RID: 539 RVA: 0x000092B2 File Offset: 0x000074B2
		public GodModeCommand()
		{
		}

		// Token: 0x0400007B RID: 123
		private global::System.Collections.Generic.List<ulong> userIDs = new global::System.Collections.Generic.List<ulong>();
	}
}
