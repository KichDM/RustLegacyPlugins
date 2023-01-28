using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000DA RID: 218
	internal sealed class StandAloneSigTable : global::Mono.Cecil.MetadataTable<uint>
	{
		// Token: 0x06000846 RID: 2118 RVA: 0x0001677C File Offset: 0x0001497C
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteBlob(this.rows[i]);
			}
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x000167A8 File Offset: 0x000149A8
		public StandAloneSigTable()
		{
		}
	}
}
