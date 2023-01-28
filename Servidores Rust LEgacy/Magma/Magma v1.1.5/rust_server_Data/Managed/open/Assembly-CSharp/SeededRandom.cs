using System;

// Token: 0x020007A3 RID: 1955
public class SeededRandom
{
	// Token: 0x06004112 RID: 16658 RVA: 0x000E9A18 File Offset: 0x000E7C18
	public SeededRandom() : this(global::System.Environment.TickCount)
	{
	}

	// Token: 0x06004113 RID: 16659 RVA: 0x000E9A28 File Offset: 0x000E7C28
	public SeededRandom(int seed)
	{
		this.byteBuffer = new byte[0x10];
		this.Seed = seed;
		this.rand = new global::System.Random(seed);
	}

	// Token: 0x06004114 RID: 16660 RVA: 0x000E9A5C File Offset: 0x000E7C5C
	public int RandomBits(int bitCount)
	{
		if (bitCount < 0 || bitCount > 0x20)
		{
			throw new global::System.ArgumentOutOfRangeException("bitCount");
		}
		int num = 0;
		int num2 = 0;
		while (bitCount-- > 0)
		{
			if (this.Boolean())
			{
				num |= 1 << num2;
			}
			num2++;
		}
		return num;
	}

	// Token: 0x17000C03 RID: 3075
	// (get) Token: 0x06004115 RID: 16661 RVA: 0x000E9AB4 File Offset: 0x000E7CB4
	// (set) Token: 0x06004116 RID: 16662 RVA: 0x000E9B14 File Offset: 0x000E7D14
	public uint PositionData
	{
		get
		{
			return ((((this.bytePos <= 0 && this.bitPos <= 0) || this.allocCount <= 0U) ? this.allocCount : (this.allocCount - 1U)) << 4 | (uint)(this.bytePos & 0xF)) << 7 | (uint)(this.bitPos & 7);
		}
		set
		{
			byte b = (byte)(value & 7U);
			byte b2 = (byte)((value >>= 3) & 0xFU);
			uint num;
			value = (num = value >> 4);
			if (b > 0 || b2 > 0)
			{
				num += 1U;
			}
			if (num < this.allocCount)
			{
				this.allocCount = 0U;
				this.rand = new global::System.Random(this.Seed);
			}
			while (this.allocCount < num)
			{
				this.allocCount += 1U;
				this.rand.NextBytes(this.byteBuffer);
			}
			this.bitPos = b;
			this.bytePos = b2;
		}
	}

	// Token: 0x06004117 RID: 16663 RVA: 0x000E9BAC File Offset: 0x000E7DAC
	private void Fill()
	{
		if ((this.allocCount += 1U) == 0x2000000U)
		{
			this.rand = new global::System.Random(this.Seed);
			this.allocCount = 1U;
		}
		this.rand.NextBytes(this.byteBuffer);
	}

	// Token: 0x06004118 RID: 16664 RVA: 0x000E9C00 File Offset: 0x000E7E00
	public bool Boolean()
	{
		if (this.bytePos == 0 && this.bitPos == 0)
		{
			this.Fill();
			this.bitPos += 1;
			return (this.byteBuffer[0] & 1) == 1;
		}
		bool result = ((int)this.byteBuffer[(int)this.bytePos] & 1 << (int)this.bitPos) == 1 << (int)this.bitPos;
		if ((this.bitPos += 1) == 8)
		{
			this.bitPos = 0;
			if ((this.bytePos += 1) == 0x10)
			{
				this.bytePos = 0;
			}
		}
		return result;
	}

	// Token: 0x06004119 RID: 16665 RVA: 0x000E9CB0 File Offset: 0x000E7EB0
	private double RandomFractionBitDepth(int bitDepth, int bitMask)
	{
		if (bitDepth < 1 || bitDepth > 0x20)
		{
			throw new global::System.ArgumentOutOfRangeException("bitDepth", "!( bitDepth > 0 && bitDepth <= 32 )");
		}
		if (bitDepth == 0x20)
		{
			return this.RandomFraction32();
		}
		if (bitMask <= 0)
		{
			throw new global::System.ArgumentException("bitMask", "!(bitMask > 0)");
		}
		int num = 0;
		for (int i = 0; i < bitDepth; i++)
		{
			if (this.Boolean())
			{
				num |= 1 << i;
			}
		}
		return (double)num / (double)bitMask;
	}

	// Token: 0x0600411A RID: 16666 RVA: 0x000E9D34 File Offset: 0x000E7F34
	public double RandomFraction32()
	{
		uint num = 0U;
		for (int i = 0; i < 0x20; i++)
		{
			if (this.Boolean())
			{
				num |= 1U << i;
			}
		}
		return num / 4294967295.0;
	}

	// Token: 0x0600411B RID: 16667 RVA: 0x000E9D7C File Offset: 0x000E7F7C
	public double RandomFraction16()
	{
		uint num = 0U;
		for (int i = 0; i < 0x10; i++)
		{
			if (this.Boolean())
			{
				num |= 1U << i;
			}
		}
		return num / 65535.0;
	}

	// Token: 0x0600411C RID: 16668 RVA: 0x000E9DC4 File Offset: 0x000E7FC4
	public double RandomFraction8()
	{
		uint num = 0U;
		for (int i = 0; i < 8; i++)
		{
			if (this.Boolean())
			{
				num |= 1U << i;
			}
		}
		return num / 255.0;
	}

	// Token: 0x0600411D RID: 16669 RVA: 0x000E9E0C File Offset: 0x000E800C
	public double RandomFractionBitDepth(int bitDepth)
	{
		if (bitDepth < 1 || bitDepth > 0x20)
		{
			throw new global::System.ArgumentOutOfRangeException("bitDepth", "!( bitDepth > 0 && bitDepth <= 32 )");
		}
		if (bitDepth == 0x20)
		{
			return this.RandomFraction32();
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < bitDepth; i++)
		{
			int num3 = 1 << i;
			if (this.Boolean())
			{
				num |= num3;
			}
			num2 |= num3;
		}
		return (double)num / (double)num2;
	}

	// Token: 0x0600411E RID: 16670 RVA: 0x000E9E7C File Offset: 0x000E807C
	private static double LT1(double v)
	{
		return (v <= 1E-323) ? v : (v - double.Epsilon);
	}

	// Token: 0x0600411F RID: 16671 RVA: 0x000E9EAC File Offset: 0x000E80AC
	private double RandomFractionBitDepthLT1(int bitDepth, int bitMask)
	{
		return global::SeededRandom.LT1(this.RandomFractionBitDepth(bitDepth, bitMask));
	}

	// Token: 0x06004120 RID: 16672 RVA: 0x000E9EBC File Offset: 0x000E80BC
	public double RandomFractionBitDepthLT1(int bitDepth)
	{
		return global::SeededRandom.LT1(this.RandomFractionBitDepth(bitDepth));
	}

	// Token: 0x06004121 RID: 16673 RVA: 0x000E9ECC File Offset: 0x000E80CC
	public int RandomIndex(int length)
	{
		if (length == 0 || (length & -0x80000000) == -0x80000000)
		{
			throw new global::System.ArgumentOutOfRangeException("length", "!(length <= 0)");
		}
		uint num;
		if ((num = (uint)length >> 1) == 0U)
		{
			return 0;
		}
		int num2 = 1;
		byte b = 1;
		if ((num >>= 1) != 0U)
		{
			do
			{
				b += 1;
				num2 = (num2 << 1 | 1);
			}
			while ((num >>= 1) != 0U);
			return (int)global::System.Math.Floor(this.RandomFractionBitDepthLT1((int)b, num2) * (double)length);
		}
		return (!this.Boolean()) ? 0 : 1;
	}

	// Token: 0x06004122 RID: 16674 RVA: 0x000E9F58 File Offset: 0x000E8158
	public double Range(double minInclusive, double maxInclusive, int bitDepth)
	{
		return (minInclusive != maxInclusive) ? (this.RandomFractionBitDepth(bitDepth) * (maxInclusive - minInclusive) + minInclusive) : minInclusive;
	}

	// Token: 0x06004123 RID: 16675 RVA: 0x000E9F74 File Offset: 0x000E8174
	public double Range(double minInclusive, double maxInclusive)
	{
		return this.Range(minInclusive, maxInclusive, 0x10);
	}

	// Token: 0x06004124 RID: 16676 RVA: 0x000E9F80 File Offset: 0x000E8180
	public float Range(float minInclusive, float maxInclusive, int bitDepth)
	{
		return (float)this.Range((double)minInclusive, (double)maxInclusive, bitDepth);
	}

	// Token: 0x06004125 RID: 16677 RVA: 0x000E9F90 File Offset: 0x000E8190
	public float Range(float minInclusive, float maxInclusive)
	{
		return (float)this.Range((double)minInclusive, (double)maxInclusive);
	}

	// Token: 0x06004126 RID: 16678 RVA: 0x000E9FA0 File Offset: 0x000E81A0
	public int Range(int minInclusive, int maxInclusive)
	{
		if (minInclusive > maxInclusive)
		{
			int num = maxInclusive;
			maxInclusive = minInclusive;
			minInclusive = num;
		}
		else if (maxInclusive == minInclusive)
		{
			return minInclusive;
		}
		ulong num2 = (ulong)((long)maxInclusive - (long)minInclusive);
		if (num2 > 0x7FFFFFFFUL)
		{
			return (int)((long)minInclusive + (long)global::System.Math.Round(num2 * this.RandomFraction32()));
		}
		int num3 = 0;
		int num4 = 0;
		uint num5 = (uint)num2;
		while ((num5 >>= 1) != 0U)
		{
			num3++;
			num4 = (num4 << 1 | 1);
		}
		return minInclusive + (int)global::System.Math.Round((double)this.RandomBits(num3) / (double)num4 * num2);
	}

	// Token: 0x06004127 RID: 16679 RVA: 0x000EA02C File Offset: 0x000E822C
	public bool Reset()
	{
		if (this.allocCount > 0U)
		{
			this.rand = new global::System.Random(this.Seed);
			this.allocCount = 0U;
			return true;
		}
		return false;
	}

	// Token: 0x06004128 RID: 16680 RVA: 0x000EA058 File Offset: 0x000E8258
	public T Pick<T>(T[] array)
	{
		if (array == null)
		{
			throw new global::System.ArgumentNullException("array");
		}
		return array[this.RandomIndex(array.Length)];
	}

	// Token: 0x06004129 RID: 16681 RVA: 0x000EA088 File Offset: 0x000E8288
	public bool Pick<T>(T[] array, out T value)
	{
		if (array == null || array.Length == 0)
		{
			value = default(T);
			return false;
		}
		value = array[this.RandomIndex(array.Length)];
		return true;
	}

	// Token: 0x040021E8 RID: 8680
	private const int kBufferSize = 0x10;

	// Token: 0x040021E9 RID: 8681
	private const int kBufferBitSize = 0x80;

	// Token: 0x040021EA RID: 8682
	private const int kBitsInByte = 8;

	// Token: 0x040021EB RID: 8683
	private const byte kMaskBitPos = 7;

	// Token: 0x040021EC RID: 8684
	private const int kShiftBitPos = 3;

	// Token: 0x040021ED RID: 8685
	private const byte kMaskBytePos = 0xF;

	// Token: 0x040021EE RID: 8686
	private const int kShiftBytePos = 4;

	// Token: 0x040021EF RID: 8687
	private const int kMaxAllocPos = 0x1FFFFFF;

	// Token: 0x040021F0 RID: 8688
	private const int kMaxAllocCount = 0x2000000;

	// Token: 0x040021F1 RID: 8689
	private global::System.Random rand;

	// Token: 0x040021F2 RID: 8690
	private readonly byte[] byteBuffer;

	// Token: 0x040021F3 RID: 8691
	public readonly int Seed;

	// Token: 0x040021F4 RID: 8692
	private uint allocCount;

	// Token: 0x040021F5 RID: 8693
	private byte bytePos;

	// Token: 0x040021F6 RID: 8694
	private byte bitPos;
}
