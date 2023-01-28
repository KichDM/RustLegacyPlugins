using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000CF RID: 207
	internal sealed class FieldTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.FieldAttributes, uint, uint>>
	{
		// Token: 0x0600082A RID: 2090 RVA: 0x00016240 File Offset: 0x00014440
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteUInt16((ushort)this.rows[i].Col1);
				buffer.WriteString(this.rows[i].Col2);
				buffer.WriteBlob(this.rows[i].Col3);
			}
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x000162A3 File Offset: 0x000144A3
		public FieldTable()
		{
		}
	}
}
