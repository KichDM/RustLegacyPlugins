using System;
using UnityEngine;

// Token: 0x02000570 RID: 1392
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public class CameraFXPost : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002EFC RID: 12028 RVA: 0x000B3134 File Offset: 0x000B1334
	public CameraFXPost()
	{
	}

	// Token: 0x06002EFD RID: 12029 RVA: 0x000B313C File Offset: 0x000B133C
	// Note: this type is marked as 'beforefieldinit'.
	static CameraFXPost()
	{
	}

	// Token: 0x0400189B RID: 6299
	private static int lastRenderFrame = -0x64;

	// Token: 0x0400189C RID: 6300
	private static bool didPostRender;

	// Token: 0x0400189D RID: 6301
	public static global::CameraFX cameraFX;

	// Token: 0x0400189E RID: 6302
	public static global::MountedCamera mountedCamera;

	// Token: 0x0400189F RID: 6303
	public bool allowPostRenderCalls;
}
