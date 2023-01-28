using System;
using UnityEngine;

// Token: 0x020005F4 RID: 1524
public class DummyHelper : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600311E RID: 12574 RVA: 0x000BB97C File Offset: 0x000B9B7C
	public DummyHelper()
	{
	}

	// Token: 0x0600311F RID: 12575 RVA: 0x000BB984 File Offset: 0x000B9B84
	public void OnDrawGizmos()
	{
		global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(1f, 1f, 0f, 0.5f);
		global::UnityEngine.Gizmos.DrawCube(base.transform.position, global::UnityEngine.Vector3.one * 0.5f);
	}

	// Token: 0x06003120 RID: 12576 RVA: 0x000BB9D0 File Offset: 0x000B9BD0
	public void OnDrawGizmosSelected()
	{
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.yellow;
		global::UnityEngine.Gizmos.DrawCube(base.transform.position, global::UnityEngine.Vector3.one * 0.5f);
	}
}
