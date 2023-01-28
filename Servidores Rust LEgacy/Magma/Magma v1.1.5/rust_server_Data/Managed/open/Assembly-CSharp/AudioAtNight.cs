using System;
using UnityEngine;

// Token: 0x020009A5 RID: 2469
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.AudioSource))]
public class AudioAtNight : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600532A RID: 21290 RVA: 0x0015CFC8 File Offset: 0x0015B1C8
	public AudioAtNight()
	{
	}

	// Token: 0x0600532B RID: 21291 RVA: 0x0015CFDC File Offset: 0x0015B1DC
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

	// Token: 0x0600532C RID: 21292 RVA: 0x0015D028 File Offset: 0x0015B228
	protected void Update()
	{
		int num = (!this.sky.IsNight) ? -1 : 1;
		this.lerpTime = global::UnityEngine.Mathf.Clamp01(this.lerpTime + (float)num * global::UnityEngine.Time.deltaTime / this.fadeTime);
		this.audioComponent.volume = global::UnityEngine.Mathf.Lerp(0f, this.audioVolume, this.lerpTime);
	}

	// Token: 0x04003094 RID: 12436
	public global::TOD_Sky sky;

	// Token: 0x04003095 RID: 12437
	public float fadeTime = 1f;

	// Token: 0x04003096 RID: 12438
	private float lerpTime;

	// Token: 0x04003097 RID: 12439
	private global::UnityEngine.AudioSource audioComponent;

	// Token: 0x04003098 RID: 12440
	private float audioVolume;
}
