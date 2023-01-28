using System;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x0200004A RID: 74
	public interface ICustomAttribute
	{
		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000377 RID: 887
		global::Mono.Cecil.TypeReference AttributeType { get; }

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000378 RID: 888
		bool HasFields { get; }

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000379 RID: 889
		bool HasProperties { get; }

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x0600037A RID: 890
		global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> Fields { get; }

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x0600037B RID: 891
		global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttributeNamedArgument> Properties { get; }
	}
}
