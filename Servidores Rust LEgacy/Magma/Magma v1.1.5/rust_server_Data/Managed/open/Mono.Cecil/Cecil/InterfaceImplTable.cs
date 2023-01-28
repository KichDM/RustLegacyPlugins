using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000D2 RID: 210
	internal sealed class InterfaceImplTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<uint, uint>>
	{
		// Token: 0x06000830 RID: 2096 RVA: 0x000163D0 File Offset: 0x000145D0
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteRID(this.rows[i].Col1, global::Mono.Cecil.Metadata.Table.TypeDef);
				buffer.WriteCodedRID(this.rows[i].Col2, global::Mono.Cecil.Metadata.CodedIndex.TypeDefOrRef);
			}
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x0001641E File Offset: 0x0001461E
		public InterfaceImplTable()
		{
		}
	}
}
