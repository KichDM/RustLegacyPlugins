using System;
using Facepunch.Utility;
using Magma;
using RustPP.Permissions;

namespace RustPP.Commands
{
	// Token: 0x02000032 RID: 50
	public class AddFlagCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000207 RID: 519 RVA: 0x0000831C File Offset: 0x0000651C
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
										if (text5.ToLower() == "all")
										{
											global::RustPP.Permissions.Administrator admin = global::RustPP.Permissions.Administrator.GetAdmin(playerClient.netUser.userID);
											foreach (string text6 in global::RustPP.Permissions.Administrator.PermissionsFlags)
											{
												if (!admin.HasPermission(text6))
												{
													admin.Flags.Add(text6);
													global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "The " + text6 + " Permissions has been added to " + playerClient.netUser.displayName);
													global::Magma.Util.sayUser(playerClient.netPlayer, Arguments.argUser.displayName + " gave you the " + text6 + " permission.");
													if (text6 == "RCON")
													{
														playerClient.netUser.admin = true;
													}
												}
											}
											break;
										}
										if (global::RustPP.Permissions.Administrator.IsValidFlag(text5))
										{
											global::RustPP.Permissions.Administrator admin2 = global::RustPP.Permissions.Administrator.GetAdmin(playerClient.netUser.userID);
											if (!admin2.HasPermission(text5))
											{
												string properName = global::RustPP.Permissions.Administrator.GetProperName(text5);
												admin2.Flags.Add(properName);
												global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "The " + properName + " Permissions has been added to " + playerClient.netUser.displayName);
												global::Magma.Util.sayUser(playerClient.netPlayer, Arguments.argUser.displayName + " gave you the " + properName + " permission.");
												if (properName == "RCON")
												{
													playerClient.netUser.admin = true;
												}
											}
											else
											{
												global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, playerClient.netUser.displayName + " already has this permission.");
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
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "AddFlag Usage:   /addflag  flag1 flag2...");
			}
		}

		// Token: 0x06000208 RID: 520 RVA: 0x000086C4 File Offset: 0x000068C4
		public AddFlagCommand()
		{
		}
	}
}
