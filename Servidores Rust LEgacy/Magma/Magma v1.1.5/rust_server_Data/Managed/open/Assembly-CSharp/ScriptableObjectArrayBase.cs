using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000EB RID: 235
public class ScriptableObjectArrayBase<T> : global::UnityEngine.ScriptableObject, global::System.Collections.IEnumerable, global::System.Collections.Generic.ICollection<T>, global::System.Collections.Generic.IList<T>, global::System.Collections.Generic.IEnumerable<!0>
{
	// Token: 0x06000497 RID: 1175 RVA: 0x00015FE8 File Offset: 0x000141E8
	public ScriptableObjectArrayBase()
	{
	}

	// Token: 0x06000498 RID: 1176 RVA: 0x00015FF0 File Offset: 0x000141F0
	global::System.Collections.Generic.IEnumerator<T> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
	{
		return this.array.GetEnumerator();
	}

	// Token: 0x06000499 RID: 1177 RVA: 0x00016000 File Offset: 0x00014200
	global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
	{
		return this.array.GetEnumerator();
	}

	// Token: 0x0600049A RID: 1178 RVA: 0x00016010 File Offset: 0x00014210
	void global::System.Collections.Generic.ICollection<!0>.Add(T item)
	{
		this.array.Add(item);
	}

	// Token: 0x0600049B RID: 1179 RVA: 0x00016020 File Offset: 0x00014220
	void global::System.Collections.Generic.ICollection<!0>.Clear()
	{
		this.array.Clear();
	}

	// Token: 0x0600049C RID: 1180 RVA: 0x00016030 File Offset: 0x00014230
	bool global::System.Collections.Generic.ICollection<!0>.Contains(T item)
	{
		return global::System.Array.IndexOf<T>(this.array, item) != -1;
	}

	// Token: 0x0600049D RID: 1181 RVA: 0x00016044 File Offset: 0x00014244
	void global::System.Collections.Generic.ICollection<!0>.CopyTo(T[] array, int arrayIndex)
	{
		this.array.CopyTo(array, arrayIndex);
	}

	// Token: 0x0600049E RID: 1182 RVA: 0x00016054 File Offset: 0x00014254
	bool global::System.Collections.Generic.ICollection<!0>.Remove(T item)
	{
		return this.array.Remove(item);
	}

	// Token: 0x170000A2 RID: 162
	// (get) Token: 0x0600049F RID: 1183 RVA: 0x00016064 File Offset: 0x00014264
	int global::System.Collections.Generic.ICollection<!0>.Count
	{
		get
		{
			return this.array.Count;
		}
	}

	// Token: 0x170000A3 RID: 163
	// (get) Token: 0x060004A0 RID: 1184 RVA: 0x00016074 File Offset: 0x00014274
	bool global::System.Collections.Generic.ICollection<!0>.IsReadOnly
	{
		get
		{
			return this.array.IsReadOnly;
		}
	}

	// Token: 0x060004A1 RID: 1185 RVA: 0x00016084 File Offset: 0x00014284
	int global::System.Collections.Generic.IList<!0>.IndexOf(T item)
	{
		return this.array.IndexOf(item);
	}

	// Token: 0x060004A2 RID: 1186 RVA: 0x00016094 File Offset: 0x00014294
	void global::System.Collections.Generic.IList<!0>.Insert(int index, T item)
	{
		this.array.Insert(index, item);
	}

	// Token: 0x060004A3 RID: 1187 RVA: 0x000160A4 File Offset: 0x000142A4
	void global::System.Collections.Generic.IList<!0>.RemoveAt(int index)
	{
		this.array.RemoveAt(index);
	}

	// Token: 0x170000A4 RID: 164
	T global::System.Collections.Generic.IList<!0>.this[int index]
	{
		get
		{
			return this.array[index];
		}
		set
		{
			this.array[index] = value;
		}
	}

	// Token: 0x170000A5 RID: 165
	// (get) Token: 0x060004A6 RID: 1190 RVA: 0x000160D4 File Offset: 0x000142D4
	public T[] array
	{
		get
		{
			return this._array ?? global::ScriptableObjectArrayBase<T>.konst.empty;
		}
	}

	// Token: 0x170000A6 RID: 166
	// (get) Token: 0x060004A7 RID: 1191 RVA: 0x000160E8 File Offset: 0x000142E8
	public int Length
	{
		get
		{
			return (this._array != null) ? this._array.Length : 0;
		}
	}

	// Token: 0x170000A7 RID: 167
	public T this[int i]
	{
		get
		{
			return this.array[i];
		}
	}

	// Token: 0x060004A9 RID: 1193 RVA: 0x00016114 File Offset: 0x00014314
	public global::ScriptableObjectArrayBase<T>.Enumerator GetEnumerator()
	{
		return new global::ScriptableObjectArrayBase<T>.Enumerator(this._array);
	}

	// Token: 0x04000445 RID: 1093
	[global::UnityEngine.SerializeField]
	private T[] _array;

	// Token: 0x020000EC RID: 236
	private static class konst
	{
		// Token: 0x060004AA RID: 1194 RVA: 0x00016124 File Offset: 0x00014324
		// Note: this type is marked as 'beforefieldinit'.
		static konst()
		{
		}

		// Token: 0x04000446 RID: 1094
		public static readonly T[] empty = new T[0];
	}

	// Token: 0x020000ED RID: 237
	public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<!0>
	{
		// Token: 0x060004AB RID: 1195 RVA: 0x00016134 File Offset: 0x00014334
		public Enumerator(T[] array)
		{
			this.array = (array ?? global::ScriptableObjectArrayBase<T>.konst.empty);
			this.i = -1;
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060004AC RID: 1196 RVA: 0x00016150 File Offset: 0x00014350
		object global::System.Collections.IEnumerator.Current
		{
			get
			{
				return this.array[this.i];
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x00016168 File Offset: 0x00014368
		public T Current
		{
			get
			{
				return this.array[this.i];
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x0001617C File Offset: 0x0001437C
		public void Reset()
		{
			this.i = -1;
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x00016188 File Offset: 0x00014388
		public bool MoveNext()
		{
			return ++this.i < (this.array ?? global::ScriptableObjectArrayBase<T>.konst.empty).Length;
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x000161BC File Offset: 0x000143BC
		public void Dispose()
		{
		}

		// Token: 0x04000447 RID: 1095
		private T[] array;

		// Token: 0x04000448 RID: 1096
		private int i;
	}
}
