using System;
using UnityEngine;

// Token: 0x020009A8 RID: 2472
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.ParticleSystem))]
public class ParticleAtDay : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005332 RID: 21298 RVA: 0x0015D218 File Offset: 0x0015B418
	public ParticleAtDay()
	{
	}

	// Token: 0x06005333 RID: 21299 RVA: 0x0015D22C File Offset: 0x0015B42C
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

	// Token: 0x06005334 RID: 21300 RVA: 0x0015D278 File Offset: 0x0015B478
	protected void Update()
	{
		int num = (!this.sky.IsDay) ? -1 : 1;
		this.lerpTime = global::UnityEngine.Mathf.Clamp01(this.lerpTime + (float)num * global::UnityEngine.Time.deltaTime / this.fadeTime);
		this.particleComponent.emissionRate = global::UnityEngine.Mathf.Lerp(0f, this.particleEmission, this.lerpTime);
	}

	// Token: 0x040030A0 RID: 12448
	public global::TOD_Sky sky;

	// Token: 0x040030A1 RID: 12449
	public float fadeTime = 1f;

	// Token: 0x040030A2 RID: 12450
	private float lerpTime;

	// Token: 0x040030A3 RID: 12451
	private global::UnityEngine.ParticleSystem particleComponent;

	// Token: 0x040030A4 RID: 12452
	private float particleEmission;
}
