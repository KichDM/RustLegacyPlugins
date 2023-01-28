using System;
using UnityEngine;

// Token: 0x02000991 RID: 2449
[global::System.Serializable]
public class TOD_StarParameters
{
	// Token: 0x060052D4 RID: 21204 RVA: 0x00159600 File Offset: 0x00157800
	public TOD_StarParameters()
	{
	}

	// Token: 0x060052D5 RID: 21205 RVA: 0x00159620 File Offset: 0x00157820
	public void CheckRange()
	{
		this.Tiling = global::UnityEngine.Mathf.Max(0f, this.Tiling);
		this.Density = global::UnityEngine.Mathf.Clamp01(this.Density);
	}

	// Token: 0x04002FF1 RID: 12273
	public float Tiling = 2f;

	// Token: 0x04002FF2 RID: 12274
	public float Density = 0.5f;
}
