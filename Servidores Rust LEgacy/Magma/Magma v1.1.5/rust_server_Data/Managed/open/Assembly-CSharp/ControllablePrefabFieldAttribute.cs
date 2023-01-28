using System;
using Facepunch.Attributes;

// Token: 0x020004F5 RID: 1269
public sealed class ControllablePrefabFieldAttribute : global::Facepunch.Attributes.ObjectLookupFieldFixedTypeAttribute
{
	// Token: 0x06002BC8 RID: 11208 RVA: 0x000A4270 File Offset: 0x000A2470
	public ControllablePrefabFieldAttribute() : base(global::Facepunch.Attributes.PrefabLookupKinds.Controllable, typeof(global::ControllablePrefab), global::Facepunch.Attributes.SearchMode.MainAsset, null)
	{
	}
}
