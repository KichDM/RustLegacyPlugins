using System;

namespace Mono.Cecil
{
	// Token: 0x02000049 RID: 73
	public enum SecurityAction : ushort
	{
		// Token: 0x0400022D RID: 557
		Request = 1,
		// Token: 0x0400022E RID: 558
		Demand,
		// Token: 0x0400022F RID: 559
		Assert,
		// Token: 0x04000230 RID: 560
		Deny,
		// Token: 0x04000231 RID: 561
		PermitOnly,
		// Token: 0x04000232 RID: 562
		LinkDemand,
		// Token: 0x04000233 RID: 563
		InheritDemand,
		// Token: 0x04000234 RID: 564
		RequestMinimum,
		// Token: 0x04000235 RID: 565
		RequestOptional,
		// Token: 0x04000236 RID: 566
		RequestRefuse,
		// Token: 0x04000237 RID: 567
		PreJitGrant,
		// Token: 0x04000238 RID: 568
		PreJitDeny,
		// Token: 0x04000239 RID: 569
		NonCasDemand,
		// Token: 0x0400023A RID: 570
		NonCasLinkDemand,
		// Token: 0x0400023B RID: 571
		NonCasInheritance
	}
}
