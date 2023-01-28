using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000488 RID: 1160
public interface ODBEnumerator<T> : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<!0> where T : global::UnityEngine.Object
{
	// Token: 0x06002858 RID: 10328
	global::System.Collections.Generic.IEnumerator<T> ToGeneric();

	// Token: 0x170008E9 RID: 2281
	// (get) Token: 0x06002859 RID: 10329
	T ExplicitCurrent { get; }
}
