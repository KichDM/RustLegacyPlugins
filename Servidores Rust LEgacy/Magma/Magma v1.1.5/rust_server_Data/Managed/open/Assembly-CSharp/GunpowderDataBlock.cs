using System;
using RustProto;
using uLink;

// Token: 0x02000692 RID: 1682
public class GunpowderDataBlock : global::ItemDataBlock
{
	// Token: 0x0600370E RID: 14094 RVA: 0x000CD2C0 File Offset: 0x000CB4C0
	public GunpowderDataBlock()
	{
	}

	// Token: 0x0600370F RID: 14095 RVA: 0x000CD2C8 File Offset: 0x000CB4C8
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::GunpowderDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x06003710 RID: 14096 RVA: 0x000CD2D0 File Offset: 0x000CB4D0
	public override string GetItemDescription()
	{
		return "Explosive used in ammunition, Combine this with empty casings to prime them.";
	}

	// Token: 0x02000693 RID: 1683
	private sealed class ITEM_TYPE : global::GunpowderItem<global::GunpowderDataBlock>, global::IGunpowderItem, global::IInventoryItem
	{
		// Token: 0x06003711 RID: 14097 RVA: 0x000CD2D8 File Offset: 0x000CB4D8
		public ITEM_TYPE(global::GunpowderDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000AFB RID: 2811
		// (get) Token: 0x06003712 RID: 14098 RVA: 0x000CD2E4 File Offset: 0x000CB4E4
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x06003713 RID: 14099 RVA: 0x000CD2EC File Offset: 0x000CB4EC
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x06003714 RID: 14100 RVA: 0x000CD2F4 File Offset: 0x000CB4F4
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x06003715 RID: 14101 RVA: 0x000CD2FC File Offset: 0x000CB4FC
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x06003716 RID: 14102 RVA: 0x000CD304 File Offset: 0x000CB504
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x06003717 RID: 14103 RVA: 0x000CD310 File Offset: 0x000CB510
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x06003718 RID: 14104 RVA: 0x000CD31C File Offset: 0x000CB51C
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x06003719 RID: 14105 RVA: 0x000CD328 File Offset: 0x000CB528
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x0600371A RID: 14106 RVA: 0x000CD334 File Offset: 0x000CB534
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x0600371B RID: 14107 RVA: 0x000CD340 File Offset: 0x000CB540
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x0600371C RID: 14108 RVA: 0x000CD34C File Offset: 0x000CB54C
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x0600371D RID: 14109 RVA: 0x000CD358 File Offset: 0x000CB558
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x0600371E RID: 14110 RVA: 0x000CD364 File Offset: 0x000CB564
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x0600371F RID: 14111 RVA: 0x000CD36C File Offset: 0x000CB56C
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x06003720 RID: 14112 RVA: 0x000CD378 File Offset: 0x000CB578
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x06003721 RID: 14113 RVA: 0x000CD384 File Offset: 0x000CB584
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x06003722 RID: 14114 RVA: 0x000CD38C File Offset: 0x000CB58C
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x06003723 RID: 14115 RVA: 0x000CD394 File Offset: 0x000CB594
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x06003724 RID: 14116 RVA: 0x000CD39C File Offset: 0x000CB59C
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x06003725 RID: 14117 RVA: 0x000CD3A4 File Offset: 0x000CB5A4
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x06003726 RID: 14118 RVA: 0x000CD3AC File Offset: 0x000CB5AC
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x06003727 RID: 14119 RVA: 0x000CD3B4 File Offset: 0x000CB5B4
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x06003728 RID: 14120 RVA: 0x000CD3BC File Offset: 0x000CB5BC
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x06003729 RID: 14121 RVA: 0x000CD3C8 File Offset: 0x000CB5C8
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x0600372A RID: 14122 RVA: 0x000CD3D0 File Offset: 0x000CB5D0
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x0600372B RID: 14123 RVA: 0x000CD3D8 File Offset: 0x000CB5D8
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x0600372C RID: 14124 RVA: 0x000CD3E0 File Offset: 0x000CB5E0
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x0600372D RID: 14125 RVA: 0x000CD3E8 File Offset: 0x000CB5E8
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x0600372E RID: 14126 RVA: 0x000CD3F0 File Offset: 0x000CB5F0
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x0600372F RID: 14127 RVA: 0x000CD3F8 File Offset: 0x000CB5F8
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
