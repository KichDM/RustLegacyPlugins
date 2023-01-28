using System;
using UnityEngine;

// Token: 0x0200021F RID: 543
public abstract class BaseTraitMap : global::UnityEngine.ScriptableObject
{
	// Token: 0x06000EA6 RID: 3750 RVA: 0x00037FA4 File Offset: 0x000361A4
	internal BaseTraitMap()
	{
	}

	// Token: 0x06000EA7 RID: 3751
	internal abstract void BindToRegistry();

	// Token: 0x06000EA8 RID: 3752 RVA: 0x00037FAC File Offset: 0x000361AC
	internal void BIND_REGISTRATION()
	{
		if (!this.bound)
		{
			this.BindToRegistry();
			this.bound = true;
		}
	}

	// Token: 0x04000953 RID: 2387
	[global::System.NonSerialized]
	private bool bound;
}
