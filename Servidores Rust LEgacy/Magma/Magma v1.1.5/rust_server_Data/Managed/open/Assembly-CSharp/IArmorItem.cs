using System;

// Token: 0x020006D3 RID: 1747
public interface IArmorItem : global::IEquipmentItem, global::IInventoryItem
{
	// Token: 0x06003BCF RID: 15311
	void ArmorUpdate(global::Inventory belongInv, int belongSlot);
}
