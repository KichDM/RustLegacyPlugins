using System;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x02000694 RID: 1684
public class HandGrenadeDataBlock : global::ThrowableItemDataBlock
{
	// Token: 0x06003730 RID: 14128 RVA: 0x000CD400 File Offset: 0x000CB600
	public HandGrenadeDataBlock()
	{
	}

	// Token: 0x06003731 RID: 14129 RVA: 0x000CD408 File Offset: 0x000CB608
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::HandGrenadeDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x06003732 RID: 14130 RVA: 0x000CD410 File Offset: 0x000CB610
	public global::IHandGrenadeItem GetHandGrenadeItemInstance(global::IInventoryItem itemInstance)
	{
		return itemInstance as global::IHandGrenadeItem;
	}

	// Token: 0x06003733 RID: 14131 RVA: 0x000CD418 File Offset: 0x000CB618
	public override void PrimaryAttack(global::ViewModel vm, global::ItemRepresentation itemRep, global::IThrowableItem itemInstance, ref global::HumanController.InputSample sample)
	{
		base.PrimaryAttack(vm, itemRep, itemInstance, ref sample);
		this.pullPinSound.Play();
		this.GetHandGrenadeItemInstance(itemInstance).nextPrimaryAttackTime = global::UnityEngine.Time.time + 1000f;
		this.GetHandGrenadeItemInstance(itemInstance).nextSecondaryAttackTime = global::UnityEngine.Time.time + 1000f;
	}

	// Token: 0x06003734 RID: 14132 RVA: 0x000CD46C File Offset: 0x000CB66C
	public override void AttackReleased(global::ViewModel vm, global::ItemRepresentation itemRep, global::IThrowableItem itemInstance, ref global::HumanController.InputSample sample)
	{
		global::UnityEngine.Debug.Log("Attack released!!!");
		this.GetHandGrenadeItemInstance(itemInstance).nextPrimaryAttackTime = global::UnityEngine.Time.time + 1f;
		this.GetHandGrenadeItemInstance(itemInstance).nextSecondaryAttackTime = global::UnityEngine.Time.time + 1f;
		global::Character component = global::PlayerClient.GetLocalPlayer().controllable.GetComponent<global::Character>();
		global::UnityEngine.Vector3 eyesOrigin = component.eyesOrigin;
		global::UnityEngine.Vector3 forward = component.eyesAngles.forward;
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.WriteVector3(eyesOrigin);
		bitStream.WriteVector3(forward * this.GetHandGrenadeItemInstance(itemInstance).heldThrowStrength);
		global::UnityEngine.Debug.Log("Throw strength is : " + this.GetHandGrenadeItemInstance(itemInstance).heldThrowStrength);
		this.GetHandGrenadeItemInstance(itemInstance).EndHoldingBack();
		itemRep.ActionStream(1, 0, bitStream);
	}

	// Token: 0x06003735 RID: 14133 RVA: 0x000CD534 File Offset: 0x000CB734
	public override void DoAction1(global::uLink.BitStream stream, global::ItemRepresentation rep, ref global::uLink.NetworkMessageInfo info)
	{
		global::NetCull.VerifyRPC(ref info, false);
		global::IHandGrenadeItem handGrenadeItem;
		if (!rep.Item<global::IHandGrenadeItem>(out handGrenadeItem) || !handGrenadeItem.ValidatePrimaryMessageTime(info.timestamp))
		{
			return;
		}
		rep.ActionStream(1, 0xA, stream);
		global::UnityEngine.Vector3 origin = stream.ReadVector3();
		global::UnityEngine.Vector3 forward = stream.ReadVector3();
		global::UnityEngine.GameObject gameObject = base.ThrowItem(rep, origin, forward);
		if (gameObject)
		{
			gameObject.rigidbody.AddTorque(new global::UnityEngine.Vector3(global::UnityEngine.Random.Range(-1f, 1f), global::UnityEngine.Random.Range(-1f, 1f), global::UnityEngine.Random.Range(-1f, 1f)) * 10f);
		}
		int num = 1;
		if (handGrenadeItem.Consume(ref num))
		{
			handGrenadeItem.inventory.RemoveItem(handGrenadeItem.slot);
		}
	}

	// Token: 0x06003736 RID: 14134 RVA: 0x000CD600 File Offset: 0x000CB800
	protected override global::UnityEngine.GameObject ThrowItem(global::ItemRepresentation rep, global::IThrowableItem item, global::UnityEngine.Vector3 origin, global::UnityEngine.Vector3 forward, global::uLink.NetworkViewID owner)
	{
		forward.Normalize();
		global::UnityEngine.Vector3 velocity = forward * 20f;
		global::UnityEngine.Vector3 position = origin + forward * 0.5f;
		return this.SpawnThrowItem(owner, this.throwObjectPrefab, position, global::UnityEngine.Quaternion.LookRotation(global::UnityEngine.Vector3.up), velocity);
	}

	// Token: 0x04001DB4 RID: 7604
	public global::UnityEngine.AudioClip pullPinSound;

	// Token: 0x02000695 RID: 1685
	private sealed class ITEM_TYPE : global::HandGrenadeItem<global::HandGrenadeDataBlock>, global::IHandGrenadeItem, global::IHeldItem, global::IInventoryItem, global::IThrowableItem, global::IWeaponItem
	{
		// Token: 0x06003737 RID: 14135 RVA: 0x000CD650 File Offset: 0x000CB850
		public ITEM_TYPE(global::HandGrenadeDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000AFC RID: 2812
		// (get) Token: 0x06003738 RID: 14136 RVA: 0x000CD65C File Offset: 0x000CB85C
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x06003739 RID: 14137 RVA: 0x000CD664 File Offset: 0x000CB864
		float get_holdingStartTime()
		{
			return base.holdingStartTime;
		}

		// Token: 0x0600373A RID: 14138 RVA: 0x000CD66C File Offset: 0x000CB86C
		void set_holdingStartTime(float value)
		{
			base.holdingStartTime = value;
		}

		// Token: 0x0600373B RID: 14139 RVA: 0x000CD678 File Offset: 0x000CB878
		bool get_holdingBack()
		{
			return base.holdingBack;
		}

		// Token: 0x0600373C RID: 14140 RVA: 0x000CD680 File Offset: 0x000CB880
		void set_holdingBack(bool value)
		{
			base.holdingBack = value;
		}

		// Token: 0x0600373D RID: 14141 RVA: 0x000CD68C File Offset: 0x000CB88C
		float get_minReleaseTime()
		{
			return base.minReleaseTime;
		}

		// Token: 0x0600373E RID: 14142 RVA: 0x000CD694 File Offset: 0x000CB894
		void set_minReleaseTime(float value)
		{
			base.minReleaseTime = value;
		}

		// Token: 0x0600373F RID: 14143 RVA: 0x000CD6A0 File Offset: 0x000CB8A0
		bool ValidatePrimaryMessageTime(double timestamp)
		{
			return base.ValidatePrimaryMessageTime(timestamp);
		}

		// Token: 0x06003740 RID: 14144 RVA: 0x000CD6AC File Offset: 0x000CB8AC
		bool get_canAim()
		{
			return base.canAim;
		}

		// Token: 0x06003741 RID: 14145 RVA: 0x000CD6B4 File Offset: 0x000CB8B4
		float get_nextPrimaryAttackTime()
		{
			return base.nextPrimaryAttackTime;
		}

		// Token: 0x06003742 RID: 14146 RVA: 0x000CD6BC File Offset: 0x000CB8BC
		void set_nextPrimaryAttackTime(float value)
		{
			base.nextPrimaryAttackTime = value;
		}

		// Token: 0x06003743 RID: 14147 RVA: 0x000CD6C8 File Offset: 0x000CB8C8
		float get_nextSecondaryAttackTime()
		{
			return base.nextSecondaryAttackTime;
		}

		// Token: 0x06003744 RID: 14148 RVA: 0x000CD6D0 File Offset: 0x000CB8D0
		void set_nextSecondaryAttackTime(float value)
		{
			base.nextSecondaryAttackTime = value;
		}

		// Token: 0x06003745 RID: 14149 RVA: 0x000CD6DC File Offset: 0x000CB8DC
		float get_deployFinishedTime()
		{
			return base.deployFinishedTime;
		}

		// Token: 0x06003746 RID: 14150 RVA: 0x000CD6E4 File Offset: 0x000CB8E4
		void set_deployFinishedTime(float value)
		{
			base.deployFinishedTime = value;
		}

		// Token: 0x06003747 RID: 14151 RVA: 0x000CD6F0 File Offset: 0x000CB8F0
		void SetTotalModSlotCount(int count)
		{
			base.SetTotalModSlotCount(count);
		}

		// Token: 0x06003748 RID: 14152 RVA: 0x000CD6FC File Offset: 0x000CB8FC
		void SetUsedModSlotCount(int count)
		{
			base.SetUsedModSlotCount(count);
		}

		// Token: 0x06003749 RID: 14153 RVA: 0x000CD708 File Offset: 0x000CB908
		void AddMod(global::ItemModDataBlock mod)
		{
			base.AddMod(mod);
		}

		// Token: 0x0600374A RID: 14154 RVA: 0x000CD714 File Offset: 0x000CB914
		int FindMod(global::ItemModDataBlock mod)
		{
			return base.FindMod(mod);
		}

		// Token: 0x0600374B RID: 14155 RVA: 0x000CD720 File Offset: 0x000CB920
		void OnActivate()
		{
			base.OnActivate();
		}

		// Token: 0x0600374C RID: 14156 RVA: 0x000CD728 File Offset: 0x000CB928
		void OnDeactivate()
		{
			base.OnDeactivate();
		}

		// Token: 0x0600374D RID: 14157 RVA: 0x000CD730 File Offset: 0x000CB930
		global::ViewModel get_viewModelInstance()
		{
			return base.viewModelInstance;
		}

		// Token: 0x0600374E RID: 14158 RVA: 0x000CD738 File Offset: 0x000CB938
		global::ItemRepresentation get_itemRepresentation()
		{
			return base.itemRepresentation;
		}

		// Token: 0x0600374F RID: 14159 RVA: 0x000CD740 File Offset: 0x000CB940
		void set_itemRepresentation(global::ItemRepresentation value)
		{
			base.itemRepresentation = value;
		}

		// Token: 0x06003750 RID: 14160 RVA: 0x000CD74C File Offset: 0x000CB94C
		bool get_canActivate()
		{
			return base.canActivate;
		}

		// Token: 0x06003751 RID: 14161 RVA: 0x000CD754 File Offset: 0x000CB954
		bool get_canDeactivate()
		{
			return base.canDeactivate;
		}

		// Token: 0x06003752 RID: 14162 RVA: 0x000CD75C File Offset: 0x000CB95C
		global::ItemModFlags get_modFlags()
		{
			return base.modFlags;
		}

		// Token: 0x06003753 RID: 14163 RVA: 0x000CD764 File Offset: 0x000CB964
		global::ItemModDataBlock[] get_itemMods()
		{
			return base.itemMods;
		}

		// Token: 0x06003754 RID: 14164 RVA: 0x000CD76C File Offset: 0x000CB96C
		int get_totalModSlots()
		{
			return base.totalModSlots;
		}

		// Token: 0x06003755 RID: 14165 RVA: 0x000CD774 File Offset: 0x000CB974
		int get_usedModSlots()
		{
			return base.usedModSlots;
		}

		// Token: 0x06003756 RID: 14166 RVA: 0x000CD77C File Offset: 0x000CB97C
		int get_freeModSlots()
		{
			return base.freeModSlots;
		}

		// Token: 0x06003757 RID: 14167 RVA: 0x000CD784 File Offset: 0x000CB984
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x06003758 RID: 14168 RVA: 0x000CD78C File Offset: 0x000CB98C
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x06003759 RID: 14169 RVA: 0x000CD794 File Offset: 0x000CB994
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x0600375A RID: 14170 RVA: 0x000CD79C File Offset: 0x000CB99C
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x0600375B RID: 14171 RVA: 0x000CD7A8 File Offset: 0x000CB9A8
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x0600375C RID: 14172 RVA: 0x000CD7B4 File Offset: 0x000CB9B4
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x0600375D RID: 14173 RVA: 0x000CD7C0 File Offset: 0x000CB9C0
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x0600375E RID: 14174 RVA: 0x000CD7CC File Offset: 0x000CB9CC
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x0600375F RID: 14175 RVA: 0x000CD7D8 File Offset: 0x000CB9D8
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x06003760 RID: 14176 RVA: 0x000CD7E4 File Offset: 0x000CB9E4
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x06003761 RID: 14177 RVA: 0x000CD7F0 File Offset: 0x000CB9F0
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x06003762 RID: 14178 RVA: 0x000CD7FC File Offset: 0x000CB9FC
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x06003763 RID: 14179 RVA: 0x000CD804 File Offset: 0x000CBA04
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x06003764 RID: 14180 RVA: 0x000CD810 File Offset: 0x000CBA10
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x06003765 RID: 14181 RVA: 0x000CD81C File Offset: 0x000CBA1C
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x06003766 RID: 14182 RVA: 0x000CD824 File Offset: 0x000CBA24
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x06003767 RID: 14183 RVA: 0x000CD82C File Offset: 0x000CBA2C
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x06003768 RID: 14184 RVA: 0x000CD834 File Offset: 0x000CBA34
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x06003769 RID: 14185 RVA: 0x000CD83C File Offset: 0x000CBA3C
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x0600376A RID: 14186 RVA: 0x000CD844 File Offset: 0x000CBA44
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x0600376B RID: 14187 RVA: 0x000CD84C File Offset: 0x000CBA4C
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x0600376C RID: 14188 RVA: 0x000CD854 File Offset: 0x000CBA54
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x0600376D RID: 14189 RVA: 0x000CD860 File Offset: 0x000CBA60
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x0600376E RID: 14190 RVA: 0x000CD868 File Offset: 0x000CBA68
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x0600376F RID: 14191 RVA: 0x000CD870 File Offset: 0x000CBA70
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x06003770 RID: 14192 RVA: 0x000CD878 File Offset: 0x000CBA78
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x06003771 RID: 14193 RVA: 0x000CD880 File Offset: 0x000CBA80
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x06003772 RID: 14194 RVA: 0x000CD888 File Offset: 0x000CBA88
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x06003773 RID: 14195 RVA: 0x000CD890 File Offset: 0x000CBA90
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
