using System;
using uLink;

namespace Facepunch.Clocks.Counters.uLink
{
	// Token: 0x02000471 RID: 1137
	public struct NetworkTime
	{
		// Token: 0x0600272E RID: 10030 RVA: 0x00096380 File Offset: 0x00094580
		public void Start()
		{
			if (double.IsNegativeInfinity(this.startTime))
			{
				this.startTime = global::Facepunch.Clocks.Counters.uLink.NetworkTime.TIME_SOURCE.NOW;
				this.deductSeconds = 0.0;
				this.endTime = double.PositiveInfinity;
			}
			else if (!double.IsPositiveInfinity(this.endTime))
			{
				double num = this.endTime;
				this.endTime = double.PositiveInfinity;
				this.deductSeconds += global::Facepunch.Clocks.Counters.uLink.NetworkTime.TIME_SOURCE.NOW - num;
			}
		}

		// Token: 0x0600272F RID: 10031 RVA: 0x00096408 File Offset: 0x00094608
		public void Stop()
		{
			if (double.IsNegativeInfinity(this.startTime))
			{
				return;
			}
			if (double.IsPositiveInfinity(this.endTime))
			{
				this.endTime = global::Facepunch.Clocks.Counters.uLink.NetworkTime.TIME_SOURCE.NOW;
			}
		}

		// Token: 0x170008DA RID: 2266
		// (get) Token: 0x06002730 RID: 10032 RVA: 0x00096444 File Offset: 0x00094644
		public double ElapsedSeconds
		{
			get
			{
				if (double.IsNegativeInfinity(this.startTime))
				{
					return 0.0;
				}
				if (double.IsPositiveInfinity(this.endTime))
				{
					return global::Facepunch.Clocks.Counters.uLink.NetworkTime.TIME_SOURCE.NOW - this.deductSeconds - this.startTime;
				}
				return this.endTime - this.deductSeconds - this.startTime;
			}
		}

		// Token: 0x170008DB RID: 2267
		// (get) Token: 0x06002731 RID: 10033 RVA: 0x000964A8 File Offset: 0x000946A8
		public long ElapsedMilliseconds
		{
			get
			{
				return (long)global::System.Math.Floor(this.ElapsedSeconds * 1000.0);
			}
		}

		// Token: 0x170008DC RID: 2268
		// (get) Token: 0x06002732 RID: 10034 RVA: 0x000964C0 File Offset: 0x000946C0
		public global::System.TimeSpan Elapsed
		{
			get
			{
				if (double.IsNegativeInfinity(this.startTime))
				{
					return global::System.TimeSpan.Zero;
				}
				return global::System.TimeSpan.FromSeconds(((!double.IsPositiveInfinity(this.endTime)) ? this.endTime : global::Facepunch.Clocks.Counters.uLink.NetworkTime.TIME_SOURCE.NOW) - this.deductSeconds - this.startTime);
			}
		}

		// Token: 0x170008DD RID: 2269
		// (get) Token: 0x06002733 RID: 10035 RVA: 0x00096518 File Offset: 0x00094718
		public bool IsRunning
		{
			get
			{
				return double.IsPositiveInfinity(this.endTime) && !double.IsNegativeInfinity(this.startTime);
			}
		}

		// Token: 0x170008DE RID: 2270
		// (get) Token: 0x06002734 RID: 10036 RVA: 0x0009653C File Offset: 0x0009473C
		public static global::Facepunch.Clocks.Counters.uLink.NetworkTime Restart
		{
			get
			{
				global::Facepunch.Clocks.Counters.uLink.NetworkTime result;
				result.deductSeconds = 0.0;
				result.endTime = double.PositiveInfinity;
				result.startTime = global::Facepunch.Clocks.Counters.uLink.NetworkTime.TIME_SOURCE.NOW;
				return result;
			}
		}

		// Token: 0x170008DF RID: 2271
		// (get) Token: 0x06002735 RID: 10037 RVA: 0x00096578 File Offset: 0x00094778
		public static global::Facepunch.Clocks.Counters.uLink.NetworkTime Reset
		{
			get
			{
				global::Facepunch.Clocks.Counters.uLink.NetworkTime result;
				result.deductSeconds = 0.0;
				result.endTime = double.PositiveInfinity;
				result.startTime = double.NegativeInfinity;
				return result;
			}
		}

		// Token: 0x040013DD RID: 5085
		private const double ZeroDeductions = 0.0;

		// Token: 0x040013DE RID: 5086
		private const double OneThousand = 1000.0;

		// Token: 0x040013DF RID: 5087
		private const double ZeroElapsed = 0.0;

		// Token: 0x040013E0 RID: 5088
		private double startTime;

		// Token: 0x040013E1 RID: 5089
		private double endTime;

		// Token: 0x040013E2 RID: 5090
		private double deductSeconds;

		// Token: 0x02000472 RID: 1138
		private static class TIME_SOURCE
		{
			// Token: 0x170008E0 RID: 2272
			// (get) Token: 0x06002736 RID: 10038 RVA: 0x000965B8 File Offset: 0x000947B8
			public static double NOW
			{
				get
				{
					return global::uLink.Network.time;
				}
			}
		}
	}
}
