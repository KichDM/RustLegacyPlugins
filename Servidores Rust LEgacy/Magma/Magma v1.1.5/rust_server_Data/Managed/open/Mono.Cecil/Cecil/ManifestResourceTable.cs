using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000E9 RID: 233
	internal sealed class ManifestResourceTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<uint, global::Mono.Cecil.ManifestResourceAttributes, uint, uint>>
	{
		// Token: 0x06000867 RID: 2151 RVA: 0x00016E60 File Offset: 0x00015060
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteUInt32(this.rows[i].Col1);
				buffer.WriteUInt32((uint)this.rows[i].Col2);
				buffer.WriteString(this.rows[i].Col3);
				buffer.WriteCodedRID(this.rows[i].Col4, global::Mono.Cecil.Metadata.CodedIndex.Implementation);
			}
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x00016EDC File Offset: 0x000150DC
		public ManifestResourceTable()
		{
		}
	}
}
