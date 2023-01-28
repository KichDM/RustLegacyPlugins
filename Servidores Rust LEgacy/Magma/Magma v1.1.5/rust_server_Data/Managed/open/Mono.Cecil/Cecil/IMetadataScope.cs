using System;

namespace Mono.Cecil
{
	// Token: 0x0200002C RID: 44
	public interface IMetadataScope : global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600023F RID: 575
		global::Mono.Cecil.MetadataScopeType MetadataScopeType { get; }

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000240 RID: 576
		// (set) Token: 0x06000241 RID: 577
		string Name { get; set; }
	}
}
