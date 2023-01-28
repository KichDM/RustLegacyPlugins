using System;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x020006BA RID: 1722
public class ToolDataBlock : global::ItemDataBlock
{
	// Token: 0x06003A48 RID: 14920 RVA: 0x000D10B4 File Offset: 0x000CF2B4
	public ToolDataBlock()
	{
	}

	// Token: 0x06003A49 RID: 14921 RVA: 0x000D10BC File Offset: 0x000CF2BC
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::ToolDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x06003A4A RID: 14922 RVA: 0x000D10C4 File Offset: 0x000CF2C4
	public virtual bool CanWork(global::IToolItem tool, global::Inventory workbenchInv)
	{
		return false;
	}

	// Token: 0x06003A4B RID: 14923 RVA: 0x000D10C8 File Offset: 0x000CF2C8
	public virtual bool CompleteWork(global::IToolItem tool, global::Inventory workbenchInv)
	{
		return false;
	}

	// Token: 0x06003A4C RID: 14924 RVA: 0x000D10CC File Offset: 0x000CF2CC
	public virtual float GetWorkDuration(global::IToolItem tool)
	{
		return 1f;
	}

	// Token: 0x06003A4D RID: 14925 RVA: 0x000D10D4 File Offset: 0x000CF2D4
	public global::IInventoryItem GetFirstItemNotTool(global::IToolItem tool, global::Inventory workbenchInv)
	{
		using (global::Inventory.OccupiedIterator occupiedIterator = workbenchInv.occupiedIterator)
		{
			global::IInventoryItem inventoryItem;
			while (occupiedIterator.Next(out inventoryItem))
			{
				if (!object.ReferenceEquals(inventoryItem, tool))
				{
					return inventoryItem;
				}
			}
		}
		global::UnityEngine.Debug.LogWarning("Could not find target item");
		return null;
	}

	// Token: 0x020006BB RID: 1723
	private sealed class ITEM_TYPE : global::ToolItem<global::ToolDataBlock>, global::IInventoryItem, global::IToolItem
	{
		// Token: 0x06003A4E RID: 14926 RVA: 0x000D1148 File Offset: 0x000CF348
		public ITEM_TYPE(global::ToolDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000B11 RID: 2833
		// (get) Token: 0x06003A4F RID: 14927 RVA: 0x000D1154 File Offset: 0x000CF354
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x06003A50 RID: 14928 RVA: 0x000D115C File Offset: 0x000CF35C
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x06003A51 RID: 14929 RVA: 0x000D1164 File Offset: 0x000CF364
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x06003A52 RID: 14930 RVA: 0x000D116C File Offset: 0x000CF36C
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x06003A53 RID: 14931 RVA: 0x000D1174 File Offset: 0x000CF374
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x06003A54 RID: 14932 RVA: 0x000D1180 File Offset: 0x000CF380
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x06003A55 RID: 14933 RVA: 0x000D118C File Offset: 0x000CF38C
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x06003A56 RID: 14934 RVA: 0x000D1198 File Offset: 0x000CF398
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x06003A57 RID: 14935 RVA: 0x000D11A4 File Offset: 0x000CF3A4
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x06003A58 RID: 14936 RVA: 0x000D11B0 File Offset: 0x000CF3B0
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x06003A59 RID: 14937 RVA: 0x000D11BC File Offset: 0x000CF3BC
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x06003A5A RID: 14938 RVA: 0x000D11C8 File Offset: 0x000CF3C8
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x06003A5B RID: 14939 RVA: 0x000D11D4 File Offset: 0x000CF3D4
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x06003A5C RID: 14940 RVA: 0x000D11DC File Offset: 0x000CF3DC
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x06003A5D RID: 14941 RVA: 0x000D11E8 File Offset: 0x000CF3E8
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x06003A5E RID: 14942 RVA: 0x000D11F4 File Offset: 0x000CF3F4
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x06003A5F RID: 14943 RVA: 0x000D11FC File Offset: 0x000CF3FC
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x06003A60 RID: 14944 RVA: 0x000D1204 File Offset: 0x000CF404
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x06003A61 RID: 14945 RVA: 0x000D120C File Offset: 0x000CF40C
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x06003A62 RID: 14946 RVA: 0x000D1214 File Offset: 0x000CF414
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x06003A63 RID: 14947 RVA: 0x000D121C File Offset: 0x000CF41C
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x06003A64 RID: 14948 RVA: 0x000D1224 File Offset: 0x000CF424
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x06003A65 RID: 14949 RVA: 0x000D122C File Offset: 0x000CF42C
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x06003A66 RID: 14950 RVA: 0x000D1238 File Offset: 0x000CF438
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x06003A67 RID: 14951 RVA: 0x000D1240 File Offset: 0x000CF440
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x06003A68 RID: 14952 RVA: 0x000D1248 File Offset: 0x000CF448
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x06003A69 RID: 14953 RVA: 0x000D1250 File Offset: 0x000CF450
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x06003A6A RID: 14954 RVA: 0x000D1258 File Offset: 0x000CF458
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x06003A6B RID: 14955 RVA: 0x000D1260 File Offset: 0x000CF460
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x06003A6C RID: 14956 RVA: 0x000D1268 File Offset: 0x000CF468
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
