using System;

namespace Facepunch.Load
{
	// Token: 0x020002D5 RID: 725
	public interface IDownloadTask
	{
		// Token: 0x170006C2 RID: 1730
		// (get) Token: 0x060018FA RID: 6394
		int ByteLength { get; }

		// Token: 0x170006C3 RID: 1731
		// (get) Token: 0x060018FB RID: 6395
		int ByteLengthDownloaded { get; }

		// Token: 0x170006C4 RID: 1732
		// (get) Token: 0x060018FC RID: 6396
		float PercentDone { get; }

		// Token: 0x170006C5 RID: 1733
		// (get) Token: 0x060018FD RID: 6397
		global::Facepunch.Load.TaskStatus TaskStatus { get; }

		// Token: 0x170006C6 RID: 1734
		// (get) Token: 0x060018FE RID: 6398
		string Name { get; }

		// Token: 0x170006C7 RID: 1735
		// (get) Token: 0x060018FF RID: 6399
		string ContextualDescription { get; }

		// Token: 0x170006C8 RID: 1736
		// (get) Token: 0x06001900 RID: 6400
		int Count { get; }

		// Token: 0x170006C9 RID: 1737
		// (get) Token: 0x06001901 RID: 6401
		int Done { get; }

		// Token: 0x170006CA RID: 1738
		// (get) Token: 0x06001902 RID: 6402
		global::Facepunch.Load.TaskStatusCount TaskStatusCount { get; }
	}
}
