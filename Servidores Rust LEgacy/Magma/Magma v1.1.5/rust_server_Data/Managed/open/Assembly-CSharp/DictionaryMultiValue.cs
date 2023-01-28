using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200019A RID: 410
public class DictionaryMultiValue<TKey, TValue> : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::MultiValue<TValue>.KeyPair<TKey>>
{
	// Token: 0x06000C09 RID: 3081 RVA: 0x0002E520 File Offset: 0x0002C720
	public DictionaryMultiValue(global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<TKey, TValue>> dict, global::System.Collections.Generic.IEqualityComparer<TKey> keyComp, global::System.Collections.Generic.IEqualityComparer<TValue> valComp)
	{
		this.HasKeyComparer = (keyComp != null);
		this.HasValueComparer = (valComp != null);
		this.ValueComparer = valComp;
		this.dict = ((!this.HasKeyComparer) ? new global::System.Collections.Generic.Dictionary<TKey, global::MultiValue<TValue>>() : new global::System.Collections.Generic.Dictionary<TKey, global::MultiValue<TValue>>(keyComp));
		this.AddRange(dict);
	}

	// Token: 0x06000C0A RID: 3082 RVA: 0x0002E580 File Offset: 0x0002C780
	global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	// Token: 0x17000337 RID: 823
	// (get) Token: 0x06000C0B RID: 3083 RVA: 0x0002E588 File Offset: 0x0002C788
	public global::System.Collections.Generic.IEqualityComparer<TKey> KeyComparer
	{
		get
		{
			return this.dict.Comparer;
		}
	}

	// Token: 0x06000C0C RID: 3084 RVA: 0x0002E598 File Offset: 0x0002C798
	internal bool GetMultiValue(TKey key, out global::MultiValue<TValue> v)
	{
		return this.dict.TryGetValue(key, out v);
	}

	// Token: 0x06000C0D RID: 3085 RVA: 0x0002E5A8 File Offset: 0x0002C7A8
	private global::MultiValue<TValue> CreateMultiValue()
	{
		if (this.HasValueComparer)
		{
			return new global::MultiValue<TValue>(this.ValueComparer);
		}
		return new global::MultiValue<TValue>();
	}

	// Token: 0x06000C0E RID: 3086 RVA: 0x0002E5C8 File Offset: 0x0002C7C8
	private global::MultiValue<TValue> CreateMultiValue(global::System.Collections.Generic.IEnumerable<TValue> enumerable)
	{
		if (this.HasValueComparer)
		{
			return new global::MultiValue<TValue>(enumerable, this.ValueComparer);
		}
		return new global::MultiValue<TValue>(enumerable);
	}

	// Token: 0x06000C0F RID: 3087 RVA: 0x0002E5E8 File Offset: 0x0002C7E8
	internal bool GetOrCreateMultiValue(TKey key, out global::MultiValue<TValue> v)
	{
		if (this.dict.TryGetValue(key, out v))
		{
			return true;
		}
		v = this.CreateMultiValue();
		return false;
	}

	// Token: 0x06000C10 RID: 3088 RVA: 0x0002E608 File Offset: 0x0002C808
	internal bool GetOrCreateMultiValue(TKey key, out global::MultiValue<TValue> v, global::System.Collections.Generic.IEnumerable<TValue> enumerable)
	{
		if (this.dict.TryGetValue(key, out v))
		{
			return true;
		}
		v = this.CreateMultiValue(enumerable);
		return false;
	}

	// Token: 0x06000C11 RID: 3089 RVA: 0x0002E628 File Offset: 0x0002C828
	public bool Add(global::System.Collections.Generic.KeyValuePair<TKey, TValue> kv)
	{
		global::MultiValue<TValue> multiValue;
		if (this.GetOrCreateMultiValue(kv.Key, out multiValue))
		{
			return multiValue.Add(kv.Value);
		}
		if (multiValue.Add(kv.Value))
		{
			this.dict.Add(kv.Key, multiValue);
			return true;
		}
		return false;
	}

	// Token: 0x06000C12 RID: 3090 RVA: 0x0002E680 File Offset: 0x0002C880
	public bool Add(TKey key, TValue value)
	{
		global::MultiValue<TValue> multiValue;
		if (this.GetOrCreateMultiValue(key, out multiValue))
		{
			return multiValue.Add(value);
		}
		if (multiValue.Add(value))
		{
			this.dict.Add(key, multiValue);
			return true;
		}
		return false;
	}

	// Token: 0x06000C13 RID: 3091 RVA: 0x0002E6C0 File Offset: 0x0002C8C0
	public int AddRange(TKey key, global::System.Collections.Generic.IEnumerable<TValue> value)
	{
		global::MultiValue<TValue> multiValue;
		if (this.GetOrCreateMultiValue(key, out multiValue, value))
		{
			return multiValue.AddRange(value);
		}
		int count = multiValue.Count;
		if (count > 0)
		{
			this.dict.Add(key, multiValue);
		}
		return count;
	}

	// Token: 0x06000C14 RID: 3092 RVA: 0x0002E700 File Offset: 0x0002C900
	public int AddRange<TValueEnumerable>(global::System.Collections.Generic.KeyValuePair<TKey, TValueEnumerable> kv) where TValueEnumerable : global::System.Collections.Generic.IEnumerable<TValue>
	{
		global::MultiValue<TValue> multiValue;
		if (this.GetOrCreateMultiValue(kv.Key, out multiValue))
		{
			return multiValue.AddRange(kv.Value);
		}
		int count = multiValue.Count;
		if (count > 0)
		{
			this.dict.Add(kv.Key, multiValue);
		}
		return count;
	}

	// Token: 0x06000C15 RID: 3093 RVA: 0x0002E758 File Offset: 0x0002C958
	public int AddRange(global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<TKey, TValue>> pairs)
	{
		int num = 0;
		foreach (global::System.Collections.Generic.KeyValuePair<TKey, TValue> kv in pairs)
		{
			if (this.Add(kv))
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x06000C16 RID: 3094 RVA: 0x0002E7C4 File Offset: 0x0002C9C4
	public int AddRange<TValueEnumerable>(global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<TKey, TValueEnumerable>> pairs) where TValueEnumerable : global::System.Collections.Generic.IEnumerable<TValue>
	{
		int num = 0;
		foreach (global::System.Collections.Generic.KeyValuePair<TKey, TValueEnumerable> kv in pairs)
		{
			num += this.AddRange<TValueEnumerable>(kv);
		}
		return num;
	}

	// Token: 0x06000C17 RID: 3095 RVA: 0x0002E828 File Offset: 0x0002CA28
	public bool Remove(TKey key)
	{
		global::MultiValue<TValue> multiValue;
		return this.GetMultiValue(key, out multiValue) && this.dict.Remove(key) && multiValue.Clear();
	}

	// Token: 0x06000C18 RID: 3096 RVA: 0x0002E860 File Offset: 0x0002CA60
	public bool Clear(TKey key)
	{
		global::MultiValue<TValue> multiValue;
		return this.GetMultiValue(key, out multiValue) && multiValue.Clear();
	}

	// Token: 0x06000C19 RID: 3097 RVA: 0x0002E884 File Offset: 0x0002CA84
	public bool Clear(TKey key, bool erase)
	{
		return this.Clear(key) && this.dict.Remove(key);
	}

	// Token: 0x06000C1A RID: 3098 RVA: 0x0002E8A4 File Offset: 0x0002CAA4
	public bool RemoveAt(TKey key, int index)
	{
		global::MultiValue<TValue> multiValue;
		return this.GetMultiValue(key, out multiValue) && multiValue.RemoveAt(index);
	}

	// Token: 0x06000C1B RID: 3099 RVA: 0x0002E8CC File Offset: 0x0002CACC
	public int ValueCount(TKey key)
	{
		global::MultiValue<TValue> multiValue;
		return (!this.GetMultiValue(key, out multiValue)) ? 0 : multiValue.Count;
	}

	// Token: 0x06000C1C RID: 3100 RVA: 0x0002E8F4 File Offset: 0x0002CAF4
	public bool ContainsKey(TKey key)
	{
		return this.dict.ContainsKey(key);
	}

	// Token: 0x06000C1D RID: 3101 RVA: 0x0002E904 File Offset: 0x0002CB04
	public bool Contains(TKey key, TValue value)
	{
		global::MultiValue<TValue> multiValue;
		return this.GetMultiValue(key, out multiValue) && multiValue.Contains(value);
	}

	// Token: 0x06000C1E RID: 3102 RVA: 0x0002E92C File Offset: 0x0002CB2C
	public bool ContainsValue(TKey key, TValue value)
	{
		return this.Contains(key, value);
	}

	// Token: 0x06000C1F RID: 3103 RVA: 0x0002E938 File Offset: 0x0002CB38
	public bool Contains(global::System.Collections.Generic.KeyValuePair<TKey, TValue> kv)
	{
		return this.Contains(kv.Key, kv.Value);
	}

	// Token: 0x06000C20 RID: 3104 RVA: 0x0002E950 File Offset: 0x0002CB50
	public bool ContainsValue(TValue value)
	{
		foreach (global::MultiValue<TValue> multiValue in this.dict.Values)
		{
			if (multiValue.Contains(value))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000C21 RID: 3105 RVA: 0x0002E9CC File Offset: 0x0002CBCC
	internal void SetMultiValue(TKey key, global::MultiValue<TValue> mv)
	{
		this.dict.Add(key, mv);
	}

	// Token: 0x06000C22 RID: 3106 RVA: 0x0002E9DC File Offset: 0x0002CBDC
	public global::System.Collections.Generic.IEnumerator<global::MultiValue<TValue>.KeyPair<TKey>> GetEnumerator()
	{
		foreach (TKey key in this.dict.Keys)
		{
			yield return new global::MultiValue<TValue>.KeyPair<TKey>(this, key);
		}
		yield break;
	}

	// Token: 0x06000C23 RID: 3107 RVA: 0x0002E9F8 File Offset: 0x0002CBF8
	private bool AreEqual(TKey l, TKey r)
	{
		global::System.Collections.Generic.IEqualityComparer<TKey> comparer = this.dict.Comparer;
		return comparer.GetHashCode(l) == comparer.GetHashCode(r) && comparer.Equals(l, r);
	}

	// Token: 0x17000338 RID: 824
	public global::MultiValue<TValue>.KeyPair<TKey> this[TKey key]
	{
		get
		{
			return new global::MultiValue<TValue>.KeyPair<TKey>(this, key);
		}
		set
		{
			if (value.Dictionary == this)
			{
				global::MultiValue<TValue> multiValue5;
				if (this.AreEqual(value.Key, key))
				{
					global::MultiValue<TValue> multiValue;
					if (this.GetMultiValue(value.Key, out multiValue))
					{
						global::MultiValue<TValue> multiValue2;
						if (this.GetMultiValue(key, out multiValue2))
						{
							multiValue2.Set(multiValue);
						}
						else if (multiValue.Count > 0)
						{
							this.dict.Add(value.Key, multiValue.Clone());
						}
					}
				}
				else if (value.Valid)
				{
					global::MultiValue<TValue> multiValue3;
					if (value.Dictionary.GetMultiValue(value.Key, out multiValue3))
					{
						global::MultiValue<TValue> multiValue4;
						if (this.GetMultiValue(key, out multiValue4))
						{
							multiValue4.Set(multiValue3);
						}
						else if (multiValue3.Count > 0 && multiValue3.Clone(this.ValueComparer, out multiValue4))
						{
							this.dict.Add(value.Key, multiValue4);
						}
					}
				}
				else if (value.Dictionary.GetMultiValue(value.Key, out multiValue5))
				{
					multiValue5.Clear();
				}
			}
		}
	}

	// Token: 0x0400080B RID: 2059
	private global::System.Collections.Generic.Dictionary<TKey, global::MultiValue<TValue>> dict;

	// Token: 0x0400080C RID: 2060
	public readonly bool HasKeyComparer;

	// Token: 0x0400080D RID: 2061
	public readonly global::System.Collections.Generic.IEqualityComparer<TValue> ValueComparer;

	// Token: 0x0400080E RID: 2062
	public readonly bool HasValueComparer;

	// Token: 0x0200019B RID: 411
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <GetEnumerator>c__Iterator29 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::MultiValue<!1>.KeyPair<!0>>
	{
		// Token: 0x06000C26 RID: 3110 RVA: 0x0002EB5C File Offset: 0x0002CD5C
		public <GetEnumerator>c__Iterator29()
		{
		}

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06000C27 RID: 3111 RVA: 0x0002EB64 File Offset: 0x0002CD64
		global::MultiValue<TValue>.KeyPair<TKey> global::System.Collections.Generic.IEnumerator<global::MultiValue<!1>.KeyPair<!0>>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06000C28 RID: 3112 RVA: 0x0002EB6C File Offset: 0x0002CD6C
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000C29 RID: 3113 RVA: 0x0002EB7C File Offset: 0x0002CD7C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				enumerator = this.dict.Keys.GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					key = enumerator.Current;
					this.$current = new global::MultiValue<TValue>.KeyPair<TKey>(this, key);
					this.$PC = 1;
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06000C2A RID: 3114 RVA: 0x0002EC64 File Offset: 0x0002CE64
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x0002ECC4 File Offset: 0x0002CEC4
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x0400080F RID: 2063
		internal global::System.Collections.Generic.Dictionary<TKey, global::MultiValue<TValue>>.KeyCollection.Enumerator <$s_223>__0;

		// Token: 0x04000810 RID: 2064
		internal TKey <key>__1;

		// Token: 0x04000811 RID: 2065
		internal int $PC;

		// Token: 0x04000812 RID: 2066
		internal global::MultiValue<TValue>.KeyPair<TKey> $current;

		// Token: 0x04000813 RID: 2067
		internal global::DictionaryMultiValue<TKey, TValue> <>f__this;
	}
}
