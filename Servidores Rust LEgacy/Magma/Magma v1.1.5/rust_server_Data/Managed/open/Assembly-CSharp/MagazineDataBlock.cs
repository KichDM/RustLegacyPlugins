using System;
using RustProto;
using uLink;

// Token: 0x0200069F RID: 1695
public class MagazineDataBlock : global::ItemDataBlock
{
	// Token: 0x06003810 RID: 14352 RVA: 0x000CE474 File Offset: 0x000CC674
	public MagazineDataBlock()
	{
	}

	// Token: 0x06003811 RID: 14353 RVA: 0x000CE47C File Offset: 0x000CC67C
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::MagazineDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x020006A0 RID: 1696
	private sealed class ITEM_TYPE : global::MagazineItem<global::MagazineDataBlock>, global::IInventoryItem, global::IMagazineItem
	{
		// Token: 0x06003812 RID: 14354 RVA: 0x000CE484 File Offset: 0x000CC684
		public ITEM_TYPE(global::MagazineDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000B04 RID: 2820
		// (get) Token: 0x06003813 RID: 14355 RVA: 0x000CE490 File Offset: 0x000CC690
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x06003814 RID: 14356 RVA: 0x000CE498 File Offset: 0x000CC698
		int get_numEmptyBulletSlots()
		{
			return base.numEmptyBulletSlots;
		}

		// Token: 0x06003815 RID: 14357 RVA: 0x000CE4A0 File Offset: 0x000CC6A0
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x06003816 RID: 14358 RVA: 0x000CE4A8 File Offset: 0x000CC6A8
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x06003817 RID: 14359 RVA: 0x000CE4B0 File Offset: 0x000CC6B0
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x06003818 RID: 14360 RVA: 0x000CE4B8 File Offset: 0x000CC6B8
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x06003819 RID: 14361 RVA: 0x000CE4C4 File Offset: 0x000CC6C4
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x0600381A RID: 14362 RVA: 0x000CE4D0 File Offset: 0x000CC6D0
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x0600381B RID: 14363 RVA: 0x000CE4DC File Offset: 0x000CC6DC
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x0600381C RID: 14364 RVA: 0x000CE4E8 File Offset: 0x000CC6E8
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x0600381D RID: 14365 RVA: 0x000CE4F4 File Offset: 0x000CC6F4
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x0600381E RID: 14366 RVA: 0x000CE500 File Offset: 0x000CC700
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x0600381F RID: 14367 RVA: 0x000CE50C File Offset: 0x000CC70C
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x06003820 RID: 14368 RVA: 0x000CE518 File Offset: 0x000CC718
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x06003821 RID: 14369 RVA: 0x000CE520 File Offset: 0x000CC720
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x06003822 RID: 14370 RVA: 0x000CE52C File Offset: 0x000CC72C
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x06003823 RID: 14371 RVA: 0x000CE538 File Offset: 0x000CC738
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x06003824 RID: 14372 RVA: 0x000CE540 File Offset: 0x000CC740
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x06003825 RID: 14373 RVA: 0x000CE548 File Offset: 0x000CC748
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x06003826 RID: 14374 RVA: 0x000CE550 File Offset: 0x000CC750
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x06003827 RID: 14375 RVA: 0x000CE558 File Offset: 0x000CC758
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x06003828 RID: 14376 RVA: 0x000CE560 File Offset: 0x000CC760
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x06003829 RID: 14377 RVA: 0x000CE568 File Offset: 0x000CC768
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x0600382A RID: 14378 RVA: 0x000CE570 File Offset: 0x000CC770
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x0600382B RID: 14379 RVA: 0x000CE57C File Offset: 0x000CC77C
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x0600382C RID: 14380 RVA: 0x000CE584 File Offset: 0x000CC784
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x0600382D RID: 14381 RVA: 0x000CE58C File Offset: 0x000CC78C
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x0600382E RID: 14382 RVA: 0x000CE594 File Offset: 0x000CC794
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x0600382F RID: 14383 RVA: 0x000CE59C File Offset: 0x000CC79C
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x06003830 RID: 14384 RVA: 0x000CE5A4 File Offset: 0x000CC7A4
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x06003831 RID: 14385 RVA: 0x000CE5AC File Offset: 0x000CC7AC
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
