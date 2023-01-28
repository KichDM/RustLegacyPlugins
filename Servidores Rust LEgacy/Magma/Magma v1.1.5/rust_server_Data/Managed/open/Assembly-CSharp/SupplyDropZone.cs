using System;
using System.Collections.Generic;
using Facepunch;
using UnityEngine;

// Token: 0x020000A5 RID: 165
public class SupplyDropZone : global::Facepunch.MonoBehaviour
{
	// Token: 0x06000330 RID: 816 RVA: 0x0000F65C File Offset: 0x0000D85C
	public SupplyDropZone()
	{
	}

	// Token: 0x06000331 RID: 817 RVA: 0x0000F670 File Offset: 0x0000D870
	public void Awake()
	{
		if (global::SupplyDropZone._dropZones == null)
		{
			global::SupplyDropZone._dropZones = new global::System.Collections.Generic.List<global::SupplyDropZone>();
		}
		global::SupplyDropZone._dropZones.Add(this);
	}

	// Token: 0x06000332 RID: 818 RVA: 0x0000F694 File Offset: 0x0000D894
	public void OnDrawGizmos()
	{
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.white;
		global::UnityEngine.Gizmos.DrawWireSphere(base.transform.position, this.radius);
	}

	// Token: 0x06000333 RID: 819 RVA: 0x0000F6C4 File Offset: 0x0000D8C4
	public void OnDrawGizmosSelected()
	{
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.yellow;
		global::UnityEngine.Gizmos.DrawWireSphere(base.transform.position, this.radius);
	}

	// Token: 0x06000334 RID: 820 RVA: 0x0000F6F4 File Offset: 0x0000D8F4
	public global::UnityEngine.Vector3 GetSupplyTargetPosition()
	{
		global::UnityEngine.Vector2 vector = global::UnityEngine.Random.insideUnitCircle * this.radius;
		return base.transform.position + new global::UnityEngine.Vector3(vector.x, 0f, vector.y);
	}

	// Token: 0x06000335 RID: 821 RVA: 0x0000F73C File Offset: 0x0000D93C
	public static global::UnityEngine.Vector3 GetRandomTargetPos()
	{
		if (global::SupplyDropZone._dropZones.Count == 0)
		{
			global::UnityEngine.Debug.LogError("no drop zones...");
			return global::UnityEngine.Vector3.zero;
		}
		global::SupplyDropZone supplyDropZone = global::SupplyDropZone._dropZones[global::UnityEngine.Random.RandomRange(0, global::SupplyDropZone._dropZones.Count)];
		return supplyDropZone.GetSupplyTargetPosition();
	}

	// Token: 0x06000336 RID: 822 RVA: 0x0000F78C File Offset: 0x0000D98C
	public static global::UnityEngine.Vector3 RandomDirectionXZ()
	{
		float num = global::UnityEngine.Random.Range(-3.1415927f, 3.1415927f);
		global::UnityEngine.Vector3 result;
		result.x = global::UnityEngine.Mathf.Cos(num);
		result.z = global::UnityEngine.Mathf.Sin(num);
		result.y = 0f;
		return result;
	}

	// Token: 0x06000337 RID: 823 RVA: 0x0000F7D0 File Offset: 0x0000D9D0
	public static void CallAirDropAt(global::UnityEngine.Vector3 targetPos)
	{
		global::UnityEngine.GameObject gameObject = global::NetCull.LoadPrefab("C130");
		global::SupplyDropPlane component = gameObject.GetComponent<global::SupplyDropPlane>();
		float num = 20f * component.maxSpeed;
		global::UnityEngine.Vector3 vector = targetPos + global::SupplyDropZone.RandomDirectionXZ() * num;
		global::UnityEngine.Vector3 vector2 = targetPos + new global::UnityEngine.Vector3(0f, 300f, 0f);
		vector += new global::UnityEngine.Vector3(0f, 400f, 0f);
		global::UnityEngine.Quaternion rotation = global::UnityEngine.Quaternion.LookRotation((vector2 - vector).normalized);
		int group = 0;
		global::UnityEngine.GameObject gameObject2 = global::NetCull.InstantiateClassic("C130", vector, rotation, group);
		global::SupplyDropPlane component2 = gameObject2.GetComponent<global::SupplyDropPlane>();
		component2.SetDropTarget(vector2);
	}

	// Token: 0x06000338 RID: 824 RVA: 0x0000F888 File Offset: 0x0000DA88
	public static void CallAirDrop()
	{
		global::UnityEngine.Vector3 randomTargetPos = global::SupplyDropZone.GetRandomTargetPos();
		global::SupplyDropZone.CallAirDropAt(randomTargetPos);
	}

	// Token: 0x040002F3 RID: 755
	public static global::System.Collections.Generic.List<global::SupplyDropZone> _dropZones;

	// Token: 0x040002F4 RID: 756
	public float radius = 100f;
}
