using System;
using Mono.Cecil.Metadata;

namespace Mono.Cecil
{
	// Token: 0x020000E1 RID: 225
	internal sealed class ModuleRefTable : global::Mono.Cecil.MetadataTable<uint>
	{
		// Token: 0x06000855 RID: 2133 RVA: 0x00016A2C File Offset: 0x00014C2C
		public override void Write(global::Mono.Cecil.Metadata.TableHeapBuffer buffer)
		{
			for (int i = 0; i < this.length; i++)
			{
				buffer.WriteString(this.rows[i]);
			}
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x00016A58 File Offset: 0x00014C58
		public ModuleRefTable()
		{
		}
	}
}
