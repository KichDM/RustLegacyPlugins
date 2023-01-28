using System;
using UnityEngine;

// Token: 0x02000915 RID: 2325
[global::UnityEngine.AddComponentMenu("NGUI/Tween/Volume")]
public class TweenVolume : global::UITweener
{
	// Token: 0x06004F8D RID: 20365 RVA: 0x00134F90 File Offset: 0x00133190
	public TweenVolume()
	{
	}

	// Token: 0x17000EAA RID: 3754
	// (get) Token: 0x06004F8E RID: 20366 RVA: 0x00134FA4 File Offset: 0x001331A4
	public global::UnityEngine.AudioSource audioSource
	{
		get
		{
			if (this.mSource == null)
			{
				this.mSource = base.audio;
				if (this.mSource == null)
				{
					this.mSource = base.GetComponentInChildren<global::UnityEngine.AudioSource>();
					if (this.mSource == null)
					{
						global::UnityEngine.Debug.LogError("TweenVolume needs an AudioSource to work with", this);
						base.enabled = false;
					}
				}
			}
			return this.mSource;
		}
	}

	// Token: 0x17000EAB RID: 3755
	// (get) Token: 0x06004F8F RID: 20367 RVA: 0x00135014 File Offset: 0x00133214
	// (set) Token: 0x06004F90 RID: 20368 RVA: 0x00135024 File Offset: 0x00133224
	public float volume
	{
		get
		{
			return this.audioSource.volume;
		}
		set
		{
			this.audioSource.volume = value;
		}
	}

	// Token: 0x06004F91 RID: 20369 RVA: 0x00135034 File Offset: 0x00133234
	protected override void OnUpdate(float factor)
	{
		this.volume = this.from * (1f - factor) + this.to * factor;
		this.mSource.enabled = (this.mSource.volume > 0.01f);
	}

	// Token: 0x06004F92 RID: 20370 RVA: 0x0013507C File Offset: 0x0013327C
	public static global::TweenVolume Begin(global::UnityEngine.GameObject go, float duration, float targetVolume)
	{
		global::TweenVolume tweenVolume = global::UITweener.Begin<global::TweenVolume>(go, duration);
		tweenVolume.from = tweenVolume.volume;
		tweenVolume.to = targetVolume;
		return tweenVolume;
	}

	// Token: 0x04002C00 RID: 11264
	public float from;

	// Token: 0x04002C01 RID: 11265
	public float to = 1f;

	// Token: 0x04002C02 RID: 11266
	private global::UnityEngine.AudioSource mSource;
}
