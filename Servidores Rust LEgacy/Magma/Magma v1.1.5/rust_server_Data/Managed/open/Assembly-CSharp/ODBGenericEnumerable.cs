using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200048E RID: 1166
public static class ODBGenericEnumerable<T> where T : global::UnityEngine.Object
{
	// Token: 0x0600287E RID: 10366 RVA: 0x0009A6C4 File Offset: 0x000988C4
	public static global::System.Collections.Generic.IEnumerable<T> Open<TEnumerator, TEnumerable>(ref TEnumerable enumerable) where TEnumerator : struct, global::ODBEnumerator<!0> where TEnumerable : struct, global::ODBEnumerable<T, TEnumerator>
	{
		return global::ODBGenericEnumerable<T, TEnumerator, TEnumerable>.Open(ref enumerable);
	}
}
