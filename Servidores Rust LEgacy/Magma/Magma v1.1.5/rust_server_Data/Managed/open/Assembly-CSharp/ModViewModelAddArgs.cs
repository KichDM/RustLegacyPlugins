using System;

// Token: 0x020006AA RID: 1706
public struct ModViewModelAddArgs
{
	// Token: 0x060038CE RID: 14542 RVA: 0x000CF6E4 File Offset: 0x000CD8E4
	public ModViewModelAddArgs(global::ViewModel vm, global::IHeldItem item, bool isMesh, global::ItemModRepresentation modRep)
	{
		this.vm = vm;
		this.item = item;
		this.isMesh = isMesh;
		this.modRep = modRep;
	}

	// Token: 0x060038CF RID: 14543 RVA: 0x000CF704 File Offset: 0x000CD904
	public ModViewModelAddArgs(global::ViewModel vm, global::IHeldItem item, bool isMesh)
	{
		this = new global::ModViewModelAddArgs(vm, item, isMesh, null);
	}

	// Token: 0x04001E12 RID: 7698
	public readonly global::ViewModel vm;

	// Token: 0x04001E13 RID: 7699
	public global::ItemModRepresentation modRep;

	// Token: 0x04001E14 RID: 7700
	public readonly global::IHeldItem item;

	// Token: 0x04001E15 RID: 7701
	public readonly bool isMesh;
}
