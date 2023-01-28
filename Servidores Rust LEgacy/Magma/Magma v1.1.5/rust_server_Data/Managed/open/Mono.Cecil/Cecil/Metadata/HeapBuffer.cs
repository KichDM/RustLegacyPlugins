using System;
using Mono.Cecil.PE;

namespace Mono.Cecil.Metadata
{
	// Token: 0x02000096 RID: 150
	internal abstract class HeapBuffer : global::Mono.Cecil.PE.ByteBuffer
	{
		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000656 RID: 1622 RVA: 0x0000FE41 File Offset: 0x0000E041
		public bool IsLarge
		{
			get
			{
				return this.length > 0xFFFF;
			}
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000657 RID: 1623
		public abstract bool IsEmpty { get; }

		// Token: 0x06000658 RID: 1624 RVA: 0x0000FE50 File Offset: 0x0000E050
		protected HeapBuffer(int length) : base(length)
		{
		}
	}
}
