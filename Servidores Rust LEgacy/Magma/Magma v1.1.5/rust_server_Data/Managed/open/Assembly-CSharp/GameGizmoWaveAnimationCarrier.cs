using System;
using UnityEngine;

// Token: 0x020005DC RID: 1500
public class GameGizmoWaveAnimationCarrier : global::GameGizmoWaveAnimation
{
	// Token: 0x060030DB RID: 12507 RVA: 0x000BA208 File Offset: 0x000B8408
	public GameGizmoWaveAnimationCarrier()
	{
	}

	// Token: 0x04001A8D RID: 6797
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Material[] carrierMaterials;

	// Token: 0x04001A8E RID: 6798
	[global::UnityEngine.SerializeField]
	protected bool hideArrowWhenCarrierExists;
}
