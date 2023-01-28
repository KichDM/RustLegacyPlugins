using System;
using UnityEngine;

// Token: 0x020008AA RID: 2218
public class UIRectHotSpot : global::UIHotSpot
{
	// Token: 0x06004CB5 RID: 19637 RVA: 0x001230B8 File Offset: 0x001212B8
	public UIRectHotSpot() : base(global::UIHotSpot.Kind.Rect, true)
	{
	}

	// Token: 0x06004CB6 RID: 19638 RVA: 0x001230D0 File Offset: 0x001212D0
	internal global::UnityEngine.Bounds? Internal_CalculateBounds(bool moved)
	{
		return new global::UnityEngine.Bounds?(new global::UnityEngine.Bounds(this.center, this.size));
	}

	// Token: 0x06004CB7 RID: 19639 RVA: 0x001230F0 File Offset: 0x001212F0
	internal bool Internal_RaycastRef(global::UnityEngine.Ray ray, ref global::UIHotSpot.Hit hit)
	{
		if (this.size.x < 3E-45f || this.size.y < 3E-45f)
		{
			return false;
		}
		hit.normal = global::UIHotSpot.forward;
		global::UnityEngine.Plane plane;
		plane..ctor(global::UIHotSpot.forward, this.center);
		float num;
		if (!plane.Raycast(ray, ref num))
		{
			hit = default(global::UIHotSpot.Hit);
			return false;
		}
		hit.point = ray.GetPoint(num);
		global::UnityEngine.Vector2 vector;
		vector.x = ((hit.point.x >= this.center.x) ? (hit.point.x - this.center.x) : (this.center.x - hit.point.x));
		vector.y = ((hit.point.y >= this.center.y) ? (hit.point.y - this.center.y) : (this.center.y - hit.point.y));
		if (vector.x * 2f <= this.size.x && vector.y * 2f <= this.size.y)
		{
			hit.distance = global::UnityEngine.Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
			return true;
		}
		return false;
	}

	// Token: 0x06004CB8 RID: 19640 RVA: 0x00123288 File Offset: 0x00121488
	private void OnDrawGizmos()
	{
		global::UnityEngine.Gizmos.matrix = base.gizmoMatrix;
		global::UnityEngine.Gizmos.color = base.gizmoColor;
		global::UnityEngine.Gizmos.DrawWireCube(this.center, this.size);
	}

	// Token: 0x0400298F RID: 10639
	private const global::UIHotSpot.Kind kKind = global::UIHotSpot.Kind.Rect;

	// Token: 0x04002990 RID: 10640
	private const float kEpsilon = 3E-45f;

	// Token: 0x04002991 RID: 10641
	public new global::UnityEngine.Vector3 center;

	// Token: 0x04002992 RID: 10642
	public new global::UnityEngine.Vector2 size = global::UnityEngine.Vector2.one;
}
