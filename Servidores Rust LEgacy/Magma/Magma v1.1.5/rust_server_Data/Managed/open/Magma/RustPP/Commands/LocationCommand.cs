using System;
using Magma;
using RustPP.Permissions;

namespace RustPP.Commands
{
	// Token: 0x02000040 RID: 64
	public class LocationCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x0600022A RID: 554 RVA: 0x00009B00 File Offset: 0x00007D00
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			string text = "";
			for (int i = 0; i < ChatArguments.Length; i++)
			{
				text = text + ChatArguments[i] + " ";
			}
			text = text.Trim();
			string text2;
			if (text == "")
			{
				text2 = Arguments.argUser.displayName;
			}
			else
			{
				if (!global::RustPP.Permissions.Administrator.IsAdmin(Arguments.argUser.userID))
				{
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Only administrators can ask for another player's location.");
					return;
				}
				text2 = text;
			}
			foreach (global::PlayerClient playerClient in global::PlayerClient.FindAllWithString(text2))
			{
				string strValue = string.Concat(new object[]
				{
					"Location: X: ",
					(int)playerClient.lastKnownPosition.x,
					" Y: ",
					(int)playerClient.lastKnownPosition.y,
					" Z: ",
					(int)playerClient.lastKnownPosition.z
				});
				Arguments.ReplyWith(strValue);
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, string.Concat(new object[]
				{
					(text == "") ? "Your" : (text2 + "'s"),
					" Location Is: X: ",
					(int)playerClient.lastKnownPosition.x,
					" Y: ",
					(int)playerClient.lastKnownPosition.y,
					" Z: ",
					(int)playerClient.lastKnownPosition.z
				}));
			}
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00009CE4 File Offset: 0x00007EE4
		public LocationCommand()
		{
		}
	}
}
