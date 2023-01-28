using System;
using Facepunch.Utility;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x0200004E RID: 78
	internal class SpawnItemCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x0600024C RID: 588 RVA: 0x0000AC78 File Offset: 0x00008E78
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			string text = "";
			for (int i = 0; i < ChatArguments.Length; i++)
			{
				text = text + ChatArguments[i] + " ";
			}
			text = text.Trim();
			string[] array = global::Facepunch.Utility.String.SplitQuotesStrings(text);
			if (array.Length == 2)
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
					string[] array2 = text4.Replace(text2, "").Trim().Split(new char[]
					{
						' '
					});
					Arguments.Args = new string[]
					{
						text2,
						array2[array2.Length - 1]
					};
					global::inv.give(ref Arguments);
					return;
				}
			}
			else
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Spawn Item usage:   /i \"itemName\" \"quantity\"");
			}
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000AD98 File Offset: 0x00008F98
		public SpawnItemCommand()
		{
		}
	}
}
