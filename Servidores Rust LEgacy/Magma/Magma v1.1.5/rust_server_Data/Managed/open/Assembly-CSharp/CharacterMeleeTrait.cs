using System;
using UnityEngine;

// Token: 0x02000135 RID: 309
public class CharacterMeleeTrait : global::CharacterTrait
{
	// Token: 0x060007A6 RID: 1958 RVA: 0x000211B0 File Offset: 0x0001F3B0
	public CharacterMeleeTrait()
	{
	}

	// Token: 0x17000196 RID: 406
	// (get) Token: 0x060007A7 RID: 1959 RVA: 0x000211D0 File Offset: 0x0001F3D0
	public float minDamage
	{
		get
		{
			return this._minDamage;
		}
	}

	// Token: 0x17000197 RID: 407
	// (get) Token: 0x060007A8 RID: 1960 RVA: 0x000211D8 File Offset: 0x0001F3D8
	public float maxDamage
	{
		get
		{
			return this._maxDamage;
		}
	}

	// Token: 0x17000198 RID: 408
	// (get) Token: 0x060007A9 RID: 1961 RVA: 0x000211E0 File Offset: 0x0001F3E0
	public float randomDamage
	{
		get
		{
			return this._minDamage + (this._maxDamage - this._minDamage) * global::UnityEngine.Random.value;
		}
	}

	// Token: 0x04000608 RID: 1544
	[global::UnityEngine.SerializeField]
	private float _minDamage = 15f;

	// Token: 0x04000609 RID: 1545
	[global::UnityEngine.SerializeField]
	private float _maxDamage = 25f;
}
