using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000E5 RID: 229
	internal sealed class AssemblyTable : global::Mono.Cecil.OneRowTable<global::Mono.Cecil.Metadata.Row<global::Mono.Cecil.AssemblyHashAlgorithm, ushort, ushort, ushort, ushort, global::Mono.Cecil.AssemblyAttributes, uint, uint, uint>>
	{
		// Token: 0x0600085F RID: 2143 RVA: 0x00016BA8 File Offset: 0x00014DA8
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			buffer.WriteUInt32((uint)this.row.Col1);
			buffer.WriteUInt16(this.row.Col2);
			buffer.WriteUInt16(this.row.Col3);
			buffer.WriteUInt16(this.row.Col4);
			buffer.WriteUInt16(this.row.Col5);
			buffer.WriteUInt32((uint)this.row.Col6);
			buffer.WriteBlob(this.row.Col7);
			buffer.WriteString(this.row.Col8);
			buffer.WriteString(this.row.Col9);
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x00016C4E File Offset: 0x00014E4E
		public AssemblyTable()
		{
		}
	}
}
