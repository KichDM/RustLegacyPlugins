using System;

// Token: 0x02000722 RID: 1826
public class SilencerModRep : global::WeaponModRep
{
	// Token: 0x06003DE6 RID: 15846 RVA: 0x000D9068 File Offset: 0x000D7268
	protected SilencerModRep(global::ItemModRepresentation.Caps caps, bool defaultOn) : base(caps, defaultOn)
	{
	}

	// Token: 0x06003DE7 RID: 15847 RVA: 0x000D9074 File Offset: 0x000D7274
	public SilencerModRep() : this((global::ItemModRepresentation.Caps)0, true)
	{
	}

	// Token: 0x06003DE8 RID: 15848 RVA: 0x000D9080 File Offset: 0x000D7280
	protected SilencerModRep(global::ItemModRepresentation.Caps caps) : this(caps, true)
	{
	}

	// Token: 0x06003DE9 RID: 15849 RVA: 0x000D908C File Offset: 0x000D728C
	protected override void EnableMod(global::ItemModRepresentation.Reason reason)
	{
	}

	// Token: 0x06003DEA RID: 15850 RVA: 0x000D9090 File Offset: 0x000D7290
	protected override void DisableMod(global::ItemModRepresentation.Reason reason)
	{
	}
}
