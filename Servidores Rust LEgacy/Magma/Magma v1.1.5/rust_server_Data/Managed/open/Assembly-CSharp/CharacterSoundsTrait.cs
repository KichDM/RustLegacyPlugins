using System;
using UnityEngine;

// Token: 0x0200013C RID: 316
public class CharacterSoundsTrait : global::CharacterTrait
{
	// Token: 0x060007E2 RID: 2018 RVA: 0x000219BC File Offset: 0x0001FBBC
	public CharacterSoundsTrait()
	{
	}

	// Token: 0x170001C6 RID: 454
	// (get) Token: 0x060007E3 RID: 2019 RVA: 0x000219C4 File Offset: 0x0001FBC4
	public global::AudioClipArray attack
	{
		get
		{
			return this._attack;
		}
	}

	// Token: 0x170001C7 RID: 455
	// (get) Token: 0x060007E4 RID: 2020 RVA: 0x000219CC File Offset: 0x0001FBCC
	public global::AudioClipArray alert
	{
		get
		{
			return this._alert;
		}
	}

	// Token: 0x170001C8 RID: 456
	// (get) Token: 0x060007E5 RID: 2021 RVA: 0x000219D4 File Offset: 0x0001FBD4
	public global::AudioClipArray idle
	{
		get
		{
			return this._idle;
		}
	}

	// Token: 0x170001C9 RID: 457
	// (get) Token: 0x060007E6 RID: 2022 RVA: 0x000219DC File Offset: 0x0001FBDC
	public global::AudioClipArray persuit
	{
		get
		{
			return this._persuit;
		}
	}

	// Token: 0x170001CA RID: 458
	// (get) Token: 0x060007E7 RID: 2023 RVA: 0x000219E4 File Offset: 0x0001FBE4
	public global::AudioClipArray impact
	{
		get
		{
			return this._impact;
		}
	}

	// Token: 0x170001CB RID: 459
	// (get) Token: 0x060007E8 RID: 2024 RVA: 0x000219EC File Offset: 0x0001FBEC
	public global::AudioClipArray death
	{
		get
		{
			return this._death;
		}
	}

	// Token: 0x0400062C RID: 1580
	[global::UnityEngine.SerializeField]
	private global::AudioClipArray _attack;

	// Token: 0x0400062D RID: 1581
	[global::UnityEngine.SerializeField]
	private global::AudioClipArray _alert;

	// Token: 0x0400062E RID: 1582
	[global::UnityEngine.SerializeField]
	private global::AudioClipArray _idle;

	// Token: 0x0400062F RID: 1583
	[global::UnityEngine.SerializeField]
	private global::AudioClipArray _persuit;

	// Token: 0x04000630 RID: 1584
	[global::UnityEngine.SerializeField]
	private global::AudioClipArray _impact;

	// Token: 0x04000631 RID: 1585
	[global::UnityEngine.SerializeField]
	private global::AudioClipArray _death;
}
