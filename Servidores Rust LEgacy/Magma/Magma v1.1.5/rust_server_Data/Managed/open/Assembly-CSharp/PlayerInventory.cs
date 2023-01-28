using System;
using System.Collections.Generic;
using RustProto;
using RustProto.Helpers;
using uLink;
using UnityEngine;

// Token: 0x0200071E RID: 1822
public class PlayerInventory : global::CraftingInventory, global::FixedSizeInventory
{
	// Token: 0x06003DC5 RID: 15813 RVA: 0x000D8830 File Offset: 0x000D6A30
	public PlayerInventory()
	{
	}

	// Token: 0x06003DC6 RID: 15814 RVA: 0x000D8840 File Offset: 0x000D6A40
	protected void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		base.InitializeThisFixedSizeInventory();
	}

	// Token: 0x06003DC7 RID: 15815 RVA: 0x000D884C File Offset: 0x000D6A4C
	public void MakeBPsDirty()
	{
		this.bpDirty = true;
	}

	// Token: 0x06003DC8 RID: 15816 RVA: 0x000D8858 File Offset: 0x000D6A58
	protected override void ConfigureSlots(int totalCount, ref global::Inventory.Slot.KindDictionary<global::Inventory.Slot.Range> ranges, ref global::Inventory.SlotFlags[] flags)
	{
		if (totalCount != 0x28)
		{
			global::UnityEngine.Debug.LogError("Invalid size for player inventory " + totalCount, this);
		}
		ranges = global::PlayerInventory.LateLoaded.SlotRanges;
		flags = global::PlayerInventory.LateLoaded.EveryPlayerInventory;
		this._boundBPs = new global::System.Collections.Generic.List<global::BlueprintDataBlock>();
	}

	// Token: 0x06003DC9 RID: 15817 RVA: 0x000D8898 File Offset: 0x000D6A98
	public bool KnowsBP(global::BlueprintDataBlock bp)
	{
		return bp && this._boundBPs.Contains(bp);
	}

	// Token: 0x06003DCA RID: 15818 RVA: 0x000D88B4 File Offset: 0x000D6AB4
	public bool BindBlueprint(global::BlueprintDataBlock bp)
	{
		if (bp == null)
		{
			global::UnityEngine.Debug.Log("Tried to bind a null blueprint!");
			return false;
		}
		if (!this._boundBPs.Contains(bp))
		{
			this._boundBPs.Add(bp);
			this.MakeBPsDirty();
			return true;
		}
		return false;
	}

	// Token: 0x06003DCB RID: 15819 RVA: 0x000D8900 File Offset: 0x000D6B00
	protected new void UpdateToNetListeners()
	{
		base.UpdateToNetListeners();
		if (this.lastUpdateToNetListenersSent)
		{
			base.InvalidateArmor();
		}
		if (this.bpDirty)
		{
			this.SendBoundBPs();
			this.bpDirty = false;
		}
	}

	// Token: 0x06003DCC RID: 15820 RVA: 0x000D8940 File Offset: 0x000D6B40
	public void SendBoundBPs()
	{
		if (this._boundBPs == null)
		{
			global::UnityEngine.Debug.Log("Bound bp's null!! can't send!");
			return;
		}
		global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
		bitStream.WriteInt32(this._boundBPs.Count);
		foreach (global::BlueprintDataBlock blueprintDataBlock in this._boundBPs)
		{
			bitStream.WriteInt32(blueprintDataBlock.uniqueID);
		}
		base.networkView.RPC<byte[]>("ReceiveBoundBPs", 3, bitStream.GetDataByteArray());
	}

	// Token: 0x06003DCD RID: 15821 RVA: 0x000D89F0 File Offset: 0x000D6BF0
	[global::NGCRPCSkip]
	[global::UnityEngine.RPC]
	public void ReceiveBoundBPs(byte[] data, global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06003DCE RID: 15822 RVA: 0x000D89F4 File Offset: 0x000D6BF4
	public global::System.Collections.Generic.List<global::BlueprintDataBlock> GetBoundBPs()
	{
		return this._boundBPs;
	}

	// Token: 0x06003DCF RID: 15823 RVA: 0x000D89FC File Offset: 0x000D6BFC
	public void SaveToAvatar(ref global::RustProto.Avatar.Builder avatar)
	{
		if (this._boundBPs != null)
		{
			using (global::RustProto.Helpers.Recycler<global::RustProto.Blueprint, global::RustProto.Blueprint.Builder> recycler = global::RustProto.Blueprint.Recycler())
			{
				global::RustProto.Blueprint.Builder builder = recycler.OpenBuilder();
				for (int i = 0; i < this._boundBPs.Count; i++)
				{
					builder.Clear();
					builder.SetId(this._boundBPs[i].uniqueID);
					avatar.AddBlueprints(builder);
				}
			}
		}
		using (global::RustProto.Helpers.Recycler<global::RustProto.Item, global::RustProto.Item.Builder> recycler2 = global::RustProto.Item.Recycler())
		{
			global::RustProto.Item.Builder builder2 = recycler2.OpenBuilder();
			using (global::Inventory.OccupiedIterator occupiedIterator = base.occupiedIterator)
			{
				global::InventoryItem invitem;
				int num;
				while (occupiedIterator.Next(out invitem, out num))
				{
					builder2.Clear();
					if (base.SaveItem(invitem, num, ref builder2))
					{
						if (global::PlayerInventory.IsEquipmentSlot(num))
						{
							builder2.SetSlot(num - 0x24);
							avatar.AddWearable(builder2);
						}
						else if (global::PlayerInventory.IsBeltSlot(num))
						{
							builder2.SetSlot(num - 0x1E);
							avatar.AddBelt(builder2);
						}
						else
						{
							avatar.AddInventory(builder2);
						}
					}
				}
			}
		}
	}

	// Token: 0x06003DD0 RID: 15824 RVA: 0x000D8B8C File Offset: 0x000D6D8C
	public void LoadToAvatar(ref global::RustProto.Avatar avatar)
	{
		for (int i = 0; i < avatar.BlueprintsCount; i++)
		{
			global::RustProto.Blueprint blueprints = avatar.GetBlueprints(i);
			global::BlueprintDataBlock blueprintDataBlock = global::DatablockDictionary.GetByUniqueID(blueprints.Id) as global::BlueprintDataBlock;
			if (!(blueprintDataBlock == null))
			{
				this.BindBlueprint(blueprintDataBlock);
			}
		}
		for (int j = 0; j < avatar.InventoryCount; j++)
		{
			global::RustProto.Item inventory = avatar.GetInventory(j);
			base.LoadItem(ref inventory);
		}
		for (int k = 0; k < avatar.BeltCount; k++)
		{
			global::RustProto.Item belt = avatar.GetBelt(k);
			base.LoadItem(ref belt, 0x1E);
		}
		for (int l = 0; l < avatar.WearableCount; l++)
		{
			global::RustProto.Item wearable = avatar.GetWearable(l);
			base.LoadItem(ref wearable, 0x24);
		}
	}

	// Token: 0x06003DD1 RID: 15825 RVA: 0x000D8C74 File Offset: 0x000D6E74
	protected override bool CheckSlotFlags(global::Inventory.SlotFlags itemSlotFlags, global::Inventory.SlotFlags slotFlags)
	{
		return base.CheckSlotFlags(itemSlotFlags, slotFlags) && ((slotFlags & global::Inventory.SlotFlags.Equip) != global::Inventory.SlotFlags.Equip || (itemSlotFlags & slotFlags) == slotFlags);
	}

	// Token: 0x06003DD2 RID: 15826 RVA: 0x000D8CA4 File Offset: 0x000D6EA4
	public static bool IsEquipmentSlot(int slot)
	{
		return slot >= 0x24 && slot < 0x28;
	}

	// Token: 0x06003DD3 RID: 15827 RVA: 0x000D8CB8 File Offset: 0x000D6EB8
	public static bool IsBeltSlot(int slot)
	{
		return slot >= 0x1E && slot < 0x24;
	}

	// Token: 0x06003DD4 RID: 15828 RVA: 0x000D8CCC File Offset: 0x000D6ECC
	protected override void DoSetActiveItem(global::InventoryItem item)
	{
		global::InventoryItem activeItem = this._activeItem;
		this._activeItem = item;
		if (activeItem != null)
		{
			global::IHeldItem heldItem = activeItem.iface as global::IHeldItem;
			if (heldItem != null)
			{
				heldItem.OnDeactivate();
			}
		}
		if (this._activeItem != null)
		{
			global::IHeldItem heldItem2 = this._activeItem as global::IHeldItem;
			if (heldItem2 != null)
			{
				heldItem2.OnActivate();
			}
		}
	}

	// Token: 0x06003DD5 RID: 15829 RVA: 0x000D8D28 File Offset: 0x000D6F28
	protected override void DoDeactivateItem()
	{
		if (this._activeItem != null)
		{
			global::IHeldItem heldItem = this._activeItem as global::IHeldItem;
			if (heldItem != null)
			{
				heldItem.OnDeactivate();
			}
		}
		this._activeItem = null;
		base.DoDeactivateItem();
	}

	// Token: 0x17000BC5 RID: 3013
	// (get) Token: 0x06003DD6 RID: 15830 RVA: 0x000D8D68 File Offset: 0x000D6F68
	private new global::EquipmentWearer equipmentWearer
	{
		get
		{
			return (!this._equipmentWearer) ? (this._equipmentWearer = base.GetLocal<global::EquipmentWearer>()) : this._equipmentWearer;
		}
	}

	// Token: 0x06003DD7 RID: 15831 RVA: 0x000D8DA0 File Offset: 0x000D6FA0
	private void UpdateEquipment()
	{
		global::EquipmentWearer equipmentWearer = this.equipmentWearer;
		if (equipmentWearer)
		{
			equipmentWearer.EquipmentUpdate();
		}
	}

	// Token: 0x06003DD8 RID: 15832 RVA: 0x000D8DC8 File Offset: 0x000D6FC8
	protected override void ItemRemoved(int slot, global::IInventoryItem item)
	{
		if (global::PlayerInventory.IsEquipmentSlot(slot))
		{
			global::IEquipmentItem equipmentItem = item as global::IEquipmentItem;
			if (equipmentItem != null)
			{
				equipmentItem.OnUnEquipped();
				this.UpdateEquipment();
			}
		}
	}

	// Token: 0x06003DD9 RID: 15833 RVA: 0x000D8DFC File Offset: 0x000D6FFC
	protected override void ItemAdded(int slot, global::IInventoryItem item)
	{
		if (global::PlayerInventory.IsEquipmentSlot(slot))
		{
			global::IEquipmentItem equipmentItem = item as global::IEquipmentItem;
			if (equipmentItem != null)
			{
				equipmentItem.OnEquipped();
				this.UpdateEquipment();
			}
		}
	}

	// Token: 0x06003DDA RID: 15834 RVA: 0x000D8E30 File Offset: 0x000D7030
	protected override bool GetArmorDatablockMap(ref global::ArmorModelMemberMap<global::ArmorDataBlock> map)
	{
		map.Clear();
		int i = 0x24;
		int num = 0x28;
		while (i < num)
		{
			global::InventoryItem inventoryItem;
			if (base.GetItem(i, out inventoryItem))
			{
				global::ArmorDataBlock armorDataBlock = inventoryItem.datablock as global::ArmorDataBlock;
				global::ArmorModelSlot slot;
				if (armorDataBlock && armorDataBlock.GetArmorModelSlot(out slot))
				{
					map[slot] = armorDataBlock;
				}
			}
			i++;
		}
		return true;
	}

	// Token: 0x17000BC6 RID: 3014
	// (get) Token: 0x06003DDB RID: 15835 RVA: 0x000D8E9C File Offset: 0x000D709C
	public int fixedSlotCount
	{
		get
		{
			return 0x28;
		}
	}

	// Token: 0x06003DDC RID: 15836 RVA: 0x000D8EA0 File Offset: 0x000D70A0
	public bool GetArmorItem<IArmorItem>(global::ArmorModelSlot slot, out IArmorItem item) where IArmorItem : class, global::IInventoryItem
	{
		int slot2;
		switch (slot)
		{
		case global::ArmorModelSlot.Feet:
			slot2 = 0x27;
			break;
		case global::ArmorModelSlot.Legs:
			slot2 = 0x26;
			break;
		case global::ArmorModelSlot.Torso:
			slot2 = 0x25;
			break;
		case global::ArmorModelSlot.Head:
			slot2 = 0x24;
			break;
		default:
			item = (IArmorItem)((object)null);
			return false;
		}
		global::IInventoryItem inventoryItem;
		if (base.GetItem(slot2, out inventoryItem))
		{
			return !object.ReferenceEquals(item = (inventoryItem as IArmorItem), null);
		}
		item = (IArmorItem)((object)null);
		return false;
	}

	// Token: 0x04001F38 RID: 7992
	private const int _storageSpace = 0x1E;

	// Token: 0x04001F39 RID: 7993
	private const int _beltSpace = 6;

	// Token: 0x04001F3A RID: 7994
	private const int _equipSpace = 4;

	// Token: 0x04001F3B RID: 7995
	public const int EquipmentStart = 0x24;

	// Token: 0x04001F3C RID: 7996
	public const int EquipmentEnd = 0x28;

	// Token: 0x04001F3D RID: 7997
	public const int NumEquipItems = 4;

	// Token: 0x04001F3E RID: 7998
	public const int BeltStart = 0x1E;

	// Token: 0x04001F3F RID: 7999
	public const int BeltEnd = 0x24;

	// Token: 0x04001F40 RID: 8000
	public const int NumBeltItems = 6;

	// Token: 0x04001F41 RID: 8001
	public const int StorageStart = 0;

	// Token: 0x04001F42 RID: 8002
	public const int StorageEnd = 0x1E;

	// Token: 0x04001F43 RID: 8003
	public const int NumStorageItems = 0x1E;

	// Token: 0x04001F44 RID: 8004
	private const int TotalSlotCount = 0x28;

	// Token: 0x04001F45 RID: 8005
	private global::System.Collections.Generic.List<global::BlueprintDataBlock> _boundBPs;

	// Token: 0x04001F46 RID: 8006
	public bool bpDirty = true;

	// Token: 0x04001F47 RID: 8007
	[global::System.NonSerialized]
	private global::EquipmentWearer _equipmentWearer;

	// Token: 0x0200071F RID: 1823
	private static class LateLoaded
	{
		// Token: 0x06003DDD RID: 15837 RVA: 0x000D8F38 File Offset: 0x000D7138
		static LateLoaded()
		{
			for (int i = 0; i < 0x28; i++)
			{
				global::Inventory.SlotFlags slotFlags = (global::Inventory.SlotFlags)0;
				if (global::PlayerInventory.IsBeltSlot(i))
				{
					slotFlags |= global::Inventory.SlotFlags.Belt;
				}
				if (i == 0x1E)
				{
					slotFlags |= global::Inventory.SlotFlags.Safe;
				}
				if (global::PlayerInventory.IsEquipmentSlot(i))
				{
					slotFlags |= global::Inventory.SlotFlags.Equip;
					switch (i)
					{
					case 0x24:
						slotFlags |= global::Inventory.SlotFlags.Head;
						break;
					case 0x25:
						slotFlags |= global::Inventory.SlotFlags.Chest;
						break;
					case 0x26:
						slotFlags |= global::Inventory.SlotFlags.Legs;
						break;
					case 0x27:
						slotFlags |= global::Inventory.SlotFlags.Feet;
						break;
					}
				}
				global::PlayerInventory.LateLoaded.EveryPlayerInventory[i] = slotFlags;
			}
			global::PlayerInventory.LateLoaded.SlotRanges[global::Inventory.Slot.Kind.Default] = new global::Inventory.Slot.Range(0, 0x1E);
			global::PlayerInventory.LateLoaded.SlotRanges[global::Inventory.Slot.Kind.Belt] = new global::Inventory.Slot.Range(0x1E, 6);
			global::PlayerInventory.LateLoaded.SlotRanges[global::Inventory.Slot.Kind.Armor] = new global::Inventory.Slot.Range(0x24, 4);
		}

		// Token: 0x04001F48 RID: 8008
		public static readonly global::Inventory.SlotFlags[] EveryPlayerInventory = new global::Inventory.SlotFlags[0x28];

		// Token: 0x04001F49 RID: 8009
		public static global::Inventory.Slot.KindDictionary<global::Inventory.Slot.Range> SlotRanges;
	}
}
