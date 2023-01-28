using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000496 RID: 1174
public class ODBList<T> : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<!0>, global::System.Collections.Generic.ICollection<!0>, global::ODBEnumerable<T, global::ODBForwardEnumerator<T>> where T : global::UnityEngine.Object
{
	// Token: 0x0600289C RID: 10396 RVA: 0x0009AC74 File Offset: 0x00098E74
	protected ODBList()
	{
		this.hashSet = new global::HSet<T>();
	}

	// Token: 0x0600289D RID: 10397 RVA: 0x0009AC88 File Offset: 0x00098E88
	protected ODBList(global::System.Collections.Generic.IEnumerable<T> collection) : this()
	{
		foreach (T item in collection)
		{
			this.DoAdd(item);
		}
	}

	// Token: 0x0600289E RID: 10398 RVA: 0x0009ACF0 File Offset: 0x00098EF0
	protected ODBList(bool isReadOnly) : this()
	{
		this.isReadOnly = isReadOnly;
	}

	// Token: 0x0600289F RID: 10399 RVA: 0x0009AD00 File Offset: 0x00098F00
	protected ODBList(bool isReadOnly, global::System.Collections.Generic.IEnumerable<T> collection) : this(collection)
	{
		this.isReadOnly = isReadOnly;
	}

	// Token: 0x060028A0 RID: 10400 RVA: 0x0009AD10 File Offset: 0x00098F10
	global::System.Collections.Generic.IEnumerator<T> global::System.Collections.Generic.IEnumerable<!0>.GetEnumerator()
	{
		global::ODBForwardEnumerator<T> enumerator = this.GetEnumerator();
		return global::ODBCachedEnumerator<T, global::ODBForwardEnumerator<T>>.Cache(ref enumerator);
	}

	// Token: 0x060028A1 RID: 10401 RVA: 0x0009AD2C File Offset: 0x00098F2C
	global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	// Token: 0x060028A2 RID: 10402 RVA: 0x0009AD3C File Offset: 0x00098F3C
	void global::System.Collections.Generic.ICollection<!0>.CopyTo(T[] array, int arrayIndex)
	{
		this.CopyTo(array, arrayIndex);
	}

	// Token: 0x170008F7 RID: 2295
	// (get) Token: 0x060028A3 RID: 10403 RVA: 0x0009AD48 File Offset: 0x00098F48
	int global::System.Collections.Generic.ICollection<!0>.Count
	{
		get
		{
			return this.count;
		}
	}

	// Token: 0x170008F8 RID: 2296
	// (get) Token: 0x060028A4 RID: 10404 RVA: 0x0009AD50 File Offset: 0x00098F50
	bool global::System.Collections.Generic.ICollection<!0>.IsReadOnly
	{
		get
		{
			return this.isReadOnly;
		}
	}

	// Token: 0x060028A5 RID: 10405 RVA: 0x0009AD58 File Offset: 0x00098F58
	void global::System.Collections.Generic.ICollection<!0>.Add(T item)
	{
		if (this.isReadOnly)
		{
			throw new global::System.NotSupportedException("Read Only");
		}
		if (!this.DoAdd(item))
		{
			throw new global::System.ArgumentException("The list already contains the given item " + item, "item");
		}
	}

	// Token: 0x060028A6 RID: 10406 RVA: 0x0009AD98 File Offset: 0x00098F98
	bool global::System.Collections.Generic.ICollection<!0>.Remove(T item)
	{
		if (this.isReadOnly)
		{
			throw new global::System.NotSupportedException("Read Only");
		}
		return this.DoRemove(item);
	}

	// Token: 0x060028A7 RID: 10407 RVA: 0x0009ADB8 File Offset: 0x00098FB8
	void global::System.Collections.Generic.ICollection<!0>.Clear()
	{
		if (this.isReadOnly)
		{
			throw new global::System.NotSupportedException("Read Only");
		}
		this.DoClear();
	}

	// Token: 0x170008F9 RID: 2297
	// (get) Token: 0x060028A8 RID: 10408 RVA: 0x0009ADD8 File Offset: 0x00098FD8
	public global::ODBForwardEnumerable<T> forward
	{
		get
		{
			return new global::ODBForwardEnumerable<T>(this);
		}
	}

	// Token: 0x170008FA RID: 2298
	// (get) Token: 0x060028A9 RID: 10409 RVA: 0x0009ADE0 File Offset: 0x00098FE0
	public global::ODBReverseEnumerable<T> reverse
	{
		get
		{
			return new global::ODBReverseEnumerable<T>(this);
		}
	}

	// Token: 0x060028AA RID: 10410 RVA: 0x0009ADE8 File Offset: 0x00098FE8
	public bool Contains(T item)
	{
		return this.any && this.hashSet.Contains(item);
	}

	// Token: 0x060028AB RID: 10411 RVA: 0x0009AE04 File Offset: 0x00099004
	public bool Contains(global::ODBNode<T> item)
	{
		return this.any && item.list == this;
	}

	// Token: 0x060028AC RID: 10412 RVA: 0x0009AE20 File Offset: 0x00099020
	public int CopyTo(T[] array)
	{
		return this.CopyTo(array, 0, this.count);
	}

	// Token: 0x060028AD RID: 10413 RVA: 0x0009AE30 File Offset: 0x00099030
	public int CopyTo(T[] array, int arrayIndex)
	{
		return this.CopyTo(array, arrayIndex, this.count);
	}

	// Token: 0x060028AE RID: 10414 RVA: 0x0009AE40 File Offset: 0x00099040
	public int CopyTo(T[] array, int arrayIndex, int count)
	{
		if (!this.any)
		{
			return 0;
		}
		global::ODBNode<T> item = this.first.item;
		int num = -1;
		if (count > this.count)
		{
			count = this.count;
		}
		while (++num < count)
		{
			array[arrayIndex++] = item.self;
			item = item.n.item;
		}
		return num;
	}

	// Token: 0x060028AF RID: 10415 RVA: 0x0009AEAC File Offset: 0x000990AC
	public T[] ToArray()
	{
		T[] array = new T[this.count];
		this.CopyTo(array, 0, this.count);
		return array;
	}

	// Token: 0x060028B0 RID: 10416 RVA: 0x0009AED8 File Offset: 0x000990D8
	public global::ODBForwardEnumerator<T> GetEnumerator()
	{
		return new global::ODBForwardEnumerator<T>(this);
	}

	// Token: 0x060028B1 RID: 10417 RVA: 0x0009AEE0 File Offset: 0x000990E0
	public global::System.Collections.Generic.IEnumerable<T> ToGeneric()
	{
		return this;
	}

	// Token: 0x060028B2 RID: 10418 RVA: 0x0009AEE4 File Offset: 0x000990E4
	protected bool DoAdd(T item)
	{
		if (!item)
		{
			throw new global::UnityEngine.MissingReferenceException("You cannot pass a missing or null item into the list");
		}
		if (this.hashSet.Add(item))
		{
			global::ODBNode<T>.New(this, item);
			return true;
		}
		return false;
	}

	// Token: 0x060028B3 RID: 10419 RVA: 0x0009AF20 File Offset: 0x00099120
	protected bool DoAdd(T item, out global::ODBNode<T> node)
	{
		if (!item)
		{
			throw new global::UnityEngine.MissingReferenceException("You cannot pass a missing or null item into the list");
		}
		if (this.hashSet.Add(item))
		{
			node = global::ODBNode<T>.New(this, item);
			return true;
		}
		node = null;
		return false;
	}

	// Token: 0x060028B4 RID: 10420 RVA: 0x0009AF60 File Offset: 0x00099160
	protected bool DoRemove(ref global::ODBNode<T> node)
	{
		if (this.any && node.list == this)
		{
			this.hashSet.Remove(node.self);
			node.Dispose();
			node = null;
			return true;
		}
		return false;
	}

	// Token: 0x060028B5 RID: 10421 RVA: 0x0009AFA8 File Offset: 0x000991A8
	protected bool DoRemove(T item)
	{
		if (this.any && this.hashSet.Remove(item))
		{
			this.KnownFind(item).Dispose();
			return true;
		}
		return false;
	}

	// Token: 0x060028B6 RID: 10422 RVA: 0x0009AFD8 File Offset: 0x000991D8
	protected void DoClear()
	{
		if (this.any)
		{
			this.hashSet.Clear();
			do
			{
				this.first.item.Dispose();
			}
			while (this.any);
		}
	}

	// Token: 0x060028B7 RID: 10423 RVA: 0x0009B00C File Offset: 0x0009920C
	protected void DoUnionWith(global::ODBList<T> list)
	{
		if (!list.any || list == this)
		{
			return;
		}
		global::ODBSibling<T> n = list.first;
		do
		{
			T self = n.item.self;
			n = n.item.n;
			if (this.hashSet.Add(self))
			{
				global::ODBNode<T>.New(this, self);
			}
		}
		while (n.has);
	}

	// Token: 0x060028B8 RID: 10424 RVA: 0x0009B074 File Offset: 0x00099274
	protected void DoExceptWith(global::ODBList<T> list)
	{
		if (!this.any || !list.any)
		{
			return;
		}
		if (list == this)
		{
			this.DoClear();
		}
		else
		{
			global::ODBSibling<T> n = list.first;
			do
			{
				T self = n.item.self;
				n = n.item.n;
				if (this.hashSet.Remove(self))
				{
					this.KnownFind(self).Dispose();
				}
			}
			while (n.has);
		}
	}

	// Token: 0x060028B9 RID: 10425 RVA: 0x0009B0F4 File Offset: 0x000992F4
	protected void DoSymmetricExceptWith(global::ODBList<T> list)
	{
		if (this.any)
		{
			if (list.any)
			{
				if (list == this)
				{
					this.DoClear();
				}
				else
				{
					global::ODBSibling<T> n = list.first;
					do
					{
						T self = n.item.self;
						n = n.item.n;
						if (this.hashSet.Remove(self))
						{
							this.KnownFind(self).Dispose();
						}
						else
						{
							this.hashSet.Add(self);
							global::ODBNode<T>.New(this, self);
						}
					}
					while (n.has);
				}
			}
		}
		else if (list.any)
		{
			global::ODBSibling<T> n2 = list.first;
			do
			{
				T self2 = n2.item.self;
				n2 = n2.item.n;
				this.hashSet.Add(self2);
				global::ODBNode<T>.New(this, self2);
			}
			while (n2.has);
		}
	}

	// Token: 0x060028BA RID: 10426 RVA: 0x0009B1E0 File Offset: 0x000993E0
	protected void DoIntersectWith(global::ODBList<T> list)
	{
		if (this.any)
		{
			if (list.any)
			{
				if (list != this)
				{
					this.hashSet.IntersectWith(list.hashSet);
					int num = this.hashSet.Count;
					if (num == 0)
					{
						while (this.any)
						{
							this.first.item.Dispose();
						}
					}
					else
					{
						global::ODBSibling<T> n = this.first;
						do
						{
							global::ODBNode<T> item = n.item;
							n = n.item.n;
							if (!this.hashSet.Contains(item.self))
							{
								item.Dispose();
								if (this.count == num)
								{
									break;
								}
							}
						}
						while (n.has);
					}
				}
			}
			else
			{
				this.DoClear();
			}
		}
	}

	// Token: 0x060028BB RID: 10427 RVA: 0x0009B2B4 File Offset: 0x000994B4
	protected global::ODBNode<T> KnownFind(T item)
	{
		global::ODBSibling<T> n = this.first;
		for (;;)
		{
			T self = n.item.self;
			if (self == item)
			{
				break;
			}
			n = n.item.n;
			if (!n.has)
			{
				goto Block_2;
			}
		}
		return n.item;
		Block_2:
		throw new global::System.ArgumentException("item was not found", "item");
	}

	// Token: 0x060028BC RID: 10428 RVA: 0x0009B31C File Offset: 0x0009951C
	public global::RecycleList<T> UnionList(global::ODBList<T> list)
	{
		return this.hashSet.UnionList(list.hashSet);
	}

	// Token: 0x060028BD RID: 10429 RVA: 0x0009B330 File Offset: 0x00099530
	public global::RecycleList<T> UnionList(global::System.Collections.Generic.IEnumerable<T> e)
	{
		return this.hashSet.UnionList(e);
	}

	// Token: 0x060028BE RID: 10430 RVA: 0x0009B340 File Offset: 0x00099540
	public global::RecycleList<T> IntersectList(global::ODBList<T> list)
	{
		return this.hashSet.IntersectList(list.hashSet);
	}

	// Token: 0x060028BF RID: 10431 RVA: 0x0009B354 File Offset: 0x00099554
	public global::RecycleList<T> IntersectList(global::System.Collections.Generic.IEnumerable<T> e)
	{
		return this.hashSet.IntersectList(e);
	}

	// Token: 0x060028C0 RID: 10432 RVA: 0x0009B364 File Offset: 0x00099564
	public global::RecycleList<T> ExceptList(global::ODBList<T> list)
	{
		return this.hashSet.ExceptList(list.hashSet);
	}

	// Token: 0x060028C1 RID: 10433 RVA: 0x0009B378 File Offset: 0x00099578
	public global::RecycleList<T> ExceptList(global::System.Collections.Generic.IEnumerable<T> e)
	{
		return this.hashSet.ExceptList(e);
	}

	// Token: 0x060028C2 RID: 10434 RVA: 0x0009B388 File Offset: 0x00099588
	public global::RecycleList<T> SymmetricExceptList(global::ODBList<T> list)
	{
		return this.hashSet.SymmetricExceptList(list.hashSet);
	}

	// Token: 0x060028C3 RID: 10435 RVA: 0x0009B39C File Offset: 0x0009959C
	public global::RecycleList<T> SymmetricExceptList(global::System.Collections.Generic.IEnumerable<T> e)
	{
		return this.hashSet.SymmetricExceptList(e);
	}

	// Token: 0x060028C4 RID: 10436 RVA: 0x0009B3AC File Offset: 0x000995AC
	public global::RecycleList<T> OperList(global::HSetOper oper, global::ODBList<T> list)
	{
		return this.hashSet.OperList(oper, list.hashSet);
	}

	// Token: 0x060028C5 RID: 10437 RVA: 0x0009B3C0 File Offset: 0x000995C0
	public global::RecycleList<T> OperList(global::HSetOper oper, global::System.Collections.Generic.IEnumerable<T> collection)
	{
		return this.hashSet.OperList(oper, collection);
	}

	// Token: 0x0400142F RID: 5167
	protected readonly global::HSet<T> hashSet;

	// Token: 0x04001430 RID: 5168
	public global::ODBSibling<T> first;

	// Token: 0x04001431 RID: 5169
	public global::ODBSibling<T> last;

	// Token: 0x04001432 RID: 5170
	public int count;

	// Token: 0x04001433 RID: 5171
	public bool any;

	// Token: 0x04001434 RID: 5172
	private readonly bool isReadOnly;
}
