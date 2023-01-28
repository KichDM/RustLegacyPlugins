using System;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x02000674 RID: 1652
public class BasicHealthKitDataBlock : global::ItemDataBlock
{
	// Token: 0x060034E0 RID: 13536 RVA: 0x000C94D0 File Offset: 0x000C76D0
	public BasicHealthKitDataBlock()
	{
	}

	// Token: 0x060034E1 RID: 13537 RVA: 0x000C94F0 File Offset: 0x000C76F0
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::BasicHealthKitDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x060034E2 RID: 13538 RVA: 0x000C94F8 File Offset: 0x000C76F8
	public virtual global::IBasicHealthKit ItemAsHealthKit(global::IInventoryItem item)
	{
		return item as global::IBasicHealthKit;
	}

	// Token: 0x060034E3 RID: 13539 RVA: 0x000C9500 File Offset: 0x000C7700
	public override int RetreiveMenuOptions(global::IInventoryItem item, global::InventoryItem.MenuItem[] results, int offset)
	{
		offset = base.RetreiveMenuOptions(item, results, offset);
		if (item.isInLocalInventory)
		{
			results[offset++] = global::InventoryItem.MenuItem.Use;
		}
		return offset;
	}

	// Token: 0x060034E4 RID: 13540 RVA: 0x000C9530 File Offset: 0x000C7730
	public override global::InventoryItem.MenuItemResult ExecuteMenuOption(global::InventoryItem.MenuItem option, global::IInventoryItem item)
	{
		if (option != global::InventoryItem.MenuItem.Use)
		{
			return base.ExecuteMenuOption(option, item);
		}
		this.UseItem(item as global::IBasicHealthKit);
		return global::InventoryItem.MenuItemResult.DoneOnServer;
	}

	// Token: 0x060034E5 RID: 13541 RVA: 0x000C9564 File Offset: 0x000C7764
	public virtual void UseItem(global::IBasicHealthKit hk)
	{
		if (global::UnityEngine.Time.time < hk.lastUseTime + 5f)
		{
			return;
		}
		int slot = hk.slot;
		global::Inventory inventory = hk.inventory;
		global::HumanBodyTakeDamage local = inventory.GetLocal<global::HumanBodyTakeDamage>();
		if (!local)
		{
			return;
		}
		global::Metabolism local2 = inventory.GetLocal<global::Metabolism>();
		if (!local2)
		{
			return;
		}
		if (local.healthLoss == 0f)
		{
			return;
		}
		if (this.stopsBleeding)
		{
			local.Bandage(1000f);
		}
		float num = global::UnityEngine.Random.Range(this.healthAddMin, this.healthAddMax);
		if (num > 0f)
		{
			local.HealOverTime(num);
		}
		hk.lastUseTime = global::UnityEngine.Time.time;
		int num2 = 1;
		bool flag = hk.Consume(ref num2);
		if (num2 == 0)
		{
			inventory.MarkSlotDirty(slot);
			hk.FireClientSideItemEvent(global::InventoryItem.ItemEvent.Used);
		}
		if (flag)
		{
			inventory.RemoveItem(slot);
		}
	}

	// Token: 0x060034E6 RID: 13542 RVA: 0x000C9648 File Offset: 0x000C7848
	public override void PopulateInfoWindow(global::ItemToolTip infoWindow, global::IInventoryItem tipItem)
	{
		infoWindow.AddItemTitle(this, tipItem, 0f);
		infoWindow.AddSectionTitle("Medical", 15f);
		string text = string.Empty;
		if (this.healthAddMin == this.healthAddMax)
		{
			text = "Heals " + this.healthAddMin + " health.";
		}
		else
		{
			text = string.Concat(new object[]
			{
				"Heals ",
				this.healthAddMin,
				" to ",
				this.healthAddMax,
				" health."
			});
		}
		infoWindow.AddBasicLabel(text, 15f);
		infoWindow.FinishPopulating();
	}

	// Token: 0x060034E7 RID: 13543 RVA: 0x000C9700 File Offset: 0x000C7900
	public override string GetItemDescription()
	{
		return "This is a Medical item. Right click, or put in your belt and press the corresponding number key to use it.";
	}

	// Token: 0x04001D3A RID: 7482
	public float healthAddMin = 1f;

	// Token: 0x04001D3B RID: 7483
	public float healthAddMax = 1f;

	// Token: 0x04001D3C RID: 7484
	public bool stopsBleeding;

	// Token: 0x02000675 RID: 1653
	private sealed class ITEM_TYPE : global::BasicHealthKit<global::BasicHealthKitDataBlock>, global::IBasicHealthKit, global::IInventoryItem
	{
		// Token: 0x060034E8 RID: 13544 RVA: 0x000C9708 File Offset: 0x000C7908
		public ITEM_TYPE(global::BasicHealthKitDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000AEA RID: 2794
		// (get) Token: 0x060034E9 RID: 13545 RVA: 0x000C9714 File Offset: 0x000C7914
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x060034EA RID: 13546 RVA: 0x000C971C File Offset: 0x000C791C
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x060034EB RID: 13547 RVA: 0x000C9724 File Offset: 0x000C7924
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x060034EC RID: 13548 RVA: 0x000C972C File Offset: 0x000C792C
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x060034ED RID: 13549 RVA: 0x000C9734 File Offset: 0x000C7934
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x060034EE RID: 13550 RVA: 0x000C9740 File Offset: 0x000C7940
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x060034EF RID: 13551 RVA: 0x000C974C File Offset: 0x000C794C
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x060034F0 RID: 13552 RVA: 0x000C9758 File Offset: 0x000C7958
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x060034F1 RID: 13553 RVA: 0x000C9764 File Offset: 0x000C7964
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x060034F2 RID: 13554 RVA: 0x000C9770 File Offset: 0x000C7970
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x060034F3 RID: 13555 RVA: 0x000C977C File Offset: 0x000C797C
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x060034F4 RID: 13556 RVA: 0x000C9788 File Offset: 0x000C7988
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x060034F5 RID: 13557 RVA: 0x000C9794 File Offset: 0x000C7994
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x060034F6 RID: 13558 RVA: 0x000C979C File Offset: 0x000C799C
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x060034F7 RID: 13559 RVA: 0x000C97A8 File Offset: 0x000C79A8
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x060034F8 RID: 13560 RVA: 0x000C97B4 File Offset: 0x000C79B4
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x060034F9 RID: 13561 RVA: 0x000C97BC File Offset: 0x000C79BC
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x060034FA RID: 13562 RVA: 0x000C97C4 File Offset: 0x000C79C4
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x060034FB RID: 13563 RVA: 0x000C97CC File Offset: 0x000C79CC
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x060034FC RID: 13564 RVA: 0x000C97D4 File Offset: 0x000C79D4
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x060034FD RID: 13565 RVA: 0x000C97DC File Offset: 0x000C79DC
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x060034FE RID: 13566 RVA: 0x000C97E4 File Offset: 0x000C79E4
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x060034FF RID: 13567 RVA: 0x000C97EC File Offset: 0x000C79EC
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x06003500 RID: 13568 RVA: 0x000C97F8 File Offset: 0x000C79F8
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x06003501 RID: 13569 RVA: 0x000C9800 File Offset: 0x000C7A00
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x06003502 RID: 13570 RVA: 0x000C9808 File Offset: 0x000C7A08
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x06003503 RID: 13571 RVA: 0x000C9810 File Offset: 0x000C7A10
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x06003504 RID: 13572 RVA: 0x000C9818 File Offset: 0x000C7A18
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x06003505 RID: 13573 RVA: 0x000C9820 File Offset: 0x000C7A20
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x06003506 RID: 13574 RVA: 0x000C9828 File Offset: 0x000C7A28
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
