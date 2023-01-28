using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000049 RID: 73
[global::UnityEngine.ExecuteInEditMode]
public class FPGrass : global::UnityEngine.MonoBehaviour, global::IFPGrassAsset
{
	// Token: 0x0600027A RID: 634 RVA: 0x0000CF68 File Offset: 0x0000B168
	public FPGrass()
	{
	}

	// Token: 0x040001A2 RID: 418
	[global::UnityEngine.SerializeField]
	private global::System.Collections.Generic.List<global::FPGrassLevel> children = new global::System.Collections.Generic.List<global::FPGrassLevel>();

	// Token: 0x040001A3 RID: 419
	public global::UnityEngine.Camera parentCamera;

	// Token: 0x040001A4 RID: 420
	public int numberOfLevels = 4;

	// Token: 0x040001A5 RID: 421
	public float baseLevelSize = 20f;

	// Token: 0x040001A6 RID: 422
	public int gridSizePerLevel = 0x1C;

	// Token: 0x040001A7 RID: 423
	[global::UnityEngine.SerializeField]
	private float gridSizeAtFinestLevel;

	// Token: 0x040001A8 RID: 424
	public global::UnityEngine.Material material;

	// Token: 0x040001A9 RID: 425
	[global::UnityEngine.SerializeField]
	private float scatterAmount = 1f;

	// Token: 0x040001AA RID: 426
	[global::UnityEngine.SerializeField]
	private float normalBias = 0.7f;

	// Token: 0x040001AB RID: 427
	public global::FPGrassProbabilities grassProbabilities;

	// Token: 0x040001AC RID: 428
	public global::FPGrassAtlas grassAtlas;

	// Token: 0x040001AD RID: 429
	public bool followSceneCamera;

	// Token: 0x040001AE RID: 430
	public bool toggleWireframe;

	// Token: 0x040001AF RID: 431
	[global::UnityEngine.SerializeField]
	private float windSpeed = 0.1f;

	// Token: 0x040001B0 RID: 432
	[global::UnityEngine.SerializeField]
	private float windSize = 1f;

	// Token: 0x040001B1 RID: 433
	[global::UnityEngine.SerializeField]
	private float windBending = 1f;

	// Token: 0x040001B2 RID: 434
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Color windTint = global::UnityEngine.Color.white;

	// Token: 0x040001B3 RID: 435
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Texture2D heightMap;

	// Token: 0x040001B4 RID: 436
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Texture2D normalMap;

	// Token: 0x040001B5 RID: 437
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Texture2D splatMap;
}
