using System;

namespace Mono.Cecil
{
	// Token: 0x02000007 RID: 7
	public interface IMarshalInfoProvider : global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000015 RID: 21
		bool HasMarshalInfo { get; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000016 RID: 22
		// (set) Token: 0x06000017 RID: 23
		global::Mono.Cecil.MarshalInfo MarshalInfo { get; set; }
	}
}
