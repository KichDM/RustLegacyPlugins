using System;

// Token: 0x020006FC RID: 1788
public abstract class ItemModItem<T> : global::InventoryItem<T> where T : global::ItemModDataBlock
{
	// Token: 0x06003CF7 RID: 15607 RVA: 0x000D693C File Offset: 0x000D4B3C
	protected ItemModItem(T db) : base(db)
	{
	}

	// Token: 0x06003CF8 RID: 15608 RVA: 0x000D6948 File Offset: 0x000D4B48
	public override global::InventoryItem.MergeResult TryStack(global::IInventoryItem otherItem)
	{
		global::InventoryItem.MergeResult mergeResult = this.TryCombine(otherItem);
		if (mergeResult == global::InventoryItem.MergeResult.Failed)
		{
			return base.TryStack(otherItem);
		}
		return mergeResult;
	}

	// Token: 0x06003CF9 RID: 15609 RVA: 0x000D696C File Offset: 0x000D4B6C
	public override global::InventoryItem.MergeResult TryCombine(global::IInventoryItem otherItem)
	{
		global::IHeldItem heldItem = otherItem as global::IHeldItem;
		if (heldItem == null)
		{
			return global::InventoryItem.MergeResult.Failed;
		}
		if (heldItem.freeModSlots <= 0)
		{
			return global::InventoryItem.MergeResult.Failed;
		}
		if (!(otherItem.datablock is global::BulletWeaponDataBlock))
		{
			return base.TryCombine(otherItem);
		}
		global::IHeldItem heldItem2 = otherItem as global::IHeldItem;
		if (heldItem2.FindMod(this.datablock) != -1)
		{
			return global::InventoryItem.MergeResult.Failed;
		}
		this.FireClientSideItemEvent(global::InventoryItem.ItemEvent.Combined);
		heldItem2.AddMod(this.datablock);
		int num = 1;
		if (base.Consume(ref num))
		{
			base.inventory.RemoveItem(base.slot);
		}
		if (heldItem2.active)
		{
			heldItem2.inventory.DeactivateItem();
			heldItem2.inventory.Invalidate();
			heldItem2.OnBeltUse();
		}
		return global::InventoryItem.MergeResult.Combined;
	}
}
