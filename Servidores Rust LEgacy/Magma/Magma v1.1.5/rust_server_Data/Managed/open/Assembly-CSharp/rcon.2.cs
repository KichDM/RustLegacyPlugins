using System;

// Token: 0x0200075E RID: 1886
public class rcon : global::ConsoleSystem
{
	// Token: 0x06003EDE RID: 16094 RVA: 0x000DFED8 File Offset: 0x000DE0D8
	public rcon()
	{
	}

	// Token: 0x06003EDF RID: 16095 RVA: 0x000DFEE0 File Offset: 0x000DE0E0
	// Note: this type is marked as 'beforefieldinit'.
	static rcon()
	{
	}

	// Token: 0x06003EE0 RID: 16096 RVA: 0x000DFEEC File Offset: 0x000DE0EC
	[global::ConsoleSystem.Help("Remote connection login - use: rcon.login password", "")]
	[global::ConsoleSystem.User]
	public static void login(ref global::ConsoleSystem.Arg arg)
	{
		if (global::rcon.password == string.Empty)
		{
			arg.ReplyWith("Rcon not set up.");
			return;
		}
		if (!arg.HasArgs(1))
		{
			arg.ReplyWith("Specify a Password.");
			return;
		}
		if (arg.argUser.CanAdmin())
		{
			arg.ReplyWith("Already logged in.");
			return;
		}
		if (arg.Args[0] == global::rcon.password)
		{
			arg.argUser.SetAdmin(true);
			arg.ReplyWith("Logged in as admin.");
		}
		else
		{
			arg.argUser.Kick(global::NetError.Facepunch_Kick_RCON, true);
		}
	}

	// Token: 0x04002063 RID: 8291
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Remote connection password for admin. - use: rcon.password password", "")]
	public static string password = string.Empty;
}
