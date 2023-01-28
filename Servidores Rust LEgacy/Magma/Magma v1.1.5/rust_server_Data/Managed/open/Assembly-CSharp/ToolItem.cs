using System;

// Token: 0x0200070E RID: 1806
public abstract class ToolItem<T> : global::InventoryItem<T> where T : global::ToolDataBlock
{
	// Token: 0x06003D3D RID: 15677 RVA: 0x000D786C File Offset: 0x000D5A6C
	protected ToolItem(T db) : base(db)
	{
	}

	// Token: 0x17000B9C RID: 2972
	// (get) Token: 0x06003D3E RID: 15678 RVA: 0x000D7878 File Offset: 0x000D5A78
	public virtual bool canWork
	{
		get
		{
			T datablock = this.datablock;
			return datablock.CanWork(this.iface as global::IToolItem, base.inventory);
		}
	}

	// Token: 0x06003D3F RID: 15679 RVA: 0x000D78AC File Offset: 0x000D5AAC
	public virtual void StartWork()
	{
	}

	// Token: 0x06003D40 RID: 15680 RVA: 0x000D78B0 File Offset: 0x000D5AB0
	public virtual void CancelWork()
	{
	}

	// Token: 0x06003D41 RID: 15681 RVA: 0x000D78B4 File Offset: 0x000D5AB4
	public virtual void CompleteWork()
	{
		T datablock = this.datablock;
		datablock.CompleteWork(this.iface as global::IToolItem, base.inventory);
	}

	// Token: 0x17000B9D RID: 2973
	// (get) Token: 0x06003D42 RID: 15682 RVA: 0x000D78E8 File Offset: 0x000D5AE8
	public virtual float workDuration
	{
		get
		{
			T datablock = this.datablock;
			return datablock.GetWorkDuration(this.iface as global::IToolItem);
		}
	}
}
