using System;
using UnityEngine;

// Token: 0x020005DF RID: 1503
[global::System.Serializable]
public class ResourceGivePair
{
	// Token: 0x060030DF RID: 12511 RVA: 0x000BA260 File Offset: 0x000B8460
	public ResourceGivePair()
	{
	}

	// Token: 0x17000A3C RID: 2620
	// (get) Token: 0x060030E0 RID: 12512 RVA: 0x000BA274 File Offset: 0x000B8474
	public global::ItemDataBlock ResourceItemDataBlock
	{
		get
		{
			if (!this._setResourceItemDatablock)
			{
				this._resourceItemDatablock = this.ResourceItemName;
				this._setResourceItemDatablock = true;
			}
			return (global::ItemDataBlock)this._resourceItemDatablock.datablock;
		}
	}

	// Token: 0x060030E1 RID: 12513 RVA: 0x000BA2AC File Offset: 0x000B84AC
	public void CalcAmount()
	{
		this.realAmount = global::UnityEngine.Random.Range(this.amountMin, this.amountMax + 1);
	}

	// Token: 0x060030E2 RID: 12514 RVA: 0x000BA2C8 File Offset: 0x000B84C8
	public bool AnyLeft()
	{
		return this.realAmount > 0;
	}

	// Token: 0x060030E3 RID: 12515 RVA: 0x000BA2D4 File Offset: 0x000B84D4
	public int AmountLeft()
	{
		return this.realAmount;
	}

	// Token: 0x060030E4 RID: 12516 RVA: 0x000BA2DC File Offset: 0x000B84DC
	public void Subtract(int amount)
	{
		this.realAmount -= amount;
	}

	// Token: 0x04001A97 RID: 6807
	[global::System.NonSerialized]
	public global::Datablock.Ident _resourceItemDatablock;

	// Token: 0x04001A98 RID: 6808
	[global::System.NonSerialized]
	private bool _setResourceItemDatablock;

	// Token: 0x04001A99 RID: 6809
	public string ResourceItemName = string.Empty;

	// Token: 0x04001A9A RID: 6810
	public int amountMin;

	// Token: 0x04001A9B RID: 6811
	public int amountMax;

	// Token: 0x04001A9C RID: 6812
	private int realAmount;
}
