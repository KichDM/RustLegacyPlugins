using System;
using RustProto;

// Token: 0x02000439 RID: 1081
public interface IServerSaveable
{
	// Token: 0x060025B5 RID: 9653
	void WriteObjectSave(ref global::RustProto.SavedObject.Builder saveobj);

	// Token: 0x060025B6 RID: 9654
	void ReadObjectSave(ref global::RustProto.SavedObject saveobj);
}
