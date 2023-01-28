using System;
using UnityEngine;

namespace Facepunch.Clocks.Counters.Unity
{
	// Token: 0x0200046B RID: 1131
	public struct ScaledTime
	{
		// Token: 0x06002713 RID: 10003 RVA: 0x00095CE0 File Offset: 0x00093EE0
		public void Start()
		{
			if (float.IsNegativeInfinity(this.startTime))
			{
				this.startTime = global::Facepunch.Clocks.Counters.Unity.ScaledTime.TIME_SOURCE.NOW;
				this.deductSeconds = 0.0;
				this.endTime = float.PositiveInfinity;
			}
			else if (!float.IsPositiveInfinity(this.endTime))
			{
				float num = this.endTime;
				this.endTime = float.PositiveInfinity;
				this.deductSeconds += (double)global::Facepunch.Clocks.Counters.Unity.ScaledTime.TIME_SOURCE.NOW - (double)num;
			}
		}

		// Token: 0x06002714 RID: 10004 RVA: 0x00095D60 File Offset: 0x00093F60
		public void Stop()
		{
			if (float.IsNegativeInfinity(this.startTime))
			{
				return;
			}
			if (float.IsPositiveInfinity(this.endTime))
			{
				this.endTime = global::Facepunch.Clocks.Counters.Unity.ScaledTime.TIME_SOURCE.NOW;
			}
		}

		// Token: 0x170008C5 RID: 2245
		// (get) Token: 0x06002715 RID: 10005 RVA: 0x00095D9C File Offset: 0x00093F9C
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
					return (double)global::Facepunch.Clocks.Counters.Unity.ScaledTime.TIME_SOURCE.NOW - this.deductSeconds - (double)this.startTime;
				}
				return (double)this.endTime - this.deductSeconds - (double)this.startTime;
			}
		}

		// Token: 0x170008C6 RID: 2246
		// (get) Token: 0x06002716 RID: 10006 RVA: 0x00095E04 File Offset: 0x00094004
		public long ElapsedMilliseconds
		{
			get
			{
				return (long)global::System.Math.Floor(this.ElapsedSeconds * 1000.0);
			}
		}

		// Token: 0x170008C7 RID: 2247
		// (get) Token: 0x06002717 RID: 10007 RVA: 0x00095E1C File Offset: 0x0009401C
		public global::System.TimeSpan Elapsed
		{
			get
			{
				if (float.IsNegativeInfinity(this.startTime))
				{
					return global::System.TimeSpan.Zero;
				}
				return global::System.TimeSpan.FromSeconds((double)((!float.IsPositiveInfinity(this.endTime)) ? this.endTime : global::Facepunch.Clocks.Counters.Unity.ScaledTime.TIME_SOURCE.NOW) - this.deductSeconds - (double)this.startTime);
			}
		}

		// Token: 0x170008C8 RID: 2248
		// (get) Token: 0x06002718 RID: 10008 RVA: 0x00095E74 File Offset: 0x00094074
		public bool IsRunning
		{
			get
			{
				return float.IsPositiveInfinity(this.endTime) && !float.IsNegativeInfinity(this.startTime);
			}
		}

		// Token: 0x170008C9 RID: 2249
		// (get) Token: 0x06002719 RID: 10009 RVA: 0x00095E98 File Offset: 0x00094098
		public static global::Facepunch.Clocks.Counters.Unity.ScaledTime Restart
		{
			get
			{
				global::Facepunch.Clocks.Counters.Unity.ScaledTime result;
				result.deductSeconds = 0.0;
				result.endTime = float.PositiveInfinity;
				result.startTime = global::Facepunch.Clocks.Counters.Unity.ScaledTime.TIME_SOURCE.NOW;
				return result;
			}
		}

		// Token: 0x170008CA RID: 2250
		// (get) Token: 0x0600271A RID: 10010 RVA: 0x00095ED0 File Offset: 0x000940D0
		public static global::Facepunch.Clocks.Counters.Unity.ScaledTime Reset
		{
			get
			{
				global::Facepunch.Clocks.Counters.Unity.ScaledTime result;
				result.deductSeconds = 0.0;
				result.endTime = float.PositiveInfinity;
				result.startTime = float.NegativeInfinity;
				return result;
			}
		}

		// Token: 0x040013CB RID: 5067
		private const double ZeroDeductions = 0.0;

		// Token: 0x040013CC RID: 5068
		private const double OneThousand = 1000.0;

		// Token: 0x040013CD RID: 5069
		private const double ZeroElapsed = 0.0;

		// Token: 0x040013CE RID: 5070
		private float startTime;

		// Token: 0x040013CF RID: 5071
		private float endTime;

		// Token: 0x040013D0 RID: 5072
		private double deductSeconds;

		// Token: 0x0200046C RID: 1132
		private static class TIME_SOURCE
		{
			// Token: 0x170008CB RID: 2251
			// (get) Token: 0x0600271B RID: 10011 RVA: 0x00095F08 File Offset: 0x00094108
			public static float NOW
			{
				get
				{
					return global::UnityEngine.Time.time;
				}
			}
		}
	}
}
