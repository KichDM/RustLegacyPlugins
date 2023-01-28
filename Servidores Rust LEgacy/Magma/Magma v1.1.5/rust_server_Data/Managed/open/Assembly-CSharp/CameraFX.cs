using System;
using UnityEngine;

// Token: 0x0200056E RID: 1390
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public class CameraFX : global::IDRemote
{
	// Token: 0x06002EF6 RID: 12022 RVA: 0x000B30B8 File Offset: 0x000B12B8
	public CameraFX()
	{
	}

	// Token: 0x170009F4 RID: 2548
	// (get) Token: 0x06002EF7 RID: 12023 RVA: 0x000B30D4 File Offset: 0x000B12D4
	public global::Character idMain
	{
		get
		{
			return (global::Character)base.idMain;
		}
	}

	// Token: 0x170009F5 RID: 2549
	// (get) Token: 0x06002EF8 RID: 12024 RVA: 0x000B30E4 File Offset: 0x000B12E4
	public global::UnityEngine.Material predrawMaterial
	{
		get
		{
			return this.viewModelPredrawMaterial;
		}
	}

	// Token: 0x170009F6 RID: 2550
	// (get) Token: 0x06002EF9 RID: 12025 RVA: 0x000B30EC File Offset: 0x000B12EC
	public global::UnityEngine.Material postdrawMaterial
	{
		get
		{
			return this.viewModelPostdrawMaterial;
		}
	}

	// Token: 0x06002EFA RID: 12026 RVA: 0x000B30F4 File Offset: 0x000B12F4
	public void SetFieldOfView(float fieldOfView, float fraction)
	{
		this.camera.fieldOfView = this.baseFieldOfView * (1f - fraction) + fieldOfView * fraction;
	}

	// Token: 0x0400188D RID: 6285
	[global::System.NonSerialized]
	public global::UnityEngine.Camera camera;

	// Token: 0x0400188E RID: 6286
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.MonoBehaviour[] _effects;

	// Token: 0x0400188F RID: 6287
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Material viewModelPredrawMaterial;

	// Token: 0x04001890 RID: 6288
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Material viewModelPostdrawMaterial;

	// Token: 0x04001891 RID: 6289
	[global::System.NonSerialized]
	private global::AdaptiveNearPlane adaptiveNearPlane;

	// Token: 0x04001892 RID: 6290
	[global::UnityEngine.SerializeField]
	private float baseFieldOfView = 60f;

	// Token: 0x04001893 RID: 6291
	[global::UnityEngine.SerializeField]
	private bool recalcViewMatrix = true;

	// Token: 0x04001894 RID: 6292
	private global::ICameraFX[] effects;

	// Token: 0x04001895 RID: 6293
	private global::UnityEngine.Quaternion preRotation;

	// Token: 0x04001896 RID: 6294
	private global::UnityEngine.Vector3 preLocalPosition;
}
