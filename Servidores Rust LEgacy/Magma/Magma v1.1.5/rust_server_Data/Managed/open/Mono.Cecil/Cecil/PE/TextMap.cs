using System;

namespace Mono.Cecil.PE
{
	// Token: 0x020000B2 RID: 178
	internal sealed class TextMap
	{
		// Token: 0x0600073C RID: 1852 RVA: 0x000134AC File Offset: 0x000116AC
		public void AddMap(global::Mono.Cecil.PE.TextSegment segment, int length)
		{
			this.map[(int)segment] = new global::Mono.Cecil.Range(this.GetStart(segment), (uint)length);
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x000134CC File Offset: 0x000116CC
		public void AddMap(global::Mono.Cecil.PE.TextSegment segment, int length, int align)
		{
			align--;
			this.AddMap(segment, length + align & ~align);
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x000134E0 File Offset: 0x000116E0
		public void AddMap(global::Mono.Cecil.PE.TextSegment segment, global::Mono.Cecil.Range range)
		{
			this.map[(int)segment] = range;
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x000134F4 File Offset: 0x000116F4
		public global::Mono.Cecil.Range GetRange(global::Mono.Cecil.PE.TextSegment segment)
		{
			return this.map[(int)segment];
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00013508 File Offset: 0x00011708
		public global::Mono.Cecil.PE.DataDirectory GetDataDirectory(global::Mono.Cecil.PE.TextSegment segment)
		{
			global::Mono.Cecil.Range range = this.map[(int)segment];
			return new global::Mono.Cecil.PE.DataDirectory((range.Length == 0U) ? 0U : range.Start, range.Length);
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00013546 File Offset: 0x00011746
		public uint GetRVA(global::Mono.Cecil.PE.TextSegment segment)
		{
			return this.map[(int)segment].Start;
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x0001355C File Offset: 0x0001175C
		public uint GetNextRVA(global::Mono.Cecil.PE.TextSegment segment)
		{
			return this.map[(int)segment].Start + this.map[(int)segment].Length;
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x0001358E File Offset: 0x0001178E
		public int GetLength(global::Mono.Cecil.PE.TextSegment segment)
		{
			return (int)this.map[(int)segment].Length;
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x000135A4 File Offset: 0x000117A4
		private uint GetStart(global::Mono.Cecil.PE.TextSegment segment)
		{
			if (segment != global::Mono.Cecil.PE.TextSegment.ImportAddressTable)
			{
				return this.ComputeStart((int)segment);
			}
			return 0x2000U;
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x000135C3 File Offset: 0x000117C3
		private uint ComputeStart(int index)
		{
			index--;
			return this.map[index].Start + this.map[index].Length;
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x000135F0 File Offset: 0x000117F0
		public uint GetLength()
		{
			global::Mono.Cecil.Range range = this.map[0xF];
			return range.Start - 0x2000U + range.Length;
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x00013625 File Offset: 0x00011825
		public TextMap()
		{
		}

		// Token: 0x0400058C RID: 1420
		private readonly global::Mono.Cecil.Range[] map = new global::Mono.Cecil.Range[0x10];
	}
}
