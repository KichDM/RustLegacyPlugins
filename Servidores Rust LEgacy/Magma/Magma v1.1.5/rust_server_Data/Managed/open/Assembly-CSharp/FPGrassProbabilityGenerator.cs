using System;
using UnityEngine;

// Token: 0x02000052 RID: 82
public class FPGrassProbabilityGenerator : global::UnityEngine.ScriptableObject, global::IFPGrassAsset
{
	// Token: 0x06000282 RID: 642 RVA: 0x0000D04C File Offset: 0x0000B24C
	public FPGrassProbabilityGenerator()
	{
	}

	// Token: 0x1700006F RID: 111
	// (get) Token: 0x06000283 RID: 643 RVA: 0x0000D054 File Offset: 0x0000B254
	// (set) Token: 0x06000284 RID: 644 RVA: 0x0000D05C File Offset: 0x0000B25C
	public string name
	{
		get
		{
			return base.name;
		}
		set
		{
			base.name = value;
			this.material.name = value + "(" + this.material.name.Replace("(Clone)", string.Empty) + ")";
		}
	}

	// Token: 0x040001CA RID: 458
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Material material;

	// Token: 0x040001CB RID: 459
	[global::UnityEngine.SerializeField]
	public float gridScale;

	// Token: 0x040001CC RID: 460
	[global::UnityEngine.SerializeField]
	public int gridSize;
}
