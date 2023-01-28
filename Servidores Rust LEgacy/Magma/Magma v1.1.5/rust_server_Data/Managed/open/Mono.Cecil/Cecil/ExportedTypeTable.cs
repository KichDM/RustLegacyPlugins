using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000E8 RID: 232
	internal sealed class ExportedTypeTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.TypeAttributes, uint, uint, uint, uint>>
	{
		// Token: 0x06000865 RID: 2149 RVA: 0x00016DC0 File Offset: 0x00014FC0
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteUInt32((uint)this.rows[i].Col1);
				buffer.WriteUInt32(this.rows[i].Col2);
				buffer.WriteString(this.rows[i].Col3);
				buffer.WriteString(this.rows[i].Col4);
				buffer.WriteCodedRID(this.rows[i].Col5, global::Mono.Cecil.Metadata.CodedIndex.Implementation);
			}
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x00016E56 File Offset: 0x00015056
		public ExportedTypeTable()
		{
		}
	}
}
