using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000E3 RID: 227
	internal sealed class ImplMapTable : global::Mono.Cecil.SortedTable<global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.PInvokeAttributes, uint, uint, uint>>
	{
		// Token: 0x06000859 RID: 2137 RVA: 0x00016A94 File Offset: 0x00014C94
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteUInt16((ushort)this.rows[i].Col1);
				buffer.WriteCodedRID(this.rows[i].Col2, global::Mono.Cecil.Metadata.CodedIndex.MemberForwarded);
				buffer.WriteString(this.rows[i].Col3);
				buffer.WriteRID(this.rows[i].Col4, global::Mono.Cecil.Metadata.Table.ModuleRef);
			}
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x00016B11 File Offset: 0x00014D11
		public override int Compare(global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.PInvokeAttributes, uint, uint, uint> x, global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.PInvokeAttributes, uint, uint, uint> y)
		{
			return base.Compare(x.Col2, y.Col2);
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x00016B27 File Offset: 0x00014D27
		public ImplMapTable()
		{
		}
	}
}
