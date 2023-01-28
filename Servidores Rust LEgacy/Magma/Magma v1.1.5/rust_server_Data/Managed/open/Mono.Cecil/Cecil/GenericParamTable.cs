using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000EB RID: 235
	internal sealed class GenericParamTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<ushort, global::Mono.Cecil.GenericParameterAttributes, uint, uint>>
	{
		// Token: 0x0600086C RID: 2156 RVA: 0x00016F50 File Offset: 0x00015150
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteUInt16(this.rows[i].Col1);
				buffer.WriteUInt16((ushort)this.rows[i].Col2);
				buffer.WriteCodedRID(this.rows[i].Col3, global::Mono.Cecil.Metadata.CodedIndex.TypeOrMethodDef);
				buffer.WriteString(this.rows[i].Col4);
			}
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x00016FCC File Offset: 0x000151CC
		public GenericParamTable()
		{
		}
	}
}
