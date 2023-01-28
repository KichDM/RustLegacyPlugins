using System;
using System.IO;

namespace Mono.Cecil.Cil
{
	// Token: 0x02000040 RID: 64
	public interface ISymbolReaderProvider
	{
		// Token: 0x0600033F RID: 831
		global::Mono.Cecil.Cil.ISymbolReader GetSymbolReader(global::Mono.Cecil.ModuleDefinition module, string fileName);

		// Token: 0x06000340 RID: 832
		global::Mono.Cecil.Cil.ISymbolReader GetSymbolReader(global::Mono.Cecil.ModuleDefinition module, global::System.IO.Stream symbolStream);
	}
}
