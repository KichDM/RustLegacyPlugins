using System;
using UnityEngine;

// Token: 0x02000136 RID: 310
public class CharacterNPCHealthTrait : global::CharacterTrait
{
	// Token: 0x060007AA RID: 1962 RVA: 0x000211FC File Offset: 0x0001F3FC
	public CharacterNPCHealthTrait()
	{
	}

	// Token: 0x17000199 RID: 409
	// (get) Token: 0x060007AB RID: 1963 RVA: 0x00021204 File Offset: 0x0001F404
	public float initialHealth
	{
		get
		{
			return this._initialHealth;
		}
	}

	// Token: 0x0400060A RID: 1546
	[global::UnityEngine.SerializeField]
	private float _initialHealth;
}
