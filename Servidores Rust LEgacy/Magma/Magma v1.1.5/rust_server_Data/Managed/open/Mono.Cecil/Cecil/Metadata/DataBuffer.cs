using System;
using Mono.Cecil.PE;

namespace Mono.Cecil.Metadata
{
	// Token: 0x02000099 RID: 153
	internal sealed class DataBuffer : global::Mono.Cecil.PE.ByteBuffer
	{
		// Token: 0x0600066D RID: 1645 RVA: 0x0001021D File Offset: 0x0000E41D
		public DataBuffer() : base(0)
		{
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x00010228 File Offset: 0x0000E428
		public uint AddData(byte[] data)
		{
			uint position = (uint)this.position;
			base.WriteBytes(data);
			return position;
		}
	}
}
