using System;
using UnityEngine;

// Token: 0x0200057A RID: 1402
public class CharacterFootstepTrait : global::CharacterTrait
{
	// Token: 0x06002F1A RID: 12058 RVA: 0x000B3C84 File Offset: 0x000B1E84
	public CharacterFootstepTrait()
	{
	}

	// Token: 0x170009FD RID: 2557
	// (get) Token: 0x06002F1B RID: 12059 RVA: 0x000B3CC4 File Offset: 0x000B1EC4
	public global::AudioClipArray defaultFootsteps
	{
		get
		{
			return this._defaultFootsteps;
		}
	}

	// Token: 0x170009FE RID: 2558
	// (get) Token: 0x06002F1C RID: 12060 RVA: 0x000B3CCC File Offset: 0x000B1ECC
	public float strideDist
	{
		get
		{
			return this._strideDist;
		}
	}

	// Token: 0x170009FF RID: 2559
	// (get) Token: 0x06002F1D RID: 12061 RVA: 0x000B3CD4 File Offset: 0x000B1ED4
	public float sqrStrideDist
	{
		get
		{
			return this._strideDist * this._strideDist;
		}
	}

	// Token: 0x17000A00 RID: 2560
	// (get) Token: 0x06002F1E RID: 12062 RVA: 0x000B3CE4 File Offset: 0x000B1EE4
	public float maxPerSecond
	{
		get
		{
			return this._maxPerSecond;
		}
	}

	// Token: 0x17000A01 RID: 2561
	// (get) Token: 0x06002F1F RID: 12063 RVA: 0x000B3CEC File Offset: 0x000B1EEC
	public float minInterval
	{
		get
		{
			return (!this.timeLimited) ? 0f : (1f / this._maxPerSecond);
		}
	}

	// Token: 0x17000A02 RID: 2562
	// (get) Token: 0x06002F20 RID: 12064 RVA: 0x000B3D10 File Offset: 0x000B1F10
	public bool timeLimited
	{
		get
		{
			return this._maxPerSecond > 0f && !float.IsInfinity(this._maxPerSecond);
		}
	}

	// Token: 0x17000A03 RID: 2563
	// (get) Token: 0x06002F21 RID: 12065 RVA: 0x000B3D34 File Offset: 0x000B1F34
	public float minAudioDist
	{
		get
		{
			return this._minAudioDist;
		}
	}

	// Token: 0x17000A04 RID: 2564
	// (get) Token: 0x06002F22 RID: 12066 RVA: 0x000B3D3C File Offset: 0x000B1F3C
	public float maxAudioDist
	{
		get
		{
			return this._maxAudioDist;
		}
	}

	// Token: 0x17000A05 RID: 2565
	// (get) Token: 0x06002F23 RID: 12067 RVA: 0x000B3D44 File Offset: 0x000B1F44
	public bool animal
	{
		get
		{
			return this._animal;
		}
	}

	// Token: 0x040018F6 RID: 6390
	[global::UnityEngine.SerializeField]
	private global::AudioClipArray _defaultFootsteps;

	// Token: 0x040018F7 RID: 6391
	[global::UnityEngine.SerializeField]
	private float _strideDist = 2.5f;

	// Token: 0x040018F8 RID: 6392
	[global::UnityEngine.SerializeField]
	private float _minAudioDist = 3f;

	// Token: 0x040018F9 RID: 6393
	[global::UnityEngine.SerializeField]
	private float _maxAudioDist = 30f;

	// Token: 0x040018FA RID: 6394
	[global::UnityEngine.SerializeField]
	private bool _animal;

	// Token: 0x040018FB RID: 6395
	[global::UnityEngine.SerializeField]
	private float _maxPerSecond = 6f;
}
