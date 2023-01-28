using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000D7 RID: 215
	internal sealed class DeclSecurityTable : global::Mono.Cecil.SortedTable<global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.SecurityAction, uint, uint>>
	{
		// Token: 0x0600083D RID: 2109 RVA: 0x00016608 File Offset: 0x00014808
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteUInt16((ushort)this.rows[i].Col1);
				buffer.WriteCodedRID(this.rows[i].Col2, global::Mono.Cecil.Metadata.CodedIndex.HasDeclSecurity);
				buffer.WriteBlob(this.rows[i].Col3);
			}
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x0001666C File Offset: 0x0001486C
		public override int Compare(global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.SecurityAction, uint, uint> x, global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.SecurityAction, uint, uint> y)
		{
			return base.Compare(x.Col2, y.Col2);
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x00016682 File Offset: 0x00014882
		public DeclSecurityTable()
		{
		}
	}
}
