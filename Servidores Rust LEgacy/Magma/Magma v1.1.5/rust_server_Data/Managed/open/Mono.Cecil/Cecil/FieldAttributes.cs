using System;

namespace Mono.Cecil
{
	// Token: 0x020000A0 RID: 160
	[global::System.Flags]
	public enum FieldAttributes : ushort
	{
		// Token: 0x04000503 RID: 1283
		FieldAccessMask = 7,
		// Token: 0x04000504 RID: 1284
		CompilerControlled = 0,
		// Token: 0x04000505 RID: 1285
		Private = 1,
		// Token: 0x04000506 RID: 1286
		FamANDAssem = 2,
		// Token: 0x04000507 RID: 1287
		Assembly = 3,
		// Token: 0x04000508 RID: 1288
		Family = 4,
		// Token: 0x04000509 RID: 1289
		FamORAssem = 5,
		// Token: 0x0400050A RID: 1290
		Public = 6,
		// Token: 0x0400050B RID: 1291
		Static = 0x10,
		// Token: 0x0400050C RID: 1292
		InitOnly = 0x20,
		// Token: 0x0400050D RID: 1293
		Literal = 0x40,
		// Token: 0x0400050E RID: 1294
		NotSerialized = 0x80,
		// Token: 0x0400050F RID: 1295
		SpecialName = 0x200,
		// Token: 0x04000510 RID: 1296
		PInvokeImpl = 0x2000,
		// Token: 0x04000511 RID: 1297
		RTSpecialName = 0x400,
		// Token: 0x04000512 RID: 1298
		HasFieldMarshal = 0x1000,
		// Token: 0x04000513 RID: 1299
		HasDefault = 0x8000,
		// Token: 0x04000514 RID: 1300
		HasFieldRVA = 0x100
	}
}
