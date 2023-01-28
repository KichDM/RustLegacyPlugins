using System;
using System.IO;

namespace Mono.Cecil.PE
{
	// Token: 0x020000A7 RID: 167
	internal class BinaryStreamReader : global::System.IO.BinaryReader
	{
		// Token: 0x060006F0 RID: 1776 RVA: 0x00011F47 File Offset: 0x00010147
		public BinaryStreamReader(global::System.IO.Stream stream) : base(stream)
		{
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x00011F50 File Offset: 0x00010150
		protected void Advance(int bytes)
		{
			this.BaseStream.Seek((long)bytes, global::System.IO.SeekOrigin.Current);
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x00011F61 File Offset: 0x00010161
		protected global::Mono.Cecil.PE.DataDirectory ReadDataDirectory()
		{
			return new global::Mono.Cecil.PE.DataDirectory(this.ReadUInt32(), this.ReadUInt32());
		}
	}
}
