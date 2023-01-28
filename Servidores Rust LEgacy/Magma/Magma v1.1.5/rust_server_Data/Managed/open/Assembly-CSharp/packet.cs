using System;

// Token: 0x0200040F RID: 1039
public class packet : global::ConsoleSystem
{
	// Token: 0x06002427 RID: 9255 RVA: 0x0008A340 File Offset: 0x00088540
	public packet()
	{
	}

	// Token: 0x06002428 RID: 9256 RVA: 0x0008A348 File Offset: 0x00088548
	// Note: this type is marked as 'beforefieldinit'.
	static packet()
	{
	}

	// Token: 0x17000822 RID: 2082
	// (get) Token: 0x06002429 RID: 9257 RVA: 0x0008A358 File Offset: 0x00088558
	// (set) Token: 0x0600242A RID: 9258 RVA: 0x0008A378 File Offset: 0x00088578
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Set the alloted transit time (in millis) for rpcs whom use NetCull.VerifyRPC", "")]
	[global::ConsoleSystem.Saved]
	public static int dropms
	{
		get
		{
			if (global::NetCull.allottedTransitTimeInMillis > 0x7FFFFFFFUL)
			{
				return int.MaxValue;
			}
			return (int)global::NetCull.allottedTransitTimeInMillis;
		}
		set
		{
			if (value < 0)
			{
				global::NetCull.allottedTransitTimeInMillis = 0xA4CB80UL;
			}
			else
			{
				global::NetCull.allottedTransitTimeInMillis = (ulong)((long)value);
			}
		}
	}

	// Token: 0x17000823 RID: 2083
	// (get) Token: 0x0600242B RID: 9259 RVA: 0x0008A398 File Offset: 0x00088598
	// (set) Token: 0x0600242C RID: 9260 RVA: 0x0008A3A0 File Offset: 0x000885A0
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Set the alloted transit time (in seconds) for rpcs whom use NetCull.VerifyRPC", "")]
	public static float dropsec
	{
		get
		{
			return (float)global::NetCull.allottedTransitTime;
		}
		set
		{
			if (value < 0f)
			{
				global::packet.dropms = -1;
			}
			else
			{
				global::NetCull.allottedTransitTime = (double)value;
			}
		}
	}

	// Token: 0x04001205 RID: 4613
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Setting this to non zero values will allow log messages ( for things like rpc drops )", "")]
	public static int loglevel;

	// Token: 0x04001206 RID: 4614
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Fix clock sync threshold, when someones timestamps have been corrected this many times their clock will resync. ( 0 for off )", "")]
	public static int dropclockthresh = 2;

	// Token: 0x04001207 RID: 4615
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Enable/disable packet dropping caused by invalid timestamps", "")]
	public static bool verify = true;
}
