using System;
using System.Text;

namespace Facepunch.Hash
{
	// Token: 0x020001DD RID: 477
	public static class MurmurHash2
	{
		// Token: 0x06000D69 RID: 3433 RVA: 0x000347EC File Offset: 0x000329EC
		public static uint UINT(byte[] key, int len, uint seed)
		{
			uint num = (uint)((ulong)seed ^ (ulong)((long)(len * 1)));
			int num2 = 0;
			while (len >= 4)
			{
				uint num3 = (uint)((int)key[num2++] | (int)key[num2++] << 8 | (int)key[num2++] << 0x10 | (int)key[num2++] << 0x18);
				num3 *= 0x5BD1E995U;
				num3 ^= num3 >> 0x18;
				num3 *= 0x5BD1E995U;
				num *= 0x5BD1E995U;
				num ^= num3;
				len -= 4;
			}
			switch (len)
			{
			case 1:
				num ^= (uint)key[num2];
				num *= 0x5BD1E995U;
				break;
			case 2:
				num ^= (uint)((uint)key[num2 + 1] << 8);
				num ^= (uint)key[num2];
				num *= 0x5BD1E995U;
				break;
			case 3:
				num ^= (uint)((uint)key[num2 + 2] << 0x10);
				num ^= (uint)((uint)key[num2 + 1] << 8);
				num ^= (uint)key[num2];
				num *= 0x5BD1E995U;
				break;
			}
			num ^= num >> 0xD;
			num *= 0x5BD1E995U;
			return num ^ num >> 0xF;
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x000348EC File Offset: 0x00032AEC
		public static uint UINT(byte[] key, uint seed)
		{
			return global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D6B RID: 3435 RVA: 0x000348F8 File Offset: 0x00032AF8
		public static uint UINT(sbyte[] key, int len, uint seed)
		{
			uint num = (uint)((ulong)seed ^ (ulong)((long)(len * 1)));
			int num2 = 0;
			while (len >= 4)
			{
				uint num3 = (uint)((int)((byte)key[num2++]) | (int)((byte)key[num2++]) << 8 | (int)((byte)key[num2++]) << 0x10 | (int)((byte)key[num2++]) << 0x18);
				num3 *= 0x5BD1E995U;
				num3 ^= num3 >> 0x18;
				num3 *= 0x5BD1E995U;
				num *= 0x5BD1E995U;
				num ^= num3;
				len -= 4;
			}
			switch (len)
			{
			case 1:
				num ^= (uint)key[num2];
				num *= 0x5BD1E995U;
				break;
			case 2:
				num ^= (uint)key[num2 + 1] << 8;
				num ^= (uint)key[num2];
				num *= 0x5BD1E995U;
				break;
			case 3:
				num ^= (uint)key[num2 + 2] << 0x10;
				num ^= (uint)key[num2 + 1] << 8;
				num ^= (uint)key[num2];
				num *= 0x5BD1E995U;
				break;
			}
			num ^= num >> 0xD;
			num *= 0x5BD1E995U;
			return num ^ num >> 0xF;
		}

		// Token: 0x06000D6C RID: 3436 RVA: 0x00034A00 File Offset: 0x00032C00
		public static uint UINT(sbyte[] key, uint seed)
		{
			return global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D6D RID: 3437 RVA: 0x00034A0C File Offset: 0x00032C0C
		public static uint UINT(ushort[] key, int len, uint seed)
		{
			uint num = (uint)((ulong)seed ^ (ulong)((long)(len * 2)));
			int num2 = 0;
			while (len >= 2)
			{
				uint num3 = (uint)((int)key[num2++] | (int)key[num2++] << 0x10);
				num3 *= 0x5BD1E995U;
				num3 ^= num3 >> 0x18;
				num3 *= 0x5BD1E995U;
				num *= 0x5BD1E995U;
				num ^= num3;
				len -= 2;
			}
			int num4 = len;
			if (num4 == 1)
			{
				num ^= (uint)(key[num2] & 0xFF00);
				num ^= (uint)(key[num2] & 0xFF);
				num *= 0x5BD1E995U;
			}
			num ^= num >> 0xD;
			num *= 0x5BD1E995U;
			return num ^ num >> 0xF;
		}

		// Token: 0x06000D6E RID: 3438 RVA: 0x00034AB8 File Offset: 0x00032CB8
		public static uint UINT(ushort[] key, uint seed)
		{
			return global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D6F RID: 3439 RVA: 0x00034AC4 File Offset: 0x00032CC4
		public static uint UINT(short[] key, int len, uint seed)
		{
			uint num = (uint)((ulong)seed ^ (ulong)((long)(len * 2)));
			int num2 = 0;
			while (len >= 2)
			{
				uint num3 = (uint)((int)((ushort)key[num2++]) | (int)((ushort)key[num2++]) << 0x10);
				num3 *= 0x5BD1E995U;
				num3 ^= num3 >> 0x18;
				num3 *= 0x5BD1E995U;
				num *= 0x5BD1E995U;
				num ^= num3;
				len -= 2;
			}
			int num4 = len;
			if (num4 == 1)
			{
				num ^= ((uint)key[num2] & 0xFF00U);
				num ^= (uint)(key[num2] & 0xFF);
				num *= 0x5BD1E995U;
			}
			num ^= num >> 0xD;
			num *= 0x5BD1E995U;
			return num ^ num >> 0xF;
		}

		// Token: 0x06000D70 RID: 3440 RVA: 0x00034B70 File Offset: 0x00032D70
		public static uint UINT(short[] key, uint seed)
		{
			return global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D71 RID: 3441 RVA: 0x00034B7C File Offset: 0x00032D7C
		public static uint UINT(char[] key, int len, uint seed)
		{
			uint num = (uint)((ulong)seed ^ (ulong)((long)(len * 2)));
			int num2 = 0;
			while (len >= 2)
			{
				uint num3 = (uint)(key[num2++] | (uint)key[num2++] << 0x10);
				num3 *= 0x5BD1E995U;
				num3 ^= num3 >> 0x18;
				num3 *= 0x5BD1E995U;
				num *= 0x5BD1E995U;
				num ^= num3;
				len -= 2;
			}
			int num4 = len;
			if (num4 == 1)
			{
				num ^= (uint)(key[num2] & '＀');
				num ^= (uint)(key[num2] & 'ÿ');
				num *= 0x5BD1E995U;
			}
			num ^= num >> 0xD;
			num *= 0x5BD1E995U;
			return num ^ num >> 0xF;
		}

		// Token: 0x06000D72 RID: 3442 RVA: 0x00034C28 File Offset: 0x00032E28
		public static uint UINT(char[] key, uint seed)
		{
			return global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D73 RID: 3443 RVA: 0x00034C34 File Offset: 0x00032E34
		public static uint UINT(string key, int len, uint seed)
		{
			uint num = (uint)((ulong)seed ^ (ulong)((long)(len * 2)));
			int index = 0;
			while (len >= 2)
			{
				uint num2 = (uint)(key[index++] | (uint)key[index++] << 0x10);
				num2 *= 0x5BD1E995U;
				num2 ^= num2 >> 0x18;
				num2 *= 0x5BD1E995U;
				num *= 0x5BD1E995U;
				num ^= num2;
				len -= 2;
			}
			int num3 = len;
			if (num3 == 1)
			{
				num ^= (uint)(key[index] & '＀');
				num ^= (uint)(key[index] & 'ÿ');
				num *= 0x5BD1E995U;
			}
			num ^= num >> 0xD;
			num *= 0x5BD1E995U;
			return num ^ num >> 0xF;
		}

		// Token: 0x06000D74 RID: 3444 RVA: 0x00034CF0 File Offset: 0x00032EF0
		public static uint UINT(string key, uint seed)
		{
			return global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D75 RID: 3445 RVA: 0x00034D00 File Offset: 0x00032F00
		public static uint UINT(uint[] key, int len, uint seed)
		{
			uint num = (uint)((ulong)seed ^ (ulong)((long)(len * 4)));
			int num2 = 0;
			while (len > 0)
			{
				uint num3 = key[num2++];
				num3 *= 0x5BD1E995U;
				num3 ^= num3 >> 0x18;
				num3 *= 0x5BD1E995U;
				num *= 0x5BD1E995U;
				num ^= num3;
				len--;
			}
			num ^= num >> 0xD;
			num *= 0x5BD1E995U;
			return num ^ num >> 0xF;
		}

		// Token: 0x06000D76 RID: 3446 RVA: 0x00034D6C File Offset: 0x00032F6C
		public static uint UINT(uint[] key, uint seed)
		{
			return global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D77 RID: 3447 RVA: 0x00034D78 File Offset: 0x00032F78
		public static uint UINT(int[] key, int len, uint seed)
		{
			uint num = (uint)((ulong)seed ^ (ulong)((long)(len * 4)));
			int num2 = 0;
			while (len > 0)
			{
				uint num3 = (uint)key[num2++];
				num3 *= 0x5BD1E995U;
				num3 ^= num3 >> 0x18;
				num3 *= 0x5BD1E995U;
				num *= 0x5BD1E995U;
				num ^= num3;
				len--;
			}
			num ^= num >> 0xD;
			num *= 0x5BD1E995U;
			return num ^ num >> 0xF;
		}

		// Token: 0x06000D78 RID: 3448 RVA: 0x00034DE4 File Offset: 0x00032FE4
		public static uint UINT(int[] key, uint seed)
		{
			return global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D79 RID: 3449 RVA: 0x00034DF0 File Offset: 0x00032FF0
		public static uint UINT(ulong[] key, int len, uint seed)
		{
			uint num = (uint)((ulong)seed ^ (ulong)((long)(len * 8)));
			int num2 = 0;
			while (len > 0)
			{
				uint num3 = (uint)(key[num2] & (ulong)-1);
				num3 *= 0x5BD1E995U;
				num3 ^= num3 >> 0x18;
				num3 *= 0x5BD1E995U;
				num *= 0x5BD1E995U;
				num ^= num3;
				uint num4 = (uint)(key[num2] >> 0x20 & (ulong)-1);
				num4 *= 0x5BD1E995U;
				num4 ^= num4 >> 0x18;
				num4 *= 0x5BD1E995U;
				num *= 0x5BD1E995U;
				num ^= num4;
				len--;
			}
			num ^= num >> 0xD;
			num *= 0x5BD1E995U;
			return num ^ num >> 0xF;
		}

		// Token: 0x06000D7A RID: 3450 RVA: 0x00034E8C File Offset: 0x0003308C
		public static uint UINT(ulong[] key, uint seed)
		{
			return global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D7B RID: 3451 RVA: 0x00034E98 File Offset: 0x00033098
		public static uint UINT(long[] key, int len, uint seed)
		{
			uint num = (uint)((ulong)seed ^ (ulong)((long)(len * 8)));
			int num2 = 0;
			while (len > 0)
			{
				uint num3 = (uint)(key[num2] & (long)((ulong)-1));
				num3 *= 0x5BD1E995U;
				num3 ^= num3 >> 0x18;
				num3 *= 0x5BD1E995U;
				num *= 0x5BD1E995U;
				num ^= num3;
				uint num4 = (uint)(key[num2] >> 0x20 & (long)((ulong)-1));
				num4 *= 0x5BD1E995U;
				num4 ^= num4 >> 0x18;
				num4 *= 0x5BD1E995U;
				num *= 0x5BD1E995U;
				num ^= num4;
				len--;
			}
			num ^= num >> 0xD;
			num *= 0x5BD1E995U;
			return num ^ num >> 0xF;
		}

		// Token: 0x06000D7C RID: 3452 RVA: 0x00034F34 File Offset: 0x00033134
		public static uint UINT(long[] key, uint seed)
		{
			return global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D7D RID: 3453 RVA: 0x00034F40 File Offset: 0x00033140
		public static uint UINT_BLOCK(global::System.Array key, int len, uint seed)
		{
			uint num = (uint)((ulong)seed ^ (ulong)((long)(len * 1)));
			int num2 = 0;
			while (len >= 4)
			{
				uint num3 = (uint)((int)global::System.Buffer.GetByte(key, num2++) | (int)global::System.Buffer.GetByte(key, num2++) << 8 | (int)global::System.Buffer.GetByte(key, num2++) << 0x10 | (int)global::System.Buffer.GetByte(key, num2++) << 0x18);
				num3 *= 0x5BD1E995U;
				num3 ^= num3 >> 0x18;
				num3 *= 0x5BD1E995U;
				num *= 0x5BD1E995U;
				num ^= num3;
				len -= 4;
			}
			switch (len)
			{
			case 1:
				num ^= (uint)global::System.Buffer.GetByte(key, num2);
				num *= 0x5BD1E995U;
				break;
			case 2:
				num ^= (uint)((uint)global::System.Buffer.GetByte(key, num2 + 1) << 8);
				num ^= (uint)global::System.Buffer.GetByte(key, num2);
				num *= 0x5BD1E995U;
				break;
			case 3:
				num ^= (uint)((uint)global::System.Buffer.GetByte(key, num2 + 2) << 0x10);
				num ^= (uint)((uint)global::System.Buffer.GetByte(key, num2 + 1) << 8);
				num ^= (uint)global::System.Buffer.GetByte(key, num2);
				num *= 0x5BD1E995U;
				break;
			}
			num ^= num >> 0xD;
			num *= 0x5BD1E995U;
			return num ^ num >> 0xF;
		}

		// Token: 0x06000D7E RID: 3454 RVA: 0x00035068 File Offset: 0x00033268
		public static uint UINT_BLOCK(global::System.Array key, uint seed)
		{
			return global::Facepunch.Hash.MurmurHash2.UINT_BLOCK(key, global::System.Buffer.ByteLength(key), seed);
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x00035078 File Offset: 0x00033278
		public static uint UINT(string key, global::System.Text.Encoding encoding, uint seed)
		{
			return global::Facepunch.Hash.MurmurHash2.UINT(encoding.GetBytes(key), seed);
		}

		// Token: 0x06000D80 RID: 3456 RVA: 0x00035088 File Offset: 0x00033288
		public static int SINT(byte[] key, int len, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, len, seed);
		}

		// Token: 0x06000D81 RID: 3457 RVA: 0x00035094 File Offset: 0x00033294
		public static int SINT(sbyte[] key, int len, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, len, seed);
		}

		// Token: 0x06000D82 RID: 3458 RVA: 0x000350A0 File Offset: 0x000332A0
		public static int SINT(ushort[] key, int len, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, len, seed);
		}

		// Token: 0x06000D83 RID: 3459 RVA: 0x000350AC File Offset: 0x000332AC
		public static int SINT(short[] key, int len, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, len, seed);
		}

		// Token: 0x06000D84 RID: 3460 RVA: 0x000350B8 File Offset: 0x000332B8
		public static int SINT(char[] key, int len, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, len, seed);
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x000350C4 File Offset: 0x000332C4
		public static int SINT(string key, int len, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, len, seed);
		}

		// Token: 0x06000D86 RID: 3462 RVA: 0x000350D0 File Offset: 0x000332D0
		public static int SINT(uint[] key, int len, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, len, seed);
		}

		// Token: 0x06000D87 RID: 3463 RVA: 0x000350DC File Offset: 0x000332DC
		public static int SINT(int[] key, int len, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, len, seed);
		}

		// Token: 0x06000D88 RID: 3464 RVA: 0x000350E8 File Offset: 0x000332E8
		public static int SINT(ulong[] key, int len, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, len, seed);
		}

		// Token: 0x06000D89 RID: 3465 RVA: 0x000350F4 File Offset: 0x000332F4
		public static int SINT(long[] key, int len, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, len, seed);
		}

		// Token: 0x06000D8A RID: 3466 RVA: 0x00035100 File Offset: 0x00033300
		public static int SINT(byte[] key, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D8B RID: 3467 RVA: 0x0003510C File Offset: 0x0003330C
		public static int SINT(sbyte[] key, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D8C RID: 3468 RVA: 0x00035118 File Offset: 0x00033318
		public static int SINT(ushort[] key, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D8D RID: 3469 RVA: 0x00035124 File Offset: 0x00033324
		public static int SINT(short[] key, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D8E RID: 3470 RVA: 0x00035130 File Offset: 0x00033330
		public static int SINT(char[] key, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D8F RID: 3471 RVA: 0x0003513C File Offset: 0x0003333C
		public static int SINT(string key, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D90 RID: 3472 RVA: 0x0003514C File Offset: 0x0003334C
		public static int SINT(uint[] key, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D91 RID: 3473 RVA: 0x00035158 File Offset: 0x00033358
		public static int SINT(int[] key, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D92 RID: 3474 RVA: 0x00035164 File Offset: 0x00033364
		public static int SINT(ulong[] key, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D93 RID: 3475 RVA: 0x00035170 File Offset: 0x00033370
		public static int SINT(long[] key, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, key.Length, seed);
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x0003517C File Offset: 0x0003337C
		public static int SINT_BLOCK(global::System.Array key, int len, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT_BLOCK(key, len, seed);
		}

		// Token: 0x06000D95 RID: 3477 RVA: 0x00035188 File Offset: 0x00033388
		public static int SINT_BLOCK(global::System.Array key, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT_BLOCK(key, global::System.Buffer.ByteLength(key), seed);
		}

		// Token: 0x06000D96 RID: 3478 RVA: 0x00035198 File Offset: 0x00033398
		public static int SINT(string key, global::System.Text.Encoding encoding, uint seed)
		{
			return (int)global::Facepunch.Hash.MurmurHash2.UINT(key, encoding, seed);
		}

		// Token: 0x04000895 RID: 2197
		public const uint m = 0x5BD1E995U;

		// Token: 0x04000896 RID: 2198
		public const int r = 0x18;
	}
}
