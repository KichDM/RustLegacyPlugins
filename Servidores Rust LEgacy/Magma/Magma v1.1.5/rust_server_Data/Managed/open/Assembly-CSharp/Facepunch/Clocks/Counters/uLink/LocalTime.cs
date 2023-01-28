using System;
using uLink;

namespace Facepunch.Clocks.Counters.uLink
{
	// Token: 0x0200046F RID: 1135
	public struct LocalTime
	{
		// Token: 0x06002725 RID: 10021 RVA: 0x00096140 File Offset: 0x00094340
		public void Start()
		{
			if (double.IsNegativeInfinity(this.startTime))
			{
				this.startTime = global::Facepunch.Clocks.Counters.uLink.LocalTime.TIME_SOURCE.NOW;
				this.deductSeconds = 0.0;
				this.endTime = double.PositiveInfinity;
			}
			else if (!double.IsPositiveInfinity(this.endTime))
			{
				double num = this.endTime;
				this.endTime = double.PositiveInfinity;
				this.deductSeconds += global::Facepunch.Clocks.Counters.uLink.LocalTime.TIME_SOURCE.NOW - num;
			}
		}

		// Token: 0x06002726 RID: 10022 RVA: 0x000961C8 File Offset: 0x000943C8
		public void Stop()
		{
			if (double.IsNegativeInfinity(this.startTime))
			{
				return;
			}
			if (double.IsPositiveInfinity(this.endTime))
			{
				this.endTime = global::Facepunch.Clocks.Counters.uLink.LocalTime.TIME_SOURCE.NOW;
			}
		}

		// Token: 0x170008D3 RID: 2259
		// (get) Token: 0x06002727 RID: 10023 RVA: 0x00096204 File Offset: 0x00094404
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
					return global::Facepunch.Clocks.Counters.uLink.LocalTime.TIME_SOURCE.NOW - this.deductSeconds - this.startTime;
				}
				return this.endTime - this.deductSeconds - this.startTime;
			}
		}

		// Token: 0x170008D4 RID: 2260
		// (get) Token: 0x06002728 RID: 10024 RVA: 0x00096268 File Offset: 0x00094468
		public long ElapsedMilliseconds
		{
			get
			{
				return (long)global::System.Math.Floor(this.ElapsedSeconds * 1000.0);
			}
		}

		// Token: 0x170008D5 RID: 2261
		// (get) Token: 0x06002729 RID: 10025 RVA: 0x00096280 File Offset: 0x00094480
		public global::System.TimeSpan Elapsed
		{
			get
			{
				if (double.IsNegativeInfinity(this.startTime))
				{
					return global::System.TimeSpan.Zero;
				}
				return global::System.TimeSpan.FromSeconds(((!double.IsPositiveInfinity(this.endTime)) ? this.endTime : global::Facepunch.Clocks.Counters.uLink.LocalTime.TIME_SOURCE.NOW) - this.deductSeconds - this.startTime);
			}
		}

		// Token: 0x170008D6 RID: 2262
		// (get) Token: 0x0600272A RID: 10026 RVA: 0x000962D8 File Offset: 0x000944D8
		public bool IsRunning
		{
			get
			{
				return double.IsPositiveInfinity(this.endTime) && !double.IsNegativeInfinity(this.startTime);
			}
		}

		// Token: 0x170008D7 RID: 2263
		// (get) Token: 0x0600272B RID: 10027 RVA: 0x000962FC File Offset: 0x000944FC
		public static global::Facepunch.Clocks.Counters.uLink.LocalTime Restart
		{
			get
			{
				global::Facepunch.Clocks.Counters.uLink.LocalTime result;
				result.deductSeconds = 0.0;
				result.endTime = double.PositiveInfinity;
				result.startTime = global::Facepunch.Clocks.Counters.uLink.LocalTime.TIME_SOURCE.NOW;
				return result;
			}
		}

		// Token: 0x170008D8 RID: 2264
		// (get) Token: 0x0600272C RID: 10028 RVA: 0x00096338 File Offset: 0x00094538
		public static global::Facepunch.Clocks.Counters.uLink.LocalTime Reset
		{
			get
			{
				global::Facepunch.Clocks.Counters.uLink.LocalTime result;
				result.deductSeconds = 0.0;
				result.endTime = double.PositiveInfinity;
				result.startTime = double.NegativeInfinity;
				return result;
			}
		}

		// Token: 0x040013D7 RID: 5079
		private const double ZeroDeductions = 0.0;

		// Token: 0x040013D8 RID: 5080
		private const double OneThousand = 1000.0;

		// Token: 0x040013D9 RID: 5081
		private const double ZeroElapsed = 0.0;

		// Token: 0x040013DA RID: 5082
		private double startTime;

		// Token: 0x040013DB RID: 5083
		private double endTime;

		// Token: 0x040013DC RID: 5084
		private double deductSeconds;

		// Token: 0x02000470 RID: 1136
		private static class TIME_SOURCE
		{
			// Token: 0x170008D9 RID: 2265
			// (get) Token: 0x0600272D RID: 10029 RVA: 0x00096378 File Offset: 0x00094578
			public static double NOW
			{
				get
				{
					return global::uLink.Network.localTime;
				}
			}
		}
	}
}
