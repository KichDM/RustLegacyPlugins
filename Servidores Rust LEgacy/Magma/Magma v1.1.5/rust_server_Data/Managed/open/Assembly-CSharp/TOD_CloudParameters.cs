using System;
using UnityEngine;

// Token: 0x02000995 RID: 2453
[global::System.Serializable]
public class TOD_CloudParameters
{
	// Token: 0x060052DC RID: 21212 RVA: 0x00159984 File Offset: 0x00157B84
	public TOD_CloudParameters()
	{
	}

	// Token: 0x060052DD RID: 21213 RVA: 0x001599E4 File Offset: 0x00157BE4
	public void CheckRange()
	{
		this.Scale1 = new global::UnityEngine.Vector2(global::UnityEngine.Mathf.Max(1f, this.Scale1.x), global::UnityEngine.Mathf.Max(1f, this.Scale1.y));
		this.Scale2 = new global::UnityEngine.Vector2(global::UnityEngine.Mathf.Max(1f, this.Scale2.x), global::UnityEngine.Mathf.Max(1f, this.Scale2.y));
		this.Density = global::UnityEngine.Mathf.Max(0f, this.Density);
		this.Sharpness = global::UnityEngine.Mathf.Max(0f, this.Sharpness);
		this.Brightness = global::UnityEngine.Mathf.Max(0f, this.Brightness);
		this.ShadowStrength = global::UnityEngine.Mathf.Clamp01(this.ShadowStrength);
	}

	// Token: 0x0400300C RID: 12300
	public float Density = 3f;

	// Token: 0x0400300D RID: 12301
	public float Sharpness = 3f;

	// Token: 0x0400300E RID: 12302
	public float Brightness = 1f;

	// Token: 0x0400300F RID: 12303
	public float ShadowStrength;

	// Token: 0x04003010 RID: 12304
	public global::UnityEngine.Vector2 Scale1 = new global::UnityEngine.Vector2(3f, 3f);

	// Token: 0x04003011 RID: 12305
	public global::UnityEngine.Vector2 Scale2 = new global::UnityEngine.Vector2(7f, 7f);
}
