using System;

namespace Mono.Cecil.PE
{
	// Token: 0x02000029 RID: 41
	internal sealed class Section
	{
		// Token: 0x060001D6 RID: 470 RVA: 0x000067C2 File Offset: 0x000049C2
		public Section()
		{
		}

		// Token: 0x04000185 RID: 389
		public string Name;

		// Token: 0x04000186 RID: 390
		public uint VirtualAddress;

		// Token: 0x04000187 RID: 391
		public uint VirtualSize;

		// Token: 0x04000188 RID: 392
		public uint SizeOfRawData;

		// Token: 0x04000189 RID: 393
		public uint PointerToRawData;

		// Token: 0x0400018A RID: 394
		public byte[] Data;
	}
}
