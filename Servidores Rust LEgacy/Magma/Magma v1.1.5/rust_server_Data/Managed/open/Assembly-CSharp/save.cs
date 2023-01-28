using System;

// Token: 0x020000AA RID: 170
internal class save : global::ConsoleSystem
{
	// Token: 0x06000345 RID: 837 RVA: 0x0000FCB8 File Offset: 0x0000DEB8
	public save()
	{
	}

	// Token: 0x06000346 RID: 838 RVA: 0x0000FCC0 File Offset: 0x0000DEC0
	// Note: this type is marked as 'beforefieldinit'.
	static save()
	{
	}

	// Token: 0x06000347 RID: 839 RVA: 0x0000FCCC File Offset: 0x0000DECC
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Saves all avatars of alive users", "")]
	public static void avatars(ref global::ConsoleSystem.Arg arg)
	{
		int num = global::AvatarSaveProc.SaveAll();
		arg.ReplyWith(string.Format("Saved {0} avatar(s)", num));
	}

	// Token: 0x06000348 RID: 840 RVA: 0x0000FCF8 File Offset: 0x0000DEF8
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Load a map. Careful - this doesn't clear the map first!", "string Filename")]
	public static void load(ref global::ConsoleSystem.Arg arg)
	{
		if (!arg.HasArgs(1))
		{
			return;
		}
		string strValue = global::ServerSaveManager.Load(arg.ArgsStr);
		arg.ReplyWith(strValue);
	}

	// Token: 0x06000349 RID: 841 RVA: 0x0000FD28 File Offset: 0x0000DF28
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Saves to a file", "string Name")]
	public static void tofile(ref global::ConsoleSystem.Arg arg)
	{
		string path = string.Empty;
		if (arg.HasArgs(1))
		{
			path = arg.ArgsStr;
		}
		global::ServerSaveManager.Save(path);
	}

	// Token: 0x0600034A RID: 842 RVA: 0x0000FD58 File Offset: 0x0000DF58
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Performs a auto save and restarts auto save timer", "")]
	public static void world(ref global::ConsoleSystem.Arg arg)
	{
		if (!global::ServerSaveManager.AutoSave())
		{
			arg.ReplyWith("Could not save right now.");
		}
	}

	// Token: 0x0600034B RID: 843 RVA: 0x0000FD70 File Offset: 0x0000DF70
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("saves world and all alive avatars", "")]
	public static void all(ref global::ConsoleSystem.Arg arg)
	{
		global::save.avatars(ref arg);
		global::ServerSaveManager.AutoSave();
		arg.ReplyWith("saved all.");
	}

	// Token: 0x040002FE RID: 766
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Should save a json formatted save too (for debugging)", "")]
	public static bool friendly;

	// Token: 0x040002FF RID: 767
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("The amount of seconds between auto saves", "")]
	public static int autosavetime = 0x258;

	// Token: 0x04000300 RID: 768
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("turn on to display more timing info on world saves", "")]
	public static bool profile;
}
