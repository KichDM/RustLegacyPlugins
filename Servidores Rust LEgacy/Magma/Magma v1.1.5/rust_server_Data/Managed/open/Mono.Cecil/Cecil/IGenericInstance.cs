using System;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x0200004C RID: 76
	public interface IGenericInstance : global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000383 RID: 899
		bool HasGenericArguments { get; }

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000384 RID: 900
		global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> GenericArguments { get; }
	}
}
