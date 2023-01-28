using System;
using Rust;

// Token: 0x02000704 RID: 1796
public abstract class ResearchToolItem<T> : global::ToolItem<T> where T : global::ToolDataBlock
{
	// Token: 0x06003D10 RID: 15632 RVA: 0x000D6DC0 File Offset: 0x000D4FC0
	protected ResearchToolItem(T db) : base(db)
	{
	}

	// Token: 0x06003D11 RID: 15633 RVA: 0x000D6DCC File Offset: 0x000D4FCC
	public override global::InventoryItem.MergeResult TryCombine(global::IInventoryItem otherItem)
	{
		global::PlayerInventory playerInventory = base.inventory as global::PlayerInventory;
		if (!playerInventory || otherItem.inventory != playerInventory)
		{
			return global::InventoryItem.MergeResult.Failed;
		}
		global::ItemDataBlock datablock = otherItem.datablock;
		if (!datablock || !datablock.isResearchable)
		{
			return global::InventoryItem.MergeResult.Failed;
		}
		if (!playerInventory.AtWorkBench())
		{
			return global::InventoryItem.MergeResult.Failed;
		}
		global::BlueprintDataBlock bp;
		if (!global::BlueprintDataBlock.FindBlueprintForItem<global::BlueprintDataBlock>(otherItem.datablock, out bp))
		{
			return global::InventoryItem.MergeResult.Failed;
		}
		if (playerInventory.KnowsBP(bp))
		{
			return global::InventoryItem.MergeResult.Failed;
		}
		playerInventory.BindBlueprint(bp);
		global::Rust.Notice.Popup(playerInventory.networkView.owner, "", "You can now craft " + otherItem.datablock.name, 4f);
		int num = 1;
		if (base.Consume(ref num))
		{
			base.inventory.RemoveItem(base.slot);
		}
		return global::InventoryItem.MergeResult.Combined;
	}
}
