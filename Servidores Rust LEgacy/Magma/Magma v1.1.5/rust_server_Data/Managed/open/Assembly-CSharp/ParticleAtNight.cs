using System;
using UnityEngine;

// Token: 0x020009A9 RID: 2473
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.ParticleSystem))]
public class ParticleAtNight : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005335 RID: 21301 RVA: 0x0015D2E0 File Offset: 0x0015B4E0
	public ParticleAtNight()
	{
	}

	// Token: 0x06005336 RID: 21302 RVA: 0x0015D2F4 File Offset: 0x0015B4F4
	protected void OnEnable()
	{
		if (!this.sky)
		{
			global::UnityEngine.Debug.LogError("Sky instance reference not set. Disabling script.");
			base.enabled = false;
		}
		this.particleComponent = base.particleSystem;
		this.particleEmission = this.particleComponent.emissionRate;
	}

	// Token: 0x06005337 RID: 21303 RVA: 0x0015D340 File Offset: 0x0015B540
	protected void Update()
	{
		int num = (!this.sky.IsNight) ? -1 : 1;
		this.lerpTime = global::UnityEngine.Mathf.Clamp01(this.lerpTime + (float)num * global::UnityEngine.Time.deltaTime / this.fadeTime);
		this.particleComponent.emissionRate = global::UnityEngine.Mathf.Lerp(0f, this.particleEmission, this.lerpTime);
	}

	// Token: 0x040030A5 RID: 12453
	public global::TOD_Sky sky;

	// Token: 0x040030A6 RID: 12454
	public float fadeTime = 1f;

	// Token: 0x040030A7 RID: 12455
	private float lerpTime;

	// Token: 0x040030A8 RID: 12456
	private global::UnityEngine.ParticleSystem particleComponent;

	// Token: 0x040030A9 RID: 12457
	private float particleEmission;
}
