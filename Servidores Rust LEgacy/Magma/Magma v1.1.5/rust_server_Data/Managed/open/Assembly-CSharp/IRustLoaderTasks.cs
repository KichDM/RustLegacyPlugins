using System;
using System.Collections.Generic;
using Facepunch.Load;

// Token: 0x0200003B RID: 59
public interface IRustLoaderTasks
{
	// Token: 0x1700005A RID: 90
	// (get) Token: 0x0600022A RID: 554
	bool Active { get; }

	// Token: 0x1700005B RID: 91
	// (get) Token: 0x0600022B RID: 555
	global::Facepunch.Load.IDownloadTask Overall { get; }

	// Token: 0x1700005C RID: 92
	// (get) Token: 0x0600022C RID: 556
	global::System.Collections.Generic.IEnumerable<global::Facepunch.Load.IDownloadTask> Groups { get; }

	// Token: 0x1700005D RID: 93
	// (get) Token: 0x0600022D RID: 557
	global::Facepunch.Load.IDownloadTask ActiveGroup { get; }

	// Token: 0x1700005E RID: 94
	// (get) Token: 0x0600022E RID: 558
	global::System.Collections.Generic.IEnumerable<global::Facepunch.Load.IDownloadTask> ActiveJobs { get; }

	// Token: 0x1700005F RID: 95
	// (get) Token: 0x0600022F RID: 559
	global::System.Collections.Generic.IEnumerable<global::Facepunch.Load.IDownloadTask> Jobs { get; }
}
