using System;
using UnityEngine;

// Token: 0x020009A6 RID: 2470
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.AudioSource))]
public class AudioAtWeather : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600532D RID: 21293 RVA: 0x0015D090 File Offset: 0x0015B290
	public AudioAtWeather()
	{
	}

	// Token: 0x0600532E RID: 21294 RVA: 0x0015D0A4 File Offset: 0x0015B2A4
	protected void OnEnable()
	{
		if (!this.sky)
		{
			global::UnityEngine.Debug.LogError("Sky instance reference not set. Disabling script.");
			base.enabled = false;
		}
		this.audioComponent = base.audio;
		this.audioVolume = this.audioComponent.volume;
	}

	// Token: 0x0600532F RID: 21295 RVA: 0x0015D0F0 File Offset: 0x0015B2F0
	protected void Update()
	{
		int num = (this.sky.Components.Weather.Weather != this.type) ? -1 : 1;
		this.lerpTime = global::UnityEngine.Mathf.Clamp01(this.lerpTime + (float)num * global::UnityEngine.Time.deltaTime / this.fadeTime);
		this.audioComponent.volume = global::UnityEngine.Mathf.Lerp(0f, this.audioVolume, this.lerpTime);
	}

	// Token: 0x04003099 RID: 12441
	public global::TOD_Sky sky;

	// Token: 0x0400309A RID: 12442
	public global::TOD_Weather.WeatherType type;

	// Token: 0x0400309B RID: 12443
	public float fadeTime = 1f;

	// Token: 0x0400309C RID: 12444
	private float lerpTime;

	// Token: 0x0400309D RID: 12445
	private global::UnityEngine.AudioSource audioComponent;

	// Token: 0x0400309E RID: 12446
	private float audioVolume;
}
