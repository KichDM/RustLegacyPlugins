using System;
using UnityEngine;

// Token: 0x02000423 RID: 1059
internal class NetPostUpdate : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060024D2 RID: 9426 RVA: 0x0008C5A4 File Offset: 0x0008A7A4
	public NetPostUpdate()
	{
	}

	// Token: 0x060024D3 RID: 9427 RVA: 0x0008C5AC File Offset: 0x0008A7AC
	private void Awake()
	{
		global::NetCull.Callbacks.BindUpdater(this);
	}

	// Token: 0x060024D4 RID: 9428 RVA: 0x0008C5B4 File Offset: 0x0008A7B4
	private void OnDestroy()
	{
		global::NetCull.Callbacks.ResignUpdater(this);
	}

	// Token: 0x060024D5 RID: 9429 RVA: 0x0008C5BC File Offset: 0x0008A7BC
	protected void LateUpdate()
	{
		if (global::UnityEngine.Application.isPlaying)
		{
			global::NetCull.Callbacks.FirePostUpdate(this);
		}
	}
}
