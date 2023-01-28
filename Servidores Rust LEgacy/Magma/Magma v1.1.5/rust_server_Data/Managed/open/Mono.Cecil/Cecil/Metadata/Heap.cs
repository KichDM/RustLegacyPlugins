using System;
using Mono.Cecil.PE;

namespace Mono.Cecil.Metadata
{
	// Token: 0x02000086 RID: 134
	internal abstract class Heap
	{
		// Token: 0x06000579 RID: 1401 RVA: 0x0000DB8E File Offset: 0x0000BD8E
		protected Heap(global::Mono.Cecil.PE.Section section, uint offset, uint size)
		{
			this.Section = section;
			this.Offset = offset;
			this.Size = size;
		}

		// Token: 0x04000374 RID: 884
		public int IndexSize;

		// Token: 0x04000375 RID: 885
		public readonly global::Mono.Cecil.PE.Section Section;

		// Token: 0x04000376 RID: 886
		public readonly uint Offset;

		// Token: 0x04000377 RID: 887
		public readonly uint Size;
	}
}
