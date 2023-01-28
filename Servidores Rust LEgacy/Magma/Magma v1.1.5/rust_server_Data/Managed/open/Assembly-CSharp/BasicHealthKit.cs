using System;

// Token: 0x020006D8 RID: 1752
public abstract class BasicHealthKit<T> : global::InventoryItem<T> where T : global::BasicHealthKitDataBlock
{
	// Token: 0x06003BE8 RID: 15336 RVA: 0x000D4D60 File Offset: 0x000D2F60
	protected BasicHealthKit(T db) : base(db)
	{
	}

	// Token: 0x06003BE9 RID: 15337 RVA: 0x000D4D6C File Offset: 0x000D2F6C
	public override void OnBeltUse()
	{
		T datablock = this.datablock;
		datablock.UseItem(this.iface as global::IBasicHealthKit);
	}
}
