using System;

namespace Mono.Cecil
{
	// Token: 0x02000073 RID: 115
	public interface IAssemblyResolver
	{
		// Token: 0x060004F5 RID: 1269
		global::Mono.Cecil.AssemblyDefinition Resolve(global::Mono.Cecil.AssemblyNameReference name);

		// Token: 0x060004F6 RID: 1270
		global::Mono.Cecil.AssemblyDefinition Resolve(global::Mono.Cecil.AssemblyNameReference name, global::Mono.Cecil.ReaderParameters parameters);

		// Token: 0x060004F7 RID: 1271
		global::Mono.Cecil.AssemblyDefinition Resolve(string fullName);

		// Token: 0x060004F8 RID: 1272
		global::Mono.Cecil.AssemblyDefinition Resolve(string fullName, global::Mono.Cecil.ReaderParameters parameters);
	}
}
