using System;

namespace Facepunch.Load
{
	// Token: 0x020002D8 RID: 728
	public interface IDownloaderDispatch
	{
		// Token: 0x06001908 RID: 6408
		void BindLoader(global::Facepunch.Load.Loader loader);

		// Token: 0x06001909 RID: 6409
		void UnbindLoader(global::Facepunch.Load.Loader loader);

		// Token: 0x0600190A RID: 6410
		global::Facepunch.Load.IDownloader CreateDownloaderForJob(global::Facepunch.Load.Job job);

		// Token: 0x0600190B RID: 6411
		void DeleteDownloader(global::Facepunch.Load.Job job, global::Facepunch.Load.IDownloader downloader);
	}
}
