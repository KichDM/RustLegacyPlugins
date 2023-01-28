using System;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x020006C5 RID: 1733
public class InventoryHolder : global::IDLocalCharacter
{
	// Token: 0x06003B47 RID: 15175 RVA: 0x000D2724 File Offset: 0x000D0924
	public InventoryHolder()
	{
	}

	// Token: 0x17000B1C RID: 2844
	// (get) Token: 0x06003B48 RID: 15176 RVA: 0x000D272C File Offset: 0x000D092C
	public global::Inventory inventory
	{
		get
		{
			if (!this._inventory.cached)
			{
				this._inventory = base.GetLocal<global::Inventory>();
			}
			return this._inventory.value;
		}
	}

	// Token: 0x17000B1D RID: 2845
	// (get) Token: 0x06003B49 RID: 15177 RVA: 0x000D2768 File Offset: 0x000D0968
	public global::IInventoryItem inputItem
	{
		get
		{
			global::Inventory inventory = this.inventory;
			global::IInventoryItem result;
			if (inventory)
			{
				global::IInventoryItem activeItem = inventory.activeItem;
				result = activeItem;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}

	// Token: 0x17000B1E RID: 2846
	// (get) Token: 0x06003B4A RID: 15178 RVA: 0x000D2798 File Offset: 0x000D0998
	public global::ItemModFlags modFlags
	{
		get
		{
			if (this.hasItem && this.itemRep)
			{
				return this.itemRep.modFlags;
			}
			global::IHeldItem heldItem = this.inputItem as global::IHeldItem;
			if (!object.ReferenceEquals(heldItem, null))
			{
				return heldItem.modFlags;
			}
			return global::ItemModFlags.Other;
		}
	}

	// Token: 0x17000B1F RID: 2847
	// (get) Token: 0x06003B4B RID: 15179 RVA: 0x000D27EC File Offset: 0x000D09EC
	public bool hasItemRepresentation
	{
		get
		{
			return this.hasItem;
		}
	}

	// Token: 0x17000B20 RID: 2848
	// (get) Token: 0x06003B4C RID: 15180 RVA: 0x000D27F4 File Offset: 0x000D09F4
	public global::ItemRepresentation itemRepresentation
	{
		get
		{
			return this.itemRep;
		}
	}

	// Token: 0x17000B21 RID: 2849
	// (get) Token: 0x06003B4D RID: 15181 RVA: 0x000D27FC File Offset: 0x000D09FC
	public string animationGroupName
	{
		get
		{
			return this._animationGroupNameCached;
		}
	}

	// Token: 0x06003B4E RID: 15182 RVA: 0x000D2804 File Offset: 0x000D0A04
	private void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		if (!info.networkView.isMine)
		{
			global::Inventory inventory = this.inventory;
			if (inventory)
			{
				inventory.AddNetListener(base.networkView.owner);
			}
		}
	}

	// Token: 0x06003B4F RID: 15183 RVA: 0x000D2848 File Offset: 0x000D0A48
	public void TryGiveDefaultItems()
	{
		global::Loadout loadout = base.GetTrait<global::CharacterLoadoutTrait>().loadout;
		if (loadout)
		{
			loadout.ApplyTo(this.inventory);
		}
	}

	// Token: 0x06003B50 RID: 15184 RVA: 0x000D2878 File Offset: 0x000D0A78
	internal void SetItemRepresentation(global::ItemRepresentation value)
	{
		if (this.itemRep != value)
		{
			this.itemRep = value;
			this.hasItem = this.itemRep;
			if (this.hasItem)
			{
				this._animationGroupNameCached = this.itemRep.worldAnimationGroupName;
				if (this._animationGroupNameCached != null && this._animationGroupNameCached.Length == 1)
				{
					this._animationGroupNameCached = null;
				}
			}
			else
			{
				this._animationGroupNameCached = null;
			}
		}
	}

	// Token: 0x06003B51 RID: 15185 RVA: 0x000D28FC File Offset: 0x000D0AFC
	internal void ClearItemRepresentation(global::ItemRepresentation value)
	{
		if (this.hasItem && this.itemRep == value)
		{
			this.itemRep = null;
			this.hasItem = false;
			this._animationGroupNameCached = null;
		}
	}

	// Token: 0x06003B52 RID: 15186 RVA: 0x000D2930 File Offset: 0x000D0B30
	private bool ValidateAntiBeltSpam(ulong timestamp)
	{
		ulong timeInMillis = global::NetCull.timeInMillis;
		if (timeInMillis + 0x320UL >= this.lastItemUseTime)
		{
			this.lastItemUseTime = timeInMillis;
			return true;
		}
		return false;
	}

	// Token: 0x06003B53 RID: 15187 RVA: 0x000D2960 File Offset: 0x000D0B60
	private bool GetPlayerInventory(out global::PlayerInventory inventory)
	{
		inventory = (this.inventory as global::PlayerInventory);
		if (!inventory)
		{
			inventory = null;
			return false;
		}
		inventory = (global::PlayerInventory)this.inventory;
		return inventory;
	}

	// Token: 0x06003B54 RID: 15188 RVA: 0x000D29A0 File Offset: 0x000D0BA0
	public void InventoryModified()
	{
	}

	// Token: 0x06003B55 RID: 15189 RVA: 0x000D29A4 File Offset: 0x000D0BA4
	[global::NGCRPCSkip]
	[global::UnityEngine.RPC]
	protected void TOSS(global::uLink.BitStream stream, global::uLink.NetworkMessageInfo info)
	{
		global::DropHelper.DropItem(this.inventory, (int)global::Inventory.RPCInteger(stream));
	}

	// Token: 0x06003B56 RID: 15190 RVA: 0x000D29B8 File Offset: 0x000D0BB8
	public bool TossItem(int slot)
	{
		global::Facepunch.NetworkView networkView = base.networkView;
		if (!networkView || !networkView.isMine)
		{
			return false;
		}
		global::Inventory inventory = this.inventory;
		global::IInventoryItem inventoryItem;
		if (!inventory || !inventory.GetItem(slot, out inventoryItem))
		{
			return false;
		}
		global::DropHelper.DropItem(inventory, slot);
		return true;
	}

	// Token: 0x06003B57 RID: 15191 RVA: 0x000D2A10 File Offset: 0x000D0C10
	[global::UnityEngine.RPC]
	protected void DoBeltUse(int beltNum)
	{
		if (base.dead)
		{
			return;
		}
		global::PlayerInventory playerInventory;
		if (this.GetPlayerInventory(out playerInventory) && this.ValidateAntiBeltSpam(global::NetCull.timeInMillis))
		{
			global::IInventoryItem inventoryItem;
			if (!playerInventory.GetItem(0x1E + beltNum, out inventoryItem))
			{
				return;
			}
			inventoryItem.OnBeltUse();
		}
	}

	// Token: 0x06003B58 RID: 15192 RVA: 0x000D2A60 File Offset: 0x000D0C60
	public void ServerFrame()
	{
		global::IHeldItem heldItem = this.inputItem as global::IHeldItem;
		if (heldItem != null)
		{
			heldItem.ServerFrame();
		}
	}

	// Token: 0x04001E4F RID: 7759
	private const string TossItem_RPC = "TOSS";

	// Token: 0x04001E50 RID: 7760
	[global::System.NonSerialized]
	private global::CacheRef<global::Inventory> _inventory;

	// Token: 0x04001E51 RID: 7761
	[global::System.NonSerialized]
	private global::ItemRepresentation itemRep;

	// Token: 0x04001E52 RID: 7762
	[global::System.NonSerialized]
	private string _animationGroupNameCached;

	// Token: 0x04001E53 RID: 7763
	[global::System.NonSerialized]
	private ulong lastItemUseTime;

	// Token: 0x04001E54 RID: 7764
	[global::System.NonSerialized]
	private bool hasItem;

	// Token: 0x04001E55 RID: 7765
	[global::System.NonSerialized]
	private bool isPlayerInventory;
}
