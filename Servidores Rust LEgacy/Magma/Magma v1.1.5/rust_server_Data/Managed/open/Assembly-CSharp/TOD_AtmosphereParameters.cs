using System;
using UnityEngine;

// Token: 0x02000990 RID: 2448
[global::System.Serializable]
public class TOD_AtmosphereParameters
{
	// Token: 0x060052D2 RID: 21202 RVA: 0x00159508 File Offset: 0x00157708
	public TOD_AtmosphereParameters()
	{
	}

	// Token: 0x060052D3 RID: 21203 RVA: 0x00159568 File Offset: 0x00157768
	public void CheckRange()
	{
		this.MieMultiplier = global::UnityEngine.Mathf.Max(0f, this.MieMultiplier);
		this.RayleighMultiplier = global::UnityEngine.Mathf.Max(0f, this.RayleighMultiplier);
		this.Brightness = global::UnityEngine.Mathf.Max(0f, this.Brightness);
		this.Contrast = global::UnityEngine.Mathf.Max(0f, this.Contrast);
		this.Directionality = global::UnityEngine.Mathf.Clamp01(this.Directionality);
		this.Haziness = global::UnityEngine.Mathf.Clamp01(this.Haziness);
		this.Fogginess = global::UnityEngine.Mathf.Clamp01(this.Fogginess);
	}

	// Token: 0x04002FE9 RID: 12265
	public global::UnityEngine.Color ScatteringColor = global::UnityEngine.Color.white;

	// Token: 0x04002FEA RID: 12266
	public float RayleighMultiplier = 1f;

	// Token: 0x04002FEB RID: 12267
	public float MieMultiplier = 1f;

	// Token: 0x04002FEC RID: 12268
	public float Brightness = 1f;

	// Token: 0x04002FED RID: 12269
	public float Contrast = 1f;

	// Token: 0x04002FEE RID: 12270
	public float Directionality = 0.5f;

	// Token: 0x04002FEF RID: 12271
	public float Haziness = 0.5f;

	// Token: 0x04002FF0 RID: 12272
	public float Fogginess;
}
