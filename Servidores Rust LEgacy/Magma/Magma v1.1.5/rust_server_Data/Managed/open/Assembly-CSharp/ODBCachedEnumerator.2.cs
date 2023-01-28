using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000492 RID: 1170
public static class ODBCachedEnumerator<T> where T : global::UnityEngine.Object
{
	// Token: 0x06002890 RID: 10384 RVA: 0x0009A8C8 File Offset: 0x00098AC8
	public static global::System.Collections.Generic.IEnumerator<T> Cache<TEnumerator>(ref TEnumerator enumerator) where TEnumerator : struct, global::ODBEnumerator<!0>
	{
		return global::ODBCachedEnumerator<T, TEnumerator>.Cache(ref enumerator);
	}
}
