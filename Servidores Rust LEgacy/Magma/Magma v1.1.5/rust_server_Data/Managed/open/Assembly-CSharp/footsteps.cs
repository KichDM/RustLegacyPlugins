using System;

// Token: 0x020005D8 RID: 1496
public class footsteps : global::ConsoleSystem
{
	// Token: 0x060030BD RID: 12477 RVA: 0x000B9B9C File Offset: 0x000B7D9C
	public footsteps()
	{
	}

	// Token: 0x060030BE RID: 12478 RVA: 0x000B9BA4 File Offset: 0x000B7DA4
	// Note: this type is marked as 'beforefieldinit'.
	static footsteps()
	{
	}

	// Token: 0x04001A71 RID: 6769
	[global::ConsoleSystem.Client]
	[global::ConsoleSystem.Help("Footstep Quality, 0 = default sound, 1 = dynamic for local, 2 = dynamic for all. 0-2 (default 2)", "")]
	[global::ConsoleSystem.Saved]
	public static int quality = 2;
}
