using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000868 RID: 2152
public class dfMarkupImageCache
{
	// Token: 0x06004AA3 RID: 19107 RVA: 0x00118890 File Offset: 0x00116A90
	public dfMarkupImageCache()
	{
	}

	// Token: 0x06004AA4 RID: 19108 RVA: 0x00118898 File Offset: 0x00116A98
	// Note: this type is marked as 'beforefieldinit'.
	static dfMarkupImageCache()
	{
	}

	// Token: 0x06004AA5 RID: 19109 RVA: 0x001188A4 File Offset: 0x00116AA4
	public static void Clear()
	{
		global::dfMarkupImageCache.cache.Clear();
	}

	// Token: 0x06004AA6 RID: 19110 RVA: 0x001188B0 File Offset: 0x00116AB0
	public static void Load(string name, global::UnityEngine.Texture image)
	{
		global::dfMarkupImageCache.cache[name.ToLowerInvariant()] = image;
	}

	// Token: 0x06004AA7 RID: 19111 RVA: 0x001188C4 File Offset: 0x00116AC4
	public static void Unload(string name)
	{
		global::dfMarkupImageCache.cache.Remove(name.ToLowerInvariant());
	}

	// Token: 0x06004AA8 RID: 19112 RVA: 0x001188D8 File Offset: 0x00116AD8
	public static global::UnityEngine.Texture Load(string path)
	{
		path = path.ToLowerInvariant();
		if (global::dfMarkupImageCache.cache.ContainsKey(path))
		{
			return global::dfMarkupImageCache.cache[path];
		}
		global::UnityEngine.Texture texture = global::Resources.Load(path) as global::UnityEngine.Texture;
		if (texture != null)
		{
			global::dfMarkupImageCache.cache[path] = texture;
		}
		return texture;
	}

	// Token: 0x040027BB RID: 10171
	private static global::System.Collections.Generic.Dictionary<string, global::UnityEngine.Texture> cache = new global::System.Collections.Generic.Dictionary<string, global::UnityEngine.Texture>();
}
