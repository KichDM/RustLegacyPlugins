using System;
using RustProto;
using UnityEngine;

// Token: 0x020000E9 RID: 233
public class TestSaveable : global::UnityEngine.MonoBehaviour, global::IServerSaveable
{
	// Token: 0x06000493 RID: 1171 RVA: 0x00015FD0 File Offset: 0x000141D0
	public TestSaveable()
	{
	}

	// Token: 0x06000494 RID: 1172 RVA: 0x00015FD8 File Offset: 0x000141D8
	public void WriteObjectSave(ref global::RustProto.SavedObject.Builder saveobj)
	{
	}

	// Token: 0x06000495 RID: 1173 RVA: 0x00015FDC File Offset: 0x000141DC
	public void ReadObjectSave(ref global::RustProto.SavedObject saveobj)
	{
	}
}
