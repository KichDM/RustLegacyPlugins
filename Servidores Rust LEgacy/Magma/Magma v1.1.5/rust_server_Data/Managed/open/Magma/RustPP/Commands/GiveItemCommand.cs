using System;
using Facepunch.Utility;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x02000038 RID: 56
	internal class GiveItemCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000217 RID: 535 RVA: 0x00009078 File Offset: 0x00007278
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			string text = "";
			for (int i = 0; i < ChatArguments.Length; i++)
			{
				text = text + ChatArguments[i] + " ";
			}
			text = text.Trim();
			string[] array = global::Facepunch.Utility.String.SplitQuotesStrings(text);
			if (array.Length == 3)
			{
				string text2 = array[0].Replace("\"", "");
				string text3 = "";
				for (int j = 1; j < ChatArguments.Length; j++)
				{
					text3 = text3 + ChatArguments[j] + " ";
				}
				string text4 = text3.Replace("\"", "");
				if (text2 != "" && text4 != "")
				{
					foreach (global::PlayerClient playerClient in global::PlayerClient.All)
					{
						if (playerClient.netUser.displayName.ToLower() == text2.ToLower())
						{
							string text5 = array[2].Replace("\"", "");
							Arguments.Args = new string[]
							{
								text2,
								text4.Replace(text5, "").Trim(),
								text5
							};
							global::inv.giveplayer(ref Arguments);
							return;
						}
					}
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "No player found with the name: " + text2);
					return;
				}
			}
			else
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Spawn Item usage:   /give \"playerName\" \"itemName\" \"quantity\"");
			}
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00009218 File Offset: 0x00007418
		public GiveItemCommand()
		{
		}
	}
}
