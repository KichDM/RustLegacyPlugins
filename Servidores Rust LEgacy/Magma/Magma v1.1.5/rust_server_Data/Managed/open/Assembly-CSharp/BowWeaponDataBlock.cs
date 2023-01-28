using System;
using Facepunch;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x0200067F RID: 1663
public class BowWeaponDataBlock : global::WeaponDataBlock
{
	// Token: 0x06003597 RID: 13719 RVA: 0x000CA45C File Offset: 0x000C865C
	public BowWeaponDataBlock()
	{
	}

	// Token: 0x06003598 RID: 13720 RVA: 0x000CA47C File Offset: 0x000C867C
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::BowWeaponDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x06003599 RID: 13721 RVA: 0x000CA484 File Offset: 0x000C8684
	public override byte GetMaxEligableSlots()
	{
		return 0;
	}

	// Token: 0x0600359A RID: 13722 RVA: 0x000CA488 File Offset: 0x000C8688
	public override void InstallData(global::IInventoryItem item)
	{
		base.InstallData(item);
	}

	// Token: 0x0600359B RID: 13723 RVA: 0x000CA494 File Offset: 0x000C8694
	public void ArrowReportMiss(global::ArrowMovement arrow, global::ItemRepresentation itemRepresentation)
	{
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::UnityEngine.Vector3>(arrow.transform.position, new object[0]);
		itemRepresentation.ActionStream(3, 0, bitStream);
	}

	// Token: 0x0600359C RID: 13724 RVA: 0x000CA4C8 File Offset: 0x000C86C8
	public void ArrowReportHit(global::IDMain hitMain, global::ArrowMovement arrow, global::ItemRepresentation itemRepresentation, global::IBowWeaponItem itemInstance)
	{
		if (!hitMain)
		{
			return;
		}
		global::TakeDamage component = hitMain.GetComponent<global::TakeDamage>();
		if (!component)
		{
			return;
		}
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.Write<global::NetEntityID>(global::NetEntityID.Get(hitMain), new object[0]);
		bitStream.Write<global::UnityEngine.Vector3>(hitMain.transform.position, new object[0]);
		itemRepresentation.ActionStream(2, 0, bitStream);
		global::Character character = itemInstance.character;
		if (component && component.ShouldPlayHitNotification())
		{
			this.PlayHitNotification(arrow.transform.position, character);
		}
	}

	// Token: 0x0600359D RID: 13725 RVA: 0x000CA560 File Offset: 0x000C8760
	public override void DoAction3(global::uLink.BitStream stream, global::ItemRepresentation rep, ref global::uLink.NetworkMessageInfo info)
	{
		global::UnityEngine.Vector3 vector = stream.ReadVector3();
		global::NetCull.VerifyRPC(ref info, false);
		global::IBowWeaponItem bowWeaponItem;
		if (rep.Item<global::IBowWeaponItem>(out bowWeaponItem))
		{
			if (!bowWeaponItem.AnyArrowInFlight())
			{
				return;
			}
			bowWeaponItem.RemoveArrowInFlight();
		}
	}

	// Token: 0x0600359E RID: 13726 RVA: 0x000CA59C File Offset: 0x000C879C
	public override void DoAction2(global::uLink.BitStream stream, global::ItemRepresentation rep, ref global::uLink.NetworkMessageInfo info)
	{
		global::NetCull.VerifyRPC(ref info, false);
		global::IBowWeaponItem bowWeaponItem;
		if (!rep.Item<global::IBowWeaponItem>(out bowWeaponItem))
		{
			return;
		}
		global::NetEntityID netEntityID = stream.Read<global::NetEntityID>(new object[0]);
		if (false || netEntityID.main == null)
		{
			bowWeaponItem.RemoveArrowInFlight();
			return;
		}
		global::TakeDamage local = netEntityID.main.GetLocal<global::TakeDamage>();
		global::UnityEngine.Vector3 vector = stream.ReadVector3();
		if (!bowWeaponItem.AnyArrowInFlight())
		{
			return;
		}
		bowWeaponItem.RemoveArrowInFlight();
		global::TakeDamage.Hurt(bowWeaponItem.inventory.idMain, netEntityID.main, new global::DamageTypeList(0f, 0f, 75f, 0f, 0f, 0f), null);
	}

	// Token: 0x0600359F RID: 13727 RVA: 0x000CA654 File Offset: 0x000C8854
	public void CreateDroppedArrow(global::UnityEngine.Vector3 hitPos, global::UnityEngine.Quaternion rot, global::ItemDataBlock pickupItem)
	{
		global::UnityEngine.GameObject gameObject = global::NetCull.InstantiateDynamicWithArgs<global::UnityEngine.Vector3>(this.arrowPickupString, hitPos, rot, global::UnityEngine.Vector3.zero);
		global::Inventory component = gameObject.GetComponent<global::Inventory>();
		component.AddItemAmount(this.defaultAmmo, 1);
	}

	// Token: 0x060035A0 RID: 13728 RVA: 0x000CA68C File Offset: 0x000C888C
	public override void DoAction1(global::uLink.BitStream stream, global::ItemRepresentation rep, ref global::uLink.NetworkMessageInfo info)
	{
		global::NetCull.VerifyRPC(ref info, false);
		global::IBowWeaponItem bowWeaponItem;
		if (rep.Item<global::IBowWeaponItem>(out bowWeaponItem) && bowWeaponItem.canPrimaryAttack)
		{
			int num = 1;
			global::IInventoryItem inventoryItem = bowWeaponItem.FindAmmo();
			if (inventoryItem == null)
			{
				return;
			}
			if (inventoryItem.Consume(ref num))
			{
				bowWeaponItem.inventory.RemoveItem(inventoryItem.slot);
			}
			bowWeaponItem.AddArrowInFlight();
			bowWeaponItem.nextPrimaryAttackTime = global::UnityEngine.Time.time + this.fireRate + this.drawLength;
			rep.ActionStream(1, 0xA, stream);
		}
	}

	// Token: 0x060035A1 RID: 13729 RVA: 0x000CA710 File Offset: 0x000C8910
	public virtual void DoWeaponEffects(global::UnityEngine.Transform soundTransform, global::UnityEngine.Vector3 startPos, global::UnityEngine.Vector3 endPos, global::Socket muzzleSocket, bool firstPerson, global::UnityEngine.Component hitComponent, bool allowBlood, global::ItemRepresentation itemRep)
	{
	}

	// Token: 0x060035A2 RID: 13730 RVA: 0x000CA714 File Offset: 0x000C8914
	public virtual void Local_GetTired(global::ViewModel vm, global::ItemRepresentation itemRep, global::IBowWeaponItem itemInstance, ref global::HumanController.InputSample sample)
	{
		if (itemInstance.tired)
		{
			return;
		}
	}

	// Token: 0x060035A3 RID: 13731 RVA: 0x000CA724 File Offset: 0x000C8924
	public virtual float GetGUIDamage()
	{
		return 999f;
	}

	// Token: 0x060035A4 RID: 13732 RVA: 0x000CA72C File Offset: 0x000C892C
	public override void PopulateInfoWindow(global::ItemToolTip infoWindow, global::IInventoryItem tipItem)
	{
	}

	// Token: 0x060035A5 RID: 13733 RVA: 0x000CA730 File Offset: 0x000C8930
	public override string GetItemDescription()
	{
		return "This is a weapon. Drag it to your belt (right side of screen) and press the corresponding number key to use it.";
	}

	// Token: 0x060035A6 RID: 13734 RVA: 0x000CA738 File Offset: 0x000C8938
	protected new virtual void PlayHitNotification(global::UnityEngine.Vector3 point, global::Character shooterOrNull)
	{
		if (global::WeaponDataBlock._hitNotify || global::Facepunch.Bundling.Load<global::UnityEngine.AudioClip>("content/shared/sfx/hitnotification", out global::WeaponDataBlock._hitNotify))
		{
			global::WeaponDataBlock._hitNotify.PlayLocal(global::UnityEngine.Camera.main.transform, global::UnityEngine.Vector3.zero, 1f, 1);
		}
		if (global::BowWeaponDataBlock._hitIndicator || global::Facepunch.Bundling.Load<global::HUDHitIndicator>("content/hud/HUDHitIndicator", out global::BowWeaponDataBlock._hitIndicator))
		{
		}
	}

	// Token: 0x060035A7 RID: 13735 RVA: 0x000CA7AC File Offset: 0x000C89AC
	protected override void SecureWriteMemberValues(global::uLink.BitStream stream)
	{
		base.SecureWriteMemberValues(stream);
	}

	// Token: 0x04001D4D RID: 7501
	public global::UnityEngine.AudioClip drawArrowSound;

	// Token: 0x04001D4E RID: 7502
	public global::UnityEngine.AudioClip fireArrowSound;

	// Token: 0x04001D4F RID: 7503
	public global::UnityEngine.AudioClip cancelArrowSound;

	// Token: 0x04001D50 RID: 7504
	public float arrowSpeed;

	// Token: 0x04001D51 RID: 7505
	public float tooTiredLength = 8f;

	// Token: 0x04001D52 RID: 7506
	public float drawLength = 2f;

	// Token: 0x04001D53 RID: 7507
	public global::ItemDataBlock defaultAmmo;

	// Token: 0x04001D54 RID: 7508
	public global::UnityEngine.GameObject arrowPrefab;

	// Token: 0x04001D55 RID: 7509
	public string arrowPickupString;

	// Token: 0x04001D56 RID: 7510
	private static global::HUDHitIndicator _hitIndicator;

	// Token: 0x02000680 RID: 1664
	private sealed class ITEM_TYPE : global::BowWeaponItem<global::BowWeaponDataBlock>, global::IBowWeaponItem, global::IHeldItem, global::IInventoryItem, global::IWeaponItem
	{
		// Token: 0x060035A8 RID: 13736 RVA: 0x000CA7B8 File Offset: 0x000C89B8
		public ITEM_TYPE(global::BowWeaponDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000AEE RID: 2798
		// (get) Token: 0x060035A9 RID: 13737 RVA: 0x000CA7C4 File Offset: 0x000C89C4
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x060035AA RID: 13738 RVA: 0x000CA7CC File Offset: 0x000C89CC
		global::IInventoryItem FindAmmo()
		{
			return base.FindAmmo();
		}

		// Token: 0x060035AB RID: 13739 RVA: 0x000CA7D4 File Offset: 0x000C89D4
		bool AnyArrowInFlight()
		{
			return base.AnyArrowInFlight();
		}

		// Token: 0x060035AC RID: 13740 RVA: 0x000CA7DC File Offset: 0x000C89DC
		void AddArrowInFlight()
		{
			base.AddArrowInFlight();
		}

		// Token: 0x060035AD RID: 13741 RVA: 0x000CA7E4 File Offset: 0x000C89E4
		void RemoveArrowInFlight()
		{
			base.RemoveArrowInFlight();
		}

		// Token: 0x060035AE RID: 13742 RVA: 0x000CA7EC File Offset: 0x000C89EC
		bool get_arrowDrawn()
		{
			return base.arrowDrawn;
		}

		// Token: 0x060035AF RID: 13743 RVA: 0x000CA7F4 File Offset: 0x000C89F4
		void set_arrowDrawn(bool value)
		{
			base.arrowDrawn = value;
		}

		// Token: 0x060035B0 RID: 13744 RVA: 0x000CA800 File Offset: 0x000C8A00
		bool get_tired()
		{
			return base.tired;
		}

		// Token: 0x060035B1 RID: 13745 RVA: 0x000CA808 File Offset: 0x000C8A08
		void set_tired(bool value)
		{
			base.tired = value;
		}

		// Token: 0x060035B2 RID: 13746 RVA: 0x000CA814 File Offset: 0x000C8A14
		float get_completeDrawTime()
		{
			return base.completeDrawTime;
		}

		// Token: 0x060035B3 RID: 13747 RVA: 0x000CA81C File Offset: 0x000C8A1C
		void set_completeDrawTime(float value)
		{
			base.completeDrawTime = value;
		}

		// Token: 0x060035B4 RID: 13748 RVA: 0x000CA828 File Offset: 0x000C8A28
		int get_currentArrowID()
		{
			return base.currentArrowID;
		}

		// Token: 0x060035B5 RID: 13749 RVA: 0x000CA830 File Offset: 0x000C8A30
		void set_currentArrowID(int value)
		{
			base.currentArrowID = value;
		}

		// Token: 0x060035B6 RID: 13750 RVA: 0x000CA83C File Offset: 0x000C8A3C
		bool ValidatePrimaryMessageTime(double timestamp)
		{
			return base.ValidatePrimaryMessageTime(timestamp);
		}

		// Token: 0x060035B7 RID: 13751 RVA: 0x000CA848 File Offset: 0x000C8A48
		bool get_canAim()
		{
			return base.canAim;
		}

		// Token: 0x060035B8 RID: 13752 RVA: 0x000CA850 File Offset: 0x000C8A50
		float get_nextPrimaryAttackTime()
		{
			return base.nextPrimaryAttackTime;
		}

		// Token: 0x060035B9 RID: 13753 RVA: 0x000CA858 File Offset: 0x000C8A58
		void set_nextPrimaryAttackTime(float value)
		{
			base.nextPrimaryAttackTime = value;
		}

		// Token: 0x060035BA RID: 13754 RVA: 0x000CA864 File Offset: 0x000C8A64
		float get_nextSecondaryAttackTime()
		{
			return base.nextSecondaryAttackTime;
		}

		// Token: 0x060035BB RID: 13755 RVA: 0x000CA86C File Offset: 0x000C8A6C
		void set_nextSecondaryAttackTime(float value)
		{
			base.nextSecondaryAttackTime = value;
		}

		// Token: 0x060035BC RID: 13756 RVA: 0x000CA878 File Offset: 0x000C8A78
		float get_deployFinishedTime()
		{
			return base.deployFinishedTime;
		}

		// Token: 0x060035BD RID: 13757 RVA: 0x000CA880 File Offset: 0x000C8A80
		void set_deployFinishedTime(float value)
		{
			base.deployFinishedTime = value;
		}

		// Token: 0x060035BE RID: 13758 RVA: 0x000CA88C File Offset: 0x000C8A8C
		void SetTotalModSlotCount(int count)
		{
			base.SetTotalModSlotCount(count);
		}

		// Token: 0x060035BF RID: 13759 RVA: 0x000CA898 File Offset: 0x000C8A98
		void SetUsedModSlotCount(int count)
		{
			base.SetUsedModSlotCount(count);
		}

		// Token: 0x060035C0 RID: 13760 RVA: 0x000CA8A4 File Offset: 0x000C8AA4
		void AddMod(global::ItemModDataBlock mod)
		{
			base.AddMod(mod);
		}

		// Token: 0x060035C1 RID: 13761 RVA: 0x000CA8B0 File Offset: 0x000C8AB0
		int FindMod(global::ItemModDataBlock mod)
		{
			return base.FindMod(mod);
		}

		// Token: 0x060035C2 RID: 13762 RVA: 0x000CA8BC File Offset: 0x000C8ABC
		void OnActivate()
		{
			base.OnActivate();
		}

		// Token: 0x060035C3 RID: 13763 RVA: 0x000CA8C4 File Offset: 0x000C8AC4
		void OnDeactivate()
		{
			base.OnDeactivate();
		}

		// Token: 0x060035C4 RID: 13764 RVA: 0x000CA8CC File Offset: 0x000C8ACC
		global::ViewModel get_viewModelInstance()
		{
			return base.viewModelInstance;
		}

		// Token: 0x060035C5 RID: 13765 RVA: 0x000CA8D4 File Offset: 0x000C8AD4
		global::ItemRepresentation get_itemRepresentation()
		{
			return base.itemRepresentation;
		}

		// Token: 0x060035C6 RID: 13766 RVA: 0x000CA8DC File Offset: 0x000C8ADC
		void set_itemRepresentation(global::ItemRepresentation value)
		{
			base.itemRepresentation = value;
		}

		// Token: 0x060035C7 RID: 13767 RVA: 0x000CA8E8 File Offset: 0x000C8AE8
		bool get_canActivate()
		{
			return base.canActivate;
		}

		// Token: 0x060035C8 RID: 13768 RVA: 0x000CA8F0 File Offset: 0x000C8AF0
		bool get_canDeactivate()
		{
			return base.canDeactivate;
		}

		// Token: 0x060035C9 RID: 13769 RVA: 0x000CA8F8 File Offset: 0x000C8AF8
		global::ItemModFlags get_modFlags()
		{
			return base.modFlags;
		}

		// Token: 0x060035CA RID: 13770 RVA: 0x000CA900 File Offset: 0x000C8B00
		global::ItemModDataBlock[] get_itemMods()
		{
			return base.itemMods;
		}

		// Token: 0x060035CB RID: 13771 RVA: 0x000CA908 File Offset: 0x000C8B08
		int get_totalModSlots()
		{
			return base.totalModSlots;
		}

		// Token: 0x060035CC RID: 13772 RVA: 0x000CA910 File Offset: 0x000C8B10
		int get_usedModSlots()
		{
			return base.usedModSlots;
		}

		// Token: 0x060035CD RID: 13773 RVA: 0x000CA918 File Offset: 0x000C8B18
		int get_freeModSlots()
		{
			return base.freeModSlots;
		}

		// Token: 0x060035CE RID: 13774 RVA: 0x000CA920 File Offset: 0x000C8B20
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x060035CF RID: 13775 RVA: 0x000CA928 File Offset: 0x000C8B28
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x060035D0 RID: 13776 RVA: 0x000CA930 File Offset: 0x000C8B30
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x060035D1 RID: 13777 RVA: 0x000CA938 File Offset: 0x000C8B38
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x060035D2 RID: 13778 RVA: 0x000CA944 File Offset: 0x000C8B44
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x060035D3 RID: 13779 RVA: 0x000CA950 File Offset: 0x000C8B50
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x060035D4 RID: 13780 RVA: 0x000CA95C File Offset: 0x000C8B5C
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x060035D5 RID: 13781 RVA: 0x000CA968 File Offset: 0x000C8B68
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x060035D6 RID: 13782 RVA: 0x000CA974 File Offset: 0x000C8B74
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x060035D7 RID: 13783 RVA: 0x000CA980 File Offset: 0x000C8B80
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x060035D8 RID: 13784 RVA: 0x000CA98C File Offset: 0x000C8B8C
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x060035D9 RID: 13785 RVA: 0x000CA998 File Offset: 0x000C8B98
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x060035DA RID: 13786 RVA: 0x000CA9A0 File Offset: 0x000C8BA0
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x060035DB RID: 13787 RVA: 0x000CA9AC File Offset: 0x000C8BAC
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x060035DC RID: 13788 RVA: 0x000CA9B8 File Offset: 0x000C8BB8
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x060035DD RID: 13789 RVA: 0x000CA9C0 File Offset: 0x000C8BC0
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x060035DE RID: 13790 RVA: 0x000CA9C8 File Offset: 0x000C8BC8
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x060035DF RID: 13791 RVA: 0x000CA9D0 File Offset: 0x000C8BD0
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x060035E0 RID: 13792 RVA: 0x000CA9D8 File Offset: 0x000C8BD8
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x060035E1 RID: 13793 RVA: 0x000CA9E0 File Offset: 0x000C8BE0
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x060035E2 RID: 13794 RVA: 0x000CA9E8 File Offset: 0x000C8BE8
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x060035E3 RID: 13795 RVA: 0x000CA9F0 File Offset: 0x000C8BF0
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x060035E4 RID: 13796 RVA: 0x000CA9FC File Offset: 0x000C8BFC
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x060035E5 RID: 13797 RVA: 0x000CAA04 File Offset: 0x000C8C04
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x060035E6 RID: 13798 RVA: 0x000CAA0C File Offset: 0x000C8C0C
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x060035E7 RID: 13799 RVA: 0x000CAA14 File Offset: 0x000C8C14
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x060035E8 RID: 13800 RVA: 0x000CAA1C File Offset: 0x000C8C1C
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x060035E9 RID: 13801 RVA: 0x000CAA24 File Offset: 0x000C8C24
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x060035EA RID: 13802 RVA: 0x000CAA2C File Offset: 0x000C8C2C
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
