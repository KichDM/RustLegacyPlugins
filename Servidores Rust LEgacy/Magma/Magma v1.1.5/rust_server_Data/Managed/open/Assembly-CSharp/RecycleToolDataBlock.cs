using System;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x020006B6 RID: 1718
public class RecycleToolDataBlock : global::ToolDataBlock
{
	// Token: 0x060039FE RID: 14846 RVA: 0x000D0C0C File Offset: 0x000CEE0C
	public RecycleToolDataBlock()
	{
	}

	// Token: 0x060039FF RID: 14847 RVA: 0x000D0C14 File Offset: 0x000CEE14
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::RecycleToolDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x06003A00 RID: 14848 RVA: 0x000D0C1C File Offset: 0x000CEE1C
	public override bool CanWork(global::IToolItem tool, global::Inventory workbenchInv)
	{
		if (workbenchInv.occupiedSlotCount > 2)
		{
			global::UnityEngine.Debug.Log("Too many items for recycle");
			return false;
		}
		global::IInventoryItem firstItemNotTool = base.GetFirstItemNotTool(tool, workbenchInv);
		return firstItemNotTool.datablock.isRecycleable && global::BlueprintDataBlock.FindBlueprintForItem(firstItemNotTool.datablock);
	}

	// Token: 0x06003A01 RID: 14849 RVA: 0x000D0C70 File Offset: 0x000CEE70
	public override float GetWorkDuration(global::IToolItem tool)
	{
		return 15f;
	}

	// Token: 0x06003A02 RID: 14850 RVA: 0x000D0C78 File Offset: 0x000CEE78
	public override bool CompleteWork(global::IToolItem tool, global::Inventory workbenchInv)
	{
		if (!this.CanWork(tool, workbenchInv))
		{
			return false;
		}
		global::IInventoryItem firstItemNotTool = base.GetFirstItemNotTool(tool, workbenchInv);
		global::BlueprintDataBlock blueprintDataBlock;
		global::BlueprintDataBlock.FindBlueprintForItem<global::BlueprintDataBlock>(firstItemNotTool.datablock, out blueprintDataBlock);
		int num = 1;
		if (firstItemNotTool.datablock.IsSplittable())
		{
			num = firstItemNotTool.uses;
		}
		for (int i = 0; i < num; i++)
		{
			foreach (global::BlueprintDataBlock.IngredientEntry ingredientEntry in blueprintDataBlock.ingredients)
			{
				int num2 = global::UnityEngine.Random.Range(0, 4);
				if (num2 != 0)
				{
					if (num2 == 1 || num2 == 2 || num2 == 3)
					{
						workbenchInv.AddItemAmount(ingredientEntry.Ingredient, ingredientEntry.amount);
					}
				}
			}
		}
		int num3;
		if (!firstItemNotTool.datablock.IsSplittable())
		{
			num3 = firstItemNotTool.uses;
		}
		else
		{
			num3 = num;
		}
		if (firstItemNotTool.Consume(ref num3))
		{
			firstItemNotTool.inventory.RemoveItem(firstItemNotTool.slot);
		}
		return true;
	}

	// Token: 0x06003A03 RID: 14851 RVA: 0x000D0D80 File Offset: 0x000CEF80
	public override string GetItemDescription()
	{
		return "This doesn't do anything.. yet";
	}

	// Token: 0x020006B7 RID: 1719
	private sealed class ITEM_TYPE : global::ResearchToolItem<global::RecycleToolDataBlock>, global::IInventoryItem, global::IResearchToolItem, global::IToolItem
	{
		// Token: 0x06003A04 RID: 14852 RVA: 0x000D0D88 File Offset: 0x000CEF88
		public ITEM_TYPE(global::RecycleToolDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000B0F RID: 2831
		// (get) Token: 0x06003A05 RID: 14853 RVA: 0x000D0D94 File Offset: 0x000CEF94
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x06003A06 RID: 14854 RVA: 0x000D0D9C File Offset: 0x000CEF9C
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x06003A07 RID: 14855 RVA: 0x000D0DA4 File Offset: 0x000CEFA4
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x06003A08 RID: 14856 RVA: 0x000D0DAC File Offset: 0x000CEFAC
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x06003A09 RID: 14857 RVA: 0x000D0DB4 File Offset: 0x000CEFB4
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x06003A0A RID: 14858 RVA: 0x000D0DC0 File Offset: 0x000CEFC0
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x06003A0B RID: 14859 RVA: 0x000D0DCC File Offset: 0x000CEFCC
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x06003A0C RID: 14860 RVA: 0x000D0DD8 File Offset: 0x000CEFD8
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x06003A0D RID: 14861 RVA: 0x000D0DE4 File Offset: 0x000CEFE4
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x06003A0E RID: 14862 RVA: 0x000D0DF0 File Offset: 0x000CEFF0
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x06003A0F RID: 14863 RVA: 0x000D0DFC File Offset: 0x000CEFFC
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x06003A10 RID: 14864 RVA: 0x000D0E08 File Offset: 0x000CF008
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x06003A11 RID: 14865 RVA: 0x000D0E14 File Offset: 0x000CF014
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x06003A12 RID: 14866 RVA: 0x000D0E1C File Offset: 0x000CF01C
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x06003A13 RID: 14867 RVA: 0x000D0E28 File Offset: 0x000CF028
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x06003A14 RID: 14868 RVA: 0x000D0E34 File Offset: 0x000CF034
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x06003A15 RID: 14869 RVA: 0x000D0E3C File Offset: 0x000CF03C
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x06003A16 RID: 14870 RVA: 0x000D0E44 File Offset: 0x000CF044
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x06003A17 RID: 14871 RVA: 0x000D0E4C File Offset: 0x000CF04C
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x06003A18 RID: 14872 RVA: 0x000D0E54 File Offset: 0x000CF054
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x06003A19 RID: 14873 RVA: 0x000D0E5C File Offset: 0x000CF05C
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x06003A1A RID: 14874 RVA: 0x000D0E64 File Offset: 0x000CF064
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x06003A1B RID: 14875 RVA: 0x000D0E6C File Offset: 0x000CF06C
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x06003A1C RID: 14876 RVA: 0x000D0E78 File Offset: 0x000CF078
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x06003A1D RID: 14877 RVA: 0x000D0E80 File Offset: 0x000CF080
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x06003A1E RID: 14878 RVA: 0x000D0E88 File Offset: 0x000CF088
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x06003A1F RID: 14879 RVA: 0x000D0E90 File Offset: 0x000CF090
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x06003A20 RID: 14880 RVA: 0x000D0E98 File Offset: 0x000CF098
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x06003A21 RID: 14881 RVA: 0x000D0EA0 File Offset: 0x000CF0A0
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x06003A22 RID: 14882 RVA: 0x000D0EA8 File Offset: 0x000CF0A8
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
