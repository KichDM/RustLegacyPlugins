using System;
using RustProto;
using RustProto.Helpers;
using uLink;
using UnityEngine;

// Token: 0x02000696 RID: 1686
public class HeldItemDataBlock : global::ItemDataBlock
{
	// Token: 0x06003774 RID: 14196 RVA: 0x000CD898 File Offset: 0x000CBA98
	public HeldItemDataBlock()
	{
	}

	// Token: 0x06003775 RID: 14197 RVA: 0x000CD8B8 File Offset: 0x000CBAB8
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::HeldItemDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x06003776 RID: 14198 RVA: 0x000CD8C0 File Offset: 0x000CBAC0
	public override void InstallData(global::IInventoryItem item)
	{
		base.InstallData(item);
		int num = global::UnityEngine.Random.Range(0, (int)(this.GetMaxEligableSlots() + 1));
		if (num > 0)
		{
			(item as global::IHeldItem).SetTotalModSlotCount(num);
		}
	}

	// Token: 0x06003777 RID: 14199 RVA: 0x000CD8F8 File Offset: 0x000CBAF8
	public bool PollForAmmoDatablock(out global::ItemDataBlock ammoType)
	{
		if (this.IsSplittable())
		{
			ammoType = this;
			return true;
		}
		if (this is global::BulletWeaponDataBlock)
		{
			ammoType = ((global::BulletWeaponDataBlock)this).ammoType;
			return ammoType;
		}
		if (this is global::BowWeaponDataBlock)
		{
			ammoType = ((global::BowWeaponDataBlock)this).defaultAmmo;
			return ammoType;
		}
		ammoType = null;
		return false;
	}

	// Token: 0x06003778 RID: 14200 RVA: 0x000CD95C File Offset: 0x000CBB5C
	protected bool SaveItemInterface(ref global::RustProto.Item.Builder item, global::IHeldItem instance)
	{
		if (instance.totalModSlots == 0)
		{
			return true;
		}
		int usedModSlots = instance.usedModSlots;
		item.SetSubslots(instance.totalModSlots);
		using (global::RustProto.Helpers.Recycler<global::RustProto.Item, global::RustProto.Item.Builder> recycler = global::RustProto.Item.Recycler())
		{
			global::RustProto.Item.Builder builder = recycler.OpenBuilder();
			for (int i = 0; i < usedModSlots; i++)
			{
				global::ItemModDataBlock itemModDataBlock = instance.itemMods[i];
				builder.Clear();
				builder.SetId(itemModDataBlock.uniqueID);
				builder.SetSlot(i);
				item.AddSubitem(builder);
			}
		}
		return true;
	}

	// Token: 0x06003779 RID: 14201 RVA: 0x000CDA0C File Offset: 0x000CBC0C
	protected override bool SaveItem(global::IInventoryItem instanceBase, ref global::RustProto.Item.Builder item)
	{
		return base.SaveItem(instanceBase, ref item) && this.SaveItemInterface(ref item, (global::IHeldItem)instanceBase);
	}

	// Token: 0x0600377A RID: 14202 RVA: 0x000CDA2C File Offset: 0x000CBC2C
	protected bool LoadItemInterface(ref global::RustProto.Item item, global::IHeldItem instance)
	{
		if (item.HasSubslots)
		{
			instance.SetTotalModSlotCount(item.Subslots);
		}
		else
		{
			instance.SetTotalModSlotCount(item.SubitemCount);
		}
		int i = 0;
		int subitemCount = item.SubitemCount;
		while (i < subitemCount)
		{
			global::RustProto.Item subitem = item.GetSubitem(i);
			instance.AddMod((global::ItemModDataBlock)global::DatablockDictionary.GetByUniqueID(subitem.Id));
			i++;
		}
		return true;
	}

	// Token: 0x0600377B RID: 14203 RVA: 0x000CDAA0 File Offset: 0x000CBCA0
	protected override bool LoadItem(global::IInventoryItem instanceBase, ref global::RustProto.Item item)
	{
		return base.LoadItem(instanceBase, ref item) && this.LoadItemInterface(ref item, (global::IHeldItem)instanceBase);
	}

	// Token: 0x0600377C RID: 14204 RVA: 0x000CDAC0 File Offset: 0x000CBCC0
	public virtual void DoAction1(global::uLink.BitStream stream, global::ItemRepresentation rep, ref global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x0600377D RID: 14205 RVA: 0x000CDAC4 File Offset: 0x000CBCC4
	public virtual void DoAction2(global::uLink.BitStream stream, global::ItemRepresentation itemRep, ref global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x0600377E RID: 14206 RVA: 0x000CDAC8 File Offset: 0x000CBCC8
	public virtual void DoAction3(global::uLink.BitStream stream, global::ItemRepresentation itemRep, ref global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x0600377F RID: 14207 RVA: 0x000CDACC File Offset: 0x000CBCCC
	protected override void SecureWriteMemberValues(global::uLink.BitStream stream)
	{
		base.SecureWriteMemberValues(stream);
		stream.Write<bool>(this.secondaryFireAims, new object[0]);
		stream.Write<float>(this.aimSensitivtyPercent, new object[0]);
		stream.Write<string>(this.attachmentPoint, new object[0]);
	}

	// Token: 0x04001DB5 RID: 7605
	public global::ItemRepresentation _itemRepPrefab;

	// Token: 0x04001DB6 RID: 7606
	public global::ViewModel _viewModelPrefab;

	// Token: 0x04001DB7 RID: 7607
	public global::UnityEngine.AudioClip deploySound;

	// Token: 0x04001DB8 RID: 7608
	public bool secondaryFireAims;

	// Token: 0x04001DB9 RID: 7609
	public float aimSensitivtyPercent = 0.4f;

	// Token: 0x04001DBA RID: 7610
	public string attachmentPoint = "RArmHand";

	// Token: 0x04001DBB RID: 7611
	public string animationGroupName;

	// Token: 0x02000697 RID: 1687
	private sealed class ITEM_TYPE : global::HeldItem<global::HeldItemDataBlock>, global::IHeldItem, global::IInventoryItem
	{
		// Token: 0x06003780 RID: 14208 RVA: 0x000CDB18 File Offset: 0x000CBD18
		public ITEM_TYPE(global::HeldItemDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000AFD RID: 2813
		// (get) Token: 0x06003781 RID: 14209 RVA: 0x000CDB24 File Offset: 0x000CBD24
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x06003782 RID: 14210 RVA: 0x000CDB2C File Offset: 0x000CBD2C
		void SetTotalModSlotCount(int count)
		{
			base.SetTotalModSlotCount(count);
		}

		// Token: 0x06003783 RID: 14211 RVA: 0x000CDB38 File Offset: 0x000CBD38
		void SetUsedModSlotCount(int count)
		{
			base.SetUsedModSlotCount(count);
		}

		// Token: 0x06003784 RID: 14212 RVA: 0x000CDB44 File Offset: 0x000CBD44
		void AddMod(global::ItemModDataBlock mod)
		{
			base.AddMod(mod);
		}

		// Token: 0x06003785 RID: 14213 RVA: 0x000CDB50 File Offset: 0x000CBD50
		int FindMod(global::ItemModDataBlock mod)
		{
			return base.FindMod(mod);
		}

		// Token: 0x06003786 RID: 14214 RVA: 0x000CDB5C File Offset: 0x000CBD5C
		void OnActivate()
		{
			base.OnActivate();
		}

		// Token: 0x06003787 RID: 14215 RVA: 0x000CDB64 File Offset: 0x000CBD64
		void OnDeactivate()
		{
			base.OnDeactivate();
		}

		// Token: 0x06003788 RID: 14216 RVA: 0x000CDB6C File Offset: 0x000CBD6C
		global::ViewModel get_viewModelInstance()
		{
			return base.viewModelInstance;
		}

		// Token: 0x06003789 RID: 14217 RVA: 0x000CDB74 File Offset: 0x000CBD74
		global::ItemRepresentation get_itemRepresentation()
		{
			return base.itemRepresentation;
		}

		// Token: 0x0600378A RID: 14218 RVA: 0x000CDB7C File Offset: 0x000CBD7C
		void set_itemRepresentation(global::ItemRepresentation value)
		{
			base.itemRepresentation = value;
		}

		// Token: 0x0600378B RID: 14219 RVA: 0x000CDB88 File Offset: 0x000CBD88
		bool get_canActivate()
		{
			return base.canActivate;
		}

		// Token: 0x0600378C RID: 14220 RVA: 0x000CDB90 File Offset: 0x000CBD90
		bool get_canDeactivate()
		{
			return base.canDeactivate;
		}

		// Token: 0x0600378D RID: 14221 RVA: 0x000CDB98 File Offset: 0x000CBD98
		global::ItemModFlags get_modFlags()
		{
			return base.modFlags;
		}

		// Token: 0x0600378E RID: 14222 RVA: 0x000CDBA0 File Offset: 0x000CBDA0
		global::ItemModDataBlock[] get_itemMods()
		{
			return base.itemMods;
		}

		// Token: 0x0600378F RID: 14223 RVA: 0x000CDBA8 File Offset: 0x000CBDA8
		int get_totalModSlots()
		{
			return base.totalModSlots;
		}

		// Token: 0x06003790 RID: 14224 RVA: 0x000CDBB0 File Offset: 0x000CBDB0
		int get_usedModSlots()
		{
			return base.usedModSlots;
		}

		// Token: 0x06003791 RID: 14225 RVA: 0x000CDBB8 File Offset: 0x000CBDB8
		int get_freeModSlots()
		{
			return base.freeModSlots;
		}

		// Token: 0x06003792 RID: 14226 RVA: 0x000CDBC0 File Offset: 0x000CBDC0
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x06003793 RID: 14227 RVA: 0x000CDBC8 File Offset: 0x000CBDC8
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x06003794 RID: 14228 RVA: 0x000CDBD0 File Offset: 0x000CBDD0
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x06003795 RID: 14229 RVA: 0x000CDBD8 File Offset: 0x000CBDD8
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x06003796 RID: 14230 RVA: 0x000CDBE4 File Offset: 0x000CBDE4
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x06003797 RID: 14231 RVA: 0x000CDBF0 File Offset: 0x000CBDF0
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x06003798 RID: 14232 RVA: 0x000CDBFC File Offset: 0x000CBDFC
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x06003799 RID: 14233 RVA: 0x000CDC08 File Offset: 0x000CBE08
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x0600379A RID: 14234 RVA: 0x000CDC14 File Offset: 0x000CBE14
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x0600379B RID: 14235 RVA: 0x000CDC20 File Offset: 0x000CBE20
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x0600379C RID: 14236 RVA: 0x000CDC2C File Offset: 0x000CBE2C
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x0600379D RID: 14237 RVA: 0x000CDC38 File Offset: 0x000CBE38
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x0600379E RID: 14238 RVA: 0x000CDC40 File Offset: 0x000CBE40
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x0600379F RID: 14239 RVA: 0x000CDC4C File Offset: 0x000CBE4C
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x060037A0 RID: 14240 RVA: 0x000CDC58 File Offset: 0x000CBE58
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x060037A1 RID: 14241 RVA: 0x000CDC60 File Offset: 0x000CBE60
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x060037A2 RID: 14242 RVA: 0x000CDC68 File Offset: 0x000CBE68
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x060037A3 RID: 14243 RVA: 0x000CDC70 File Offset: 0x000CBE70
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x060037A4 RID: 14244 RVA: 0x000CDC78 File Offset: 0x000CBE78
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x060037A5 RID: 14245 RVA: 0x000CDC80 File Offset: 0x000CBE80
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x060037A6 RID: 14246 RVA: 0x000CDC88 File Offset: 0x000CBE88
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x060037A7 RID: 14247 RVA: 0x000CDC90 File Offset: 0x000CBE90
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x060037A8 RID: 14248 RVA: 0x000CDC9C File Offset: 0x000CBE9C
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x060037A9 RID: 14249 RVA: 0x000CDCA4 File Offset: 0x000CBEA4
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x060037AA RID: 14250 RVA: 0x000CDCAC File Offset: 0x000CBEAC
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x060037AB RID: 14251 RVA: 0x000CDCB4 File Offset: 0x000CBEB4
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x060037AC RID: 14252 RVA: 0x000CDCBC File Offset: 0x000CBEBC
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x060037AD RID: 14253 RVA: 0x000CDCC4 File Offset: 0x000CBEC4
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x060037AE RID: 14254 RVA: 0x000CDCCC File Offset: 0x000CBECC
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
