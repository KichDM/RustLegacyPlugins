using System;
using UnityEngine;

// Token: 0x02000959 RID: 2393
[global::UnityEngine.AddComponentMenu("NGUI/UI/Orthographic Camera")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public class UIOrthoCamera : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600517F RID: 20863 RVA: 0x00142988 File Offset: 0x00140B88
	public UIOrthoCamera()
	{
	}

	// Token: 0x06005180 RID: 20864 RVA: 0x00142990 File Offset: 0x00140B90
	private void Start()
	{
		this.mCam = base.camera;
		this.mTrans = base.transform;
		this.mCam.orthographic = true;
	}

	// Token: 0x06005181 RID: 20865 RVA: 0x001429C4 File Offset: 0x00140BC4
	private void Update()
	{
		float num = this.mCam.rect.yMin * (float)global::UnityEngine.Screen.height;
		float num2 = this.mCam.rect.yMax * (float)global::UnityEngine.Screen.height;
		float num3 = (num2 - num) * 0.5f * this.mTrans.lossyScale.y;
		if (!global::UnityEngine.Mathf.Approximately(this.mCam.orthographicSize, num3))
		{
			this.mCam.orthographicSize = num3;
		}
	}

	// Token: 0x04002E15 RID: 11797
	private global::UnityEngine.Camera mCam;

	// Token: 0x04002E16 RID: 11798
	private global::UnityEngine.Transform mTrans;
}
