using System;
using uLink;

// Token: 0x0200044A RID: 1098
public static class uLinkExtentions
{
	// Token: 0x060025FF RID: 9727 RVA: 0x00091CBC File Offset: 0x0008FEBC
	public static void Write7BitEncodedSize(this global::uLink.BitStream stream, ulong u)
	{
		while (u >= 0x80UL)
		{
			stream.WriteByte((byte)((u & 0x7FUL) | 0x80UL));
			u >>= 7;
		}
		stream.WriteByte((byte)u);
	}

	// Token: 0x06002600 RID: 9728 RVA: 0x00091CF0 File Offset: 0x0008FEF0
	public static void Write7BitEncodedSize(this global::uLink.BitStream stream, uint u)
	{
		while (u >= 0x80U)
		{
			stream.WriteByte((byte)((u & 0x7FU) | 0x80U));
			u >>= 7;
		}
		stream.WriteByte((byte)u);
	}

	// Token: 0x06002601 RID: 9729 RVA: 0x00091D2C File Offset: 0x0008FF2C
	public static void Write7BitEncodedSize(this global::uLink.BitStream stream, ushort u)
	{
		while (u >= 0x80)
		{
			stream.WriteByte((byte)((u & 0x7F) | 0x80));
			u = (ushort)(u >> 7);
		}
		stream.WriteByte((byte)u);
	}

	// Token: 0x06002602 RID: 9730 RVA: 0x00091D60 File Offset: 0x0008FF60
	public static void Write7BitEncodedSize(this global::uLink.BitStream stream, long u)
	{
		if (u < 0L)
		{
			throw new global::System.ArgumentOutOfRangeException("u", "u<0");
		}
		stream.Write7BitEncodedSize((ulong)u);
	}

	// Token: 0x06002603 RID: 9731 RVA: 0x00091D84 File Offset: 0x0008FF84
	public static void Write7BitEncodedSize(this global::uLink.BitStream stream, int u)
	{
		if (u < 0)
		{
			throw new global::System.ArgumentOutOfRangeException("u", "u<0");
		}
		stream.Write7BitEncodedSize((uint)u);
	}

	// Token: 0x06002604 RID: 9732 RVA: 0x00091DA4 File Offset: 0x0008FFA4
	public static void Write7BitEncodedSize(this global::uLink.BitStream stream, short u)
	{
		if (u < 0)
		{
			throw new global::System.ArgumentOutOfRangeException("u", "u<0");
		}
		stream.Write7BitEncodedSize((ushort)u);
	}

	// Token: 0x06002605 RID: 9733 RVA: 0x00091DC8 File Offset: 0x0008FFC8
	public static void Read7BitEncodedSize(this global::uLink.BitStream stream, out ulong u)
	{
		byte b = stream.ReadByte();
		int num = 0;
		u = (ulong)(b & 0x7F);
		while ((b & 0x80) == 0x80 && num <= 9)
		{
			b = stream.ReadByte();
			u |= (ulong)((ulong)(b & 0x7F) << (++num * 7 & 0x1F & 0x1F));
		}
	}

	// Token: 0x06002606 RID: 9734 RVA: 0x00091E24 File Offset: 0x00090024
	public static void Read7BitEncodedSize(this global::uLink.BitStream stream, out uint u)
	{
		byte b = stream.ReadByte();
		int num = 0;
		u = (uint)(b & 0x7F);
		while ((b & 0x80) == 0x80 && num <= 4)
		{
			b = stream.ReadByte();
			u |= (uint)((uint)(b & 0x7F) << ++num * 7);
		}
	}

	// Token: 0x06002607 RID: 9735 RVA: 0x00091E7C File Offset: 0x0009007C
	public static void Read7BitEncodedSize(this global::uLink.BitStream stream, out ushort u)
	{
		byte b = stream.ReadByte();
		int num = 0;
		u = (ushort)(b & 0x7F);
		while ((b & 0x80) == 0x80 && num <= 2)
		{
			b = stream.ReadByte();
			u |= (ushort)((b & 0x7F) << (++num * 7 & 0x1F));
		}
	}

	// Token: 0x06002608 RID: 9736 RVA: 0x00091ED4 File Offset: 0x000900D4
	public static void Read7BitEncodedSize(this global::uLink.BitStream stream, out long u)
	{
		ulong num;
		stream.Read7BitEncodedSize(out num);
		if (num > 0x7FFFFFFFFFFFFFFFUL)
		{
			throw new global::System.InvalidOperationException("Wrong");
		}
		u = (long)num;
	}

	// Token: 0x06002609 RID: 9737 RVA: 0x00091F08 File Offset: 0x00090108
	public static void Read7BitEncodedSize(this global::uLink.BitStream stream, out int u)
	{
		uint num;
		stream.Read7BitEncodedSize(out num);
		if (num > 0x7FFFFFFFU)
		{
			throw new global::System.InvalidOperationException("Wrong");
		}
		u = (int)num;
	}

	// Token: 0x0600260A RID: 9738 RVA: 0x00091F38 File Offset: 0x00090138
	public static void Read7BitEncodedSize(this global::uLink.BitStream stream, out short u)
	{
		ushort num;
		stream.Read7BitEncodedSize(out num);
		if (num > 0x7FFF)
		{
			throw new global::System.InvalidOperationException("Wrong");
		}
		u = (short)num;
	}

	// Token: 0x0600260B RID: 9739 RVA: 0x00091F68 File Offset: 0x00090168
	public static byte[] GetDataByteArray(this global::uLink.BitStream stream)
	{
		int bitCount = stream._bitCount;
		int num = bitCount / 8;
		if (bitCount % 8 != 0)
		{
			num++;
		}
		byte[] data = stream._data;
		if (data.Length > num)
		{
			global::System.Array.Resize<byte>(ref data, num);
		}
		return data;
	}

	// Token: 0x0600260C RID: 9740 RVA: 0x00091FA8 File Offset: 0x000901A8
	public static byte[] GetDataByteArrayShiftedRight(this global::uLink.BitStream stream, int right)
	{
		if (right == 0)
		{
			return stream.GetDataByteArray();
		}
		int bitCount = stream._bitCount;
		int num = bitCount / 8;
		if (bitCount % 8 != 0)
		{
			num++;
		}
		byte[] array = new byte[right + num];
		byte[] data = stream._data;
		for (int i = 0; i < num; i++)
		{
			array[right++] = data[i];
		}
		return array;
	}

	// Token: 0x0600260D RID: 9741 RVA: 0x0009200C File Offset: 0x0009020C
	public static void WriteByteArray_MinimumCalls(this global::uLink.BitStream stream, byte[] array, int offset, int length, params object[] codecOptions)
	{
		stream.Write<int>(length, codecOptions);
		int num = offset + length;
		int num2 = length / 8;
		int num3 = length / 4;
		int num4 = length / 2;
		int num5 = length - num4 * 2;
		while (num5-- > 0)
		{
			stream.Write<byte>(array[--num], codecOptions);
		}
		num4 -= num3 * 2;
		while (num4-- > 0)
		{
			ushort num6 = (ushort)(array[--num] << 8);
			num6 |= (ushort)array[--num];
			stream.Write<ushort>(num6, codecOptions);
		}
		num3 -= num2 * 2;
		while (num3-- > 0)
		{
			uint num7 = (uint)((uint)array[--num] << 0x18);
			num7 |= (uint)((uint)array[--num] << 0x10);
			num7 |= (uint)((uint)array[--num] << 8);
			num7 |= (uint)array[--num];
			stream.Write<uint>(num7, codecOptions);
		}
		while (num2-- > 0)
		{
			ulong num8 = (ulong)array[--num] << 0x38;
			num8 |= (ulong)array[--num] << 0x30;
			num8 |= (ulong)array[--num] << 0x28;
			num8 |= (ulong)array[--num] << 0x20;
			num8 |= (ulong)array[--num] << 0x18;
			num8 |= (ulong)array[--num] << 0x10;
			num8 |= (ulong)array[--num] << 8;
			num8 |= (ulong)array[--num];
			stream.Write<ulong>(num8, codecOptions);
		}
	}

	// Token: 0x0600260E RID: 9742 RVA: 0x00092180 File Offset: 0x00090380
	public static void ReadByteArray_MinimalCalls(this global::uLink.BitStream stream, out byte[] array, out int length, params object[] codecOptions)
	{
		length = stream.Read<int>(codecOptions);
		if (length == 0)
		{
			array = null;
		}
		else
		{
			array = new byte[length];
			int num = length;
			int num2 = length / 8;
			int num3 = length / 4;
			int num4 = length / 2;
			int num5 = length;
			num5 -= num4 * 2;
			while (num5-- > 0)
			{
				array[--num] = stream.Read<byte>(codecOptions);
			}
			num4 -= num3 * 2;
			while (num4-- > 0)
			{
				ushort num6 = stream.Read<ushort>(codecOptions);
				array[--num] = (byte)(num6 >> 8 & 0xFF);
				array[--num] = (byte)(num6 & 0xFF);
			}
			num3 -= num2 * 2;
			while (num3-- > 0)
			{
				uint num7 = stream.Read<uint>(codecOptions);
				array[--num] = (byte)(num7 >> 0x18 & 0xFFU);
				array[--num] = (byte)(num7 >> 0x10 & 0xFFU);
				array[--num] = (byte)(num7 >> 8 & 0xFFU);
				array[--num] = (byte)(num7 & 0xFFU);
			}
			while (num2-- > 0)
			{
				ulong num8 = stream.Read<ulong>(codecOptions);
				array[--num] = (byte)(num8 >> 0x38 & 0xFFUL);
				array[--num] = (byte)(num8 >> 0x30 & 0xFFUL);
				array[--num] = (byte)(num8 >> 0x28 & 0xFFUL);
				array[--num] = (byte)(num8 >> 0x20 & 0xFFUL);
				array[--num] = (byte)(num8 >> 0x18 & 0xFFUL);
				array[--num] = (byte)(num8 >> 0x10 & 0xFFUL);
				array[--num] = (byte)(num8 >> 8 & 0xFFUL);
				array[--num] = (byte)(num8 & 0xFFUL);
			}
		}
	}

	// Token: 0x0400135F RID: 4959
	private const ushort bit8 = 0x80;

	// Token: 0x04001360 RID: 4960
	private const ushort bit1234567 = 0x7F;

	// Token: 0x04001361 RID: 4961
	private const int kByte0 = 0;

	// Token: 0x04001362 RID: 4962
	private const int kByte1 = 8;

	// Token: 0x04001363 RID: 4963
	private const int kByte2 = 0x10;

	// Token: 0x04001364 RID: 4964
	private const int kByte3 = 0x18;

	// Token: 0x04001365 RID: 4965
	private const int kByte4 = 0x20;

	// Token: 0x04001366 RID: 4966
	private const int kByte5 = 0x28;

	// Token: 0x04001367 RID: 4967
	private const int kByte6 = 0x30;

	// Token: 0x04001368 RID: 4968
	private const int kByte7 = 0x38;
}
