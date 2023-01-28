using System;
using UnityEngine;

// Token: 0x02000146 RID: 326
public class CharacterWalkSpeedTrait : global::CharacterTrait
{
	// Token: 0x06000882 RID: 2178 RVA: 0x000241FC File Offset: 0x000223FC
	public CharacterWalkSpeedTrait()
	{
	}

	// Token: 0x170001E1 RID: 481
	// (get) Token: 0x06000883 RID: 2179 RVA: 0x00024228 File Offset: 0x00022428
	public float jog
	{
		get
		{
			return this._jog;
		}
	}

	// Token: 0x170001E2 RID: 482
	// (get) Token: 0x06000884 RID: 2180 RVA: 0x00024230 File Offset: 0x00022430
	public float run
	{
		get
		{
			return this._run;
		}
	}

	// Token: 0x170001E3 RID: 483
	// (get) Token: 0x06000885 RID: 2181 RVA: 0x00024238 File Offset: 0x00022438
	public float walk
	{
		get
		{
			return this._walk;
		}
	}

	// Token: 0x06000886 RID: 2182 RVA: 0x00024240 File Offset: 0x00022440
	public bool IsRunningAtSpeed(float metersPerSecond)
	{
		return (this._jog >= this._run) ? (this._run > metersPerSecond) : (this._run <= metersPerSecond);
	}

	// Token: 0x06000887 RID: 2183 RVA: 0x00024270 File Offset: 0x00022470
	public bool IsJoggingOrRunningAtSpeed(float metersPerSecond)
	{
		return (this._jog >= this._run) ? (this._run <= metersPerSecond) : (this._jog <= metersPerSecond);
	}

	// Token: 0x0400065C RID: 1628
	[global::UnityEngine.SerializeField]
	private float _jog = 3f;

	// Token: 0x0400065D RID: 1629
	[global::UnityEngine.SerializeField]
	private float _run = 6f;

	// Token: 0x0400065E RID: 1630
	[global::UnityEngine.SerializeField]
	private float _walk = 1.8f;
}
