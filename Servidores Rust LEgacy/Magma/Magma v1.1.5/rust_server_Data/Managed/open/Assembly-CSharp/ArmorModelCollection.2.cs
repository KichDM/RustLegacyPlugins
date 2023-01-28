using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x02000621 RID: 1569
[global::System.Serializable]
public class ArmorModelCollection<T> : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<!0>, global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, !0>>
{
	// Token: 0x060031E0 RID: 12768 RVA: 0x000BF49C File Offset: 0x000BD69C
	public ArmorModelCollection()
	{
	}

	// Token: 0x060031E1 RID: 12769 RVA: 0x000BF4A4 File Offset: 0x000BD6A4
	public ArmorModelCollection(T defaultValue)
	{
		for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
		{
			this[armorModelSlot] = defaultValue;
		}
	}

	// Token: 0x060031E2 RID: 12770 RVA: 0x000BF4D4 File Offset: 0x000BD6D4
	public ArmorModelCollection(global::ArmorModelMemberMap<T> map) : this()
	{
		for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
		{
			this[armorModelSlot] = map[armorModelSlot];
		}
	}

	// Token: 0x060031E3 RID: 12771 RVA: 0x000BF508 File Offset: 0x000BD708
	global::System.Collections.Generic.IEnumerator<T> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
	{
		return new global::ArmorModelCollection<T>.Enumerator(this);
	}

	// Token: 0x060031E4 RID: 12772 RVA: 0x000BF518 File Offset: 0x000BD718
	global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, T>> global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, !0>>.GetEnumerator()
	{
		return new global::ArmorModelCollection<T>.Enumerator(this);
	}

	// Token: 0x060031E5 RID: 12773 RVA: 0x000BF528 File Offset: 0x000BD728
	global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
	{
		return new global::ArmorModelCollection<T>.Enumerator(this);
	}

	// Token: 0x060031E6 RID: 12774 RVA: 0x000BF538 File Offset: 0x000BD738
	public void Clear(T value)
	{
		for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
		{
			this[armorModelSlot] = value;
		}
	}

	// Token: 0x060031E7 RID: 12775 RVA: 0x000BF560 File Offset: 0x000BD760
	public void Clear()
	{
		for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
		{
			this[armorModelSlot] = default(T);
		}
	}

	// Token: 0x060031E8 RID: 12776 RVA: 0x000BF590 File Offset: 0x000BD790
	public global::ArmorModelCollection<T>.Enumerator GetEnumerator()
	{
		return new global::ArmorModelCollection<T>.Enumerator(this);
	}

	// Token: 0x060031E9 RID: 12777 RVA: 0x000BF598 File Offset: 0x000BD798
	public int CopyTo(T[] array, int offset, int maxCount)
	{
		int num = (maxCount >= 4) ? 4 : maxCount;
		for (int i = 0; i < 4; i++)
		{
			array[offset++] = this[(global::ArmorModelSlot)i];
		}
		return offset;
	}

	// Token: 0x060031EA RID: 12778 RVA: 0x000BF5DC File Offset: 0x000BD7DC
	public void CopyFrom(T[] array, int offset)
	{
		for (int i = 0; i < 4; i++)
		{
			this[(global::ArmorModelSlot)i] = array[offset++];
		}
	}

	// Token: 0x060031EB RID: 12779 RVA: 0x000BF610 File Offset: 0x000BD810
	public global::ArmorModelMemberMap<T> ToMemberMap()
	{
		global::ArmorModelMemberMap<T> result = default(global::ArmorModelMemberMap<T>);
		for (global::ArmorModelSlot armorModelSlot = global::ArmorModelSlot.Feet; armorModelSlot < (global::ArmorModelSlot)4; armorModelSlot += 1)
		{
			result[armorModelSlot] = this[armorModelSlot];
		}
		return result;
	}

	// Token: 0x17000A66 RID: 2662
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

	// Token: 0x04001BDC RID: 7132
	public T feet;

	// Token: 0x04001BDD RID: 7133
	public T legs;

	// Token: 0x04001BDE RID: 7134
	public T torso;

	// Token: 0x04001BDF RID: 7135
	public T head;

	// Token: 0x02000622 RID: 1570
	public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<!0>, global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<global::ArmorModelSlot, !0>>
	{
		// Token: 0x060031EE RID: 12782 RVA: 0x000BF6FC File Offset: 0x000BD8FC
		internal Enumerator(global::ArmorModelCollection<T> collection)
		{
			this.collection = collection;
			this.index = -1;
		}

		// Token: 0x17000A67 RID: 2663
		// (get) Token: 0x060031EF RID: 12783 RVA: 0x000BF70C File Offset: 0x000BD90C
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

		// Token: 0x17000A68 RID: 2664
		// (get) Token: 0x060031F0 RID: 12784 RVA: 0x000BF758 File Offset: 0x000BD958
		object global::System.Collections.IEnumerator.Current
		{
			get
			{
				return this.Current;
			}
		}

		// Token: 0x17000A69 RID: 2665
		// (get) Token: 0x060031F1 RID: 12785 RVA: 0x000BF768 File Offset: 0x000BD968
		public T Current
		{
			get
			{
				return (this.index <= 0 || this.index >= 4) ? default(T) : this.collection[(global::ArmorModelSlot)this.index];
			}
		}

		// Token: 0x060031F2 RID: 12786 RVA: 0x000BF7B0 File Offset: 0x000BD9B0
		public bool MoveNext()
		{
			return ++this.index < 4;
		}

		// Token: 0x060031F3 RID: 12787 RVA: 0x000BF7D4 File Offset: 0x000BD9D4
		public void Reset()
		{
			this.index = -1;
		}

		// Token: 0x060031F4 RID: 12788 RVA: 0x000BF7E0 File Offset: 0x000BD9E0
		public void Dispose()
		{
			this = default(global::ArmorModelCollection<T>.Enumerator);
		}

		// Token: 0x04001BE0 RID: 7136
		private global::ArmorModelCollection<T> collection;

		// Token: 0x04001BE1 RID: 7137
		private int index;
	}
}
