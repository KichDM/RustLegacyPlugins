using System;
using System.Collections;
using Magma;

namespace RustPP.Commands
{
	// Token: 0x0200004A RID: 74
	public class ReplyCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x0600023F RID: 575 RVA: 0x0000A790 File Offset: 0x00008990
		public void SetReplies(global::System.Collections.Hashtable rep)
		{
			this.replies = rep;
		}

		// Token: 0x06000240 RID: 576 RVA: 0x0000A799 File Offset: 0x00008999
		public global::System.Collections.Hashtable GetReplies()
		{
			return this.replies;
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0000A7A4 File Offset: 0x000089A4
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			if (ChatArguments != null)
			{
				if (this.replies.ContainsKey(Arguments.argUser.displayName))
				{
					string text = this.replies[Arguments.argUser.displayName].ToString();
					string text2 = "";
					for (int i = 0; i < ChatArguments.Length; i++)
					{
						text2 = text2 + ChatArguments[i] + " ";
					}
					foreach (global::PlayerClient playerClient in global::PlayerClient.All)
					{
						if (playerClient.netUser.displayName.ToLower() == text.ToLower())
						{
							global::Magma.Util.say(playerClient.netPlayer, "\"PM from " + Arguments.argUser.displayName + "\"", "\"" + text2 + "\"");
							global::Magma.Util.say(Arguments.argUser.networkPlayer, "\"PM to " + text + "\"", "\"" + text2 + "\"");
							if (this.replies.ContainsKey(text))
							{
								this.replies[text] = Arguments.argUser.displayName;
							}
							else
							{
								this.replies.Add(text, Arguments.argUser.displayName);
							}
							return;
						}
					}
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "No player found with the name: " + text);
					return;
				}
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "There's nobody to answer.");
				return;
			}
			else
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Reply Command Usage:   /r \"message\"");
			}
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0000A970 File Offset: 0x00008B70
		public ReplyCommand()
		{
		}

		// Token: 0x0400007E RID: 126
		private global::System.Collections.Hashtable replies = new global::System.Collections.Hashtable();
	}
}
