using System;
using UnityEngine;

// Token: 0x02000897 RID: 2199
public abstract class dfTweenPlayableBase : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004C1C RID: 19484 RVA: 0x0011E130 File Offset: 0x0011C330
	protected dfTweenPlayableBase()
	{
	}

	// Token: 0x17000E32 RID: 3634
	// (get) Token: 0x06004C1D RID: 19485
	// (set) Token: 0x06004C1E RID: 19486
	public abstract string TweenName { get; set; }

	// Token: 0x17000E33 RID: 3635
	// (get) Token: 0x06004C1F RID: 19487
	public abstract bool IsPlaying { get; }

	// Token: 0x06004C20 RID: 19488
	public abstract void Play();

	// Token: 0x06004C21 RID: 19489
	public abstract void Stop();

	// Token: 0x06004C22 RID: 19490
	public abstract void Reset();

	// Token: 0x06004C23 RID: 19491 RVA: 0x0011E138 File Offset: 0x0011C338
	public void Enable()
	{
		base.enabled = true;
	}

	// Token: 0x06004C24 RID: 19492 RVA: 0x0011E144 File Offset: 0x0011C344
	public void Disable()
	{
		base.enabled = false;
	}

	// Token: 0x06004C25 RID: 19493 RVA: 0x0011E150 File Offset: 0x0011C350
	public override string ToString()
	{
		return this.TweenName + " - " + base.ToString();
	}
}
