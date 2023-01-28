using System;
using UnityEngine;

// Token: 0x02000993 RID: 2451
[global::System.Serializable]
public class TOD_NightParameters
{
	// Token: 0x060052D8 RID: 21208 RVA: 0x00159798 File Offset: 0x00157998
	public TOD_NightParameters()
	{
	}

	// Token: 0x060052D9 RID: 21209 RVA: 0x00159860 File Offset: 0x00157A60
	public void CheckRange()
	{
		this.MoonLightIntensity = global::UnityEngine.Mathf.Max(0f, this.MoonLightIntensity);
		this.MoonMeshSize = global::UnityEngine.Mathf.Max(0f, this.MoonMeshSize);
		this.AmbientIntensity = global::UnityEngine.Mathf.Clamp01(this.AmbientIntensity);
		this.ShadowStrength = global::UnityEngine.Mathf.Clamp01(this.ShadowStrength);
		this.SkyMultiplier = global::UnityEngine.Mathf.Clamp01(this.SkyMultiplier);
		this.CloudMultiplier = global::UnityEngine.Mathf.Clamp01(this.CloudMultiplier);
	}

	// Token: 0x04002FFD RID: 12285
	public global::UnityEngine.Color AdditiveColor = global::UnityEngine.Color.black;

	// Token: 0x04002FFE RID: 12286
	public global::UnityEngine.Color MoonMeshColor = new global::UnityEngine.Color32(byte.MaxValue, 0xE9, 0xC8, byte.MaxValue);

	// Token: 0x04002FFF RID: 12287
	public global::UnityEngine.Color MoonLightColor = new global::UnityEngine.Color32(0xB5, 0xCC, byte.MaxValue, byte.MaxValue);

	// Token: 0x04003000 RID: 12288
	public global::UnityEngine.Color MoonHaloColor = new global::UnityEngine.Color32(0x51, 0x68, 0x9B, byte.MaxValue);

	// Token: 0x04003001 RID: 12289
	public float MoonMeshSize = 1f;

	// Token: 0x04003002 RID: 12290
	public float MoonLightIntensity = 0.1f;

	// Token: 0x04003003 RID: 12291
	public float AmbientIntensity = 0.2f;

	// Token: 0x04003004 RID: 12292
	public float ShadowStrength = 1f;

	// Token: 0x04003005 RID: 12293
	public float SkyMultiplier = 0.1f;

	// Token: 0x04003006 RID: 12294
	public float CloudMultiplier = 0.2f;
}
