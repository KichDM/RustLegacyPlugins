using System;

// Token: 0x02000638 RID: 1592
public struct CraftingSession
{
	// Token: 0x17000A7E RID: 2686
	// (get) Token: 0x0600327A RID: 12922 RVA: 0x000C11DC File Offset: 0x000BF3DC
	// (set) Token: 0x0600327B RID: 12923 RVA: 0x000C11E4 File Offset: 0x000BF3E4
	public float progressPerSec
	{
		get
		{
			return this._progressPerSec;
		}
		set
		{
			this._progressPerSec = value;
		}
	}

	// Token: 0x17000A7F RID: 2687
	// (get) Token: 0x0600327C RID: 12924 RVA: 0x000C11F0 File Offset: 0x000BF3F0
	public float remainingSeconds
	{
		get
		{
			return (this.duration - this.progressSeconds) / this.progressPerSec;
		}
	}

	// Token: 0x17000A80 RID: 2688
	// (get) Token: 0x0600327D RID: 12925 RVA: 0x000C1208 File Offset: 0x000BF408
	public double percentComplete
	{
		get
		{
			if (this.inProgress)
			{
				return (double)(this.progressSeconds / this.duration);
			}
			return 0.0;
		}
	}

	// Token: 0x0600327E RID: 12926 RVA: 0x000C1230 File Offset: 0x000BF430
	public bool Restart(global::Inventory inventory, int amount, global::BlueprintDataBlock blueprint, ulong startTimeMillis)
	{
		if (!blueprint || !blueprint.CanWork(amount, inventory))
		{
			this = default(global::CraftingSession);
			return false;
		}
		this.blueprint = blueprint;
		this.startTime = (float)(startTimeMillis / 1000.0);
		this.duration = blueprint.craftingDuration * (float)amount;
		this.progressPerSec = 1f;
		this.progressSeconds = 0f;
		this.amount = amount;
		this.inProgress = true;
		return true;
	}

	// Token: 0x04001C1C RID: 7196
	[global::System.NonSerialized]
	public global::BlueprintDataBlock blueprint;

	// Token: 0x04001C1D RID: 7197
	[global::System.NonSerialized]
	public float startTime;

	// Token: 0x04001C1E RID: 7198
	[global::System.NonSerialized]
	public float duration;

	// Token: 0x04001C1F RID: 7199
	[global::System.NonSerialized]
	public float progressSeconds;

	// Token: 0x04001C20 RID: 7200
	[global::System.NonSerialized]
	public float _progressPerSec;

	// Token: 0x04001C21 RID: 7201
	[global::System.NonSerialized]
	public ulong startTimeMillis;

	// Token: 0x04001C22 RID: 7202
	[global::System.NonSerialized]
	public ulong durationMillis;

	// Token: 0x04001C23 RID: 7203
	[global::System.NonSerialized]
	public ulong secondsCraftingFor;

	// Token: 0x04001C24 RID: 7204
	[global::System.NonSerialized]
	public int amount;

	// Token: 0x04001C25 RID: 7205
	[global::System.NonSerialized]
	public bool inProgress;
}
