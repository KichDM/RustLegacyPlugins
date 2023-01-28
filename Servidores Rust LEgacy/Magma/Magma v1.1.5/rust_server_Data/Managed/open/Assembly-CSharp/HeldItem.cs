using System;
using System.Runtime.CompilerServices;
using Facepunch;
using InventoryExtensions;
using Rust;
using uLink;
using UnityEngine;

// Token: 0x020006EE RID: 1774
public abstract class HeldItem<T> : global::InventoryItem<T> where T : global::HeldItemDataBlock
{
	// Token: 0x06003C62 RID: 15458 RVA: 0x000D57BC File Offset: 0x000D39BC
	public HeldItem(T datablock) : base(datablock)
	{
	}

	// Token: 0x17000B5C RID: 2908
	// (get) Token: 0x06003C63 RID: 15459 RVA: 0x000D57D4 File Offset: 0x000D39D4
	// (set) Token: 0x06003C64 RID: 15460 RVA: 0x000D57DC File Offset: 0x000D39DC
	public int totalModSlots
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<totalModSlots>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<totalModSlots>k__BackingField = value;
		}
	}

	// Token: 0x17000B5D RID: 2909
	// (get) Token: 0x06003C65 RID: 15461 RVA: 0x000D57E8 File Offset: 0x000D39E8
	// (set) Token: 0x06003C66 RID: 15462 RVA: 0x000D57F0 File Offset: 0x000D39F0
	public int usedModSlots
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<usedModSlots>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<usedModSlots>k__BackingField = value;
		}
	}

	// Token: 0x17000B5E RID: 2910
	// (get) Token: 0x06003C67 RID: 15463 RVA: 0x000D57FC File Offset: 0x000D39FC
	public int freeModSlots
	{
		get
		{
			return this.totalModSlots - this.usedModSlots;
		}
	}

	// Token: 0x17000B5F RID: 2911
	// (get) Token: 0x06003C68 RID: 15464 RVA: 0x000D580C File Offset: 0x000D3A0C
	public global::ItemModDataBlock[] itemMods
	{
		get
		{
			return this._itemMods;
		}
	}

	// Token: 0x17000B60 RID: 2912
	// (get) Token: 0x06003C69 RID: 15465 RVA: 0x000D5814 File Offset: 0x000D3A14
	// (set) Token: 0x06003C6A RID: 15466 RVA: 0x000D581C File Offset: 0x000D3A1C
	public global::ViewModel viewModelInstance
	{
		get
		{
			return this._vm;
		}
		protected set
		{
			this._vm = value;
		}
	}

	// Token: 0x17000B61 RID: 2913
	// (get) Token: 0x06003C6B RID: 15467 RVA: 0x000D5828 File Offset: 0x000D3A28
	// (set) Token: 0x06003C6C RID: 15468 RVA: 0x000D5830 File Offset: 0x000D3A30
	public global::ItemRepresentation itemRepresentation
	{
		get
		{
			return this._itemRep;
		}
		set
		{
			this.SetItemRepresentation(value);
		}
	}

	// Token: 0x17000B62 RID: 2914
	// (get) Token: 0x06003C6D RID: 15469 RVA: 0x000D583C File Offset: 0x000D3A3C
	public bool canActivate
	{
		get
		{
			return this.CanSetActivate(true);
		}
	}

	// Token: 0x17000B63 RID: 2915
	// (get) Token: 0x06003C6E RID: 15470 RVA: 0x000D5848 File Offset: 0x000D3A48
	public bool canDeactivate
	{
		get
		{
			return this.CanSetActivate(false);
		}
	}

	// Token: 0x06003C6F RID: 15471 RVA: 0x000D5854 File Offset: 0x000D3A54
	protected virtual bool CanSetActivate(bool value)
	{
		return !value || !base.IsBroken();
	}

	// Token: 0x06003C70 RID: 15472 RVA: 0x000D586C File Offset: 0x000D3A6C
	protected virtual void SetItemRepresentation(global::ItemRepresentation itemRep)
	{
		this._itemRep = itemRep;
		if (this._itemRep)
		{
			if (this._itemRep.datablock != this.datablock)
			{
				global::UnityEngine.Debug.Log("yea the code below wasn't pointless..");
				this._itemRep.SetDataBlockFromHeldItem<T>(this);
			}
			this._itemRep._internal_bind_server_item(this);
			int usedModSlots = this.usedModSlots;
			if (usedModSlots > 0)
			{
				global::uLink.BitStream bitStream = new global::uLink.BitStream(false);
				bitStream.WriteInvInt(usedModSlots);
				for (int i = 0; i < usedModSlots; i++)
				{
					bitStream.WriteInt32(this._itemMods[i].uniqueID);
				}
				this._itemRep.networkView.RPC<byte[]>("Mods", 5, bitStream.GetDataByteArray());
			}
			this._itemRep.SetParent(base.inventory.gameObject);
		}
	}

	// Token: 0x06003C71 RID: 15473 RVA: 0x000D5948 File Offset: 0x000D3B48
	public override void OnBeltUse()
	{
		if (base.active)
		{
			if (this.canDeactivate)
			{
				base.inventory.DeactivateItem();
			}
			return;
		}
		global::IHeldItem heldItem = base.inventory.activeItem as global::IHeldItem;
		if (heldItem != null && !heldItem.canDeactivate)
		{
			return;
		}
		if (this.canActivate)
		{
			base.OnBeltUse();
			global::Facepunch.NetworkView networkView = base.inventory.networkView;
			global::NetworkCullInfo networkCullInfo;
			global::NetworkCullInfo.Find(networkView, out networkCullInfo);
			global::uLink.NetworkPlayer owner = networkView.owner;
			global::NetworkCullInfo group = networkCullInfo;
			global::ItemRepresentation itemRepPrefab = this.datablock._itemRepPrefab;
			global::UnityEngine.Vector3 position = networkView.transform.position;
			global::UnityEngine.Quaternion rotation = networkView.transform.rotation;
			object[] array = new object[2];
			array[0] = networkView.viewID;
			int num = 1;
			T datablock = this.datablock;
			array[num] = datablock.uniqueID;
			global::ItemRepresentation itemRepresentation = global::NetCull.InstantiatePiggyBackWithArgs<global::ItemRepresentation>(owner, group, itemRepPrefab, position, rotation, array);
			base.inventory.SetActiveItemManually(base.slot, itemRepresentation, new global::uLink.NetworkViewID?(itemRepresentation.networkView.viewID));
		}
		else if (base.IsBroken())
		{
			global::Rust.Notice.Popup(base.inventory.networkViewOwner, "", "This item is broken - Repair it", 4f);
		}
	}

	// Token: 0x06003C72 RID: 15474 RVA: 0x000D5A78 File Offset: 0x000D3C78
	public void OnActivate()
	{
		this.OnSetActive(true);
	}

	// Token: 0x06003C73 RID: 15475 RVA: 0x000D5A84 File Offset: 0x000D3C84
	public void OnDeactivate()
	{
		this.OnSetActive(false);
	}

	// Token: 0x06003C74 RID: 15476 RVA: 0x000D5A90 File Offset: 0x000D3C90
	protected virtual void OnSetActive(bool isActive)
	{
		if (this._itemRep && !isActive)
		{
			this._itemRep.networkView.RPC("InterpDestroy", 1, new object[0]);
			global::NetCull.Destroy(this._itemRep.gameObject);
			this._itemRep = null;
		}
	}

	// Token: 0x06003C75 RID: 15477 RVA: 0x000D5AE8 File Offset: 0x000D3CE8
	public override void OnMovedTo(global::Inventory toInv, int toSlot)
	{
		if (base.active)
		{
			base.inventory.DeactivateItem();
		}
	}

	// Token: 0x17000B64 RID: 2916
	// (get) Token: 0x06003C76 RID: 15478 RVA: 0x000D5B00 File Offset: 0x000D3D00
	public bool canAim
	{
		get
		{
			return this.CanAim();
		}
	}

	// Token: 0x06003C77 RID: 15479 RVA: 0x000D5B08 File Offset: 0x000D3D08
	protected virtual bool CanAim()
	{
		return true;
	}

	// Token: 0x06003C78 RID: 15480 RVA: 0x000D5B0C File Offset: 0x000D3D0C
	public virtual void ItemPreFrame(ref global::HumanController.InputSample sample)
	{
		if (sample.attack2 && this.datablock.secondaryFireAims && this.CanAim())
		{
			sample.attack2 = false;
			sample.aim = true;
			sample.yaw *= this.datablock.aimSensitivtyPercent;
			sample.pitch *= this.datablock.aimSensitivtyPercent;
		}
	}

	// Token: 0x06003C79 RID: 15481 RVA: 0x000D5B8C File Offset: 0x000D3D8C
	public virtual void ItemPostFrame(ref global::HumanController.InputSample sample)
	{
	}

	// Token: 0x06003C7A RID: 15482 RVA: 0x000D5B90 File Offset: 0x000D3D90
	private void RecalculateMods()
	{
		int num = 0;
		for (int i = 0; i < 5; i++)
		{
			if (this._itemMods[i] != null)
			{
				num++;
			}
		}
		this.usedModSlots = num;
	}

	// Token: 0x06003C7B RID: 15483 RVA: 0x000D5BD0 File Offset: 0x000D3DD0
	public void AddMod(global::ItemModDataBlock mod)
	{
		this.RecalculateMods();
		int usedModSlots = this.usedModSlots;
		this._itemMods[usedModSlots] = mod;
		this.RecalculateMods();
		this.OnModAdded(mod);
		base.MarkDirty();
	}

	// Token: 0x06003C7C RID: 15484 RVA: 0x000D5C08 File Offset: 0x000D3E08
	public int FindMod(global::ItemModDataBlock mod)
	{
		if (mod)
		{
			for (int i = 0; i < 5; i++)
			{
				if (this._itemMods[i] == mod)
				{
					return i;
				}
			}
		}
		return -1;
	}

	// Token: 0x06003C7D RID: 15485 RVA: 0x000D5C48 File Offset: 0x000D3E48
	protected virtual void OnModAdded(global::ItemModDataBlock mod)
	{
	}

	// Token: 0x06003C7E RID: 15486 RVA: 0x000D5C4C File Offset: 0x000D3E4C
	public virtual void PreCameraRender()
	{
	}

	// Token: 0x06003C7F RID: 15487 RVA: 0x000D5C50 File Offset: 0x000D3E50
	public virtual void ServerFrame()
	{
	}

	// Token: 0x17000B65 RID: 2917
	// (get) Token: 0x06003C80 RID: 15488 RVA: 0x000D5C54 File Offset: 0x000D3E54
	public global::ItemModFlags modFlags
	{
		get
		{
			global::ItemModFlags itemModFlags = global::ItemModFlags.Other;
			if (this._itemMods != null)
			{
				foreach (global::ItemModDataBlock itemModDataBlock in this._itemMods)
				{
					if (itemModDataBlock != null)
					{
						itemModFlags |= itemModDataBlock.modFlag;
					}
				}
			}
			return itemModFlags;
		}
	}

	// Token: 0x06003C81 RID: 15489 RVA: 0x000D5CA4 File Offset: 0x000D3EA4
	public void SetTotalModSlotCount(int count)
	{
		this.totalModSlots = count;
	}

	// Token: 0x06003C82 RID: 15490 RVA: 0x000D5CB0 File Offset: 0x000D3EB0
	public void SetUsedModSlotCount(int count)
	{
		this.usedModSlots = count;
	}

	// Token: 0x06003C83 RID: 15491 RVA: 0x000D5CBC File Offset: 0x000D3EBC
	protected override void OnBitStreamWrite(global::uLink.BitStream stream)
	{
		base.OnBitStreamWrite(stream);
		stream.WriteInvInt(this.totalModSlots);
		int usedModSlots = this.usedModSlots;
		stream.WriteInvInt(usedModSlots);
		for (int i = 0; i < usedModSlots; i++)
		{
			stream.WriteInt32(this._itemMods[i].uniqueID);
		}
	}

	// Token: 0x06003C84 RID: 15492 RVA: 0x000D5D10 File Offset: 0x000D3F10
	protected override void OnBitStreamRead(global::uLink.BitStream stream)
	{
		base.OnBitStreamRead(stream);
		this.SetTotalModSlotCount(stream.ReadInvInt());
		this.SetUsedModSlotCount(stream.ReadInvInt());
		int usedModSlots = this.usedModSlots;
		for (int i = 0; i < 5; i++)
		{
			if (i < usedModSlots)
			{
				this._itemMods[i] = (global::DatablockDictionary.GetByUniqueID(stream.ReadInt32()) as global::ItemModDataBlock);
			}
			else
			{
				this._itemMods[i] = null;
			}
		}
	}

	// Token: 0x06003C85 RID: 15493 RVA: 0x000D5D84 File Offset: 0x000D3F84
	public override void ConditionChanged(float oldCondition)
	{
		if (base.IsBroken() && base.active)
		{
			base.inventory.DeactivateItem();
			global::Rust.Notice.Popup(base.inventory.networkViewOwner, "", "Active item has broken! - Repair it", 4f);
		}
		base.ConditionChanged(oldCondition);
	}

	// Token: 0x04001EAF RID: 7855
	protected global::ItemModDataBlock[] _itemMods = new global::ItemModDataBlock[5];

	// Token: 0x04001EB0 RID: 7856
	private global::ViewModel _vm;

	// Token: 0x04001EB1 RID: 7857
	private global::ItemRepresentation _itemRep;

	// Token: 0x04001EB2 RID: 7858
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <totalModSlots>k__BackingField;

	// Token: 0x04001EB3 RID: 7859
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <usedModSlots>k__BackingField;
}
