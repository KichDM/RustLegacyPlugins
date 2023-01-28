using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000493 RID: 1171
public static class ODBCachedEnumerator
{
	// Token: 0x06002891 RID: 10385 RVA: 0x0009A8D0 File Offset: 0x00098AD0
	public static global::System.Collections.Generic.IEnumerator<T> Cache<TEnumerator, T>(ref TEnumerator enumerator) where TEnumerator : struct, global::ODBEnumerator<T> where T : global::UnityEngine.Object
	{
		return global::ODBCachedEnumerator<T>.Cache<TEnumerator>(ref enumerator);
	}
}
