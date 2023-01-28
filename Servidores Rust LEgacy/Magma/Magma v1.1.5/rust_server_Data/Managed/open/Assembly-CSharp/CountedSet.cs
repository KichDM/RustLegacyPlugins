using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x02000194 RID: 404
public class CountedSet<TValue> : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<!0>, global::System.Collections.Generic.ICollection<!0>
{
	// Token: 0x06000BE6 RID: 3046 RVA: 0x0002DF5C File Offset: 0x0002C15C
	public CountedSet(global::System.Collections.Generic.IEnumerable<TValue> values, global::System.Collections.Generic.IEqualityComparer<TValue> comparer)
	{
		this.index = new global::System.Collections.Generic.Dictionary<TValue, global::CountedSet<TValue>.Node>(comparer);
		foreach (TValue value in values)
		{
			this.Retain(value);
		}
	}

	// Token: 0x06000BE7 RID: 3047 RVA: 0x0002DFD0 File Offset: 0x0002C1D0
	// Note: this type is marked as 'beforefieldinit'.
	static CountedSet()
	{
	}

	// Token: 0x06000BE8 RID: 3048 RVA: 0x0002DFE0 File Offset: 0x0002C1E0
	void global::System.Collections.Generic.ICollection<!0>.Add(TValue item)
	{
		((global::System.Collections.Generic.ICollection<!0>)this.index.Keys).Add(item);
	}

	// Token: 0x06000BE9 RID: 3049 RVA: 0x0002DFF4 File Offset: 0x0002C1F4
	void global::System.Collections.Generic.ICollection<!0>.Clear()
	{
		((global::System.Collections.Generic.ICollection<!0>)this.index.Keys).Clear();
	}

	// Token: 0x06000BEA RID: 3050 RVA: 0x0002E008 File Offset: 0x0002C208
	void global::System.Collections.Generic.ICollection<!0>.CopyTo(TValue[] array, int arrayIndex)
	{
		((global::System.Collections.Generic.ICollection<!0>)this.index.Keys).CopyTo(array, arrayIndex);
	}

	// Token: 0x06000BEB RID: 3051 RVA: 0x0002E01C File Offset: 0x0002C21C
	bool global::System.Collections.Generic.ICollection<!0>.Remove(TValue item)
	{
		throw new global::System.NotSupportedException();
	}

	// Token: 0x06000BEC RID: 3052 RVA: 0x0002E024 File Offset: 0x0002C224
	global::System.Collections.Generic.IEnumerator<TValue> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
	{
		return ((global::System.Collections.Generic.IEnumerable<!0>)this.index.Keys).GetEnumerator();
	}

	// Token: 0x06000BED RID: 3053 RVA: 0x0002E038 File Offset: 0x0002C238
	global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
	{
		return ((global::System.Collections.IEnumerable)this.index.Keys).GetEnumerator();
	}

	// Token: 0x06000BEE RID: 3054 RVA: 0x0002E04C File Offset: 0x0002C24C
	private static global::System.Collections.Generic.EqualityComparer<global::CountedSet<TValue>.Node> ConvertEqualityComparer(global::System.Collections.Generic.IEqualityComparer<TValue> comparer)
	{
		if (comparer == null || comparer == global::CountedSet<TValue>.DefaultComparer.Singleton.Value.Comparer)
		{
			return global::CountedSet<TValue>.DefaultComparer.Singleton.Value;
		}
		return new global::CountedSet<TValue>.CustomComparer(comparer);
	}

	// Token: 0x17000331 RID: 817
	// (get) Token: 0x06000BEF RID: 3055 RVA: 0x0002E07C File Offset: 0x0002C27C
	public int Count
	{
		get
		{
			return (int)this.nodeCount;
		}
	}

	// Token: 0x06000BF0 RID: 3056 RVA: 0x0002E084 File Offset: 0x0002C284
	public int Retain(TValue value)
	{
		global::CountedSet<TValue>.Node node;
		if (!this.index.TryGetValue(value, out node))
		{
			node = (this.index[value] = new global::CountedSet<TValue>.Node
			{
				v = value
			});
			this.nodeCount += 1U;
		}
		uint count = node.count;
		node.Retain();
		this.totalRetains += 1U;
		return (int)count;
	}

	// Token: 0x06000BF1 RID: 3057 RVA: 0x0002E0EC File Offset: 0x0002C2EC
	public bool Contains(TValue value)
	{
		return this.index.ContainsKey(value);
	}

	// Token: 0x06000BF2 RID: 3058 RVA: 0x0002E0FC File Offset: 0x0002C2FC
	public int Release(TValue value)
	{
		global::CountedSet<TValue>.Node node;
		if (!this.index.TryGetValue(value, out node))
		{
			return -1;
		}
		bool flag = node.Release();
		this.totalRetains -= 1U;
		if (flag)
		{
			this.index.Remove(value);
			this.nodeCount -= 1U;
		}
		return (int)node.count;
	}

	// Token: 0x06000BF3 RID: 3059 RVA: 0x0002E15C File Offset: 0x0002C35C
	public TValue[] ReleaseAll()
	{
		TValue[] array;
		using (global::CountedSet<TValue>.ReleaseRecursor releaseRecursor = new global::CountedSet<TValue>.ReleaseRecursor(this))
		{
			releaseRecursor.Run();
			array = releaseRecursor.array;
		}
		return array;
	}

	// Token: 0x06000BF4 RID: 3060 RVA: 0x0002E1B4 File Offset: 0x0002C3B4
	public void RetainAll()
	{
		foreach (global::CountedSet<TValue>.Node node in this.index.Values)
		{
			node.Retain();
			this.totalRetains += 1U;
		}
	}

	// Token: 0x17000332 RID: 818
	public int this[TValue value]
	{
		get
		{
			global::CountedSet<TValue>.Node node;
			return (int)((!this.index.TryGetValue(value, out node)) ? uint.MaxValue : (node.count - 1U));
		}
	}

	// Token: 0x17000333 RID: 819
	// (get) Token: 0x06000BF6 RID: 3062 RVA: 0x0002E260 File Offset: 0x0002C460
	public bool IsReadOnly
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06000BF7 RID: 3063 RVA: 0x0002E264 File Offset: 0x0002C464
	public global::System.Collections.Generic.Dictionary<TValue, global::CountedSet<TValue>.Node>.KeyCollection.Enumerator GetEnumerator()
	{
		return this.index.Keys.GetEnumerator();
	}

	// Token: 0x040007FB RID: 2043
	private global::System.Collections.Generic.Dictionary<TValue, global::CountedSet<TValue>.Node> index;

	// Token: 0x040007FC RID: 2044
	private uint totalRetains;

	// Token: 0x040007FD RID: 2045
	private uint nodeCount;

	// Token: 0x040007FE RID: 2046
	private static TValue[] empty = new TValue[0];

	// Token: 0x02000195 RID: 405
	public class Node
	{
		// Token: 0x06000BF8 RID: 3064 RVA: 0x0002E278 File Offset: 0x0002C478
		public Node()
		{
		}

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x06000BF9 RID: 3065 RVA: 0x0002E280 File Offset: 0x0002C480
		public bool Released
		{
			get
			{
				return this.done;
			}
		}

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x06000BFA RID: 3066 RVA: 0x0002E288 File Offset: 0x0002C488
		public bool Retained
		{
			get
			{
				return !this.done;
			}
		}

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x06000BFB RID: 3067 RVA: 0x0002E294 File Offset: 0x0002C494
		public uint ReferenceCount
		{
			get
			{
				return this.count + 1U;
			}
		}

		// Token: 0x06000BFC RID: 3068 RVA: 0x0002E2A0 File Offset: 0x0002C4A0
		public bool Release()
		{
			return !this.done && (this.count -= 1U) == 0U;
		}

		// Token: 0x06000BFD RID: 3069 RVA: 0x0002E2D0 File Offset: 0x0002C4D0
		public bool Retain()
		{
			return !this.done && this.count++ == 0U;
		}

		// Token: 0x040007FF RID: 2047
		public TValue v;

		// Token: 0x04000800 RID: 2048
		public bool done;

		// Token: 0x04000801 RID: 2049
		public uint count;
	}

	// Token: 0x02000196 RID: 406
	private class CustomComparer : global::System.Collections.Generic.EqualityComparer<global::CountedSet<TValue>.Node>, global::System.IDisposable
	{
		// Token: 0x06000BFE RID: 3070 RVA: 0x0002E300 File Offset: 0x0002C500
		public CustomComparer(global::System.Collections.Generic.IEqualityComparer<TValue> comparer)
		{
			this.comparer = comparer;
		}

		// Token: 0x06000BFF RID: 3071 RVA: 0x0002E310 File Offset: 0x0002C510
		public override bool Equals(global::CountedSet<TValue>.Node x, global::CountedSet<TValue>.Node y)
		{
			return this.comparer.Equals(x.v, y.v);
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x0002E32C File Offset: 0x0002C52C
		public override int GetHashCode(global::CountedSet<TValue>.Node obj)
		{
			return this.comparer.GetHashCode(obj.v);
		}

		// Token: 0x06000C01 RID: 3073 RVA: 0x0002E340 File Offset: 0x0002C540
		public void Dispose()
		{
			if (this.comparer is global::System.IDisposable)
			{
				((global::System.IDisposable)this.comparer).Dispose();
			}
			this.comparer = null;
		}

		// Token: 0x04000802 RID: 2050
		private global::System.Collections.Generic.IEqualityComparer<TValue> comparer;
	}

	// Token: 0x02000197 RID: 407
	private class DefaultComparer : global::System.Collections.Generic.EqualityComparer<global::CountedSet<TValue>.Node>
	{
		// Token: 0x06000C02 RID: 3074 RVA: 0x0002E36C File Offset: 0x0002C56C
		private DefaultComparer()
		{
			this.Comparer = global::System.Collections.Generic.EqualityComparer<TValue>.Default;
		}

		// Token: 0x06000C03 RID: 3075 RVA: 0x0002E380 File Offset: 0x0002C580
		public override bool Equals(global::CountedSet<TValue>.Node x, global::CountedSet<TValue>.Node y)
		{
			return this.Comparer.Equals(x.v, y.v);
		}

		// Token: 0x06000C04 RID: 3076 RVA: 0x0002E39C File Offset: 0x0002C59C
		public override int GetHashCode(global::CountedSet<TValue>.Node obj)
		{
			return this.Comparer.GetHashCode(obj.v);
		}

		// Token: 0x04000803 RID: 2051
		public readonly global::System.Collections.Generic.EqualityComparer<TValue> Comparer;

		// Token: 0x02000198 RID: 408
		public static class Singleton
		{
			// Token: 0x06000C05 RID: 3077 RVA: 0x0002E3B0 File Offset: 0x0002C5B0
			// Note: this type is marked as 'beforefieldinit'.
			static Singleton()
			{
			}

			// Token: 0x04000804 RID: 2052
			public static readonly global::CountedSet<TValue>.DefaultComparer Value = new global::CountedSet<TValue>.DefaultComparer();
		}
	}

	// Token: 0x02000199 RID: 409
	private struct ReleaseRecursor : global::System.IDisposable
	{
		// Token: 0x06000C06 RID: 3078 RVA: 0x0002E3BC File Offset: 0x0002C5BC
		public ReleaseRecursor(global::CountedSet<TValue> v)
		{
			this.s = v;
			this.dict = this.s.index;
			this.enumerator = this.dict.Values.GetEnumerator();
			this.array = global::CountedSet<TValue>.empty;
			this.count = 0;
			this.disposed = false;
		}

		// Token: 0x06000C07 RID: 3079 RVA: 0x0002E410 File Offset: 0x0002C610
		public void Run()
		{
			if (this.enumerator.MoveNext())
			{
				global::CountedSet<TValue>.Node node = this.enumerator.Current;
				if (node.Release())
				{
					this.s.totalRetains -= 1U;
					this.count++;
					this.Run();
					this.dict.Remove(node.v);
					this.s.nodeCount -= 1U;
					this.array[this.count--] = node.v;
				}
				else
				{
					this.s.totalRetains -= 1U;
				}
			}
			else
			{
				this.Dispose();
				if (this.count > 0)
				{
					this.array = new TValue[this.count];
				}
				this.count--;
			}
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x0002E500 File Offset: 0x0002C700
		public void Dispose()
		{
			if (!this.disposed)
			{
				this.disposed = true;
				this.enumerator.Dispose();
			}
		}

		// Token: 0x04000805 RID: 2053
		private global::CountedSet<TValue> s;

		// Token: 0x04000806 RID: 2054
		private global::System.Collections.Generic.Dictionary<TValue, global::CountedSet<TValue>.Node> dict;

		// Token: 0x04000807 RID: 2055
		private global::System.Collections.Generic.Dictionary<TValue, global::CountedSet<TValue>.Node>.ValueCollection.Enumerator enumerator;

		// Token: 0x04000808 RID: 2056
		public TValue[] array;

		// Token: 0x04000809 RID: 2057
		private int count;

		// Token: 0x0400080A RID: 2058
		private bool disposed;
	}
}
