using System;

namespace Mono.Cecil
{
	// Token: 0x020000BD RID: 189
	[global::System.Flags]
	public enum ParameterAttributes : ushort
	{
		// Token: 0x040005BD RID: 1469
		None = 0,
		// Token: 0x040005BE RID: 1470
		In = 1,
		// Token: 0x040005BF RID: 1471
		Out = 2,
		// Token: 0x040005C0 RID: 1472
		Lcid = 4,
		// Token: 0x040005C1 RID: 1473
		Retval = 8,
		// Token: 0x040005C2 RID: 1474
		Optional = 0x10,
		// Token: 0x040005C3 RID: 1475
		HasDefault = 0x1000,
		// Token: 0x040005C4 RID: 1476
		HasFieldMarshal = 0x2000,
		// Token: 0x040005C5 RID: 1477
		Unused = 0xCFE0
	}
}
