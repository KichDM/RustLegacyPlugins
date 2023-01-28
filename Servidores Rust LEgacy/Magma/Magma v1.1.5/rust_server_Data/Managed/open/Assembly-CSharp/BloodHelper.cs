using System;
using Facepunch;
using UnityEngine;

// Token: 0x020005EE RID: 1518
public class BloodHelper : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600310F RID: 12559 RVA: 0x000BB1DC File Offset: 0x000B93DC
	public BloodHelper()
	{
	}

	// Token: 0x06003110 RID: 12560 RVA: 0x000BB1E4 File Offset: 0x000B93E4
	// Note: this type is marked as 'beforefieldinit'.
	static BloodHelper()
	{
	}

	// Token: 0x06003111 RID: 12561 RVA: 0x000BB1E8 File Offset: 0x000B93E8
	private static void BleedDir(global::UnityEngine.Vector3 startPos, global::UnityEngine.Vector3 dir, int hitMask)
	{
		global::UnityEngine.Ray ray;
		ray..ctor(startPos + dir * 0.25f, dir);
		global::UnityEngine.RaycastHit raycastHit;
		if (global::UnityEngine.Physics.Raycast(ray, ref raycastHit, 4f, hitMask))
		{
			if (global::BloodHelper.bloodDecalPrefab == null && !global::Facepunch.Bundling.Load<global::UnityEngine.GameObject>("content/effect/BloodDecal", out global::BloodHelper.bloodDecalPrefab))
			{
				return;
			}
			global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.LookRotation(raycastHit.normal);
			global::UnityEngine.GameObject gameObject = global::UnityEngine.Object.Instantiate(global::BloodHelper.bloodDecalPrefab, raycastHit.point + raycastHit.normal * global::UnityEngine.Random.Range(0.025f, 0.035f), quaternion * global::UnityEngine.Quaternion.Euler(0f, 0f, (float)global::UnityEngine.Random.Range(0, 0x168))) as global::UnityEngine.GameObject;
			global::UnityEngine.Object.Destroy(gameObject, 12f);
		}
	}

	// Token: 0x04001B2F RID: 6959
	private static global::UnityEngine.GameObject bloodDecalPrefab;
}
