using System;

namespace Mono.Cecil
{
	// Token: 0x02000005 RID: 5
	public interface IConstantProvider : global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000F RID: 15
		// (set) Token: 0x06000010 RID: 16
		bool HasConstant { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000011 RID: 17
		// (set) Token: 0x06000012 RID: 18
		object Constant { get; set; }
	}
}
