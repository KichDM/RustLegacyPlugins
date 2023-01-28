using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000DE RID: 222
	internal sealed class PropertyTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.PropertyAttributes, uint, uint>>
	{
		// Token: 0x0600084E RID: 2126 RVA: 0x000168CC File Offset: 0x00014ACC
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteUInt16((ushort)this.rows[i].Col1);
				buffer.WriteString(this.rows[i].Col2);
				buffer.WriteBlob(this.rows[i].Col3);
			}
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x0001692F File Offset: 0x00014B2F
		public PropertyTable()
		{
		}
	}
}
