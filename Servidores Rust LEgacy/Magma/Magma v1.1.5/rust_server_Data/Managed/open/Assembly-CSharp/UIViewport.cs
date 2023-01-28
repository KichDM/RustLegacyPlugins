using System;
using UnityEngine;

// Token: 0x02000973 RID: 2419
[global::UnityEngine.AddComponentMenu("NGUI/UI/Viewport Camera")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public class UIViewport : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005271 RID: 21105 RVA: 0x00153470 File Offset: 0x00151670
	public UIViewport()
	{
	}

	// Token: 0x06005272 RID: 21106 RVA: 0x00153484 File Offset: 0x00151684
	private void Start()
	{
		this.mCam = base.camera;
		if (this.sourceCamera == null)
		{
			this.sourceCamera = global::UnityEngine.Camera.main;
		}
	}

	// Token: 0x06005273 RID: 21107 RVA: 0x001534BC File Offset: 0x001516BC
	private void LateUpdate()
	{
		if (this.topLeft != null && this.bottomRight != null)
		{
			global::UnityEngine.Vector3 vector = this.sourceCamera.WorldToScreenPoint(this.topLeft.position);
			global::UnityEngine.Vector3 vector2 = this.sourceCamera.WorldToScreenPoint(this.bottomRight.position);
			global::UnityEngine.Rect rect;
			rect..ctor(vector.x / (float)global::UnityEngine.Screen.width, vector2.y / (float)global::UnityEngine.Screen.height, (vector2.x - vector.x) / (float)global::UnityEngine.Screen.width, (vector.y - vector2.y) / (float)global::UnityEngine.Screen.height);
			float num = this.fullSize * rect.height;
			if (rect != this.mCam.rect)
			{
				this.mCam.rect = rect;
			}
			if (this.mCam.orthographicSize != num)
			{
				this.mCam.orthographicSize = num;
			}
		}
	}

	// Token: 0x04002EED RID: 12013
	public global::UnityEngine.Camera sourceCamera;

	// Token: 0x04002EEE RID: 12014
	public global::UnityEngine.Transform topLeft;

	// Token: 0x04002EEF RID: 12015
	public global::UnityEngine.Transform bottomRight;

	// Token: 0x04002EF0 RID: 12016
	public float fullSize = 1f;

	// Token: 0x04002EF1 RID: 12017
	private global::UnityEngine.Camera mCam;
}
