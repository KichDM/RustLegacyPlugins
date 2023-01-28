using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.Cecil.Metadata
{
	// Token: 0x0200009A RID: 154
	internal class StringHeapBuffer : global::Mono.Cecil.Metadata.HeapBuffer
	{
		// Token: 0x17000253 RID: 595
		// (get) Token: 0x0600066F RID: 1647 RVA: 0x00010244 File Offset: 0x0000E444
		public sealed override bool IsEmpty
		{
			get
			{
				return this.length <= 1;
			}
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x00010252 File Offset: 0x0000E452
		public StringHeapBuffer() : base(1)
		{
			base.WriteByte(0);
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x00010270 File Offset: 0x0000E470
		public uint GetStringIndex(string @string)
		{
			uint position;
			if (this.strings.TryGetValue(@string, out position))
			{
				return position;
			}
			position = (uint)this.position;
			this.WriteString(@string);
			this.strings.Add(@string, position);
			return position;
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x000102AB File Offset: 0x0000E4AB
		protected virtual void WriteString(string @string)
		{
			base.WriteBytes(global::System.Text.Encoding.UTF8.GetBytes(@string));
			base.WriteByte(0);
		}

		// Token: 0x040004D6 RID: 1238
		private readonly global::System.Collections.Generic.Dictionary<string, uint> strings = new global::System.Collections.Generic.Dictionary<string, uint>();
	}
}
