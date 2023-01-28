using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000E0 RID: 224
	internal sealed class MethodImplTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<uint, uint, uint>>
	{
		// Token: 0x06000853 RID: 2131 RVA: 0x000169BC File Offset: 0x00014BBC
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteRID(this.rows[i].Col1, global::Mono.Cecil.Metadata.Table.TypeDef);
				buffer.WriteCodedRID(this.rows[i].Col2, global::Mono.Cecil.Metadata.CodedIndex.MethodDefOrRef);
				buffer.WriteCodedRID(this.rows[i].Col3, global::Mono.Cecil.Metadata.CodedIndex.MethodDefOrRef);
			}
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x00016A22 File Offset: 0x00014C22
		public MethodImplTable()
		{
		}
	}
}
