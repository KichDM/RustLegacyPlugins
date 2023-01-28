using System;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x020006F7 RID: 1783
public abstract class InventoryItem<DB> : global::InventoryItem where DB : global::ItemDataBlock
{
	// Token: 0x06003CE2 RID: 15586 RVA: 0x000D645C File Offset: 0x000D465C
	protected InventoryItem(DB datablock) : base(datablock)
	{
		this.datablock = datablock;
	}

	// Token: 0x17000B87 RID: 2951
	// (get) Token: 0x06003CE3 RID: 15587 RVA: 0x000D6474 File Offset: 0x000D4674
	public bool doNotSave
	{
		get
		{
			bool result;
			if (this.datablock)
			{
				DB db = this.datablock;
				result = db.doesNotSave;
			}
			else
			{
				result = false;
			}
			return result;
		}
	}

	// Token: 0x17000B88 RID: 2952
	// (get) Token: 0x06003CE4 RID: 15588 RVA: 0x000D64B0 File Offset: 0x000D46B0
	public override string toolTip
	{
		get
		{
			string conditionString = this.GetConditionString();
			if (string.IsNullOrEmpty(conditionString))
			{
				DB db = this.datablock;
				return db.name;
			}
			string str = conditionString;
			string str2 = " ";
			DB db2 = this.datablock;
			return str + str2 + db2.name;
		}
	}

	// Token: 0x17000B89 RID: 2953
	// (get) Token: 0x06003CE5 RID: 15589 RVA: 0x000D6504 File Offset: 0x000D4704
	protected sealed override global::ItemDataBlock __infrastructure_db
	{
		get
		{
			return this.datablock;
		}
	}

	// Token: 0x06003CE6 RID: 15590 RVA: 0x000D6514 File Offset: 0x000D4714
	protected override void OnBitStreamWrite(global::uLink.BitStream stream)
	{
		global::InventoryItem.SerializeSharedProperties(stream, this, this.datablock);
	}

	// Token: 0x06003CE7 RID: 15591 RVA: 0x000D6528 File Offset: 0x000D4728
	protected override void OnBitStreamRead(global::uLink.BitStream stream)
	{
		global::InventoryItem.DeserializeSharedProperties(stream, this, this.datablock);
	}

	// Token: 0x06003CE8 RID: 15592 RVA: 0x000D653C File Offset: 0x000D473C
	public override void OnBeltUse()
	{
	}

	// Token: 0x06003CE9 RID: 15593 RVA: 0x000D6540 File Offset: 0x000D4740
	public override void OnMovedTo(global::Inventory inv, int slot)
	{
	}

	// Token: 0x06003CEA RID: 15594 RVA: 0x000D6544 File Offset: 0x000D4744
	public override global::InventoryItem.MergeResult TryStack(global::IInventoryItem other)
	{
		int uses = base.uses;
		if (uses == 0)
		{
			return global::InventoryItem.MergeResult.Failed;
		}
		DB db = other.datablock as DB;
		if (db && db == this.datablock)
		{
			int uses2 = other.uses;
			if (uses2 == this.maxUses)
			{
				return global::InventoryItem.MergeResult.Failed;
			}
			DB db2 = this.datablock;
			if (db2.IsSplittable())
			{
				int num = other.AddUses(uses);
				if (num == 0)
				{
					return global::InventoryItem.MergeResult.Failed;
				}
				bool flag = this.Consume(ref num);
				if (flag)
				{
					this.inventory.RemoveItem(this.slot);
					other.MarkDirty();
				}
				else
				{
					this.MarkDirty();
					other.MarkDirty();
				}
				return global::InventoryItem.MergeResult.Merged;
			}
		}
		return global::InventoryItem.MergeResult.Failed;
	}

	// Token: 0x06003CEB RID: 15595 RVA: 0x000D6628 File Offset: 0x000D4828
	public override global::InventoryItem.MenuItemResult OnMenuOption(global::InventoryItem.MenuItem option)
	{
		DB db = this.datablock;
		global::InventoryItem.MenuItemResult result = db.ExecuteMenuOption(option, this.iface);
		switch (result)
		{
		case global::InventoryItem.MenuItemResult.Unhandled:
			global::UnityEngine.Debug.LogWarning("Did not handle " + option);
			break;
		case global::InventoryItem.MenuItemResult.DoneOnClient:
			base.inventory.NetworkItemAction(base.slot, option);
			break;
		}
		return result;
	}

	// Token: 0x06003CEC RID: 15596 RVA: 0x000D66A8 File Offset: 0x000D48A8
	public sealed override void FireClientSideItemEvent(global::InventoryItem.ItemEvent itemEvent)
	{
		global::Inventory inventory = base.inventory;
		if (inventory)
		{
			inventory.FireClientSideEvent(itemEvent, this.datablock);
		}
	}

	// Token: 0x06003CED RID: 15597 RVA: 0x000D66DC File Offset: 0x000D48DC
	public override global::InventoryItem.MergeResult TryCombine(global::IInventoryItem other)
	{
		global::ItemDataBlock db = other.datablock;
		DB db2 = this.datablock;
		global::ItemDataBlock.CombineRecipe matchingRecipe = db2.GetMatchingRecipe(db);
		if (matchingRecipe == null)
		{
			return global::InventoryItem.MergeResult.Failed;
		}
		int uses = other.uses;
		if (uses < matchingRecipe.amountToLoseOther)
		{
			return global::InventoryItem.MergeResult.Failed;
		}
		if (base.uses < matchingRecipe.amountToLose)
		{
			return global::InventoryItem.MergeResult.Failed;
		}
		global::Inventory inventory = other.inventory;
		int num = base.uses / matchingRecipe.amountToLose;
		int num2 = uses / matchingRecipe.amountToLoseOther;
		int num3 = global::UnityEngine.Mathf.Min(num, num2);
		int num4 = 0;
		if (matchingRecipe.resultItem.IsSplittable())
		{
			num4 = global::UnityEngine.Mathf.CeilToInt((float)num3 / (float)num4);
		}
		else
		{
			num4 = num3;
		}
		int vacantSlotCount = inventory.vacantSlotCount;
		if (num4 > vacantSlotCount)
		{
			return global::InventoryItem.MergeResult.Failed;
		}
		int num5 = num3 * matchingRecipe.amountToLoseOther;
		if (other.Consume(ref num5))
		{
			inventory.RemoveItem(other.slot);
		}
		inventory.AddItemAmount(matchingRecipe.resultItem, num3, global::Inventory.AmountMode.Default);
		int num6 = num3 * matchingRecipe.amountToLose;
		if (base.Consume(ref num6))
		{
			base.inventory.RemoveItem(base.slot);
		}
		this.FireClientSideItemEvent(global::InventoryItem.ItemEvent.Combined);
		return global::InventoryItem.MergeResult.Failed;
	}

	// Token: 0x06003CEE RID: 15598 RVA: 0x000D680C File Offset: 0x000D4A0C
	public bool Save(ref global::RustProto.Item.Builder item)
	{
		return global::ItemDataBlock.SaveItem<DB, global::InventoryItem<DB>>(this.datablock, this, ref item);
	}

	// Token: 0x06003CEF RID: 15599 RVA: 0x000D681C File Offset: 0x000D4A1C
	public bool Load(ref global::RustProto.Item item)
	{
		return global::ItemDataBlock.LoadItem<DB, global::InventoryItem<DB>>(this.datablock, this, ref item);
	}

	// Token: 0x06003CF0 RID: 15600 RVA: 0x000D682C File Offset: 0x000D4A2C
	public override string ToString()
	{
		global::Inventory inventory = base.inventory;
		string text;
		if (this.datablock)
		{
			DB db = this.datablock;
			text = db.name;
		}
		else
		{
			text = global::InventoryItem<DB>.tostringhelper.nullDatablockString;
		}
		string text2 = text;
		if (inventory)
		{
			return string.Format("[{0} (on {1}[{2}]) with ({3} uses)]", new object[]
			{
				text2,
				inventory.name,
				base.slot,
				base.uses
			});
		}
		return string.Format("[{0} (unbound slot {1}) with ({2} uses)]", text2, base.slot, base.uses);
	}

	// Token: 0x04001ED8 RID: 7896
	public new readonly DB datablock;

	// Token: 0x020006F8 RID: 1784
	private static class tostringhelper
	{
		// Token: 0x06003CF1 RID: 15601 RVA: 0x000D68DC File Offset: 0x000D4ADC
		static tostringhelper()
		{
		}

		// Token: 0x04001ED9 RID: 7897
		public static readonly string nullDatablockString = string.Format("NULL<{0}>", typeof(DB).FullName);
	}
}
