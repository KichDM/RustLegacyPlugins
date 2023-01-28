using System;
using UnityEngine;

// Token: 0x0200057E RID: 1406
public class CharacterMetabolismTrait : global::CharacterTrait
{
	// Token: 0x06002F29 RID: 12073 RVA: 0x000B3D74 File Offset: 0x000B1F74
	public CharacterMetabolismTrait()
	{
	}

	// Token: 0x17000A08 RID: 2568
	// (get) Token: 0x06002F2A RID: 12074 RVA: 0x000B3D94 File Offset: 0x000B1F94
	public float tickRate
	{
		get
		{
			return this._tickRate;
		}
	}

	// Token: 0x17000A09 RID: 2569
	// (get) Token: 0x06002F2B RID: 12075 RVA: 0x000B3D9C File Offset: 0x000B1F9C
	public bool selfTick
	{
		get
		{
			return this._selfTick;
		}
	}

	// Token: 0x17000A0A RID: 2570
	// (get) Token: 0x06002F2C RID: 12076 RVA: 0x000B3DA4 File Offset: 0x000B1FA4
	public float hungerDamagePerMin
	{
		get
		{
			return this._hungerDamagePerMin;
		}
	}

	// Token: 0x040018FE RID: 6398
	[global::UnityEngine.SerializeField]
	private float _tickRate = 3f;

	// Token: 0x040018FF RID: 6399
	[global::UnityEngine.SerializeField]
	private bool _selfTick;

	// Token: 0x04001900 RID: 6400
	[global::UnityEngine.SerializeField]
	private float _hungerDamagePerMin = 5f;
}
