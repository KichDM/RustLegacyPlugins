using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000491 RID: 1169
public class ODBCachedEnumerator<T, TEnumerator> : global::System.IDisposable, global::System.Collections.IEnumerator, global::ODBEnumerator<!0>, global::System.Collections.Generic.IEnumerator<!0> where T : global::UnityEngine.Object where TEnumerator : struct, global::ODBEnumerator<!0>
{
	// Token: 0x06002887 RID: 10375 RVA: 0x0009A7C4 File Offset: 0x000989C4
	private ODBCachedEnumerator(ref TEnumerator enumerator)
	{
		this.enumerator = enumerator;
	}

	// Token: 0x170008F0 RID: 2288
	// (get) Token: 0x06002888 RID: 10376 RVA: 0x0009A7D8 File Offset: 0x000989D8
	T global::ODBEnumerator<!0>.ExplicitCurrent
	{
		get
		{
			return this.Current;
		}
	}

	// Token: 0x170008F1 RID: 2289
	// (get) Token: 0x06002889 RID: 10377 RVA: 0x0009A7E0 File Offset: 0x000989E0
	object global::System.Collections.IEnumerator.Current
	{
		get
		{
			throw new global::System.NotSupportedException("You must use the IEnumerator<> interface. as dispose is entirely neccisary");
		}
	}

	// Token: 0x0600288A RID: 10378 RVA: 0x0009A7EC File Offset: 0x000989EC
	global::System.Collections.Generic.IEnumerator<T> global::ODBEnumerator<!0>.ToGeneric()
	{
		return this;
	}

	// Token: 0x170008F2 RID: 2290
	// (get) Token: 0x0600288B RID: 10379 RVA: 0x0009A7F0 File Offset: 0x000989F0
	public T Current
	{
		get
		{
			return this.enumerator.ExplicitCurrent;
		}
	}

	// Token: 0x0600288C RID: 10380 RVA: 0x0009A804 File Offset: 0x00098A04
	public bool MoveNext()
	{
		return this.enumerator.MoveNext();
	}

	// Token: 0x0600288D RID: 10381 RVA: 0x0009A818 File Offset: 0x00098A18
	public void Reset()
	{
		this.enumerator.Reset();
	}

	// Token: 0x0600288E RID: 10382 RVA: 0x0009A82C File Offset: 0x00098A2C
	public void Dispose()
	{
		if (!this.disposed)
		{
			this.disposed = true;
			this.next = global::ODBCachedEnumerator<T, TEnumerator>.recycle;
			global::ODBCachedEnumerator<T, TEnumerator>.recycle = this;
			this.enumerator.Dispose();
			this.enumerator = default(TEnumerator);
		}
	}

	// Token: 0x0600288F RID: 10383 RVA: 0x0009A87C File Offset: 0x00098A7C
	public static global::System.Collections.Generic.IEnumerator<T> Cache(ref TEnumerator enumerator)
	{
		if (global::ODBCachedEnumerator<T, TEnumerator>.recycle == null)
		{
			return new global::ODBCachedEnumerator<T, TEnumerator>(ref enumerator);
		}
		global::ODBCachedEnumerator<T, TEnumerator> odbcachedEnumerator = global::ODBCachedEnumerator<T, TEnumerator>.recycle;
		global::ODBCachedEnumerator<T, TEnumerator>.recycle = odbcachedEnumerator.next;
		odbcachedEnumerator.disposed = false;
		odbcachedEnumerator.enumerator = enumerator;
		odbcachedEnumerator.next = null;
		return odbcachedEnumerator;
	}

	// Token: 0x04001422 RID: 5154
	private global::ODBCachedEnumerator<T, TEnumerator> next;

	// Token: 0x04001423 RID: 5155
	private static global::ODBCachedEnumerator<T, TEnumerator> recycle;

	// Token: 0x04001424 RID: 5156
	private TEnumerator enumerator;

	// Token: 0x04001425 RID: 5157
	private bool disposed;
}
