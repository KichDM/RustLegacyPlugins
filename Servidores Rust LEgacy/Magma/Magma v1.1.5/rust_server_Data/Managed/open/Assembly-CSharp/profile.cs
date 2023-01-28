using System;
using UnityEngine;

// Token: 0x02000507 RID: 1287
public class profile : global::ConsoleSystem
{
	// Token: 0x06002C27 RID: 11303 RVA: 0x000A6410 File Offset: 0x000A4610
	public profile()
	{
	}

	// Token: 0x06002C28 RID: 11304 RVA: 0x000A6418 File Offset: 0x000A4618
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Starts profiling for x seconds.", "int seconds")]
	public static void record(ref global::ConsoleSystem.Arg arg)
	{
		int num = arg.GetInt(0, 0xA);
		if (num <= 0)
		{
			num = 0xA;
		}
		global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject("profiler");
		global::RustProfiler rustProfiler = gameObject.AddComponent<global::RustProfiler>();
		rustProfiler.StartRecording(num);
		arg.ReplyWith("Recording started!");
	}
}
