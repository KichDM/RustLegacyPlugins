using System;
using UnityEngine;

// Token: 0x02000745 RID: 1861
public class MusicPlayer : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003EB1 RID: 16049 RVA: 0x000DF880 File Offset: 0x000DDA80
	public MusicPlayer()
	{
	}

	// Token: 0x04002023 RID: 8227
	public float timeBetweenTracks = 600f;

	// Token: 0x04002024 RID: 8228
	public float targetVolume = 0.2f;

	// Token: 0x04002025 RID: 8229
	public float startDelay;

	// Token: 0x04002026 RID: 8230
	public global::UnityEngine.AudioClip[] tracks;
}
