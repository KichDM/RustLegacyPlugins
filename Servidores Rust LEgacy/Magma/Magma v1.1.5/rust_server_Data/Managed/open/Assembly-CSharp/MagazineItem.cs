using System;

// Token: 0x02000700 RID: 1792
public abstract class MagazineItem<T> : global::InventoryItem<T> where T : global::MagazineDataBlock
{
	// Token: 0x06003CFD RID: 15613 RVA: 0x000D6B90 File Offset: 0x000D4D90
	protected MagazineItem(T db) : base(db)
	{
	}

	// Token: 0x17000B8B RID: 2955
	// (get) Token: 0x06003CFE RID: 15614 RVA: 0x000D6B9C File Offset: 0x000D4D9C
	public int numEmptyBulletSlots
	{
		get
		{
			return this.maxUses - base.uses;
		}
	}

	// Token: 0x17000B8C RID: 2956
	// (get) Token: 0x06003CFF RID: 15615 RVA: 0x000D6BAC File Offset: 0x000D4DAC
	public override string toolTip
	{
		get
		{
			int uses = base.uses;
			if (this.lastUsesStringCount != uses)
			{
				if (uses <= 0)
				{
					string str = "Empty ";
					T datablock = this.datablock;
					this.lastUsesString = str + datablock.name;
				}
				else
				{
					string format = "{0} ({1})";
					T datablock2 = this.datablock;
					this.lastUsesString = string.Format(format, datablock2.name, this.lastUsesStringCount);
				}
				this.lastUsesStringCount = new int?(uses);
			}
			return this.lastUsesString;
		}
	}

	// Token: 0x04001EDC RID: 7900
	private int? lastUsesStringCount;

	// Token: 0x04001EDD RID: 7901
	private string lastUsesString;
}
