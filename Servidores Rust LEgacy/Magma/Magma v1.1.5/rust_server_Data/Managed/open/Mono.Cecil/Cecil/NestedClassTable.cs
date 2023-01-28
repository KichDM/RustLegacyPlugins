using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000EA RID: 234
	internal sealed class NestedClassTable : global::Mono.Cecil.SortedTable<global::Mono.Cecil.Metadata.Row<uint, uint>>
	{
		// Token: 0x06000869 RID: 2153 RVA: 0x00016EE4 File Offset: 0x000150E4
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteRID(this.rows[i].Col1, global::Mono.Cecil.Metadata.Table.TypeDef);
				buffer.WriteRID(this.rows[i].Col2, global::Mono.Cecil.Metadata.Table.TypeDef);
			}
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x00016F32 File Offset: 0x00015132
		public override int Compare(global::Mono.Cecil.Metadata.Row<uint, uint> x, global::Mono.Cecil.Metadata.Row<uint, uint> y)
		{
			return base.Compare(x.Col1, y.Col1);
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x00016F48 File Offset: 0x00015148
		public NestedClassTable()
		{
		}
	}
}
