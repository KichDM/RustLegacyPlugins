using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000490 RID: 1168
public sealed class ODBGenericEnumerable<T, TEnumerator, TEnumerable> : global::System.IDisposable, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<!0> where T : global::UnityEngine.Object where TEnumerator : struct, global::ODBEnumerator<!0> where TEnumerable : struct, global::ODBEnumerable<T, TEnumerator>
{
	// Token: 0x06002880 RID: 10368 RVA: 0x0009A6D4 File Offset: 0x000988D4
	private ODBGenericEnumerable(ref TEnumerable enumerable)
	{
		this.enumerable = enumerable;
	}

	// Token: 0x06002881 RID: 10369 RVA: 0x0009A6E8 File Offset: 0x000988E8
	// Note: this type is marked as 'beforefieldinit'.
	static ODBGenericEnumerable()
	{
	}

	// Token: 0x06002882 RID: 10370 RVA: 0x0009A6EC File Offset: 0x000988EC
	global::System.Collections.Generic.IEnumerator<T> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
	{
		TEnumerator enumerator = this.GetEnumerator();
		return global::ODBCachedEnumerator<T, TEnumerator>.Cache(ref enumerator);
	}

	// Token: 0x06002883 RID: 10371 RVA: 0x0009A708 File Offset: 0x00098908
	global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
	{
		throw new global::System.NotSupportedException("Cannot use non generic IEnumerable interface with given object");
	}

	// Token: 0x06002884 RID: 10372 RVA: 0x0009A714 File Offset: 0x00098914
	public TEnumerator GetEnumerator()
	{
		if (this.disposed)
		{
			throw new global::System.ObjectDisposedException("enumerable");
		}
		return this.enumerable.GetEnumerator();
	}

	// Token: 0x06002885 RID: 10373 RVA: 0x0009A740 File Offset: 0x00098940
	public void Dispose()
	{
		if (!this.disposed)
		{
			this.enumerable = default(TEnumerable);
			this.disposed = true;
			this.next = global::ODBGenericEnumerable<T, TEnumerator, TEnumerable>.recycle;
			global::ODBGenericEnumerable<T, TEnumerator, TEnumerable>.recycle = this;
		}
	}

	// Token: 0x06002886 RID: 10374 RVA: 0x0009A780 File Offset: 0x00098980
	public static global::ODBGenericEnumerable<T, TEnumerator, TEnumerable> Open(ref TEnumerable enumerable)
	{
		if (global::ODBGenericEnumerable<T, TEnumerator, TEnumerable>.recycle == null)
		{
			return new global::ODBGenericEnumerable<T, TEnumerator, TEnumerable>(ref enumerable);
		}
		global::ODBGenericEnumerable<T, TEnumerator, TEnumerable> odbgenericEnumerable = global::ODBGenericEnumerable<T, TEnumerator, TEnumerable>.recycle;
		odbgenericEnumerable.disposed = false;
		global::ODBGenericEnumerable<T, TEnumerator, TEnumerable>.recycle = odbgenericEnumerable.next;
		odbgenericEnumerable.enumerable = enumerable;
		return odbgenericEnumerable;
	}

	// Token: 0x0400141E RID: 5150
	private TEnumerable enumerable;

	// Token: 0x0400141F RID: 5151
	private global::ODBGenericEnumerable<T, TEnumerator, TEnumerable> next;

	// Token: 0x04001420 RID: 5152
	private bool disposed;

	// Token: 0x04001421 RID: 5153
	private static global::ODBGenericEnumerable<T, TEnumerator, TEnumerable> recycle;
}
