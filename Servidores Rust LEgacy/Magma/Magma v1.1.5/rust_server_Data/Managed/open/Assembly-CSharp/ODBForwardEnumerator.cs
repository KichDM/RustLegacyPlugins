using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000489 RID: 1161
public struct ODBForwardEnumerator<T> : global::System.IDisposable, global::System.Collections.IEnumerator, global::ODBEnumerator<T>, global::System.Collections.Generic.IEnumerator<!0> where T : global::UnityEngine.Object
{
	// Token: 0x0600285A RID: 10330 RVA: 0x0009A38C File Offset: 0x0009858C
	public ODBForwardEnumerator(global::ODBNode<T> node)
	{
		this.sib.has = true;
		this.sib.item = node;
		this.Current = (T)((object)null);
	}

	// Token: 0x0600285B RID: 10331 RVA: 0x0009A3C0 File Offset: 0x000985C0
	public ODBForwardEnumerator(global::ODBList<T> list)
	{
		this = new global::ODBForwardEnumerator<T>(list.first);
	}

	// Token: 0x0600285C RID: 10332 RVA: 0x0009A3D0 File Offset: 0x000985D0
	public ODBForwardEnumerator(global::ODBSibling<T> sibling)
	{
		this.sib = sibling;
		this.Current = (T)((object)null);
	}

	// Token: 0x170008EA RID: 2282
	// (get) Token: 0x0600285D RID: 10333 RVA: 0x0009A3E8 File Offset: 0x000985E8
	T global::ODBEnumerator<!0>.ExplicitCurrent
	{
		get
		{
			return this.Current;
		}
	}

	// Token: 0x170008EB RID: 2283
	// (get) Token: 0x0600285E RID: 10334 RVA: 0x0009A3F0 File Offset: 0x000985F0
	T global::System.Collections.Generic.IEnumerator<!0>.Current
	{
		get
		{
			return this.Current;
		}
	}

	// Token: 0x170008EC RID: 2284
	// (get) Token: 0x0600285F RID: 10335 RVA: 0x0009A3F8 File Offset: 0x000985F8
	object global::System.Collections.IEnumerator.Current
	{
		get
		{
			return this.Current;
		}
	}

	// Token: 0x06002860 RID: 10336 RVA: 0x0009A408 File Offset: 0x00098608
	void global::System.Collections.IEnumerator.Reset()
	{
		throw new global::System.NotSupportedException();
	}

	// Token: 0x06002861 RID: 10337 RVA: 0x0009A410 File Offset: 0x00098610
	public bool MoveNext()
	{
		if (this.sib.has)
		{
			global::ODBNode<T> item = this.sib.item;
			this.Current = item.self;
			this.sib = item.n;
			return true;
		}
		return false;
	}

	// Token: 0x06002862 RID: 10338 RVA: 0x0009A454 File Offset: 0x00098654
	public void Dispose()
	{
		this.sib = default(global::ODBSibling<T>);
		this.Current = (T)((object)null);
	}

	// Token: 0x06002863 RID: 10339 RVA: 0x0009A47C File Offset: 0x0009867C
	public global::System.Collections.Generic.IEnumerator<T> ToGeneric()
	{
		global::ODBForwardEnumerator<T> odbforwardEnumerator = this;
		return global::ODBCachedEnumerator<T, global::ODBForwardEnumerator<T>>.Cache(ref odbforwardEnumerator);
	}

	// Token: 0x04001418 RID: 5144
	private global::ODBSibling<T> sib;

	// Token: 0x04001419 RID: 5145
	public T Current;
}
