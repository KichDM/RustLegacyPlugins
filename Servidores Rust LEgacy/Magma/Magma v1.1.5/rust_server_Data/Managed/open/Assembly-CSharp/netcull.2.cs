using System;

// Token: 0x02000429 RID: 1065
public class netcull : global::ConsoleSystem
{
	// Token: 0x0600250B RID: 9483 RVA: 0x0008DB58 File Offset: 0x0008BD58
	public netcull()
	{
	}

	// Token: 0x0600250C RID: 9484 RVA: 0x0008DB60 File Offset: 0x0008BD60
	// Note: this type is marked as 'beforefieldinit'.
	static netcull()
	{
	}

	// Token: 0x0600250D RID: 9485 RVA: 0x0008DB68 File Offset: 0x0008BD68
	[global::ConsoleSystem.Admin]
	public static void list(ref global::ConsoleSystem.Arg arg)
	{
		arg.ReplyWith(global::NetworkCullInfo.List.ListNetworkCullInfoLists());
	}

	// Token: 0x040012D4 RID: 4820
	[global::ConsoleSystem.Admin]
	public static bool log = true;
}
