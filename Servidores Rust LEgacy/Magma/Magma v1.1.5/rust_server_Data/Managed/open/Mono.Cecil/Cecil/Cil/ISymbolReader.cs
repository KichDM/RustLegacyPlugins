using System;

namespace Mono.Cecil.Cil
{
	// Token: 0x0200003F RID: 63
	public interface ISymbolReader : global::System.IDisposable
	{
		// Token: 0x0600033C RID: 828
		bool ProcessDebugHeader(global::Mono.Cecil.Cil.ImageDebugDirectory directory, byte[] header);

		// Token: 0x0600033D RID: 829
		void Read(global::Mono.Cecil.Cil.MethodBody body, global::Mono.Cecil.Cil.InstructionMapper mapper);

		// Token: 0x0600033E RID: 830
		void Read(global::Mono.Cecil.Cil.MethodSymbols symbols);
	}
}
