using System;

namespace Mono.Cecil
{
	// Token: 0x0200004E RID: 78
	public struct ArrayDimension
	{
		// Token: 0x17000152 RID: 338
		// (get) Token: 0x0600038D RID: 909 RVA: 0x00009A50 File Offset: 0x00007C50
		// (set) Token: 0x0600038E RID: 910 RVA: 0x00009A58 File Offset: 0x00007C58
		public int? LowerBound
		{
			get
			{
				return this.lower_bound;
			}
			set
			{
				this.lower_bound = value;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x0600038F RID: 911 RVA: 0x00009A61 File Offset: 0x00007C61
		// (set) Token: 0x06000390 RID: 912 RVA: 0x00009A69 File Offset: 0x00007C69
		public int? UpperBound
		{
			get
			{
				return this.upper_bound;
			}
			set
			{
				this.upper_bound = value;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000391 RID: 913 RVA: 0x00009A72 File Offset: 0x00007C72
		public bool IsSized
		{
			get
			{
				return this.lower_bound != null || this.upper_bound != null;
			}
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00009A8E File Offset: 0x00007C8E
		public ArrayDimension(int? lowerBound, int? upperBound)
		{
			this.lower_bound = lowerBound;
			this.upper_bound = upperBound;
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00009A9E File Offset: 0x00007C9E
		public override string ToString()
		{
			if (this.IsSized)
			{
				return this.lower_bound + "..." + this.upper_bound;
			}
			return string.Empty;
		}

		// Token: 0x04000240 RID: 576
		private int? lower_bound;

		// Token: 0x04000241 RID: 577
		private int? upper_bound;
	}
}
