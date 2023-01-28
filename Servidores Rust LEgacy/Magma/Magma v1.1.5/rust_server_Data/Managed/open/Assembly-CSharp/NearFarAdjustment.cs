using System;
using UnityEngine;

// Token: 0x02000746 RID: 1862
public class NearFarAdjustment : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003EB2 RID: 16050 RVA: 0x000DF8A0 File Offset: 0x000DDAA0
	public NearFarAdjustment()
	{
	}

	// Token: 0x06003EB3 RID: 16051 RVA: 0x000DF8A8 File Offset: 0x000DDAA8
	private void Update()
	{
		bool flag = global::UnityEngine.Physics.Raycast(new global::UnityEngine.Ray(base.transform.position, base.transform.forward), 1.2f);
		if (flag)
		{
			base.camera.nearClipPlane = 0.21f;
		}
		else
		{
			base.camera.nearClipPlane = 0.8f;
		}
	}
}
