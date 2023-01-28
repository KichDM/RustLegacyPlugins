using System;

namespace Mono.Cecil.Cil
{
	// Token: 0x0200003C RID: 60
	public struct InstructionSymbol
	{
		// Token: 0x0600032E RID: 814 RVA: 0x000091FA File Offset: 0x000073FA
		public InstructionSymbol(int offset, global::Mono.Cecil.Cil.SequencePoint sequencePoint)
		{
			this.Offset = offset;
			this.SequencePoint = sequencePoint;
		}

		// Token: 0x04000214 RID: 532
		public readonly int Offset;

		// Token: 0x04000215 RID: 533
		public readonly global::Mono.Cecil.Cil.SequencePoint SequencePoint;
	}
}
