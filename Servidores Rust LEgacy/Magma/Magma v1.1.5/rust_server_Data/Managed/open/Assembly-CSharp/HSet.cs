using System;
using System.Collections.Generic;

// Token: 0x02000486 RID: 1158
public class HSet<T> : global::System.Collections.Generic.HashSet<T>
{
	// Token: 0x0600284C RID: 10316 RVA: 0x0009A144 File Offset: 0x00098344
	public HSet()
	{
	}

	// Token: 0x0600284D RID: 10317 RVA: 0x0009A14C File Offset: 0x0009834C
	public HSet(global::System.Collections.Generic.IEnumerable<T> collection) : base(collection)
	{
	}

	// Token: 0x0600284E RID: 10318 RVA: 0x0009A158 File Offset: 0x00098358
	public HSet(global::System.Collections.Generic.IEqualityComparer<T> comparer) : base(comparer)
	{
	}

	// Token: 0x0600284F RID: 10319 RVA: 0x0009A164 File Offset: 0x00098364
	public HSet(global::System.Collections.Generic.IEnumerable<T> collection, global::System.Collections.Generic.IEqualityComparer<T> comparer) : base(collection, comparer)
	{
	}

	// Token: 0x06002850 RID: 10320 RVA: 0x0009A170 File Offset: 0x00098370
	// Note: this type is marked as 'beforefieldinit'.
	static HSet()
	{
	}

	// Token: 0x06002851 RID: 10321 RVA: 0x0009A17C File Offset: 0x0009837C
	public new global::HSetIter<T> GetEnumerator()
	{
		return new global::HSetIter<T>(base.GetEnumerator());
	}

	// Token: 0x06002852 RID: 10322 RVA: 0x0009A18C File Offset: 0x0009838C
	private global::RecycleList<T> ToList()
	{
		global::HSetIter<T> enumerator = this.GetEnumerator();
		return global::RecycleList<T>.MakeFromValuedEnumerator<global::HSetIter<T>>(ref enumerator);
	}

	// Token: 0x06002853 RID: 10323 RVA: 0x0009A1A8 File Offset: 0x000983A8
	public global::RecycleList<T> UnionList(global::System.Collections.Generic.IEnumerable<T> unionWith)
	{
		global::RecycleList<T> result = null;
		try
		{
			global::HSet<T>.temp.UnionWith(this);
			global::HSet<T>.temp.UnionWith(unionWith);
			result = global::HSet<T>.temp.ToList();
		}
		finally
		{
			global::HSet<T>.temp.Clear();
		}
		return result;
	}

	// Token: 0x06002854 RID: 10324 RVA: 0x0009A208 File Offset: 0x00098408
	public global::RecycleList<T> IntersectList(global::System.Collections.Generic.IEnumerable<T> intersectWith)
	{
		global::RecycleList<T> result = null;
		try
		{
			global::HSet<T>.temp.UnionWith(this);
			global::HSet<T>.temp.IntersectWith(intersectWith);
			result = global::HSet<T>.temp.ToList();
		}
		finally
		{
			global::HSet<T>.temp.Clear();
		}
		return result;
	}

	// Token: 0x06002855 RID: 10325 RVA: 0x0009A268 File Offset: 0x00098468
	public global::RecycleList<T> ExceptList(global::System.Collections.Generic.IEnumerable<T> exceptWith)
	{
		global::RecycleList<T> result = null;
		try
		{
			global::HSet<T>.temp.UnionWith(this);
			global::HSet<T>.temp.ExceptWith(exceptWith);
			result = global::HSet<T>.temp.ToList();
		}
		finally
		{
			global::HSet<T>.temp.Clear();
		}
		return result;
	}

	// Token: 0x06002856 RID: 10326 RVA: 0x0009A2C8 File Offset: 0x000984C8
	public global::RecycleList<T> SymmetricExceptList(global::System.Collections.Generic.IEnumerable<T> exceptWith)
	{
		global::RecycleList<T> result = null;
		try
		{
			global::HSet<T>.temp.UnionWith(this);
			global::HSet<T>.temp.SymmetricExceptWith(exceptWith);
			result = global::HSet<T>.temp.ToList();
		}
		finally
		{
			global::HSet<T>.temp.Clear();
		}
		return result;
	}

	// Token: 0x06002857 RID: 10327 RVA: 0x0009A328 File Offset: 0x00098528
	public global::RecycleList<T> OperList(global::HSetOper oper, global::System.Collections.Generic.IEnumerable<T> collection)
	{
		switch (oper)
		{
		case global::HSetOper.Union:
			return this.UnionList(collection);
		case global::HSetOper.Intersect:
			return this.IntersectList(collection);
		case global::HSetOper.Except:
			return this.ExceptList(collection);
		case global::HSetOper.SymmetricExcept:
			return this.SymmetricExceptList(collection);
		default:
			throw new global::System.ArgumentException("Don't know what to do with " + oper, "oper");
		}
	}

	// Token: 0x04001415 RID: 5141
	private static global::HSet<T> temp = new global::HSet<T>();
}
