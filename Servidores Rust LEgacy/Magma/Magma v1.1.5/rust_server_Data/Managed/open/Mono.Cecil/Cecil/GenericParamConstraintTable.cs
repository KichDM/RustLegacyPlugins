using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000ED RID: 237
	internal sealed class GenericParamConstraintTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<uint, uint>>
	{
		// Token: 0x06000870 RID: 2160 RVA: 0x0001702C File Offset: 0x0001522C
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteRID(this.rows[i].Col1, global::Mono.Cecil.Metadata.Table.GenericParam);
				buffer.WriteCodedRID(this.rows[i].Col2, global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef);
			}
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x0001707B File Offset: 0x0001527B
		public GenericParamConstraintTable()
		{
		}
	}
}
