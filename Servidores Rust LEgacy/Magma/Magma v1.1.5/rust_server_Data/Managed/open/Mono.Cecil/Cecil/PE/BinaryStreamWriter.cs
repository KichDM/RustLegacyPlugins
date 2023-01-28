using System;
using System.IO;

namespace Mono.Cecil.PE
{
	// Token: 0x020000A5 RID: 165
	internal class BinaryStreamWriter : global::System.IO.BinaryWriter
	{
		// Token: 0x060006B4 RID: 1716 RVA: 0x00010ADC File Offset: 0x0000ECDC
		public BinaryStreamWriter(global::System.IO.Stream stream) : base(stream)
		{
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x00010AE5 File Offset: 0x0000ECE5
		public void WriteByte(byte value)
		{
			this.Write(value);
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x00010AEE File Offset: 0x0000ECEE
		public void WriteUInt16(ushort value)
		{
			this.Write(value);
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x00010AF7 File Offset: 0x0000ECF7
		public void WriteInt16(short value)
		{
			this.Write(value);
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x00010B00 File Offset: 0x0000ED00
		public void WriteUInt32(uint value)
		{
			this.Write(value);
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00010B09 File Offset: 0x0000ED09
		public void WriteInt32(int value)
		{
			this.Write(value);
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x00010B12 File Offset: 0x0000ED12
		public void WriteUInt64(ulong value)
		{
			this.Write(value);
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x00010B1B File Offset: 0x0000ED1B
		public void WriteBytes(byte[] bytes)
		{
			this.Write(bytes);
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x00010B24 File Offset: 0x0000ED24
		public void WriteDataDirectory(global::Mono.Cecil.PE.DataDirectory directory)
		{
			this.Write(directory.VirtualAddress);
			this.Write(directory.Size);
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x00010B40 File Offset: 0x0000ED40
		public void WriteBuffer(global::Mono.Cecil.PE.ByteBuffer buffer)
		{
			this.Write(buffer.buffer, 0, buffer.length);
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x00010B55 File Offset: 0x0000ED55
		protected void Advance(int bytes)
		{
			this.BaseStream.Seek((long)bytes, global::System.IO.SeekOrigin.Current);
		}
	}
}
