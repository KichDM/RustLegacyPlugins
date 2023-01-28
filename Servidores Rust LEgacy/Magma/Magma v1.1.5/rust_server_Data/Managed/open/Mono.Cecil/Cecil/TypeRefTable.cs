using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000CD RID: 205
	internal sealed class TypeRefTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<uint, uint, uint>>
	{
		// Token: 0x06000826 RID: 2086 RVA: 0x00016114 File Offset: 0x00014314
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteCodedRID(this.rows[i].Col1, global::Mono.Cecil.Metadata.CodedIndex.ResolutionScope);
				buffer.WriteString(this.rows[i].Col2);
				buffer.WriteString(this.rows[i].Col3);
			}
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x00016179 File Offset: 0x00014379
		public TypeRefTable()
		{
		}
	}
}
