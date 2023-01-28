using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200005F RID: 95
public class NoPlacementZone : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060002AD RID: 685 RVA: 0x0000D8F4 File Offset: 0x0000BAF4
	public NoPlacementZone()
	{
	}

	// Token: 0x060002AE RID: 686 RVA: 0x0000D8FC File Offset: 0x0000BAFC
	// Note: this type is marked as 'beforefieldinit'.
	static NoPlacementZone()
	{
	}

	// Token: 0x060002AF RID: 687 RVA: 0x0000D900 File Offset: 0x0000BB00
	public static void AddZone(global::NoPlacementZone zone)
	{
		if (global::NoPlacementZone._zones == null)
		{
			global::NoPlacementZone._zones = new global::System.Collections.Generic.List<global::NoPlacementZone>();
		}
		if (global::NoPlacementZone._zones.Contains(zone))
		{
			return;
		}
		global::NoPlacementZone._zones.Add(zone);
	}

	// Token: 0x060002B0 RID: 688 RVA: 0x0000D940 File Offset: 0x0000BB40
	public static void RemoveZone(global::NoPlacementZone zone)
	{
		if (global::NoPlacementZone._zones.Contains(zone))
		{
			global::NoPlacementZone._zones.Remove(zone);
		}
	}

	// Token: 0x060002B1 RID: 689 RVA: 0x0000D960 File Offset: 0x0000BB60
	public void Awake()
	{
		global::NoPlacementZone.AddZone(this);
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x0000D968 File Offset: 0x0000BB68
	public void OnDestroy()
	{
		global::NoPlacementZone.RemoveZone(this);
	}

	// Token: 0x060002B3 RID: 691 RVA: 0x0000D970 File Offset: 0x0000BB70
	public void OnDrawGizmos()
	{
		global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(1f, 0.5f, 0.3f, 0.1f);
		global::UnityEngine.Gizmos.DrawSphere(base.transform.position, this.GetRadius());
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.green;
		global::UnityEngine.Gizmos.DrawCube(base.transform.position, global::UnityEngine.Vector3.one * 0.5f);
	}

	// Token: 0x060002B4 RID: 692 RVA: 0x0000D9DC File Offset: 0x0000BBDC
	public void OnDrawGizmosSelected()
	{
		global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(1f, 0.5f, 0.3f, 0.8f);
		global::UnityEngine.Gizmos.DrawWireSphere(base.transform.position, this.GetRadius());
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.green;
		global::UnityEngine.Gizmos.DrawCube(base.transform.position, global::UnityEngine.Vector3.one * 0.5f);
	}

	// Token: 0x060002B5 RID: 693 RVA: 0x0000DA48 File Offset: 0x0000BC48
	public float GetRadius()
	{
		return base.transform.localScale.x;
	}

	// Token: 0x060002B6 RID: 694 RVA: 0x0000DA68 File Offset: 0x0000BC68
	public static bool ValidPos(global::UnityEngine.Vector3 pos)
	{
		foreach (global::NoPlacementZone noPlacementZone in global::NoPlacementZone._zones)
		{
			float num = global::UnityEngine.Vector3.Distance(pos, noPlacementZone.transform.position);
			if (num <= noPlacementZone.GetRadius())
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x040001DE RID: 478
	public static global::System.Collections.Generic.List<global::NoPlacementZone> _zones;
}
