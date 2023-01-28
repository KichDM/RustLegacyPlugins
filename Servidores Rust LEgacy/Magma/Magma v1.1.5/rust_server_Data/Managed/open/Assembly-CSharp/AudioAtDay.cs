using System;
using UnityEngine;

// Token: 0x020009A4 RID: 2468
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.AudioSource))]
public class AudioAtDay : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005327 RID: 21287 RVA: 0x0015CF00 File Offset: 0x0015B100
	public AudioAtDay()
	{
	}

	// Token: 0x06005328 RID: 21288 RVA: 0x0015CF14 File Offset: 0x0015B114
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

	// Token: 0x06005329 RID: 21289 RVA: 0x0015CF60 File Offset: 0x0015B160
	protected void Update()
	{
		int num = (!this.sky.IsDay) ? -1 : 1;
		this.lerpTime = global::UnityEngine.Mathf.Clamp01(this.lerpTime + (float)num * global::UnityEngine.Time.deltaTime / this.fadeTime);
		this.audioComponent.volume = global::UnityEngine.Mathf.Lerp(0f, this.audioVolume, this.lerpTime);
	}

	// Token: 0x0400308F RID: 12431
	public global::TOD_Sky sky;

	// Token: 0x04003090 RID: 12432
	public float fadeTime = 1f;

	// Token: 0x04003091 RID: 12433
	private float lerpTime;

	// Token: 0x04003092 RID: 12434
	private global::UnityEngine.AudioSource audioComponent;

	// Token: 0x04003093 RID: 12435
	private float audioVolume;
}
