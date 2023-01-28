using System;
using Facepunch;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x020006B4 RID: 1716
public class ThrowableItemDataBlock : global::WeaponDataBlock
{
	// Token: 0x060039B6 RID: 14774 RVA: 0x000D085C File Offset: 0x000CEA5C
	public ThrowableItemDataBlock()
	{
	}

	// Token: 0x060039B7 RID: 14775 RVA: 0x000D0888 File Offset: 0x000CEA88
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::ThrowableItemDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x060039B8 RID: 14776 RVA: 0x000D0890 File Offset: 0x000CEA90
	public override void InstallData(global::IInventoryItem item)
	{
		base.InstallData(item);
	}

	// Token: 0x060039B9 RID: 14777 RVA: 0x000D089C File Offset: 0x000CEA9C
	public global::IThrowableItem GetThrowableInstance(global::IInventoryItem itemInstance)
	{
		return itemInstance as global::IThrowableItem;
	}

	// Token: 0x060039BA RID: 14778 RVA: 0x000D08A4 File Offset: 0x000CEAA4
	public virtual void PrimaryAttack(global::ViewModel vm, global::ItemRepresentation itemRep, global::IThrowableItem itemInstance, ref global::HumanController.InputSample sample)
	{
		this.GetThrowableInstance(itemInstance).BeginHoldingBack();
	}

	// Token: 0x060039BB RID: 14779 RVA: 0x000D08B4 File Offset: 0x000CEAB4
	public virtual void SecondaryAttack(global::ViewModel vm, global::ItemRepresentation itemRep, global::IThrowableItem itemInstance, ref global::HumanController.InputSample sample)
	{
	}

	// Token: 0x060039BC RID: 14780 RVA: 0x000D08B8 File Offset: 0x000CEAB8
	public virtual void AttackReleased(global::ViewModel vm, global::ItemRepresentation itemRep, global::IThrowableItem itemInstance, ref global::HumanController.InputSample sample)
	{
		global::UnityEngine.Debug.Log("Throwable attack released");
	}

	// Token: 0x060039BD RID: 14781 RVA: 0x000D08C4 File Offset: 0x000CEAC4
	protected virtual global::UnityEngine.GameObject SpawnThrowItem(global::uLink.NetworkViewID owningViewID, global::UnityEngine.GameObject prefab, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, global::UnityEngine.Vector3 velocity)
	{
		return global::RigidObj.InstantiateRigidObj<global::RigidObj>(owningViewID, this.throwObjectPrefab, position, rotation, velocity).gameObject;
	}

	// Token: 0x060039BE RID: 14782 RVA: 0x000D08DC File Offset: 0x000CEADC
	protected virtual global::UnityEngine.GameObject ThrowItem(global::ItemRepresentation rep, global::IThrowableItem item, global::UnityEngine.Vector3 origin, global::UnityEngine.Vector3 forward, global::uLink.NetworkViewID owner)
	{
		global::UnityEngine.Vector3 velocity = forward * item.heldThrowStrength;
		global::UnityEngine.Vector3 position = origin + forward * 1f;
		global::UnityEngine.Quaternion rotation = global::UnityEngine.Quaternion.LookRotation(global::UnityEngine.Vector3.up);
		return this.SpawnThrowItem(owner, this.throwObjectPrefab, position, rotation, velocity);
	}

	// Token: 0x060039BF RID: 14783 RVA: 0x000D0928 File Offset: 0x000CEB28
	public global::UnityEngine.GameObject ThrowItem(global::ItemRepresentation rep, global::UnityEngine.Vector3 origin, global::UnityEngine.Vector3 forward)
	{
		global::IThrowableItem throwableItem;
		if (!rep.Item<global::IThrowableItem>(out throwableItem))
		{
			return null;
		}
		global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Get(throwableItem.inventory);
		return this.ThrowItem(rep, throwableItem, origin, forward, (!networkView) ? global::uLink.NetworkViewID.unassigned : networkView.viewID);
	}

	// Token: 0x060039C0 RID: 14784 RVA: 0x000D0978 File Offset: 0x000CEB78
	protected override void SecureWriteMemberValues(global::uLink.BitStream stream)
	{
		base.SecureWriteMemberValues(stream);
		stream.Write<float>(this.throwStrengthMin, new object[0]);
		stream.Write<float>(this.throwStrengthPerSec, new object[0]);
		stream.Write<float>(this.throwStrengthMax, new object[0]);
	}

	// Token: 0x04001E28 RID: 7720
	public global::UnityEngine.GameObject throwObjectPrefab;

	// Token: 0x04001E29 RID: 7721
	public float throwStrengthMin = 10f;

	// Token: 0x04001E2A RID: 7722
	public float throwStrengthPerSec = 10f;

	// Token: 0x04001E2B RID: 7723
	public float throwStrengthMax = 10f;

	// Token: 0x020006B5 RID: 1717
	private sealed class ITEM_TYPE : global::ThrowableItem<global::ThrowableItemDataBlock>, global::IHeldItem, global::IInventoryItem, global::IThrowableItem, global::IWeaponItem
	{
		// Token: 0x060039C1 RID: 14785 RVA: 0x000D09C4 File Offset: 0x000CEBC4
		public ITEM_TYPE(global::ThrowableItemDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000B0E RID: 2830
		// (get) Token: 0x060039C2 RID: 14786 RVA: 0x000D09D0 File Offset: 0x000CEBD0
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x060039C3 RID: 14787 RVA: 0x000D09D8 File Offset: 0x000CEBD8
		float get_holdingStartTime()
		{
			return base.holdingStartTime;
		}

		// Token: 0x060039C4 RID: 14788 RVA: 0x000D09E0 File Offset: 0x000CEBE0
		void set_holdingStartTime(float value)
		{
			base.holdingStartTime = value;
		}

		// Token: 0x060039C5 RID: 14789 RVA: 0x000D09EC File Offset: 0x000CEBEC
		bool get_holdingBack()
		{
			return base.holdingBack;
		}

		// Token: 0x060039C6 RID: 14790 RVA: 0x000D09F4 File Offset: 0x000CEBF4
		void set_holdingBack(bool value)
		{
			base.holdingBack = value;
		}

		// Token: 0x060039C7 RID: 14791 RVA: 0x000D0A00 File Offset: 0x000CEC00
		float get_minReleaseTime()
		{
			return base.minReleaseTime;
		}

		// Token: 0x060039C8 RID: 14792 RVA: 0x000D0A08 File Offset: 0x000CEC08
		void set_minReleaseTime(float value)
		{
			base.minReleaseTime = value;
		}

		// Token: 0x060039C9 RID: 14793 RVA: 0x000D0A14 File Offset: 0x000CEC14
		bool ValidatePrimaryMessageTime(double timestamp)
		{
			return base.ValidatePrimaryMessageTime(timestamp);
		}

		// Token: 0x060039CA RID: 14794 RVA: 0x000D0A20 File Offset: 0x000CEC20
		bool get_canAim()
		{
			return base.canAim;
		}

		// Token: 0x060039CB RID: 14795 RVA: 0x000D0A28 File Offset: 0x000CEC28
		float get_nextPrimaryAttackTime()
		{
			return base.nextPrimaryAttackTime;
		}

		// Token: 0x060039CC RID: 14796 RVA: 0x000D0A30 File Offset: 0x000CEC30
		void set_nextPrimaryAttackTime(float value)
		{
			base.nextPrimaryAttackTime = value;
		}

		// Token: 0x060039CD RID: 14797 RVA: 0x000D0A3C File Offset: 0x000CEC3C
		float get_nextSecondaryAttackTime()
		{
			return base.nextSecondaryAttackTime;
		}

		// Token: 0x060039CE RID: 14798 RVA: 0x000D0A44 File Offset: 0x000CEC44
		void set_nextSecondaryAttackTime(float value)
		{
			base.nextSecondaryAttackTime = value;
		}

		// Token: 0x060039CF RID: 14799 RVA: 0x000D0A50 File Offset: 0x000CEC50
		float get_deployFinishedTime()
		{
			return base.deployFinishedTime;
		}

		// Token: 0x060039D0 RID: 14800 RVA: 0x000D0A58 File Offset: 0x000CEC58
		void set_deployFinishedTime(float value)
		{
			base.deployFinishedTime = value;
		}

		// Token: 0x060039D1 RID: 14801 RVA: 0x000D0A64 File Offset: 0x000CEC64
		void SetTotalModSlotCount(int count)
		{
			base.SetTotalModSlotCount(count);
		}

		// Token: 0x060039D2 RID: 14802 RVA: 0x000D0A70 File Offset: 0x000CEC70
		void SetUsedModSlotCount(int count)
		{
			base.SetUsedModSlotCount(count);
		}

		// Token: 0x060039D3 RID: 14803 RVA: 0x000D0A7C File Offset: 0x000CEC7C
		void AddMod(global::ItemModDataBlock mod)
		{
			base.AddMod(mod);
		}

		// Token: 0x060039D4 RID: 14804 RVA: 0x000D0A88 File Offset: 0x000CEC88
		int FindMod(global::ItemModDataBlock mod)
		{
			return base.FindMod(mod);
		}

		// Token: 0x060039D5 RID: 14805 RVA: 0x000D0A94 File Offset: 0x000CEC94
		void OnActivate()
		{
			base.OnActivate();
		}

		// Token: 0x060039D6 RID: 14806 RVA: 0x000D0A9C File Offset: 0x000CEC9C
		void OnDeactivate()
		{
			base.OnDeactivate();
		}

		// Token: 0x060039D7 RID: 14807 RVA: 0x000D0AA4 File Offset: 0x000CECA4
		global::ViewModel get_viewModelInstance()
		{
			return base.viewModelInstance;
		}

		// Token: 0x060039D8 RID: 14808 RVA: 0x000D0AAC File Offset: 0x000CECAC
		global::ItemRepresentation get_itemRepresentation()
		{
			return base.itemRepresentation;
		}

		// Token: 0x060039D9 RID: 14809 RVA: 0x000D0AB4 File Offset: 0x000CECB4
		void set_itemRepresentation(global::ItemRepresentation value)
		{
			base.itemRepresentation = value;
		}

		// Token: 0x060039DA RID: 14810 RVA: 0x000D0AC0 File Offset: 0x000CECC0
		bool get_canActivate()
		{
			return base.canActivate;
		}

		// Token: 0x060039DB RID: 14811 RVA: 0x000D0AC8 File Offset: 0x000CECC8
		bool get_canDeactivate()
		{
			return base.canDeactivate;
		}

		// Token: 0x060039DC RID: 14812 RVA: 0x000D0AD0 File Offset: 0x000CECD0
		global::ItemModFlags get_modFlags()
		{
			return base.modFlags;
		}

		// Token: 0x060039DD RID: 14813 RVA: 0x000D0AD8 File Offset: 0x000CECD8
		global::ItemModDataBlock[] get_itemMods()
		{
			return base.itemMods;
		}

		// Token: 0x060039DE RID: 14814 RVA: 0x000D0AE0 File Offset: 0x000CECE0
		int get_totalModSlots()
		{
			return base.totalModSlots;
		}

		// Token: 0x060039DF RID: 14815 RVA: 0x000D0AE8 File Offset: 0x000CECE8
		int get_usedModSlots()
		{
			return base.usedModSlots;
		}

		// Token: 0x060039E0 RID: 14816 RVA: 0x000D0AF0 File Offset: 0x000CECF0
		int get_freeModSlots()
		{
			return base.freeModSlots;
		}

		// Token: 0x060039E1 RID: 14817 RVA: 0x000D0AF8 File Offset: 0x000CECF8
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x060039E2 RID: 14818 RVA: 0x000D0B00 File Offset: 0x000CED00
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x060039E3 RID: 14819 RVA: 0x000D0B08 File Offset: 0x000CED08
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x060039E4 RID: 14820 RVA: 0x000D0B10 File Offset: 0x000CED10
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x060039E5 RID: 14821 RVA: 0x000D0B1C File Offset: 0x000CED1C
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x060039E6 RID: 14822 RVA: 0x000D0B28 File Offset: 0x000CED28
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x060039E7 RID: 14823 RVA: 0x000D0B34 File Offset: 0x000CED34
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x060039E8 RID: 14824 RVA: 0x000D0B40 File Offset: 0x000CED40
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x060039E9 RID: 14825 RVA: 0x000D0B4C File Offset: 0x000CED4C
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x060039EA RID: 14826 RVA: 0x000D0B58 File Offset: 0x000CED58
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x060039EB RID: 14827 RVA: 0x000D0B64 File Offset: 0x000CED64
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x060039EC RID: 14828 RVA: 0x000D0B70 File Offset: 0x000CED70
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x060039ED RID: 14829 RVA: 0x000D0B78 File Offset: 0x000CED78
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x060039EE RID: 14830 RVA: 0x000D0B84 File Offset: 0x000CED84
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x060039EF RID: 14831 RVA: 0x000D0B90 File Offset: 0x000CED90
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x060039F0 RID: 14832 RVA: 0x000D0B98 File Offset: 0x000CED98
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x060039F1 RID: 14833 RVA: 0x000D0BA0 File Offset: 0x000CEDA0
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x060039F2 RID: 14834 RVA: 0x000D0BA8 File Offset: 0x000CEDA8
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x060039F3 RID: 14835 RVA: 0x000D0BB0 File Offset: 0x000CEDB0
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x060039F4 RID: 14836 RVA: 0x000D0BB8 File Offset: 0x000CEDB8
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x060039F5 RID: 14837 RVA: 0x000D0BC0 File Offset: 0x000CEDC0
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x060039F6 RID: 14838 RVA: 0x000D0BC8 File Offset: 0x000CEDC8
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x060039F7 RID: 14839 RVA: 0x000D0BD4 File Offset: 0x000CEDD4
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x060039F8 RID: 14840 RVA: 0x000D0BDC File Offset: 0x000CEDDC
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x060039F9 RID: 14841 RVA: 0x000D0BE4 File Offset: 0x000CEDE4
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x060039FA RID: 14842 RVA: 0x000D0BEC File Offset: 0x000CEDEC
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x060039FB RID: 14843 RVA: 0x000D0BF4 File Offset: 0x000CEDF4
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x060039FC RID: 14844 RVA: 0x000D0BFC File Offset: 0x000CEDFC
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x060039FD RID: 14845 RVA: 0x000D0C04 File Offset: 0x000CEE04
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
