using System;

namespace Mono.Cecil
{
	// Token: 0x0200009D RID: 157
	public enum MetadataType : byte
	{
		// Token: 0x040004D9 RID: 1241
		Void = 1,
		// Token: 0x040004DA RID: 1242
		Boolean,
		// Token: 0x040004DB RID: 1243
		Char,
		// Token: 0x040004DC RID: 1244
		SByte,
		// Token: 0x040004DD RID: 1245
		Byte,
		// Token: 0x040004DE RID: 1246
		Int16,
		// Token: 0x040004DF RID: 1247
		UInt16,
		// Token: 0x040004E0 RID: 1248
		Int32,
		// Token: 0x040004E1 RID: 1249
		UInt32,
		// Token: 0x040004E2 RID: 1250
		Int64,
		// Token: 0x040004E3 RID: 1251
		UInt64,
		// Token: 0x040004E4 RID: 1252
		Single,
		// Token: 0x040004E5 RID: 1253
		Double,
		// Token: 0x040004E6 RID: 1254
		String,
		// Token: 0x040004E7 RID: 1255
		Pointer,
		// Token: 0x040004E8 RID: 1256
		ByReference,
		// Token: 0x040004E9 RID: 1257
		ValueType,
		// Token: 0x040004EA RID: 1258
		Class,
		// Token: 0x040004EB RID: 1259
		Var,
		// Token: 0x040004EC RID: 1260
		Array,
		// Token: 0x040004ED RID: 1261
		GenericInstance,
		// Token: 0x040004EE RID: 1262
		TypedByReference,
		// Token: 0x040004EF RID: 1263
		IntPtr = 0x18,
		// Token: 0x040004F0 RID: 1264
		UIntPtr,
		// Token: 0x040004F1 RID: 1265
		FunctionPointer = 0x1B,
		// Token: 0x040004F2 RID: 1266
		Object,
		// Token: 0x040004F3 RID: 1267
		MVar = 0x1E,
		// Token: 0x040004F4 RID: 1268
		RequiredModifier,
		// Token: 0x040004F5 RID: 1269
		OptionalModifier,
		// Token: 0x040004F6 RID: 1270
		Sentinel = 0x41,
		// Token: 0x040004F7 RID: 1271
		Pinned = 0x45
	}
}
