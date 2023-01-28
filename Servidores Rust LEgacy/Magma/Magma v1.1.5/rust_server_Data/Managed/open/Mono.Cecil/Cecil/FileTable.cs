using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000E7 RID: 231
	internal sealed class FileTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.FileAttributes, uint, uint>>
	{
		// Token: 0x06000863 RID: 2147 RVA: 0x00016D54 File Offset: 0x00014F54
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteUInt32((uint)this.rows[i].Col1);
				buffer.WriteString(this.rows[i].Col2);
				buffer.WriteBlob(this.rows[i].Col3);
			}
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x00016DB7 File Offset: 0x00014FB7
		public FileTable()
		{
		}
	}
}
