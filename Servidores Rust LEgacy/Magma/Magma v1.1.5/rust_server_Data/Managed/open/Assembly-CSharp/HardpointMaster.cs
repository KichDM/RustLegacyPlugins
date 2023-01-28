using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200076A RID: 1898
public class HardpointMaster : global::IDLocal
{
	// Token: 0x06003F1E RID: 16158 RVA: 0x000E1158 File Offset: 0x000DF358
	public HardpointMaster()
	{
	}

	// Token: 0x06003F1F RID: 16159 RVA: 0x000E1160 File Offset: 0x000DF360
	public void Awake()
	{
		this._points = new global::System.Collections.Generic.List<global::Hardpoint>();
	}

	// Token: 0x06003F20 RID: 16160 RVA: 0x000E1170 File Offset: 0x000DF370
	public void AddHardpoint(global::Hardpoint point)
	{
		this._points.Add(point);
	}

	// Token: 0x06003F21 RID: 16161 RVA: 0x000E1180 File Offset: 0x000DF380
	public global::Hardpoint GetHardpointNear(global::UnityEngine.Vector3 worldPos, float maxRange, global::Hardpoint.hardpoint_type type)
	{
		foreach (global::Hardpoint hardpoint in this._points)
		{
			if (hardpoint.type == type)
			{
				if (hardpoint.IsFree())
				{
					if (global::UnityEngine.Vector3.Distance(hardpoint.transform.position, worldPos) <= maxRange)
					{
						return hardpoint;
					}
				}
			}
		}
		return null;
	}

	// Token: 0x06003F22 RID: 16162 RVA: 0x000E1224 File Offset: 0x000DF424
	public global::Hardpoint GetHardpointNear(global::UnityEngine.Vector3 worldPos, global::Hardpoint.hardpoint_type type)
	{
		return this.GetHardpointNear(worldPos, 3f, type);
	}

	// Token: 0x06003F23 RID: 16163 RVA: 0x000E1234 File Offset: 0x000DF434
	public global::TransCarrier GetTransCarrier()
	{
		return this.idMain.GetLocal<global::TransCarrier>();
	}

	// Token: 0x04002081 RID: 8321
	public global::System.Collections.Generic.List<global::Hardpoint> _points;
}
