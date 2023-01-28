using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000DF RID: 223
	internal sealed class MethodSemanticsTable : global::Mono.Cecil.SortedTable<global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.MethodSemanticsAttributes, uint, uint>>
	{
		// Token: 0x06000850 RID: 2128 RVA: 0x00016938 File Offset: 0x00014B38
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteUInt16((ushort)this.rows[i].Col1);
				buffer.WriteRID(this.rows[i].Col2, global::Mono.Cecil.Metadata.Table.Method);
				buffer.WriteCodedRID(this.rows[i].Col3, global::Mono.Cecil.Metadata.CodedIndex.HasSemantics);
			}
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x0001699D File Offset: 0x00014B9D
		public override int Compare(global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.MethodSemanticsAttributes, uint, uint> x, global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.MethodSemanticsAttributes, uint, uint> y)
		{
			return base.Compare(x.Col3, y.Col3);
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x000169B3 File Offset: 0x00014BB3
		public MethodSemanticsTable()
		{
		}
	}
}
