using System;

// Token: 0x020000A6 RID: 166
public class airdrop : global::ConsoleSystem
{
	// Token: 0x06000339 RID: 825 RVA: 0x0000F8A4 File Offset: 0x0000DAA4
	public airdrop()
	{
	}

	// Token: 0x0600033A RID: 826 RVA: 0x0000F8AC File Offset: 0x0000DAAC
	// Note: this type is marked as 'beforefieldinit'.
	static airdrop()
	{
	}

	// Token: 0x0600033B RID: 827 RVA: 0x0000F8B8 File Offset: 0x0000DAB8
	[global::ConsoleSystem.Admin]
	public static void drop(ref global::ConsoleSystem.Arg arg)
	{
		arg.ReplyWith("Called airdrop...");
		global::SupplyDropZone.CallAirDrop();
	}

	// Token: 0x040002F5 RID: 757
	[global::ConsoleSystem.Admin]
	public static int min_players = 0x32;
}
