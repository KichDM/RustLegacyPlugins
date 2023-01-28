using System;

// Token: 0x020006AB RID: 1707
public struct ModViewModelRemoveArgs
{
	// Token: 0x060038D0 RID: 14544 RVA: 0x000CF710 File Offset: 0x000CD910
	public ModViewModelRemoveArgs(global::ViewModel vm, global::IHeldItem item, global::ItemModRepresentation modRep)
	{
		this.vm = vm;
		this.item = item;
		this.modRep = modRep;
	}

	// Token: 0x060038D1 RID: 14545 RVA: 0x000CF728 File Offset: 0x000CD928
	public ModViewModelRemoveArgs(global::ViewModel vm, global::IHeldItem item)
	{
		this = new global::ModViewModelRemoveArgs(vm, item, null);
	}

	// Token: 0x04001E16 RID: 7702
	public readonly global::ViewModel vm;

	// Token: 0x04001E17 RID: 7703
	public global::ItemModRepresentation modRep;

	// Token: 0x04001E18 RID: 7704
	public readonly global::IHeldItem item;
}
