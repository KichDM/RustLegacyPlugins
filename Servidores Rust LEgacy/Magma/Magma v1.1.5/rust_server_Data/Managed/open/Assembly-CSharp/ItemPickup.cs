using System;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x0200078B RID: 1931
[global::NGCAutoAddScript]
[global::UnityEngine.RequireComponent(typeof(global::Inventory))]
public class ItemPickup : global::RigidObj, global::IContextRequestable, global::IContextRequestableQuick, global::IContextRequestableText, global::IContextRequestablePointText, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour, global::Contextual>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IContextRequestable>
{
	// Token: 0x0600401E RID: 16414 RVA: 0x000E5348 File Offset: 0x000E3548
	public ItemPickup() : base(global::RigidObj.FeatureFlags.StreamInitialVelocity)
	{
	}

	// Token: 0x0600401F RID: 16415 RVA: 0x000E5354 File Offset: 0x000E3554
	protected new void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		base.GetLocal<global::Inventory>().TryToInitializeSize(1);
		base.Invoke("DestroyTime", 90f);
		base.uLink_OnNetworkInstantiate(info);
	}

	// Token: 0x06004020 RID: 16416 RVA: 0x000E5388 File Offset: 0x000E3588
	private void UpdateItemInfo(global::IInventoryItem item)
	{
		global::NetEntityID entID = global::NetEntityID.Get(this);
		if ((int)this.sentItemInfo != 0)
		{
			if ((int)this.sentItemInfo == 1)
			{
				global::NetCull.RemoveRPCsByName(entID, "PKIS");
			}
			else
			{
				global::NetCull.RemoveRPCsByName(entID, "PKIF");
			}
			this.sentItemInfo = 0;
		}
		global::ItemDataBlock datablock = item.datablock;
		int uses;
		if (datablock.IsSplittable() && (uses = item.uses) > 1)
		{
			global::NetCull.RPC<int, byte>(entID, "PKIF", 5, datablock.uniqueID, (byte)uses);
			this.sentItemInfo = 2;
		}
		else
		{
			global::NetCull.RPC<int>(entID, "PKIS", 5, datablock.uniqueID);
			this.sentItemInfo = 1;
		}
	}

	// Token: 0x06004021 RID: 16417 RVA: 0x000E5434 File Offset: 0x000E3634
	public bool SetPickupItem(global::IInventoryItem item)
	{
		global::Inventory local = base.GetLocal<global::Inventory>();
		global::Inventory.AddExistingItemResult addExistingItemResult = local.AddExistingItem(item, true);
		if (addExistingItemResult != global::Inventory.AddExistingItemResult.Failed && addExistingItemResult != global::Inventory.AddExistingItemResult.BadItemArgument)
		{
			this.UpdateItemInfo(local.firstItem);
			return true;
		}
		return false;
	}

	// Token: 0x06004022 RID: 16418 RVA: 0x000E5474 File Offset: 0x000E3674
	[global::UnityEngine.RPC]
	protected void PKIS(int itemName)
	{
	}

	// Token: 0x06004023 RID: 16419 RVA: 0x000E5478 File Offset: 0x000E3678
	[global::UnityEngine.RPC]
	protected void PKIF(int itemName, byte itemAmount)
	{
	}

	// Token: 0x06004024 RID: 16420 RVA: 0x000E547C File Offset: 0x000E367C
	public global::ContextExecution ContextQuery(global::Controllable controllable, ulong timestamp)
	{
		return global::ContextExecution.Quick;
	}

	// Token: 0x06004025 RID: 16421 RVA: 0x000E5480 File Offset: 0x000E3680
	public global::ContextResponse ContextRespondQuick(global::Controllable controllable, ulong timestamp)
	{
		if (this.PlayerUse(controllable))
		{
			return global::ContextResponse.DoneBreak;
		}
		return global::ContextResponse.FailBreak;
	}

	// Token: 0x06004026 RID: 16422 RVA: 0x000E5494 File Offset: 0x000E3694
	protected void RemoveThis()
	{
		base.CancelInvoke();
		global::RigidObj.MakeDoneAndDestroy(this);
	}

	// Token: 0x06004027 RID: 16423 RVA: 0x000E54A4 File Offset: 0x000E36A4
	protected bool PlayerUse(global::Controllable controllable)
	{
		global::Inventory local = controllable.GetLocal<global::Inventory>();
		if (!local)
		{
			return false;
		}
		global::Inventory local2 = base.GetLocal<global::Inventory>();
		global::IInventoryItem firstItem;
		if (!local2 || object.ReferenceEquals(firstItem = local2.firstItem, null))
		{
			this.RemoveThis();
			return false;
		}
		switch (local.AddExistingItem(firstItem, false))
		{
		case global::Inventory.AddExistingItemResult.CompletlyStacked:
			local2.RemoveItem(firstItem);
			break;
		case global::Inventory.AddExistingItemResult.Moved:
			break;
		case global::Inventory.AddExistingItemResult.PartiallyStacked:
			this.UpdateItemInfo(firstItem);
			return true;
		case global::Inventory.AddExistingItemResult.Failed:
			return false;
		case global::Inventory.AddExistingItemResult.BadItemArgument:
			this.RemoveThis();
			return false;
		default:
			throw new global::System.NotImplementedException();
		}
		this.RemoveThis();
		return true;
	}

	// Token: 0x06004028 RID: 16424 RVA: 0x000E554C File Offset: 0x000E374C
	private void DestroyTime()
	{
		global::RigidObj.MakeDoneAndDestroy(this);
	}

	// Token: 0x06004029 RID: 16425 RVA: 0x000E5554 File Offset: 0x000E3754
	protected override void OnDone()
	{
	}

	// Token: 0x0600402A RID: 16426 RVA: 0x000E5558 File Offset: 0x000E3758
	protected override void OnHide()
	{
		if (base.renderer)
		{
			base.renderer.enabled = false;
		}
	}

	// Token: 0x0600402B RID: 16427 RVA: 0x000E5578 File Offset: 0x000E3778
	protected override void OnShow()
	{
		if (base.renderer)
		{
			base.renderer.enabled = true;
		}
	}

	// Token: 0x04002168 RID: 8552
	private const string ItemInfoOne_RPC = "PKIS";

	// Token: 0x04002169 RID: 8553
	private const string ItemInfo_RPC = "PKIF";

	// Token: 0x0400216A RID: 8554
	[global::System.NonSerialized]
	private global::ItemPickup.PickupInfo? info;

	// Token: 0x0400216B RID: 8555
	[global::System.NonSerialized]
	private sbyte sentItemInfo;

	// Token: 0x0200078C RID: 1932
	private struct PickupInfo : global::System.IEquatable<global::ItemPickup.PickupInfo>
	{
		// Token: 0x0600402C RID: 16428 RVA: 0x000E5598 File Offset: 0x000E3798
		public bool Equals(global::ItemPickup.PickupInfo other)
		{
			return this.datablock == other.datablock && this.amount == other.amount;
		}

		// Token: 0x0600402D RID: 16429 RVA: 0x000E55C4 File Offset: 0x000E37C4
		public override int GetHashCode()
		{
			return (!this.datablock) ? this.amount : (this.datablock.GetHashCode() ^ this.amount);
		}

		// Token: 0x0600402E RID: 16430 RVA: 0x000E55F4 File Offset: 0x000E37F4
		public override bool Equals(object obj)
		{
			return obj is global::ItemPickup.PickupInfo && this.Equals((global::ItemPickup.PickupInfo)obj);
		}

		// Token: 0x0600402F RID: 16431 RVA: 0x000E5610 File Offset: 0x000E3810
		public override string ToString()
		{
			if (this.datablock)
			{
				if (this.amount > 1 && this.datablock.IsSplittable())
				{
					return string.Format("{0} x{1}", this.datablock.name, this.amount);
				}
				return this.datablock.name;
			}
			else
			{
				if (this.amount > 1)
				{
					return string.Format("null x{0}", this.amount);
				}
				return "null";
			}
		}

		// Token: 0x0400216C RID: 8556
		public global::ItemDataBlock datablock;

		// Token: 0x0400216D RID: 8557
		public int amount;
	}
}
