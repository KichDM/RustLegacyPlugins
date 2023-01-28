using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Facepunch;
using RustProto;
using RustProto.Helpers;
using uLink;
using UnityEngine;

// Token: 0x02000639 RID: 1593
[global::NGCAutoAddScript]
public class Inventory : global::IDLocal
{
	// Token: 0x0600327F RID: 12927 RVA: 0x000C12B8 File Offset: 0x000BF4B8
	public Inventory()
	{
	}

	// Token: 0x17000A81 RID: 2689
	// (get) Token: 0x06003280 RID: 12928 RVA: 0x000C12C0 File Offset: 0x000BF4C0
	public bool isCraftingInventory
	{
		get
		{
			return this is global::CraftingInventory;
		}
	}

	// Token: 0x17000A82 RID: 2690
	// (get) Token: 0x06003281 RID: 12929 RVA: 0x000C12CC File Offset: 0x000BF4CC
	public float craftingSpeed
	{
		get
		{
			global::CraftingInventory craftingInventory = this as global::CraftingInventory;
			if (craftingInventory == null)
			{
				return 0f;
			}
			return craftingInventory.craftingSpeedPerSec;
		}
	}

	// Token: 0x17000A83 RID: 2691
	// (get) Token: 0x06003282 RID: 12930 RVA: 0x000C12F8 File Offset: 0x000BF4F8
	public bool isCrafting
	{
		get
		{
			global::CraftingInventory craftingInventory = this as global::CraftingInventory;
			return craftingInventory && craftingInventory.isCrafting;
		}
	}

	// Token: 0x17000A84 RID: 2692
	// (get) Token: 0x06003283 RID: 12931 RVA: 0x000C1320 File Offset: 0x000BF520
	public float? craftingCompletePercent
	{
		get
		{
			global::CraftingInventory craftingInventory = this as global::CraftingInventory;
			if (craftingInventory)
			{
				return craftingInventory.craftingCompletePercent;
			}
			return null;
		}
	}

	// Token: 0x17000A85 RID: 2693
	// (get) Token: 0x06003284 RID: 12932 RVA: 0x000C1350 File Offset: 0x000BF550
	public float? craftingSecondsRemaining
	{
		get
		{
			global::CraftingInventory craftingInventory = this as global::CraftingInventory;
			if (craftingInventory)
			{
				return craftingInventory.craftingSecondsRemaining;
			}
			return null;
		}
	}

	// Token: 0x17000A86 RID: 2694
	// (get) Token: 0x06003285 RID: 12933 RVA: 0x000C1380 File Offset: 0x000BF580
	public int slotCount
	{
		get
		{
			return this.collection.Capacity;
		}
	}

	// Token: 0x17000A87 RID: 2695
	// (get) Token: 0x06003286 RID: 12934 RVA: 0x000C1390 File Offset: 0x000BF590
	public int occupiedSlotCount
	{
		get
		{
			return this.collection.OccupiedCount;
		}
	}

	// Token: 0x17000A88 RID: 2696
	// (get) Token: 0x06003287 RID: 12935 RVA: 0x000C13A0 File Offset: 0x000BF5A0
	public int vacantSlotCount
	{
		get
		{
			return this.collection.VacantCount;
		}
	}

	// Token: 0x17000A89 RID: 2697
	// (get) Token: 0x06003288 RID: 12936 RVA: 0x000C13B0 File Offset: 0x000BF5B0
	public int dirtySlotCount
	{
		get
		{
			return this.collection.DirtyCount;
		}
	}

	// Token: 0x17000A8A RID: 2698
	// (get) Token: 0x06003289 RID: 12937 RVA: 0x000C13C0 File Offset: 0x000BF5C0
	public global::IInventoryItem firstItem
	{
		get
		{
			global::InventoryItem inventoryItem;
			if (this.collection.GetByOrder(0, out inventoryItem))
			{
				return inventoryItem.iface;
			}
			return null;
		}
	}

	// Token: 0x17000A8B RID: 2699
	// (get) Token: 0x0600328A RID: 12938 RVA: 0x000C13E8 File Offset: 0x000BF5E8
	public global::Inventory.OccupiedIterator occupiedIterator
	{
		get
		{
			return new global::Inventory.OccupiedIterator(this);
		}
	}

	// Token: 0x17000A8C RID: 2700
	// (get) Token: 0x0600328B RID: 12939 RVA: 0x000C13F0 File Offset: 0x000BF5F0
	public global::Inventory.OccupiedReverseIterator occupiedReverseIterator
	{
		get
		{
			return new global::Inventory.OccupiedReverseIterator(this);
		}
	}

	// Token: 0x17000A8D RID: 2701
	// (get) Token: 0x0600328C RID: 12940 RVA: 0x000C13F8 File Offset: 0x000BF5F8
	public global::Inventory.VacantIterator vacantIterator
	{
		get
		{
			return new global::Inventory.VacantIterator(this);
		}
	}

	// Token: 0x17000A8E RID: 2702
	// (get) Token: 0x0600328D RID: 12941 RVA: 0x000C1400 File Offset: 0x000BF600
	public bool noVacantSlots
	{
		get
		{
			return this.collection.HasNoVacancy;
		}
	}

	// Token: 0x17000A8F RID: 2703
	// (get) Token: 0x0600328E RID: 12942 RVA: 0x000C1410 File Offset: 0x000BF610
	public bool noOccupiedSlots
	{
		get
		{
			return this.collection.HasNoOccupant;
		}
	}

	// Token: 0x17000A90 RID: 2704
	// (get) Token: 0x0600328F RID: 12943 RVA: 0x000C1420 File Offset: 0x000BF620
	public bool anyVacantSlots
	{
		get
		{
			return this.collection.HasVacancy;
		}
	}

	// Token: 0x17000A91 RID: 2705
	// (get) Token: 0x06003290 RID: 12944 RVA: 0x000C1430 File Offset: 0x000BF630
	public bool anyOccupiedSlots
	{
		get
		{
			return this.collection.HasAnyOccupant;
		}
	}

	// Token: 0x17000A92 RID: 2706
	// (get) Token: 0x06003291 RID: 12945 RVA: 0x000C1440 File Offset: 0x000BF640
	public bool initialized
	{
		get
		{
			return this._collection_made_;
		}
	}

	// Token: 0x17000A93 RID: 2707
	// (get) Token: 0x06003292 RID: 12946 RVA: 0x000C1448 File Offset: 0x000BF648
	// (set) Token: 0x06003293 RID: 12947 RVA: 0x000C1450 File Offset: 0x000BF650
	public bool locked
	{
		get
		{
			return this._locked;
		}
		set
		{
			this._locked = value;
		}
	}

	// Token: 0x17000A94 RID: 2708
	// (get) Token: 0x06003294 RID: 12948 RVA: 0x000C145C File Offset: 0x000BF65C
	public global::InventoryHolder inventoryHolder
	{
		get
		{
			if (!this._inventoryHolder.cached)
			{
				this._inventoryHolder = base.GetLocal<global::InventoryHolder>();
			}
			return this._inventoryHolder.value;
		}
	}

	// Token: 0x17000A95 RID: 2709
	// (get) Token: 0x06003295 RID: 12949 RVA: 0x000C1498 File Offset: 0x000BF698
	public global::EquipmentWearer equipmentWearer
	{
		get
		{
			if (!this._equipmentWearer.cached)
			{
				this._equipmentWearer = base.GetLocal<global::EquipmentWearer>();
			}
			return this._equipmentWearer.value;
		}
	}

	// Token: 0x17000A96 RID: 2710
	// (get) Token: 0x06003296 RID: 12950 RVA: 0x000C14D4 File Offset: 0x000BF6D4
	protected global::InventoryItem firstInventoryItem
	{
		get
		{
			global::InventoryItem result;
			if (this.collection.GetByOrder(0, out result))
			{
				return result;
			}
			return null;
		}
	}

	// Token: 0x17000A97 RID: 2711
	// (get) Token: 0x06003297 RID: 12951 RVA: 0x000C14F8 File Offset: 0x000BF6F8
	protected global::HumanController hackyNeedToFixHumanControllGetValue
	{
		get
		{
			global::Character character = this.idMain as global::Character;
			return (!character) ? null : (character.controller as global::HumanController);
		}
	}

	// Token: 0x06003298 RID: 12952 RVA: 0x000C1530 File Offset: 0x000BF730
	private void Initialize(int slotCount)
	{
		if (this._collection_made_)
		{
			this.Clear();
			this._collection_ = null;
			this._collection_made_ = false;
		}
		this._slotFlags = global::Inventory.Empty.SlotFlags;
		this._collection_ = new global::Inventory.Collection<global::InventoryItem>(slotCount);
		this._collection_made_ = true;
		this.slotRanges = default(global::Inventory.Slot.KindDictionary<global::Inventory.Slot.Range>);
		this.slotRanges[global::Inventory.Slot.Kind.Default] = new global::Inventory.Slot.Range(0, slotCount);
		this.ConfigureSlots(slotCount, ref this.slotRanges, ref this._slotFlags);
		this._collection_.MarkCompletelyDirty();
		this._collection_.ForcedDirty = true;
	}

	// Token: 0x06003299 RID: 12953 RVA: 0x000C15C8 File Offset: 0x000BF7C8
	protected bool InitializeThisFixedSizeInventory()
	{
		global::FixedSizeInventory fixedSizeInventory = this as global::FixedSizeInventory;
		if (object.ReferenceEquals(fixedSizeInventory, null))
		{
			return false;
		}
		int fixedSlotCount = fixedSizeInventory.fixedSlotCount;
		if (this._collection_made_)
		{
			if (this._collection_.Capacity == fixedSlotCount)
			{
				return false;
			}
			global::UnityEngine.Debug.LogError("Some how this inventory was already inititalized to a different size. It will be reinitialized. the original off size was " + this._collection_.Capacity, this);
		}
		this.Initialize(fixedSlotCount);
		return true;
	}

	// Token: 0x0600329A RID: 12954 RVA: 0x000C163C File Offset: 0x000BF83C
	public bool TryToInitializeSize(int lootSize)
	{
		if (this is global::FixedSizeInventory && (this as global::FixedSizeInventory).fixedSlotCount != lootSize)
		{
			return false;
		}
		if (this._collection_made_)
		{
			global::UnityEngine.Debug.Log("too late", this);
			return false;
		}
		this.Initialize(lootSize);
		return true;
	}

	// Token: 0x0600329B RID: 12955 RVA: 0x000C1688 File Offset: 0x000BF888
	public static byte RPCInteger(int i)
	{
		return (byte)i;
	}

	// Token: 0x0600329C RID: 12956 RVA: 0x000C168C File Offset: 0x000BF88C
	public static byte RPCInteger(byte i)
	{
		return i;
	}

	// Token: 0x0600329D RID: 12957 RVA: 0x000C1690 File Offset: 0x000BF890
	public static byte RPCInteger(global::uLink.BitStream stream)
	{
		return stream.Read<byte>(new object[0]);
	}

	// Token: 0x0600329E RID: 12958 RVA: 0x000C16A0 File Offset: 0x000BF8A0
	public global::Inventory.AddExistingItemResult AddExistingItem(global::IInventoryItem iitem, bool forbidStacking)
	{
		return this.AddExistingItem(iitem, forbidStacking, false);
	}

	// Token: 0x0600329F RID: 12959 RVA: 0x000C16AC File Offset: 0x000BF8AC
	public global::IInventoryItem AddItem(global::ItemDataBlock datablock, global::Inventory.Slot.Preference slot, global::Inventory.Uses.Quantity uses)
	{
		global::Datablock.Ident ident = (global::Datablock.Ident)datablock;
		return this.AddItem(ref ident, slot, uses);
	}

	// Token: 0x060032A0 RID: 12960 RVA: 0x000C16CC File Offset: 0x000BF8CC
	public global::IInventoryItem AddItem(ref global::Datablock.Ident ident, global::Inventory.Slot.Preference slot, global::Inventory.Uses.Quantity uses)
	{
		global::Inventory.Addition addition = default(global::Inventory.Addition);
		global::Inventory.Addition addition2 = addition;
		addition2.ItemDataBlock = (global::ItemDataBlock)ident.datablock;
		addition2.SlotPreference = slot;
		addition2.UsesQuantity = uses;
		addition = addition2;
		return this.AddItem(ref addition);
	}

	// Token: 0x060032A1 RID: 12961 RVA: 0x000C1710 File Offset: 0x000BF910
	public global::IInventoryItem AddItem(ref global::Inventory.Addition itemAdd)
	{
		return this.AddItem(ref itemAdd, (global::Inventory.Payload.Opt)0, null);
	}

	// Token: 0x060032A2 RID: 12962 RVA: 0x000C171C File Offset: 0x000BF91C
	public void AddItems(global::Inventory.Addition[] itemAdds)
	{
		for (int i = 0; i < itemAdds.Length; i++)
		{
			this.AddItem(ref itemAdds[i]);
		}
	}

	// Token: 0x060032A3 RID: 12963 RVA: 0x000C174C File Offset: 0x000BF94C
	public global::IInventoryItem AddItemSomehow(global::ItemDataBlock item, global::Inventory.Slot.Kind? slotKindPref, int slotOffset, int usesCount)
	{
		global::IInventoryItem result;
		if (item && (usesCount > 0 || !item.IsSplittable()))
		{
			global::IInventoryItem inventoryItem = this.AddItemSomehowWork(item, slotKindPref, slotOffset, usesCount);
			result = inventoryItem;
		}
		else
		{
			result = null;
		}
		return result;
	}

	// Token: 0x060032A4 RID: 12964 RVA: 0x000C178C File Offset: 0x000BF98C
	public int AddItemAmount(global::ItemDataBlock datablock, int amount, global::Inventory.AmountMode mode, global::Inventory.Uses.Quantity perNonSplittableItemUseQuantity)
	{
		return this.AddItemAmount(datablock, amount, mode, new global::Inventory.Uses.Quantity?(perNonSplittableItemUseQuantity), null);
	}

	// Token: 0x060032A5 RID: 12965 RVA: 0x000C17B4 File Offset: 0x000BF9B4
	public int AddItemAmount(ref global::Datablock.Ident ident, int amount, global::Inventory.AmountMode mode, global::Inventory.Uses.Quantity perNonSplittableItemUseQuantity)
	{
		return this.AddItemAmount((global::ItemDataBlock)ident.datablock, amount, mode, new global::Inventory.Uses.Quantity?(perNonSplittableItemUseQuantity), null);
	}

	// Token: 0x060032A6 RID: 12966 RVA: 0x000C17E4 File Offset: 0x000BF9E4
	public int AddItemAmount(global::ItemDataBlock datablock, int amount, global::Inventory.AmountMode mode)
	{
		return this.AddItemAmount(datablock, amount, mode, null, null);
	}

	// Token: 0x060032A7 RID: 12967 RVA: 0x000C180C File Offset: 0x000BFA0C
	public int AddItemAmount(ref global::Datablock.Ident ident, int amount, global::Inventory.AmountMode mode)
	{
		return this.AddItemAmount((global::ItemDataBlock)ident.datablock, amount, mode, null, null);
	}

	// Token: 0x060032A8 RID: 12968 RVA: 0x000C1840 File Offset: 0x000BFA40
	public int AddItemAmount(global::ItemDataBlock datablock, int amount, global::Inventory.Uses.Quantity perNonSplittableItemUseQuantity)
	{
		return this.AddItemAmount(datablock, amount, global::Inventory.AmountMode.Default, new global::Inventory.Uses.Quantity?(perNonSplittableItemUseQuantity), null);
	}

	// Token: 0x060032A9 RID: 12969 RVA: 0x000C1868 File Offset: 0x000BFA68
	public int AddItemAmount(ref global::Datablock.Ident ident, int amount, global::Inventory.Uses.Quantity perNonSplittableItemUseQuantity)
	{
		return this.AddItemAmount((global::ItemDataBlock)ident.datablock, amount, global::Inventory.AmountMode.Default, new global::Inventory.Uses.Quantity?(perNonSplittableItemUseQuantity), null);
	}

	// Token: 0x060032AA RID: 12970 RVA: 0x000C1898 File Offset: 0x000BFA98
	public int AddItemAmount(global::ItemDataBlock datablock, int amount)
	{
		return this.AddItemAmount(datablock, amount, global::Inventory.AmountMode.Default, null, null);
	}

	// Token: 0x060032AB RID: 12971 RVA: 0x000C18C0 File Offset: 0x000BFAC0
	public int AddItemAmount(ref global::Datablock.Ident ident, int amount)
	{
		return this.AddItemAmount((global::ItemDataBlock)ident.datablock, amount, global::Inventory.AmountMode.Default, null, null);
	}

	// Token: 0x060032AC RID: 12972 RVA: 0x000C18F4 File Offset: 0x000BFAF4
	public int AddItemAmount(global::ItemDataBlock datablock, int amount, global::Inventory.AmountMode mode, global::Inventory.Uses.Quantity perNonSplittableItemUseQuantity, global::Inventory.Slot.Preference slotPref)
	{
		return this.AddItemAmount(datablock, amount, mode, new global::Inventory.Uses.Quantity?(perNonSplittableItemUseQuantity), new global::Inventory.Slot.Preference?(slotPref));
	}

	// Token: 0x060032AD RID: 12973 RVA: 0x000C1910 File Offset: 0x000BFB10
	public int AddItemAmount(ref global::Datablock.Ident ident, int amount, global::Inventory.AmountMode mode, global::Inventory.Uses.Quantity perNonSplittableItemUseQuantity, global::Inventory.Slot.Preference slotPref)
	{
		return this.AddItemAmount((global::ItemDataBlock)ident.datablock, amount, mode, new global::Inventory.Uses.Quantity?(perNonSplittableItemUseQuantity), new global::Inventory.Slot.Preference?(slotPref));
	}

	// Token: 0x060032AE RID: 12974 RVA: 0x000C1940 File Offset: 0x000BFB40
	public int AddItemAmount(global::ItemDataBlock datablock, int amount, global::Inventory.AmountMode mode, global::Inventory.Slot.Preference slotPref)
	{
		return this.AddItemAmount(datablock, amount, mode, null, new global::Inventory.Slot.Preference?(slotPref));
	}

	// Token: 0x060032AF RID: 12975 RVA: 0x000C1968 File Offset: 0x000BFB68
	public int AddItemAmount(ref global::Datablock.Ident ident, int amount, global::Inventory.AmountMode mode, global::Inventory.Slot.Preference slotPref)
	{
		return this.AddItemAmount((global::ItemDataBlock)ident.datablock, amount, mode, null, new global::Inventory.Slot.Preference?(slotPref));
	}

	// Token: 0x060032B0 RID: 12976 RVA: 0x000C1998 File Offset: 0x000BFB98
	public int AddItemAmount(global::ItemDataBlock datablock, int amount, global::Inventory.Uses.Quantity perNonSplittableItemUseQuantity, global::Inventory.Slot.Preference slotPref)
	{
		return this.AddItemAmount(datablock, amount, global::Inventory.AmountMode.Default, new global::Inventory.Uses.Quantity?(perNonSplittableItemUseQuantity), new global::Inventory.Slot.Preference?(slotPref));
	}

	// Token: 0x060032B1 RID: 12977 RVA: 0x000C19B0 File Offset: 0x000BFBB0
	public int AddItemAmount(ref global::Datablock.Ident ident, int amount, global::Inventory.Uses.Quantity perNonSplittableItemUseQuantity, global::Inventory.Slot.Preference slotPref)
	{
		return this.AddItemAmount((global::ItemDataBlock)ident.datablock, amount, global::Inventory.AmountMode.Default, new global::Inventory.Uses.Quantity?(perNonSplittableItemUseQuantity), new global::Inventory.Slot.Preference?(slotPref));
	}

	// Token: 0x060032B2 RID: 12978 RVA: 0x000C19E0 File Offset: 0x000BFBE0
	public int AddItemAmount(global::ItemDataBlock datablock, int amount, global::Inventory.Slot.Preference slotPref)
	{
		return this.AddItemAmount(datablock, amount, global::Inventory.AmountMode.Default, null, new global::Inventory.Slot.Preference?(slotPref));
	}

	// Token: 0x060032B3 RID: 12979 RVA: 0x000C1A08 File Offset: 0x000BFC08
	public int AddItemAmount(ref global::Datablock.Ident ident, int amount, global::Inventory.Slot.Preference slotPref)
	{
		return this.AddItemAmount((global::ItemDataBlock)ident.datablock, amount, global::Inventory.AmountMode.Default, null, new global::Inventory.Slot.Preference?(slotPref));
	}

	// Token: 0x060032B4 RID: 12980 RVA: 0x000C1A38 File Offset: 0x000BFC38
	public bool RemoveItem(int slot)
	{
		return this.RemoveItem(slot, null, false);
	}

	// Token: 0x060032B5 RID: 12981 RVA: 0x000C1A44 File Offset: 0x000BFC44
	public bool RemoveItem(global::InventoryItem item)
	{
		return !object.ReferenceEquals(item, null) && !(item.inventory != this) && this.RemoveItem(item.slot, item, true);
	}

	// Token: 0x060032B6 RID: 12982 RVA: 0x000C1A80 File Offset: 0x000BFC80
	public bool RemoveItem(global::IInventoryItem item)
	{
		return this.RemoveItem(item as global::InventoryItem);
	}

	// Token: 0x060032B7 RID: 12983 RVA: 0x000C1A90 File Offset: 0x000BFC90
	[global::System.Obsolete("This isnt right")]
	public void NULL_SLOT_FIX_ME(int slot)
	{
		this.DeleteItem(slot);
	}

	// Token: 0x060032B8 RID: 12984 RVA: 0x000C1A9C File Offset: 0x000BFC9C
	public void Clear()
	{
		using (global::Inventory.Collection<global::InventoryItem>.OccupiedCollection.ReverseEnumerator occupiedReverseEnumerator = this.collection.OccupiedReverseEnumerator)
		{
			while (occupiedReverseEnumerator.MoveNext())
			{
				this.DeleteItem(occupiedReverseEnumerator.Slot);
			}
		}
	}

	// Token: 0x060032B9 RID: 12985 RVA: 0x000C1B00 File Offset: 0x000BFD00
	public bool IsSlotDirty(int slot)
	{
		return this.collection.IsDirty(slot);
	}

	// Token: 0x060032BA RID: 12986 RVA: 0x000C1B10 File Offset: 0x000BFD10
	public bool MarkSlotDirty(int slot)
	{
		return this.collection.MarkDirty(slot);
	}

	// Token: 0x060032BB RID: 12987 RVA: 0x000C1B20 File Offset: 0x000BFD20
	public bool MarkSlotClean(int slot)
	{
		return this.collection.MarkClean(slot);
	}

	// Token: 0x060032BC RID: 12988 RVA: 0x000C1B30 File Offset: 0x000BFD30
	public bool IsSlotVacant(int slot)
	{
		return this.collection.IsVacant(slot);
	}

	// Token: 0x060032BD RID: 12989 RVA: 0x000C1B40 File Offset: 0x000BFD40
	public bool IsSlotOccupied(int slot)
	{
		return this.collection.IsOccupied(slot);
	}

	// Token: 0x060032BE RID: 12990 RVA: 0x000C1B50 File Offset: 0x000BFD50
	public bool IsSlotWithinRange(int slot)
	{
		return this.collection.IsWithinRange(slot);
	}

	// Token: 0x060032BF RID: 12991 RVA: 0x000C1B60 File Offset: 0x000BFD60
	public int CanConsume(global::ItemDataBlock db, int useCount, global::System.Collections.Generic.List<int> storeToList)
	{
		global::Inventory.Collection<global::InventoryItem> collection = this.collection;
		if (useCount <= 0 || !db || collection.HasNoOccupant)
		{
			return 0;
		}
		if (storeToList == null)
		{
			return this.CanConsume(db, useCount);
		}
		int count = storeToList.Count;
		int num = 0;
		int uniqueID = db.uniqueID;
		using (global::Inventory.Collection<global::InventoryItem>.OccupiedCollection.Enumerator occupiedEnumerator = collection.OccupiedEnumerator)
		{
			while (occupiedEnumerator.MoveNext())
			{
				global::InventoryItem inventoryItem = occupiedEnumerator.Current;
				if (inventoryItem.datablockUniqueID == uniqueID)
				{
					useCount -= inventoryItem.uses;
					storeToList.Add(occupiedEnumerator.Slot);
					num++;
					if (useCount <= 0)
					{
						return num;
					}
				}
			}
		}
		if (num > 0)
		{
			storeToList.RemoveRange(count, num);
		}
		return -useCount;
	}

	// Token: 0x060032C0 RID: 12992 RVA: 0x000C1C50 File Offset: 0x000BFE50
	public int CanConsume(global::ItemDataBlock db, int useCount)
	{
		global::Inventory.Collection<global::InventoryItem> collection = this.collection;
		if (useCount <= 0 || collection.HasNoOccupant)
		{
			return 0;
		}
		int num = 0;
		int uniqueID = db.uniqueID;
		using (global::Inventory.Collection<global::InventoryItem>.OccupiedCollection.Enumerator occupiedEnumerator = this.collection.OccupiedEnumerator)
		{
			while (occupiedEnumerator.MoveNext())
			{
				global::InventoryItem inventoryItem = occupiedEnumerator.Current;
				if (inventoryItem.datablockUniqueID == uniqueID)
				{
					useCount -= inventoryItem.uses;
					num++;
					if (useCount <= 0)
					{
						return num;
					}
				}
			}
		}
		return -useCount;
	}

	// Token: 0x060032C1 RID: 12993 RVA: 0x000C1D04 File Offset: 0x000BFF04
	public bool GetItem(int slot, out global::IInventoryItem item)
	{
		global::InventoryItem inventoryItem;
		if (!this._collection_made_ || !this._collection_.Get(slot, out inventoryItem))
		{
			item = null;
			return false;
		}
		item = inventoryItem.iface;
		return true;
	}

	// Token: 0x060032C2 RID: 12994 RVA: 0x000C1D40 File Offset: 0x000BFF40
	protected bool GetItem(int slot, out global::InventoryItem item)
	{
		if (!this._collection_made_)
		{
			item = null;
			return false;
		}
		return this._collection_.Get(slot, out item);
	}

	// Token: 0x060032C3 RID: 12995 RVA: 0x000C1D60 File Offset: 0x000BFF60
	public bool GetSlotsOfKind(global::Inventory.Slot.Kind kind, out global::Inventory.Slot.Range range)
	{
		return this.slotRanges.TryGetValue(kind, out range);
	}

	// Token: 0x060032C4 RID: 12996 RVA: 0x000C1D70 File Offset: 0x000BFF70
	public bool HasSlotsOfKind(global::Inventory.Slot.Kind kind)
	{
		return this.slotRanges.ContainsKey(kind);
	}

	// Token: 0x060032C5 RID: 12997 RVA: 0x000C1D80 File Offset: 0x000BFF80
	public bool IsSlotFree(int slot)
	{
		return this.collection.IsVacant(slot);
	}

	// Token: 0x060032C6 RID: 12998 RVA: 0x000C1D90 File Offset: 0x000BFF90
	public global::Inventory.SlotFlags GetSlotFlags(int slot)
	{
		return (this._slotFlags != null && this._slotFlags.Length > slot) ? this._slotFlags[slot] : ((global::Inventory.SlotFlags)0);
	}

	// Token: 0x060032C7 RID: 12999 RVA: 0x000C1DBC File Offset: 0x000BFFBC
	public bool GetSlotKind(int slot, out global::Inventory.Slot.Kind kind, out int offset)
	{
		if (slot >= 0 && slot < this.slotCount)
		{
			for (global::Inventory.Slot.Kind kind2 = global::Inventory.Slot.Kind.Default; kind2 < (global::Inventory.Slot.Kind)3; kind2 += 1)
			{
				global::Inventory.Slot.Range range;
				if (this.slotRanges.TryGetValue(kind2, out range))
				{
					offset = range.GetOffset(slot);
					if (offset != -1)
					{
						kind = kind2;
						return true;
					}
				}
			}
		}
		kind = global::Inventory.Slot.Kind.Default;
		offset = -1;
		return false;
	}

	// Token: 0x060032C8 RID: 13000 RVA: 0x000C1E20 File Offset: 0x000C0020
	public bool GetSlotForKind(global::Inventory.Slot.Kind kind, int offset, out int slot)
	{
		global::Inventory.Slot.Range range;
		if (offset >= 0 && this.slotRanges.TryGetValue(kind, out range) && offset < range.Count)
		{
			slot = range.Start + offset;
			return true;
		}
		slot = -1;
		return false;
	}

	// Token: 0x060032C9 RID: 13001 RVA: 0x000C1E68 File Offset: 0x000C0068
	public bool IsSlotOffsetValid(global::Inventory.Slot.Kind kind, int offset)
	{
		int num;
		return this.GetSlotForKind(kind, offset, out num);
	}

	// Token: 0x060032CA RID: 13002 RVA: 0x000C1E80 File Offset: 0x000C0080
	public bool CanItemFit(global::IInventoryItem iitem)
	{
		global::InventoryItem inventoryItem = iitem as global::InventoryItem;
		global::ItemDataBlock datablock = inventoryItem.datablock;
		if (datablock.IsSplittable())
		{
			int num = inventoryItem.uses;
			using (global::Inventory.Collection<global::InventoryItem>.OccupiedCollection.Enumerator occupiedEnumerator = this.collection.OccupiedEnumerator)
			{
				while (occupiedEnumerator.MoveNext())
				{
					global::InventoryItem inventoryItem2 = occupiedEnumerator.Current;
					if (inventoryItem2.datablockUniqueID == inventoryItem.datablockUniqueID)
					{
						if (inventoryItem2 != iitem)
						{
							int num2 = datablock._maxUses - inventoryItem2.uses;
							if (num2 >= num)
							{
								return true;
							}
							num -= num2;
						}
					}
				}
			}
			return false;
		}
		return this.anyVacantSlots;
	}

	// Token: 0x060032CB RID: 13003 RVA: 0x000C1F50 File Offset: 0x000C0150
	private bool CheckSlotFlagsAgainstSlot(global::Inventory.SlotFlags itemSlotFlags, int slot)
	{
		return this.CheckSlotFlags(itemSlotFlags, this.GetSlotFlags(slot));
	}

	// Token: 0x060032CC RID: 13004 RVA: 0x000C1F60 File Offset: 0x000C0160
	public global::IngredientList<global::ItemDataBlock> ToIngredientList()
	{
		global::Inventory.Collection<global::InventoryItem> collection = this.collection;
		int occupiedCount = collection.OccupiedCount;
		global::ItemDataBlock[] array = new global::ItemDataBlock[occupiedCount];
		using (global::Inventory.Collection<global::InventoryItem>.OccupiedCollection.Enumerator occupiedEnumerator = collection.OccupiedEnumerator)
		{
			int newSize = 0;
			while (occupiedEnumerator.MoveNext())
			{
				global::InventoryItem inventoryItem = occupiedEnumerator.Current;
				array[newSize++] = inventoryItem.datablock;
			}
			global::System.Array.Resize<global::ItemDataBlock>(ref array, newSize);
		}
		return new global::IngredientList<global::ItemDataBlock>(array);
	}

	// Token: 0x060032CD RID: 13005 RVA: 0x000C1FF4 File Offset: 0x000C01F4
	public bool MoveItemAtSlotToEmptySlot(global::Inventory toInv, int fromSlot, int toSlot)
	{
		if (!toInv)
		{
			return false;
		}
		if (toInv == this && fromSlot == toSlot)
		{
			return false;
		}
		global::Inventory.Collection<global::InventoryItem> collection = this.collection;
		if (collection.HasNoOccupant)
		{
			return false;
		}
		global::InventoryItem inventoryItem;
		if (!collection.Get(fromSlot, out inventoryItem))
		{
			return false;
		}
		global::ItemDataBlock datablock = inventoryItem.datablock;
		global::Inventory.Addition addition = default(global::Inventory.Addition);
		global::Inventory.Addition addition2 = addition;
		addition2.ItemDataBlock = datablock;
		addition2.UsesQuantity = inventoryItem.uses;
		addition2.SlotPreference = global::Inventory.Slot.Preference.Define(toSlot, datablock.IsSplittable());
		addition = addition2;
		return !object.ReferenceEquals(toInv.AddItem(ref addition, global::Inventory.Payload.Opt.DoNotStack | global::Inventory.Payload.Opt.RestrictToOffset | global::Inventory.Payload.Opt.ReuseItem, inventoryItem), null);
	}

	// Token: 0x060032CE RID: 13006 RVA: 0x000C20A0 File Offset: 0x000C02A0
	[global::System.Obsolete("Do not use")]
	public void GiveAllTo(global::Inventory toInv)
	{
		global::Inventory.Collection<global::InventoryItem> collection = this.collection;
		if (collection.HasNoOccupant)
		{
			return;
		}
		try
		{
			global::UnityEngine.Debug.LogWarning(string.Concat(new object[]
			{
				"Inventory.GiveAllTo Called On ",
				this,
				" To ",
				toInv,
				"\n",
				global::UnityEngine.StackTraceUtility.ExtractStackTrace()
			}));
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogException(ex);
		}
		global::InventoryItem[] array = collection.OccupiedToArray();
		foreach (global::InventoryItem inventoryItem in array)
		{
			global::ItemDataBlock datablock = inventoryItem.datablock;
			global::Inventory.Addition addition = default(global::Inventory.Addition);
			global::Inventory.Addition addition2 = addition;
			addition2.ItemDataBlock = datablock;
			addition2.UsesQuantity = inventoryItem.uses;
			addition2.SlotPreference = global::Inventory.Slot.Preference.Define(global::Inventory.Slot.KindFlags.Default, global::Inventory.Slot.KindFlags.Belt | global::Inventory.Slot.KindFlags.Armor).CloneStackChange(datablock.IsSplittable());
			addition = addition2;
			toInv.AddItem(ref addition, global::Inventory.Payload.Opt.IgnoreSlotOffset | global::Inventory.Payload.Opt.ReuseItem, inventoryItem);
		}
	}

	// Token: 0x060032CF RID: 13007 RVA: 0x000C21AC File Offset: 0x000C03AC
	public T FindItemType<T>() where T : class, global::IInventoryItem
	{
		using (global::Inventory.Collection<global::InventoryItem>.OccupiedCollection.Enumerator occupiedEnumerator = this.collection.OccupiedEnumerator)
		{
			while (occupiedEnumerator.MoveNext())
			{
				global::InventoryItem inventoryItem = occupiedEnumerator.Current;
				T t = inventoryItem.iface as T;
				if (!object.ReferenceEquals(t, null))
				{
					return t;
				}
			}
		}
		return (T)((object)null);
	}

	// Token: 0x060032D0 RID: 13008 RVA: 0x000C223C File Offset: 0x000C043C
	public IItemT FindItem<IItemT>() where IItemT : class, global::IInventoryItem
	{
		using (global::Inventory.Collection<global::InventoryItem>.OccupiedCollection.Enumerator occupiedEnumerator = this.collection.OccupiedEnumerator)
		{
			while (occupiedEnumerator.MoveNext())
			{
				global::InventoryItem inventoryItem = occupiedEnumerator.Current;
				IItemT itemT = inventoryItem.iface as IItemT;
				if (!object.ReferenceEquals(itemT, null))
				{
					return itemT;
				}
			}
		}
		return (IItemT)((object)null);
	}

	// Token: 0x060032D1 RID: 13009 RVA: 0x000C22CC File Offset: 0x000C04CC
	public global::System.Collections.Generic.IEnumerable<IItemT> FindItems<IItemT>() where IItemT : class, global::IInventoryItem
	{
		using (global::Inventory.Collection<global::InventoryItem>.OccupiedCollection.Enumerator enumerator = this.collection.OccupiedEnumerator)
		{
			while (enumerator.MoveNext())
			{
				global::InventoryItem inventoryItem = enumerator.Current;
				IItemT item = inventoryItem.iface as IItemT;
				if (!object.ReferenceEquals(item, null))
				{
					yield return item;
				}
			}
		}
		yield break;
	}

	// Token: 0x060032D2 RID: 13010 RVA: 0x000C22F0 File Offset: 0x000C04F0
	public global::IInventoryItem FindItem(string itemDBName)
	{
		return this.FindItem(global::DatablockDictionary.GetByName(itemDBName));
	}

	// Token: 0x060032D3 RID: 13011 RVA: 0x000C2300 File Offset: 0x000C0500
	public global::IInventoryItem FindItem(global::ItemDataBlock itemDB)
	{
		int num = 0;
		return this.FindItem(itemDB, out num);
	}

	// Token: 0x060032D4 RID: 13012 RVA: 0x000C2318 File Offset: 0x000C0518
	public global::IInventoryItem FindItem(global::ItemDataBlock itemDB, out int totalNum)
	{
		bool flag = false;
		global::InventoryItem inventoryItem = null;
		int num = 0;
		int num2 = -1;
		int uniqueID = itemDB.uniqueID;
		using (global::Inventory.Collection<global::InventoryItem>.OccupiedCollection.Enumerator occupiedEnumerator = this.collection.OccupiedEnumerator)
		{
			while (occupiedEnumerator.MoveNext())
			{
				global::InventoryItem inventoryItem2 = occupiedEnumerator.Current;
				if (inventoryItem2.datablockUniqueID == uniqueID)
				{
					int uses = inventoryItem2.uses;
					if (!flag || uses > num2)
					{
						inventoryItem = inventoryItem2;
						num2 = uses;
						flag = true;
					}
					num += uses;
				}
			}
		}
		totalNum = num;
		global::IInventoryItem result;
		if (flag)
		{
			global::IInventoryItem iface = inventoryItem.iface;
			result = iface;
		}
		else
		{
			result = null;
		}
		return result;
	}

	// Token: 0x17000A98 RID: 2712
	// (get) Token: 0x060032D5 RID: 13013 RVA: 0x000C23D8 File Offset: 0x000C05D8
	public global::IInventoryItem activeItem
	{
		get
		{
			global::IInventoryItem result;
			if (this._activeItem == null)
			{
				global::IInventoryItem inventoryItem = null;
				result = inventoryItem;
			}
			else
			{
				result = this._activeItem.iface;
			}
			return result;
		}
	}

	// Token: 0x060032D6 RID: 13014 RVA: 0x000C2404 File Offset: 0x000C0604
	public void SetActiveItemManually(int itemIndex, global::ItemRepresentation itemRep, global::uLink.NetworkViewID? itemRepID = null)
	{
		global::IInventoryItem inventoryItem;
		this.GetItem(itemIndex, out inventoryItem);
		((global::IHeldItem)inventoryItem).itemRepresentation = itemRep;
		this.DoSetActiveItem((global::InventoryItem)inventoryItem);
		global::Facepunch.NetworkView networkView = base.networkView;
		if (networkView)
		{
			networkView.RPC("IAST", networkView.owner, new object[]
			{
				(byte)itemIndex,
				(itemRepID == null) ? ((!itemRep) ? global::uLink.NetworkViewID.unassigned : itemRep.networkView.viewID) : itemRepID.Value
			});
		}
	}

	// Token: 0x060032D7 RID: 13015 RVA: 0x000C24A8 File Offset: 0x000C06A8
	public void DeactivateItem()
	{
		this.DoDeactivateItem();
	}

	// Token: 0x060032D8 RID: 13016 RVA: 0x000C24B0 File Offset: 0x000C06B0
	public global::Inventory.Transfer[] GenerateOptimizedInventoryListing(global::Inventory.Slot.KindFlags fallbackPlacement)
	{
		global::Inventory.Collection<global::InventoryItem> collection = this.collection;
		if (collection.HasNoOccupant)
		{
			return new global::Inventory.Transfer[0];
		}
		global::Inventory.Transfer[] result;
		try
		{
			global::Inventory.Report.Begin();
			using (global::Inventory.Collection<global::InventoryItem>.OccupiedCollection.Enumerator occupiedEnumerator = collection.OccupiedEnumerator)
			{
				while (occupiedEnumerator.MoveNext())
				{
					global::InventoryItem item = occupiedEnumerator.Current;
					global::Inventory.Report.Take(item);
				}
			}
			result = global::Inventory.Report.Build(fallbackPlacement);
		}
		finally
		{
			global::Inventory.Report.Recover();
		}
		return result;
	}

	// Token: 0x060032D9 RID: 13017 RVA: 0x000C255C File Offset: 0x000C075C
	public global::Inventory.Transfer[] GenerateOptimizedInventoryListing(global::Inventory.Slot.KindFlags fallbackPlacement, bool randomize)
	{
		global::Inventory.Transfer[] array = this.GenerateOptimizedInventoryListing(fallbackPlacement);
		if (randomize && array.Length > 0)
		{
			global::Inventory.Shuffle.Array<global::Inventory.Transfer>(array);
			for (int i = 0; i < array.Length; i++)
			{
				array[i].addition.SlotPreference = array[i].addition.SlotPreference.CloneOffsetChange(i);
			}
		}
		return array;
	}

	// Token: 0x060032DA RID: 13018 RVA: 0x000C25C4 File Offset: 0x000C07C4
	public void ResetToReport(global::Inventory.Transfer[] items)
	{
		if (this._collection_made_)
		{
			this.Clear();
		}
		this.Initialize(items.Length);
		for (int i = 0; i < items.Length; i++)
		{
			this.AssignItem(ref items[i].addition, global::Inventory.Payload.Opt.DoNotStack | global::Inventory.Payload.Opt.RestrictToOffset | global::Inventory.Payload.Opt.ReuseItem, items[i].item);
		}
	}

	// Token: 0x060032DB RID: 13019 RVA: 0x000C2620 File Offset: 0x000C0820
	protected void BindArmorModelsFromArmorDatablockMap(global::ArmorModelMemberMap<global::ArmorDataBlock> armorDatablockMap)
	{
		this.lastNetworkedArmorDatablocks = armorDatablockMap;
		global::ArmorModelRenderer local = base.GetLocal<global::ArmorModelRenderer>();
		if (local)
		{
			global::ArmorModelMemberMap map = default(global::ArmorModelMemberMap);
			for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
			{
				global::ArmorDataBlock armorDataBlock = armorDatablockMap[armorModelSlot];
				map[armorModelSlot] = ((!armorDataBlock) ? null : armorDataBlock.GetArmorModel(armorModelSlot));
			}
			local.BindArmorModels(map);
		}
	}

	// Token: 0x060032DC RID: 13020 RVA: 0x000C2694 File Offset: 0x000C0894
	public void IssueArmorUpdate(global::ArmorModelMemberMap<global::ArmorDataBlock> armorDatablockMap)
	{
		if (this._blockArmorUpdates)
		{
			return;
		}
		if (this._iteratingArmor)
		{
			global::UnityEngine.Debug.LogError("IssueArmorUpdate should not be called with a callstack containing CheckForArmorChanges!\r\nNothing sent");
			return;
		}
		global::NetEntityID entID;
		if ((int)global::NetEntityID.Of(this, out entID) != 0)
		{
			global::uLink.BitStream bitStream = new global::uLink.BitStream(0x10, false);
			bool flag = false;
			for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
			{
				global::ArmorDataBlock armorDataBlock = armorDatablockMap[armorModelSlot];
				int num = (!armorDataBlock) ? 0 : armorDataBlock.uniqueID;
				if (!flag && num != 0)
				{
					flag = true;
				}
				bitStream.WriteInt32((!armorDataBlock) ? 0 : armorDataBlock.uniqueID);
			}
			if (this._armorBuffered)
			{
				global::NetCull.RemoveRPCsByName(entID, "CFAR");
				this._armorBuffered = false;
			}
			global::uLink.RPCMode rpcMode;
			bool armorBuffered;
			if (flag)
			{
				rpcMode = 5;
				armorBuffered = true;
			}
			else
			{
				rpcMode = 1;
				armorBuffered = false;
			}
			global::NetCull.RPC<global::uLink.BitStream>(this, "CFAR", rpcMode, bitStream);
			this._armorBuffered = armorBuffered;
		}
		this.BindArmorModelsFromArmorDatablockMap(armorDatablockMap);
	}

	// Token: 0x060032DD RID: 13021 RVA: 0x000C2794 File Offset: 0x000C0994
	public bool CheckForArmorChanges(out global::ArmorModelMemberMap<global::ArmorDataBlock> armorDatablocks)
	{
		armorDatablocks = this.lastNetworkedArmorDatablocks;
		if (this._blockArmorUpdates)
		{
			return false;
		}
		if (this._iteratingArmor)
		{
			global::UnityEngine.Debug.LogError("Invalid Recursive Call To CheckForArmor", this);
			return false;
		}
		bool result;
		try
		{
			this._iteratingArmor = true;
			if (this.GetArmorDatablockMap(ref armorDatablocks))
			{
				for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
				{
					if (this.lastNetworkedArmorDatablocks[armorModelSlot] != armorDatablocks[armorModelSlot])
					{
						return true;
					}
				}
			}
			result = false;
		}
		finally
		{
			this._iteratingArmor = false;
		}
		return result;
	}

	// Token: 0x060032DE RID: 13022 RVA: 0x000C284C File Offset: 0x000C0A4C
	public bool InvalidateArmor()
	{
		if (this._iteratingArmor)
		{
			return false;
		}
		global::ArmorModelMemberMap<global::ArmorDataBlock> armorDatablockMap;
		if (this.CheckForArmorChanges(out armorDatablockMap))
		{
			this.IssueArmorUpdate(armorDatablockMap);
			return true;
		}
		return false;
	}

	// Token: 0x060032DF RID: 13023 RVA: 0x000C2880 File Offset: 0x000C0A80
	public void BlockFutureArmorUpdates()
	{
		this._blockArmorUpdates = true;
	}

	// Token: 0x060032E0 RID: 13024 RVA: 0x000C288C File Offset: 0x000C0A8C
	public bool IsAnAuthorizedLooter(global::uLink.NetworkPlayer target)
	{
		return target.isClient && ((this._anyNetListeners && this._netListeners.Contains(target)) || base.networkViewOwner == target);
	}

	// Token: 0x060032E1 RID: 13025 RVA: 0x000C28D4 File Offset: 0x000C0AD4
	public bool IsAnAuthorizedLooter(global::uLink.NetworkPlayer target, bool reportCheater, string exploit_name = "loot_ua")
	{
		if (this.IsAnAuthorizedLooter(target))
		{
			return true;
		}
		if (reportCheater && target.isClient)
		{
			global::NetUser netUser = global::NetUser.Find(target);
			if (netUser != null)
			{
				global::FeedbackLog.Start(global::FeedbackLog.TYPE.SimpleExploit);
				global::FeedbackLog.Writer.Write(exploit_name);
				global::FeedbackLog.Writer.Write(netUser.userID);
				global::FeedbackLog.End(global::FeedbackLog.TYPE.SimpleExploit);
			}
		}
		return false;
	}

	// Token: 0x060032E2 RID: 13026 RVA: 0x000C2938 File Offset: 0x000C0B38
	public bool SendAllDataToAuthorizedLooter(global::uLink.NetworkPlayer target, bool reportCheater = false)
	{
		if (this.IsAnAuthorizedLooter(target, reportCheater, "loot_ua"))
		{
			this.SendAllDataToClient(target);
			return true;
		}
		return false;
	}

	// Token: 0x060032E3 RID: 13027 RVA: 0x000C2958 File Offset: 0x000C0B58
	private void SendAllDataToClient(global::uLink.NetworkPlayer target)
	{
		global::uLink.BitStream stream = new global::uLink.BitStream(false);
		this.GenerateInvBitStream(ref stream, false);
		global::NetCull.RPC<byte[]>(this, "GNUP", target, stream.GetDataByteArray());
	}

	// Token: 0x060032E4 RID: 13028 RVA: 0x000C2988 File Offset: 0x000C0B88
	private void GenerateInvBitStream_Header(ref global::uLink.BitStream invdata)
	{
		invdata.WriteByte((byte)this.collection.Capacity);
	}

	// Token: 0x060032E5 RID: 13029 RVA: 0x000C29A0 File Offset: 0x000C0BA0
	private void GenerateInvBitStream_Full(ref global::uLink.BitStream invdata)
	{
		this.GenerateInvBitStream_Header(ref invdata);
		invdata.WriteBoolean(true);
		global::Inventory.Collection<global::InventoryItem> collection = this.collection;
		for (int i = 0; i < collection.Capacity; i++)
		{
			global::InventoryItem inventoryItem;
			bool flag = collection.Get(i, out inventoryItem);
			invdata.WriteBoolean(flag);
			if (flag)
			{
				invdata.Write<int>(inventoryItem.datablockUniqueID, new object[0]);
				inventoryItem.Serialize(invdata);
			}
		}
	}

	// Token: 0x060032E6 RID: 13030 RVA: 0x000C2A10 File Offset: 0x000C0C10
	private void GenerateInvBitStream_Dirty(ref global::uLink.BitStream invdata, bool andClean)
	{
		this.GenerateInvBitStream_Header(ref invdata);
		invdata.WriteBoolean(false);
		global::Inventory.Collection<global::InventoryItem> collection = this.collection;
		global::Inventory.Mask mask;
		int num;
		if (!collection.Clean(out mask, out num, !andClean))
		{
			invdata.WriteByte(0);
		}
		else
		{
			int num2 = mask.CountOnBits();
			if (num2 != num)
			{
				num = num2;
			}
			invdata.WriteByte((byte)num);
			for (int i = 0; i < 0x100; i++)
			{
				if (mask[i])
				{
					global::InventoryItem inventoryItem;
					bool flag = collection.Get(i, out inventoryItem);
					invdata.WriteBoolean(flag);
					invdata.WriteByte((byte)i);
					if (flag)
					{
						invdata.Write<int>(inventoryItem.datablockUniqueID, new object[0]);
						inventoryItem.Serialize(invdata);
					}
					if (--num == 0)
					{
						break;
					}
				}
			}
		}
	}

	// Token: 0x060032E7 RID: 13031 RVA: 0x000C2AE8 File Offset: 0x000C0CE8
	public void GenerateInvBitStream(ref global::uLink.BitStream invdata, bool checkAndClearDirty)
	{
		if (checkAndClearDirty)
		{
			this.GenerateInvBitStream_Dirty(ref invdata, true);
		}
		else
		{
			this.GenerateInvBitStream_Full(ref invdata);
		}
	}

	// Token: 0x060032E8 RID: 13032 RVA: 0x000C2B04 File Offset: 0x000C0D04
	public bool AddNetListener(global::uLink.NetworkPlayer ply)
	{
		if (ply.isServer || !ply.isConnected)
		{
			return false;
		}
		if (!this._anyNetListeners)
		{
			this._netListeners = new global::System.Collections.Generic.HashSet<global::uLink.NetworkPlayer>();
			if (!this._netListeners.Add(ply))
			{
				this._netListeners = null;
				return false;
			}
			this._anyNetListeners = true;
			this.OnNetListenersExist();
			this.OnNetListenerAdded(ply);
			return true;
		}
		else
		{
			if (this._netListeners.Add(ply))
			{
				this.OnNetListenerAdded(ply);
				return true;
			}
			return false;
		}
	}

	// Token: 0x060032E9 RID: 13033 RVA: 0x000C2B8C File Offset: 0x000C0D8C
	private void OnNetListenersExist()
	{
		base.InvokeRepeating("UpdateToNetListeners", 0.5f, 0.5f);
	}

	// Token: 0x060032EA RID: 13034 RVA: 0x000C2BA4 File Offset: 0x000C0DA4
	private void OnNetListenerAdded(global::uLink.NetworkPlayer ply)
	{
		this.SendAllDataToClient(ply);
	}

	// Token: 0x060032EB RID: 13035 RVA: 0x000C2BB0 File Offset: 0x000C0DB0
	protected void UpdateToNetListeners()
	{
		this.lastUpdateToNetListenersSent = this.SendUpdateToNetListeners();
	}

	// Token: 0x060032EC RID: 13036 RVA: 0x000C2BC0 File Offset: 0x000C0DC0
	private bool SendUpdateToNetListeners()
	{
		if (!this.collection.MarkedDirty)
		{
			return false;
		}
		global::uLink.BitStream stream = new global::uLink.BitStream(false);
		this.GenerateInvBitStream(ref stream, true);
		global::NetCull.RPC<byte[]>(this, "GNUP", this._netListeners, stream.GetDataByteArray());
		return true;
	}

	// Token: 0x060032ED RID: 13037 RVA: 0x000C2C08 File Offset: 0x000C0E08
	protected void RestartNetListeners()
	{
		if (this._anyNetListeners)
		{
			base.CancelInvoke("UpdateToNetListeners");
			base.InvokeRepeating("UpdateToNetListeners", 0f, 0.5f);
		}
	}

	// Token: 0x060032EE RID: 13038 RVA: 0x000C2C38 File Offset: 0x000C0E38
	public void Invalidate()
	{
		this.RestartNetListeners();
	}

	// Token: 0x060032EF RID: 13039 RVA: 0x000C2C40 File Offset: 0x000C0E40
	public bool RemoveNetListener(global::uLink.NetworkPlayer ply)
	{
		if (!this._anyNetListeners || !this._netListeners.Remove(ply))
		{
			return false;
		}
		this.OnNetListenerRemoved(ply);
		if (this._netListeners.Count == 0)
		{
			this._anyNetListeners = false;
			this._netListeners = null;
			this.OnNetListenersRemoved();
		}
		return true;
	}

	// Token: 0x060032F0 RID: 13040 RVA: 0x000C2C98 File Offset: 0x000C0E98
	private void OnNetListenerRemoved(global::uLink.NetworkPlayer ply)
	{
	}

	// Token: 0x060032F1 RID: 13041 RVA: 0x000C2C9C File Offset: 0x000C0E9C
	private void OnNetListenersRemoved()
	{
		base.CancelInvoke("UpdateToNetListeners");
		this.lastUpdateToNetListenersSent = false;
	}

	// Token: 0x060032F2 RID: 13042 RVA: 0x000C2CB0 File Offset: 0x000C0EB0
	private void OnNetSlotUpdate(global::Inventory.Collection<global::InventoryItem> _collection, int slot, bool occupied, global::uLink.BitStream invdata)
	{
		if (occupied)
		{
			int num = invdata.ReadInt32();
			global::InventoryItem inventoryItem;
			bool flag = _collection.Get(slot, out inventoryItem);
			if (flag && inventoryItem.datablockUniqueID != num)
			{
				this.DeleteItem(slot);
				flag = false;
				inventoryItem = null;
			}
			if (!flag)
			{
				global::Inventory.Addition addition = default(global::Inventory.Addition);
				global::Inventory.Addition addition2 = addition;
				addition2.UniqueID = num;
				addition2.UsesQuantity = global::Inventory.Uses.Quantity.Maximum;
				addition2.SlotPreference = global::Inventory.Slot.Preference.Define(slot, false);
				addition = addition2;
				inventoryItem = (this.AddItem(ref addition, global::Inventory.Payload.Opt.DoNotStack | global::Inventory.Payload.Opt.RestrictToOffset, null) as global::InventoryItem);
			}
			inventoryItem.Deserialize(invdata);
			if (flag)
			{
				_collection.MarkDirty(slot);
			}
		}
		else
		{
			this.DeleteItem(slot);
		}
	}

	// Token: 0x060032F3 RID: 13043 RVA: 0x000C2D5C File Offset: 0x000C0F5C
	protected void OnNetUpdate(global::uLink.BitStream invdata)
	{
		int num = (int)invdata.ReadByte();
		global::Inventory.Collection<global::InventoryItem> collection_;
		if (this._collection_made_)
		{
			collection_ = this._collection_;
		}
		else
		{
			this.Initialize(num);
			collection_ = this._collection_;
		}
		int capacity = collection_.Capacity;
		if (num != capacity)
		{
			this.Initialize(num);
		}
		bool flag = invdata.ReadBoolean();
		if (flag)
		{
			int num2 = num;
			for (int i = 0; i < num2; i++)
			{
				bool occupied = invdata.ReadBoolean();
				this.OnNetSlotUpdate(collection_, i, occupied, invdata);
			}
		}
		else
		{
			int num2 = (int)invdata.ReadByte();
			int num3 = 0;
			try
			{
				for (int j = 0; j < num2; j++)
				{
					num3++;
					bool occupied2 = invdata.ReadBoolean();
					int slot = (int)invdata.ReadByte();
					this.OnNetSlotUpdate(collection_, slot, occupied2, invdata);
				}
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex, this);
				global::UnityEngine.Debug.Log(string.Format("numItemsInUpdate = {0}, iterated pos = {1}", num2, num3), this);
			}
		}
	}

	// Token: 0x17000A99 RID: 2713
	// (get) Token: 0x060032F4 RID: 13044 RVA: 0x000C2E7C File Offset: 0x000C107C
	private global::Inventory.Collection<global::InventoryItem> collection
	{
		get
		{
			if (!this._collection_made_)
			{
				return global::Inventory.Collection<global::InventoryItem>.Default.Empty;
			}
			return this._collection_;
		}
	}

	// Token: 0x060032F5 RID: 13045 RVA: 0x000C2E98 File Offset: 0x000C1098
	private global::Inventory.Payload.Result AssignItem(ref global::Inventory.Addition addition, global::Inventory.Payload.Opt flags, global::InventoryItem reuse)
	{
		return global::Inventory.Payload.AddItem(this, ref addition, flags, reuse);
	}

	// Token: 0x060032F6 RID: 13046 RVA: 0x000C2EB0 File Offset: 0x000C10B0
	private static global::IInventoryItem ResultToItem(ref global::Inventory.Payload.Result result, global::Inventory.Payload.Opt flags)
	{
		if ((byte)(result.flags & global::Inventory.Payload.Result.Flags.AssignedInstance) == 0x40)
		{
			return result.item.iface;
		}
		if ((byte)(flags & global::Inventory.Payload.Opt.AllowStackedItemsToBeReturned) != 0x20)
		{
			return null;
		}
		if ((byte)(result.flags & global::Inventory.Payload.Result.Flags.Stacked) == 0x20)
		{
			return result.item.iface;
		}
		return null;
	}

	// Token: 0x060032F7 RID: 13047 RVA: 0x000C2F08 File Offset: 0x000C1108
	private global::IInventoryItem AddItem(ref global::Inventory.Addition addition, global::Inventory.Payload.Opt flags, global::InventoryItem reuse)
	{
		global::Inventory.Payload.Result result = this.AssignItem(ref addition, flags, reuse);
		return global::Inventory.ResultToItem(ref result, flags);
	}

	// Token: 0x060032F8 RID: 13048 RVA: 0x000C2F28 File Offset: 0x000C1128
	private global::Inventory.AddExistingItemResult AddExistingItem(global::IInventoryItem iitem, bool forbidStacking, bool mustBeUnassigned)
	{
		global::InventoryItem inventoryItem = iitem as global::InventoryItem;
		if (object.ReferenceEquals(inventoryItem, null) || (mustBeUnassigned && inventoryItem.inventory))
		{
			return global::Inventory.AddExistingItemResult.BadItemArgument;
		}
		global::ItemDataBlock datablock = inventoryItem.datablock;
		global::Inventory.Addition addition = default(global::Inventory.Addition);
		global::Inventory.Addition addition2 = addition;
		addition2.ItemDataBlock = datablock;
		addition2.UsesQuantity = inventoryItem.uses;
		addition2.SlotPreference = global::Inventory.Slot.Preference.Define(global::Inventory.Slot.Kind.Default, !forbidStacking && datablock.IsSplittable(), global::Inventory.Slot.Kind.Belt);
		addition = addition2;
		global::Inventory.Payload.Opt opt = global::Inventory.Payload.Opt.IgnoreSlotOffset | global::Inventory.Payload.Opt.ReuseItem;
		if (forbidStacking)
		{
			opt |= global::Inventory.Payload.Opt.DoNotStack;
		}
		global::Inventory.Payload.Result result = this.AssignItem(ref addition, opt, inventoryItem);
		if ((byte)(result.flags & global::Inventory.Payload.Result.Flags.Complete) == 0x80)
		{
			if ((byte)(result.flags & global::Inventory.Payload.Result.Flags.AssignedInstance) == 0x40)
			{
				return global::Inventory.AddExistingItemResult.Moved;
			}
			if ((byte)(result.flags & global::Inventory.Payload.Result.Flags.Stacked) == 0x20)
			{
				inventoryItem.SetUses(0);
				return global::Inventory.AddExistingItemResult.CompletlyStacked;
			}
			global::UnityEngine.Debug.LogWarning("unhandled", this);
			return global::Inventory.AddExistingItemResult.Failed;
		}
		else
		{
			if ((byte)(result.flags & global::Inventory.Payload.Result.Flags.Stacked) == 0x20)
			{
				inventoryItem.SetUses(result.usesRemaining);
				return global::Inventory.AddExistingItemResult.PartiallyStacked;
			}
			return global::Inventory.AddExistingItemResult.Failed;
		}
	}

	// Token: 0x060032F9 RID: 13049 RVA: 0x000C303C File Offset: 0x000C123C
	private static global::Inventory.Slot.Preference DefaultAddMultipleItemsSlotPreference(bool stack)
	{
		return global::Inventory.Slot.Preference.Define(global::Inventory.Slot.Kind.Default, stack, global::Inventory.Slot.KindFlags.Belt);
	}

	// Token: 0x060032FA RID: 13050 RVA: 0x000C3048 File Offset: 0x000C1248
	private int AddMultipleItems(global::ItemDataBlock itemDB, int usesOrItemCountWhenNotSplittable, global::Inventory.Uses.Quantity nonSplittableUses, global::Inventory.AddMultipleItemFlags amif, global::Inventory.Slot.Preference? slotPreference)
	{
		global::Inventory.Addition addition = default(global::Inventory.Addition);
		global::Inventory.Addition addition2 = addition;
		addition2.ItemDataBlock = itemDB;
		addition = addition2;
		bool flag = itemDB.IsSplittable();
		if (((amif & (global::Inventory.AddMultipleItemFlags.MustBeSplittable | global::Inventory.AddMultipleItemFlags.MustBeNonSplittable)) | ((!flag) ? global::Inventory.AddMultipleItemFlags.MustBeNonSplittable : global::Inventory.AddMultipleItemFlags.MustBeSplittable)) == (global::Inventory.AddMultipleItemFlags.MustBeSplittable | global::Inventory.AddMultipleItemFlags.MustBeNonSplittable))
		{
			return usesOrItemCountWhenNotSplittable;
		}
		if (!flag)
		{
			addition.UsesQuantity = nonSplittableUses;
			addition.SlotPreference = ((slotPreference == null) ? global::Inventory.Slot.Preference.Define(global::Inventory.Slot.Kind.Default, false, global::Inventory.Slot.Kind.Belt) : slotPreference.Value.CloneStackChange(false));
			while (usesOrItemCountWhenNotSplittable > 0 && (byte)(this.AssignItem(ref addition, global::Inventory.Payload.Opt.DoNotStack | global::Inventory.Payload.Opt.IgnoreSlotOffset, null).flags & global::Inventory.Payload.Result.Flags.Complete) == 0x80)
			{
				usesOrItemCountWhenNotSplittable--;
			}
			return usesOrItemCountWhenNotSplittable;
		}
		if (usesOrItemCountWhenNotSplittable == 0)
		{
			return 0;
		}
		if ((amif & (global::Inventory.AddMultipleItemFlags.DoNotCreateNewSplittableStacks | global::Inventory.AddMultipleItemFlags.DoNotStackSplittables)) == (global::Inventory.AddMultipleItemFlags.DoNotCreateNewSplittableStacks | global::Inventory.AddMultipleItemFlags.DoNotStackSplittables))
		{
			return usesOrItemCountWhenNotSplittable;
		}
		int num = usesOrItemCountWhenNotSplittable / itemDB._maxUses;
		global::Inventory.Payload.Opt opt = global::Inventory.Payload.Opt.IgnoreSlotOffset;
		bool flag2;
		if ((amif & global::Inventory.AddMultipleItemFlags.DoNotStackSplittables) == global::Inventory.AddMultipleItemFlags.DoNotStackSplittables)
		{
			flag2 = true;
			opt |= global::Inventory.Payload.Opt.DoNotStack;
			if (slotPreference != null)
			{
				addition.SlotPreference = slotPreference.Value.CloneStackChange(false);
			}
			else
			{
				addition.SlotPreference = global::Inventory.DefaultAddMultipleItemsSlotPreference(false);
			}
		}
		else
		{
			flag2 = false;
			if (slotPreference != null)
			{
				addition.SlotPreference = slotPreference.Value;
			}
			else
			{
				addition.SlotPreference = global::Inventory.DefaultAddMultipleItemsSlotPreference(true);
			}
		}
		if ((amif & global::Inventory.AddMultipleItemFlags.DoNotCreateNewSplittableStacks) == global::Inventory.AddMultipleItemFlags.DoNotCreateNewSplittableStacks)
		{
			opt |= global::Inventory.Payload.Opt.DoNotAssign;
		}
		int num2 = 0;
		if (num > 0)
		{
			addition.UsesQuantity = itemDB._maxUses;
			global::Inventory.Payload.Result result;
			for (;;)
			{
				result = this.AssignItem(ref addition, opt, null);
				if ((byte)(result.flags & global::Inventory.Payload.Result.Flags.Complete) != 0x80)
				{
					break;
				}
				num2 += itemDB._maxUses;
				if (!flag2 && (byte)(result.flags & global::Inventory.Payload.Result.Flags.AssignedInstance) == 0x40)
				{
					opt |= global::Inventory.Payload.Opt.DoNotStack;
					flag2 = true;
				}
				if (--num <= 0)
				{
					goto IL_18F;
				}
			}
			if ((byte)(result.flags & global::Inventory.Payload.Result.Flags.Stacked) == 0x20)
			{
				num2 += itemDB._maxUses - result.usesRemaining;
			}
			return usesOrItemCountWhenNotSplittable - num2;
		}
		IL_18F:
		if (num2 == usesOrItemCountWhenNotSplittable)
		{
			return 0;
		}
		int num3 = usesOrItemCountWhenNotSplittable - num2;
		addition.UsesQuantity = num3;
		global::Inventory.Payload.Result result2 = this.AssignItem(ref addition, opt, null);
		if ((byte)(result2.flags & (global::Inventory.Payload.Result.Flags.Complete | global::Inventory.Payload.Result.Flags.Stacked)) != 0)
		{
			num2 += num3 - result2.usesRemaining;
		}
		return usesOrItemCountWhenNotSplittable - num2;
	}

	// Token: 0x060032FB RID: 13051 RVA: 0x000C32A4 File Offset: 0x000C14A4
	private int AddItemAmount(global::ItemDataBlock datablock, int amount, global::Inventory.AmountMode mode, global::Inventory.Uses.Quantity? perNonSplittableItemQuantity, global::Inventory.Slot.Preference? slotPref)
	{
		if (!datablock)
		{
			return amount;
		}
		global::Inventory.AddMultipleItemFlags addMultipleItemFlags;
		global::Inventory.Uses.Quantity nonSplittableUses;
		if (datablock.IsSplittable())
		{
			addMultipleItemFlags = global::Inventory.AddMultipleItemFlags.MustBeSplittable;
			switch (mode)
			{
			case global::Inventory.AmountMode.OnlyStack:
				addMultipleItemFlags |= global::Inventory.AddMultipleItemFlags.DoNotCreateNewSplittableStacks;
				break;
			case global::Inventory.AmountMode.OnlyCreateNew:
				addMultipleItemFlags |= global::Inventory.AddMultipleItemFlags.DoNotStackSplittables;
				break;
			case global::Inventory.AmountMode.IgnoreSplittables:
				return amount;
			}
			nonSplittableUses = default(global::Inventory.Uses.Quantity);
		}
		else
		{
			if (mode == global::Inventory.AmountMode.OnlyStack)
			{
				return amount;
			}
			addMultipleItemFlags = global::Inventory.AddMultipleItemFlags.MustBeNonSplittable;
			nonSplittableUses = ((perNonSplittableItemQuantity == null) ? global::Inventory.Uses.Quantity.Random : perNonSplittableItemQuantity.Value);
		}
		return this.AddMultipleItems(datablock, amount, nonSplittableUses, addMultipleItemFlags, slotPref);
	}

	// Token: 0x060032FC RID: 13052 RVA: 0x000C3348 File Offset: 0x000C1548
	private global::IInventoryItem AddItemSomehowWork(global::ItemDataBlock item, global::Inventory.Slot.Kind? slotKindPref, int slotOffset, int usesCount)
	{
		global::Inventory.Slot.Kind value;
		int num;
		bool flag;
		bool flag2;
		if (slotKindPref != null)
		{
			value = slotKindPref.Value;
			flag = this.GetSlotForKind(value, slotOffset, out num);
			flag2 = (flag || this.HasSlotsOfKind(value));
		}
		else
		{
			num = slotOffset;
			flag = (flag2 = this.GetSlotKind(num, out value, out slotOffset));
		}
		global::Inventory.Addition addition;
		addition.Ident = (global::Datablock.Ident)item;
		addition.UsesQuantity = usesCount;
		if (flag2)
		{
			if (flag)
			{
				addition.SlotPreference = global::Inventory.Slot.Preference.Define(value, slotOffset);
				global::Inventory.Payload.Result result = this.AssignItem(ref addition, global::Inventory.Payload.Opt.RestrictToOffset, null);
				if ((byte)(result.flags & global::Inventory.Payload.Result.Flags.Complete) == 0x80)
				{
					return global::Inventory.ResultToItem(ref result, global::Inventory.Payload.Opt.RestrictToOffset);
				}
				if ((byte)(result.flags & global::Inventory.Payload.Result.Flags.Stacked) == 0x20)
				{
					addition.UsesQuantity = (usesCount = result.usesRemaining);
				}
			}
			addition.SlotPreference = value;
			global::Inventory.Payload.Result result2 = this.AssignItem(ref addition, (global::Inventory.Payload.Opt)0, null);
			if ((byte)(result2.flags & global::Inventory.Payload.Result.Flags.Complete) == 0x80)
			{
				return global::Inventory.ResultToItem(ref result2, (global::Inventory.Payload.Opt)0);
			}
			if ((byte)(result2.flags & global::Inventory.Payload.Result.Flags.Stacked) == 0x20)
			{
				addition.UsesQuantity = (usesCount = result2.usesRemaining);
			}
		}
		else if (num >= 0 && num < this.slotCount)
		{
			addition.SlotPreference = global::Inventory.Slot.Preference.Define(num);
			global::Inventory.Payload.Result result3 = this.AssignItem(ref addition, global::Inventory.Payload.Opt.RestrictToOffset, null);
			if ((byte)(result3.flags & global::Inventory.Payload.Result.Flags.Complete) == 0x80)
			{
				return global::Inventory.ResultToItem(ref result3, global::Inventory.Payload.Opt.RestrictToOffset);
			}
			if ((byte)(result3.flags & global::Inventory.Payload.Result.Flags.Stacked) == 0x20)
			{
				addition.UsesQuantity = (usesCount = result3.usesRemaining);
			}
		}
		global::Inventory.Slot.KindFlags kindFlags = global::Inventory.Slot.KindFlags.Default | global::Inventory.Slot.KindFlags.Belt | global::Inventory.Slot.KindFlags.Armor;
		if (flag2)
		{
			kindFlags &= ~(global::Inventory.Slot.KindFlags)(1 << (int)value);
		}
		addition.SlotPreference = global::Inventory.Slot.Preference.Define(kindFlags);
		return this.AddItem(ref addition);
	}

	// Token: 0x060032FD RID: 13053 RVA: 0x000C3530 File Offset: 0x000C1730
	private bool RemoveItem(int slot, global::InventoryItem match, bool mustMatch)
	{
		global::Inventory.Collection<global::InventoryItem> collection = this.collection;
		global::InventoryItem inventoryItem;
		if ((!mustMatch || (collection.Get(slot, out inventoryItem) && object.ReferenceEquals(inventoryItem, match))) && collection.Evict(slot, out inventoryItem))
		{
			if (inventoryItem == this._activeItem)
			{
				this.DeactivateItem();
			}
			this.ItemRemoved(slot, inventoryItem.iface);
			this.MarkSlotDirty(slot);
			return true;
		}
		return false;
	}

	// Token: 0x060032FE RID: 13054 RVA: 0x000C359C File Offset: 0x000C179C
	private void DeleteItem(int slot)
	{
		this.RemoveItem(slot);
	}

	// Token: 0x060032FF RID: 13055 RVA: 0x000C35A8 File Offset: 0x000C17A8
	public bool NetworkItemAction(int slot, global::InventoryItem.MenuItem option)
	{
		global::Facepunch.NetworkView networkView = base.networkView;
		if (!networkView)
		{
			return false;
		}
		if (networkView.isMine)
		{
			return false;
		}
		networkView.RPC("IACT", 3, new object[]
		{
			(byte)slot,
			(byte)option
		});
		return true;
	}

	// Token: 0x06003300 RID: 13056 RVA: 0x000C35FC File Offset: 0x000C17FC
	public bool FireClientSideEvent(global::InventoryItem.ItemEvent itemEvent, global::ItemDataBlock datablock)
	{
		global::Facepunch.NetworkView networkView = base.networkView;
		if (networkView && !networkView.isMine)
		{
			networkView.RPC("CLEV", 3, new object[]
			{
				(byte)itemEvent,
				datablock.uniqueID
			});
			return true;
		}
		return false;
	}

	// Token: 0x06003301 RID: 13057 RVA: 0x000C3654 File Offset: 0x000C1854
	[global::UnityEngine.RPC]
	protected void GNUP(byte[] data, global::uLink.NetworkMessageInfo info)
	{
		if (!global::inv.clientupdates)
		{
			global::uLink.NetworkPlayer sender = info.sender;
			if (sender.isClient)
			{
				global::NetUser netUser = global::NetUser.Find(info.sender);
				if (netUser != null)
				{
					global::FeedbackLog.Start(global::FeedbackLog.TYPE.SimpleExploit);
					global::FeedbackLog.Writer.Write("sentinvdata");
					global::FeedbackLog.Writer.Write(netUser.userID);
					global::FeedbackLog.End(global::FeedbackLog.TYPE.SimpleExploit);
				}
				return;
			}
		}
		this.OnNetUpdate(new global::uLink.BitStream(data, false));
	}

	// Token: 0x06003302 RID: 13058 RVA: 0x000C36CC File Offset: 0x000C18CC
	[global::UnityEngine.RPC]
	protected void ITMV(global::NetEntityID toInvID, byte fromSlot, byte toSlot, global::uLink.NetworkMessageInfo info)
	{
		global::Inventory component = toInvID.GetComponent<global::Inventory>();
		global::Inventory.SlotOperationResult slotOperationResult = this.SlotOperation((int)fromSlot, component, (int)toSlot, global::Inventory.SlotOperationsMove(info.sender));
		if ((int)slotOperationResult <= 0)
		{
			global::UnityEngine.Debug.LogWarning(slotOperationResult);
		}
	}

	// Token: 0x06003303 RID: 13059 RVA: 0x000C370C File Offset: 0x000C190C
	[global::UnityEngine.RPC]
	protected void ISMV(byte fromSlot, byte toSlot, global::uLink.NetworkMessageInfo info)
	{
		global::Inventory.SlotOperationResult slotOperationResult = this.SlotOperation((int)fromSlot, (int)toSlot, global::Inventory.SlotOperationsMove(info.sender));
		if ((int)slotOperationResult <= 0)
		{
			global::UnityEngine.Debug.LogWarning(slotOperationResult);
		}
	}

	// Token: 0x06003304 RID: 13060 RVA: 0x000C3740 File Offset: 0x000C1940
	[global::NGCRPCSkip]
	[global::UnityEngine.RPC]
	protected void IACT(byte itemIndex, byte action, global::uLink.NetworkMessageInfo info)
	{
		global::InventoryItem inventoryItem;
		if (info.sender == base.networkView.owner && this.collection.Get((int)itemIndex, out inventoryItem))
		{
			inventoryItem.OnMenuOption((global::InventoryItem.MenuItem)action);
		}
	}

	// Token: 0x06003305 RID: 13061 RVA: 0x000C3784 File Offset: 0x000C1984
	private bool CheckSenderIsNonOwningClient(global::uLink.NetworkPlayer sender)
	{
		if (sender.isClient && sender != base.networkView.owner)
		{
			global::UnityEngine.Debug.LogWarning("Not owner!");
			return true;
		}
		return false;
	}

	// Token: 0x06003306 RID: 13062 RVA: 0x000C37C0 File Offset: 0x000C19C0
	[global::NGCRPCSkip]
	[global::UnityEngine.RPC]
	protected void IAST(byte itemIndex, global::uLink.NetworkViewID itemRepID, global::uLink.NetworkMessageInfo info)
	{
		if (this.CheckSenderIsNonOwningClient(info.sender))
		{
			return;
		}
		this.SetActiveItemManually((int)itemIndex, (!(itemRepID != global::uLink.NetworkViewID.unassigned)) ? null : global::uLink.NetworkView.Find(itemRepID).GetComponent<global::ItemRepresentation>(), new global::uLink.NetworkViewID?(itemRepID));
	}

	// Token: 0x06003307 RID: 13063 RVA: 0x000C3810 File Offset: 0x000C1A10
	[global::NGCRPCSkip]
	[global::UnityEngine.RPC]
	protected void ITDE(global::uLink.NetworkMessageInfo info)
	{
		if (this.CheckSenderIsNonOwningClient(info.sender))
		{
			return;
		}
		this.DeactivateItem();
	}

	// Token: 0x06003308 RID: 13064 RVA: 0x000C382C File Offset: 0x000C1A2C
	[global::UnityEngine.RPC]
	protected void CFAR(global::uLink.BitStream stream)
	{
		global::UnityEngine.Debug.LogWarning("Didnt plan on this running on server.", this);
		global::ArmorModelMemberMap<global::ArmorDataBlock> armorDatablockMap = default(global::ArmorModelMemberMap<global::ArmorDataBlock>);
		for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
		{
			armorDatablockMap[armorModelSlot] = (global::DatablockDictionary.GetByUniqueID(stream.ReadInt32()) as global::ArmorDataBlock);
		}
		this.BindArmorModelsFromArmorDatablockMap(armorDatablockMap);
	}

	// Token: 0x06003309 RID: 13065 RVA: 0x000C3880 File Offset: 0x000C1A80
	[global::UnityEngine.RPC]
	protected void SVUF(global::uLink.NetworkMessageInfo info)
	{
		global::uLink.NetworkPlayer sender = info.sender;
		if (!this.IsAnAuthorizedLooter(sender, true, "reqinvfullupdate"))
		{
			return;
		}
		this.SendAllDataToClient(sender);
	}

	// Token: 0x0600330A RID: 13066 RVA: 0x000C38B0 File Offset: 0x000C1AB0
	[global::UnityEngine.RPC]
	protected void ITMG(global::NetEntityID toInvID, byte fromSlot, byte toSlot, bool tryCombine, global::uLink.NetworkMessageInfo info)
	{
		global::Inventory component = toInvID.GetComponent<global::Inventory>();
		global::Inventory.SlotOperationResult slotOperationResult = this.SlotOperation((int)fromSlot, component, (int)toSlot, global::Inventory.SlotOperationsMerge(tryCombine, info.sender));
		if ((int)slotOperationResult <= 0)
		{
			global::UnityEngine.Debug.LogWarning(slotOperationResult);
		}
	}

	// Token: 0x0600330B RID: 13067 RVA: 0x000C38F0 File Offset: 0x000C1AF0
	[global::UnityEngine.RPC]
	protected void ITSM(byte fromSlot, byte toSlot, bool tryCombine, global::uLink.NetworkMessageInfo info)
	{
		global::Inventory.SlotOperationResult slotOperationResult = this.SlotOperation((int)fromSlot, (int)toSlot, global::Inventory.SlotOperationsMerge(tryCombine, info.sender));
		if ((int)slotOperationResult <= 0)
		{
			global::UnityEngine.Debug.LogWarning(slotOperationResult);
		}
	}

	// Token: 0x0600330C RID: 13068 RVA: 0x000C3928 File Offset: 0x000C1B28
	public bool SplitStack(int slotNumber)
	{
		global::InventoryItem inventoryItem;
		if (this.GetItem(slotNumber, out inventoryItem))
		{
			int num = inventoryItem.uses;
			if (num > 1 && this.anyVacantSlots && inventoryItem.datablock.IsSplittable())
			{
				int num2 = num / 2;
				int num3 = num2 - this.AddItemAmount(inventoryItem.datablock, num2, global::Inventory.AmountMode.OnlyCreateNew);
				if (num3 > 0)
				{
					num -= num3;
					inventoryItem.SetUses(num);
					this.MarkSlotDirty(inventoryItem.slot);
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600330D RID: 13069 RVA: 0x000C39A4 File Offset: 0x000C1BA4
	[global::UnityEngine.RPC]
	protected void ITSP(byte slotNumber, global::uLink.NetworkMessageInfo info)
	{
		if (!this.IsAnAuthorizedLooter(info.sender))
		{
			global::UnityEngine.Debug.LogWarning("invalid split", this);
		}
		else
		{
			this.SplitStack((int)slotNumber);
		}
	}

	// Token: 0x0600330E RID: 13070 RVA: 0x000C39D0 File Offset: 0x000C1BD0
	[global::UnityEngine.RPC]
	protected void CLEV(byte itemEvent, int uniqueID)
	{
	}

	// Token: 0x0600330F RID: 13071 RVA: 0x000C39D4 File Offset: 0x000C1BD4
	[global::UnityEngine.RPC]
	protected void SVUC(byte cell, global::uLink.NetworkMessageInfo info)
	{
		if (this.IsAnAuthorizedLooter(info.sender, true, "reqinvcellupdate"))
		{
			this.MarkSlotDirty((int)cell);
		}
	}

	// Token: 0x06003310 RID: 13072 RVA: 0x000C39F8 File Offset: 0x000C1BF8
	protected global::IInventoryItem LoadItem(ref global::RustProto.Item item)
	{
		return this.LoadItem(ref item, 0, false);
	}

	// Token: 0x06003311 RID: 13073 RVA: 0x000C3A04 File Offset: 0x000C1C04
	protected global::IInventoryItem LoadItem(ref global::RustProto.Item item, int iOffset)
	{
		return this.LoadItem(ref item, iOffset, false);
	}

	// Token: 0x06003312 RID: 13074 RVA: 0x000C3A10 File Offset: 0x000C1C10
	protected global::IInventoryItem LoadItem(ref global::RustProto.Item item, int iOffset, bool ignoreSavedSlot)
	{
		if (!item.HasId || (!ignoreSavedSlot && !item.HasSlot))
		{
			return null;
		}
		int num;
		if (ignoreSavedSlot)
		{
			num = this.collection.FirstVacancy;
			if (num == -1)
			{
				return null;
			}
		}
		else
		{
			num = item.Slot;
			if (iOffset != 0)
			{
				num += iOffset;
			}
		}
		int id = item.Id;
		global::ItemDataBlock byUniqueID;
		try
		{
			byUniqueID = global::DatablockDictionary.GetByUniqueID(id);
		}
		catch (global::System.InvalidCastException)
		{
			return null;
		}
		if (!byUniqueID)
		{
			return null;
		}
		global::Inventory.Addition addition = default(global::Inventory.Addition);
		global::Inventory.Addition addition2 = addition;
		addition2.ItemDataBlock = byUniqueID;
		addition2.SlotPreference = global::Inventory.Slot.Preference.Define(num, false);
		addition2.UsesQuantity = ((!item.HasCount) ? global::Inventory.Uses.Quantity.Maximum : global::Inventory.Uses.Quantity.Manual(item.Count));
		addition = addition2;
		global::Inventory.Payload.Result result = this.AssignItem(ref addition, global::Inventory.Payload.Opt.DoNotStack | global::Inventory.Payload.Opt.RestrictToOffset, null);
		if ((byte)(result.flags & global::Inventory.Payload.Result.Flags.Complete) != 0x80)
		{
			return null;
		}
		if (!result.item.iface.Load(ref item))
		{
			this.RemoveItem(num);
			return null;
		}
		return result.item.iface;
	}

	// Token: 0x06003313 RID: 13075 RVA: 0x000C3B60 File Offset: 0x000C1D60
	public global::IInventoryItem LoadItemIntoVacantSlot(ref global::RustProto.Item item)
	{
		return this.LoadItem(ref item, 0, true);
	}

	// Token: 0x06003314 RID: 13076 RVA: 0x000C3B6C File Offset: 0x000C1D6C
	protected bool SaveItem(global::InventoryItem invitem, int slot, ref global::RustProto.Item.Builder item)
	{
		item.SetSlot(slot);
		item.SetId(invitem.datablockUniqueID);
		return invitem.iface.Save(ref item);
	}

	// Token: 0x06003315 RID: 13077 RVA: 0x000C3B94 File Offset: 0x000C1D94
	public void WriteObjectSave(ref global::RustProto.SavedObject.Builder saveobj)
	{
		global::RustProto.Item.Builder builder = null;
		bool flag = false;
		using (global::RustProto.Helpers.Recycler<global::RustProto.Item, global::RustProto.Item.Builder> recycler = global::RustProto.Item.Recycler())
		{
			using (global::Inventory.Collection<global::InventoryItem>.OccupiedCollection.Enumerator occupiedEnumerator = this.collection.OccupiedEnumerator)
			{
				while (occupiedEnumerator.MoveNext())
				{
					global::InventoryItem invitem = occupiedEnumerator.Current;
					if (flag)
					{
						builder.Clear();
					}
					else
					{
						builder = recycler.OpenBuilder();
						flag = true;
					}
					if (this.SaveItem(invitem, occupiedEnumerator.Slot, ref builder))
					{
						saveobj.AddInventory(builder);
					}
				}
			}
			if (flag)
			{
				recycler.CloseBuilder(ref builder);
			}
		}
	}

	// Token: 0x06003316 RID: 13078 RVA: 0x000C3C78 File Offset: 0x000C1E78
	public void ReadObjectSave(ref global::RustProto.SavedObject saveobj)
	{
		int i = 0;
		int inventoryCount = saveobj.InventoryCount;
		while (i < inventoryCount)
		{
			global::RustProto.Item inventory = saveobj.GetInventory(i);
			global::IInventoryItem inventoryItem = this.LoadItem(ref inventory);
			bool flag = object.ReferenceEquals(inventory, null);
			if (flag)
			{
				return;
			}
			i++;
		}
	}

	// Token: 0x06003317 RID: 13079 RVA: 0x000C3CC4 File Offset: 0x000C1EC4
	private global::Inventory.SlotOperationResult SlotOperation(int fromSlot, int toSlot, global::Inventory.SlotOperationsInfo info)
	{
		return this.SlotOperation(fromSlot, this, toSlot, info);
	}

	// Token: 0x06003318 RID: 13080 RVA: 0x000C3CD0 File Offset: 0x000C1ED0
	private global::Inventory.SlotOperationResult SlotOperation(int fromSlot, global::Inventory toInventory, int toSlot, global::Inventory.SlotOperationsInfo info)
	{
		if ((byte)((global::Inventory.SlotOperations)7 & info.SlotOperations) == 0)
		{
			return global::Inventory.SlotOperationResult.Error_NoOpArgs;
		}
		if (!this || !toInventory)
		{
			return global::Inventory.SlotOperationResult.Error_MissingInventory;
		}
		bool flag = this == toInventory;
		if (flag)
		{
			if (toSlot == fromSlot)
			{
				return global::Inventory.SlotOperationResult.Error_SameSlot;
			}
			if ((byte)(global::Inventory.SlotOperations.EnsureAuthenticLooter & info.SlotOperations) == 0x80 && !this.IsAnAuthorizedLooter(info.Looter, (byte)(global::Inventory.SlotOperations.ReportCheater & info.SlotOperations) == 0x40, "slotop_srcdst"))
			{
				return global::Inventory.SlotOperationResult.Error_NotALooter;
			}
		}
		else if ((byte)(global::Inventory.SlotOperations.EnsureAuthenticLooter & info.SlotOperations) == 0x80)
		{
			bool reportCheater = (byte)(global::Inventory.SlotOperations.ReportCheater & info.SlotOperations) == 0x40;
			if (!this.IsAnAuthorizedLooter(info.Looter, reportCheater, "slotop_src") || !toInventory.IsAnAuthorizedLooter(info.Looter, reportCheater, "slotop_dst"))
			{
				return global::Inventory.SlotOperationResult.Error_NotALooter;
			}
		}
		global::InventoryItem inventoryItem;
		if (!this.GetItem(fromSlot, out inventoryItem))
		{
			return global::Inventory.SlotOperationResult.Error_EmptySourceSlot;
		}
		global::InventoryItem inventoryItem2;
		if (toInventory.GetItem(toSlot, out inventoryItem2))
		{
			this.MarkSlotDirty(fromSlot);
			toInventory.MarkSlotDirty(toSlot);
			global::InventoryItem.MergeResult mergeResult;
			if ((byte)((global::Inventory.SlotOperations)3 & info.SlotOperations) == 1 && inventoryItem.datablockUniqueID == inventoryItem2.datablockUniqueID)
			{
				mergeResult = inventoryItem.iface.TryStack(inventoryItem2.iface);
			}
			else if ((byte)((global::Inventory.SlotOperations)3 & info.SlotOperations) != 0)
			{
				mergeResult = inventoryItem.iface.TryCombine(inventoryItem2.iface);
			}
			else
			{
				mergeResult = global::InventoryItem.MergeResult.Failed;
			}
			global::InventoryItem.MergeResult mergeResult2 = mergeResult;
			if (mergeResult2 == global::InventoryItem.MergeResult.Merged)
			{
				return global::Inventory.SlotOperationResult.Success_Stacked;
			}
			if (mergeResult2 == global::InventoryItem.MergeResult.Combined)
			{
				return global::Inventory.SlotOperationResult.Success_Combined;
			}
			if ((byte)(global::Inventory.SlotOperations.Move & info.SlotOperations) == 4)
			{
				return global::Inventory.SlotOperationResult.Error_OccupiedDestination;
			}
			return global::Inventory.SlotOperationResult.NoOp;
		}
		else
		{
			if ((byte)(global::Inventory.SlotOperations.Move & info.SlotOperations) == 0)
			{
				return global::Inventory.SlotOperationResult.Error_EmptyDestinationSlot;
			}
			if (this.MoveItemAtSlotToEmptySlot(toInventory, fromSlot, toSlot))
			{
				if (this)
				{
					this.MarkSlotDirty(fromSlot);
				}
				if (toInventory)
				{
					toInventory.MarkSlotDirty(toSlot);
				}
				return global::Inventory.SlotOperationResult.Success_Moved;
			}
			return global::Inventory.SlotOperationResult.Error_Failed;
		}
	}

	// Token: 0x06003319 RID: 13081 RVA: 0x000C3ED0 File Offset: 0x000C20D0
	private static global::Inventory.SlotOperations SlotOperationsMerge(bool tryCombine)
	{
		return tryCombine ? ((global::Inventory.SlotOperations)3) : global::Inventory.SlotOperations.Stack;
	}

	// Token: 0x0600331A RID: 13082 RVA: 0x000C3EE0 File Offset: 0x000C20E0
	private static global::Inventory.SlotOperationsInfo SlotOperationsMerge(bool tryCombine, global::uLink.NetworkPlayer looter)
	{
		return new global::Inventory.SlotOperationsInfo(global::Inventory.SlotOperations.EnsureAuthenticLooter | global::Inventory.SlotOperationsMerge(tryCombine), looter);
	}

	// Token: 0x0600331B RID: 13083 RVA: 0x000C3EF8 File Offset: 0x000C20F8
	private static global::Inventory.SlotOperationsInfo SlotOperationsMove(global::uLink.NetworkPlayer looter)
	{
		return new global::Inventory.SlotOperationsInfo((global::Inventory.SlotOperations)0x84, looter);
	}

	// Token: 0x0600331C RID: 13084 RVA: 0x000C3F08 File Offset: 0x000C2108
	protected virtual void ConfigureSlots(int totalCount, ref global::Inventory.Slot.KindDictionary<global::Inventory.Slot.Range> ranges, ref global::Inventory.SlotFlags[] flags)
	{
	}

	// Token: 0x0600331D RID: 13085 RVA: 0x000C3F0C File Offset: 0x000C210C
	protected virtual void ItemRemoved(int slot, global::IInventoryItem item)
	{
		global::FireBarrel local = base.GetLocal<global::FireBarrel>();
		if (local)
		{
			local.InvItemRemoved();
		}
	}

	// Token: 0x0600331E RID: 13086 RVA: 0x000C3F34 File Offset: 0x000C2134
	protected virtual void ItemAdded(int slot, global::IInventoryItem item)
	{
		global::FireBarrel local = base.GetLocal<global::FireBarrel>();
		if (local)
		{
			local.InvItemAdded();
		}
	}

	// Token: 0x0600331F RID: 13087 RVA: 0x000C3F5C File Offset: 0x000C215C
	protected virtual bool CheckSlotFlags(global::Inventory.SlotFlags itemSlotFlags, global::Inventory.SlotFlags slotFlags)
	{
		return true;
	}

	// Token: 0x06003320 RID: 13088 RVA: 0x000C3F60 File Offset: 0x000C2160
	protected virtual void DoSetActiveItem(global::InventoryItem item)
	{
		this._activeItem = item;
	}

	// Token: 0x06003321 RID: 13089 RVA: 0x000C3F6C File Offset: 0x000C216C
	protected virtual void DoDeactivateItem()
	{
		this._activeItem = null;
		global::Facepunch.NetworkView networkView = base.networkView;
		if (networkView && global::NetCheck.PlayerValid(networkView.owner))
		{
			networkView.RPC("ITDE", networkView.owner, new object[0]);
		}
	}

	// Token: 0x06003322 RID: 13090 RVA: 0x000C3FBC File Offset: 0x000C21BC
	protected virtual bool GetArmorDatablockMap(ref global::ArmorModelMemberMap<global::ArmorDataBlock> map)
	{
		return false;
	}

	// Token: 0x04001C26 RID: 7206
	private const float kNetworkListenersUpdateInterval = 0.5f;

	// Token: 0x04001C27 RID: 7207
	private const string UpdateToNetListenersMethodName = "UpdateToNetListeners";

	// Token: 0x04001C28 RID: 7208
	private const global::uLink.RPCMode ItemAction_RPCMode = 3;

	// Token: 0x04001C29 RID: 7209
	private const string GetNetUpdate_RPC = "GNUP";

	// Token: 0x04001C2A RID: 7210
	private const string ItemMove_RPC = "ITMV";

	// Token: 0x04001C2B RID: 7211
	private const string ItemMoveSelf_RPC = "ISMV";

	// Token: 0x04001C2C RID: 7212
	private const string DoItemAction_RPC = "IACT";

	// Token: 0x04001C2D RID: 7213
	private const string SetActiveItem_RPC = "IAST";

	// Token: 0x04001C2E RID: 7214
	private const string DeactivateItem_RPC = "ITDE";

	// Token: 0x04001C2F RID: 7215
	private const string ConfigureArmor_RPC = "CFAR";

	// Token: 0x04001C30 RID: 7216
	private const string Server_Request_Inventory_Update_Full = "SVUF";

	// Token: 0x04001C31 RID: 7217
	private const string MergeItems_RPC = "ITMG";

	// Token: 0x04001C32 RID: 7218
	private const string MergeItemsSelf_RPC = "ITSM";

	// Token: 0x04001C33 RID: 7219
	private const string SplitStack_RPCName = "ITSP";

	// Token: 0x04001C34 RID: 7220
	private const string Client_ItemEvent = "CLEV";

	// Token: 0x04001C35 RID: 7221
	private const string Server_Request_Inventory_Update_Cell = "SVUC";

	// Token: 0x04001C36 RID: 7222
	protected const int kDoNotOffsetProtoItem = 0;

	// Token: 0x04001C37 RID: 7223
	private const global::Inventory.Payload.Opt kLoadItemOpt = global::Inventory.Payload.Opt.DoNotStack | global::Inventory.Payload.Opt.RestrictToOffset;

	// Token: 0x04001C38 RID: 7224
	private const global::Inventory.SlotOperations SlotOperations_Mask = (global::Inventory.SlotOperations)0xC7;

	// Token: 0x04001C39 RID: 7225
	private const global::Inventory.SlotOperations SlotOperations_Operations = (global::Inventory.SlotOperations)7;

	// Token: 0x04001C3A RID: 7226
	private const global::Inventory.SlotOperations SlotOperations_Options = (global::Inventory.SlotOperations)0xC0;

	// Token: 0x04001C3B RID: 7227
	[global::System.NonSerialized]
	public global::InventoryItem _activeItem;

	// Token: 0x04001C3C RID: 7228
	[global::System.NonSerialized]
	private global::CacheRef<global::InventoryHolder> _inventoryHolder;

	// Token: 0x04001C3D RID: 7229
	[global::System.NonSerialized]
	private global::CacheRef<global::EquipmentWearer> _equipmentWearer;

	// Token: 0x04001C3E RID: 7230
	[global::System.NonSerialized]
	private bool _iteratingArmor;

	// Token: 0x04001C3F RID: 7231
	[global::System.NonSerialized]
	private bool _armorBuffered;

	// Token: 0x04001C40 RID: 7232
	[global::System.NonSerialized]
	private bool _blockArmorUpdates;

	// Token: 0x04001C41 RID: 7233
	[global::System.NonSerialized]
	private global::System.Collections.Generic.HashSet<global::uLink.NetworkPlayer> _netListeners;

	// Token: 0x04001C42 RID: 7234
	[global::System.NonSerialized]
	private bool _anyNetListeners;

	// Token: 0x04001C43 RID: 7235
	[global::System.NonSerialized]
	protected bool lastUpdateToNetListenersSent;

	// Token: 0x04001C44 RID: 7236
	[global::System.NonSerialized]
	private global::Inventory.Slot.KindDictionary<global::Inventory.Slot.Range> slotRanges;

	// Token: 0x04001C45 RID: 7237
	[global::System.NonSerialized]
	private global::Inventory.Collection<global::InventoryItem> _collection_;

	// Token: 0x04001C46 RID: 7238
	[global::System.NonSerialized]
	private global::Inventory.SlotFlags[] _slotFlags;

	// Token: 0x04001C47 RID: 7239
	[global::System.NonSerialized]
	private global::ArmorModelMemberMap<global::ArmorDataBlock> lastNetworkedArmorDatablocks;

	// Token: 0x04001C48 RID: 7240
	[global::System.NonSerialized]
	private bool _collection_made_;

	// Token: 0x04001C49 RID: 7241
	[global::System.NonSerialized]
	private bool _locked;

	// Token: 0x0200063A RID: 1594
	public enum AddExistingItemResult
	{
		// Token: 0x04001C4B RID: 7243
		CompletlyStacked,
		// Token: 0x04001C4C RID: 7244
		Moved,
		// Token: 0x04001C4D RID: 7245
		PartiallyStacked,
		// Token: 0x04001C4E RID: 7246
		Failed,
		// Token: 0x04001C4F RID: 7247
		BadItemArgument
	}

	// Token: 0x0200063B RID: 1595
	[global::System.Flags]
	private enum AddMultipleItemFlags
	{
		// Token: 0x04001C51 RID: 7249
		MustBeSplittable = 2,
		// Token: 0x04001C52 RID: 7250
		MustBeNonSplittable = 1,
		// Token: 0x04001C53 RID: 7251
		DoNotCreateNewSplittableStacks = 4,
		// Token: 0x04001C54 RID: 7252
		DoNotStackSplittables = 8
	}

	// Token: 0x0200063C RID: 1596
	public struct Addition
	{
		// Token: 0x17000A9A RID: 2714
		// (get) Token: 0x06003323 RID: 13091 RVA: 0x000C3FC0 File Offset: 0x000C21C0
		// (set) Token: 0x06003324 RID: 13092 RVA: 0x000C3FD4 File Offset: 0x000C21D4
		public global::ItemDataBlock ItemDataBlock
		{
			get
			{
				return (global::ItemDataBlock)this.Ident.datablock;
			}
			set
			{
				this.Ident = (global::Datablock.Ident)value;
			}
		}

		// Token: 0x17000A9B RID: 2715
		// (get) Token: 0x06003325 RID: 13093 RVA: 0x000C3FE4 File Offset: 0x000C21E4
		// (set) Token: 0x06003326 RID: 13094 RVA: 0x000C4010 File Offset: 0x000C2210
		public string Name
		{
			get
			{
				global::ItemDataBlock itemDataBlock = this.ItemDataBlock;
				return (!itemDataBlock) ? null : itemDataBlock.name;
			}
			set
			{
				this.Ident = value;
			}
		}

		// Token: 0x17000A9C RID: 2716
		// (get) Token: 0x06003327 RID: 13095 RVA: 0x000C4020 File Offset: 0x000C2220
		// (set) Token: 0x06003328 RID: 13096 RVA: 0x000C404C File Offset: 0x000C224C
		public int UniqueID
		{
			get
			{
				global::ItemDataBlock itemDataBlock = this.ItemDataBlock;
				return (!itemDataBlock) ? 0 : itemDataBlock.uniqueID;
			}
			set
			{
				this.Ident = value;
			}
		}

		// Token: 0x04001C55 RID: 7253
		public global::Datablock.Ident Ident;

		// Token: 0x04001C56 RID: 7254
		public global::Inventory.Uses.Quantity UsesQuantity;

		// Token: 0x04001C57 RID: 7255
		public global::Inventory.Slot.Preference SlotPreference;
	}

	// Token: 0x0200063D RID: 1597
	public enum AmountMode
	{
		// Token: 0x04001C59 RID: 7257
		Default,
		// Token: 0x04001C5A RID: 7258
		OnlyStack,
		// Token: 0x04001C5B RID: 7259
		OnlyCreateNew,
		// Token: 0x04001C5C RID: 7260
		IgnoreSplittables
	}

	// Token: 0x0200063E RID: 1598
	private sealed class Collection<T>
	{
		// Token: 0x06003329 RID: 13097 RVA: 0x000C405C File Offset: 0x000C225C
		public Collection(int Capacity)
		{
			if (Capacity < 0 || Capacity > 0x100)
			{
				throw new global::System.ArgumentOutOfRangeException();
			}
			this.capacity = Capacity;
			this.count = 0;
			this.array = new T[Capacity];
			this.indices = new byte[Capacity];
		}

		// Token: 0x17000A9D RID: 2717
		// (get) Token: 0x0600332A RID: 13098 RVA: 0x000C40B0 File Offset: 0x000C22B0
		public bool AnyVacantOrOccupied
		{
			get
			{
				return this.capacity > 0;
			}
		}

		// Token: 0x17000A9E RID: 2718
		// (get) Token: 0x0600332B RID: 13099 RVA: 0x000C40BC File Offset: 0x000C22BC
		public bool IsCompletelyVacant
		{
			get
			{
				return this.count == 0 && this.capacity > 0;
			}
		}

		// Token: 0x17000A9F RID: 2719
		// (get) Token: 0x0600332C RID: 13100 RVA: 0x000C40D8 File Offset: 0x000C22D8
		public bool HasVacancy
		{
			get
			{
				return this.count < this.capacity;
			}
		}

		// Token: 0x17000AA0 RID: 2720
		// (get) Token: 0x0600332D RID: 13101 RVA: 0x000C40E8 File Offset: 0x000C22E8
		public bool HasNoVacancy
		{
			get
			{
				return this.count == this.capacity;
			}
		}

		// Token: 0x17000AA1 RID: 2721
		// (get) Token: 0x0600332E RID: 13102 RVA: 0x000C40F8 File Offset: 0x000C22F8
		public bool HasNoOccupant
		{
			get
			{
				return this.count == 0;
			}
		}

		// Token: 0x17000AA2 RID: 2722
		// (get) Token: 0x0600332F RID: 13103 RVA: 0x000C4104 File Offset: 0x000C2304
		public bool HasAnyOccupant
		{
			get
			{
				return this.count > 0;
			}
		}

		// Token: 0x17000AA3 RID: 2723
		// (get) Token: 0x06003330 RID: 13104 RVA: 0x000C4110 File Offset: 0x000C2310
		public int FirstVacancy
		{
			get
			{
				if (this.count == this.capacity)
				{
					return -1;
				}
				for (int i = 0; i < 0x100; i++)
				{
					if (!this.occupied[i])
					{
						return i;
					}
				}
				throw new global::System.InvalidOperationException();
			}
		}

		// Token: 0x17000AA4 RID: 2724
		// (get) Token: 0x06003331 RID: 13105 RVA: 0x000C4160 File Offset: 0x000C2360
		public int FirstOccupied
		{
			get
			{
				if (this.count > 0)
				{
					return (int)this.indices[0];
				}
				return -1;
			}
		}

		// Token: 0x17000AA5 RID: 2725
		// (get) Token: 0x06003332 RID: 13106 RVA: 0x000C4178 File Offset: 0x000C2378
		public int LastOccupied
		{
			get
			{
				if (this.count > 0)
				{
					return (int)this.indices[this.count - 1];
				}
				return -1;
			}
		}

		// Token: 0x17000AA6 RID: 2726
		// (get) Token: 0x06003333 RID: 13107 RVA: 0x000C4198 File Offset: 0x000C2398
		public bool MarkedDirty
		{
			get
			{
				return this.forcedDirty || this.countDirty > 0;
			}
		}

		// Token: 0x17000AA7 RID: 2727
		// (get) Token: 0x06003334 RID: 13108 RVA: 0x000C41B4 File Offset: 0x000C23B4
		public bool CompletelyDirty
		{
			get
			{
				return this.countDirty == this.capacity && this.capacity > 0;
			}
		}

		// Token: 0x17000AA8 RID: 2728
		// (get) Token: 0x06003335 RID: 13109 RVA: 0x000C41D4 File Offset: 0x000C23D4
		// (set) Token: 0x06003336 RID: 13110 RVA: 0x000C41DC File Offset: 0x000C23DC
		public bool ForcedDirty
		{
			get
			{
				return this.forcedDirty;
			}
			set
			{
				if (value != this.forcedDirty && this.capacity > 0)
				{
					this.forcedDirty = value;
				}
			}
		}

		// Token: 0x06003337 RID: 13111 RVA: 0x000C4200 File Offset: 0x000C2400
		public bool Clean(out global::Inventory.Mask dirtyMask, out int numDirty)
		{
			return this.Clean(out dirtyMask, out numDirty, false);
		}

		// Token: 0x06003338 RID: 13112 RVA: 0x000C420C File Offset: 0x000C240C
		public bool Clean(out global::Inventory.Mask dirtyMask, out int numDirty, bool dontActuallyClean)
		{
			if (this.countDirty > 0)
			{
				dirtyMask = this.dirty;
				numDirty = this.countDirty;
				if (!dontActuallyClean)
				{
					this.dirty = default(global::Inventory.Mask);
					this.countDirty = 0;
					this.forcedDirty = false;
				}
				return true;
			}
			dirtyMask = default(global::Inventory.Mask);
			numDirty = 0;
			if (this.forcedDirty)
			{
				if (!dontActuallyClean)
				{
					this.forcedDirty = false;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06003339 RID: 13113 RVA: 0x000C428C File Offset: 0x000C248C
		public bool GetByOrder(int index, out T value)
		{
			if (index < this.count)
			{
				value = this.array[(int)this.indices[index]];
				return true;
			}
			value = default(T);
			return false;
		}

		// Token: 0x17000AA9 RID: 2729
		// (get) Token: 0x0600333A RID: 13114 RVA: 0x000C42D0 File Offset: 0x000C24D0
		public int Capacity
		{
			get
			{
				return this.capacity;
			}
		}

		// Token: 0x17000AAA RID: 2730
		// (get) Token: 0x0600333B RID: 13115 RVA: 0x000C42D8 File Offset: 0x000C24D8
		public int OccupiedCount
		{
			get
			{
				return this.count;
			}
		}

		// Token: 0x17000AAB RID: 2731
		// (get) Token: 0x0600333C RID: 13116 RVA: 0x000C42E0 File Offset: 0x000C24E0
		public int VacantCount
		{
			get
			{
				return this.capacity - this.count;
			}
		}

		// Token: 0x17000AAC RID: 2732
		// (get) Token: 0x0600333D RID: 13117 RVA: 0x000C42F0 File Offset: 0x000C24F0
		public int DirtyCount
		{
			get
			{
				return this.countDirty;
			}
		}

		// Token: 0x0600333E RID: 13118 RVA: 0x000C42F8 File Offset: 0x000C24F8
		public void MarkCompletelyDirty()
		{
			this.dirty = new global::Inventory.Mask(0, this.capacity);
			this.countDirty = this.capacity;
		}

		// Token: 0x0600333F RID: 13119 RVA: 0x000C4318 File Offset: 0x000C2518
		public bool MarkDirty(int slot)
		{
			if (slot >= 0 && slot < this.capacity && this.dirty.On(slot))
			{
				this.countDirty++;
				return true;
			}
			return false;
		}

		// Token: 0x06003340 RID: 13120 RVA: 0x000C4350 File Offset: 0x000C2550
		public bool IsVacant(int slot)
		{
			return slot >= 0 && slot < this.capacity && !this.occupied[slot];
		}

		// Token: 0x06003341 RID: 13121 RVA: 0x000C4378 File Offset: 0x000C2578
		public bool IsOccupied(int slot)
		{
			return slot >= 0 && slot < this.capacity && this.occupied[slot];
		}

		// Token: 0x06003342 RID: 13122 RVA: 0x000C43A8 File Offset: 0x000C25A8
		public bool IsWithinRange(int slot)
		{
			return slot >= 0 && slot < this.capacity;
		}

		// Token: 0x17000AAD RID: 2733
		// (get) Token: 0x06003343 RID: 13123 RVA: 0x000C43C0 File Offset: 0x000C25C0
		public global::Inventory.Collection<T>.OccupiedCollection.Enumerator OccupiedEnumerator
		{
			get
			{
				return new global::Inventory.Collection<T>.OccupiedCollection.Enumerator(this);
			}
		}

		// Token: 0x17000AAE RID: 2734
		// (get) Token: 0x06003344 RID: 13124 RVA: 0x000C43C8 File Offset: 0x000C25C8
		public global::Inventory.Collection<T>.OccupiedCollection.ReverseEnumerator OccupiedReverseEnumerator
		{
			get
			{
				return new global::Inventory.Collection<T>.OccupiedCollection.ReverseEnumerator(this);
			}
		}

		// Token: 0x17000AAF RID: 2735
		// (get) Token: 0x06003345 RID: 13125 RVA: 0x000C43D0 File Offset: 0x000C25D0
		public global::Inventory.Collection<T>.VacantCollection.Enumerator VacantEnumerator
		{
			get
			{
				return new global::Inventory.Collection<T>.VacantCollection.Enumerator(this);
			}
		}

		// Token: 0x06003346 RID: 13126 RVA: 0x000C43D8 File Offset: 0x000C25D8
		public void Contract()
		{
			this.Contract(new global::Inventory.Slot.Range(0, this.capacity));
		}

		// Token: 0x06003347 RID: 13127 RVA: 0x000C43EC File Offset: 0x000C25EC
		public void Contract(global::Inventory.Slot.Range range)
		{
			int start = range.Start;
			int num = start + range.Count;
			if (start < 0 || num > this.capacity)
			{
				throw new global::System.ArgumentOutOfRangeException();
			}
			if (this.count == this.capacity || start == num)
			{
				return;
			}
			for (int i = 0; i < this.count; i++)
			{
				if ((int)this.indices[i] >= start)
				{
					if ((int)this.indices[i] >= num)
					{
						break;
					}
					do
					{
						int num2 = start++;
						if (num2 != (int)this.indices[i])
						{
							this.array[num2] = this.array[(int)this.indices[i]];
							this.array[(int)this.indices[i]] = default(T);
							if (this.dirty.On((int)this.indices[i]))
							{
								this.countDirty++;
							}
							this.indices[i] = (byte)num2;
							if (this.dirty.On(i))
							{
								this.countDirty++;
							}
							if (start == num)
							{
								break;
							}
						}
					}
					while (++i < this.count && (int)this.indices[i] < num);
				}
			}
		}

		// Token: 0x06003348 RID: 13128 RVA: 0x000C4548 File Offset: 0x000C2748
		public bool Get(int slot, out T value)
		{
			if (slot < 0 || slot >= this.capacity)
			{
				throw new global::System.ArgumentOutOfRangeException();
			}
			if (this.occupied[slot])
			{
				value = this.array[slot];
				return true;
			}
			value = default(T);
			return false;
		}

		// Token: 0x06003349 RID: 13129 RVA: 0x000C45A4 File Offset: 0x000C27A4
		private bool DoReplace(bool equalityCheck, int slot, T value, out T replacedValue)
		{
			replacedValue = this.array[slot];
			if (equalityCheck && object.Equals(replacedValue, value))
			{
				return false;
			}
			this.array[slot] = value;
			if (this.dirty.On(slot))
			{
				this.countDirty++;
			}
			return true;
		}

		// Token: 0x0600334A RID: 13130 RVA: 0x000C4618 File Offset: 0x000C2818
		public bool Supplant(int slot, T value, out T replacedValue, bool equalityCheck)
		{
			if (slot < 0 || slot >= this.capacity)
			{
				throw new global::System.ArgumentOutOfRangeException();
			}
			if (!this.occupied.On(slot))
			{
				return this.DoReplace(equalityCheck, slot, value, out replacedValue);
			}
			replacedValue = default(T);
			return false;
		}

		// Token: 0x0600334B RID: 13131 RVA: 0x000C466C File Offset: 0x000C286C
		private void DoSet(int slot, T value)
		{
			if (this.count == 0 || (int)this.indices[0] > slot)
			{
				int num = this.count;
				for (int i = this.count - 1; i >= 0; i--)
				{
					this.indices[num] = this.indices[i];
					num--;
				}
				this.indices[0] = (byte)slot;
			}
			else
			{
				for (int j = this.count - 1; j >= 0; j--)
				{
					if ((int)this.indices[j] <= slot)
					{
						this.indices[j + 1] = (byte)slot;
						break;
					}
					this.indices[j + 1] = this.indices[j];
				}
			}
			this.array[slot] = value;
			this.count++;
			if (this.dirty.On(slot))
			{
				this.countDirty++;
			}
		}

		// Token: 0x0600334C RID: 13132 RVA: 0x000C4760 File Offset: 0x000C2960
		public bool Occupy(int slot, T occupant)
		{
			if (slot < 0 || slot >= this.capacity)
			{
				throw new global::System.ArgumentOutOfRangeException();
			}
			if (this.occupied.On(slot))
			{
				this.DoSet(slot, occupant);
				return true;
			}
			return false;
		}

		// Token: 0x0600334D RID: 13133 RVA: 0x000C4798 File Offset: 0x000C2998
		public bool SupplantOrOccupy(int slot, T occupant, out T replacedValue, bool equalityCheck)
		{
			if (slot < 0 || slot >= this.capacity)
			{
				throw new global::System.ArgumentOutOfRangeException();
			}
			if (this.occupied.On(slot))
			{
				replacedValue = default(T);
				this.DoSet(slot, occupant);
				return false;
			}
			return this.DoReplace(equalityCheck, slot, occupant, out replacedValue);
		}

		// Token: 0x0600334E RID: 13134 RVA: 0x000C47F4 File Offset: 0x000C29F4
		public bool Evict(int slot, out T value)
		{
			if (slot < 0 || slot >= this.capacity)
			{
				throw new global::System.ArgumentOutOfRangeException();
			}
			if (this.occupied.Off(slot))
			{
				for (int i = 0; i < this.count; i++)
				{
					if ((int)this.indices[i] == slot)
					{
						for (int j = i + 1; j < this.count; j++)
						{
							this.indices[i] = this.indices[j];
							i++;
						}
						this.indices[--this.count] = 0;
						value = this.array[slot];
						this.array[slot] = default(T);
						if (this.dirty.On(slot))
						{
							this.countDirty++;
						}
						return true;
					}
				}
				throw new global::System.InvalidOperationException();
			}
			value = default(T);
			return false;
		}

		// Token: 0x17000AB0 RID: 2736
		// (get) Token: 0x0600334F RID: 13135 RVA: 0x000C48F8 File Offset: 0x000C2AF8
		public global::Inventory.Collection<T>.OccupiedCollection Occupied
		{
			get
			{
				global::Inventory.Collection<T>.OccupiedCollection result;
				if ((result = this.occupiedCollection) == null)
				{
					result = (this.occupiedCollection = new global::Inventory.Collection<T>.OccupiedCollection(this));
				}
				return result;
			}
		}

		// Token: 0x06003350 RID: 13136 RVA: 0x000C4924 File Offset: 0x000C2B24
		public T[] OccupiedToArray()
		{
			T[] array = new T[this.count];
			for (int i = 0; i < this.count; i++)
			{
				array[i] = this.array[(int)this.indices[i]];
			}
			return array;
		}

		// Token: 0x17000AB1 RID: 2737
		// (get) Token: 0x06003351 RID: 13137 RVA: 0x000C4970 File Offset: 0x000C2B70
		public global::Inventory.Collection<T>.VacantCollection Vacant
		{
			get
			{
				global::Inventory.Collection<T>.VacantCollection result;
				if ((result = this.vacantCollection) == null)
				{
					result = (this.vacantCollection = new global::Inventory.Collection<T>.VacantCollection(this));
				}
				return result;
			}
		}

		// Token: 0x06003352 RID: 13138 RVA: 0x000C499C File Offset: 0x000C2B9C
		public bool IsDirty(int slot)
		{
			return slot >= 0 && slot < this.capacity && this.dirty[slot];
		}

		// Token: 0x06003353 RID: 13139 RVA: 0x000C49CC File Offset: 0x000C2BCC
		public void MarkCompletelyClean()
		{
			this.dirty = default(global::Inventory.Mask);
			this.countDirty = 0;
		}

		// Token: 0x06003354 RID: 13140 RVA: 0x000C49F0 File Offset: 0x000C2BF0
		public bool MarkClean(int slot)
		{
			if (slot >= 0 && slot < this.capacity && this.dirty.Off(slot))
			{
				this.countDirty--;
				return true;
			}
			return false;
		}

		// Token: 0x04001C5D RID: 7261
		[global::System.NonSerialized]
		private global::Inventory.Collection<T>.OccupiedCollection occupiedCollection;

		// Token: 0x04001C5E RID: 7262
		[global::System.NonSerialized]
		private global::Inventory.Collection<T>.VacantCollection vacantCollection;

		// Token: 0x04001C5F RID: 7263
		[global::System.NonSerialized]
		private T[] array;

		// Token: 0x04001C60 RID: 7264
		[global::System.NonSerialized]
		private byte[] indices;

		// Token: 0x04001C61 RID: 7265
		[global::System.NonSerialized]
		private global::Inventory.Mask occupied;

		// Token: 0x04001C62 RID: 7266
		[global::System.NonSerialized]
		private global::Inventory.Mask dirty;

		// Token: 0x04001C63 RID: 7267
		[global::System.NonSerialized]
		private int count;

		// Token: 0x04001C64 RID: 7268
		[global::System.NonSerialized]
		private int capacity;

		// Token: 0x04001C65 RID: 7269
		[global::System.NonSerialized]
		private int countDirty;

		// Token: 0x04001C66 RID: 7270
		[global::System.NonSerialized]
		private bool forcedDirty;

		// Token: 0x0200063F RID: 1599
		public static class Default
		{
			// Token: 0x06003355 RID: 13141 RVA: 0x000C4A28 File Offset: 0x000C2C28
			// Note: this type is marked as 'beforefieldinit'.
			static Default()
			{
			}

			// Token: 0x04001C67 RID: 7271
			public static readonly global::Inventory.Collection<T> Empty = new global::Inventory.Collection<T>(0);
		}

		// Token: 0x02000640 RID: 1600
		public sealed class OccupiedCollection : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<!0>
		{
			// Token: 0x06003356 RID: 13142 RVA: 0x000C4A38 File Offset: 0x000C2C38
			internal OccupiedCollection(global::Inventory.Collection<T> collection)
			{
				this.Collection = collection;
			}

			// Token: 0x06003357 RID: 13143 RVA: 0x000C4A48 File Offset: 0x000C2C48
			global::System.Collections.Generic.IEnumerator<T> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06003358 RID: 13144 RVA: 0x000C4A58 File Offset: 0x000C2C58
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x17000AB2 RID: 2738
			// (get) Token: 0x06003359 RID: 13145 RVA: 0x000C4A68 File Offset: 0x000C2C68
			public int Count
			{
				get
				{
					return this.Collection.count;
				}
			}

			// Token: 0x17000AB3 RID: 2739
			// (get) Token: 0x0600335A RID: 13146 RVA: 0x000C4A78 File Offset: 0x000C2C78
			public bool Empty
			{
				get
				{
					return this.Collection.count == 0;
				}
			}

			// Token: 0x0600335B RID: 13147 RVA: 0x000C4A88 File Offset: 0x000C2C88
			public T[] ToArray()
			{
				return this.Collection.OccupiedToArray();
			}

			// Token: 0x0600335C RID: 13148 RVA: 0x000C4A98 File Offset: 0x000C2C98
			public global::Inventory.Collection<T>.OccupiedCollection.Enumerator GetEnumerator()
			{
				return new global::Inventory.Collection<T>.OccupiedCollection.Enumerator(this.Collection);
			}

			// Token: 0x04001C68 RID: 7272
			public readonly global::Inventory.Collection<T> Collection;

			// Token: 0x02000641 RID: 1601
			public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<!0>
			{
				// Token: 0x0600335D RID: 13149 RVA: 0x000C4AA8 File Offset: 0x000C2CA8
				internal Enumerator(global::Inventory.Collection<T> collection)
				{
					this.collection = collection;
					this.indexPosition = -1;
				}

				// Token: 0x17000AB4 RID: 2740
				// (get) Token: 0x0600335E RID: 13150 RVA: 0x000C4AB8 File Offset: 0x000C2CB8
				object global::System.Collections.IEnumerator.Current
				{
					get
					{
						return this.collection.array[(int)this.collection.indices[this.indexPosition]];
					}
				}

				// Token: 0x0600335F RID: 13151 RVA: 0x000C4AE4 File Offset: 0x000C2CE4
				public bool MoveNext()
				{
					return ++this.indexPosition < this.collection.count;
				}

				// Token: 0x17000AB5 RID: 2741
				// (get) Token: 0x06003360 RID: 13152 RVA: 0x000C4B10 File Offset: 0x000C2D10
				public T Current
				{
					get
					{
						return this.collection.array[(int)this.collection.indices[this.indexPosition]];
					}
				}

				// Token: 0x17000AB6 RID: 2742
				// (get) Token: 0x06003361 RID: 13153 RVA: 0x000C4B40 File Offset: 0x000C2D40
				public int Slot
				{
					get
					{
						return (int)this.collection.indices[this.indexPosition];
					}
				}

				// Token: 0x06003362 RID: 13154 RVA: 0x000C4B54 File Offset: 0x000C2D54
				public void Reset()
				{
					this.indexPosition = -1;
				}

				// Token: 0x06003363 RID: 13155 RVA: 0x000C4B60 File Offset: 0x000C2D60
				public void Dispose()
				{
					this.collection = null;
				}

				// Token: 0x04001C69 RID: 7273
				private global::Inventory.Collection<T> collection;

				// Token: 0x04001C6A RID: 7274
				private int indexPosition;
			}

			// Token: 0x02000642 RID: 1602
			public struct ReverseEnumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<!0>
			{
				// Token: 0x06003364 RID: 13156 RVA: 0x000C4B6C File Offset: 0x000C2D6C
				internal ReverseEnumerator(global::Inventory.Collection<T> collection)
				{
					this.collection = collection;
					this.indexPosition = collection.count;
				}

				// Token: 0x17000AB7 RID: 2743
				// (get) Token: 0x06003365 RID: 13157 RVA: 0x000C4B84 File Offset: 0x000C2D84
				object global::System.Collections.IEnumerator.Current
				{
					get
					{
						return this.collection.array[(int)this.collection.indices[this.indexPosition]];
					}
				}

				// Token: 0x06003366 RID: 13158 RVA: 0x000C4BB0 File Offset: 0x000C2DB0
				public bool MoveNext()
				{
					return --this.indexPosition >= 0;
				}

				// Token: 0x17000AB8 RID: 2744
				// (get) Token: 0x06003367 RID: 13159 RVA: 0x000C4BD4 File Offset: 0x000C2DD4
				public T Current
				{
					get
					{
						return this.collection.array[(int)this.collection.indices[this.indexPosition]];
					}
				}

				// Token: 0x17000AB9 RID: 2745
				// (get) Token: 0x06003368 RID: 13160 RVA: 0x000C4C04 File Offset: 0x000C2E04
				public int Slot
				{
					get
					{
						return (int)this.collection.indices[this.indexPosition];
					}
				}

				// Token: 0x06003369 RID: 13161 RVA: 0x000C4C18 File Offset: 0x000C2E18
				public void Reset()
				{
					this.indexPosition = this.collection.count;
				}

				// Token: 0x0600336A RID: 13162 RVA: 0x000C4C2C File Offset: 0x000C2E2C
				public void Dispose()
				{
					this.collection = null;
				}

				// Token: 0x04001C6B RID: 7275
				private global::Inventory.Collection<T> collection;

				// Token: 0x04001C6C RID: 7276
				private int indexPosition;
			}
		}

		// Token: 0x02000643 RID: 1603
		public sealed class VacantCollection : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<int>
		{
			// Token: 0x0600336B RID: 13163 RVA: 0x000C4C38 File Offset: 0x000C2E38
			internal VacantCollection(global::Inventory.Collection<T> collection)
			{
				this.Collection = collection;
			}

			// Token: 0x0600336C RID: 13164 RVA: 0x000C4C48 File Offset: 0x000C2E48
			global::System.Collections.Generic.IEnumerator<int> global::System.Collections.Generic.IEnumerable<int>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x0600336D RID: 13165 RVA: 0x000C4C58 File Offset: 0x000C2E58
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x17000ABA RID: 2746
			// (get) Token: 0x0600336E RID: 13166 RVA: 0x000C4C68 File Offset: 0x000C2E68
			public int Count
			{
				get
				{
					return this.Collection.capacity - this.Collection.count;
				}
			}

			// Token: 0x17000ABB RID: 2747
			// (get) Token: 0x0600336F RID: 13167 RVA: 0x000C4C84 File Offset: 0x000C2E84
			public bool Empty
			{
				get
				{
					return this.Collection.count == this.Collection.capacity;
				}
			}

			// Token: 0x06003370 RID: 13168 RVA: 0x000C4CA0 File Offset: 0x000C2EA0
			public global::Inventory.Collection<T>.VacantCollection.Enumerator GetEnumerator()
			{
				return new global::Inventory.Collection<T>.VacantCollection.Enumerator(this.Collection);
			}

			// Token: 0x04001C6D RID: 7277
			public readonly global::Inventory.Collection<T> Collection;

			// Token: 0x02000644 RID: 1604
			public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<int>
			{
				// Token: 0x06003371 RID: 13169 RVA: 0x000C4CB0 File Offset: 0x000C2EB0
				internal Enumerator(global::Inventory.Collection<T> collection)
				{
					this.collection = collection;
					this.slotPosition = -1;
				}

				// Token: 0x17000ABC RID: 2748
				// (get) Token: 0x06003372 RID: 13170 RVA: 0x000C4CC0 File Offset: 0x000C2EC0
				object global::System.Collections.IEnumerator.Current
				{
					get
					{
						return this.slotPosition;
					}
				}

				// Token: 0x06003373 RID: 13171 RVA: 0x000C4CD0 File Offset: 0x000C2ED0
				public bool MoveNext()
				{
					while (++this.slotPosition < this.collection.capacity)
					{
						if (!this.collection.occupied[this.slotPosition])
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x17000ABD RID: 2749
				// (get) Token: 0x06003374 RID: 13172 RVA: 0x000C4D24 File Offset: 0x000C2F24
				public int Current
				{
					get
					{
						return this.slotPosition;
					}
				}

				// Token: 0x06003375 RID: 13173 RVA: 0x000C4D2C File Offset: 0x000C2F2C
				public void Reset()
				{
					this.slotPosition = -1;
				}

				// Token: 0x06003376 RID: 13174 RVA: 0x000C4D38 File Offset: 0x000C2F38
				public void Dispose()
				{
					this.collection = null;
				}

				// Token: 0x04001C6E RID: 7278
				private global::Inventory.Collection<T> collection;

				// Token: 0x04001C6F RID: 7279
				private int slotPosition;
			}
		}
	}

	// Token: 0x02000645 RID: 1605
	public static class Constants
	{
		// Token: 0x04001C70 RID: 7280
		public const int MaximumSlotCount = 0x100;
	}

	// Token: 0x02000646 RID: 1606
	public struct Mask
	{
		// Token: 0x06003377 RID: 13175 RVA: 0x000C4D44 File Offset: 0x000C2F44
		public Mask(bool defaultOn)
		{
			int num = (!defaultOn) ? 0 : -1;
			this.a = (this.b = (this.c = (this.d = (this.e = (this.f = (this.g = (this.h = num)))))));
		}

		// Token: 0x06003378 RID: 13176 RVA: 0x000C4DA8 File Offset: 0x000C2FA8
		public Mask(int onStart, int onCount)
		{
			this = new global::Inventory.Mask(false);
			int num = onStart;
			int num2 = onStart + onCount;
			while (num < 0x100 && num < num2)
			{
				this[num] = true;
				num++;
			}
		}

		// Token: 0x17000ABE RID: 2750
		// (get) Token: 0x06003379 RID: 13177 RVA: 0x000C4DE8 File Offset: 0x000C2FE8
		public bool any
		{
			get
			{
				return this.a != 0 || this.b != 0 || this.c != 0 || this.d != 0 || this.e != 0 || this.f != 0 || this.g != 0 || this.h != 0;
			}
		}

		// Token: 0x17000ABF RID: 2751
		// (get) Token: 0x0600337A RID: 13178 RVA: 0x000C4E54 File Offset: 0x000C3054
		public int firstOnBit
		{
			get
			{
				int num = 0;
				int num2;
				if (this.a == 0)
				{
					num++;
					if (this.b == 0)
					{
						num++;
						if (this.c == 0)
						{
							num++;
							if (this.d == 0)
							{
								num++;
								if (this.e == 0)
								{
									num++;
									if (this.f == 0)
									{
										num++;
										if (this.g == 0)
										{
											num++;
											if (this.h == 0)
											{
												num++;
												num2 = 0;
											}
											else
											{
												num2 = this.h;
											}
										}
										else
										{
											num2 = this.g;
										}
									}
									else
									{
										num2 = this.f;
									}
								}
								else
								{
									num2 = this.e;
								}
							}
							else
							{
								num2 = this.d;
							}
						}
						else
						{
							num2 = this.c;
						}
					}
					else
					{
						num2 = this.b;
					}
				}
				else
				{
					num2 = this.a;
				}
				int num3 = 0;
				for (int i = 0; i < 0x20; i++)
				{
					if ((num2 & 1 << i) == 1 << i)
					{
						break;
					}
					num3++;
				}
				return num * 0x20 + num3;
			}
		}

		// Token: 0x17000AC0 RID: 2752
		// (get) Token: 0x0600337B RID: 13179 RVA: 0x000C4F78 File Offset: 0x000C3178
		public int lastOnBit
		{
			get
			{
				int num = 7;
				int num2;
				if (this.h == 0)
				{
					num--;
					if (this.g == 0)
					{
						num--;
						if (this.f == 0)
						{
							num--;
							if (this.e == 0)
							{
								num--;
								if (this.d == 0)
								{
									num--;
									if (this.c == 0)
									{
										num--;
										if (this.b == 0)
										{
											num--;
											if (this.a == 0)
											{
												return -1;
											}
											num2 = this.a;
										}
										else
										{
											num2 = this.b;
										}
									}
									else
									{
										num2 = this.c;
									}
								}
								else
								{
									num2 = this.d;
								}
							}
							else
							{
								num2 = this.e;
							}
						}
						else
						{
							num2 = this.f;
						}
					}
					else
					{
						num2 = this.g;
					}
				}
				else
				{
					num2 = this.h;
				}
				int num3 = 0;
				for (int i = 0x1F; i >= 0; i--)
				{
					if ((num2 & 1 << i) == 1 << i)
					{
						break;
					}
					num3++;
				}
				return num * 0x20 + num3;
			}
		}

		// Token: 0x17000AC1 RID: 2753
		public bool this[int bit]
		{
			get
			{
				if (bit < 0x80)
				{
					if (bit < 0x40)
					{
						if (bit < 0x20)
						{
							return (this.a & 1 << bit) != 0;
						}
						return (this.b & 1 << bit - 0x20) != 0;
					}
					else
					{
						if (bit < 0x60)
						{
							return (this.c & 1 << bit - 0x40) != 0;
						}
						return (this.d & 1 << bit - 0x60) != 0;
					}
				}
				else if (bit < 0xC0)
				{
					if (bit < 0xA0)
					{
						return (this.e & 1 << bit - 0x80) != 0;
					}
					return (this.f & 1 << bit - 0xA0) != 0;
				}
				else
				{
					if (bit < 0xE0)
					{
						return (this.g & 1 << bit - 0xC0) != 0;
					}
					return (this.h & 1 << bit - 0xE0) != 0;
				}
			}
			set
			{
				if (value)
				{
					if (bit < 0x80)
					{
						if (bit < 0x40)
						{
							if (bit < 0x20)
							{
								this.a |= 1 << bit;
							}
							else
							{
								this.b |= 1 << bit - 0x20;
							}
						}
						else if (bit < 0x60)
						{
							this.c |= 1 << bit - 0x40;
						}
						else
						{
							this.d |= 1 << bit - 0x60;
						}
					}
					else if (bit < 0xC0)
					{
						if (bit < 0xA0)
						{
							this.e |= 1 << bit - 0x80;
						}
						else
						{
							this.f |= 1 << bit - 0xA0;
						}
					}
					else if (bit < 0xE0)
					{
						this.g |= 1 << bit - 0xC0;
					}
					else
					{
						this.h |= 1 << bit - 0xE0;
					}
				}
				else if (bit < 0x80)
				{
					if (bit < 0x40)
					{
						if (bit < 0x20)
						{
							this.a &= ~(1 << bit);
						}
						else
						{
							this.b &= ~(1 << bit - 0x20);
						}
					}
					else if (bit < 0x60)
					{
						this.c &= ~(1 << bit - 0x40);
					}
					else
					{
						this.d &= ~(1 << bit - 0x60);
					}
				}
				else if (bit < 0xC0)
				{
					if (bit < 0xA0)
					{
						this.e &= ~(1 << bit - 0x80);
					}
					else
					{
						this.f &= ~(1 << bit - 0xA0);
					}
				}
				else if (bit < 0xE0)
				{
					this.g &= ~(1 << bit - 0xC0);
				}
				else
				{
					this.h &= ~(1 << bit - 0xE0);
				}
			}
		}

		// Token: 0x0600337E RID: 13182 RVA: 0x000C5438 File Offset: 0x000C3638
		public bool On(int bit)
		{
			if (bit < 0x80)
			{
				if (bit < 0x40)
				{
					if (bit < 0x20)
					{
						int num = 1 << bit;
						if (num != 0 && (this.a & num) == 0)
						{
							this.a |= num;
							return true;
						}
						return false;
					}
					else
					{
						int num = 1 << bit - 0x20;
						if (num != 0 && (this.b & num) == 0)
						{
							this.b |= num;
							return true;
						}
						return false;
					}
				}
				else if (bit < 0x60)
				{
					int num = 1 << bit - 0x40;
					if (num != 0 && (this.c & num) == 0)
					{
						this.c |= num;
						return true;
					}
					return false;
				}
				else
				{
					int num = 1 << bit - 0x60;
					if (num != 0 && (this.d & num) == 0)
					{
						this.d |= num;
						return true;
					}
					return false;
				}
			}
			else if (bit < 0xC0)
			{
				if (bit < 0xA0)
				{
					int num = 1 << bit - 0x80;
					if (num != 0 && (this.e & num) == 0)
					{
						this.e |= num;
						return true;
					}
					return false;
				}
				else
				{
					int num = 1 << bit - 0xA0;
					if (num != 0 && (this.f & num) == 0)
					{
						this.f |= num;
						return true;
					}
					return false;
				}
			}
			else if (bit < 0xE0)
			{
				int num = 1 << bit - 0xC0;
				if (num != 0 && (this.g & num) == 0)
				{
					this.g |= num;
					return true;
				}
				return false;
			}
			else
			{
				int num = 1 << bit - 0xE0;
				if (num != 0 && (this.h & num) == 0)
				{
					this.h |= num;
					return true;
				}
				return false;
			}
		}

		// Token: 0x0600337F RID: 13183 RVA: 0x000C560C File Offset: 0x000C380C
		public bool Off(int bit)
		{
			if (bit < 0x80)
			{
				if (bit < 0x40)
				{
					if (bit < 0x20)
					{
						int num = 1 << bit;
						if (num != 0 && (this.a & num) == num)
						{
							this.a &= ~num;
							return true;
						}
						return false;
					}
					else
					{
						int num = 1 << bit - 0x20;
						if (num != 0 && (this.b & num) == num)
						{
							this.b &= ~num;
							return true;
						}
						return false;
					}
				}
				else if (bit < 0x60)
				{
					int num = 1 << bit - 0x40;
					if (num != 0 && (this.c & num) == num)
					{
						this.c &= ~num;
						return true;
					}
					return false;
				}
				else
				{
					int num = 1 << bit - 0x60;
					if (num != 0 && (this.d & num) == num)
					{
						this.d &= ~num;
						return true;
					}
					return false;
				}
			}
			else if (bit < 0xC0)
			{
				if (bit < 0xA0)
				{
					int num = 1 << bit - 0x80;
					if (num != 0 && (this.e & num) == num)
					{
						this.e &= ~num;
						return true;
					}
					return false;
				}
				else
				{
					int num = 1 << bit - 0xA0;
					if (num != 0 && (this.f & num) == num)
					{
						this.f &= ~num;
						return true;
					}
					return false;
				}
			}
			else if (bit < 0xE0)
			{
				int num = 1 << bit - 0xC0;
				if (num != 0 && (this.g & num) == num)
				{
					this.g &= ~num;
					return true;
				}
				return false;
			}
			else
			{
				int num = 1 << bit - 0xE0;
				if (num != 0 && (this.h & num) == num)
				{
					this.h &= ~num;
					return true;
				}
				return false;
			}
		}

		// Token: 0x06003380 RID: 13184 RVA: 0x000C57F0 File Offset: 0x000C39F0
		public int CountOnBits()
		{
			int num = 0;
			if (this.a != 0)
			{
				uint num2 = (uint)this.a;
				while (num2 != 0U)
				{
					num2 &= num2 - 1U;
					num++;
				}
			}
			if (this.b != 0)
			{
				uint num2 = (uint)this.b;
				while (num2 != 0U)
				{
					num2 &= num2 - 1U;
					num++;
				}
			}
			if (this.c != 0)
			{
				uint num2 = (uint)this.c;
				while (num2 != 0U)
				{
					num2 &= num2 - 1U;
					num++;
				}
			}
			if (this.d != 0)
			{
				uint num2 = (uint)this.d;
				while (num2 != 0U)
				{
					num2 &= num2 - 1U;
					num++;
				}
			}
			if (this.e != 0)
			{
				uint num2 = (uint)this.e;
				while (num2 != 0U)
				{
					num2 &= num2 - 1U;
					num++;
				}
			}
			if (this.f != 0)
			{
				uint num2 = (uint)this.f;
				while (num2 != 0U)
				{
					num2 &= num2 - 1U;
					num++;
				}
			}
			if (this.g != 0)
			{
				uint num2 = (uint)this.g;
				while (num2 != 0U)
				{
					num2 &= num2 - 1U;
					num++;
				}
			}
			if (this.h != 0)
			{
				uint num2 = (uint)this.h;
				while (num2 != 0U)
				{
					num2 &= num2 - 1U;
					num++;
				}
			}
			return num;
		}

		// Token: 0x04001C71 RID: 7281
		public int a;

		// Token: 0x04001C72 RID: 7282
		public int b;

		// Token: 0x04001C73 RID: 7283
		public int c;

		// Token: 0x04001C74 RID: 7284
		public int d;

		// Token: 0x04001C75 RID: 7285
		public int e;

		// Token: 0x04001C76 RID: 7286
		public int f;

		// Token: 0x04001C77 RID: 7287
		public int g;

		// Token: 0x04001C78 RID: 7288
		public int h;
	}

	// Token: 0x02000647 RID: 1607
	public struct OccupiedIterator : global::System.IDisposable
	{
		// Token: 0x06003381 RID: 13185 RVA: 0x000C5938 File Offset: 0x000C3B38
		public OccupiedIterator(global::Inventory inventory)
		{
			this.baseEnumerator = inventory.collection.OccupiedEnumerator;
		}

		// Token: 0x06003382 RID: 13186 RVA: 0x000C594C File Offset: 0x000C3B4C
		public void Reset()
		{
			this.baseEnumerator.Reset();
		}

		// Token: 0x17000AC2 RID: 2754
		// (get) Token: 0x06003383 RID: 13187 RVA: 0x000C595C File Offset: 0x000C3B5C
		public global::IInventoryItem item
		{
			get
			{
				return this.baseEnumerator.Current.iface;
			}
		}

		// Token: 0x17000AC3 RID: 2755
		// (get) Token: 0x06003384 RID: 13188 RVA: 0x000C5970 File Offset: 0x000C3B70
		internal global::InventoryItem inventoryItem
		{
			get
			{
				return this.baseEnumerator.Current;
			}
		}

		// Token: 0x17000AC4 RID: 2756
		// (get) Token: 0x06003385 RID: 13189 RVA: 0x000C5980 File Offset: 0x000C3B80
		public int slot
		{
			get
			{
				return this.baseEnumerator.Slot;
			}
		}

		// Token: 0x06003386 RID: 13190 RVA: 0x000C5990 File Offset: 0x000C3B90
		public bool Next()
		{
			return this.baseEnumerator.MoveNext();
		}

		// Token: 0x06003387 RID: 13191 RVA: 0x000C59A0 File Offset: 0x000C3BA0
		public void Dispose()
		{
			this.baseEnumerator.Dispose();
		}

		// Token: 0x06003388 RID: 13192 RVA: 0x000C59B0 File Offset: 0x000C3BB0
		internal bool Next(out global::InventoryItem item, out int slot)
		{
			if (this.Next())
			{
				slot = this.baseEnumerator.Slot;
				item = this.baseEnumerator.Current;
				return true;
			}
			slot = -1;
			item = null;
			return false;
		}

		// Token: 0x06003389 RID: 13193 RVA: 0x000C59EC File Offset: 0x000C3BEC
		internal bool Next(int datablockUniqueID, out global::InventoryItem item, out int slot)
		{
			while (this.Next(out item, out slot))
			{
				if (item.datablockUniqueID == datablockUniqueID)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600338A RID: 13194 RVA: 0x000C5A1C File Offset: 0x000C3C1C
		internal bool Next(global::ItemDataBlock datablock, out global::InventoryItem item, out int slot)
		{
			return this.Next(datablock.uniqueID, out item, out slot);
		}

		// Token: 0x0600338B RID: 13195 RVA: 0x000C5A2C File Offset: 0x000C3C2C
		public bool Next(out global::IInventoryItem item, out int slot)
		{
			global::InventoryItem inventoryItem;
			if (this.Next(out inventoryItem, out slot))
			{
				item = inventoryItem.iface;
				return true;
			}
			item = null;
			return false;
		}

		// Token: 0x0600338C RID: 13196 RVA: 0x000C5A58 File Offset: 0x000C3C58
		public bool Next(int datablockUniqueID, out global::IInventoryItem item, out int slot)
		{
			global::InventoryItem inventoryItem;
			if (this.Next(datablockUniqueID, out inventoryItem, out slot))
			{
				item = inventoryItem.iface;
				return true;
			}
			item = null;
			return false;
		}

		// Token: 0x0600338D RID: 13197 RVA: 0x000C5A84 File Offset: 0x000C3C84
		internal bool Next(global::ItemDataBlock datablock, out global::IInventoryItem item, out int slot)
		{
			return this.Next(datablock.uniqueID, out item, out slot);
		}

		// Token: 0x0600338E RID: 13198 RVA: 0x000C5A94 File Offset: 0x000C3C94
		public bool Next<TItemInterface>(out TItemInterface item, out int slot) where TItemInterface : class, global::IInventoryItem
		{
			global::IInventoryItem inventoryItem;
			while (this.Next(out inventoryItem, out slot))
			{
				if (inventoryItem is TItemInterface)
				{
					item = (TItemInterface)((object)this.inventoryItem.iface);
					return true;
				}
			}
			item = (TItemInterface)((object)null);
			return false;
		}

		// Token: 0x0600338F RID: 13199 RVA: 0x000C5AEC File Offset: 0x000C3CEC
		public bool Next<TItemInterface>(int datablockUniqueID, out TItemInterface item, out int slot) where TItemInterface : class, global::IInventoryItem
		{
			global::IInventoryItem inventoryItem;
			while (this.Next(datablockUniqueID, out inventoryItem, out slot))
			{
				if (inventoryItem is TItemInterface)
				{
					item = (TItemInterface)((object)this.inventoryItem.iface);
					return true;
				}
			}
			item = (TItemInterface)((object)null);
			return false;
		}

		// Token: 0x06003390 RID: 13200 RVA: 0x000C5B44 File Offset: 0x000C3D44
		public bool Next<TItemInterface>(global::ItemDataBlock datablock, out TItemInterface item, out int slot) where TItemInterface : class, global::IInventoryItem
		{
			return this.Next<TItemInterface>(datablock.uniqueID, out item, out slot);
		}

		// Token: 0x06003391 RID: 13201 RVA: 0x000C5B54 File Offset: 0x000C3D54
		public bool Next(out int slot)
		{
			global::InventoryItem inventoryItem;
			return this.Next(out inventoryItem, out slot);
		}

		// Token: 0x06003392 RID: 13202 RVA: 0x000C5B6C File Offset: 0x000C3D6C
		public bool Next(int datablockUniqueID, out int slot)
		{
			global::InventoryItem inventoryItem;
			return this.Next(out inventoryItem, out slot);
		}

		// Token: 0x06003393 RID: 13203 RVA: 0x000C5B84 File Offset: 0x000C3D84
		public bool Next(global::ItemDataBlock datablock, out int slot)
		{
			global::InventoryItem inventoryItem;
			return this.Next(datablock.uniqueID, out inventoryItem, out slot);
		}

		// Token: 0x06003394 RID: 13204 RVA: 0x000C5BA0 File Offset: 0x000C3DA0
		public bool Next<TItemInterface>(out int slot) where TItemInterface : class, global::IInventoryItem
		{
			TItemInterface titemInterface;
			return this.Next<TItemInterface>(out titemInterface, out slot);
		}

		// Token: 0x06003395 RID: 13205 RVA: 0x000C5BB8 File Offset: 0x000C3DB8
		public bool Next<TItemInterface>(int datablockUniqueID, out int slot) where TItemInterface : class, global::IInventoryItem
		{
			TItemInterface titemInterface;
			return this.Next<TItemInterface>(out titemInterface, out slot);
		}

		// Token: 0x06003396 RID: 13206 RVA: 0x000C5BD0 File Offset: 0x000C3DD0
		public bool Next<TItemInterface>(global::ItemDataBlock datablock, out int slot) where TItemInterface : class, global::IInventoryItem
		{
			TItemInterface titemInterface;
			return this.Next<TItemInterface>(datablock.uniqueID, out titemInterface, out slot);
		}

		// Token: 0x06003397 RID: 13207 RVA: 0x000C5BEC File Offset: 0x000C3DEC
		internal bool Next(out global::InventoryItem item)
		{
			int num;
			return this.Next(out item, out num);
		}

		// Token: 0x06003398 RID: 13208 RVA: 0x000C5C04 File Offset: 0x000C3E04
		internal bool Next(int datablockUniqueID, out global::InventoryItem item)
		{
			int num;
			return this.Next(datablockUniqueID, out item, out num);
		}

		// Token: 0x06003399 RID: 13209 RVA: 0x000C5C1C File Offset: 0x000C3E1C
		internal bool Next(global::ItemDataBlock datablock, out global::InventoryItem item)
		{
			int num;
			return this.Next(datablock.uniqueID, out item, out num);
		}

		// Token: 0x0600339A RID: 13210 RVA: 0x000C5C38 File Offset: 0x000C3E38
		public bool Next(out global::IInventoryItem item)
		{
			int num;
			return this.Next(out item, out num);
		}

		// Token: 0x0600339B RID: 13211 RVA: 0x000C5C50 File Offset: 0x000C3E50
		public bool Next(int datablockUniqueID, out global::IInventoryItem item)
		{
			int num;
			return this.Next(datablockUniqueID, out item, out num);
		}

		// Token: 0x0600339C RID: 13212 RVA: 0x000C5C68 File Offset: 0x000C3E68
		internal bool Next(global::ItemDataBlock datablock, out global::IInventoryItem item)
		{
			int num;
			return this.Next(datablock.uniqueID, out item, out num);
		}

		// Token: 0x0600339D RID: 13213 RVA: 0x000C5C84 File Offset: 0x000C3E84
		public bool Next<TItemInterface>(out TItemInterface item) where TItemInterface : class, global::IInventoryItem
		{
			int num;
			return this.Next<TItemInterface>(out item, out num);
		}

		// Token: 0x0600339E RID: 13214 RVA: 0x000C5C9C File Offset: 0x000C3E9C
		public bool Next<TItemInterface>(int datablockUniqueID, out TItemInterface item) where TItemInterface : class, global::IInventoryItem
		{
			int num;
			return this.Next<TItemInterface>(datablockUniqueID, out item, out num);
		}

		// Token: 0x0600339F RID: 13215 RVA: 0x000C5CB4 File Offset: 0x000C3EB4
		public bool Next<TItemInterface>(global::ItemDataBlock datablock, out TItemInterface item) where TItemInterface : class, global::IInventoryItem
		{
			int num;
			return this.Next<TItemInterface>(datablock.uniqueID, out item, out num);
		}

		// Token: 0x04001C79 RID: 7289
		private global::Inventory.Collection<global::InventoryItem>.OccupiedCollection.Enumerator baseEnumerator;
	}

	// Token: 0x02000648 RID: 1608
	public struct OccupiedReverseIterator : global::System.IDisposable
	{
		// Token: 0x060033A0 RID: 13216 RVA: 0x000C5CD0 File Offset: 0x000C3ED0
		public OccupiedReverseIterator(global::Inventory inventory)
		{
			this.baseEnumerator = inventory.collection.OccupiedReverseEnumerator;
		}

		// Token: 0x060033A1 RID: 13217 RVA: 0x000C5CE4 File Offset: 0x000C3EE4
		public void Reset()
		{
			this.baseEnumerator.Reset();
		}

		// Token: 0x17000AC5 RID: 2757
		// (get) Token: 0x060033A2 RID: 13218 RVA: 0x000C5CF4 File Offset: 0x000C3EF4
		public global::IInventoryItem item
		{
			get
			{
				return this.baseEnumerator.Current.iface;
			}
		}

		// Token: 0x17000AC6 RID: 2758
		// (get) Token: 0x060033A3 RID: 13219 RVA: 0x000C5D08 File Offset: 0x000C3F08
		internal global::InventoryItem inventoryItem
		{
			get
			{
				return this.baseEnumerator.Current;
			}
		}

		// Token: 0x17000AC7 RID: 2759
		// (get) Token: 0x060033A4 RID: 13220 RVA: 0x000C5D18 File Offset: 0x000C3F18
		public int slot
		{
			get
			{
				return this.baseEnumerator.Slot;
			}
		}

		// Token: 0x060033A5 RID: 13221 RVA: 0x000C5D28 File Offset: 0x000C3F28
		public bool Next()
		{
			return this.baseEnumerator.MoveNext();
		}

		// Token: 0x060033A6 RID: 13222 RVA: 0x000C5D38 File Offset: 0x000C3F38
		public void Dispose()
		{
			this.baseEnumerator.Dispose();
		}

		// Token: 0x060033A7 RID: 13223 RVA: 0x000C5D48 File Offset: 0x000C3F48
		internal bool Next(out global::InventoryItem item, out int slot)
		{
			if (this.Next())
			{
				slot = this.baseEnumerator.Slot;
				item = this.baseEnumerator.Current;
				return true;
			}
			slot = -1;
			item = null;
			return false;
		}

		// Token: 0x060033A8 RID: 13224 RVA: 0x000C5D84 File Offset: 0x000C3F84
		internal bool Next(int datablockUniqueID, out global::InventoryItem item, out int slot)
		{
			while (this.Next(out item, out slot))
			{
				if (item.datablockUniqueID == datablockUniqueID)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060033A9 RID: 13225 RVA: 0x000C5DB4 File Offset: 0x000C3FB4
		internal bool Next(global::ItemDataBlock datablock, out global::InventoryItem item, out int slot)
		{
			return this.Next(datablock.uniqueID, out item, out slot);
		}

		// Token: 0x060033AA RID: 13226 RVA: 0x000C5DC4 File Offset: 0x000C3FC4
		public bool Next(out global::IInventoryItem item, out int slot)
		{
			global::InventoryItem inventoryItem;
			if (this.Next(out inventoryItem, out slot))
			{
				item = inventoryItem.iface;
				return true;
			}
			item = null;
			return false;
		}

		// Token: 0x060033AB RID: 13227 RVA: 0x000C5DF0 File Offset: 0x000C3FF0
		public bool Next(int datablockUniqueID, out global::IInventoryItem item, out int slot)
		{
			global::InventoryItem inventoryItem;
			if (this.Next(datablockUniqueID, out inventoryItem, out slot))
			{
				item = inventoryItem.iface;
				return true;
			}
			item = null;
			return false;
		}

		// Token: 0x060033AC RID: 13228 RVA: 0x000C5E1C File Offset: 0x000C401C
		internal bool Next(global::ItemDataBlock datablock, out global::IInventoryItem item, out int slot)
		{
			return this.Next(datablock.uniqueID, out item, out slot);
		}

		// Token: 0x060033AD RID: 13229 RVA: 0x000C5E2C File Offset: 0x000C402C
		public bool Next<TItemInterface>(out TItemInterface item, out int slot) where TItemInterface : class, global::IInventoryItem
		{
			global::IInventoryItem inventoryItem;
			while (this.Next(out inventoryItem, out slot))
			{
				if (inventoryItem is TItemInterface)
				{
					item = (TItemInterface)((object)this.inventoryItem.iface);
					return true;
				}
			}
			item = (TItemInterface)((object)null);
			return false;
		}

		// Token: 0x060033AE RID: 13230 RVA: 0x000C5E84 File Offset: 0x000C4084
		public bool Next<TItemInterface>(int datablockUniqueID, out TItemInterface item, out int slot) where TItemInterface : class, global::IInventoryItem
		{
			global::IInventoryItem inventoryItem;
			while (this.Next(datablockUniqueID, out inventoryItem, out slot))
			{
				if (inventoryItem is TItemInterface)
				{
					item = (TItemInterface)((object)this.inventoryItem.iface);
					return true;
				}
			}
			item = (TItemInterface)((object)null);
			return false;
		}

		// Token: 0x060033AF RID: 13231 RVA: 0x000C5EDC File Offset: 0x000C40DC
		public bool Next<TItemInterface>(global::ItemDataBlock datablock, out TItemInterface item, out int slot) where TItemInterface : class, global::IInventoryItem
		{
			return this.Next<TItemInterface>(datablock.uniqueID, out item, out slot);
		}

		// Token: 0x060033B0 RID: 13232 RVA: 0x000C5EEC File Offset: 0x000C40EC
		public bool Next(out int slot)
		{
			global::InventoryItem inventoryItem;
			return this.Next(out inventoryItem, out slot);
		}

		// Token: 0x060033B1 RID: 13233 RVA: 0x000C5F04 File Offset: 0x000C4104
		public bool Next(int datablockUniqueID, out int slot)
		{
			global::InventoryItem inventoryItem;
			return this.Next(out inventoryItem, out slot);
		}

		// Token: 0x060033B2 RID: 13234 RVA: 0x000C5F1C File Offset: 0x000C411C
		public bool Next(global::ItemDataBlock datablock, out int slot)
		{
			global::InventoryItem inventoryItem;
			return this.Next(datablock.uniqueID, out inventoryItem, out slot);
		}

		// Token: 0x060033B3 RID: 13235 RVA: 0x000C5F38 File Offset: 0x000C4138
		public bool Next<TItemInterface>(out int slot) where TItemInterface : class, global::IInventoryItem
		{
			TItemInterface titemInterface;
			return this.Next<TItemInterface>(out titemInterface, out slot);
		}

		// Token: 0x060033B4 RID: 13236 RVA: 0x000C5F50 File Offset: 0x000C4150
		public bool Next<TItemInterface>(int datablockUniqueID, out int slot) where TItemInterface : class, global::IInventoryItem
		{
			TItemInterface titemInterface;
			return this.Next<TItemInterface>(out titemInterface, out slot);
		}

		// Token: 0x060033B5 RID: 13237 RVA: 0x000C5F68 File Offset: 0x000C4168
		public bool Next<TItemInterface>(global::ItemDataBlock datablock, out int slot) where TItemInterface : class, global::IInventoryItem
		{
			TItemInterface titemInterface;
			return this.Next<TItemInterface>(datablock.uniqueID, out titemInterface, out slot);
		}

		// Token: 0x060033B6 RID: 13238 RVA: 0x000C5F84 File Offset: 0x000C4184
		internal bool Next(out global::InventoryItem item)
		{
			int num;
			return this.Next(out item, out num);
		}

		// Token: 0x060033B7 RID: 13239 RVA: 0x000C5F9C File Offset: 0x000C419C
		internal bool Next(int datablockUniqueID, out global::InventoryItem item)
		{
			int num;
			return this.Next(datablockUniqueID, out item, out num);
		}

		// Token: 0x060033B8 RID: 13240 RVA: 0x000C5FB4 File Offset: 0x000C41B4
		internal bool Next(global::ItemDataBlock datablock, out global::InventoryItem item)
		{
			int num;
			return this.Next(datablock.uniqueID, out item, out num);
		}

		// Token: 0x060033B9 RID: 13241 RVA: 0x000C5FD0 File Offset: 0x000C41D0
		public bool Next(out global::IInventoryItem item)
		{
			int num;
			return this.Next(out item, out num);
		}

		// Token: 0x060033BA RID: 13242 RVA: 0x000C5FE8 File Offset: 0x000C41E8
		public bool Next(int datablockUniqueID, out global::IInventoryItem item)
		{
			int num;
			return this.Next(datablockUniqueID, out item, out num);
		}

		// Token: 0x060033BB RID: 13243 RVA: 0x000C6000 File Offset: 0x000C4200
		internal bool Next(global::ItemDataBlock datablock, out global::IInventoryItem item)
		{
			int num;
			return this.Next(datablock.uniqueID, out item, out num);
		}

		// Token: 0x060033BC RID: 13244 RVA: 0x000C601C File Offset: 0x000C421C
		public bool Next<TItemInterface>(out TItemInterface item) where TItemInterface : class, global::IInventoryItem
		{
			int num;
			return this.Next<TItemInterface>(out item, out num);
		}

		// Token: 0x060033BD RID: 13245 RVA: 0x000C6034 File Offset: 0x000C4234
		public bool Next<TItemInterface>(int datablockUniqueID, out TItemInterface item) where TItemInterface : class, global::IInventoryItem
		{
			int num;
			return this.Next<TItemInterface>(datablockUniqueID, out item, out num);
		}

		// Token: 0x060033BE RID: 13246 RVA: 0x000C604C File Offset: 0x000C424C
		public bool Next<TItemInterface>(global::ItemDataBlock datablock, out TItemInterface item) where TItemInterface : class, global::IInventoryItem
		{
			int num;
			return this.Next<TItemInterface>(datablock.uniqueID, out item, out num);
		}

		// Token: 0x04001C7A RID: 7290
		private global::Inventory.Collection<global::InventoryItem>.OccupiedCollection.ReverseEnumerator baseEnumerator;
	}

	// Token: 0x02000649 RID: 1609
	private static class Payload
	{
		// Token: 0x060033BF RID: 13247 RVA: 0x000C6068 File Offset: 0x000C4268
		private static bool StackUsesSlot(ref global::Inventory.Payload.StackArguments args, ref global::Inventory.Payload.StackWork work)
		{
			if (work.instance.datablockUniqueID != args.datablockUID)
			{
				return false;
			}
			int useCount = args.useCount;
			args.useCount -= work.instance.AddUses(args.useCount);
			if (useCount != args.useCount)
			{
				args.collection.MarkDirty(work.slot);
				if (args.useCount == 0)
				{
					return true;
				}
				if (!work.gotFirstUsage)
				{
					work.firstUsage = work.instance;
					work.gotFirstUsage = true;
				}
			}
			return false;
		}

		// Token: 0x060033C0 RID: 13248 RVA: 0x000C60FC File Offset: 0x000C42FC
		private static global::Inventory.Payload.StackResult StackUses(ref global::Inventory.Payload.StackArguments args, ref global::Inventory.Payload.RangeArray.Holder ranges, out global::InventoryItem item)
		{
			if (ranges.Count == 0)
			{
				item = null;
				return global::Inventory.Payload.StackResult.NoRange;
			}
			if ((byte)(args.prefFlags & global::Inventory.Slot.PreferenceFlags.Stack) != 8)
			{
				item = null;
				return global::Inventory.Payload.StackResult.NoneNotMarked;
			}
			if (args.splittable)
			{
				global::Inventory.Payload.StackWork stackWork;
				stackWork.gotFirstUsage = false;
				stackWork.firstUsage = null;
				int useCount = args.useCount;
				bool flag = false;
				int num = -1;
				global::Inventory.Collection<global::InventoryItem>.OccupiedCollection.Enumerator enumerator = default(global::Inventory.Collection<global::InventoryItem>.OccupiedCollection.Enumerator);
				try
				{
					for (int i = 0; i < ranges.Count; i++)
					{
						if (ranges.Range[i].Count == 1)
						{
							if (args.collection.Get(stackWork.slot = ranges.Range[i].Start, out stackWork.instance) && global::Inventory.Payload.StackUsesSlot(ref args, ref stackWork))
							{
								item = ((!stackWork.gotFirstUsage) ? stackWork.instance : stackWork.firstUsage);
								return global::Inventory.Payload.StackResult.Complete;
							}
						}
						else
						{
							if (flag)
							{
								if (ranges.Range[i].Start < num)
								{
									enumerator.Reset();
								}
								else if (ranges.Range[i].Start == num)
								{
									stackWork.slot = num;
									stackWork.instance = enumerator.Current;
									if (global::Inventory.Payload.StackUsesSlot(ref args, ref stackWork))
									{
										item = ((!stackWork.gotFirstUsage) ? stackWork.instance : stackWork.firstUsage);
										return global::Inventory.Payload.StackResult.Complete;
									}
								}
							}
							else
							{
								enumerator = args.collection.OccupiedEnumerator;
								flag = true;
							}
							bool flag2;
							while (flag2 = enumerator.MoveNext())
							{
								num = enumerator.Slot;
								if (ranges.Range[i].Start <= num)
								{
									if (num - ranges.Range[i].Start >= ranges.Range[i].Count)
									{
										break;
									}
									stackWork.slot = num;
									stackWork.instance = enumerator.Current;
									if (global::Inventory.Payload.StackUsesSlot(ref args, ref stackWork))
									{
										item = ((!stackWork.gotFirstUsage) ? stackWork.instance : stackWork.firstUsage);
										return global::Inventory.Payload.StackResult.Complete;
									}
								}
							}
							if (!flag2)
							{
								num = 0x101;
							}
						}
					}
				}
				finally
				{
					if (flag)
					{
						enumerator.Dispose();
					}
				}
				if (stackWork.gotFirstUsage)
				{
					item = stackWork.firstUsage;
					return (args.useCount >= useCount) ? global::Inventory.Payload.StackResult.None_FoundFull : global::Inventory.Payload.StackResult.Partial;
				}
				item = null;
				return global::Inventory.Payload.StackResult.None;
			}
			item = null;
			return global::Inventory.Payload.StackResult.NoneUnsplittable;
		}

		// Token: 0x060033C1 RID: 13249 RVA: 0x000C63D0 File Offset: 0x000C45D0
		private static bool AssignItem(ref global::Inventory.Payload.Assignment args)
		{
			if (args.inventory.CheckSlotFlagsAgainstSlot(args.datablock._itemFlags, args.slot) && args.item.CanMoveToSlot(args.inventory, args.slot))
			{
				args.attemptsMade++;
				if (args.collection.Occupy(args.slot, args.item))
				{
					if (!args.fresh && args.item.inventory)
					{
						args.item.inventory.RemoveItem(args.item.slot);
					}
					args.item.SetUses(args.uses);
					args.item.OnAddedTo(args.inventory, args.slot);
					args.inventory.ItemAdded(args.slot, args.item.iface);
					return true;
				}
			}
			return false;
		}

		// Token: 0x060033C2 RID: 13250 RVA: 0x000C64C8 File Offset: 0x000C46C8
		private static bool AssignItemInsideRanges(ref global::Inventory.Collection<global::InventoryItem>.VacantCollection.Enumerator enumerator, ref global::Inventory.Payload.RangeArray.Holder ranges, ref global::Inventory.Payload.Assignment args)
		{
			int i = 0;
			while (i < ranges.Count)
			{
				if (ranges.Range[i].Count != 1)
				{
					goto IL_5D;
				}
				args.slot = ranges.Range[i].Start;
				if (!args.collection.IsOccupied(args.slot))
				{
					if (global::Inventory.Payload.AssignItem(ref args))
					{
						return true;
					}
					goto IL_5D;
				}
				IL_DB:
				i++;
				continue;
				IL_5D:
				enumerator.Reset();
				while (enumerator.MoveNext())
				{
					int slot = enumerator.Current;
					args.slot = slot;
					sbyte b = ranges.Range[i].ContainEx(args.slot);
					bool flag;
					switch (b + 1)
					{
					case 0:
						continue;
					case 1:
						goto IL_AA;
					case 2:
						flag = true;
						break;
					default:
						goto IL_AA;
					}
					IL_B8:
					if (flag)
					{
						break;
					}
					if (global::Inventory.Payload.AssignItem(ref args))
					{
						return true;
					}
					continue;
					IL_AA:
					flag = false;
					goto IL_B8;
				}
				goto IL_DB;
			}
			return false;
		}

		// Token: 0x060033C3 RID: 13251 RVA: 0x000C65C4 File Offset: 0x000C47C4
		public static global::Inventory.Payload.Result AddItem(global::Inventory inventory, ref global::Inventory.Addition addition, global::Inventory.Payload.Opt options, global::InventoryItem reuseItem)
		{
			global::Inventory.Payload.Result result;
			if ((byte)(options & (global::Inventory.Payload.Opt.DoNotStack | global::Inventory.Payload.Opt.DoNotAssign)) == 3 || (byte)(options & (global::Inventory.Payload.Opt.IgnoreSlotOffset | global::Inventory.Payload.Opt.RestrictToOffset)) == 0xC)
			{
				result.item = null;
				result.flags = global::Inventory.Payload.Result.Flags.OptionsResultedInNoOp;
				result.usesRemaining = 0;
			}
			else
			{
				global::ItemDataBlock itemDataBlock = addition.ItemDataBlock;
				if (!itemDataBlock)
				{
					result.item = null;
					result.flags = global::Inventory.Payload.Result.Flags.NoItemDatablock;
					result.usesRemaining = 0;
					return result;
				}
				global::Inventory.Slot.KindFlags kindFlags = addition.SlotPreference.PrimaryKindFlags;
				global::Inventory.Slot.KindFlags kindFlags2 = addition.SlotPreference.SecondaryKindFlags;
				global::Inventory.Slot.Range explicitSlot;
				if ((byte)(options & global::Inventory.Payload.Opt.IgnoreSlotOffset) == 4)
				{
					explicitSlot = default(global::Inventory.Slot.Range);
				}
				else
				{
					explicitSlot = global::Inventory.Payload.RangeArray.CalculateExplicitSlotPosition(inventory, ref addition.SlotPreference);
				}
				bool flag = (byte)(options & global::Inventory.Payload.Opt.RestrictToOffset) == 8;
				bool any = explicitSlot.Any;
				if (flag && !any)
				{
					result.item = null;
					result.flags = global::Inventory.Payload.Result.Flags.MissingRequiredOffset;
					result.usesRemaining = 0;
					return result;
				}
				if (flag)
				{
					global::Inventory.Payload.RangeArray.FillTemporaryRanges(ref global::Inventory.Payload.RangeArray.Primary, inventory, (global::Inventory.Slot.KindFlags)0, explicitSlot, true);
					global::Inventory.Payload.RangeArray.FillTemporaryRanges(ref global::Inventory.Payload.RangeArray.Secondary, inventory, (global::Inventory.Slot.KindFlags)0, explicitSlot, false);
				}
				else
				{
					global::Inventory.Payload.RangeArray.FillTemporaryRanges(ref global::Inventory.Payload.RangeArray.Primary, inventory, kindFlags, explicitSlot, true);
					global::Inventory.Payload.RangeArray.FillTemporaryRanges(ref global::Inventory.Payload.RangeArray.Secondary, inventory, kindFlags2, explicitSlot, false);
				}
				int num;
				if (global::Inventory.Payload.RangeArray.Primary.Count == 0)
				{
					kindFlags = (global::Inventory.Slot.KindFlags)0;
					if (global::Inventory.Payload.RangeArray.Secondary.Count == 0)
					{
						kindFlags2 = (global::Inventory.Slot.KindFlags)0;
						num = 0;
					}
					else
					{
						num = global::Inventory.Payload.RangeArray.Secondary.Count;
					}
				}
				else if (global::Inventory.Payload.RangeArray.Secondary.Count == 0)
				{
					kindFlags2 = (global::Inventory.Slot.KindFlags)0;
					num = global::Inventory.Payload.RangeArray.Primary.Count;
				}
				else
				{
					num = global::Inventory.Payload.RangeArray.Primary.Count + global::Inventory.Payload.RangeArray.Secondary.Count;
				}
				if (num == 0 || (!any && ((byte)(kindFlags | kindFlags2) & 7) == 0))
				{
					result.item = null;
					result.flags = global::Inventory.Payload.Result.Flags.NoSlotRanges;
					result.usesRemaining = 0;
				}
				else
				{
					int maxUses = itemDataBlock._maxUses;
					bool flag2 = (byte)(options & global::Inventory.Payload.Opt.ReuseItem) == 0x10;
					if (flag2 && (object.ReferenceEquals(reuseItem, null) || (itemDataBlock.untransferable && reuseItem.inventory != inventory)))
					{
						result.flags = global::Inventory.Payload.Result.Flags.FailedToReuse;
						result.item = null;
						result.usesRemaining = 0;
					}
					else
					{
						global::Inventory.Collection<global::InventoryItem> collection = inventory.collection;
						result.usesRemaining = ((!flag2) ? addition.UsesQuantity.CalculateCount(itemDataBlock) : reuseItem.uses);
						global::InventoryItem item;
						global::Inventory.Payload.StackResult stackResult2;
						if ((byte)(options & global::Inventory.Payload.Opt.DoNotStack) != 1 && (byte)(addition.SlotPreference.Flags & global::Inventory.Slot.PreferenceFlags.Stack) == 8)
						{
							global::Inventory.Payload.StackArguments stackArguments;
							stackArguments.collection = collection;
							stackArguments.datablockUID = itemDataBlock.uniqueID;
							stackArguments.splittable = itemDataBlock.IsSplittable();
							stackArguments.useCount = result.usesRemaining;
							stackArguments.prefFlags = addition.SlotPreference.Flags;
							global::InventoryItem inventoryItem;
							global::Inventory.Payload.StackResult stackResult = global::Inventory.Payload.StackUses(ref stackArguments, ref global::Inventory.Payload.RangeArray.Primary, out inventoryItem);
							if (stackResult == global::Inventory.Payload.StackResult.NoneUnsplittable || stackResult == global::Inventory.Payload.StackResult.Complete)
							{
								global::InventoryItem inventoryItem2 = item = inventoryItem;
								stackResult2 = stackResult;
							}
							else
							{
								global::InventoryItem inventoryItem2;
								global::Inventory.Payload.StackResult stackResult3 = global::Inventory.Payload.StackUses(ref stackArguments, ref global::Inventory.Payload.RangeArray.Secondary, out inventoryItem2);
								if (stackResult > stackResult3)
								{
									item = (inventoryItem ?? inventoryItem2);
									stackResult2 = stackResult;
								}
								else
								{
									item = (inventoryItem ?? inventoryItem2);
									stackResult2 = stackResult3;
								}
							}
							result.usesRemaining = stackArguments.useCount;
						}
						else
						{
							item = null;
							stackResult2 = global::Inventory.Payload.StackResult.NoneNotMarked;
						}
						if (stackResult2 == global::Inventory.Payload.StackResult.Complete)
						{
							result.item = item;
							result.flags = (global::Inventory.Payload.Result.Flags.Complete | global::Inventory.Payload.Result.Flags.Stacked);
						}
						else
						{
							if (stackResult2 == global::Inventory.Payload.StackResult.Partial)
							{
								result.item = item;
								result.flags = global::Inventory.Payload.Result.Flags.Stacked;
							}
							else
							{
								result.flags = global::Inventory.Payload.Result.Flags.OptionsResultedInNoOp;
							}
							if ((byte)(options & global::Inventory.Payload.Opt.DoNotAssign) != 2)
							{
								if (collection.HasNoVacancy)
								{
									result.item = item;
									result.flags |= global::Inventory.Payload.Result.Flags.NoVacancy;
								}
								else
								{
									global::Inventory.Payload.Assignment assignment;
									assignment.inventory = inventory;
									assignment.collection = collection;
									assignment.fresh = !flag2;
									assignment.item = ((!assignment.fresh) ? reuseItem : (itemDataBlock.CreateItem() as global::InventoryItem));
									assignment.uses = result.usesRemaining;
									assignment.datablock = itemDataBlock;
									if (!flag2 && object.ReferenceEquals(assignment.item, null))
									{
										result.item = item;
										result.flags |= ((!assignment.fresh) ? global::Inventory.Payload.Result.Flags.FailedToReuse : global::Inventory.Payload.Result.Flags.FailedToCreate);
									}
									else
									{
										assignment.slot = -1;
										assignment.attemptsMade = 0;
										global::Inventory.Collection<global::InventoryItem>.VacantCollection.Enumerator vacantEnumerator = collection.VacantEnumerator;
										bool flag3;
										try
										{
											flag3 = (global::Inventory.Payload.AssignItemInsideRanges(ref vacantEnumerator, ref global::Inventory.Payload.RangeArray.Primary, ref assignment) || global::Inventory.Payload.AssignItemInsideRanges(ref vacantEnumerator, ref global::Inventory.Payload.RangeArray.Secondary, ref assignment));
										}
										finally
										{
											vacantEnumerator.Dispose();
										}
										if (flag3)
										{
											result.flags |= (global::Inventory.Payload.Result.Flags.Complete | global::Inventory.Payload.Result.Flags.AssignedInstance);
											result.item = assignment.item;
											result.usesRemaining -= result.item.uses;
										}
										else if (assignment.attemptsMade > 0)
										{
											result.flags |= global::Inventory.Payload.Result.Flags.NoVacancy;
											result.item = item;
										}
										else
										{
											result.flags |= global::Inventory.Payload.Result.Flags.NoSlotRanges;
											result.item = item;
										}
									}
								}
							}
							else
							{
								result.item = item;
								if (result.flags == global::Inventory.Payload.Result.Flags.OptionsResultedInNoOp)
								{
									result.flags = global::Inventory.Payload.Result.Flags.MissingRequiredOffset;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x04001C7B RID: 7291
		private const global::Inventory.Payload.Opt NoOp1_Mask = global::Inventory.Payload.Opt.DoNotStack | global::Inventory.Payload.Opt.DoNotAssign;

		// Token: 0x04001C7C RID: 7292
		private const global::Inventory.Payload.Opt NoOp2_Mask = global::Inventory.Payload.Opt.IgnoreSlotOffset | global::Inventory.Payload.Opt.RestrictToOffset;

		// Token: 0x0200064A RID: 1610
		public struct Result
		{
			// Token: 0x04001C7D RID: 7293
			public global::InventoryItem item;

			// Token: 0x04001C7E RID: 7294
			public global::Inventory.Payload.Result.Flags flags;

			// Token: 0x04001C7F RID: 7295
			public int usesRemaining;

			// Token: 0x0200064B RID: 1611
			[global::System.Flags]
			public enum Flags : byte
			{
				// Token: 0x04001C81 RID: 7297
				Complete = 0x80,
				// Token: 0x04001C82 RID: 7298
				AssignedInstance = 0x40,
				// Token: 0x04001C83 RID: 7299
				Stacked = 0x20,
				// Token: 0x04001C84 RID: 7300
				NoVacancy = 0x10,
				// Token: 0x04001C85 RID: 7301
				DidNotCreate = 6,
				// Token: 0x04001C86 RID: 7302
				FailedToReuse = 5,
				// Token: 0x04001C87 RID: 7303
				FailedToCreate = 4,
				// Token: 0x04001C88 RID: 7304
				NoSlotRanges = 3,
				// Token: 0x04001C89 RID: 7305
				MissingRequiredOffset = 2,
				// Token: 0x04001C8A RID: 7306
				NoItemDatablock = 1,
				// Token: 0x04001C8B RID: 7307
				OptionsResultedInNoOp = 0
			}
		}

		// Token: 0x0200064C RID: 1612
		[global::System.Flags]
		public enum Opt : byte
		{
			// Token: 0x04001C8D RID: 7309
			DoNotStack = 1,
			// Token: 0x04001C8E RID: 7310
			DoNotAssign = 2,
			// Token: 0x04001C8F RID: 7311
			IgnoreSlotOffset = 4,
			// Token: 0x04001C90 RID: 7312
			RestrictToOffset = 8,
			// Token: 0x04001C91 RID: 7313
			ReuseItem = 0x10,
			// Token: 0x04001C92 RID: 7314
			AllowStackedItemsToBeReturned = 0x20
		}

		// Token: 0x0200064D RID: 1613
		private enum StackResult : byte
		{
			// Token: 0x04001C94 RID: 7316
			None,
			// Token: 0x04001C95 RID: 7317
			NoneNotMarked,
			// Token: 0x04001C96 RID: 7318
			NoneUnsplittable,
			// Token: 0x04001C97 RID: 7319
			NoRange,
			// Token: 0x04001C98 RID: 7320
			None_FoundFull,
			// Token: 0x04001C99 RID: 7321
			Partial,
			// Token: 0x04001C9A RID: 7322
			Complete
		}

		// Token: 0x0200064E RID: 1614
		private struct Assignment
		{
			// Token: 0x04001C9B RID: 7323
			public global::Inventory.Collection<global::InventoryItem> collection;

			// Token: 0x04001C9C RID: 7324
			public global::Inventory inventory;

			// Token: 0x04001C9D RID: 7325
			public global::InventoryItem item;

			// Token: 0x04001C9E RID: 7326
			public global::ItemDataBlock datablock;

			// Token: 0x04001C9F RID: 7327
			public int slot;

			// Token: 0x04001CA0 RID: 7328
			public int uses;

			// Token: 0x04001CA1 RID: 7329
			public bool fresh;

			// Token: 0x04001CA2 RID: 7330
			public int attemptsMade;
		}

		// Token: 0x0200064F RID: 1615
		private static class RangeArray
		{
			// Token: 0x060033C4 RID: 13252 RVA: 0x000C6B50 File Offset: 0x000C4D50
			// Note: this type is marked as 'beforefieldinit'.
			static RangeArray()
			{
			}

			// Token: 0x060033C5 RID: 13253 RVA: 0x000C6B80 File Offset: 0x000C4D80
			public static void FillTemporaryRanges(ref global::Inventory.Payload.RangeArray.Holder temp, global::Inventory inventory, global::Inventory.Slot.KindFlags kindFlags, global::Inventory.Slot.Range explicitSlot, bool insertExplicitSlot)
			{
				kindFlags &= (global::Inventory.Slot.KindFlags.Default | global::Inventory.Slot.KindFlags.Belt | global::Inventory.Slot.KindFlags.Armor);
				temp.Count = 0;
				int num = 0;
				int num2 = 0;
				int gougeIndex;
				if (explicitSlot.Any)
				{
					if (insertExplicitSlot)
					{
						temp.Range[temp.Count++] = explicitSlot;
					}
					gougeIndex = explicitSlot.Start;
				}
				else
				{
					gougeIndex = -1;
				}
				for (global::Inventory.Slot.Kind kind = global::Inventory.Slot.Kind.Default; kind < (global::Inventory.Slot.Kind)3; kind += 1)
				{
					global::Inventory.Slot.KindFlags flag = (global::Inventory.Slot.KindFlags)(1 << (int)kind);
					if (global::Inventory.Payload.RangeArray.CheckSlotKindFlag(inventory, kindFlags, flag, kind, ref num, ref num2))
					{
						temp.Insert(ref num, ref num2, gougeIndex);
					}
				}
			}

			// Token: 0x060033C6 RID: 13254 RVA: 0x000C6C20 File Offset: 0x000C4E20
			public static global::Inventory.Slot.Range CalculateExplicitSlotPosition(global::Inventory inventory, ref global::Inventory.Slot.Preference pref)
			{
				global::Inventory.Slot.Offset offset = pref.Offset;
				if (!offset.Specified)
				{
					return default(global::Inventory.Slot.Range);
				}
				global::Inventory.Slot.Range range;
				if (offset.HasOffsetOfKind)
				{
					if (!inventory.slotRanges.TryGetValue(offset.OffsetOfKind, out range))
					{
						return default(global::Inventory.Slot.Range);
					}
				}
				else
				{
					range = new global::Inventory.Slot.Range(0, inventory.slotCount);
				}
				int slotOffset = offset.SlotOffset;
				if (range.Count > slotOffset)
				{
					return new global::Inventory.Slot.Range(range.Start + slotOffset, 1);
				}
				return default(global::Inventory.Slot.Range);
			}

			// Token: 0x060033C7 RID: 13255 RVA: 0x000C6CBC File Offset: 0x000C4EBC
			private static bool CheckSlotKindFlag(global::Inventory inventory, global::Inventory.Slot.KindFlags flags, global::Inventory.Slot.KindFlags flag, global::Inventory.Slot.Kind kind, ref int start, ref int count)
			{
				global::Inventory.Slot.Range range;
				if ((flags & flag) == flag && inventory.slotRanges.TryGetValue(kind, out range) && range.Any)
				{
					if (range.End <= inventory.slotCount)
					{
						start = range.Start;
						count = range.Count;
						return true;
					}
				}
				return false;
			}

			// Token: 0x04001CA3 RID: 7331
			private const int ArrayElementCount = 6;

			// Token: 0x04001CA4 RID: 7332
			public static global::Inventory.Payload.RangeArray.Holder Primary = new global::Inventory.Payload.RangeArray.Holder(new global::Inventory.Slot.Range[6]);

			// Token: 0x04001CA5 RID: 7333
			public static global::Inventory.Payload.RangeArray.Holder Secondary = new global::Inventory.Payload.RangeArray.Holder(new global::Inventory.Slot.Range[6]);

			// Token: 0x02000650 RID: 1616
			public struct Holder
			{
				// Token: 0x060033C8 RID: 13256 RVA: 0x000C6D20 File Offset: 0x000C4F20
				public Holder(global::Inventory.Slot.Range[] array)
				{
					this.Count = 0;
					this.Range = array;
				}

				// Token: 0x060033C9 RID: 13257 RVA: 0x000C6D30 File Offset: 0x000C4F30
				public void Insert(ref int start, ref int count, int gougeIndex)
				{
					global::Inventory.Slot.Range range = new global::Inventory.Slot.Range(start, count);
					if (gougeIndex != -1)
					{
						global::Inventory.Slot.RangePair rangePair;
						switch (range.Gouge(gougeIndex, out rangePair))
						{
						case 1:
							this.Range[this.Count++] = rangePair.A;
							break;
						case 2:
							this.Range[this.Count++] = rangePair.A;
							this.Range[this.Count++] = rangePair.B;
							break;
						}
					}
					else
					{
						this.Range[this.Count++] = range;
					}
					start = (count = 0);
				}

				// Token: 0x04001CA6 RID: 7334
				public int Count;

				// Token: 0x04001CA7 RID: 7335
				public readonly global::Inventory.Slot.Range[] Range;
			}
		}

		// Token: 0x02000651 RID: 1617
		private struct StackArguments
		{
			// Token: 0x04001CA8 RID: 7336
			public global::Inventory.Collection<global::InventoryItem> collection;

			// Token: 0x04001CA9 RID: 7337
			public global::Inventory.Slot.PreferenceFlags prefFlags;

			// Token: 0x04001CAA RID: 7338
			public int useCount;

			// Token: 0x04001CAB RID: 7339
			public int datablockUID;

			// Token: 0x04001CAC RID: 7340
			public bool splittable;
		}

		// Token: 0x02000652 RID: 1618
		private struct StackWork
		{
			// Token: 0x04001CAD RID: 7341
			public bool gotFirstUsage;

			// Token: 0x04001CAE RID: 7342
			public global::InventoryItem firstUsage;

			// Token: 0x04001CAF RID: 7343
			public int slot;

			// Token: 0x04001CB0 RID: 7344
			public global::InventoryItem instance;
		}
	}

	// Token: 0x02000653 RID: 1619
	private class Report
	{
		// Token: 0x060033CA RID: 13258 RVA: 0x000C6E28 File Offset: 0x000C5028
		public Report()
		{
		}

		// Token: 0x060033CB RID: 13259 RVA: 0x000C6E30 File Offset: 0x000C5030
		// Note: this type is marked as 'beforefieldinit'.
		static Report()
		{
		}

		// Token: 0x060033CC RID: 13260 RVA: 0x000C6E3C File Offset: 0x000C503C
		private static global::Inventory.Report Create()
		{
			global::Inventory.Report report;
			if (global::Inventory.Report.dumpSize > 0)
			{
				report = global::Inventory.Report.dump;
				if (--global::Inventory.Report.dumpSize == 0)
				{
					global::Inventory.Report.dump = null;
				}
				else
				{
					global::Inventory.Report.dump = report.dumpNext;
				}
				report.dumpNext = null;
				report.Disposed = false;
				report.amount = 0;
			}
			else
			{
				report = new global::Inventory.Report();
			}
			return report;
		}

		// Token: 0x060033CD RID: 13261 RVA: 0x000C6EA4 File Offset: 0x000C50A4
		public static void Begin()
		{
			if (global::Inventory.Report.begun)
			{
				throw new global::System.InvalidOperationException();
			}
			global::Inventory.Report.begun = true;
			global::Inventory.Report.totalItemCount = 0;
		}

		// Token: 0x060033CE RID: 13262 RVA: 0x000C6EC4 File Offset: 0x000C50C4
		public static void Take(global::InventoryItem item)
		{
			int uses = item.uses;
			int datablockUniqueID = item.datablockUniqueID;
			global::Inventory.Report report;
			if (global::Inventory.Report.dict.TryGetValue(datablockUniqueID, out report))
			{
				global::Inventory.Report report2 = report.first;
				if (report.splittable)
				{
					int num = report2.amount + uses;
					if (num > item.maxUses)
					{
						global::Inventory.Report report3 = global::Inventory.Report.Create();
						report3.typeNext = report2;
						report3.amount = num - report.maxUses;
						report3.item = item;
						report2.amount = report.maxUses;
						report.first = report3;
						report.length++;
						global::Inventory.Report.totalItemCount++;
					}
					else
					{
						report.first.amount = num;
					}
				}
				else
				{
					global::Inventory.Report report4 = global::Inventory.Report.Create();
					report4.typeNext = report2;
					report4.amount = uses;
					report4.item = item;
					report.first = report4;
					report.length++;
					global::Inventory.Report.totalItemCount++;
				}
			}
			else
			{
				global::ItemDataBlock itemDataBlock = item.datablock;
				if (itemDataBlock.transferable)
				{
					global::Inventory.Report report5 = global::Inventory.Report.Create();
					report5.amount = uses;
					report5.splittable = itemDataBlock.IsSplittable();
					report5.first = report5;
					report5.length = 1;
					report5.datablock = itemDataBlock;
					report5.item = item;
					if (report5.splittable)
					{
						report5.maxUses = item.maxUses;
					}
					global::Inventory.Report.dict.Add(item.datablockUniqueID, report5);
					global::Inventory.Report.totalItemCount++;
				}
			}
		}

		// Token: 0x060033CF RID: 13263 RVA: 0x000C7058 File Offset: 0x000C5258
		public static global::Inventory.Transfer[] Build(global::Inventory.Slot.KindFlags fallbackKindFlags)
		{
			if (!global::Inventory.Report.begun)
			{
				throw new global::System.InvalidOperationException();
			}
			global::Inventory.Transfer[] array = new global::Inventory.Transfer[global::Inventory.Report.totalItemCount];
			int slotNumber = 0;
			foreach (global::System.Collections.Generic.KeyValuePair<int, global::Inventory.Report> keyValuePair in global::Inventory.Report.dict)
			{
				global::Inventory.Report value = keyValuePair.Value;
				global::Inventory.Transfer transfer;
				transfer.addition.Ident = (global::Datablock.Ident)value.datablock;
				int num = value.length;
				value = value.first;
				bool flag = value.splittable;
				for (int i = 0; i < num; i++)
				{
					transfer.addition.SlotPreference = global::Inventory.Slot.Preference.Define(slotNumber, false, fallbackKindFlags);
					transfer.addition.UsesQuantity = global::Inventory.Uses.Quantity.Manual(value.amount);
					transfer.item = value.item;
					array[slotNumber++] = transfer;
					global::Inventory.Report report = value;
					value = value.typeNext;
					if (!report.Disposed)
					{
						report.Disposed = true;
						report.dumpNext = global::Inventory.Report.dump;
						report.first = (report.typeNext = null);
						report.datablock = null;
						report.item = null;
						global::Inventory.Report.dump = report;
						global::Inventory.Report.dumpSize++;
					}
				}
			}
			global::Inventory.Report.dict.Clear();
			global::Inventory.Report.begun = false;
			return array;
		}

		// Token: 0x060033D0 RID: 13264 RVA: 0x000C71E8 File Offset: 0x000C53E8
		public static void Recover()
		{
			if (global::Inventory.Report.begun)
			{
				foreach (global::Inventory.Report report in global::Inventory.Report.dict.Values)
				{
					if (!report.Disposed)
					{
						report.Disposed = true;
						report.dumpNext = global::Inventory.Report.dump;
						report.first = (report.typeNext = null);
						report.datablock = null;
						report.item = null;
						global::Inventory.Report.dump = report;
						global::Inventory.Report.dumpSize++;
					}
				}
				global::Inventory.Report.dict.Clear();
			}
		}

		// Token: 0x04001CB1 RID: 7345
		private int amount;

		// Token: 0x04001CB2 RID: 7346
		private bool Disposed;

		// Token: 0x04001CB3 RID: 7347
		private global::Inventory.Report dumpNext;

		// Token: 0x04001CB4 RID: 7348
		private global::Inventory.Report typeNext;

		// Token: 0x04001CB5 RID: 7349
		private global::Inventory.Report first;

		// Token: 0x04001CB6 RID: 7350
		private global::ItemDataBlock datablock;

		// Token: 0x04001CB7 RID: 7351
		private global::InventoryItem item;

		// Token: 0x04001CB8 RID: 7352
		private bool splittable;

		// Token: 0x04001CB9 RID: 7353
		private int length;

		// Token: 0x04001CBA RID: 7354
		private int maxUses;

		// Token: 0x04001CBB RID: 7355
		private static global::Inventory.Report dump;

		// Token: 0x04001CBC RID: 7356
		private static int dumpSize;

		// Token: 0x04001CBD RID: 7357
		private static readonly global::System.Collections.Generic.Dictionary<int, global::Inventory.Report> dict = new global::System.Collections.Generic.Dictionary<int, global::Inventory.Report>();

		// Token: 0x04001CBE RID: 7358
		private static bool begun;

		// Token: 0x04001CBF RID: 7359
		private static int totalItemCount;
	}

	// Token: 0x02000654 RID: 1620
	public static class Slot
	{
		// Token: 0x04001CC0 RID: 7360
		public const global::Inventory.Slot.Kind KindBegin = global::Inventory.Slot.Kind.Default;

		// Token: 0x04001CC1 RID: 7361
		public const global::Inventory.Slot.Kind KindLast = global::Inventory.Slot.Kind.Armor;

		// Token: 0x04001CC2 RID: 7362
		public const global::Inventory.Slot.Kind KindFirst = global::Inventory.Slot.Kind.Default;

		// Token: 0x04001CC3 RID: 7363
		public const global::Inventory.Slot.Kind KindEnd = (global::Inventory.Slot.Kind)3;

		// Token: 0x04001CC4 RID: 7364
		public const int KindCount = 3;

		// Token: 0x04001CC5 RID: 7365
		private const global::Inventory.Slot.Kind HiddenKind_Explicit = (global::Inventory.Slot.Kind)4;

		// Token: 0x04001CC6 RID: 7366
		private const global::Inventory.Slot.Kind HiddenKind_Null = (global::Inventory.Slot.Kind)5;

		// Token: 0x04001CC7 RID: 7367
		public const int NumberOfKinds = 3;

		// Token: 0x04001CC8 RID: 7368
		public const global::Inventory.Slot.KindFlags KindFlagsMask_Kind = global::Inventory.Slot.KindFlags.Default | global::Inventory.Slot.KindFlags.Belt | global::Inventory.Slot.KindFlags.Armor;

		// Token: 0x04001CC9 RID: 7369
		private const int PrimaryShift = 4;

		// Token: 0x02000655 RID: 1621
		public enum Kind : byte
		{
			// Token: 0x04001CCB RID: 7371
			Default,
			// Token: 0x04001CCC RID: 7372
			Belt,
			// Token: 0x04001CCD RID: 7373
			Armor
		}

		// Token: 0x02000656 RID: 1622
		public struct KindDictionary<TValue> : global::System.Collections.IEnumerable, global::System.Collections.Generic.IDictionary<global::Inventory.Slot.Kind, TValue>, global::System.Collections.Generic.ICollection<global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, TValue>>, global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, TValue>>
		{
			// Token: 0x060033D1 RID: 13265 RVA: 0x000C72AC File Offset: 0x000C54AC
			void global::System.Collections.Generic.IDictionary<global::Inventory.Slot.Kind, !0>.Add(global::Inventory.Slot.Kind key, TValue value)
			{
				if (this.GetMember(key).Defined)
				{
					throw new global::System.ArgumentException("Key was already set to a value");
				}
				this.SetMember(key, new global::Inventory.Slot.KindDictionary<TValue>.Member(value));
				this.count += 1;
			}

			// Token: 0x17000AC8 RID: 2760
			// (get) Token: 0x060033D2 RID: 13266 RVA: 0x000C72F4 File Offset: 0x000C54F4
			global::System.Collections.Generic.ICollection<global::Inventory.Slot.Kind> global::System.Collections.Generic.IDictionary<global::Inventory.Slot.Kind, !0>.Keys
			{
				get
				{
					global::Inventory.Slot.Kind[] array = new global::Inventory.Slot.Kind[(int)this.count];
					int num = 0;
					for (global::Inventory.Slot.Kind kind = global::Inventory.Slot.Kind.Default; kind < (global::Inventory.Slot.Kind)3; kind += 1)
					{
						if (this.GetMember(kind).Defined)
						{
							array[num++] = kind;
						}
					}
					return array;
				}
			}

			// Token: 0x060033D3 RID: 13267 RVA: 0x000C7340 File Offset: 0x000C5540
			void global::System.Collections.Generic.ICollection<global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, !0>>.Add(global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, TValue> item)
			{
				this[item.Key] = item.Value;
			}

			// Token: 0x17000AC9 RID: 2761
			// (get) Token: 0x060033D4 RID: 13268 RVA: 0x000C7358 File Offset: 0x000C5558
			global::System.Collections.Generic.ICollection<TValue> global::System.Collections.Generic.IDictionary<global::Inventory.Slot.Kind, !0>.Values
			{
				get
				{
					TValue[] array = new TValue[(int)this.count];
					int num = 0;
					for (global::Inventory.Slot.Kind kind = global::Inventory.Slot.Kind.Default; kind < (global::Inventory.Slot.Kind)3; kind += 1)
					{
						global::Inventory.Slot.KindDictionary<TValue>.Member member = this.GetMember(kind);
						if (member.Defined)
						{
							array[num++] = member.Value;
						}
					}
					return array;
				}
			}

			// Token: 0x060033D5 RID: 13269 RVA: 0x000C73B0 File Offset: 0x000C55B0
			bool global::System.Collections.Generic.ICollection<global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, !0>>.Contains(global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, TValue> item)
			{
				bool result;
				try
				{
					global::Inventory.Slot.KindDictionary<TValue>.Member member = this.GetMember(item.Key);
					if (!member.Defined)
					{
						result = false;
					}
					else
					{
						global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, TValue> keyValuePair = new global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, TValue>(item.Key, member.Value);
						result = object.Equals(keyValuePair, item);
					}
				}
				catch
				{
					result = false;
				}
				return result;
			}

			// Token: 0x060033D6 RID: 13270 RVA: 0x000C743C File Offset: 0x000C563C
			void global::System.Collections.Generic.ICollection<global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, !0>>.CopyTo(global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, TValue>[] array, int arrayIndex)
			{
				for (global::Inventory.Slot.Kind kind = global::Inventory.Slot.Kind.Default; kind < (global::Inventory.Slot.Kind)3; kind += 1)
				{
					global::Inventory.Slot.KindDictionary<TValue>.Member member = this.GetMember(kind);
					if (member.Defined)
					{
						array[arrayIndex++] = new global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, TValue>(kind, member.Value);
					}
				}
			}

			// Token: 0x17000ACA RID: 2762
			// (get) Token: 0x060033D7 RID: 13271 RVA: 0x000C7490 File Offset: 0x000C5690
			bool global::System.Collections.Generic.ICollection<global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, !0>>.IsReadOnly
			{
				get
				{
					return false;
				}
			}

			// Token: 0x060033D8 RID: 13272 RVA: 0x000C7494 File Offset: 0x000C5694
			bool global::System.Collections.Generic.ICollection<global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, !0>>.Remove(global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, TValue> item)
			{
				bool result;
				try
				{
					global::Inventory.Slot.KindDictionary<TValue>.Member member = this.GetMember(item.Key);
					if (!member.Defined)
					{
						result = false;
					}
					else
					{
						global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, TValue> keyValuePair = new global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, TValue>(item.Key, member.Value);
						if (object.Equals(keyValuePair, item))
						{
							this.SetMember(item.Key, default(global::Inventory.Slot.KindDictionary<TValue>.Member));
							result = true;
						}
						else
						{
							result = false;
						}
					}
				}
				catch
				{
					result = false;
				}
				return result;
			}

			// Token: 0x060033D9 RID: 13273 RVA: 0x000C7540 File Offset: 0x000C5740
			global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, TValue>> global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, !0>>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x060033DA RID: 13274 RVA: 0x000C7550 File Offset: 0x000C5750
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x060033DB RID: 13275 RVA: 0x000C7560 File Offset: 0x000C5760
			private global::Inventory.Slot.KindDictionary<TValue>.Member GetMember(global::Inventory.Slot.Kind kind)
			{
				switch (kind)
				{
				case global::Inventory.Slot.Kind.Default:
					return this.mDefault;
				case global::Inventory.Slot.Kind.Belt:
					return this.mBelt;
				case global::Inventory.Slot.Kind.Armor:
					return this.mArmor;
				default:
					throw new global::System.ArgumentNullException("Unimplemented kind");
				}
			}

			// Token: 0x060033DC RID: 13276 RVA: 0x000C75A8 File Offset: 0x000C57A8
			private void SetMember(global::Inventory.Slot.Kind kind, global::Inventory.Slot.KindDictionary<TValue>.Member member)
			{
				switch (kind)
				{
				case global::Inventory.Slot.Kind.Default:
					this.mDefault = member;
					break;
				case global::Inventory.Slot.Kind.Belt:
					this.mBelt = member;
					break;
				case global::Inventory.Slot.Kind.Armor:
					this.mArmor = member;
					break;
				default:
					throw new global::System.ArgumentNullException("Unimplemented kind");
				}
			}

			// Token: 0x17000ACB RID: 2763
			// (get) Token: 0x060033DD RID: 13277 RVA: 0x000C7600 File Offset: 0x000C5800
			public int Count
			{
				get
				{
					return (int)this.count;
				}
			}

			// Token: 0x17000ACC RID: 2764
			public TValue this[global::Inventory.Slot.Kind kind]
			{
				get
				{
					global::Inventory.Slot.KindDictionary<TValue>.Member member = this.GetMember(kind);
					if (!member.Defined)
					{
						throw new global::System.Collections.Generic.KeyNotFoundException();
					}
					return member.Value;
				}
				set
				{
					if (!this.GetMember(kind).Defined)
					{
						this.SetMember(kind, new global::Inventory.Slot.KindDictionary<TValue>.Member(value));
						this.count += 1;
					}
					else
					{
						this.SetMember(kind, new global::Inventory.Slot.KindDictionary<TValue>.Member(value));
					}
				}
			}

			// Token: 0x060033E0 RID: 13280 RVA: 0x000C768C File Offset: 0x000C588C
			public bool ContainsKey(global::Inventory.Slot.Kind key)
			{
				return key >= global::Inventory.Slot.Kind.Default && key < (global::Inventory.Slot.Kind)3 && this.GetMember(key).Defined;
			}

			// Token: 0x060033E1 RID: 13281 RVA: 0x000C76BC File Offset: 0x000C58BC
			public bool Remove(global::Inventory.Slot.Kind key)
			{
				if (this.GetMember(key).Defined)
				{
					this.SetMember(key, default(global::Inventory.Slot.KindDictionary<TValue>.Member));
					this.count -= 1;
					return true;
				}
				return false;
			}

			// Token: 0x060033E2 RID: 13282 RVA: 0x000C7700 File Offset: 0x000C5900
			public void Clear()
			{
				global::Inventory.Slot.Kind kind = global::Inventory.Slot.Kind.Default;
				while ((int)this.count > 0 && kind < (global::Inventory.Slot.Kind)3)
				{
					this.Remove(kind);
					kind += 1;
				}
			}

			// Token: 0x060033E3 RID: 13283 RVA: 0x000C7734 File Offset: 0x000C5934
			public bool TryGetValue(global::Inventory.Slot.Kind key, out TValue value)
			{
				global::Inventory.Slot.KindDictionary<TValue>.Member member;
				try
				{
					member = this.GetMember(key);
				}
				catch (global::System.ArgumentNullException)
				{
					value = default(TValue);
					return false;
				}
				if (member.Defined)
				{
					value = member.Value;
					return true;
				}
				value = default(TValue);
				return false;
			}

			// Token: 0x060033E4 RID: 13284 RVA: 0x000C77B4 File Offset: 0x000C59B4
			public global::Inventory.Slot.KindDictionary<TValue>.Enumerator GetEnumerator()
			{
				return new global::Inventory.Slot.KindDictionary<TValue>.Enumerator(this);
			}

			// Token: 0x04001CCE RID: 7374
			private global::Inventory.Slot.KindDictionary<TValue>.Member mDefault;

			// Token: 0x04001CCF RID: 7375
			private global::Inventory.Slot.KindDictionary<TValue>.Member mBelt;

			// Token: 0x04001CD0 RID: 7376
			private global::Inventory.Slot.KindDictionary<TValue>.Member mArmor;

			// Token: 0x04001CD1 RID: 7377
			private sbyte count;

			// Token: 0x02000657 RID: 1623
			private struct Member
			{
				// Token: 0x060033E5 RID: 13285 RVA: 0x000C77C4 File Offset: 0x000C59C4
				public Member(TValue value)
				{
					this.Value = value;
					this.Defined = true;
				}

				// Token: 0x04001CD2 RID: 7378
				public TValue Value;

				// Token: 0x04001CD3 RID: 7379
				public bool Defined;
			}

			// Token: 0x02000658 RID: 1624
			public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, TValue>>
			{
				// Token: 0x060033E6 RID: 13286 RVA: 0x000C77D4 File Offset: 0x000C59D4
				public Enumerator(global::Inventory.Slot.KindDictionary<TValue> dict)
				{
					this.dict = dict;
					this.kind = -1;
				}

				// Token: 0x17000ACD RID: 2765
				// (get) Token: 0x060033E7 RID: 13287 RVA: 0x000C77E4 File Offset: 0x000C59E4
				object global::System.Collections.IEnumerator.Current
				{
					get
					{
						return this.Current;
					}
				}

				// Token: 0x060033E8 RID: 13288 RVA: 0x000C77F4 File Offset: 0x000C59F4
				public void Reset()
				{
					this.kind = -1;
				}

				// Token: 0x060033E9 RID: 13289 RVA: 0x000C7800 File Offset: 0x000C5A00
				public void Dispose()
				{
					this.dict = default(global::Inventory.Slot.KindDictionary<TValue>);
				}

				// Token: 0x17000ACE RID: 2766
				// (get) Token: 0x060033EA RID: 13290 RVA: 0x000C781C File Offset: 0x000C5A1C
				public global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, TValue> Current
				{
					get
					{
						global::Inventory.Slot.KindDictionary<TValue>.Member member = this.dict.GetMember((global::Inventory.Slot.Kind)this.kind);
						return new global::System.Collections.Generic.KeyValuePair<global::Inventory.Slot.Kind, TValue>((global::Inventory.Slot.Kind)this.kind, member.Value);
					}
				}

				// Token: 0x060033EB RID: 13291 RVA: 0x000C7850 File Offset: 0x000C5A50
				public bool MoveNext()
				{
					global::Inventory.Slot.Kind kind;
					while ((kind = (global::Inventory.Slot.Kind)(++this.kind)) < (global::Inventory.Slot.Kind)3)
					{
						if (this.dict.GetMember(kind).Defined)
						{
							return true;
						}
					}
					return false;
				}

				// Token: 0x04001CD4 RID: 7380
				private global::Inventory.Slot.KindDictionary<TValue> dict;

				// Token: 0x04001CD5 RID: 7381
				private int kind;
			}
		}

		// Token: 0x02000659 RID: 1625
		[global::System.Flags]
		public enum KindFlags : byte
		{
			// Token: 0x04001CD7 RID: 7383
			Default = 1,
			// Token: 0x04001CD8 RID: 7384
			Belt = 2,
			// Token: 0x04001CD9 RID: 7385
			Armor = 4
		}

		// Token: 0x0200065A RID: 1626
		[global::System.Flags]
		public enum PreferenceFlags : byte
		{
			// Token: 0x04001CDB RID: 7387
			Secondary_Default = 1,
			// Token: 0x04001CDC RID: 7388
			Secondary_Belt = 2,
			// Token: 0x04001CDD RID: 7389
			Secondary_Armor = 4,
			// Token: 0x04001CDE RID: 7390
			Stack = 8,
			// Token: 0x04001CDF RID: 7391
			Primary_Default = 0x10,
			// Token: 0x04001CE0 RID: 7392
			Primary_Belt = 0x20,
			// Token: 0x04001CE1 RID: 7393
			Primary_Armor = 0x40,
			// Token: 0x04001CE2 RID: 7394
			Offset = 0x80,
			// Token: 0x04001CE3 RID: 7395
			Primary_ExplicitSlot = 0
		}

		// Token: 0x0200065B RID: 1627
		public struct Offset
		{
			// Token: 0x060033EC RID: 13292 RVA: 0x000C7898 File Offset: 0x000C5A98
			public Offset(int offset)
			{
				this.offset = (byte)offset;
				this.kind = (global::Inventory.Slot.Kind)4;
			}

			// Token: 0x060033ED RID: 13293 RVA: 0x000C78AC File Offset: 0x000C5AAC
			public Offset(global::Inventory.Slot.Kind kind, int offset)
			{
				this.kind = kind;
				this.offset = (byte)offset;
			}

			// Token: 0x17000ACF RID: 2767
			// (get) Token: 0x060033EE RID: 13294 RVA: 0x000C78C0 File Offset: 0x000C5AC0
			public static global::Inventory.Slot.Offset None
			{
				get
				{
					return new global::Inventory.Slot.Offset((global::Inventory.Slot.Kind)5, 0);
				}
			}

			// Token: 0x17000AD0 RID: 2768
			// (get) Token: 0x060033EF RID: 13295 RVA: 0x000C78CC File Offset: 0x000C5ACC
			public bool Specified
			{
				get
				{
					return this.kind < (global::Inventory.Slot.Kind)3 || (this.kind >= (global::Inventory.Slot.Kind)4 && this.kind < (global::Inventory.Slot.Kind)5);
				}
			}

			// Token: 0x17000AD1 RID: 2769
			// (get) Token: 0x060033F0 RID: 13296 RVA: 0x000C78F8 File Offset: 0x000C5AF8
			public bool HasOffsetOfKind
			{
				get
				{
					return this.kind < (global::Inventory.Slot.Kind)3;
				}
			}

			// Token: 0x17000AD2 RID: 2770
			// (get) Token: 0x060033F1 RID: 13297 RVA: 0x000C7904 File Offset: 0x000C5B04
			public bool ExplicitSlot
			{
				get
				{
					return this.kind == (global::Inventory.Slot.Kind)4;
				}
			}

			// Token: 0x17000AD3 RID: 2771
			// (get) Token: 0x060033F2 RID: 13298 RVA: 0x000C7910 File Offset: 0x000C5B10
			public global::Inventory.Slot.Kind OffsetOfKind
			{
				get
				{
					if (!this.HasOffsetOfKind)
					{
						throw new global::System.InvalidOperationException("You must check HasOffsetOfKind == true before requesting this value");
					}
					return this.kind;
				}
			}

			// Token: 0x17000AD4 RID: 2772
			// (get) Token: 0x060033F3 RID: 13299 RVA: 0x000C7930 File Offset: 0x000C5B30
			public int SlotOffset
			{
				get
				{
					return (int)this.offset;
				}
			}

			// Token: 0x060033F4 RID: 13300 RVA: 0x000C7938 File Offset: 0x000C5B38
			public override string ToString()
			{
				if (!this.Specified)
				{
					return "[Unspecified]";
				}
				if (this.HasOffsetOfKind)
				{
					return string.Format("[{0}+{1}]", this.OffsetOfKind, this.SlotOffset);
				}
				return string.Format("[{0}]", this.SlotOffset);
			}

			// Token: 0x04001CE4 RID: 7396
			private global::Inventory.Slot.Kind kind;

			// Token: 0x04001CE5 RID: 7397
			private byte offset;
		}

		// Token: 0x0200065C RID: 1628
		public struct Preference
		{
			// Token: 0x060033F5 RID: 13301 RVA: 0x000C7998 File Offset: 0x000C5B98
			private Preference(global::Inventory.Slot.PreferenceFlags preferenceFlags, int primaryOffset)
			{
				this.Flags = preferenceFlags;
				this.offset = (byte)primaryOffset;
			}

			// Token: 0x17000AD5 RID: 2773
			// (get) Token: 0x060033F6 RID: 13302 RVA: 0x000C79AC File Offset: 0x000C5BAC
			public bool IsUndefined
			{
				get
				{
					return (byte)(this.Flags & ~global::Inventory.Slot.PreferenceFlags.Stack) == 0;
				}
			}

			// Token: 0x17000AD6 RID: 2774
			// (get) Token: 0x060033F7 RID: 13303 RVA: 0x000C79C0 File Offset: 0x000C5BC0
			public bool IsDefined
			{
				get
				{
					return (byte)(this.Flags & ~global::Inventory.Slot.PreferenceFlags.Stack) != 0;
				}
			}

			// Token: 0x17000AD7 RID: 2775
			// (get) Token: 0x060033F8 RID: 13304 RVA: 0x000C79D8 File Offset: 0x000C5BD8
			public global::Inventory.Slot.KindFlags PrimaryKindFlags
			{
				get
				{
					return (global::Inventory.Slot.KindFlags)((byte)(this.Flags >> 4) & 7);
				}
			}

			// Token: 0x17000AD8 RID: 2776
			// (get) Token: 0x060033F9 RID: 13305 RVA: 0x000C79E8 File Offset: 0x000C5BE8
			public global::Inventory.Slot.KindFlags SecondaryKindFlags
			{
				get
				{
					return (global::Inventory.Slot.KindFlags)(this.Flags & (global::Inventory.Slot.PreferenceFlags.Secondary_Default | global::Inventory.Slot.PreferenceFlags.Secondary_Belt | global::Inventory.Slot.PreferenceFlags.Secondary_Armor));
				}
			}

			// Token: 0x17000AD9 RID: 2777
			// (get) Token: 0x060033FA RID: 13306 RVA: 0x000C79F4 File Offset: 0x000C5BF4
			public bool HasOffset
			{
				get
				{
					return (byte)(this.Flags & global::Inventory.Slot.PreferenceFlags.Offset) == 0x80;
				}
			}

			// Token: 0x17000ADA RID: 2778
			// (get) Token: 0x060033FB RID: 13307 RVA: 0x000C7A0C File Offset: 0x000C5C0C
			public bool Stack
			{
				get
				{
					return (byte)(this.Flags & global::Inventory.Slot.PreferenceFlags.Stack) == 8;
				}
			}

			// Token: 0x17000ADB RID: 2779
			// (get) Token: 0x060033FC RID: 13308 RVA: 0x000C7A1C File Offset: 0x000C5C1C
			public global::Inventory.Slot.Offset Offset
			{
				get
				{
					if ((byte)(this.Flags & global::Inventory.Slot.PreferenceFlags.Offset) == 0x80)
					{
						uint num = (uint)((byte)(this.Flags & ~global::Inventory.Slot.PreferenceFlags.Offset)) >> 4;
						if (num == 0U)
						{
							return new global::Inventory.Slot.Offset((int)this.offset);
						}
						if ((num & num - 1U) == 0U)
						{
							global::Inventory.Slot.Kind kind = global::Inventory.Slot.Kind.Default;
							while ((num >>= 1) != 0U)
							{
								kind += 1;
							}
							return new global::Inventory.Slot.Offset(kind, (int)this.offset);
						}
					}
					return global::Inventory.Slot.Offset.None;
				}
			}

			// Token: 0x060033FD RID: 13309 RVA: 0x000C7A90 File Offset: 0x000C5C90
			public global::Inventory.Slot.Preference CloneOffsetChange(int newOffset)
			{
				return new global::Inventory.Slot.Preference(this.Flags, newOffset);
			}

			// Token: 0x060033FE RID: 13310 RVA: 0x000C7AA0 File Offset: 0x000C5CA0
			public global::Inventory.Slot.Preference CloneStackChange(bool stack)
			{
				if (stack)
				{
					return new global::Inventory.Slot.Preference(this.Flags | global::Inventory.Slot.PreferenceFlags.Stack, (int)this.offset);
				}
				return new global::Inventory.Slot.Preference(this.Flags & ~global::Inventory.Slot.PreferenceFlags.Stack, (int)this.offset);
			}

			// Token: 0x060033FF RID: 13311 RVA: 0x000C7AD8 File Offset: 0x000C5CD8
			public static global::Inventory.Slot.Preference Define(int slotNumber, bool stack, global::Inventory.Slot.KindFlags fallbackSlots)
			{
				global::Inventory.Slot.PreferenceFlags preferenceFlags = (global::Inventory.Slot.PreferenceFlags)(fallbackSlots & (global::Inventory.Slot.KindFlags.Default | global::Inventory.Slot.KindFlags.Belt | global::Inventory.Slot.KindFlags.Armor));
				if (stack)
				{
					preferenceFlags |= global::Inventory.Slot.PreferenceFlags.Stack;
				}
				if (slotNumber >= 0)
				{
					preferenceFlags |= global::Inventory.Slot.PreferenceFlags.Offset;
				}
				else
				{
					slotNumber = 0;
				}
				return new global::Inventory.Slot.Preference(preferenceFlags, slotNumber);
			}

			// Token: 0x06003400 RID: 13312 RVA: 0x000C7B14 File Offset: 0x000C5D14
			public static global::Inventory.Slot.Preference Define(global::Inventory.Slot.Kind startSlotKind, int offsetOfSlotKind, bool stack, global::Inventory.Slot.KindFlags fallbackSlotKinds)
			{
				global::Inventory.Slot.PreferenceFlags preferenceFlags = (global::Inventory.Slot.PreferenceFlags)(fallbackSlotKinds & (global::Inventory.Slot.KindFlags.Default | global::Inventory.Slot.KindFlags.Belt | global::Inventory.Slot.KindFlags.Armor));
				if (stack)
				{
					preferenceFlags |= global::Inventory.Slot.PreferenceFlags.Stack;
				}
				if (offsetOfSlotKind >= 0)
				{
					preferenceFlags |= global::Inventory.Slot.PreferenceFlags.Offset;
				}
				else
				{
					offsetOfSlotKind = 0;
				}
				global::Inventory.Slot.PreferenceFlags preferenceFlags2 = (global::Inventory.Slot.PreferenceFlags)(1 << (int)startSlotKind);
				preferenceFlags &= ~preferenceFlags2;
				preferenceFlags |= preferenceFlags2 << 4;
				return new global::Inventory.Slot.Preference(preferenceFlags, offsetOfSlotKind);
			}

			// Token: 0x06003401 RID: 13313 RVA: 0x000C7B68 File Offset: 0x000C5D68
			public static global::Inventory.Slot.Preference Define(int offsetOfSlotKind, bool stack)
			{
				return global::Inventory.Slot.Preference.Define(offsetOfSlotKind, stack, (global::Inventory.Slot.KindFlags)0);
			}

			// Token: 0x06003402 RID: 13314 RVA: 0x000C7B74 File Offset: 0x000C5D74
			public static global::Inventory.Slot.Preference Define(int offsetOfSlotKind, global::Inventory.Slot.KindFlags fallbackSlotKinds)
			{
				return global::Inventory.Slot.Preference.Define(offsetOfSlotKind, true, fallbackSlotKinds);
			}

			// Token: 0x06003403 RID: 13315 RVA: 0x000C7B80 File Offset: 0x000C5D80
			public static global::Inventory.Slot.Preference Define(int offsetOfSlotKind, global::Inventory.Slot.Kind fallbackSlotKind)
			{
				return global::Inventory.Slot.Preference.Define(offsetOfSlotKind, true, (global::Inventory.Slot.KindFlags)(1 << (int)fallbackSlotKind));
			}

			// Token: 0x06003404 RID: 13316 RVA: 0x000C7B90 File Offset: 0x000C5D90
			public static global::Inventory.Slot.Preference Define(int offsetOfSlotKind)
			{
				return global::Inventory.Slot.Preference.Define(offsetOfSlotKind, true, (global::Inventory.Slot.KindFlags)0);
			}

			// Token: 0x06003405 RID: 13317 RVA: 0x000C7B9C File Offset: 0x000C5D9C
			public static global::Inventory.Slot.Preference Define(global::Inventory.Slot.Kind startSlotKind, int offsetOfSlotKind, bool stack)
			{
				return global::Inventory.Slot.Preference.Define(startSlotKind, offsetOfSlotKind, stack, (global::Inventory.Slot.KindFlags)0);
			}

			// Token: 0x06003406 RID: 13318 RVA: 0x000C7BA8 File Offset: 0x000C5DA8
			public static global::Inventory.Slot.Preference Define(global::Inventory.Slot.Kind startSlotKind, int offsetOfSlotKind, global::Inventory.Slot.KindFlags fallbackSlotKinds)
			{
				return global::Inventory.Slot.Preference.Define(startSlotKind, offsetOfSlotKind, true, fallbackSlotKinds);
			}

			// Token: 0x06003407 RID: 13319 RVA: 0x000C7BB4 File Offset: 0x000C5DB4
			public static global::Inventory.Slot.Preference Define(global::Inventory.Slot.Kind startSlotKind, int offsetOfSlotKind, global::Inventory.Slot.Kind fallbackSlotKind)
			{
				return global::Inventory.Slot.Preference.Define(startSlotKind, offsetOfSlotKind, true, (global::Inventory.Slot.KindFlags)(1 << (int)fallbackSlotKind));
			}

			// Token: 0x06003408 RID: 13320 RVA: 0x000C7BC8 File Offset: 0x000C5DC8
			public static global::Inventory.Slot.Preference Define(global::Inventory.Slot.Kind startSlotKind, int offsetOfSlotKind)
			{
				return global::Inventory.Slot.Preference.Define(startSlotKind, offsetOfSlotKind, true, (global::Inventory.Slot.KindFlags)0);
			}

			// Token: 0x06003409 RID: 13321 RVA: 0x000C7BD4 File Offset: 0x000C5DD4
			public static global::Inventory.Slot.Preference Define(global::Inventory.Slot.KindFlags firstPreferenceSlotKinds, bool stack, global::Inventory.Slot.KindFlags secondPreferenceSlotKinds)
			{
				global::Inventory.Slot.PreferenceFlags preferenceFlags = (global::Inventory.Slot.PreferenceFlags)((byte)(secondPreferenceSlotKinds & (global::Inventory.Slot.KindFlags.Default | global::Inventory.Slot.KindFlags.Belt | global::Inventory.Slot.KindFlags.Armor)) & (byte)(~(byte)firstPreferenceSlotKinds));
				if (stack)
				{
					preferenceFlags |= global::Inventory.Slot.PreferenceFlags.Stack;
				}
				preferenceFlags |= (global::Inventory.Slot.PreferenceFlags)(firstPreferenceSlotKinds << 4);
				return new global::Inventory.Slot.Preference(preferenceFlags, 0);
			}

			// Token: 0x0600340A RID: 13322 RVA: 0x000C7C08 File Offset: 0x000C5E08
			public static global::Inventory.Slot.Preference Define(global::Inventory.Slot.Kind firstPreferenceSlotKind, bool stack, global::Inventory.Slot.KindFlags secondPreferenceSlotKinds)
			{
				return global::Inventory.Slot.Preference.Define((global::Inventory.Slot.KindFlags)(1 << (int)firstPreferenceSlotKind), stack, secondPreferenceSlotKinds);
			}

			// Token: 0x0600340B RID: 13323 RVA: 0x000C7C18 File Offset: 0x000C5E18
			public static global::Inventory.Slot.Preference Define(global::Inventory.Slot.Kind firstPreferenceSlotKind, bool stack, global::Inventory.Slot.Kind secondPreferenceSlotKind)
			{
				return global::Inventory.Slot.Preference.Define((global::Inventory.Slot.KindFlags)(1 << (int)firstPreferenceSlotKind), stack, (global::Inventory.Slot.KindFlags)(1 << (int)secondPreferenceSlotKind));
			}

			// Token: 0x0600340C RID: 13324 RVA: 0x000C7C30 File Offset: 0x000C5E30
			public static global::Inventory.Slot.Preference Define(global::Inventory.Slot.KindFlags firstPreferenceSlotKind, bool stack, global::Inventory.Slot.Kind secondPreferenceSlotKind)
			{
				return global::Inventory.Slot.Preference.Define(firstPreferenceSlotKind, stack, (global::Inventory.Slot.KindFlags)(1 << (int)secondPreferenceSlotKind));
			}

			// Token: 0x0600340D RID: 13325 RVA: 0x000C7C40 File Offset: 0x000C5E40
			public static global::Inventory.Slot.Preference Define(global::Inventory.Slot.Kind slotsOfKind, bool stack)
			{
				return global::Inventory.Slot.Preference.Define(slotsOfKind, stack, (global::Inventory.Slot.KindFlags)0);
			}

			// Token: 0x0600340E RID: 13326 RVA: 0x000C7C4C File Offset: 0x000C5E4C
			public static global::Inventory.Slot.Preference Define(global::Inventory.Slot.KindFlags slotsOfKinds, bool stack)
			{
				return global::Inventory.Slot.Preference.Define(slotsOfKinds, stack, (global::Inventory.Slot.KindFlags)0);
			}

			// Token: 0x0600340F RID: 13327 RVA: 0x000C7C58 File Offset: 0x000C5E58
			public static global::Inventory.Slot.Preference Define(global::Inventory.Slot.Kind firstPreferenceSlotKind, global::Inventory.Slot.Kind secondPreferenceSlotKind)
			{
				return global::Inventory.Slot.Preference.Define(firstPreferenceSlotKind, true, secondPreferenceSlotKind);
			}

			// Token: 0x06003410 RID: 13328 RVA: 0x000C7C64 File Offset: 0x000C5E64
			public static global::Inventory.Slot.Preference Define(global::Inventory.Slot.KindFlags firstPreferenceSlotKinds, global::Inventory.Slot.KindFlags secondPreferenceSlotKinds)
			{
				return global::Inventory.Slot.Preference.Define(firstPreferenceSlotKinds, true, secondPreferenceSlotKinds);
			}

			// Token: 0x06003411 RID: 13329 RVA: 0x000C7C70 File Offset: 0x000C5E70
			public static global::Inventory.Slot.Preference Define(global::Inventory.Slot.Kind firstPreferenceSlotKind, global::Inventory.Slot.KindFlags secondPreferenceSlotKinds)
			{
				return global::Inventory.Slot.Preference.Define(firstPreferenceSlotKind, true, secondPreferenceSlotKinds);
			}

			// Token: 0x06003412 RID: 13330 RVA: 0x000C7C7C File Offset: 0x000C5E7C
			public static global::Inventory.Slot.Preference Define(global::Inventory.Slot.KindFlags firstPreferenceSlotKinds, global::Inventory.Slot.Kind secondPreferenceSlotKind)
			{
				return global::Inventory.Slot.Preference.Define(firstPreferenceSlotKinds, true, secondPreferenceSlotKind);
			}

			// Token: 0x06003413 RID: 13331 RVA: 0x000C7C88 File Offset: 0x000C5E88
			public static global::Inventory.Slot.Preference Define(global::Inventory.Slot.Kind slotsOfKind)
			{
				return global::Inventory.Slot.Preference.Define(slotsOfKind, true, (global::Inventory.Slot.KindFlags)0);
			}

			// Token: 0x06003414 RID: 13332 RVA: 0x000C7C94 File Offset: 0x000C5E94
			public static global::Inventory.Slot.Preference Define(global::Inventory.Slot.KindFlags slotsOfKinds)
			{
				return global::Inventory.Slot.Preference.Define(slotsOfKinds, true, (global::Inventory.Slot.KindFlags)0);
			}

			// Token: 0x06003415 RID: 13333 RVA: 0x000C7CA0 File Offset: 0x000C5EA0
			public override string ToString()
			{
				global::Inventory.Slot.KindFlags primaryKindFlags = this.PrimaryKindFlags;
				global::Inventory.Slot.KindFlags secondaryKindFlags = this.SecondaryKindFlags;
				global::Inventory.Slot.Offset offset = this.Offset;
				if (secondaryKindFlags != (global::Inventory.Slot.KindFlags)0)
				{
					if (offset.Specified)
					{
						if (offset.HasOffsetOfKind)
						{
							if (this.Stack)
							{
								return string.Format("[{0}+{1}|{2} (stack)]", offset.OffsetOfKind, offset.SlotOffset, secondaryKindFlags);
							}
							return string.Format("[{0}+{1}|{2}]", offset.OffsetOfKind, offset.SlotOffset, secondaryKindFlags);
						}
						else
						{
							if (this.Stack)
							{
								return string.Format("[{0}|{1} (stack)]", offset.SlotOffset, secondaryKindFlags);
							}
							return string.Format("[{0}|{1}]", offset.SlotOffset, secondaryKindFlags);
						}
					}
					else if (primaryKindFlags != (global::Inventory.Slot.KindFlags)0)
					{
						if (this.Stack)
						{
							return string.Format("[{0}|{1} (stack)]", primaryKindFlags, secondaryKindFlags);
						}
						return string.Format("[{0}|{1}]", primaryKindFlags, secondaryKindFlags);
					}
					else
					{
						if (this.Stack)
						{
							return string.Format("[|{1} (stack)]", secondaryKindFlags);
						}
						return string.Format("[|{1}]", secondaryKindFlags);
					}
				}
				else if (offset.Specified)
				{
					if (offset.HasOffsetOfKind)
					{
						if (this.Stack)
						{
							return string.Format("[{0}+{1} (stack)]", offset.OffsetOfKind, offset.SlotOffset);
						}
						return string.Format("[{0}+{1}]", offset.OffsetOfKind, offset.SlotOffset);
					}
					else
					{
						if (this.Stack)
						{
							return string.Format("[{0} (stack)]", offset.SlotOffset);
						}
						return string.Format("[{0}]", offset.SlotOffset);
					}
				}
				else
				{
					if (primaryKindFlags == (global::Inventory.Slot.KindFlags)0)
					{
						return "[Undefined]";
					}
					if (this.Stack)
					{
						return string.Format("[{0} (stack)]", primaryKindFlags);
					}
					return string.Format("[{0}]", primaryKindFlags);
				}
			}

			// Token: 0x06003416 RID: 13334 RVA: 0x000C7EC8 File Offset: 0x000C60C8
			public static implicit operator global::Inventory.Slot.Preference(int slot)
			{
				return new global::Inventory.Slot.Preference(global::Inventory.Slot.PreferenceFlags.Stack | global::Inventory.Slot.PreferenceFlags.Offset, (int)((byte)slot));
			}

			// Token: 0x06003417 RID: 13335 RVA: 0x000C7ED8 File Offset: 0x000C60D8
			public static implicit operator global::Inventory.Slot.Preference(global::Inventory.Slot.Kind kind)
			{
				return new global::Inventory.Slot.Preference((global::Inventory.Slot.PreferenceFlags)((byte)(((byte)(1 << (int)kind) & 7) << 4) | 8), 0);
			}

			// Token: 0x06003418 RID: 13336 RVA: 0x000C7EF0 File Offset: 0x000C60F0
			public static implicit operator global::Inventory.Slot.Preference(global::Inventory.Slot.KindFlags kindFlags)
			{
				return new global::Inventory.Slot.Preference((global::Inventory.Slot.PreferenceFlags)((byte)((byte)(kindFlags & (global::Inventory.Slot.KindFlags.Default | global::Inventory.Slot.KindFlags.Belt | global::Inventory.Slot.KindFlags.Armor)) << 4) | 8), 0);
			}

			// Token: 0x04001CE6 RID: 7398
			private const bool kDefaultStack = true;

			// Token: 0x04001CE7 RID: 7399
			public readonly global::Inventory.Slot.PreferenceFlags Flags;

			// Token: 0x04001CE8 RID: 7400
			private readonly byte offset;
		}

		// Token: 0x0200065D RID: 1629
		public struct Range
		{
			// Token: 0x06003419 RID: 13337 RVA: 0x000C7F04 File Offset: 0x000C6104
			public Range(int start, int length)
			{
				this.Start = start;
				this.Count = length;
			}

			// Token: 0x17000ADC RID: 2780
			// (get) Token: 0x0600341A RID: 13338 RVA: 0x000C7F14 File Offset: 0x000C6114
			public int End
			{
				get
				{
					return this.Start + this.Count;
				}
			}

			// Token: 0x17000ADD RID: 2781
			// (get) Token: 0x0600341B RID: 13339 RVA: 0x000C7F24 File Offset: 0x000C6124
			public int Last
			{
				get
				{
					return (this.Count > 1) ? (this.Start + (this.Count - 1)) : this.Start;
				}
			}

			// Token: 0x17000ADE RID: 2782
			// (get) Token: 0x0600341C RID: 13340 RVA: 0x000C7F58 File Offset: 0x000C6158
			public bool Any
			{
				get
				{
					return this.Count > 0;
				}
			}

			// Token: 0x0600341D RID: 13341 RVA: 0x000C7F64 File Offset: 0x000C6164
			public bool Contains(int i)
			{
				return this.Count > 0 && (this.Start == i || (this.Start < i && this.Start + this.Count > i));
			}

			// Token: 0x0600341E RID: 13342 RVA: 0x000C7FA4 File Offset: 0x000C61A4
			public sbyte ContainEx(int i)
			{
				if (this.Start > i)
				{
					return -1;
				}
				if (i - this.Start < this.Count)
				{
					return 0;
				}
				return 1;
			}

			// Token: 0x0600341F RID: 13343 RVA: 0x000C7FD8 File Offset: 0x000C61D8
			public int Gouge(int i, out global::Inventory.Slot.RangePair pair)
			{
				if (this.Count <= 0 || (this.Count == 1 && i == this.Start))
				{
					pair = default(global::Inventory.Slot.RangePair);
					return 0;
				}
				if (i < this.Start || i >= this.Start + this.Count)
				{
					pair = new global::Inventory.Slot.RangePair(this);
					return 1;
				}
				if (i == this.Start)
				{
					pair = new global::Inventory.Slot.RangePair(new global::Inventory.Slot.Range(this.Start + 1, this.Count - 1));
					return 1;
				}
				if (i == this.Start + this.Count - 1)
				{
					pair = new global::Inventory.Slot.RangePair(new global::Inventory.Slot.Range(this.Start, this.Count - 1));
					return 1;
				}
				pair = new global::Inventory.Slot.RangePair(new global::Inventory.Slot.Range(this.Start, i - this.Start), new global::Inventory.Slot.Range(i + 1, this.Count - (i - this.Start + 1)));
				return 2;
			}

			// Token: 0x06003420 RID: 13344 RVA: 0x000C80D4 File Offset: 0x000C62D4
			public int Index(int offset)
			{
				int num = this.Start + offset;
				return (!this.Contains(num)) ? -1 : num;
			}

			// Token: 0x06003421 RID: 13345 RVA: 0x000C8100 File Offset: 0x000C6300
			public int GetOffset(int i)
			{
				if (this.Contains(i))
				{
					return i - this.Start;
				}
				return -1;
			}

			// Token: 0x06003422 RID: 13346 RVA: 0x000C8118 File Offset: 0x000C6318
			public override string ToString()
			{
				return string.Format("[{0}:{1}]", this.Start, this.Count);
			}

			// Token: 0x04001CE9 RID: 7401
			public readonly int Start;

			// Token: 0x04001CEA RID: 7402
			public readonly int Count;
		}

		// Token: 0x0200065E RID: 1630
		public struct RangePair
		{
			// Token: 0x06003423 RID: 13347 RVA: 0x000C8148 File Offset: 0x000C6348
			public RangePair(global::Inventory.Slot.Range A, global::Inventory.Slot.Range B)
			{
				this.A = A;
				this.B = B;
			}

			// Token: 0x06003424 RID: 13348 RVA: 0x000C8158 File Offset: 0x000C6358
			public RangePair(global::Inventory.Slot.Range AB)
			{
				this.A = AB;
				this.B = AB;
			}

			// Token: 0x04001CEB RID: 7403
			public readonly global::Inventory.Slot.Range A;

			// Token: 0x04001CEC RID: 7404
			public readonly global::Inventory.Slot.Range B;
		}
	}

	// Token: 0x0200065F RID: 1631
	[global::System.Flags]
	public enum SlotFlags
	{
		// Token: 0x04001CEE RID: 7406
		Belt = 1,
		// Token: 0x04001CEF RID: 7407
		Storage = 2,
		// Token: 0x04001CF0 RID: 7408
		Equip = 4,
		// Token: 0x04001CF1 RID: 7409
		Head = 8,
		// Token: 0x04001CF2 RID: 7410
		Chest = 0x10,
		// Token: 0x04001CF3 RID: 7411
		Legs = 0x20,
		// Token: 0x04001CF4 RID: 7412
		Feet = 0x40,
		// Token: 0x04001CF5 RID: 7413
		FuelBasic = 0x80,
		// Token: 0x04001CF6 RID: 7414
		Debris = 0x100,
		// Token: 0x04001CF7 RID: 7415
		Raw = 0x200,
		// Token: 0x04001CF8 RID: 7416
		Cooked = 0x400,
		// Token: 0x04001CF9 RID: 7417
		Safe = -0x80000000
	}

	// Token: 0x02000660 RID: 1632
	public struct Transfer
	{
		// Token: 0x04001CFA RID: 7418
		public global::InventoryItem item;

		// Token: 0x04001CFB RID: 7419
		public global::Inventory.Addition addition;
	}

	// Token: 0x02000661 RID: 1633
	public static class Uses
	{
		// Token: 0x02000662 RID: 1634
		public enum Quantifier : byte
		{
			// Token: 0x04001CFD RID: 7421
			Default,
			// Token: 0x04001CFE RID: 7422
			Manual,
			// Token: 0x04001CFF RID: 7423
			Minimum,
			// Token: 0x04001D00 RID: 7424
			Maximum,
			// Token: 0x04001D01 RID: 7425
			StackSize,
			// Token: 0x04001D02 RID: 7426
			Random
		}

		// Token: 0x02000663 RID: 1635
		public struct Quantity
		{
			// Token: 0x06003425 RID: 13349 RVA: 0x000C8168 File Offset: 0x000C6368
			private Quantity(global::Inventory.Uses.Quantifier quantifier, byte manualAmount)
			{
				this.Quantifier = quantifier;
				this.manualAmount = manualAmount;
			}

			// Token: 0x06003426 RID: 13350 RVA: 0x000C8178 File Offset: 0x000C6378
			// Note: this type is marked as 'beforefieldinit'.
			static Quantity()
			{
			}

			// Token: 0x17000ADF RID: 2783
			// (get) Token: 0x06003427 RID: 13351 RVA: 0x000C81B8 File Offset: 0x000C63B8
			public int ManualAmount
			{
				get
				{
					if (this.Quantifier == global::Inventory.Uses.Quantifier.Manual)
					{
						return (int)this.manualAmount;
					}
					return -1;
				}
			}

			// Token: 0x06003428 RID: 13352 RVA: 0x000C81D0 File Offset: 0x000C63D0
			public static global::Inventory.Uses.Quantity Manual(int amount)
			{
				return new global::Inventory.Uses.Quantity(global::Inventory.Uses.Quantifier.Manual, (byte)amount);
			}

			// Token: 0x06003429 RID: 13353 RVA: 0x000C81DC File Offset: 0x000C63DC
			public int CalculateCount(global::ItemDataBlock datablock)
			{
				switch (this.Quantifier)
				{
				case global::Inventory.Uses.Quantifier.Default:
					return datablock._spawnUsesMin + (datablock._spawnUsesMax - datablock._spawnUsesMin) / 2;
				case global::Inventory.Uses.Quantifier.Manual:
					return (this.manualAmount != 0) ? (((int)this.manualAmount <= datablock._maxUses) ? ((int)this.manualAmount) : datablock._maxUses) : 1;
				case global::Inventory.Uses.Quantifier.Minimum:
					return datablock._spawnUsesMin;
				case global::Inventory.Uses.Quantifier.Maximum:
					return datablock._spawnUsesMax;
				case global::Inventory.Uses.Quantifier.StackSize:
					return datablock._maxUses;
				case global::Inventory.Uses.Quantifier.Random:
					return global::UnityEngine.Random.Range(datablock._spawnUsesMin, datablock._spawnUsesMax + 1);
				default:
					throw new global::System.NotImplementedException();
				}
			}

			// Token: 0x0600342A RID: 13354 RVA: 0x000C828C File Offset: 0x000C648C
			public override string ToString()
			{
				if (this.Quantifier == global::Inventory.Uses.Quantifier.Manual)
				{
					return this.manualAmount.ToString();
				}
				return this.Quantifier.ToString();
			}

			// Token: 0x0600342B RID: 13355 RVA: 0x000C82C4 File Offset: 0x000C64C4
			public static bool TryParse(string text, out global::Inventory.Uses.Quantity uses)
			{
				int num;
				if (int.TryParse(text, out num))
				{
					if (num == 0)
					{
						uses = global::Inventory.Uses.Quantity.Random;
					}
					else if (num < 0)
					{
						uses = global::Inventory.Uses.Quantity.Minimum;
					}
					else if (num > 0xFF)
					{
						uses = global::Inventory.Uses.Quantity.Maximum;
					}
					else
					{
						uses = num;
					}
					return true;
				}
				if (string.Equals(text, "min", global::System.StringComparison.InvariantCultureIgnoreCase))
				{
					uses = global::Inventory.Uses.Quantity.Minimum;
					return true;
				}
				if (string.Equals(text, "max", global::System.StringComparison.InvariantCultureIgnoreCase))
				{
					uses = global::Inventory.Uses.Quantity.Maximum;
					return true;
				}
				bool result;
				try
				{
					switch ((byte)global::System.Enum.Parse(typeof(global::Inventory.Uses.Quantifier), text, true))
					{
					case 0:
						uses = global::Inventory.Uses.Quantity.Default;
						return true;
					case 2:
						uses = global::Inventory.Uses.Quantity.Minimum;
						return true;
					case 3:
						uses = global::Inventory.Uses.Quantity.Maximum;
						return true;
					case 5:
						uses = global::Inventory.Uses.Quantity.Random;
						return true;
					}
					throw new global::System.NotImplementedException();
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogException(ex);
					uses = global::Inventory.Uses.Quantity.Default;
					result = false;
				}
				return result;
			}

			// Token: 0x0600342C RID: 13356 RVA: 0x000C8438 File Offset: 0x000C6638
			public static implicit operator global::Inventory.Uses.Quantity(int amount)
			{
				return global::Inventory.Uses.Quantity.Manual(amount);
			}

			// Token: 0x04001D03 RID: 7427
			public readonly global::Inventory.Uses.Quantifier Quantifier;

			// Token: 0x04001D04 RID: 7428
			private readonly byte manualAmount;

			// Token: 0x04001D05 RID: 7429
			public static readonly global::Inventory.Uses.Quantity Default = new global::Inventory.Uses.Quantity(global::Inventory.Uses.Quantifier.Default, 0);

			// Token: 0x04001D06 RID: 7430
			public static readonly global::Inventory.Uses.Quantity Minimum = new global::Inventory.Uses.Quantity(global::Inventory.Uses.Quantifier.Minimum, 0);

			// Token: 0x04001D07 RID: 7431
			public static readonly global::Inventory.Uses.Quantity Maximum = new global::Inventory.Uses.Quantity(global::Inventory.Uses.Quantifier.Maximum, 0);

			// Token: 0x04001D08 RID: 7432
			public static readonly global::Inventory.Uses.Quantity Random = new global::Inventory.Uses.Quantity(global::Inventory.Uses.Quantifier.Random, 0);
		}
	}

	// Token: 0x02000664 RID: 1636
	public struct VacantIterator : global::System.IDisposable
	{
		// Token: 0x0600342D RID: 13357 RVA: 0x000C8440 File Offset: 0x000C6640
		public VacantIterator(global::Inventory inventory)
		{
			this.baseEnumerator = inventory.collection.VacantEnumerator;
		}

		// Token: 0x0600342E RID: 13358 RVA: 0x000C8454 File Offset: 0x000C6654
		public void Reset()
		{
			this.baseEnumerator.Reset();
		}

		// Token: 0x17000AE0 RID: 2784
		// (get) Token: 0x0600342F RID: 13359 RVA: 0x000C8464 File Offset: 0x000C6664
		public int slot
		{
			get
			{
				return this.baseEnumerator.Current;
			}
		}

		// Token: 0x06003430 RID: 13360 RVA: 0x000C8474 File Offset: 0x000C6674
		public bool Next()
		{
			return this.baseEnumerator.MoveNext();
		}

		// Token: 0x06003431 RID: 13361 RVA: 0x000C8484 File Offset: 0x000C6684
		public void Dispose()
		{
			this.baseEnumerator.Dispose();
		}

		// Token: 0x06003432 RID: 13362 RVA: 0x000C8494 File Offset: 0x000C6694
		public bool Next(out int slot)
		{
			if (this.Next())
			{
				slot = this.baseEnumerator.Current;
				return true;
			}
			slot = -1;
			return false;
		}

		// Token: 0x04001D09 RID: 7433
		private global::Inventory.Collection<global::InventoryItem>.VacantCollection.Enumerator baseEnumerator;
	}

	// Token: 0x02000665 RID: 1637
	private static class Empty
	{
		// Token: 0x06003433 RID: 13363 RVA: 0x000C84B4 File Offset: 0x000C66B4
		// Note: this type is marked as 'beforefieldinit'.
		static Empty()
		{
		}

		// Token: 0x04001D0A RID: 7434
		public static readonly global::Inventory.SlotFlags[] SlotFlags = new global::Inventory.SlotFlags[0];
	}

	// Token: 0x02000666 RID: 1638
	private static class Shuffle
	{
		// Token: 0x06003434 RID: 13364 RVA: 0x000C84C4 File Offset: 0x000C66C4
		// Note: this type is marked as 'beforefieldinit'.
		static Shuffle()
		{
		}

		// Token: 0x06003435 RID: 13365 RVA: 0x000C84D0 File Offset: 0x000C66D0
		public static void Array<T>(T[] array)
		{
			for (int i = array.Length - 1; i > 0; i--)
			{
				int num = global::Inventory.Shuffle.r.Next(i);
				if (num != i)
				{
					T t = array[i];
					array[i] = array[num];
					array[num] = t;
				}
			}
		}

		// Token: 0x04001D0B RID: 7435
		private static readonly global::System.Random r = new global::System.Random();
	}

	// Token: 0x02000667 RID: 1639
	public enum SlotOperationResult : sbyte
	{
		// Token: 0x04001D0D RID: 7437
		NoOp,
		// Token: 0x04001D0E RID: 7438
		Success_Stacked,
		// Token: 0x04001D0F RID: 7439
		Success_Combined,
		// Token: 0x04001D10 RID: 7440
		Success_Moved = 4,
		// Token: 0x04001D11 RID: 7441
		Error_NotALooter = -9,
		// Token: 0x04001D12 RID: 7442
		Error_OccupiedDestination,
		// Token: 0x04001D13 RID: 7443
		Error_SameSlot,
		// Token: 0x04001D14 RID: 7444
		Error_MissingInventory,
		// Token: 0x04001D15 RID: 7445
		Error_EmptySourceSlot,
		// Token: 0x04001D16 RID: 7446
		Error_EmptyDestinationSlot,
		// Token: 0x04001D17 RID: 7447
		Error_SlotRange,
		// Token: 0x04001D18 RID: 7448
		Error_NoOpArgs,
		// Token: 0x04001D19 RID: 7449
		Error_Failed
	}

	// Token: 0x02000668 RID: 1640
	private enum SlotOperations : byte
	{
		// Token: 0x04001D1B RID: 7451
		Stack = 1,
		// Token: 0x04001D1C RID: 7452
		Combine,
		// Token: 0x04001D1D RID: 7453
		Move = 4,
		// Token: 0x04001D1E RID: 7454
		ReportCheater = 0x40,
		// Token: 0x04001D1F RID: 7455
		EnsureAuthenticLooter = 0x80
	}

	// Token: 0x02000669 RID: 1641
	private struct SlotOperationsInfo
	{
		// Token: 0x06003436 RID: 13366 RVA: 0x000C852C File Offset: 0x000C672C
		public SlotOperationsInfo(global::Inventory.SlotOperations SlotOperations, global::uLink.NetworkPlayer Looter)
		{
			this.SlotOperations = SlotOperations;
			this.Looter = Looter;
		}

		// Token: 0x06003437 RID: 13367 RVA: 0x000C853C File Offset: 0x000C673C
		public SlotOperationsInfo(global::Inventory.SlotOperations SlotOperations)
		{
			this.SlotOperations = SlotOperations;
			this.Looter = default(global::uLink.NetworkPlayer);
		}

		// Token: 0x06003438 RID: 13368 RVA: 0x000C8560 File Offset: 0x000C6760
		public override string ToString()
		{
			return this.SlotOperations.ToString();
		}

		// Token: 0x06003439 RID: 13369 RVA: 0x000C8574 File Offset: 0x000C6774
		public override bool Equals(object obj)
		{
			return obj is global::Inventory.SlotOperationsInfo && this.Equals((global::Inventory.SlotOperationsInfo)obj);
		}

		// Token: 0x0600343A RID: 13370 RVA: 0x000C8590 File Offset: 0x000C6790
		public override int GetHashCode()
		{
			return (int)((byte)(this.SlotOperations & (global::Inventory.SlotOperations)0xC7)) << 0x10 ^ (((byte)(this.SlotOperations & global::Inventory.SlotOperations.EnsureAuthenticLooter) != 0x80) ? 0 : this.Looter.id);
		}

		// Token: 0x0600343B RID: 13371 RVA: 0x000C85DC File Offset: 0x000C67DC
		public bool Equals(global::Inventory.SlotOperationsInfo other)
		{
			return (byte)(this.SlotOperations & (global::Inventory.SlotOperations)0xC7) == (byte)(other.SlotOperations & (global::Inventory.SlotOperations)0xC7) && ((byte)(this.SlotOperations & global::Inventory.SlotOperations.EnsureAuthenticLooter) != 0x80 || this.Looter.Equals(other.Looter));
		}

		// Token: 0x0600343C RID: 13372 RVA: 0x000C863C File Offset: 0x000C683C
		public static implicit operator global::Inventory.SlotOperationsInfo(global::Inventory.SlotOperations ops)
		{
			return new global::Inventory.SlotOperationsInfo(ops);
		}

		// Token: 0x04001D20 RID: 7456
		[global::System.NonSerialized]
		public readonly global::Inventory.SlotOperations SlotOperations;

		// Token: 0x04001D21 RID: 7457
		[global::System.NonSerialized]
		public readonly global::uLink.NetworkPlayer Looter;
	}

	// Token: 0x0200066A RID: 1642
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <FindItems>c__Iterator47<IItemT> : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<!0>, global::System.Collections.Generic.IEnumerator<!0> where IItemT : class, global::IInventoryItem
	{
		// Token: 0x0600343D RID: 13373 RVA: 0x000C8644 File Offset: 0x000C6844
		public <FindItems>c__Iterator47()
		{
		}

		// Token: 0x17000AE1 RID: 2785
		// (get) Token: 0x0600343E RID: 13374 RVA: 0x000C864C File Offset: 0x000C684C
		IItemT global::System.Collections.Generic.IEnumerator<!0>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000AE2 RID: 2786
		// (get) Token: 0x0600343F RID: 13375 RVA: 0x000C8654 File Offset: 0x000C6854
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06003440 RID: 13376 RVA: 0x000C8664 File Offset: 0x000C6864
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<IItemT>.GetEnumerator();
		}

		// Token: 0x06003441 RID: 13377 RVA: 0x000C866C File Offset: 0x000C686C
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<IItemT> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::Inventory.<FindItems>c__Iterator47<IItemT> <FindItems>c__Iterator = new global::Inventory.<FindItems>c__Iterator47<IItemT>();
			<FindItems>c__Iterator.<>f__this = this;
			return <FindItems>c__Iterator;
		}

		// Token: 0x06003442 RID: 13378 RVA: 0x000C86A0 File Offset: 0x000C68A0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				enumerator = base.collection.OccupiedEnumerator;
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				while (enumerator.MoveNext())
				{
					item = (enumerator.Current.iface as IItemT);
					if (!object.ReferenceEquals(item, null))
					{
						this.$current = item;
						this.$PC = 1;
						flag = true;
						return true;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06003443 RID: 13379 RVA: 0x000C879C File Offset: 0x000C699C
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06003444 RID: 13380 RVA: 0x000C87FC File Offset: 0x000C69FC
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04001D22 RID: 7458
		internal global::Inventory.Collection<global::InventoryItem>.OccupiedCollection.Enumerator <enumerator>__0;

		// Token: 0x04001D23 RID: 7459
		internal IItemT <item>__1;

		// Token: 0x04001D24 RID: 7460
		internal int $PC;

		// Token: 0x04001D25 RID: 7461
		internal IItemT $current;

		// Token: 0x04001D26 RID: 7462
		internal global::Inventory <>f__this;
	}
}
