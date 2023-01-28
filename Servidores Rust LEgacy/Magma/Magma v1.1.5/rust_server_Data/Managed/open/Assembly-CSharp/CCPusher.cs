using System;
using Facepunch.Geometry;
using UnityEngine;

// Token: 0x02000301 RID: 769
public class CCPusher : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06001A40 RID: 6720 RVA: 0x00067370 File Offset: 0x00065570
	public CCPusher()
	{
	}

	// Token: 0x06001A41 RID: 6721 RVA: 0x000673B0 File Offset: 0x000655B0
	private void OnDrawGizmosSelected()
	{
		global::UnityEngine.Collider collider = base.collider;
		if (collider)
		{
			global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(0.5f, 0.5f, 1f, 0.8f);
			this.shape.Transform(global::Facepunch.Geometry.ColliderUtility.ColliderToWorld(collider)).Gizmo();
			global::UnityEngine.Matrix4x4 localToWorldMatrix = base.transform.localToWorldMatrix;
			global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(0.9f, 0.5f, 1f, 0.8f);
			global::CCPusher.DrawPushPlane(localToWorldMatrix, this.pushPoint0, this.pushDir0);
			global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(1f, 0.5f, 0.5f, 0.8f);
			global::CCPusher.DrawPushPlane(localToWorldMatrix, this.pushPoint1, this.pushDir1);
		}
	}

	// Token: 0x06001A42 RID: 6722 RVA: 0x0006747C File Offset: 0x0006567C
	private static void DrawPushPlane(global::UnityEngine.Matrix4x4 trs, global::UnityEngine.Vector3 point, global::UnityEngine.Vector3 dir)
	{
		point = trs.MultiplyPoint3x4(point);
		dir = trs.MultiplyVector(dir);
		global::UnityEngine.Vector3 vector = point + dir.normalized * 0.1f;
		global::UnityEngine.Gizmos.DrawLine(point, vector);
		global::UnityEngine.Matrix4x4 matrix = global::UnityEngine.Gizmos.matrix;
		global::UnityEngine.Gizmos.matrix = matrix * global::UnityEngine.Matrix4x4.TRS(point, global::UnityEngine.Quaternion.LookRotation(dir), global::UnityEngine.Vector3.one);
		global::UnityEngine.Gizmos.DrawWireCube(global::UnityEngine.Vector3.zero, new global::UnityEngine.Vector3(1f, 1f, 0.0001f));
		global::UnityEngine.Gizmos.matrix = matrix;
	}

	// Token: 0x06001A43 RID: 6723 RVA: 0x00067504 File Offset: 0x00065704
	private void Reset()
	{
		if (this.shape == null)
		{
			this.shape = new global::Facepunch.Geometry.ShapeDefinition();
		}
		global::Facepunch.Geometry.Shape shape;
		if (base.collider && global::Facepunch.Geometry.ColliderUtility.GetGeometricShapeLocal(base.collider, ref shape))
		{
			this.shape.Shape = shape;
		}
	}

	// Token: 0x06001A44 RID: 6724 RVA: 0x00067558 File Offset: 0x00065758
	public bool Push(global::Facepunch.Geometry.Sphere Sphere, ref global::UnityEngine.Vector3 Velocity)
	{
		if (this.shape.Shape.Intersects(Sphere))
		{
			global::Facepunch.Geometry.Plane plane = global::Facepunch.Geometry.Plane.DirectionPoint(this.pushDir0, this.pushPoint0);
			global::Facepunch.Geometry.Plane plane2 = global::Facepunch.Geometry.Plane.DirectionPoint(this.pushDir1, this.pushPoint1);
			float num = plane.DistanceTo(Sphere.Center + (global::Facepunch.Geometry.Normal)plane.Direction * Sphere.Radius);
			float num2 = plane2.DistanceTo(Sphere.Center + (global::Facepunch.Geometry.Normal)plane2.Direction * Sphere.Radius);
			global::Facepunch.Geometry.Vector vector;
			if (num > num2)
			{
				vector = (global::Facepunch.Geometry.Normal)plane.Direction * (this.pushSpeed * global::UnityEngine.Time.deltaTime);
			}
			else
			{
				vector = (global::Facepunch.Geometry.Normal)plane2.Direction * (this.pushSpeed * global::UnityEngine.Time.deltaTime);
			}
			Velocity.x += vector.x;
			Velocity.y += vector.y;
			Velocity.z += vector.z;
			return true;
		}
		return false;
	}

	// Token: 0x04000F20 RID: 3872
	[global::UnityEngine.SerializeField]
	private global::Facepunch.Geometry.ShapeDefinition shape;

	// Token: 0x04000F21 RID: 3873
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector3 pushPoint0 = global::UnityEngine.Vector3.forward;

	// Token: 0x04000F22 RID: 3874
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector3 pushDir0 = global::UnityEngine.Vector3.back;

	// Token: 0x04000F23 RID: 3875
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector3 pushPoint1 = global::UnityEngine.Vector3.back;

	// Token: 0x04000F24 RID: 3876
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector3 pushDir1 = global::UnityEngine.Vector3.forward;

	// Token: 0x04000F25 RID: 3877
	[global::UnityEngine.SerializeField]
	private float pushSpeed = 3f;
}
