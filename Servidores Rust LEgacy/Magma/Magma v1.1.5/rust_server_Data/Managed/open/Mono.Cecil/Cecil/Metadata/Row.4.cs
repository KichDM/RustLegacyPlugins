using System;

namespace Mono.Cecil.Metadata
{
	// Token: 0x02000058 RID: 88
	internal struct Row<T1, T2, T3, T4, T5>
	{
		// Token: 0x060003CC RID: 972 RVA: 0x0000A262 File Offset: 0x00008462
		public Row(T1 col1, T2 col2, T3 col3, T4 col4, T5 col5)
		{
			this.Col1 = col1;
			this.Col2 = col2;
			this.Col3 = col3;
			this.Col4 = col4;
			this.Col5 = col5;
		}

		// Token: 0x04000285 RID: 645
		internal T1 Col1;

		// Token: 0x04000286 RID: 646
		internal T2 Col2;

		// Token: 0x04000287 RID: 647
		internal T3 Col3;

		// Token: 0x04000288 RID: 648
		internal T4 Col4;

		// Token: 0x04000289 RID: 649
		internal T5 Col5;
	}
}
