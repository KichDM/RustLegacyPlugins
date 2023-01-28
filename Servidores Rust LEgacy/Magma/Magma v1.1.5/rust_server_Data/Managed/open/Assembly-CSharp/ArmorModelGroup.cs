using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000628 RID: 1576
public sealed class ArmorModelGroup : global::UnityEngine.ScriptableObject, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::ArmorModel>
{
	// Token: 0x0600321E RID: 12830 RVA: 0x000BFE9C File Offset: 0x000BE09C
	public ArmorModelGroup()
	{
	}

	// Token: 0x0600321F RID: 12831 RVA: 0x000BFEA4 File Offset: 0x000BE0A4
	global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
	{
		return ((global::System.Collections.IEnumerable)this.collection).GetEnumerator();
	}

	// Token: 0x17000A72 RID: 2674
	public global::ArmorModel this[global::ArmorModelSlot slot]
	{
		get
		{
			return this.collection[slot];
		}
	}

	// Token: 0x06003221 RID: 12833 RVA: 0x000BFEC4 File Offset: 0x000BE0C4
	public T GetArmorModel<T>() where T : global::ArmorModel, new()
	{
		return this.collection.GetArmorModel<T>();
	}

	// Token: 0x06003222 RID: 12834 RVA: 0x000BFED4 File Offset: 0x000BE0D4
	public global::System.Collections.Generic.IEnumerator<global::ArmorModel> GetEnumerator()
	{
		return this.collection.GetEnumerator();
	}

	// Token: 0x17000A73 RID: 2675
	// (get) Token: 0x06003223 RID: 12835 RVA: 0x000BFEE8 File Offset: 0x000BE0E8
	public global::ArmorModelMemberMap armorModelMemberMap
	{
		get
		{
			return this.collection.ToMemberMap();
		}
	}

	// Token: 0x04001BEE RID: 7150
	[global::UnityEngine.SerializeField]
	private global::ArmorModelCollection collection;
}
