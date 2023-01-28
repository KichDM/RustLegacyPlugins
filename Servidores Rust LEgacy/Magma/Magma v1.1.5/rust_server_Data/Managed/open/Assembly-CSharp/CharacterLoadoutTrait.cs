using System;
using UnityEngine;

// Token: 0x0200057D RID: 1405
public class CharacterLoadoutTrait : global::CharacterTrait
{
	// Token: 0x06002F27 RID: 12071 RVA: 0x000B3D64 File Offset: 0x000B1F64
	public CharacterLoadoutTrait()
	{
	}

	// Token: 0x17000A07 RID: 2567
	// (get) Token: 0x06002F28 RID: 12072 RVA: 0x000B3D6C File Offset: 0x000B1F6C
	public global::Loadout loadout
	{
		get
		{
			return this._loadout;
		}
	}

	// Token: 0x040018FD RID: 6397
	[global::UnityEngine.SerializeField]
	private global::Loadout _loadout;
}
