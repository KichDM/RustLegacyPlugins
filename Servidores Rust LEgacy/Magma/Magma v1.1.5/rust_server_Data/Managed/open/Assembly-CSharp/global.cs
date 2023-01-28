using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Facepunch.Utility;
using uLink;
using UnityEngine;

// Token: 0x020001BB RID: 443
public class global : global::ConsoleSystem
{
	// Token: 0x06000CF8 RID: 3320 RVA: 0x00031DD4 File Offset: 0x0002FFD4
	public global()
	{
	}

	// Token: 0x06000CF9 RID: 3321 RVA: 0x00031DDC File Offset: 0x0002FFDC
	// Note: this type is marked as 'beforefieldinit'.
	static global()
	{
	}

	// Token: 0x06000CFA RID: 3322 RVA: 0x00031DE8 File Offset: 0x0002FFE8
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Client]
	[global::ConsoleSystem.Help("Search for a command", "string Name")]
	[global::ConsoleSystem.User]
	public static void find(ref global::ConsoleSystem.Arg arg)
	{
		if (!arg.HasArgs(1))
		{
			return;
		}
		string text = arg.Args[0];
		string text2 = string.Empty;
		global::System.Reflection.Assembly[] assemblies = global::System.AppDomain.CurrentDomain.GetAssemblies();
		for (int i = 0; i < assemblies.Length; i++)
		{
			global::System.Type[] types = assemblies[i].GetTypes();
			for (int j = 0; j < types.Length; j++)
			{
				if (types[j].IsSubclassOf(typeof(global::ConsoleSystem)))
				{
					global::System.Reflection.MethodInfo[] methods = types[j].GetMethods();
					for (int k = 0; k < methods.Length; k++)
					{
						if (methods[k].IsStatic)
						{
							if (!(text != "*") || types[j].Name.Contains(text) || methods[k].Name.Contains(text))
							{
								if (arg.CheckPermissions(methods[k].GetCustomAttributes(true)))
								{
									string text3 = text2;
									text2 = string.Concat(new string[]
									{
										text3,
										types[j].Name,
										".",
										global::global.BuildMethodString(ref methods[k]),
										"\n"
									});
								}
							}
						}
					}
					global::System.Reflection.FieldInfo[] fields = types[j].GetFields();
					for (int l = 0; l < fields.Length; l++)
					{
						if (fields[l].IsStatic)
						{
							if (!(text != "*") || types[j].Name.Contains(text) || fields[l].Name.Contains(text))
							{
								if (arg.CheckPermissions(fields[l].GetCustomAttributes(true)))
								{
									string text3 = text2;
									text2 = string.Concat(new string[]
									{
										text3,
										types[j].Name,
										".",
										global::global.BuildFieldsString(ref fields[l]),
										"\n"
									});
								}
							}
						}
					}
					global::System.Reflection.PropertyInfo[] properties = types[j].GetProperties();
					for (int m = 0; m < properties.Length; m++)
					{
						if (!(text != "*") || types[j].Name.Contains(text) || properties[m].Name.Contains(text))
						{
							if (arg.CheckPermissions(properties[m].GetCustomAttributes(true)))
							{
								string text3 = text2;
								text2 = string.Concat(new string[]
								{
									text3,
									types[j].Name,
									".",
									global::global.BuildPropertyString(ref properties[m]),
									"\n"
								});
							}
						}
					}
				}
			}
		}
		arg.ReplyWith("Finding " + text + ":\n" + text2);
	}

	// Token: 0x06000CFB RID: 3323 RVA: 0x00032100 File Offset: 0x00030300
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Search for a command (server-side)", "string Name")]
	[global::ConsoleSystem.User]
	public static void findsv(ref global::ConsoleSystem.Arg arg)
	{
		global::global.find(ref arg);
	}

	// Token: 0x06000CFC RID: 3324 RVA: 0x00032108 File Offset: 0x00030308
	public static string BuildMethodString(ref global::System.Reflection.MethodInfo method)
	{
		string text = string.Empty;
		string text2 = "no help";
		object[] customAttributes = method.GetCustomAttributes(true);
		foreach (object obj in customAttributes)
		{
			if (obj is global::ConsoleSystem.Help)
			{
				text = (obj as global::ConsoleSystem.Help).argsDescription;
				text2 = (obj as global::ConsoleSystem.Help).helpDescription;
				text = " " + text.Trim() + " ";
			}
		}
		return string.Concat(new string[]
		{
			method.Name,
			"(",
			text,
			") : ",
			text2
		});
	}

	// Token: 0x06000CFD RID: 3325 RVA: 0x000321B4 File Offset: 0x000303B4
	public static string BuildFieldsString(ref global::System.Reflection.FieldInfo field)
	{
		string str = "no help";
		object[] customAttributes = field.GetCustomAttributes(true);
		foreach (object obj in customAttributes)
		{
			if (obj is global::ConsoleSystem.Help)
			{
				str = (obj as global::ConsoleSystem.Help).helpDescription;
			}
		}
		return field.Name + " : " + str;
	}

	// Token: 0x06000CFE RID: 3326 RVA: 0x00032218 File Offset: 0x00030418
	public static string BuildPropertyString(ref global::System.Reflection.PropertyInfo field)
	{
		string str = "no help";
		object[] customAttributes = field.GetCustomAttributes(true);
		foreach (object obj in customAttributes)
		{
			if (obj is global::ConsoleSystem.Help)
			{
				str = (obj as global::ConsoleSystem.Help).helpDescription;
			}
		}
		return field.Name + " : " + str;
	}

	// Token: 0x06000CFF RID: 3327 RVA: 0x0003227C File Offset: 0x0003047C
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Client]
	[global::ConsoleSystem.Help("Prints something to the debug output", "string output")]
	[global::ConsoleSystem.User]
	public static void echo(ref global::ConsoleSystem.Arg arg)
	{
		arg.ReplyWith(arg.ArgsStr);
	}

	// Token: 0x06000D00 RID: 3328 RVA: 0x0003228C File Offset: 0x0003048C
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Client]
	[global::ConsoleSystem.Help("Quits the game", "")]
	public static void quit(ref global::ConsoleSystem.Arg arg)
	{
		global::ConsoleSystem.Run("server.close", false);
		global::ConsoleSystem.Run("save.all", false);
		global::global.Console_AllowClose();
		global::UnityEngine.Application.Quit();
	}

	// Token: 0x06000D01 RID: 3329
	[global::System.Runtime.InteropServices.DllImport("librust")]
	public static extern void Console_AllowClose();

	// Token: 0x06000D02 RID: 3330 RVA: 0x000322BC File Offset: 0x000304BC
	[global::ConsoleSystem.Help("Kill yourself", "")]
	[global::ConsoleSystem.User]
	public static void suicide(ref global::ConsoleSystem.Arg arg)
	{
		global::Character character = arg.playerCharacter();
		if (character && character.alive)
		{
			global::DamageEvent damageEvent;
			global::TakeDamage.Kill(character, character, out damageEvent, null);
			arg.ReplyWith("You suicided!");
			global::UnityEngine.Debug.Log(string.Format("{0} has suicided", arg.argUser.user.Displayname));
		}
		else
		{
			arg.ReplyWith("You dead!");
		}
	}

	// Token: 0x06000D03 RID: 3331 RVA: 0x00032330 File Offset: 0x00030530
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Print out currently connected clients etc", "")]
	public static void status(ref global::ConsoleSystem.Arg arg)
	{
		string text = "hostname: " + global::server.hostname + "\n";
		text = text + "version : " + 0x42D.ToString() + " secure (secure mode enabled, connected to Steam3)\n";
		text = text + "map     : " + global::server.map + "\n";
		string text2 = text;
		text = string.Concat(new string[]
		{
			text2,
			"players : ",
			global::NetCull.connections.Length.ToString(),
			" (",
			global::NetCull.maxConnections.ToString(),
			" max)\n\n"
		});
		text += "id".PadRight(0x12);
		text += "name".PadRight(0x26);
		text += "ping".PadRight(6);
		text += "connected".PadRight(0xC);
		text += "addr".PadRight(0xC);
		text += "\n";
		foreach (global::uLink.NetworkPlayer networkPlayer in global::NetCull.connections)
		{
			object localData = networkPlayer.GetLocalData();
			string text3 = string.Empty;
			string text4 = string.Empty;
			string text5 = string.Empty;
			string text6 = string.Empty;
			string text7 = string.Empty;
			if (localData is global::NetUser)
			{
				global::NetUser netUser = (global::NetUser)localData;
				text3 = netUser.user.Userid.ToString();
				string text8 = netUser.displayName.ToString();
				if (text8.Length >= 0x20)
				{
					text8 = text8.Substring(0, 0x20) + "..";
				}
				text4 = global::Facepunch.Utility.String.QuoteSafe(text8);
				text5 = netUser.networkPlayer.lastPing.ToString();
				text7 = netUser.networkPlayer.ipAddress;
				text6 = netUser.SecondsConnected().ToString() + "s";
			}
			else if (localData is global::ClientConnection)
			{
				global::ClientConnection clientConnection = (global::ClientConnection)localData;
				text3 = "n/a";
				text4 = "\"none\"";
				text6 = "-";
				text7 = networkPlayer.ipAddress.ToString();
			}
			text += text3.PadRight(0x12);
			text += text4.PadRight(0x26);
			text += text5.PadRight(6);
			text += text6.PadRight(0xC);
			text += text7.PadRight(0xC);
			text += "\n";
		}
		text += "\n";
		arg.ReplyWith(text);
	}

	// Token: 0x06000D04 RID: 3332 RVA: 0x000325F0 File Offset: 0x000307F0
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Sends a message in chat", "")]
	public static void say(ref global::ConsoleSystem.Arg arg)
	{
		string text = global::Facepunch.Utility.String.QuoteSafe(arg.GetString(0, string.Empty));
		if (text == string.Empty)
		{
			return;
		}
		global::ConsoleNetworker.Broadcast("chat.add \"SERVER CONSOLE\" " + text);
	}

	// Token: 0x06000D05 RID: 3333 RVA: 0x00032634 File Offset: 0x00030834
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Show user info for players on server.", "")]
	public static void users(ref global::ConsoleSystem.Arg arg)
	{
		string text = "<slot:userid:\"name\">\n";
		int num = 0;
		foreach (global::uLink.NetworkPlayer networkPlayer in global::NetCull.connections)
		{
			object localData = networkPlayer.GetLocalData();
			if (localData is global::NetUser)
			{
				global::NetUser netUser = (global::NetUser)localData;
				string text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					netUser.networkPlayer.id,
					":\"",
					netUser.displayName,
					"\"\n"
				});
				num++;
			}
		}
		text = text + num.ToString() + "users\n";
		arg.ReplyWith(text);
	}

	// Token: 0x06000D06 RID: 3334 RVA: 0x000326F8 File Offset: 0x000308F8
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("List of banned users (sourceds compat)", "")]
	public static void banlist(ref global::ConsoleSystem.Arg arg)
	{
		arg.ReplyWith(global::BanList.BanListString(false));
	}

	// Token: 0x06000D07 RID: 3335 RVA: 0x00032708 File Offset: 0x00030908
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("List of banned users - shows reasons and usernames", "")]
	public static void banlistex(ref global::ConsoleSystem.Arg arg)
	{
		arg.ReplyWith(global::BanList.BanListStringEx());
	}

	// Token: 0x06000D08 RID: 3336 RVA: 0x00032718 File Offset: 0x00030918
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("List of banned users, by ID (sourceds compat)", "")]
	public static void listid(ref global::ConsoleSystem.Arg arg)
	{
		arg.ReplyWith(global::BanList.BanListString(true));
	}

	// Token: 0x06000D09 RID: 3337 RVA: 0x00032728 File Offset: 0x00030928
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("kick  a user from the server", "")]
	public static void kick(ref global::ConsoleSystem.Arg arg)
	{
		global::PlayerClient[] playerClients = arg.GetPlayerClients(0);
		foreach (global::PlayerClient playerClient in playerClients)
		{
			global::NetUser netUser = playerClient.netUser;
			if (netUser != null)
			{
				netUser.Kick(global::NetError.Facepunch_Kick_RCON, true);
			}
		}
		if (playerClients.Length > 0)
		{
			arg.ReplyWith("Kicked " + playerClients.Length + " users!");
			return;
		}
		arg.ReplyWith("Couldn't find anyone!");
	}

	// Token: 0x06000D0A RID: 3338 RVA: 0x000327B0 File Offset: 0x000309B0
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Bans a user from the server", "")]
	public static void ban(ref global::ConsoleSystem.Arg arg)
	{
		global::PlayerClient[] playerClients = arg.GetPlayerClients(0);
		foreach (global::PlayerClient playerClient in playerClients)
		{
			global::NetUser netUser = playerClient.netUser;
			if (netUser != null)
			{
				string displayName = netUser.displayName;
				string @string = arg.GetString(1, string.Empty);
				global::BanList.Add(netUser.user.Userid, displayName, @string);
			}
		}
		if (playerClients.Length > 0)
		{
			global::BanList.Save();
			arg.ReplyWith("Banned " + playerClients.Length + " users!");
			return;
		}
		arg.ReplyWith("Couldn't find anyone!");
	}

	// Token: 0x06000D0B RID: 3339 RVA: 0x0003285C File Offset: 0x00030A5C
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Bans a userid from the server", "")]
	public static void banid(ref global::ConsoleSystem.Arg arg)
	{
		ulong @uint = arg.GetUInt64(0, 0UL);
		if (@uint == 0UL)
		{
			return;
		}
		string @string = arg.GetString(1, string.Empty);
		string string2 = arg.GetString(2, string.Empty);
		global::BanList.Add(@uint, @string, string2);
		global::BanList.Save();
	}

	// Token: 0x06000D0C RID: 3340 RVA: 0x000328A4 File Offset: 0x00030AA4
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Unbans a userid from the server", "")]
	public static void removeid(ref global::ConsoleSystem.Arg arg)
	{
		ulong @uint = arg.GetUInt64(0, 0UL);
		if (@uint == 0UL)
		{
			arg.ReplyWith("removeid:  couldn't find 0");
			return;
		}
		if (global::BanList.Remove(@uint))
		{
			arg.ReplyWith("removeid:  filter removed for " + @uint.ToString());
		}
		else
		{
			arg.ReplyWith("removeid:  couldn't find " + @uint.ToString());
		}
		global::BanList.Save();
	}

	// Token: 0x06000D0D RID: 3341 RVA: 0x00032914 File Offset: 0x00030B14
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Removes all bans", "")]
	public static void unbanall(ref global::ConsoleSystem.Arg arg)
	{
		global::BanList.Clear();
		global::BanList.Save();
	}

	// Token: 0x04000856 RID: 2134
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("When set to True, all console printing will go through Debug.Log", "")]
	public static bool logprint;

	// Token: 0x04000857 RID: 2135
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Client]
	[global::ConsoleSystem.Help("Prints fps at said interval", "interval (seconds)")]
	[global::ConsoleSystem.User]
	public static float fpslog = -1f;
}
