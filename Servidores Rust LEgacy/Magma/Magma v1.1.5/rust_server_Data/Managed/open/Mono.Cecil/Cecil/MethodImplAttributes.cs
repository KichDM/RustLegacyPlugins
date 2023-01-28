using System;

namespace Mono.Cecil
{
	// Token: 0x02000092 RID: 146
	[global::System.Flags]
	public enum MethodImplAttributes : ushort
	{
		// Token: 0x040004B8 RID: 1208
		CodeTypeMask = 3,
		// Token: 0x040004B9 RID: 1209
		IL = 0,
		// Token: 0x040004BA RID: 1210
		Native = 1,
		// Token: 0x040004BB RID: 1211
		OPTIL = 2,
		// Token: 0x040004BC RID: 1212
		Runtime = 3,
		// Token: 0x040004BD RID: 1213
		ManagedMask = 4,
		// Token: 0x040004BE RID: 1214
		Unmanaged = 4,
		// Token: 0x040004BF RID: 1215
		Managed = 0,
		// Token: 0x040004C0 RID: 1216
		ForwardRef = 0x10,
		// Token: 0x040004C1 RID: 1217
		PreserveSig = 0x80,
		// Token: 0x040004C2 RID: 1218
		InternalCall = 0x1000,
		// Token: 0x040004C3 RID: 1219
		Synchronized = 0x20,
		// Token: 0x040004C4 RID: 1220
		NoOptimization = 0x40,
		// Token: 0x040004C5 RID: 1221
		NoInlining = 8,
		// Token: 0x040004C6 RID: 1222
		MaxMethodImplVal = 0xFFFF
	}
}
