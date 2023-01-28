using System;

// Token: 0x020005BE RID: 1470
public class StructureComponentTakeDamage : global::ProtectionTakeDamage
{
	// Token: 0x06003061 RID: 12385 RVA: 0x000B8588 File Offset: 0x000B6788
	public StructureComponentTakeDamage()
	{
	}

	// Token: 0x06003062 RID: 12386 RVA: 0x000B8590 File Offset: 0x000B6790
	protected override global::LifeStatus Hurt(ref global::DamageEvent damage)
	{
		return base.Hurt(ref damage);
	}
}
