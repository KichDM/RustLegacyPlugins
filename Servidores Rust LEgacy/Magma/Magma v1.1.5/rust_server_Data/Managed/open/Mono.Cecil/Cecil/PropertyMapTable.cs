using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000DD RID: 221
	internal sealed class PropertyMapTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<uint, uint>>
	{
		// Token: 0x0600084C RID: 2124 RVA: 0x00016874 File Offset: 0x00014A74
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteRID(this.rows[i].Col1, global::Mono.Cecil.Metadata.Table.TypeDef);
				buffer.WriteRID(this.rows[i].Col2, global::Mono.Cecil.Metadata.Table.Property);
			}
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x000168C3 File Offset: 0x00014AC3
		public PropertyMapTable()
		{
		}
	}
}
