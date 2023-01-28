using System;

namespace Mono.Cecil.Metadata
{
	// Token: 0x02000057 RID: 87
	internal struct Row<T1, T2, T3, T4>
	{
		// Token: 0x060003CB RID: 971 RVA: 0x0000A243 File Offset: 0x00008443
		public Row(T1 col1, T2 col2, T3 col3, T4 col4)
		{
			this.Col1 = col1;
			this.Col2 = col2;
			this.Col3 = col3;
			this.Col4 = col4;
		}

		// Token: 0x04000281 RID: 641
		internal T1 Col1;

		// Token: 0x04000282 RID: 642
		internal T2 Col2;

		// Token: 0x04000283 RID: 643
		internal T3 Col3;

		// Token: 0x04000284 RID: 644
		internal T4 Col4;
	}
}
