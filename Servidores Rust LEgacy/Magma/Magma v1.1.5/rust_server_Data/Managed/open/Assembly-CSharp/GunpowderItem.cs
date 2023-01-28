using System;

// Token: 0x020006EA RID: 1770
public abstract class GunpowderItem<T> : global::InventoryItem<T> where T : global::GunpowderDataBlock
{
	// Token: 0x06003C4F RID: 15439 RVA: 0x000D57A4 File Offset: 0x000D39A4
	protected GunpowderItem(T db) : base(db)
	{
	}
}
