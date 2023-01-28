using System;
using UnityEngine;

namespace Facepunch.Clocks.Counters.Unity
{
	// Token: 0x02000469 RID: 1129
	public struct RealtimeSinceStartup
	{
		// Token: 0x0600270A RID: 9994 RVA: 0x00095AB0 File Offset: 0x00093CB0
		public void Start()
		{
			if (float.IsNegativeInfinity(this.startTime))
			{
				this.startTime = global::Facepunch.Clocks.Counters.Unity.RealtimeSinceStartup.TIME_SOURCE.NOW;
				this.deductSeconds = 0.0;
				this.endTime = float.PositiveInfinity;
			}
			else if (!float.IsPositiveInfinity(this.endTime))
			{
				float num = this.endTime;
				this.endTime = float.PositiveInfinity;
				this.deductSeconds += (double)global::Facepunch.Clocks.Counters.Unity.RealtimeSinceStartup.TIME_SOURCE.NOW - (double)num;
			}
		}

		// Token: 0x0600270B RID: 9995 RVA: 0x00095B30 File Offset: 0x00093D30
		public void Stop()
		{
			if (float.IsNegativeInfinity(this.startTime))
			{
				return;
			}
			if (float.IsPositiveInfinity(this.endTime))
			{
				this.endTime = global::Facepunch.Clocks.Counters.Unity.RealtimeSinceStartup.TIME_SOURCE.NOW;
			}
		}

		// Token: 0x170008BE RID: 2238
		// (get) Token: 0x0600270C RID: 9996 RVA: 0x00095B6C File Offset: 0x00093D6C
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
					return (double)global::Facepunch.Clocks.Counters.Unity.RealtimeSinceStartup.TIME_SOURCE.NOW - this.deductSeconds - (double)this.startTime;
				}
				return (double)this.endTime - this.deductSeconds - (double)this.startTime;
			}
		}

		// Token: 0x170008BF RID: 2239
		// (get) Token: 0x0600270D RID: 9997 RVA: 0x00095BD4 File Offset: 0x00093DD4
		public long ElapsedMilliseconds
		{
			get
			{
				return (long)global::System.Math.Floor(this.ElapsedSeconds * 1000.0);
			}
		}

		// Token: 0x170008C0 RID: 2240
		// (get) Token: 0x0600270E RID: 9998 RVA: 0x00095BEC File Offset: 0x00093DEC
		public global::System.TimeSpan Elapsed
		{
			get
			{
				if (float.IsNegativeInfinity(this.startTime))
				{
					return global::System.TimeSpan.Zero;
				}
				return global::System.TimeSpan.FromSeconds((double)((!float.IsPositiveInfinity(this.endTime)) ? this.endTime : global::Facepunch.Clocks.Counters.Unity.RealtimeSinceStartup.TIME_SOURCE.NOW) - this.deductSeconds - (double)this.startTime);
			}
		}

		// Token: 0x170008C1 RID: 2241
		// (get) Token: 0x0600270F RID: 9999 RVA: 0x00095C44 File Offset: 0x00093E44
		public bool IsRunning
		{
			get
			{
				return float.IsPositiveInfinity(this.endTime) && !float.IsNegativeInfinity(this.startTime);
			}
		}

		// Token: 0x170008C2 RID: 2242
		// (get) Token: 0x06002710 RID: 10000 RVA: 0x00095C68 File Offset: 0x00093E68
		public static global::Facepunch.Clocks.Counters.Unity.RealtimeSinceStartup Restart
		{
			get
			{
				global::Facepunch.Clocks.Counters.Unity.RealtimeSinceStartup result;
				result.deductSeconds = 0.0;
				result.endTime = float.PositiveInfinity;
				result.startTime = global::Facepunch.Clocks.Counters.Unity.RealtimeSinceStartup.TIME_SOURCE.NOW;
				return result;
			}
		}

		// Token: 0x170008C3 RID: 2243
		// (get) Token: 0x06002711 RID: 10001 RVA: 0x00095CA0 File Offset: 0x00093EA0
		public static global::Facepunch.Clocks.Counters.Unity.RealtimeSinceStartup Reset
		{
			get
			{
				global::Facepunch.Clocks.Counters.Unity.RealtimeSinceStartup result;
				result.deductSeconds = 0.0;
				result.endTime = float.PositiveInfinity;
				result.startTime = float.NegativeInfinity;
				return result;
			}
		}

		// Token: 0x040013C5 RID: 5061
		private const double ZeroDeductions = 0.0;

		// Token: 0x040013C6 RID: 5062
		private const double OneThousand = 1000.0;

		// Token: 0x040013C7 RID: 5063
		private const double ZeroElapsed = 0.0;

		// Token: 0x040013C8 RID: 5064
		private float startTime;

		// Token: 0x040013C9 RID: 5065
		private float endTime;

		// Token: 0x040013CA RID: 5066
		private double deductSeconds;

		// Token: 0x0200046A RID: 1130
		private static class TIME_SOURCE
		{
			// Token: 0x170008C4 RID: 2244
			// (get) Token: 0x06002712 RID: 10002 RVA: 0x00095CD8 File Offset: 0x00093ED8
			public static float NOW
			{
				get
				{
					return global::UnityEngine.Time.realtimeSinceStartup;
				}
			}
		}
	}
}
