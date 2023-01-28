using System;
using UnityEngine;

// Token: 0x02000536 RID: 1334
[global::UnityEngine.RequireComponent(typeof(global::UICamera))]
public class RPOSFilter : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002D4D RID: 11597 RVA: 0x000AC07C File Offset: 0x000AA27C
	public RPOSFilter()
	{
	}

	// Token: 0x06002D4E RID: 11598 RVA: 0x000AC084 File Offset: 0x000AA284
	private void Awake()
	{
		this.uicamera = base.GetComponent<global::UICamera>();
	}

	// Token: 0x0400174E RID: 5966
	private global::UICamera uicamera;
}
