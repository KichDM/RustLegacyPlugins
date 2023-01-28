using System;
using Facepunch;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x020006BE RID: 1726
public class WeaponDataBlock : global::HeldItemDataBlock
{
	// Token: 0x06003AC0 RID: 15040 RVA: 0x000D17F8 File Offset: 0x000CF9F8
	public WeaponDataBlock()
	{
	}

	// Token: 0x06003AC1 RID: 15041 RVA: 0x000D1838 File Offset: 0x000CFA38
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::WeaponDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x06003AC2 RID: 15042 RVA: 0x000D1840 File Offset: 0x000CFA40
	public virtual float GetDamage()
	{
		return global::UnityEngine.Random.Range(this.damageMin, this.damageMax);
	}

	// Token: 0x06003AC3 RID: 15043 RVA: 0x000D1854 File Offset: 0x000CFA54
	public override void InstallData(global::IInventoryItem item)
	{
		base.InstallData(item);
	}

	// Token: 0x06003AC4 RID: 15044 RVA: 0x000D1860 File Offset: 0x000CFA60
	protected virtual void PlayHitNotification(global::UnityEngine.Vector3 point, global::Character shooterOrNull)
	{
		if (global::WeaponDataBlock._hitNotify || global::Facepunch.Bundling.Load<global::UnityEngine.AudioClip>("content/shared/sfx/hitnotification", out global::WeaponDataBlock._hitNotify))
		{
			global::WeaponDataBlock._hitNotify.PlayLocal(global::UnityEngine.Camera.main.transform, global::UnityEngine.Vector3.zero, 1f, 1);
		}
		if (global::WeaponDataBlock._hitIndicator || global::Facepunch.Bundling.Load<global::HUDHitIndicator>("content/hud/HUDHitIndicator", out global::WeaponDataBlock._hitIndicator))
		{
			bool flag = !shooterOrNull || !shooterOrNull.stateFlags.aim;
		}
	}

	// Token: 0x06003AC5 RID: 15045 RVA: 0x000D18F0 File Offset: 0x000CFAF0
	protected override void SecureWriteMemberValues(global::uLink.BitStream stream)
	{
		base.SecureWriteMemberValues(stream);
		stream.Write<float>(this.deployLength, new object[0]);
		stream.Write<float>(this.damageMin, new object[0]);
		stream.Write<float>(this.damageMax, new object[0]);
		stream.Write<float>(this.fireRate, new object[0]);
		stream.Write<float>(this.fireRateSecondary, new object[0]);
		stream.Write<bool>(this.isSemiAuto, new object[0]);
	}

	// Token: 0x04001E2F RID: 7727
	public bool isSemiAuto;

	// Token: 0x04001E30 RID: 7728
	public float fireRate = 1f;

	// Token: 0x04001E31 RID: 7729
	public float fireRateSecondary = 1f;

	// Token: 0x04001E32 RID: 7730
	public float deployLength = 0.75f;

	// Token: 0x04001E33 RID: 7731
	public float damageMin = 5f;

	// Token: 0x04001E34 RID: 7732
	public float damageMax = 5f;

	// Token: 0x04001E35 RID: 7733
	public static global::UnityEngine.AudioClip _hitNotify;

	// Token: 0x04001E36 RID: 7734
	private static global::HUDHitIndicator _hitIndicator;

	// Token: 0x020006BF RID: 1727
	private sealed class ITEM_TYPE : global::WeaponItem<global::WeaponDataBlock>, global::IHeldItem, global::IInventoryItem, global::IWeaponItem
	{
		// Token: 0x06003AC6 RID: 15046 RVA: 0x000D1970 File Offset: 0x000CFB70
		public ITEM_TYPE(global::WeaponDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000B13 RID: 2835
		// (get) Token: 0x06003AC7 RID: 15047 RVA: 0x000D197C File Offset: 0x000CFB7C
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x06003AC8 RID: 15048 RVA: 0x000D1984 File Offset: 0x000CFB84
		bool ValidatePrimaryMessageTime(double timestamp)
		{
			return base.ValidatePrimaryMessageTime(timestamp);
		}

		// Token: 0x06003AC9 RID: 15049 RVA: 0x000D1990 File Offset: 0x000CFB90
		bool get_canAim()
		{
			return base.canAim;
		}

		// Token: 0x06003ACA RID: 15050 RVA: 0x000D1998 File Offset: 0x000CFB98
		float get_nextPrimaryAttackTime()
		{
			return base.nextPrimaryAttackTime;
		}

		// Token: 0x06003ACB RID: 15051 RVA: 0x000D19A0 File Offset: 0x000CFBA0
		void set_nextPrimaryAttackTime(float value)
		{
			base.nextPrimaryAttackTime = value;
		}

		// Token: 0x06003ACC RID: 15052 RVA: 0x000D19AC File Offset: 0x000CFBAC
		float get_nextSecondaryAttackTime()
		{
			return base.nextSecondaryAttackTime;
		}

		// Token: 0x06003ACD RID: 15053 RVA: 0x000D19B4 File Offset: 0x000CFBB4
		void set_nextSecondaryAttackTime(float value)
		{
			base.nextSecondaryAttackTime = value;
		}

		// Token: 0x06003ACE RID: 15054 RVA: 0x000D19C0 File Offset: 0x000CFBC0
		float get_deployFinishedTime()
		{
			return base.deployFinishedTime;
		}

		// Token: 0x06003ACF RID: 15055 RVA: 0x000D19C8 File Offset: 0x000CFBC8
		void set_deployFinishedTime(float value)
		{
			base.deployFinishedTime = value;
		}

		// Token: 0x06003AD0 RID: 15056 RVA: 0x000D19D4 File Offset: 0x000CFBD4
		void SetTotalModSlotCount(int count)
		{
			base.SetTotalModSlotCount(count);
		}

		// Token: 0x06003AD1 RID: 15057 RVA: 0x000D19E0 File Offset: 0x000CFBE0
		void SetUsedModSlotCount(int count)
		{
			base.SetUsedModSlotCount(count);
		}

		// Token: 0x06003AD2 RID: 15058 RVA: 0x000D19EC File Offset: 0x000CFBEC
		void AddMod(global::ItemModDataBlock mod)
		{
			base.AddMod(mod);
		}

		// Token: 0x06003AD3 RID: 15059 RVA: 0x000D19F8 File Offset: 0x000CFBF8
		int FindMod(global::ItemModDataBlock mod)
		{
			return base.FindMod(mod);
		}

		// Token: 0x06003AD4 RID: 15060 RVA: 0x000D1A04 File Offset: 0x000CFC04
		void OnActivate()
		{
			base.OnActivate();
		}

		// Token: 0x06003AD5 RID: 15061 RVA: 0x000D1A0C File Offset: 0x000CFC0C
		void OnDeactivate()
		{
			base.OnDeactivate();
		}

		// Token: 0x06003AD6 RID: 15062 RVA: 0x000D1A14 File Offset: 0x000CFC14
		global::ViewModel get_viewModelInstance()
		{
			return base.viewModelInstance;
		}

		// Token: 0x06003AD7 RID: 15063 RVA: 0x000D1A1C File Offset: 0x000CFC1C
		global::ItemRepresentation get_itemRepresentation()
		{
			return base.itemRepresentation;
		}

		// Token: 0x06003AD8 RID: 15064 RVA: 0x000D1A24 File Offset: 0x000CFC24
		void set_itemRepresentation(global::ItemRepresentation value)
		{
			base.itemRepresentation = value;
		}

		// Token: 0x06003AD9 RID: 15065 RVA: 0x000D1A30 File Offset: 0x000CFC30
		bool get_canActivate()
		{
			return base.canActivate;
		}

		// Token: 0x06003ADA RID: 15066 RVA: 0x000D1A38 File Offset: 0x000CFC38
		bool get_canDeactivate()
		{
			return base.canDeactivate;
		}

		// Token: 0x06003ADB RID: 15067 RVA: 0x000D1A40 File Offset: 0x000CFC40
		global::ItemModFlags get_modFlags()
		{
			return base.modFlags;
		}

		// Token: 0x06003ADC RID: 15068 RVA: 0x000D1A48 File Offset: 0x000CFC48
		global::ItemModDataBlock[] get_itemMods()
		{
			return base.itemMods;
		}

		// Token: 0x06003ADD RID: 15069 RVA: 0x000D1A50 File Offset: 0x000CFC50
		int get_totalModSlots()
		{
			return base.totalModSlots;
		}

		// Token: 0x06003ADE RID: 15070 RVA: 0x000D1A58 File Offset: 0x000CFC58
		int get_usedModSlots()
		{
			return base.usedModSlots;
		}

		// Token: 0x06003ADF RID: 15071 RVA: 0x000D1A60 File Offset: 0x000CFC60
		int get_freeModSlots()
		{
			return base.freeModSlots;
		}

		// Token: 0x06003AE0 RID: 15072 RVA: 0x000D1A68 File Offset: 0x000CFC68
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x06003AE1 RID: 15073 RVA: 0x000D1A70 File Offset: 0x000CFC70
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x06003AE2 RID: 15074 RVA: 0x000D1A78 File Offset: 0x000CFC78
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x06003AE3 RID: 15075 RVA: 0x000D1A80 File Offset: 0x000CFC80
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x06003AE4 RID: 15076 RVA: 0x000D1A8C File Offset: 0x000CFC8C
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x06003AE5 RID: 15077 RVA: 0x000D1A98 File Offset: 0x000CFC98
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x06003AE6 RID: 15078 RVA: 0x000D1AA4 File Offset: 0x000CFCA4
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x06003AE7 RID: 15079 RVA: 0x000D1AB0 File Offset: 0x000CFCB0
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x06003AE8 RID: 15080 RVA: 0x000D1ABC File Offset: 0x000CFCBC
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x06003AE9 RID: 15081 RVA: 0x000D1AC8 File Offset: 0x000CFCC8
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x06003AEA RID: 15082 RVA: 0x000D1AD4 File Offset: 0x000CFCD4
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x06003AEB RID: 15083 RVA: 0x000D1AE0 File Offset: 0x000CFCE0
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x06003AEC RID: 15084 RVA: 0x000D1AE8 File Offset: 0x000CFCE8
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x06003AED RID: 15085 RVA: 0x000D1AF4 File Offset: 0x000CFCF4
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x06003AEE RID: 15086 RVA: 0x000D1B00 File Offset: 0x000CFD00
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x06003AEF RID: 15087 RVA: 0x000D1B08 File Offset: 0x000CFD08
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x06003AF0 RID: 15088 RVA: 0x000D1B10 File Offset: 0x000CFD10
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x06003AF1 RID: 15089 RVA: 0x000D1B18 File Offset: 0x000CFD18
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x06003AF2 RID: 15090 RVA: 0x000D1B20 File Offset: 0x000CFD20
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x06003AF3 RID: 15091 RVA: 0x000D1B28 File Offset: 0x000CFD28
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x06003AF4 RID: 15092 RVA: 0x000D1B30 File Offset: 0x000CFD30
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x06003AF5 RID: 15093 RVA: 0x000D1B38 File Offset: 0x000CFD38
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x06003AF6 RID: 15094 RVA: 0x000D1B44 File Offset: 0x000CFD44
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x06003AF7 RID: 15095 RVA: 0x000D1B4C File Offset: 0x000CFD4C
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x06003AF8 RID: 15096 RVA: 0x000D1B54 File Offset: 0x000CFD54
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x06003AF9 RID: 15097 RVA: 0x000D1B5C File Offset: 0x000CFD5C
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x06003AFA RID: 15098 RVA: 0x000D1B64 File Offset: 0x000CFD64
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x06003AFB RID: 15099 RVA: 0x000D1B6C File Offset: 0x000CFD6C
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x06003AFC RID: 15100 RVA: 0x000D1B74 File Offset: 0x000CFD74
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
