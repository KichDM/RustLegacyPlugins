using System;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x020006A3 RID: 1699
public class BaseWeaponModDataBlock : global::ItemModDataBlock
{
	// Token: 0x0600387A RID: 14458 RVA: 0x000CF0FC File Offset: 0x000CD2FC
	protected BaseWeaponModDataBlock(global::System.Type minimumItemModRepresentationType) : base(minimumItemModRepresentationType)
	{
		if (!typeof(global::WeaponModRep).IsAssignableFrom(minimumItemModRepresentationType))
		{
			throw new global::System.ArgumentOutOfRangeException("minimumItemModRepresentationType", minimumItemModRepresentationType, "!typeof(WeaponModRep).IsAssignableFrom(minimumItemModRepresentationType)");
		}
	}

	// Token: 0x0600387B RID: 14459 RVA: 0x000CF158 File Offset: 0x000CD358
	public BaseWeaponModDataBlock() : this(typeof(global::WeaponModRep))
	{
	}

	// Token: 0x0600387C RID: 14460 RVA: 0x000CF16C File Offset: 0x000CD36C
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::BaseWeaponModDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x0600387D RID: 14461 RVA: 0x000CF174 File Offset: 0x000CD374
	protected override void InstallToItemModRepresentation(global::ItemModRepresentation modRep)
	{
		base.InstallToItemModRepresentation(modRep);
		if (this.attachObjectRep != null)
		{
			global::UnityEngine.GameObject gameObject = modRep.itemRep.muzzle.InstantiateAsChild(this.attachObjectRep, false);
			gameObject.name = this.attachObjectRep.name;
			((global::WeaponModRep)modRep).SetAttached(gameObject, false);
		}
	}

	// Token: 0x0600387E RID: 14462 RVA: 0x000CF1D0 File Offset: 0x000CD3D0
	protected override void UninstallFromItemModRepresentation(global::ItemModRepresentation rep)
	{
		global::WeaponModRep weaponModRep = (global::WeaponModRep)rep;
		global::UnityEngine.GameObject attached = weaponModRep.attached;
		if (attached)
		{
			weaponModRep.SetAttached(null, false);
			global::UnityEngine.Object.Destroy(attached);
		}
		base.UninstallFromItemModRepresentation(rep);
	}

	// Token: 0x0600387F RID: 14463 RVA: 0x000CF20C File Offset: 0x000CD40C
	protected override void SecureWriteMemberValues(global::uLink.BitStream stream)
	{
		base.SecureWriteMemberValues(stream);
		stream.Write<string>(this.socketOverrideName, new object[0]);
		stream.Write<float>(this.zoomOffsetZ, new object[0]);
		stream.Write<bool>(this.isMesh, new object[0]);
		stream.Write<float>(this.punchScalar, new object[0]);
		stream.Write<bool>(this.modifyZoomOffset, new object[0]);
	}

	// Token: 0x04001DFC RID: 7676
	public string attachSocketName = "muzzle";

	// Token: 0x04001DFD RID: 7677
	public global::UnityEngine.GameObject attachObjectVM;

	// Token: 0x04001DFE RID: 7678
	public global::UnityEngine.GameObject attachObjectRep;

	// Token: 0x04001DFF RID: 7679
	public bool isMesh;

	// Token: 0x04001E00 RID: 7680
	public string socketOverrideName = string.Empty;

	// Token: 0x04001E01 RID: 7681
	public float punchScalar = 1f;

	// Token: 0x04001E02 RID: 7682
	public float zoomOffsetZ;

	// Token: 0x04001E03 RID: 7683
	public bool modifyZoomOffset;

	// Token: 0x020006A4 RID: 1700
	private sealed class ITEM_TYPE : global::ItemModItem<global::BaseWeaponModDataBlock>, global::IInventoryItem, global::IItemModItem
	{
		// Token: 0x06003880 RID: 14464 RVA: 0x000CF27C File Offset: 0x000CD47C
		public ITEM_TYPE(global::BaseWeaponModDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000B06 RID: 2822
		// (get) Token: 0x06003881 RID: 14465 RVA: 0x000CF288 File Offset: 0x000CD488
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x06003882 RID: 14466 RVA: 0x000CF290 File Offset: 0x000CD490
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x06003883 RID: 14467 RVA: 0x000CF298 File Offset: 0x000CD498
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x06003884 RID: 14468 RVA: 0x000CF2A0 File Offset: 0x000CD4A0
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x06003885 RID: 14469 RVA: 0x000CF2A8 File Offset: 0x000CD4A8
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x06003886 RID: 14470 RVA: 0x000CF2B4 File Offset: 0x000CD4B4
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x06003887 RID: 14471 RVA: 0x000CF2C0 File Offset: 0x000CD4C0
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x06003888 RID: 14472 RVA: 0x000CF2CC File Offset: 0x000CD4CC
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x06003889 RID: 14473 RVA: 0x000CF2D8 File Offset: 0x000CD4D8
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x0600388A RID: 14474 RVA: 0x000CF2E4 File Offset: 0x000CD4E4
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x0600388B RID: 14475 RVA: 0x000CF2F0 File Offset: 0x000CD4F0
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x0600388C RID: 14476 RVA: 0x000CF2FC File Offset: 0x000CD4FC
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x0600388D RID: 14477 RVA: 0x000CF308 File Offset: 0x000CD508
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x0600388E RID: 14478 RVA: 0x000CF310 File Offset: 0x000CD510
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x0600388F RID: 14479 RVA: 0x000CF31C File Offset: 0x000CD51C
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x06003890 RID: 14480 RVA: 0x000CF328 File Offset: 0x000CD528
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x06003891 RID: 14481 RVA: 0x000CF330 File Offset: 0x000CD530
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x06003892 RID: 14482 RVA: 0x000CF338 File Offset: 0x000CD538
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x06003893 RID: 14483 RVA: 0x000CF340 File Offset: 0x000CD540
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x06003894 RID: 14484 RVA: 0x000CF348 File Offset: 0x000CD548
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x06003895 RID: 14485 RVA: 0x000CF350 File Offset: 0x000CD550
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x06003896 RID: 14486 RVA: 0x000CF358 File Offset: 0x000CD558
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x06003897 RID: 14487 RVA: 0x000CF360 File Offset: 0x000CD560
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x06003898 RID: 14488 RVA: 0x000CF36C File Offset: 0x000CD56C
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x06003899 RID: 14489 RVA: 0x000CF374 File Offset: 0x000CD574
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x0600389A RID: 14490 RVA: 0x000CF37C File Offset: 0x000CD57C
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x0600389B RID: 14491 RVA: 0x000CF384 File Offset: 0x000CD584
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x0600389C RID: 14492 RVA: 0x000CF38C File Offset: 0x000CD58C
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x0600389D RID: 14493 RVA: 0x000CF394 File Offset: 0x000CD594
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x0600389E RID: 14494 RVA: 0x000CF39C File Offset: 0x000CD59C
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
