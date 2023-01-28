using System;
using System.Collections.Generic;
using Magma;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x0200067B RID: 1659
public class BlueprintDataBlock : global::ToolDataBlock
{
	// Token: 0x06003565 RID: 13669 RVA: 0x000C9CB4 File Offset: 0x000C7EB4
	public BlueprintDataBlock()
	{
		this.icon = "Items/BlueprintIcon";
	}

	// Token: 0x06003566 RID: 13670 RVA: 0x000C9CDC File Offset: 0x000C7EDC
	// Note: this type is marked as 'beforefieldinit'.
	static BlueprintDataBlock()
	{
	}

	// Token: 0x06003567 RID: 13671 RVA: 0x000C9CE0 File Offset: 0x000C7EE0
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::BlueprintDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x06003568 RID: 13672 RVA: 0x000C9CE8 File Offset: 0x000C7EE8
	public virtual void DefaultChancesInit()
	{
		if (!global::BlueprintDataBlock.chancesInitalized)
		{
			global::BlueprintDataBlock.chancesInitalized = true;
			global::BlueprintDataBlock.defaultSlotChances = new global::BlueprintDataBlock.SlotChanceWeightedEntry[5];
			global::BlueprintDataBlock.defaultSlotChances[0].numSlots = 1;
			global::BlueprintDataBlock.defaultSlotChances[1].numSlots = 2;
			global::BlueprintDataBlock.defaultSlotChances[2].numSlots = 3;
			global::BlueprintDataBlock.defaultSlotChances[3].numSlots = 4;
			global::BlueprintDataBlock.defaultSlotChances[4].numSlots = 5;
			global::BlueprintDataBlock.defaultSlotChances[0].weight = 50f;
			global::BlueprintDataBlock.defaultSlotChances[1].weight = 40f;
			global::BlueprintDataBlock.defaultSlotChances[2].weight = 30f;
			global::BlueprintDataBlock.defaultSlotChances[3].weight = 20f;
			global::BlueprintDataBlock.defaultSlotChances[4].weight = 10f;
		}
	}

	// Token: 0x06003569 RID: 13673 RVA: 0x000C9DA8 File Offset: 0x000C7FA8
	public override void InstallData(global::IInventoryItem item)
	{
		base.InstallData(item);
	}

	// Token: 0x0600356A RID: 13674 RVA: 0x000C9DB4 File Offset: 0x000C7FB4
	public virtual int MaxAmount(global::Inventory workbenchInv)
	{
		int num = int.MaxValue;
		foreach (global::BlueprintDataBlock.IngredientEntry ingredientEntry in this.ingredients)
		{
			int num2 = 0;
			global::IInventoryItem inventoryItem = workbenchInv.FindItem(ingredientEntry.Ingredient, out num2);
			if (inventoryItem != null)
			{
				int num3 = num2 / ingredientEntry.amount;
				if (num3 < num)
				{
					num = num3;
				}
			}
		}
		return (num != int.MaxValue) ? num : 0;
	}

	// Token: 0x0600356B RID: 13675 RVA: 0x000C9E28 File Offset: 0x000C8028
	public virtual bool CanWork(int amount, global::Inventory workbenchInv)
	{
		if (this.lastCanWorkResult == null)
		{
			this.lastCanWorkResult = new global::System.Collections.Generic.List<int>();
		}
		else
		{
			this.lastCanWorkResult.Clear();
		}
		if (this.lastCanWorkIngredientCount == null)
		{
			this.lastCanWorkIngredientCount = new global::System.Collections.Generic.List<int>(this.ingredients.Length);
		}
		else
		{
			this.lastCanWorkIngredientCount.Clear();
		}
		if (this.RequireWorkbench)
		{
			global::CraftingInventory component = workbenchInv.GetComponent<global::CraftingInventory>();
			if (!component || !component.AtWorkBench())
			{
				return false;
			}
		}
		foreach (global::BlueprintDataBlock.IngredientEntry ingredientEntry in this.ingredients)
		{
			if (ingredientEntry.amount != 0)
			{
				int num = workbenchInv.CanConsume(ingredientEntry.Ingredient, ingredientEntry.amount * amount, this.lastCanWorkResult);
				if (num <= 0)
				{
					this.lastCanWorkResult.Clear();
					this.lastCanWorkIngredientCount.Clear();
					return false;
				}
				this.lastCanWorkIngredientCount.Add(num);
			}
		}
		return true;
	}

	// Token: 0x0600356C RID: 13676 RVA: 0x000C9F2C File Offset: 0x000C812C
	public override float GetWorkDuration(global::IToolItem tool)
	{
		return this.craftingDuration;
	}

	// Token: 0x0600356D RID: 13677 RVA: 0x000C9F34 File Offset: 0x000C8134
	public virtual bool CompleteWork(int amount, global::Inventory workbenchInv)
	{
		if (!this.CanWork(amount, workbenchInv))
		{
			return false;
		}
		int num = 0;
		for (int i = 0; i < this.ingredients.Length; i++)
		{
			int num2 = this.ingredients[i].amount * amount;
			if (num2 != 0)
			{
				int num3 = this.lastCanWorkIngredientCount[i];
				for (int j = 0; j < num3; j++)
				{
					int slot = this.lastCanWorkResult[num++];
					global::IInventoryItem inventoryItem;
					if (workbenchInv.GetItem(slot, out inventoryItem) && inventoryItem.Consume(ref num2))
					{
						workbenchInv.RemoveItem(slot);
					}
				}
			}
		}
		workbenchInv.AddItemAmount(this.resultItem, amount * this.numResultItem);
		return true;
	}

	// Token: 0x0600356E RID: 13678 RVA: 0x000C9FF8 File Offset: 0x000C81F8
	public override int RetreiveMenuOptions(global::IInventoryItem item, global::InventoryItem.MenuItem[] results, int offset)
	{
		offset = base.RetreiveMenuOptions(item, results, offset);
		if (item.isInLocalInventory)
		{
			results[offset++] = global::InventoryItem.MenuItem.Study;
		}
		return offset;
	}

	// Token: 0x0600356F RID: 13679 RVA: 0x000CA028 File Offset: 0x000C8228
	public override global::InventoryItem.MenuItemResult ExecuteMenuOption(global::InventoryItem.MenuItem option, global::IInventoryItem item)
	{
		if (option != global::InventoryItem.MenuItem.Study)
		{
			return base.ExecuteMenuOption(option, item);
		}
		this.UseItem(item as global::IBlueprintItem);
		return global::InventoryItem.MenuItemResult.DoneOnServer;
	}

	// Token: 0x06003570 RID: 13680 RVA: 0x000CA05C File Offset: 0x000C825C
	public virtual void UseItem(global::IBlueprintItem item)
	{
		global::Magma.Hooks.BlueprintUse(item, this);
	}

	// Token: 0x06003571 RID: 13681 RVA: 0x000CA070 File Offset: 0x000C8270
	public override void PopulateInfoWindow(global::ItemToolTip infoWindow, global::IInventoryItem tipItem)
	{
		infoWindow.AddItemTitle(this, tipItem, 0f);
		infoWindow.AddSectionTitle("Ingredients", 15f);
		for (int i = 0; i < this.ingredients.Length; i++)
		{
			string text = this.ingredients[i].Ingredient.name;
			if (this.ingredients[i].amount > 1)
			{
				text = text + " x" + this.ingredients[i].amount;
			}
			infoWindow.AddBasicLabel(text, 15f);
		}
		infoWindow.AddSectionTitle("Result Item", 15f);
		infoWindow.AddBasicLabel(this.resultItem.name, 15f);
		infoWindow.AddItemDescription(this, 15f);
		infoWindow.FinishPopulating();
	}

	// Token: 0x06003572 RID: 13682 RVA: 0x000CA144 File Offset: 0x000C8344
	public override string GetItemDescription()
	{
		return "This is an item Blueprint. Study it to learn how to craft the item it represents!";
	}

	// Token: 0x06003573 RID: 13683 RVA: 0x000CA14C File Offset: 0x000C834C
	public static bool FindBlueprintForItem<T>(global::ItemDataBlock item, out T blueprint) where T : global::BlueprintDataBlock
	{
		foreach (global::ItemDataBlock itemDataBlock in global::DatablockDictionary.All)
		{
			T t = itemDataBlock as T;
			if (t && t.resultItem == item)
			{
				blueprint = t;
				return true;
			}
		}
		global::UnityEngine.Debug.LogWarning("Could not find blueprint foritem");
		blueprint = (T)((object)null);
		return false;
	}

	// Token: 0x06003574 RID: 13684 RVA: 0x000CA1CC File Offset: 0x000C83CC
	public static bool FindBlueprintForItem(global::ItemDataBlock item)
	{
		global::BlueprintDataBlock blueprintDataBlock;
		return global::BlueprintDataBlock.FindBlueprintForItem<global::BlueprintDataBlock>(item, out blueprintDataBlock);
	}

	// Token: 0x06003575 RID: 13685 RVA: 0x000CA1E4 File Offset: 0x000C83E4
	protected override void SecureWriteMemberValues(global::uLink.BitStream stream)
	{
		base.SecureWriteMemberValues(stream);
		stream.Write<float>(this.craftingDuration, new object[0]);
		if (this.ingredients != null)
		{
			foreach (global::BlueprintDataBlock.IngredientEntry ingredientEntry in this.ingredients)
			{
				if (ingredientEntry != null)
				{
					if (ingredientEntry.Ingredient)
					{
						stream.Write<int>(ingredientEntry.Ingredient.uniqueID ^ ingredientEntry.amount, new object[0]);
					}
					else
					{
						stream.Write<int>(ingredientEntry.amount, new object[0]);
					}
				}
			}
		}
		if (this.resultItem)
		{
			stream.Write<int>(this.resultItem.uniqueID, new object[0]);
		}
		if (global::BlueprintDataBlock.defaultSlotChances != null)
		{
			foreach (global::BlueprintDataBlock.SlotChanceWeightedEntry slotChanceWeightedEntry in global::BlueprintDataBlock.defaultSlotChances)
			{
				stream.Write<float>(slotChanceWeightedEntry.weight, new object[0]);
			}
			foreach (global::BlueprintDataBlock.SlotChanceWeightedEntry slotChanceWeightedEntry2 in global::BlueprintDataBlock.defaultSlotChances)
			{
				stream.Write<byte>(slotChanceWeightedEntry2.numSlots, new object[0]);
			}
		}
	}

	// Token: 0x04001D41 RID: 7489
	public global::ItemDataBlock resultItem;

	// Token: 0x04001D42 RID: 7490
	public int numResultItem = 1;

	// Token: 0x04001D43 RID: 7491
	public global::BlueprintDataBlock.IngredientEntry[] ingredients;

	// Token: 0x04001D44 RID: 7492
	public static global::BlueprintDataBlock.SlotChanceWeightedEntry[] defaultSlotChances;

	// Token: 0x04001D45 RID: 7493
	public static bool chancesInitalized;

	// Token: 0x04001D46 RID: 7494
	public float craftingDuration = 20f;

	// Token: 0x04001D47 RID: 7495
	public bool RequireWorkbench;

	// Token: 0x04001D48 RID: 7496
	private global::System.Collections.Generic.List<int> lastCanWorkResult;

	// Token: 0x04001D49 RID: 7497
	private global::System.Collections.Generic.List<int> lastCanWorkIngredientCount;

	// Token: 0x0200067C RID: 1660
	private sealed class ITEM_TYPE : global::BlueprintItem<global::BlueprintDataBlock>, global::IBlueprintItem, global::IInventoryItem, global::IToolItem
	{
		// Token: 0x06003576 RID: 13686 RVA: 0x000CA324 File Offset: 0x000C8524
		public ITEM_TYPE(global::BlueprintDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000AED RID: 2797
		// (get) Token: 0x06003577 RID: 13687 RVA: 0x000CA330 File Offset: 0x000C8530
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x06003578 RID: 13688 RVA: 0x000CA338 File Offset: 0x000C8538
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x06003579 RID: 13689 RVA: 0x000CA340 File Offset: 0x000C8540
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x0600357A RID: 13690 RVA: 0x000CA348 File Offset: 0x000C8548
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x0600357B RID: 13691 RVA: 0x000CA350 File Offset: 0x000C8550
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x0600357C RID: 13692 RVA: 0x000CA35C File Offset: 0x000C855C
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x0600357D RID: 13693 RVA: 0x000CA368 File Offset: 0x000C8568
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x0600357E RID: 13694 RVA: 0x000CA374 File Offset: 0x000C8574
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x0600357F RID: 13695 RVA: 0x000CA380 File Offset: 0x000C8580
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x06003580 RID: 13696 RVA: 0x000CA38C File Offset: 0x000C858C
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x06003581 RID: 13697 RVA: 0x000CA398 File Offset: 0x000C8598
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x06003582 RID: 13698 RVA: 0x000CA3A4 File Offset: 0x000C85A4
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x06003583 RID: 13699 RVA: 0x000CA3B0 File Offset: 0x000C85B0
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x06003584 RID: 13700 RVA: 0x000CA3B8 File Offset: 0x000C85B8
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x06003585 RID: 13701 RVA: 0x000CA3C4 File Offset: 0x000C85C4
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x06003586 RID: 13702 RVA: 0x000CA3D0 File Offset: 0x000C85D0
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x06003587 RID: 13703 RVA: 0x000CA3D8 File Offset: 0x000C85D8
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x06003588 RID: 13704 RVA: 0x000CA3E0 File Offset: 0x000C85E0
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x06003589 RID: 13705 RVA: 0x000CA3E8 File Offset: 0x000C85E8
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x0600358A RID: 13706 RVA: 0x000CA3F0 File Offset: 0x000C85F0
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x0600358B RID: 13707 RVA: 0x000CA3F8 File Offset: 0x000C85F8
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x0600358C RID: 13708 RVA: 0x000CA400 File Offset: 0x000C8600
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x0600358D RID: 13709 RVA: 0x000CA408 File Offset: 0x000C8608
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x0600358E RID: 13710 RVA: 0x000CA414 File Offset: 0x000C8614
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x0600358F RID: 13711 RVA: 0x000CA41C File Offset: 0x000C861C
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x06003590 RID: 13712 RVA: 0x000CA424 File Offset: 0x000C8624
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x06003591 RID: 13713 RVA: 0x000CA42C File Offset: 0x000C862C
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x06003592 RID: 13714 RVA: 0x000CA434 File Offset: 0x000C8634
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x06003593 RID: 13715 RVA: 0x000CA43C File Offset: 0x000C863C
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x06003594 RID: 13716 RVA: 0x000CA444 File Offset: 0x000C8644
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}

	// Token: 0x0200067D RID: 1661
	[global::System.Serializable]
	public class IngredientEntry
	{
		// Token: 0x06003595 RID: 13717 RVA: 0x000CA44C File Offset: 0x000C864C
		public IngredientEntry()
		{
		}

		// Token: 0x04001D4A RID: 7498
		public global::ItemDataBlock Ingredient;

		// Token: 0x04001D4B RID: 7499
		public int amount;
	}

	// Token: 0x0200067E RID: 1662
	[global::System.Serializable]
	public class SlotChanceWeightedEntry : global::WeightSelection.WeightedEntry
	{
		// Token: 0x06003596 RID: 13718 RVA: 0x000CA454 File Offset: 0x000C8654
		public SlotChanceWeightedEntry()
		{
		}

		// Token: 0x04001D4C RID: 7500
		public byte numSlots;
	}
}
