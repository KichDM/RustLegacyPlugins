using System;
using Magma;

// Token: 0x02000513 RID: 1299
public class chat : global::ConsoleSystem
{
	// Token: 0x06002C52 RID: 11346 RVA: 0x000A7244 File Offset: 0x000A5444
	public chat()
	{
	}

	// Token: 0x06002C53 RID: 11347 RVA: 0x000A724C File Offset: 0x000A544C
	// Note: this type is marked as 'beforefieldinit'.
	static chat()
	{
	}

	// Token: 0x06002C54 RID: 11348 RVA: 0x000A725C File Offset: 0x000A545C
	[global::ConsoleSystem.User]
	public static void say(ref global::ConsoleSystem.Arg arg)
	{
		global::Magma.Hooks.ChatReceived(ref arg);
	}

	// Token: 0x040016A4 RID: 5796
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Client]
	[global::ConsoleSystem.Help("Enable or disable chat displaying", "")]
	public static bool enabled = true;

	// Token: 0x040016A5 RID: 5797
	[global::ConsoleSystem.Admin]
	public static bool serverlog = true;
}
