using System;

namespace Mono.Cecil.Cil
{
	// Token: 0x02000042 RID: 66
	public interface ISymbolWriter : global::System.IDisposable
	{
		// Token: 0x06000347 RID: 839
		bool GetDebugHeader(out global::Mono.Cecil.Cil.ImageDebugDirectory directory, out byte[] header);

		// Token: 0x06000348 RID: 840
		void Write(global::Mono.Cecil.Cil.MethodBody body);

		// Token: 0x06000349 RID: 841
		void Write(global::Mono.Cecil.Cil.MethodSymbols symbols);
	}
}
