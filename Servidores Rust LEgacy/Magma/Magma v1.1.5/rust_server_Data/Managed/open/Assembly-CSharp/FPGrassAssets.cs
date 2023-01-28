using System;
using UnityEngine;

// Token: 0x0200004A RID: 74
public sealed class FPGrassAssets : global::UnityEngine.MonoBehaviour, global::IFPGrassAsset
{
	// Token: 0x0600027B RID: 635 RVA: 0x0000CFE4 File Offset: 0x0000B1E4
	public FPGrassAssets()
	{
	}

	// Token: 0x0600027C RID: 636 RVA: 0x0000CFEC File Offset: 0x0000B1EC
	public bool Contains(global::UnityEngine.Object asset)
	{
		return global::System.Array.IndexOf<global::UnityEngine.Object>(this.All, asset) != -1;
	}

	// Token: 0x040001B6 RID: 438
	public global::UnityEngine.Object[] All;
}
