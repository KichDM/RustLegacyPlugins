using System;

// Token: 0x02000721 RID: 1825
public class SightModRep : global::WeaponModRep
{
	// Token: 0x06003DE1 RID: 15841 RVA: 0x000D903C File Offset: 0x000D723C
	protected SightModRep(global::ItemModRepresentation.Caps caps, bool defaultOn) : base(caps, defaultOn)
	{
	}

	// Token: 0x06003DE2 RID: 15842 RVA: 0x000D9048 File Offset: 0x000D7248
	public SightModRep() : this((global::ItemModRepresentation.Caps)0, true)
	{
	}

	// Token: 0x06003DE3 RID: 15843 RVA: 0x000D9054 File Offset: 0x000D7254
	protected SightModRep(global::ItemModRepresentation.Caps caps) : this(caps, true)
	{
	}

	// Token: 0x06003DE4 RID: 15844 RVA: 0x000D9060 File Offset: 0x000D7260
	protected override void EnableMod(global::ItemModRepresentation.Reason reason)
	{
	}

	// Token: 0x06003DE5 RID: 15845 RVA: 0x000D9064 File Offset: 0x000D7264
	protected override void DisableMod(global::ItemModRepresentation.Reason reason)
	{
	}
}
