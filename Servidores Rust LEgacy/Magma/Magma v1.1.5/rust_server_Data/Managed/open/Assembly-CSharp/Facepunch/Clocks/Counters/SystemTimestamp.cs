using System;
using System.Diagnostics;
using UnityEngine;

namespace Facepunch.Clocks.Counters
{
	// Token: 0x02000462 RID: 1122
	public struct SystemTimestamp
	{
		// Token: 0x060026CE RID: 9934 RVA: 0x00094EA0 File Offset: 0x000930A0
		public void Start()
		{
			if (double.IsNegativeInfinity(this.startTime))
			{
				this.startTime = global::Facepunch.Clocks.Counters.SystemTimestamp.TIME_SOURCE.NOW;
				this.deductSeconds = 0.0;
				this.endTime = double.PositiveInfinity;
			}
			else if (!double.IsPositiveInfinity(this.endTime))
			{
				double num = this.endTime;
				this.endTime = double.PositiveInfinity;
				this.deductSeconds += global::Facepunch.Clocks.Counters.SystemTimestamp.TIME_SOURCE.NOW - num;
			}
		}

		// Token: 0x060026CF RID: 9935 RVA: 0x00094F28 File Offset: 0x00093128
		public void Stop()
		{
			if (double.IsNegativeInfinity(this.startTime))
			{
				return;
			}
			if (double.IsPositiveInfinity(this.endTime))
			{
				this.endTime = global::Facepunch.Clocks.Counters.SystemTimestamp.TIME_SOURCE.NOW;
			}
		}

		// Token: 0x1700089F RID: 2207
		// (get) Token: 0x060026D0 RID: 9936 RVA: 0x00094F64 File Offset: 0x00093164
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
					return global::Facepunch.Clocks.Counters.SystemTimestamp.TIME_SOURCE.NOW - this.deductSeconds - this.startTime;
				}
				return this.endTime - this.deductSeconds - this.startTime;
			}
		}

		// Token: 0x170008A0 RID: 2208
		// (get) Token: 0x060026D1 RID: 9937 RVA: 0x00094FC8 File Offset: 0x000931C8
		public long ElapsedMilliseconds
		{
			get
			{
				return (long)global::System.Math.Floor(this.ElapsedSeconds * 1000.0);
			}
		}

		// Token: 0x170008A1 RID: 2209
		// (get) Token: 0x060026D2 RID: 9938 RVA: 0x00094FE0 File Offset: 0x000931E0
		public global::System.TimeSpan Elapsed
		{
			get
			{
				if (double.IsNegativeInfinity(this.startTime))
				{
					return global::System.TimeSpan.Zero;
				}
				return global::System.TimeSpan.FromSeconds(((!double.IsPositiveInfinity(this.endTime)) ? this.endTime : global::Facepunch.Clocks.Counters.SystemTimestamp.TIME_SOURCE.NOW) - this.deductSeconds - this.startTime);
			}
		}

		// Token: 0x170008A2 RID: 2210
		// (get) Token: 0x060026D3 RID: 9939 RVA: 0x00095038 File Offset: 0x00093238
		public bool IsRunning
		{
			get
			{
				return double.IsPositiveInfinity(this.endTime) && !double.IsNegativeInfinity(this.startTime);
			}
		}

		// Token: 0x170008A3 RID: 2211
		// (get) Token: 0x060026D4 RID: 9940 RVA: 0x0009505C File Offset: 0x0009325C
		public static global::Facepunch.Clocks.Counters.SystemTimestamp Restart
		{
			get
			{
				global::Facepunch.Clocks.Counters.SystemTimestamp result;
				result.deductSeconds = 0.0;
				result.endTime = double.PositiveInfinity;
				result.startTime = global::Facepunch.Clocks.Counters.SystemTimestamp.TIME_SOURCE.NOW;
				return result;
			}
		}

		// Token: 0x170008A4 RID: 2212
		// (get) Token: 0x060026D5 RID: 9941 RVA: 0x00095098 File Offset: 0x00093298
		public static global::Facepunch.Clocks.Counters.SystemTimestamp Reset
		{
			get
			{
				global::Facepunch.Clocks.Counters.SystemTimestamp result;
				result.deductSeconds = 0.0;
				result.endTime = double.PositiveInfinity;
				result.startTime = double.NegativeInfinity;
				return result;
			}
		}

		// Token: 0x040013AD RID: 5037
		private const double ZeroDeductions = 0.0;

		// Token: 0x040013AE RID: 5038
		private const double OneThousand = 1000.0;

		// Token: 0x040013AF RID: 5039
		private const double ZeroElapsed = 0.0;

		// Token: 0x040013B0 RID: 5040
		private double startTime;

		// Token: 0x040013B1 RID: 5041
		private double endTime;

		// Token: 0x040013B2 RID: 5042
		private double deductSeconds;

		// Token: 0x02000463 RID: 1123
		private static class TIME_SOURCE
		{
			// Token: 0x060026D6 RID: 9942 RVA: 0x000950D8 File Offset: 0x000932D8
			static TIME_SOURCE()
			{
				global::Facepunch.Clocks.Counters.SystemTimestamp.TIME_SOURCE.ToSeconds = (double)(1m / global::Facepunch.Clocks.Counters.SystemTimestamp.TIME_SOURCE.Frequency);
				string text = string.Format("SystemTimestampWatch settings={{IsHighResolution={0},Frequency={1},ToSecond={2}}}", global::Facepunch.Clocks.Counters.SystemTimestamp.TIME_SOURCE.IsHighResolution, global::Facepunch.Clocks.Counters.SystemTimestamp.TIME_SOURCE.Frequency, global::Facepunch.Clocks.Counters.SystemTimestamp.TIME_SOURCE.ToSeconds);
				if (!global::Facepunch.Clocks.Counters.SystemTimestamp.TIME_SOURCE.IsHighResolution)
				{
					global::UnityEngine.Debug.LogWarning(text);
				}
			}

			// Token: 0x170008A5 RID: 2213
			// (get) Token: 0x060026D7 RID: 9943 RVA: 0x0009515C File Offset: 0x0009335C
			public static double NOW
			{
				get
				{
					return (double)(global::System.Diagnostics.Stopwatch.GetTimestamp() - global::Facepunch.Clocks.Counters.SystemTimestamp.TIME_SOURCE.ThenTimestamp) * global::Facepunch.Clocks.Counters.SystemTimestamp.TIME_SOURCE.ToSeconds;
				}
			}

			// Token: 0x040013B3 RID: 5043
			private static readonly long ThenTimestamp = global::System.Diagnostics.Stopwatch.GetTimestamp();

			// Token: 0x040013B4 RID: 5044
			private static readonly long Frequency = global::System.Diagnostics.Stopwatch.Frequency;

			// Token: 0x040013B5 RID: 5045
			private static readonly double ToSeconds;

			// Token: 0x040013B6 RID: 5046
			private static readonly bool IsHighResolution = global::System.Diagnostics.Stopwatch.IsHighResolution;
		}
	}
}
