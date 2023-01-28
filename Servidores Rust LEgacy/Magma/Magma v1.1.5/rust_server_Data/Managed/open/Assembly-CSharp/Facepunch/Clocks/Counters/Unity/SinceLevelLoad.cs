using System;
using UnityEngine;

namespace Facepunch.Clocks.Counters.Unity
{
	// Token: 0x0200046D RID: 1133
	public struct SinceLevelLoad
	{
		// Token: 0x0600271C RID: 10012 RVA: 0x00095F10 File Offset: 0x00094110
		public void Start()
		{
			if (float.IsNegativeInfinity(this.startTime))
			{
				this.startTime = global::Facepunch.Clocks.Counters.Unity.SinceLevelLoad.TIME_SOURCE.NOW;
				this.deductSeconds = 0.0;
				this.endTime = float.PositiveInfinity;
			}
			else if (!float.IsPositiveInfinity(this.endTime))
			{
				float num = this.endTime;
				this.endTime = float.PositiveInfinity;
				this.deductSeconds += (double)global::Facepunch.Clocks.Counters.Unity.SinceLevelLoad.TIME_SOURCE.NOW - (double)num;
			}
		}

		// Token: 0x0600271D RID: 10013 RVA: 0x00095F90 File Offset: 0x00094190
		public void Stop()
		{
			if (float.IsNegativeInfinity(this.startTime))
			{
				return;
			}
			if (float.IsPositiveInfinity(this.endTime))
			{
				this.endTime = global::Facepunch.Clocks.Counters.Unity.SinceLevelLoad.TIME_SOURCE.NOW;
			}
		}

		// Token: 0x170008CC RID: 2252
		// (get) Token: 0x0600271E RID: 10014 RVA: 0x00095FCC File Offset: 0x000941CC
		public double ElapsedSeconds
		{
			get
			{
				if (float.IsNegativeInfinity(this.startTime))
				{
					return 0.0;
				}
				if (float.IsPositiveInfinity(this.endTime))
				{
					return (double)global::Facepunch.Clocks.Counters.Unity.SinceLevelLoad.TIME_SOURCE.NOW - this.deductSeconds - (double)this.startTime;
				}
				return (double)this.endTime - this.deductSeconds - (double)this.startTime;
			}
		}

		// Token: 0x170008CD RID: 2253
		// (get) Token: 0x0600271F RID: 10015 RVA: 0x00096034 File Offset: 0x00094234
		public long ElapsedMilliseconds
		{
			get
			{
				return (long)global::System.Math.Floor(this.ElapsedSeconds * 1000.0);
			}
		}

		// Token: 0x170008CE RID: 2254
		// (get) Token: 0x06002720 RID: 10016 RVA: 0x0009604C File Offset: 0x0009424C
		public global::System.TimeSpan Elapsed
		{
			get
			{
				if (float.IsNegativeInfinity(this.startTime))
				{
					return global::System.TimeSpan.Zero;
				}
				return global::System.TimeSpan.FromSeconds((double)((!float.IsPositiveInfinity(this.endTime)) ? this.endTime : global::Facepunch.Clocks.Counters.Unity.SinceLevelLoad.TIME_SOURCE.NOW) - this.deductSeconds - (double)this.startTime);
			}
		}

		// Token: 0x170008CF RID: 2255
		// (get) Token: 0x06002721 RID: 10017 RVA: 0x000960A4 File Offset: 0x000942A4
		public bool IsRunning
		{
			get
			{
				return float.IsPositiveInfinity(this.endTime) && !float.IsNegativeInfinity(this.startTime);
			}
		}

		// Token: 0x170008D0 RID: 2256
		// (get) Token: 0x06002722 RID: 10018 RVA: 0x000960C8 File Offset: 0x000942C8
		public static global::Facepunch.Clocks.Counters.Unity.SinceLevelLoad Restart
		{
			get
			{
				global::Facepunch.Clocks.Counters.Unity.SinceLevelLoad result;
				result.deductSeconds = 0.0;
				result.endTime = float.PositiveInfinity;
				result.startTime = global::Facepunch.Clocks.Counters.Unity.SinceLevelLoad.TIME_SOURCE.NOW;
				return result;
			}
		}

		// Token: 0x170008D1 RID: 2257
		// (get) Token: 0x06002723 RID: 10019 RVA: 0x00096100 File Offset: 0x00094300
		public static global::Facepunch.Clocks.Counters.Unity.SinceLevelLoad Reset
		{
			get
			{
				global::Facepunch.Clocks.Counters.Unity.SinceLevelLoad result;
				result.deductSeconds = 0.0;
				result.endTime = float.PositiveInfinity;
				result.startTime = float.NegativeInfinity;
				return result;
			}
		}

		// Token: 0x040013D1 RID: 5073
		private const double ZeroDeductions = 0.0;

		// Token: 0x040013D2 RID: 5074
		private const double OneThousand = 1000.0;

		// Token: 0x040013D3 RID: 5075
		private const double ZeroElapsed = 0.0;

		// Token: 0x040013D4 RID: 5076
		private float startTime;

		// Token: 0x040013D5 RID: 5077
		private float endTime;

		// Token: 0x040013D6 RID: 5078
		private double deductSeconds;

		// Token: 0x0200046E RID: 1134
		private static class TIME_SOURCE
		{
			// Token: 0x170008D2 RID: 2258
			// (get) Token: 0x06002724 RID: 10020 RVA: 0x00096138 File Offset: 0x00094338
			public static float NOW
			{
				get
				{
					return global::UnityEngine.Time.timeSinceLevelLoad;
				}
			}
		}
	}
}
