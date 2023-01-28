using System;
using System.Collections.Generic;

namespace Mono.Cecil.PE
{
	// Token: 0x02000076 RID: 118
	internal sealed class ByteBufferEqualityComparer : global::System.Collections.Generic.IEqualityComparer<global::Mono.Cecil.PE.ByteBuffer>
	{
		// Token: 0x06000519 RID: 1305 RVA: 0x0000C644 File Offset: 0x0000A844
		public bool Equals(global::Mono.Cecil.PE.ByteBuffer x, global::Mono.Cecil.PE.ByteBuffer y)
		{
			if (x.length != y.length)
			{
				return false;
			}
			byte[] buffer = x.buffer;
			byte[] buffer2 = y.buffer;
			for (int i = 0; i < x.length; i++)
			{
				if (buffer[i] != buffer2[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x0000C68C File Offset: 0x0000A88C
		public int GetHashCode(global::Mono.Cecil.PE.ByteBuffer buffer)
		{
			int num = 0;
			byte[] buffer2 = buffer.buffer;
			for (int i = 0; i < buffer.length; i++)
			{
				num = (num * 0x25 ^ (int)buffer2[i]);
			}
			return num;
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x0000C6BD File Offset: 0x0000A8BD
		public ByteBufferEqualityComparer()
		{
		}
	}
}
