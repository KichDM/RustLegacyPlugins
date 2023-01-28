using System;

// Token: 0x020007EB RID: 2027
public static class dfMouseButtonsExtensions
{
	// Token: 0x06004416 RID: 17430 RVA: 0x000F9020 File Offset: 0x000F7220
	public static bool IsSet(this global::dfMouseButtons value, global::dfMouseButtons flag)
	{
		return flag == (value & flag);
	}
}
