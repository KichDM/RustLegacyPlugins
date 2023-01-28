using System;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x02000045 RID: 69
	public class PlayersCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000235 RID: 565 RVA: 0x00009F30 File Offset: 0x00008130
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, string.Concat(new object[]
			{
				global::PlayerClient.All.Count,
				"  Player",
				(global::PlayerClient.All.Count > 1) ? "s" : "",
				" Online:"
			}));
			int num = 0;
			int num2 = 0;
			string text = "";
			foreach (global::PlayerClient playerClient in global::PlayerClient.All)
			{
				num2++;
				if (num2 >= 0x3C)
				{
					num = 0;
					break;
				}
				text = text + playerClient.userName + ",  ";
				if (num == 6)
				{
					num = 0;
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, text.Substring(0, text.Length - 3));
					text = "";
				}
				else
				{
					num++;
				}
			}
			if (num != 0)
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, text.Substring(0, text.Length - 3));
			}
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000A05C File Offset: 0x0000825C
		public PlayersCommand()
		{
		}
	}
}
