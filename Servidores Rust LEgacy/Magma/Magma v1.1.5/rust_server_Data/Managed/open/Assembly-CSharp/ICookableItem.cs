using System;

// Token: 0x020006EF RID: 1775
public interface ICookableItem : global::IInventoryItem
{
	// Token: 0x06003C86 RID: 15494
	bool GetCookableInfo(out int consumeCount, out global::ItemDataBlock cookedVersion, out int cookedCount, out int cookTempMin, out int burnTemp);
}
