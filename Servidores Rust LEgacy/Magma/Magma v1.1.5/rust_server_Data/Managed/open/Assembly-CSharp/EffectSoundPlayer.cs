using System;
using UnityEngine;

// Token: 0x020005CA RID: 1482
public class EffectSoundPlayer : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600307F RID: 12415 RVA: 0x000B89E0 File Offset: 0x000B6BE0
	public EffectSoundPlayer()
	{
	}

	// Token: 0x06003080 RID: 12416 RVA: 0x000B89E8 File Offset: 0x000B6BE8
	private void Start()
	{
		global::UnityEngine.AudioClip clip = this.sounds[global::UnityEngine.Random.Range(0, this.sounds.Length)];
		clip.Play(base.transform.position, 1f, 1f, 10f);
	}

	// Token: 0x04001A34 RID: 6708
	public global::AudioClipArray sounds;
}
