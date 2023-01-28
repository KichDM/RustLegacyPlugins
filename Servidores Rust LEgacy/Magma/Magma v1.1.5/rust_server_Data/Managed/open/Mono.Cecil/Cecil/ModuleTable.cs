using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000CC RID: 204
	internal sealed class ModuleTable : global::Mono.Cecil.OneRowTable<uint>
	{
		// Token: 0x06000824 RID: 2084 RVA: 0x000160E2 File Offset: 0x000142E2
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			buffer.WriteUInt16(0);
			buffer.WriteString(this.row);
			buffer.WriteUInt16(1);
			buffer.WriteUInt16(0);
			buffer.WriteUInt16(0);
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0001610C File Offset: 0x0001430C
		public ModuleTable()
		{
		}
	}
}
