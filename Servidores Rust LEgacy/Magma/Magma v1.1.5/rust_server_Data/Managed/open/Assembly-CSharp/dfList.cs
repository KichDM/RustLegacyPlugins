using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x0200081E RID: 2078
public class dfList<T> : global::System.IDisposable, global::System.Collections.IEnumerable, global::System.Collections.Generic.ICollection<!0>, global::System.Collections.Generic.IList<!0>, global::System.Collections.Generic.IEnumerable<!0>
{
	// Token: 0x06004614 RID: 17940 RVA: 0x001016B0 File Offset: 0x000FF8B0
	internal dfList()
	{
	}

	// Token: 0x06004615 RID: 17941 RVA: 0x001016C8 File Offset: 0x000FF8C8
	internal dfList(global::System.Collections.Generic.IList<T> listToClone)
	{
		this.AddRange(listToClone);
	}

	// Token: 0x06004616 RID: 17942 RVA: 0x001016E8 File Offset: 0x000FF8E8
	internal dfList(int capacity)
	{
		this.EnsureCapacity(capacity);
	}

	// Token: 0x06004617 RID: 17943 RVA: 0x00101708 File Offset: 0x000FF908
	// Note: this type is marked as 'beforefieldinit'.
	static dfList()
	{
	}

	// Token: 0x06004618 RID: 17944 RVA: 0x00101714 File Offset: 0x000FF914
	global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
	{
		return global::dfList<T>.PooledEnumerator.Obtain(this, null);
	}

	// Token: 0x06004619 RID: 17945 RVA: 0x00101720 File Offset: 0x000FF920
	public static global::dfList<T> Obtain()
	{
		return (global::dfList<T>.pool.Count <= 0) ? new global::dfList<T>() : ((global::dfList<T>)global::dfList<T>.pool.Dequeue());
	}

	// Token: 0x0600461A RID: 17946 RVA: 0x0010174C File Offset: 0x000FF94C
	internal static global::dfList<T> Obtain(int capacity)
	{
		global::dfList<T> dfList = global::dfList<T>.Obtain();
		dfList.EnsureCapacity(capacity);
		return dfList;
	}

	// Token: 0x17000D10 RID: 3344
	// (get) Token: 0x0600461B RID: 17947 RVA: 0x00101768 File Offset: 0x000FF968
	public int Count
	{
		get
		{
			return this.count;
		}
	}

	// Token: 0x17000D11 RID: 3345
	// (get) Token: 0x0600461C RID: 17948 RVA: 0x00101770 File Offset: 0x000FF970
	internal int Capacity
	{
		get
		{
			return this.items.Length;
		}
	}

	// Token: 0x17000D12 RID: 3346
	// (get) Token: 0x0600461D RID: 17949 RVA: 0x0010177C File Offset: 0x000FF97C
	public bool IsReadOnly
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000D13 RID: 3347
	public T this[int index]
	{
		get
		{
			if (index < 0 || index > this.count - 1)
			{
				throw new global::System.IndexOutOfRangeException();
			}
			return this.items[index];
		}
		set
		{
			if (index < 0 || index > this.count - 1)
			{
				throw new global::System.IndexOutOfRangeException();
			}
			this.items[index] = value;
		}
	}

	// Token: 0x17000D14 RID: 3348
	// (get) Token: 0x06004620 RID: 17952 RVA: 0x001017E4 File Offset: 0x000FF9E4
	internal T[] Items
	{
		get
		{
			return this.items;
		}
	}

	// Token: 0x06004621 RID: 17953 RVA: 0x001017EC File Offset: 0x000FF9EC
	public void Enqueue(T item)
	{
		this.Add(item);
	}

	// Token: 0x06004622 RID: 17954 RVA: 0x001017F8 File Offset: 0x000FF9F8
	public T Dequeue()
	{
		if (this.count == 0)
		{
			throw new global::System.IndexOutOfRangeException();
		}
		T result = this.items[0];
		this.RemoveAt(0);
		return result;
	}

	// Token: 0x06004623 RID: 17955 RVA: 0x0010182C File Offset: 0x000FFA2C
	public global::dfList<T> Clone()
	{
		global::dfList<T> dfList = global::dfList<T>.Obtain(this.count);
		global::System.Array.Copy(this.items, dfList.items, this.count);
		dfList.count = this.count;
		return dfList;
	}

	// Token: 0x06004624 RID: 17956 RVA: 0x0010186C File Offset: 0x000FFA6C
	public void Release()
	{
		this.Clear();
		global::dfList<T>.pool.Enqueue(this);
	}

	// Token: 0x06004625 RID: 17957 RVA: 0x00101880 File Offset: 0x000FFA80
	public void Reverse()
	{
		global::System.Array.Reverse(this.items, 0, this.count);
	}

	// Token: 0x06004626 RID: 17958 RVA: 0x00101894 File Offset: 0x000FFA94
	public void Sort()
	{
		global::System.Array.Sort<T>(this.items, 0, this.count, null);
	}

	// Token: 0x06004627 RID: 17959 RVA: 0x001018AC File Offset: 0x000FFAAC
	public void Sort(global::System.Collections.Generic.IComparer<T> comparer)
	{
		global::System.Array.Sort<T>(this.items, 0, this.count, comparer);
	}

	// Token: 0x06004628 RID: 17960 RVA: 0x001018C4 File Offset: 0x000FFAC4
	public void Sort(global::System.Comparison<T> comparison)
	{
		if (comparison == null)
		{
			throw new global::System.ArgumentNullException("comparison");
		}
		if (this.count > 0)
		{
			using (global::dfList<T>.FunctorComparer functorComparer = global::dfList<T>.FunctorComparer.Obtain(comparison))
			{
				global::System.Array.Sort<T>(this.items, 0, this.count, functorComparer);
			}
		}
	}

	// Token: 0x06004629 RID: 17961 RVA: 0x00101938 File Offset: 0x000FFB38
	public void EnsureCapacity(int Size)
	{
		if (this.items.Length < Size)
		{
			int newSize = Size / 0x80 * 0x80 + 0x80;
			global::System.Array.Resize<T>(ref this.items, newSize);
		}
	}

	// Token: 0x0600462A RID: 17962 RVA: 0x00101974 File Offset: 0x000FFB74
	public void AddRange(global::dfList<T> list)
	{
		this.EnsureCapacity(this.count + list.Count);
		global::System.Array.Copy(list.items, 0, this.items, this.count, list.Count);
		this.count += list.Count;
	}

	// Token: 0x0600462B RID: 17963 RVA: 0x001019C8 File Offset: 0x000FFBC8
	public void AddRange(global::System.Collections.Generic.IList<T> list)
	{
		this.EnsureCapacity(this.count + list.Count);
		for (int i = 0; i < list.Count; i++)
		{
			this.items[this.count++] = list[i];
		}
	}

	// Token: 0x0600462C RID: 17964 RVA: 0x00101A24 File Offset: 0x000FFC24
	public void AddRange(T[] list)
	{
		this.EnsureCapacity(this.count + list.Length);
		global::System.Array.Copy(list, 0, this.items, this.count, list.Length);
		this.count += list.Length;
	}

	// Token: 0x0600462D RID: 17965 RVA: 0x00101A68 File Offset: 0x000FFC68
	public int IndexOf(T item)
	{
		return global::System.Array.IndexOf<T>(this.items, item, 0, this.count);
	}

	// Token: 0x0600462E RID: 17966 RVA: 0x00101A80 File Offset: 0x000FFC80
	public void Insert(int index, T item)
	{
		this.EnsureCapacity(this.count + 1);
		if (index < this.count)
		{
			global::System.Array.Copy(this.items, index, this.items, index + 1, this.count - index);
		}
		this.items[index] = item;
		this.count++;
	}

	// Token: 0x0600462F RID: 17967 RVA: 0x00101AE0 File Offset: 0x000FFCE0
	public void InsertRange(int index, T[] array)
	{
		if (array == null)
		{
			throw new global::System.ArgumentNullException("items");
		}
		if (index < 0 || index > this.count)
		{
			throw new global::System.ArgumentOutOfRangeException("index");
		}
		this.EnsureCapacity(this.count + array.Length);
		if (index < this.count)
		{
			global::System.Array.Copy(this.items, index, this.items, index + array.Length, this.count - index);
		}
		array.CopyTo(this.items, index);
		this.count += array.Length;
	}

	// Token: 0x06004630 RID: 17968 RVA: 0x00101B74 File Offset: 0x000FFD74
	public void InsertRange(int index, global::dfList<T> list)
	{
		if (list == null)
		{
			throw new global::System.ArgumentNullException("items");
		}
		if (index < 0 || index > this.count)
		{
			throw new global::System.ArgumentOutOfRangeException("index");
		}
		this.EnsureCapacity(this.count + list.count);
		if (index < this.count)
		{
			global::System.Array.Copy(this.items, index, this.items, index + list.count, this.count - index);
		}
		global::System.Array.Copy(list.items, 0, this.items, index, list.count);
		this.count += list.count;
	}

	// Token: 0x06004631 RID: 17969 RVA: 0x00101C20 File Offset: 0x000FFE20
	public void RemoveAll(global::System.Predicate<T> predicate)
	{
		int i = 0;
		while (i < this.count)
		{
			if (predicate(this.items[i]))
			{
				this.RemoveAt(i);
			}
			else
			{
				i++;
			}
		}
	}

	// Token: 0x06004632 RID: 17970 RVA: 0x00101C68 File Offset: 0x000FFE68
	public void RemoveAt(int index)
	{
		if (index >= this.count)
		{
			throw new global::System.ArgumentOutOfRangeException();
		}
		this.count--;
		if (index < this.count)
		{
			global::System.Array.Copy(this.items, index + 1, this.items, index, this.count - index);
		}
		this.items[this.count] = default(T);
	}

	// Token: 0x06004633 RID: 17971 RVA: 0x00101CD8 File Offset: 0x000FFED8
	public void RemoveRange(int index, int length)
	{
		if (index < 0 || length < 0 || this.count - index < length)
		{
			throw new global::System.ArgumentOutOfRangeException();
		}
		if (this.count > 0)
		{
			this.count -= length;
			if (index < this.count)
			{
				global::System.Array.Copy(this.items, index + length, this.items, index, this.count - index);
			}
			global::System.Array.Clear(this.items, this.count, length);
		}
	}

	// Token: 0x06004634 RID: 17972 RVA: 0x00101D5C File Offset: 0x000FFF5C
	public void Add(T item)
	{
		this.EnsureCapacity(this.count + 1);
		this.items[this.count++] = item;
	}

	// Token: 0x06004635 RID: 17973 RVA: 0x00101D94 File Offset: 0x000FFF94
	public void Clear()
	{
		global::System.Array.Clear(this.items, 0, this.items.Length);
		this.count = 0;
	}

	// Token: 0x06004636 RID: 17974 RVA: 0x00101DB4 File Offset: 0x000FFFB4
	public void TrimExcess()
	{
		global::System.Array.Resize<T>(ref this.items, this.count);
	}

	// Token: 0x06004637 RID: 17975 RVA: 0x00101DC8 File Offset: 0x000FFFC8
	public bool Contains(T item)
	{
		if (item == null)
		{
			for (int i = 0; i < this.count; i++)
			{
				if (this.items[i] == null)
				{
					return true;
				}
			}
			return false;
		}
		global::System.Collections.Generic.EqualityComparer<T> @default = global::System.Collections.Generic.EqualityComparer<T>.Default;
		for (int j = 0; j < this.count; j++)
		{
			if (@default.Equals(this.items[j], item))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06004638 RID: 17976 RVA: 0x00101E4C File Offset: 0x0010004C
	public void CopyTo(T[] array)
	{
		this.CopyTo(array, 0);
	}

	// Token: 0x06004639 RID: 17977 RVA: 0x00101E58 File Offset: 0x00100058
	public void CopyTo(T[] array, int arrayIndex)
	{
		global::System.Array.Copy(this.items, 0, array, arrayIndex, this.count);
	}

	// Token: 0x0600463A RID: 17978 RVA: 0x00101E70 File Offset: 0x00100070
	public void CopyTo(int sourceIndex, T[] dest, int destIndex, int length)
	{
		if (sourceIndex + length > this.count)
		{
			throw new global::System.IndexOutOfRangeException("sourceIndex");
		}
		if (dest == null)
		{
			throw new global::System.ArgumentNullException("dest");
		}
		if (destIndex + length > dest.Length)
		{
			throw new global::System.IndexOutOfRangeException("destIndex");
		}
		global::System.Array.Copy(this.items, sourceIndex, dest, destIndex, length);
	}

	// Token: 0x0600463B RID: 17979 RVA: 0x00101ED0 File Offset: 0x001000D0
	public bool Remove(T item)
	{
		int num = this.IndexOf(item);
		if (num == -1)
		{
			return false;
		}
		this.RemoveAt(num);
		return true;
	}

	// Token: 0x0600463C RID: 17980 RVA: 0x00101EF8 File Offset: 0x001000F8
	public T[] ToArray()
	{
		T[] array = new T[this.count];
		global::System.Array.Copy(this.items, array, this.count);
		return array;
	}

	// Token: 0x0600463D RID: 17981 RVA: 0x00101F24 File Offset: 0x00100124
	public T[] ToArray(int index, int length)
	{
		T[] array = new T[this.count];
		if (this.count > 0)
		{
			this.CopyTo(index, array, 0, length);
		}
		return array;
	}

	// Token: 0x0600463E RID: 17982 RVA: 0x00101F54 File Offset: 0x00100154
	public global::dfList<T> GetRange(int index, int length)
	{
		global::dfList<T> dfList = global::dfList<T>.Obtain(length);
		this.CopyTo(0, dfList.items, index, length);
		return dfList;
	}

	// Token: 0x0600463F RID: 17983 RVA: 0x00101F78 File Offset: 0x00100178
	public bool Any(global::System.Func<T, bool> predicate)
	{
		for (int i = 0; i < this.count; i++)
		{
			if (predicate(this.items[i]))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06004640 RID: 17984 RVA: 0x00101FB8 File Offset: 0x001001B8
	public T First()
	{
		if (this.count == 0)
		{
			throw new global::System.IndexOutOfRangeException();
		}
		return this.items[0];
	}

	// Token: 0x06004641 RID: 17985 RVA: 0x00101FD8 File Offset: 0x001001D8
	public T FirstOrDefault()
	{
		if (this.count > 0)
		{
			return this.items[0];
		}
		return default(T);
	}

	// Token: 0x06004642 RID: 17986 RVA: 0x00102008 File Offset: 0x00100208
	public T FirstOrDefault(global::System.Func<T, bool> predicate)
	{
		for (int i = 0; i < this.count; i++)
		{
			if (predicate(this.items[i]))
			{
				return this.items[i];
			}
		}
		return default(T);
	}

	// Token: 0x06004643 RID: 17987 RVA: 0x0010205C File Offset: 0x0010025C
	public T Last()
	{
		if (this.count == 0)
		{
			throw new global::System.IndexOutOfRangeException();
		}
		return this.items[this.count - 1];
	}

	// Token: 0x06004644 RID: 17988 RVA: 0x00102090 File Offset: 0x00100290
	public T LastOrDefault()
	{
		if (this.count == 0)
		{
			return default(T);
		}
		return this.items[this.count - 1];
	}

	// Token: 0x06004645 RID: 17989 RVA: 0x001020C8 File Offset: 0x001002C8
	public T LastOrDefault(global::System.Func<T, bool> predicate)
	{
		T result = default(T);
		for (int i = 0; i < this.count; i++)
		{
			if (predicate(this.items[i]))
			{
				result = this.items[i];
			}
		}
		return result;
	}

	// Token: 0x06004646 RID: 17990 RVA: 0x0010211C File Offset: 0x0010031C
	public global::dfList<T> Where(global::System.Func<T, bool> predicate)
	{
		global::dfList<T> dfList = global::dfList<T>.Obtain(this.count);
		for (int i = 0; i < this.count; i++)
		{
			if (predicate(this.items[i]))
			{
				dfList.Add(this.items[i]);
			}
		}
		return dfList;
	}

	// Token: 0x06004647 RID: 17991 RVA: 0x00102178 File Offset: 0x00100378
	public int Matching(global::System.Func<T, bool> predicate)
	{
		int num = 0;
		for (int i = 0; i < this.count; i++)
		{
			if (predicate(this.items[i]))
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x06004648 RID: 17992 RVA: 0x001021BC File Offset: 0x001003BC
	public global::dfList<TResult> Select<TResult>(global::System.Func<T, TResult> selector)
	{
		global::dfList<TResult> dfList = global::dfList<TResult>.Obtain(this.count);
		for (int i = 0; i < this.count; i++)
		{
			dfList.Add(selector(this.items[i]));
		}
		return dfList;
	}

	// Token: 0x06004649 RID: 17993 RVA: 0x00102208 File Offset: 0x00100408
	public global::dfList<T> Concat(global::dfList<T> list)
	{
		global::dfList<T> dfList = global::dfList<T>.Obtain(this.count + list.count);
		dfList.AddRange(this);
		dfList.AddRange(list);
		return dfList;
	}

	// Token: 0x0600464A RID: 17994 RVA: 0x00102238 File Offset: 0x00100438
	public global::dfList<TResult> Convert<TResult>()
	{
		global::dfList<TResult> dfList = global::dfList<TResult>.Obtain(this.count);
		for (int i = 0; i < this.count; i++)
		{
			dfList.Add((TResult)((object)global::System.Convert.ChangeType(this.items[i], typeof(TResult))));
		}
		return dfList;
	}

	// Token: 0x0600464B RID: 17995 RVA: 0x00102294 File Offset: 0x00100494
	public void ForEach(global::System.Action<T> action)
	{
		int i = 0;
		while (i < this.Count)
		{
			action(this.items[i++]);
		}
	}

	// Token: 0x0600464C RID: 17996 RVA: 0x001022CC File Offset: 0x001004CC
	public global::System.Collections.Generic.IEnumerator<T> GetEnumerator()
	{
		return global::dfList<T>.PooledEnumerator.Obtain(this, null);
	}

	// Token: 0x0600464D RID: 17997 RVA: 0x001022D8 File Offset: 0x001004D8
	public void Dispose()
	{
		this.Release();
	}

	// Token: 0x040025F6 RID: 9718
	private const int DEFAULT_CAPACITY = 0x80;

	// Token: 0x040025F7 RID: 9719
	private static global::System.Collections.Generic.Queue<object> pool = new global::System.Collections.Generic.Queue<object>();

	// Token: 0x040025F8 RID: 9720
	private T[] items = new T[0x80];

	// Token: 0x040025F9 RID: 9721
	private int count;

	// Token: 0x0200081F RID: 2079
	private class PooledEnumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<!0>, global::System.Collections.Generic.IEnumerator<!0>
	{
		// Token: 0x0600464E RID: 17998 RVA: 0x001022E0 File Offset: 0x001004E0
		public PooledEnumerator()
		{
		}

		// Token: 0x0600464F RID: 17999 RVA: 0x001022E8 File Offset: 0x001004E8
		// Note: this type is marked as 'beforefieldinit'.
		static PooledEnumerator()
		{
		}

		// Token: 0x17000D15 RID: 3349
		// (get) Token: 0x06004650 RID: 18000 RVA: 0x001022F4 File Offset: 0x001004F4
		object global::System.Collections.IEnumerator.Current
		{
			get
			{
				return this.Current;
			}
		}

		// Token: 0x06004651 RID: 18001 RVA: 0x00102304 File Offset: 0x00100504
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this;
		}

		// Token: 0x06004652 RID: 18002 RVA: 0x00102308 File Offset: 0x00100508
		public static global::dfList<T>.PooledEnumerator Obtain(global::dfList<T> list, global::System.Func<T, bool> predicate = null)
		{
			global::dfList<T>.PooledEnumerator pooledEnumerator = (global::dfList<T>.PooledEnumerator.pool.Count <= 0) ? new global::dfList<T>.PooledEnumerator() : global::dfList<T>.PooledEnumerator.pool.Dequeue();
			pooledEnumerator.ResetInternal(list, predicate);
			return pooledEnumerator;
		}

		// Token: 0x06004653 RID: 18003 RVA: 0x00102344 File Offset: 0x00100544
		public void Release()
		{
			if (this.isValid)
			{
				this.isValid = false;
				global::dfList<T>.PooledEnumerator.pool.Enqueue(this);
			}
		}

		// Token: 0x17000D16 RID: 3350
		// (get) Token: 0x06004654 RID: 18004 RVA: 0x00102364 File Offset: 0x00100564
		public T Current
		{
			get
			{
				if (!this.isValid)
				{
					throw new global::System.InvalidOperationException("The enumerator is no longer valid");
				}
				return this.currentValue;
			}
		}

		// Token: 0x06004655 RID: 18005 RVA: 0x00102384 File Offset: 0x00100584
		private void ResetInternal(global::dfList<T> list, global::System.Func<T, bool> predicate = null)
		{
			this.isValid = true;
			this.list = list;
			this.predicate = predicate;
			this.currentIndex = 0;
			this.currentValue = default(T);
		}

		// Token: 0x06004656 RID: 18006 RVA: 0x001023BC File Offset: 0x001005BC
		public void Dispose()
		{
			this.Release();
		}

		// Token: 0x06004657 RID: 18007 RVA: 0x001023C4 File Offset: 0x001005C4
		public bool MoveNext()
		{
			if (!this.isValid)
			{
				throw new global::System.InvalidOperationException("The enumerator is no longer valid");
			}
			while (this.currentIndex < this.list.Count)
			{
				T arg = this.list[this.currentIndex++];
				if (this.predicate == null || this.predicate(arg))
				{
					this.currentValue = arg;
					return true;
				}
			}
			this.Release();
			this.currentValue = default(T);
			return false;
		}

		// Token: 0x06004658 RID: 18008 RVA: 0x00102460 File Offset: 0x00100660
		public void Reset()
		{
			throw new global::System.NotImplementedException();
		}

		// Token: 0x06004659 RID: 18009 RVA: 0x00102468 File Offset: 0x00100668
		public global::System.Collections.Generic.IEnumerator<T> GetEnumerator()
		{
			return this;
		}

		// Token: 0x040025FA RID: 9722
		private static global::System.Collections.Generic.Queue<global::dfList<T>.PooledEnumerator> pool = new global::System.Collections.Generic.Queue<global::dfList<T>.PooledEnumerator>();

		// Token: 0x040025FB RID: 9723
		private global::dfList<T> list;

		// Token: 0x040025FC RID: 9724
		private global::System.Func<T, bool> predicate;

		// Token: 0x040025FD RID: 9725
		private int currentIndex;

		// Token: 0x040025FE RID: 9726
		private T currentValue;

		// Token: 0x040025FF RID: 9727
		private bool isValid;
	}

	// Token: 0x02000820 RID: 2080
	private class FunctorComparer : global::System.IDisposable, global::System.Collections.Generic.IComparer<T>
	{
		// Token: 0x0600465A RID: 18010 RVA: 0x0010246C File Offset: 0x0010066C
		public FunctorComparer()
		{
		}

		// Token: 0x0600465B RID: 18011 RVA: 0x00102474 File Offset: 0x00100674
		// Note: this type is marked as 'beforefieldinit'.
		static FunctorComparer()
		{
		}

		// Token: 0x0600465C RID: 18012 RVA: 0x00102480 File Offset: 0x00100680
		public static global::dfList<T>.FunctorComparer Obtain(global::System.Comparison<T> comparison)
		{
			global::dfList<T>.FunctorComparer functorComparer = (global::dfList<T>.FunctorComparer.pool.Count <= 0) ? new global::dfList<T>.FunctorComparer() : global::dfList<T>.FunctorComparer.pool.Dequeue();
			functorComparer.comparison = comparison;
			return functorComparer;
		}

		// Token: 0x0600465D RID: 18013 RVA: 0x001024BC File Offset: 0x001006BC
		public void Release()
		{
			this.comparison = null;
			if (!global::dfList<T>.FunctorComparer.pool.Contains(this))
			{
				global::dfList<T>.FunctorComparer.pool.Enqueue(this);
			}
		}

		// Token: 0x0600465E RID: 18014 RVA: 0x001024EC File Offset: 0x001006EC
		public int Compare(T x, T y)
		{
			return this.comparison(x, y);
		}

		// Token: 0x0600465F RID: 18015 RVA: 0x001024FC File Offset: 0x001006FC
		public void Dispose()
		{
			this.Release();
		}

		// Token: 0x04002600 RID: 9728
		private static global::System.Collections.Generic.Queue<global::dfList<T>.FunctorComparer> pool = new global::System.Collections.Generic.Queue<global::dfList<T>.FunctorComparer>();

		// Token: 0x04002601 RID: 9729
		private global::System.Comparison<T> comparison;
	}
}
