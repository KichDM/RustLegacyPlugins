using System;
using Mono.Cecil.PE;

namespace Mono.Cecil.Metadata
{
	// Token: 0x020000AC RID: 172
	internal sealed class BlobHeap : global::Mono.Cecil.Metadata.Heap
	{
		// Token: 0x0600070A RID: 1802 RVA: 0x00012ACA File Offset: 0x00010CCA
		public BlobHeap(global::Mono.Cecil.PE.Section section, uint start, uint size) : base(section, start, size)
		{
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00012AD8 File Offset: 0x00010CD8
		public byte[] Read(uint index)
		{
			if (index == 0U || index > this.Size - 1U)
			{
				return global::Mono.Empty<byte>.Array;
			}
			byte[] data = this.Section.Data;
			int srcOffset = (int)(index + this.Offset);
			int num = (int)data.ReadCompressedUInt32(ref srcOffset);
			byte[] array = new byte[num];
			global::System.Buffer.BlockCopy(data, srcOffset, array, 0, num);
			return array;
		}
	}
}
