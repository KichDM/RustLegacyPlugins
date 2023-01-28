using System;
using UnityEngine;

// Token: 0x02000138 RID: 312
public class CharacterOverlayTrait : global::CharacterTrait
{
	// Token: 0x060007BB RID: 1979 RVA: 0x000213A0 File Offset: 0x0001F5A0
	public CharacterOverlayTrait()
	{
	}

	// Token: 0x170001A7 RID: 423
	// (get) Token: 0x060007BC RID: 1980 RVA: 0x000213B4 File Offset: 0x0001F5B4
	public string overlayComponentName
	{
		get
		{
			return this._overlayComponentName;
		}
	}

	// Token: 0x170001A8 RID: 424
	// (get) Token: 0x060007BD RID: 1981 RVA: 0x000213BC File Offset: 0x0001F5BC
	public global::UnityEngine.Texture2D damageOverlay
	{
		get
		{
			return this._damageOverlay;
		}
	}

	// Token: 0x170001A9 RID: 425
	// (get) Token: 0x060007BE RID: 1982 RVA: 0x000213C4 File Offset: 0x0001F5C4
	public global::UnityEngine.Texture2D damageOverlay2
	{
		get
		{
			return this._damageOverlay2;
		}
	}

	// Token: 0x170001AA RID: 426
	// (get) Token: 0x060007BF RID: 1983 RVA: 0x000213CC File Offset: 0x0001F5CC
	public global::UnityEngine.ScriptableObject takeDamageBob
	{
		get
		{
			return this._takeDamageBob;
		}
	}

	// Token: 0x170001AB RID: 427
	// (get) Token: 0x060007C0 RID: 1984 RVA: 0x000213D4 File Offset: 0x0001F5D4
	public global::UnityEngine.ScriptableObject meleeBob
	{
		get
		{
			return this._meleeBob;
		}
	}

	// Token: 0x04000618 RID: 1560
	[global::UnityEngine.SerializeField]
	private string _overlayComponentName = "LocalDamageDisplay";

	// Token: 0x04000619 RID: 1561
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Texture2D _damageOverlay;

	// Token: 0x0400061A RID: 1562
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Texture2D _damageOverlay2;

	// Token: 0x0400061B RID: 1563
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.ScriptableObject _takeDamageBob;

	// Token: 0x0400061C RID: 1564
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.ScriptableObject _meleeBob;
}
