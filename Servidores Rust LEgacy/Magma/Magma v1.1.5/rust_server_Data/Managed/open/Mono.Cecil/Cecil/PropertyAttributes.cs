using System;

namespace Mono.Cecil
{
	// Token: 0x02000026 RID: 38
	[global::System.Flags]
	public enum PropertyAttributes : ushort
	{
		// Token: 0x0400017F RID: 383
		None = 0,
		// Token: 0x04000180 RID: 384
		SpecialName = 0x200,
		// Token: 0x04000181 RID: 385
		RTSpecialName = 0x400,
		// Token: 0x04000182 RID: 386
		HasDefault = 0x1000,
		// Token: 0x04000183 RID: 387
		Unused = 0xE9FF
	}
}
