using System;
using UnityEngine;

namespace Facepunch.Load.Downloaders
{
	// Token: 0x020002D2 RID: 722
	public sealed class WWWDispatch : global::Facepunch.Load.IDownloaderDispatch
	{
		// Token: 0x060018DF RID: 6367 RVA: 0x000607D8 File Offset: 0x0005E9D8
		public WWWDispatch()
		{
		}

		// Token: 0x060018E0 RID: 6368 RVA: 0x000607F0 File Offset: 0x0005E9F0
		public void BindLoader(global::Facepunch.Load.Loader loader)
		{
			this.coroutineRunner.Retain();
		}

		// Token: 0x060018E1 RID: 6369 RVA: 0x00060800 File Offset: 0x0005EA00
		public void UnbindLoader(global::Facepunch.Load.Loader loader)
		{
			this.coroutineRunner.Release();
		}

		// Token: 0x060018E2 RID: 6370 RVA: 0x00060810 File Offset: 0x0005EA10
		public global::Facepunch.Load.IDownloader CreateDownloaderForJob(global::Facepunch.Load.Job job)
		{
			return new global::Facepunch.Load.Downloaders.WWWDispatch.Downloader(this);
		}

		// Token: 0x060018E3 RID: 6371 RVA: 0x00060818 File Offset: 0x0005EA18
		public void DeleteDownloader(global::Facepunch.Load.Job job, global::Facepunch.Load.IDownloader idownloader)
		{
			if (idownloader is global::Facepunch.Load.Downloaders.WWWDispatch.Downloader)
			{
				global::Facepunch.Load.Downloaders.WWWDispatch.Downloader downloader = (global::Facepunch.Load.Downloaders.WWWDispatch.Downloader)idownloader;
				downloader.Job = null;
				downloader.Download = null;
			}
		}

		// Token: 0x060018E4 RID: 6372 RVA: 0x00060848 File Offset: 0x0005EA48
		private void DownloadBegin(global::Facepunch.Load.Downloaders.WWWDispatch.Downloader downloader, global::Facepunch.Load.Job job)
		{
			downloader.Job = job;
			downloader.Download = new global::UnityEngine.WWW(job.Path);
			job.OnDownloadingBegin(downloader);
			if (downloader.Download.isDone)
			{
				this.DownloadFinished(downloader);
			}
			else
			{
				this.coroutineRunner.Install(global::Facepunch.Load.Downloaders.WWWDispatch.Downloader.DownloaderRoutineCallback, downloader, downloader.Download, true);
			}
		}

		// Token: 0x060018E5 RID: 6373 RVA: 0x000608AC File Offset: 0x0005EAAC
		private void DownloadFinished(global::Facepunch.Load.Downloaders.WWWDispatch.Downloader downloader)
		{
			downloader.Job.OnDownloadingComplete();
		}

		// Token: 0x04000E1F RID: 3615
		private readonly global::Facepunch.Load.Utility.ReferenceCountedCoroutine.Runner coroutineRunner = new global::Facepunch.Load.Utility.ReferenceCountedCoroutine.Runner("WWWDispatch");

		// Token: 0x020002D3 RID: 723
		private class Downloader : global::Facepunch.Load.IDownloader
		{
			// Token: 0x060018E6 RID: 6374 RVA: 0x000608BC File Offset: 0x0005EABC
			public Downloader(global::Facepunch.Load.Downloaders.WWWDispatch dispatch)
			{
				this.Dispatch = dispatch;
			}

			// Token: 0x060018E7 RID: 6375 RVA: 0x000608CC File Offset: 0x0005EACC
			// Note: this type is marked as 'beforefieldinit'.
			static Downloader()
			{
			}

			// Token: 0x060018E8 RID: 6376 RVA: 0x000608E0 File Offset: 0x0005EAE0
			public void BeginJob(global::Facepunch.Load.Job job)
			{
				this.Dispatch.DownloadBegin(this, job);
			}

			// Token: 0x060018E9 RID: 6377 RVA: 0x000608F0 File Offset: 0x0005EAF0
			public float GetDownloadProgress(global::Facepunch.Load.Job job)
			{
				return (this.Download != null) ? this.Download.progress : 0f;
			}

			// Token: 0x060018EA RID: 6378 RVA: 0x00060920 File Offset: 0x0005EB20
			public global::UnityEngine.AssetBundle GetLoadedAssetBundle(global::Facepunch.Load.Job job)
			{
				return this.Download.assetBundle;
			}

			// Token: 0x060018EB RID: 6379 RVA: 0x00060930 File Offset: 0x0005EB30
			public void OnJobCompleted(global::Facepunch.Load.Job job)
			{
				if (this.Job == job)
				{
					this.Download.Dispose();
					this.Download = null;
					this.Job = null;
				}
			}

			// Token: 0x060018EC RID: 6380 RVA: 0x00060958 File Offset: 0x0005EB58
			private static bool DownloaderRoutine(ref object yieldInstruction, ref object tag)
			{
				global::Facepunch.Load.Downloaders.WWWDispatch.Downloader downloader = (global::Facepunch.Load.Downloaders.WWWDispatch.Downloader)tag;
				yieldInstruction = downloader.Download;
				if (downloader.Download.isDone)
				{
					downloader.Dispatch.DownloadFinished(downloader);
					return false;
				}
				return true;
			}

			// Token: 0x04000E20 RID: 3616
			public readonly global::Facepunch.Load.Downloaders.WWWDispatch Dispatch;

			// Token: 0x04000E21 RID: 3617
			public global::UnityEngine.WWW Download;

			// Token: 0x04000E22 RID: 3618
			public global::Facepunch.Load.Job Job;

			// Token: 0x04000E23 RID: 3619
			public static readonly global::Facepunch.Load.Utility.ReferenceCountedCoroutine.Callback DownloaderRoutineCallback = new global::Facepunch.Load.Utility.ReferenceCountedCoroutine.Callback(global::Facepunch.Load.Downloaders.WWWDispatch.Downloader.DownloaderRoutine);
		}
	}
}
