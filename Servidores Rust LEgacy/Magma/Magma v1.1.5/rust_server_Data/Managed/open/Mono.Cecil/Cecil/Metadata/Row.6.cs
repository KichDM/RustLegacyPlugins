using System;

namespace Mono.Cecil.Metadata
{
	// Token: 0x0200005A RID: 90
	internal struct Row<T1, T2, T3, T4, T5, T6, T7, T8, T9>
	{
		// Token: 0x060003CE RID: 974 RVA: 0x0000A2B8 File Offset: 0x000084B8
		public Row(T1 col1, T2 col2, T3 col3, T4 col4, T5 col5, T6 col6, T7 col7, T8 col8, T9 col9)
		{
			this.Col1 = col1;
			this.Col2 = col2;
			this.Col3 = col3;
			this.Col4 = col4;
			this.Col5 = col5;
			this.Col6 = col6;
			this.Col7 = col7;
			this.Col8 = col8;
			this.Col9 = col9;
		}

		// Token: 0x04000290 RID: 656
		internal T1 Col1;

		// Token: 0x04000291 RID: 657
		internal T2 Col2;

		// Token: 0x04000292 RID: 658
		internal T3 Col3;

		// Token: 0x04000293 RID: 659
		internal T4 Col4;

		// Token: 0x04000294 RID: 660
		internal T5 Col5;

		// Token: 0x04000295 RID: 661
		internal T6 Col6;

		// Token: 0x04000296 RID: 662
		internal T7 Col7;

		// Token: 0x04000297 RID: 663
		internal T8 Col8;

		// Token: 0x04000298 RID: 664
		internal T9 Col9;
	}
}
