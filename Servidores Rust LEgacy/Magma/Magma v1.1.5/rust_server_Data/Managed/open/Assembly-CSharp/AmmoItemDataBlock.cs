using System;
using RustProto;
using uLink;

// Token: 0x0200066E RID: 1646
public class AmmoItemDataBlock : global::ItemDataBlock
{
	// Token: 0x06003457 RID: 13399 RVA: 0x000C8BE0 File Offset: 0x000C6DE0
	public AmmoItemDataBlock()
	{
	}

	// Token: 0x06003458 RID: 13400 RVA: 0x000C8BE8 File Offset: 0x000C6DE8
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::AmmoItemDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x06003459 RID: 13401 RVA: 0x000C8BF0 File Offset: 0x000C6DF0
	public override string GetItemDescription()
	{
		return "Ammunition for a weapon";
	}

	// Token: 0x04001D32 RID: 7474
	public global::ItemDataBlock spentCasingType;

	// Token: 0x0200066F RID: 1647
	private sealed class ITEM_TYPE : global::AmmoItem<global::AmmoItemDataBlock>, global::IAmmoItem, global::IInventoryItem
	{
		// Token: 0x0600345A RID: 13402 RVA: 0x000C8BF8 File Offset: 0x000C6DF8
		public ITEM_TYPE(global::AmmoItemDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000AE7 RID: 2791
		// (get) Token: 0x0600345B RID: 13403 RVA: 0x000C8C04 File Offset: 0x000C6E04
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x0600345C RID: 13404 RVA: 0x000C8C0C File Offset: 0x000C6E0C
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x0600345D RID: 13405 RVA: 0x000C8C14 File Offset: 0x000C6E14
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x0600345E RID: 13406 RVA: 0x000C8C1C File Offset: 0x000C6E1C
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x0600345F RID: 13407 RVA: 0x000C8C24 File Offset: 0x000C6E24
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x06003460 RID: 13408 RVA: 0x000C8C30 File Offset: 0x000C6E30
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x06003461 RID: 13409 RVA: 0x000C8C3C File Offset: 0x000C6E3C
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x06003462 RID: 13410 RVA: 0x000C8C48 File Offset: 0x000C6E48
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x06003463 RID: 13411 RVA: 0x000C8C54 File Offset: 0x000C6E54
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x06003464 RID: 13412 RVA: 0x000C8C60 File Offset: 0x000C6E60
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x06003465 RID: 13413 RVA: 0x000C8C6C File Offset: 0x000C6E6C
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x06003466 RID: 13414 RVA: 0x000C8C78 File Offset: 0x000C6E78
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x06003467 RID: 13415 RVA: 0x000C8C84 File Offset: 0x000C6E84
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x06003468 RID: 13416 RVA: 0x000C8C8C File Offset: 0x000C6E8C
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x06003469 RID: 13417 RVA: 0x000C8C98 File Offset: 0x000C6E98
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x0600346A RID: 13418 RVA: 0x000C8CA4 File Offset: 0x000C6EA4
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x0600346B RID: 13419 RVA: 0x000C8CAC File Offset: 0x000C6EAC
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x0600346C RID: 13420 RVA: 0x000C8CB4 File Offset: 0x000C6EB4
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x0600346D RID: 13421 RVA: 0x000C8CBC File Offset: 0x000C6EBC
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x0600346E RID: 13422 RVA: 0x000C8CC4 File Offset: 0x000C6EC4
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x0600346F RID: 13423 RVA: 0x000C8CCC File Offset: 0x000C6ECC
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x06003470 RID: 13424 RVA: 0x000C8CD4 File Offset: 0x000C6ED4
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x06003471 RID: 13425 RVA: 0x000C8CDC File Offset: 0x000C6EDC
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x06003472 RID: 13426 RVA: 0x000C8CE8 File Offset: 0x000C6EE8
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x06003473 RID: 13427 RVA: 0x000C8CF0 File Offset: 0x000C6EF0
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x06003474 RID: 13428 RVA: 0x000C8CF8 File Offset: 0x000C6EF8
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x06003475 RID: 13429 RVA: 0x000C8D00 File Offset: 0x000C6F00
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x06003476 RID: 13430 RVA: 0x000C8D08 File Offset: 0x000C6F08
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x06003477 RID: 13431 RVA: 0x000C8D10 File Offset: 0x000C6F10
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x06003478 RID: 13432 RVA: 0x000C8D18 File Offset: 0x000C6F18
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
