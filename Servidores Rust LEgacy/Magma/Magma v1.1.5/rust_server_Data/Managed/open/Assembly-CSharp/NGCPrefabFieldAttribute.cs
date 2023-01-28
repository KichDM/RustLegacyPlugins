using System;
using Facepunch.Attributes;
using UnityEngine;

// Token: 0x020004F6 RID: 1270
public sealed class NGCPrefabFieldAttribute : global::Facepunch.Attributes.ObjectLookupFieldFixedTypeAttribute
{
	// Token: 0x06002BC9 RID: 11209 RVA: 0x000A4288 File Offset: 0x000A2488
	public NGCPrefabFieldAttribute() : base(global::Facepunch.Attributes.PrefabLookupKinds.NGC, typeof(global::UnityEngine.GameObject), global::Facepunch.Attributes.SearchMode.MainAsset, null)
	{
	}
}
