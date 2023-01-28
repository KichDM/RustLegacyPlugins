using System;
using System.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x020000CB RID: 203
	internal abstract class SortedTable<TRow> : global::Mono.Cecil.MetadataTable<TRow>, global::System.Collections.Generic.IComparer<TRow> where TRow : struct
	{
		// Token: 0x06000820 RID: 2080 RVA: 0x000160B6 File Offset: 0x000142B6
		public sealed override void Sort()
		{
			global::System.Array.Sort<TRow>(this.rows, 0, this.length, this);
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x000160CB File Offset: 0x000142CB
		protected int Compare(uint x, uint y)
		{
			if (x == y)
			{
				return 0;
			}
			if (x <= y)
			{
				return -1;
			}
			return 1;
		}

		// Token: 0x06000822 RID: 2082
		public abstract int Compare(TRow x, TRow y);

		// Token: 0x06000823 RID: 2083 RVA: 0x000160DA File Offset: 0x000142DA
		protected SortedTable()
		{
		}
	}
}
