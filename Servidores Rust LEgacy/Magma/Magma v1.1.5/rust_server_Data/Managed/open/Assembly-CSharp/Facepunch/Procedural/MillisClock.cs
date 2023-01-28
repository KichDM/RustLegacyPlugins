using System;
using UnityEngine;

namespace Facepunch.Procedural
{
	// Token: 0x02000609 RID: 1545
	public struct MillisClock
	{
		// Token: 0x17000A4A RID: 2634
		// (get) Token: 0x0600315B RID: 12635 RVA: 0x000BD064 File Offset: 0x000BB264
		public global::Facepunch.Procedural.ClockStatus clockStatus
		{
			get
			{
				return (!this.once) ? global::Facepunch.Procedural.ClockStatus.Unset : ((this.remain != 0UL) ? ((this.remain >= this.duration) ? global::Facepunch.Procedural.ClockStatus.Negative : global::Facepunch.Procedural.ClockStatus.WillElapse) : ((this.duration != 0UL) ? global::Facepunch.Procedural.ClockStatus.Elapsed : global::Facepunch.Procedural.ClockStatus.Unset));
			}
		}

		// Token: 0x0600315C RID: 12636 RVA: 0x000BD0BC File Offset: 0x000BB2BC
		public global::Facepunch.Procedural.ClockStatus ResetRandomDurationSeconds(double secondsMin, double secondsMax)
		{
			return this.ResetDurationSeconds(secondsMin + (double)global::UnityEngine.Random.value * (secondsMax - secondsMin));
		}

		// Token: 0x0600315D RID: 12637 RVA: 0x000BD0D0 File Offset: 0x000BB2D0
		public global::Facepunch.Procedural.ClockStatus ResetDurationSeconds(double seconds)
		{
			return this.ResetDurationMillis((ulong)global::System.Math.Ceiling(seconds * 1000.0));
		}

		// Token: 0x0600315E RID: 12638 RVA: 0x000BD0EC File Offset: 0x000BB2EC
		public global::Facepunch.Procedural.ClockStatus ResetDurationMillis(ulong millis)
		{
			if (millis <= 1UL)
			{
				this.SetImmediate();
				return global::Facepunch.Procedural.ClockStatus.DidElapse;
			}
			this.once = true;
			this.duration = millis;
			this.remain = millis;
			return global::Facepunch.Procedural.ClockStatus.WillElapse;
		}

		// Token: 0x17000A4B RID: 2635
		// (get) Token: 0x0600315F RID: 12639 RVA: 0x000BD124 File Offset: 0x000BB324
		public float percentf
		{
			get
			{
				return (this.remain != 0UL) ? ((this.remain < this.duration) ? ((float)(1.0 - this.remain / this.duration)) : 0f) : 1f;
			}
		}

		// Token: 0x17000A4C RID: 2636
		// (get) Token: 0x06003160 RID: 12640 RVA: 0x000BD180 File Offset: 0x000BB380
		public double percent
		{
			get
			{
				return (this.remain != 0UL) ? ((this.remain < this.duration) ? (1.0 - this.remain / this.duration) : 0.0) : 1.0;
			}
		}

		// Token: 0x06003161 RID: 12641 RVA: 0x000BD1E0 File Offset: 0x000BB3E0
		public void SetImmediate()
		{
			this.once = true;
			this.remain = 1UL;
			this.duration = 2UL;
		}

		// Token: 0x06003162 RID: 12642 RVA: 0x000BD1FC File Offset: 0x000BB3FC
		public bool IntegrateTime_Reached(ulong millis)
		{
			return (byte)(this.IntegrateTime(millis) & global::Facepunch.Procedural.Integration.Stationary) == 1;
		}

		// Token: 0x06003163 RID: 12643 RVA: 0x000BD20C File Offset: 0x000BB40C
		public global::Facepunch.Procedural.Integration IntegrateTime(ulong millis)
		{
			if (!this.once || this.remain == 0UL || this.duration == 0UL || millis == 0UL)
			{
				return global::Facepunch.Procedural.Integration.Stationary;
			}
			if (this.remain <= millis)
			{
				this.remain = 0UL;
				return global::Facepunch.Procedural.Integration.Stationary;
			}
			this.remain -= millis;
			if (this.remain < this.duration)
			{
				return global::Facepunch.Procedural.Integration.Moved;
			}
			return global::Facepunch.Procedural.Integration.MovedDestination;
		}

		// Token: 0x04001B8A RID: 7050
		[global::System.NonSerialized]
		public ulong remain;

		// Token: 0x04001B8B RID: 7051
		[global::System.NonSerialized]
		public ulong duration;

		// Token: 0x04001B8C RID: 7052
		[global::System.NonSerialized]
		public bool once;
	}
}
