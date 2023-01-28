using System;
using UnityEngine;

// Token: 0x0200056C RID: 1388
public sealed class CameraEventMaskClear : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002EF4 RID: 12020 RVA: 0x000B30A0 File Offset: 0x000B12A0
	public CameraEventMaskClear()
	{
	}

	// Token: 0x06002EF5 RID: 12021 RVA: 0x000B30A8 File Offset: 0x000B12A8
	private void Awake()
	{
		base.camera.eventMask = 0;
	}
}
