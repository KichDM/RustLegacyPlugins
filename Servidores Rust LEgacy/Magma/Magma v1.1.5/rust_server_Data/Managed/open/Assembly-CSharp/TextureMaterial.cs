using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200096C RID: 2412
public static class TextureMaterial
{
	// Token: 0x0600522D RID: 21037 RVA: 0x00151140 File Offset: 0x0014F340
	// Note: this type is marked as 'beforefieldinit'.
	static TextureMaterial()
	{
	}

	// Token: 0x0600522E RID: 21038 RVA: 0x0015114C File Offset: 0x0014F34C
	public static global::UnityEngine.Material GetMaterial(global::UnityEngine.Material skeleton, global::UnityEngine.Texture mainTex)
	{
		if (!skeleton)
		{
			return null;
		}
		global::System.Collections.Generic.Dictionary<global::UnityEngine.Texture, global::UnityEngine.Material> dictionary;
		if (!global::TextureMaterial.dict.TryGetValue(skeleton, out dictionary))
		{
			global::UnityEngine.Material material = new global::UnityEngine.Material(skeleton);
			material.mainTexture = mainTex;
			dictionary = new global::System.Collections.Generic.Dictionary<global::UnityEngine.Texture, global::UnityEngine.Material>();
			dictionary.Add(mainTex, material);
			global::TextureMaterial.dict.Add(skeleton, dictionary);
			return material;
		}
		global::UnityEngine.Material result;
		if (!dictionary.TryGetValue(mainTex, out result))
		{
			global::UnityEngine.Material material2 = new global::UnityEngine.Material(skeleton);
			material2.mainTexture = mainTex;
			dictionary.Add(mainTex, material2);
			return material2;
		}
		return result;
	}

	// Token: 0x04002E8A RID: 11914
	private static global::System.Collections.Generic.Dictionary<global::UnityEngine.Material, global::System.Collections.Generic.Dictionary<global::UnityEngine.Texture, global::UnityEngine.Material>> dict = new global::System.Collections.Generic.Dictionary<global::UnityEngine.Material, global::System.Collections.Generic.Dictionary<global::UnityEngine.Texture, global::UnityEngine.Material>>();
}
