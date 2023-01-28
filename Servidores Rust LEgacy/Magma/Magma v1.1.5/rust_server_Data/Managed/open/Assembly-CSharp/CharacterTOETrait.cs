using System;
using UnityEngine;

// Token: 0x02000141 RID: 321
public class CharacterTOETrait : global::CharacterTrait
{
	// Token: 0x0600086D RID: 2157 RVA: 0x00023580 File Offset: 0x00021780
	public CharacterTOETrait()
	{
	}

	// Token: 0x170001DC RID: 476
	// (get) Token: 0x0600086E RID: 2158 RVA: 0x000235C0 File Offset: 0x000217C0
	public float attackMinimumDistance
	{
		get
		{
			return this._attackMinimumDistance;
		}
	}

	// Token: 0x170001DD RID: 477
	// (get) Token: 0x0600086F RID: 2159 RVA: 0x000235C8 File Offset: 0x000217C8
	public float attackMaximumDistance
	{
		get
		{
			return this._attackMaximumDistance;
		}
	}

	// Token: 0x170001DE RID: 478
	// (get) Token: 0x06000870 RID: 2160 RVA: 0x000235D0 File Offset: 0x000217D0
	public float seekMaximumDistance
	{
		get
		{
			return this._seekMaximumDistance;
		}
	}

	// Token: 0x170001DF RID: 479
	// (get) Token: 0x06000871 RID: 2161 RVA: 0x000235D8 File Offset: 0x000217D8
	public float persuitMaximumDistance
	{
		get
		{
			return this._persuitMaximumDistance;
		}
	}

	// Token: 0x170001E0 RID: 480
	// (get) Token: 0x06000872 RID: 2162 RVA: 0x000235E0 File Offset: 0x000217E0
	public float attackDurationInSeconds
	{
		get
		{
			return this._attackDuration;
		}
	}

	// Token: 0x04000654 RID: 1620
	[global::UnityEngine.SerializeField]
	private float _attackMinimumDistance = 1.5f;

	// Token: 0x04000655 RID: 1621
	[global::UnityEngine.SerializeField]
	private float _attackMaximumDistance = 3f;

	// Token: 0x04000656 RID: 1622
	[global::UnityEngine.SerializeField]
	private float _seekMaximumDistance = 30f;

	// Token: 0x04000657 RID: 1623
	[global::UnityEngine.SerializeField]
	private float _persuitMaximumDistance = 40f;

	// Token: 0x04000658 RID: 1624
	[global::UnityEngine.SerializeField]
	private float _attackDuration = 1.5f;
}
