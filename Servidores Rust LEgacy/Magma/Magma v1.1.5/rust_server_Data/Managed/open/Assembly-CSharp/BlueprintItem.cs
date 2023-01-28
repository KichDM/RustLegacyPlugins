using System;

// Token: 0x020006DE RID: 1758
public abstract class BlueprintItem<T> : global::ToolItem<T> where T : global::BlueprintDataBlock
{
	// Token: 0x06003BFB RID: 15355 RVA: 0x000D4F08 File Offset: 0x000D3108
	protected BlueprintItem(T db) : base(db)
	{
	}

	// Token: 0x17000B3D RID: 2877
	// (get) Token: 0x06003BFC RID: 15356 RVA: 0x000D4F14 File Offset: 0x000D3114
	public override float workDuration
	{
		get
		{
			T datablock = this.datablock;
			return datablock.GetWorkDuration(this.iface as global::IToolItem);
		}
	}

	// Token: 0x06003BFD RID: 15357 RVA: 0x000D4F40 File Offset: 0x000D3140
	public override void OnBeltUse()
	{
		T datablock = this.datablock;
		datablock.UseItem(this.iface as global::IBlueprintItem);
	}
}
