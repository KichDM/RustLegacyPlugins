using System;
using Magma;
using RustPP;

// Token: 0x0200005D RID: 93
public class rustpp : global::ConsoleSystem
{
	// Token: 0x0600029C RID: 668 RVA: 0x0000D494 File Offset: 0x0000B694
	[global::ConsoleSystem.Admin]
	public static void day(ref global::ConsoleSystem.Arg arg)
	{
		global::Magma.World.GetWorld().Time = 12f;
	}

	// Token: 0x0600029D RID: 669 RVA: 0x0000D4A5 File Offset: 0x0000B6A5
	[global::ConsoleSystem.Admin]
	public static void night(ref global::ConsoleSystem.Arg arg)
	{
		global::Magma.World.GetWorld().Time = 0f;
	}

	// Token: 0x0600029E RID: 670 RVA: 0x0000D4B6 File Offset: 0x0000B6B6
	[global::ConsoleSystem.Admin]
	public static void shutdown(ref global::ConsoleSystem.Arg arg)
	{
		global::RustPP.TimedEvents.shutdown();
	}

	// Token: 0x0600029F RID: 671 RVA: 0x0000D4BD File Offset: 0x0000B6BD
	[global::ConsoleSystem.Admin]
	public static void savealldata(ref global::ConsoleSystem.Arg arg)
	{
		global::RustPP.TimedEvents.savealldata();
	}

	// Token: 0x060002A0 RID: 672 RVA: 0x0000D4C4 File Offset: 0x0000B6C4
	public rustpp()
	{
	}
}
