using System;
using System.Collections.Generic;
using System.Text;
using Mono.Cecil.PE;

namespace Mono.Cecil.Metadata
{
	// Token: 0x020000F7 RID: 247
	internal class StringHeap : global::Mono.Cecil.Metadata.Heap
	{
		// Token: 0x060009C1 RID: 2497 RVA: 0x0001DECE File Offset: 0x0001C0CE
		public StringHeap(global::Mono.Cecil.PE.Section section, uint start, uint size) : base(section, start, size)
		{
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x0001DEE4 File Offset: 0x0001C0E4
		public string Read(uint index)
		{
			if (index == 0U)
			{
				return string.Empty;
			}
			string text;
			if (this.strings.TryGetValue(index, out text))
			{
				return text;
			}
			if (index > this.Size - 1U)
			{
				return string.Empty;
			}
			text = this.ReadStringAt(index);
			if (text.Length != 0)
			{
				this.strings.Add(index, text);
			}
			return text;
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x0001DF3C File Offset: 0x0001C13C
		protected virtual string ReadStringAt(uint index)
		{
			int num = 0;
			byte[] data = this.Section.Data;
			int num2 = (int)(index + this.Offset);
			int num3 = num2;
			while (data[num3] != 0)
			{
				num++;
				num3++;
			}
			return global::System.Text.Encoding.UTF8.GetString(data, num2, num);
		}

		// Token: 0x0400061B RID: 1563
		private readonly global::System.Collections.Generic.Dictionary<uint, string> strings = new global::System.Collections.Generic.Dictionary<uint, string>();
	}
}
