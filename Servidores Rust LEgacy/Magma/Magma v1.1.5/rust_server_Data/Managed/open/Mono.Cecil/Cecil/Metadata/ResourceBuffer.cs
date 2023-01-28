using System;
using Mono.Cecil.PE;

namespace Mono.Cecil.Metadata
{
	// Token: 0x02000098 RID: 152
	internal sealed class ResourceBuffer : global::Mono.Cecil.PE.ByteBuffer
	{
		// Token: 0x0600066B RID: 1643 RVA: 0x000101EF File Offset: 0x0000E3EF
		public ResourceBuffer() : base(0)
		{
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x000101F8 File Offset: 0x0000E3F8
		public uint AddResource(byte[] resource)
		{
			uint position = (uint)this.position;
			base.WriteInt32(resource.Length);
			base.WriteBytes(resource);
			return position;
		}
	}
}
