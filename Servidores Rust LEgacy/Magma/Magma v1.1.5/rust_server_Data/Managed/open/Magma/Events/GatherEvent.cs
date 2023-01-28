using System;

namespace Magma.Events
{
	// Token: 0x02000007 RID: 7
	public class GatherEvent
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002926 File Offset: 0x00000B26
		public string Type
		{
			get
			{
				return this._type;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000035 RID: 53 RVA: 0x0000292E File Offset: 0x00000B2E
		public float PercentFull
		{
			get
			{
				return this.res.GetPercentFull();
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000036 RID: 54 RVA: 0x0000293B File Offset: 0x00000B3B
		public int AmountLeft
		{
			get
			{
				return this.res.GetTotalResLeft();
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00002948 File Offset: 0x00000B48
		// (set) Token: 0x06000038 RID: 56 RVA: 0x00002950 File Offset: 0x00000B50
		public int Quantity
		{
			get
			{
				return this._qty;
			}
			set
			{
				this._qty = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002959 File Offset: 0x00000B59
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00002961 File Offset: 0x00000B61
		public bool Override
		{
			get
			{
				return this._over;
			}
			set
			{
				this._over = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600003B RID: 59 RVA: 0x0000296A File Offset: 0x00000B6A
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00002972 File Offset: 0x00000B72
		public string Item
		{
			get
			{
				return this._item;
			}
			set
			{
				this._item = value;
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000297C File Offset: 0x00000B7C
		public GatherEvent(global::ResourceTarget r, global::ResourceGivePair gp, int qty)
		{
			this.res = r;
			this._qty = qty;
			this._item = gp.ResourceItemDataBlock.name;
			this._type = this.res.type.ToString();
			this.Override = false;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000029D0 File Offset: 0x00000BD0
		public GatherEvent(global::ResourceTarget r, global::ItemDataBlock db, int qty)
		{
			this.res = r;
			this._qty = qty;
			this._item = db.name;
			this._type = "Tree";
			this.Override = false;
		}

		// Token: 0x0400000E RID: 14
		private global::ResourceTarget res;

		// Token: 0x0400000F RID: 15
		private string _type;

		// Token: 0x04000010 RID: 16
		private int _qty;

		// Token: 0x04000011 RID: 17
		private bool _over;

		// Token: 0x04000012 RID: 18
		private string _item;
	}
}
