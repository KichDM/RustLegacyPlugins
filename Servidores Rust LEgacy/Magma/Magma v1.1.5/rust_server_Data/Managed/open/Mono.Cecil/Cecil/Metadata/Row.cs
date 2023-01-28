using System;

namespace Mono.Cecil.Metadata
{
	// Token: 0x02000055 RID: 85
	internal struct Row<T1, T2>
	{
		// Token: 0x060003C9 RID: 969 RVA: 0x0000A21C File Offset: 0x0000841C
		public Row(T1 col1, T2 col2)
		{
			this.Col1 = col1;
			this.Col2 = col2;
		}

		// Token: 0x0400027C RID: 636
		internal T1 Col1;

		// Token: 0x0400027D RID: 637
		internal T2 Col2;
	}
}
