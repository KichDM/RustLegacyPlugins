using System;
using Facepunch.Utility;
using Magma;
using RustPP.Permissions;

namespace RustPP.Commands
{
	// Token: 0x02000049 RID: 73
	public class RemoveFlagsCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x0600023D RID: 573 RVA: 0x0000A4E0 File Offset: 0x000086E0
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			if (ChatArguments != null)
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
								if (global::RustPP.Permissions.Administrator.IsAdmin(playerClient.netUser.userID))
								{
									for (int k = 1; k < ChatArguments.Length; k++)
									{
										string text5 = ChatArguments[k].Replace("\"", "");
										if (global::RustPP.Permissions.Administrator.IsValidFlag(text5))
										{
											global::RustPP.Permissions.Administrator admin = global::RustPP.Permissions.Administrator.GetAdmin(playerClient.netUser.userID);
											if (admin.HasPermission(text5))
											{
												string properName = global::RustPP.Permissions.Administrator.GetProperName(text5);
												admin.Flags.Remove(properName);
												global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "The " + properName + " Permissions has been removed from " + playerClient.netUser.displayName);
												global::Magma.Util.sayUser(playerClient.netPlayer, Arguments.argUser.displayName + " removed you the " + properName + " permission.");
											}
											else
											{
												global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, playerClient.netUser.displayName + " doesn't have this permission.");
											}
										}
										else
										{
											global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, text5 + " is not a valid flag.");
										}
									}
									return;
								}
								global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, playerClient.netUser.displayName + " is not an administrator !");
								return;
							}
						}
						global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "No player found with the name: " + text2);
						return;
					}
				}
			}
			else
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "RemoveFlag Usage:   /unflag  flag1 flag2...");
			}
		}

		// Token: 0x0600023E RID: 574 RVA: 0x0000A788 File Offset: 0x00008988
		public RemoveFlagsCommand()
		{
		}
	}
}
