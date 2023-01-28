using System;
using System.Collections.Generic;
using Mono.Cecil.PE;

namespace Mono.Cecil.Metadata
{
	// Token: 0x0200009B RID: 155
	internal sealed class BlobHeapBuffer : global::Mono.Cecil.Metadata.HeapBuffer
	{
		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000673 RID: 1651 RVA: 0x000102C5 File Offset: 0x0000E4C5
		public override bool IsEmpty
		{
			get
			{
				return this.length <= 1;
			}
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x000102D3 File Offset: 0x0000E4D3
		public BlobHeapBuffer() : base(1)
		{
			base.WriteByte(0);
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x000102F4 File Offset: 0x0000E4F4
		public uint GetBlobIndex(global::Mono.Cecil.PE.ByteBuffer blob)
		{
			uint position;
			if (this.blobs.TryGetValue(blob, out position))
			{
				return position;
			}
			position = (uint)this.position;
			this.WriteBlob(blob);
			this.blobs.Add(blob, position);
			return position;
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x0001032F File Offset: 0x0000E52F
		private void WriteBlob(global::Mono.Cecil.PE.ByteBuffer blob)
		{
			base.WriteCompressedUInt32((uint)blob.length);
			base.WriteBytes(blob);
		}

		// Token: 0x040004D7 RID: 1239
		private readonly global::System.Collections.Generic.Dictionary<global::Mono.Cecil.PE.ByteBuffer, uint> blobs = new global::System.Collections.Generic.Dictionary<global::Mono.Cecil.PE.ByteBuffer, uint>(new global::Mono.Cecil.PE.ByteBufferEqualityComparer());
	}
}
