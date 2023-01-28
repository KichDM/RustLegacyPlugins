using System;
using UnityEngine;

// Token: 0x0200050B RID: 1291
public class GUIHide : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C3F RID: 11327 RVA: 0x000A6B7C File Offset: 0x000A4D7C
	public GUIHide()
	{
	}

	// Token: 0x06002C40 RID: 11328 RVA: 0x000A6B84 File Offset: 0x000A4D84
	public static void SetVisible(bool bShow)
	{
		global::UnityEngine.Object[] array = global::Resources.FindObjectsOfTypeAll(typeof(global::GUIHide));
		foreach (global::GUIHide guihide in array)
		{
			if (guihide.gameObject == null)
			{
				return;
			}
			guihide.gameObject.SetActive(bShow);
		}
	}
}
