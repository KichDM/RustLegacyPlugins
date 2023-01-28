using System;
using UnityEngine;

// Token: 0x02000579 RID: 1401
public class CharacterContextProbeTrait : global::CharacterTrait
{
	// Token: 0x06002F18 RID: 12056 RVA: 0x000B3C68 File Offset: 0x000B1E68
	public CharacterContextProbeTrait()
	{
	}

	// Token: 0x170009FC RID: 2556
	// (get) Token: 0x06002F19 RID: 12057 RVA: 0x000B3C7C File Offset: 0x000B1E7C
	public float rayLength
	{
		get
		{
			return this._rayLength;
		}
	}

	// Token: 0x040018F5 RID: 6389
	[global::UnityEngine.SerializeField]
	private float _rayLength = 3f;
}
