using System;
using UnityEngine;

// Token: 0x02000994 RID: 2452
[global::System.Serializable]
public class TOD_LightParameters
{
	// Token: 0x060052DA RID: 21210 RVA: 0x001598E0 File Offset: 0x00157AE0
	public TOD_LightParameters()
	{
	}

	// Token: 0x060052DB RID: 21211 RVA: 0x00159920 File Offset: 0x00157B20
	public void CheckRange()
	{
		this.Falloff = global::UnityEngine.Mathf.Clamp01(this.Falloff);
		this.Coloring = global::UnityEngine.Mathf.Clamp01(this.Coloring);
		this.SkyColoring = global::UnityEngine.Mathf.Clamp01(this.SkyColoring);
		this.CloudColoring = global::UnityEngine.Mathf.Clamp01(this.CloudColoring);
		this.ShaftColoring = global::UnityEngine.Mathf.Clamp01(this.ShaftColoring);
	}

	// Token: 0x04003007 RID: 12295
	public float Falloff = 0.7f;

	// Token: 0x04003008 RID: 12296
	public float Coloring = 0.7f;

	// Token: 0x04003009 RID: 12297
	public float SkyColoring = 0.5f;

	// Token: 0x0400300A RID: 12298
	public float CloudColoring = 0.9f;

	// Token: 0x0400300B RID: 12299
	public float ShaftColoring = 0.9f;
}
