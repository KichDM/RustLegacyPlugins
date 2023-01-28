using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Facepunch.Load
{
	// Token: 0x020002DA RID: 730
	public sealed class Job : global::Facepunch.Load.IDownloadTask
	{
		// Token: 0x0600190C RID: 6412 RVA: 0x00060E08 File Offset: 0x0005F008
		public Job()
		{
			this.TaskStatus = global::Facepunch.Load.TaskStatus.Pending;
		}

		// Token: 0x170006CB RID: 1739
		// (get) Token: 0x0600190D RID: 6413 RVA: 0x00060E18 File Offset: 0x0005F018
		int global::Facepunch.Load.IDownloadTask.Count
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170006CC RID: 1740
		// (get) Token: 0x0600190E RID: 6414 RVA: 0x00060E1C File Offset: 0x0005F01C
		int global::Facepunch.Load.IDownloadTask.Done
		{
			get
			{
				return (this.TaskStatus != global::Facepunch.Load.TaskStatus.Complete) ? 0 : 1;
			}
		}

		// Token: 0x170006CD RID: 1741
		// (get) Token: 0x0600190F RID: 6415 RVA: 0x00060E34 File Offset: 0x0005F034
		global::Facepunch.Load.TaskStatusCount global::Facepunch.Load.IDownloadTask.TaskStatusCount
		{
			get
			{
				switch (this.TaskStatus)
				{
				case global::Facepunch.Load.TaskStatus.Pending:
					return global::Facepunch.Load.TaskStatusCount.OnePending;
				case global::Facepunch.Load.TaskStatus.Downloading:
					return global::Facepunch.Load.TaskStatusCount.OneDownloading;
				case global::Facepunch.Load.TaskStatus.Complete:
					return global::Facepunch.Load.TaskStatusCount.OneComplete;
				}
				throw new global::System.ArgumentOutOfRangeException("TaskStatus");
			}
		}

		// Token: 0x170006CE RID: 1742
		// (get) Token: 0x06001910 RID: 6416 RVA: 0x00060E84 File Offset: 0x0005F084
		public global::Facepunch.Load.Loader Loader
		{
			get
			{
				return this._op.Loader;
			}
		}

		// Token: 0x170006CF RID: 1743
		// (get) Token: 0x06001911 RID: 6417 RVA: 0x00060E94 File Offset: 0x0005F094
		// (set) Token: 0x06001912 RID: 6418 RVA: 0x00060E9C File Offset: 0x0005F09C
		public global::Facepunch.Load.Group Group
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Group>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			internal set
			{
				this.<Group>k__BackingField = value;
			}
		}

		// Token: 0x170006D0 RID: 1744
		// (get) Token: 0x06001913 RID: 6419 RVA: 0x00060EA8 File Offset: 0x0005F0A8
		public string Name
		{
			get
			{
				return this.Item.Name;
			}
		}

		// Token: 0x170006D1 RID: 1745
		// (get) Token: 0x06001914 RID: 6420 RVA: 0x00060EB8 File Offset: 0x0005F0B8
		public string Path
		{
			get
			{
				return this.Item.Path;
			}
		}

		// Token: 0x170006D2 RID: 1746
		// (get) Token: 0x06001915 RID: 6421 RVA: 0x00060EC8 File Offset: 0x0005F0C8
		public int ByteLength
		{
			get
			{
				return this.Item.ByteLength;
			}
		}

		// Token: 0x170006D3 RID: 1747
		// (get) Token: 0x06001916 RID: 6422 RVA: 0x00060ED8 File Offset: 0x0005F0D8
		public global::Facepunch.Load.ContentType ContentType
		{
			get
			{
				return this.Item.ContentType;
			}
		}

		// Token: 0x170006D4 RID: 1748
		// (get) Token: 0x06001917 RID: 6423 RVA: 0x00060EE8 File Offset: 0x0005F0E8
		public global::System.Type TypeOfAssets
		{
			get
			{
				return this.Item.TypeOfAssets;
			}
		}

		// Token: 0x170006D5 RID: 1749
		// (get) Token: 0x06001918 RID: 6424 RVA: 0x00060EF8 File Offset: 0x0005F0F8
		public int ByteLengthDownloaded
		{
			get
			{
				return global::UnityEngine.Mathf.FloorToInt(this.PercentDone * (float)this.ByteLength);
			}
		}

		// Token: 0x170006D6 RID: 1750
		// (get) Token: 0x06001919 RID: 6425 RVA: 0x00060F10 File Offset: 0x0005F110
		// (set) Token: 0x0600191A RID: 6426 RVA: 0x00060F18 File Offset: 0x0005F118
		internal global::UnityEngine.AssetBundle AssetBundle
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<AssetBundle>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<AssetBundle>k__BackingField = value;
			}
		}

		// Token: 0x170006D7 RID: 1751
		// (get) Token: 0x0600191B RID: 6427 RVA: 0x00060F24 File Offset: 0x0005F124
		public float PercentDone
		{
			get
			{
				switch (this.TaskStatus)
				{
				case global::Facepunch.Load.TaskStatus.Pending:
					return 0f;
				case global::Facepunch.Load.TaskStatus.Downloading:
					return this.downloader.GetDownloadProgress(this);
				case global::Facepunch.Load.TaskStatus.Complete:
					return 1f;
				}
				throw new global::System.ArgumentOutOfRangeException("TaskStatus");
			}
		}

		// Token: 0x170006D8 RID: 1752
		// (get) Token: 0x0600191C RID: 6428 RVA: 0x00060F78 File Offset: 0x0005F178
		public string ContextualDescription
		{
			get
			{
				switch (this.TaskStatus)
				{
				case global::Facepunch.Load.TaskStatus.Pending:
					return "Pending";
				case global::Facepunch.Load.TaskStatus.Downloading:
					return (!this.hasDescriptiveDownloader || !this.descriptiveDownloader.DescribeProgress(this, ref this.lastDescriptiveString)) ? "Downloading" : (this.lastDescriptiveString ?? string.Empty);
				case global::Facepunch.Load.TaskStatus.Complete:
					return "Complete";
				}
				throw new global::System.ArgumentOutOfRangeException("TaskStatus");
			}
		}

		// Token: 0x170006D9 RID: 1753
		// (get) Token: 0x0600191D RID: 6429 RVA: 0x00061000 File Offset: 0x0005F200
		// (set) Token: 0x0600191E RID: 6430 RVA: 0x00061008 File Offset: 0x0005F208
		public global::Facepunch.Load.TaskStatus TaskStatus
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<TaskStatus>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<TaskStatus>k__BackingField = value;
			}
		}

		// Token: 0x0600191F RID: 6431 RVA: 0x00061014 File Offset: 0x0005F214
		public void OnDownloadingBegin(global::Facepunch.Load.IDownloader downloader)
		{
			this.downloader = downloader;
			this.lastDescriptiveString = null;
			this.hasDescriptiveDownloader = ((this.descriptiveDownloader = (downloader as global::Facepunch.Load.IDownloaderDescriptive)) != null);
			this.TaskStatus = global::Facepunch.Load.TaskStatus.Downloading;
		}

		// Token: 0x06001920 RID: 6432 RVA: 0x00061054 File Offset: 0x0005F254
		public void OnDownloadingComplete()
		{
			this.TaskStatus = global::Facepunch.Load.TaskStatus.Complete;
			global::Facepunch.Load.IDownloader downloader = this.downloader;
			this.downloader = null;
			this.descriptiveDownloader = null;
			this.hasDescriptiveDownloader = false;
			this.Loader.OnJobCompleted(this, downloader);
			if (!object.ReferenceEquals(this.Tag, null))
			{
				global::UnityEngine.Debug.LogWarning("Clearing tag manually ( should have been done by the IDownloader during the OnJobComplete callback )");
			}
			this.Tag = null;
		}

		// Token: 0x04000E2F RID: 3631
		[global::System.NonSerialized]
		public global::Facepunch.Load.Operation _op;

		// Token: 0x04000E30 RID: 3632
		[global::System.NonSerialized]
		public global::Facepunch.Load.Item Item;

		// Token: 0x04000E31 RID: 3633
		private global::Facepunch.Load.IDownloaderDescriptive descriptiveDownloader;

		// Token: 0x04000E32 RID: 3634
		private bool hasDescriptiveDownloader;

		// Token: 0x04000E33 RID: 3635
		private string lastDescriptiveString;

		// Token: 0x04000E34 RID: 3636
		public object Tag;

		// Token: 0x04000E35 RID: 3637
		private global::Facepunch.Load.IDownloader downloader;

		// Token: 0x04000E36 RID: 3638
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Facepunch.Load.Group <Group>k__BackingField;

		// Token: 0x04000E37 RID: 3639
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::UnityEngine.AssetBundle <AssetBundle>k__BackingField;

		// Token: 0x04000E38 RID: 3640
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Facepunch.Load.TaskStatus <TaskStatus>k__BackingField;
	}
}
