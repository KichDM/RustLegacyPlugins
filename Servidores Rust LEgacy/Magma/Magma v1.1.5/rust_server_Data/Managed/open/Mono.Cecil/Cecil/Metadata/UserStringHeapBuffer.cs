using System;

namespace Mono.Cecil.Metadata
{
	// Token: 0x0200009C RID: 156
	internal sealed class UserStringHeapBuffer : global::Mono.Cecil.Metadata.StringHeapBuffer
	{
		// Token: 0x06000677 RID: 1655 RVA: 0x00010344 File Offset: 0x0000E544
		protected override void WriteString(string @string)
		{
			base.WriteCompressedUInt32((uint)(@string.Length * 2 + 1));
			byte b = 0;
			foreach (char c in @string)
			{
				base.WriteUInt16((ushort)c);
				if (b != 1 && (c < ' ' || c > '~') && (c > '~' || (c >= '\u0001' && c <= '\b') || (c >= '\u000e' && c <= '\u001f') || c == '\'' || c == '-'))
				{
					b = 1;
				}
			}
			base.WriteByte(b);
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x000103BB File Offset: 0x0000E5BB
		public UserStringHeapBuffer()
		{
		}
	}
}
