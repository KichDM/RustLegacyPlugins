using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000573 RID: 1395
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public sealed class CameraMount : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002F07 RID: 12039 RVA: 0x000B3BBC File Offset: 0x000B1DBC
	public CameraMount()
	{
	}

	// Token: 0x170009F8 RID: 2552
	// (get) Token: 0x06002F08 RID: 12040 RVA: 0x000B3BC4 File Offset: 0x000B1DC4
	public static global::CameraMount current
	{
		get
		{
			return global::CameraMount.top;
		}
	}

	// Token: 0x170009F9 RID: 2553
	// (get) Token: 0x06002F09 RID: 12041 RVA: 0x000B3BCC File Offset: 0x000B1DCC
	public bool isActiveMount
	{
		get
		{
			return global::CameraMount.top == this;
		}
	}

	// Token: 0x06002F0A RID: 12042 RVA: 0x000B3BDC File Offset: 0x000B1DDC
	private void OnSetActiveMount()
	{
	}

	// Token: 0x06002F0B RID: 12043 RVA: 0x000B3BE0 File Offset: 0x000B1DE0
	private void OnNotActiveMount()
	{
	}

	// Token: 0x06002F0C RID: 12044 RVA: 0x000B3BE4 File Offset: 0x000B1DE4
	public void OnPreMount(global::MountedCamera camera)
	{
	}

	// Token: 0x06002F0D RID: 12045 RVA: 0x000B3BE8 File Offset: 0x000B1DE8
	public void OnPostMount(global::MountedCamera camera)
	{
	}

	// Token: 0x170009FA RID: 2554
	// (get) Token: 0x06002F0E RID: 12046 RVA: 0x000B3BEC File Offset: 0x000B1DEC
	private static global::System.Collections.Generic.Stack<global::CameraMount> queue
	{
		get
		{
			return global::CameraMount.QUEUE_LATE.queue;
		}
	}

	// Token: 0x040018E7 RID: 6375
	[global::PrefetchComponent]
	public global::CameraFX cameraFX;

	// Token: 0x040018E8 RID: 6376
	[global::PrefetchComponent]
	public global::UnityEngine.Camera camera;

	// Token: 0x040018E9 RID: 6377
	public global::KindOfCamera kindOfCamera;

	// Token: 0x040018EA RID: 6378
	public global::SharedCameraMode cameraMode;

	// Token: 0x040018EB RID: 6379
	private static global::CameraMount top;

	// Token: 0x040018EC RID: 6380
	[global::UnityEngine.SerializeField]
	private int importance;

	// Token: 0x040018ED RID: 6381
	[global::UnityEngine.SerializeField]
	private bool autoBind;

	// Token: 0x040018EE RID: 6382
	[global::System.NonSerialized]
	private bool awoke;

	// Token: 0x040018EF RID: 6383
	[global::System.NonSerialized]
	private bool bound;

	// Token: 0x040018F0 RID: 6384
	[global::System.NonSerialized]
	private bool destroyed;

	// Token: 0x02000574 RID: 1396
	private static class QUEUE_LATE
	{
		// Token: 0x06002F0F RID: 12047 RVA: 0x000B3BF4 File Offset: 0x000B1DF4
		// Note: this type is marked as 'beforefieldinit'.
		static QUEUE_LATE()
		{
		}

		// Token: 0x040018F1 RID: 6385
		public static readonly global::System.Collections.Generic.Stack<global::CameraMount> queue = new global::System.Collections.Generic.Stack<global::CameraMount>();
	}

	// Token: 0x02000575 RID: 1397
	private static class WORK_LATE
	{
		// Token: 0x06002F10 RID: 12048 RVA: 0x000B3C00 File Offset: 0x000B1E00
		// Note: this type is marked as 'beforefieldinit'.
		static WORK_LATE()
		{
		}

		// Token: 0x040018F2 RID: 6386
		public static readonly global::System.Collections.Generic.List<global::CameraMount> list = new global::System.Collections.Generic.List<global::CameraMount>();
	}
}
