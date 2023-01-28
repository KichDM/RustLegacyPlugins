using System;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x0200000A RID: 10
	public interface IGenericParameterProvider : global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600003D RID: 61
		bool HasGenericParameters { get; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600003E RID: 62
		bool IsDefinition { get; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600003F RID: 63
		global::Mono.Cecil.ModuleDefinition Module { get; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000040 RID: 64
		global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> GenericParameters { get; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000041 RID: 65
		global::Mono.Cecil.GenericParameterType GenericParameterType { get; }
	}
}
