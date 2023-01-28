using System;
using UnityEngine;

// Token: 0x020009B2 RID: 2482
public class TerrainQualitySettings : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005352 RID: 21330 RVA: 0x0015DF38 File Offset: 0x0015C138
	public TerrainQualitySettings()
	{
	}

	// Token: 0x06005353 RID: 21331 RVA: 0x0015DF40 File Offset: 0x0015C140
	private void Start()
	{
		this.UpdateQuality();
	}

	// Token: 0x06005354 RID: 21332 RVA: 0x0015DF48 File Offset: 0x0015C148
	private void UpdateQuality()
	{
		global::UnityEngine.Debug.Log("updating terrain quality");
		switch (global::UnityEngine.QualitySettings.currentLevel)
		{
		case 0:
			global::UnityEngine.Terrain.activeTerrain.treeDistance = 250f;
			global::UnityEngine.Terrain.activeTerrain.treeBillboardDistance = 30f;
			global::UnityEngine.Terrain.activeTerrain.treeCrossFadeLength = 5f;
			global::UnityEngine.Terrain.activeTerrain.treeMaximumFullLODCount = 5;
			global::UnityEngine.Terrain.activeTerrain.detailObjectDistance = 30f;
			global::UnityEngine.Terrain.activeTerrain.heightmapPixelError = 20f;
			global::UnityEngine.Terrain.activeTerrain.heightmapMaximumLOD = 1;
			global::UnityEngine.Terrain.activeTerrain.basemapDistance = 100f;
			break;
		case 1:
			global::UnityEngine.Terrain.activeTerrain.treeDistance = 500f;
			global::UnityEngine.Terrain.activeTerrain.treeBillboardDistance = 50f;
			global::UnityEngine.Terrain.activeTerrain.treeCrossFadeLength = 10f;
			global::UnityEngine.Terrain.activeTerrain.treeMaximumFullLODCount = 0xA;
			global::UnityEngine.Terrain.activeTerrain.detailObjectDistance = 40f;
			global::UnityEngine.Terrain.activeTerrain.heightmapPixelError = 10f;
			global::UnityEngine.Terrain.activeTerrain.heightmapMaximumLOD = 1;
			global::UnityEngine.Terrain.activeTerrain.basemapDistance = 250f;
			break;
		case 2:
			global::UnityEngine.Terrain.activeTerrain.treeDistance = 650f;
			global::UnityEngine.Terrain.activeTerrain.treeBillboardDistance = 75f;
			global::UnityEngine.Terrain.activeTerrain.treeCrossFadeLength = 25f;
			global::UnityEngine.Terrain.activeTerrain.treeMaximumFullLODCount = 0x14;
			global::UnityEngine.Terrain.activeTerrain.detailObjectDistance = 60f;
			global::UnityEngine.Terrain.activeTerrain.heightmapPixelError = 8f;
			global::UnityEngine.Terrain.activeTerrain.heightmapMaximumLOD = 0;
			global::UnityEngine.Terrain.activeTerrain.basemapDistance = 500f;
			break;
		case 3:
			global::UnityEngine.Terrain.activeTerrain.treeDistance = 800f;
			global::UnityEngine.Terrain.activeTerrain.treeBillboardDistance = 100f;
			global::UnityEngine.Terrain.activeTerrain.treeCrossFadeLength = 40f;
			global::UnityEngine.Terrain.activeTerrain.treeMaximumFullLODCount = 0x1E;
			global::UnityEngine.Terrain.activeTerrain.detailObjectDistance = 75f;
			global::UnityEngine.Terrain.activeTerrain.heightmapPixelError = 5f;
			global::UnityEngine.Terrain.activeTerrain.heightmapMaximumLOD = 0;
			global::UnityEngine.Terrain.activeTerrain.basemapDistance = 800f;
			break;
		case 4:
			global::UnityEngine.Terrain.activeTerrain.treeDistance = 1000f;
			global::UnityEngine.Terrain.activeTerrain.treeBillboardDistance = 150f;
			global::UnityEngine.Terrain.activeTerrain.treeCrossFadeLength = 50f;
			global::UnityEngine.Terrain.activeTerrain.treeMaximumFullLODCount = 0x32;
			global::UnityEngine.Terrain.activeTerrain.detailObjectDistance = 100f;
			global::UnityEngine.Terrain.activeTerrain.heightmapPixelError = 5f;
			global::UnityEngine.Terrain.activeTerrain.heightmapMaximumLOD = 0;
			global::UnityEngine.Terrain.activeTerrain.basemapDistance = 1000f;
			break;
		case 5:
			global::UnityEngine.Terrain.activeTerrain.treeDistance = 2000f;
			global::UnityEngine.Terrain.activeTerrain.treeBillboardDistance = 250f;
			global::UnityEngine.Terrain.activeTerrain.treeCrossFadeLength = 50f;
			global::UnityEngine.Terrain.activeTerrain.treeMaximumFullLODCount = 0x64;
			global::UnityEngine.Terrain.activeTerrain.detailObjectDistance = 200f;
			global::UnityEngine.Terrain.activeTerrain.heightmapPixelError = 5f;
			global::UnityEngine.Terrain.activeTerrain.heightmapMaximumLOD = 0;
			global::UnityEngine.Terrain.activeTerrain.basemapDistance = 1000f;
			break;
		}
	}
}
