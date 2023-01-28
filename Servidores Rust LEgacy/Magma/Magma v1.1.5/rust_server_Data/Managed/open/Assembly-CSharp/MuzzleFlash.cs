using System;
using UnityEngine;

// Token: 0x020005CD RID: 1485
public class MuzzleFlash : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600308A RID: 12426 RVA: 0x000B8C14 File Offset: 0x000B6E14
	public MuzzleFlash()
	{
	}

	// Token: 0x0600308B RID: 12427 RVA: 0x000B8C1C File Offset: 0x000B6E1C
	private void Start()
	{
		this.startTime = global::UnityEngine.Time.time;
		this.initialIntensity = this.myLight.intensity;
	}

	// Token: 0x0600308C RID: 12428 RVA: 0x000B8C3C File Offset: 0x000B6E3C
	private void Update()
	{
		float num = global::UnityEngine.Mathf.Clamp(1f - (global::UnityEngine.Time.time - this.startTime) / 0.1f, 0f, 1f);
		this.myLight.intensity = this.initialIntensity * num;
	}

	// Token: 0x04001A3B RID: 6715
	public global::UnityEngine.Light myLight;

	// Token: 0x04001A3C RID: 6716
	private float initialIntensity;

	// Token: 0x04001A3D RID: 6717
	private float startTime;
}
