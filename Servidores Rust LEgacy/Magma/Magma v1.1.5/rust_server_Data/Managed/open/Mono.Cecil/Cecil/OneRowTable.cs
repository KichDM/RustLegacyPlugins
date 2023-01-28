using System;

namespace Mono.Cecil
{
	// Token: 0x020000C9 RID: 201
	internal abstract class OneRowTable<TRow> : global::Mono.Cecil.MetadataTable where TRow : struct
	{
		// Token: 0x170002BA RID: 698
		// (get) Token: 0x06000818 RID: 2072 RVA: 0x0001600B File Offset: 0x0001420B
		public sealed override int Length
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x0001600E File Offset: 0x0001420E
		public sealed override void Sort()
		{
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x00016010 File Offset: 0x00014210
		protected OneRowTable()
		{
		}

		// Token: 0x040005DB RID: 1499
		internal TRow row;
	}
}
