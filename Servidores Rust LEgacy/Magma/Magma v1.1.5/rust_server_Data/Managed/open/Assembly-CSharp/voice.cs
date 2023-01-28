using System;

// Token: 0x020000BF RID: 191
public class voice : global::ConsoleSystem
{
	// Token: 0x060003C1 RID: 961 RVA: 0x00012180 File Offset: 0x00010380
	public voice()
	{
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x00012188 File Offset: 0x00010388
	// Note: this type is marked as 'beforefieldinit'.
	static voice()
	{
	}

	// Token: 0x0400038B RID: 907
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("The voice distance", "")]
	public static float distance = 100f;
}
