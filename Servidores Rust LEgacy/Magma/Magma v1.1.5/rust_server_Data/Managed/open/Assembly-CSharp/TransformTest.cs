using System;
using Facepunch.Precision;
using UnityEngine;

// Token: 0x020007C7 RID: 1991
public class TransformTest : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060041FA RID: 16890 RVA: 0x000EFA00 File Offset: 0x000EDC00
	public TransformTest()
	{
	}

	// Token: 0x060041FB RID: 16891 RVA: 0x000EFA08 File Offset: 0x000EDC08
	private void OnDrawGizmos()
	{
		global::Facepunch.Precision.Matrix4x4G matrix4x4G;
		global::Facepunch.Precision.Precise.ExtractLocalToWorld(base.transform, ref matrix4x4G);
		global::UnityEngine.Matrix4x4 localToWorldMatrix = base.transform.localToWorldMatrix;
		global::UnityEngine.Vector3 vector = localToWorldMatrix.MultiplyPoint(global::UnityEngine.Vector3.zero);
		global::UnityEngine.Vector3 vector2 = localToWorldMatrix.MultiplyPoint(global::UnityEngine.Vector3.forward);
		global::UnityEngine.Vector3 vector3 = localToWorldMatrix.MultiplyPoint(global::UnityEngine.Vector3.up);
		global::UnityEngine.Vector3 vector4 = localToWorldMatrix.MultiplyPoint(global::UnityEngine.Vector3.right);
		global::Facepunch.Precision.Vector3G vector3G;
		vector3G.x = 1.0;
		vector3G.y = 0.0;
		vector3G.z = 0.0;
		global::Facepunch.Precision.Vector3G vector3G2;
		global::Facepunch.Precision.Matrix4x4G.Mult(ref vector3G, ref matrix4x4G, ref vector3G2);
		vector3G.x = 0.0;
		vector3G.y = 1.0;
		vector3G.z = 0.0;
		global::Facepunch.Precision.Vector3G vector3G3;
		global::Facepunch.Precision.Matrix4x4G.Mult(ref vector3G, ref matrix4x4G, ref vector3G3);
		vector3G.x = 0.0;
		vector3G.y = 0.0;
		vector3G.z = 1.0;
		global::Facepunch.Precision.Vector3G vector3G4;
		global::Facepunch.Precision.Matrix4x4G.Mult(ref vector3G, ref matrix4x4G, ref vector3G4);
		vector3G.x = 0.0;
		vector3G.y = 0.0;
		vector3G.z = 0.0;
		global::Facepunch.Precision.Vector3G vector3G5;
		global::Facepunch.Precision.Matrix4x4G.Mult(ref vector3G, ref matrix4x4G, ref vector3G5);
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.red * new global::UnityEngine.Color(1f, 1f, 1f, 0.5f);
		global::UnityEngine.Gizmos.DrawLine(vector, vector4);
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.green * new global::UnityEngine.Color(1f, 1f, 1f, 0.5f);
		global::UnityEngine.Gizmos.DrawLine(vector, vector3);
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.blue * new global::UnityEngine.Color(1f, 1f, 1f, 0.5f);
		global::UnityEngine.Gizmos.DrawLine(vector, vector2);
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.red * new global::UnityEngine.Color(1f, 1f, 1f, 1f);
		global::UnityEngine.Gizmos.DrawLine(vector3G5.f, vector3G2.f);
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.green * new global::UnityEngine.Color(1f, 1f, 1f, 1f);
		global::UnityEngine.Gizmos.DrawLine(vector3G5.f, vector3G3.f);
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.blue * new global::UnityEngine.Color(1f, 1f, 1f, 1f);
		global::UnityEngine.Gizmos.DrawLine(vector3G5.f, vector3G4.f);
	}
}
