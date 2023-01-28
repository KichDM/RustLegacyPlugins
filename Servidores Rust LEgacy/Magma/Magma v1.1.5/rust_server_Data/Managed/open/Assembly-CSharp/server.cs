using System;
using Rust.Steam;
using uLink;

// Token: 0x020004EA RID: 1258
public class server : global::ConsoleSystem
{
	// Token: 0x06002B9F RID: 11167 RVA: 0x000A3C4C File Offset: 0x000A1E4C
	public server()
	{
	}

	// Token: 0x06002BA0 RID: 11168 RVA: 0x000A3C54 File Offset: 0x000A1E54
	// Note: this type is marked as 'beforefieldinit'.
	static server()
	{
	}

	// Token: 0x17000992 RID: 2450
	// (get) Token: 0x06002BA1 RID: 11169 RVA: 0x000A3CAC File Offset: 0x000A1EAC
	// (set) Token: 0x06002BA2 RID: 11170 RVA: 0x000A3CB4 File Offset: 0x000A1EB4
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Sendrate. Higher = more cpu, more network. Lower = less frequent updates, delayed game play.", "")]
	public static float sendrate
	{
		get
		{
			return global::NetCull.sendRate;
		}
		set
		{
			global::NetCull.sendRate = value;
		}
	}

	// Token: 0x17000993 RID: 2451
	// (get) Token: 0x06002BA3 RID: 11171 RVA: 0x000A3CBC File Offset: 0x000A1EBC
	// (set) Token: 0x06002BA4 RID: 11172 RVA: 0x000A3CC8 File Offset: 0x000A1EC8
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Allow for more communication to be had by unconnected players (useful over lan)", "")]
	public static bool lan
	{
		get
		{
			return global::NetCull.config.allowInternalUnconnectedMessages;
		}
		set
		{
			global::NetCull.config.allowInternalUnconnectedMessages = value;
		}
	}

	// Token: 0x17000994 RID: 2452
	// (get) Token: 0x06002BA5 RID: 11173 RVA: 0x000A3CD8 File Offset: 0x000A1ED8
	// (set) Token: 0x06002BA6 RID: 11174 RVA: 0x000A3CE4 File Offset: 0x000A1EE4
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("The local ip to use for server. use \"\" for any", "")]
	public static string ip
	{
		get
		{
			return global::NetCull.config.localIP;
		}
		set
		{
			global::NetCull.config.localIP = value;
		}
	}

	// Token: 0x17000995 RID: 2453
	// (get) Token: 0x06002BA7 RID: 11175 RVA: 0x000A3CF4 File Offset: 0x000A1EF4
	// (set) Token: 0x06002BA8 RID: 11176 RVA: 0x000A3D00 File Offset: 0x000A1F00
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Time measurement source (0=stopwatch, 1=tickcount, 2=datetime)", "")]
	public static int timesrc
	{
		get
		{
			return global::NetCull.config.timeMeasurementFunction;
		}
		set
		{
			global::NetCull.config.timeMeasurementFunction = value;
		}
	}

	// Token: 0x17000996 RID: 2454
	// (get) Token: 0x06002BA9 RID: 11177 RVA: 0x000A3D10 File Offset: 0x000A1F10
	// (set) Token: 0x06002BAA RID: 11178 RVA: 0x000A3D1C File Offset: 0x000A1F1C
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("the send buffer size ( must be inside of a .cfg )", "")]
	public static int sendbuffer
	{
		get
		{
			return global::NetCull.config.sendBufferSize;
		}
		set
		{
			global::NetCull.config.sendBufferSize = value;
		}
	}

	// Token: 0x17000997 RID: 2455
	// (get) Token: 0x06002BAB RID: 11179 RVA: 0x000A3D2C File Offset: 0x000A1F2C
	// (set) Token: 0x06002BAC RID: 11180 RVA: 0x000A3D38 File Offset: 0x000A1F38
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("the receive buffer size ( must be inside of a .cfg )", "")]
	public static int receivebuffer
	{
		get
		{
			return global::NetCull.config.receiveBufferSize;
		}
		set
		{
			global::NetCull.config.receiveBufferSize = value;
		}
	}

	// Token: 0x17000998 RID: 2456
	// (get) Token: 0x06002BAD RID: 11181 RVA: 0x000A3D48 File Offset: 0x000A1F48
	// (set) Token: 0x06002BAE RID: 11182 RVA: 0x000A3D50 File Offset: 0x000A1F50
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("gets/sets the minimum log level", "")]
	public static int log
	{
		get
		{
			return global::uLink.NetworkLog.minLevel;
		}
		set
		{
			global::uLink.NetworkLog.minLevel = (byte)value;
		}
	}

	// Token: 0x06002BAF RID: 11183 RVA: 0x000A3D5C File Offset: 0x000A1F5C
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("gets/sets log flags to given log level", "")]
	public static void setlog(ref global::ConsoleSystem.Arg Arg)
	{
		global::uLink.NetworkLogFlags networkLogFlags = (global::uLink.NetworkLogFlags)Arg.GetEnum(typeof(global::uLink.NetworkLogFlags), 0, 0);
		global::uLink.NetworkLogLevel networkLogLevel = (global::uLink.NetworkLogLevel)Arg.GetEnum(typeof(global::uLink.NetworkLogLevel), 1, 2);
		global::uLink.NetworkLog.SetLevel(networkLogFlags, networkLogLevel);
	}

	// Token: 0x17000999 RID: 2457
	// (get) Token: 0x06002BB0 RID: 11184 RVA: 0x000A3DAC File Offset: 0x000A1FAC
	// (set) Token: 0x06002BB1 RID: 11185 RVA: 0x000A3DB8 File Offset: 0x000A1FB8
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("If set only users in this steam group can join the server. This should be the huge numberic ID of the steam group.", "")]
	public static string steamgroup
	{
		get
		{
			return global::Rust.Steam.Server.SteamGroup.ToString();
		}
		set
		{
			ulong.TryParse(value, out global::Rust.Steam.Server.SteamGroup);
		}
	}

	// Token: 0x04001606 RID: 5638
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("The server's target framerate. 30 is fine.", "")]
	public static int framerate = 0x1E;

	// Token: 0x04001607 RID: 5639
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("How long until unresponsive clients timeout.", "")]
	public static int clienttimeout = 0x12C;

	// Token: 0x04001608 RID: 5640
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("The name of the current server", "")]
	public static string hostname = "Untitled Rust Server";

	// Token: 0x04001609 RID: 5641
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("The maximum allowed connected players", "")]
	public static int maxplayers = 0x3E8;

	// Token: 0x0400160A RID: 5642
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("The port for the server to use. Requires restart.", "")]
	public static int port = 0x6D6F;

	// Token: 0x0400160B RID: 5643
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Should players be allowed to damage other players", "")]
	public static bool pvp = true;

	// Token: 0x0400160C RID: 5644
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("The scene file to use", "")]
	public static string map = "rust_island_2013";

	// Token: 0x0400160D RID: 5645
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Folder in which to store data. Must end in slash.", "")]
	public static string datadir = "serverdata/";
}
