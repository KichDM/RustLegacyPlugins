using System;
using UnityEngine;

// Token: 0x02000616 RID: 1558
public class TerrainTextureHelper
{
	// Token: 0x06003198 RID: 12696 RVA: 0x000BE720 File Offset: 0x000BC920
	public TerrainTextureHelper()
	{
	}

	// Token: 0x06003199 RID: 12697 RVA: 0x000BE728 File Offset: 0x000BC928
	// Note: this type is marked as 'beforefieldinit'.
	static TerrainTextureHelper()
	{
	}

	// Token: 0x0600319A RID: 12698 RVA: 0x000BE72C File Offset: 0x000BC92C
	public static void EnsureInit()
	{
		if (global::TerrainTextureHelper.cachedTerrain == global::UnityEngine.Terrain.activeTerrain)
		{
			return;
		}
		global::TerrainTextureHelper.CacheTextures();
		global::TerrainTextureHelper.cachedTerrain = global::UnityEngine.Terrain.activeTerrain;
	}

	// Token: 0x0600319B RID: 12699 RVA: 0x000BE760 File Offset: 0x000BC960
	public static void CacheTextures()
	{
		global::UnityEngine.Debug.Log("Caching Terrain splatmap lookups, please wait...");
		global::UnityEngine.Terrain activeTerrain = global::UnityEngine.Terrain.activeTerrain;
		global::UnityEngine.TerrainData terrainData = activeTerrain.terrainData;
		global::UnityEngine.Vector3 position = activeTerrain.transform.position;
		float[,,] alphamaps = terrainData.GetAlphamaps(0, 0, terrainData.alphamapWidth, terrainData.alphamapHeight);
		global::TerrainTextureHelper.textures = new byte[alphamaps.GetUpperBound(0) + 1, alphamaps.GetUpperBound(1) + 1];
		for (int i = 0; i < terrainData.alphamapWidth; i++)
		{
			for (int j = 0; j < terrainData.alphamapHeight; j++)
			{
				float num = 0f;
				int num2 = 0;
				for (int k = 0; k < alphamaps.GetUpperBound(2) + 1; k++)
				{
					if (alphamaps[i, j, k] >= num)
					{
						num2 = k;
						num = alphamaps[i, j, k];
					}
				}
				global::TerrainTextureHelper.textures[i, j] = (byte)num2;
			}
		}
		global::System.GC.Collect(global::System.GC.MaxGeneration, global::System.GCCollectionMode.Forced);
	}

	// Token: 0x0600319C RID: 12700 RVA: 0x000BE860 File Offset: 0x000BCA60
	public static float[] GetTextureAmounts(global::UnityEngine.Vector3 worldPos)
	{
		return global::TerrainTextureHelper.OLD_GetTextureMix(worldPos);
	}

	// Token: 0x0600319D RID: 12701 RVA: 0x000BE868 File Offset: 0x000BCA68
	public static int GetTextureIndex(global::UnityEngine.Vector3 worldPos)
	{
		return global::TerrainTextureHelper.OLD_GetMainTexture(worldPos);
	}

	// Token: 0x0600319E RID: 12702 RVA: 0x000BE87C File Offset: 0x000BCA7C
	public static float[] OLD_GetTextureMix(global::UnityEngine.Vector3 worldPos)
	{
		global::UnityEngine.Terrain activeTerrain = global::UnityEngine.Terrain.activeTerrain;
		global::UnityEngine.TerrainData terrainData = activeTerrain.terrainData;
		global::UnityEngine.Vector3 position = activeTerrain.transform.position;
		int num = (int)((worldPos.x - position.x) / terrainData.size.x * (float)terrainData.alphamapWidth);
		int num2 = (int)((worldPos.z - position.z) / terrainData.size.z * (float)terrainData.alphamapHeight);
		float[,,] alphamaps = terrainData.GetAlphamaps(num, num2, 1, 1);
		float[] array = new float[alphamaps.GetUpperBound(2) + 1];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = alphamaps[0, 0, i];
		}
		return array;
	}

	// Token: 0x0600319F RID: 12703 RVA: 0x000BE940 File Offset: 0x000BCB40
	public static int OLD_GetMainTexture(global::UnityEngine.Vector3 worldPos)
	{
		float[] array = global::TerrainTextureHelper.OLD_GetTextureMix(worldPos);
		float num = 0f;
		int result = 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] > num)
			{
				result = i;
				num = array[i];
			}
		}
		return result;
	}

	// Token: 0x04001BC3 RID: 7107
	public static byte[,] textures;

	// Token: 0x04001BC4 RID: 7108
	public static global::UnityEngine.Terrain cachedTerrain;
}
