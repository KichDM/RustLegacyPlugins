using System;

// Token: 0x02000683 RID: 1667
public class WeaponImpact
{
	// Token: 0x0600364A RID: 13898 RVA: 0x000CBC00 File Offset: 0x000C9E00
	public WeaponImpact(global::WeaponDataBlock dataBlock, global::IWeaponItem item, global::ItemRepresentation itemRep)
	{
		this.dataBlock = dataBlock;
		this.item = item;
		this.itemRep = itemRep;
	}

	// Token: 0x04001D77 RID: 7543
	public readonly global::WeaponDataBlock dataBlock;

	// Token: 0x04001D78 RID: 7544
	public readonly global::ItemRepresentation itemRep;

	// Token: 0x04001D79 RID: 7545
	public readonly global::IWeaponItem item;
}
