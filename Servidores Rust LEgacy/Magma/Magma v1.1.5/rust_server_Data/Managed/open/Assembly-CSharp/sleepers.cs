using System;

// Token: 0x0200079B RID: 1947
public class sleepers : global::ConsoleSystem
{
	// Token: 0x060040C6 RID: 16582 RVA: 0x000E894C File Offset: 0x000E6B4C
	public sleepers()
	{
	}

	// Token: 0x060040C7 RID: 16583 RVA: 0x000E8954 File Offset: 0x000E6B54
	// Note: this type is marked as 'beforefieldinit'.
	static sleepers()
	{
	}

	// Token: 0x060040C8 RID: 16584 RVA: 0x000E8964 File Offset: 0x000E6B64
	[global::ConsoleSystem.Admin]
	public static void clear(ref global::ConsoleSystem.Arg arg)
	{
		if (arg.Args.Length > 0)
		{
			global::SleepingAvatar.Close(arg.GetUInt64(0, 0UL));
		}
		else
		{
			global::SleepingAvatar.CloseAll(false, true);
		}
	}

	// Token: 0x060040C9 RID: 16585 RVA: 0x000E8994 File Offset: 0x000E6B94
	[global::ConsoleSystem.Admin]
	public static void kill(ref global::ConsoleSystem.Arg arg)
	{
		global::SleepingAvatar.CloseAll(true, true);
	}

	// Token: 0x040021CD RID: 8653
	[global::ConsoleSystem.Admin]
	public static int loglevel;

	// Token: 0x040021CE RID: 8654
	[global::ConsoleSystem.Admin]
	public static int pointsolver = 7;

	// Token: 0x040021CF RID: 8655
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Saved]
	public static bool on = true;
}
