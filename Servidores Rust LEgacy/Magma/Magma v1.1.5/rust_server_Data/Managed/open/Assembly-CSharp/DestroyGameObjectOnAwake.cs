using System;
using UnityEngine;

// Token: 0x020005C0 RID: 1472
public class DestroyGameObjectOnAwake : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003066 RID: 12390 RVA: 0x000B85A8 File Offset: 0x000B67A8
	public DestroyGameObjectOnAwake()
	{
	}

	// Token: 0x06003067 RID: 12391 RVA: 0x000B85B0 File Offset: 0x000B67B0
	private void Awake()
	{
		global::UnityEngine.Object.Destroy(base.gameObject);
	}
}
