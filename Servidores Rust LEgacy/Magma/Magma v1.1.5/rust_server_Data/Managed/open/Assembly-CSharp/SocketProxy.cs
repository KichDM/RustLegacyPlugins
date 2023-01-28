using System;
using UnityEngine;

// Token: 0x0200045E RID: 1118
[global::UnityEngine.AddComponentMenu("")]
public sealed class SocketProxy : global::Socket.Proxy
{
	// Token: 0x060026AD RID: 9901 RVA: 0x000948B8 File Offset: 0x00092AB8
	public SocketProxy()
	{
	}

	// Token: 0x060026AE RID: 9902 RVA: 0x000948C0 File Offset: 0x00092AC0
	protected override void UninitializeProxy()
	{
		base.transform.DetachChildren();
	}
}
