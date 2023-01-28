using System;

// Token: 0x02000341 RID: 833
public static class Interpolation
{
	// Token: 0x06001C0F RID: 7183 RVA: 0x00070B54 File Offset: 0x0006ED54
	// Note: this type is marked as 'beforefieldinit'.
	static Interpolation()
	{
	}

	// Token: 0x170007AD RID: 1965
	// (get) Token: 0x06001C10 RID: 7184 RVA: 0x00070BB4 File Offset: 0x0006EDB4
	public static double deltaSeconds
	{
		get
		{
			return --0.0;
		}
	}

	// Token: 0x170007AE RID: 1966
	// (get) Token: 0x06001C11 RID: 7185 RVA: 0x00070BC0 File Offset: 0x0006EDC0
	public static double totalDelaySeconds
	{
		get
		{
			return 0.0;
		}
	}

	// Token: 0x170007AF RID: 1967
	// (get) Token: 0x06001C12 RID: 7186 RVA: 0x00070BCC File Offset: 0x0006EDCC
	public static ulong totalDelayMillis
	{
		get
		{
			return 0UL;
		}
	}

	// Token: 0x170007B0 RID: 1968
	// (get) Token: 0x06001C13 RID: 7187 RVA: 0x00070BD0 File Offset: 0x0006EDD0
	public static double delaySeconds
	{
		get
		{
			return 0.0;
		}
	}

	// Token: 0x170007B1 RID: 1969
	// (get) Token: 0x06001C14 RID: 7188 RVA: 0x00070BDC File Offset: 0x0006EDDC
	public static ulong delayMillis
	{
		get
		{
			return 0UL;
		}
	}

	// Token: 0x170007B2 RID: 1970
	// (get) Token: 0x06001C15 RID: 7189 RVA: 0x00070BE0 File Offset: 0x0006EDE0
	public static ulong delayFromSendRateMillis
	{
		get
		{
			return 0UL;
		}
	}

	// Token: 0x170007B3 RID: 1971
	// (get) Token: 0x06001C16 RID: 7190 RVA: 0x00070BE4 File Offset: 0x0006EDE4
	public static double delayFromSendRateSeconds
	{
		get
		{
			return 0.0;
		}
	}

	// Token: 0x170007B4 RID: 1972
	// (get) Token: 0x06001C17 RID: 7191 RVA: 0x00070BF0 File Offset: 0x0006EDF0
	public static float delayFromSendRateSecondsf
	{
		get
		{
			return 0f;
		}
	}

	// Token: 0x170007B5 RID: 1973
	// (get) Token: 0x06001C18 RID: 7192 RVA: 0x00070BF8 File Offset: 0x0006EDF8
	public static double sendRateRatio
	{
		get
		{
			return 0.0;
		}
	}

	// Token: 0x170007B6 RID: 1974
	// (get) Token: 0x06001C19 RID: 7193 RVA: 0x00070C04 File Offset: 0x0006EE04
	public static float sendRate
	{
		get
		{
			return 1f;
		}
	}

	// Token: 0x170007B7 RID: 1975
	// (get) Token: 0x06001C1A RID: 7194 RVA: 0x00070C0C File Offset: 0x0006EE0C
	public static float delaySecondsf
	{
		get
		{
			return 0f;
		}
	}

	// Token: 0x170007B8 RID: 1976
	// (get) Token: 0x06001C1B RID: 7195 RVA: 0x00070C14 File Offset: 0x0006EE14
	public static float deltaSecondsf
	{
		get
		{
			return --0f;
		}
	}

	// Token: 0x170007B9 RID: 1977
	// (get) Token: 0x06001C1C RID: 7196 RVA: 0x00070C1C File Offset: 0x0006EE1C
	public static float sendRateRatiof
	{
		get
		{
			return 0f;
		}
	}

	// Token: 0x170007BA RID: 1978
	// (get) Token: 0x06001C1D RID: 7197 RVA: 0x00070C24 File Offset: 0x0006EE24
	public static float totalDelaySecondsf
	{
		get
		{
			return 0f;
		}
	}

	// Token: 0x06001C1E RID: 7198 RVA: 0x00070C2C File Offset: 0x0006EE2C
	public static double AddDelayToTimeStampSeconds(double timeStamp)
	{
		return timeStamp;
	}

	// Token: 0x06001C1F RID: 7199 RVA: 0x00070C30 File Offset: 0x0006EE30
	public static ulong AddDelayToTimeStampMillis(ulong timestamp)
	{
		return timestamp;
	}

	// Token: 0x06001C20 RID: 7200 RVA: 0x00070C34 File Offset: 0x0006EE34
	public static double GetInterpolationTimeSeconds(double timeStamp)
	{
		return timeStamp;
	}

	// Token: 0x06001C21 RID: 7201 RVA: 0x00070C38 File Offset: 0x0006EE38
	public static ulong GetInterpolationTimeMillis(ulong timestamp)
	{
		if (timestamp < 0UL)
		{
			return 0UL;
		}
		return timestamp;
	}

	// Token: 0x06001C22 RID: 7202 RVA: 0x00070C48 File Offset: 0x0006EE48
	public static global::Interpolation.TimingData Capture()
	{
		return new global::Interpolation.TimingData(0.0, --0.0, 0.0, 0.0, 0.0, 0UL, 0UL, 0UL, 1f);
	}

	// Token: 0x170007BB RID: 1979
	// (get) Token: 0x06001C23 RID: 7203 RVA: 0x00070C94 File Offset: 0x0006EE94
	public static double time
	{
		get
		{
			return global::NetCull.time;
		}
	}

	// Token: 0x170007BC RID: 1980
	// (get) Token: 0x06001C24 RID: 7204 RVA: 0x00070C9C File Offset: 0x0006EE9C
	public static double localTime
	{
		get
		{
			return global::NetCull.localTime;
		}
	}

	// Token: 0x170007BD RID: 1981
	// (get) Token: 0x06001C25 RID: 7205 RVA: 0x00070CA4 File Offset: 0x0006EEA4
	public static ulong timeInMillis
	{
		get
		{
			ulong num = global::NetCull.timeInMillis;
			if (num < 0UL)
			{
				num = 0UL;
			}
			else
			{
				num = num;
			}
			return num;
		}
	}

	// Token: 0x170007BE RID: 1982
	// (get) Token: 0x06001C26 RID: 7206 RVA: 0x00070CCC File Offset: 0x0006EECC
	public static ulong localTimeInMillis
	{
		get
		{
			ulong num = global::NetCull.localTimeInMillis;
			if (num < 0UL)
			{
				num = 0UL;
			}
			else
			{
				num = num;
			}
			return num;
		}
	}

	// Token: 0x04001065 RID: 4197
	private const float kDefaultSendRateRatio = 1.5f;

	// Token: 0x04001066 RID: 4198
	private const int kDefaultDelayMillis = 0x14;

	// Token: 0x04001067 RID: 4199
	private const double _ratio = 0.0;

	// Token: 0x04001068 RID: 4200
	private const float _sendRate = 1f;

	// Token: 0x04001069 RID: 4201
	private const ulong _delayMillis = 0UL;

	// Token: 0x0400106A RID: 4202
	private const double delayFromSendRateMillis__d = 0.0;

	// Token: 0x0400106B RID: 4203
	private const ulong _delayFromSendRateMillis = 0UL;

	// Token: 0x0400106C RID: 4204
	private const ulong _totalDelayMillis = 0UL;

	// Token: 0x0400106D RID: 4205
	private const double _delayFromSendRateSeconds = 0.0;

	// Token: 0x0400106E RID: 4206
	private const double _delaySeconds = 0.0;

	// Token: 0x0400106F RID: 4207
	private const double _totalDelaySeconds = 0.0;

	// Token: 0x04001070 RID: 4208
	private const double _deltaSeconds = --0.0;

	// Token: 0x04001071 RID: 4209
	public static readonly global::Interpolation.TimingData @struct = new global::Interpolation.TimingData(0.0, --0.0, 0.0, 0.0, 0.0, 0UL, 0UL, 0UL, 1f);

	// Token: 0x04001072 RID: 4210
	public static float clientInterpRatio = 1.5f;

	// Token: 0x04001073 RID: 4211
	public static int clientInterpDelay = 0x14;

	// Token: 0x02000342 RID: 834
	public struct TimingData
	{
		// Token: 0x06001C27 RID: 7207 RVA: 0x00070CF4 File Offset: 0x0006EEF4
		public TimingData(double sendRateRatio, double deltaSeconds, double totalDelaySeconds, double delaySeconds, double delayFromSendRateSeconds, ulong totalDelayMillis, ulong delayFromSendRateMillis, ulong delayMillis, float sendRate)
		{
			this.sendRateRatio = sendRateRatio;
			this.deltaSeconds = deltaSeconds;
			this.totalDelaySeconds = totalDelaySeconds;
			this.delaySeconds = delaySeconds;
			this.delayFromSendRateSeconds = delayFromSendRateSeconds;
			this.totalDelayMillis = totalDelayMillis;
			this.delayFromSendRateMillis = delayFromSendRateMillis;
			this.delayMillis = delayMillis;
			this.sendRate = sendRate;
			this.sendRateRatioF = (float)sendRateRatio;
			this.deltaSecondsF = (float)deltaSeconds;
			this.totalDelaySecondsF = (float)totalDelaySeconds;
			this.delaySecondsF = (float)delaySeconds;
			this.delayFromSendRateSecondsF = (float)delayFromSendRateSeconds;
		}

		// Token: 0x04001074 RID: 4212
		public readonly double sendRateRatio;

		// Token: 0x04001075 RID: 4213
		public readonly double deltaSeconds;

		// Token: 0x04001076 RID: 4214
		public readonly double totalDelaySeconds;

		// Token: 0x04001077 RID: 4215
		public readonly double delaySeconds;

		// Token: 0x04001078 RID: 4216
		public readonly double delayFromSendRateSeconds;

		// Token: 0x04001079 RID: 4217
		public readonly float sendRateRatioF;

		// Token: 0x0400107A RID: 4218
		public readonly float deltaSecondsF;

		// Token: 0x0400107B RID: 4219
		public readonly float totalDelaySecondsF;

		// Token: 0x0400107C RID: 4220
		public readonly float delaySecondsF;

		// Token: 0x0400107D RID: 4221
		public readonly float delayFromSendRateSecondsF;

		// Token: 0x0400107E RID: 4222
		public readonly ulong totalDelayMillis;

		// Token: 0x0400107F RID: 4223
		public readonly ulong delayFromSendRateMillis;

		// Token: 0x04001080 RID: 4224
		public readonly ulong delayMillis;

		// Token: 0x04001081 RID: 4225
		public readonly float sendRate;
	}
}
