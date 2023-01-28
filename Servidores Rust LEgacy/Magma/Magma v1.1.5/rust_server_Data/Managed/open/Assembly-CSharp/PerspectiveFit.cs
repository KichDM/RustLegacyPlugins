using System;
using UnityEngine;

// Token: 0x0200076F RID: 1903
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public class PerspectiveFit : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003F35 RID: 16181 RVA: 0x000E1460 File Offset: 0x000DF660
	public PerspectiveFit()
	{
	}

	// Token: 0x06003F36 RID: 16182 RVA: 0x000E1494 File Offset: 0x000DF694
	private void OnPreCull()
	{
		if (base.enabled && this.camera && this.camera.enabled)
		{
			float aspect = this.camera.aspect;
			float num = this.targetSize.x / this.targetSize.y;
			float num2 = global::UnityEngine.Vector2.Angle(new global::UnityEngine.Vector2(this.targetSize.x / aspect * 0.5f, this.targetDistance), new global::UnityEngine.Vector2(0f, this.targetDistance)) * 2f;
			float num3 = global::UnityEngine.Vector2.Angle(new global::UnityEngine.Vector2(this.targetSize.y * 0.5f, this.targetDistance), new global::UnityEngine.Vector2(0f, this.targetDistance)) * 2f;
			float fieldOfView;
			if (num < aspect)
			{
				fieldOfView = num3;
			}
			else
			{
				fieldOfView = num2;
			}
			this.camera.fieldOfView = fieldOfView;
		}
	}

	// Token: 0x06003F37 RID: 16183 RVA: 0x000E1580 File Offset: 0x000DF780
	private void Reset()
	{
		if (!this.camera)
		{
			this.camera = base.camera;
		}
	}

	// Token: 0x0400208A RID: 8330
	[global::PrefetchComponent]
	public global::UnityEngine.Camera camera;

	// Token: 0x0400208B RID: 8331
	public float targetDistance = 2.2f;

	// Token: 0x0400208C RID: 8332
	public global::UnityEngine.Vector2 targetSize = new global::UnityEngine.Vector2(2.4f, 1.1f);
}
