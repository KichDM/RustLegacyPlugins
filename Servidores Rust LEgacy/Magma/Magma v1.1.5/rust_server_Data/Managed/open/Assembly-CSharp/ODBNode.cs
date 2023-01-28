using System;
using UnityEngine;

// Token: 0x02000494 RID: 1172
public class ODBNode<T> : global::System.IDisposable where T : global::UnityEngine.Object
{
	// Token: 0x06002892 RID: 10386 RVA: 0x0009A8D8 File Offset: 0x00098AD8
	private ODBNode()
	{
	}

	// Token: 0x170008F3 RID: 2291
	// (get) Token: 0x06002893 RID: 10387 RVA: 0x0009A8E0 File Offset: 0x00098AE0
	public global::ODBReverseEnumerable<T> beforeInclusive
	{
		get
		{
			return new global::ODBReverseEnumerable<T>(this);
		}
	}

	// Token: 0x170008F4 RID: 2292
	// (get) Token: 0x06002894 RID: 10388 RVA: 0x0009A8E8 File Offset: 0x00098AE8
	public global::ODBReverseEnumerable<T> beforeExclusive
	{
		get
		{
			return new global::ODBReverseEnumerable<T>(this.p);
		}
	}

	// Token: 0x170008F5 RID: 2293
	// (get) Token: 0x06002895 RID: 10389 RVA: 0x0009A8F8 File Offset: 0x00098AF8
	public global::ODBForwardEnumerable<T> afterInclusive
	{
		get
		{
			return new global::ODBForwardEnumerable<T>(this);
		}
	}

	// Token: 0x170008F6 RID: 2294
	// (get) Token: 0x06002896 RID: 10390 RVA: 0x0009A900 File Offset: 0x00098B00
	public global::ODBForwardEnumerable<T> afterExclusive
	{
		get
		{
			return new global::ODBForwardEnumerable<T>(this.n);
		}
	}

	// Token: 0x06002897 RID: 10391 RVA: 0x0009A910 File Offset: 0x00098B10
	private void Setup(global::ODBList<T> list, T self)
	{
		this.self = self;
		this.list = list;
		this.hasList = true;
		this.n = default(global::ODBSibling<T>);
		if (list.any)
		{
			this.p = list.last;
			this.p.item.n.item = this;
			this.p.item.n.has = true;
			list.last.item = this;
			list.count++;
		}
		else
		{
			list.count = 1;
			list.any = true;
			global::ODBSibling<T> odbsibling;
			odbsibling.has = true;
			odbsibling.item = this;
			list.first = odbsibling;
			list.last = odbsibling;
		}
	}

	// Token: 0x06002898 RID: 10392 RVA: 0x0009A9D0 File Offset: 0x00098BD0
	public static global::ODBNode<T> New(global::ODBList<T> list, T self)
	{
		global::ODBNode<T> odbnode;
		if (!global::ODBNode<T>.recycle.Pop(out odbnode))
		{
			odbnode = new global::ODBNode<T>();
		}
		odbnode.Setup(list, self);
		return odbnode;
	}

	// Token: 0x06002899 RID: 10393 RVA: 0x0009AA00 File Offset: 0x00098C00
	public void Dispose()
	{
		if (this.hasList)
		{
			if (this.n.has)
			{
				if (this.p.has)
				{
					this.p.item.n = this.n;
					this.n.item.p = this.p;
					this.p = default(global::ODBSibling<T>);
					this.list.count--;
				}
				else
				{
					this.n.item.p = default(global::ODBSibling<T>);
					this.list.first = this.n;
					this.list.count--;
				}
			}
			else if (this.p.has)
			{
				this.p.item.n = default(global::ODBSibling<T>);
				this.list.last = this.p;
				this.p = default(global::ODBSibling<T>);
				this.list.count--;
			}
			else
			{
				this.list.count = 0;
				this.list.any = false;
				this.list.first = default(global::ODBSibling<T>);
				this.list.last = default(global::ODBSibling<T>);
			}
			this.hasList = false;
			this.list = null;
			global::ODBNode<T>.recycle.Push(this);
		}
	}

	// Token: 0x04001426 RID: 5158
	public T self;

	// Token: 0x04001427 RID: 5159
	public global::ODBSibling<T> n;

	// Token: 0x04001428 RID: 5160
	public global::ODBSibling<T> p;

	// Token: 0x04001429 RID: 5161
	public global::ODBList<T> list;

	// Token: 0x0400142A RID: 5162
	private bool hasList;

	// Token: 0x0400142B RID: 5163
	private static global::ODBNode<T>.Recycler recycle;

	// Token: 0x02000495 RID: 1173
	private struct Recycler
	{
		// Token: 0x0600289A RID: 10394 RVA: 0x0009AB8C File Offset: 0x00098D8C
		public bool Pop(out global::ODBNode<T> o)
		{
			o = this.items;
			if (this.any)
			{
				if (--this.count == 0)
				{
					this.any = false;
					this.items = null;
				}
				else
				{
					this.items = o.n.item;
				}
				return true;
			}
			return false;
		}

		// Token: 0x0600289B RID: 10395 RVA: 0x0009ABEC File Offset: 0x00098DEC
		public void Push(global::ODBNode<T> item)
		{
			item.list = null;
			item.self = (T)((object)null);
			if (this.any)
			{
				item.n.item = this.items;
				item.n.has = true;
				this.items = item;
				this.count++;
			}
			else
			{
				item.n = default(global::ODBSibling<T>);
				this.items = item;
				this.count = 1;
				this.any = true;
			}
		}

		// Token: 0x0400142C RID: 5164
		public global::ODBNode<T> items;

		// Token: 0x0400142D RID: 5165
		public int count;

		// Token: 0x0400142E RID: 5166
		public bool any;
	}
}
