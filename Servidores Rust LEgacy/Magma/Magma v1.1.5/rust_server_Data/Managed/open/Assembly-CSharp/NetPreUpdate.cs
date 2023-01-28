using System;
using UnityEngine;

// Token: 0x02000424 RID: 1060
internal class NetPreUpdate : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060024D6 RID: 9430 RVA: 0x0008C5D0 File Offset: 0x0008A7D0
	public NetPreUpdate()
	{
	}

	// Token: 0x060024D7 RID: 9431 RVA: 0x0008C5E4 File Offset: 0x0008A7E4
	private void Awake()
	{
		global::NetCull.Callbacks.BindUpdater(this);
	}

	// Token: 0x060024D8 RID: 9432 RVA: 0x0008C5EC File Offset: 0x0008A7EC
	private void OnDestroy()
	{
		global::NetCull.Callbacks.ResignUpdater(this);
	}

	// Token: 0x060024D9 RID: 9433 RVA: 0x0008C5F4 File Offset: 0x0008A7F4
	private void LateUpdate()
	{
		if (global::global.fpslog >= 0f)
		{
			if (this.lastfpslog != global::global.fpslog)
			{
				this.lastfpslog = global::global.fpslog;
				this.lastfpslogtime = global::UnityEngine.Time.time - this.lastfpslog;
			}
			float time = global::UnityEngine.Time.time;
			if (this.lastfpslog == 0f || time - this.lastfpslogtime >= this.lastfpslog)
			{
				this.lastfpslogtime = time;
				global::UnityEngine.MonoBehaviour.print(string.Concat(new object[]
				{
					global::System.DateTime.Now,
					": frame #",
					global::UnityEngine.Time.frameCount,
					", fps ",
					1f / global::UnityEngine.Time.smoothDeltaTime
				}));
			}
		}
		if (global::UnityEngine.Application.isPlaying)
		{
			global::NetCull.Callbacks.FirePreUpdate(this);
		}
	}

	// Token: 0x04001293 RID: 4755
	[global::System.NonSerialized]
	private float lastfpslog = -1f;

	// Token: 0x04001294 RID: 4756
	[global::System.NonSerialized]
	private float lastfpslogtime;
}
