using System;
using UnityEngine;

namespace Facepunch.Clocks.Counters.Unity
{
	// Token: 0x02000465 RID: 1125
	public struct FixedTime
	{
		// Token: 0x060026F8 RID: 9976 RVA: 0x00095640 File Offset: 0x00093840
		public void Start()
		{
			if (float.IsNegativeInfinity(this.startTime))
			{
				this.startTime = global::Facepunch.Clocks.Counters.Unity.FixedTime.TIME_SOURCE.NOW;
				this.deductSeconds = 0.0;
				this.endTime = float.PositiveInfinity;
			}
			else if (!float.IsPositiveInfinity(this.endTime))
			{
				float num = this.endTime;
				this.endTime = float.PositiveInfinity;
				this.deductSeconds += (double)global::Facepunch.Clocks.Counters.Unity.FixedTime.TIME_SOURCE.NOW - (double)num;
			}
		}

		// Token: 0x060026F9 RID: 9977 RVA: 0x000956C0 File Offset: 0x000938C0
		public void Stop()
		{
			if (float.IsNegativeInfinity(this.startTime))
			{
				return;
			}
			if (float.IsPositiveInfinity(this.endTime))
			{
				this.endTime = global::Facepunch.Clocks.Counters.Unity.FixedTime.TIME_SOURCE.NOW;
			}
		}

		// Token: 0x170008B0 RID: 2224
		// (get) Token: 0x060026FA RID: 9978 RVA: 0x000956FC File Offset: 0x000938FC
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
					return (double)global::Facepunch.Clocks.Counters.Unity.FixedTime.TIME_SOURCE.NOW - this.deductSeconds - (double)this.startTime;
				}
				return (double)this.endTime - this.deductSeconds - (double)this.startTime;
			}
		}

		// Token: 0x170008B1 RID: 2225
		// (get) Token: 0x060026FB RID: 9979 RVA: 0x00095764 File Offset: 0x00093964
		public long ElapsedMilliseconds
		{
			get
			{
				return (long)global::System.Math.Floor(this.ElapsedSeconds * 1000.0);
			}
		}

		// Token: 0x170008B2 RID: 2226
		// (get) Token: 0x060026FC RID: 9980 RVA: 0x0009577C File Offset: 0x0009397C
		public global::System.TimeSpan Elapsed
		{
			get
			{
				if (float.IsNegativeInfinity(this.startTime))
				{
					return global::System.TimeSpan.Zero;
				}
				return global::System.TimeSpan.FromSeconds((double)((!float.IsPositiveInfinity(this.endTime)) ? this.endTime : global::Facepunch.Clocks.Counters.Unity.FixedTime.TIME_SOURCE.NOW) - this.deductSeconds - (double)this.startTime);
			}
		}

		// Token: 0x170008B3 RID: 2227
		// (get) Token: 0x060026FD RID: 9981 RVA: 0x000957D4 File Offset: 0x000939D4
		public bool IsRunning
		{
			get
			{
				return float.IsPositiveInfinity(this.endTime) && !float.IsNegativeInfinity(this.startTime);
			}
		}

		// Token: 0x170008B4 RID: 2228
		// (get) Token: 0x060026FE RID: 9982 RVA: 0x000957F8 File Offset: 0x000939F8
		public static global::Facepunch.Clocks.Counters.Unity.FixedTime Restart
		{
			get
			{
				global::Facepunch.Clocks.Counters.Unity.FixedTime result;
				result.deductSeconds = 0.0;
				result.endTime = float.PositiveInfinity;
				result.startTime = global::Facepunch.Clocks.Counters.Unity.FixedTime.TIME_SOURCE.NOW;
				return result;
			}
		}

		// Token: 0x170008B5 RID: 2229
		// (get) Token: 0x060026FF RID: 9983 RVA: 0x00095830 File Offset: 0x00093A30
		public static global::Facepunch.Clocks.Counters.Unity.FixedTime Reset
		{
			get
			{
				global::Facepunch.Clocks.Counters.Unity.FixedTime result;
				result.deductSeconds = 0.0;
				result.endTime = float.PositiveInfinity;
				result.startTime = float.NegativeInfinity;
				return result;
			}
		}

		// Token: 0x040013B9 RID: 5049
		private const double ZeroDeductions = 0.0;

		// Token: 0x040013BA RID: 5050
		private const double OneThousand = 1000.0;

		// Token: 0x040013BB RID: 5051
		private const double ZeroElapsed = 0.0;

		// Token: 0x040013BC RID: 5052
		private float startTime;

		// Token: 0x040013BD RID: 5053
		private float endTime;

		// Token: 0x040013BE RID: 5054
		private double deductSeconds;

		// Token: 0x02000466 RID: 1126
		private static class TIME_SOURCE
		{
			// Token: 0x170008B6 RID: 2230
			// (get) Token: 0x06002700 RID: 9984 RVA: 0x00095868 File Offset: 0x00093A68
			public static float NOW
			{
				get
				{
					return global::UnityEngine.Time.fixedTime;
				}
			}
		}
	}
}
