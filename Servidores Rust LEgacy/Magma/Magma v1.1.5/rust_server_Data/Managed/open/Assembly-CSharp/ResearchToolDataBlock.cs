using System;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x020006B8 RID: 1720
public class ResearchToolDataBlock : global::ToolDataBlock
{
	// Token: 0x06003A23 RID: 14883 RVA: 0x000D0EB0 File Offset: 0x000CF0B0
	public ResearchToolDataBlock()
	{
	}

	// Token: 0x06003A24 RID: 14884 RVA: 0x000D0EB8 File Offset: 0x000CF0B8
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::ResearchToolDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x06003A25 RID: 14885 RVA: 0x000D0EC0 File Offset: 0x000CF0C0
	public override float GetWorkDuration(global::IToolItem tool)
	{
		return 30f;
	}

	// Token: 0x06003A26 RID: 14886 RVA: 0x000D0EC8 File Offset: 0x000CF0C8
	public override bool CanWork(global::IToolItem tool, global::Inventory workbenchInv)
	{
		if (workbenchInv.occupiedSlotCount > 2)
		{
			global::UnityEngine.Debug.Log("Too many items for research");
			return false;
		}
		global::IInventoryItem firstItemNotTool = base.GetFirstItemNotTool(tool, workbenchInv);
		if (firstItemNotTool != null && firstItemNotTool.datablock.isResearchable && global::BlueprintDataBlock.FindBlueprintForItem(firstItemNotTool.datablock))
		{
			return true;
		}
		global::UnityEngine.Debug.Log("Can't work!?!!?");
		return false;
	}

	// Token: 0x06003A27 RID: 14887 RVA: 0x000D0F2C File Offset: 0x000CF12C
	public override bool CompleteWork(global::IToolItem tool, global::Inventory workbenchInv)
	{
		if (!this.CanWork(tool, workbenchInv))
		{
			return false;
		}
		global::IInventoryItem firstItemNotTool = base.GetFirstItemNotTool(tool, workbenchInv);
		global::BlueprintDataBlock blueprintDataBlock;
		if (global::BlueprintDataBlock.FindBlueprintForItem<global::BlueprintDataBlock>(firstItemNotTool.datablock, out blueprintDataBlock))
		{
			workbenchInv.AddItem(blueprintDataBlock, global::Inventory.Slot.Preference.Define(global::Inventory.Slot.Kind.Default, blueprintDataBlock.IsSplittable(), global::Inventory.Slot.Kind.Belt), 1);
			return true;
		}
		return false;
	}

	// Token: 0x06003A28 RID: 14888 RVA: 0x000D0F84 File Offset: 0x000CF184
	public override string GetItemDescription()
	{
		return "Drag this onto another item to learn how to craft it. Requires 1 Paper.";
	}

	// Token: 0x020006B9 RID: 1721
	private sealed class ITEM_TYPE : global::ResearchToolItem<global::ResearchToolDataBlock>, global::IInventoryItem, global::IResearchToolItem, global::IToolItem
	{
		// Token: 0x06003A29 RID: 14889 RVA: 0x000D0F8C File Offset: 0x000CF18C
		public ITEM_TYPE(global::ResearchToolDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000B10 RID: 2832
		// (get) Token: 0x06003A2A RID: 14890 RVA: 0x000D0F98 File Offset: 0x000CF198
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x06003A2B RID: 14891 RVA: 0x000D0FA0 File Offset: 0x000CF1A0
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x06003A2C RID: 14892 RVA: 0x000D0FA8 File Offset: 0x000CF1A8
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x06003A2D RID: 14893 RVA: 0x000D0FB0 File Offset: 0x000CF1B0
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x06003A2E RID: 14894 RVA: 0x000D0FB8 File Offset: 0x000CF1B8
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x06003A2F RID: 14895 RVA: 0x000D0FC4 File Offset: 0x000CF1C4
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x06003A30 RID: 14896 RVA: 0x000D0FD0 File Offset: 0x000CF1D0
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x06003A31 RID: 14897 RVA: 0x000D0FDC File Offset: 0x000CF1DC
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x06003A32 RID: 14898 RVA: 0x000D0FE8 File Offset: 0x000CF1E8
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x06003A33 RID: 14899 RVA: 0x000D0FF4 File Offset: 0x000CF1F4
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x06003A34 RID: 14900 RVA: 0x000D1000 File Offset: 0x000CF200
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x06003A35 RID: 14901 RVA: 0x000D100C File Offset: 0x000CF20C
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x06003A36 RID: 14902 RVA: 0x000D1018 File Offset: 0x000CF218
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x06003A37 RID: 14903 RVA: 0x000D1020 File Offset: 0x000CF220
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x06003A38 RID: 14904 RVA: 0x000D102C File Offset: 0x000CF22C
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x06003A39 RID: 14905 RVA: 0x000D1038 File Offset: 0x000CF238
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x06003A3A RID: 14906 RVA: 0x000D1040 File Offset: 0x000CF240
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x06003A3B RID: 14907 RVA: 0x000D1048 File Offset: 0x000CF248
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x06003A3C RID: 14908 RVA: 0x000D1050 File Offset: 0x000CF250
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x06003A3D RID: 14909 RVA: 0x000D1058 File Offset: 0x000CF258
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x06003A3E RID: 14910 RVA: 0x000D1060 File Offset: 0x000CF260
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x06003A3F RID: 14911 RVA: 0x000D1068 File Offset: 0x000CF268
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x06003A40 RID: 14912 RVA: 0x000D1070 File Offset: 0x000CF270
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x06003A41 RID: 14913 RVA: 0x000D107C File Offset: 0x000CF27C
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x06003A42 RID: 14914 RVA: 0x000D1084 File Offset: 0x000CF284
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x06003A43 RID: 14915 RVA: 0x000D108C File Offset: 0x000CF28C
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x06003A44 RID: 14916 RVA: 0x000D1094 File Offset: 0x000CF294
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x06003A45 RID: 14917 RVA: 0x000D109C File Offset: 0x000CF29C
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x06003A46 RID: 14918 RVA: 0x000D10A4 File Offset: 0x000CF2A4
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x06003A47 RID: 14919 RVA: 0x000D10AC File Offset: 0x000CF2AC
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
