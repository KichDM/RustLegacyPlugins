using System;

namespace Facepunch.Load
{
	// Token: 0x020002D7 RID: 727
	public interface IDownloaderDescriptive : global::Facepunch.Load.IDownloader
	{
		// Token: 0x06001907 RID: 6407
		bool DescribeProgress(global::Facepunch.Load.Job job, ref string lastString);
	}
}
