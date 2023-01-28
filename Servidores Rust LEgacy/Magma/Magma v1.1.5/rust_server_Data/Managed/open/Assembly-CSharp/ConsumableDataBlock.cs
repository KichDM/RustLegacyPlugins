using System;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x02000686 RID: 1670
public class ConsumableDataBlock : global::ItemDataBlock
{
	// Token: 0x06003655 RID: 13909 RVA: 0x000CBD60 File Offset: 0x000C9F60
	public ConsumableDataBlock()
	{
	}

	// Token: 0x06003656 RID: 13910 RVA: 0x000CBD78 File Offset: 0x000C9F78
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::ConsumableDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x06003657 RID: 13911 RVA: 0x000CBD80 File Offset: 0x000C9F80
	public override int RetreiveMenuOptions(global::IInventoryItem item, global::InventoryItem.MenuItem[] results, int offset)
	{
		offset = base.RetreiveMenuOptions(item, results, offset);
		if (item.isInLocalInventory)
		{
			results[offset++] = this.GetConsumeMenuItem();
		}
		return offset;
	}

	// Token: 0x06003658 RID: 13912 RVA: 0x000CBDB4 File Offset: 0x000C9FB4
	public global::InventoryItem.MenuItem GetConsumeMenuItem()
	{
		if (this.calories > 0f && this.litresOfWater <= 0f)
		{
			return global::InventoryItem.MenuItem.Eat;
		}
		if (this.litresOfWater > 0f && this.calories <= 0f)
		{
			return global::InventoryItem.MenuItem.Drink;
		}
		return global::InventoryItem.MenuItem.Consume;
	}

	// Token: 0x06003659 RID: 13913 RVA: 0x000CBE08 File Offset: 0x000CA008
	public override global::InventoryItem.MenuItemResult ExecuteMenuOption(global::InventoryItem.MenuItem option, global::IInventoryItem item)
	{
		if (option == this.GetConsumeMenuItem())
		{
			this.UseItem(item as global::IConsumableItem);
			return global::InventoryItem.MenuItemResult.DoneOnServer;
		}
		return base.ExecuteMenuOption(option, item);
	}

	// Token: 0x0600365A RID: 13914 RVA: 0x000CBE38 File Offset: 0x000CA038
	public virtual void UseItem(global::IConsumableItem item)
	{
		global::Inventory inventory = item.inventory;
		global::Metabolism local = inventory.GetLocal<global::Metabolism>();
		if (local == null)
		{
			return;
		}
		if (!local.CanConsumeYet())
		{
			return;
		}
		local.MarkConsumptionTime();
		float numCalories = global::UnityEngine.Mathf.Min(local.GetRemainingCaloricSpace(), this.calories);
		if (this.calories > 0f)
		{
			local.AddCalories(numCalories);
		}
		if (this.litresOfWater > 0f)
		{
			local.AddWater(this.litresOfWater);
		}
		if (this.antiRads > 0f)
		{
			local.AddAntiRad(this.antiRads);
		}
		if (this.healthToHeal != 0f)
		{
			global::HumanBodyTakeDamage local2 = inventory.GetLocal<global::HumanBodyTakeDamage>();
			if (local2 != null)
			{
				if (this.healthToHeal > 0f)
				{
					local2.HealOverTime(this.healthToHeal);
				}
				else
				{
					global::TakeDamage.HurtSelf(inventory.idMain, global::UnityEngine.Mathf.Abs(this.healthToHeal), null);
				}
			}
		}
		if (this.poisonAmount > 0f)
		{
			local.AddPoison(this.poisonAmount);
		}
		item.FireClientSideItemEvent(global::InventoryItem.ItemEvent.Used);
		int num = 1;
		if (item.Consume(ref num))
		{
			inventory.RemoveItem(item.slot);
		}
		else
		{
			inventory.MarkSlotDirty(item.slot);
		}
	}

	// Token: 0x0600365B RID: 13915 RVA: 0x000CBF88 File Offset: 0x000CA188
	public override void PopulateInfoWindow(global::ItemToolTip infoWindow, global::IInventoryItem tipItem)
	{
		infoWindow.AddItemTitle(this, tipItem, 0f);
		infoWindow.AddSectionTitle("Consumable", 15f);
		if (this.calories > 0f)
		{
			infoWindow.AddBasicLabel(this.calories + " Calories", 15f);
		}
		if (this.litresOfWater > 0f)
		{
			infoWindow.AddBasicLabel(this.litresOfWater + "L Water", 15f);
		}
		if (this.antiRads > 0f)
		{
			infoWindow.AddBasicLabel("-" + this.antiRads + " Rads", 15f);
		}
		if (this.healthToHeal != 0f)
		{
			infoWindow.AddBasicLabel(((this.healthToHeal <= 0f) ? string.Empty : "+") + this.healthToHeal + " Health", 15f);
		}
		infoWindow.AddItemDescription(this, 15f);
		infoWindow.FinishPopulating();
	}

	// Token: 0x0600365C RID: 13916 RVA: 0x000CC0B0 File Offset: 0x000CA2B0
	public override string GetItemDescription()
	{
		string text = string.Empty;
		if (this.calories > 0f && this.litresOfWater > 0f)
		{
			text += "This is a food item, consuming it (via right click) will replenish your food and water. ";
		}
		else if (this.calories > 0f)
		{
			text += "This is a food item, eating it will satisfy some of your hunger. ";
		}
		else if (this.litresOfWater > 0f)
		{
			text += "This is a beverage, drinking it will quench some of your thirst. ";
		}
		if (this.antiRads > 0f)
		{
			text += "This item has some anti-radioactive properties, consuming it will lower your radiation level. ";
		}
		if (this.healthToHeal > 0f)
		{
			text += "It will also provide minor healing";
		}
		return text;
	}

	// Token: 0x04001D7E RID: 7550
	public float litresOfWater;

	// Token: 0x04001D7F RID: 7551
	public float calories;

	// Token: 0x04001D80 RID: 7552
	public float antiRads;

	// Token: 0x04001D81 RID: 7553
	public float healthToHeal;

	// Token: 0x04001D82 RID: 7554
	public float poisonAmount;

	// Token: 0x04001D83 RID: 7555
	public bool cookable;

	// Token: 0x04001D84 RID: 7556
	public int numToCookPerTick;

	// Token: 0x04001D85 RID: 7557
	public global::ItemDataBlock cookedVersion;

	// Token: 0x04001D86 RID: 7558
	public int burnTemp = 0xA;

	// Token: 0x04001D87 RID: 7559
	public int cookHeatRequirement = 1;

	// Token: 0x02000687 RID: 1671
	private sealed class ITEM_TYPE : global::ConsumableItem<global::ConsumableDataBlock>, global::IConsumableItem, global::ICookableItem, global::IInventoryItem
	{
		// Token: 0x0600365D RID: 13917 RVA: 0x000CC16C File Offset: 0x000CA36C
		public ITEM_TYPE(global::ConsumableDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000AF6 RID: 2806
		// (get) Token: 0x0600365E RID: 13918 RVA: 0x000CC178 File Offset: 0x000CA378
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x0600365F RID: 13919 RVA: 0x000CC180 File Offset: 0x000CA380
		bool GetCookableInfo(out int consumeCount, out global::ItemDataBlock cookedVersion, out int cookedCount, out int cookTempMin, out int burnTemp)
		{
			return base.GetCookableInfo(out consumeCount, out cookedVersion, out cookedCount, out cookTempMin, out burnTemp);
		}

		// Token: 0x06003660 RID: 13920 RVA: 0x000CC190 File Offset: 0x000CA390
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x06003661 RID: 13921 RVA: 0x000CC198 File Offset: 0x000CA398
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x06003662 RID: 13922 RVA: 0x000CC1A0 File Offset: 0x000CA3A0
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x06003663 RID: 13923 RVA: 0x000CC1A8 File Offset: 0x000CA3A8
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x06003664 RID: 13924 RVA: 0x000CC1B4 File Offset: 0x000CA3B4
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x06003665 RID: 13925 RVA: 0x000CC1C0 File Offset: 0x000CA3C0
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x06003666 RID: 13926 RVA: 0x000CC1CC File Offset: 0x000CA3CC
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x06003667 RID: 13927 RVA: 0x000CC1D8 File Offset: 0x000CA3D8
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x06003668 RID: 13928 RVA: 0x000CC1E4 File Offset: 0x000CA3E4
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x06003669 RID: 13929 RVA: 0x000CC1F0 File Offset: 0x000CA3F0
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x0600366A RID: 13930 RVA: 0x000CC1FC File Offset: 0x000CA3FC
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x0600366B RID: 13931 RVA: 0x000CC208 File Offset: 0x000CA408
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x0600366C RID: 13932 RVA: 0x000CC210 File Offset: 0x000CA410
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x0600366D RID: 13933 RVA: 0x000CC21C File Offset: 0x000CA41C
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x0600366E RID: 13934 RVA: 0x000CC228 File Offset: 0x000CA428
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x0600366F RID: 13935 RVA: 0x000CC230 File Offset: 0x000CA430
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x06003670 RID: 13936 RVA: 0x000CC238 File Offset: 0x000CA438
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x06003671 RID: 13937 RVA: 0x000CC240 File Offset: 0x000CA440
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x06003672 RID: 13938 RVA: 0x000CC248 File Offset: 0x000CA448
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x06003673 RID: 13939 RVA: 0x000CC250 File Offset: 0x000CA450
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x06003674 RID: 13940 RVA: 0x000CC258 File Offset: 0x000CA458
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x06003675 RID: 13941 RVA: 0x000CC260 File Offset: 0x000CA460
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x06003676 RID: 13942 RVA: 0x000CC26C File Offset: 0x000CA46C
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x06003677 RID: 13943 RVA: 0x000CC274 File Offset: 0x000CA474
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x06003678 RID: 13944 RVA: 0x000CC27C File Offset: 0x000CA47C
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x06003679 RID: 13945 RVA: 0x000CC284 File Offset: 0x000CA484
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x0600367A RID: 13946 RVA: 0x000CC28C File Offset: 0x000CA48C
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x0600367B RID: 13947 RVA: 0x000CC294 File Offset: 0x000CA494
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x0600367C RID: 13948 RVA: 0x000CC29C File Offset: 0x000CA49C
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}
}
