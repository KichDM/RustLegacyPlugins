using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x020001A2 RID: 418
public sealed class GrabBag<T> : global::System.Collections.IEnumerable, global::System.Collections.Generic.IList<!0>, global::System.Collections.Generic.ICollection<!0>, global::System.Collections.Generic.IEnumerable<!0>
{
	// Token: 0x06000C41 RID: 3137 RVA: 0x0002EF18 File Offset: 0x0002D118
	public GrabBag(int capacity)
	{
		this._array = new T[capacity];
		this._length = 0;
	}

	// Token: 0x06000C42 RID: 3138 RVA: 0x0002EF34 File Offset: 0x0002D134
	public GrabBag()
	{
		this._array = global::EmptyArray<T>.array;
		this._length = 0;
	}

	// Token: 0x06000C43 RID: 3139 RVA: 0x0002EF50 File Offset: 0x0002D150
	public GrabBag(T[] copy)
	{
		if (copy == null || (this._length = copy.Length) == 0)
		{
			this._length = 0;
			this._array = global::EmptyArray<T>.array;
		}
		else
		{
			this._length = copy.Length;
			this._array = new T[this._length];
			global::System.Array.Copy(copy, this._array, this._length);
		}
	}

	// Token: 0x06000C44 RID: 3140 RVA: 0x0002EFC0 File Offset: 0x0002D1C0
	public GrabBag(global::GrabBag<T> copy)
	{
		if (copy == null || copy._length == 0)
		{
			this._length = 0;
			this._array = global::EmptyArray<T>.array;
		}
		else
		{
			this._length = copy._length;
			this._array = new T[this._length];
			global::System.Array.Copy(copy._array, this._array, this._length);
		}
	}

	// Token: 0x06000C45 RID: 3141 RVA: 0x0002F030 File Offset: 0x0002D230
	public GrabBag(global::System.Collections.Generic.ICollection<T> collection)
	{
		this._array = collection.ToArray<T>();
		this._length = this._array.Length;
	}

	// Token: 0x06000C46 RID: 3142 RVA: 0x0002F060 File Offset: 0x0002D260
	public GrabBag(global::System.Collections.Generic.IEnumerable<T> collection)
	{
		this._array = collection.ToArray<T>();
		this._length = this._array.Length;
	}

	// Token: 0x06000C47 RID: 3143 RVA: 0x0002F090 File Offset: 0x0002D290
	void global::System.Collections.Generic.ICollection<!0>.Add(T item)
	{
		int num = this.Grow(1);
		this._array[num] = item;
	}

	// Token: 0x06000C48 RID: 3144 RVA: 0x0002F0B4 File Offset: 0x0002D2B4
	global::System.Collections.Generic.IEnumerator<T> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
	{
		global::System.Collections.Generic.IEnumerator<T> result;
		if (this._length == 0)
		{
			global::System.Collections.Generic.IEnumerator<T> emptyEnumerator = global::EmptyArray<T>.emptyEnumerator;
			result = emptyEnumerator;
		}
		else
		{
			result = new global::GrabBag<T>.KlassEnumerator(this);
		}
		return result;
	}

	// Token: 0x06000C49 RID: 3145 RVA: 0x0002F0E0 File Offset: 0x0002D2E0
	global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
	{
		global::System.Collections.IEnumerator result;
		if (this._length == 0)
		{
			global::System.Collections.Generic.IEnumerator<T> emptyEnumerator = global::EmptyArray<T>.emptyEnumerator;
			result = emptyEnumerator;
		}
		else
		{
			result = new global::GrabBag<T>.KlassEnumerator(this);
		}
		return result;
	}

	// Token: 0x17000340 RID: 832
	// (get) Token: 0x06000C4A RID: 3146 RVA: 0x0002F10C File Offset: 0x0002D30C
	public int Count
	{
		get
		{
			return this._length;
		}
	}

	// Token: 0x17000341 RID: 833
	// (get) Token: 0x06000C4B RID: 3147 RVA: 0x0002F114 File Offset: 0x0002D314
	public int Capacity
	{
		get
		{
			return this._array.Length;
		}
	}

	// Token: 0x17000342 RID: 834
	// (get) Token: 0x06000C4C RID: 3148 RVA: 0x0002F120 File Offset: 0x0002D320
	public T[] Buffer
	{
		get
		{
			return this._array;
		}
	}

	// Token: 0x17000343 RID: 835
	// (get) Token: 0x06000C4D RID: 3149 RVA: 0x0002F128 File Offset: 0x0002D328
	public global::System.ArraySegment<T> ArraySegment
	{
		get
		{
			return new global::System.ArraySegment<T>(this._array, 0, this._length);
		}
	}

	// Token: 0x06000C4E RID: 3150 RVA: 0x0002F13C File Offset: 0x0002D33C
	public int Grow(int count)
	{
		int length = this._length;
		int num = this._length + count - this._array.Length;
		if (num > 0)
		{
			global::System.Array.Resize<T>(ref this._array, num / 2 * 4 + 1 + this._length);
		}
		this._length += count;
		return length;
	}

	// Token: 0x06000C4F RID: 3151 RVA: 0x0002F194 File Offset: 0x0002D394
	public void Shrink()
	{
		if (this._length < this._array.Length)
		{
			global::System.Array.Resize<T>(ref this._array, this._length);
		}
	}

	// Token: 0x06000C50 RID: 3152 RVA: 0x0002F1C8 File Offset: 0x0002D3C8
	public int Add(T item)
	{
		int num = this.Grow(1);
		this._array[num] = item;
		return num;
	}

	// Token: 0x06000C51 RID: 3153 RVA: 0x0002F1EC File Offset: 0x0002D3EC
	public void Insert(int index, T item)
	{
		int num = this.Grow(1);
		this._array[num] = this._array[index];
		this._array[index] = item;
	}

	// Token: 0x06000C52 RID: 3154 RVA: 0x0002F228 File Offset: 0x0002D428
	public bool Remove(T item)
	{
		int num = global::System.Array.IndexOf<T>(this._array, item, 0, this._length);
		if (num != -1)
		{
			this._array[num] = this._array[--this._length];
			this._array[this._length] = default(T);
			return true;
		}
		return false;
	}

	// Token: 0x06000C53 RID: 3155 RVA: 0x0002F298 File Offset: 0x0002D498
	public int RemoveAll(T item)
	{
		int num = 0;
		while (this.Remove(item))
		{
			num++;
		}
		return num;
	}

	// Token: 0x06000C54 RID: 3156 RVA: 0x0002F2C0 File Offset: 0x0002D4C0
	public void RemoveAt(int index)
	{
		this._array[index] = this._array[--this._length];
		this._array[this._length] = default(T);
	}

	// Token: 0x06000C55 RID: 3157 RVA: 0x0002F310 File Offset: 0x0002D510
	public int IndexOf(T item)
	{
		return (this._length != 0) ? global::System.Array.IndexOf<T>(this._array, item, 0, this._length) : -1;
	}

	// Token: 0x06000C56 RID: 3158 RVA: 0x0002F344 File Offset: 0x0002D544
	public int LastIndexOf(T item)
	{
		return (this._length != 0) ? global::System.Array.LastIndexOf<T>(this._array, item, 0, this._length) : -1;
	}

	// Token: 0x06000C57 RID: 3159 RVA: 0x0002F378 File Offset: 0x0002D578
	public int IndexOf(T item, int start)
	{
		return (this._length != 0) ? global::System.Array.IndexOf<T>(this._array, item, start, this._length - start) : -1;
	}

	// Token: 0x06000C58 RID: 3160 RVA: 0x0002F3AC File Offset: 0x0002D5AC
	public int LastIndexOf(T item, int start)
	{
		return (this._length != 0) ? global::System.Array.LastIndexOf<T>(this._array, item, start, this._length - start) : -1;
	}

	// Token: 0x06000C59 RID: 3161 RVA: 0x0002F3E0 File Offset: 0x0002D5E0
	public int IndexOf(T item, int start, int count)
	{
		return (this._length != 0) ? global::System.Array.IndexOf<T>(this._array, item, start, count) : -1;
	}

	// Token: 0x06000C5A RID: 3162 RVA: 0x0002F404 File Offset: 0x0002D604
	public int LastIndexOf(T item, int start, int count)
	{
		return (this._length != 0) ? global::System.Array.LastIndexOf<T>(this._array, item, start, count) : -1;
	}

	// Token: 0x06000C5B RID: 3163 RVA: 0x0002F428 File Offset: 0x0002D628
	public bool Contains(T item)
	{
		return global::System.Array.IndexOf<T>(this._array, item) != -1;
	}

	// Token: 0x06000C5C RID: 3164 RVA: 0x0002F43C File Offset: 0x0002D63C
	public void Reverse()
	{
		if (this._length > 0)
		{
			global::System.Array.Reverse(this._array, 0, this._length);
		}
	}

	// Token: 0x06000C5D RID: 3165 RVA: 0x0002F45C File Offset: 0x0002D65C
	public void Reverse(int start, int count)
	{
		if (this._length > 0)
		{
			global::System.Array.Reverse(this._array, start, count);
		}
	}

	// Token: 0x06000C5E RID: 3166 RVA: 0x0002F478 File Offset: 0x0002D678
	public void Sort()
	{
		if (this._length != 0)
		{
			global::System.Array.Sort<T>(this._array, 0, this._length);
		}
	}

	// Token: 0x06000C5F RID: 3167 RVA: 0x0002F498 File Offset: 0x0002D698
	public void Sort(int start, int count)
	{
		if (this._length != 0)
		{
			global::System.Array.Sort<T>(this._array, start, count);
		}
	}

	// Token: 0x06000C60 RID: 3168 RVA: 0x0002F4B4 File Offset: 0x0002D6B4
	public void Sort(global::System.Collections.Generic.IComparer<T> comparer)
	{
		if (this._length != 0)
		{
			global::System.Array.Sort<T>(this._array, 0, this._length, comparer);
		}
	}

	// Token: 0x06000C61 RID: 3169 RVA: 0x0002F4D4 File Offset: 0x0002D6D4
	public void Sort(global::System.Collections.Generic.IComparer<T> comparer, int start, int count)
	{
		if (this._length != 0)
		{
			global::System.Array.Sort<T>(this._array, start, count, comparer);
		}
	}

	// Token: 0x06000C62 RID: 3170 RVA: 0x0002F4F0 File Offset: 0x0002D6F0
	public void SortAsValue<K>(K[] keys)
	{
		global::System.Array.Sort<K, T>(keys, this._array, 0, this._length);
	}

	// Token: 0x06000C63 RID: 3171 RVA: 0x0002F508 File Offset: 0x0002D708
	public void SortAsValue<K>(K[] keys, global::System.Collections.Generic.IComparer<K> comparer)
	{
		global::System.Array.Sort<K, T>(keys, this._array, 0, this._length, comparer);
	}

	// Token: 0x06000C64 RID: 3172 RVA: 0x0002F520 File Offset: 0x0002D720
	public void SortAsValue<K>(K[] keys, int start, int count)
	{
		global::System.Array.Sort<K, T>(keys, this._array, start, count);
	}

	// Token: 0x06000C65 RID: 3173 RVA: 0x0002F530 File Offset: 0x0002D730
	public void SortAsValue<K>(K[] keys, int start, int count, global::System.Collections.Generic.IComparer<K> comparer)
	{
		global::System.Array.Sort<K, T>(keys, this._array, start, count, comparer);
	}

	// Token: 0x06000C66 RID: 3174 RVA: 0x0002F544 File Offset: 0x0002D744
	public void SortAsKey<V>(V[] values)
	{
		global::System.Array.Sort<T, V>(this._array, values, 0, this._length);
	}

	// Token: 0x06000C67 RID: 3175 RVA: 0x0002F55C File Offset: 0x0002D75C
	public void SortAsKey<V>(V[] values, global::System.Collections.Generic.IComparer<T> comparer)
	{
		global::System.Array.Sort<T, V>(this._array, values, 0, this._length, comparer);
	}

	// Token: 0x06000C68 RID: 3176 RVA: 0x0002F574 File Offset: 0x0002D774
	public void SortAsKey<V>(V[] values, int start, int count)
	{
		global::System.Array.Sort<T, V>(this._array, values, start, count);
	}

	// Token: 0x06000C69 RID: 3177 RVA: 0x0002F584 File Offset: 0x0002D784
	public void SortAsKey<V>(V[] values, int start, int count, global::System.Collections.Generic.IComparer<T> comparer)
	{
		global::System.Array.Sort<T, V>(this._array, values, start, count, comparer);
	}

	// Token: 0x06000C6A RID: 3178 RVA: 0x0002F598 File Offset: 0x0002D798
	public void Clear()
	{
		while (this._length > 0)
		{
			this._array[--this._length] = default(T);
		}
	}

	// Token: 0x17000344 RID: 836
	public T this[int i]
	{
		get
		{
			return this._array[i];
		}
		set
		{
			this._array[i] = value;
		}
	}

	// Token: 0x06000C6D RID: 3181 RVA: 0x0002F5FC File Offset: 0x0002D7FC
	public void CopyTo(T[] array, int arrayIndex)
	{
		for (int i = 0; i < this._length; i++)
		{
			array[arrayIndex++] = this._array[i];
		}
	}

	// Token: 0x17000345 RID: 837
	// (get) Token: 0x06000C6E RID: 3182 RVA: 0x0002F638 File Offset: 0x0002D838
	public bool IsReadOnly
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06000C6F RID: 3183 RVA: 0x0002F63C File Offset: 0x0002D83C
	public global::GrabBag<T>.Enumerator GetEnumerator()
	{
		global::GrabBag<T>.Enumerator result;
		result.array = this;
		result.nonNull = true;
		result.index = -1;
		return result;
	}

	// Token: 0x06000C70 RID: 3184 RVA: 0x0002F664 File Offset: 0x0002D864
	public T[] ToArray()
	{
		if (this._length == 0)
		{
			return global::EmptyArray<T>.array;
		}
		T[] array = new T[this._length];
		global::System.Array.Copy(this._array, array, this._length);
		return array;
	}

	// Token: 0x06000C71 RID: 3185 RVA: 0x0002F6A4 File Offset: 0x0002D8A4
	public override string ToString()
	{
		return string.Format(global::GrabBag<T>.StringGetter.Format, this.Count, this.Capacity);
	}

	// Token: 0x0400081C RID: 2076
	private T[] _array;

	// Token: 0x0400081D RID: 2077
	private int _length;

	// Token: 0x020001A3 RID: 419
	public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<!0>
	{
		// Token: 0x17000346 RID: 838
		// (get) Token: 0x06000C72 RID: 3186 RVA: 0x0002F6D4 File Offset: 0x0002D8D4
		object global::System.Collections.IEnumerator.Current
		{
			get
			{
				return this.array._array[this.index];
			}
		}

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x06000C73 RID: 3187 RVA: 0x0002F6F4 File Offset: 0x0002D8F4
		public T Current
		{
			get
			{
				return this.array._array[this.index];
			}
		}

		// Token: 0x06000C74 RID: 3188 RVA: 0x0002F70C File Offset: 0x0002D90C
		public bool MoveNext()
		{
			return this.nonNull && ++this.index < this.array._length;
		}

		// Token: 0x06000C75 RID: 3189 RVA: 0x0002F748 File Offset: 0x0002D948
		public void Reset()
		{
			this.index = -1;
		}

		// Token: 0x06000C76 RID: 3190 RVA: 0x0002F754 File Offset: 0x0002D954
		public void Dispose()
		{
			this = default(global::GrabBag<T>.Enumerator);
		}

		// Token: 0x0400081E RID: 2078
		public global::GrabBag<T> array;

		// Token: 0x0400081F RID: 2079
		public int index;

		// Token: 0x04000820 RID: 2080
		public bool nonNull;
	}

	// Token: 0x020001A4 RID: 420
	private class KlassEnumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<!0>
	{
		// Token: 0x06000C77 RID: 3191 RVA: 0x0002F770 File Offset: 0x0002D970
		public KlassEnumerator(global::GrabBag<T> array)
		{
			this.array = array;
			this.index = -1;
		}

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06000C78 RID: 3192 RVA: 0x0002F788 File Offset: 0x0002D988
		object global::System.Collections.IEnumerator.Current
		{
			get
			{
				return this.array._array[this.index];
			}
		}

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06000C79 RID: 3193 RVA: 0x0002F7A8 File Offset: 0x0002D9A8
		public T Current
		{
			get
			{
				return this.array._array[this.index];
			}
		}

		// Token: 0x06000C7A RID: 3194 RVA: 0x0002F7C0 File Offset: 0x0002D9C0
		public bool MoveNext()
		{
			return ++this.index < this.array._length;
		}

		// Token: 0x06000C7B RID: 3195 RVA: 0x0002F7EC File Offset: 0x0002D9EC
		public void Reset()
		{
			this.index = -1;
		}

		// Token: 0x06000C7C RID: 3196 RVA: 0x0002F7F8 File Offset: 0x0002D9F8
		public void Dispose()
		{
			this.array = null;
		}

		// Token: 0x04000821 RID: 2081
		public global::GrabBag<T> array;

		// Token: 0x04000822 RID: 2082
		public int index;
	}

	// Token: 0x020001A5 RID: 421
	private static class StringGetter
	{
		// Token: 0x06000C7D RID: 3197 RVA: 0x0002F804 File Offset: 0x0002DA04
		// Note: this type is marked as 'beforefieldinit'.
		static StringGetter()
		{
		}

		// Token: 0x04000823 RID: 2083
		public static readonly string Format = "[DynArray<" + typeof(T).Name + ">: Count={0}, Capacity={1}]";
	}
}
