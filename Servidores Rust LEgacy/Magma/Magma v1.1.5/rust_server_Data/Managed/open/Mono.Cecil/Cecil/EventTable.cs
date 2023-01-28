using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000DC RID: 220
	internal sealed class EventTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.EventAttributes, uint, uint>>
	{
		// Token: 0x0600084A RID: 2122 RVA: 0x00016808 File Offset: 0x00014A08
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteUInt16((ushort)this.rows[i].Col1);
				buffer.WriteString(this.rows[i].Col2);
				buffer.WriteCodedRID(this.rows[i].Col3, global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef);
			}
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x0001686C File Offset: 0x00014A6C
		public EventTable()
		{
		}
	}
}
