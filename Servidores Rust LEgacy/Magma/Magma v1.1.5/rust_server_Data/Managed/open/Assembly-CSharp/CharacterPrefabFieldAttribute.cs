using System;
using Facepunch.Attributes;

// Token: 0x020004F4 RID: 1268
public sealed class CharacterPrefabFieldAttribute : global::Facepunch.Attributes.ObjectLookupFieldFixedTypeAttribute
{
	// Token: 0x06002BC7 RID: 11207 RVA: 0x000A4258 File Offset: 0x000A2458
	public CharacterPrefabFieldAttribute() : base(global::Facepunch.Attributes.PrefabLookupKinds.Character, typeof(global::CharacterPrefab), global::Facepunch.Attributes.SearchMode.MainAsset, null)
	{
	}
}
