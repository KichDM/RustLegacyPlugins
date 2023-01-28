using System;

// Token: 0x020007F4 RID: 2036
public static class dfSpriteFlipExtensions
{
	// Token: 0x0600441D RID: 17437 RVA: 0x000F90B4 File Offset: 0x000F72B4
	public static bool IsSet(this global::dfSpriteFlip value, global::dfSpriteFlip flag)
	{
		return flag == (value & flag);
	}

	// Token: 0x0600441E RID: 17438 RVA: 0x000F90BC File Offset: 0x000F72BC
	public static global::dfSpriteFlip SetFlag(this global::dfSpriteFlip value, global::dfSpriteFlip flag, bool on)
	{
		if (on)
		{
			return value | flag;
		}
		return value & ~flag;
	}
}
