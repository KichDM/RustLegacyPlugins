using System;
using UnityEngine;

// Token: 0x020008A2 RID: 2210
public class UIBrushHotSpot : global::UIHotSpot
{
	// Token: 0x06004C65 RID: 19557 RVA: 0x00120D98 File Offset: 0x0011EF98
	public UIBrushHotSpot() : base(global::UIHotSpot.Kind.Brush, true)
	{
	}

	// Token: 0x06004C66 RID: 19558 RVA: 0x00120DA8 File Offset: 0x0011EFA8
	internal global::UnityEngine.Bounds? Internal_CalculateBounds(bool moved)
	{
		throw new global::System.NotImplementedException();
	}

	// Token: 0x06004C67 RID: 19559 RVA: 0x00120DB0 File Offset: 0x0011EFB0
	internal bool Internal_RaycastRef(global::UnityEngine.Ray ray, ref global::UIHotSpot.Hit hit)
	{
		throw new global::System.NotImplementedException();
	}

	// Token: 0x04002955 RID: 10581
	private const global::UIHotSpot.Kind kKind = global::UIHotSpot.Kind.Brush;
}
