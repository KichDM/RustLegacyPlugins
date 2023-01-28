using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x02000484 RID: 1156
public struct HSetIter<T> : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<!0>
{
	// Token: 0x06002846 RID: 10310 RVA: 0x0009A0EC File Offset: 0x000982EC
	public HSetIter(global::System.Collections.Generic.HashSet<T>.Enumerator enumerator)
	{
		this.enumerator = enumerator;
	}

	// Token: 0x170008E7 RID: 2279
	// (get) Token: 0x06002847 RID: 10311 RVA: 0x0009A0F8 File Offset: 0x000982F8
	object global::System.Collections.IEnumerator.Current
	{
		get
		{
			return this.enumerator.Current;
		}
	}

	// Token: 0x06002848 RID: 10312 RVA: 0x0009A10C File Offset: 0x0009830C
	public bool MoveNext()
	{
		return this.enumerator.MoveNext();
	}

	// Token: 0x170008E8 RID: 2280
	// (get) Token: 0x06002849 RID: 10313 RVA: 0x0009A11C File Offset: 0x0009831C
	public T Current
	{
		get
		{
			return this.enumerator.Current;
		}
	}

	// Token: 0x0600284A RID: 10314 RVA: 0x0009A12C File Offset: 0x0009832C
	public void Reset()
	{
		throw new global::System.NotSupportedException();
	}

	// Token: 0x0600284B RID: 10315 RVA: 0x0009A134 File Offset: 0x00098334
	public void Dispose()
	{
		this.enumerator.Dispose();
	}

	// Token: 0x0400140F RID: 5135
	private global::System.Collections.Generic.HashSet<T>.Enumerator enumerator;
}
