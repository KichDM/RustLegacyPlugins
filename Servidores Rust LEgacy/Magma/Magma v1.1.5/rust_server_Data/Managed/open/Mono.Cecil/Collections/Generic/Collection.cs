using System;
using System.Collections;
using System.Collections.Generic;

namespace Mono.Collections.Generic
{
	// Token: 0x0200001F RID: 31
	public class Collection<T> : global::System.Collections.Generic.IList<T>, global::System.Collections.Generic.ICollection<T>, global::System.Collections.Generic.IEnumerable<T>, global::System.Collections.IList, global::System.Collections.ICollection, global::System.Collections.IEnumerable
	{
		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000173 RID: 371 RVA: 0x00004D29 File Offset: 0x00002F29
		public int Count
		{
			get
			{
				return this.size;
			}
		}

		// Token: 0x1700009F RID: 159
		public T this[int index]
		{
			get
			{
				if (index >= this.size)
				{
					throw new global::System.ArgumentOutOfRangeException();
				}
				return this.items[index];
			}
			set
			{
				this.CheckIndex(index);
				if (index == this.size)
				{
					throw new global::System.ArgumentOutOfRangeException();
				}
				this.OnSet(value, index);
				this.items[index] = value;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000176 RID: 374 RVA: 0x00004D7B File Offset: 0x00002F7B
		bool global::System.Collections.Generic.ICollection<!0>.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000177 RID: 375 RVA: 0x00004D7E File Offset: 0x00002F7E
		bool global::System.Collections.IList.IsFixedSize
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000178 RID: 376 RVA: 0x00004D81 File Offset: 0x00002F81
		bool global::System.Collections.IList.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000A3 RID: 163
		object global::System.Collections.IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				this.CheckIndex(index);
				try
				{
					this[index] = (T)((object)value);
					return;
				}
				catch (global::System.InvalidCastException)
				{
				}
				catch (global::System.NullReferenceException)
				{
				}
				throw new global::System.ArgumentException();
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600017B RID: 379 RVA: 0x00004DE0 File Offset: 0x00002FE0
		int global::System.Collections.ICollection.Count
		{
			get
			{
				return this.Count;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600017C RID: 380 RVA: 0x00004DE8 File Offset: 0x00002FE8
		bool global::System.Collections.ICollection.IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600017D RID: 381 RVA: 0x00004DEB File Offset: 0x00002FEB
		object global::System.Collections.ICollection.SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00004DEE File Offset: 0x00002FEE
		public Collection()
		{
			this.items = global::Mono.Empty<T>.Array;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00004E01 File Offset: 0x00003001
		public Collection(int capacity)
		{
			if (capacity < 0)
			{
				throw new global::System.ArgumentOutOfRangeException();
			}
			this.items = new T[capacity];
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00004E20 File Offset: 0x00003020
		public Collection(global::System.Collections.Generic.ICollection<T> items)
		{
			if (items == null)
			{
				throw new global::System.ArgumentNullException("items");
			}
			this.items = new T[items.Count];
			items.CopyTo(this.items, 0);
			this.size = this.items.Length;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00004E70 File Offset: 0x00003070
		public void Add(T item)
		{
			if (this.size == this.items.Length)
			{
				this.Grow(1);
			}
			this.OnAdd(item, this.size);
			this.items[this.size++] = item;
			this.version++;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00004ECC File Offset: 0x000030CC
		public bool Contains(T item)
		{
			return this.IndexOf(item) != -1;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00004EDB File Offset: 0x000030DB
		public int IndexOf(T item)
		{
			return global::System.Array.IndexOf<T>(this.items, item, 0, this.size);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00004EF0 File Offset: 0x000030F0
		public void Insert(int index, T item)
		{
			this.CheckIndex(index);
			if (this.size == this.items.Length)
			{
				this.Grow(1);
			}
			this.OnInsert(item, index);
			this.Shift(index, 1);
			this.items[index] = item;
			this.version++;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00004F48 File Offset: 0x00003148
		public void RemoveAt(int index)
		{
			if (index < 0 || index >= this.size)
			{
				throw new global::System.ArgumentOutOfRangeException();
			}
			T item = this.items[index];
			this.OnRemove(item, index);
			this.Shift(index, -1);
			global::System.Array.Clear(this.items, this.size, 1);
			this.version++;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00004FA8 File Offset: 0x000031A8
		public bool Remove(T item)
		{
			int num = this.IndexOf(item);
			if (num == -1)
			{
				return false;
			}
			this.OnRemove(item, num);
			this.Shift(num, -1);
			global::System.Array.Clear(this.items, this.size, 1);
			this.version++;
			return true;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00004FF4 File Offset: 0x000031F4
		public void Clear()
		{
			this.OnClear();
			global::System.Array.Clear(this.items, 0, this.size);
			this.size = 0;
			this.version++;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00005023 File Offset: 0x00003223
		public void CopyTo(T[] array, int arrayIndex)
		{
			global::System.Array.Copy(this.items, 0, array, arrayIndex, this.size);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000503C File Offset: 0x0000323C
		public T[] ToArray()
		{
			T[] array = new T[this.size];
			global::System.Array.Copy(this.items, 0, array, 0, this.size);
			return array;
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000506A File Offset: 0x0000326A
		private void CheckIndex(int index)
		{
			if (index < 0 || index > this.size)
			{
				throw new global::System.ArgumentOutOfRangeException();
			}
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00005080 File Offset: 0x00003280
		private void Shift(int start, int delta)
		{
			if (delta < 0)
			{
				start -= delta;
			}
			if (start < this.size)
			{
				global::System.Array.Copy(this.items, start, this.items, start + delta, this.size - start);
			}
			this.size += delta;
			if (delta < 0)
			{
				global::System.Array.Clear(this.items, this.size, -delta);
			}
		}

		// Token: 0x0600018C RID: 396 RVA: 0x000050E1 File Offset: 0x000032E1
		protected virtual void OnAdd(T item, int index)
		{
		}

		// Token: 0x0600018D RID: 397 RVA: 0x000050E3 File Offset: 0x000032E3
		protected virtual void OnInsert(T item, int index)
		{
		}

		// Token: 0x0600018E RID: 398 RVA: 0x000050E5 File Offset: 0x000032E5
		protected virtual void OnSet(T item, int index)
		{
		}

		// Token: 0x0600018F RID: 399 RVA: 0x000050E7 File Offset: 0x000032E7
		protected virtual void OnRemove(T item, int index)
		{
		}

		// Token: 0x06000190 RID: 400 RVA: 0x000050E9 File Offset: 0x000032E9
		protected virtual void OnClear()
		{
		}

		// Token: 0x06000191 RID: 401 RVA: 0x000050EC File Offset: 0x000032EC
		internal virtual void Grow(int desired)
		{
			int num = this.size + desired;
			if (num <= this.items.Length)
			{
				return;
			}
			num = global::System.Math.Max(global::System.Math.Max(this.items.Length * 2, 4), num);
			global::System.Array.Resize<T>(ref this.items, num);
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00005134 File Offset: 0x00003334
		int global::System.Collections.IList.Add(object value)
		{
			try
			{
				this.Add((T)((object)value));
				return this.size - 1;
			}
			catch (global::System.InvalidCastException)
			{
			}
			catch (global::System.NullReferenceException)
			{
			}
			throw new global::System.ArgumentException();
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00005184 File Offset: 0x00003384
		void global::System.Collections.IList.Clear()
		{
			this.Clear();
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0000518C File Offset: 0x0000338C
		bool global::System.Collections.IList.Contains(object value)
		{
			return ((global::System.Collections.IList)this).IndexOf(value) > -1;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00005198 File Offset: 0x00003398
		int global::System.Collections.IList.IndexOf(object value)
		{
			try
			{
				return this.IndexOf((T)((object)value));
			}
			catch (global::System.InvalidCastException)
			{
			}
			catch (global::System.NullReferenceException)
			{
			}
			return -1;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x000051DC File Offset: 0x000033DC
		void global::System.Collections.IList.Insert(int index, object value)
		{
			this.CheckIndex(index);
			try
			{
				this.Insert(index, (T)((object)value));
				return;
			}
			catch (global::System.InvalidCastException)
			{
			}
			catch (global::System.NullReferenceException)
			{
			}
			throw new global::System.ArgumentException();
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00005228 File Offset: 0x00003428
		void global::System.Collections.IList.Remove(object value)
		{
			try
			{
				this.Remove((T)((object)value));
			}
			catch (global::System.InvalidCastException)
			{
			}
			catch (global::System.NullReferenceException)
			{
			}
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00005268 File Offset: 0x00003468
		void global::System.Collections.IList.RemoveAt(int index)
		{
			this.RemoveAt(index);
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00005271 File Offset: 0x00003471
		void global::System.Collections.ICollection.CopyTo(global::System.Array array, int index)
		{
			global::System.Array.Copy(this.items, 0, array, index, this.size);
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00005287 File Offset: 0x00003487
		public global::Mono.Collections.Generic.Collection<T>.Enumerator GetEnumerator()
		{
			return new global::Mono.Collections.Generic.Collection<T>.Enumerator(this);
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000528F File Offset: 0x0000348F
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return new global::Mono.Collections.Generic.Collection<T>.Enumerator(this);
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0000529C File Offset: 0x0000349C
		global::System.Collections.Generic.IEnumerator<T> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
		{
			return new global::Mono.Collections.Generic.Collection<T>.Enumerator(this);
		}

		// Token: 0x04000095 RID: 149
		internal T[] items;

		// Token: 0x04000096 RID: 150
		internal int size;

		// Token: 0x04000097 RID: 151
		private int version;

		// Token: 0x02000020 RID: 32
		public struct Enumerator : global::System.Collections.Generic.IEnumerator<T>, global::System.Collections.IEnumerator, global::System.IDisposable
		{
			// Token: 0x170000A7 RID: 167
			// (get) Token: 0x0600019D RID: 413 RVA: 0x000052A9 File Offset: 0x000034A9
			public T Current
			{
				get
				{
					return this.current;
				}
			}

			// Token: 0x170000A8 RID: 168
			// (get) Token: 0x0600019E RID: 414 RVA: 0x000052B1 File Offset: 0x000034B1
			object global::System.Collections.IEnumerator.Current
			{
				get
				{
					this.CheckState();
					if (this.next <= 0)
					{
						throw new global::System.InvalidOperationException();
					}
					return this.current;
				}
			}

			// Token: 0x0600019F RID: 415 RVA: 0x000052D3 File Offset: 0x000034D3
			internal Enumerator(global::Mono.Collections.Generic.Collection<T> collection)
			{
				this = default(global::Mono.Collections.Generic.Collection<T>.Enumerator);
				this.collection = collection;
				this.version = collection.version;
			}

			// Token: 0x060001A0 RID: 416 RVA: 0x000052F0 File Offset: 0x000034F0
			public bool MoveNext()
			{
				this.CheckState();
				if (this.next < 0)
				{
					return false;
				}
				if (this.next < this.collection.size)
				{
					this.current = this.collection.items[this.next++];
					return true;
				}
				this.next = -1;
				return false;
			}

			// Token: 0x060001A1 RID: 417 RVA: 0x00005352 File Offset: 0x00003552
			public void Reset()
			{
				this.CheckState();
				this.next = 0;
			}

			// Token: 0x060001A2 RID: 418 RVA: 0x00005361 File Offset: 0x00003561
			private void CheckState()
			{
				if (this.collection == null)
				{
					throw new global::System.ObjectDisposedException(base.GetType().FullName);
				}
				if (this.version != this.collection.version)
				{
					throw new global::System.InvalidOperationException();
				}
			}

			// Token: 0x060001A3 RID: 419 RVA: 0x0000539F File Offset: 0x0000359F
			public void Dispose()
			{
				this.collection = null;
			}

			// Token: 0x04000098 RID: 152
			private global::Mono.Collections.Generic.Collection<T> collection;

			// Token: 0x04000099 RID: 153
			private T current;

			// Token: 0x0400009A RID: 154
			private int next;

			// Token: 0x0400009B RID: 155
			private readonly int version;
		}
	}
}
