using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000D4 RID: 212
	internal sealed class ConstantTable : global::Mono.Cecil.SortedTable<global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, uint, uint>>
	{
		// Token: 0x06000834 RID: 2100 RVA: 0x00016494 File Offset: 0x00014694
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteUInt16((ushort)this.rows[i].Col1);
				buffer.WriteCodedRID(this.rows[i].Col2, global::Mono.Cecil.Metadata.CodedIndex.HasConstant);
				buffer.WriteBlob(this.rows[i].Col3);
			}
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x000164F8 File Offset: 0x000146F8
		public override int Compare(global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, uint, uint> x, global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.Metadata.ElementType, uint, uint> y)
		{
			return base.Compare(x.Col2, y.Col2);
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x0001650E File Offset: 0x0001470E
		public ConstantTable()
		{
		}
	}
}
