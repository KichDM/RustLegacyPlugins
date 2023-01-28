using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200048A RID: 1162
public struct ODBReverseEnumerator<T> : global::System.IDisposable, global::System.Collections.IEnumerator, global::ODBEnumerator<!0>, global::System.Collections.Generic.IEnumerator<!0> where T : global::UnityEngine.Object
{
	// Token: 0x06002864 RID: 10340 RVA: 0x0009A498 File Offset: 0x00098698
	public ODBReverseEnumerator(global::ODBNode<T> node)
	{
		this.sib.has = true;
		this.sib.item = node;
		this.Current = (T)((object)null);
	}

	// Token: 0x06002865 RID: 10341 RVA: 0x0009A4CC File Offset: 0x000986CC
	public ODBReverseEnumerator(global::ODBList<T> list)
	{
		this = new global::ODBReverseEnumerator<T>(list.last);
	}

	// Token: 0x06002866 RID: 10342 RVA: 0x0009A4DC File Offset: 0x000986DC
	public ODBReverseEnumerator(global::ODBSibling<T> sibling)
	{
		this.sib = sibling;
		this.Current = (T)((object)null);
	}

	// Token: 0x170008ED RID: 2285
	// (get) Token: 0x06002867 RID: 10343 RVA: 0x0009A4F4 File Offset: 0x000986F4
	T global::ODBEnumerator<!0>.ExplicitCurrent
	{
		get
		{
			return this.Current;
		}
	}

	// Token: 0x170008EE RID: 2286
	// (get) Token: 0x06002868 RID: 10344 RVA: 0x0009A4FC File Offset: 0x000986FC
	T global::System.Collections.Generic.IEnumerator<!0>.Current
	{
		get
		{
			return this.Current;
		}
	}

	// Token: 0x170008EF RID: 2287
	// (get) Token: 0x06002869 RID: 10345 RVA: 0x0009A504 File Offset: 0x00098704
	object global::System.Collections.IEnumerator.Current
	{
		get
		{
			return this.Current;
		}
	}

	// Token: 0x0600286A RID: 10346 RVA: 0x0009A514 File Offset: 0x00098714
	void global::System.Collections.IEnumerator.Reset()
	{
		throw new global::System.NotSupportedException();
	}

	// Token: 0x0600286B RID: 10347 RVA: 0x0009A51C File Offset: 0x0009871C
	public bool MoveNext()
	{
		if (this.sib.has)
		{
			global::ODBNode<T> item = this.sib.item;
			this.Current = item.self;
			this.sib = item.p;
			return true;
		}
		return false;
	}

	// Token: 0x0600286C RID: 10348 RVA: 0x0009A560 File Offset: 0x00098760
	public void Dispose()
	{
		this.sib = default(global::ODBSibling<T>);
		this.Current = (T)((object)null);
	}

	// Token: 0x0600286D RID: 10349 RVA: 0x0009A588 File Offset: 0x00098788
	public global::System.Collections.Generic.IEnumerator<T> ToGeneric()
	{
		global::ODBReverseEnumerator<T> odbreverseEnumerator = this;
		return global::ODBCachedEnumerator<T, global::ODBReverseEnumerator<T>>.Cache(ref odbreverseEnumerator);
	}

	// Token: 0x0400141A RID: 5146
	private global::ODBSibling<T> sib;

	// Token: 0x0400141B RID: 5147
	public T Current;
}
