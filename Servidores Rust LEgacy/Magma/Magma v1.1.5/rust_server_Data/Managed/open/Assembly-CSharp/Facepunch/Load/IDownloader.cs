using System;
using UnityEngine;

namespace Facepunch.Load
{
	// Token: 0x020002D6 RID: 726
	public interface IDownloader
	{
		// Token: 0x06001903 RID: 6403
		void BeginJob(global::Facepunch.Load.Job job);

		// Token: 0x06001904 RID: 6404
		float GetDownloadProgress(global::Facepunch.Load.Job job);

		// Token: 0x06001905 RID: 6405
		global::UnityEngine.AssetBundle GetLoadedAssetBundle(global::Facepunch.Load.Job job);

		// Token: 0x06001906 RID: 6406
		void OnJobCompleted(global::Facepunch.Load.Job job);
	}
}
