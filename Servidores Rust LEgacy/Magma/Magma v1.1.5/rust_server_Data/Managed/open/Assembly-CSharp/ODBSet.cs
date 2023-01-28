using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000497 RID: 1175
public sealed class ODBSet<T> : global::ODBList<T> where T : global::UnityEngine.Object
{
	// Token: 0x060028C6 RID: 10438 RVA: 0x0009B3D0 File Offset: 0x000995D0
	public ODBSet()
	{
	}

	// Token: 0x060028C7 RID: 10439 RVA: 0x0009B3D8 File Offset: 0x000995D8
	public ODBSet(global::System.Collections.Generic.IEnumerable<T> collection) : base(collection)
	{
	}

	// Token: 0x060028C8 RID: 10440 RVA: 0x0009B3E4 File Offset: 0x000995E4
	public bool Add(T item)
	{
		return base.DoAdd(item);
	}

	// Token: 0x060028C9 RID: 10441 RVA: 0x0009B3F0 File Offset: 0x000995F0
	public bool Add(T item, out global::ODBNode<T> node)
	{
		return base.DoAdd(item, out node);
	}

	// Token: 0x060028CA RID: 10442 RVA: 0x0009B3FC File Offset: 0x000995FC
	public bool Remove(T item)
	{
		return base.DoRemove(item);
	}

	// Token: 0x060028CB RID: 10443 RVA: 0x0009B408 File Offset: 0x00099608
	public bool Remove(ref global::ODBNode<T> node)
	{
		return base.DoRemove(ref node);
	}

	// Token: 0x060028CC RID: 10444 RVA: 0x0009B414 File Offset: 0x00099614
	public void Clear()
	{
		base.DoClear();
	}

	// Token: 0x060028CD RID: 10445 RVA: 0x0009B41C File Offset: 0x0009961C
	public void UnionWith(global::ODBList<T> list)
	{
		base.DoUnionWith(list);
	}

	// Token: 0x060028CE RID: 10446 RVA: 0x0009B428 File Offset: 0x00099628
	public void IntersectWith(global::ODBList<T> list)
	{
		base.DoIntersectWith(list);
	}

	// Token: 0x060028CF RID: 10447 RVA: 0x0009B434 File Offset: 0x00099634
	public void ExceptWith(global::ODBList<T> list)
	{
		base.DoExceptWith(list);
	}

	// Token: 0x060028D0 RID: 10448 RVA: 0x0009B440 File Offset: 0x00099640
	public void SymmetricExceptWith(global::ODBList<T> list)
	{
		base.DoSymmetricExceptWith(list);
	}
}
