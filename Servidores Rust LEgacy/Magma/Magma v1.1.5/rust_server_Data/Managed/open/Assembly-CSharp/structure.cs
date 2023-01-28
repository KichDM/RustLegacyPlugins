using System;

// Token: 0x020007B3 RID: 1971
public class structure : global::ConsoleSystem
{
	// Token: 0x060041B2 RID: 16818 RVA: 0x000ED130 File Offset: 0x000EB330
	public structure()
	{
	}

	// Token: 0x060041B3 RID: 16819 RVA: 0x000ED138 File Offset: 0x000EB338
	// Note: this type is marked as 'beforefieldinit'.
	static structure()
	{
	}

	// Token: 0x060041B4 RID: 16820 RVA: 0x000ED154 File Offset: 0x000EB354
	[global::ConsoleSystem.Admin]
	public static void touchall(ref global::ConsoleSystem.Arg args)
	{
		foreach (global::StructureMaster structureMaster in global::StructureMaster.AllStructures)
		{
			if (structureMaster)
			{
				structureMaster.Touched();
			}
		}
	}

	// Token: 0x0400224F RID: 8783
	[global::ConsoleSystem.Admin]
	public static float minpercentdmg = 0.1f;

	// Token: 0x04002250 RID: 8784
	[global::ConsoleSystem.Admin]
	public static int framelimit = 1;

	// Token: 0x04002251 RID: 8785
	[global::ConsoleSystem.Admin]
	public static int maxframeattempt = 0x3E8;
}
