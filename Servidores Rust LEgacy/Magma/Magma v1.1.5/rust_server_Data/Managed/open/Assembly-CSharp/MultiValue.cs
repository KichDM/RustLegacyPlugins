using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x02000190 RID: 400
public class MultiValue<TValue> : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<!0>, global::System.Collections.Generic.ICollection<!0>, global::System.Collections.Generic.IList<!0>, global::System.ICloneable
{
	// Token: 0x06000BA9 RID: 2985 RVA: 0x0002D340 File Offset: 0x0002B540
	private MultiValue(bool ignore)
	{
	}

	// Token: 0x06000BAA RID: 2986 RVA: 0x0002D348 File Offset: 0x0002B548
	public MultiValue()
	{
		this.list = new global::System.Collections.Generic.List<TValue>();
		this.hashSet = new global::System.Collections.Generic.HashSet<TValue>();
	}

	// Token: 0x06000BAB RID: 2987 RVA: 0x0002D368 File Offset: 0x0002B568
	private MultiValue(global::System.Collections.Generic.IEqualityComparer<TValue> comparer, global::MultiValue<TValue> mv)
	{
		this.list = new global::System.Collections.Generic.List<TValue>(mv.list);
		this.hashSet = new global::System.Collections.Generic.HashSet<TValue>(mv.hashSet, comparer);
		this.count = mv.count;
	}

	// Token: 0x06000BAC RID: 2988 RVA: 0x0002D3A0 File Offset: 0x0002B5A0
	public MultiValue(global::System.Collections.Generic.IEnumerable<TValue> v)
	{
		this.hashSet = new global::System.Collections.Generic.HashSet<TValue>();
		global::MultiValue<TValue>.InitData initData;
		initData.mv = this;
		using (initData.enumerator = v.GetEnumerator())
		{
			initData.RecurseInit();
		}
	}

	// Token: 0x06000BAD RID: 2989 RVA: 0x0002D40C File Offset: 0x0002B60C
	public MultiValue(global::System.Collections.Generic.IEnumerable<TValue> v, global::System.Collections.Generic.IEqualityComparer<TValue> equalityComparer)
	{
		this.hashSet = new global::System.Collections.Generic.HashSet<TValue>(equalityComparer);
		global::MultiValue<TValue>.InitData initData;
		initData.mv = this;
		using (initData.enumerator = v.GetEnumerator())
		{
			initData.RecurseInit();
		}
	}

	// Token: 0x06000BAE RID: 2990 RVA: 0x0002D47C File Offset: 0x0002B67C
	public MultiValue(int capacity, global::System.Collections.Generic.IEqualityComparer<TValue> equalityComparer)
	{
		this.hashSet = new global::System.Collections.Generic.HashSet<TValue>(equalityComparer);
		this.list = new global::System.Collections.Generic.List<TValue>(capacity);
	}

	// Token: 0x06000BAF RID: 2991 RVA: 0x0002D49C File Offset: 0x0002B69C
	public MultiValue(global::System.Collections.Generic.IEqualityComparer<TValue> equalityComparer)
	{
		this.hashSet = new global::System.Collections.Generic.HashSet<TValue>(equalityComparer);
		this.list = new global::System.Collections.Generic.List<TValue>();
	}

	// Token: 0x06000BB0 RID: 2992 RVA: 0x0002D4BC File Offset: 0x0002B6BC
	global::System.Collections.Generic.IEnumerator<TValue> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
	{
		return ((global::System.Collections.Generic.IEnumerable<!0>)this.list).GetEnumerator();
	}

	// Token: 0x06000BB1 RID: 2993 RVA: 0x0002D4CC File Offset: 0x0002B6CC
	global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
	{
		return ((global::System.Collections.IEnumerable)this.list).GetEnumerator();
	}

	// Token: 0x06000BB2 RID: 2994 RVA: 0x0002D4DC File Offset: 0x0002B6DC
	void global::System.Collections.Generic.IList<!0>.Insert(int index, TValue value)
	{
		this.InsertOrMove(index, value);
	}

	// Token: 0x06000BB3 RID: 2995 RVA: 0x0002D4E8 File Offset: 0x0002B6E8
	void global::System.Collections.Generic.IList<!0>.RemoveAt(int index)
	{
		TValue item = this.list[index];
		this.list.RemoveAt(index);
		this.hashSet.Remove(item);
		this.count--;
	}

	// Token: 0x06000BB4 RID: 2996 RVA: 0x0002D52C File Offset: 0x0002B72C
	void global::System.Collections.Generic.ICollection<!0>.Add(TValue item)
	{
		if (this.hashSet.Add(item))
		{
			this.list.Add(item);
			this.count++;
		}
	}

	// Token: 0x06000BB5 RID: 2997 RVA: 0x0002D55C File Offset: 0x0002B75C
	void global::System.Collections.Generic.ICollection<!0>.Clear()
	{
		if (this.count > 0)
		{
			this.list.Clear();
			this.hashSet.Clear();
			this.count = 0;
		}
	}

	// Token: 0x06000BB6 RID: 2998 RVA: 0x0002D588 File Offset: 0x0002B788
	bool global::System.Collections.Generic.ICollection<!0>.Remove(TValue value)
	{
		return this.Remove(value) != 0;
	}

	// Token: 0x17000328 RID: 808
	// (get) Token: 0x06000BB7 RID: 2999 RVA: 0x0002D598 File Offset: 0x0002B798
	bool global::System.Collections.Generic.ICollection<!0>.IsReadOnly
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06000BB8 RID: 3000 RVA: 0x0002D59C File Offset: 0x0002B79C
	object global::System.ICloneable.Clone()
	{
		return this.Clone();
	}

	// Token: 0x06000BB9 RID: 3001 RVA: 0x0002D5A4 File Offset: 0x0002B7A4
	public global::System.Collections.Generic.List<TValue>.Enumerator GetEnumerator()
	{
		return this.list.GetEnumerator();
	}

	// Token: 0x06000BBA RID: 3002 RVA: 0x0002D5B4 File Offset: 0x0002B7B4
	public int IndexOf(TValue item)
	{
		if (this.count >= 0x10 && !this.hashSet.Contains(item))
		{
			return -1;
		}
		return this.list.IndexOf(item);
	}

	// Token: 0x06000BBB RID: 3003 RVA: 0x0002D5F0 File Offset: 0x0002B7F0
	public int InsertOrMove(int index, TValue item)
	{
		if (index == this.count)
		{
			if (this.hashSet.Add(item))
			{
				this.list.Add(item);
				this.count++;
				return 1;
			}
			int num = this.list.IndexOf(item);
			int num2 = this.count - num;
			if (num2 != 1)
			{
				if (num2 != 2)
				{
					this.list.RemoveAt(num);
					this.list.Add(item);
				}
				else
				{
					this.list.Reverse(this.count - 2, 2);
				}
				return 2;
			}
			return 0;
		}
		else
		{
			if (index < 0)
			{
				throw new global::System.ArgumentOutOfRangeException("index", "index < 0");
			}
			if (index > this.count)
			{
				throw new global::System.ArgumentOutOfRangeException("index", "index > count");
			}
			if (this.hashSet.Add(item))
			{
				this.list.Insert(index, item);
				this.count++;
				return 1;
			}
			int num3 = this.list.IndexOf(item);
			int num4 = index - num3;
			int num2 = num4;
			switch (num2 + 1)
			{
			case 0:
				this.list.Reverse(num3, 2);
				break;
			case 1:
				return 0;
			case 2:
				this.list.Reverse(index, 2);
				break;
			default:
				if (num4 <= -2)
				{
					for (int i = num3; i > index; i--)
					{
						this.list[i] = this.list[i - 1];
					}
				}
				else if (num4 >= 2)
				{
					for (int j = num3; j < index; j++)
					{
						this.list[j] = this.list[j + 1];
					}
				}
				this.list[index] = item;
				break;
			}
			return 2;
		}
	}

	// Token: 0x06000BBC RID: 3004 RVA: 0x0002D7D8 File Offset: 0x0002B9D8
	public bool RemoveAt(int index)
	{
		TValue item = this.list[index];
		this.list.RemoveAt(index);
		this.hashSet.Remove(item);
		return --this.count != 0;
	}

	// Token: 0x17000329 RID: 809
	public TValue this[int index]
	{
		get
		{
			return this.list[index];
		}
		set
		{
			this.list[index] = value;
		}
	}

	// Token: 0x06000BBF RID: 3007 RVA: 0x0002D844 File Offset: 0x0002BA44
	public bool Add(TValue item)
	{
		if (this.hashSet.Add(item))
		{
			this.list.Add(item);
			this.count++;
			return true;
		}
		return false;
	}

	// Token: 0x06000BC0 RID: 3008 RVA: 0x0002D880 File Offset: 0x0002BA80
	public bool Clear()
	{
		if (this.count > 0)
		{
			this.list.Clear();
			this.hashSet.Clear();
			this.count = 0;
			return true;
		}
		return false;
	}

	// Token: 0x06000BC1 RID: 3009 RVA: 0x0002D8BC File Offset: 0x0002BABC
	public bool Contains(TValue item)
	{
		return this.hashSet.Contains(item);
	}

	// Token: 0x06000BC2 RID: 3010 RVA: 0x0002D8CC File Offset: 0x0002BACC
	public void CopyTo(TValue[] array, int arrayIndex)
	{
		this.list.CopyTo(array, arrayIndex);
	}

	// Token: 0x06000BC3 RID: 3011 RVA: 0x0002D8DC File Offset: 0x0002BADC
	public int Remove(TValue item)
	{
		if (!this.hashSet.Remove(item))
		{
			return 0;
		}
		if (!this.list.Remove(item))
		{
			this.hashSet.Add(item);
			return 0;
		}
		return (--this.count != 0) ? 1 : 2;
	}

	// Token: 0x1700032A RID: 810
	// (get) Token: 0x06000BC4 RID: 3012 RVA: 0x0002D93C File Offset: 0x0002BB3C
	public int Count
	{
		get
		{
			return this.count;
		}
	}

	// Token: 0x06000BC5 RID: 3013 RVA: 0x0002D944 File Offset: 0x0002BB44
	public int AddRange(global::System.Collections.Generic.IEnumerable<TValue> value)
	{
		int num = 0;
		foreach (TValue item in value)
		{
			if (this.Add(item))
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x06000BC6 RID: 3014 RVA: 0x0002D9B0 File Offset: 0x0002BBB0
	public void Set(global::MultiValue<TValue> other)
	{
		if (other == this)
		{
			return;
		}
		this.Clear();
		foreach (TValue item in other)
		{
			this.Add(item);
		}
	}

	// Token: 0x06000BC7 RID: 3015 RVA: 0x0002DA24 File Offset: 0x0002BC24
	public global::MultiValue<TValue> Clone()
	{
		return new global::MultiValue<TValue>(false)
		{
			hashSet = new global::System.Collections.Generic.HashSet<TValue>(this.hashSet),
			list = new global::System.Collections.Generic.List<TValue>(this.list),
			count = this.count
		};
	}

	// Token: 0x06000BC8 RID: 3016 RVA: 0x0002DA68 File Offset: 0x0002BC68
	public bool Clone(global::System.Collections.Generic.IEqualityComparer<TValue> valueComparer, out global::MultiValue<TValue> val)
	{
		if (this.count == 0)
		{
			val = null;
			return false;
		}
		if (valueComparer == this.hashSet.Comparer)
		{
			val = this.Clone();
			return true;
		}
		val = new global::MultiValue<TValue>(this.list, valueComparer);
		if (val.count == 0)
		{
			val = null;
			return false;
		}
		return true;
	}

	// Token: 0x040007F1 RID: 2033
	private const int kCheckHashCountMin = 0x10;

	// Token: 0x040007F2 RID: 2034
	private const bool kIsReadOnly = false;

	// Token: 0x040007F3 RID: 2035
	private global::System.Collections.Generic.HashSet<TValue> hashSet;

	// Token: 0x040007F4 RID: 2036
	private global::System.Collections.Generic.List<TValue> list;

	// Token: 0x040007F5 RID: 2037
	private int count;

	// Token: 0x02000191 RID: 401
	private struct InitData
	{
		// Token: 0x06000BC9 RID: 3017 RVA: 0x0002DAC0 File Offset: 0x0002BCC0
		public void RecurseInit()
		{
			while (this.enumerator.MoveNext())
			{
				TValue item = this.enumerator.Current;
				if (this.mv.hashSet.Add(item))
				{
					this.mv.count++;
					this.RecurseInit();
					this.mv.list.Add(item);
					return;
				}
			}
			this.mv.list = new global::System.Collections.Generic.List<TValue>(this.mv.count);
		}

		// Token: 0x040007F6 RID: 2038
		public global::MultiValue<TValue> mv;

		// Token: 0x040007F7 RID: 2039
		public global::System.Collections.Generic.IEnumerator<TValue> enumerator;
	}

	// Token: 0x02000192 RID: 402
	public struct KeyPair<TKey> : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<!0>, global::System.Collections.Generic.ICollection<!0>, global::System.Collections.Generic.IList<!0>
	{
		// Token: 0x06000BCA RID: 3018 RVA: 0x0002DB4C File Offset: 0x0002BD4C
		public KeyPair(global::DictionaryMultiValue<TKey, TValue> dict, TKey key)
		{
			this.dict = dict;
			this.key = key;
		}

		// Token: 0x06000BCB RID: 3019 RVA: 0x0002DB5C File Offset: 0x0002BD5C
		global::System.Collections.Generic.IEnumerator<TValue> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
		{
			global::MultiValue<TValue> multiValue;
			if (this.GetMultiValue(out multiValue))
			{
				return ((global::System.Collections.Generic.IEnumerable<!0>)multiValue).GetEnumerator();
			}
			return ((global::System.Collections.Generic.IEnumerable<!0>)global::MultiValue<TValue>.KeyPair<TKey>.g.emptyList).GetEnumerator();
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x0002DB88 File Offset: 0x0002BD88
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			global::MultiValue<TValue> multiValue;
			if (this.GetMultiValue(out multiValue))
			{
				return ((global::System.Collections.IEnumerable)multiValue).GetEnumerator();
			}
			return ((global::System.Collections.IEnumerable)global::MultiValue<TValue>.KeyPair<TKey>.g.emptyList).GetEnumerator();
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x0002DBB4 File Offset: 0x0002BDB4
		bool global::System.Collections.Generic.ICollection<!0>.Remove(TValue value)
		{
			global::MultiValue<TValue> multiValue;
			return this.GetMultiValue(out multiValue) && ((global::System.Collections.Generic.ICollection<!0>)multiValue).Remove(value);
		}

		// Token: 0x06000BCE RID: 3022 RVA: 0x0002DBD8 File Offset: 0x0002BDD8
		void global::System.Collections.Generic.IList<!0>.RemoveAt(int index)
		{
			global::MultiValue<TValue> multiValue;
			if (!this.GetMultiValue(out multiValue))
			{
				global::MultiValue<TValue>.KeyPair<TKey>.g.emptyList.RemoveAt(index);
			}
			else
			{
				((global::System.Collections.Generic.IList<!0>)multiValue).RemoveAt(index);
			}
		}

		// Token: 0x06000BCF RID: 3023 RVA: 0x0002DC0C File Offset: 0x0002BE0C
		void global::System.Collections.Generic.IList<!0>.Insert(int index, TValue value)
		{
			global::MultiValue<TValue> multiValue;
			bool orCreateMultiValue = this.GetOrCreateMultiValue(out multiValue);
			((global::System.Collections.Generic.IList<!0>)multiValue).Insert(index, value);
			if (!orCreateMultiValue && multiValue.count > 0)
			{
				this.Bind(multiValue);
			}
		}

		// Token: 0x06000BD0 RID: 3024 RVA: 0x0002DC44 File Offset: 0x0002BE44
		void global::System.Collections.Generic.ICollection<!0>.Add(TValue item)
		{
			global::MultiValue<TValue> multiValue;
			bool orCreateMultiValue = this.GetOrCreateMultiValue(out multiValue);
			((global::System.Collections.Generic.ICollection<!0>)multiValue).Add(item);
			if (!orCreateMultiValue && multiValue.count != 0)
			{
				this.Bind(multiValue);
			}
		}

		// Token: 0x06000BD1 RID: 3025 RVA: 0x0002DC7C File Offset: 0x0002BE7C
		void global::System.Collections.Generic.ICollection<!0>.Clear()
		{
			global::MultiValue<TValue> multiValue;
			if (this.GetMultiValue(out multiValue))
			{
				((global::System.Collections.Generic.ICollection<!0>)multiValue).Clear();
			}
		}

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x06000BD2 RID: 3026 RVA: 0x0002DC9C File Offset: 0x0002BE9C
		bool global::System.Collections.Generic.ICollection<!0>.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06000BD3 RID: 3027 RVA: 0x0002DCA0 File Offset: 0x0002BEA0
		public TKey Key
		{
			get
			{
				return this.key;
			}
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06000BD4 RID: 3028 RVA: 0x0002DCA8 File Offset: 0x0002BEA8
		public global::DictionaryMultiValue<TKey, TValue> Dictionary
		{
			get
			{
				return this.dict;
			}
		}

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x06000BD5 RID: 3029 RVA: 0x0002DCB0 File Offset: 0x0002BEB0
		public bool Valid
		{
			get
			{
				return this.dict != null;
			}
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x0002DCC0 File Offset: 0x0002BEC0
		private bool GetMultiValue(out global::MultiValue<TValue> v)
		{
			if (this.dict == null)
			{
				v = null;
			}
			return this.dict.GetMultiValue(this.key, out v);
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x0002DCF0 File Offset: 0x0002BEF0
		private bool GetOrCreateMultiValue(out global::MultiValue<TValue> v)
		{
			if (this.dict == null)
			{
				throw new global::System.InvalidOperationException("The KeyPair is invalid");
			}
			return this.dict.GetOrCreateMultiValue(this.key, out v);
		}

		// Token: 0x06000BD8 RID: 3032 RVA: 0x0002DD28 File Offset: 0x0002BF28
		private void Bind(global::MultiValue<TValue> v)
		{
			this.dict.SetMultiValue(this.key, v);
		}

		// Token: 0x06000BD9 RID: 3033 RVA: 0x0002DD3C File Offset: 0x0002BF3C
		public global::System.Collections.Generic.List<TValue>.Enumerator GetEnumerator()
		{
			global::MultiValue<TValue> multiValue;
			if (this.GetMultiValue(out multiValue))
			{
				return multiValue.GetEnumerator();
			}
			return global::MultiValue<TValue>.KeyPair<TKey>.g.emptyList.GetEnumerator();
		}

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06000BDA RID: 3034 RVA: 0x0002DD68 File Offset: 0x0002BF68
		public int Count
		{
			get
			{
				global::MultiValue<TValue> multiValue;
				return (!this.GetMultiValue(out multiValue)) ? multiValue.Count : 0;
			}
		}

		// Token: 0x06000BDB RID: 3035 RVA: 0x0002DD90 File Offset: 0x0002BF90
		public bool Add(TValue value)
		{
			global::MultiValue<TValue> multiValue;
			bool orCreateMultiValue = this.GetOrCreateMultiValue(out multiValue);
			if (multiValue.Add(value))
			{
				if (!orCreateMultiValue)
				{
					this.Bind(multiValue);
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000BDC RID: 3036 RVA: 0x0002DDC4 File Offset: 0x0002BFC4
		public int InsertOrMove(int index, TValue item)
		{
			global::MultiValue<TValue> multiValue;
			bool orCreateMultiValue = this.GetOrCreateMultiValue(out multiValue);
			int num = multiValue.InsertOrMove(index, item);
			if (num == 1 && !orCreateMultiValue)
			{
				this.Bind(multiValue);
			}
			return num;
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x0002DDF8 File Offset: 0x0002BFF8
		public int Remove(TValue value)
		{
			global::MultiValue<TValue> multiValue;
			return (!this.GetMultiValue(out multiValue)) ? 0 : multiValue.Remove(value);
		}

		// Token: 0x06000BDE RID: 3038 RVA: 0x0002DE20 File Offset: 0x0002C020
		public bool Contains(TValue value)
		{
			global::MultiValue<TValue> multiValue;
			return this.GetMultiValue(out multiValue) && multiValue.Contains(value);
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x0002DE44 File Offset: 0x0002C044
		public bool Clear(TValue value)
		{
			global::MultiValue<TValue> multiValue;
			return this.GetMultiValue(out multiValue) && multiValue.Clear();
		}

		// Token: 0x06000BE0 RID: 3040 RVA: 0x0002DE68 File Offset: 0x0002C068
		public bool RemoveAt(int index)
		{
			global::MultiValue<TValue> multiValue;
			return this.GetMultiValue(out multiValue) && multiValue.RemoveAt(index);
		}

		// Token: 0x06000BE1 RID: 3041 RVA: 0x0002DE8C File Offset: 0x0002C08C
		public void CopyTo(TValue[] array, int arrayIndex)
		{
			global::MultiValue<TValue> multiValue;
			if (this.GetMultiValue(out multiValue))
			{
				multiValue.CopyTo(array, arrayIndex);
			}
			else
			{
				global::MultiValue<TValue>.KeyPair<TKey>.g.emptyList.CopyTo(array, arrayIndex);
			}
		}

		// Token: 0x06000BE2 RID: 3042 RVA: 0x0002DEC0 File Offset: 0x0002C0C0
		public int IndexOf(TValue item)
		{
			global::MultiValue<TValue> multiValue;
			return (!this.GetMultiValue(out multiValue)) ? -1 : multiValue.IndexOf(item);
		}

		// Token: 0x17000330 RID: 816
		public TValue this[int i]
		{
			get
			{
				global::MultiValue<TValue> multiValue;
				if (!this.GetMultiValue(out multiValue))
				{
					return global::MultiValue<TValue>.KeyPair<TKey>.g.emptyList[i];
				}
				return multiValue[i];
			}
			set
			{
				global::MultiValue<TValue> multiValue;
				if (!this.GetMultiValue(out multiValue))
				{
					global::MultiValue<TValue>.KeyPair<TKey>.g.emptyList[i] = value;
				}
				else
				{
					multiValue[i] = value;
				}
			}
		}

		// Token: 0x040007F8 RID: 2040
		private readonly TKey key;

		// Token: 0x040007F9 RID: 2041
		private readonly global::DictionaryMultiValue<TKey, TValue> dict;

		// Token: 0x02000193 RID: 403
		private static class g
		{
			// Token: 0x06000BE5 RID: 3045 RVA: 0x0002DF4C File Offset: 0x0002C14C
			// Note: this type is marked as 'beforefieldinit'.
			static g()
			{
			}

			// Token: 0x040007FA RID: 2042
			public static readonly global::System.Collections.Generic.List<TValue> emptyList = new global::System.Collections.Generic.List<TValue>(0);
		}
	}
}
