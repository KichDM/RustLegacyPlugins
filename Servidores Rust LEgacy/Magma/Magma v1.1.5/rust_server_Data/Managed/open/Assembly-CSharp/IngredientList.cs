using System;

// Token: 0x0200066C RID: 1644
public abstract class IngredientList
{
	// Token: 0x06003449 RID: 13385 RVA: 0x000C8834 File Offset: 0x000C6A34
	protected IngredientList()
	{
	}

	// Token: 0x0600344A RID: 13386 RVA: 0x000C883C File Offset: 0x000C6A3C
	// Note: this type is marked as 'beforefieldinit'.
	static IngredientList()
	{
	}

	// Token: 0x04001D2B RID: 7467
	public const uint seed = 0xF00DFEEDU;

	// Token: 0x04001D2C RID: 7468
	protected static int[] tempHash = new int[0x10];
}
