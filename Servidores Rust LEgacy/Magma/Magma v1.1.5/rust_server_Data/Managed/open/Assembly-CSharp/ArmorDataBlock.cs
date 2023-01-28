using System;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x02000670 RID: 1648
public class ArmorDataBlock : global::EquipmentDataBlock
{
	// Token: 0x06003479 RID: 13433 RVA: 0x000C8D20 File Offset: 0x000C6F20
	public ArmorDataBlock()
	{
	}

	// Token: 0x0600347A RID: 13434 RVA: 0x000C8D28 File Offset: 0x000C6F28
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::ArmorDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x0600347B RID: 13435 RVA: 0x000C8D30 File Offset: 0x000C6F30
	public void AddToDamageTypeList(global::DamageTypeList damageList)
	{
		for (int i = 0; i < 6; i++)
		{
			int index2;
			int index = index2 = i;
			float num = damageList[index2];
			damageList[index] = num + this.armorValues[i];
		}
	}

	// Token: 0x0600347C RID: 13436 RVA: 0x000C8D70 File Offset: 0x000C6F70
	public TArmorModel GetArmorModel<TArmorModel>() where TArmorModel : global::ArmorModel, new()
	{
		return (TArmorModel)((object)this.GetArmorModel(global::ArmorModelSlotUtility.GetArmorModelSlotForClass<TArmorModel>()));
	}

	// Token: 0x0600347D RID: 13437 RVA: 0x000C8D84 File Offset: 0x000C6F84
	public global::ArmorModel GetArmorModel(global::ArmorModelSlot slot)
	{
		if (!this.armorModel)
		{
			global::UnityEngine.Debug.LogWarning("No armorModel set to datablock " + this, this);
			return null;
		}
		if (this.armorModel.slot != slot)
		{
			global::UnityEngine.Debug.LogError(string.Format("The armor model for {0} is {1}. Its not for slot {2}", this, this.armorModel.slot, slot), this);
			return null;
		}
		return this.armorModel;
	}

	// Token: 0x0600347E RID: 13438 RVA: 0x000C8DF4 File Offset: 0x000C6FF4
	public bool GetArmorModelSlot(out global::ArmorModelSlot slot)
	{
		if (!this.armorModel)
		{
			slot = (global::ArmorModelSlot)4;
		}
		else
		{
			slot = this.armorModel.slot;
		}
		return slot < (global::ArmorModelSlot)4;
	}

	// Token: 0x0600347F RID: 13439 RVA: 0x000C8E2C File Offset: 0x000C702C
	public override void PopulateInfoWindow(global::ItemToolTip infoWindow, global::IInventoryItem tipItem)
	{
		infoWindow.AddItemTitle(this, tipItem, 0f);
		infoWindow.AddConditionInfo(tipItem);
		infoWindow.AddSectionTitle("Protection", 0f);
		for (int i = 0; i < 6; i++)
		{
			if (this.armorValues[i] != 0f)
			{
				float contentHeight = infoWindow.GetContentHeight();
				global::UnityEngine.GameObject gameObject = infoWindow.AddBasicLabel(global::TakeDamage.DamageIndexToString((global::DamageTypeIndex)i), 0f);
				global::UnityEngine.GameObject gameObject2 = infoWindow.AddBasicLabel("+" + ((int)this.armorValues[i]).ToString("N0"), 0f);
				gameObject2.transform.SetLocalPositionX(145f);
				gameObject2.GetComponentInChildren<global::UILabel>().color = global::UnityEngine.Color.green;
				gameObject.transform.SetLocalPositionY(-(contentHeight + 10f));
				gameObject2.transform.SetLocalPositionY(-(contentHeight + 10f));
			}
		}
		infoWindow.AddSectionTitle("Equipment Slot", 20f);
		string text = "Head, Chest, Legs, Feet";
		if ((this._itemFlags & global::Inventory.SlotFlags.Head) == global::Inventory.SlotFlags.Head)
		{
			text = "Head";
		}
		else if ((this._itemFlags & global::Inventory.SlotFlags.Chest) == global::Inventory.SlotFlags.Chest)
		{
			text = "Chest";
		}
		infoWindow.AddBasicLabel(text, 10f);
		infoWindow.AddItemDescription(this, 15f);
		infoWindow.FinishPopulating();
	}

	// Token: 0x06003480 RID: 13440 RVA: 0x000C8F84 File Offset: 0x000C7184
	public override void OnEquipped(global::IEquipmentItem item)
	{
		item.FireClientSideItemEvent(global::InventoryItem.ItemEvent.Equipped);
	}

	// Token: 0x06003481 RID: 13441 RVA: 0x000C8F90 File Offset: 0x000C7190
	public override void OnUnEquipped(global::IEquipmentItem item)
	{
		item.FireClientSideItemEvent(global::InventoryItem.ItemEvent.UnEquipped);
	}

	// Token: 0x06003482 RID: 13442 RVA: 0x000C8F9C File Offset: 0x000C719C
	public override string GetItemDescription()
	{
		return "This is an piece of armor. Drag it to it's corresponding slot in the armor window and it will provide additional protection";
	}

	// Token: 0x04001D33 RID: 7475
	public global::DamageTypeList armorValues;

	// Token: 0x04001D34 RID: 7476
	[global::UnityEngine.SerializeField]
	protected global::ArmorModel armorModel;

	// Token: 0x02000671 RID: 1649
	private sealed class ITEM_TYPE : global::ArmorItem<global::ArmorDataBlock>, global::IArmorItem, global::IEquipmentItem, global::IInventoryItem
	{
		// Token: 0x06003483 RID: 13443 RVA: 0x000C8FA4 File Offset: 0x000C71A4
		public ITEM_TYPE(global::ArmorDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000AE8 RID: 2792
		// (get) Token: 0x06003484 RID: 13444 RVA: 0x000C8FB0 File Offset: 0x000C71B0
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x06003485 RID: 13445 RVA: 0x000C8FB8 File Offset: 0x000C71B8
		void OnUnEquipped()
		{
			base.OnUnEquipped();
		}

		// Token: 0x06003486 RID: 13446 RVA: 0x000C8FC0 File Offset: 0x000C71C0
		void OnEquipped()
		{
			base.OnEquipped();
		}

		// Token: 0x06003487 RID: 13447 RVA: 0x000C8FC8 File Offset: 0x000C71C8
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x06003488 RID: 13448 RVA: 0x000C8FD0 File Offset: 0x000C71D0
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x06003489 RID: 13449 RVA: 0x000C8FD8 File Offset: 0x000C71D8
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x0600348A RID: 13450 RVA: 0x000C8FE0 File Offset: 0x000C71E0
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x0600348B RID: 13451 RVA: 0x000C8FEC File Offset: 0x000C71EC
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x0600348C RID: 13452 RVA: 0x000C8FF8 File Offset: 0x000C71F8
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x0600348D RID: 13453 RVA: 0x000C9004 File Offset: 0x000C7204
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x0600348E RID: 13454 RVA: 0x000C9010 File Offset: 0x000C7210
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x0600348F RID: 13455 RVA: 0x000C901C File Offset: 0x000C721C
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x06003490 RID: 13456 RVA: 0x000C9028 File Offset: 0x000C7228
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x06003491 RID: 13457 RVA: 0x000C9034 File Offset: 0x000C7234
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x06003492 RID: 13458 RVA: 0x000C9040 File Offset: 0x000C7240
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x06003493 RID: 13459 RVA: 0x000C9048 File Offset: 0x000C7248
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x06003494 RID: 13460 RVA: 0x000C9054 File Offset: 0x000C7254
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x06003495 RID: 13461 RVA: 0x000C9060 File Offset: 0x000C7260
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x06003496 RID: 13462 RVA: 0x000C9068 File Offset: 0x000C7268
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x06003497 RID: 13463 RVA: 0x000C9070 File Offset: 0x000C7270
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x06003498 RID: 13464 RVA: 0x000C9078 File Offset: 0x000C7278
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x06003499 RID: 13465 RVA: 0x000C9080 File Offset: 0x000C7280
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x0600349A RID: 13466 RVA: 0x000C9088 File Offset: 0x000C7288
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x0600349B RID: 13467 RVA: 0x000C9090 File Offset: 0x000C7290
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x0600349C RID: 13468 RVA: 0x000C9098 File Offset: 0x000C7298
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x0600349D RID: 13469 RVA: 0x000C90A4 File Offset: 0x000C72A4
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x0600349E RID: 13470 RVA: 0x000C90AC File Offset: 0x000C72AC
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x0600349F RID: 13471 RVA: 0x000C90B4 File Offset: 0x000C72B4
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x060034A0 RID: 13472 RVA: 0x000C90BC File Offset: 0x000C72BC
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x060034A1 RID: 13473 RVA: 0x000C90C4 File Offset: 0x000C72C4
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x060034A2 RID: 13474 RVA: 0x000C90CC File Offset: 0x000C72CC
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x060034A3 RID: 13475 RVA: 0x000C90D4 File Offset: 0x000C72D4
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
