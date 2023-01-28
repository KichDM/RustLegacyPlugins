using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020007D3 RID: 2003
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Animation Clip")]
public class dfAnimationClip : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004234 RID: 16948 RVA: 0x000F0B9C File Offset: 0x000EED9C
	public dfAnimationClip()
	{
	}

	// Token: 0x17000C27 RID: 3111
	// (get) Token: 0x06004235 RID: 16949 RVA: 0x000F0BB0 File Offset: 0x000EEDB0
	// (set) Token: 0x06004236 RID: 16950 RVA: 0x000F0BB8 File Offset: 0x000EEDB8
	public global::dfAtlas Atlas
	{
		get
		{
			return this.atlas;
		}
		set
		{
			this.atlas = value;
		}
	}

	// Token: 0x17000C28 RID: 3112
	// (get) Token: 0x06004237 RID: 16951 RVA: 0x000F0BC4 File Offset: 0x000EEDC4
	public global::System.Collections.Generic.List<string> Sprites
	{
		get
		{
			return this.sprites;
		}
	}

	// Token: 0x04002367 RID: 9063
	[global::UnityEngine.SerializeField]
	private global::dfAtlas atlas;

	// Token: 0x04002368 RID: 9064
	[global::UnityEngine.SerializeField]
	private global::System.Collections.Generic.List<string> sprites = new global::System.Collections.Generic.List<string>();
}
