using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

// Token: 0x020001FE RID: 510
[global::System.Diagnostics.DebuggerDisplay("Count = {Count}")]
public sealed class LockedList<T> : global::System.Collections.IEnumerable, global::System.Collections.IList, global::System.Collections.ICollection, global::System.Collections.Generic.ICollection<!0>, global::System.Collections.Generic.IList<!0>, global::System.Collections.Generic.IEnumerable<!0>, global::System.IEquatable<global::System.Collections.Generic.List<T>>
{
	// Token: 0x06000DDA RID: 3546 RVA: 0x00035E50 File Offset: 0x00034050
	private LockedList()
	{
		this.list = new global::System.Collections.Generic.List<T>(0);
	}

	// Token: 0x06000DDB RID: 3547 RVA: 0x00035E64 File Offset: 0x00034064
	public LockedList(global::System.Collections.Generic.List<T> list)
	{
		if (object.ReferenceEquals(list, null))
		{
			throw new global::System.ArgumentNullException("list");
		}
		this.list = list;
	}

	// Token: 0x06000DDC RID: 3548 RVA: 0x00035E98 File Offset: 0x00034098
	int global::System.Collections.Generic.IList<!0>.IndexOf(T item)
	{
		return this.list.IndexOf(item);
	}

	// Token: 0x06000DDD RID: 3549 RVA: 0x00035EA8 File Offset: 0x000340A8
	void global::System.Collections.Generic.IList<!0>.Insert(int index, T item)
	{
		throw new global::System.NotSupportedException();
	}

	// Token: 0x06000DDE RID: 3550 RVA: 0x00035EB0 File Offset: 0x000340B0
	void global::System.Collections.Generic.IList<!0>.RemoveAt(int index)
	{
		throw new global::System.NotSupportedException();
	}

	// Token: 0x1700035C RID: 860
	T global::System.Collections.Generic.IList<!0>.this[int index]
	{
		get
		{
			return this.ilist[index];
		}
		set
		{
			throw new global::System.NotImplementedException();
		}
	}

	// Token: 0x06000DE1 RID: 3553 RVA: 0x00035ED0 File Offset: 0x000340D0
	void global::System.Collections.Generic.ICollection<!0>.Add(T item)
	{
		throw new global::System.NotSupportedException();
	}

	// Token: 0x06000DE2 RID: 3554 RVA: 0x00035ED8 File Offset: 0x000340D8
	void global::System.Collections.Generic.ICollection<!0>.Clear()
	{
		throw new global::System.NotSupportedException();
	}

	// Token: 0x06000DE3 RID: 3555 RVA: 0x00035EE0 File Offset: 0x000340E0
	bool global::System.Collections.Generic.ICollection<!0>.Contains(T item)
	{
		return this.ilist.Contains(item);
	}

	// Token: 0x06000DE4 RID: 3556 RVA: 0x00035EF0 File Offset: 0x000340F0
	void global::System.Collections.Generic.ICollection<!0>.CopyTo(T[] array, int arrayIndex)
	{
		this.ilist.CopyTo(array, arrayIndex);
	}

	// Token: 0x1700035D RID: 861
	// (get) Token: 0x06000DE5 RID: 3557 RVA: 0x00035F00 File Offset: 0x00034100
	int global::System.Collections.Generic.ICollection<!0>.Count
	{
		get
		{
			return this.ilist.Count;
		}
	}

	// Token: 0x1700035E RID: 862
	// (get) Token: 0x06000DE6 RID: 3558 RVA: 0x00035F10 File Offset: 0x00034110
	bool global::System.Collections.Generic.ICollection<!0>.IsReadOnly
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06000DE7 RID: 3559 RVA: 0x00035F14 File Offset: 0x00034114
	bool global::System.Collections.Generic.ICollection<!0>.Remove(T item)
	{
		throw new global::System.NotSupportedException();
	}

	// Token: 0x06000DE8 RID: 3560 RVA: 0x00035F1C File Offset: 0x0003411C
	global::System.Collections.Generic.IEnumerator<T> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
	{
		return this.ilist.GetEnumerator();
	}

	// Token: 0x06000DE9 RID: 3561 RVA: 0x00035F2C File Offset: 0x0003412C
	global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
	{
		return this.olist.GetEnumerator();
	}

	// Token: 0x06000DEA RID: 3562 RVA: 0x00035F3C File Offset: 0x0003413C
	int global::System.Collections.IList.Add(object value)
	{
		throw new global::System.NotSupportedException();
	}

	// Token: 0x06000DEB RID: 3563 RVA: 0x00035F44 File Offset: 0x00034144
	void global::System.Collections.IList.Clear()
	{
		throw new global::System.NotSupportedException();
	}

	// Token: 0x06000DEC RID: 3564 RVA: 0x00035F4C File Offset: 0x0003414C
	bool global::System.Collections.IList.Contains(object value)
	{
		return this.olist.Contains(value);
	}

	// Token: 0x06000DED RID: 3565 RVA: 0x00035F5C File Offset: 0x0003415C
	int global::System.Collections.IList.IndexOf(object value)
	{
		return this.olist.IndexOf(value);
	}

	// Token: 0x06000DEE RID: 3566 RVA: 0x00035F6C File Offset: 0x0003416C
	void global::System.Collections.IList.Insert(int index, object value)
	{
		throw new global::System.NotSupportedException();
	}

	// Token: 0x1700035F RID: 863
	// (get) Token: 0x06000DEF RID: 3567 RVA: 0x00035F74 File Offset: 0x00034174
	bool global::System.Collections.IList.IsFixedSize
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000360 RID: 864
	// (get) Token: 0x06000DF0 RID: 3568 RVA: 0x00035F78 File Offset: 0x00034178
	bool global::System.Collections.IList.IsReadOnly
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06000DF1 RID: 3569 RVA: 0x00035F7C File Offset: 0x0003417C
	void global::System.Collections.IList.Remove(object value)
	{
		throw new global::System.NotSupportedException();
	}

	// Token: 0x06000DF2 RID: 3570 RVA: 0x00035F84 File Offset: 0x00034184
	void global::System.Collections.IList.RemoveAt(int index)
	{
		throw new global::System.NotSupportedException();
	}

	// Token: 0x17000361 RID: 865
	object global::System.Collections.IList.this[int index]
	{
		get
		{
			return this.olist[index];
		}
		set
		{
			throw new global::System.NotSupportedException();
		}
	}

	// Token: 0x06000DF5 RID: 3573 RVA: 0x00035FA4 File Offset: 0x000341A4
	void global::System.Collections.ICollection.CopyTo(global::System.Array array, int index)
	{
		this.olist.CopyTo(array, index);
	}

	// Token: 0x17000362 RID: 866
	// (get) Token: 0x06000DF6 RID: 3574 RVA: 0x00035FB4 File Offset: 0x000341B4
	int global::System.Collections.ICollection.Count
	{
		get
		{
			return this.olist.Count;
		}
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x06000DF7 RID: 3575 RVA: 0x00035FC4 File Offset: 0x000341C4
	bool global::System.Collections.ICollection.IsSynchronized
	{
		get
		{
			return this.olist.IsSynchronized;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x06000DF8 RID: 3576 RVA: 0x00035FD4 File Offset: 0x000341D4
	object global::System.Collections.ICollection.SyncRoot
	{
		get
		{
			return this.olist.SyncRoot;
		}
	}

	// Token: 0x17000365 RID: 869
	// (get) Token: 0x06000DF9 RID: 3577 RVA: 0x00035FE4 File Offset: 0x000341E4
	public static global::LockedList<T> Empty
	{
		get
		{
			return global::LockedList<T>.EmptyInstance.List;
		}
	}

	// Token: 0x17000366 RID: 870
	// (get) Token: 0x06000DFA RID: 3578 RVA: 0x00035FEC File Offset: 0x000341EC
	private global::System.Collections.Generic.IList<T> ilist
	{
		get
		{
			return this.list;
		}
	}

	// Token: 0x17000367 RID: 871
	// (get) Token: 0x06000DFB RID: 3579 RVA: 0x00035FF4 File Offset: 0x000341F4
	private global::System.Collections.IList olist
	{
		get
		{
			return this.list;
		}
	}

	// Token: 0x17000368 RID: 872
	public T this[int index]
	{
		get
		{
			return this.list[index];
		}
		set
		{
			throw new global::System.NotImplementedException();
		}
	}

	// Token: 0x17000369 RID: 873
	// (get) Token: 0x06000DFE RID: 3582 RVA: 0x00036014 File Offset: 0x00034214
	public int Count
	{
		get
		{
			return this.list.Count;
		}
	}

	// Token: 0x06000DFF RID: 3583 RVA: 0x00036024 File Offset: 0x00034224
	public global::System.Collections.Generic.List<T>.Enumerator GetEnumerator()
	{
		return this.list.GetEnumerator();
	}

	// Token: 0x06000E00 RID: 3584 RVA: 0x00036034 File Offset: 0x00034234
	public bool Equals(global::System.Collections.Generic.List<T> list)
	{
		return this.list.Equals(list);
	}

	// Token: 0x06000E01 RID: 3585 RVA: 0x00036044 File Offset: 0x00034244
	public override bool Equals(object obj)
	{
		return (!(obj is global::LockedList<T>)) ? (obj is global::System.Collections.Generic.List<T> && this.list.Equals(obj)) : this.list.Equals(((global::LockedList<T>)obj).list);
	}

	// Token: 0x06000E02 RID: 3586 RVA: 0x00036094 File Offset: 0x00034294
	public override int GetHashCode()
	{
		return this.list.GetHashCode();
	}

	// Token: 0x06000E03 RID: 3587 RVA: 0x000360A4 File Offset: 0x000342A4
	public override string ToString()
	{
		return this.list.ToString();
	}

	// Token: 0x06000E04 RID: 3588 RVA: 0x000360B4 File Offset: 0x000342B4
	public T[] ToArray()
	{
		return this.list.ToArray();
	}

	// Token: 0x06000E05 RID: 3589 RVA: 0x000360C4 File Offset: 0x000342C4
	public global::System.Collections.Generic.List<T> ToList()
	{
		return this.list.GetRange(0, this.list.Count);
	}

	// Token: 0x06000E06 RID: 3590 RVA: 0x000360E0 File Offset: 0x000342E0
	public void CopyTo(T[] array)
	{
		this.list.CopyTo(array);
	}

	// Token: 0x06000E07 RID: 3591 RVA: 0x000360F0 File Offset: 0x000342F0
	public void CopyTo(T[] array, int arrayIndex)
	{
		this.list.CopyTo(array, arrayIndex);
	}

	// Token: 0x06000E08 RID: 3592 RVA: 0x00036100 File Offset: 0x00034300
	public void CopyTo(int index, T[] array, int arrayIndex, int count)
	{
		this.list.CopyTo(index, array, arrayIndex, count);
	}

	// Token: 0x06000E09 RID: 3593 RVA: 0x00036114 File Offset: 0x00034314
	public global::System.Collections.Generic.List<TOutput> ConvertAll<TOutput>(global::System.Converter<T, TOutput> converter)
	{
		return this.list.ConvertAll<TOutput>(converter);
	}

	// Token: 0x06000E0A RID: 3594 RVA: 0x00036124 File Offset: 0x00034324
	public int BinarySearch(T item)
	{
		return this.list.BinarySearch(item);
	}

	// Token: 0x06000E0B RID: 3595 RVA: 0x00036134 File Offset: 0x00034334
	public int BinarySearch(int index, int count, T item, global::System.Collections.Generic.IComparer<T> comparer)
	{
		return this.list.BinarySearch(index, count, item, comparer);
	}

	// Token: 0x06000E0C RID: 3596 RVA: 0x00036148 File Offset: 0x00034348
	public int BinarySearch(T item, global::System.Collections.Generic.IComparer<T> comparer)
	{
		return this.list.BinarySearch(item, comparer);
	}

	// Token: 0x1700036A RID: 874
	// (get) Token: 0x06000E0D RID: 3597 RVA: 0x00036158 File Offset: 0x00034358
	public int Capacity
	{
		get
		{
			return this.list.Capacity;
		}
	}

	// Token: 0x06000E0E RID: 3598 RVA: 0x00036168 File Offset: 0x00034368
	public bool TrueForAll(global::System.Predicate<T> match)
	{
		return this.list.TrueForAll(match);
	}

	// Token: 0x06000E0F RID: 3599 RVA: 0x00036178 File Offset: 0x00034378
	public global::System.Collections.Generic.List<T> FindAll(global::System.Predicate<T> match)
	{
		return this.list.FindAll(match);
	}

	// Token: 0x06000E10 RID: 3600 RVA: 0x00036188 File Offset: 0x00034388
	public int FindIndex(global::System.Predicate<T> match)
	{
		return this.list.FindIndex(match);
	}

	// Token: 0x06000E11 RID: 3601 RVA: 0x00036198 File Offset: 0x00034398
	public T Find(global::System.Predicate<T> match)
	{
		return this.list.Find(match);
	}

	// Token: 0x06000E12 RID: 3602 RVA: 0x000361A8 File Offset: 0x000343A8
	public int FindLastIndex(global::System.Predicate<T> match)
	{
		return this.list.FindLastIndex(match);
	}

	// Token: 0x06000E13 RID: 3603 RVA: 0x000361B8 File Offset: 0x000343B8
	public T FindLast(global::System.Predicate<T> match)
	{
		return this.list.FindLast(match);
	}

	// Token: 0x06000E14 RID: 3604 RVA: 0x000361C8 File Offset: 0x000343C8
	public void ForEach(global::System.Action<T> action)
	{
		this.list.ForEach(action);
	}

	// Token: 0x06000E15 RID: 3605 RVA: 0x000361D8 File Offset: 0x000343D8
	public global::System.Collections.Generic.List<T> GetRange(int index, int count)
	{
		return this.list.GetRange(index, count);
	}

	// Token: 0x06000E16 RID: 3606 RVA: 0x000361E8 File Offset: 0x000343E8
	public int LastIndexOf(T item)
	{
		return this.list.LastIndexOf(item);
	}

	// Token: 0x06000E17 RID: 3607 RVA: 0x000361F8 File Offset: 0x000343F8
	public int LastIndexOf(T item, int index)
	{
		return this.list.LastIndexOf(item, index);
	}

	// Token: 0x06000E18 RID: 3608 RVA: 0x00036208 File Offset: 0x00034408
	public int LastIndexOf(T item, int index, int count)
	{
		return this.list.LastIndexOf(item, index, count);
	}

	// Token: 0x06000E19 RID: 3609 RVA: 0x00036218 File Offset: 0x00034418
	public int IndexOf(T item)
	{
		return this.list.IndexOf(item);
	}

	// Token: 0x06000E1A RID: 3610 RVA: 0x00036228 File Offset: 0x00034428
	public int IndexOf(T item, int index)
	{
		return this.list.IndexOf(item, index);
	}

	// Token: 0x06000E1B RID: 3611 RVA: 0x00036238 File Offset: 0x00034438
	public int IndexOf(T item, int index, int count)
	{
		return this.list.IndexOf(item, index, count);
	}

	// Token: 0x06000E1C RID: 3612 RVA: 0x00036248 File Offset: 0x00034448
	public bool Contains(T item)
	{
		return this.list.Contains(item);
	}

	// Token: 0x040008C2 RID: 2242
	private readonly global::System.Collections.Generic.List<T> list;

	// Token: 0x020001FF RID: 511
	private static class EmptyInstance
	{
		// Token: 0x06000E1D RID: 3613 RVA: 0x00036258 File Offset: 0x00034458
		// Note: this type is marked as 'beforefieldinit'.
		static EmptyInstance()
		{
		}

		// Token: 0x040008C3 RID: 2243
		public static readonly global::LockedList<T> List = new global::LockedList<T>();
	}
}
