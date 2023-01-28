using System;
using UnityEngine;

// Token: 0x0200013A RID: 314
public class CharacterRagdollTrait : global::CharacterTrait
{
	// Token: 0x060007C6 RID: 1990 RVA: 0x000214EC File Offset: 0x0001F6EC
	public CharacterRagdollTrait()
	{
	}

	// Token: 0x170001AC RID: 428
	// (get) Token: 0x060007C7 RID: 1991 RVA: 0x000214F4 File Offset: 0x0001F6F4
	public global::UnityEngine.GameObject ragdollPrefab
	{
		get
		{
			return this._ragdollPrefab;
		}
	}

	// Token: 0x0400061D RID: 1565
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.GameObject _ragdollPrefab;
}
