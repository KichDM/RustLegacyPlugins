using System;
using UnityEngine;

// Token: 0x020005CB RID: 1483
public class ExplosionEffect : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003081 RID: 12417 RVA: 0x000B8A34 File Offset: 0x000B6C34
	public ExplosionEffect()
	{
	}

	// Token: 0x06003082 RID: 12418 RVA: 0x000B8A48 File Offset: 0x000B6C48
	public virtual void Start()
	{
		this.startTime = global::UnityEngine.Time.time;
		global::UnityEngine.Object.Destroy(base.gameObject, 3f);
	}

	// Token: 0x06003083 RID: 12419 RVA: 0x000B8A68 File Offset: 0x000B6C68
	public virtual void Update()
	{
		float num = global::UnityEngine.Time.time - this.startTime;
		if (this.myLight)
		{
			this.myLight.intensity = global::UnityEngine.Mathf.Clamp(this.initialLightIntensity * (1f - num / 0.25f), 0f, this.initialLightIntensity);
			if (this.myLight.intensity <= 0f)
			{
				global::UnityEngine.Object.Destroy(this.myLight.gameObject);
				this.myLight = null;
			}
		}
	}

	// Token: 0x04001A35 RID: 6709
	public global::UnityEngine.Light myLight;

	// Token: 0x04001A36 RID: 6710
	public float initialLightIntensity = 2f;

	// Token: 0x04001A37 RID: 6711
	public float startTime;
}
