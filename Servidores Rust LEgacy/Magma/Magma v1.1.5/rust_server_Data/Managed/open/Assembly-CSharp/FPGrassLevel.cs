using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200004F RID: 79
public class FPGrassLevel : global::UnityEngine.MonoBehaviour, global::IFPGrassAsset
{
	// Token: 0x0600027F RID: 639 RVA: 0x0000D028 File Offset: 0x0000B228
	public FPGrassLevel()
	{
	}

	// Token: 0x040001BB RID: 443
	public int levelNumber;

	// Token: 0x040001BC RID: 444
	public global::UnityEngine.Material levelMaterial;

	// Token: 0x040001BD RID: 445
	public global::FPGrass parent;

	// Token: 0x040001BE RID: 446
	[global::UnityEngine.SerializeField]
	private global::System.Collections.Generic.List<global::FPGrassPatch> children = new global::System.Collections.Generic.List<global::FPGrassPatch>();

	// Token: 0x040001BF RID: 447
	[global::UnityEngine.SerializeField]
	private float gridSpacingAtLevel;

	// Token: 0x040001C0 RID: 448
	[global::UnityEngine.SerializeField]
	private float levelSize;

	// Token: 0x040001C1 RID: 449
	[global::UnityEngine.SerializeField]
	private int gridSize;

	// Token: 0x040001C2 RID: 450
	[global::UnityEngine.SerializeField]
	private int gridSizeAtLevel;

	// Token: 0x040001C3 RID: 451
	private global::UnityEngine.Vector3 lastPosition;

	// Token: 0x040001C4 RID: 452
	public global::FPGrassProbabilityGenerator probabilityGenerator;
}
