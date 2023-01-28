using System;

namespace Mono.Cecil.PE
{
	// Token: 0x020000B1 RID: 177
	internal enum TextSegment
	{
		// Token: 0x0400057C RID: 1404
		ImportAddressTable,
		// Token: 0x0400057D RID: 1405
		CLIHeader,
		// Token: 0x0400057E RID: 1406
		Code,
		// Token: 0x0400057F RID: 1407
		Resources,
		// Token: 0x04000580 RID: 1408
		Data,
		// Token: 0x04000581 RID: 1409
		StrongNameSignature,
		// Token: 0x04000582 RID: 1410
		MetadataHeader,
		// Token: 0x04000583 RID: 1411
		TableHeap,
		// Token: 0x04000584 RID: 1412
		StringHeap,
		// Token: 0x04000585 RID: 1413
		UserStringHeap,
		// Token: 0x04000586 RID: 1414
		GuidHeap,
		// Token: 0x04000587 RID: 1415
		BlobHeap,
		// Token: 0x04000588 RID: 1416
		DebugDirectory,
		// Token: 0x04000589 RID: 1417
		ImportDirectory,
		// Token: 0x0400058A RID: 1418
		ImportHintNameTable,
		// Token: 0x0400058B RID: 1419
		StartupStub
	}
}
