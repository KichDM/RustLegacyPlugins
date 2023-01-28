using System;

namespace Mono.Cecil.Cil
{
	// Token: 0x02000024 RID: 36
	public static class OpCodes
	{
		// Token: 0x060001B5 RID: 437 RVA: 0x0000556C File Offset: 0x0000376C
		// Note: this type is marked as 'beforefieldinit'.
		static OpCodes()
		{
		}

		// Token: 0x040000A1 RID: 161
		internal static readonly global::Mono.Cecil.Cil.OpCode[] OneByteOpCode = new global::Mono.Cecil.Cil.OpCode[0xE1];

		// Token: 0x040000A2 RID: 162
		internal static readonly global::Mono.Cecil.Cil.OpCode[] TwoBytesOpCode = new global::Mono.Cecil.Cil.OpCode[0x1F];

		// Token: 0x040000A3 RID: 163
		public static readonly global::Mono.Cecil.Cil.OpCode Nop = new global::Mono.Cecil.Cil.OpCode(0x50000FF, 0x13000505);

		// Token: 0x040000A4 RID: 164
		public static readonly global::Mono.Cecil.Cil.OpCode Break = new global::Mono.Cecil.Cil.OpCode(0x10101FF, 0x13000505);

		// Token: 0x040000A5 RID: 165
		public static readonly global::Mono.Cecil.Cil.OpCode Ldarg_0 = new global::Mono.Cecil.Cil.OpCode(0x50202FF, 0x14000501);

		// Token: 0x040000A6 RID: 166
		public static readonly global::Mono.Cecil.Cil.OpCode Ldarg_1 = new global::Mono.Cecil.Cil.OpCode(0x50303FF, 0x14000501);

		// Token: 0x040000A7 RID: 167
		public static readonly global::Mono.Cecil.Cil.OpCode Ldarg_2 = new global::Mono.Cecil.Cil.OpCode(0x50404FF, 0x14000501);

		// Token: 0x040000A8 RID: 168
		public static readonly global::Mono.Cecil.Cil.OpCode Ldarg_3 = new global::Mono.Cecil.Cil.OpCode(0x50505FF, 0x14000501);

		// Token: 0x040000A9 RID: 169
		public static readonly global::Mono.Cecil.Cil.OpCode Ldloc_0 = new global::Mono.Cecil.Cil.OpCode(0x50606FF, 0x14000501);

		// Token: 0x040000AA RID: 170
		public static readonly global::Mono.Cecil.Cil.OpCode Ldloc_1 = new global::Mono.Cecil.Cil.OpCode(0x50707FF, 0x14000501);

		// Token: 0x040000AB RID: 171
		public static readonly global::Mono.Cecil.Cil.OpCode Ldloc_2 = new global::Mono.Cecil.Cil.OpCode(0x50808FF, 0x14000501);

		// Token: 0x040000AC RID: 172
		public static readonly global::Mono.Cecil.Cil.OpCode Ldloc_3 = new global::Mono.Cecil.Cil.OpCode(0x50909FF, 0x14000501);

		// Token: 0x040000AD RID: 173
		public static readonly global::Mono.Cecil.Cil.OpCode Stloc_0 = new global::Mono.Cecil.Cil.OpCode(0x50A0AFF, 0x13010501);

		// Token: 0x040000AE RID: 174
		public static readonly global::Mono.Cecil.Cil.OpCode Stloc_1 = new global::Mono.Cecil.Cil.OpCode(0x50B0BFF, 0x13010501);

		// Token: 0x040000AF RID: 175
		public static readonly global::Mono.Cecil.Cil.OpCode Stloc_2 = new global::Mono.Cecil.Cil.OpCode(0x50C0CFF, 0x13010501);

		// Token: 0x040000B0 RID: 176
		public static readonly global::Mono.Cecil.Cil.OpCode Stloc_3 = new global::Mono.Cecil.Cil.OpCode(0x50D0DFF, 0x13010501);

		// Token: 0x040000B1 RID: 177
		public static readonly global::Mono.Cecil.Cil.OpCode Ldarg_S = new global::Mono.Cecil.Cil.OpCode(0x50E0EFF, 0x14001301);

		// Token: 0x040000B2 RID: 178
		public static readonly global::Mono.Cecil.Cil.OpCode Ldarga_S = new global::Mono.Cecil.Cil.OpCode(0x50F0FFF, 0x16001301);

		// Token: 0x040000B3 RID: 179
		public static readonly global::Mono.Cecil.Cil.OpCode Starg_S = new global::Mono.Cecil.Cil.OpCode(0x51010FF, 0x13011301);

		// Token: 0x040000B4 RID: 180
		public static readonly global::Mono.Cecil.Cil.OpCode Ldloc_S = new global::Mono.Cecil.Cil.OpCode(0x51111FF, 0x14001201);

		// Token: 0x040000B5 RID: 181
		public static readonly global::Mono.Cecil.Cil.OpCode Ldloca_S = new global::Mono.Cecil.Cil.OpCode(0x51212FF, 0x16001201);

		// Token: 0x040000B6 RID: 182
		public static readonly global::Mono.Cecil.Cil.OpCode Stloc_S = new global::Mono.Cecil.Cil.OpCode(0x51313FF, 0x13011201);

		// Token: 0x040000B7 RID: 183
		public static readonly global::Mono.Cecil.Cil.OpCode Ldnull = new global::Mono.Cecil.Cil.OpCode(0x51414FF, 0x1A000505);

		// Token: 0x040000B8 RID: 184
		public static readonly global::Mono.Cecil.Cil.OpCode Ldc_I4_M1 = new global::Mono.Cecil.Cil.OpCode(0x51515FF, 0x16000501);

		// Token: 0x040000B9 RID: 185
		public static readonly global::Mono.Cecil.Cil.OpCode Ldc_I4_0 = new global::Mono.Cecil.Cil.OpCode(0x51616FF, 0x16000501);

		// Token: 0x040000BA RID: 186
		public static readonly global::Mono.Cecil.Cil.OpCode Ldc_I4_1 = new global::Mono.Cecil.Cil.OpCode(0x51717FF, 0x16000501);

		// Token: 0x040000BB RID: 187
		public static readonly global::Mono.Cecil.Cil.OpCode Ldc_I4_2 = new global::Mono.Cecil.Cil.OpCode(0x51818FF, 0x16000501);

		// Token: 0x040000BC RID: 188
		public static readonly global::Mono.Cecil.Cil.OpCode Ldc_I4_3 = new global::Mono.Cecil.Cil.OpCode(0x51919FF, 0x16000501);

		// Token: 0x040000BD RID: 189
		public static readonly global::Mono.Cecil.Cil.OpCode Ldc_I4_4 = new global::Mono.Cecil.Cil.OpCode(0x51A1AFF, 0x16000501);

		// Token: 0x040000BE RID: 190
		public static readonly global::Mono.Cecil.Cil.OpCode Ldc_I4_5 = new global::Mono.Cecil.Cil.OpCode(0x51B1BFF, 0x16000501);

		// Token: 0x040000BF RID: 191
		public static readonly global::Mono.Cecil.Cil.OpCode Ldc_I4_6 = new global::Mono.Cecil.Cil.OpCode(0x51C1CFF, 0x16000501);

		// Token: 0x040000C0 RID: 192
		public static readonly global::Mono.Cecil.Cil.OpCode Ldc_I4_7 = new global::Mono.Cecil.Cil.OpCode(0x51D1DFF, 0x16000501);

		// Token: 0x040000C1 RID: 193
		public static readonly global::Mono.Cecil.Cil.OpCode Ldc_I4_8 = new global::Mono.Cecil.Cil.OpCode(0x51E1EFF, 0x16000501);

		// Token: 0x040000C2 RID: 194
		public static readonly global::Mono.Cecil.Cil.OpCode Ldc_I4_S = new global::Mono.Cecil.Cil.OpCode(0x51F1FFF, 0x16001001);

		// Token: 0x040000C3 RID: 195
		public static readonly global::Mono.Cecil.Cil.OpCode Ldc_I4 = new global::Mono.Cecil.Cil.OpCode(0x52020FF, 0x16000205);

		// Token: 0x040000C4 RID: 196
		public static readonly global::Mono.Cecil.Cil.OpCode Ldc_I8 = new global::Mono.Cecil.Cil.OpCode(0x52121FF, 0x17000305);

		// Token: 0x040000C5 RID: 197
		public static readonly global::Mono.Cecil.Cil.OpCode Ldc_R4 = new global::Mono.Cecil.Cil.OpCode(0x52222FF, 0x18001105);

		// Token: 0x040000C6 RID: 198
		public static readonly global::Mono.Cecil.Cil.OpCode Ldc_R8 = new global::Mono.Cecil.Cil.OpCode(0x52323FF, 0x19000705);

		// Token: 0x040000C7 RID: 199
		public static readonly global::Mono.Cecil.Cil.OpCode Dup = new global::Mono.Cecil.Cil.OpCode(0x52425FF, 0x15010505);

		// Token: 0x040000C8 RID: 200
		public static readonly global::Mono.Cecil.Cil.OpCode Pop = new global::Mono.Cecil.Cil.OpCode(0x52526FF, 0x13010505);

		// Token: 0x040000C9 RID: 201
		public static readonly global::Mono.Cecil.Cil.OpCode Jmp = new global::Mono.Cecil.Cil.OpCode(0x22627FF, 0x13000405);

		// Token: 0x040000CA RID: 202
		public static readonly global::Mono.Cecil.Cil.OpCode Call = new global::Mono.Cecil.Cil.OpCode(0x22728FF, 0x1C1B0405);

		// Token: 0x040000CB RID: 203
		public static readonly global::Mono.Cecil.Cil.OpCode Calli = new global::Mono.Cecil.Cil.OpCode(0x22829FF, 0x1C1B0805);

		// Token: 0x040000CC RID: 204
		public static readonly global::Mono.Cecil.Cil.OpCode Ret = new global::Mono.Cecil.Cil.OpCode(0x7292AFF, 0x131B0505);

		// Token: 0x040000CD RID: 205
		public static readonly global::Mono.Cecil.Cil.OpCode Br_S = new global::Mono.Cecil.Cil.OpCode(0x2A2BFF, 0x13000F01);

		// Token: 0x040000CE RID: 206
		public static readonly global::Mono.Cecil.Cil.OpCode Brfalse_S = new global::Mono.Cecil.Cil.OpCode(0x32B2CFF, 0x13030F01);

		// Token: 0x040000CF RID: 207
		public static readonly global::Mono.Cecil.Cil.OpCode Brtrue_S = new global::Mono.Cecil.Cil.OpCode(0x32C2DFF, 0x13030F01);

		// Token: 0x040000D0 RID: 208
		public static readonly global::Mono.Cecil.Cil.OpCode Beq_S = new global::Mono.Cecil.Cil.OpCode(0x32D2EFF, 0x13020F01);

		// Token: 0x040000D1 RID: 209
		public static readonly global::Mono.Cecil.Cil.OpCode Bge_S = new global::Mono.Cecil.Cil.OpCode(0x32E2FFF, 0x13020F01);

		// Token: 0x040000D2 RID: 210
		public static readonly global::Mono.Cecil.Cil.OpCode Bgt_S = new global::Mono.Cecil.Cil.OpCode(0x32F30FF, 0x13020F01);

		// Token: 0x040000D3 RID: 211
		public static readonly global::Mono.Cecil.Cil.OpCode Ble_S = new global::Mono.Cecil.Cil.OpCode(0x33031FF, 0x13020F01);

		// Token: 0x040000D4 RID: 212
		public static readonly global::Mono.Cecil.Cil.OpCode Blt_S = new global::Mono.Cecil.Cil.OpCode(0x33132FF, 0x13020F01);

		// Token: 0x040000D5 RID: 213
		public static readonly global::Mono.Cecil.Cil.OpCode Bne_Un_S = new global::Mono.Cecil.Cil.OpCode(0x33233FF, 0x13020F01);

		// Token: 0x040000D6 RID: 214
		public static readonly global::Mono.Cecil.Cil.OpCode Bge_Un_S = new global::Mono.Cecil.Cil.OpCode(0x33334FF, 0x13020F01);

		// Token: 0x040000D7 RID: 215
		public static readonly global::Mono.Cecil.Cil.OpCode Bgt_Un_S = new global::Mono.Cecil.Cil.OpCode(0x33435FF, 0x13020F01);

		// Token: 0x040000D8 RID: 216
		public static readonly global::Mono.Cecil.Cil.OpCode Ble_Un_S = new global::Mono.Cecil.Cil.OpCode(0x33536FF, 0x13020F01);

		// Token: 0x040000D9 RID: 217
		public static readonly global::Mono.Cecil.Cil.OpCode Blt_Un_S = new global::Mono.Cecil.Cil.OpCode(0x33637FF, 0x13020F01);

		// Token: 0x040000DA RID: 218
		public static readonly global::Mono.Cecil.Cil.OpCode Br = new global::Mono.Cecil.Cil.OpCode(0x3738FF, 0x13000005);

		// Token: 0x040000DB RID: 219
		public static readonly global::Mono.Cecil.Cil.OpCode Brfalse = new global::Mono.Cecil.Cil.OpCode(0x33839FF, 0x13030005);

		// Token: 0x040000DC RID: 220
		public static readonly global::Mono.Cecil.Cil.OpCode Brtrue = new global::Mono.Cecil.Cil.OpCode(0x3393AFF, 0x13030005);

		// Token: 0x040000DD RID: 221
		public static readonly global::Mono.Cecil.Cil.OpCode Beq = new global::Mono.Cecil.Cil.OpCode(0x33A3BFF, 0x13020001);

		// Token: 0x040000DE RID: 222
		public static readonly global::Mono.Cecil.Cil.OpCode Bge = new global::Mono.Cecil.Cil.OpCode(0x33B3CFF, 0x13020001);

		// Token: 0x040000DF RID: 223
		public static readonly global::Mono.Cecil.Cil.OpCode Bgt = new global::Mono.Cecil.Cil.OpCode(0x33C3DFF, 0x13020001);

		// Token: 0x040000E0 RID: 224
		public static readonly global::Mono.Cecil.Cil.OpCode Ble = new global::Mono.Cecil.Cil.OpCode(0x33D3EFF, 0x13020001);

		// Token: 0x040000E1 RID: 225
		public static readonly global::Mono.Cecil.Cil.OpCode Blt = new global::Mono.Cecil.Cil.OpCode(0x33E3FFF, 0x13020001);

		// Token: 0x040000E2 RID: 226
		public static readonly global::Mono.Cecil.Cil.OpCode Bne_Un = new global::Mono.Cecil.Cil.OpCode(0x33F40FF, 0x13020001);

		// Token: 0x040000E3 RID: 227
		public static readonly global::Mono.Cecil.Cil.OpCode Bge_Un = new global::Mono.Cecil.Cil.OpCode(0x34041FF, 0x13020001);

		// Token: 0x040000E4 RID: 228
		public static readonly global::Mono.Cecil.Cil.OpCode Bgt_Un = new global::Mono.Cecil.Cil.OpCode(0x34142FF, 0x13020001);

		// Token: 0x040000E5 RID: 229
		public static readonly global::Mono.Cecil.Cil.OpCode Ble_Un = new global::Mono.Cecil.Cil.OpCode(0x34243FF, 0x13020001);

		// Token: 0x040000E6 RID: 230
		public static readonly global::Mono.Cecil.Cil.OpCode Blt_Un = new global::Mono.Cecil.Cil.OpCode(0x34344FF, 0x13020001);

		// Token: 0x040000E7 RID: 231
		public static readonly global::Mono.Cecil.Cil.OpCode Switch = new global::Mono.Cecil.Cil.OpCode(0x34445FF, 0x13030A05);

		// Token: 0x040000E8 RID: 232
		public static readonly global::Mono.Cecil.Cil.OpCode Ldind_I1 = new global::Mono.Cecil.Cil.OpCode(0x54546FF, 0x16030505);

		// Token: 0x040000E9 RID: 233
		public static readonly global::Mono.Cecil.Cil.OpCode Ldind_U1 = new global::Mono.Cecil.Cil.OpCode(0x54647FF, 0x16030505);

		// Token: 0x040000EA RID: 234
		public static readonly global::Mono.Cecil.Cil.OpCode Ldind_I2 = new global::Mono.Cecil.Cil.OpCode(0x54748FF, 0x16030505);

		// Token: 0x040000EB RID: 235
		public static readonly global::Mono.Cecil.Cil.OpCode Ldind_U2 = new global::Mono.Cecil.Cil.OpCode(0x54849FF, 0x16030505);

		// Token: 0x040000EC RID: 236
		public static readonly global::Mono.Cecil.Cil.OpCode Ldind_I4 = new global::Mono.Cecil.Cil.OpCode(0x5494AFF, 0x16030505);

		// Token: 0x040000ED RID: 237
		public static readonly global::Mono.Cecil.Cil.OpCode Ldind_U4 = new global::Mono.Cecil.Cil.OpCode(0x54A4BFF, 0x16030505);

		// Token: 0x040000EE RID: 238
		public static readonly global::Mono.Cecil.Cil.OpCode Ldind_I8 = new global::Mono.Cecil.Cil.OpCode(0x54B4CFF, 0x17030505);

		// Token: 0x040000EF RID: 239
		public static readonly global::Mono.Cecil.Cil.OpCode Ldind_I = new global::Mono.Cecil.Cil.OpCode(0x54C4DFF, 0x16030505);

		// Token: 0x040000F0 RID: 240
		public static readonly global::Mono.Cecil.Cil.OpCode Ldind_R4 = new global::Mono.Cecil.Cil.OpCode(0x54D4EFF, 0x18030505);

		// Token: 0x040000F1 RID: 241
		public static readonly global::Mono.Cecil.Cil.OpCode Ldind_R8 = new global::Mono.Cecil.Cil.OpCode(0x54E4FFF, 0x19030505);

		// Token: 0x040000F2 RID: 242
		public static readonly global::Mono.Cecil.Cil.OpCode Ldind_Ref = new global::Mono.Cecil.Cil.OpCode(0x54F50FF, 0x1A030505);

		// Token: 0x040000F3 RID: 243
		public static readonly global::Mono.Cecil.Cil.OpCode Stind_Ref = new global::Mono.Cecil.Cil.OpCode(0x55051FF, 0x13050505);

		// Token: 0x040000F4 RID: 244
		public static readonly global::Mono.Cecil.Cil.OpCode Stind_I1 = new global::Mono.Cecil.Cil.OpCode(0x55152FF, 0x13050505);

		// Token: 0x040000F5 RID: 245
		public static readonly global::Mono.Cecil.Cil.OpCode Stind_I2 = new global::Mono.Cecil.Cil.OpCode(0x55253FF, 0x13050505);

		// Token: 0x040000F6 RID: 246
		public static readonly global::Mono.Cecil.Cil.OpCode Stind_I4 = new global::Mono.Cecil.Cil.OpCode(0x55354FF, 0x13050505);

		// Token: 0x040000F7 RID: 247
		public static readonly global::Mono.Cecil.Cil.OpCode Stind_I8 = new global::Mono.Cecil.Cil.OpCode(0x55455FF, 0x13060505);

		// Token: 0x040000F8 RID: 248
		public static readonly global::Mono.Cecil.Cil.OpCode Stind_R4 = new global::Mono.Cecil.Cil.OpCode(0x55556FF, 0x13080505);

		// Token: 0x040000F9 RID: 249
		public static readonly global::Mono.Cecil.Cil.OpCode Stind_R8 = new global::Mono.Cecil.Cil.OpCode(0x55657FF, 0x13090505);

		// Token: 0x040000FA RID: 250
		public static readonly global::Mono.Cecil.Cil.OpCode Add = new global::Mono.Cecil.Cil.OpCode(0x55758FF, 0x14020505);

		// Token: 0x040000FB RID: 251
		public static readonly global::Mono.Cecil.Cil.OpCode Sub = new global::Mono.Cecil.Cil.OpCode(0x55859FF, 0x14020505);

		// Token: 0x040000FC RID: 252
		public static readonly global::Mono.Cecil.Cil.OpCode Mul = new global::Mono.Cecil.Cil.OpCode(0x5595AFF, 0x14020505);

		// Token: 0x040000FD RID: 253
		public static readonly global::Mono.Cecil.Cil.OpCode Div = new global::Mono.Cecil.Cil.OpCode(0x55A5BFF, 0x14020505);

		// Token: 0x040000FE RID: 254
		public static readonly global::Mono.Cecil.Cil.OpCode Div_Un = new global::Mono.Cecil.Cil.OpCode(0x55B5CFF, 0x14020505);

		// Token: 0x040000FF RID: 255
		public static readonly global::Mono.Cecil.Cil.OpCode Rem = new global::Mono.Cecil.Cil.OpCode(0x55C5DFF, 0x14020505);

		// Token: 0x04000100 RID: 256
		public static readonly global::Mono.Cecil.Cil.OpCode Rem_Un = new global::Mono.Cecil.Cil.OpCode(0x55D5EFF, 0x14020505);

		// Token: 0x04000101 RID: 257
		public static readonly global::Mono.Cecil.Cil.OpCode And = new global::Mono.Cecil.Cil.OpCode(0x55E5FFF, 0x14020505);

		// Token: 0x04000102 RID: 258
		public static readonly global::Mono.Cecil.Cil.OpCode Or = new global::Mono.Cecil.Cil.OpCode(0x55F60FF, 0x14020505);

		// Token: 0x04000103 RID: 259
		public static readonly global::Mono.Cecil.Cil.OpCode Xor = new global::Mono.Cecil.Cil.OpCode(0x56061FF, 0x14020505);

		// Token: 0x04000104 RID: 260
		public static readonly global::Mono.Cecil.Cil.OpCode Shl = new global::Mono.Cecil.Cil.OpCode(0x56162FF, 0x14020505);

		// Token: 0x04000105 RID: 261
		public static readonly global::Mono.Cecil.Cil.OpCode Shr = new global::Mono.Cecil.Cil.OpCode(0x56263FF, 0x14020505);

		// Token: 0x04000106 RID: 262
		public static readonly global::Mono.Cecil.Cil.OpCode Shr_Un = new global::Mono.Cecil.Cil.OpCode(0x56364FF, 0x14020505);

		// Token: 0x04000107 RID: 263
		public static readonly global::Mono.Cecil.Cil.OpCode Neg = new global::Mono.Cecil.Cil.OpCode(0x56465FF, 0x14010505);

		// Token: 0x04000108 RID: 264
		public static readonly global::Mono.Cecil.Cil.OpCode Not = new global::Mono.Cecil.Cil.OpCode(0x56566FF, 0x14010505);

		// Token: 0x04000109 RID: 265
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_I1 = new global::Mono.Cecil.Cil.OpCode(0x56667FF, 0x16010505);

		// Token: 0x0400010A RID: 266
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_I2 = new global::Mono.Cecil.Cil.OpCode(0x56768FF, 0x16010505);

		// Token: 0x0400010B RID: 267
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_I4 = new global::Mono.Cecil.Cil.OpCode(0x56869FF, 0x16010505);

		// Token: 0x0400010C RID: 268
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_I8 = new global::Mono.Cecil.Cil.OpCode(0x5696AFF, 0x17010505);

		// Token: 0x0400010D RID: 269
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_R4 = new global::Mono.Cecil.Cil.OpCode(0x56A6BFF, 0x18010505);

		// Token: 0x0400010E RID: 270
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_R8 = new global::Mono.Cecil.Cil.OpCode(0x56B6CFF, 0x19010505);

		// Token: 0x0400010F RID: 271
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_U4 = new global::Mono.Cecil.Cil.OpCode(0x56C6DFF, 0x16010505);

		// Token: 0x04000110 RID: 272
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_U8 = new global::Mono.Cecil.Cil.OpCode(0x56D6EFF, 0x17010505);

		// Token: 0x04000111 RID: 273
		public static readonly global::Mono.Cecil.Cil.OpCode Callvirt = new global::Mono.Cecil.Cil.OpCode(0x26E6FFF, 0x1C1B0403);

		// Token: 0x04000112 RID: 274
		public static readonly global::Mono.Cecil.Cil.OpCode Cpobj = new global::Mono.Cecil.Cil.OpCode(0x56F70FF, 0x13050C03);

		// Token: 0x04000113 RID: 275
		public static readonly global::Mono.Cecil.Cil.OpCode Ldobj = new global::Mono.Cecil.Cil.OpCode(0x57071FF, 0x14030C03);

		// Token: 0x04000114 RID: 276
		public static readonly global::Mono.Cecil.Cil.OpCode Ldstr = new global::Mono.Cecil.Cil.OpCode(0x57172FF, 0x1A000903);

		// Token: 0x04000115 RID: 277
		public static readonly global::Mono.Cecil.Cil.OpCode Newobj = new global::Mono.Cecil.Cil.OpCode(0x27273FF, 0x1A1B0403);

		// Token: 0x04000116 RID: 278
		public static readonly global::Mono.Cecil.Cil.OpCode Castclass = new global::Mono.Cecil.Cil.OpCode(0x57374FF, 0x1A0A0C03);

		// Token: 0x04000117 RID: 279
		public static readonly global::Mono.Cecil.Cil.OpCode Isinst = new global::Mono.Cecil.Cil.OpCode(0x57475FF, 0x160A0C03);

		// Token: 0x04000118 RID: 280
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_R_Un = new global::Mono.Cecil.Cil.OpCode(0x57576FF, 0x19010505);

		// Token: 0x04000119 RID: 281
		public static readonly global::Mono.Cecil.Cil.OpCode Unbox = new global::Mono.Cecil.Cil.OpCode(0x57679FF, 0x160A0C05);

		// Token: 0x0400011A RID: 282
		public static readonly global::Mono.Cecil.Cil.OpCode Throw = new global::Mono.Cecil.Cil.OpCode(0x8777AFF, 0x130A0503);

		// Token: 0x0400011B RID: 283
		public static readonly global::Mono.Cecil.Cil.OpCode Ldfld = new global::Mono.Cecil.Cil.OpCode(0x5787BFF, 0x140A0103);

		// Token: 0x0400011C RID: 284
		public static readonly global::Mono.Cecil.Cil.OpCode Ldflda = new global::Mono.Cecil.Cil.OpCode(0x5797CFF, 0x160A0103);

		// Token: 0x0400011D RID: 285
		public static readonly global::Mono.Cecil.Cil.OpCode Stfld = new global::Mono.Cecil.Cil.OpCode(0x57A7DFF, 0x130B0103);

		// Token: 0x0400011E RID: 286
		public static readonly global::Mono.Cecil.Cil.OpCode Ldsfld = new global::Mono.Cecil.Cil.OpCode(0x57B7EFF, 0x14000103);

		// Token: 0x0400011F RID: 287
		public static readonly global::Mono.Cecil.Cil.OpCode Ldsflda = new global::Mono.Cecil.Cil.OpCode(0x57C7FFF, 0x16000103);

		// Token: 0x04000120 RID: 288
		public static readonly global::Mono.Cecil.Cil.OpCode Stsfld = new global::Mono.Cecil.Cil.OpCode(0x57D80FF, 0x13010103);

		// Token: 0x04000121 RID: 289
		public static readonly global::Mono.Cecil.Cil.OpCode Stobj = new global::Mono.Cecil.Cil.OpCode(0x57E81FF, 0x13040C03);

		// Token: 0x04000122 RID: 290
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_I1_Un = new global::Mono.Cecil.Cil.OpCode(0x57F82FF, 0x16010505);

		// Token: 0x04000123 RID: 291
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_I2_Un = new global::Mono.Cecil.Cil.OpCode(0x58083FF, 0x16010505);

		// Token: 0x04000124 RID: 292
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_I4_Un = new global::Mono.Cecil.Cil.OpCode(0x58184FF, 0x16010505);

		// Token: 0x04000125 RID: 293
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_I8_Un = new global::Mono.Cecil.Cil.OpCode(0x58285FF, 0x17010505);

		// Token: 0x04000126 RID: 294
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_U1_Un = new global::Mono.Cecil.Cil.OpCode(0x58386FF, 0x16010505);

		// Token: 0x04000127 RID: 295
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_U2_Un = new global::Mono.Cecil.Cil.OpCode(0x58487FF, 0x16010505);

		// Token: 0x04000128 RID: 296
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_U4_Un = new global::Mono.Cecil.Cil.OpCode(0x58588FF, 0x16010505);

		// Token: 0x04000129 RID: 297
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_U8_Un = new global::Mono.Cecil.Cil.OpCode(0x58689FF, 0x17010505);

		// Token: 0x0400012A RID: 298
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_I_Un = new global::Mono.Cecil.Cil.OpCode(0x5878AFF, 0x16010505);

		// Token: 0x0400012B RID: 299
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_U_Un = new global::Mono.Cecil.Cil.OpCode(0x5888BFF, 0x16010505);

		// Token: 0x0400012C RID: 300
		public static readonly global::Mono.Cecil.Cil.OpCode Box = new global::Mono.Cecil.Cil.OpCode(0x5898CFF, 0x1A010C05);

		// Token: 0x0400012D RID: 301
		public static readonly global::Mono.Cecil.Cil.OpCode Newarr = new global::Mono.Cecil.Cil.OpCode(0x58A8DFF, 0x1A030C03);

		// Token: 0x0400012E RID: 302
		public static readonly global::Mono.Cecil.Cil.OpCode Ldlen = new global::Mono.Cecil.Cil.OpCode(0x58B8EFF, 0x160A0503);

		// Token: 0x0400012F RID: 303
		public static readonly global::Mono.Cecil.Cil.OpCode Ldelema = new global::Mono.Cecil.Cil.OpCode(0x58C8FFF, 0x160C0C03);

		// Token: 0x04000130 RID: 304
		public static readonly global::Mono.Cecil.Cil.OpCode Ldelem_I1 = new global::Mono.Cecil.Cil.OpCode(0x58D90FF, 0x160C0503);

		// Token: 0x04000131 RID: 305
		public static readonly global::Mono.Cecil.Cil.OpCode Ldelem_U1 = new global::Mono.Cecil.Cil.OpCode(0x58E91FF, 0x160C0503);

		// Token: 0x04000132 RID: 306
		public static readonly global::Mono.Cecil.Cil.OpCode Ldelem_I2 = new global::Mono.Cecil.Cil.OpCode(0x58F92FF, 0x160C0503);

		// Token: 0x04000133 RID: 307
		public static readonly global::Mono.Cecil.Cil.OpCode Ldelem_U2 = new global::Mono.Cecil.Cil.OpCode(0x59093FF, 0x160C0503);

		// Token: 0x04000134 RID: 308
		public static readonly global::Mono.Cecil.Cil.OpCode Ldelem_I4 = new global::Mono.Cecil.Cil.OpCode(0x59194FF, 0x160C0503);

		// Token: 0x04000135 RID: 309
		public static readonly global::Mono.Cecil.Cil.OpCode Ldelem_U4 = new global::Mono.Cecil.Cil.OpCode(0x59295FF, 0x160C0503);

		// Token: 0x04000136 RID: 310
		public static readonly global::Mono.Cecil.Cil.OpCode Ldelem_I8 = new global::Mono.Cecil.Cil.OpCode(0x59396FF, 0x170C0503);

		// Token: 0x04000137 RID: 311
		public static readonly global::Mono.Cecil.Cil.OpCode Ldelem_I = new global::Mono.Cecil.Cil.OpCode(0x59497FF, 0x160C0503);

		// Token: 0x04000138 RID: 312
		public static readonly global::Mono.Cecil.Cil.OpCode Ldelem_R4 = new global::Mono.Cecil.Cil.OpCode(0x59598FF, 0x180C0503);

		// Token: 0x04000139 RID: 313
		public static readonly global::Mono.Cecil.Cil.OpCode Ldelem_R8 = new global::Mono.Cecil.Cil.OpCode(0x59699FF, 0x190C0503);

		// Token: 0x0400013A RID: 314
		public static readonly global::Mono.Cecil.Cil.OpCode Ldelem_Ref = new global::Mono.Cecil.Cil.OpCode(0x5979AFF, 0x1A0C0503);

		// Token: 0x0400013B RID: 315
		public static readonly global::Mono.Cecil.Cil.OpCode Stelem_I = new global::Mono.Cecil.Cil.OpCode(0x5989BFF, 0x130D0503);

		// Token: 0x0400013C RID: 316
		public static readonly global::Mono.Cecil.Cil.OpCode Stelem_I1 = new global::Mono.Cecil.Cil.OpCode(0x5999CFF, 0x130D0503);

		// Token: 0x0400013D RID: 317
		public static readonly global::Mono.Cecil.Cil.OpCode Stelem_I2 = new global::Mono.Cecil.Cil.OpCode(0x59A9DFF, 0x130D0503);

		// Token: 0x0400013E RID: 318
		public static readonly global::Mono.Cecil.Cil.OpCode Stelem_I4 = new global::Mono.Cecil.Cil.OpCode(0x59B9EFF, 0x130D0503);

		// Token: 0x0400013F RID: 319
		public static readonly global::Mono.Cecil.Cil.OpCode Stelem_I8 = new global::Mono.Cecil.Cil.OpCode(0x59C9FFF, 0x130E0503);

		// Token: 0x04000140 RID: 320
		public static readonly global::Mono.Cecil.Cil.OpCode Stelem_R4 = new global::Mono.Cecil.Cil.OpCode(0x59DA0FF, 0x130F0503);

		// Token: 0x04000141 RID: 321
		public static readonly global::Mono.Cecil.Cil.OpCode Stelem_R8 = new global::Mono.Cecil.Cil.OpCode(0x59EA1FF, 0x13100503);

		// Token: 0x04000142 RID: 322
		public static readonly global::Mono.Cecil.Cil.OpCode Stelem_Ref = new global::Mono.Cecil.Cil.OpCode(0x59FA2FF, 0x13110503);

		// Token: 0x04000143 RID: 323
		public static readonly global::Mono.Cecil.Cil.OpCode Ldelem_Any = new global::Mono.Cecil.Cil.OpCode(0x5A0A3FF, 0x140C0C03);

		// Token: 0x04000144 RID: 324
		public static readonly global::Mono.Cecil.Cil.OpCode Stelem_Any = new global::Mono.Cecil.Cil.OpCode(0x5A1A4FF, 0x13110C03);

		// Token: 0x04000145 RID: 325
		public static readonly global::Mono.Cecil.Cil.OpCode Unbox_Any = new global::Mono.Cecil.Cil.OpCode(0x5A2A5FF, 0x140A0C03);

		// Token: 0x04000146 RID: 326
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_I1 = new global::Mono.Cecil.Cil.OpCode(0x5A3B3FF, 0x16010505);

		// Token: 0x04000147 RID: 327
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_U1 = new global::Mono.Cecil.Cil.OpCode(0x5A4B4FF, 0x16010505);

		// Token: 0x04000148 RID: 328
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_I2 = new global::Mono.Cecil.Cil.OpCode(0x5A5B5FF, 0x16010505);

		// Token: 0x04000149 RID: 329
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_U2 = new global::Mono.Cecil.Cil.OpCode(0x5A6B6FF, 0x16010505);

		// Token: 0x0400014A RID: 330
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_I4 = new global::Mono.Cecil.Cil.OpCode(0x5A7B7FF, 0x16010505);

		// Token: 0x0400014B RID: 331
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_U4 = new global::Mono.Cecil.Cil.OpCode(0x5A8B8FF, 0x16010505);

		// Token: 0x0400014C RID: 332
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_I8 = new global::Mono.Cecil.Cil.OpCode(0x5A9B9FF, 0x17010505);

		// Token: 0x0400014D RID: 333
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_U8 = new global::Mono.Cecil.Cil.OpCode(0x5AABAFF, 0x17010505);

		// Token: 0x0400014E RID: 334
		public static readonly global::Mono.Cecil.Cil.OpCode Refanyval = new global::Mono.Cecil.Cil.OpCode(0x5ABC2FF, 0x16010C05);

		// Token: 0x0400014F RID: 335
		public static readonly global::Mono.Cecil.Cil.OpCode Ckfinite = new global::Mono.Cecil.Cil.OpCode(0x5ACC3FF, 0x19010505);

		// Token: 0x04000150 RID: 336
		public static readonly global::Mono.Cecil.Cil.OpCode Mkrefany = new global::Mono.Cecil.Cil.OpCode(0x5ADC6FF, 0x14030C05);

		// Token: 0x04000151 RID: 337
		public static readonly global::Mono.Cecil.Cil.OpCode Ldtoken = new global::Mono.Cecil.Cil.OpCode(0x5AED0FF, 0x16000B05);

		// Token: 0x04000152 RID: 338
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_U2 = new global::Mono.Cecil.Cil.OpCode(0x5AFD1FF, 0x16010505);

		// Token: 0x04000153 RID: 339
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_U1 = new global::Mono.Cecil.Cil.OpCode(0x5B0D2FF, 0x16010505);

		// Token: 0x04000154 RID: 340
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_I = new global::Mono.Cecil.Cil.OpCode(0x5B1D3FF, 0x16010505);

		// Token: 0x04000155 RID: 341
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_I = new global::Mono.Cecil.Cil.OpCode(0x5B2D4FF, 0x16010505);

		// Token: 0x04000156 RID: 342
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_Ovf_U = new global::Mono.Cecil.Cil.OpCode(0x5B3D5FF, 0x16010505);

		// Token: 0x04000157 RID: 343
		public static readonly global::Mono.Cecil.Cil.OpCode Add_Ovf = new global::Mono.Cecil.Cil.OpCode(0x5B4D6FF, 0x14020505);

		// Token: 0x04000158 RID: 344
		public static readonly global::Mono.Cecil.Cil.OpCode Add_Ovf_Un = new global::Mono.Cecil.Cil.OpCode(0x5B5D7FF, 0x14020505);

		// Token: 0x04000159 RID: 345
		public static readonly global::Mono.Cecil.Cil.OpCode Mul_Ovf = new global::Mono.Cecil.Cil.OpCode(0x5B6D8FF, 0x14020505);

		// Token: 0x0400015A RID: 346
		public static readonly global::Mono.Cecil.Cil.OpCode Mul_Ovf_Un = new global::Mono.Cecil.Cil.OpCode(0x5B7D9FF, 0x14020505);

		// Token: 0x0400015B RID: 347
		public static readonly global::Mono.Cecil.Cil.OpCode Sub_Ovf = new global::Mono.Cecil.Cil.OpCode(0x5B8DAFF, 0x14020505);

		// Token: 0x0400015C RID: 348
		public static readonly global::Mono.Cecil.Cil.OpCode Sub_Ovf_Un = new global::Mono.Cecil.Cil.OpCode(0x5B9DBFF, 0x14020505);

		// Token: 0x0400015D RID: 349
		public static readonly global::Mono.Cecil.Cil.OpCode Endfinally = new global::Mono.Cecil.Cil.OpCode(0x7BADCFF, 0x13000505);

		// Token: 0x0400015E RID: 350
		public static readonly global::Mono.Cecil.Cil.OpCode Leave = new global::Mono.Cecil.Cil.OpCode(0xBBDDFF, 0x13120005);

		// Token: 0x0400015F RID: 351
		public static readonly global::Mono.Cecil.Cil.OpCode Leave_S = new global::Mono.Cecil.Cil.OpCode(0xBCDEFF, 0x13120F01);

		// Token: 0x04000160 RID: 352
		public static readonly global::Mono.Cecil.Cil.OpCode Stind_I = new global::Mono.Cecil.Cil.OpCode(0x5BDDFFF, 0x13050505);

		// Token: 0x04000161 RID: 353
		public static readonly global::Mono.Cecil.Cil.OpCode Conv_U = new global::Mono.Cecil.Cil.OpCode(0x5BEE0FF, 0x16010505);

		// Token: 0x04000162 RID: 354
		public static readonly global::Mono.Cecil.Cil.OpCode Arglist = new global::Mono.Cecil.Cil.OpCode(0x5BF00FE, 0x16000505);

		// Token: 0x04000163 RID: 355
		public static readonly global::Mono.Cecil.Cil.OpCode Ceq = new global::Mono.Cecil.Cil.OpCode(0x5C001FE, 0x16020505);

		// Token: 0x04000164 RID: 356
		public static readonly global::Mono.Cecil.Cil.OpCode Cgt = new global::Mono.Cecil.Cil.OpCode(0x5C102FE, 0x16020505);

		// Token: 0x04000165 RID: 357
		public static readonly global::Mono.Cecil.Cil.OpCode Cgt_Un = new global::Mono.Cecil.Cil.OpCode(0x5C203FE, 0x16020505);

		// Token: 0x04000166 RID: 358
		public static readonly global::Mono.Cecil.Cil.OpCode Clt = new global::Mono.Cecil.Cil.OpCode(0x5C304FE, 0x16020505);

		// Token: 0x04000167 RID: 359
		public static readonly global::Mono.Cecil.Cil.OpCode Clt_Un = new global::Mono.Cecil.Cil.OpCode(0x5C405FE, 0x16020505);

		// Token: 0x04000168 RID: 360
		public static readonly global::Mono.Cecil.Cil.OpCode Ldftn = new global::Mono.Cecil.Cil.OpCode(0x5C506FE, 0x16000405);

		// Token: 0x04000169 RID: 361
		public static readonly global::Mono.Cecil.Cil.OpCode Ldvirtftn = new global::Mono.Cecil.Cil.OpCode(0x5C607FE, 0x160A0405);

		// Token: 0x0400016A RID: 362
		public static readonly global::Mono.Cecil.Cil.OpCode Ldarg = new global::Mono.Cecil.Cil.OpCode(0x5C709FE, 0x14000E05);

		// Token: 0x0400016B RID: 363
		public static readonly global::Mono.Cecil.Cil.OpCode Ldarga = new global::Mono.Cecil.Cil.OpCode(0x5C80AFE, 0x16000E05);

		// Token: 0x0400016C RID: 364
		public static readonly global::Mono.Cecil.Cil.OpCode Starg = new global::Mono.Cecil.Cil.OpCode(0x5C90BFE, 0x13010E05);

		// Token: 0x0400016D RID: 365
		public static readonly global::Mono.Cecil.Cil.OpCode Ldloc = new global::Mono.Cecil.Cil.OpCode(0x5CA0CFE, 0x14000D05);

		// Token: 0x0400016E RID: 366
		public static readonly global::Mono.Cecil.Cil.OpCode Ldloca = new global::Mono.Cecil.Cil.OpCode(0x5CB0DFE, 0x16000D05);

		// Token: 0x0400016F RID: 367
		public static readonly global::Mono.Cecil.Cil.OpCode Stloc = new global::Mono.Cecil.Cil.OpCode(0x5CC0EFE, 0x13010D05);

		// Token: 0x04000170 RID: 368
		public static readonly global::Mono.Cecil.Cil.OpCode Localloc = new global::Mono.Cecil.Cil.OpCode(0x5CD0FFE, 0x16030505);

		// Token: 0x04000171 RID: 369
		public static readonly global::Mono.Cecil.Cil.OpCode Endfilter = new global::Mono.Cecil.Cil.OpCode(0x7CE11FE, 0x13030505);

		// Token: 0x04000172 RID: 370
		public static readonly global::Mono.Cecil.Cil.OpCode Unaligned = new global::Mono.Cecil.Cil.OpCode(0x4CF12FE, 0x13001004);

		// Token: 0x04000173 RID: 371
		public static readonly global::Mono.Cecil.Cil.OpCode Volatile = new global::Mono.Cecil.Cil.OpCode(0x4D013FE, 0x13000504);

		// Token: 0x04000174 RID: 372
		public static readonly global::Mono.Cecil.Cil.OpCode Tail = new global::Mono.Cecil.Cil.OpCode(0x4D114FE, 0x13000504);

		// Token: 0x04000175 RID: 373
		public static readonly global::Mono.Cecil.Cil.OpCode Initobj = new global::Mono.Cecil.Cil.OpCode(0x5D215FE, 0x13030C03);

		// Token: 0x04000176 RID: 374
		public static readonly global::Mono.Cecil.Cil.OpCode Constrained = new global::Mono.Cecil.Cil.OpCode(0x5D316FE, 0x13000C04);

		// Token: 0x04000177 RID: 375
		public static readonly global::Mono.Cecil.Cil.OpCode Cpblk = new global::Mono.Cecil.Cil.OpCode(0x5D417FE, 0x13070505);

		// Token: 0x04000178 RID: 376
		public static readonly global::Mono.Cecil.Cil.OpCode Initblk = new global::Mono.Cecil.Cil.OpCode(0x5D518FE, 0x13070505);

		// Token: 0x04000179 RID: 377
		public static readonly global::Mono.Cecil.Cil.OpCode No = new global::Mono.Cecil.Cil.OpCode(0x5D619FE, 0x13001004);

		// Token: 0x0400017A RID: 378
		public static readonly global::Mono.Cecil.Cil.OpCode Rethrow = new global::Mono.Cecil.Cil.OpCode(0x8D71AFE, 0x13000503);

		// Token: 0x0400017B RID: 379
		public static readonly global::Mono.Cecil.Cil.OpCode Sizeof = new global::Mono.Cecil.Cil.OpCode(0x5D81CFE, 0x16000C05);

		// Token: 0x0400017C RID: 380
		public static readonly global::Mono.Cecil.Cil.OpCode Refanytype = new global::Mono.Cecil.Cil.OpCode(0x5D91DFE, 0x16010505);

		// Token: 0x0400017D RID: 381
		public static readonly global::Mono.Cecil.Cil.OpCode Readonly = new global::Mono.Cecil.Cil.OpCode(0x5DA1EFE, 0x13000504);
	}
}
