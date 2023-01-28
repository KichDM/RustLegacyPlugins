using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000E6 RID: 230
	internal sealed class AssemblyRefTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<ushort, ushort, ushort, ushort, global::Mono.Cecil.AssemblyAttributes, uint, uint, uint, uint>>
	{
		// Token: 0x06000861 RID: 2145 RVA: 0x00016C58 File Offset: 0x00014E58
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteUInt16(this.rows[i].Col1);
				buffer.WriteUInt16(this.rows[i].Col2);
				buffer.WriteUInt16(this.rows[i].Col3);
				buffer.WriteUInt16(this.rows[i].Col4);
				buffer.WriteUInt32((uint)this.rows[i].Col5);
				buffer.WriteBlob(this.rows[i].Col6);
				buffer.WriteString(this.rows[i].Col7);
				buffer.WriteString(this.rows[i].Col8);
				buffer.WriteBlob(this.rows[i].Col9);
			}
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x00016D4B File Offset: 0x00014F4B
		public AssemblyRefTable()
		{
		}
	}
}
