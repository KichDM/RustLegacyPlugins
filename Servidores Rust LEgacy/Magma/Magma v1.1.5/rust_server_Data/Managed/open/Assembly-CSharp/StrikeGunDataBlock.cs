using System;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x020006B0 RID: 1712
public class StrikeGunDataBlock : global::ShotgunDataBlock
{
	// Token: 0x0600393E RID: 14654 RVA: 0x000D0190 File Offset: 0x000CE390
	public StrikeGunDataBlock()
	{
	}

	// Token: 0x0600393F RID: 14655 RVA: 0x000D0198 File Offset: 0x000CE398
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::StrikeGunDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x06003940 RID: 14656 RVA: 0x000D01A0 File Offset: 0x000CE3A0
	public virtual void Local_CancelStrikes(global::ViewModel vm, global::ItemRepresentation itemRep, global::IStrikeGunItem itemInstance, ref global::HumanController.InputSample sample)
	{
	}

	// Token: 0x06003941 RID: 14657 RVA: 0x000D01A4 File Offset: 0x000CE3A4
	public virtual void Local_BeginStrikes(int numStrikes, global::ViewModel vm, global::ItemRepresentation itemRep, global::IStrikeGunItem itemInstance, ref global::HumanController.InputSample sample)
	{
	}

	// Token: 0x06003942 RID: 14658 RVA: 0x000D01A8 File Offset: 0x000CE3A8
	public override string GetItemDescription()
	{
		return "Unreliable shotgun type weapon, uses homemade shells";
	}

	// Token: 0x04001E22 RID: 7714
	public float[] strikeDurations;

	// Token: 0x04001E23 RID: 7715
	public global::UnityEngine.AudioClip[] strikeSounds;

	// Token: 0x020006B1 RID: 1713
	private sealed class ITEM_TYPE : global::StrikeGunItem<global::StrikeGunDataBlock>, global::IBulletWeaponItem, global::IHeldItem, global::IInventoryItem, global::IStrikeGunItem, global::IWeaponItem
	{
		// Token: 0x06003943 RID: 14659 RVA: 0x000D01B0 File Offset: 0x000CE3B0
		public ITEM_TYPE(global::StrikeGunDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000B0B RID: 2827
		// (get) Token: 0x06003944 RID: 14660 RVA: 0x000D01BC File Offset: 0x000CE3BC
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x06003945 RID: 14661 RVA: 0x000D01C4 File Offset: 0x000CE3C4
		global::MagazineDataBlock get_clipType()
		{
			return base.clipType;
		}

		// Token: 0x06003946 RID: 14662 RVA: 0x000D01CC File Offset: 0x000CE3CC
		int get_clipAmmo()
		{
			return base.clipAmmo;
		}

		// Token: 0x06003947 RID: 14663 RVA: 0x000D01D4 File Offset: 0x000CE3D4
		void set_clipAmmo(int value)
		{
			base.clipAmmo = value;
		}

		// Token: 0x06003948 RID: 14664 RVA: 0x000D01E0 File Offset: 0x000CE3E0
		int get_cachedCasings()
		{
			return base.cachedCasings;
		}

		// Token: 0x06003949 RID: 14665 RVA: 0x000D01E8 File Offset: 0x000CE3E8
		void set_cachedCasings(int value)
		{
			base.cachedCasings = value;
		}

		// Token: 0x0600394A RID: 14666 RVA: 0x000D01F4 File Offset: 0x000CE3F4
		float get_nextCasingsTime()
		{
			return base.nextCasingsTime;
		}

		// Token: 0x0600394B RID: 14667 RVA: 0x000D01FC File Offset: 0x000CE3FC
		void set_nextCasingsTime(float value)
		{
			base.nextCasingsTime = value;
		}

		// Token: 0x0600394C RID: 14668 RVA: 0x000D0208 File Offset: 0x000CE408
		bool ValidatePrimaryMessageTime(double timestamp)
		{
			return base.ValidatePrimaryMessageTime(timestamp);
		}

		// Token: 0x0600394D RID: 14669 RVA: 0x000D0214 File Offset: 0x000CE414
		bool get_canAim()
		{
			return base.canAim;
		}

		// Token: 0x0600394E RID: 14670 RVA: 0x000D021C File Offset: 0x000CE41C
		float get_nextPrimaryAttackTime()
		{
			return base.nextPrimaryAttackTime;
		}

		// Token: 0x0600394F RID: 14671 RVA: 0x000D0224 File Offset: 0x000CE424
		void set_nextPrimaryAttackTime(float value)
		{
			base.nextPrimaryAttackTime = value;
		}

		// Token: 0x06003950 RID: 14672 RVA: 0x000D0230 File Offset: 0x000CE430
		float get_nextSecondaryAttackTime()
		{
			return base.nextSecondaryAttackTime;
		}

		// Token: 0x06003951 RID: 14673 RVA: 0x000D0238 File Offset: 0x000CE438
		void set_nextSecondaryAttackTime(float value)
		{
			base.nextSecondaryAttackTime = value;
		}

		// Token: 0x06003952 RID: 14674 RVA: 0x000D0244 File Offset: 0x000CE444
		float get_deployFinishedTime()
		{
			return base.deployFinishedTime;
		}

		// Token: 0x06003953 RID: 14675 RVA: 0x000D024C File Offset: 0x000CE44C
		void set_deployFinishedTime(float value)
		{
			base.deployFinishedTime = value;
		}

		// Token: 0x06003954 RID: 14676 RVA: 0x000D0258 File Offset: 0x000CE458
		void SetTotalModSlotCount(int count)
		{
			base.SetTotalModSlotCount(count);
		}

		// Token: 0x06003955 RID: 14677 RVA: 0x000D0264 File Offset: 0x000CE464
		void SetUsedModSlotCount(int count)
		{
			base.SetUsedModSlotCount(count);
		}

		// Token: 0x06003956 RID: 14678 RVA: 0x000D0270 File Offset: 0x000CE470
		void AddMod(global::ItemModDataBlock mod)
		{
			base.AddMod(mod);
		}

		// Token: 0x06003957 RID: 14679 RVA: 0x000D027C File Offset: 0x000CE47C
		int FindMod(global::ItemModDataBlock mod)
		{
			return base.FindMod(mod);
		}

		// Token: 0x06003958 RID: 14680 RVA: 0x000D0288 File Offset: 0x000CE488
		void OnActivate()
		{
			base.OnActivate();
		}

		// Token: 0x06003959 RID: 14681 RVA: 0x000D0290 File Offset: 0x000CE490
		void OnDeactivate()
		{
			base.OnDeactivate();
		}

		// Token: 0x0600395A RID: 14682 RVA: 0x000D0298 File Offset: 0x000CE498
		global::ViewModel get_viewModelInstance()
		{
			return base.viewModelInstance;
		}

		// Token: 0x0600395B RID: 14683 RVA: 0x000D02A0 File Offset: 0x000CE4A0
		global::ItemRepresentation get_itemRepresentation()
		{
			return base.itemRepresentation;
		}

		// Token: 0x0600395C RID: 14684 RVA: 0x000D02A8 File Offset: 0x000CE4A8
		void set_itemRepresentation(global::ItemRepresentation value)
		{
			base.itemRepresentation = value;
		}

		// Token: 0x0600395D RID: 14685 RVA: 0x000D02B4 File Offset: 0x000CE4B4
		bool get_canActivate()
		{
			return base.canActivate;
		}

		// Token: 0x0600395E RID: 14686 RVA: 0x000D02BC File Offset: 0x000CE4BC
		bool get_canDeactivate()
		{
			return base.canDeactivate;
		}

		// Token: 0x0600395F RID: 14687 RVA: 0x000D02C4 File Offset: 0x000CE4C4
		global::ItemModFlags get_modFlags()
		{
			return base.modFlags;
		}

		// Token: 0x06003960 RID: 14688 RVA: 0x000D02CC File Offset: 0x000CE4CC
		global::ItemModDataBlock[] get_itemMods()
		{
			return base.itemMods;
		}

		// Token: 0x06003961 RID: 14689 RVA: 0x000D02D4 File Offset: 0x000CE4D4
		int get_totalModSlots()
		{
			return base.totalModSlots;
		}

		// Token: 0x06003962 RID: 14690 RVA: 0x000D02DC File Offset: 0x000CE4DC
		int get_usedModSlots()
		{
			return base.usedModSlots;
		}

		// Token: 0x06003963 RID: 14691 RVA: 0x000D02E4 File Offset: 0x000CE4E4
		int get_freeModSlots()
		{
			return base.freeModSlots;
		}

		// Token: 0x06003964 RID: 14692 RVA: 0x000D02EC File Offset: 0x000CE4EC
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x06003965 RID: 14693 RVA: 0x000D02F4 File Offset: 0x000CE4F4
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x06003966 RID: 14694 RVA: 0x000D02FC File Offset: 0x000CE4FC
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x06003967 RID: 14695 RVA: 0x000D0304 File Offset: 0x000CE504
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x06003968 RID: 14696 RVA: 0x000D0310 File Offset: 0x000CE510
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x06003969 RID: 14697 RVA: 0x000D031C File Offset: 0x000CE51C
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x0600396A RID: 14698 RVA: 0x000D0328 File Offset: 0x000CE528
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x0600396B RID: 14699 RVA: 0x000D0334 File Offset: 0x000CE534
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x0600396C RID: 14700 RVA: 0x000D0340 File Offset: 0x000CE540
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x0600396D RID: 14701 RVA: 0x000D034C File Offset: 0x000CE54C
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x0600396E RID: 14702 RVA: 0x000D0358 File Offset: 0x000CE558
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x0600396F RID: 14703 RVA: 0x000D0364 File Offset: 0x000CE564
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x06003970 RID: 14704 RVA: 0x000D036C File Offset: 0x000CE56C
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x06003971 RID: 14705 RVA: 0x000D0378 File Offset: 0x000CE578
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x06003972 RID: 14706 RVA: 0x000D0384 File Offset: 0x000CE584
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x06003973 RID: 14707 RVA: 0x000D038C File Offset: 0x000CE58C
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x06003974 RID: 14708 RVA: 0x000D0394 File Offset: 0x000CE594
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x06003975 RID: 14709 RVA: 0x000D039C File Offset: 0x000CE59C
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x06003976 RID: 14710 RVA: 0x000D03A4 File Offset: 0x000CE5A4
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x06003977 RID: 14711 RVA: 0x000D03AC File Offset: 0x000CE5AC
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x06003978 RID: 14712 RVA: 0x000D03B4 File Offset: 0x000CE5B4
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x06003979 RID: 14713 RVA: 0x000D03BC File Offset: 0x000CE5BC
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x0600397A RID: 14714 RVA: 0x000D03C8 File Offset: 0x000CE5C8
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x0600397B RID: 14715 RVA: 0x000D03D0 File Offset: 0x000CE5D0
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x0600397C RID: 14716 RVA: 0x000D03D8 File Offset: 0x000CE5D8
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x0600397D RID: 14717 RVA: 0x000D03E0 File Offset: 0x000CE5E0
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x0600397E RID: 14718 RVA: 0x000D03E8 File Offset: 0x000CE5E8
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x0600397F RID: 14719 RVA: 0x000D03F0 File Offset: 0x000CE5F0
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x06003980 RID: 14720 RVA: 0x000D03F8 File Offset: 0x000CE5F8
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
