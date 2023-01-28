using System;

// Token: 0x020007CB RID: 1995
internal class terrain : global::ConsoleSystem
{
	// Token: 0x06004213 RID: 16915 RVA: 0x000F0314 File Offset: 0x000EE514
	public terrain()
	{
	}

	// Token: 0x06004214 RID: 16916 RVA: 0x000F031C File Offset: 0x000EE51C
	// Note: this type is marked as 'beforefieldinit'.
	static terrain()
	{
	}

	// Token: 0x06004215 RID: 16917 RVA: 0x000F0328 File Offset: 0x000EE528
	[global::ConsoleSystem.Client]
	public static void reassign(ref global::ConsoleSystem.Arg arg)
	{
		global::TerrainControl.ter_reassign();
	}

	// Token: 0x06004216 RID: 16918 RVA: 0x000F0330 File Offset: 0x000EE530
	[global::ConsoleSystem.Client]
	public static void reassign_nocopy(ref global::ConsoleSystem.Arg arg)
	{
		global::TerrainControl.ter_reassign_nocopy();
	}

	// Token: 0x06004217 RID: 16919 RVA: 0x000F0338 File Offset: 0x000EE538
	[global::ConsoleSystem.Client]
	public static void mat(ref global::ConsoleSystem.Arg arg)
	{
		global::TerrainControl.ter_mat();
	}

	// Token: 0x06004218 RID: 16920 RVA: 0x000F0340 File Offset: 0x000EE540
	[global::ConsoleSystem.Client]
	public static void flush(ref global::ConsoleSystem.Arg arg)
	{
		global::TerrainControl.ter_flush();
	}

	// Token: 0x06004219 RID: 16921 RVA: 0x000F0348 File Offset: 0x000EE548
	[global::ConsoleSystem.Client]
	public static void flushtrees(ref global::ConsoleSystem.Arg arg)
	{
		global::TerrainControl.ter_flushtrees();
	}

	// Token: 0x040022EC RID: 8940
	[global::ConsoleSystem.Client]
	public static bool manual;

	// Token: 0x040022ED RID: 8941
	[global::ConsoleSystem.Client]
	[global::ConsoleSystem.Help("The interval (seconds) to force tree redrawing when there is no camera movement. Set to zero if you do not want forced tree drawing", "")]
	public static float idleinterval = 3.2f;
}
