using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000E2 RID: 226
	internal sealed class TypeSpecTable : global::Mono.Cecil.MetadataTable<uint>
	{
		// Token: 0x06000857 RID: 2135 RVA: 0x00016A60 File Offset: 0x00014C60
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteBlob(this.rows[i]);
			}
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x00016A8C File Offset: 0x00014C8C
		public TypeSpecTable()
		{
		}
	}
}
