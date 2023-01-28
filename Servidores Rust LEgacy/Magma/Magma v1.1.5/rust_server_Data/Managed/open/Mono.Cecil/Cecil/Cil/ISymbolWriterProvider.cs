using System;
using System.IO;

namespace Mono.Cecil.Cil
{
	// Token: 0x02000043 RID: 67
	public interface ISymbolWriterProvider
	{
		// Token: 0x0600034A RID: 842
		global::Mono.Cecil.Cil.ISymbolWriter GetSymbolWriter(global::Mono.Cecil.ModuleDefinition module, string fileName);

		// Token: 0x0600034B RID: 843
		global::Mono.Cecil.Cil.ISymbolWriter GetSymbolWriter(global::Mono.Cecil.ModuleDefinition module, global::System.IO.Stream symbolStream);
	}
}
