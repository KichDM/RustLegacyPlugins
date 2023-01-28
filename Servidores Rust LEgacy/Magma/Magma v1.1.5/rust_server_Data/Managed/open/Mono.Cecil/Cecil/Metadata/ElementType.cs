using System;

namespace Mono.Cecil.Metadata
{
	// Token: 0x02000014 RID: 20
	internal enum ElementType : byte
	{
		// Token: 0x04000031 RID: 49
		None,
		// Token: 0x04000032 RID: 50
		Void,
		// Token: 0x04000033 RID: 51
		Boolean,
		// Token: 0x04000034 RID: 52
		Char,
		// Token: 0x04000035 RID: 53
		I1,
		// Token: 0x04000036 RID: 54
		U1,
		// Token: 0x04000037 RID: 55
		I2,
		// Token: 0x04000038 RID: 56
		U2,
		// Token: 0x04000039 RID: 57
		I4,
		// Token: 0x0400003A RID: 58
		U4,
		// Token: 0x0400003B RID: 59
		I8,
		// Token: 0x0400003C RID: 60
		U8,
		// Token: 0x0400003D RID: 61
		R4,
		// Token: 0x0400003E RID: 62
		R8,
		// Token: 0x0400003F RID: 63
		String,
		// Token: 0x04000040 RID: 64
		Ptr,
		// Token: 0x04000041 RID: 65
		ByRef,
		// Token: 0x04000042 RID: 66
		ValueType,
		// Token: 0x04000043 RID: 67
		Class,
		// Token: 0x04000044 RID: 68
		Var,
		// Token: 0x04000045 RID: 69
		Array,
		// Token: 0x04000046 RID: 70
		GenericInst,
		// Token: 0x04000047 RID: 71
		TypedByRef,
		// Token: 0x04000048 RID: 72
		I = 0x18,
		// Token: 0x04000049 RID: 73
		U,
		// Token: 0x0400004A RID: 74
		FnPtr = 0x1B,
		// Token: 0x0400004B RID: 75
		Object,
		// Token: 0x0400004C RID: 76
		SzArray,
		// Token: 0x0400004D RID: 77
		MVar,
		// Token: 0x0400004E RID: 78
		CModReqD,
		// Token: 0x0400004F RID: 79
		CModOpt,
		// Token: 0x04000050 RID: 80
		Internal,
		// Token: 0x04000051 RID: 81
		Modifier = 0x40,
		// Token: 0x04000052 RID: 82
		Sentinel,
		// Token: 0x04000053 RID: 83
		Pinned = 0x45,
		// Token: 0x04000054 RID: 84
		Type = 0x50,
		// Token: 0x04000055 RID: 85
		Boxed,
		// Token: 0x04000056 RID: 86
		Enum = 0x55
	}
}
