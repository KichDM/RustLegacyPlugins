using System;

// Token: 0x0200066B RID: 1643
public class crafting : global::ConsoleSystem
{
	// Token: 0x06003445 RID: 13381 RVA: 0x000C8804 File Offset: 0x000C6A04
	public crafting()
	{
	}

	// Token: 0x06003446 RID: 13382 RVA: 0x000C880C File Offset: 0x000C6A0C
	// Note: this type is marked as 'beforefieldinit'.
	static crafting()
	{
	}

	// Token: 0x06003447 RID: 13383 RVA: 0x000C8824 File Offset: 0x000C6A24
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("completes every single crafting job in progress (for all crafting character)", "")]
	public static void complete(ref global::ConsoleSystem.Arg args)
	{
		global::CraftingInventory.CompleteAllCraftingInProgress();
	}

	// Token: 0x06003448 RID: 13384 RVA: 0x000C882C File Offset: 0x000C6A2C
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("cancels every single crafting job in progress (for all crafting character)", "")]
	public static void cancel(ref global::ConsoleSystem.Arg args)
	{
		global::CraftingInventory.CancelAllCraftingInProgress();
	}

	// Token: 0x04001D27 RID: 7463
	[global::ConsoleSystem.Admin]
	public static bool instant;

	// Token: 0x04001D28 RID: 7464
	[global::ConsoleSystem.Admin]
	public static bool instant_admins;

	// Token: 0x04001D29 RID: 7465
	[global::ConsoleSystem.Admin]
	public static float timescale = 1f;

	// Token: 0x04001D2A RID: 7466
	[global::ConsoleSystem.Admin]
	public static float workbench_speed = 3f;
}
