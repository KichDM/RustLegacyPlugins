using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000EC RID: 236
	internal sealed class MethodSpecTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<uint, uint>>
	{
		// Token: 0x0600086E RID: 2158 RVA: 0x00016FD4 File Offset: 0x000151D4
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteCodedRID(this.rows[i].Col1, global::Mono.Cecil.Metadata.CodedIndex.MethodDefOrRef);
				buffer.WriteBlob(this.rows[i].Col2);
			}
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x00017021 File Offset: 0x00015221
		public MethodSpecTable()
		{
		}
	}
}
