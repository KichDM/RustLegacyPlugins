using System;
using UnityEngine;

// Token: 0x020007C5 RID: 1989
public class TransformLerpTest : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060041F4 RID: 16884 RVA: 0x000EF514 File Offset: 0x000ED714
	public TransformLerpTest()
	{
	}

	// Token: 0x060041F5 RID: 16885 RVA: 0x000EF51C File Offset: 0x000ED71C
	private global::UnityEngine.Matrix4x4 Interp(float t, global::UnityEngine.Matrix4x4 a, global::UnityEngine.Matrix4x4 b)
	{
		global::UnityEngine.Matrix4x4 result;
		switch (this.mode)
		{
		default:
			result = global::TransitionFunctions.Slerp(t, a, b);
			break;
		case global::TransformLerpTest.SlerpMode.TransformLerp:
		case global::TransformLerpTest.SlerpMode.WorldToCameraLerp:
		case global::TransformLerpTest.SlerpMode.CameraToWorldLerp:
			result = global::TransitionFunctions.Linear(t, a, b);
			break;
		case global::TransformLerpTest.SlerpMode.WorldToCameraSlerp2:
			result = global::TransitionFunctions.SlerpWorldToCamera(t, a, b);
			break;
		}
		if (this.inverse0)
		{
			if (this.transpose)
			{
				if (!this.inverse1)
				{
					return result.inverse.transpose;
				}
				return result.inverse.transpose.inverse;
			}
			else
			{
				if (this.inverse1)
				{
					return result.inverse.inverse;
				}
				return result.inverse;
			}
		}
		else if (this.transpose)
		{
			if (this.inverse1)
			{
				return result.transpose.inverse;
			}
			return result.transpose;
		}
		else
		{
			if (this.inverse1)
			{
				return result.inverse;
			}
			return result;
		}
	}

	// Token: 0x17000C1B RID: 3099
	// (get) Token: 0x060041F6 RID: 16886 RVA: 0x000EF634 File Offset: 0x000ED834
	private bool ready
	{
		get
		{
			switch (this.mode)
			{
			default:
				return this.a && this.b;
			case global::TransformLerpTest.SlerpMode.WorldToCameraSlerp:
			case global::TransformLerpTest.SlerpMode.WorldToCameraLerp:
			case global::TransformLerpTest.SlerpMode.CameraToWorldSlerp:
			case global::TransformLerpTest.SlerpMode.CameraToWorldLerp:
				return this.a && this.b && this.a.camera && this.b.camera;
			}
		}
	}

	// Token: 0x060041F7 RID: 16887 RVA: 0x000EF6D4 File Offset: 0x000ED8D4
	private global::UnityEngine.Matrix4x4 GetMatrix(global::UnityEngine.Transform a)
	{
		switch (this.mode)
		{
		default:
			if (a.camera)
			{
				return a.camera.worldToCameraMatrix * a.localToWorldMatrix;
			}
			return a.localToWorldMatrix;
		case global::TransformLerpTest.SlerpMode.WorldToCameraSlerp:
		case global::TransformLerpTest.SlerpMode.WorldToCameraLerp:
		case global::TransformLerpTest.SlerpMode.WorldToCameraSlerp2:
			return a.camera.worldToCameraMatrix;
		case global::TransformLerpTest.SlerpMode.CameraToWorldSlerp:
		case global::TransformLerpTest.SlerpMode.CameraToWorldLerp:
			return a.camera.cameraToWorldMatrix;
		}
	}

	// Token: 0x060041F8 RID: 16888 RVA: 0x000EF754 File Offset: 0x000ED954
	private static void DrawAxes(global::UnityEngine.Matrix4x4 m, float alpha)
	{
		global::UnityEngine.Vector3 vector = m.MultiplyPoint(global::UnityEngine.Vector3.zero);
		global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(1f, 1f, 1f, alpha);
		global::UnityEngine.Gizmos.DrawSphere(vector, 0.01f);
		global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(1f, 0f, 0f, alpha);
		global::UnityEngine.Gizmos.DrawLine(vector, m.MultiplyPoint(global::UnityEngine.Vector3.right));
		global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(0f, 1f, 0f, alpha);
		global::UnityEngine.Gizmos.DrawLine(vector, m.MultiplyPoint(global::UnityEngine.Vector3.up));
		global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(0f, 0f, 1f, alpha);
		global::UnityEngine.Gizmos.DrawLine(vector, m.MultiplyPoint(global::UnityEngine.Vector3.forward));
	}

	// Token: 0x060041F9 RID: 16889 RVA: 0x000EF818 File Offset: 0x000EDA18
	private void OnDrawGizmos()
	{
		if (this.ready)
		{
			global::UnityEngine.Matrix4x4 matrix = this.GetMatrix(this.a);
			global::UnityEngine.Matrix4x4 matrix2 = this.GetMatrix(this.b);
			float num = (!this.cap) ? this.t : global::UnityEngine.Mathf.Clamp01(this.t);
			global::UnityEngine.Matrix4x4 m = this.Interp(0f, matrix, matrix2);
			global::TransformLerpTest.DrawAxes(m, 0.5f);
			for (int i = 1; i <= 0x20; i++)
			{
				global::UnityEngine.Matrix4x4 matrix4x = this.Interp((float)i / 32f, matrix, matrix2);
				global::UnityEngine.Gizmos.color = global::UnityEngine.Color.white * 0.5f;
				global::UnityEngine.Gizmos.DrawLine(m.MultiplyPoint(global::UnityEngine.Vector3.zero), matrix4x.MultiplyPoint(global::UnityEngine.Vector3.zero));
				global::UnityEngine.Gizmos.color = global::UnityEngine.Color.red * 0.5f;
				global::UnityEngine.Gizmos.DrawLine(m.MultiplyPoint(global::UnityEngine.Vector3.right), matrix4x.MultiplyPoint(global::UnityEngine.Vector3.right));
				global::UnityEngine.Gizmos.color = global::UnityEngine.Color.green * 0.5f;
				global::UnityEngine.Gizmos.DrawLine(m.MultiplyPoint(global::UnityEngine.Vector3.up), matrix4x.MultiplyPoint(global::UnityEngine.Vector3.up));
				global::UnityEngine.Gizmos.color = global::UnityEngine.Color.blue * 0.5f;
				global::UnityEngine.Gizmos.DrawLine(m.MultiplyPoint(global::UnityEngine.Vector3.forward), matrix4x.MultiplyPoint(global::UnityEngine.Vector3.forward));
				m = matrix4x;
			}
			global::TransformLerpTest.DrawAxes(m, 0.5f);
			m = this.Interp(num, matrix, matrix2);
			global::TransformLerpTest.DrawAxes(m, 1f);
			this.angleXY = global::UnityEngine.Vector3.Angle(m.MultiplyVector(global::UnityEngine.Vector3.right), m.MultiplyVector(global::UnityEngine.Vector3.up));
			this.angleYZ = global::UnityEngine.Vector3.Angle(m.MultiplyVector(global::UnityEngine.Vector3.up), m.MultiplyVector(global::UnityEngine.Vector3.forward));
			this.angleZX = global::UnityEngine.Vector3.Angle(m.MultiplyVector(global::UnityEngine.Vector3.forward), m.MultiplyVector(global::UnityEngine.Vector3.right));
		}
	}

	// Token: 0x040022BB RID: 8891
	public global::UnityEngine.Transform a;

	// Token: 0x040022BC RID: 8892
	public global::UnityEngine.Transform b;

	// Token: 0x040022BD RID: 8893
	public float t;

	// Token: 0x040022BE RID: 8894
	public float angleXY;

	// Token: 0x040022BF RID: 8895
	public float angleYZ;

	// Token: 0x040022C0 RID: 8896
	public float angleZX;

	// Token: 0x040022C1 RID: 8897
	public bool cap;

	// Token: 0x040022C2 RID: 8898
	public bool inverse0;

	// Token: 0x040022C3 RID: 8899
	public bool transpose;

	// Token: 0x040022C4 RID: 8900
	public bool inverse1;

	// Token: 0x040022C5 RID: 8901
	[global::UnityEngine.SerializeField]
	private global::TransformLerpTest.SlerpMode mode;

	// Token: 0x020007C6 RID: 1990
	private enum SlerpMode
	{
		// Token: 0x040022C7 RID: 8903
		TransformSlerp,
		// Token: 0x040022C8 RID: 8904
		TransformLerp,
		// Token: 0x040022C9 RID: 8905
		WorldToCameraSlerp,
		// Token: 0x040022CA RID: 8906
		WorldToCameraLerp,
		// Token: 0x040022CB RID: 8907
		CameraToWorldSlerp,
		// Token: 0x040022CC RID: 8908
		CameraToWorldLerp,
		// Token: 0x040022CD RID: 8909
		WorldToCameraSlerp2
	}
}
