using System;
using UnityEngine;

// Token: 0x02000051 RID: 81
public class FPGrassProbabilities : global::UnityEngine.ScriptableObject, global::IFPGrassAsset
{
	// Token: 0x06000281 RID: 641 RVA: 0x0000D044 File Offset: 0x0000B244
	public FPGrassProbabilities()
	{
	}

	// Token: 0x040001C8 RID: 456
	[global::System.Obsolete]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Texture2D probabilityTexture;

	// Token: 0x040001C9 RID: 457
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Color[] pixels;
}
