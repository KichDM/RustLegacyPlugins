using System;
using UnityEngine;

// Token: 0x020008A4 RID: 2212
public class UIConvexHotSpot : global::UIHotSpot
{
	// Token: 0x06004C6E RID: 19566 RVA: 0x00120F8C File Offset: 0x0011F18C
	public UIConvexHotSpot() : base(global::UIHotSpot.Kind.Convex, true)
	{
	}

	// Token: 0x06004C6F RID: 19567 RVA: 0x00120F98 File Offset: 0x0011F198
	internal global::UnityEngine.Bounds? Internal_CalculateBounds(bool moved)
	{
		throw new global::System.NotImplementedException();
	}

	// Token: 0x06004C70 RID: 19568 RVA: 0x00120FA0 File Offset: 0x0011F1A0
	internal bool Internal_RaycastRef(global::UnityEngine.Ray ray, ref global::UIHotSpot.Hit hit)
	{
		throw new global::System.NotImplementedException();
	}

	// Token: 0x04002959 RID: 10585
	private const global::UIHotSpot.Kind kKind = global::UIHotSpot.Kind.Convex;
}
