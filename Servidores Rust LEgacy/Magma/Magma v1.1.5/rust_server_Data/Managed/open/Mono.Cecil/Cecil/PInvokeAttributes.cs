using System;

namespace Mono.Cecil
{
	// Token: 0x02000050 RID: 80
	[global::System.Flags]
	public enum PInvokeAttributes : ushort
	{
		// Token: 0x04000244 RID: 580
		NoMangle = 1,
		// Token: 0x04000245 RID: 581
		CharSetMask = 6,
		// Token: 0x04000246 RID: 582
		CharSetNotSpec = 0,
		// Token: 0x04000247 RID: 583
		CharSetAnsi = 2,
		// Token: 0x04000248 RID: 584
		CharSetUnicode = 4,
		// Token: 0x04000249 RID: 585
		CharSetAuto = 6,
		// Token: 0x0400024A RID: 586
		SupportsLastError = 0x40,
		// Token: 0x0400024B RID: 587
		CallConvMask = 0x700,
		// Token: 0x0400024C RID: 588
		CallConvWinapi = 0x100,
		// Token: 0x0400024D RID: 589
		CallConvCdecl = 0x200,
		// Token: 0x0400024E RID: 590
		CallConvStdCall = 0x300,
		// Token: 0x0400024F RID: 591
		CallConvThiscall = 0x400,
		// Token: 0x04000250 RID: 592
		CallConvFastcall = 0x500,
		// Token: 0x04000251 RID: 593
		BestFitMask = 0x30,
		// Token: 0x04000252 RID: 594
		BestFitEnabled = 0x10,
		// Token: 0x04000253 RID: 595
		BestFitDisabled = 0x20,
		// Token: 0x04000254 RID: 596
		ThrowOnUnmappableCharMask = 0x3000,
		// Token: 0x04000255 RID: 597
		ThrowOnUnmappableCharEnabled = 0x1000,
		// Token: 0x04000256 RID: 598
		ThrowOnUnmappableCharDisabled = 0x2000
	}
}
