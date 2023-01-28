using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000D9 RID: 217
	internal sealed class FieldLayoutTable : global::Mono.Cecil.SortedTable<global::Mono.Cecil.Metadata.Row<uint, uint>>
	{
		// Token: 0x06000843 RID: 2115 RVA: 0x00016710 File Offset: 0x00014910
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteUInt32(this.rows[i].Col1);
				buffer.WriteRID(this.rows[i].Col2, global::Mono.Cecil.Metadata.Table.Field);
			}
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x0001675D File Offset: 0x0001495D
		public override int Compare(global::Mono.Cecil.Metadata.Row<uint, uint> x, global::Mono.Cecil.Metadata.Row<uint, uint> y)
		{
			return base.Compare(x.Col2, y.Col2);
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x00016773 File Offset: 0x00014973
		public FieldLayoutTable()
		{
		}
	}
}
