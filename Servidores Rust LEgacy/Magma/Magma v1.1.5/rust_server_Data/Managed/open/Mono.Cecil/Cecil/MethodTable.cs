using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000D0 RID: 208
	internal sealed class MethodTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<uint, global::Mono.Cecil.MethodImplAttributes, global::Mono.Cecil.MethodAttributes, uint, uint, uint>>
	{
		// Token: 0x0600082C RID: 2092 RVA: 0x000162AC File Offset: 0x000144AC
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteUInt32(this.rows[i].Col1);
				buffer.WriteUInt16((ushort)this.rows[i].Col2);
				buffer.WriteUInt16((ushort)this.rows[i].Col3);
				buffer.WriteString(this.rows[i].Col4);
				buffer.WriteBlob(this.rows[i].Col5);
				buffer.WriteRID(this.rows[i].Col6, global::Mono.Cecil.Metadata.Table.Param);
			}
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x0001635B File Offset: 0x0001455B
		public MethodTable()
		{
		}
	}
}
