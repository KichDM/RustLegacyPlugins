using System;
using Mono.Cecil.PE;

namespace Mono.Cecil.Metadata
{
	// Token: 0x020000AB RID: 171
	internal sealed class TableHeap : global::Mono.Cecil.Metadata.Heap
	{
		// Token: 0x17000274 RID: 628
		public global::Mono.Cecil.Metadata.TableInformation this[global::Mono.Cecil.Metadata.Table table]
		{
			get
			{
				return this.Tables[(int)table];
			}
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x00012A9B File Offset: 0x00010C9B
		public TableHeap(global::Mono.Cecil.PE.Section section, uint start, uint size) : base(section, start, size)
		{
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x00012AB3 File Offset: 0x00010CB3
		public bool HasTable(global::Mono.Cecil.Metadata.Table table)
		{
			return (this.Valid & 1L << (int)table) != 0L;
		}

		// Token: 0x0400056B RID: 1387
		public const int TableCount = 0x2D;

		// Token: 0x0400056C RID: 1388
		public long Valid;

		// Token: 0x0400056D RID: 1389
		public long Sorted;

		// Token: 0x0400056E RID: 1390
		public readonly global::Mono.Cecil.Metadata.TableInformation[] Tables = new global::Mono.Cecil.Metadata.TableInformation[0x2D];
	}
}
