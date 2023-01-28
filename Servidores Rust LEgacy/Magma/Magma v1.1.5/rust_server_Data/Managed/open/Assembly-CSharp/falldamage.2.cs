using System;

// Token: 0x020005B6 RID: 1462
internal class falldamage : global::ConsoleSystem
{
	// Token: 0x06003012 RID: 12306 RVA: 0x000B70F0 File Offset: 0x000B52F0
	public falldamage()
	{
	}

	// Token: 0x06003013 RID: 12307 RVA: 0x000B70F8 File Offset: 0x000B52F8
	// Note: this type is marked as 'beforefieldinit'.
	static falldamage()
	{
	}

	// Token: 0x040019CC RID: 6604
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Fall velocity to begin fall damage calculations - min 18", "")]
	public static float min_vel = 24f;

	// Token: 0x040019CD RID: 6605
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Fall Velocity when damage of maxhealth will be applied", "")]
	public static float max_vel = 38f;

	// Token: 0x040019CE RID: 6606
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("enable/disable fall damage", "")]
	public static bool enabled = true;

	// Token: 0x040019CF RID: 6607
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Average amount of time a leg injury lasts", "")]
	public static float injury_length = 40f;
}
