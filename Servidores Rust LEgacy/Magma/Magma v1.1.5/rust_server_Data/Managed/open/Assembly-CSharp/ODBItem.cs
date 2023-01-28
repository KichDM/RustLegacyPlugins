using System;
using UnityEngine;

// Token: 0x02000483 RID: 1155
public struct ODBItem<TItem> : global::System.IEquatable<TItem> where TItem : global::UnityEngine.Object
{
	// Token: 0x0600283A RID: 10298 RVA: 0x00099F1C File Offset: 0x0009811C
	internal ODBItem(global::ODBNode<TItem> node)
	{
		this.node = node;
	}

	// Token: 0x0600283B RID: 10299 RVA: 0x00099F28 File Offset: 0x00098128
	public override int GetHashCode()
	{
		return this.node.GetHashCode();
	}

	// Token: 0x0600283C RID: 10300 RVA: 0x00099F38 File Offset: 0x00098138
	public override string ToString()
	{
		return this.node.ToString();
	}

	// Token: 0x0600283D RID: 10301 RVA: 0x00099F48 File Offset: 0x00098148
	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return this.node == null || !this.node.self;
		}
		if (obj is global::ODBItem<TItem>)
		{
			return ((global::ODBItem<TItem>)obj).node == this.node;
		}
		if (obj is global::UnityEngine.Object)
		{
			return this.node != null && this.node.self && this.node.self == (global::UnityEngine.Object)obj;
		}
		return obj.Equals(this.node);
	}

	// Token: 0x0600283E RID: 10302 RVA: 0x0009A000 File Offset: 0x00098200
	public bool Equals(TItem obj)
	{
		if (obj)
		{
			return obj.Equals(this);
		}
		return this.node == null || !this.node.self;
	}

	// Token: 0x0600283F RID: 10303 RVA: 0x0009A064 File Offset: 0x00098264
	public static bool operator ==(global::ODBItem<TItem> L, global::ODBItem<TItem> R)
	{
		return L.node == R.node;
	}

	// Token: 0x06002840 RID: 10304 RVA: 0x0009A078 File Offset: 0x00098278
	public static bool operator !=(global::ODBItem<TItem> L, global::ODBItem<TItem> R)
	{
		return L.node != R.node;
	}

	// Token: 0x06002841 RID: 10305 RVA: 0x0009A090 File Offset: 0x00098290
	public static bool operator ==(global::ODBItem<TItem> L, TItem R)
	{
		return L.Equals(R);
	}

	// Token: 0x06002842 RID: 10306 RVA: 0x0009A09C File Offset: 0x0009829C
	public static bool operator !=(global::ODBItem<TItem> L, TItem R)
	{
		return !L.Equals(R);
	}

	// Token: 0x06002843 RID: 10307 RVA: 0x0009A0AC File Offset: 0x000982AC
	public static bool operator ==(TItem L, global::ODBItem<TItem> R)
	{
		return R.Equals(L);
	}

	// Token: 0x06002844 RID: 10308 RVA: 0x0009A0B8 File Offset: 0x000982B8
	public static bool operator !=(TItem L, global::ODBItem<TItem> R)
	{
		return !R.Equals(L);
	}

	// Token: 0x06002845 RID: 10309 RVA: 0x0009A0C8 File Offset: 0x000982C8
	public static implicit operator TItem(global::ODBItem<TItem> item)
	{
		if (item.node != null)
		{
			return item.node.self;
		}
		return (TItem)((object)null);
	}

	// Token: 0x0400140E RID: 5134
	internal global::ODBNode<TItem> node;
}
