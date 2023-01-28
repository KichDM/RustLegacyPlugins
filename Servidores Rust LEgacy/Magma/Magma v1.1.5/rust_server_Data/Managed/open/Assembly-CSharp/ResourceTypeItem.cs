using System;
using UnityEngine;

// Token: 0x02000706 RID: 1798
public abstract class ResourceTypeItem<T> : global::InventoryItem<T> where T : global::ResourceTypeItemDataBlock
{
	// Token: 0x06003D12 RID: 15634 RVA: 0x000D6EAC File Offset: 0x000D50AC
	protected ResourceTypeItem(T db) : base(db)
	{
	}

	// Token: 0x17000B91 RID: 2961
	// (get) Token: 0x06003D13 RID: 15635 RVA: 0x000D6EB8 File Offset: 0x000D50B8
	public bool flammable
	{
		get
		{
			return this.datablock.flammable;
		}
	}

	// Token: 0x06003D14 RID: 15636 RVA: 0x000D6ECC File Offset: 0x000D50CC
	public bool GetCookableInfo(out int consumeCount, out global::ItemDataBlock cookedVersion, out int cookedCount, out int cookTempMin, out int burnTemp)
	{
		burnTemp = 0x3B9AC9FF;
		cookTempMin = this.datablock.cookHeatRequirement;
		cookedVersion = this.datablock.cookedVersion;
		if (!this.datablock.cookable || !cookedVersion)
		{
			cookedCount = (consumeCount = 0);
			return false;
		}
		consumeCount = global::UnityEngine.Mathf.Min(2, base.uses);
		cookedCount = consumeCount * global::UnityEngine.Random.Range(this.datablock.numToGiveCookedMin, this.datablock.numToGiveCookedMax + 1);
		if (cookedCount == 0)
		{
			consumeCount = 0;
			return false;
		}
		return true;
	}

	// Token: 0x06003D15 RID: 15637 RVA: 0x000D6F78 File Offset: 0x000D5178
	public override void OnBeltUse()
	{
		if (global::UnityEngine.Time.time - this._lastUseTime < 2f)
		{
			return;
		}
		T datablock = this.datablock;
		datablock.UseItem(this.iface as global::IResourceTypeItem);
	}

	// Token: 0x04001EE0 RID: 7904
	protected float _lastUseTime;
}
