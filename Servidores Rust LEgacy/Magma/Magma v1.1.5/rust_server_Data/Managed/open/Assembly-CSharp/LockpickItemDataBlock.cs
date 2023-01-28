using System;
using RustProto;
using uLink;

// Token: 0x0200069D RID: 1693
public class LockpickItemDataBlock : global::ItemDataBlock
{
	// Token: 0x060037EF RID: 14319 RVA: 0x000CE33C File Offset: 0x000CC53C
	public LockpickItemDataBlock()
	{
	}

	// Token: 0x060037F0 RID: 14320 RVA: 0x000CE344 File Offset: 0x000CC544
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::LockpickItemDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x04001DE9 RID: 7657
	public float pickingAbility;

	// Token: 0x0200069E RID: 1694
	private sealed class ITEM_TYPE : global::LockpickItem<global::LockpickItemDataBlock>, global::IInventoryItem, global::ILockpickItem
	{
		// Token: 0x060037F1 RID: 14321 RVA: 0x000CE34C File Offset: 0x000CC54C
		public ITEM_TYPE(global::LockpickItemDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000B03 RID: 2819
		// (get) Token: 0x060037F2 RID: 14322 RVA: 0x000CE358 File Offset: 0x000CC558
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x060037F3 RID: 14323 RVA: 0x000CE360 File Offset: 0x000CC560
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x060037F4 RID: 14324 RVA: 0x000CE368 File Offset: 0x000CC568
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x060037F5 RID: 14325 RVA: 0x000CE370 File Offset: 0x000CC570
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x060037F6 RID: 14326 RVA: 0x000CE378 File Offset: 0x000CC578
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x060037F7 RID: 14327 RVA: 0x000CE384 File Offset: 0x000CC584
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x060037F8 RID: 14328 RVA: 0x000CE390 File Offset: 0x000CC590
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x060037F9 RID: 14329 RVA: 0x000CE39C File Offset: 0x000CC59C
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x060037FA RID: 14330 RVA: 0x000CE3A8 File Offset: 0x000CC5A8
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x060037FB RID: 14331 RVA: 0x000CE3B4 File Offset: 0x000CC5B4
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x060037FC RID: 14332 RVA: 0x000CE3C0 File Offset: 0x000CC5C0
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x060037FD RID: 14333 RVA: 0x000CE3CC File Offset: 0x000CC5CC
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x060037FE RID: 14334 RVA: 0x000CE3D8 File Offset: 0x000CC5D8
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x060037FF RID: 14335 RVA: 0x000CE3E0 File Offset: 0x000CC5E0
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x06003800 RID: 14336 RVA: 0x000CE3EC File Offset: 0x000CC5EC
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x06003801 RID: 14337 RVA: 0x000CE3F8 File Offset: 0x000CC5F8
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x06003802 RID: 14338 RVA: 0x000CE400 File Offset: 0x000CC600
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x06003803 RID: 14339 RVA: 0x000CE408 File Offset: 0x000CC608
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x06003804 RID: 14340 RVA: 0x000CE410 File Offset: 0x000CC610
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x06003805 RID: 14341 RVA: 0x000CE418 File Offset: 0x000CC618
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x06003806 RID: 14342 RVA: 0x000CE420 File Offset: 0x000CC620
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x06003807 RID: 14343 RVA: 0x000CE428 File Offset: 0x000CC628
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x06003808 RID: 14344 RVA: 0x000CE430 File Offset: 0x000CC630
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x06003809 RID: 14345 RVA: 0x000CE43C File Offset: 0x000CC63C
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x0600380A RID: 14346 RVA: 0x000CE444 File Offset: 0x000CC644
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x0600380B RID: 14347 RVA: 0x000CE44C File Offset: 0x000CC64C
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x0600380C RID: 14348 RVA: 0x000CE454 File Offset: 0x000CC654
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x0600380D RID: 14349 RVA: 0x000CE45C File Offset: 0x000CC65C
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x0600380E RID: 14350 RVA: 0x000CE464 File Offset: 0x000CC664
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x0600380F RID: 14351 RVA: 0x000CE46C File Offset: 0x000CC66C
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
