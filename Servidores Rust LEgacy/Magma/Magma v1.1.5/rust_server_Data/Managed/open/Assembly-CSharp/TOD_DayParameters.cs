using System;
using UnityEngine;

// Token: 0x02000992 RID: 2450
[global::System.Serializable]
public class TOD_DayParameters
{
	// Token: 0x060052D6 RID: 21206 RVA: 0x0015964C File Offset: 0x0015784C
	public TOD_DayParameters()
	{
	}

	// Token: 0x060052D7 RID: 21207 RVA: 0x00159718 File Offset: 0x00157918
	public void CheckRange()
	{
		this.SunLightIntensity = global::UnityEngine.Mathf.Max(0f, this.SunLightIntensity);
		this.SunMeshSize = global::UnityEngine.Mathf.Max(0f, this.SunMeshSize);
		this.AmbientIntensity = global::UnityEngine.Mathf.Clamp01(this.AmbientIntensity);
		this.ShadowStrength = global::UnityEngine.Mathf.Clamp01(this.ShadowStrength);
		this.SkyMultiplier = global::UnityEngine.Mathf.Clamp01(this.SkyMultiplier);
		this.CloudMultiplier = global::UnityEngine.Mathf.Clamp01(this.CloudMultiplier);
	}

	// Token: 0x04002FF3 RID: 12275
	public global::UnityEngine.Color AdditiveColor = global::UnityEngine.Color.black;

	// Token: 0x04002FF4 RID: 12276
	public global::UnityEngine.Color SunMeshColor = new global::UnityEngine.Color32(byte.MaxValue, 0xE9, 0xB4, byte.MaxValue);

	// Token: 0x04002FF5 RID: 12277
	public global::UnityEngine.Color SunLightColor = new global::UnityEngine.Color32(byte.MaxValue, 0xF3, 0xEA, byte.MaxValue);

	// Token: 0x04002FF6 RID: 12278
	public global::UnityEngine.Color SunShaftColor = new global::UnityEngine.Color32(byte.MaxValue, 0xF3, 0xEA, byte.MaxValue);

	// Token: 0x04002FF7 RID: 12279
	public float SunMeshSize = 1f;

	// Token: 0x04002FF8 RID: 12280
	public float SunLightIntensity = 0.75f;

	// Token: 0x04002FF9 RID: 12281
	public float AmbientIntensity = 0.75f;

	// Token: 0x04002FFA RID: 12282
	public float ShadowStrength = 1f;

	// Token: 0x04002FFB RID: 12283
	public float SkyMultiplier = 1f;

	// Token: 0x04002FFC RID: 12284
	public float CloudMultiplier = 1f;
}
