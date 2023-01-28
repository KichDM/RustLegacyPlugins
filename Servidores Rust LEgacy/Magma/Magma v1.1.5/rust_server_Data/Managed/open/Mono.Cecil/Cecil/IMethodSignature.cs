using System;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x0200001A RID: 26
	public interface IMethodSignature : global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000122 RID: 290
		// (set) Token: 0x06000123 RID: 291
		bool HasThis { get; set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000124 RID: 292
		// (set) Token: 0x06000125 RID: 293
		bool ExplicitThis { get; set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000126 RID: 294
		// (set) Token: 0x06000127 RID: 295
		global::Mono.Cecil.MethodCallingConvention CallingConvention { get; set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000128 RID: 296
		bool HasParameters { get; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000129 RID: 297
		global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> Parameters { get; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600012A RID: 298
		// (set) Token: 0x0600012B RID: 299
		global::Mono.Cecil.TypeReference ReturnType { get; set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600012C RID: 300
		global::Mono.Cecil.MethodReturnType MethodReturnType { get; }
	}
}
