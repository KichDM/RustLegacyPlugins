using System;
using System.IO;

// Token: 0x020001BC RID: 444
public class config : global::ConsoleSystem
{
	// Token: 0x06000D0E RID: 3342 RVA: 0x00032920 File Offset: 0x00030B20
	public config()
	{
	}

	// Token: 0x06000D0F RID: 3343 RVA: 0x00032928 File Offset: 0x00030B28
	public static string ConfigName()
	{
		return global::server.datadir + "cfg/server.cfg";
	}

	// Token: 0x06000D10 RID: 3344 RVA: 0x0003293C File Offset: 0x00030B3C
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Client]
	[global::ConsoleSystem.Help("Save the current config to config.cfg", "")]
	[global::ConsoleSystem.User]
	public static void save(ref global::ConsoleSystem.Arg arg)
	{
		string path = global::config.ConfigName();
		string contents = global::ConsoleSystem.SaveToConfigString();
		global::System.IO.File.WriteAllText(path, contents);
		arg.ReplyWith("Saved config.cfg");
	}

	// Token: 0x06000D11 RID: 3345 RVA: 0x00032968 File Offset: 0x00030B68
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Client]
	[global::ConsoleSystem.Help("Load the current config from config.cfg", "")]
	[global::ConsoleSystem.User]
	public static void load(ref global::ConsoleSystem.Arg arg)
	{
		string text = global::config.ConfigName();
		string strFile = string.Empty;
		if (global::System.IO.File.Exists(text))
		{
			strFile = global::System.IO.File.ReadAllText(text);
		}
		global::ConsoleSystem.RunFile(strFile);
		arg.ReplyWith("Loaded " + text);
	}

	// Token: 0x04000858 RID: 2136
	public const string defaultConfig = "";
}
