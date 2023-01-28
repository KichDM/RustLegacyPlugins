using System;
using UnityEngine;

// Token: 0x020005DB RID: 1499
public class GameGizmoWaveAnimation : global::GameGizmo
{
	// Token: 0x060030DA RID: 12506 RVA: 0x000BA1C8 File Offset: 0x000B83C8
	public GameGizmoWaveAnimation()
	{
	}

	// Token: 0x04001A88 RID: 6792
	[global::UnityEngine.SerializeField]
	protected float frequency = 1.2566371f;

	// Token: 0x04001A89 RID: 6793
	[global::UnityEngine.SerializeField]
	protected float amplitudePositive = 0.15f;

	// Token: 0x04001A8A RID: 6794
	[global::UnityEngine.SerializeField]
	protected float amplitudeNegative = -0.1f;

	// Token: 0x04001A8B RID: 6795
	[global::UnityEngine.SerializeField]
	protected float phase;

	// Token: 0x04001A8C RID: 6796
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Vector3 axis = global::UnityEngine.Vector3.up;
}
