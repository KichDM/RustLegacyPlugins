using System;
using UnityEngine;

// Token: 0x02000501 RID: 1281
public class RockDecorAreaHelper : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C07 RID: 11271 RVA: 0x000A5B74 File Offset: 0x000A3D74
	public RockDecorAreaHelper()
	{
	}

	// Token: 0x06002C08 RID: 11272 RVA: 0x000A5B7C File Offset: 0x000A3D7C
	private void OnDrawGizmos()
	{
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.grey;
		this.DrawBounds();
	}

	// Token: 0x06002C09 RID: 11273 RVA: 0x000A5B90 File Offset: 0x000A3D90
	private void OnDrawGizmosSelected()
	{
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.white;
		this.DrawBounds();
	}

	// Token: 0x06002C0A RID: 11274 RVA: 0x000A5BA4 File Offset: 0x000A3DA4
	private void DrawBounds()
	{
		global::UnityEngine.Color color = global::UnityEngine.Gizmos.color;
		color.a = 0.25f;
		global::UnityEngine.Gizmos.color = color;
		global::UnityEngine.Gizmos.DrawCube(base.transform.position, base.transform.localScale);
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.white;
		global::UnityEngine.Gizmos.DrawWireCube(base.transform.position, base.transform.localScale);
	}
}
