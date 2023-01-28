using System;
using System.Collections;
using Facepunch.Utility;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x02000046 RID: 70
	public class PrivateMessagesCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000237 RID: 567 RVA: 0x0000A064 File Offset: 0x00008264
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
				if (text2 != null && text4 != null)
				{
					foreach (global::PlayerClient playerClient in global::PlayerClient.All)
					{
						if (playerClient.netUser.displayName.ToLower() == text2.ToLower())
						{
							global::Magma.Util.say(playerClient.netPlayer, "\"PM from " + Arguments.argUser.displayName + "\"", "\"" + text4 + "\"");
							global::Magma.Util.say(Arguments.argUser.networkPlayer, "\"PM to " + playerClient.netUser.displayName + "\"", "\"" + text4 + "\"");
							global::RustPP.Commands.ReplyCommand replyCommand = global::RustPP.Commands.ChatCommand.GetCommand("r") as global::RustPP.Commands.ReplyCommand;
							global::System.Collections.Hashtable replies = replyCommand.GetReplies();
							if (replies.ContainsKey(playerClient.netUser.displayName))
							{
								replies[playerClient.netUser.displayName] = Arguments.argUser.displayName;
							}
							else
							{
								replies.Add(playerClient.netUser.displayName, Arguments.argUser.displayName);
							}
							return;
						}
					}
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "No player found with the name: " + text2);
					return;
				}
			}
			else
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Private Message Usage:   /pm \"player\" \"message\"");
			}
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000A29C File Offset: 0x0000849C
		public PrivateMessagesCommand()
		{
		}
	}
}
