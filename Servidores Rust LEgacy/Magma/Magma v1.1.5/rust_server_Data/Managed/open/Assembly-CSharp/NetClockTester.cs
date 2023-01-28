using System;
using uLink;

// Token: 0x02000406 RID: 1030
public struct NetClockTester
{
	// Token: 0x17000814 RID: 2068
	// (get) Token: 0x060023E7 RID: 9191 RVA: 0x00089250 File Offset: 0x00087450
	public bool Any
	{
		get
		{
			return this.Count > 0UL;
		}
	}

	// Token: 0x17000815 RID: 2069
	// (get) Token: 0x060023E8 RID: 9192 RVA: 0x0008925C File Offset: 0x0008745C
	public bool Empty
	{
		get
		{
			return this.Count == 0UL;
		}
	}

	// Token: 0x060023E9 RID: 9193 RVA: 0x00089268 File Offset: 0x00087468
	public static global::NetClockTester.ValidityFlags TestValidity(ref global::NetClockTester test, ref global::uLink.NetworkMessageInfo info, double intervalSec, global::NetClockTester.ValidityFlags testFor)
	{
		return global::NetClockTester.TestValidity(ref test, ref info, (long)global::System.Math.Floor(intervalSec * 1000.0), testFor);
	}

	// Token: 0x060023EA RID: 9194 RVA: 0x00089284 File Offset: 0x00087484
	public static global::NetClockTester.ValidityFlags TestValidity(ref global::NetClockTester test, ref global::uLink.NetworkMessageInfo info, long intervalMS, global::NetClockTester.ValidityFlags testFor)
	{
		global::NetClockTester.ValidityFlags validityFlags = global::NetClockTester.TestValidity(ref test, info.timestampInMillis, intervalMS);
		test.Results.Add(validityFlags & testFor);
		return validityFlags;
	}

	// Token: 0x060023EB RID: 9195 RVA: 0x000892B0 File Offset: 0x000874B0
	private static global::NetClockTester.ValidityFlags TestValidity(ref global::NetClockTester test, ulong timeStamp, long minimalSendRateMS)
	{
		ulong timeInMillis = global::NetCull.timeInMillis;
		global::NetClockTester.ValidityFlags validityFlags = (timeInMillis >= timeStamp) ? ((global::NetClockTester.ValidityFlags)0) : global::NetClockTester.ValidityFlags.AheadOfServerTime;
		if (test.Count > 0UL)
		{
			long num = global::NetClockTester.Subtract(timeStamp, test.Send.Last);
			long num2 = global::NetClockTester.Subtract(timeInMillis, test.Receive.Last);
			test.Send.Sum = global::NetClockTester.Add(test.Send.Sum, num);
			test.Receive.Sum = global::NetClockTester.Add(test.Receive.Sum, num2);
			test.Count += 1UL;
			test.Send.Last = timeStamp;
			test.Receive.Last = timeInMillis;
			if (num < minimalSendRateMS)
			{
				validityFlags |= global::NetClockTester.ValidityFlags.TooFrequent;
			}
			long num3 = global::NetClockTester.Subtract(test.Send.Last, test.Send.First);
			long num4 = global::NetClockTester.Subtract(test.Receive.Last, test.Receive.First);
			if (test.Count >= 5UL)
			{
				if (num3 > num4 * 2L)
				{
					validityFlags |= global::NetClockTester.ValidityFlags.OverTimed;
				}
			}
			else if (test.Count >= 3UL && num3 > num4 * 4L)
			{
				validityFlags |= global::NetClockTester.ValidityFlags.OverTimed;
			}
			global::NetClockTester.ValidityFlags lastTestFlags = test.LastTestFlags;
			test.LastTestFlags = validityFlags;
			if ((validityFlags & global::NetClockTester.ValidityFlags.TooFrequent) == global::NetClockTester.ValidityFlags.TooFrequent && (lastTestFlags & global::NetClockTester.ValidityFlags.TooFrequent) != global::NetClockTester.ValidityFlags.TooFrequent)
			{
				validityFlags &= ~global::NetClockTester.ValidityFlags.TooFrequent;
				test.Count = 1UL;
				test.Send.First = test.Send.Last;
				test.Send.Sum = 0UL;
				if (num2 > 0L)
				{
					test.Receive.First = (ulong)global::NetClockTester.Subtract(test.Receive.Last, (ulong)num2);
					test.Receive.Sum = (ulong)num2;
				}
				else
				{
					test.Receive.First = test.Receive.Last;
					test.Receive.Sum = 0UL;
				}
			}
			return (validityFlags != (global::NetClockTester.ValidityFlags)0) ? validityFlags : global::NetClockTester.ValidityFlags.Valid;
		}
		test.Send.Sum = (test.Receive.Sum = 0UL);
		test.Send.First = timeStamp;
		test.Send.Last = timeStamp;
		test.Receive.Last = (test.Receive.First = timeInMillis);
		test.Count = 1UL;
		return validityFlags;
	}

	// Token: 0x17000816 RID: 2070
	// (get) Token: 0x060023EC RID: 9196 RVA: 0x000894FC File Offset: 0x000876FC
	public static global::NetClockTester Reset
	{
		get
		{
			return default(global::NetClockTester);
		}
	}

	// Token: 0x060023ED RID: 9197 RVA: 0x00089514 File Offset: 0x00087714
	private static long Subtract(ulong a, ulong b)
	{
		if (a > b)
		{
			return (long)(a - b);
		}
		if (a < b)
		{
			return (long)(-(long)(b - a));
		}
		return 0L;
	}

	// Token: 0x060023EE RID: 9198 RVA: 0x00089530 File Offset: 0x00087730
	private static ulong Add(ulong a, long b)
	{
		if (b >= 0L)
		{
			return a + (ulong)b;
		}
		if (a > (ulong)(-(ulong)b))
		{
			return a - (ulong)(-(ulong)b);
		}
		return 0UL;
	}

	// Token: 0x040011D4 RID: 4564
	public global::NetClockTester.Stamping Send;

	// Token: 0x040011D5 RID: 4565
	public global::NetClockTester.Stamping Receive;

	// Token: 0x040011D6 RID: 4566
	[global::System.NonSerialized]
	public ulong Count;

	// Token: 0x040011D7 RID: 4567
	public global::NetClockTester.Validity Results;

	// Token: 0x040011D8 RID: 4568
	public global::NetClockTester.ValidityFlags LastTestFlags;

	// Token: 0x02000407 RID: 1031
	public struct Stamping
	{
		// Token: 0x17000817 RID: 2071
		// (get) Token: 0x060023EF RID: 9199 RVA: 0x00089550 File Offset: 0x00087750
		public long Duration
		{
			get
			{
				return global::NetClockTester.Subtract(this.Last, this.First);
			}
		}

		// Token: 0x17000818 RID: 2072
		// (get) Token: 0x060023F0 RID: 9200 RVA: 0x00089564 File Offset: 0x00087764
		public long Variance
		{
			get
			{
				return (long)(this.Sum - (ulong)global::NetClockTester.Subtract(this.Last, this.First));
			}
		}

		// Token: 0x040011D9 RID: 4569
		public ulong Last;

		// Token: 0x040011DA RID: 4570
		public ulong First;

		// Token: 0x040011DB RID: 4571
		public ulong Sum;
	}

	// Token: 0x02000408 RID: 1032
	[global::System.Flags]
	public enum ValidityFlags
	{
		// Token: 0x040011DD RID: 4573
		Valid = 1,
		// Token: 0x040011DE RID: 4574
		TooFrequent = 2,
		// Token: 0x040011DF RID: 4575
		OverTimed = 4,
		// Token: 0x040011E0 RID: 4576
		AheadOfServerTime = 8
	}

	// Token: 0x02000409 RID: 1033
	public struct Validity
	{
		// Token: 0x17000819 RID: 2073
		// (get) Token: 0x060023F1 RID: 9201 RVA: 0x00089580 File Offset: 0x00087780
		public global::NetClockTester.ValidityFlags Flags
		{
			get
			{
				if (this.TooFrequent > 0U)
				{
					if (this.OverTimed > 0U)
					{
						if (this.AheadOfServerTime > 0U)
						{
							return global::NetClockTester.ValidityFlags.TooFrequent | global::NetClockTester.ValidityFlags.OverTimed | global::NetClockTester.ValidityFlags.AheadOfServerTime;
						}
						return global::NetClockTester.ValidityFlags.TooFrequent | global::NetClockTester.ValidityFlags.OverTimed;
					}
					else
					{
						if (this.AheadOfServerTime > 0U)
						{
							return global::NetClockTester.ValidityFlags.TooFrequent | global::NetClockTester.ValidityFlags.AheadOfServerTime;
						}
						return global::NetClockTester.ValidityFlags.TooFrequent;
					}
				}
				else if (this.OverTimed > 0U)
				{
					if (this.AheadOfServerTime > 0U)
					{
						return global::NetClockTester.ValidityFlags.OverTimed | global::NetClockTester.ValidityFlags.AheadOfServerTime;
					}
					return global::NetClockTester.ValidityFlags.OverTimed;
				}
				else
				{
					if (this.AheadOfServerTime > 0U)
					{
						return global::NetClockTester.ValidityFlags.AheadOfServerTime;
					}
					if (this.Valid > 0U)
					{
						return global::NetClockTester.ValidityFlags.Valid;
					}
					return (global::NetClockTester.ValidityFlags)0;
				}
			}
		}

		// Token: 0x060023F2 RID: 9202 RVA: 0x00089604 File Offset: 0x00087804
		public void Add(global::NetClockTester.ValidityFlags vf)
		{
			switch (vf & (global::NetClockTester.ValidityFlags.TooFrequent | global::NetClockTester.ValidityFlags.OverTimed | global::NetClockTester.ValidityFlags.AheadOfServerTime))
			{
			case (global::NetClockTester.ValidityFlags)0:
				if ((vf & global::NetClockTester.ValidityFlags.Valid) == global::NetClockTester.ValidityFlags.Valid)
				{
					this.Valid += 1U;
				}
				break;
			case global::NetClockTester.ValidityFlags.TooFrequent:
				this.TooFrequent += 1U;
				break;
			case global::NetClockTester.ValidityFlags.OverTimed:
				this.OverTimed += 1U;
				break;
			case global::NetClockTester.ValidityFlags.TooFrequent | global::NetClockTester.ValidityFlags.OverTimed:
				this.OverTimed += 1U;
				this.TooFrequent += 1U;
				break;
			case global::NetClockTester.ValidityFlags.AheadOfServerTime:
				this.AheadOfServerTime += 1U;
				break;
			case global::NetClockTester.ValidityFlags.TooFrequent | global::NetClockTester.ValidityFlags.AheadOfServerTime:
				this.AheadOfServerTime += 1U;
				this.TooFrequent += 1U;
				break;
			case global::NetClockTester.ValidityFlags.OverTimed | global::NetClockTester.ValidityFlags.AheadOfServerTime:
				this.AheadOfServerTime += 1U;
				this.OverTimed += 1U;
				break;
			case global::NetClockTester.ValidityFlags.TooFrequent | global::NetClockTester.ValidityFlags.OverTimed | global::NetClockTester.ValidityFlags.AheadOfServerTime:
				this.AheadOfServerTime += 1U;
				this.OverTimed += 1U;
				this.TooFrequent += 1U;
				break;
			}
		}

		// Token: 0x040011E1 RID: 4577
		public uint TooFrequent;

		// Token: 0x040011E2 RID: 4578
		public uint OverTimed;

		// Token: 0x040011E3 RID: 4579
		public uint AheadOfServerTime;

		// Token: 0x040011E4 RID: 4580
		public uint Valid;
	}
}
