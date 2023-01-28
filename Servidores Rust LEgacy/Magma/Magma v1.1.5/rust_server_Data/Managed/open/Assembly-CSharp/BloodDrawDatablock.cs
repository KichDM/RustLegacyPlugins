using System;
using Rust;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x02000678 RID: 1656
public class BloodDrawDatablock : global::ItemDataBlock
{
	// Token: 0x0600353F RID: 13631 RVA: 0x000C9A44 File Offset: 0x000C7C44
	public BloodDrawDatablock()
	{
	}

	// Token: 0x06003540 RID: 13632 RVA: 0x000C9A58 File Offset: 0x000C7C58
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::BloodDrawDatablock.ITEM_TYPE(this);
	}

	// Token: 0x06003541 RID: 13633 RVA: 0x000C9A60 File Offset: 0x000C7C60
	public override int RetreiveMenuOptions(global::IInventoryItem item, global::InventoryItem.MenuItem[] results, int offset)
	{
		offset = base.RetreiveMenuOptions(item, results, offset);
		if (item.isInLocalInventory)
		{
			results[offset++] = global::InventoryItem.MenuItem.Use;
		}
		return offset;
	}

	// Token: 0x06003542 RID: 13634 RVA: 0x000C9A90 File Offset: 0x000C7C90
	public override global::InventoryItem.MenuItemResult ExecuteMenuOption(global::InventoryItem.MenuItem option, global::IInventoryItem item)
	{
		if (option != global::InventoryItem.MenuItem.Use)
		{
			return base.ExecuteMenuOption(option, item);
		}
		this.UseItem(item as global::IBloodDrawItem);
		return global::InventoryItem.MenuItemResult.DoneOnServer;
	}

	// Token: 0x06003543 RID: 13635 RVA: 0x000C9AC4 File Offset: 0x000C7CC4
	public virtual void UseItem(global::IBloodDrawItem draw)
	{
		if (global::UnityEngine.Time.time < draw.lastUseTime + 2f)
		{
			return;
		}
		global::Inventory inventory = draw.inventory;
		global::HumanBodyTakeDamage local = inventory.GetLocal<global::HumanBodyTakeDamage>();
		if (local.health <= this.bloodToTake)
		{
			global::Rust.Notice.Popup(inventory.networkView.owner, "", "You're too weak to use this", 4f);
			return;
		}
		global::IDMain idMain = inventory.idMain;
		global::TakeDamage.Hurt(idMain, idMain, this.bloodToTake, null);
		inventory.AddItem(ref global::BloodDrawDatablock.LateLoaded.blood, global::Inventory.Slot.Preference.Define(global::Inventory.Slot.Kind.Default, true, global::Inventory.Slot.KindFlags.Belt), 1);
		draw.lastUseTime = global::UnityEngine.Time.time;
		draw.FireClientSideItemEvent(global::InventoryItem.ItemEvent.Used);
	}

	// Token: 0x06003544 RID: 13636 RVA: 0x000C9B70 File Offset: 0x000C7D70
	public override string GetItemDescription()
	{
		return "Used to extract your own blood, perhaps to make a medkit";
	}

	// Token: 0x04001D3F RID: 7487
	public float bloodToTake = 25f;

	// Token: 0x02000679 RID: 1657
	private sealed class ITEM_TYPE : global::BloodDrawItem<global::BloodDrawDatablock>, global::IBloodDrawItem, global::IInventoryItem
	{
		// Token: 0x06003545 RID: 13637 RVA: 0x000C9B78 File Offset: 0x000C7D78
		public ITEM_TYPE(global::BloodDrawDatablock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000AEC RID: 2796
		// (get) Token: 0x06003546 RID: 13638 RVA: 0x000C9B84 File Offset: 0x000C7D84
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x06003547 RID: 13639 RVA: 0x000C9B8C File Offset: 0x000C7D8C
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x06003548 RID: 13640 RVA: 0x000C9B94 File Offset: 0x000C7D94
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x06003549 RID: 13641 RVA: 0x000C9B9C File Offset: 0x000C7D9C
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x0600354A RID: 13642 RVA: 0x000C9BA4 File Offset: 0x000C7DA4
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x0600354B RID: 13643 RVA: 0x000C9BB0 File Offset: 0x000C7DB0
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x0600354C RID: 13644 RVA: 0x000C9BBC File Offset: 0x000C7DBC
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x0600354D RID: 13645 RVA: 0x000C9BC8 File Offset: 0x000C7DC8
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x0600354E RID: 13646 RVA: 0x000C9BD4 File Offset: 0x000C7DD4
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x0600354F RID: 13647 RVA: 0x000C9BE0 File Offset: 0x000C7DE0
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x06003550 RID: 13648 RVA: 0x000C9BEC File Offset: 0x000C7DEC
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x06003551 RID: 13649 RVA: 0x000C9BF8 File Offset: 0x000C7DF8
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x06003552 RID: 13650 RVA: 0x000C9C04 File Offset: 0x000C7E04
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x06003553 RID: 13651 RVA: 0x000C9C0C File Offset: 0x000C7E0C
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x06003554 RID: 13652 RVA: 0x000C9C18 File Offset: 0x000C7E18
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x06003555 RID: 13653 RVA: 0x000C9C24 File Offset: 0x000C7E24
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x06003556 RID: 13654 RVA: 0x000C9C2C File Offset: 0x000C7E2C
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x06003557 RID: 13655 RVA: 0x000C9C34 File Offset: 0x000C7E34
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x06003558 RID: 13656 RVA: 0x000C9C3C File Offset: 0x000C7E3C
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x06003559 RID: 13657 RVA: 0x000C9C44 File Offset: 0x000C7E44
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x0600355A RID: 13658 RVA: 0x000C9C4C File Offset: 0x000C7E4C
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x0600355B RID: 13659 RVA: 0x000C9C54 File Offset: 0x000C7E54
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x0600355C RID: 13660 RVA: 0x000C9C5C File Offset: 0x000C7E5C
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x0600355D RID: 13661 RVA: 0x000C9C68 File Offset: 0x000C7E68
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x0600355E RID: 13662 RVA: 0x000C9C70 File Offset: 0x000C7E70
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x0600355F RID: 13663 RVA: 0x000C9C78 File Offset: 0x000C7E78
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x06003560 RID: 13664 RVA: 0x000C9C80 File Offset: 0x000C7E80
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x06003561 RID: 13665 RVA: 0x000C9C88 File Offset: 0x000C7E88
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x06003562 RID: 13666 RVA: 0x000C9C90 File Offset: 0x000C7E90
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x06003563 RID: 13667 RVA: 0x000C9C98 File Offset: 0x000C7E98
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}

	// Token: 0x0200067A RID: 1658
	private static class LateLoaded
	{
		// Token: 0x06003564 RID: 13668 RVA: 0x000C9CA0 File Offset: 0x000C7EA0
		// Note: this type is marked as 'beforefieldinit'.
		static LateLoaded()
		{
		}

		// Token: 0x04001D40 RID: 7488
		public static global::Datablock.Ident blood = "Blood";
	}
}
