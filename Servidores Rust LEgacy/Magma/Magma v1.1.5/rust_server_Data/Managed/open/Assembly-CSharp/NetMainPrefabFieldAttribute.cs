using System;
using Facepunch.Attributes;

// Token: 0x020004F3 RID: 1267
public sealed class NetMainPrefabFieldAttribute : global::Facepunch.Attributes.ObjectLookupFieldFixedTypeAttribute
{
	// Token: 0x06002BC6 RID: 11206 RVA: 0x000A4240 File Offset: 0x000A2440
	public NetMainPrefabFieldAttribute() : base(global::Facepunch.Attributes.PrefabLookupKinds.NetMain, typeof(global::NetMainPrefab), global::Facepunch.Attributes.SearchMode.MainAsset, null)
	{
	}
}
