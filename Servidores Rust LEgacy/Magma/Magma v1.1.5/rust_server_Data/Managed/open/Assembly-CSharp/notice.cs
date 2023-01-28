using System;
using uLink;

// Token: 0x0200051A RID: 1306
public class notice : global::ConsoleSystem
{
	// Token: 0x06002C6B RID: 11371 RVA: 0x000A7AF4 File Offset: 0x000A5CF4
	public notice()
	{
	}

	// Token: 0x06002C6C RID: 11372 RVA: 0x000A7AFC File Offset: 0x000A5CFC
	[global::ConsoleSystem.Client]
	public static void popup(ref global::ConsoleSystem.Arg arg)
	{
		float @float = arg.GetFloat(0, 2f);
		string @string = arg.GetString(1, "!");
		string string2 = arg.GetString(2, "This is the text");
		global::PopupUI.singleton.CreateNotice(@float, @string, string2);
	}

	// Token: 0x06002C6D RID: 11373 RVA: 0x000A7B40 File Offset: 0x000A5D40
	[global::ConsoleSystem.Admin]
	public static void popupall(ref global::ConsoleSystem.Arg arg)
	{
		foreach (global::uLink.NetworkPlayer player in global::NetCull.connections)
		{
			global::ConsoleNetworker.SendClientCommand(player, string.Concat(new object[]
			{
				"notice.popup ",
				0xA,
				" q \"",
				arg.GetString(0, "No Message"),
				"\""
			}));
		}
	}

	// Token: 0x06002C6E RID: 11374 RVA: 0x000A7BB8 File Offset: 0x000A5DB8
	[global::ConsoleSystem.Client]
	public static void inventory(ref global::ConsoleSystem.Arg arg)
	{
		string @string = arg.GetString(0, "This is the text");
		global::PopupUI.singleton.CreateInventory(@string);
	}

	// Token: 0x06002C6F RID: 11375 RVA: 0x000A7BE0 File Offset: 0x000A5DE0
	[global::ConsoleSystem.Client]
	public static void test(ref global::ConsoleSystem.Arg arg)
	{
		global::PopupUI.singleton.StartCoroutine("DoTests");
	}
}
