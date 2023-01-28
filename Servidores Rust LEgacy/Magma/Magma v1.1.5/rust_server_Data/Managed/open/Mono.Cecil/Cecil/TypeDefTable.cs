using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000CE RID: 206
	internal sealed class TypeDefTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.TypeAttributes, uint, uint, uint, uint, uint>>
	{
		// Token: 0x06000828 RID: 2088 RVA: 0x00016184 File Offset: 0x00014384
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteUInt32((uint)this.rows[i].Col1);
				buffer.WriteString(this.rows[i].Col2);
				buffer.WriteString(this.rows[i].Col3);
				buffer.WriteCodedRID(this.rows[i].Col4, global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef);
				buffer.WriteRID(this.rows[i].Col5, global::Mono.Cecil.Metadata.Table.Field);
				buffer.WriteRID(this.rows[i].Col6, global::Mono.Cecil.Metadata.Table.Method);
			}
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x00016235 File Offset: 0x00014435
		public TypeDefTable()
		{
		}
	}
}
