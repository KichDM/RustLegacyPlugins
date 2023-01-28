using System;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x02000676 RID: 1654
public class BasicTorchItemDataBlock : global::HeldItemDataBlock
{
	// Token: 0x06003507 RID: 13575 RVA: 0x000C9830 File Offset: 0x000C7A30
	public BasicTorchItemDataBlock()
	{
	}

	// Token: 0x06003508 RID: 13576 RVA: 0x000C9838 File Offset: 0x000C7A38
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::BasicTorchItemDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x06003509 RID: 13577 RVA: 0x000C9840 File Offset: 0x000C7A40
	public override void DoAction2(global::uLink.BitStream stream, global::ItemRepresentation itemRep, ref global::uLink.NetworkMessageInfo info)
	{
		itemRep.Action(2, 0xD);
	}

	// Token: 0x0600350A RID: 13578 RVA: 0x000C984C File Offset: 0x000C7A4C
	public override void DoAction3(global::uLink.BitStream stream, global::ItemRepresentation itemRep, ref global::uLink.NetworkMessageInfo info)
	{
		itemRep.Action(3, 0xD);
	}

	// Token: 0x04001D3D RID: 7485
	public global::UnityEngine.GameObject FirstPersonLightPrefab;

	// Token: 0x04001D3E RID: 7486
	public global::UnityEngine.GameObject ThirdPersonLightPrefab;

	// Token: 0x02000677 RID: 1655
	private sealed class ITEM_TYPE : global::BasicTorchItem<global::BasicTorchItemDataBlock>, global::IBasicTorchItem, global::IHeldItem, global::IInventoryItem
	{
		// Token: 0x0600350B RID: 13579 RVA: 0x000C9858 File Offset: 0x000C7A58
		public ITEM_TYPE(global::BasicTorchItemDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000AEB RID: 2795
		// (get) Token: 0x0600350C RID: 13580 RVA: 0x000C9864 File Offset: 0x000C7A64
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x0600350D RID: 13581 RVA: 0x000C986C File Offset: 0x000C7A6C
		void Ignite()
		{
			base.Ignite();
		}

		// Token: 0x0600350E RID: 13582 RVA: 0x000C9874 File Offset: 0x000C7A74
		bool get_isLit()
		{
			return base.isLit;
		}

		// Token: 0x0600350F RID: 13583 RVA: 0x000C987C File Offset: 0x000C7A7C
		void set_isLit(bool value)
		{
			base.isLit = value;
		}

		// Token: 0x06003510 RID: 13584 RVA: 0x000C9888 File Offset: 0x000C7A88
		global::UnityEngine.GameObject get_light()
		{
			return base.light;
		}

		// Token: 0x06003511 RID: 13585 RVA: 0x000C9890 File Offset: 0x000C7A90
		void set_light(global::UnityEngine.GameObject value)
		{
			base.light = value;
		}

		// Token: 0x06003512 RID: 13586 RVA: 0x000C989C File Offset: 0x000C7A9C
		void SetTotalModSlotCount(int count)
		{
			base.SetTotalModSlotCount(count);
		}

		// Token: 0x06003513 RID: 13587 RVA: 0x000C98A8 File Offset: 0x000C7AA8
		void SetUsedModSlotCount(int count)
		{
			base.SetUsedModSlotCount(count);
		}

		// Token: 0x06003514 RID: 13588 RVA: 0x000C98B4 File Offset: 0x000C7AB4
		void AddMod(global::ItemModDataBlock mod)
		{
			base.AddMod(mod);
		}

		// Token: 0x06003515 RID: 13589 RVA: 0x000C98C0 File Offset: 0x000C7AC0
		int FindMod(global::ItemModDataBlock mod)
		{
			return base.FindMod(mod);
		}

		// Token: 0x06003516 RID: 13590 RVA: 0x000C98CC File Offset: 0x000C7ACC
		void OnActivate()
		{
			base.OnActivate();
		}

		// Token: 0x06003517 RID: 13591 RVA: 0x000C98D4 File Offset: 0x000C7AD4
		void OnDeactivate()
		{
			base.OnDeactivate();
		}

		// Token: 0x06003518 RID: 13592 RVA: 0x000C98DC File Offset: 0x000C7ADC
		global::ViewModel get_viewModelInstance()
		{
			return base.viewModelInstance;
		}

		// Token: 0x06003519 RID: 13593 RVA: 0x000C98E4 File Offset: 0x000C7AE4
		global::ItemRepresentation get_itemRepresentation()
		{
			return base.itemRepresentation;
		}

		// Token: 0x0600351A RID: 13594 RVA: 0x000C98EC File Offset: 0x000C7AEC
		void set_itemRepresentation(global::ItemRepresentation value)
		{
			base.itemRepresentation = value;
		}

		// Token: 0x0600351B RID: 13595 RVA: 0x000C98F8 File Offset: 0x000C7AF8
		bool get_canActivate()
		{
			return base.canActivate;
		}

		// Token: 0x0600351C RID: 13596 RVA: 0x000C9900 File Offset: 0x000C7B00
		bool get_canDeactivate()
		{
			return base.canDeactivate;
		}

		// Token: 0x0600351D RID: 13597 RVA: 0x000C9908 File Offset: 0x000C7B08
		global::ItemModFlags get_modFlags()
		{
			return base.modFlags;
		}

		// Token: 0x0600351E RID: 13598 RVA: 0x000C9910 File Offset: 0x000C7B10
		global::ItemModDataBlock[] get_itemMods()
		{
			return base.itemMods;
		}

		// Token: 0x0600351F RID: 13599 RVA: 0x000C9918 File Offset: 0x000C7B18
		int get_totalModSlots()
		{
			return base.totalModSlots;
		}

		// Token: 0x06003520 RID: 13600 RVA: 0x000C9920 File Offset: 0x000C7B20
		int get_usedModSlots()
		{
			return base.usedModSlots;
		}

		// Token: 0x06003521 RID: 13601 RVA: 0x000C9928 File Offset: 0x000C7B28
		int get_freeModSlots()
		{
			return base.freeModSlots;
		}

		// Token: 0x06003522 RID: 13602 RVA: 0x000C9930 File Offset: 0x000C7B30
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x06003523 RID: 13603 RVA: 0x000C9938 File Offset: 0x000C7B38
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x06003524 RID: 13604 RVA: 0x000C9940 File Offset: 0x000C7B40
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x06003525 RID: 13605 RVA: 0x000C9948 File Offset: 0x000C7B48
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x06003526 RID: 13606 RVA: 0x000C9954 File Offset: 0x000C7B54
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x06003527 RID: 13607 RVA: 0x000C9960 File Offset: 0x000C7B60
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x06003528 RID: 13608 RVA: 0x000C996C File Offset: 0x000C7B6C
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x06003529 RID: 13609 RVA: 0x000C9978 File Offset: 0x000C7B78
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x0600352A RID: 13610 RVA: 0x000C9984 File Offset: 0x000C7B84
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x0600352B RID: 13611 RVA: 0x000C9990 File Offset: 0x000C7B90
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x0600352C RID: 13612 RVA: 0x000C999C File Offset: 0x000C7B9C
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x0600352D RID: 13613 RVA: 0x000C99A8 File Offset: 0x000C7BA8
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x0600352E RID: 13614 RVA: 0x000C99B0 File Offset: 0x000C7BB0
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x0600352F RID: 13615 RVA: 0x000C99BC File Offset: 0x000C7BBC
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x06003530 RID: 13616 RVA: 0x000C99C8 File Offset: 0x000C7BC8
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x06003531 RID: 13617 RVA: 0x000C99D0 File Offset: 0x000C7BD0
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x06003532 RID: 13618 RVA: 0x000C99D8 File Offset: 0x000C7BD8
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x06003533 RID: 13619 RVA: 0x000C99E0 File Offset: 0x000C7BE0
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x06003534 RID: 13620 RVA: 0x000C99E8 File Offset: 0x000C7BE8
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x06003535 RID: 13621 RVA: 0x000C99F0 File Offset: 0x000C7BF0
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x06003536 RID: 13622 RVA: 0x000C99F8 File Offset: 0x000C7BF8
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x06003537 RID: 13623 RVA: 0x000C9A00 File Offset: 0x000C7C00
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x06003538 RID: 13624 RVA: 0x000C9A0C File Offset: 0x000C7C0C
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x06003539 RID: 13625 RVA: 0x000C9A14 File Offset: 0x000C7C14
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x0600353A RID: 13626 RVA: 0x000C9A1C File Offset: 0x000C7C1C
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x0600353B RID: 13627 RVA: 0x000C9A24 File Offset: 0x000C7C24
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x0600353C RID: 13628 RVA: 0x000C9A2C File Offset: 0x000C7C2C
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x0600353D RID: 13629 RVA: 0x000C9A34 File Offset: 0x000C7C34
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x0600353E RID: 13630 RVA: 0x000C9A3C File Offset: 0x000C7C3C
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
