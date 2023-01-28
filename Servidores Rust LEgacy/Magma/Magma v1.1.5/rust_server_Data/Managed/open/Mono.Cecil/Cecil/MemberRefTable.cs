using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000D3 RID: 211
	internal sealed class MemberRefTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<uint, uint, uint>>
	{
		// Token: 0x06000832 RID: 2098 RVA: 0x00016428 File Offset: 0x00014628
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteCodedRID(this.rows[i].Col1, global::Mono.Cecil.Metadata.CodedIndex.MemberRefParent);
				buffer.WriteString(this.rows[i].Col2);
				buffer.WriteBlob(this.rows[i].Col3);
			}
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x0001648C File Offset: 0x0001468C
		public MemberRefTable()
		{
		}
	}
}
