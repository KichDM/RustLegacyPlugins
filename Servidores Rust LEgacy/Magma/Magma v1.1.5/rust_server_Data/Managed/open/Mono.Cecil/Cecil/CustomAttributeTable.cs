using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000D5 RID: 213
	internal sealed class CustomAttributeTable : global::Mono.Cecil.SortedTable<global::Mono.Cecil.Metadata.Row<uint, uint, uint>>
	{
		// Token: 0x06000837 RID: 2103 RVA: 0x00016518 File Offset: 0x00014718
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteCodedRID(this.rows[i].Col1, global::Mono.Cecil.Metadata.CodedIndex.HasCustomAttribute);
				buffer.WriteCodedRID(this.rows[i].Col2, global::Mono.Cecil.Metadata.CodedIndex.CustomAttributeType);
				buffer.WriteBlob(this.rows[i].Col3);
			}
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x0001657E File Offset: 0x0001477E
		public override int Compare(global::Mono.Cecil.Metadata.Row<uint, uint, uint> x, global::Mono.Cecil.Metadata.Row<uint, uint, uint> y)
		{
			return base.Compare(x.Col1, y.Col1);
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x00016594 File Offset: 0x00014794
		public CustomAttributeTable()
		{
		}
	}
}
