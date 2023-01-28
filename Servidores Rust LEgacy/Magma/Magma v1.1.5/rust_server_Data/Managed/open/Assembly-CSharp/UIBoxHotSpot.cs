using System;
using UnityEngine;

// Token: 0x020008A1 RID: 2209
public class UIBoxHotSpot : global::UIHotSpot
{
	// Token: 0x06004C61 RID: 19553 RVA: 0x00120CE0 File Offset: 0x0011EEE0
	public UIBoxHotSpot() : base(global::UIHotSpot.Kind.Box, true)
	{
	}

	// Token: 0x06004C62 RID: 19554 RVA: 0x00120CF0 File Offset: 0x0011EEF0
	internal global::UnityEngine.Bounds? Internal_CalculateBounds(bool moved)
	{
		return new global::UnityEngine.Bounds?(new global::UnityEngine.Bounds(this.center, this.size));
	}

	// Token: 0x06004C63 RID: 19555 RVA: 0x00120D08 File Offset: 0x0011EF08
	internal bool Internal_RaycastRef(global::UnityEngine.Ray ray, ref global::UIHotSpot.Hit hit)
	{
		global::UnityEngine.Bounds bounds;
		bounds..ctor(this.center, this.size);
		if (bounds.IntersectRay(ray, ref hit.distance))
		{
			hit.point = ray.GetPoint(hit.distance);
			hit.normal = -ray.direction;
			return true;
		}
		return false;
	}

	// Token: 0x06004C64 RID: 19556 RVA: 0x00120D64 File Offset: 0x0011EF64
	private void OnDrawGizmos()
	{
		global::UnityEngine.Gizmos.matrix = base.gizmoMatrix;
		global::UnityEngine.Gizmos.color = base.gizmoColor;
		global::UnityEngine.Gizmos.DrawWireCube(this.center, this.size);
	}

	// Token: 0x04002952 RID: 10578
	private const global::UIHotSpot.Kind kKind = global::UIHotSpot.Kind.Box;

	// Token: 0x04002953 RID: 10579
	public new global::UnityEngine.Vector3 center;

	// Token: 0x04002954 RID: 10580
	public new global::UnityEngine.Vector3 size;
}
