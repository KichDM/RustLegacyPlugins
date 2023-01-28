using System;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x02000672 RID: 1650
public class BandageDataBlock : global::HeldItemDataBlock
{
	// Token: 0x060034A4 RID: 13476 RVA: 0x000C90DC File Offset: 0x000C72DC
	public BandageDataBlock()
	{
	}

	// Token: 0x060034A5 RID: 13477 RVA: 0x000C911C File Offset: 0x000C731C
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::BandageDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x060034A6 RID: 13478 RVA: 0x000C9124 File Offset: 0x000C7324
	public bool DoesGiveBlood()
	{
		return this.bloodAddMax > 0f;
	}

	// Token: 0x060034A7 RID: 13479 RVA: 0x000C9134 File Offset: 0x000C7334
	public bool DoesBandage()
	{
		return this.bandageAmount > 0f;
	}

	// Token: 0x060034A8 RID: 13480 RVA: 0x000C9144 File Offset: 0x000C7344
	public override int RetreiveMenuOptions(global::IInventoryItem item, global::InventoryItem.MenuItem[] results, int offset)
	{
		offset = base.RetreiveMenuOptions(item, results, offset);
		if (item.isInLocalInventory)
		{
			results[offset++] = global::InventoryItem.MenuItem.Use;
		}
		return offset;
	}

	// Token: 0x060034A9 RID: 13481 RVA: 0x000C9174 File Offset: 0x000C7374
	public override void DoAction3(global::uLink.BitStream stream, global::ItemRepresentation itemRep, ref global::uLink.NetworkMessageInfo info)
	{
		global::NetCull.VerifyRPC(ref info, false);
		global::IBandageItem bandageItem;
		if (!itemRep.Item<global::IBandageItem>(out bandageItem))
		{
			return;
		}
		global::Inventory inventory = bandageItem.inventory;
		global::HumanBodyTakeDamage local = inventory.GetLocal<global::HumanBodyTakeDamage>();
		if (this.bandageAmount > 0f)
		{
			local.Bandage(this.bandageAmount);
		}
		if (this.bloodAddMax > 0f && this.bloodAddMax > 0f)
		{
			local.Heal(inventory, global::UnityEngine.Random.Range(this.bloodAddMin, this.bloodAddMax));
		}
		int slot = bandageItem.slot;
		int num = 1;
		if (bandageItem.Consume(ref num))
		{
			inventory.RemoveItem(slot);
		}
		inventory.MarkSlotDirty(slot);
	}

	// Token: 0x060034AA RID: 13482 RVA: 0x000C9220 File Offset: 0x000C7420
	public override void PopulateInfoWindow(global::ItemToolTip infoWindow, global::IInventoryItem tipItem)
	{
		infoWindow.AddItemTitle(this, tipItem, 0f);
		infoWindow.AddSectionTitle("Medical", 15f);
		string text = string.Empty;
		if (this.bloodAddMin == this.bloodAddMax)
		{
			text = "Heals " + this.bloodAddMin + " health.";
		}
		else
		{
			text = string.Concat(new object[]
			{
				"Heals ",
				this.bloodAddMin,
				" to ",
				this.bloodAddMax,
				" health."
			});
		}
		infoWindow.AddBasicLabel(text, 15f);
		infoWindow.FinishPopulating();
	}

	// Token: 0x04001D35 RID: 7477
	public float bandageDuration = 3f;

	// Token: 0x04001D36 RID: 7478
	public float bandageStartTime;

	// Token: 0x04001D37 RID: 7479
	public float bandageAmount = 100f;

	// Token: 0x04001D38 RID: 7480
	public float bloodAddMin = 20f;

	// Token: 0x04001D39 RID: 7481
	public float bloodAddMax = 30f;

	// Token: 0x02000673 RID: 1651
	private sealed class ITEM_TYPE : global::BandageItem<global::BandageDataBlock>, global::IBandageItem, global::IHeldItem, global::IInventoryItem
	{
		// Token: 0x060034AB RID: 13483 RVA: 0x000C92D8 File Offset: 0x000C74D8
		public ITEM_TYPE(global::BandageDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000AE9 RID: 2793
		// (get) Token: 0x060034AC RID: 13484 RVA: 0x000C92E4 File Offset: 0x000C74E4
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x060034AD RID: 13485 RVA: 0x000C92EC File Offset: 0x000C74EC
		float get_bandageStartTime()
		{
			return base.bandageStartTime;
		}

		// Token: 0x060034AE RID: 13486 RVA: 0x000C92F4 File Offset: 0x000C74F4
		void set_bandageStartTime(float value)
		{
			base.bandageStartTime = value;
		}

		// Token: 0x060034AF RID: 13487 RVA: 0x000C9300 File Offset: 0x000C7500
		bool get_lastFramePrimary()
		{
			return base.lastFramePrimary;
		}

		// Token: 0x060034B0 RID: 13488 RVA: 0x000C9308 File Offset: 0x000C7508
		void set_lastFramePrimary(bool value)
		{
			base.lastFramePrimary = value;
		}

		// Token: 0x060034B1 RID: 13489 RVA: 0x000C9314 File Offset: 0x000C7514
		float get_lastBandageTime()
		{
			return base.lastBandageTime;
		}

		// Token: 0x060034B2 RID: 13490 RVA: 0x000C931C File Offset: 0x000C751C
		void set_lastBandageTime(float value)
		{
			base.lastBandageTime = value;
		}

		// Token: 0x060034B3 RID: 13491 RVA: 0x000C9328 File Offset: 0x000C7528
		void SetTotalModSlotCount(int count)
		{
			base.SetTotalModSlotCount(count);
		}

		// Token: 0x060034B4 RID: 13492 RVA: 0x000C9334 File Offset: 0x000C7534
		void SetUsedModSlotCount(int count)
		{
			base.SetUsedModSlotCount(count);
		}

		// Token: 0x060034B5 RID: 13493 RVA: 0x000C9340 File Offset: 0x000C7540
		void AddMod(global::ItemModDataBlock mod)
		{
			base.AddMod(mod);
		}

		// Token: 0x060034B6 RID: 13494 RVA: 0x000C934C File Offset: 0x000C754C
		int FindMod(global::ItemModDataBlock mod)
		{
			return base.FindMod(mod);
		}

		// Token: 0x060034B7 RID: 13495 RVA: 0x000C9358 File Offset: 0x000C7558
		void OnActivate()
		{
			base.OnActivate();
		}

		// Token: 0x060034B8 RID: 13496 RVA: 0x000C9360 File Offset: 0x000C7560
		void OnDeactivate()
		{
			base.OnDeactivate();
		}

		// Token: 0x060034B9 RID: 13497 RVA: 0x000C9368 File Offset: 0x000C7568
		global::ViewModel get_viewModelInstance()
		{
			return base.viewModelInstance;
		}

		// Token: 0x060034BA RID: 13498 RVA: 0x000C9370 File Offset: 0x000C7570
		global::ItemRepresentation get_itemRepresentation()
		{
			return base.itemRepresentation;
		}

		// Token: 0x060034BB RID: 13499 RVA: 0x000C9378 File Offset: 0x000C7578
		void set_itemRepresentation(global::ItemRepresentation value)
		{
			base.itemRepresentation = value;
		}

		// Token: 0x060034BC RID: 13500 RVA: 0x000C9384 File Offset: 0x000C7584
		bool get_canActivate()
		{
			return base.canActivate;
		}

		// Token: 0x060034BD RID: 13501 RVA: 0x000C938C File Offset: 0x000C758C
		bool get_canDeactivate()
		{
			return base.canDeactivate;
		}

		// Token: 0x060034BE RID: 13502 RVA: 0x000C9394 File Offset: 0x000C7594
		global::ItemModFlags get_modFlags()
		{
			return base.modFlags;
		}

		// Token: 0x060034BF RID: 13503 RVA: 0x000C939C File Offset: 0x000C759C
		global::ItemModDataBlock[] get_itemMods()
		{
			return base.itemMods;
		}

		// Token: 0x060034C0 RID: 13504 RVA: 0x000C93A4 File Offset: 0x000C75A4
		int get_totalModSlots()
		{
			return base.totalModSlots;
		}

		// Token: 0x060034C1 RID: 13505 RVA: 0x000C93AC File Offset: 0x000C75AC
		int get_usedModSlots()
		{
			return base.usedModSlots;
		}

		// Token: 0x060034C2 RID: 13506 RVA: 0x000C93B4 File Offset: 0x000C75B4
		int get_freeModSlots()
		{
			return base.freeModSlots;
		}

		// Token: 0x060034C3 RID: 13507 RVA: 0x000C93BC File Offset: 0x000C75BC
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x060034C4 RID: 13508 RVA: 0x000C93C4 File Offset: 0x000C75C4
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x060034C5 RID: 13509 RVA: 0x000C93CC File Offset: 0x000C75CC
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x060034C6 RID: 13510 RVA: 0x000C93D4 File Offset: 0x000C75D4
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x060034C7 RID: 13511 RVA: 0x000C93E0 File Offset: 0x000C75E0
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x060034C8 RID: 13512 RVA: 0x000C93EC File Offset: 0x000C75EC
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x060034C9 RID: 13513 RVA: 0x000C93F8 File Offset: 0x000C75F8
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x060034CA RID: 13514 RVA: 0x000C9404 File Offset: 0x000C7604
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x060034CB RID: 13515 RVA: 0x000C9410 File Offset: 0x000C7610
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x060034CC RID: 13516 RVA: 0x000C941C File Offset: 0x000C761C
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x060034CD RID: 13517 RVA: 0x000C9428 File Offset: 0x000C7628
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x060034CE RID: 13518 RVA: 0x000C9434 File Offset: 0x000C7634
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x060034CF RID: 13519 RVA: 0x000C943C File Offset: 0x000C763C
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x060034D0 RID: 13520 RVA: 0x000C9448 File Offset: 0x000C7648
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x060034D1 RID: 13521 RVA: 0x000C9454 File Offset: 0x000C7654
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x060034D2 RID: 13522 RVA: 0x000C945C File Offset: 0x000C765C
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x060034D3 RID: 13523 RVA: 0x000C9464 File Offset: 0x000C7664
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x060034D4 RID: 13524 RVA: 0x000C946C File Offset: 0x000C766C
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x060034D5 RID: 13525 RVA: 0x000C9474 File Offset: 0x000C7674
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x060034D6 RID: 13526 RVA: 0x000C947C File Offset: 0x000C767C
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x060034D7 RID: 13527 RVA: 0x000C9484 File Offset: 0x000C7684
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x060034D8 RID: 13528 RVA: 0x000C948C File Offset: 0x000C768C
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x060034D9 RID: 13529 RVA: 0x000C9498 File Offset: 0x000C7698
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x060034DA RID: 13530 RVA: 0x000C94A0 File Offset: 0x000C76A0
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x060034DB RID: 13531 RVA: 0x000C94A8 File Offset: 0x000C76A8
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x060034DC RID: 13532 RVA: 0x000C94B0 File Offset: 0x000C76B0
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x060034DD RID: 13533 RVA: 0x000C94B8 File Offset: 0x000C76B8
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x060034DE RID: 13534 RVA: 0x000C94C0 File Offset: 0x000C76C0
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x060034DF RID: 13535 RVA: 0x000C94C8 File Offset: 0x000C76C8
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
