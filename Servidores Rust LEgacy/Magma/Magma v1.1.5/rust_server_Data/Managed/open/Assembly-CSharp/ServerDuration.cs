using System;

// Token: 0x0200040A RID: 1034
public struct ServerDuration
{
	// Token: 0x060023F3 RID: 9203 RVA: 0x00089744 File Offset: 0x00087944
	internal void MakeFinal()
	{
		if (!this.final)
		{
			ulong overheadDurationInMillis = global::NetCull.overheadDurationInMillis;
			if (overheadDurationInMillis > this.active)
			{
				this.active = overheadDurationInMillis;
			}
			if (this.active > this.overhead)
			{
				this.overhead = this.active;
			}
			this.active = 0UL;
			this.final = true;
		}
	}

	// Token: 0x1700081A RID: 2074
	// (get) Token: 0x060023F4 RID: 9204 RVA: 0x000897A4 File Offset: 0x000879A4
	public ulong endTime
	{
		get
		{
			if (this.final || this.active <= this.overhead)
			{
				return this.time + this.frame + this.overhead;
			}
			return this.time + this.frame + this.active;
		}
	}

	// Token: 0x1700081B RID: 2075
	// (get) Token: 0x060023F5 RID: 9205 RVA: 0x000897F8 File Offset: 0x000879F8
	public static global::ServerDuration Now
	{
		get
		{
			global::ServerDuration result;
			result.time = global::NetCull.timeInMillis;
			result.frame = global::NetCull.frameDurationInMillis;
			result.overhead = global::NetCull.overheadDurationInMillis;
			if (global::NetCull.Time.Updating)
			{
				result.final = false;
				result.active = result.time - global::NetCull.Time.PreUpdateTimestamp.Value;
			}
			else
			{
				result.final = true;
				result.active = 0UL;
			}
			return result;
		}
	}

	// Token: 0x040011E5 RID: 4581
	[global::System.NonSerialized]
	public ulong time;

	// Token: 0x040011E6 RID: 4582
	[global::System.NonSerialized]
	public ulong overhead;

	// Token: 0x040011E7 RID: 4583
	[global::System.NonSerialized]
	public ulong active;

	// Token: 0x040011E8 RID: 4584
	[global::System.NonSerialized]
	public ulong frame;

	// Token: 0x040011E9 RID: 4585
	[global::System.NonSerialized]
	public bool final;
}
