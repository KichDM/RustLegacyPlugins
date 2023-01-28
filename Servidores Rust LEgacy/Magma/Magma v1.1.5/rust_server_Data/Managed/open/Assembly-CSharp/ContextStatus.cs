using System;

// Token: 0x02000591 RID: 1425
public static class ContextStatus
{
	// Token: 0x06002F76 RID: 12150 RVA: 0x000B4EE4 File Offset: 0x000B30E4
	public static global::ContextStatusFlags GetSpriteFlags(this global::ContextStatusFlags statusFlags)
	{
		return statusFlags & (global::ContextStatusFlags.SpriteFlag0 | global::ContextStatusFlags.SpriteFlag1);
	}

	// Token: 0x06002F77 RID: 12151 RVA: 0x000B4EF0 File Offset: 0x000B30F0
	public static global::ContextStatusFlags CopyWithSpriteSetting(this global::ContextStatusFlags statusFlags, global::ContextStatusFlags SPRITE_SETTING)
	{
		return (statusFlags & ~(global::ContextStatusFlags.SpriteFlag0 | global::ContextStatusFlags.SpriteFlag1)) | (SPRITE_SETTING & (global::ContextStatusFlags.SpriteFlag0 | global::ContextStatusFlags.SpriteFlag1));
	}

	// Token: 0x04001949 RID: 6473
	public const global::ContextStatusFlags ObjectBusy = global::ContextStatusFlags.ObjectBusy;

	// Token: 0x0400194A RID: 6474
	public const global::ContextStatusFlags ObjectBroken = global::ContextStatusFlags.ObjectBroken;

	// Token: 0x0400194B RID: 6475
	public const global::ContextStatusFlags ObjectEmpty = global::ContextStatusFlags.ObjectEmpty;

	// Token: 0x0400194C RID: 6476
	public const global::ContextStatusFlags ObjectOccupied = global::ContextStatusFlags.ObjectOccupied;

	// Token: 0x0400194D RID: 6477
	public const global::ContextStatusFlags SPRITE_DEFAULT = (global::ContextStatusFlags)0;

	// Token: 0x0400194E RID: 6478
	public const global::ContextStatusFlags SPRITE_FRACTION = global::ContextStatusFlags.SpriteFlag0;

	// Token: 0x0400194F RID: 6479
	public const global::ContextStatusFlags SPRITE_NEVER = global::ContextStatusFlags.SpriteFlag1;

	// Token: 0x04001950 RID: 6480
	public const global::ContextStatusFlags SPRITE_ALWAYS = global::ContextStatusFlags.SpriteFlag0 | global::ContextStatusFlags.SpriteFlag1;

	// Token: 0x04001951 RID: 6481
	public const global::ContextStatusFlags MASK_SPRITE = global::ContextStatusFlags.SpriteFlag0 | global::ContextStatusFlags.SpriteFlag1;
}
