using System;
using UnityEngine;

// Token: 0x02000134 RID: 308
public class CharacterItemDropPrefabTrait : global::CharacterTrait
{
	// Token: 0x060007A4 RID: 1956 RVA: 0x000211A0 File Offset: 0x0001F3A0
	public CharacterItemDropPrefabTrait()
	{
	}

	// Token: 0x17000195 RID: 405
	// (get) Token: 0x060007A5 RID: 1957 RVA: 0x000211A8 File Offset: 0x0001F3A8
	public global::UnityEngine.GameObject prefab
	{
		get
		{
			return this._prefab;
		}
	}

	// Token: 0x04000607 RID: 1543
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.GameObject _prefab;
}
