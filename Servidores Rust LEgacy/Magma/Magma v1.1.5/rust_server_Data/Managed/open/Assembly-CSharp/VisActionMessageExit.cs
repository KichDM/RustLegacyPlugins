using System;

// Token: 0x020004B6 RID: 1206
public class VisActionMessageExit : global::VisActionMessageEnter
{
	// Token: 0x060029E0 RID: 10720 RVA: 0x0009DE4C File Offset: 0x0009C04C
	public VisActionMessageExit()
	{
	}

	// Token: 0x060029E1 RID: 10721 RVA: 0x0009DE54 File Offset: 0x0009C054
	public override void Accomplish(global::IDMain self, global::IDMain instigator)
	{
	}

	// Token: 0x060029E2 RID: 10722 RVA: 0x0009DE58 File Offset: 0x0009C058
	public override void UnAcomplish(global::IDMain self, global::IDMain instigator)
	{
		base.Accomplish(self, instigator);
	}
}
