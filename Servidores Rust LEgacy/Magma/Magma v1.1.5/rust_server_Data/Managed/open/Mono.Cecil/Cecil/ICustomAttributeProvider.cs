using System;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x02000006 RID: 6
	public interface ICustomAttributeProvider : global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000013 RID: 19
		global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> CustomAttributes { get; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000014 RID: 20
		bool HasCustomAttributes { get; }
	}
}
