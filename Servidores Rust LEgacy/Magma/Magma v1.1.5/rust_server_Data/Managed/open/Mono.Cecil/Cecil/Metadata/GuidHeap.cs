using System;
using Mono.Cecil.PE;

namespace Mono.Cecil.Metadata
{
	// Token: 0x02000095 RID: 149
	internal sealed class GuidHeap : global::Mono.Cecil.Metadata.Heap
	{
		// Token: 0x06000654 RID: 1620 RVA: 0x0000FDEB File Offset: 0x0000DFEB
		public GuidHeap(global::Mono.Cecil.PE.Section section, uint start, uint size) : base(section, start, size)
		{
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x0000FDF8 File Offset: 0x0000DFF8
		public global::System.Guid Read(uint index)
		{
			if (index == 0U)
			{
				return default(global::System.Guid);
			}
			byte[] array = new byte[0x10];
			index -= 1U;
			global::System.Buffer.BlockCopy(this.Section.Data, (int)(this.Offset + index), array, 0, 0x10);
			return new global::System.Guid(array);
		}
	}
}
