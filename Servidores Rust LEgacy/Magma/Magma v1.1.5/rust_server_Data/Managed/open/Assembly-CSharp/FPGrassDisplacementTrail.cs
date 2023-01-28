using System;
using UnityEngine;

// Token: 0x02000048 RID: 72
public class FPGrassDisplacementTrail : global::FPGrassDisplacementObject
{
	// Token: 0x06000277 RID: 631 RVA: 0x0000CF18 File Offset: 0x0000B118
	public FPGrassDisplacementTrail()
	{
	}

	// Token: 0x06000278 RID: 632 RVA: 0x0000CF20 File Offset: 0x0000B120
	public override void Initialize()
	{
		this._trail = base.GetComponent<global::UnityEngine.TrailRenderer>();
	}

	// Token: 0x06000279 RID: 633 RVA: 0x0000CF30 File Offset: 0x0000B130
	public override void DetachAndDestroy()
	{
		base.transform.parent = null;
		global::UnityEngine.Object.Destroy(base.gameObject, this._trail.time * 1.5f);
	}

	// Token: 0x040001A1 RID: 417
	public global::UnityEngine.TrailRenderer _trail;
}
