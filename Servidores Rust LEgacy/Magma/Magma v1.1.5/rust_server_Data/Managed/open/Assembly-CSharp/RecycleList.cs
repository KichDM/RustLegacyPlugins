using System;
using System.Collections.Generic;

// Token: 0x0200049A RID: 1178
public class RecycleList<T> : global::System.Collections.Generic.List<T>, global::System.IDisposable
{
	// Token: 0x060028DD RID: 10461 RVA: 0x0009B544 File Offset: 0x00099744
	internal RecycleList()
	{
	}

	// Token: 0x060028DE RID: 10462 RVA: 0x0009B54C File Offset: 0x0009974C
	// Note: this type is marked as 'beforefieldinit'.
	static RecycleList()
	{
	}

	// Token: 0x060028DF RID: 10463 RVA: 0x0009B560 File Offset: 0x00099760
	public static global::RecycleList<T> Make()
	{
		global::RecycleList<T> recycleList;
		if (global::RecycleList<T>.binCount > 0)
		{
			recycleList = global::RecycleList<T>.bin.First.Value;
			global::RecycleList<T>.bin.RemoveFirst();
			global::RecycleList<T>.binCount--;
		}
		else
		{
			recycleList = new global::RecycleList<T>();
		}
		recycleList.bound = true;
		return recycleList;
	}

	// Token: 0x060028E0 RID: 10464 RVA: 0x0009B5B4 File Offset: 0x000997B4
	public static void Bin(ref global::RecycleList<T> list)
	{
		if (list != null)
		{
			if (list.bound)
			{
				global::RecycleList<T>.bin.AddLast(list);
				list.bound = false;
			}
			list = null;
		}
	}

	// Token: 0x060028E1 RID: 10465 RVA: 0x0009B5E4 File Offset: 0x000997E4
	public static global::RecycleList<T> MakeFromValuedEnumerator<TEnumerator>(ref TEnumerator enumerator) where TEnumerator : struct, global::System.Collections.Generic.IEnumerator<!0>
	{
		global::RecycleList<T> recycleList = global::RecycleList<T>.Make();
		while (enumerator.MoveNext())
		{
			recycleList.Add((T)((object)enumerator.Current));
		}
		enumerator.Dispose();
		return recycleList;
	}

	// Token: 0x060028E2 RID: 10466 RVA: 0x0009B634 File Offset: 0x00099834
	public static global::RecycleList<T> Make<TClassEnumerable>(TClassEnumerable enumerable) where TClassEnumerable : class, global::System.Collections.Generic.IEnumerable<!0>
	{
		global::RecycleList<T> recycleList = global::RecycleList<T>.Make();
		recycleList.AddRange(enumerable);
		return recycleList;
	}

	// Token: 0x060028E3 RID: 10467 RVA: 0x0009B654 File Offset: 0x00099854
	public static global::RecycleList<T> MakeValueEnumerable<TStructEnumerable>(ref TStructEnumerable enumerable) where TStructEnumerable : struct, global::System.Collections.Generic.IEnumerable<!0>
	{
		global::RecycleList<T> recycleList = global::RecycleList<T>.Make();
		recycleList.AddRange(enumerable);
		return recycleList;
	}

	// Token: 0x060028E4 RID: 10468 RVA: 0x0009B67C File Offset: 0x0009987C
	public global::RecycleList<T> Clone()
	{
		return global::RecycleList<T>.Make<global::RecycleList<T>>(this);
	}

	// Token: 0x060028E5 RID: 10469 RVA: 0x0009B684 File Offset: 0x00099884
	public void Dispose()
	{
		global::RecycleList<T> recycleList = this;
		global::RecycleList<T>.Bin(ref recycleList);
	}

	// Token: 0x060028E6 RID: 10470 RVA: 0x0009B69C File Offset: 0x0009989C
	public global::RecycleListIter<T> MakeIter()
	{
		return new global::RecycleListIter<T>(base.GetEnumerator());
	}

	// Token: 0x04001436 RID: 5174
	private bool bound;

	// Token: 0x04001437 RID: 5175
	private static int binCount = 0;

	// Token: 0x04001438 RID: 5176
	private static global::System.Collections.Generic.LinkedList<global::RecycleList<T>> bin = new global::System.Collections.Generic.LinkedList<global::RecycleList<T>>();
}
