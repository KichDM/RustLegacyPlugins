using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x02000625 RID: 1573
[global::System.Serializable]
public struct ArmorModelMemberMap<T> : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<!0>, global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, T>>
{
	// Token: 0x0600320B RID: 12811 RVA: 0x000BFB8C File Offset: 0x000BDD8C
	public ArmorModelMemberMap(T defaultValue)
	{
		this = default(global::ArmorModelMemberMap<T>);
		for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
		{
			this[armorModelSlot] = defaultValue;
		}
	}

	// Token: 0x0600320C RID: 12812 RVA: 0x000BFBC4 File Offset: 0x000BDDC4
	global::System.Collections.Generic.IEnumerator<T> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
	{
		return new global::ArmorModelMemberMap<T>.Enumerator(this);
	}

	// Token: 0x0600320D RID: 12813 RVA: 0x000BFBD8 File Offset: 0x000BDDD8
	global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, T>> global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, !0>>.GetEnumerator()
	{
		return new global::ArmorModelMemberMap<T>.Enumerator(this);
	}

	// Token: 0x0600320E RID: 12814 RVA: 0x000BFBEC File Offset: 0x000BDDEC
	global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
	{
		return new global::ArmorModelMemberMap<T>.Enumerator(this);
	}

	// Token: 0x0600320F RID: 12815 RVA: 0x000BFC00 File Offset: 0x000BDE00
	public void Clear(T value)
	{
		for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
		{
			this[armorModelSlot] = value;
		}
	}

	// Token: 0x06003210 RID: 12816 RVA: 0x000BFC28 File Offset: 0x000BDE28
	public void Clear()
	{
		for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
		{
			this[armorModelSlot] = default(T);
		}
	}

	// Token: 0x06003211 RID: 12817 RVA: 0x000BFC58 File Offset: 0x000BDE58
	public global::ArmorModelMemberMap<T>.Enumerator GetEnumerator()
	{
		return new global::ArmorModelMemberMap<T>.Enumerator(this);
	}

	// Token: 0x06003212 RID: 12818 RVA: 0x000BFC68 File Offset: 0x000BDE68
	public int CopyTo(T[] array, int offset, int maxCount)
	{
		int num = (maxCount >= 4) ? 4 : maxCount;
		for (int i = 0; i < 4; i++)
		{
			array[offset++] = this[(global::ArmorModelSlot)i];
		}
		return offset;
	}

	// Token: 0x06003213 RID: 12819 RVA: 0x000BFCAC File Offset: 0x000BDEAC
	public void CopyFrom(T[] array, int offset)
	{
		for (int i = 0; i < 4; i++)
		{
			this[(global::ArmorModelSlot)i] = array[offset++];
		}
	}

	// Token: 0x17000A6E RID: 2670
	public T this[global::ArmorModelSlot slot]
	{
		get
		{
			switch (slot)
			{
			case global::ArmorModelSlot.Feet:
				return this.feet;
			case global::ArmorModelSlot.Legs:
				return this.legs;
			case global::ArmorModelSlot.Torso:
				return this.torso;
			case global::ArmorModelSlot.Head:
				return this.head;
			default:
				return default(T);
			}
		}
		set
		{
			switch (slot)
			{
			case global::ArmorModelSlot.Feet:
				this.feet = value;
				break;
			case global::ArmorModelSlot.Legs:
				this.legs = value;
				break;
			case global::ArmorModelSlot.Torso:
				this.torso = value;
				break;
			case global::ArmorModelSlot.Head:
				this.head = value;
				break;
			}
		}
	}

	// Token: 0x04001BE8 RID: 7144
	public T feet;

	// Token: 0x04001BE9 RID: 7145
	public T legs;

	// Token: 0x04001BEA RID: 7146
	public T torso;

	// Token: 0x04001BEB RID: 7147
	public T head;

	// Token: 0x02000626 RID: 1574
	public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<!0>, global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, T>>
	{
		// Token: 0x06003216 RID: 12822 RVA: 0x000BFD90 File Offset: 0x000BDF90
		internal Enumerator(global::ArmorModelMemberMap<T> collection)
		{
			this.collection = collection;
			this.index = -1;
		}

		// Token: 0x17000A6F RID: 2671
		// (get) Token: 0x06003217 RID: 12823 RVA: 0x000BFDA0 File Offset: 0x000BDFA0
		global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, T> global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, !0>>.Current
		{
			get
			{
				if (this.index > 0 && this.index < 4)
				{
					return new global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, T>((global::ArmorModelSlot)this.index, this.collection[(global::ArmorModelSlot)this.index]);
				}
				throw new global::System.InvalidOperationException();
			}
		}

		// Token: 0x17000A70 RID: 2672
		// (get) Token: 0x06003218 RID: 12824 RVA: 0x000BFDEC File Offset: 0x000BDFEC
		object global::System.Collections.IEnumerator.Current
		{
			get
			{
				return this.Current;
			}
		}

		// Token: 0x17000A71 RID: 2673
		// (get) Token: 0x06003219 RID: 12825 RVA: 0x000BFDFC File Offset: 0x000BDFFC
		public T Current
		{
			get
			{
				return (this.index <= 0 || this.index >= 4) ? default(T) : this.collection[(global::ArmorModelSlot)this.index];
			}
		}

		// Token: 0x0600321A RID: 12826 RVA: 0x000BFE44 File Offset: 0x000BE044
		public bool MoveNext()
		{
			return ++this.index < 4;
		}

		// Token: 0x0600321B RID: 12827 RVA: 0x000BFE68 File Offset: 0x000BE068
		public void Reset()
		{
			this.index = -1;
		}

		// Token: 0x0600321C RID: 12828 RVA: 0x000BFE74 File Offset: 0x000BE074
		public void Dispose()
		{
			this = default(global::ArmorModelMemberMap<T>.Enumerator);
		}

		// Token: 0x04001BEC RID: 7148
		private global::ArmorModelMemberMap<T> collection;

		// Token: 0x04001BED RID: 7149
		private int index;
	}
}
