using System;
using UnityEngine;

// Token: 0x020009A7 RID: 2471
public class DeviceTime : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005330 RID: 21296 RVA: 0x0015D168 File Offset: 0x0015B368
	public DeviceTime()
	{
	}

	// Token: 0x06005331 RID: 21297 RVA: 0x0015D170 File Offset: 0x0015B370
	protected void OnEnable()
	{
		if (!this.sky)
		{
			global::UnityEngine.Debug.LogError("Sky instance reference not set. Disabling script.");
			base.enabled = false;
		}
		else
		{
			global::System.DateTime now = global::System.DateTime.Now;
			this.sky.Cycle.Year = now.Year;
			this.sky.Cycle.Month = now.Month;
			this.sky.Cycle.Day = now.Day;
			this.sky.Cycle.Hour = (float)now.Hour + (float)now.Minute / 60f;
		}
	}

	// Token: 0x0400309F RID: 12447
	public global::TOD_Sky sky;
}
