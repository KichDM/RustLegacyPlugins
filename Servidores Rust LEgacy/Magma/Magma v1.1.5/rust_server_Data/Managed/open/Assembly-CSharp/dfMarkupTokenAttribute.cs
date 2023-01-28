using System;
using System.Collections.Generic;

// Token: 0x02000824 RID: 2084
public class dfMarkupTokenAttribute
{
	// Token: 0x060046C2 RID: 18114 RVA: 0x00104200 File Offset: 0x00102400
	private dfMarkupTokenAttribute()
	{
	}

	// Token: 0x060046C3 RID: 18115 RVA: 0x00104208 File Offset: 0x00102408
	// Note: this type is marked as 'beforefieldinit'.
	static dfMarkupTokenAttribute()
	{
	}

	// Token: 0x060046C4 RID: 18116 RVA: 0x0010421C File Offset: 0x0010241C
	internal static global::dfMarkupTokenAttribute GetAttribute(int index)
	{
		return global::dfMarkupTokenAttribute.pool[index];
	}

	// Token: 0x060046C5 RID: 18117 RVA: 0x0010422C File Offset: 0x0010242C
	public static void Reset()
	{
		global::dfMarkupTokenAttribute.poolIndex = 0;
	}

	// Token: 0x060046C6 RID: 18118 RVA: 0x00104234 File Offset: 0x00102434
	public static global::dfMarkupTokenAttribute Obtain(global::dfMarkupToken key, global::dfMarkupToken value)
	{
		if (global::dfMarkupTokenAttribute.poolIndex >= global::dfMarkupTokenAttribute.pool.Count - 1)
		{
			global::dfMarkupTokenAttribute.pool.Add(new global::dfMarkupTokenAttribute());
		}
		global::dfMarkupTokenAttribute dfMarkupTokenAttribute = global::dfMarkupTokenAttribute.pool[global::dfMarkupTokenAttribute.poolIndex];
		dfMarkupTokenAttribute.Index = global::dfMarkupTokenAttribute.poolIndex;
		dfMarkupTokenAttribute.Key = key;
		dfMarkupTokenAttribute.Value = value;
		global::dfMarkupTokenAttribute.poolIndex++;
		return dfMarkupTokenAttribute;
	}

	// Token: 0x0400262F RID: 9775
	public int Index;

	// Token: 0x04002630 RID: 9776
	public global::dfMarkupToken Key;

	// Token: 0x04002631 RID: 9777
	public global::dfMarkupToken Value;

	// Token: 0x04002632 RID: 9778
	private static global::System.Collections.Generic.List<global::dfMarkupTokenAttribute> pool = new global::System.Collections.Generic.List<global::dfMarkupTokenAttribute>();

	// Token: 0x04002633 RID: 9779
	private static int poolIndex = 0;
}
