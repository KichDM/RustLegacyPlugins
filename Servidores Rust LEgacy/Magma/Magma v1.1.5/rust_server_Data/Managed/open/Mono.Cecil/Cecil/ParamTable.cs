using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000D1 RID: 209
	internal sealed class ParamTable : global::Mono.Cecil.MetadataTable<global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.ParameterAttributes, ushort, uint>>
	{
		// Token: 0x0600082E RID: 2094 RVA: 0x00016364 File Offset: 0x00014564
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteUInt16((ushort)this.rows[i].Col1);
				buffer.WriteUInt16(this.rows[i].Col2);
				buffer.WriteString(this.rows[i].Col3);
			}
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x000163C7 File Offset: 0x000145C7
		public ParamTable()
		{
		}
	}
}
