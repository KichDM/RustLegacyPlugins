using System;
using UnityEngine;

// Token: 0x020008AB RID: 2219
public class UISphereHotSpot : global::UIHotSpot
{
	// Token: 0x06004CB9 RID: 19641 RVA: 0x001232C4 File Offset: 0x001214C4
	public UISphereHotSpot() : base(global::UIHotSpot.Kind.Sphere, true)
	{
	}

	// Token: 0x17000E52 RID: 3666
	// (get) Token: 0x06004CBA RID: 19642 RVA: 0x001232E0 File Offset: 0x001214E0
	// (set) Token: 0x06004CBB RID: 19643 RVA: 0x001232F0 File Offset: 0x001214F0
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

	// Token: 0x06004CBC RID: 19644 RVA: 0x00123300 File Offset: 0x00121500
	internal global::UnityEngine.Bounds? Internal_CalculateBounds(bool moved)
	{
		float num = this.radius * 2f;
		return new global::UnityEngine.Bounds?(new global::UnityEngine.Bounds(this.center, new global::UnityEngine.Vector3(num, num, num)));
	}

	// Token: 0x06004CBD RID: 19645 RVA: 0x00123334 File Offset: 0x00121534
	internal bool Internal_RaycastRef(global::UnityEngine.Ray ray, ref global::UIHotSpot.Hit hit)
	{
		float num;
		float num2;
		global::IntersectHint intersectHint = global::Intersect3D.RayCircleInfiniteForward(ray, this.center, this.radius, ref num, ref num2);
		switch (intersectHint)
		{
		case 1:
		case 2:
		case 3:
			hit.distance = global::UnityEngine.Mathf.Min(num, num2);
			if (hit.distance < 0f && (hit.distance = global::UnityEngine.Mathf.Max(num, num2)) < 0f)
			{
				return false;
			}
			hit.point = ray.GetPoint(hit.distance);
			hit.normal = global::UnityEngine.Vector3.Normalize(hit.point - this.center);
			return true;
		default:
			global::UnityEngine.Debug.Log(intersectHint, this);
			return false;
		}
	}

	// Token: 0x06004CBE RID: 19646 RVA: 0x001233F4 File Offset: 0x001215F4
	private void OnDrawGizmos()
	{
		global::UnityEngine.Gizmos.matrix = base.gizmoMatrix;
		global::UnityEngine.Gizmos.color = base.gizmoColor;
		global::UnityEngine.Gizmos.DrawWireSphere(this.center, this.radius);
	}

	// Token: 0x04002993 RID: 10643
	private const global::UIHotSpot.Kind kKind = global::UIHotSpot.Kind.Sphere;

	// Token: 0x04002994 RID: 10644
	public new global::UnityEngine.Vector3 center;

	// Token: 0x04002995 RID: 10645
	public float radius = 0.5f;
}
