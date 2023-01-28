using System;
using UnityEngine;

// Token: 0x020009AA RID: 2474
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.ParticleSystem))]
public class ParticleAtWeather : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005338 RID: 21304 RVA: 0x0015D3A8 File Offset: 0x0015B5A8
	public ParticleAtWeather()
	{
	}

	// Token: 0x06005339 RID: 21305 RVA: 0x0015D3BC File Offset: 0x0015B5BC
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

	// Token: 0x0600533A RID: 21306 RVA: 0x0015D408 File Offset: 0x0015B608
	protected void Update()
	{
		int num = (this.sky.Components.Weather.Weather != this.type) ? -1 : 1;
		this.lerpTime = global::UnityEngine.Mathf.Clamp01(this.lerpTime + (float)num * global::UnityEngine.Time.deltaTime / this.fadeTime);
		this.particleComponent.emissionRate = global::UnityEngine.Mathf.Lerp(0f, this.particleEmission, this.lerpTime);
	}

	// Token: 0x040030AA RID: 12458
	public global::TOD_Sky sky;

	// Token: 0x040030AB RID: 12459
	public global::TOD_Weather.WeatherType type;

	// Token: 0x040030AC RID: 12460
	public float fadeTime = 1f;

	// Token: 0x040030AD RID: 12461
	private float lerpTime;

	// Token: 0x040030AE RID: 12462
	private global::UnityEngine.ParticleSystem particleComponent;

	// Token: 0x040030AF RID: 12463
	private float particleEmission;
}
