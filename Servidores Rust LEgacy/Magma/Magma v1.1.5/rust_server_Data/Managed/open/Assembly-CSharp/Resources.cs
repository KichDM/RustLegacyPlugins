using System;
using UnityEngine;

// Token: 0x020001DE RID: 478
public static class Resources
{
	// Token: 0x06000D97 RID: 3479 RVA: 0x000351A4 File Offset: 0x000333A4
	[global::System.Obsolete("Do not use Resources. Use Bundles.", false)]
	public static global::UnityEngine.Object Load(string path)
	{
		return global::UnityEngine.Resources.Load(path);
	}

	// Token: 0x06000D98 RID: 3480 RVA: 0x000351AC File Offset: 0x000333AC
	[global::System.Obsolete("Do not use Resources. Use Bundles.", false)]
	public static global::UnityEngine.Object Load(string path, global::System.Type type)
	{
		return global::UnityEngine.Resources.Load(path, type);
	}

	// Token: 0x06000D99 RID: 3481 RVA: 0x000351B8 File Offset: 0x000333B8
	[global::System.Obsolete("Do not use Resources. Use Bundles.", false)]
	public static global::UnityEngine.Object[] LoadAll(string path)
	{
		return global::UnityEngine.Resources.LoadAll(path);
	}

	// Token: 0x06000D9A RID: 3482 RVA: 0x000351C0 File Offset: 0x000333C0
	[global::System.Obsolete("Do not use Resources. Use Bundles.", false)]
	public static global::UnityEngine.Object[] LoadAll(string path, global::System.Type type)
	{
		return global::UnityEngine.Resources.LoadAll(path, type);
	}

	// Token: 0x06000D9B RID: 3483 RVA: 0x000351CC File Offset: 0x000333CC
	public static void UnloadAsset(global::UnityEngine.Object assetToUnload)
	{
		global::UnityEngine.Resources.UnloadAsset(assetToUnload);
	}

	// Token: 0x06000D9C RID: 3484 RVA: 0x000351D4 File Offset: 0x000333D4
	public static global::UnityEngine.AsyncOperation UnloadUnusedAssets()
	{
		return global::UnityEngine.Resources.UnloadUnusedAssets();
	}

	// Token: 0x06000D9D RID: 3485 RVA: 0x000351DC File Offset: 0x000333DC
	public static global::UnityEngine.Object[] FindObjectsOfTypeAll(global::System.Type type)
	{
		return global::UnityEngine.Resources.FindObjectsOfTypeAll(type);
	}

	// Token: 0x04000897 RID: 2199
	private const string kDontUse = "Do not use Resources. Use Bundles.";

	// Token: 0x04000898 RID: 2200
	private const bool kErrorNotWarning = false;
}
