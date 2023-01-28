using System;

namespace Mono.Cecil
{
	// Token: 0x020000F6 RID: 246
	[global::System.Flags]
	public enum AssemblyAttributes : uint
	{
		// Token: 0x04000616 RID: 1558
		PublicKey = 1U,
		// Token: 0x04000617 RID: 1559
		SideBySideCompatible = 0U,
		// Token: 0x04000618 RID: 1560
		Retargetable = 0x100U,
		// Token: 0x04000619 RID: 1561
		DisableJITCompileOptimizer = 0x4000U,
		// Token: 0x0400061A RID: 1562
		EnableJITCompileTracking = 0x8000U
	}
}
