using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200048B RID: 1163
public interface ODBEnumerable<T, TEnumerator> : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<!0> where T : global::UnityEngine.Object where TEnumerator : struct, global::ODBEnumerator<!0>
{
	// Token: 0x0600286E RID: 10350
	TEnumerator GetEnumerator();

	// Token: 0x0600286F RID: 10351
	global::System.Collections.Generic.IEnumerable<T> ToGeneric();
}
