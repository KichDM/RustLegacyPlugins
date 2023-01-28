using System;

namespace Mono.Cecil
{
	// Token: 0x0200008C RID: 140
	public enum NativeType
	{
		// Token: 0x04000488 RID: 1160
		None = 0x66,
		// Token: 0x04000489 RID: 1161
		Boolean = 2,
		// Token: 0x0400048A RID: 1162
		I1,
		// Token: 0x0400048B RID: 1163
		U1,
		// Token: 0x0400048C RID: 1164
		I2,
		// Token: 0x0400048D RID: 1165
		U2,
		// Token: 0x0400048E RID: 1166
		I4,
		// Token: 0x0400048F RID: 1167
		U4,
		// Token: 0x04000490 RID: 1168
		I8,
		// Token: 0x04000491 RID: 1169
		U8,
		// Token: 0x04000492 RID: 1170
		R4,
		// Token: 0x04000493 RID: 1171
		R8,
		// Token: 0x04000494 RID: 1172
		LPStr = 0x14,
		// Token: 0x04000495 RID: 1173
		Int = 0x1F,
		// Token: 0x04000496 RID: 1174
		UInt,
		// Token: 0x04000497 RID: 1175
		Func = 0x26,
		// Token: 0x04000498 RID: 1176
		Array = 0x2A,
		// Token: 0x04000499 RID: 1177
		Currency = 0xF,
		// Token: 0x0400049A RID: 1178
		BStr = 0x13,
		// Token: 0x0400049B RID: 1179
		LPWStr = 0x15,
		// Token: 0x0400049C RID: 1180
		LPTStr,
		// Token: 0x0400049D RID: 1181
		FixedSysString,
		// Token: 0x0400049E RID: 1182
		IUnknown = 0x19,
		// Token: 0x0400049F RID: 1183
		IDispatch,
		// Token: 0x040004A0 RID: 1184
		Struct,
		// Token: 0x040004A1 RID: 1185
		IntF,
		// Token: 0x040004A2 RID: 1186
		SafeArray,
		// Token: 0x040004A3 RID: 1187
		FixedArray,
		// Token: 0x040004A4 RID: 1188
		ByValStr = 0x22,
		// Token: 0x040004A5 RID: 1189
		ANSIBStr,
		// Token: 0x040004A6 RID: 1190
		TBStr,
		// Token: 0x040004A7 RID: 1191
		VariantBool,
		// Token: 0x040004A8 RID: 1192
		ASAny = 0x28,
		// Token: 0x040004A9 RID: 1193
		LPStruct = 0x2B,
		// Token: 0x040004AA RID: 1194
		CustomMarshaler,
		// Token: 0x040004AB RID: 1195
		Error,
		// Token: 0x040004AC RID: 1196
		Max = 0x50
	}
}
