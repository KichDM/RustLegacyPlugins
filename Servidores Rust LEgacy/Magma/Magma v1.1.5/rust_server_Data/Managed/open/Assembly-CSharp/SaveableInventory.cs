using System;
using RustProto;

// Token: 0x02000720 RID: 1824
[global::NGCAutoAddScript]
public class SaveableInventory : global::Inventory, global::IServerSaveable
{
	// Token: 0x06003DDE RID: 15838 RVA: 0x000D901C File Offset: 0x000D721C
	public SaveableInventory()
	{
	}

	// Token: 0x06003DDF RID: 15839 RVA: 0x000D9024 File Offset: 0x000D7224
	virtual void WriteObjectSave(ref global::RustProto.SavedObject.Builder saveobj)
	{
		base.WriteObjectSave(ref saveobj);
	}

	// Token: 0x06003DE0 RID: 15840 RVA: 0x000D9030 File Offset: 0x000D7230
	virtual void ReadObjectSave(ref global::RustProto.SavedObject saveobj)
	{
		base.ReadObjectSave(ref saveobj);
	}
}
