using System;

// Token: 0x0200005A RID: 90
public class env : global::ConsoleSystem
{
	// Token: 0x06000293 RID: 659 RVA: 0x0000D2DC File Offset: 0x0000B4DC
	public env()
	{
	}

	// Token: 0x06000294 RID: 660 RVA: 0x0000D2E4 File Offset: 0x0000B4E4
	// Note: this type is marked as 'beforefieldinit'.
	static env()
	{
	}

	// Token: 0x06000295 RID: 661 RVA: 0x0000D2FC File Offset: 0x0000B4FC
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Gets or sets the current time", "")]
	public static void time(ref global::ConsoleSystem.Arg arg)
	{
		if (!global::EnvironmentControlCenter.Singleton)
		{
			return;
		}
		if (arg.GetFloat(0, -1f) >= 0f)
		{
			global::EnvironmentControlCenter.Singleton.SetTime(arg.GetFloat(0, 0f));
			arg.ReplyWith("Set Time To: " + global::EnvironmentControlCenter.Singleton.GetTime().ToString());
			return;
		}
		arg.ReplyWith("Current Time: " + global::EnvironmentControlCenter.Singleton.GetTime().ToString());
	}

	// Token: 0x040001D6 RID: 470
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("The length of a day in real minutes", "")]
	public static float daylength = 45f;

	// Token: 0x040001D7 RID: 471
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("The length of a night in real minutes", "")]
	public static float nightlength = 15f;
}
