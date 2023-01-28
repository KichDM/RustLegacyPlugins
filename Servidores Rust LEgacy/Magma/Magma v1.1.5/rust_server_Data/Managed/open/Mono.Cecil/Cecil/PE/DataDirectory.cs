using System;

namespace Mono.Cecil.PE
{
	// Token: 0x02000053 RID: 83
	internal struct DataDirectory
	{
		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060003C7 RID: 967 RVA: 0x0000A1F7 File Offset: 0x000083F7
		public bool IsZero
		{
			get
			{
				return this.VirtualAddress == 0U && this.Size == 0U;
			}
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x0000A20C File Offset: 0x0000840C
		public DataDirectory(uint rva, uint size)
		{
			this.VirtualAddress = rva;
			this.Size = size;
		}

		// Token: 0x04000262 RID: 610
		public readonly uint VirtualAddress;

		// Token: 0x04000263 RID: 611
		public readonly uint Size;
	}
}
