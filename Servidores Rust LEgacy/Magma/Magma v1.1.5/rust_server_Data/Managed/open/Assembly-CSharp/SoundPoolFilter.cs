using System;
using UnityEngine;

// Token: 0x02000109 RID: 265
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public sealed class SoundPoolFilter : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060005CC RID: 1484 RVA: 0x0001B424 File Offset: 0x00019624
	public SoundPoolFilter()
	{
	}

	// Token: 0x060005CD RID: 1485 RVA: 0x0001B42C File Offset: 0x0001962C
	private void OnApplicationQuit()
	{
		global::SoundPool.quitting = true;
		this.quitting = true;
	}

	// Token: 0x060005CE RID: 1486 RVA: 0x0001B43C File Offset: 0x0001963C
	private void OnEnable()
	{
		if (this.awake)
		{
			global::SoundPool.enabled = true;
		}
	}

	// Token: 0x060005CF RID: 1487 RVA: 0x0001B450 File Offset: 0x00019650
	private void OnDisable()
	{
		if (this.awake)
		{
			global::SoundPool.enabled = false;
		}
	}

	// Token: 0x060005D0 RID: 1488 RVA: 0x0001B464 File Offset: 0x00019664
	private void OnPreCull()
	{
		global::SoundPool.Pump();
	}

	// Token: 0x060005D1 RID: 1489 RVA: 0x0001B46C File Offset: 0x0001966C
	private void OnDestroy()
	{
		if (global::SoundPoolFilter.instance == this)
		{
			this.awake = false;
			global::SoundPoolFilter.instance = null;
			global::SoundPool.enabled = false;
			if (this.quitting)
			{
				global::SoundPool.Drain();
			}
		}
	}

	// Token: 0x0400051F RID: 1311
	private static global::SoundPoolFilter instance;

	// Token: 0x04000520 RID: 1312
	private bool awake;

	// Token: 0x04000521 RID: 1313
	private bool quitting;
}
