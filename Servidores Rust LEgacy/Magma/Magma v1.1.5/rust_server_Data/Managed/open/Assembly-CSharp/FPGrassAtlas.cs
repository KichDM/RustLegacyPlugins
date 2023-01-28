using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200004D RID: 77
public class FPGrassAtlas : global::UnityEngine.ScriptableObject, global::IFPGrassAsset
{
	// Token: 0x0600027D RID: 637 RVA: 0x0000D000 File Offset: 0x0000B200
	public FPGrassAtlas()
	{
	}

	// Token: 0x040001B7 RID: 439
	public const int max_textures = 0x10;

	// Token: 0x040001B8 RID: 440
	public global::System.Collections.Generic.List<global::FPGrassProperty> properties = new global::System.Collections.Generic.List<global::FPGrassProperty>();

	// Token: 0x040001B9 RID: 441
	public global::System.Collections.Generic.List<global::UnityEngine.Texture2D> textures = new global::System.Collections.Generic.List<global::UnityEngine.Texture2D>();

	// Token: 0x040001BA RID: 442
	public global::UnityEngine.Texture2D textureAtlas;
}
