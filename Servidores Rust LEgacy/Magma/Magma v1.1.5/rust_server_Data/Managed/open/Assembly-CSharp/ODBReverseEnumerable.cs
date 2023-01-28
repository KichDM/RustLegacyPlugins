using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200048C RID: 1164
public struct ODBReverseEnumerable<T> : global::System.Collections.IEnumerable, global::ODBEnumerable<T, global::ODBReverseEnumerator<T>>, global::System.Collections.Generic.IEnumerable<!0> where T : global::UnityEngine.Object
{
	// Token: 0x06002870 RID: 10352 RVA: 0x0009A5A4 File Offset: 0x000987A4
	public ODBReverseEnumerable(global::ODBNode<T> node)
	{
		this.sibling.has = true;
		this.sibling.item = node;
	}

	// Token: 0x06002871 RID: 10353 RVA: 0x0009A5C0 File Offset: 0x000987C0
	public ODBReverseEnumerable(global::ODBList<T> list)
	{
		this = new global::ODBReverseEnumerable<T>(list.last);
	}

	// Token: 0x06002872 RID: 10354 RVA: 0x0009A5D0 File Offset: 0x000987D0
	public ODBReverseEnumerable(global::ODBSibling<T> sibling)
	{
		this.sibling = sibling;
	}

	// Token: 0x06002873 RID: 10355 RVA: 0x0009A5DC File Offset: 0x000987DC
	global::System.Collections.Generic.IEnumerator<T> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
	{
		global::ODBReverseEnumerator<T> enumerator = this.GetEnumerator();
		return global::ODBCachedEnumerator<T, global::ODBReverseEnumerator<T>>.Cache(ref enumerator);
	}

	// Token: 0x06002874 RID: 10356 RVA: 0x0009A5F8 File Offset: 0x000987F8
	global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	// Token: 0x06002875 RID: 10357 RVA: 0x0009A608 File Offset: 0x00098808
	public global::ODBReverseEnumerator<T> GetEnumerator()
	{
		return new global::ODBReverseEnumerator<T>(this.sibling);
	}

	// Token: 0x06002876 RID: 10358 RVA: 0x0009A618 File Offset: 0x00098818
	public global::System.Collections.Generic.IEnumerable<T> ToGeneric()
	{
		global::ODBReverseEnumerable<T> odbreverseEnumerable = this;
		return global::ODBGenericEnumerable<T, global::ODBReverseEnumerator<T>, global::ODBReverseEnumerable<T>>.Open(ref odbreverseEnumerable);
	}

	// Token: 0x0400141C RID: 5148
	private global::ODBSibling<T> sibling;
}
