using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000DB RID: 219
	internal sealed class EventMapTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<uint, uint>>
	{
		// Token: 0x06000848 RID: 2120 RVA: 0x000167B0 File Offset: 0x000149B0
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteRID(this.rows[i].Col1, global::Mono.Cecil.Metadata.Table.TypeDef);
				buffer.WriteRID(this.rows[i].Col2, global::Mono.Cecil.Metadata.Table.Event);
			}
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x000167FF File Offset: 0x000149FF
		public EventMapTable()
		{
		}
	}
}
