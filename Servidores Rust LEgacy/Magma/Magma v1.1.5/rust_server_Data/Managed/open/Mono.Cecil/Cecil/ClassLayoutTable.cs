using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000D8 RID: 216
	internal sealed class ClassLayoutTable : global::Mono.Cecil.SortedTable<global::Mono.Cecil.Metadata.Row<ushort, uint, uint>>
	{
		// Token: 0x06000840 RID: 2112 RVA: 0x0001668C File Offset: 0x0001488C
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteUInt16(this.rows[i].Col1);
				buffer.WriteUInt32(this.rows[i].Col2);
				buffer.WriteRID(this.rows[i].Col3, global::Mono.Cecil.Metadata.Table.TypeDef);
			}
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x000166F0 File Offset: 0x000148F0
		public override int Compare(global::Mono.Cecil.Metadata.Row<ushort, uint, uint> x, global::Mono.Cecil.Metadata.Row<ushort, uint, uint> y)
		{
			return base.Compare(x.Col3, y.Col3);
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x00016706 File Offset: 0x00014906
		public ClassLayoutTable()
		{
		}
	}
}
