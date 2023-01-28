using System;
using UnityEngine;

// Token: 0x020006E4 RID: 1764
public abstract class ConsumableItem<T> : global::InventoryItem<T> where T : global::ConsumableDataBlock
{
	// Token: 0x06003C43 RID: 15427 RVA: 0x000D5578 File Offset: 0x000D3778
	protected ConsumableItem(T db) : base(db)
	{
	}

	// Token: 0x06003C44 RID: 15428 RVA: 0x000D5584 File Offset: 0x000D3784
	public bool GetCookableInfo(out int consumeCount, out global::ItemDataBlock cookedVersion, out int cookedCount, out int cookTempMin, out int burnTemp)
	{
		burnTemp = this.datablock.burnTemp;
		cookTempMin = this.datablock.cookHeatRequirement;
		cookedVersion = this.datablock.cookedVersion;
		if (this.datablock.cookable && cookedVersion)
		{
			cookedCount = (consumeCount = global::UnityEngine.Mathf.Min(2, base.uses));
			return consumeCount > 0;
		}
		cookedCount = (consumeCount = 0);
		return false;
	}

	// Token: 0x06003C45 RID: 15429 RVA: 0x000D560C File Offset: 0x000D380C
	public override void OnBeltUse()
	{
		T datablock = this.datablock;
		datablock.UseItem(this.iface as global::IConsumableItem);
	}
}
