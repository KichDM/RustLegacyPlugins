using System;

// Token: 0x020006D2 RID: 1746
public abstract class AmmoItem<T> : global::InventoryItem<T> where T : global::AmmoItemDataBlock
{
	// Token: 0x06003BCE RID: 15310 RVA: 0x000D4A40 File Offset: 0x000D2C40
	protected AmmoItem(T db) : base(db)
	{
	}
}
