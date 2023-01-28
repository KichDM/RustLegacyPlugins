using System;

// Token: 0x020007F2 RID: 2034
public static class AnchorStyleExtensions
{
	// Token: 0x06004419 RID: 17433 RVA: 0x000F9088 File Offset: 0x000F7288
	public static bool IsFlagSet(this global::dfAnchorStyle value, global::dfAnchorStyle flag)
	{
		return flag == (value & flag);
	}

	// Token: 0x0600441A RID: 17434 RVA: 0x000F9090 File Offset: 0x000F7290
	public static bool IsAnyFlagSet(this global::dfAnchorStyle value, global::dfAnchorStyle flag)
	{
		return global::dfAnchorStyle.None != (value & flag);
	}

	// Token: 0x0600441B RID: 17435 RVA: 0x000F909C File Offset: 0x000F729C
	public static global::dfAnchorStyle SetFlag(this global::dfAnchorStyle value, global::dfAnchorStyle flag)
	{
		return value | flag;
	}

	// Token: 0x0600441C RID: 17436 RVA: 0x000F90A4 File Offset: 0x000F72A4
	public static global::dfAnchorStyle SetFlag(this global::dfAnchorStyle value, global::dfAnchorStyle flag, bool on)
	{
		if (on)
		{
			return value | flag;
		}
		return value & ~flag;
	}
}
