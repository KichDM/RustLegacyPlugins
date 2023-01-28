using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200048F RID: 1167
public static class ODBGenericEnumerable<T, TEnumerator> where T : global::UnityEngine.Object where TEnumerator : struct, global::ODBEnumerator<!0>
{
	// Token: 0x0600287F RID: 10367 RVA: 0x0009A6CC File Offset: 0x000988CC
	public static global::System.Collections.Generic.IEnumerable<T> Open<TEnumerable>(ref TEnumerable enumerable) where TEnumerable : struct, global::ODBEnumerable<T, TEnumerator>
	{
		return global::ODBGenericEnumerable<T, TEnumerator, TEnumerable>.Open(ref enumerable);
	}
}
