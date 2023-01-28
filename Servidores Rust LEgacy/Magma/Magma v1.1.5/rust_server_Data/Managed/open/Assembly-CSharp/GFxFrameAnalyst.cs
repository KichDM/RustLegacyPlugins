using System;
using UnityEngine;

// Token: 0x020002A2 RID: 674
[global::UnityEngine.AddComponentMenu("")]
public class GFxFrameAnalyst : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060017DA RID: 6106 RVA: 0x00059C28 File Offset: 0x00057E28
	public GFxFrameAnalyst()
	{
	}

	// Token: 0x060017DB RID: 6107 RVA: 0x00059C30 File Offset: 0x00057E30
	public static void EnsureRunning()
	{
	}

	// Token: 0x060017DC RID: 6108 RVA: 0x00059C34 File Offset: 0x00057E34
	private void LateUpdate()
	{
		global::GFxCameraDepthTextureControl.FrameCheck();
	}

	// Token: 0x060017DD RID: 6109 RVA: 0x00059C3C File Offset: 0x00057E3C
	private void OnDestroy()
	{
		if (global::GFxFrameAnalyst.once && global::GFxFrameAnalyst.singleton == this)
		{
			global::GFxFrameAnalyst.singleton = null;
			global::GFxFrameAnalyst.once = false;
		}
	}

	// Token: 0x04000C9C RID: 3228
	private static global::GFxFrameAnalyst singleton;

	// Token: 0x04000C9D RID: 3229
	private static bool once;
}
