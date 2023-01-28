using System;

namespace Mono.Cecil
{
	// Token: 0x02000054 RID: 84
	public enum TokenType : uint
	{
		// Token: 0x04000265 RID: 613
		Module,
		// Token: 0x04000266 RID: 614
		TypeRef = 0x1000000U,
		// Token: 0x04000267 RID: 615
		TypeDef = 0x2000000U,
		// Token: 0x04000268 RID: 616
		Field = 0x4000000U,
		// Token: 0x04000269 RID: 617
		Method = 0x6000000U,
		// Token: 0x0400026A RID: 618
		Param = 0x8000000U,
		// Token: 0x0400026B RID: 619
		InterfaceImpl = 0x9000000U,
		// Token: 0x0400026C RID: 620
		MemberRef = 0xA000000U,
		// Token: 0x0400026D RID: 621
		CustomAttribute = 0xC000000U,
		// Token: 0x0400026E RID: 622
		Permission = 0xE000000U,
		// Token: 0x0400026F RID: 623
		Signature = 0x11000000U,
		// Token: 0x04000270 RID: 624
		Event = 0x14000000U,
		// Token: 0x04000271 RID: 625
		Property = 0x17000000U,
		// Token: 0x04000272 RID: 626
		ModuleRef = 0x1A000000U,
		// Token: 0x04000273 RID: 627
		TypeSpec = 0x1B000000U,
		// Token: 0x04000274 RID: 628
		Assembly = 0x20000000U,
		// Token: 0x04000275 RID: 629
		AssemblyRef = 0x23000000U,
		// Token: 0x04000276 RID: 630
		File = 0x26000000U,
		// Token: 0x04000277 RID: 631
		ExportedType = 0x27000000U,
		// Token: 0x04000278 RID: 632
		ManifestResource = 0x28000000U,
		// Token: 0x04000279 RID: 633
		GenericParam = 0x2A000000U,
		// Token: 0x0400027A RID: 634
		MethodSpec = 0x2B000000U,
		// Token: 0x0400027B RID: 635
		String = 0x70000000U
	}
}
