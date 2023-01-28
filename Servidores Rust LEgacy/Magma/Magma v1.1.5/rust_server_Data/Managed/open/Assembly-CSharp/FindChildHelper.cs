using System;
using UnityEngine;

// Token: 0x020001F1 RID: 497
public static class FindChildHelper
{
	// Token: 0x06000DB8 RID: 3512 RVA: 0x000358F8 File Offset: 0x00033AF8
	private static global::UnityEngine.Transform _GetFound()
	{
		global::UnityEngine.Transform result = global::FindChildHelper.found;
		global::FindChildHelper.found = null;
		return result;
	}

	// Token: 0x06000DB9 RID: 3513 RVA: 0x00035914 File Offset: 0x00033B14
	private static bool __FindChildByNameRecurse(string name, global::UnityEngine.Transform parent)
	{
		if (parent.childCount == 0)
		{
			return false;
		}
		global::FindChildHelper.found = parent.Find(name);
		if (global::FindChildHelper.found)
		{
			return true;
		}
		int childCount = parent.childCount;
		for (int i = 0; i < childCount; i++)
		{
			global::UnityEngine.Transform child = parent.GetChild(i);
			if (child.childCount > 0 && global::FindChildHelper.__FindChildByNameRecurse(name, child))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000DBA RID: 3514 RVA: 0x00035988 File Offset: 0x00033B88
	private static bool _FindChildByNameRecurse(string name, global::UnityEngine.Transform parent)
	{
		return global::FindChildHelper.__FindChildByNameRecurse(name, parent);
	}

	// Token: 0x06000DBB RID: 3515 RVA: 0x000359A0 File Offset: 0x00033BA0
	private static global::UnityEngine.Transform NoChildNamed(string name, global::UnityEngine.Object parent)
	{
		return null;
	}

	// Token: 0x06000DBC RID: 3516 RVA: 0x000359A4 File Offset: 0x00033BA4
	[global::System.Obsolete("If this is being called in Start, Awake, or OnEnabled consider using the @PrefetchChildComponent on the variable.", false)]
	public static global::UnityEngine.Transform FindChildByName(string name, global::UnityEngine.Transform parent)
	{
		if (parent.name == name)
		{
			return parent;
		}
		if (global::FindChildHelper._FindChildByNameRecurse(name, parent))
		{
			return global::FindChildHelper._GetFound();
		}
		return global::FindChildHelper.NoChildNamed(name, parent);
	}

	// Token: 0x06000DBD RID: 3517 RVA: 0x000359E0 File Offset: 0x00033BE0
	[global::System.Obsolete("If this is being called in Start, Awake, or OnEnabled consider using the @PrefetchChildComponent on the variable.", false)]
	public static global::UnityEngine.Transform FindChildByName(string name, global::UnityEngine.GameObject parent)
	{
		if (parent.name == name)
		{
			return parent.transform;
		}
		if (global::FindChildHelper._FindChildByNameRecurse(name, parent.transform))
		{
			return global::FindChildHelper._GetFound();
		}
		return global::FindChildHelper.NoChildNamed(name, parent);
	}

	// Token: 0x06000DBE RID: 3518 RVA: 0x00035A24 File Offset: 0x00033C24
	[global::System.Obsolete("If this is being called in Start, Awake, or OnEnabled consider using the @PrefetchChildComponent on the variable.", false)]
	public static global::UnityEngine.Transform FindChildByName(string name, global::UnityEngine.Component parent)
	{
		if (parent.name == name)
		{
			return parent.transform;
		}
		if (global::FindChildHelper._FindChildByNameRecurse(name, parent.transform))
		{
			return global::FindChildHelper._GetFound();
		}
		return global::FindChildHelper.NoChildNamed(name, parent);
	}

	// Token: 0x06000DBF RID: 3519 RVA: 0x00035A68 File Offset: 0x00033C68
	public static global::UnityEngine.Transform GetChildAtIndex(global::UnityEngine.Transform transform, int i)
	{
		if (0 > i)
		{
			return null;
		}
		if (transform.childCount > i)
		{
			return transform.GetChild(i);
		}
		return null;
	}

	// Token: 0x06000DC0 RID: 3520 RVA: 0x00035A88 File Offset: 0x00033C88
	public static global::UnityEngine.Transform RandomChild(global::UnityEngine.Transform transform)
	{
		int childCount = transform.childCount;
		int num = childCount;
		if (num == 0)
		{
			return null;
		}
		if (num != 1)
		{
			return global::FindChildHelper.GetChildAtIndex(transform, global::UnityEngine.Random.Range(0, childCount));
		}
		return transform.GetChild(0);
	}

	// Token: 0x040008AF RID: 2223
	private static global::UnityEngine.Transform found;
}
