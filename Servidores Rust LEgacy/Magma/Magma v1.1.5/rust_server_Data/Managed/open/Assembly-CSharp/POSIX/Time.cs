using System;

namespace POSIX
{
	// Token: 0x02000200 RID: 512
	public static class Time
	{
		// Token: 0x06000E1E RID: 3614 RVA: 0x00036264 File Offset: 0x00034464
		// Note: this type is marked as 'beforefieldinit'.
		static Time()
		{
		}

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06000E1F RID: 3615 RVA: 0x0003627C File Offset: 0x0003447C
		public static int NowStamp
		{
			get
			{
				double totalSeconds = global::System.DateTime.UtcNow.Subtract(global::POSIX.Time.epoch).TotalSeconds;
				int num = (int)totalSeconds;
				if ((double)num > totalSeconds)
				{
					num--;
				}
				return num;
			}
		}

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x06000E20 RID: 3616 RVA: 0x000362B4 File Offset: 0x000344B4
		public static double NowSeconds
		{
			get
			{
				return global::System.DateTime.UtcNow.Subtract(global::POSIX.Time.epoch).TotalSeconds;
			}
		}

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x06000E21 RID: 3617 RVA: 0x000362DC File Offset: 0x000344DC
		public static global::System.TimeSpan NowSpan
		{
			get
			{
				return global::System.DateTime.UtcNow.Subtract(global::POSIX.Time.epoch);
			}
		}

		// Token: 0x06000E22 RID: 3618 RVA: 0x000362FC File Offset: 0x000344FC
		public static global::System.TimeSpan ElapsedSince(int timeStamp)
		{
			return global::System.DateTime.UtcNow.Subtract(global::POSIX.Time.epoch.AddSeconds((double)timeStamp));
		}

		// Token: 0x06000E23 RID: 3619 RVA: 0x00036328 File Offset: 0x00034528
		public static global::System.TimeSpan ElapsedSince(global::System.TimeSpan sinceEpoch)
		{
			return global::System.DateTime.UtcNow.Subtract(global::POSIX.Time.epoch.Add(sinceEpoch));
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x00036350 File Offset: 0x00034550
		public static global::System.TimeSpan ElapsedSince(global::System.DateTime dateTime)
		{
			return global::System.DateTime.UtcNow.Subtract(dateTime.ToUniversalTime());
		}

		// Token: 0x06000E25 RID: 3621 RVA: 0x00036374 File Offset: 0x00034574
		public static double ElapsedSecondsSince(int timeStamp)
		{
			return global::System.DateTime.UtcNow.Subtract(global::POSIX.Time.epoch.AddSeconds((double)timeStamp)).TotalSeconds;
		}

		// Token: 0x06000E26 RID: 3622 RVA: 0x000363A8 File Offset: 0x000345A8
		public static double ElapsedSecondsSince(global::System.TimeSpan sinceEpoch)
		{
			return global::System.DateTime.UtcNow.Subtract(global::POSIX.Time.epoch.Add(sinceEpoch)).TotalSeconds;
		}

		// Token: 0x06000E27 RID: 3623 RVA: 0x000363D8 File Offset: 0x000345D8
		public static double ElapsedSecondsSince(global::System.DateTime dateTime)
		{
			return global::System.DateTime.UtcNow.Subtract(dateTime.ToUniversalTime()).TotalSeconds;
		}

		// Token: 0x06000E28 RID: 3624 RVA: 0x00036404 File Offset: 0x00034604
		public static int ElapsedStampSince(int timeStamp)
		{
			double totalSeconds = global::System.DateTime.UtcNow.Subtract(global::POSIX.Time.epoch.AddSeconds((double)timeStamp)).TotalSeconds;
			int num = (int)totalSeconds;
			if ((double)num > totalSeconds)
			{
				num--;
			}
			return num;
		}

		// Token: 0x06000E29 RID: 3625 RVA: 0x00036448 File Offset: 0x00034648
		public static int ElapsedStampSince(global::System.TimeSpan sinceEpoch)
		{
			double totalSeconds = global::System.DateTime.UtcNow.Subtract(global::POSIX.Time.epoch.Add(sinceEpoch)).TotalSeconds;
			int num = (int)totalSeconds;
			if ((double)num > totalSeconds)
			{
				num--;
			}
			return num;
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x0003648C File Offset: 0x0003468C
		public static int ElapsedStampSince(global::System.DateTime dateTime)
		{
			double totalSeconds = global::System.DateTime.UtcNow.Subtract(dateTime.ToUniversalTime()).TotalSeconds;
			int num = (int)totalSeconds;
			if ((double)num > totalSeconds)
			{
				num--;
			}
			return num;
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x000364C8 File Offset: 0x000346C8
		public static global::System.TimeSpan Elapsed(int timeStampStart, int timeStampEnd)
		{
			return global::System.TimeSpan.FromSeconds((double)(timeStampEnd - timeStampStart));
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x000364D4 File Offset: 0x000346D4
		public static global::System.TimeSpan Elapsed(global::System.TimeSpan sinceEpochStart, global::System.TimeSpan sinceEpochEnd)
		{
			return sinceEpochEnd.Subtract(sinceEpochStart);
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x000364E0 File Offset: 0x000346E0
		public static global::System.TimeSpan Elapsed(global::System.DateTime dateTimeStart, global::System.DateTime dateTimeEnd)
		{
			return dateTimeEnd.ToUniversalTime().Subtract(dateTimeStart.ToUniversalTime());
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x00036504 File Offset: 0x00034704
		public static double ElapsedSeconds(int timeStampStart, int timeStampEnd)
		{
			return global::System.TimeSpan.FromSeconds((double)(timeStampEnd - timeStampStart)).TotalSeconds;
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x00036524 File Offset: 0x00034724
		public static double ElapsedSeconds(global::System.TimeSpan sinceEpochStart, global::System.TimeSpan sinceEpochEnd)
		{
			return sinceEpochEnd.Subtract(sinceEpochStart).TotalSeconds;
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x00036544 File Offset: 0x00034744
		public static double ElapsedSeconds(global::System.DateTime dateTimeStart, global::System.DateTime dateTimeEnd)
		{
			return dateTimeEnd.ToUniversalTime().Subtract(dateTimeStart.ToUniversalTime()).TotalSeconds;
		}

		// Token: 0x06000E31 RID: 3633 RVA: 0x00036570 File Offset: 0x00034770
		public static int ElapsedStamp(int timeStampStart, int timeStampEnd)
		{
			double totalSeconds = global::System.TimeSpan.FromSeconds((double)(timeStampEnd - timeStampStart)).TotalSeconds;
			int num = (int)totalSeconds;
			if ((double)num > totalSeconds)
			{
				num--;
			}
			return num;
		}

		// Token: 0x06000E32 RID: 3634 RVA: 0x000365A0 File Offset: 0x000347A0
		public static int ElapsedStamp(global::System.TimeSpan sinceEpochStart, global::System.TimeSpan sinceEpochEnd)
		{
			double totalSeconds = sinceEpochEnd.Subtract(sinceEpochStart).TotalSeconds;
			int num = (int)totalSeconds;
			if ((double)num > totalSeconds)
			{
				num--;
			}
			return num;
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x000365D0 File Offset: 0x000347D0
		public static int ElapsedStamp(global::System.DateTime dateTimeStart, global::System.DateTime dateTimeEnd)
		{
			double totalSeconds = dateTimeEnd.ToUniversalTime().Subtract(dateTimeStart.ToUniversalTime()).TotalSeconds;
			int num = (int)totalSeconds;
			if ((double)num > totalSeconds)
			{
				num--;
			}
			return num;
		}

		// Token: 0x040008C4 RID: 2244
		private static readonly global::System.DateTime epoch = new global::System.DateTime(0x7B2, 1, 1, 0, 0, 0, global::System.DateTimeKind.Utc);
	}
}
