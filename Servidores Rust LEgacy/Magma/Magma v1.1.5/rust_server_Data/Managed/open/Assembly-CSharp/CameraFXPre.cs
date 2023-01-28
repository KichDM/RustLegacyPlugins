using System;
using UnityEngine;

// Token: 0x02000571 RID: 1393
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public class CameraFXPre : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002EFE RID: 12030 RVA: 0x000B3148 File Offset: 0x000B1348
	public CameraFXPre()
	{
	}

	// Token: 0x06002EFF RID: 12031 RVA: 0x000B3150 File Offset: 0x000B1350
	// Note: this type is marked as 'beforefieldinit'.
	static CameraFXPre()
	{
	}

	// Token: 0x040018A0 RID: 6304
	private static int lastRenderFrame = -0x64;

	// Token: 0x040018A1 RID: 6305
	private static bool didPostRender;

	// Token: 0x040018A2 RID: 6306
	public static global::CameraFX cameraFX;

	// Token: 0x040018A3 RID: 6307
	public static global::MountedCamera mountedCamera;

	// Token: 0x040018A4 RID: 6308
	public bool allowPostRenderCalls;
}
