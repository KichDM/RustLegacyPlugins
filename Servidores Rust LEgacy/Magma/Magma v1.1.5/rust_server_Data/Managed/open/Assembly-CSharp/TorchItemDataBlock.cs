using System;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x020006BC RID: 1724
public class TorchItemDataBlock : global::ThrowableItemDataBlock
{
	// Token: 0x06003A6D RID: 14957 RVA: 0x000D1270 File Offset: 0x000CF470
	public TorchItemDataBlock()
	{
	}

	// Token: 0x06003A6E RID: 14958 RVA: 0x000D1278 File Offset: 0x000CF478
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::TorchItemDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x06003A6F RID: 14959 RVA: 0x000D1280 File Offset: 0x000CF480
	public global::ITorchItem GetTorchInstance(global::IThrowableItem itemInstance)
	{
		return itemInstance as global::ITorchItem;
	}

	// Token: 0x06003A70 RID: 14960 RVA: 0x000D1288 File Offset: 0x000CF488
	public global::TorchItemRep GetTorchRep(global::ItemRepresentation rep)
	{
		return rep as global::TorchItemRep;
	}

	// Token: 0x06003A71 RID: 14961 RVA: 0x000D1290 File Offset: 0x000CF490
	public override void PrimaryAttack(global::ViewModel vm, global::ItemRepresentation itemRep, global::IThrowableItem itemInstance, ref global::HumanController.InputSample sample)
	{
		global::ITorchItem torchInstance = this.GetTorchInstance(itemInstance);
		if (torchInstance.isLit)
		{
			return;
		}
		torchInstance.realIgniteTime = global::UnityEngine.Time.time + 0.8f;
		torchInstance.nextPrimaryAttackTime = global::UnityEngine.Time.time + 1.5f;
		torchInstance.nextSecondaryAttackTime = global::UnityEngine.Time.time + 1.5f;
	}

	// Token: 0x06003A72 RID: 14962 RVA: 0x000D12E4 File Offset: 0x000CF4E4
	public override void SecondaryAttack(global::ViewModel vm, global::ItemRepresentation itemRep, global::IThrowableItem itemInstance, ref global::HumanController.InputSample sample)
	{
		global::ITorchItem torchInstance = this.GetTorchInstance(itemInstance);
		if (!torchInstance.isLit)
		{
			this.PrimaryAttack(vm, itemRep, itemInstance, ref sample);
			torchInstance.forceSecondaryTime = global::UnityEngine.Time.time + 1.51f;
			return;
		}
		torchInstance.realThrowTime = global::UnityEngine.Time.time + 0.5f;
		torchInstance.nextPrimaryAttackTime = global::UnityEngine.Time.time + 1.5f;
		torchInstance.nextSecondaryAttackTime = global::UnityEngine.Time.time + 1.5f;
	}

	// Token: 0x06003A73 RID: 14963 RVA: 0x000D1354 File Offset: 0x000CF554
	public override void DoAction2(global::uLink.BitStream stream, global::ItemRepresentation itemRep, ref global::uLink.NetworkMessageInfo info)
	{
		global::ITorchItem torchItem;
		if (itemRep.Item<global::ITorchItem>(out torchItem))
		{
			torchItem.Ignite();
			itemRep.Action(2, 0xD);
		}
	}

	// Token: 0x06003A74 RID: 14964 RVA: 0x000D1380 File Offset: 0x000CF580
	public override void DoAction1(global::uLink.BitStream stream, global::ItemRepresentation rep, ref global::uLink.NetworkMessageInfo info)
	{
		global::NetCull.VerifyRPC(ref info, false);
		global::ITorchItem torchItem;
		if (!rep.Item<global::ITorchItem>(out torchItem) || !torchItem.ValidatePrimaryMessageTime(info.timestamp))
		{
			return;
		}
		if (torchItem.isLit)
		{
			torchItem.Extinguish();
		}
		rep.ActionStream(1, 0xA, stream);
		global::UnityEngine.Vector3 origin = stream.ReadVector3();
		global::UnityEngine.Vector3 forward = stream.ReadVector3();
		this.ThrowFlare(rep, origin, forward);
		int num = 1;
		if (torchItem.Consume(ref num))
		{
			torchItem.inventory.RemoveItem(torchItem.slot);
		}
	}

	// Token: 0x06003A75 RID: 14965 RVA: 0x000D1408 File Offset: 0x000CF608
	public override void DoAction3(global::uLink.BitStream stream, global::ItemRepresentation itemRep, ref global::uLink.NetworkMessageInfo info)
	{
		itemRep.Action(3, 0xA);
	}

	// Token: 0x06003A76 RID: 14966 RVA: 0x000D1414 File Offset: 0x000CF614
	public void ThrowFlare(global::ItemRepresentation rep, global::UnityEngine.Vector3 origin, global::UnityEngine.Vector3 forward)
	{
		global::UnityEngine.Vector3 arg = forward * 20f;
		global::UnityEngine.Vector3 position = origin + forward * 1f;
		global::UnityEngine.Quaternion rotation = global::UnityEngine.Quaternion.LookRotation(global::UnityEngine.Vector3.up);
		global::NetCull.InstantiateDynamicWithArgs<global::UnityEngine.Vector3>(this.throwObjectPrefab, position, rotation, arg);
	}

	// Token: 0x06003A77 RID: 14967 RVA: 0x000D145C File Offset: 0x000CF65C
	public void Ignite(global::ViewModel vm, global::ItemRepresentation itemRep, global::ITorchItem torchItem)
	{
		if (torchItem != null)
		{
			torchItem.Ignite();
		}
		bool flag = vm != null;
		if (flag)
		{
			this.StrikeSound.Play();
			global::UnityEngine.GameObject light = vm.socketMap["muzzle"].socket.InstantiateAsChild(this.FirstPersonLightPrefab, false);
			if (torchItem != null)
			{
				torchItem.light = light;
			}
		}
		else if ((torchItem == null || !torchItem.light) && !itemRep.networkView.isMine)
		{
			if (this.ThirdPersonLightPrefab)
			{
				((global::TorchItemRep)itemRep)._myLightPrefab = this.ThirdPersonLightPrefab;
			}
			((global::TorchItemRep)itemRep).RepIgnite();
			if (((global::TorchItemRep)itemRep)._myLight && torchItem != null)
			{
				torchItem.light = ((global::TorchItemRep)itemRep)._myLight;
			}
		}
	}

	// Token: 0x04001E2C RID: 7724
	public global::UnityEngine.GameObject FirstPersonLightPrefab;

	// Token: 0x04001E2D RID: 7725
	public global::UnityEngine.GameObject ThirdPersonLightPrefab;

	// Token: 0x04001E2E RID: 7726
	public global::UnityEngine.AudioClip StrikeSound;

	// Token: 0x020006BD RID: 1725
	private sealed class ITEM_TYPE : global::TorchItem<global::TorchItemDataBlock>, global::IHeldItem, global::IInventoryItem, global::IThrowableItem, global::ITorchItem, global::IWeaponItem
	{
		// Token: 0x06003A78 RID: 14968 RVA: 0x000D1548 File Offset: 0x000CF748
		public ITEM_TYPE(global::TorchItemDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000B12 RID: 2834
		// (get) Token: 0x06003A79 RID: 14969 RVA: 0x000D1554 File Offset: 0x000CF754
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x06003A7A RID: 14970 RVA: 0x000D155C File Offset: 0x000CF75C
		void Ignite()
		{
			base.Ignite();
		}

		// Token: 0x06003A7B RID: 14971 RVA: 0x000D1564 File Offset: 0x000CF764
		void Extinguish()
		{
			base.Extinguish();
		}

		// Token: 0x06003A7C RID: 14972 RVA: 0x000D156C File Offset: 0x000CF76C
		bool get_isLit()
		{
			return base.isLit;
		}

		// Token: 0x06003A7D RID: 14973 RVA: 0x000D1574 File Offset: 0x000CF774
		float get_realThrowTime()
		{
			return base.realThrowTime;
		}

		// Token: 0x06003A7E RID: 14974 RVA: 0x000D157C File Offset: 0x000CF77C
		void set_realThrowTime(float value)
		{
			base.realThrowTime = value;
		}

		// Token: 0x06003A7F RID: 14975 RVA: 0x000D1588 File Offset: 0x000CF788
		float get_realIgniteTime()
		{
			return base.realIgniteTime;
		}

		// Token: 0x06003A80 RID: 14976 RVA: 0x000D1590 File Offset: 0x000CF790
		void set_realIgniteTime(float value)
		{
			base.realIgniteTime = value;
		}

		// Token: 0x06003A81 RID: 14977 RVA: 0x000D159C File Offset: 0x000CF79C
		float get_forceSecondaryTime()
		{
			return base.forceSecondaryTime;
		}

		// Token: 0x06003A82 RID: 14978 RVA: 0x000D15A4 File Offset: 0x000CF7A4
		void set_forceSecondaryTime(float value)
		{
			base.forceSecondaryTime = value;
		}

		// Token: 0x06003A83 RID: 14979 RVA: 0x000D15B0 File Offset: 0x000CF7B0
		global::UnityEngine.GameObject get_light()
		{
			return base.light;
		}

		// Token: 0x06003A84 RID: 14980 RVA: 0x000D15B8 File Offset: 0x000CF7B8
		void set_light(global::UnityEngine.GameObject value)
		{
			base.light = value;
		}

		// Token: 0x06003A85 RID: 14981 RVA: 0x000D15C4 File Offset: 0x000CF7C4
		float get_holdingStartTime()
		{
			return base.holdingStartTime;
		}

		// Token: 0x06003A86 RID: 14982 RVA: 0x000D15CC File Offset: 0x000CF7CC
		void set_holdingStartTime(float value)
		{
			base.holdingStartTime = value;
		}

		// Token: 0x06003A87 RID: 14983 RVA: 0x000D15D8 File Offset: 0x000CF7D8
		bool get_holdingBack()
		{
			return base.holdingBack;
		}

		// Token: 0x06003A88 RID: 14984 RVA: 0x000D15E0 File Offset: 0x000CF7E0
		void set_holdingBack(bool value)
		{
			base.holdingBack = value;
		}

		// Token: 0x06003A89 RID: 14985 RVA: 0x000D15EC File Offset: 0x000CF7EC
		float get_minReleaseTime()
		{
			return base.minReleaseTime;
		}

		// Token: 0x06003A8A RID: 14986 RVA: 0x000D15F4 File Offset: 0x000CF7F4
		void set_minReleaseTime(float value)
		{
			base.minReleaseTime = value;
		}

		// Token: 0x06003A8B RID: 14987 RVA: 0x000D1600 File Offset: 0x000CF800
		bool ValidatePrimaryMessageTime(double timestamp)
		{
			return base.ValidatePrimaryMessageTime(timestamp);
		}

		// Token: 0x06003A8C RID: 14988 RVA: 0x000D160C File Offset: 0x000CF80C
		bool get_canAim()
		{
			return base.canAim;
		}

		// Token: 0x06003A8D RID: 14989 RVA: 0x000D1614 File Offset: 0x000CF814
		float get_nextPrimaryAttackTime()
		{
			return base.nextPrimaryAttackTime;
		}

		// Token: 0x06003A8E RID: 14990 RVA: 0x000D161C File Offset: 0x000CF81C
		void set_nextPrimaryAttackTime(float value)
		{
			base.nextPrimaryAttackTime = value;
		}

		// Token: 0x06003A8F RID: 14991 RVA: 0x000D1628 File Offset: 0x000CF828
		float get_nextSecondaryAttackTime()
		{
			return base.nextSecondaryAttackTime;
		}

		// Token: 0x06003A90 RID: 14992 RVA: 0x000D1630 File Offset: 0x000CF830
		void set_nextSecondaryAttackTime(float value)
		{
			base.nextSecondaryAttackTime = value;
		}

		// Token: 0x06003A91 RID: 14993 RVA: 0x000D163C File Offset: 0x000CF83C
		float get_deployFinishedTime()
		{
			return base.deployFinishedTime;
		}

		// Token: 0x06003A92 RID: 14994 RVA: 0x000D1644 File Offset: 0x000CF844
		void set_deployFinishedTime(float value)
		{
			base.deployFinishedTime = value;
		}

		// Token: 0x06003A93 RID: 14995 RVA: 0x000D1650 File Offset: 0x000CF850
		void SetTotalModSlotCount(int count)
		{
			base.SetTotalModSlotCount(count);
		}

		// Token: 0x06003A94 RID: 14996 RVA: 0x000D165C File Offset: 0x000CF85C
		void SetUsedModSlotCount(int count)
		{
			base.SetUsedModSlotCount(count);
		}

		// Token: 0x06003A95 RID: 14997 RVA: 0x000D1668 File Offset: 0x000CF868
		void AddMod(global::ItemModDataBlock mod)
		{
			base.AddMod(mod);
		}

		// Token: 0x06003A96 RID: 14998 RVA: 0x000D1674 File Offset: 0x000CF874
		int FindMod(global::ItemModDataBlock mod)
		{
			return base.FindMod(mod);
		}

		// Token: 0x06003A97 RID: 14999 RVA: 0x000D1680 File Offset: 0x000CF880
		void OnActivate()
		{
			base.OnActivate();
		}

		// Token: 0x06003A98 RID: 15000 RVA: 0x000D1688 File Offset: 0x000CF888
		void OnDeactivate()
		{
			base.OnDeactivate();
		}

		// Token: 0x06003A99 RID: 15001 RVA: 0x000D1690 File Offset: 0x000CF890
		global::ViewModel get_viewModelInstance()
		{
			return base.viewModelInstance;
		}

		// Token: 0x06003A9A RID: 15002 RVA: 0x000D1698 File Offset: 0x000CF898
		global::ItemRepresentation get_itemRepresentation()
		{
			return base.itemRepresentation;
		}

		// Token: 0x06003A9B RID: 15003 RVA: 0x000D16A0 File Offset: 0x000CF8A0
		void set_itemRepresentation(global::ItemRepresentation value)
		{
			base.itemRepresentation = value;
		}

		// Token: 0x06003A9C RID: 15004 RVA: 0x000D16AC File Offset: 0x000CF8AC
		bool get_canActivate()
		{
			return base.canActivate;
		}

		// Token: 0x06003A9D RID: 15005 RVA: 0x000D16B4 File Offset: 0x000CF8B4
		bool get_canDeactivate()
		{
			return base.canDeactivate;
		}

		// Token: 0x06003A9E RID: 15006 RVA: 0x000D16BC File Offset: 0x000CF8BC
		global::ItemModFlags get_modFlags()
		{
			return base.modFlags;
		}

		// Token: 0x06003A9F RID: 15007 RVA: 0x000D16C4 File Offset: 0x000CF8C4
		global::ItemModDataBlock[] get_itemMods()
		{
			return base.itemMods;
		}

		// Token: 0x06003AA0 RID: 15008 RVA: 0x000D16CC File Offset: 0x000CF8CC
		int get_totalModSlots()
		{
			return base.totalModSlots;
		}

		// Token: 0x06003AA1 RID: 15009 RVA: 0x000D16D4 File Offset: 0x000CF8D4
		int get_usedModSlots()
		{
			return base.usedModSlots;
		}

		// Token: 0x06003AA2 RID: 15010 RVA: 0x000D16DC File Offset: 0x000CF8DC
		int get_freeModSlots()
		{
			return base.freeModSlots;
		}

		// Token: 0x06003AA3 RID: 15011 RVA: 0x000D16E4 File Offset: 0x000CF8E4
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x06003AA4 RID: 15012 RVA: 0x000D16EC File Offset: 0x000CF8EC
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x06003AA5 RID: 15013 RVA: 0x000D16F4 File Offset: 0x000CF8F4
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x06003AA6 RID: 15014 RVA: 0x000D16FC File Offset: 0x000CF8FC
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x06003AA7 RID: 15015 RVA: 0x000D1708 File Offset: 0x000CF908
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x06003AA8 RID: 15016 RVA: 0x000D1714 File Offset: 0x000CF914
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x06003AA9 RID: 15017 RVA: 0x000D1720 File Offset: 0x000CF920
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x06003AAA RID: 15018 RVA: 0x000D172C File Offset: 0x000CF92C
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x06003AAB RID: 15019 RVA: 0x000D1738 File Offset: 0x000CF938
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x06003AAC RID: 15020 RVA: 0x000D1744 File Offset: 0x000CF944
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x06003AAD RID: 15021 RVA: 0x000D1750 File Offset: 0x000CF950
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x06003AAE RID: 15022 RVA: 0x000D175C File Offset: 0x000CF95C
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x06003AAF RID: 15023 RVA: 0x000D1764 File Offset: 0x000CF964
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x06003AB0 RID: 15024 RVA: 0x000D1770 File Offset: 0x000CF970
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x06003AB1 RID: 15025 RVA: 0x000D177C File Offset: 0x000CF97C
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x06003AB2 RID: 15026 RVA: 0x000D1784 File Offset: 0x000CF984
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x06003AB3 RID: 15027 RVA: 0x000D178C File Offset: 0x000CF98C
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x06003AB4 RID: 15028 RVA: 0x000D1794 File Offset: 0x000CF994
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x06003AB5 RID: 15029 RVA: 0x000D179C File Offset: 0x000CF99C
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x06003AB6 RID: 15030 RVA: 0x000D17A4 File Offset: 0x000CF9A4
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x06003AB7 RID: 15031 RVA: 0x000D17AC File Offset: 0x000CF9AC
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x06003AB8 RID: 15032 RVA: 0x000D17B4 File Offset: 0x000CF9B4
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x06003AB9 RID: 15033 RVA: 0x000D17C0 File Offset: 0x000CF9C0
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x06003ABA RID: 15034 RVA: 0x000D17C8 File Offset: 0x000CF9C8
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x06003ABB RID: 15035 RVA: 0x000D17D0 File Offset: 0x000CF9D0
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x06003ABC RID: 15036 RVA: 0x000D17D8 File Offset: 0x000CF9D8
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x06003ABD RID: 15037 RVA: 0x000D17E0 File Offset: 0x000CF9E0
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x06003ABE RID: 15038 RVA: 0x000D17E8 File Offset: 0x000CF9E8
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x06003ABF RID: 15039 RVA: 0x000D17F0 File Offset: 0x000CF9F0
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
