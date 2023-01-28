using System;
using UnityEngine;

// Token: 0x02000578 RID: 1400
public class CharacterArmorTrait : global::CharacterTrait
{
	// Token: 0x06002F16 RID: 12054 RVA: 0x000B3C58 File Offset: 0x000B1E58
	public CharacterArmorTrait()
	{
	}

	// Token: 0x170009FB RID: 2555
	// (get) Token: 0x06002F17 RID: 12055 RVA: 0x000B3C60 File Offset: 0x000B1E60
	public global::ArmorModelGroup defaultGroup
	{
		get
		{
			return this._defaultGroup;
		}
	}

	// Token: 0x040018F4 RID: 6388
	[global::UnityEngine.SerializeField]
	private global::ArmorModelGroup _defaultGroup;
}
