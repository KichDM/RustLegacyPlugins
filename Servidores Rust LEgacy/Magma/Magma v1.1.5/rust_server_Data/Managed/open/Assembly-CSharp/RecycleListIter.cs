using System;
using System.Collections.Generic;

// Token: 0x02000499 RID: 1177
public struct RecycleListIter<T>
{
	// Token: 0x060028D9 RID: 10457 RVA: 0x0009B508 File Offset: 0x00099708
	internal RecycleListIter(global::System.Collections.Generic.List<T>.Enumerator enumerator)
	{
		this.enumerator = enumerator;
	}

	// Token: 0x060028DA RID: 10458 RVA: 0x0009B514 File Offset: 0x00099714
	public bool MoveNext()
	{
		return this.enumerator.MoveNext();
	}

	// Token: 0x170008FC RID: 2300
	// (get) Token: 0x060028DB RID: 10459 RVA: 0x0009B524 File Offset: 0x00099724
	public T Current
	{
		get
		{
			return this.enumerator.Current;
		}
	}

	// Token: 0x060028DC RID: 10460 RVA: 0x0009B534 File Offset: 0x00099734
	public void Dispose()
	{
		this.enumerator.Dispose();
	}

	// Token: 0x04001435 RID: 5173
	private global::System.Collections.Generic.List<T>.Enumerator enumerator;
}
