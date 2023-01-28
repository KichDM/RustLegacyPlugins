using System;

namespace Mono.Cecil
{
	// Token: 0x020000BE RID: 190
	[global::System.Flags]
	public enum MethodSemanticsAttributes : ushort
	{
		// Token: 0x040005C7 RID: 1479
		None = 0,
		// Token: 0x040005C8 RID: 1480
		Setter = 1,
		// Token: 0x040005C9 RID: 1481
		Getter = 2,
		// Token: 0x040005CA RID: 1482
		Other = 4,
		// Token: 0x040005CB RID: 1483
		AddOn = 8,
		// Token: 0x040005CC RID: 1484
		RemoveOn = 0x10,
		// Token: 0x040005CD RID: 1485
		Fire = 0x20
	}
}
