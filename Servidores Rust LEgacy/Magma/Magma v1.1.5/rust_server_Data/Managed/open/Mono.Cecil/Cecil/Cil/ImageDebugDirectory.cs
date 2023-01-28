using System;

namespace Mono.Cecil.Cil
{
	// Token: 0x02000039 RID: 57
	public struct ImageDebugDirectory
	{
		// Token: 0x04000208 RID: 520
		public int Characteristics;

		// Token: 0x04000209 RID: 521
		public int TimeDateStamp;

		// Token: 0x0400020A RID: 522
		public short MajorVersion;

		// Token: 0x0400020B RID: 523
		public short MinorVersion;

		// Token: 0x0400020C RID: 524
		public int Type;

		// Token: 0x0400020D RID: 525
		public int SizeOfData;

		// Token: 0x0400020E RID: 526
		public int AddressOfRawData;

		// Token: 0x0400020F RID: 527
		public int PointerToRawData;
	}
}
