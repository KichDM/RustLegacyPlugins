using System;

namespace Mono.Cecil
{
	// Token: 0x0200001D RID: 29
	internal struct Range
	{
		// Token: 0x06000146 RID: 326 RVA: 0x000045F4 File Offset: 0x000027F4
		public Range(uint index, uint length)
		{
			this.Start = index;
			this.Length = length;
		}

		// Token: 0x0400007A RID: 122
		public uint Start;

		// Token: 0x0400007B RID: 123
		public uint Length;
	}
}
