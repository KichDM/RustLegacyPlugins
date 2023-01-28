using System;

namespace Mono.Cecil.Metadata
{
	// Token: 0x02000059 RID: 89
	internal struct Row<T1, T2, T3, T4, T5, T6>
	{
		// Token: 0x060003CD RID: 973 RVA: 0x0000A289 File Offset: 0x00008489
		public Row(T1 col1, T2 col2, T3 col3, T4 col4, T5 col5, T6 col6)
		{
			this.Col1 = col1;
			this.Col2 = col2;
			this.Col3 = col3;
			this.Col4 = col4;
			this.Col5 = col5;
			this.Col6 = col6;
		}

		// Token: 0x0400028A RID: 650
		internal T1 Col1;

		// Token: 0x0400028B RID: 651
		internal T2 Col2;

		// Token: 0x0400028C RID: 652
		internal T3 Col3;

		// Token: 0x0400028D RID: 653
		internal T4 Col4;

		// Token: 0x0400028E RID: 654
		internal T5 Col5;

		// Token: 0x0400028F RID: 655
		internal T6 Col6;
	}
}
