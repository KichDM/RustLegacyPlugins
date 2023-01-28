using System;
using RustProto;
using uLink;

// Token: 0x02000688 RID: 1672
public class DeployableInventoryDataBlock : global::DeployableItemDataBlock
{
	// Token: 0x0600367D RID: 13949 RVA: 0x000CC2A4 File Offset: 0x000CA4A4
	public DeployableInventoryDataBlock()
	{
	}

	// Token: 0x0600367E RID: 13950 RVA: 0x000CC2AC File Offset: 0x000CA4AC
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::DeployableInventoryDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x0600367F RID: 13951 RVA: 0x000CC2B4 File Offset: 0x000CA4B4
	protected override void SetupDeployableObject(global::uLink.BitStream stream, global::ItemRepresentation rep, ref global::uLink.NetworkMessageInfo timestamp, global::DeployableObject created, global::TransCarrier carrier)
	{
		base.SetupDeployableObject(stream, rep, ref timestamp, created, carrier);
		if (this.initialItems != null && this.initialItems.Length > 0)
		{
			global::Inventory local = created.GetLocal<global::Inventory>();
			if (local)
			{
				for (int i = 0; i < this.initialItems.Length; i++)
				{
					if (this.initialItems[i].item)
					{
						local.AddItem(this.initialItems[i].item, this.initialItems[i].slot, this.initialItems[i].count);
					}
				}
			}
		}
	}

	// Token: 0x04001D88 RID: 7560
	public global::DeployableInventoryDataBlock.InitialItem[] initialItems;

	// Token: 0x02000689 RID: 1673
	[global::System.Serializable]
	public class InitialItem
	{
		// Token: 0x06003680 RID: 13952 RVA: 0x000CC364 File Offset: 0x000CA564
		public InitialItem()
		{
		}

		// Token: 0x04001D89 RID: 7561
		public global::ItemDataBlock item;

		// Token: 0x04001D8A RID: 7562
		public int count;

		// Token: 0x04001D8B RID: 7563
		public int slot;
	}

	// Token: 0x0200068A RID: 1674
	private sealed class ITEM_TYPE : global::DeployableItem<global::DeployableInventoryDataBlock>, global::IDeployableItem, global::IHeldItem, global::IInventoryItem
	{
		// Token: 0x06003681 RID: 13953 RVA: 0x000CC36C File Offset: 0x000CA56C
		public ITEM_TYPE(global::DeployableInventoryDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000AF7 RID: 2807
		// (get) Token: 0x06003682 RID: 13954 RVA: 0x000CC378 File Offset: 0x000CA578
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x06003683 RID: 13955 RVA: 0x000CC380 File Offset: 0x000CA580
		void SetTotalModSlotCount(int count)
		{
			base.SetTotalModSlotCount(count);
		}

		// Token: 0x06003684 RID: 13956 RVA: 0x000CC38C File Offset: 0x000CA58C
		void SetUsedModSlotCount(int count)
		{
			base.SetUsedModSlotCount(count);
		}

		// Token: 0x06003685 RID: 13957 RVA: 0x000CC398 File Offset: 0x000CA598
		void AddMod(global::ItemModDataBlock mod)
		{
			base.AddMod(mod);
		}

		// Token: 0x06003686 RID: 13958 RVA: 0x000CC3A4 File Offset: 0x000CA5A4
		int FindMod(global::ItemModDataBlock mod)
		{
			return base.FindMod(mod);
		}

		// Token: 0x06003687 RID: 13959 RVA: 0x000CC3B0 File Offset: 0x000CA5B0
		void OnActivate()
		{
			base.OnActivate();
		}

		// Token: 0x06003688 RID: 13960 RVA: 0x000CC3B8 File Offset: 0x000CA5B8
		void OnDeactivate()
		{
			base.OnDeactivate();
		}

		// Token: 0x06003689 RID: 13961 RVA: 0x000CC3C0 File Offset: 0x000CA5C0
		global::ViewModel get_viewModelInstance()
		{
			return base.viewModelInstance;
		}

		// Token: 0x0600368A RID: 13962 RVA: 0x000CC3C8 File Offset: 0x000CA5C8
		global::ItemRepresentation get_itemRepresentation()
		{
			return base.itemRepresentation;
		}

		// Token: 0x0600368B RID: 13963 RVA: 0x000CC3D0 File Offset: 0x000CA5D0
		void set_itemRepresentation(global::ItemRepresentation value)
		{
			base.itemRepresentation = value;
		}

		// Token: 0x0600368C RID: 13964 RVA: 0x000CC3DC File Offset: 0x000CA5DC
		bool get_canActivate()
		{
			return base.canActivate;
		}

		// Token: 0x0600368D RID: 13965 RVA: 0x000CC3E4 File Offset: 0x000CA5E4
		bool get_canDeactivate()
		{
			return base.canDeactivate;
		}

		// Token: 0x0600368E RID: 13966 RVA: 0x000CC3EC File Offset: 0x000CA5EC
		global::ItemModFlags get_modFlags()
		{
			return base.modFlags;
		}

		// Token: 0x0600368F RID: 13967 RVA: 0x000CC3F4 File Offset: 0x000CA5F4
		global::ItemModDataBlock[] get_itemMods()
		{
			return base.itemMods;
		}

		// Token: 0x06003690 RID: 13968 RVA: 0x000CC3FC File Offset: 0x000CA5FC
		int get_totalModSlots()
		{
			return base.totalModSlots;
		}

		// Token: 0x06003691 RID: 13969 RVA: 0x000CC404 File Offset: 0x000CA604
		int get_usedModSlots()
		{
			return base.usedModSlots;
		}

		// Token: 0x06003692 RID: 13970 RVA: 0x000CC40C File Offset: 0x000CA60C
		int get_freeModSlots()
		{
			return base.freeModSlots;
		}

		// Token: 0x06003693 RID: 13971 RVA: 0x000CC414 File Offset: 0x000CA614
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x06003694 RID: 13972 RVA: 0x000CC41C File Offset: 0x000CA61C
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x06003695 RID: 13973 RVA: 0x000CC424 File Offset: 0x000CA624
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x06003696 RID: 13974 RVA: 0x000CC42C File Offset: 0x000CA62C
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x06003697 RID: 13975 RVA: 0x000CC438 File Offset: 0x000CA638
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x06003698 RID: 13976 RVA: 0x000CC444 File Offset: 0x000CA644
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x06003699 RID: 13977 RVA: 0x000CC450 File Offset: 0x000CA650
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x0600369A RID: 13978 RVA: 0x000CC45C File Offset: 0x000CA65C
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x0600369B RID: 13979 RVA: 0x000CC468 File Offset: 0x000CA668
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x0600369C RID: 13980 RVA: 0x000CC474 File Offset: 0x000CA674
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x0600369D RID: 13981 RVA: 0x000CC480 File Offset: 0x000CA680
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x0600369E RID: 13982 RVA: 0x000CC48C File Offset: 0x000CA68C
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x0600369F RID: 13983 RVA: 0x000CC494 File Offset: 0x000CA694
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x060036A0 RID: 13984 RVA: 0x000CC4A0 File Offset: 0x000CA6A0
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x060036A1 RID: 13985 RVA: 0x000CC4AC File Offset: 0x000CA6AC
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x060036A2 RID: 13986 RVA: 0x000CC4B4 File Offset: 0x000CA6B4
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x060036A3 RID: 13987 RVA: 0x000CC4BC File Offset: 0x000CA6BC
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x060036A4 RID: 13988 RVA: 0x000CC4C4 File Offset: 0x000CA6C4
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x060036A5 RID: 13989 RVA: 0x000CC4CC File Offset: 0x000CA6CC
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x060036A6 RID: 13990 RVA: 0x000CC4D4 File Offset: 0x000CA6D4
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x060036A7 RID: 13991 RVA: 0x000CC4DC File Offset: 0x000CA6DC
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x060036A8 RID: 13992 RVA: 0x000CC4E4 File Offset: 0x000CA6E4
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x060036A9 RID: 13993 RVA: 0x000CC4F0 File Offset: 0x000CA6F0
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x060036AA RID: 13994 RVA: 0x000CC4F8 File Offset: 0x000CA6F8
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x060036AB RID: 13995 RVA: 0x000CC500 File Offset: 0x000CA700
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x060036AC RID: 13996 RVA: 0x000CC508 File Offset: 0x000CA708
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x060036AD RID: 13997 RVA: 0x000CC510 File Offset: 0x000CA710
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x060036AE RID: 13998 RVA: 0x000CC518 File Offset: 0x000CA718
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x060036AF RID: 13999 RVA: 0x000CC520 File Offset: 0x000CA720
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
