using System;
using UnityEngine;

// Token: 0x020008A3 RID: 2211
public class UICircleHotSpot : global::UIHotSpot
{
	// Token: 0x06004C68 RID: 19560 RVA: 0x00120DB8 File Offset: 0x0011EFB8
	public UICircleHotSpot() : base(global::UIHotSpot.Kind.Circle, true)
	{
	}

	// Token: 0x17000E34 RID: 3636
	// (get) Token: 0x06004C69 RID: 19561 RVA: 0x00120DD0 File Offset: 0x0011EFD0
	// (set) Token: 0x06004C6A RID: 19562 RVA: 0x00120DE0 File Offset: 0x0011EFE0
	public new float size
	{
		get
		{
			return this.radius * 2f;
		}
		set
		{
			this.radius = value / 2f;
		}
	}

	// Token: 0x06004C6B RID: 19563 RVA: 0x00120DF0 File Offset: 0x0011EFF0
	internal global::UnityEngine.Bounds? Internal_CalculateBounds(bool moved)
	{
		float num = this.radius * 2f;
		return new global::UnityEngine.Bounds?(new global::UnityEngine.Bounds(this.center, new global::UnityEngine.Vector3(num, num, 0f)));
	}

	// Token: 0x06004C6C RID: 19564 RVA: 0x00120E28 File Offset: 0x0011F028
	internal bool Internal_RaycastRef(global::UnityEngine.Ray ray, ref global::UIHotSpot.Hit hit)
	{
		if (this.radius == 0f)
		{
			return false;
		}
		global::UnityEngine.Plane plane;
		plane..ctor(global::UIHotSpot.forward, this.center);
		float num;
		if (!plane.Raycast(ray, ref num))
		{
			hit = default(global::UIHotSpot.Hit);
			return false;
		}
		hit.point = ray.GetPoint(num);
		hit.normal = ((!plane.GetSide(ray.origin)) ? global::UIHotSpot.backward : global::UIHotSpot.forward);
		global::UnityEngine.Vector2 vector;
		vector.x = hit.point.x - this.center.x;
		vector.y = hit.point.y - this.center.y;
		float num2 = vector.x * vector.x + vector.y * vector.y;
		if (num2 < this.radius * this.radius)
		{
			hit.distance = global::UnityEngine.Mathf.Sqrt(num2);
			return true;
		}
		return false;
	}

	// Token: 0x06004C6D RID: 19565 RVA: 0x00120F30 File Offset: 0x0011F130
	private void OnDrawGizmos()
	{
		global::UnityEngine.Gizmos.matrix = base.gizmoMatrix * global::UnityEngine.Matrix4x4.TRS(this.center, global::UnityEngine.Quaternion.identity, new global::UnityEngine.Vector3(1f, 1f, 0.0001f));
		global::UnityEngine.Gizmos.color = base.gizmoColor;
		global::UnityEngine.Gizmos.DrawWireSphere(global::UnityEngine.Vector3.zero, this.radius);
	}

	// Token: 0x04002956 RID: 10582
	private const global::UIHotSpot.Kind kKind = global::UIHotSpot.Kind.Circle;

	// Token: 0x04002957 RID: 10583
	public new global::UnityEngine.Vector3 center;

	// Token: 0x04002958 RID: 10584
	public float radius = 0.5f;
}
