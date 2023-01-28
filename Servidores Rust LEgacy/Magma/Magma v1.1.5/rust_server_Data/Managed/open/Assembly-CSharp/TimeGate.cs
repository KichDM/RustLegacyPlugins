using System;

// Token: 0x02000464 RID: 1124
public struct TimeGate
{
	// Token: 0x170008A6 RID: 2214
	// (get) Token: 0x060026D8 RID: 9944 RVA: 0x00095170 File Offset: 0x00093370
	public bool started
	{
		get
		{
			return this.initialized;
		}
	}

	// Token: 0x170008A7 RID: 2215
	// (get) Token: 0x060026D9 RID: 9945 RVA: 0x00095178 File Offset: 0x00093378
	// (set) Token: 0x060026DA RID: 9946 RVA: 0x000951A8 File Offset: 0x000933A8
	public long elapsedMillis
	{
		get
		{
			return (!this.initialized) ? 0x7FFFFFFFL : (global::TimeGate.timeSource - this.startTime);
		}
		set
		{
			if (value == 0x7FFFFFFFL)
			{
				this.initialized = false;
			}
			else
			{
				this.startTime = global::TimeGate.timeSource - value;
				this.initialized = true;
			}
		}
	}

	// Token: 0x170008A8 RID: 2216
	// (get) Token: 0x060026DB RID: 9947 RVA: 0x000951E4 File Offset: 0x000933E4
	// (set) Token: 0x060026DC RID: 9948 RVA: 0x00095224 File Offset: 0x00093424
	public double elapsedSeconds
	{
		get
		{
			return (!this.initialized) ? double.PositiveInfinity : ((double)(global::TimeGate.timeSource - this.startTime) / 1000.0);
		}
		set
		{
			if (double.IsPositiveInfinity(value))
			{
				this.initialized = false;
			}
			else
			{
				this.startTime = global::TimeGate.timeSource - global::TimeGate.SecondsToMS(value);
				this.initialized = true;
			}
		}
	}

	// Token: 0x170008A9 RID: 2217
	// (get) Token: 0x060026DD RID: 9949 RVA: 0x00095264 File Offset: 0x00093464
	// (set) Token: 0x060026DE RID: 9950 RVA: 0x00095280 File Offset: 0x00093480
	public long timeInMillis
	{
		get
		{
			return (!this.initialized) ? 0L : this.startTime;
		}
		set
		{
			this.startTime = value;
			this.initialized = true;
		}
	}

	// Token: 0x170008AA RID: 2218
	// (get) Token: 0x060026DF RID: 9951 RVA: 0x00095290 File Offset: 0x00093490
	// (set) Token: 0x060026E0 RID: 9952 RVA: 0x000952C8 File Offset: 0x000934C8
	public double timeInSeconds
	{
		get
		{
			return (!this.initialized) ? 0.0 : ((double)this.startTime / 1000.0);
		}
		set
		{
			this.startTime = global::TimeGate.SecondsToMS(value);
			this.initialized = true;
		}
	}

	// Token: 0x170008AB RID: 2219
	// (get) Token: 0x060026E1 RID: 9953 RVA: 0x000952E0 File Offset: 0x000934E0
	public bool passedOrAtTime
	{
		get
		{
			return !this.initialized || this.startTime <= global::TimeGate.timeSource;
		}
	}

	// Token: 0x170008AC RID: 2220
	// (get) Token: 0x060026E2 RID: 9954 RVA: 0x00095300 File Offset: 0x00093500
	public bool behindOrAtTime
	{
		get
		{
			return !this.initialized || this.startTime >= global::TimeGate.timeSource;
		}
	}

	// Token: 0x170008AD RID: 2221
	// (get) Token: 0x060026E3 RID: 9955 RVA: 0x00095320 File Offset: 0x00093520
	public bool passedTime
	{
		get
		{
			return !this.initialized || this.startTime < global::TimeGate.timeSource;
		}
	}

	// Token: 0x170008AE RID: 2222
	// (get) Token: 0x060026E4 RID: 9956 RVA: 0x00095340 File Offset: 0x00093540
	public bool behindTime
	{
		get
		{
			return !this.initialized || this.startTime > global::TimeGate.timeSource;
		}
	}

	// Token: 0x170008AF RID: 2223
	// (get) Token: 0x060026E5 RID: 9957 RVA: 0x00095360 File Offset: 0x00093560
	private static long timeSource
	{
		get
		{
			return (long)global::NetCull.timeInMillis;
		}
	}

	// Token: 0x060026E6 RID: 9958 RVA: 0x00095368 File Offset: 0x00093568
	private static long SecondsToMS(double seconds)
	{
		return (long)global::System.Math.Floor(seconds * 1000.0);
	}

	// Token: 0x060026E7 RID: 9959 RVA: 0x0009537C File Offset: 0x0009357C
	public bool ElapsedMillis(long span)
	{
		return span <= 0L || !this.initialized || global::TimeGate.timeSource - this.startTime >= span;
	}

	// Token: 0x060026E8 RID: 9960 RVA: 0x000953B4 File Offset: 0x000935B4
	public bool ElapsedSeconds(double seconds)
	{
		return seconds <= 0.0 || !this.initialized || global::TimeGate.timeSource - this.startTime >= global::TimeGate.SecondsToMS(seconds);
	}

	// Token: 0x060026E9 RID: 9961 RVA: 0x000953F8 File Offset: 0x000935F8
	public bool FireMillis(long minimumElapsedTime)
	{
		return minimumElapsedTime <= 0L || this.RefireMillis(-minimumElapsedTime);
	}

	// Token: 0x060026EA RID: 9962 RVA: 0x00095410 File Offset: 0x00093610
	public bool RefireMillis(long intervalMS)
	{
		long timeSource = global::TimeGate.timeSource;
		if (!this.initialized)
		{
			this.initialized = true;
			this.startTime = timeSource;
			return true;
		}
		if (intervalMS == 0L)
		{
			bool result = timeSource != this.startTime;
			this.startTime = timeSource;
			return result;
		}
		if (intervalMS < 0L)
		{
			long num = this.startTime - timeSource;
			if (num <= intervalMS)
			{
				this.startTime = timeSource;
				return true;
			}
			return false;
		}
		else
		{
			long num2 = timeSource - this.startTime;
			if (num2 >= intervalMS)
			{
				this.startTime += intervalMS;
				return true;
			}
			return false;
		}
	}

	// Token: 0x060026EB RID: 9963 RVA: 0x000954A0 File Offset: 0x000936A0
	public bool RefireSeconds(double intervalSeconds)
	{
		return this.RefireMillis(global::TimeGate.SecondsToMS(intervalSeconds));
	}

	// Token: 0x060026EC RID: 9964 RVA: 0x000954B0 File Offset: 0x000936B0
	public static implicit operator global::TimeGate(double timeRemaining)
	{
		global::TimeGate result;
		result.initialized = true;
		result.startTime = global::TimeGate.SecondsToMS((double)global::TimeGate.timeSource / 1000.0 - timeRemaining);
		return result;
	}

	// Token: 0x060026ED RID: 9965 RVA: 0x000954E4 File Offset: 0x000936E4
	public static implicit operator global::TimeGate(float timeRemaining)
	{
		return (double)timeRemaining;
	}

	// Token: 0x060026EE RID: 9966 RVA: 0x000954F0 File Offset: 0x000936F0
	public static implicit operator global::TimeGate(long timeRemaining)
	{
		global::TimeGate result;
		result.initialized = true;
		result.startTime = global::TimeGate.timeSource - timeRemaining;
		return result;
	}

	// Token: 0x060026EF RID: 9967 RVA: 0x00095514 File Offset: 0x00093714
	public static implicit operator global::TimeGate(ulong timeRemaining)
	{
		global::TimeGate result;
		result.initialized = true;
		result.startTime = global::TimeGate.timeSource - (long)timeRemaining;
		return result;
	}

	// Token: 0x060026F0 RID: 9968 RVA: 0x00095538 File Offset: 0x00093738
	public static implicit operator global::TimeGate(int timeRemaining)
	{
		global::TimeGate result;
		result.initialized = true;
		result.startTime = global::TimeGate.timeSource - (long)timeRemaining;
		return result;
	}

	// Token: 0x060026F1 RID: 9969 RVA: 0x00095560 File Offset: 0x00093760
	public static implicit operator global::TimeGate(uint timeRemaining)
	{
		global::TimeGate result;
		result.initialized = true;
		result.startTime = global::TimeGate.timeSource - (long)((ulong)timeRemaining);
		return result;
	}

	// Token: 0x060026F2 RID: 9970 RVA: 0x00095588 File Offset: 0x00093788
	public static implicit operator global::TimeGate(short timeRemaining)
	{
		global::TimeGate result;
		result.initialized = true;
		result.startTime = global::TimeGate.timeSource - (long)timeRemaining;
		return result;
	}

	// Token: 0x060026F3 RID: 9971 RVA: 0x000955B0 File Offset: 0x000937B0
	public static implicit operator global::TimeGate(ushort timeRemaining)
	{
		global::TimeGate result;
		result.initialized = true;
		result.startTime = global::TimeGate.timeSource - (long)timeRemaining;
		return result;
	}

	// Token: 0x060026F4 RID: 9972 RVA: 0x000955D8 File Offset: 0x000937D8
	public static implicit operator global::TimeGate(byte timeRemaining)
	{
		global::TimeGate result;
		result.initialized = true;
		result.startTime = global::TimeGate.timeSource - (long)timeRemaining;
		return result;
	}

	// Token: 0x060026F5 RID: 9973 RVA: 0x00095600 File Offset: 0x00093800
	public static implicit operator global::TimeGate(sbyte timeRemaining)
	{
		global::TimeGate result;
		result.initialized = true;
		result.startTime = global::TimeGate.timeSource - (long)timeRemaining;
		return result;
	}

	// Token: 0x060026F6 RID: 9974 RVA: 0x00095628 File Offset: 0x00093828
	public static bool operator true(global::TimeGate gate)
	{
		return gate.passedOrAtTime;
	}

	// Token: 0x060026F7 RID: 9975 RVA: 0x00095634 File Offset: 0x00093834
	public static bool operator false(global::TimeGate gate)
	{
		return gate.behindTime;
	}

	// Token: 0x040013B7 RID: 5047
	[global::System.NonSerialized]
	private bool initialized;

	// Token: 0x040013B8 RID: 5048
	[global::System.NonSerialized]
	private long startTime;
}
