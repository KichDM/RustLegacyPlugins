using System;

namespace Facepunch.Clocks.Counters
{
	// Token: 0x02000460 RID: 1120
	public struct DateTimeWatch
	{
		// Token: 0x060026C4 RID: 9924 RVA: 0x00094BE4 File Offset: 0x00092DE4
		public void Start()
		{
			if (double.IsNegativeInfinity(this.startTime))
			{
				this.startTime = global::Facepunch.Clocks.Counters.DateTimeWatch.TIME_SOURCE.NOW;
				this.deductSeconds = 0.0;
				this.endTime = double.PositiveInfinity;
			}
			else if (!double.IsPositiveInfinity(this.endTime))
			{
				double num = this.endTime;
				this.endTime = double.PositiveInfinity;
				this.deductSeconds += global::Facepunch.Clocks.Counters.DateTimeWatch.TIME_SOURCE.NOW - num;
			}
		}

		// Token: 0x060026C5 RID: 9925 RVA: 0x00094C6C File Offset: 0x00092E6C
		public void Stop()
		{
			if (double.IsNegativeInfinity(this.startTime))
			{
				return;
			}
			if (double.IsPositiveInfinity(this.endTime))
			{
				this.endTime = global::Facepunch.Clocks.Counters.DateTimeWatch.TIME_SOURCE.NOW;
			}
		}

		// Token: 0x17000898 RID: 2200
		// (get) Token: 0x060026C6 RID: 9926 RVA: 0x00094CA8 File Offset: 0x00092EA8
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
					return global::Facepunch.Clocks.Counters.DateTimeWatch.TIME_SOURCE.NOW - this.deductSeconds - this.startTime;
				}
				return this.endTime - this.deductSeconds - this.startTime;
			}
		}

		// Token: 0x17000899 RID: 2201
		// (get) Token: 0x060026C7 RID: 9927 RVA: 0x00094D0C File Offset: 0x00092F0C
		public long ElapsedMilliseconds
		{
			get
			{
				return (long)global::System.Math.Floor(this.ElapsedSeconds * 1000.0);
			}
		}

		// Token: 0x1700089A RID: 2202
		// (get) Token: 0x060026C8 RID: 9928 RVA: 0x00094D24 File Offset: 0x00092F24
		public global::System.TimeSpan Elapsed
		{
			get
			{
				if (double.IsNegativeInfinity(this.startTime))
				{
					return global::System.TimeSpan.Zero;
				}
				return global::System.TimeSpan.FromSeconds(((!double.IsPositiveInfinity(this.endTime)) ? this.endTime : global::Facepunch.Clocks.Counters.DateTimeWatch.TIME_SOURCE.NOW) - this.deductSeconds - this.startTime);
			}
		}

		// Token: 0x1700089B RID: 2203
		// (get) Token: 0x060026C9 RID: 9929 RVA: 0x00094D7C File Offset: 0x00092F7C
		public bool IsRunning
		{
			get
			{
				return double.IsPositiveInfinity(this.endTime) && !double.IsNegativeInfinity(this.startTime);
			}
		}

		// Token: 0x1700089C RID: 2204
		// (get) Token: 0x060026CA RID: 9930 RVA: 0x00094DA0 File Offset: 0x00092FA0
		public static global::Facepunch.Clocks.Counters.DateTimeWatch Restart
		{
			get
			{
				global::Facepunch.Clocks.Counters.DateTimeWatch result;
				result.deductSeconds = 0.0;
				result.endTime = double.PositiveInfinity;
				result.startTime = global::Facepunch.Clocks.Counters.DateTimeWatch.TIME_SOURCE.NOW;
				return result;
			}
		}

		// Token: 0x1700089D RID: 2205
		// (get) Token: 0x060026CB RID: 9931 RVA: 0x00094DDC File Offset: 0x00092FDC
		public static global::Facepunch.Clocks.Counters.DateTimeWatch Reset
		{
			get
			{
				global::Facepunch.Clocks.Counters.DateTimeWatch result;
				result.deductSeconds = 0.0;
				result.endTime = double.PositiveInfinity;
				result.startTime = double.NegativeInfinity;
				return result;
			}
		}

		// Token: 0x040013A4 RID: 5028
		private const double ZeroDeductions = 0.0;

		// Token: 0x040013A5 RID: 5029
		private const double OneThousand = 1000.0;

		// Token: 0x040013A6 RID: 5030
		private const double ZeroElapsed = 0.0;

		// Token: 0x040013A7 RID: 5031
		private double startTime;

		// Token: 0x040013A8 RID: 5032
		private double endTime;

		// Token: 0x040013A9 RID: 5033
		private double deductSeconds;

		// Token: 0x02000461 RID: 1121
		private static class TIME_SOURCE
		{
			// Token: 0x060026CC RID: 9932 RVA: 0x00094E1C File Offset: 0x0009301C
			static TIME_SOURCE()
			{
			}

			// Token: 0x1700089E RID: 2206
			// (get) Token: 0x060026CD RID: 9933 RVA: 0x00094E5C File Offset: 0x0009305C
			public static double NOW
			{
				get
				{
					return (double)((global::System.DateTime.Now.Ticks - global::Facepunch.Clocks.Counters.DateTimeWatch.TIME_SOURCE.ThenTicks) * 0.0000001000000000000000000000m);
				}
			}

			// Token: 0x040013AA RID: 5034
			private const decimal kTickToSecond = 0.0000001000000000000000000000m;

			// Token: 0x040013AB RID: 5035
			public static readonly global::System.DateTime Then = global::System.DateTime.Now;

			// Token: 0x040013AC RID: 5036
			public static readonly long ThenTicks = global::Facepunch.Clocks.Counters.DateTimeWatch.TIME_SOURCE.Then.Ticks;
		}
	}
}
