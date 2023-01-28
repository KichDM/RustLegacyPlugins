using System;
using System.Collections.Generic;

// Token: 0x020001AF RID: 431
public static class TempList
{
	// Token: 0x06000CA0 RID: 3232 RVA: 0x00030330 File Offset: 0x0002E530
	public static global::TempList<T> New<T>(global::System.Collections.Generic.IEnumerable<T> enumerable)
	{
		return global::TempList<T>.New(enumerable);
	}

	// Token: 0x06000CA1 RID: 3233 RVA: 0x00030338 File Offset: 0x0002E538
	public static global::TempList<T> New<T>()
	{
		return global::TempList<T>.New();
	}
}
