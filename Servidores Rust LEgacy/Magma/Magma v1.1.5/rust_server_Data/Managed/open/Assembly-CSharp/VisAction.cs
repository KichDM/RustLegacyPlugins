using System;
using UnityEngine;

// Token: 0x020004B3 RID: 1203
public abstract class VisAction : global::UnityEngine.ScriptableObject
{
	// Token: 0x060029D8 RID: 10712 RVA: 0x0009DB88 File Offset: 0x0009BD88
	protected VisAction()
	{
	}

	// Token: 0x060029D9 RID: 10713
	public abstract void Accomplish(global::IDMain self, global::IDMain instigator);

	// Token: 0x060029DA RID: 10714
	public abstract void UnAcomplish(global::IDMain self, global::IDMain instigator);
}
