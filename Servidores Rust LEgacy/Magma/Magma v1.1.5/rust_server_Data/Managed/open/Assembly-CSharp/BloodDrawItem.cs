using System;

// Token: 0x020006DC RID: 1756
public abstract class BloodDrawItem<T> : global::InventoryItem<T> where T : global::BloodDrawDatablock
{
	// Token: 0x06003BF9 RID: 15353 RVA: 0x000D4ED0 File Offset: 0x000D30D0
	protected BloodDrawItem(T db) : base(db)
	{
	}

	// Token: 0x06003BFA RID: 15354 RVA: 0x000D4EDC File Offset: 0x000D30DC
	public override void OnBeltUse()
	{
		T datablock = this.datablock;
		datablock.UseItem(this.iface as global::IBloodDrawItem);
	}
}
