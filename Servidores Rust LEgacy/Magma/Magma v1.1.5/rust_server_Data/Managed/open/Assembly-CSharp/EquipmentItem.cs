using System;

// Token: 0x020006E8 RID: 1768
public abstract class EquipmentItem<T> : global::InventoryItem<T> where T : global::EquipmentDataBlock
{
	// Token: 0x06003C4C RID: 15436 RVA: 0x000D5740 File Offset: 0x000D3940
	protected EquipmentItem(T db) : base(db)
	{
	}

	// Token: 0x06003C4D RID: 15437 RVA: 0x000D574C File Offset: 0x000D394C
	public void OnEquipped()
	{
		T datablock = this.datablock;
		datablock.OnEquipped(this.iface as global::IEquipmentItem);
	}

	// Token: 0x06003C4E RID: 15438 RVA: 0x000D5778 File Offset: 0x000D3978
	public void OnUnEquipped()
	{
		T datablock = this.datablock;
		datablock.OnUnEquipped(this.iface as global::IEquipmentItem);
	}
}
