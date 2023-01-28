using System;
using UnityEngine;

// Token: 0x020004F8 RID: 1272
public class IgnoreColliders : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002BDD RID: 11229 RVA: 0x000A4794 File Offset: 0x000A2994
	public IgnoreColliders()
	{
	}

	// Token: 0x06002BDE RID: 11230 RVA: 0x000A479C File Offset: 0x000A299C
	private void Awake()
	{
		if (this.a != null && this.b != null)
		{
			int num = global::UnityEngine.Mathf.Min(this.a.Length, this.b.Length);
			for (int i = 0; i < num; i++)
			{
				if (this.a[i] && this.b[i] && this.b[i] != this.a[i])
				{
					global::UnityEngine.Physics.IgnoreCollision(this.a[i], this.b[i]);
				}
			}
			this.a = null;
			this.b = null;
		}
	}

	// Token: 0x0400162E RID: 5678
	public global::UnityEngine.Collider[] a;

	// Token: 0x0400162F RID: 5679
	public global::UnityEngine.Collider[] b;
}
