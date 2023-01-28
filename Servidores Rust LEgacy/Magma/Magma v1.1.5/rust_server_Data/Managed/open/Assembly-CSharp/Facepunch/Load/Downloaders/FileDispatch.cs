using System;
using System.IO;
using UnityEngine;

namespace Facepunch.Load.Downloaders
{
	// Token: 0x020002D0 RID: 720
	public sealed class FileDispatch : global::Facepunch.Load.IDownloaderDispatch
	{
		// Token: 0x060018D5 RID: 6357 RVA: 0x0006069C File Offset: 0x0005E89C
		public FileDispatch()
		{
		}

		// Token: 0x060018D6 RID: 6358 RVA: 0x000606B0 File Offset: 0x0005E8B0
		public void BindLoader(global::Facepunch.Load.Loader loader)
		{
			this.wwwFallback.BindLoader(loader);
		}

		// Token: 0x060018D7 RID: 6359 RVA: 0x000606C0 File Offset: 0x0005E8C0
		public void UnbindLoader(global::Facepunch.Load.Loader loader)
		{
			this.wwwFallback.BindLoader(loader);
		}

		// Token: 0x060018D8 RID: 6360 RVA: 0x000606D0 File Offset: 0x0005E8D0
		public global::Facepunch.Load.IDownloader CreateDownloaderForJob(global::Facepunch.Load.Job job)
		{
			if (global::System.IO.File.Exists(job.Path))
			{
				global::System.IO.FileInfo fileInfo = new global::System.IO.FileInfo(job.Path);
				bool flag = fileInfo.Length == (long)job.ByteLength;
				if (flag)
				{
					global::UnityEngine.AssetBundle assetBundle = global::UnityEngine.AssetBundle.CreateFromFile(global::System.IO.Path.GetFullPath(job.Path).Replace('\\', '/'));
					if (assetBundle)
					{
						return new global::Facepunch.Load.Downloaders.FileDispatch.Downloader
						{
							bundle = assetBundle
						};
					}
				}
			}
			global::UnityEngine.Debug.LogWarning("Missing Bundle " + job.Path);
			if (job.ContentType != global::Facepunch.Load.ContentType.Assets || job.TypeOfAssets == typeof(global::UnityEngine.NavMesh))
			{
				return this.wwwFallback.CreateDownloaderForJob(job);
			}
			return null;
		}

		// Token: 0x060018D9 RID: 6361 RVA: 0x00060788 File Offset: 0x0005E988
		public void DeleteDownloader(global::Facepunch.Load.Job job, global::Facepunch.Load.IDownloader downloader)
		{
			if (!(downloader is global::Facepunch.Load.Downloaders.FileDispatch.Downloader))
			{
				this.wwwFallback.DeleteDownloader(job, downloader);
			}
		}

		// Token: 0x04000E1D RID: 3613
		private global::Facepunch.Load.Downloaders.WWWDispatch wwwFallback = new global::Facepunch.Load.Downloaders.WWWDispatch();

		// Token: 0x020002D1 RID: 721
		private class Downloader : global::Facepunch.Load.IDownloader
		{
			// Token: 0x060018DA RID: 6362 RVA: 0x000607A4 File Offset: 0x0005E9A4
			public Downloader()
			{
			}

			// Token: 0x060018DB RID: 6363 RVA: 0x000607AC File Offset: 0x0005E9AC
			public void BeginJob(global::Facepunch.Load.Job job)
			{
				job.OnDownloadingBegin(this);
				job.OnDownloadingComplete();
			}

			// Token: 0x060018DC RID: 6364 RVA: 0x000607BC File Offset: 0x0005E9BC
			public float GetDownloadProgress(global::Facepunch.Load.Job job)
			{
				return 0f;
			}

			// Token: 0x060018DD RID: 6365 RVA: 0x000607C4 File Offset: 0x0005E9C4
			public global::UnityEngine.AssetBundle GetLoadedAssetBundle(global::Facepunch.Load.Job job)
			{
				return this.bundle;
			}

			// Token: 0x060018DE RID: 6366 RVA: 0x000607CC File Offset: 0x0005E9CC
			public void OnJobCompleted(global::Facepunch.Load.Job job)
			{
				this.bundle = null;
			}

			// Token: 0x04000E1E RID: 3614
			public global::UnityEngine.AssetBundle bundle;
		}
	}
}
