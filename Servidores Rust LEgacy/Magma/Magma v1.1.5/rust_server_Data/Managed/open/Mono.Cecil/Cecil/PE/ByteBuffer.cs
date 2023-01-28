using System;

namespace Mono.Cecil.PE
{
	// Token: 0x02000085 RID: 133
	internal class ByteBuffer
	{
		// Token: 0x06000557 RID: 1367 RVA: 0x0000D37D File Offset: 0x0000B57D
		public ByteBuffer()
		{
			this.buffer = global::Mono.Empty<byte>.Array;
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x0000D390 File Offset: 0x0000B590
		public ByteBuffer(int length)
		{
			this.buffer = new byte[length];
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x0000D3A4 File Offset: 0x0000B5A4
		public ByteBuffer(byte[] buffer)
		{
			this.buffer = (buffer ?? global::Mono.Empty<byte>.Array);
			this.length = this.buffer.Length;
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x0000D3CA File Offset: 0x0000B5CA
		public void Reset(byte[] buffer)
		{
			this.buffer = (buffer ?? global::Mono.Empty<byte>.Array);
			this.length = this.buffer.Length;
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x0000D3EA File Offset: 0x0000B5EA
		public void Advance(int length)
		{
			this.position += length;
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x0000D3FC File Offset: 0x0000B5FC
		public byte ReadByte()
		{
			return this.buffer[this.position++];
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x0000D421 File Offset: 0x0000B621
		public sbyte ReadSByte()
		{
			return (sbyte)this.ReadByte();
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x0000D42C File Offset: 0x0000B62C
		public byte[] ReadBytes(int length)
		{
			byte[] array = new byte[length];
			global::System.Buffer.BlockCopy(this.buffer, this.position, array, 0, length);
			this.position += length;
			return array;
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x0000D464 File Offset: 0x0000B664
		public ushort ReadUInt16()
		{
			ushort result = (ushort)((int)this.buffer[this.position] | (int)this.buffer[this.position + 1] << 8);
			this.position += 2;
			return result;
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x0000D4A1 File Offset: 0x0000B6A1
		public short ReadInt16()
		{
			return (short)this.ReadUInt16();
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x0000D4AC File Offset: 0x0000B6AC
		public uint ReadUInt32()
		{
			uint result = (uint)((int)this.buffer[this.position] | (int)this.buffer[this.position + 1] << 8 | (int)this.buffer[this.position + 2] << 0x10 | (int)this.buffer[this.position + 3] << 0x18);
			this.position += 4;
			return result;
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x0000D50E File Offset: 0x0000B70E
		public int ReadInt32()
		{
			return (int)this.ReadUInt32();
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0000D518 File Offset: 0x0000B718
		public ulong ReadUInt64()
		{
			uint num = this.ReadUInt32();
			uint num2 = this.ReadUInt32();
			return (ulong)num2 << 0x20 | (ulong)num;
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x0000D53B File Offset: 0x0000B73B
		public long ReadInt64()
		{
			return (long)this.ReadUInt64();
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x0000D544 File Offset: 0x0000B744
		public uint ReadCompressedUInt32()
		{
			byte b = this.ReadByte();
			if ((b & 0x80) == 0)
			{
				return (uint)b;
			}
			if ((b & 0x40) == 0)
			{
				return ((uint)b & 0xFFFFFF7FU) << 8 | (uint)this.ReadByte();
			}
			return (uint)(((int)b & -0xC1) << 0x18 | (int)this.ReadByte() << 0x10 | (int)this.ReadByte() << 8 | (int)this.ReadByte());
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x0000D5A0 File Offset: 0x0000B7A0
		public int ReadCompressedInt32()
		{
			int num = (int)this.ReadCompressedUInt32();
			if ((num & 1) == 0)
			{
				return num >> 1;
			}
			return -(num >> 1);
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x0000D5C4 File Offset: 0x0000B7C4
		public float ReadSingle()
		{
			if (!global::System.BitConverter.IsLittleEndian)
			{
				byte[] array = this.ReadBytes(4);
				global::System.Array.Reverse(array);
				return global::System.BitConverter.ToSingle(array, 0);
			}
			float result = global::System.BitConverter.ToSingle(this.buffer, this.position);
			this.position += 4;
			return result;
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x0000D610 File Offset: 0x0000B810
		public double ReadDouble()
		{
			if (!global::System.BitConverter.IsLittleEndian)
			{
				byte[] array = this.ReadBytes(8);
				global::System.Array.Reverse(array);
				return global::System.BitConverter.ToDouble(array, 0);
			}
			double result = global::System.BitConverter.ToDouble(this.buffer, this.position);
			this.position += 8;
			return result;
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x0000D65C File Offset: 0x0000B85C
		public void WriteByte(byte value)
		{
			if (this.position == this.buffer.Length)
			{
				this.Grow(1);
			}
			this.buffer[this.position++] = value;
			if (this.position > this.length)
			{
				this.length = this.position;
			}
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0000D6B3 File Offset: 0x0000B8B3
		public void WriteSByte(sbyte value)
		{
			this.WriteByte((byte)value);
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0000D6C0 File Offset: 0x0000B8C0
		public void WriteUInt16(ushort value)
		{
			if (this.position + 2 > this.buffer.Length)
			{
				this.Grow(2);
			}
			this.buffer[this.position++] = (byte)value;
			this.buffer[this.position++] = (byte)(value >> 8);
			if (this.position > this.length)
			{
				this.length = this.position;
			}
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0000D736 File Offset: 0x0000B936
		public void WriteInt16(short value)
		{
			this.WriteUInt16((ushort)value);
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0000D740 File Offset: 0x0000B940
		public void WriteUInt32(uint value)
		{
			if (this.position + 4 > this.buffer.Length)
			{
				this.Grow(4);
			}
			this.buffer[this.position++] = (byte)value;
			this.buffer[this.position++] = (byte)(value >> 8);
			this.buffer[this.position++] = (byte)(value >> 0x10);
			this.buffer[this.position++] = (byte)(value >> 0x18);
			if (this.position > this.length)
			{
				this.length = this.position;
			}
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x0000D7F0 File Offset: 0x0000B9F0
		public void WriteInt32(int value)
		{
			this.WriteUInt32((uint)value);
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x0000D7FC File Offset: 0x0000B9FC
		public void WriteUInt64(ulong value)
		{
			if (this.position + 8 > this.buffer.Length)
			{
				this.Grow(8);
			}
			this.buffer[this.position++] = (byte)value;
			this.buffer[this.position++] = (byte)(value >> 8);
			this.buffer[this.position++] = (byte)(value >> 0x10);
			this.buffer[this.position++] = (byte)(value >> 0x18);
			this.buffer[this.position++] = (byte)(value >> 0x20);
			this.buffer[this.position++] = (byte)(value >> 0x28);
			this.buffer[this.position++] = (byte)(value >> 0x30);
			this.buffer[this.position++] = (byte)(value >> 0x38);
			if (this.position > this.length)
			{
				this.length = this.position;
			}
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x0000D928 File Offset: 0x0000BB28
		public void WriteInt64(long value)
		{
			this.WriteUInt64((ulong)value);
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x0000D934 File Offset: 0x0000BB34
		public void WriteCompressedUInt32(uint value)
		{
			if (value < 0x80U)
			{
				this.WriteByte((byte)value);
				return;
			}
			if (value < 0x4000U)
			{
				this.WriteByte((byte)(0x80U | value >> 8));
				this.WriteByte((byte)(value & 0xFFU));
				return;
			}
			this.WriteByte((byte)(value >> 0x18 | 0xC0U));
			this.WriteByte((byte)(value >> 0x10 & 0xFFU));
			this.WriteByte((byte)(value >> 8 & 0xFFU));
			this.WriteByte((byte)(value & 0xFFU));
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x0000D9B9 File Offset: 0x0000BBB9
		public void WriteCompressedInt32(int value)
		{
			this.WriteCompressedUInt32((uint)((value < 0) ? (-value << 1 | 1) : ((uint)value << 1)));
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x0000D9D0 File Offset: 0x0000BBD0
		public void WriteBytes(byte[] bytes)
		{
			int num = bytes.Length;
			if (this.position + num > this.buffer.Length)
			{
				this.Grow(num);
			}
			global::System.Buffer.BlockCopy(bytes, 0, this.buffer, this.position, num);
			this.position += num;
			if (this.position > this.length)
			{
				this.length = this.position;
			}
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x0000DA38 File Offset: 0x0000BC38
		public void WriteBytes(int length)
		{
			if (this.position + length > this.buffer.Length)
			{
				this.Grow(length);
			}
			this.position += length;
			if (this.position > this.length)
			{
				this.length = this.position;
			}
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x0000DA88 File Offset: 0x0000BC88
		public void WriteBytes(global::Mono.Cecil.PE.ByteBuffer buffer)
		{
			if (this.position + buffer.length > this.buffer.Length)
			{
				this.Grow(buffer.length);
			}
			global::System.Buffer.BlockCopy(buffer.buffer, 0, this.buffer, this.position, buffer.length);
			this.position += buffer.length;
			if (this.position > this.length)
			{
				this.length = this.position;
			}
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x0000DB04 File Offset: 0x0000BD04
		public void WriteSingle(float value)
		{
			byte[] bytes = global::System.BitConverter.GetBytes(value);
			if (!global::System.BitConverter.IsLittleEndian)
			{
				global::System.Array.Reverse(bytes);
			}
			this.WriteBytes(bytes);
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0000DB2C File Offset: 0x0000BD2C
		public void WriteDouble(double value)
		{
			byte[] bytes = global::System.BitConverter.GetBytes(value);
			if (!global::System.BitConverter.IsLittleEndian)
			{
				global::System.Array.Reverse(bytes);
			}
			this.WriteBytes(bytes);
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x0000DB54 File Offset: 0x0000BD54
		private void Grow(int desired)
		{
			byte[] array = this.buffer;
			int num = array.Length;
			byte[] dst = new byte[global::System.Math.Max(num + desired, num * 2)];
			global::System.Buffer.BlockCopy(array, 0, dst, 0, num);
			this.buffer = dst;
		}

		// Token: 0x04000371 RID: 881
		internal byte[] buffer;

		// Token: 0x04000372 RID: 882
		internal int length;

		// Token: 0x04000373 RID: 883
		internal int position;
	}
}
