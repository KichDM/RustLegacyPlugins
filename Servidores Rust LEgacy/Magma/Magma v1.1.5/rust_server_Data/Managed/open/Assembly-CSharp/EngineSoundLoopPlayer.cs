using System;
using UnityEngine;

// Token: 0x020000F2 RID: 242
internal sealed class EngineSoundLoopPlayer : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060004E4 RID: 1252 RVA: 0x000179DC File Offset: 0x00015BDC
	public EngineSoundLoopPlayer()
	{
	}

	// Token: 0x060004E5 RID: 1253 RVA: 0x000179E4 File Offset: 0x00015BE4
	private void OnDestroy()
	{
		if (this.instance != null)
		{
			global::EngineSoundLoop.Instance instance = this.instance;
			this.instance = null;
			instance.Dispose(true);
		}
	}

	// Token: 0x040004A8 RID: 1192
	[global::System.NonSerialized]
	internal global::EngineSoundLoop.Instance instance;
}
