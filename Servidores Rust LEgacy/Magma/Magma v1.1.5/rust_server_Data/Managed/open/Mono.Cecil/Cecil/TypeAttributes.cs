using System;

namespace Mono.Cecil
{
	// Token: 0x02000088 RID: 136
	[global::System.Flags]
	public enum TypeAttributes : uint
	{
		// Token: 0x04000387 RID: 903
		VisibilityMask = 7U,
		// Token: 0x04000388 RID: 904
		NotPublic = 0U,
		// Token: 0x04000389 RID: 905
		Public = 1U,
		// Token: 0x0400038A RID: 906
		NestedPublic = 2U,
		// Token: 0x0400038B RID: 907
		NestedPrivate = 3U,
		// Token: 0x0400038C RID: 908
		NestedFamily = 4U,
		// Token: 0x0400038D RID: 909
		NestedAssembly = 5U,
		// Token: 0x0400038E RID: 910
		NestedFamANDAssem = 6U,
		// Token: 0x0400038F RID: 911
		NestedFamORAssem = 7U,
		// Token: 0x04000390 RID: 912
		LayoutMask = 0x18U,
		// Token: 0x04000391 RID: 913
		AutoLayout = 0U,
		// Token: 0x04000392 RID: 914
		SequentialLayout = 8U,
		// Token: 0x04000393 RID: 915
		ExplicitLayout = 0x10U,
		// Token: 0x04000394 RID: 916
		ClassSemanticMask = 0x20U,
		// Token: 0x04000395 RID: 917
		Class = 0U,
		// Token: 0x04000396 RID: 918
		Interface = 0x20U,
		// Token: 0x04000397 RID: 919
		Abstract = 0x80U,
		// Token: 0x04000398 RID: 920
		Sealed = 0x100U,
		// Token: 0x04000399 RID: 921
		SpecialName = 0x400U,
		// Token: 0x0400039A RID: 922
		Import = 0x1000U,
		// Token: 0x0400039B RID: 923
		Serializable = 0x2000U,
		// Token: 0x0400039C RID: 924
		StringFormatMask = 0x30000U,
		// Token: 0x0400039D RID: 925
		AnsiClass = 0U,
		// Token: 0x0400039E RID: 926
		UnicodeClass = 0x10000U,
		// Token: 0x0400039F RID: 927
		AutoClass = 0x20000U,
		// Token: 0x040003A0 RID: 928
		BeforeFieldInit = 0x100000U,
		// Token: 0x040003A1 RID: 929
		RTSpecialName = 0x800U,
		// Token: 0x040003A2 RID: 930
		HasSecurity = 0x40000U,
		// Token: 0x040003A3 RID: 931
		Forwarder = 0x200000U
	}
}
