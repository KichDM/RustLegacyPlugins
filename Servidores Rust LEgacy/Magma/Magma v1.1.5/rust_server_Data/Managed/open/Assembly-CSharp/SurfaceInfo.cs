using System;
using UnityEngine;

// Token: 0x020005CF RID: 1487
public class SurfaceInfo : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003097 RID: 12439 RVA: 0x000B8E70 File Offset: 0x000B7070
	public SurfaceInfo()
	{
	}

	// Token: 0x06003098 RID: 12440 RVA: 0x000B8E78 File Offset: 0x000B7078
	public static global::SurfaceInfoObject GetSurfaceInfoFor(global::UnityEngine.Collider collider, global::UnityEngine.Vector3 worldPos)
	{
		return global::SurfaceInfo.GetSurfaceInfoFor(collider.gameObject, worldPos);
	}

	// Token: 0x06003099 RID: 12441 RVA: 0x000B8E88 File Offset: 0x000B7088
	public static global::SurfaceInfoObject GetSurfaceInfoFor(global::UnityEngine.GameObject obj, global::UnityEngine.Vector3 worldPos)
	{
		global::SurfaceInfo component = obj.GetComponent<global::SurfaceInfo>();
		if (component)
		{
			return component.SurfaceObj(worldPos);
		}
		global::IDBase component2 = obj.GetComponent<global::IDBase>();
		if (component2)
		{
			global::SurfaceInfo component3 = component2.idMain.GetComponent<global::SurfaceInfo>();
			if (component3)
			{
				return component3.SurfaceObj(worldPos);
			}
		}
		return global::SurfaceInfoObject.GetDefault();
	}

	// Token: 0x0600309A RID: 12442 RVA: 0x000B8EE8 File Offset: 0x000B70E8
	public static void DoImpact(global::UnityEngine.GameObject go, global::SurfaceInfoObject.ImpactType type, global::UnityEngine.Vector3 worldPos, global::UnityEngine.Quaternion rotation)
	{
		global::SurfaceInfoObject surfaceInfoFor = global::SurfaceInfo.GetSurfaceInfoFor(go, worldPos);
		global::UnityEngine.Object @object = global::UnityEngine.Object.Instantiate(surfaceInfoFor.GetImpactEffect(type), worldPos, rotation);
		global::UnityEngine.Object.Destroy(@object, 1f);
	}

	// Token: 0x0600309B RID: 12443 RVA: 0x000B8F18 File Offset: 0x000B7118
	public virtual global::SurfaceInfoObject SurfaceObj()
	{
		return this.surface;
	}

	// Token: 0x0600309C RID: 12444 RVA: 0x000B8F20 File Offset: 0x000B7120
	public virtual global::SurfaceInfoObject SurfaceObj(global::UnityEngine.Vector3 worldPos)
	{
		return this.surface;
	}

	// Token: 0x04001A43 RID: 6723
	public global::SurfaceInfoObject surface;
}
