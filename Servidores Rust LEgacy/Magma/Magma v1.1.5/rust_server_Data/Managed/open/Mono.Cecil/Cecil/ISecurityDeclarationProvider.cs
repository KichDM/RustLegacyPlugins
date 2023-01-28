using System;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x0200002A RID: 42
	public interface ISecurityDeclarationProvider : global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060001D7 RID: 471
		bool HasSecurityDeclarations { get; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060001D8 RID: 472
		global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration> SecurityDeclarations { get; }
	}
}
