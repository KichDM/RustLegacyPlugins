using System;

namespace Mono.Cecil.Cil
{
	// Token: 0x0200007D RID: 125
	public enum StackBehaviour
	{
		// Token: 0x04000336 RID: 822
		Pop0,
		// Token: 0x04000337 RID: 823
		Pop1,
		// Token: 0x04000338 RID: 824
		Pop1_pop1,
		// Token: 0x04000339 RID: 825
		Popi,
		// Token: 0x0400033A RID: 826
		Popi_pop1,
		// Token: 0x0400033B RID: 827
		Popi_popi,
		// Token: 0x0400033C RID: 828
		Popi_popi8,
		// Token: 0x0400033D RID: 829
		Popi_popi_popi,
		// Token: 0x0400033E RID: 830
		Popi_popr4,
		// Token: 0x0400033F RID: 831
		Popi_popr8,
		// Token: 0x04000340 RID: 832
		Popref,
		// Token: 0x04000341 RID: 833
		Popref_pop1,
		// Token: 0x04000342 RID: 834
		Popref_popi,
		// Token: 0x04000343 RID: 835
		Popref_popi_popi,
		// Token: 0x04000344 RID: 836
		Popref_popi_popi8,
		// Token: 0x04000345 RID: 837
		Popref_popi_popr4,
		// Token: 0x04000346 RID: 838
		Popref_popi_popr8,
		// Token: 0x04000347 RID: 839
		Popref_popi_popref,
		// Token: 0x04000348 RID: 840
		PopAll,
		// Token: 0x04000349 RID: 841
		Push0,
		// Token: 0x0400034A RID: 842
		Push1,
		// Token: 0x0400034B RID: 843
		Push1_push1,
		// Token: 0x0400034C RID: 844
		Pushi,
		// Token: 0x0400034D RID: 845
		Pushi8,
		// Token: 0x0400034E RID: 846
		Pushr4,
		// Token: 0x0400034F RID: 847
		Pushr8,
		// Token: 0x04000350 RID: 848
		Pushref,
		// Token: 0x04000351 RID: 849
		Varpop,
		// Token: 0x04000352 RID: 850
		Varpush
	}
}
