using System;
using System.Collections.Generic;

// Token: 0x02000481 RID: 1153
public static class ShaderModUtility
{
	// Token: 0x06002836 RID: 10294 RVA: 0x00099E78 File Offset: 0x00098078
	public static int Replace(this global::ShaderMod[] mods, global::ShaderMod.Replacement replacement, string incoming, ref string outgoing)
	{
		if (mods != null)
		{
			int num = mods.Length;
			for (int i = 0; i < num; i++)
			{
				if (mods[i] && mods[i].Replace(replacement, incoming, ref outgoing))
				{
					return i;
				}
			}
		}
		return -1;
	}

	// Token: 0x06002837 RID: 10295 RVA: 0x00099EC4 File Offset: 0x000980C4
	public static int ReplaceReverse(this global::ShaderMod[] mods, global::ShaderMod.Replacement replacement, string incoming, ref string outgoing)
	{
		if (mods != null)
		{
			int num = mods.Length;
			for (int i = num - 1; i >= 0; i--)
			{
				if (mods[i] && mods[i].Replace(replacement, incoming, ref outgoing))
				{
					return i;
				}
			}
		}
		return -1;
	}

	// Token: 0x06002838 RID: 10296 RVA: 0x00099F10 File Offset: 0x00098110
	public static global::System.Collections.Generic.IEnumerable<global::ShaderMod.KV> MergeKeyValues(this global::ShaderMod[] mods, global::ShaderMod.Replacement replacement)
	{
		return null;
	}
}
