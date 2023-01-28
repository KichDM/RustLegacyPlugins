using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200048D RID: 1165
public struct ODBForwardEnumerable<T> : global::System.Collections.IEnumerable, global::ODBEnumerable<T, global::ODBForwardEnumerator<T>>, global::System.Collections.Generic.IEnumerable<!0> where T : global::UnityEngine.Object
{
	// Token: 0x06002877 RID: 10359 RVA: 0x0009A634 File Offset: 0x00098834
	public ODBForwardEnumerable(global::ODBNode<T> node)
	{
		this.sibling.has = true;
		this.sibling.item = node;
	}

	// Token: 0x06002878 RID: 10360 RVA: 0x0009A650 File Offset: 0x00098850
	public ODBForwardEnumerable(global::ODBList<T> list)
	{
		this = new global::ODBForwardEnumerable<T>(list.last);
	}

	// Token: 0x06002879 RID: 10361 RVA: 0x0009A660 File Offset: 0x00098860
	public ODBForwardEnumerable(global::ODBSibling<T> sibling)
	{
		this.sibling = sibling;
	}

	// Token: 0x0600287A RID: 10362 RVA: 0x0009A66C File Offset: 0x0009886C
	global::System.Collections.Generic.IEnumerator<T> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
	{
		global::ODBForwardEnumerator<T> enumerator = this.GetEnumerator();
		return global::ODBCachedEnumerator<T, global::ODBForwardEnumerator<T>>.Cache(ref enumerator);
	}

	// Token: 0x0600287B RID: 10363 RVA: 0x0009A688 File Offset: 0x00098888
	global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	// Token: 0x0600287C RID: 10364 RVA: 0x0009A698 File Offset: 0x00098898
	public global::ODBForwardEnumerator<T> GetEnumerator()
	{
		return new global::ODBForwardEnumerator<T>(this.sibling);
	}

	// Token: 0x0600287D RID: 10365 RVA: 0x0009A6A8 File Offset: 0x000988A8
	public global::System.Collections.Generic.IEnumerable<T> ToGeneric()
	{
		global::ODBForwardEnumerable<T> odbforwardEnumerable = this;
		return global::ODBGenericEnumerable<T, global::ODBForwardEnumerator<T>, global::ODBForwardEnumerable<T>>.Open(ref odbforwardEnumerable);
	}

	// Token: 0x0400141D RID: 5149
	private global::ODBSibling<T> sibling;
}
