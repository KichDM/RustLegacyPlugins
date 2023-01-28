using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using LitJson;
using UnityEngine;

namespace Facepunch.Load
{
	// Token: 0x020002DB RID: 731
	public sealed class Loader : global::System.IDisposable, global::Facepunch.Load.IDownloadTask
	{
		// Token: 0x06001921 RID: 6433 RVA: 0x000610B4 File Offset: 0x0005F2B4
		private Loader(global::Facepunch.Load.Group masterGroup, global::Facepunch.Load.Job[] allJobs, global::Facepunch.Load.Group[] allGroups, global::Facepunch.Load.IDownloaderDispatch dispatch)
		{
			this.MasterGroup = masterGroup;
			this.Jobs = allJobs;
			this.Groups = allGroups;
			this.Dispatch = dispatch;
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06001922 RID: 6434 RVA: 0x000610EC File Offset: 0x0005F2EC
		// (remove) Token: 0x06001923 RID: 6435 RVA: 0x00061108 File Offset: 0x0005F308
		public event global::Facepunch.Load.AssetBundleLoadedEventHandler OnAssetBundleLoaded
		{
			[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
			add
			{
				this.OnAssetBundleLoaded = (global::Facepunch.Load.AssetBundleLoadedEventHandler)global::System.Delegate.Combine(this.OnAssetBundleLoaded, value);
			}
			[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
			remove
			{
				this.OnAssetBundleLoaded = (global::Facepunch.Load.AssetBundleLoadedEventHandler)global::System.Delegate.Remove(this.OnAssetBundleLoaded, value);
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06001924 RID: 6436 RVA: 0x00061124 File Offset: 0x0005F324
		// (remove) Token: 0x06001925 RID: 6437 RVA: 0x00061140 File Offset: 0x0005F340
		public event global::Facepunch.Load.MultipleAssetBundlesLoadedEventHandler OnAllAssetBundlesLoaded
		{
			[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
			add
			{
				this.OnAllAssetBundlesLoaded = (global::Facepunch.Load.MultipleAssetBundlesLoadedEventHandler)global::System.Delegate.Combine(this.OnAllAssetBundlesLoaded, value);
			}
			[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
			remove
			{
				this.OnAllAssetBundlesLoaded = (global::Facepunch.Load.MultipleAssetBundlesLoadedEventHandler)global::System.Delegate.Remove(this.OnAllAssetBundlesLoaded, value);
			}
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06001926 RID: 6438 RVA: 0x0006115C File Offset: 0x0005F35C
		// (remove) Token: 0x06001927 RID: 6439 RVA: 0x00061178 File Offset: 0x0005F378
		public event global::Facepunch.Load.MultipleAssetBundlesLoadedEventHandler OnGroupedAssetBundlesLoaded
		{
			[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
			add
			{
				this.OnGroupedAssetBundlesLoaded = (global::Facepunch.Load.MultipleAssetBundlesLoadedEventHandler)global::System.Delegate.Combine(this.OnGroupedAssetBundlesLoaded, value);
			}
			[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
			remove
			{
				this.OnGroupedAssetBundlesLoaded = (global::Facepunch.Load.MultipleAssetBundlesLoadedEventHandler)global::System.Delegate.Remove(this.OnGroupedAssetBundlesLoaded, value);
			}
		}

		// Token: 0x170006DA RID: 1754
		// (get) Token: 0x06001928 RID: 6440 RVA: 0x00061194 File Offset: 0x0005F394
		string global::Facepunch.Load.IDownloadTask.Name
		{
			get
			{
				return "Loading all bundles";
			}
		}

		// Token: 0x170006DB RID: 1755
		// (get) Token: 0x06001929 RID: 6441 RVA: 0x0006119C File Offset: 0x0005F39C
		string global::Facepunch.Load.IDownloadTask.ContextualDescription
		{
			get
			{
				return this.MasterGroup.ContextualDescription;
			}
		}

		// Token: 0x170006DC RID: 1756
		// (get) Token: 0x0600192A RID: 6442 RVA: 0x000611AC File Offset: 0x0005F3AC
		public int ByteLength
		{
			get
			{
				return this.MasterGroup.ByteLength;
			}
		}

		// Token: 0x170006DD RID: 1757
		// (get) Token: 0x0600192B RID: 6443 RVA: 0x000611BC File Offset: 0x0005F3BC
		public int ByteLengthDownloaded
		{
			get
			{
				return this.MasterGroup.ByteLengthDownloaded;
			}
		}

		// Token: 0x170006DE RID: 1758
		// (get) Token: 0x0600192C RID: 6444 RVA: 0x000611CC File Offset: 0x0005F3CC
		public float PercentDone
		{
			get
			{
				return this.MasterGroup.PercentDone;
			}
		}

		// Token: 0x170006DF RID: 1759
		// (get) Token: 0x0600192D RID: 6445 RVA: 0x000611DC File Offset: 0x0005F3DC
		public global::Facepunch.Load.TaskStatus TaskStatus
		{
			get
			{
				return this.MasterGroup.TaskStatus;
			}
		}

		// Token: 0x170006E0 RID: 1760
		// (get) Token: 0x0600192E RID: 6446 RVA: 0x000611EC File Offset: 0x0005F3EC
		public int Count
		{
			get
			{
				return this.MasterGroup.Count;
			}
		}

		// Token: 0x170006E1 RID: 1761
		// (get) Token: 0x0600192F RID: 6447 RVA: 0x000611FC File Offset: 0x0005F3FC
		public int Done
		{
			get
			{
				return this.MasterGroup.Done;
			}
		}

		// Token: 0x170006E2 RID: 1762
		// (get) Token: 0x06001930 RID: 6448 RVA: 0x0006120C File Offset: 0x0005F40C
		public global::Facepunch.Load.TaskStatusCount TaskStatusCount
		{
			get
			{
				return this.MasterGroup.TaskStatusCount;
			}
		}

		// Token: 0x170006E3 RID: 1763
		// (get) Token: 0x06001931 RID: 6449 RVA: 0x0006121C File Offset: 0x0005F41C
		public global::Facepunch.Load.Group CurrentGroup
		{
			get
			{
				return (this.currentGroup < 0 || this.currentGroup >= this.Groups.Length) ? null : this.Groups[this.currentGroup];
			}
		}

		// Token: 0x06001932 RID: 6450 RVA: 0x0006125C File Offset: 0x0005F45C
		private static global::Facepunch.Load.Loader Deserialize(global::Facepunch.Load.Reader reader, global::Facepunch.Load.IDownloaderDispatch dispatch)
		{
			global::System.Collections.Generic.List<global::Facepunch.Load.Item[]> list = new global::System.Collections.Generic.List<global::Facepunch.Load.Item[]>();
			global::System.Collections.Generic.List<global::Facepunch.Load.Item> list2 = new global::System.Collections.Generic.List<global::Facepunch.Load.Item>();
			while (reader.Read())
			{
				switch (reader.Token)
				{
				case global::Facepunch.Load.Token.RandomLoadOrderAreaBegin:
					list2.Clear();
					break;
				case global::Facepunch.Load.Token.BundleListing:
					list2.Add(reader.Item);
					break;
				case global::Facepunch.Load.Token.RandomLoadOrderAreaEnd:
					list.Add(list2.ToArray());
					break;
				case global::Facepunch.Load.Token.DownloadQueueEnd:
				{
					global::Facepunch.Load.Operation operation = new global::Facepunch.Load.Operation();
					int num = 0;
					foreach (global::Facepunch.Load.Item[] array in list)
					{
						num += array.Length;
					}
					global::Facepunch.Load.Job[] array2 = new global::Facepunch.Load.Job[num];
					int num2 = 0;
					foreach (global::Facepunch.Load.Item[] array3 in list)
					{
						foreach (global::Facepunch.Load.Item item in array3)
						{
							array2[num2++] = new global::Facepunch.Load.Job
							{
								_op = operation,
								Item = item
							};
						}
					}
					global::Facepunch.Load.Group group = new global::Facepunch.Load.Group();
					group._op = operation;
					group.Jobs = array2;
					group.Initialize();
					global::Facepunch.Load.Group[] array5 = new global::Facepunch.Load.Group[list.Count];
					int num3 = 0;
					int num4 = 0;
					foreach (global::Facepunch.Load.Item[] array6 in list)
					{
						int num5 = array6.Length;
						global::Facepunch.Load.Job[] array7 = new global::Facepunch.Load.Job[num5];
						for (int j = 0; j < num5; j++)
						{
							array7[j] = array2[num3++];
						}
						array5[num4] = new global::Facepunch.Load.Group();
						array5[num4]._op = operation;
						array5[num4].Jobs = array7;
						array5[num4].Initialize();
						for (int k = 0; k < num5; k++)
						{
							array7[k].Group = array5[num4];
						}
						num4++;
					}
					return operation.Loader = new global::Facepunch.Load.Loader(group, array2, array5, dispatch);
				}
				}
			}
			throw new global::System.InvalidProgramException();
		}

		// Token: 0x06001933 RID: 6451 RVA: 0x00061510 File Offset: 0x0005F710
		public static global::Facepunch.Load.Loader CreateFromText(string downloadListJson, string bundlePath, global::Facepunch.Load.IDownloaderDispatch dispatch)
		{
			global::Facepunch.Load.Loader result;
			using (global::Facepunch.Load.Reader reader = global::Facepunch.Load.Reader.CreateFromText(downloadListJson, bundlePath))
			{
				result = global::Facepunch.Load.Loader.Deserialize(reader, dispatch);
			}
			return result;
		}

		// Token: 0x06001934 RID: 6452 RVA: 0x00061564 File Offset: 0x0005F764
		public static global::Facepunch.Load.Loader CreateFromFile(string downloadListPath, string bundlePath, global::Facepunch.Load.IDownloaderDispatch dispatch)
		{
			global::Facepunch.Load.Loader result;
			using (global::Facepunch.Load.Reader reader = global::Facepunch.Load.Reader.CreateFromFile(downloadListPath, bundlePath))
			{
				result = global::Facepunch.Load.Loader.Deserialize(reader, dispatch);
			}
			return result;
		}

		// Token: 0x06001935 RID: 6453 RVA: 0x000615B8 File Offset: 0x0005F7B8
		public static global::Facepunch.Load.Loader CreateFromFile(string downloadListPath, global::Facepunch.Load.IDownloaderDispatch dispatch)
		{
			global::Facepunch.Load.Loader result;
			using (global::Facepunch.Load.Reader reader = global::Facepunch.Load.Reader.CreateFromFile(downloadListPath))
			{
				result = global::Facepunch.Load.Loader.Deserialize(reader, dispatch);
			}
			return result;
		}

		// Token: 0x06001936 RID: 6454 RVA: 0x00061608 File Offset: 0x0005F808
		public static global::Facepunch.Load.Loader CreateFromReader(global::System.IO.TextReader textReader, string bundlePath, global::Facepunch.Load.IDownloaderDispatch dispatch)
		{
			global::Facepunch.Load.Loader result;
			using (global::Facepunch.Load.Reader reader = global::Facepunch.Load.Reader.CreateFromReader(textReader, bundlePath))
			{
				result = global::Facepunch.Load.Loader.Deserialize(reader, dispatch);
			}
			return result;
		}

		// Token: 0x06001937 RID: 6455 RVA: 0x0006165C File Offset: 0x0005F85C
		public static global::Facepunch.Load.Loader CreateFromReader(global::LitJson.JsonReader jsonReader, string bundlePath, global::Facepunch.Load.IDownloaderDispatch dispatch)
		{
			global::Facepunch.Load.Loader result;
			using (global::Facepunch.Load.Reader reader = global::Facepunch.Load.Reader.CreateFromReader(jsonReader, bundlePath))
			{
				result = global::Facepunch.Load.Loader.Deserialize(reader, dispatch);
			}
			return result;
		}

		// Token: 0x06001938 RID: 6456 RVA: 0x000616B0 File Offset: 0x0005F8B0
		public static global::Facepunch.Load.Loader Create(global::Facepunch.Load.Reader reader, global::Facepunch.Load.IDownloaderDispatch dispatch)
		{
			return global::Facepunch.Load.Loader.Deserialize(reader, dispatch);
		}

		// Token: 0x06001939 RID: 6457 RVA: 0x000616BC File Offset: 0x0005F8BC
		internal void OnJobCompleted(global::Facepunch.Load.Job job, global::Facepunch.Load.IDownloader downloader)
		{
			job.AssetBundle = downloader.GetLoadedAssetBundle(job);
			if (this.OnAssetBundleLoaded != null)
			{
				try
				{
					this.OnAssetBundleLoaded(job.AssetBundle, job.Item);
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogException(ex);
				}
			}
			downloader.OnJobCompleted(job);
			this.Dispatch.DeleteDownloader(job, downloader);
			if (++this.jobsCompleted == this.MasterGroup.Count)
			{
				if (this.OnAllAssetBundlesLoaded != null)
				{
					global::UnityEngine.AssetBundle[] assetBundle;
					global::Facepunch.Load.Item[] item;
					this.MasterGroup.GetArrays(out assetBundle, out item);
					try
					{
						this.OnAllAssetBundlesLoaded(assetBundle, item);
					}
					catch (global::System.Exception ex2)
					{
						global::UnityEngine.Debug.LogException(ex2);
					}
				}
				this.DisposeDispatch();
			}
			else if (++this.jobsCompletedInGroup == this.Groups[this.currentGroup].Jobs.Length)
			{
				if (this.OnGroupedAssetBundlesLoaded != null)
				{
					global::UnityEngine.AssetBundle[] assetBundle2;
					global::Facepunch.Load.Item[] item2;
					this.Groups[this.currentGroup].GetArrays(out assetBundle2, out item2);
					try
					{
						this.OnGroupedAssetBundlesLoaded(assetBundle2, item2);
					}
					catch (global::System.Exception ex3)
					{
						global::UnityEngine.Debug.LogException(ex3);
					}
				}
				this.StartNextGroup();
			}
		}

		// Token: 0x0600193A RID: 6458 RVA: 0x00061844 File Offset: 0x0005FA44
		private void DisposeDispatch()
		{
			if (this.Dispatch != null)
			{
				global::Facepunch.Load.IDownloaderDispatch dispatch = this.Dispatch;
				this.Dispatch = null;
				dispatch.UnbindLoader(this);
			}
		}

		// Token: 0x0600193B RID: 6459 RVA: 0x00061874 File Offset: 0x0005FA74
		public void Dispose()
		{
			if (!this.disposed)
			{
				this.disposed = true;
				this.DisposeDispatch();
			}
		}

		// Token: 0x0600193C RID: 6460 RVA: 0x00061890 File Offset: 0x0005FA90
		private void StartJob(global::Facepunch.Load.Job job)
		{
			global::Facepunch.Load.IDownloader downloader = this.Dispatch.CreateDownloaderForJob(job);
			downloader.BeginJob(job);
		}

		// Token: 0x0600193D RID: 6461 RVA: 0x000618B4 File Offset: 0x0005FAB4
		private void StartNextGroup()
		{
			this.jobsCompletedInGroup = 0;
			foreach (global::Facepunch.Load.Job job in this.Groups[++this.currentGroup].Jobs)
			{
				this.StartJob(job);
			}
		}

		// Token: 0x0600193E RID: 6462 RVA: 0x00061908 File Offset: 0x0005FB08
		public void StartLoading()
		{
			if (this.currentGroup == -1)
			{
				this.Dispatch.BindLoader(this);
				if (this.Groups.Length > 0)
				{
					this.StartNextGroup();
				}
			}
		}

		// Token: 0x170006E4 RID: 1764
		// (get) Token: 0x0600193F RID: 6463 RVA: 0x00061944 File Offset: 0x0005FB44
		public global::System.Collections.IEnumerator WaitEnumerator
		{
			get
			{
				while (this.jobsCompleted < this.MasterGroup.Jobs.Length)
				{
					yield return null;
				}
				yield break;
			}
		}

		// Token: 0x04000E39 RID: 3641
		[global::System.NonSerialized]
		private readonly global::Facepunch.Load.Group MasterGroup;

		// Token: 0x04000E3A RID: 3642
		[global::System.NonSerialized]
		public readonly global::Facepunch.Load.Group[] Groups;

		// Token: 0x04000E3B RID: 3643
		[global::System.NonSerialized]
		public readonly global::Facepunch.Load.Job[] Jobs;

		// Token: 0x04000E3C RID: 3644
		[global::System.NonSerialized]
		private int jobsCompleted;

		// Token: 0x04000E3D RID: 3645
		[global::System.NonSerialized]
		private int currentGroup = -1;

		// Token: 0x04000E3E RID: 3646
		[global::System.NonSerialized]
		private int jobsCompletedInGroup;

		// Token: 0x04000E3F RID: 3647
		[global::System.NonSerialized]
		private bool disposed;

		// Token: 0x04000E40 RID: 3648
		[global::System.NonSerialized]
		private global::Facepunch.Load.IDownloaderDispatch Dispatch;

		// Token: 0x04000E41 RID: 3649
		private global::Facepunch.Load.AssetBundleLoadedEventHandler OnAssetBundleLoaded;

		// Token: 0x04000E42 RID: 3650
		private global::Facepunch.Load.MultipleAssetBundlesLoadedEventHandler OnAllAssetBundlesLoaded;

		// Token: 0x04000E43 RID: 3651
		private global::Facepunch.Load.MultipleAssetBundlesLoadedEventHandler OnGroupedAssetBundlesLoaded;

		// Token: 0x020002DC RID: 732
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <>c__Iterator2C : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
		{
			// Token: 0x06001940 RID: 6464 RVA: 0x00061960 File Offset: 0x0005FB60
			public <>c__Iterator2C()
			{
			}

			// Token: 0x170006E5 RID: 1765
			// (get) Token: 0x06001941 RID: 6465 RVA: 0x00061968 File Offset: 0x0005FB68
			object global::System.Collections.Generic.IEnumerator<object>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x170006E6 RID: 1766
			// (get) Token: 0x06001942 RID: 6466 RVA: 0x00061970 File Offset: 0x0005FB70
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06001943 RID: 6467 RVA: 0x00061978 File Offset: 0x0005FB78
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0U:
					break;
				case 1U:
					break;
				default:
					return false;
				}
				if (this.jobsCompleted < this.MasterGroup.Jobs.Length)
				{
					this.$current = null;
					this.$PC = 1;
					return true;
				}
				this.$PC = -1;
				return false;
			}

			// Token: 0x06001944 RID: 6468 RVA: 0x000619EC File Offset: 0x0005FBEC
			[global::System.Diagnostics.DebuggerHidden]
			public void Dispose()
			{
				this.$PC = -1;
			}

			// Token: 0x06001945 RID: 6469 RVA: 0x000619F8 File Offset: 0x0005FBF8
			[global::System.Diagnostics.DebuggerHidden]
			public void Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x04000E44 RID: 3652
			internal int $PC;

			// Token: 0x04000E45 RID: 3653
			internal object $current;

			// Token: 0x04000E46 RID: 3654
			internal global::Facepunch.Load.Loader <>f__this;
		}
	}
}
