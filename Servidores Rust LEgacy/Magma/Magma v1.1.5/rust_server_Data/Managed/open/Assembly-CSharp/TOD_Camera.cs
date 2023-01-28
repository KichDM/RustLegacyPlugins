using System;
using UnityEngine;

// Token: 0x0200098D RID: 2445
[global::UnityEngine.AddComponentMenu("Time of Day/Camera Main Script")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public class TOD_Camera : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060052C8 RID: 21192 RVA: 0x00158F08 File Offset: 0x00157108
	public TOD_Camera()
	{
	}

	// Token: 0x060052C9 RID: 21193 RVA: 0x00158F24 File Offset: 0x00157124
	protected void OnPreCull()
	{
		if (!this.sky)
		{
			return;
		}
		if (this.DomeScaleToFarClip)
		{
			float num = this.DomeScaleFactor * base.camera.farClipPlane;
			global::UnityEngine.Vector3 localScale;
			localScale..ctor(num, num, num);
			this.sky.transform.localScale = localScale;
		}
		if (this.DomePosToCamera)
		{
			global::UnityEngine.Vector3 position = base.transform.position;
			this.sky.transform.position = position;
		}
	}

	// Token: 0x04002FB5 RID: 12213
	public global::TOD_Sky sky;

	// Token: 0x04002FB6 RID: 12214
	public bool DomePosToCamera = true;

	// Token: 0x04002FB7 RID: 12215
	public bool DomeScaleToFarClip;

	// Token: 0x04002FB8 RID: 12216
	public float DomeScaleFactor = 0.95f;
}
