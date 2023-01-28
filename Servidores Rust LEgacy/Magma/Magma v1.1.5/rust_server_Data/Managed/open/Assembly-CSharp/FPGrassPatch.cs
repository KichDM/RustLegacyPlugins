using System;
using UnityEngine;

// Token: 0x02000050 RID: 80
public class FPGrassPatch : global::UnityEngine.MonoBehaviour, global::IFPGrassAsset
{
	// Token: 0x06000280 RID: 640 RVA: 0x0000D03C File Offset: 0x0000B23C
	public FPGrassPatch()
	{
	}

	// Token: 0x040001C5 RID: 453
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Mesh mesh;

	// Token: 0x040001C6 RID: 454
	[global::UnityEngine.SerializeField]
	private float patchSize;

	// Token: 0x040001C7 RID: 455
	[global::UnityEngine.SerializeField]
	public global::FPGrassLevel level;
}
