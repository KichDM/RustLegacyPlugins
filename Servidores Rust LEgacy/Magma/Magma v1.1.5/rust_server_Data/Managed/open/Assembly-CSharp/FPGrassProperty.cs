using System;
using UnityEngine;

// Token: 0x02000053 RID: 83
public class FPGrassProperty : global::UnityEngine.ScriptableObject, global::IFPGrassAsset
{
	// Token: 0x06000285 RID: 645 RVA: 0x0000D0A8 File Offset: 0x0000B2A8
	public FPGrassProperty()
	{
	}

	// Token: 0x040001CD RID: 461
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Color color1 = global::UnityEngine.Color.white;

	// Token: 0x040001CE RID: 462
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Color color2 = global::UnityEngine.Color.white;

	// Token: 0x040001CF RID: 463
	[global::UnityEngine.SerializeField]
	private float minWidth = 1f;

	// Token: 0x040001D0 RID: 464
	[global::UnityEngine.SerializeField]
	private float maxWidth = 1f;

	// Token: 0x040001D1 RID: 465
	[global::UnityEngine.SerializeField]
	private float minHeight = 1f;

	// Token: 0x040001D2 RID: 466
	[global::UnityEngine.SerializeField]
	private float maxHeight = 1f;
}
