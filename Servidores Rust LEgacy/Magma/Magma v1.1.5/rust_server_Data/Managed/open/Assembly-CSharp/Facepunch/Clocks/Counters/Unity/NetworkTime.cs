using System;
using UnityEngine;

namespace Facepunch.Clocks.Counters.Unity
{
	// Token: 0x02000467 RID: 1127
	public struct NetworkTime
	{
		// Token: 0x06002701 RID: 9985 RVA: 0x00095870 File Offset: 0x00093A70
		public void Start()
		{
			if (double.IsNegativeInfinity(this.startTime))
			{
				this.startTime = global::Facepunch.Clocks.Counters.Unity.NetworkTime.TIME_SOURCE.NOW;
				this.deductSeconds = 0.0;
				this.endTime = double.PositiveInfinity;
			}
			else if (!double.IsPositiveInfinity(this.endTime))
			{
				double num = this.endTime;
				this.endTime = double.PositiveInfinity;
				this.deductSeconds += global::Facepunch.Clocks.Counters.Unity.NetworkTime.TIME_SOURCE.NOW - num;
			}
		}

		// Token: 0x06002702 RID: 9986 RVA: 0x000958F8 File Offset: 0x00093AF8
		public void Stop()
		{
			if (double.IsNegativeInfinity(this.startTime))
			{
				return;
			}
			if (double.IsPositiveInfinity(this.endTime))
			{
				this.endTime = global::Facepunch.Clocks.Counters.Unity.NetworkTime.TIME_SOURCE.NOW;
			}
		}

		// Token: 0x170008B7 RID: 2231
		// (get) Token: 0x06002703 RID: 9987 RVA: 0x00095934 File Offset: 0x00093B34
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
					return global::Facepunch.Clocks.Counters.Unity.NetworkTime.TIME_SOURCE.NOW - this.deductSeconds - this.startTime;
				}
				return this.endTime - this.deductSeconds - this.startTime;
			}
		}

		// Token: 0x170008B8 RID: 2232
		// (get) Token: 0x06002704 RID: 9988 RVA: 0x00095998 File Offset: 0x00093B98
		public long ElapsedMilliseconds
		{
			get
			{
				return (long)global::System.Math.Floor(this.ElapsedSeconds * 1000.0);
			}
		}

		// Token: 0x170008B9 RID: 2233
		// (get) Token: 0x06002705 RID: 9989 RVA: 0x000959B0 File Offset: 0x00093BB0
		public global::System.TimeSpan Elapsed
		{
			get
			{
				if (double.IsNegativeInfinity(this.startTime))
				{
					return global::System.TimeSpan.Zero;
				}
				return global::System.TimeSpan.FromSeconds(((!double.IsPositiveInfinity(this.endTime)) ? this.endTime : global::Facepunch.Clocks.Counters.Unity.NetworkTime.TIME_SOURCE.NOW) - this.deductSeconds - this.startTime);
			}
		}

		// Token: 0x170008BA RID: 2234
		// (get) Token: 0x06002706 RID: 9990 RVA: 0x00095A08 File Offset: 0x00093C08
		public bool IsRunning
		{
			get
			{
				return double.IsPositiveInfinity(this.endTime) && !double.IsNegativeInfinity(this.startTime);
			}
		}

		// Token: 0x170008BB RID: 2235
		// (get) Token: 0x06002707 RID: 9991 RVA: 0x00095A2C File Offset: 0x00093C2C
		public static global::Facepunch.Clocks.Counters.Unity.NetworkTime Restart
		{
			get
			{
				global::Facepunch.Clocks.Counters.Unity.NetworkTime result;
				result.deductSeconds = 0.0;
				result.endTime = double.PositiveInfinity;
				result.startTime = global::Facepunch.Clocks.Counters.Unity.NetworkTime.TIME_SOURCE.NOW;
				return result;
			}
		}

		// Token: 0x170008BC RID: 2236
		// (get) Token: 0x06002708 RID: 9992 RVA: 0x00095A68 File Offset: 0x00093C68
		public static global::Facepunch.Clocks.Counters.Unity.NetworkTime Reset
		{
			get
			{
				global::Facepunch.Clocks.Counters.Unity.NetworkTime result;
				result.deductSeconds = 0.0;
				result.endTime = double.PositiveInfinity;
				result.startTime = double.NegativeInfinity;
				return result;
			}
		}

		// Token: 0x040013BF RID: 5055
		private const double ZeroDeductions = 0.0;

		// Token: 0x040013C0 RID: 5056
		private const double OneThousand = 1000.0;

		// Token: 0x040013C1 RID: 5057
		private const double ZeroElapsed = 0.0;

		// Token: 0x040013C2 RID: 5058
		private double startTime;

		// Token: 0x040013C3 RID: 5059
		private double endTime;

		// Token: 0x040013C4 RID: 5060
		private double deductSeconds;

		// Token: 0x02000468 RID: 1128
		private static class TIME_SOURCE
		{
			// Token: 0x170008BD RID: 2237
			// (get) Token: 0x06002709 RID: 9993 RVA: 0x00095AA8 File Offset: 0x00093CA8
			public static double NOW
			{
				get
				{
					return global::UnityEngine.Network.time;
				}
			}
		}
	}
}
