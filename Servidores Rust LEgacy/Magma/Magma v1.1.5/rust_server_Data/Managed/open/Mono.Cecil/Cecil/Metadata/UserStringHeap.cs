using System;
using Mono.Cecil.PE;

namespace Mono.Cecil.Metadata
{
	// Token: 0x020000F8 RID: 248
	internal sealed class UserStringHeap : global::Mono.Cecil.Metadata.StringHeap
	{
		// Token: 0x060009C4 RID: 2500 RVA: 0x0001DF7E File Offset: 0x0001C17E
		public UserStringHeap(global::Mono.Cecil.PE.Section section, uint start, uint size) : base(section, start, size)
		{
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x0001DF8C File Offset: 0x0001C18C
		protected override string ReadStringAt(uint index)
		{
			byte[] data = this.Section.Data;
			int num = (int)(index + this.Offset);
			uint num2 = (uint)((ulong)data.ReadCompressedUInt32(ref num) & 0xFFFFFFFFFFFFFFFEUL);
			if (num2 < 1U)
			{
				return string.Empty;
			}
			char[] array = new char[num2 / 2U];
			int num3 = num;
			int num4 = 0;
			while ((long)num3 < (long)num + (long)((ulong)num2))
			{
				array[num4++] = (char)((int)data[num3] | (int)data[num3 + 1] << 8);
				num3 += 2;
			}
			return new string(array);
		}
	}
}
