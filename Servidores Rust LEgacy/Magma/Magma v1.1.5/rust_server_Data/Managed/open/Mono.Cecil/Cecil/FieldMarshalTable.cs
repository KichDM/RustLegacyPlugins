using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000D6 RID: 214
	internal sealed class FieldMarshalTable : global::Mono.Cecil.SortedTable<global::Mono.Cecil.Metadata.Row<uint, uint>>
	{
		// Token: 0x0600083A RID: 2106 RVA: 0x0001659C File Offset: 0x0001479C
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteCodedRID(this.rows[i].Col1, global::Mono.Cecil.Metadata.CodedIndex.HasFieldMarshal);
				buffer.WriteBlob(this.rows[i].Col2);
			}
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x000165E9 File Offset: 0x000147E9
		public override int Compare(global::Mono.Cecil.Metadata.Row<uint, uint> x, global::Mono.Cecil.Metadata.Row<uint, uint> y)
		{
			return base.Compare(x.Col1, y.Col1);
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x000165FF File Offset: 0x000147FF
		public FieldMarshalTable()
		{
		}
	}
}
