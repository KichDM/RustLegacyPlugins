using System;

// Token: 0x020006FA RID: 1786
public class conditionloss : global::ConsoleSystem
{
	// Token: 0x06003CF5 RID: 15605 RVA: 0x000D691C File Offset: 0x000D4B1C
	public conditionloss()
	{
	}

	// Token: 0x06003CF6 RID: 15606 RVA: 0x000D6924 File Offset: 0x000D4B24
	// Note: this type is marked as 'beforefieldinit'.
	static conditionloss()
	{
	}

	// Token: 0x04001EDA RID: 7898
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Multiply the amount of condition loss when it happens", "")]
	public static float damagemultiplier = 1f;

	// Token: 0x04001EDB RID: 7899
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("Incoming damage is multiplied by this and applied as condition loss to armor i.e. 100 dmg * 0.333 = 33% condition loss", "")]
	public static float armorhealthmult = 0.25f;
}
