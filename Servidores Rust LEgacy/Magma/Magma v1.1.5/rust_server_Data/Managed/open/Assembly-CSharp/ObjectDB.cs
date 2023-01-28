using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000498 RID: 1176
public sealed class ObjectDB<Object> : global::ODBList<Object>, global::System.Collections.IEnumerable, global::System.Collections.Generic.ICollection<!0>, global::System.Collections.Generic.IEnumerable<!0>, global::ODBEnumerable<Object, global::ODBForwardEnumerator<Object>> where Object : global::UnityEngine.Object
{
	// Token: 0x060028D1 RID: 10449 RVA: 0x0009B44C File Offset: 0x0009964C
	public ObjectDB() : base(true)
	{
	}

	// Token: 0x170008FB RID: 2299
	// (get) Token: 0x060028D2 RID: 10450 RVA: 0x0009B458 File Offset: 0x00099658
	bool global::System.Collections.Generic.ICollection<!0>.IsReadOnly
	{
		get
		{
			return true;
		}
	}

	// Token: 0x060028D3 RID: 10451 RVA: 0x0009B45C File Offset: 0x0009965C
	void global::System.Collections.Generic.ICollection<!0>.Add(Object value)
	{
		throw new global::System.NotSupportedException("Use register and you must keep track of the return value");
	}

	// Token: 0x060028D4 RID: 10452 RVA: 0x0009B468 File Offset: 0x00099668
	bool global::System.Collections.Generic.ICollection<!0>.Remove(Object value)
	{
		throw new global::System.NotSupportedException("You must call unregister using the return value from Register");
	}

	// Token: 0x060028D5 RID: 10453 RVA: 0x0009B474 File Offset: 0x00099674
	void global::System.Collections.Generic.ICollection<!0>.Clear()
	{
		throw new global::System.NotSupportedException("Clear would be catastrophic to design. you must manually unregister everything");
	}

	// Token: 0x060028D6 RID: 10454 RVA: 0x0009B480 File Offset: 0x00099680
	public global::ODBItem<Object> Register(Object value)
	{
		global::ODBNode<Object> node;
		if (base.DoAdd(value, out node))
		{
			return new global::ODBItem<Object>(node);
		}
		throw new global::System.ArgumentException(value.ToString() + " was already registered", "value");
	}

	// Token: 0x060028D7 RID: 10455 RVA: 0x0009B4C4 File Offset: 0x000996C4
	public void Unregister(ref global::ODBItem<Object> value)
	{
		if (!base.DoRemove(ref value.node))
		{
			throw new global::System.ArgumentException(value.node.ToString() + " does not belong to this list", "value");
		}
	}

	// Token: 0x060028D8 RID: 10456 RVA: 0x0009B4F8 File Offset: 0x000996F8
	public bool Contains(ref global::ODBItem<Object> value)
	{
		return base.Contains(value.node);
	}
}
