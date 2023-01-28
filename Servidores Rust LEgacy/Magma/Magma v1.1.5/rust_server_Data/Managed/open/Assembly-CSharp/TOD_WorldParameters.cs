using System;
using UnityEngine;

// Token: 0x02000996 RID: 2454
[global::System.Serializable]
public class TOD_WorldParameters
{
	// Token: 0x060052DE RID: 21214 RVA: 0x00159AB0 File Offset: 0x00157CB0
	public TOD_WorldParameters()
	{
	}

	// Token: 0x060052DF RID: 21215 RVA: 0x00159AB8 File Offset: 0x00157CB8
	public void CheckRange()
	{
		this.FogColorBias = global::UnityEngine.Mathf.Clamp01(this.FogColorBias);
		this.ViewerHeight = global::UnityEngine.Mathf.Clamp01(this.ViewerHeight);
		this.HorizonOffset = global::UnityEngine.Mathf.Clamp01(this.HorizonOffset);
	}

	// Token: 0x04003012 RID: 12306
	public bool SetAmbientLight;

	// Token: 0x04003013 RID: 12307
	public bool SetFogColor;

	// Token: 0x04003014 RID: 12308
	public float FogColorBias;

	// Token: 0x04003015 RID: 12309
	public float ViewerHeight;

	// Token: 0x04003016 RID: 12310
	public float HorizonOffset;
}
