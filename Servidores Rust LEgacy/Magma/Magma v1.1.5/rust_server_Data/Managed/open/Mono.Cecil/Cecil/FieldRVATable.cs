using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000E4 RID: 228
	internal sealed class FieldRVATable : global::Mono.Cecil.SortedTable<global::Mono.Cecil.Metadata.Row<uint, uint>>
	{
		// Token: 0x0600085C RID: 2140 RVA: 0x00016B30 File Offset: 0x00014D30
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			this.position = buffer.position;
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteUInt32(this.rows[i].Col1);
				buffer.WriteRID(this.rows[i].Col2, global::Mono.Cecil.Metadata.Table.Field);
			}
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x00016B89 File Offset: 0x00014D89
		public override int Compare(global::Mono.Cecil.Metadata.Row<uint, uint> x, global::Mono.Cecil.Metadata.Row<uint, uint> y)
		{
			return base.Compare(x.Col2, y.Col2);
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x00016B9F File Offset: 0x00014D9F
		public FieldRVATable()
		{
		}

		// Token: 0x040005DE RID: 1502
		internal int position;
	}
}
