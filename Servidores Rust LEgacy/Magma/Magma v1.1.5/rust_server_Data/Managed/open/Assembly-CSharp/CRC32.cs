using System;
using System.Security.Cryptography;
using System.Text;

// Token: 0x020001DB RID: 475
public sealed class CRC32 : global::System.Security.Cryptography.HashAlgorithm
{
	// Token: 0x06000D5B RID: 3419 RVA: 0x00034548 File Offset: 0x00032748
	public CRC32()
	{
		this.table = global::CRC32.Default.Table;
		this.seed = uint.MaxValue;
		this.Initialize();
	}

	// Token: 0x06000D5C RID: 3420 RVA: 0x00034568 File Offset: 0x00032768
	public CRC32(uint polynomial, uint seed)
	{
		this.table = ((polynomial != 0xEDB88320U) ? global::CRC32.ProcessHashTable(polynomial) : global::CRC32.Default.Table);
		this.seed = seed;
		this.Initialize();
	}

	// Token: 0x06000D5D RID: 3421 RVA: 0x000345AC File Offset: 0x000327AC
	private static uint[] ProcessHashTable(uint p)
	{
		uint[] array = new uint[0x100];
		for (ushort num = 0; num < 0x100; num += 1)
		{
			array[(int)num] = (uint)num;
			for (uint num2 = 0U; num2 < 8U; num2 += 1U)
			{
				array[(int)num] = (((array[(int)num] & 1U) != 1U) ? (array[(int)num] >> 1) : (array[(int)num] >> 1 ^ p));
			}
		}
		return array;
	}

	// Token: 0x06000D5E RID: 3422 RVA: 0x00034614 File Offset: 0x00032814
	public static uint Quick(byte[] buffer)
	{
		return ~global::CRC32.BufferHash(global::CRC32.Default.Table, uint.MaxValue, buffer, 0, buffer.Length);
	}

	// Token: 0x06000D5F RID: 3423 RVA: 0x00034628 File Offset: 0x00032828
	public static uint String(string str)
	{
		byte[] bytes = global::System.Text.Encoding.ASCII.GetBytes(str);
		return global::CRC32.Quick(bytes);
	}

	// Token: 0x06000D60 RID: 3424 RVA: 0x00034648 File Offset: 0x00032848
	public static uint Quick(uint seed, byte[] buffer)
	{
		return ~global::CRC32.BufferHash(global::CRC32.Default.Table, seed, buffer, 0, buffer.Length);
	}

	// Token: 0x06000D61 RID: 3425 RVA: 0x0003465C File Offset: 0x0003285C
	public static uint Quick(uint polynomial, uint seed, byte[] buffer)
	{
		return ~global::CRC32.BufferHash(global::CRC32.Default.Table, seed, buffer, 0, buffer.Length);
	}

	// Token: 0x06000D62 RID: 3426 RVA: 0x00034670 File Offset: 0x00032870
	private static uint BufferHash(uint[] table, uint seed, byte[] buffer, int start, int size)
	{
		while (size-- > 0)
		{
			seed = (seed >> 8 ^ table[(int)((global::System.UIntPtr)((uint)buffer[start++] ^ (seed & 0xFFU)))]);
		}
		return seed;
	}

	// Token: 0x06000D63 RID: 3427 RVA: 0x000346AC File Offset: 0x000328AC
	private void BufferHash(byte[] buffer, int start, int size)
	{
		while (size-- > 0)
		{
			this.hash = (this.hash >> 8 ^ this.table[(int)((global::System.UIntPtr)((uint)buffer[start++] ^ (this.hash & 0xFFU)))]);
		}
	}

	// Token: 0x06000D64 RID: 3428 RVA: 0x000346EC File Offset: 0x000328EC
	public override void Initialize()
	{
		this.hash = this.seed;
	}

	// Token: 0x06000D65 RID: 3429 RVA: 0x000346FC File Offset: 0x000328FC
	protected sealed override void HashCore(byte[] buffer, int start, int length)
	{
		this.BufferHash(buffer, start, length);
	}

	// Token: 0x06000D66 RID: 3430 RVA: 0x00034708 File Offset: 0x00032908
	protected sealed override byte[] HashFinal()
	{
		uint num = ~this.hash;
		byte[] array = new byte[]
		{
			(byte)(num >> 0x18 & 0xFFU),
			(byte)(num >> 0x10 & 0xFFU),
			(byte)(num >> 8 & 0xFFU),
			(byte)(num & 0xFFU)
		};
		this.HashValue = array;
		return array;
	}

	// Token: 0x1700034F RID: 847
	// (get) Token: 0x06000D67 RID: 3431 RVA: 0x00034760 File Offset: 0x00032960
	public sealed override int HashSize
	{
		get
		{
			return 0x20;
		}
	}

	// Token: 0x0400088C RID: 2188
	public const uint kDefaultPolynomial = 0xEDB88320U;

	// Token: 0x0400088D RID: 2189
	public const uint kDefaultSeed = 0xFFFFFFFFU;

	// Token: 0x0400088E RID: 2190
	public const uint kTableSize = 0x100U;

	// Token: 0x0400088F RID: 2191
	private const uint I = 0x100U;

	// Token: 0x04000890 RID: 2192
	private const uint J = 8U;

	// Token: 0x04000891 RID: 2193
	private uint hash;

	// Token: 0x04000892 RID: 2194
	private readonly uint seed;

	// Token: 0x04000893 RID: 2195
	private readonly uint[] table;

	// Token: 0x020001DC RID: 476
	private static class Default
	{
		// Token: 0x06000D68 RID: 3432 RVA: 0x00034764 File Offset: 0x00032964
		static Default()
		{
			for (uint num = 0U; num < 0x100U; num += 1U)
			{
				global::CRC32.Default.Table[(int)((global::System.UIntPtr)num)] = num;
				for (uint num2 = 0U; num2 < 8U; num2 += 1U)
				{
					global::CRC32.Default.Table[(int)((global::System.UIntPtr)num)] = (((global::CRC32.Default.Table[(int)((global::System.UIntPtr)num)] & 1U) != 1U) ? (global::CRC32.Default.Table[(int)((global::System.UIntPtr)num)] >> 1) : (global::CRC32.Default.Table[(int)((global::System.UIntPtr)num)] >> 1 ^ 0xEDB88320U));
				}
			}
		}

		// Token: 0x04000894 RID: 2196
		public static readonly uint[] Table = new uint[0x100];
	}
}
