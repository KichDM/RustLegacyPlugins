using System;
using UnityEngine;

// Token: 0x020005C7 RID: 1479
public class BounceArrow : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003077 RID: 12407 RVA: 0x000B87F4 File Offset: 0x000B69F4
	public BounceArrow()
	{
	}

	// Token: 0x06003078 RID: 12408 RVA: 0x000B87FC File Offset: 0x000B69FC
	private void Update()
	{
		float num = 0f + global::UnityEngine.Mathf.Abs(global::UnityEngine.Mathf.Sin(global::UnityEngine.Time.time * 5f)) * 0.15f;
		base.transform.localPosition = new global::UnityEngine.Vector3(0f, num, 0f);
	}
}
