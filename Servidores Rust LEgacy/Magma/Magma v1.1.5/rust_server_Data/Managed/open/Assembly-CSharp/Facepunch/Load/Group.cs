using System;
using UnityEngine;

namespace Facepunch.Load
{
	// Token: 0x020002D4 RID: 724
	public class Group : global::Facepunch.Load.IDownloadTask
	{
		// Token: 0x060018ED RID: 6381 RVA: 0x00060994 File Offset: 0x0005EB94
		public Group()
		{
		}

		// Token: 0x170006B8 RID: 1720
		// (get) Token: 0x060018EE RID: 6382 RVA: 0x0006099C File Offset: 0x0005EB9C
		string global::Facepunch.Load.IDownloadTask.Name
		{
			get
			{
				return this.jobDesc;
			}
		}

		// Token: 0x170006B9 RID: 1721
		// (get) Token: 0x060018EF RID: 6383 RVA: 0x000609A4 File Offset: 0x0005EBA4
		int global::Facepunch.Load.IDownloadTask.ByteLength
		{
			get
			{
				return this.ByteLength;
			}
		}

		// Token: 0x170006BA RID: 1722
		// (get) Token: 0x060018F0 RID: 6384 RVA: 0x000609AC File Offset: 0x0005EBAC
		public global::Facepunch.Load.Loader Loader
		{
			get
			{
				return this._op.Loader;
			}
		}

		// Token: 0x170006BB RID: 1723
		// (get) Token: 0x060018F1 RID: 6385 RVA: 0x000609BC File Offset: 0x0005EBBC
		public int ByteLengthDownloaded
		{
			get
			{
				int num = 0;
				foreach (global::Facepunch.Load.Job job in this.Jobs)
				{
					num += job.ByteLengthDownloaded;
				}
				return num;
			}
		}

		// Token: 0x170006BC RID: 1724
		// (get) Token: 0x060018F2 RID: 6386 RVA: 0x000609F4 File Offset: 0x0005EBF4
		public global::Facepunch.Load.TaskStatus TaskStatus
		{
			get
			{
				global::Facepunch.Load.TaskStatus result = global::Facepunch.Load.TaskStatus.Complete;
				foreach (global::Facepunch.Load.Job job in this.Jobs)
				{
					if (job.TaskStatus == global::Facepunch.Load.TaskStatus.Downloading)
					{
						return global::Facepunch.Load.TaskStatus.Downloading;
					}
					if (job.TaskStatus == global::Facepunch.Load.TaskStatus.Pending)
					{
						result = global::Facepunch.Load.TaskStatus.Pending;
					}
				}
				return result;
			}
		}

		// Token: 0x170006BD RID: 1725
		// (get) Token: 0x060018F3 RID: 6387 RVA: 0x00060A40 File Offset: 0x0005EC40
		public global::Facepunch.Load.TaskStatusCount TaskStatusCount
		{
			get
			{
				global::Facepunch.Load.TaskStatusCount result = default(global::Facepunch.Load.TaskStatusCount);
				foreach (global::Facepunch.Load.Job job in this.Jobs)
				{
					ref global::Facepunch.Load.TaskStatusCount ptr = ref result;
					global::Facepunch.Load.TaskStatus taskStatus;
					global::Facepunch.Load.TaskStatus status = taskStatus = job.TaskStatus;
					int num = ptr[taskStatus];
					result[status] = num + 1;
				}
				return result;
			}
		}

		// Token: 0x170006BE RID: 1726
		// (get) Token: 0x060018F4 RID: 6388 RVA: 0x00060A9C File Offset: 0x0005EC9C
		public string ContextualDescription
		{
			get
			{
				global::Facepunch.Load.TaskStatusCount taskStatusCount = this.TaskStatusCount;
				global::Facepunch.Load.TaskStatusCount? taskStatusCount2 = this.lastStatusCount;
				global::Facepunch.Load.TaskStatusCount taskStatusCount3 = (taskStatusCount2 == null) ? taskStatusCount : taskStatusCount2.Value;
				if (this.lastStatusCount == null || taskStatusCount3.Pending != taskStatusCount.Pending || taskStatusCount3.Complete != taskStatusCount.Complete || taskStatusCount3.Downloading != taskStatusCount.Downloading)
				{
					this.lastStatusCount = new global::Facepunch.Load.TaskStatusCount?(taskStatusCount);
					switch ((byte)(taskStatusCount.TaskStatus & (global::Facepunch.Load.TaskStatus.Pending | global::Facepunch.Load.TaskStatus.Downloading | global::Facepunch.Load.TaskStatus.Complete)))
					{
					case 1:
						this.lastDescriptiveText = string.Format("{0} pending", taskStatusCount.Pending);
						break;
					case 2:
						this.lastDescriptiveText = string.Format("{0} downloading", taskStatusCount.Downloading);
						break;
					case 3:
						this.lastDescriptiveText = string.Format("{0} pending, {1} downloading", taskStatusCount.Pending, taskStatusCount.Downloading);
						break;
					case 4:
						this.lastDescriptiveText = string.Format("{0} complete", taskStatusCount.Complete);
						break;
					case 5:
						this.lastDescriptiveText = string.Format("{0} pending, {1} complete", taskStatusCount.Pending, taskStatusCount.Downloading);
						break;
					case 6:
						this.lastDescriptiveText = string.Format("{0} downloading, {1} complete", taskStatusCount.Downloading, taskStatusCount.Complete);
						break;
					case 7:
						this.lastDescriptiveText = string.Format("{0} pending, {1} downloading, {2} complete", taskStatusCount.Pending, taskStatusCount.Downloading, taskStatusCount.Complete);
						break;
					default:
						throw new global::System.ArgumentException("TaskStatus");
					}
				}
				return this.lastDescriptiveText;
			}
		}

		// Token: 0x170006BF RID: 1727
		// (get) Token: 0x060018F5 RID: 6389 RVA: 0x00060C90 File Offset: 0x0005EE90
		public float PercentDone
		{
			get
			{
				return (float)((double)this.ByteLengthDownloaded / (double)this.ByteLength);
			}
		}

		// Token: 0x170006C0 RID: 1728
		// (get) Token: 0x060018F6 RID: 6390 RVA: 0x00060CA4 File Offset: 0x0005EEA4
		public int Count
		{
			get
			{
				return this.Jobs.Length;
			}
		}

		// Token: 0x170006C1 RID: 1729
		// (get) Token: 0x060018F7 RID: 6391 RVA: 0x00060CB0 File Offset: 0x0005EEB0
		public int Done
		{
			get
			{
				int num = 0;
				foreach (global::Facepunch.Load.Job job in this.Jobs)
				{
					if (job.TaskStatus == global::Facepunch.Load.TaskStatus.Complete)
					{
						num++;
					}
				}
				return num;
			}
		}

		// Token: 0x060018F8 RID: 6392 RVA: 0x00060CF0 File Offset: 0x0005EEF0
		public void Initialize()
		{
			this.ByteLength = 0;
			foreach (global::Facepunch.Load.Job job in this.Jobs)
			{
				this.ByteLength += job.Item.ByteLength;
			}
			int num = this.Jobs.Length;
			if (num != 0)
			{
				if (num != 1)
				{
					this.jobDesc = string.Format("{0} bundles", this.Jobs.Length);
				}
				else
				{
					this.jobDesc = "1 bundle";
				}
			}
			else
			{
				this.jobDesc = "No bundles";
			}
		}

		// Token: 0x060018F9 RID: 6393 RVA: 0x00060D98 File Offset: 0x0005EF98
		internal void GetArrays(out global::UnityEngine.AssetBundle[] assetBundles, out global::Facepunch.Load.Item[] items)
		{
			items = new global::Facepunch.Load.Item[this.Jobs.Length];
			assetBundles = new global::UnityEngine.AssetBundle[this.Jobs.Length];
			for (int i = 0; i < this.Jobs.Length; i++)
			{
				assetBundles[i] = this.Jobs[i].AssetBundle;
				items[i] = this.Jobs[i].Item;
			}
		}

		// Token: 0x04000E24 RID: 3620
		[global::System.NonSerialized]
		public global::Facepunch.Load.Operation _op;

		// Token: 0x04000E25 RID: 3621
		[global::System.NonSerialized]
		public global::Facepunch.Load.Job[] Jobs;

		// Token: 0x04000E26 RID: 3622
		[global::System.NonSerialized]
		public int ByteLength;

		// Token: 0x04000E27 RID: 3623
		[global::System.NonSerialized]
		private string jobDesc;

		// Token: 0x04000E28 RID: 3624
		[global::System.NonSerialized]
		private string lastDescriptiveText;

		// Token: 0x04000E29 RID: 3625
		[global::System.NonSerialized]
		private global::Facepunch.Load.TaskStatusCount? lastStatusCount;
	}
}
