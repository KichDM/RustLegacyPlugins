using System;

// Token: 0x020005B4 RID: 1460
public class decay : global::ConsoleSystem
{
	// Token: 0x06003004 RID: 12292 RVA: 0x000B6E34 File Offset: 0x000B5034
	public decay()
	{
	}

	// Token: 0x06003005 RID: 12293 RVA: 0x000B6E3C File Offset: 0x000B503C
	// Note: this type is marked as 'beforefieldinit'.
	static decay()
	{
	}

	// Token: 0x040019C1 RID: 6593
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Number of seconds until decay deals max health amount of damage", "")]
	public static float deploy_maxhealth_sec = 43200f;

	// Token: 0x040019C2 RID: 6594
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("How often decay is processed", "")]
	public static float decaytickrate = 300f;

	// Token: 0x040019C3 RID: 6595
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Maximum amount of env decays to process per frame. Use zero to process all env decays every frame", "")]
	public static int maxperframe = 0x64;

	// Token: 0x040019C4 RID: 6596
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Maximum amount of env decays to process with raycasts. Use zero to process all env decays every frame", "")]
	public static int maxtestperframe = 8;
}
