using System;

namespace Mono.Cecil.Metadata
{
	// Token: 0x02000056 RID: 86
	internal struct Row<T1, T2, T3>
	{
		// Token: 0x060003CA RID: 970 RVA: 0x0000A22C File Offset: 0x0000842C
		public Row(T1 col1, T2 col2, T3 col3)
		{
			this.Col1 = col1;
			this.Col2 = col2;
			this.Col3 = col3;
		}

		// Token: 0x0400027E RID: 638
		internal T1 Col1;

		// Token: 0x0400027F RID: 639
		internal T2 Col2;

		// Token: 0x04000280 RID: 640
		internal T3 Col3;
	}
}
