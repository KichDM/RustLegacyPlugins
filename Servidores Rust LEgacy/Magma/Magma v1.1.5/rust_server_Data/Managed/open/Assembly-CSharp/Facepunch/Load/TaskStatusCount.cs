using System;

namespace Facepunch.Load
{
	// Token: 0x020002E2 RID: 738
	public struct TaskStatusCount
	{
		// Token: 0x06001959 RID: 6489 RVA: 0x00062490 File Offset: 0x00060690
		// Note: this type is marked as 'beforefieldinit'.
		static TaskStatusCount()
		{
		}

		// Token: 0x170006E9 RID: 1769
		// (get) Token: 0x0600195A RID: 6490 RVA: 0x000624E0 File Offset: 0x000606E0
		public int Total
		{
			get
			{
				return this.Pending + this.Downloading + this.Complete;
			}
		}

		// Token: 0x170006EA RID: 1770
		// (get) Token: 0x0600195B RID: 6491 RVA: 0x000624F8 File Offset: 0x000606F8
		public int Remaining
		{
			get
			{
				return this.Pending + this.Downloading;
			}
		}

		// Token: 0x170006EB RID: 1771
		// (get) Token: 0x0600195C RID: 6492 RVA: 0x00062508 File Offset: 0x00060708
		public float PercentComplete
		{
			get
			{
				return (this.Complete != 0) ? ((float)((double)this.Remaining / (double)this.Total)) : 0f;
			}
		}

		// Token: 0x170006EC RID: 1772
		// (get) Token: 0x0600195D RID: 6493 RVA: 0x00062530 File Offset: 0x00060730
		public float PercentPending
		{
			get
			{
				return (this.Pending != 0) ? ((float)((double)this.Pending / (double)this.Total)) : 0f;
			}
		}

		// Token: 0x170006ED RID: 1773
		// (get) Token: 0x0600195E RID: 6494 RVA: 0x00062558 File Offset: 0x00060758
		public float PercentDownloading
		{
			get
			{
				return ((float)this.Downloading != 0f) ? ((float)((double)this.Downloading / (double)this.Total)) : 0f;
			}
		}

		// Token: 0x170006EE RID: 1774
		// (get) Token: 0x0600195F RID: 6495 RVA: 0x00062588 File Offset: 0x00060788
		public bool CompletelyPending
		{
			get
			{
				return this.Pending > 0 && this.Downloading == 0 && this.Complete == 0;
			}
		}

		// Token: 0x170006EF RID: 1775
		// (get) Token: 0x06001960 RID: 6496 RVA: 0x000625BC File Offset: 0x000607BC
		public bool CompletelyDownloading
		{
			get
			{
				return this.Downloading > 0 && this.Pending == 0 && this.Complete == 0;
			}
		}

		// Token: 0x170006F0 RID: 1776
		// (get) Token: 0x06001961 RID: 6497 RVA: 0x000625F0 File Offset: 0x000607F0
		public bool CompletelyComplete
		{
			get
			{
				return this.Complete > 0 && this.Downloading == 0 && this.Pending == 0;
			}
		}

		// Token: 0x170006F1 RID: 1777
		// (get) Token: 0x06001962 RID: 6498 RVA: 0x00062624 File Offset: 0x00060824
		public global::Facepunch.Load.TaskStatus TaskStatus
		{
			get
			{
				if (this.Pending > 0)
				{
					if (this.Downloading > 0)
					{
						if (this.Complete > 0)
						{
							return global::Facepunch.Load.TaskStatus.Pending | global::Facepunch.Load.TaskStatus.Downloading | global::Facepunch.Load.TaskStatus.Complete;
						}
						return global::Facepunch.Load.TaskStatus.Pending | global::Facepunch.Load.TaskStatus.Downloading;
					}
					else
					{
						if (this.Complete > 0)
						{
							return global::Facepunch.Load.TaskStatus.Pending | global::Facepunch.Load.TaskStatus.Complete;
						}
						return global::Facepunch.Load.TaskStatus.Pending;
					}
				}
				else if (this.Downloading > 0)
				{
					if (this.Complete > 0)
					{
						return global::Facepunch.Load.TaskStatus.Downloading | global::Facepunch.Load.TaskStatus.Complete;
					}
					return global::Facepunch.Load.TaskStatus.Downloading;
				}
				else
				{
					if (this.Complete > 0)
					{
						return global::Facepunch.Load.TaskStatus.Complete;
					}
					return (global::Facepunch.Load.TaskStatus)0;
				}
			}
		}

		// Token: 0x170006F2 RID: 1778
		public int this[global::Facepunch.Load.TaskStatus status]
		{
			get
			{
				switch (status)
				{
				case global::Facepunch.Load.TaskStatus.Pending:
					return this.Pending;
				case global::Facepunch.Load.TaskStatus.Downloading:
					return this.Downloading;
				case global::Facepunch.Load.TaskStatus.Pending | global::Facepunch.Load.TaskStatus.Downloading:
					return this.Pending + this.Downloading;
				case global::Facepunch.Load.TaskStatus.Complete:
					return this.Complete;
				case global::Facepunch.Load.TaskStatus.Pending | global::Facepunch.Load.TaskStatus.Complete:
					return this.Pending + this.Complete;
				case global::Facepunch.Load.TaskStatus.Downloading | global::Facepunch.Load.TaskStatus.Complete:
					return this.Pending + this.Downloading;
				case global::Facepunch.Load.TaskStatus.Pending | global::Facepunch.Load.TaskStatus.Downloading | global::Facepunch.Load.TaskStatus.Complete:
					return this.Pending + this.Downloading + this.Complete;
				default:
					return 0;
				}
			}
			set
			{
				switch (status)
				{
				case global::Facepunch.Load.TaskStatus.Pending:
					this.Pending = value;
					break;
				case global::Facepunch.Load.TaskStatus.Downloading:
					this.Downloading = value;
					break;
				case global::Facepunch.Load.TaskStatus.Pending | global::Facepunch.Load.TaskStatus.Downloading:
					this.Pending = value;
					this.Downloading = value;
					break;
				case global::Facepunch.Load.TaskStatus.Complete:
					this.Complete = value;
					break;
				case global::Facepunch.Load.TaskStatus.Pending | global::Facepunch.Load.TaskStatus.Complete:
					this.Pending = value;
					this.Complete = value;
					break;
				case global::Facepunch.Load.TaskStatus.Downloading | global::Facepunch.Load.TaskStatus.Complete:
					this.Complete = value;
					this.Downloading = value;
					break;
				case global::Facepunch.Load.TaskStatus.Pending | global::Facepunch.Load.TaskStatus.Downloading | global::Facepunch.Load.TaskStatus.Complete:
					this.Downloading = value;
					this.Pending = value;
					this.Complete = value;
					break;
				}
			}
		}

		// Token: 0x04000E5A RID: 3674
		public int Pending;

		// Token: 0x04000E5B RID: 3675
		public int Downloading;

		// Token: 0x04000E5C RID: 3676
		public int Complete;

		// Token: 0x04000E5D RID: 3677
		public static readonly global::Facepunch.Load.TaskStatusCount OnePending = new global::Facepunch.Load.TaskStatusCount
		{
			Pending = 1
		};

		// Token: 0x04000E5E RID: 3678
		public static readonly global::Facepunch.Load.TaskStatusCount OneDownloading = new global::Facepunch.Load.TaskStatusCount
		{
			Downloading = 1
		};

		// Token: 0x04000E5F RID: 3679
		public static readonly global::Facepunch.Load.TaskStatusCount OneComplete = new global::Facepunch.Load.TaskStatusCount
		{
			Complete = 1
		};
	}
}
