using System;

namespace Mono.Cecil
{
	// Token: 0x02000034 RID: 52
	public enum MethodCallingConvention : byte
	{
		// Token: 0x040001F8 RID: 504
		Default,
		// Token: 0x040001F9 RID: 505
		C,
		// Token: 0x040001FA RID: 506
		StdCall,
		// Token: 0x040001FB RID: 507
		ThisCall,
		// Token: 0x040001FC RID: 508
		FastCall,
		// Token: 0x040001FD RID: 509
		VarArg,
		// Token: 0x040001FE RID: 510
		Generic = 0x10
	}
}
