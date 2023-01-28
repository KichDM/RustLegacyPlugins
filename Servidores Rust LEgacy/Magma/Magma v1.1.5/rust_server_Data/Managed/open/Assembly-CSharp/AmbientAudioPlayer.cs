using System;
using UnityEngine;

// Token: 0x020005ED RID: 1517
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.AudioSource))]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.AudioSource))]
public class AmbientAudioPlayer : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600310A RID: 12554 RVA: 0x000BAFE4 File Offset: 0x000B91E4
	public AmbientAudioPlayer()
	{
	}

	// Token: 0x0600310B RID: 12555 RVA: 0x000BAFEC File Offset: 0x000B91EC
	private void Awake()
	{
		global::UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x0600310C RID: 12556 RVA: 0x000BAFFC File Offset: 0x000B91FC
	public bool NeedsAudioUpdate()
	{
		return !global::EnvironmentControlCenter.Singleton || (global::EnvironmentControlCenter.Singleton && !global::EnvironmentControlCenter.Singleton.IsNight() && (this.daySource.volume < 1f || this.nightSource.volume > 0f)) || (global::EnvironmentControlCenter.Singleton && global::EnvironmentControlCenter.Singleton.IsNight() && (this.nightSource.volume < 1f || this.daySource.volume > 0f));
	}

	// Token: 0x0600310D RID: 12557 RVA: 0x000BB0B0 File Offset: 0x000B92B0
	private void CheckTimeChange()
	{
		if (this.NeedsAudioUpdate())
		{
			base.Invoke("UpdateVolume", 0f);
		}
	}

	// Token: 0x0600310E RID: 12558 RVA: 0x000BB0D0 File Offset: 0x000B92D0
	private void UpdateVolume()
	{
		if (this.NeedsAudioUpdate())
		{
			base.Invoke("UpdateVolume", global::UnityEngine.Time.deltaTime);
			bool flag = !global::EnvironmentControlCenter.Singleton || !global::EnvironmentControlCenter.Singleton.IsNight();
			global::UnityEngine.AudioSource audioSource = (!flag) ? this.nightSource : this.daySource;
			global::UnityEngine.AudioSource audioSource2 = (!flag) ? this.daySource : this.nightSource;
			if (!audioSource.isPlaying)
			{
				audioSource.enabled = true;
				audioSource.Play();
			}
			audioSource.volume += 0.2f * global::UnityEngine.Time.deltaTime;
			audioSource2.volume -= 0.2f * global::UnityEngine.Time.deltaTime;
			if (audioSource.volume > 1f)
			{
				audioSource.volume = 1f;
			}
			if (audioSource2.volume < 0f)
			{
				audioSource2.volume = 0f;
				audioSource2.Stop();
				audioSource2.enabled = false;
			}
			return;
		}
	}

	// Token: 0x04001B2B RID: 6955
	public global::UnityEngine.AudioClip daySound;

	// Token: 0x04001B2C RID: 6956
	public global::UnityEngine.AudioClip nightSound;

	// Token: 0x04001B2D RID: 6957
	public global::UnityEngine.AudioSource daySource;

	// Token: 0x04001B2E RID: 6958
	public global::UnityEngine.AudioSource nightSource;
}
