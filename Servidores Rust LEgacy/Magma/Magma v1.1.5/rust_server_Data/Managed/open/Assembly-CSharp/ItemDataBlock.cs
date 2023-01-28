using System;
using Facepunch;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x02000698 RID: 1688
public class ItemDataBlock : global::Datablock, global::System.IComparable<global::ItemDataBlock>
{
	// Token: 0x060037AF RID: 14255 RVA: 0x000CDCD4 File Offset: 0x000CBED4
	public ItemDataBlock()
	{
	}

	// Token: 0x060037B0 RID: 14256 RVA: 0x000CDD38 File Offset: 0x000CBF38
	int global::System.IComparable<global::ItemDataBlock>.CompareTo(global::ItemDataBlock other)
	{
		return this.CompareTo(other);
	}

	// Token: 0x060037B1 RID: 14257 RVA: 0x000CDD44 File Offset: 0x000CBF44
	protected virtual global::IInventoryItem ConstructItem()
	{
		return new global::ItemDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x060037B2 RID: 14258 RVA: 0x000CDD4C File Offset: 0x000CBF4C
	public global::IInventoryItem CreateItem()
	{
		global::IInventoryItem inventoryItem = this.ConstructItem();
		this.InstallData(inventoryItem);
		return inventoryItem;
	}

	// Token: 0x060037B3 RID: 14259 RVA: 0x000CDD68 File Offset: 0x000CBF68
	protected override void SecureWriteMemberValues(global::uLink.BitStream stream)
	{
		base.SecureWriteMemberValues(stream);
		stream.Write<int>((int)this._itemFlags, new object[0]);
		stream.Write<int>(this._maxUses, new object[0]);
		stream.Write<bool>(this._splittable, new object[0]);
		stream.Write<byte>((byte)this.transientMode, new object[0]);
		stream.Write<bool>(this.isResearchable, new object[0]);
		stream.Write<bool>(this.isResearchable, new object[0]);
		stream.Write<bool>(this.isRecycleable, new object[0]);
	}

	// Token: 0x060037B4 RID: 14260 RVA: 0x000CDDFC File Offset: 0x000CBFFC
	public virtual void InstallData(global::IInventoryItem item)
	{
		item.SetUses(1);
		item.SetMaxCondition(1f);
		item.SetCondition(1f);
	}

	// Token: 0x060037B5 RID: 14261 RVA: 0x000CDE1C File Offset: 0x000CC01C
	protected virtual void PreInstallJsonProperties(global::IInventoryItem item)
	{
	}

	// Token: 0x060037B6 RID: 14262 RVA: 0x000CDE20 File Offset: 0x000CC020
	protected virtual void PostInstallJsonProperties(global::IInventoryItem item)
	{
	}

	// Token: 0x060037B7 RID: 14263 RVA: 0x000CDE24 File Offset: 0x000CC024
	public static bool LoadIconOrUnknown<TTex>(string iconPath, ref TTex tex) where TTex : global::UnityEngine.Texture
	{
		return tex || global::ItemDataBlock.LoadIconOrUnknownForced<TTex>(iconPath, out tex);
	}

	// Token: 0x060037B8 RID: 14264 RVA: 0x000CDE48 File Offset: 0x000CC048
	public static bool LoadIconOrUnknownForced<TTex>(string iconPath, out TTex tex) where TTex : global::UnityEngine.Texture
	{
		return global::Facepunch.Bundling.Load<TTex>(iconPath, out tex) || global::Facepunch.Bundling.Load<TTex>("content/item/tex/unknown", out tex);
	}

	// Token: 0x17000AFE RID: 2814
	// (get) Token: 0x060037B9 RID: 14265 RVA: 0x000CDE64 File Offset: 0x000CC064
	public bool doesNotSave
	{
		get
		{
			return (this.transientMode & global::ItemDataBlock.TransientMode.DoesNotSave) == global::ItemDataBlock.TransientMode.DoesNotSave;
		}
	}

	// Token: 0x17000AFF RID: 2815
	// (get) Token: 0x060037BA RID: 14266 RVA: 0x000CDE74 File Offset: 0x000CC074
	public bool untransferable
	{
		get
		{
			return (this.transientMode & global::ItemDataBlock.TransientMode.Untransferable) == global::ItemDataBlock.TransientMode.Untransferable;
		}
	}

	// Token: 0x17000B00 RID: 2816
	// (get) Token: 0x060037BB RID: 14267 RVA: 0x000CDE84 File Offset: 0x000CC084
	public bool saves
	{
		get
		{
			return (this.transientMode & global::ItemDataBlock.TransientMode.DoesNotSave) != global::ItemDataBlock.TransientMode.DoesNotSave;
		}
	}

	// Token: 0x17000B01 RID: 2817
	// (get) Token: 0x060037BC RID: 14268 RVA: 0x000CDE94 File Offset: 0x000CC094
	public bool transferable
	{
		get
		{
			return (this.transientMode & global::ItemDataBlock.TransientMode.Untransferable) != global::ItemDataBlock.TransientMode.Untransferable;
		}
	}

	// Token: 0x060037BD RID: 14269 RVA: 0x000CDEA4 File Offset: 0x000CC0A4
	public virtual byte GetMaxEligableSlots()
	{
		return 0;
	}

	// Token: 0x060037BE RID: 14270 RVA: 0x000CDEA8 File Offset: 0x000CC0A8
	public int GetRandomSpawnUses()
	{
		return global::UnityEngine.Random.Range(this._spawnUsesMin, this._spawnUsesMax + 1);
	}

	// Token: 0x060037BF RID: 14271 RVA: 0x000CDEC0 File Offset: 0x000CC0C0
	public virtual bool IsSplittable()
	{
		return this._splittable;
	}

	// Token: 0x060037C0 RID: 14272 RVA: 0x000CDEC8 File Offset: 0x000CC0C8
	public bool DoesLoseCondition()
	{
		return this.doesLoseCondition;
	}

	// Token: 0x060037C1 RID: 14273 RVA: 0x000CDED0 File Offset: 0x000CC0D0
	public int GetMinUsesForDisplay()
	{
		return this._minUsesForDisplay;
	}

	// Token: 0x060037C2 RID: 14274 RVA: 0x000CDED8 File Offset: 0x000CC0D8
	public virtual string GetItemDescription()
	{
		if (this.itemDescriptionOverride.Length > 0)
		{
			return this.itemDescriptionOverride;
		}
		return "No item description available";
	}

	// Token: 0x060037C3 RID: 14275 RVA: 0x000CDEF8 File Offset: 0x000CC0F8
	public virtual int RetreiveMenuOptions(global::IInventoryItem item, global::InventoryItem.MenuItem[] results, int offset)
	{
		if (this._splittable && item.uses > 1 && item.isInLocalInventory)
		{
			results[offset++] = global::InventoryItem.MenuItem.Split;
		}
		return offset;
	}

	// Token: 0x060037C4 RID: 14276 RVA: 0x000CDF34 File Offset: 0x000CC134
	public virtual global::InventoryItem.MenuItemResult ExecuteMenuOption(global::InventoryItem.MenuItem option, global::IInventoryItem item)
	{
		if (option == global::InventoryItem.MenuItem.Info)
		{
			return global::InventoryItem.MenuItemResult.DoneOnClient;
		}
		if (option != global::InventoryItem.MenuItem.Split)
		{
			return global::InventoryItem.MenuItemResult.Unhandled;
		}
		item.inventory.SplitStack(item.slot);
		return global::InventoryItem.MenuItemResult.Complete;
	}

	// Token: 0x060037C5 RID: 14277 RVA: 0x000CDF70 File Offset: 0x000CC170
	public global::UnityEngine.Texture GetIconTexture()
	{
		if (!this.iconTex && !global::Facepunch.Bundling.Load<global::UnityEngine.Texture>(this.icon, out this.iconTex))
		{
			global::Facepunch.Bundling.Load<global::UnityEngine.Texture>("content/item/tex/unknown", out this.iconTex);
		}
		return this.iconTex;
	}

	// Token: 0x060037C6 RID: 14278 RVA: 0x000CDFB0 File Offset: 0x000CC1B0
	public global::ItemDataBlock.CombineRecipe GetMatchingRecipe(global::ItemDataBlock db)
	{
		if (this.Combinations == null || this.Combinations.Length == 0)
		{
			return null;
		}
		foreach (global::ItemDataBlock.CombineRecipe combineRecipe in this.Combinations)
		{
			if (combineRecipe.droppedOnType == db)
			{
				return combineRecipe;
			}
		}
		return null;
	}

	// Token: 0x060037C7 RID: 14279 RVA: 0x000CE00C File Offset: 0x000CC20C
	public virtual void PopulateInfoWindow(global::ItemToolTip infoWindow, global::IInventoryItem item)
	{
		infoWindow.AddItemTitle(this, item, 0f);
		infoWindow.AddConditionInfo(item);
		infoWindow.AddItemDescription(this, 15f);
		infoWindow.FinishPopulating();
	}

	// Token: 0x060037C8 RID: 14280 RVA: 0x000CE038 File Offset: 0x000CC238
	public virtual void OnItemEvent(global::InventoryItem.ItemEvent itemEvent)
	{
		switch (itemEvent)
		{
		case global::InventoryItem.ItemEvent.Equipped:
			if (this.equippedSound)
			{
				this.equippedSound.Play(1f);
			}
			break;
		case global::InventoryItem.ItemEvent.UnEquipped:
			if (this.unEquippedSound)
			{
				this.unEquippedSound.Play(1f);
			}
			break;
		case global::InventoryItem.ItemEvent.Combined:
			if (this.combinedSound)
			{
				this.combinedSound.Play(1f);
			}
			break;
		case global::InventoryItem.ItemEvent.Used:
			if (this.UsedSound)
			{
				this.UsedSound.Play(1f);
			}
			break;
		}
	}

	// Token: 0x060037C9 RID: 14281 RVA: 0x000CE0F8 File Offset: 0x000CC2F8
	internal static bool SaveItem<DB, ITEM>(DB datablock, ITEM dbItem, ref global::RustProto.Item.Builder proto) where DB : global::ItemDataBlock where ITEM : global::InventoryItem<DB>
	{
		return datablock.SaveItem(dbItem.iface, ref proto);
	}

	// Token: 0x060037CA RID: 14282 RVA: 0x000CE114 File Offset: 0x000CC314
	internal static bool LoadItem<DB, ITEM>(DB datablock, ITEM dbItem, ref global::RustProto.Item proto) where DB : global::ItemDataBlock where ITEM : global::InventoryItem<DB>
	{
		return datablock.LoadItem(dbItem.iface, ref proto);
	}

	// Token: 0x060037CB RID: 14283 RVA: 0x000CE130 File Offset: 0x000CC330
	protected bool SaveItemInterface(ref global::RustProto.Item.Builder item, global::IInventoryItem instance)
	{
		item.SetCount(instance.uses);
		item.SetCondition(instance.condition);
		item.SetMaxcondition(instance.maxcondition);
		return true;
	}

	// Token: 0x060037CC RID: 14284 RVA: 0x000CE168 File Offset: 0x000CC368
	protected virtual bool SaveItem(global::IInventoryItem instance, ref global::RustProto.Item.Builder item)
	{
		return !this.doesNotSave && this.SaveItemInterface(ref item, instance);
	}

	// Token: 0x060037CD RID: 14285 RVA: 0x000CE180 File Offset: 0x000CC380
	protected bool LoadItemInterface(ref global::RustProto.Item item, global::IInventoryItem instance)
	{
		if (item.HasCount)
		{
			instance.SetUses(item.Count);
		}
		if (item.HasMaxcondition)
		{
			instance.SetMaxCondition(item.Maxcondition);
		}
		if (item.HasCondition)
		{
			instance.SetCondition(item.Condition);
		}
		return true;
	}

	// Token: 0x060037CE RID: 14286 RVA: 0x000CE1DC File Offset: 0x000CC3DC
	protected virtual bool LoadItem(global::IInventoryItem instance, ref global::RustProto.Item item)
	{
		return !this.doesNotSave && this.LoadItemInterface(ref item, instance);
	}

	// Token: 0x04001DBC RID: 7612
	public const string kUnknownIconPath = "content/item/tex/unknown";

	// Token: 0x04001DBD RID: 7613
	public string icon;

	// Token: 0x04001DBE RID: 7614
	[global::System.NonSerialized]
	[global::UnityEngine.HideInInspector]
	public global::UnityEngine.Texture iconTex;

	// Token: 0x04001DBF RID: 7615
	public int _maxUses = 1;

	// Token: 0x04001DC0 RID: 7616
	public int _spawnUsesMin = 1;

	// Token: 0x04001DC1 RID: 7617
	public int _spawnUsesMax = 1;

	// Token: 0x04001DC2 RID: 7618
	public int _minUsesForDisplay = 1;

	// Token: 0x04001DC3 RID: 7619
	public float _maxCondition = 1f;

	// Token: 0x04001DC4 RID: 7620
	public bool _splittable;

	// Token: 0x04001DC5 RID: 7621
	[global::UnityEngine.HideInInspector]
	public global::Inventory.SlotFlags _itemFlags;

	// Token: 0x04001DC6 RID: 7622
	public bool isResearchable = true;

	// Token: 0x04001DC7 RID: 7623
	public bool isRepairable = true;

	// Token: 0x04001DC8 RID: 7624
	public bool isRecycleable = true;

	// Token: 0x04001DC9 RID: 7625
	public bool doesLoseCondition;

	// Token: 0x04001DCA RID: 7626
	public global::ItemDataBlock.ItemCategory category = global::ItemDataBlock.ItemCategory.Misc;

	// Token: 0x04001DCB RID: 7627
	public string itemDescriptionOverride = string.Empty;

	// Token: 0x04001DCC RID: 7628
	public global::UnityEngine.AudioClip equippedSound;

	// Token: 0x04001DCD RID: 7629
	public global::UnityEngine.AudioClip unEquippedSound;

	// Token: 0x04001DCE RID: 7630
	public global::UnityEngine.AudioClip combinedSound;

	// Token: 0x04001DCF RID: 7631
	public global::UnityEngine.AudioClip UsedSound;

	// Token: 0x04001DD0 RID: 7632
	public global::ItemDataBlock.CombineRecipe[] Combinations;

	// Token: 0x04001DD1 RID: 7633
	public global::ItemDataBlock.TransientMode transientMode;

	// Token: 0x02000699 RID: 1689
	private sealed class ITEM_TYPE : global::InventoryItem<global::ItemDataBlock>, global::IInventoryItem
	{
		// Token: 0x060037CF RID: 14287 RVA: 0x000CE1F4 File Offset: 0x000CC3F4
		public ITEM_TYPE(global::ItemDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000B02 RID: 2818
		// (get) Token: 0x060037D0 RID: 14288 RVA: 0x000CE200 File Offset: 0x000CC400
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x060037D1 RID: 14289 RVA: 0x000CE208 File Offset: 0x000CC408
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x060037D2 RID: 14290 RVA: 0x000CE210 File Offset: 0x000CC410
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x060037D3 RID: 14291 RVA: 0x000CE218 File Offset: 0x000CC418
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x060037D4 RID: 14292 RVA: 0x000CE220 File Offset: 0x000CC420
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x060037D5 RID: 14293 RVA: 0x000CE22C File Offset: 0x000CC42C
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x060037D6 RID: 14294 RVA: 0x000CE238 File Offset: 0x000CC438
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x060037D7 RID: 14295 RVA: 0x000CE244 File Offset: 0x000CC444
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x060037D8 RID: 14296 RVA: 0x000CE250 File Offset: 0x000CC450
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x060037D9 RID: 14297 RVA: 0x000CE25C File Offset: 0x000CC45C
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x060037DA RID: 14298 RVA: 0x000CE268 File Offset: 0x000CC468
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x060037DB RID: 14299 RVA: 0x000CE274 File Offset: 0x000CC474
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x060037DC RID: 14300 RVA: 0x000CE280 File Offset: 0x000CC480
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x060037DD RID: 14301 RVA: 0x000CE288 File Offset: 0x000CC488
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x060037DE RID: 14302 RVA: 0x000CE294 File Offset: 0x000CC494
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x060037DF RID: 14303 RVA: 0x000CE2A0 File Offset: 0x000CC4A0
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x060037E0 RID: 14304 RVA: 0x000CE2A8 File Offset: 0x000CC4A8
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x060037E1 RID: 14305 RVA: 0x000CE2B0 File Offset: 0x000CC4B0
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x060037E2 RID: 14306 RVA: 0x000CE2B8 File Offset: 0x000CC4B8
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x060037E3 RID: 14307 RVA: 0x000CE2C0 File Offset: 0x000CC4C0
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x060037E4 RID: 14308 RVA: 0x000CE2C8 File Offset: 0x000CC4C8
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x060037E5 RID: 14309 RVA: 0x000CE2D0 File Offset: 0x000CC4D0
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x060037E6 RID: 14310 RVA: 0x000CE2D8 File Offset: 0x000CC4D8
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x060037E7 RID: 14311 RVA: 0x000CE2E4 File Offset: 0x000CC4E4
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x060037E8 RID: 14312 RVA: 0x000CE2EC File Offset: 0x000CC4EC
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x060037E9 RID: 14313 RVA: 0x000CE2F4 File Offset: 0x000CC4F4
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x060037EA RID: 14314 RVA: 0x000CE2FC File Offset: 0x000CC4FC
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x060037EB RID: 14315 RVA: 0x000CE304 File Offset: 0x000CC504
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x060037EC RID: 14316 RVA: 0x000CE30C File Offset: 0x000CC50C
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x060037ED RID: 14317 RVA: 0x000CE314 File Offset: 0x000CC514
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}

	// Token: 0x0200069A RID: 1690
	[global::System.Serializable]
	public class CombineRecipe
	{
		// Token: 0x060037EE RID: 14318 RVA: 0x000CE31C File Offset: 0x000CC51C
		public CombineRecipe()
		{
		}

		// Token: 0x04001DD2 RID: 7634
		public global::ItemDataBlock droppedOnType;

		// Token: 0x04001DD3 RID: 7635
		public global::ItemDataBlock resultItem;

		// Token: 0x04001DD4 RID: 7636
		public int amountToLose = 1;

		// Token: 0x04001DD5 RID: 7637
		public int amountToLoseOther = 1;

		// Token: 0x04001DD6 RID: 7638
		public int amountToGive = 1;
	}

	// Token: 0x0200069B RID: 1691
	[global::System.Serializable]
	public enum ItemCategory
	{
		// Token: 0x04001DD8 RID: 7640
		Survival,
		// Token: 0x04001DD9 RID: 7641
		Weapons,
		// Token: 0x04001DDA RID: 7642
		Ammo,
		// Token: 0x04001DDB RID: 7643
		Misc,
		// Token: 0x04001DDC RID: 7644
		Medical,
		// Token: 0x04001DDD RID: 7645
		Armor,
		// Token: 0x04001DDE RID: 7646
		Blueprint,
		// Token: 0x04001DDF RID: 7647
		Food,
		// Token: 0x04001DE0 RID: 7648
		Tools,
		// Token: 0x04001DE1 RID: 7649
		Mods,
		// Token: 0x04001DE2 RID: 7650
		Parts,
		// Token: 0x04001DE3 RID: 7651
		Resource
	}

	// Token: 0x0200069C RID: 1692
	public enum TransientMode
	{
		// Token: 0x04001DE5 RID: 7653
		Full,
		// Token: 0x04001DE6 RID: 7654
		DoesNotSave,
		// Token: 0x04001DE7 RID: 7655
		Untransferable,
		// Token: 0x04001DE8 RID: 7656
		None
	}
}
