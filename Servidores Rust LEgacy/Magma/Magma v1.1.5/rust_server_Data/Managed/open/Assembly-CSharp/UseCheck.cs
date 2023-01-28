using System;

// Token: 0x02000232 RID: 562
public enum UseCheck : sbyte
{
	// Token: 0x040009A6 RID: 2470
	Success = 1,
	// Token: 0x040009A7 RID: 2471
	OutOfOrder = -0x80,
	// Token: 0x040009A8 RID: 2472
	BadUser,
	// Token: 0x040009A9 RID: 2473
	BadConfiguration
}
